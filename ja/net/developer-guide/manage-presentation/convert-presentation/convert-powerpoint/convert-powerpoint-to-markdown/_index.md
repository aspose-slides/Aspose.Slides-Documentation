---
title: "C# で PowerPoint を Markdown に変換"
type: docs
weight: 140
url: /ja/net/convert-powerpoint-to-markdown/
keywords: "PowerPoint を Markdown に変換, ppt を md に変換, PowerPoint, PPT, PPTX, Presentation, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "C# で PowerPoint を Markdown に変換"
---

{{% alert color="info" %}} 

PowerPoint から markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) にて実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から markdown へのエクスポートはデフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`ExportType = MarkdownExportType.Visual` を設定し、markdown ドキュメントで参照される画像が保存される BasePath を設定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. プレゼンテーション オブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. オブジェクトを markdown ファイルとして保存するには、[Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)メソッドを使用します。

この C# コードは PowerPoint を markdown に変換する方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバー markdown、Trello、XWiki、GitLab、その他 17 種類の markdown フレーバーに変換できます。

この C# コードは PowerPoint を CommonMark に変換する方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


サポートされている 23 の markdown フレーバーは、[Flavor 列挙体](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) に一覧されており、[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスから参照できます。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスは、生成される markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列挙体は、画像の描画または処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次変換**

画像を結果の markdown に個別に順番に表示させたい場合は、順次オプションを選択する必要があります。この C# コードは、画像を含むプレゼンテーションを markdown に変換する方法を示しています:
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


### **画像を視覚的に変換**

画像を結果の markdown に一緒に表示させたい場合は、視覚オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内で相対パスが構築されます）、または任意のパスとフォルダー名を指定できます。

この C# コードは操作を示しています:
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

**ハイパーリンクは Markdown へのエクスポートで保持されますか？**

はい。テキスト [hyperlinks](/slides/ja/net/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/net/slide-transition/) と [animations](/slides/ja/net/powerpoint-animation/) は変換されません。

**複数スレッドで実行して変換を高速化できますか？**

ファイル単位での並列処理は可能ですが、同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください（[don’t share](/slides/ja/net/multithreading/)）。ファイルごとに別々のインスタンスまたはプロセスを使用して競合を回避してください。

**画像はどう扱われますか？保存先はどこで、パスは相対ですか？**

[Images](/slides/ja/net/image/) は専用フォルダーにエクスポートされ、Markdown ファイルはデフォルトで相対パスで参照します。ベース出力パスとアセットフォルダー名を構成して、予測可能なリポジトリ構造を維持できます。