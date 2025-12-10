---
title: Java で PowerPoint プレゼンテーションを Markdown に変換
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメントを自動化しながら書式を維持します。"
---

{{% alert color="info" %}} 

PowerPoint から Markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から Markdown へのエクスポートは既定で **画像なし** です。画像を含む PowerPoint 文書をエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を設定し、Markdown 文書で参照される画像の保存先となる `BasePath` も指定する必要があります。

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. プレゼンテーション オブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. オブジェクトを Markdown ファイルとして保存するために、[Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) メソッドを使用します。

この Java コードは PowerPoint を Markdown に変換する方法を示しています。  
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides を使用すると、PowerPoint を Markdown（基本構文を含む）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab、その他 17 種類の Markdown フレーバーに変換できます。

この Java コードは PowerPoint を CommonMark に変換する方法を示しています。  
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


サポートされている 23 の Markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) クラスの [Flavor 列挙体](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) に一覧されています。

## **Convert a Presentation Containing Images to Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) クラスは、生成される Markdown ファイルに対して使用できるプロパティや列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) 列挙体は、画像の描画または処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **Convert Images Sequentially**

画像を 1 枚ずつ順番に Markdown に出力したい場合は、Sequential オプションを選択します。この Java コードは、画像を含むプレゼンテーションを Markdown に変換する方法を示しています。  
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


### **Convert Images Visually**

画像を Markdown にまとめて出力したい場合は、Visual オプションを選択します。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown 文書内では相対パスが作成されます）、または任意のパスとフォルダー名を指定することもできます。

この Java コードはその操作を実演しています。  
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


## **FAQ**

**Do hyperlinks survive the export to Markdown?**

はい。テキストの [hyperlinks](/slides/ja/java/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/java/slide-transition/) や [animations](/slides/ja/java/powerpoint-animation/) は変換されません。

**Can I speed up conversion by running it in multiple threads?**

ファイル単位で並列化は可能ですが、同じ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。ファイルごとに個別のインスタンスまたはプロセスを使用して競合を回避します。

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/ja/java/image/) は専用フォルダーにエクスポートされ、Markdown ファイルは既定で相対パスで参照します。ベース出力パスやアセット フォルダー名を設定すれば、リポジトリ構造を予測可能に保つことができます。