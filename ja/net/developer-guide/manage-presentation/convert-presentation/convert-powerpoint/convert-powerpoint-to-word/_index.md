---
title: C# で PowerPoint プレゼンテーションを Word ドキュメントに変換
linktitle: PowerPoint を Word に変換
type: docs
weight: 110
url: /ja/net/convert-powerpoint-to-word/
keywords:
- PowerPoint を DOCX に変換
- OpenDocument を DOCX に変換
- プレゼンテーションを DOCX に変換
- スライドを DOCX に変換
- PPT を DOCX に変換
- PPTX を DOCX に変換
- ODP を DOCX に変換
- PowerPoint を DOC に変換
- OpenDocument を DOC に変換
- プレゼンテーションを DOC に変換
- スライドを DOC に変換
- PPT を DOC に変換
- PPTX を DOC に変換
- ODP を DOC に変換
- PowerPoint を Word に変換
- OpenDocument を Word に変換
- プレゼンテーションを Word に変換
- スライドを Word に変換
- PPT を Word に変換
- PPTX を Word に変換
- ODP を Word に変換
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- ODP を変換
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを Word ドキュメントに簡単に変換する方法をご紹介します。サンプル C# コード付きのステップバイステップガイドは、ドキュメントワークフローを効率化したい開発者向けのソリューションです。"
---

## **概要**

この記事では、Aspose.Slides for .NET と Aspose.Words for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するためのソリューションを開発者向けに提供します。ステップバイステップのガイドで、変換プロセスのすべての段階を案内します。

## **プレゼンテーションを Word 文書に変換**

以下の手順に従って、PowerPoint または OpenDocument プレゼンテーションを Word 文書に変換します。

1. Presentation クラスをインスタンス化し、プレゼンテーション ファイルを読み込みます。
2. Document クラスと DocumentBuilder クラスをインスタンス化して、Word 文書を生成します。
3. DocumentBuilder.PageSetup プロパティを使用して、Word 文書のページサイズをプレゼンテーションと同じに設定します。
4. DocumentBuilder.PageSetup プロパティを使用して、Word 文書の余白を設定します。
5. Presentation.Slides プロパティを使用して、すべてのプレゼンテーション スライドを処理します。
    - `GetImage` メソッドを使用して ISlide インターフェイスからスライド画像を生成し、メモリ ストリームに保存します。
    - `InsertImage` メソッドを使用して DocumentBuilder クラスからスライド画像を Word 文書に追加します。
6. Word 文書をファイルに保存します。

例えば、次のようなプレゼンテーション "sample.pptx" があるとします。

![PowerPoint プレゼンテーション](PowerPoint.png)

以下の C# コード例は、PowerPoint プレゼンテーションを Word 文書に変換する方法を示しています。
```cs
// プレゼンテーション ファイルをロードします。
using var presentation = new Presentation("sample.pptx");

// Document と DocumentBuilder オブジェクトを作成します。
var document = new Document();
var builder = new DocumentBuilder(document);

// Word 文書のページサイズを設定します。
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word 文書の余白を設定します。
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// すべてのプレゼンテーション スライドを処理します。
foreach (var slide in presentation.Slides)
{
    // スライド画像を生成し、メモリ ストリームに保存します。
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // スライド画像を Word 文書に追加します。
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word 文書をファイルに保存します。
document.Save("output.docx");
```


結果：

![Word 文書](Word.png)

{{% alert color="primary" %}} 
当社の[**オンライン PPT から Word 変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-word)を試して、PowerPoint と OpenDocument プレゼンテーションを Word 文書に変換することで得られるメリットをご確認ください。 
{{% /alert %}}

## **よくある質問**

**PowerPoint と OpenDocument プレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

C# プロジェクトに [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) と [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) の各 NuGet パッケージを追加するだけで済みます。両方のライブラリは単独の API として動作し、Microsoft Office をインストールする必要はありません。

**すべての PowerPoint と OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides for .NET は、PPT、PPTX、ODP などの一般的なファイル形式を含むすべてのプレゼンテーション形式を [サポートしています](/slides/ja/net/supported-file-formats/)。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。