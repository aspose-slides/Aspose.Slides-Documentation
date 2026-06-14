---
title: 在 Android 上管理簡報中的上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/androidjava/superscript-and-subscript/
keywords:
- 上標
- 下標
- 新增上標
- 新增下標
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Android 上使用 Aspose.Slides 完全掌握上標與下標，為您的簡報提供專業的文字格式設定，達到最佳呈現效果。"
---
## **概述**

Aspose.Slides 提供將上標與下標文字整合至 PowerPoint (PPT、PPTX) 及 OpenDocument (ODP) 簡報的功能。無論是要突顯化學式、數學方程式，或以腳註方式標註內容，這些特殊的格式選項都有助於保持清晰與精確。本文將說明如何在每張投影片中無縫套用上標與下標樣式，確保專業的呈現效果。

## **管理上標和下標文字**
您可以在任何段落的文字區塊中加入上標或下標。若要在 Aspose.Slides 文字框中加入上標或下標，必須使用 [**setEscapement**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) 方法，該方法屬於 [PortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PortionFormat) 類別。

此屬性可取得或設定上標或下標文字（值介於 -100%（下標）至 100%（上標））。例如：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 依索引取得投影片參考。
- 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape)（類型為 [Rectangle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeType#Rectangle)）。
- 取得與該 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape) 相關聯的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame)。
- 清除現有段落。
- 建立新的段落物件以容納上標文字，並將其加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame) 的 [IParagraphs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) 集合中。
- 建立新的 Portion 物件。
- 為 Portion 設定 Escapement 屬性，值介於 0 到 100 之間，以加入上標。（0 表示不使用上標）
- 為 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Portion) 設定文字，然後將其加入段落的 Portion 集合。
- 建立新的段落物件以容納下標文字，並將其加入 ITextFrame 的 IParagraphs 集合中。
- 建立新的 Portion 物件。
- 為 Portion 設定 Escapement 屬性，值介於 0 到 -100 之間，以加入下標。（0 表示不使用下標）
- 為 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Portion) 設定文字，然後將其加入段落的 Portion 集合。
- 將簡報儲存為 PPTX 檔案。

上述步驟的實作範例請參考下方內容。

```java
// 實例化一個代表 PPTX 的 Presentation 類別
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

**匯出為 PDF 或其他格式時，上標和下標會被保留嗎？**

是的，Aspose.Slides 在將簡報匯出為 PDF、PPT/PPTX、影像及其他支援的格式時，會正確保留上標與下標的格式。此類特殊格式在所有輸出檔案中均保持完整。

**上標和下標能與其他格式樣式（例如粗體或斜體）結合使用嗎？**

可以，Aspose.Slides 允許在同一 Portion 文字中混合多種樣式。您可以同時啟用粗體、斜體、底線，並透過設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portionformat/) 的相關屬性來套用上標或下標。

**上標和下標在表格、圖表或 SmartArt 內的文字是否也能使用？**

可以，Aspose.Slides 支援在大多數物件內的文字進行格式設定，包括表格與圖表元素。若要在 SmartArt 中使用，需存取相應的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/smartartnode/)）及其文字容器，然後以相同方式設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portionformat/) 屬性。