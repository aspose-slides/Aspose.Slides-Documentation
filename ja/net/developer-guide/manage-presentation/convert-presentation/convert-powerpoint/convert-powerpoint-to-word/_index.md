---
title: .NET で PowerPoint プレゼンテーションを Word 文書に変換
linktitle: PowerPoint から Word へ
type: docs
weight: 110
url: /ja/net/convert-powerpoint-to-word/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から Word へ
- プレゼンテーションを Word に
- スライドを Word に
- PPT を Word に
- PPTX を Word に
- PowerPoint を DOCX に
- プレゼンテーションを DOCX に
- スライドを DOCX に
- PPT を DOCX に
- PPTX を DOCX に
- PowerPoint を DOC に
- プレゼンテーションを DOC に
- スライドを DOC に
- PPT を DOC に
- PPTX を DOC に
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して C# で PowerPoint の PPT および PPTX スライドを編集可能な Word 文書に変換し、レイアウト、画像、書式設定を正確に保持します。"
---

## **概要**

この記事では、開発者向けに Aspose.Slides for .NET と Aspose.Words for .NET を使用して PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するソリューションを提供します。ステップバイステップのガイドで、変換プロセスのすべての段階を案内します。

## **プレゼンテーションを Word 文書に変換する**

以下の手順に従って、PowerPoint または OpenDocument プレゼンテーションを Word 文書に変換します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーション ファイルをロードします。
2. Word 文書を生成するために、[Document](https://reference.aspose.com/words/net/aspose.words/document/) と [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) クラスのインスタンスを作成します。
3. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) プロパティを使用して、Word 文書のページ サイズをプレゼンテーションと同じに設定します。
4. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) プロパティを使用して、Word 文書の余白を設定します。
5. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) プロパティを使用して、すべてのプレゼンテーション スライドを処理します。
    - [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) インターフェイスの `GetImage` メソッドを使用してスライド画像を生成し、メモリ ストリームに保存します。
    - [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) クラスの `InsertImage` メソッドを使用して、スライド画像を Word 文書に追加します。
6. Word 文書をファイルに保存します。

例えば、次のようなプレゼンテーション「sample.pptx」があるとします。

![PowerPoint プレゼンテーション](PowerPoint.png)

以下の C# コード例は、PowerPoint プレゼンテーションを Word 文書に変換する方法を示しています。
```cs
// プレゼンテーションファイルを読み込む。
using var presentation = new Presentation("sample.pptx");

// Document と DocumentBuilder オブジェクトを作成。
var document = new Document();
var builder = new DocumentBuilder(document);

// Word 文書のページサイズを設定。
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word 文書の余白を設定。
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// すべてのプレゼンテーションスライドを処理。
foreach (var slide in presentation.Slides)
{
    // スライド画像を生成し、メモリストリームに保存。
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // スライド画像を Word 文書に追加。
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word 文書をファイルに保存。
document.Save("output.docx");
```


結果：

![Word 文書](Word.png)

{{% alert color="primary" %}} 
PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換することで得られるメリットを確認するには、[**Online PPT to Word Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) をお試しください。 
{{% /alert %}}

## **よくある質問**

**PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

必要なのは、[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) と [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) のそれぞれの NuGet パッケージを C# プロジェクトに追加することだけです。両方のライブラリはスタンドアロン API として動作し、Microsoft Office をインストールする必要はありません。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides for .NET は、[すべてのプレゼンテーション形式をサポート](/slides/ja/net/supported-file-formats/)しており、PPT、PPTX、ODP などの一般的なファイル形式を含みます。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。