---
title: ".NET でノートページのサイズと向きを変更する"
linktitle: "ノートページサイズ"
type: docs
weight: 10
url: /ja/net/notes-size/
keywords:
- "ノートページサイズ"
- "ノート向き"
- "横向きノート"
- "縦向きノート"
- "配布資料サイズ"
- "PowerPoint"
- "プレゼンテーション"
- "PPT"
- "PPTX"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でノートページの寸法を読み取り・変更し、向きを切り替え、保存されたサイズを検証し、ノートや配布資料を PDF と画像にエクスポートします。"
---
## **概要**

プレゼンテーションのノートページ設定にアクセスするには [Presentation.NotesSize](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/notessize/) を使用します。これは [INotesSize](https://reference.aspose.com/slides/ja/net/aspose.slides/inotessize/) オブジェクトを返し、その [Size](https://reference.aspose.com/slides/ja/net/aspose.slides/inotessize/size/) プロパティは書き込み可能です。設定オブジェクト自体は読み取り専用ですが、サイズプロパティに新しい寸法を割り当てることができます。

幅と高さは **ポイント** 単位で指定され、1インチは72ポイントです。たとえば、900 × 600ポイントは12.5 × 8⅓インチに相当します。これらの設定はプレゼンテーション全体に適用され、個々のスライドのノートには適用されません。

| 設定 | 目的 |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/notessize/) | ノートページの寸法と配布資料エクスポートに使用されるページ寸法を制御します。 |
| [Presentation.SlideSize](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slidesize/) | 通常のプレゼンテーションスライドの寸法を [ISlideSize](https://reference.aspose.com/slides/ja/net/aspose.slides/islidesize/) を通じて制御します。 |

どちらかの設定を変更しても、もう一方が自動的に変更されることはありません。ノートページの向きを変更しても、通常のスライドは回転しません。通常スライドのサイズ変更については [Slide Size](/slides/ja/net/slide-size/) を参照してください。

以下の例は既存の `sample.pptx` を使用します。エクスポートの例では、スピーカーノートを含むスライドが少なくとも1枚あるプレゼンテーションを使用してください。各例は独立して実行できます。

## **ノートページのサイズと向きの読み取り**

幅と高さを読み取り、比較して向きを判断します。幅が大きいページは横向き、縦が大きいページは縦向き、寸法が等しい場合は正方形のページです。この例では標準用紙サイズを前提とせず、実際の寸法をポイントで出力します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **紙サイズを変更せずに横向きに切り替える**

向きだけを変更するには、既存の幅と高さを入れ替えます。これにより、カスタム用紙サイズを含む両側の長さが保持されます。以下の条件は、すでに横向きのページが縦向きに戻されることを防ぎ、正方形のページは変更しません。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

縦向きの場合は、`size.Width > size.Height` のときに同じ代入を使用します。用紙サイズも変更したい場合以外は、A4 や Letter の寸法に置き換えないでください。

## **カスタムノートページサイズの設定と検証**

両方の寸法を同時に割り当て、次に [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) を使用してプレゼンテーションを書き出します。この例では 900 × 600 ポイントの横向きページを設定し、PPTX として保存し、保存されたファイルを再度開いて永続化された値を確認します。比較では浮動小数点値に対して 0.01 ポイントの許容誤差を許可していますが、すべてのファイル形式での精度を保証するものではありません。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

期待される結果は `900 x 600 points` と `Size preserved: True` です。新しく開いたプレゼンテーションを確認することで、メモリ上の設定だけでなく、保存されたファイルが正しいことを検証します。

## **ノートと配布資料のエクスポート**

ページ寸法はノートや配布資料レイアウトの利用可能領域を定義します。これらの寸法だけでレイアウトが有効になるわけではなく、エクスポートオプションも設定する必要があります。通常のスライドエクスポートはスライドの寸法を引き続き使用します。

### **ノートを PDF と PNG にエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notescommentslayoutingoptions/) を [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) に割り当てて PDF にノートを含めます。この例では、[Slide.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage/) と [RenderingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BottomTruncated](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notespositions/) モードはノートを 1 ページに収め、収まらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。下記で使用する 1 × 1 の画像スケールでは、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を示し、ピクセルはラスタ出力を示し、寸法はレンダリングスケールにも依存します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

長いノートを含む PDF エクスポートでは、[BottomFull](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notespositions/) を使用すると必要に応じて追加ページが生成されます。ただし、上記の単一スライド画像呼び出しではこのモードはサポートされていないため使用しないでください。サイズ変更後、クリップされたノートや既存の notes‑master オブジェクトの配置を出力で確認してください。ページ寸法だけを変更しても、すべてのコンテンツが収まる保証にはなりません。ノートのエクスポートに関する詳細は [Convert PowerPoint to PDF with Notes](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **配布資料を PDF にエクスポート**

1 ページに複数のスライドサムネイルを配置するには [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/handoutlayoutingoptions/) を使用します。以下の例では 900 × 600 ポイントのページを設定し、[HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ja/net/aspose.slides.export/handouttype/) を使用してページあたり最大 4 枚のスライドを配置します。横方向のプリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

ページサイズを変更すると、配布資料グリッドの利用可能領域が変わりますが、元のスライドの寸法は変わりません。配布資料用画像を取得するには、個々のスライドの画像メソッドではなく、配布資料レイアウトを指定して [Presentation.GetImages](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages/) を使用してください。Aspose.Slides では、プレゼンテーションレベルの配布資料レンダリングはノートページの寸法を使用しますが、個別スライドの画像呼び出しは配布資料ページを生成しません。レイアウトオプションについては [Handout Mode](/slides/ja/net/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷された用紙サイズを区別して管理してください。

- **プレゼンテーションビューア:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。他のアプリケーションがファイルを保存した場合、再度開いて寸法を確認してください。そのアプリケーションの形式変換により正規化されることがあります。
- **エクスポート形式:** 上記のノートおよび配布資料の PDF 例は設定されたページ寸法を使用します。ラスタ画像は整数ピクセル寸法とレンダリングスケールを使用するため、画像出力では小数点以下のポイント値が丸められることがあります。通常のスライドのエクスポートはノートページサイズを適用しません。
- **プリンタードライバー:** 用紙の選択、自動回転、ページに合わせる設定により、プレゼンテーションや PDF に保存された寸法を変更せずに実際の出力が変わることがあります。特定の用紙サイズの場合、プリンター設定を合わせて印刷プレビューを確認してください。

## **FAQ**

**特定のスライドだけのノートサイズを設定できますか？**

ノートページサイズはプレゼンテーション全体の設定です。個々のスライドは異なるノート内容を持つことができますが、このプロパティはスライドごとに別々のページサイズを提供しません。

**ノートの向きを変更してもスライドが変わらなかったのはなぜですか？**

ノートページと通常スライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果のサイズが異なるのはなぜですか？**

まず保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。もし変更されていれば、別のアプリケーションで保存または変換した際にページ設定が変わっていないか確認します。変更がない場合は、エクスポートレイアウト、画像スケール、ビューア設定、プリンターの用紙選択を確認してください。