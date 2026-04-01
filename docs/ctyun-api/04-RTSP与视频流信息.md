# RTSP 与视频流信息（精简版）

## 1. 获取 RTSP 直播地址
接口：`/open/token/cloud/getDeviceMediaUrlRtsp`

### 关键点
- 主链路固定使用 RTSP
- 地址短时效、动态分配、非固定
- 不能长期缓存后重复使用
- 客户端按 `rtp over tcp` 使用

### 关键参数
- `deviceCode`
- `mediaType`
- `mute`
- `expire`
- `netType`

### 当前项目建议
- 默认公网 `netType=0`
- 默认静音 `mute=1`
- 优先使用更稳的低码流/标清流

## 2. 获取视频流信息
接口：`/open/token/vpaas/device/getVideoInfo`

### 调用时机
在设备在线并成功拉流播放后调用。

### 关键字段
- `codec`
- `fps`
- `bps`
- `clarity`
- `audioFormat`

## 3. 当前项目视频策略
- 视频主链路：RTSP
- 单点位采用“两轮地址、四次播放尝试”的鲁棒策略
- 成功标准不是拿到地址，而是：
  1. 成功打开
  2. 持续出帧
  3. 稳定观察通过
- 完全无法正常播放也要形成结果，并允许通知
