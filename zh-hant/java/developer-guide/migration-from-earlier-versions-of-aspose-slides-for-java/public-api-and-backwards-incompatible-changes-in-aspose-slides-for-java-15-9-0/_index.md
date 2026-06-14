---
title: Aspose.Slides for Java 15.9.0 中的公開 API 與向後不相容變更
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
description: "檢閱 Aspose.Slides for Java 的公開 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有 [已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 或 [已移除](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 類別、方法、屬性等，及其他在 Aspose.Slides for Java 15.8.0 API 中引入的變更。

{{% /alert %}} 
## **公開 API 變更**
#### **已在 com.aspose.slides.ISlide、Slide 中加入 renderToGraphics 方法**
已加入以下方法：

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
已加入至 com.aspose.slides.ISlide 介面以及 com.aspose.slides.Slide 類別。這些方法允許將投影片渲染至指定的 Graphics2D 物件。

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```