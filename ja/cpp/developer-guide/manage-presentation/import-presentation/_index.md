---
title: プレゼンテーションのインポート - C++ PowerPoint API
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/cpp/import-presentation/
keywords: "PowerPointのインポート, PDFからプレゼンテーションへ, PDFからPPTXへ, PDFからPPTへ, C++, Aspose.Slides for C++"
description: "PDFからPowerPointプレゼンテーションをインポートします。PDFをPowerPointに変換します。"
---

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slidesは、PDF、HTMLドキュメントなどからプレゼンテーションをインポートするために[SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection)クラスを提供します。

## **PDFからPowerPointをインポート**

この場合、PDFをPowerPointプレゼンテーションに変換します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. プレゼンテーションクラスのオブジェクトをインスタンス化します。 
2. [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5)メソッドを呼び出し、PDFファイルを渡します。 
3. [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドを使用して、PowerPoint形式でファイルを保存します。

このC++コードは、PDFからPowerPointへの操作を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="ヒント" color="primary" %}} 

**Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)ウェブアプリをチェックしてみると良いでしょう。これは、ここで説明したプロセスのライブ実装です。

{{% /alert %}} 

## **HTMLからPowerPointをインポート**

この場合、HTMLドキュメントをPowerPointプレゼンテーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスのインスタンスを作成します。 
2. [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965)メソッドを呼び出し、HTMLファイルを渡します。 
3. [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドを使用して、PowerPoint形式でファイルを保存します。

このC++コードは、HTMLからPowerPointへの操作を示しています：

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slidesを使用して、HTMLを他の人気のあるファイル形式に変換することもできます：

* [HTMLから画像](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTMLからJPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTMLからXML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTMLからTIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}