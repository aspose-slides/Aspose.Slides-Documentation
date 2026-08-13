---
title: 在 Android 上管理簡報中的項目符號與編號清單
linktitle: 管理清單
type: docs
weight: 60
url: /zh-hant/androidjava/manage-lists/
keywords:
- 項目符號
- 項目符號清單
- 編號清單
- 符號項目符號
- 圖片項目符號
- 自訂項目符號
- 多層次清單
- 建立項目符號
- 新增項目符號
- 新增清單
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Android via Java 在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號、圖片、多層次與編號清單。"
---
## **概述**

Aspose.Slides for Android via Java 讓您在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號與編號清單。清單項目是一個段落，其項目符號設定由段落格式控制。

使用[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) 方法存取段落層級的清單設定。主要入口是[IParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)，它會傳回一個[IBulletFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/) 物件。使用此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式以及起始編號。

本文說明如何：

- 建立使用自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層次清單
- 建立編號清單
- 檢查與變更現有簡報中的清單格式

## **建立項目符號清單**

要建立項目符號清單，將段落新增至[ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 並將[IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) 設為[BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/bullettype/)。之後可設定[IBulletFormat.setChar](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)、[IBulletFormat.getColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#getColor--) 以及[IBulletFormat.setHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) 以控制項目符號外觀。

以下 Java 程式碼示範如何在投影片中建立項目符號清單：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![符號項目符號](symbol_bullets.png)

## **建立編號清單**

使用編號清單時，項目的順序很重要。將[IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) 設為[BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/bullettype/)。您還可以使用[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) 設定編號格式，或在清單需要從非 1 的值開始時，使用[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 設定起始值。

以下 Java 程式碼示範如何在投影片中建立編號清單：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![編號項目符號](numbered_bullets.png)

## **建立圖片項目符號**

Aspose.Slides 允許您以圖像取代一般的項目符號。圖片項目符號最適合簡單且在小尺寸仍能辨識的圖像，例如圖示或小型透明 PNG 檔。

{{% alert color="info" %}}
理想情況下，如果您打算以圖像取代一般的項目符號，最好選擇具透明背景的簡易圖形。此類圖像非常適合作為自訂的項目符號。

請記住，圖像會被縮小到非常小的尺寸。因此，我們強烈建議選擇即使作為清單項目符號使用時仍保持清晰且視覺有效的圖像。
{{% /alert %}}

要建立圖片項目符號，請將圖像加入[Presentation.getImages](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getImages--)，並將返回的[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件指派給[IBulletFormat.getPicture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#getPicture--)。在指派圖像之前，先將[IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) 設為[BulletType.Picture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/bullettype/)。

假設我們有一個 "image.png"：

![項目符號的圖片](picture_for_bullets.png)

以下 Java 程式碼示範如何在投影片中建立圖片項目符號：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![圖片項目符號](picture_bullets.png)

## **建立多層次清單**

使用[IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 將清單項目放在不同層級。第 0 層為頂層，第 1 層為其下的子層，依此類推。

以下 Java 程式碼示範如何建立多層次清單：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![多層次清單](multilevel_list.png)

## **變更現有清單**

要變更現有簡報中的清單格式，存取目標段落並更新其[IParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 設定。建立清單時使用的相同方法亦可用於檢查或修改從 PPT、PPTX 或 ODP 檔載入的清單。

以下 Java 程式碼將文字框中的第一個段落改為使用編號清單樣式：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

### 能否將項目符號與編號清單匯出為 PDF 或圖片？

是的。當目標格式支援相應的文字布局與項目符號功能時，Aspose.Slides 會保留清單格式。

### 我可以編輯現有簡報中的清單嗎？

是的。載入簡報，存取目標段落，檢查或更新其[IParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 設定，然後儲存簡報。

### 清單可以包含非拉丁文字嗎？

是的。清單項目文字可以包含 Unicode 字元，因此您可以在多語言簡報中建立清單。請確保簡報中使用的字型支援您需要的字元。