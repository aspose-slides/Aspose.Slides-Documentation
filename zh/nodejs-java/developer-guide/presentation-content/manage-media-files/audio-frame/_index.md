---
title: 使用 JavaScript 管理演示文稿中的音频
linktitle: 音频帧
type: docs
weight: 10
url: /zh/nodejs-java/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中创建和控制音频帧——提供 JavaScript 示例，实现嵌入、修剪、循环以及在 PPT、PPTX 和 ODP 演示文稿中的播放配置。"
---

## **创建音频帧**

Aspose.Slides for Node.js via Java 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载您想要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 设置由 [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame) 对象公开的 [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 JavaScript 代码演示了如何向幻灯片添加嵌入的音频帧：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类
const pres = new aspose.slides.Presentation();
try {
    // 获取第一页幻灯片
    const sld = pres.getSlides().get_Item(0);
    // 将 wav 音频文件加载为流
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // 添加音频帧
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // 设置音频的播放模式和音量
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // 将 PowerPoint 文件写入磁盘
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改音频帧缩略图**

将音频文件添加到演示文稿时，音频会以带有标准默认图像的帧形式显示（请参见下节中的图像）。您可以更改音频帧的预览图像（设置您喜欢的图像）。

下面的 JavaScript 代码演示了如何更改音频帧的缩略图或预览图像：
```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // 向幻灯片添加音频帧并指定位置和尺寸。
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // 向演示文稿资源添加图像。
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 为音频帧设置图像。
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // 将修改后的演示文稿保存到磁盘
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **更改音频播放选项**

Aspose.Slides for Node.js via Java 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量、设置音频循环播放，甚至隐藏音频图标。

The **Audio Options** pane in Microsoft PowerPoint:

![示例1_图像](audio_frame_0.png)

PowerPoint **音频选项** 与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) 属性对应：

- **Start** 下拉列表对应 [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) 方法
- **Volume** 对应 [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) 方法
- **Play Across Slides** 对应 [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法
- **Loop until Stopped** 对应 [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) 方法
- **Hide During Show** 对应 [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) 方法
- **Rewind after Playing** 对应 [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) 方法

PowerPoint **编辑** 选项与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) 属性对应：

- **Fade In** 对应 [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 方法 
- **Fade Out** 对应 [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 方法 
- **Trim Audio Start Time** 对应 [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 方法 
- **Trim Audio End Time** 的值等于音频时长减去 [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) 方法的值

PowerPoint **音量控制** 在音频控制面板上对应 [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) 方法。它允许您以百分比方式更改音频音量。

以下是更改音频播放选项的方法：

1. [创建](#create-audio-frame) 或获取音频帧。
2. 为要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 JavaScript 代码演示了一个调整音频选项的操作：
```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // 获取 AudioFrame 形状
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 将播放模式设置为点击播放
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // 将音量设置为低
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // 将音频设置为跨幻灯片播放
    audioFrame.setPlayAcrossSlides(true);
    // 禁用音频循环
    audioFrame.setPlayLoopMode(false);
    // 在幻灯片放映期间隐藏 AudioFrame
    audioFrame.setHideAtShowing(true);
    // 播放后将音频倒带到开始
    audioFrame.setRewindAudio(true);
    // 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


下面的 JavaScript 示例展示了如何添加带嵌入音频的新音频帧、进行修剪并设置淡入淡出时长：
```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 设置剪辑开始偏移为 1.5 秒
    // 设置剪辑结束偏移为 2 秒
    // 设置淡入持续时间为 200 毫秒
    // 设置淡出持续时间为 500 毫秒

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


以下代码示例展示了如何检索带嵌入音频的音频帧并将其音量设置为 85%：
```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // 获取音频帧形状
    const audioFrame = slide.getShapes().get_Item(0);

    // 将音频音量设置为 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **提取音频**

Aspose.Slides for Node.js via Java 允许您提取幻灯片放映过渡中使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [slideshow transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--)。
4. 以字节数据形式提取声音。

下面的 JavaScript 代码演示了如何提取幻灯片中使用的音频：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // 访问所需的幻灯片
    const slide = pres.getSlides().get_Item(0);
    // 获取该幻灯片的幻灯片放映过渡效果
    const transition = slide.getSlideShowTransition();
    // 将声音提取为字节数组
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**是否可以在多个幻灯片中重复使用相同的音频资源而不增加文件大小？**

是的。将音频一次添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/)，然后创建引用该现有资源的额外音频帧。这避免了媒体数据的重复，并使演示文稿大小保持可控。

**是否可以在不重新创建形状的情况下替换现有音频帧中的声音？**

是的。对于链接声音，更新 [link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) 以指向新文件。对于嵌入声音，使用演示文稿的另一个 [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) 中的音频替换 [embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) 对象。帧的格式和大多数播放设置保持不变。

**修剪是否会更改存储在演示文稿中的底层音频数据？**

否。修剪仅调整播放边界。原始音频字节保持未修改，可通过嵌入音频或演示文稿的 audio collection 访问。