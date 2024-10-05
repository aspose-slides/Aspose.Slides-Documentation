---
title: PowerPointをJavaでMarkdownに変換する
type: docs
weight: 140
url: /androidjava/convert-powerpoint-to-markdown/
keywords: "PowerPointをMarkdownに変換, pptをmdに変換, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointをMarkdownに変換する"
---

{{% alert color="info" %}} 

PowerPointからMarkdownへの変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPointからMarkdownへのエクスポートは、デフォルトで**画像なし**です。画像を含むPowerPoint文書をエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)`を設定し、Markdown文書に参照される画像が保存される`BasePath`を設定する必要があります。

{{% /alert %}} 

## **PowerPointをMarkdownに変換する**

1. プレゼンテーションオブジェクトを表すために[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. オブジェクトをMarkdownファイルとして保存するために[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)メソッドを使用します。

このJavaコードは、PowerPointをMarkdownに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## PowerPointをMarkdownフレーバーに変換する

Aspose.Slidesは、PowerPointをMarkdown（基本構文を含む）、CommonMark、GitHubフレーバーのMarkdown、Trello、XWiki、GitLab、その他17のMarkdownフレーバーに変換することができます。

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

サポートされている23のMarkdownフレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/)クラスの[Flavor列挙型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/)で一覧表示されています。

## **画像を含むプレゼンテーションをMarkdownに変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/)クラスは、生成されるMarkdownファイルに対して特定のオプションや設定を使用することを可能にするプロパティと列挙型を提供します。[MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/)列挙型は、画像がどのようにレンダリングまたは処理されるかを決定する値を設定できます：`Sequential`、`TextOnly`、`Visual`。

### **画像を順次変換する**

画像が結果のMarkdownに個別に順に表示されるようにする場合は、順次オプションを選択する必要があります。このJavaコードは、画像を含むプレゼンテーションをMarkdownに変換する方法を示しています：

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

### **画像をビジュアルに変換する**

画像を結果のMarkdownにまとめて表示させたい場合は、ビジュアルオプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書内で画像の相対パスが構築されます）、または好みのパスとフォルダー名を指定することができます。

このJavaコードは操作を示しています：

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