---
title: "C++ で PowerPoint プレゼンテーションをノート付き PDF に変換"
linktitle: "PowerPoint をノート付き PDF に変換"
type: docs
weight: 50
url: /ja/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint から PDF へ
- プレゼンテーション から PDF へ
- スライド から PDF へ
- PPT から PDF へ
- PPTX から PDF へ
- プレゼンテーション を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- スピーカーノート
- ノート付き PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPT および PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

本稿では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスライド ノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を解説し、効率的にタスクを実行できるようコード例を提供します。この記事を読み終えると、次のことができるようになります。

- PowerPoint スライドを PDF ドキュメントに変換し、スライド ノートを保持する変換プロセスを実装する。
- 出力 PDF をカスタマイズし、スライド ノートが要件に合わせて含まれ、書式設定されていることを確認する。

エクスポート前にノート ページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/cpp/notes-size/) を参照してください。

## **スライド ノート付きで PowerPoint を PDF に変換する方法**

`Save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスで使用でき、PPT または PPTX プレゼンテーションをスライド ノート付きの PDF に変換します。Aspose.Slides を使用する場合、プレゼンテーションを読み込み、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスでレイアウト オプションを設定してスライド ノートを含め、ファイルを PDF として保存します。以下のコード スニペットは、サンプル プレゼンテーションをノート スライド表示の PDF に変換する方法を示しています。

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

// スピーカーノートを描画するための PDF オプションを設定します。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にスピーカーノートを描画します。
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを PDF に保存します。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Aspose の[Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ja/conversion) を確認すると便利です。 
{{% /alert %}}