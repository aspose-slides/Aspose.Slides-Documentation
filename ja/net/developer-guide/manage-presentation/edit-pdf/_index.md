---
title: .NET で PDF ドキュメントを編集
linktitle: PDF を編集
type: docs
weight: 65
url: /ja/net/edit-pdf/
keywords:
- PDF を編集
- PDF テキストを置換
- PDF から PPTX へ
- PPTX から PDF へ
- .NET
- C#
- Aspose.Slides
description: "C# で Aspose.Slides にインポートし、テキストを置換して、変更したプレゼンテーションを PDF に再保存することで PDF ドキュメントを編集します。"
---
## **概要**

Aspose.Slides for .NET は、PDF のページをスライドとしてインポートし、プレゼンテーションを編集して、再び PDF としてエクスポートすることで PDF コンテンツを編集できます。この記事では、簡単なテキスト置換を示します。プレゼンテーションはメモリ上に保持されるため、中間の PPTX ファイルを保存する必要はありません。

## **PDF のテキスト置換**

[AddFromPdf](https://reference.aspose.com/slides/ja/net/aspose.slides/slidecollection/addfrompdf/) を使用してページをインポートし、[ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replacetext/) でテキストを更新し、[Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) で結果をエクスポートします。

以下の例は、インポート後に `input.pdf` に編集可能なテキストとして単語「Draft」が含まれていることを想定しています。この単語を「Final」に置換し、`edited.pdf` として書き出します。インポート前に最初のスライドをクリアすることで、出力に余分な空白ページが入るのを防ぎます。検索は大文字小文字を区別した単語全体にマッチします。`null` は結果コールバックが不要であることを意味します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

さらに詳しいオプションについては、[Search and Replace Text](/slides/ja/net/search-and-replace-text/) と [Convert PowerPoint to PDF](/slides/ja/net/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対してのみ機能し、スキャンされた画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は、出力を確認してください。
{{% /alert %}}

## **よくある質問**

**PDF をエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。メモリ上の同じプレゼンテーションを編集してエクスポートできます。PowerPoint で引き続き編集したい場合のみ、PPTX のコピーを保存してください。詳細は [Save Presentations](/slides/ja/net/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されないままになることがありますか？**

この例は、正確な大文字小文字で単語「Draft」全体にマッチさせています。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索に一致しない可能性があります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。