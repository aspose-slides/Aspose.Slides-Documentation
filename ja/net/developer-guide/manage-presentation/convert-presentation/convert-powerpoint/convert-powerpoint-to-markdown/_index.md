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
description: "Aspose.Slides for .NET を使用して PowerPoint スライド（PPT、PPTX）をきれいな Markdown に変換し、ドキュメントの自動化と書式を維持します。"
---

{{% alert color="info" %}}

PowerPoint から Markdown への変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) に実装されました。

{{% /alert %}}

{{% alert color="warning" %}}

PowerPoint から Markdown へのエクスポートは、既定では **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`ExportType = MarkdownExportType.Visual` を設定し、Markdown ドキュメントで参照される画像が保存される BasePath を指定する必要があります。

{{% /alert %}}

## **PowerPoint を Markdown に変換**

1. プレゼンテーション オブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. オブジェクトを markdown ファイルとして保存するには、[Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method を使用します。

この C# コードは PowerPoint を markdown に変換する方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバー markdown、Trello、XWiki、GitLab、その他 17 種類の markdown フレーバーに変換できます。

この C#コードは PowerPoint を CommonMark に変換する方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


サポートされている 23 の markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスの [Flavor 列挙体](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) に一覧表示されています。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスは、生成される markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列挙体は、画像のレンダリングまたは処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次変換**

画像を結果の markdown に個別に順番に表示したい場合は、Sequential オプションを選択する必要があります。この C# コードは、画像を含むプレゼンテーションを markdown に変換する方法を示しています:
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

結果の markdown に画像を一緒に表示したい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメントでは相対パスが生成されます）、または任意のパスとフォルダー名を指定することもできます。

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

はい。テキストの[ハイパーリンク](/slides/ja/net/manage-hyperlinks/)は標準的な Markdown リンクとして保持されます。スライドの[トランジション](/slides/ja/net/slide-transition/)や[アニメーション](/slides/ja/net/powerpoint-animation/)は変換されません。

**マルチスレッドで実行して変換を高速化できますか？**

ファイル単位で並列処理は可能ですが、スレッド間で同じ[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを[共有しない](/slides/ja/net/multithreading/)ようにしてください。ファイルごとに別々のインスタンスまたはプロセスを使用して競合を回避します。

**画像はどう扱われますか？保存先はどこで、パスは相対ですか？**

[画像](/slides/ja/net/image/)は専用のフォルダーにエクスポートされ、Markdown ファイルは既定で相対パスで参照します。ベース出力パスやアセットフォルダー名を設定して、予測可能なリポジトリ構造を維持できます。