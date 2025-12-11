---
title: Android で PPT を PPTX に変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、レガシー PPT プレゼンテーションを最新の PPTX に高速変換します — 明確なチュートリアル、無料コードサンプル、Microsoft Office に依存しません。"
---

## **概要**

This article explains how to convert PowerPoint Presentation in PPT format into PPTX format using Java and with online PPT to PPTX conversion app. The following topic is covered.

- Convert PPT to PPTX in Java

## **Android で PPT を PPTX に変換**

For Java sample code to convert PPT to PPTX, please see the section below i.e. [Convert PPT to PPTX](#convert-ppt-to-pptx). It just loads the PPT file and saves in PPTX format. By specifiying different save formats, you can also save PPT file into many other formats like PDF, XPS, ODP, HTML etc. as disscussed in these articles.

- [Java Convert PPT to PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convert PPT to XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convert PPT to HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convert PPT to ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convert PPT to Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

Convert old PPT format to PPTX with Aspose.Slides API. If you need to convert thousands of PPT presentations to PPTX format, the best solution is to do it programmatically. With Aspose.Slides API its possible to do it just in few lines of code. The API supports full compatibility to convert PPT presentation to PPTX and its possible to:

- Convert complicated structures of masters, layouts and slides.
- Convert presentation with charts.
- Convert presentation with group shapes, auto-shapes (like rectangles and ellipses), shapes with custom geometry.
- Convert presentation, having textures and pictures fill styles for auto-shapes.
- Convert presentation with placeholders, text frames and text holders.

{{% alert color="primary" %}} 

Take a look at [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

This app is built based on [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), so you may see alive example of basic PPT to PPTX conversion capabilities. Aspose.Slides Conversion is a web app, which allows to drop presentation file in PPT format and download it converted to PPTX.

Find other live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) examples.
{{% /alert %}} 

## **PPT を PPTX に変換**

Aspose.Slides for Android via Java now facilitates the developers to access the PPT using [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class instance and converting that to respective [PPTX](https://docs.fileformat.com/presentation/pptx/) format. Presently, it supports partial conversion of [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX. For more details about what features are supported and unsupported in PPT to PPTX conversion, please proceed to this documentation [link](/slides/ja/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides for Android via Java offers [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class that represents a **PPTX** presentation file. Presentation class can now also access **PPT** through Presentation when the object is instantiated. The following example shows how to convert a PPT presentation into PPTX Presentation.
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPTX プレゼンテーションを PPTX 形式で保存しています
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後に生成された PPTX プレゼンテーション**|

## **よくある質問**

**What is the difference between PPT and PPTX formats?**

PPT is the older binary file format used by Microsoft PowerPoint, while PPTX is the newer XML-based format introduced with Microsoft Office 2007. PPTX files offer better performance, reduced file size, and improved data recovery.

**Does Aspose.Slides support batch conversion of multiple PPT files to PPTX?**

Yes, you can use Aspose.Slides in a loop to convert multiple PPT files to PPTX programmatically, making it suitable for batch conversion scenarios.

**Will the content and formatting be preserved after conversion?**

Aspose.Slides maintains high fidelity in converting presentations. Slide layouts, animations, shapes, charts, and other design elements are preserved during the PPT to PPTX conversion.

**Can I convert other formats like PDF or HTML from PPT files?**

Yes, Aspose.Slides supports converting PPT files to [multiple formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), including PDF, XPS, HTML, ODP, and image formats like PNG and JPEG.

**Is it possible to convert PPT to PPTX without Microsoft PowerPoint installed?**

Yes, Aspose.Slides is a standalone API and does not require Microsoft PowerPoint or any third-party software to perform the conversion.

**Is there an online tool available for PPT to PPTX conversion?**

Yes, you can use the free [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) web application to perform the conversion directly in your browser without writing any code.