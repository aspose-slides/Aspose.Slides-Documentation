---
title: AndroidでPowerPointプレゼンテーションをMarkdownに変換
linktitle: PowerPointをMarkdownに変換
type: docs
weight: 140
url: /ja/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをMDに変換
- プレゼンテーションをMDに変換
- スライドをMDに変換
- PPTをMDに変換
- PPTXをMDに変換
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
- Android
- Java
- Aspose.Slides
description: "Javaを使用し、Android用Aspose.SlidesでPowerPointスライド（PPT、PPTX）をクリーンなMarkdownに変換し、ドキュメント自動化と書式を保持します。"
---

Aspose.Slides はプレゼンテーションから Markdown への変換をサポートします。

{{% alert color="warning" %}} 
PowerPoint の markdown エクスポートはデフォルトで**画像なし**です。画像を含む PowerPoint ドキュメントをエクスポートする場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を設定し、markdown ドキュメントで参照される画像の保存先である `BasePath` も設定する必要があります。
{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. プレゼンテーション オブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. オブジェクトを markdown ファイルとして保存するために、[Save ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)メソッドを使用します。

この Java コードは PowerPoint を markdown に変換する方法を示します：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバー markdown、Trello、XWiki、GitLab、その他 17 の markdown フレーバーに変換できます。

この Java コードは PowerPoint を CommonMark に変換する方法を示します：
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


サポートされている 23 の markdown フレーバーは、[Flavor 列挙体](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) に一覧表示されており、[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) クラスから参照できます。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) クラスは、結果の markdown ファイルに使用できるプロパティや列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) 列挙体は、画像のレンダリングや処理方法を決定する `Sequential`、`TextOnly`、`Visual` のいずれかに設定できます。

### **画像を順次変換**

結果の markdown で画像を個別に順番に表示したい場合は、Sequential オプションを選択する必要があります。この Java コードは、画像を含むプレゼンテーションを markdown に変換する方法を示します：
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

結果の markdown で画像を一緒に表示したい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内で相対パスが構築されます）、または任意のパスとフォルダー名を指定することもできます。

この Java コードは操作を実演します：
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

**ハイパーリンクは Markdown へのエクスポート後も残りますか？**

はい。テキスト [hyperlinks](/slides/ja/androidjava/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/androidjava/slide-transition/) と [animations](/slides/ja/androidjava/powerpoint-animation/) は変換されません。

**複数スレッドで実行して変換を高速化できますか？**

ファイルごとに並列処理は可能ですが、同じ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) インスタンスをスレッド間で[共有しない](/slides/ja/androidjava/multithreading/)ようにしてください。ファイルごとに別々のインスタンスまたはプロセスを使用して競合を回避します。

**画像はどうなりますか—どこに保存され、パスは相対ですか？**

[Images](/slides/ja/androidjava/image/) は専用フォルダーにエクスポートされ、Markdown ファイルはデフォルトで相対パスで参照します。出力先のベースパスやアセットフォルダー名を設定して、リポジトリ構造を予測可能に保つことができます。