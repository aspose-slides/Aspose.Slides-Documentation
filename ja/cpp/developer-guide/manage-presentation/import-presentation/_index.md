---
title: PDF または HTML から C++ でプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/cpp/import-presentation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PDF および HTML ドキュメントを PowerPoint や OpenDocument のプレゼンテーションにシームレスかつ高性能にインポートし、スライド処理を容易に行えます。"
---

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF、HTML ドキュメントなどからプレゼンテーションをインポートできるようにするために、[SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) クラスを提供します。

## **PDF から PowerPoint にインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation クラスのオブジェクトをインスタンス化します。  
2. [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) メソッドを呼び出し、PDF ファイルを渡します。  
3. [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この C++ コードは PDF から PowerPoint への操作を示しています：
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert  title="Tip" color="primary" %}} 
**Aspose free** の [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリをチェックするとよいでしょう。これはここで説明したプロセスの実装例です。 
{{% /alert %}} 

## **HTML から PowerPoint にインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。  
2. [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) メソッドを呼び出し、HTML ファイルを渡します。  
3. [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この C++ コードは HTML から PowerPoint への操作を示しています：
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
Aspose.Slides を使用して、HTML を他の一般的なファイル形式に変換することもできます。 

* [HTML を画像に変換](https://products.aspose.com/slides/cpp/conversion/html-to-image/)  
* [HTML を JPG に変換](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)  
* [HTML を XML に変換](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)  
* [HTML を TIFF に変換](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)  

{{% /alert %}}

## **FAQ**

**PDF をインポートする際にテーブルは保持されますか？ また、検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) には、テーブル認識を有効にする [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) メソッドが含まれています。効果は PDF の構造に依存します。