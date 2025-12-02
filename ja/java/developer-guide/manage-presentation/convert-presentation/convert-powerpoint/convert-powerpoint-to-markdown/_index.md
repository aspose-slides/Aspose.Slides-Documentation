---
title: JavaでPowerPointプレゼンテーションをMarkdownに変換
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
description: "Aspose.Slides for Java を使用して、PowerPoint スライド（PPT、PPTX）をきれいな Markdown に変換し、ドキュメント作成を自動化し、書式を保持します。"
---

{{% alert color="info" %}} 

PowerPoint から Markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から Markdown へのエクスポートはデフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を設定し、Markdown ドキュメントで参照される画像が保存される `BasePath` も設定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. オブジェクトを Markdown ファイルとして保存するために、[Save ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)メソッドを使用します。

以下の Java コードは PowerPoint を Markdown に変換する方法を示しています。
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## PowerPoint をさまざまな Markdown フレーバーに変換

Aspose.Slides は、PowerPoint を Markdown（基本構文を含む）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab、その他 17 の Markdown フレーバーに変換できます。

以下の Java コードは PowerPoint を CommonMark に変換する方法を示しています。
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


サポートされている 23 の Markdown フレーバーは、[Flavor 列挙体](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) と [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) クラスに一覧されています。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) クラスは、結果の Markdown ファイルに使用できるプロパティや列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) 列挙体は、画像の描画や処理方法を決定する値（`Sequential`, `TextOnly`, `Visual`）に設定できます。

### **画像を順次変換**

画像を順に個別に表示させたい場合は、Sequential オプションを選択する必要があります。以下の Java コードは、画像を含むプレゼンテーションを Markdown に変換する方法を示しています。
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


### **画像をビジュアル変換**

画像を Markdown 内で一緒に表示させたい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown ドキュメント内で相対パスが作成されます）、または任意のパスとフォルダー名を指定することもできます。以下の Java コードはその操作を示しています。
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
