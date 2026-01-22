---
title: JavaScript で PowerPoint プレゼンテーションを Markdown に変換
linktitle: PowerPoint を Markdown に
type: docs
weight: 140
url: /ja/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に
- プレゼンテーションを MD に
- スライドを MD に
- PPT を MD に
- PPTX を MD に
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で PowerPoint スライド（PPT、PPTX）を Aspose.Slides for Node.js（Java 経由）を使用してクリーンな Markdown に変換し、ドキュメントを自動化し、書式を保持します。"
---

{{% alert color="warning" %}} 

PowerPoint から markdown へのエクスポートはデフォルトで**画像なし**です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を呼び出し、markdown ドキュメントで参照される画像が保存される `BasePath` を設定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. オブジェクトを markdown ファイルとして保存するには、[save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) メソッドを使用します。

この JavaScript コードは PowerPoint を markdown に変換する方法を示しています。
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

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバー markdown、Trello、XWiki、GitLab、その他 17 種類の markdown フレーバーに変換できます。

この JavaScript コードは PowerPoint を CommonMark に変換する方法を示しています。
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


サポートされている 23 の markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) クラスの [Flavor 列挙](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) に一覧化されています。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) クラスは、結果の markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) 列挙は、画像のレンダリングや処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次変換**

画像を結果の markdown に個別に順番に表示したい場合は、Sequential オプションを選択する必要があります。この JavaScript コードは、画像を含むプレゼンテーションを markdown に変換する方法を示しています。
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


### **画像をビジュアル変換**

画像を結果の markdown にまとめて表示したい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内で相対パスが作成されます）、または希望のパスとフォルダー名を指定できます。

この JavaScript コードはその操作を示しています。
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

**ハイパーリンクは Markdown へのエクスポートで保持されますか？**

はい。テキストの[hyperlinks](/slides/ja/nodejs-java/manage-hyperlinks/)は標準的な Markdown リンクとして保持されます。スライドの[transitions](/slides/ja/nodejs-java/slide-transition/)や[animations](/slides/ja/nodejs-java/powerpoint-animation/)は変換されません。

**マルチスレッドで実行して変換を高速化できますか？**

ファイル単位で並列処理は可能ですが、スレッド間で同じ[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)インスタンスを[共有しない](/slides/ja/nodejs-java/multithreading/)でください。競合を避けるために、ファイルごとに別々のインスタンスまたはプロセスを使用します。

**画像はどうなりますか？どこに保存され、パスは相対ですか？**

[Images](/slides/ja/nodejs-java/image/) は専用フォルダーにエクスポートされ、Markdown ファイルはデフォルトで相対パスでそれらを参照します。ベース出力パスとアセットフォルダー名を設定して、予測可能なリポジトリ構造を維持できます。