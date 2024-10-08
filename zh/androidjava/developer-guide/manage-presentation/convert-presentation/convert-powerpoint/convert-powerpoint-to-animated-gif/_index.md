---
title: 将 PowerPoint 转换为动画 GIF
type: docs
weight: 65
url: /zh/androidjava/convert-powerpoint-to-animated-gif/
keywords: "将 PowerPoint 转换为动画 GIF, PPT 转 GIF, PPTX 转 GIF"
description: "使用 Aspose.Slides API 将 PowerPoint 转换为动画 GIF：PPT 转 GIF，PPTX 转 GIF。"
---

## 使用默认设置将演示文稿转换为动画 GIF ##

以下 Java 示例代码演示了如何使用标准设置将演示文稿转换为动画 GIF：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

生成的动画 GIF 将使用默认参数创建。

{{%  alert  title="提示"  color="primary"  %}} 

如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions) 类。请参见下面的示例代码。

{{% /alert %}} 

## 使用自定义设置将演示文稿转换为动画 GIF ##
以下示例代码演示了如何使用自定义设置将演示文稿转换为动画 GIF：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 结果 GIF 的大小  
	gifOptions.setDefaultDelay(2000); // 每个幻灯片显示多长时间，直到切换到下一个
	gifOptions.setTransitionFps(35); // 增加 FPS 以改善过渡动画质量
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="信息" color="info" %}}

您可能想查看 Aspose 开发的免费 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}