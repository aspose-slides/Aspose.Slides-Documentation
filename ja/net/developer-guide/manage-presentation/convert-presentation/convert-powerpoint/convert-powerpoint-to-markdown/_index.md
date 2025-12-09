---
title: .NETでPowerPointプレゼンテーションをMarkdownに変換
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/net/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからMDへ
- プレゼンテーションからMDへ
- スライドからMDへ
- PPTからMDへ
- PPTXからMDへ
- PowerPointをMarkdownとして保存
- プレゼンテーションをMarkdownとして保存
- スライドをMarkdownとして保存
- PPTをMDとして保存
- PPTXをMDとして保存
- PPTをMDへエクスポート
- PPTXをMDへエクスポート
- PowerPoint
- プレゼンテーション
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメントを自動化し、書式を保持します。"
---

{{% alert color="info" %}} 

PowerPoint から Markdown への変換サポートは[Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から Markdown へのエクスポートはデフォルトで**画像なし**です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`ExportType = MarkdownExportType.Visual` を設定し、Markdown ドキュメントで参照される画像が保存される BasePath を指定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) メソッドを使用してオブジェクトを Markdown ファイルとして保存します。

以下の C# コードは PowerPoint を Markdown に変換する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を Markdown（基本構文を含む）、CommonMark、GitHub フレーバー Markdown、Trello、XWiki、GitLab、その他 17 種類の Markdown フレーバーに変換できます。

以下の C# コードは PowerPoint を CommonMark に変換する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


サポートされている 23 の Markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions) クラスの[Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor) 列挙体に一覧されています。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions) クラスは、結果の Markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype) 列挙体は、画像のレンダリングや処理方法を決定する `Sequential`、`TextOnly`、`Visual` の各値に設定できます。

### **画像を順次変換**

画像を結果の Markdown に個別に順番で表示したい場合は、Sequential オプションを選択する必要があります。以下の C# コードは画像を含むプレゼンテーションを Markdown に変換する方法を示しています：
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


### **画像をビジュアルに変換**

画像を結果の Markdown にまとめて表示したい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown ドキュメント内で相対パスが構築されます）、または任意のパスとフォルダー名を指定できます。

以下の C# コードはこの操作を示しています：
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

**ハイパーリンクは Markdown へのエクスポート後も維持されますか？**

はい。テキストの[hyperlinks](/slides/ja/net/manage-hyperlinks/)は標準的な Markdown リンクとして保持されます。スライドの[transitions](/slides/ja/net/slide-transition/)や[animations](/slides/ja/net/powerpoint-animation/)は変換されません。

**複数スレッドで実行して変換を高速化できますか？**

ファイル単位での並列処理は可能ですが、同じ[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)インスタンスをスレッド間で[don’t share](/slides/ja/net/multithreading/)しないでください。ファイルごとに別々のインスタンスまたはプロセスを使用して競合を回避します。

**画像はどうなりますか—保存場所はどこで、パスは相対ですか？**

[Images](/slides/ja/net/image/) は専用フォルダーにエクスポートされ、Markdown ファイルはデフォルトで相対パスで参照します。ベース出力パスとアセットフォルダー名を設定して、予測可能なリポジトリ構造を維持できます。