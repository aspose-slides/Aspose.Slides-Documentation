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
- プレゼンテーションから Word へ
- スライドから Word へ
- PPT から Word へ
- PPTX から Word へ
- PowerPoint から DOCX へ
- プレゼンテーションから DOCX へ
- スライドから DOCX へ
- PPT から DOCX へ
- PPTX から DOCX へ
- PowerPoint から DOC へ
- プレゼンテーションから DOC へ
- スライドから DOC へ
- PPT から DOC へ
- PPTX から DOC へ
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用し、C# で PowerPoint PPT および PPTX スライドを編集可能な Word 文書に変換します。レイアウト、画像、書式設定が正確に保持されます。"
---

## **概要**

この記事では、Aspose.Slides for .NET と Aspose.Words for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換する方法を開発者向けに提供します。ステップバイステップのガイドで、変換プロセスのすべての段階を説明します。

## **プレゼンテーションを Word 文書に変換**

PowerPoint または OpenDocument のプレゼンテーションを Word 文書に変換する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーション ファイルを読み込みます。
2. [Document](https://reference.aspose.com/words/net/aspose.words/document/) と [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) のインスタンスを作成して、Word 文書を生成します。
3. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) プロパティを使用して、Word 文書のページ サイズをプレゼンテーションに合わせます。
4. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) プロパティを使用して、Word 文書の余白を設定します。
5. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) プロパティでプレゼンテーションのすべてのスライドを走査します。
   - [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) インタフェースの `GetImage` メソッドでスライド画像を取得し、メモリ ストリームに保存します。
   - [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) クラスの `InsertImage` メソッドでスライド画像を Word 文書に追加します。
6. Word 文書をファイルに保存します。

例として、次のようなプレゼンテーション「sample.pptx」があるとします。

![PowerPoint プレゼンテーション](PowerPoint.png)

以下の C# コード例は、PowerPoint プレゼンテーションを Word 文書に変換する方法を示しています。
```cs
// プレゼンテーション ファイルを読み込む。
using var presentation = new Presentation("sample.pptx");

// Document と DocumentBuilder オブジェクトを作成する。
var document = new Document();
var builder = new DocumentBuilder(document);

// Word 文書のページサイズを設定する。
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word 文書の余白を設定する。
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Go through all the presentation slides.
foreach (var slide in presentation.Slides)
{
    // スライド画像を生成し、メモリ ストリームに保存する。
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // スライド画像を Word 文書に追加する。
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word 文書をファイルに保存する。
document.Save("output.docx");
```


結果:

![Word 文書](Word.png)

{{% alert color="primary" %}} 

[**Online PPT to Word Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) を試して、PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換することで得られるメリットをご確認ください。 

{{% /alert %}}

## **FAQ**

**PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

C# プロジェクトに [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) と [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) の対応 NuGet パッケージを追加するだけで済みます。両ライブラリはスタンドアロン API として動作し、Microsoft Office のインストールは不要です。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides for .NET は [すべてのプレゼンテーション形式をサポート](/slides/ja/net/supported-file-formats/) しており、PPT、PPTX、ODP などの一般的なファイル タイプを含みます。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。