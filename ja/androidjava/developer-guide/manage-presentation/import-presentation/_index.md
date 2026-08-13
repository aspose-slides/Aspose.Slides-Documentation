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
description: "Aspose.Slides for Android を使用して、Java で PDF および HTML ドキュメントを PowerPoint と OpenDocument のプレゼンテーションにインポートし、シームレスで高性能なスライド処理を実現します。"
---
## **概要**

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/ja/androidjava/) を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF、HTML ドキュメントなどからプレゼンテーションをインポートできるようにするために、[SlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidecollection/) クラスを提供します。

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromPdf()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) メソッドを呼び出し、PDF ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この Java コードは PDF から PowerPoint への変換を示しています：

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

{{% alert  title="ヒント" color="info" %}} 
ここで説明したプロセスの実際の実装であるため、**Aspose 無料** [PDF to PowerPoint](https://products.aspose.app/slides/ja/import/pdf-to-powerpoint) Web アプリを確認した方がよいでしょう。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromHtml()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) メソッドを呼び出し、HTML ドキュメントを含むストリームを渡します。  
3. [save()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この Java コードは HTML から PowerPoint への変換を示しています： 

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

### PDF をインポートするときにテーブルは保持されますか、検出精度を向上させることはできますか？

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfimportoptions/) にはテーブル認識を有効にする [setDetectTables](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) メソッドが含まれています。効果は PDF の構造に依存します。