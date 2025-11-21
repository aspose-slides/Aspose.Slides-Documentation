---
title: JavaScript で PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/nodejs-java/convert-powerpoint-to-markdown/
keywords: "PowerPoint を Markdown に変換, ppt を md に変換, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint を Markdown に変換"
---

{{% alert color="info" %}} 
PowerPoint から Markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-23-7-release-notes/) で実装されました。
{{% /alert %}} 

{{% alert color="warning" %}} 
PowerPoint から Markdown へのエクスポートはデフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を呼び出し、さらに Markdown ドキュメントで参照される画像の保存先となる `BasePath` を設定する必要があります。
{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションオブジェクトを表します。
2. [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) メソッドを使用して、オブジェクトを Markdown ファイルとして保存します。

この JavaScript コードは、PowerPoint を Markdown に変換する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を Markdown（基本構文を含む）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab、その他 17 種類の Markdown フレーバーに変換できます。

この JavaScript コードは、PowerPoint を CommonMark に変換する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


サポートされている 23 の Markdown フレーバーは、[Flavor 列挙体](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) の下にある [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) クラスから [一覧表示されています](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/)。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) クラスは、結果の Markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) 列挙体は、画像のレンダリングや処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次変換**

結果の Markdown で画像を個別に順番に表示したい場合は、Sequential オプションを選択する必要があります。この JavaScript コードは、画像を含むプレゼンテーションを Markdown に変換する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **画像を視覚的に変換**

結果の Markdown で画像をまとめて表示したい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown ドキュメント内で相対パスが作成されます）、または任意のパスとフォルダー名を指定することもできます。

この JavaScript コードは、操作を実演しています。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ハイパーリンクは Markdown へのエクスポート後も残りますか？**

はい。テキストの [hyperlinks](/slides/ja/nodejs-java/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/nodejs-java/slide-transition/) や [animations](/slides/ja/nodejs-java/powerpoint-animation/) は変換されません。

**