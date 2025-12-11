---
title: Android で PowerPoint プレゼンテーションを Markdown に変換する
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメント化を自動化し、書式を保持します。"
---

{{% alert color="info" %}} 

PowerPoint から Markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/) で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から Markdown へのエクスポートはデフォルトで**画像なし**です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を設定し、さらに Markdown ドキュメントで参照される画像が保存される `BasePath` を設定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換する**

1. プレゼンテーション オブジェクトを表すために [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. オブジェクトを Markdown ファイルとして保存するために [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) メソッドを使用します。

この Java コードは PowerPoint を Markdown に変換する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint を Markdown フレーバーに変換する**

Aspose.Slides を使用すると、PowerPoint を基本構文を含む Markdown、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab、その他 17 の Markdown フレーバーに変換できます。

この Java コードは PowerPoint を CommonMark に変換する方法を示しています:
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


サポートされている 23 の Markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) クラスの [Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) 列挙体に一覧されています。

## **画像を含むプレゼンテーションを Markdown に変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) クラスは、生成される Markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。例えば、[MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) 列挙体は、画像のレンダリングまたは処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次変換する**

画像を Markdown に個別に順番に表示したい場合は、Sequential オプションを選択する必要があります。この Java コードは画像を含むプレゼンテーションを Markdown に変換する方法を示しています:
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


### **画像を視覚的に変換する**

画像を Markdown にまとめて表示したい場合は、visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown ドキュメント内で相対パスが構築されます）、または任意のパスとフォルダー名を指定することもできます。

この Java コードは操作を実演しています:
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

**ハイパーリンクは Markdown へのエクスポートで維持されますか？**

はい。テキストの [hyperlinks](/slides/ja/androidjava/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/androidjava/slide-transition/) と [animations](/slides/ja/androidjava/powerpoint-animation/) は変換されません。

**