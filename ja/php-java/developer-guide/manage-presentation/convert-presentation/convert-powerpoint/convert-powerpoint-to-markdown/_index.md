---
title: PHPでPowerPointプレゼンテーションをMarkdownに変換
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをMDへ
- プレゼンテーションをMDへ
- スライドをMDへ
- PPTをMDへ
- PPTXをMDへ
- PowerPointをMarkdownとして保存
- プレゼンテーションをMarkdownとして保存
- スライドをMarkdownとして保存
- PPTをMDとして保存
- PPTXをMDとして保存
- PPTをMDにエクスポート
- PPTXをMDにエクスポート
- PowerPoint
- プレゼンテーション
- Markdown
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメントを自動化し、書式を保持します。"
---

## **概要**

Aspose.Slides for PHP via Java は、プレゼンテーション コンテンツを Markdown に変換できるようにし、PowerPoint (PPT、PPTX) および OpenDocument (ODP) ファイルをウィキ、Git リポジトリ、静的サイトジェネレーター向けに再利用できるようにします。API はスライドの階層構造を保持しながら、軽量で人間が読みやすい Markdown を生成するため、ドキュメント パイプラインを自動化し、ソースのプレゼンテーションと Markdown ファイルを完全に同期させることができます。

PowerPoint から Markdown への変換サポートは、[Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/) に実装されました。

## **プレゼンテーションを Markdown に変換**

このセクションでは、Aspose.Slides が PowerPoint と OpenDocument のプレゼンテーション (PPT、PPTX、ODP) をクリーンな Markdown に変換し、元のスライド階層、テキスト、主要な書式設定を保持したまま、ドキュメントやバージョン管理されたワークフローでコンテンツを再利用できる方法を説明します。

1. プレゼンテーションを表すために、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) メソッドを使用して、Markdown ファイルとしてエクスポートします。

この PHP コードは、PowerPoint プレゼンテーションを Markdown に変換する方法を示しています。
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **プレゼンテーションを Markdown フレーバーに変換**

Aspose.Slides は、PowerPoint プレゼンテーションを基本構文の Markdown に変換できるだけでなく、CommonMark、GitHub フレーバー Markdown、Trello、XWiki、GitLab、その他 17 の Markdown フレーバーにも変換できます。

次の PHP コードは、PowerPoint プレゼンテーションを CommonMark に変換する方法を示しています。
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


サポートされている 23 種類の Markdown フレーバーは、[Flavor enumeration](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) に一覧されています。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) クラスは、生成される Markdown ファイルを構成できるプロパティと列挙体を公開します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) 列挙体は画像の処理方法を指定します：`Sequential`、`TextOnly`、または `Visual`。

{{% alert color="warning" %}}
デフォルトでは、PowerPoint から Markdown へのエクスポートは **画像を含みません**。画像を埋め込むには、`markdownSaveOptions.setExportType(MarkdownExportType::Visual)` を呼び出し、Markdown ファイルで参照される画像の保存先を指定する `BasePath` を設定します。
{{% /alert %}}

### **画像を順次変換**

結果の Markdown で画像を個別に、1 つずつ順番に表示したい場合は、`Sequential` オプションを選択する必要があります。次の PHP コードは、画像を含むプレゼンテーションを Markdown に変換する方法を示しています。
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


### **画像を視覚的に変換**

結果の Markdown で画像をまとめて表示したい場合は、`Visual` オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown ドキュメント内で相対パスが生成されます）、または希望するディレクトリとフォルダー名を指定することもできます。

次の PHP コードはこの操作を示しています。
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


## **よくある質問**

**ハイパーリンクは Markdown へのエクスポートで保持されますか？**

はい。テキストの [hyperlinks](/slides/ja/php-java/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/php-java/slide-transition/) および [animations](/slides/ja/php-java/powerpoint-animation/) は変換されません。

**