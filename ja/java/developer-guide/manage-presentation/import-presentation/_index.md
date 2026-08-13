---
title: Java で PDF または HTML からプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/java/import-presentation/
keywords:
- プレゼンテーションのインポート
- スライドのインポート
- PDF のインポート
- HTML のインポート
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
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PDF および HTML ドキュメントを PowerPoint や OpenDocument のプレゼンテーションにシームレスかつ高性能にインポートし、スライド処理を簡単に行えます。"
---
## **はじめに**

Aspose.Slides を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF および HTML ドキュメントからプレゼンテーションをインポートできる SlideCollection クラスを提供します。

## **PDF から PowerPoint にインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation クラスのインスタンスを作成します。 
2. addFromPdf() メソッドを呼び出し、PDF ファイルを渡します。 
3. save() メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この Java コードは PDF から PowerPoint への変換操作を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
このページで説明したプロセスの実装例として、**Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ja/import/pdf-to-powerpoint) Web アプリをご確認いただけます。 
{{% /alert %}} 

## **HTML から PowerPoint にインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. Presentation クラスのインスタンスを作成します。 
2. addFromHtml() メソッドを呼び出し、HTML ドキュメントを含むストリームを渡します。 
3. save() メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この Java コードは HTML から PowerPoint への変換操作を示しています： 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

## **よくある質問**

### PDF をインポートする際にテーブルは保持されますか？また、検出精度を向上させることはできますか？

インポート時にテーブルを検出できます。PdfImportOptions にはテーブル認識を有効にする setDetectTables メソッドが含まれています。効果は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides を使用して、HTML を他の一般的なファイル形式に変換することもできます： 

* [HTML を画像へ](https://products.aspose.com/slides/ja/java/conversion/html-to-image/)
* [HTML を JPG へ](https://products.aspose.com/slides/ja/java/conversion/html-to-jpg/)
* [HTML を XML へ](https://products.aspose.com/slides/ja/java/conversion/html-to-xml/)
* [HTML を TIFF へ](https://products.aspose.com/slides/ja/java/conversion/html-to-tiff/)

{{% /alert %}}