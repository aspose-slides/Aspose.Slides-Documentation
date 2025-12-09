---
title: .NET で PowerPoint プレゼンテーションを Markdown に変換
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- PowerPoint
- プレゼンテーション
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメントを自動化し、書式を保持します。"
---

{{% alert color="info" %}} 

PowerPoint から markdown への変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から markdown へのエクスポートは、デフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`ExportType = MarkdownExportType.Visual` を設定し、markdown ドキュメントで参照される画像が保存される BasePath を指定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換する**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. オブジェクトを markdown ファイルとして保存するには、[Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)メソッドを使用します。

以下の C# コードは、PowerPoint を markdown に変換する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint を Markdown フレーバーに変換する**

Aspose.Slides は、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバー markdown、Trello、XWiki、GitLab、その他 17 の markdown フレーバーに変換できます。

以下の C# コードは、PowerPoint を CommonMark に変換する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


23 のサポートされている markdown フレーバーは、[Flavor 列挙体](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/)に一覧されており、[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスから参照できます。

## **画像を含むプレゼンテーションを Markdown に変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスは、生成される markdown ファイルに対して特定のオプションや設定を使用できるプロパティや列挙体を提供します。例えば、[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)列挙体は、画像のレンダリングや処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次変換する**

結果の markdown で画像を1枚ずつ順番に表示したい場合は、sequential オプションを選択する必要があります。以下の C# コードは、画像を含むプレゼンテーションを markdown に変換する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```


### **画像を視覚的に変換する**

結果の markdown で画像をまとめて表示したい場合は、visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内で相対パスが生成されます）、または任意のパスとフォルダー名を指定することもできます。

以下の C# コードは、操作を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```


## **FAQ**

**ハイパーリンクは Markdown へのエクスポート後も保持されますか？**

はい。テキストの[hyperlinks](/slides/ja/net/manage-hyperlinks/)は標準的な Markdown リンクとして保持されます。スライドの[transitions](/slides/ja/net/slide-transition/)や[animations](/slides/ja/net/powerpoint-animation/)は変換されません。

**