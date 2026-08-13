---
title: PDF または HTML から C++ でプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/cpp/import-presentation/
keywords:
- プレゼンテーションのインポート
- スライドのインポート
- PDF のインポート
- HTML のインポート
- PDF からプレゼンテーション
- PDF から PPT
- PDF から PPTX
- PDF から ODP
- HTML からプレゼンテーション
- HTML から PPT
- HTML から PPTX
- HTML から ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PDF および HTML ドキュメントを PowerPoint や OpenDocument プレゼンテーションにシームレスかつ高性能にインポートし、スライド処理を容易にします。"
---
## **はじめに**

[**Aspose.Slides for C++**](https://products.aspose.com/slides/ja/cpp/) を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF や HTML ドキュメントなどからプレゼンテーションをインポートできるようにするために、[SlideCollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.slide_collection) クラスを提供します。

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. プレゼンテーションクラスのオブジェクトをインスタンス化します。  
2. PDF ファイルを渡して [AddFromPdf()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) メソッドを呼び出します。  
3. PowerPoint 形式でファイルを保存するために [Save()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用します。

この C++ コードは PDF から PowerPoint への変換を示しています：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
ここで説明したプロセスの実際の実装である **Aspose free** の [PDF to PowerPoint](https://products.aspose.app/slides/ja/import/pdf-to-powerpoint) Web アプリを確認したいかもしれません。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。  
2. HTML ファイルを渡して [AddFromHtml()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) メソッドを呼び出します。  
3. PowerPoint 形式でファイルを保存するために [Save()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用します。

この C++ コードは HTML から PowerPoint への変換を示しています：

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
また、Aspose.Slides を使用して HTML を他の一般的なファイル形式に変換することもできます： 

* [HTML から画像](https://products.aspose.com/slides/ja/cpp/conversion/html-to-image/)  
* [HTML から JPG](https://products.aspose.com/slides/ja/cpp/conversion/html-to-jpg/)  
* [HTML から XML](https://products.aspose.com/slides/ja/cpp/conversion/html-to-xml/)  
* [HTML から TIFF](https://products.aspose.com/slides/ja/cpp/conversion/html-to-tiff/)  

{{% /alert %}}

## **FAQ**

### PDF をインポートする際に表は保持されますか、検出を改善できますか？

インポート時に表を検出できます。[PdfImportOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/pdfimportoptions/) には表認識を有効にする [set_DetectTables](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) メソッドが含まれています。効果は PDF の構造に依存します。