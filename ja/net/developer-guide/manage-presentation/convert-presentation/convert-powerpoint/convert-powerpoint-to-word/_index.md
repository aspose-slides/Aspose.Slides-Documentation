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
description: ".NET 用 Aspose.Slides を使用し、C#で PowerPoint の PPT および PPTX スライドを編集可能な Word 文書に変換します。レイアウト、画像、書式設定が正確に保持されます。"
---

## **概要**

本記事は、開発者向けに Aspose.Slides for .NET と Aspose.Words for .NET を使用して PowerPoint および OpenDocument のプレゼンテーションを Word 文書に変換するソリューションを提供します。ステップバイステップのガイドで変換プロセスのすべての段階を案内します。

## **プレゼンテーションを Word 文書に変換する**

以下の手順に従って、PowerPoint または OpenDocument のプレゼンテーションを Word 文書に変換します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーション ファイルをロードします。
2. [Document](https://reference.aspose.com/words/net/aspose.words/document/) と [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) クラスのインスタンスを作成して、Word 文書を生成します。
3. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) プロパティを使用して、Word 文書のページサイズをプレゼンテーションと同じに設定します。
4. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) プロパティを使用して、Word 文書の余白を設定します。
5. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) プロパティを使用して、すべてのプレゼンテーション スライドを処理します。
   - [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) インターフェイスの `GetImage` メソッドを使用してスライド画像を生成し、メモリ ストリームに保存します。
   - [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) クラスの `InsertImage` メソッドを使用して、スライド画像を Word 文書に追加します。
6. Word 文書をファイルに保存します。

例として、以下のようなプレゼンテーション "sample.pptx" があるとします：

![PowerPoint プレゼンテーション](PowerPoint.png)

以下の C# コード例は、PowerPoint プレゼンテーションを Word 文書に変換する方法を示しています：
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

PowerPoint と OpenDocument のプレゼンテーションを Word 文書に変換することで得られる利点を確認するには、[**オンライン PPT から Word へのコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-word) をお試しください。 

{{% /alert %}}

## **FAQ**

**PowerPoint と OpenDocument のプレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

C# プロジェクトに [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) と [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) の対応する NuGet パッケージを追加するだけで済みます。両方のライブラリはスタンドアロンの API として動作し、Microsoft Office のインストールは必要ありません。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides for .NET は [すべてのプレゼンテーション形式をサポート](/slides/ja/net/supported-file-formats/) しており、PPT、PPTX、ODP などの一般的なファイル形式が含まれます。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。