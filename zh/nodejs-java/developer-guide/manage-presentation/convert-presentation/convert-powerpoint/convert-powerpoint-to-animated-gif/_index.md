---
title: 将 PowerPoint 转换为动画 GIF
type: docs
weight: 65
url: /zh/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "将 PowerPoint 转换为动画 GIF, PPT 转 GIF, PPTX 转 GIF"
description: "将 PowerPoint 转换为动画 GIF：PPT 转 GIF，PPTX 转 GIF，使用 Aspose.Slides API。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

以下 JavaScript 示例代码演示了如何使用标准设置将演示文稿转换为动画 GIF：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


动画 GIF 将使用默认参数创建。

{{%  alert  title="提示"  color="primary"  %}} 
如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions) 类。请参阅下面的示例代码。
{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

以下示例代码演示了如何在 JavaScript 中使用自定义设置将演示文稿转换为动画 GIF：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// 生成的 GIF 的尺寸
    gifOptions.setDefaultDelay(2000);// 每张幻灯片显示的时长，直到切换到下一张
    gifOptions.setTransitionFps(35);// 提高 FPS 以获得更好的过渡动画质量
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="信息" color="info" %}}
您可以查看由 Aspose 开发的免费 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器。
{{% /alert %}}

## **常见问题**

**如果演示文稿中使用的字体未在系统上安装怎么办？**

安装缺失的字体或 [配置备用字体](/slides/zh/nodejs-java/powerpoint-fonts/)。Aspose.Slides 将进行替换，但外观可能会有所不同。如需品牌一致性，请务必确保所需字体已明确可用。

**我可以在 GIF 帧上叠加水印吗？**

是的。 在导出前将 [添加半透明对象/徽标](/slides/zh/nodejs-java/watermark/) 到母版幻灯片或各个幻灯片 — 水印将出现在每一帧上。