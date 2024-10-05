---
title: PowerPointをC#でMarkdownに変換
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords: "PowerPointをMarkdownに変換, pptをmdに変換, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "C#でPowerPointをMarkdownに変換"
---

{{% alert color="info" %}} 

PowerPointからMarkdownへの変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

デフォルトでは、PowerPointからMarkdownへのエクスポートは**画像なし**です。画像を含むPowerPoint文書をエクスポートしたい場合は、`ExportType = MarkdownExportType.Visual`を設定し、Markdown文書内で参照される画像が保存されるBasePathを設定する必要があります。

{{% /alert %}} 

## **PowerPointをMarkdownに変換**

1. プレゼンテーションオブジェクトを表すために[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)メソッドを使用して、オブジェクトをMarkdownファイルとして保存します。

以下のC#コードは、PowerPointをMarkdownに変換する方法を示します：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## PowerPointをMarkdownフレーバーに変換

Aspose.Slidesを使用すると、PowerPointをMarkdown（基本構文を含む）、CommonMark、GitHubフレーバーのMarkdown、Trello、XWiki、GitLab、その他17種類のMarkdownフレーバーに変換できます。

以下のC#コードは、PowerPointをCommonMarkに変換する方法を示します：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

サポートされている23種類のMarkdownフレーバーは、[Flavor列挙体の下に一覧されています](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/)。[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスからです。

## **画像を含むプレゼンテーションをMarkdownに変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスは、生成されるMarkdownファイルのために特定のオプションまたは設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)列挙体は、画像がどのようにレンダリングまたは処理されるかを決定する値に設定できます：`Sequential`、`TextOnly`、`Visual`。

### **画像を順次変換**

生成されるMarkdownに画像を個別に順番に表示させたい場合は、順次オプションを選択する必要があります。以下のC#コードは、画像を含むプレゼンテーションをMarkdownに変換する方法を示します：

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

生成されるMarkdownに画像を一緒に表示させたい場合は、視覚的オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書内に相対パスが構築されます）、または指定したいパスとフォルダ名を指定できます。

以下のC#コードは、その操作を示しています：

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