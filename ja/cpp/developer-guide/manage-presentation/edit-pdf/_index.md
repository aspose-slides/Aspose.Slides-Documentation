---
title: C++ で PDF 文書を編集
linktitle: PDF を編集
type: docs
weight: 65
url: /ja/cpp/edit-pdf/
keywords:
- PDF を編集
- PDF テキストを置換
- PDF から PPTX へ
- PPTX から PDF へ
- C++
- Aspose.Slides
description: "C++ で Aspose.Slides に PDF をインポートし、テキストを置換して、変更したプレゼンテーションを PDF に保存することで PDF 文書を編集します。"
---
## **概要**

Aspose.Slides for C++ は、PDF のページをスライドとしてインポートし、プレゼンテーションを修正し、PDF にエクスポートすることで PDF コンテンツを編集できます。本記事ではシンプルなテキスト置換の例を示します。プレゼンテーションはメモリ内に保持されるため、中間の PPTX ファイルを保存する必要は任意です。

## **PDF のテキスト置換**

ページをインポートするには[SlideCollection::AddFromPdf](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidecollection/addfrompdf/) を、テキストを更新するには[Presentation::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/replacetext/) を、結果をエクスポートするには[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) を使用します。

以下の例は、インポート後に `input.pdf` に編集可能なテキストとして「Draft」という単語が含まれていることを前提としています。この単語を「Final」に置換し、`edited.pdf` として書き出します。インポート前に最初のスライドをクリアすることで、出力に余分な空白ページが入るのを防ぎます。検索は同一の大文字小文字で完全一致する単語を対象とし、`nullptr` は結果コールバックが不要であることを意味します。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

詳細なオプションについては[テキスト検索と置換](/slides/ja/cpp/search-and-replace-text/) と[PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対してのみ機能し、スキャンされた画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は出力を確認してください。
{{% /alert %}}

## **よくある質問**

**PDF をエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。メモリ内の同じプレゼンテーションを編集してエクスポートできます。PowerPoint で引き続き編集したい場合のみ PPTX のコピーを保存してください。詳しくは[プレゼンテーションの保存](/slides/ja/cpp/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されない場合があるのでしょうか？**

この例では、完全一致かつ大文字小文字を区別して単語「Draft」を検索しています。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索にヒットしない可能性があります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。