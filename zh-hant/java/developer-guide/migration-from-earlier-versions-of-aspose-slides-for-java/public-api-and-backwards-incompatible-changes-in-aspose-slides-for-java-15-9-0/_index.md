---
title: Aspose.Slides for Java 15.9.0 的公開 API 及向後不相容變更
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公開 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)或[已移除](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)的類別、方法、屬性等，並說明隨 Aspose.Slides for Java 15.8.0 API 所引入的其他變更。

{{% /alert %}} 
## **公開 API 變更**
#### **已在 com.aspose.slides.ISlide、Slide 中加入 renderToGraphics 方法**
已新增以下方法：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
已加入至 com.aspose.slides.ISlide 介面以及 com.aspose.slides.Slide 類別。這些方法允許將投影片渲染到指定的 Graphics2D 物件。

`renderToGraphics` 方法自此已從公開 API 中移除。在目前的版本中，請使用[ISlide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 來渲染投影片，如下例所示：

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