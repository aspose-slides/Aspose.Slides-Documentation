---
title: PowerPointをJavaでMarkdownに変換
type: docs
weight: 140
url: /java/convert-powerpoint-to-markdown/
keywords: "PowerPointをMarkdownに変換, pptをmdに変換, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, Java, Aspose.Slides for Java"
description: "JavaでPowerPointをMarkdownに変換"
---

{{% alert color="info" %}} 

PowerPointからMarkdownへの変換のサポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPointからMarkdownへのエクスポートは、デフォルトで**画像なし**です。画像を含むPowerPoint文書をエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)`を設定し、Markdown文書で参照される画像が保存される`BasePath`も設定する必要があります。

{{% /alert %}} 

## **PowerPointをMarkdownに変換**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)メソッドを使用して、オブジェクトをMarkdownファイルとして保存します。

このJavaコードは、PowerPointをMarkdownに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## PowerPointをMarkdownフレーバーに変換

Aspose.Slidesを使用すると、PowerPointをMarkdown（基本構文を含む）、CommonMark、GitHubフレーバーのMarkdown、Trello、XWiki、GitLab、その他17のMarkdownフレーバーに変換できます。

このJavaコードは、PowerPointをCommonMarkに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

サポートされている23のMarkdownフレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/)クラスの[Flavor列挙型](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/)の下に[リストされています](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/)。

## **画像を含むプレゼンテーションをMarkdownに変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/)クラスは、生成されるMarkdownファイルの特定のオプションまたは設定を使用できるプロパティと列挙型を提供します。[MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/)列挙型は、画像がどのようにレンダリングまたは処理されるかを決定する値に設定できます：`Sequential`、`TextOnly`、`Visual`。

### **画像を順次変換**

結果のMarkdownに画像を個別に表示させたい場合は、順次オプションを選択する必要があります。このJavaコードは、画像を含むプレゼンテーションをMarkdownに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **画像を視覚的に変換**

結果のMarkdownに画像を一緒に表示させたい場合は、視覚的オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書内に相対パスが生成されます）、または希望するパスとフォルダ名を指定できます。

このJavaコードは、操作を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```