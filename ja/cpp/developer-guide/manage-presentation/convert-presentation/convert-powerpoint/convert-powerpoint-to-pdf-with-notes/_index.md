---
title: C++ でノート付き PowerPoint プレゼンテーションを PDF に変換
linktitle: ノート付き PowerPoint を PDF に変換
type: docs
weight: 50
url: /ja/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PDF に変換
- プレゼンテーションを PDF に変換
- スライドを PDF に変換
- PPT を PDF に変換
- PPTX を PDF に変換
- プレゼンテーションを PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- スピーカーノート
- ノート付き PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PPT および PPTX 形式をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

このガイドでは、Aspose.Slides を使用してスライドノート付きの PDF 形式に PowerPoint プレゼンテーションを変換する方法を学びます。必要な手順を説明し、コード例を示すことで、効率的にこのタスクを実行できるようにします。この記事を読み終えると、以下ができるようになります。

- スライドノートを保持したまま、PowerPoint のスライドを PDF 文書に変換するプロセスを実装する。
- 出力 PDF がスライドノートを含み、要件に合わせて書式設定されていることを確認する。

## **スライドのノート付きでPowerPointをPDFに変換**

`Save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスで使用でき、PPT または PPTX プレゼンテーションをスライドノート付きの PDF に変換します。Aspose.Slides では、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスでレイアウトオプションを設定してスライドノートを含め、ファイルを PDF として保存します。次のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// スピーカーノートをレンダリングするための PDF オプションを構成します。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にスピーカーノートを描画します。
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを PDF に保存します。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Aspose の [オンライン PowerPoint から PDF へのコンバータ](https://products.aspose.app/slides/ja/conversion) をご確認ください。 
{{% /alert %}}