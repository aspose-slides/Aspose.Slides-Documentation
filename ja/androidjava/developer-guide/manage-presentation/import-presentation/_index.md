---
title: Android で PDF または HTML からプレゼンテーションをインポート
linktitle: プレゼンテーションをインポート
type: docs
weight: 60
url: /ja/androidjava/import-presentation/
keywords:
- プレゼンテーションをインポート
- スライドをインポート
- PDF をインポート
- HTML をインポート
- PDF からプレゼンテーションへ
- PDF から PPT へ
- PDF から PPTX へ
- PDF から ODP へ
- HTML からプレゼンテーションへ
- HTML から PPT へ
- HTML から PPTX へ
- HTML から ODP へ
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用した Java で、PDF および HTML ドキュメントを PowerPoint および OpenDocument のプレゼンテーションにシームレスかつ高性能にスライド処理できます。"
---

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/) を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF や HTML ドキュメントなどからプレゼンテーションをインポートできるように、[SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) クラスを提供します。

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) メソッドを呼び出し、PDF ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この Java コードは PDF から PowerPoint への変換を示しています:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert  title="Tip" color="primary" %}} 
ここで説明したプロセスのライブ実装である **Aspose free** の [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリをチェックするとよいでしょう。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) メソッドを呼び出し、HTML ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この Java コードは HTML から PowerPoint への変換を示しています: 
```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**PDF をインポートする際にテーブルは保持されますか、また検出を改善できますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) にはテーブル認識を有効にする [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) メソッドが含まれています。効果は PDF の構造に依存します。