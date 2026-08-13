---
title: Aspose.Slides for Java 15.9.0 中的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审查 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有[added](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)或[removed](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)的类、方法、属性等，以及随 Aspose.Slides for Java 15.8.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已向 com.aspose.slides.ISlide, Slide 添加了 renderToGraphics 方法**
已添加以下方法：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
已添加到 com.aspose.slides.ISlide 接口和 com.aspose.slides.Slide 类。这些方法允许将幻灯片渲染到指定的 Graphics2D 对象。

`renderToGraphics` 方法已从公共 API 中移除。在当前版本中，可使用 [ISlide.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 渲染幻灯片，如下面的示例所示：

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```