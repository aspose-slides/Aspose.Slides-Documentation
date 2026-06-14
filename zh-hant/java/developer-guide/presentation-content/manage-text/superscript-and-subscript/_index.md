---
title: 使用 Java 管理簡報中的上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/java/superscript-and-subscript/
keywords:
- 上標
- 下標
- 新增上標
- 新增下標
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通上標與下標，並以專業的文字格式提升您的簡報，達到最佳效果。"
---
## **概觀**

Aspose.Slides 提供將上標與下標文字整合到 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報中的功能。無論您需要突顯化學式、數學方程式，或以註腳標註內容，這些專門的格式選項都有助於保持清晰與精確。本文將教您如何順暢套用上標與下標樣式，確保每張投影片皆呈現專業效果。

## **管理上標與下標文字**
您可以在任何段落的 Portion 中加入上標與下標文字。要在 Aspose.Slides 文字框中加入上標或下標，必須使用 [PortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PortionFormat) 類別的 [**setEscapement**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) 方法。

此屬性可取得或設定上標或下標文字（值範圍從 -100%（下標）到 100%（上標））。例如：

- 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
- 透過 Index 取得投影片的參考。
- 在投影片中加入類型為 [Rectangle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeType#Rectangle) 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。
- 存取與 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape) 相關聯的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrame)。
- 清除現有的段落。
- 建立一個用於容納上標文字的新段落物件，並將其加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrame) 的 [IParagraphs collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrame#getParagraphs--) 中。
- 建立一個新的 Portion 物件。
- 將 Escapement 屬性設定於 0 到 100 之間，以加入上標。（0 表示無上標）
- 為 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Portion) 設定文字，然後將其加入段落的 Portion 集合中。
- 建立一個用於容納下標文字的新段落物件，並將其加入 ITextFrame 的 IParagraphs 集合中。
- 建立一個新的 Portion 物件。
- 將 Escapement 屬性設定於 0 到 -100 之間，以加入下標。（0 表示無下標）
- 為 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Portion) 設定文字，然後將其加入段落的 Portion 集合中。
- 將簡報儲存為 PPTX 檔案。

以下提供上述步驟的實作範例。

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 建立文字方塊
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 建立上標文字段落
    IParagraph superPar = new Paragraph();

    // 建立一般文字的 Portion
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 建立上標文字的 Portion
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 建立下標文字段落
    IParagraph paragraph2 = new Paragraph();

    // 建立一般文字的 Portion
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 建立下標文字的 Portion
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // 將段落加入文字方塊
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**匯出為 PDF 或其他格式時，上標與下標會被保留嗎？**

是，Aspose.Slides 會在匯出簡報為 PDF、PPT/PPTX、影像及其他支援的格式時，正確保留上標與下標的格式。此專門的格式在所有輸出檔案中皆保持完整。

**上標與下標能否與其他格式樣式（如粗體或斜體）結合使用？**

是，Aspose.Slides 允許在同一段文字的 Portion 中混合多種文字樣式。您可以同時啟用粗體、斜體、底線，並透過設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portionformat/) 的相應屬性來套用上標或下標。

**上標與下標格式是否適用於表格、圖表或 SmartArt 中的文字？**

是，Aspose.Slides 支援在大多數物件內的格式設定，包括表格和圖表元素。處理 SmartArt 時，您需要存取相應的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/smartartnode/)）及其文字容器，然後以類似方式設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portionformat/) 屬性。