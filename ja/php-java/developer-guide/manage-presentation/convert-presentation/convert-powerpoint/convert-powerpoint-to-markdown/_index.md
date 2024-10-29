---
title: PowerPointをMarkdownに変換
type: docs
weight: 140
url: /ja/php-java/convert-powerpoint-to-markdown/
keywords: "PowerPointをMarkdownに変換, pptをmdに変換, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, Java, Aspose.Slides for PHP via Java"
description: "PowerPointをMarkdownに変換"
---

{{% alert color="info" %}} 

PowerPointからMarkdownへの変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPointからMarkdownへのエクスポートは、デフォルトで**画像なし**です。画像を含むPowerPoint文書をエクスポートする場合は、 `markdownSaveOptions.setExportType(MarkdownExportType::Visual)`を設定し、Markdown文書に参照される画像が保存される`BasePath`も設定する必要があります。

{{% /alert %}} 

## **PowerPointをMarkdownに変換**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)メソッドを使用して、オブジェクトをMarkdownファイルとして保存します。

このPHPコードは、PowerPointをMarkdownに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.md", SaveFormat::Md);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## PowerPointをMarkdownフレーバーに変換

Aspose.Slidesは、PowerPointを基本構文を含むMarkdown、CommonMark、GitHubフレーバーのMarkdown、Trello、XWiki、GitLab、および17種類の他のMarkdownフレーバーに変換することを可能にします。

このPHPコードは、PowerPointをCommonMarkに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setFlavor(Flavor->CommonMark);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

サポートされている23のMarkdownフレーバーは、[Flavor列挙型](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/)の下に[MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/)クラスから一覧表示されています。

## **画像を含むプレゼンテーションをMarkdownに変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/)クラスは、結果のMarkdownファイルのために特定のオプションや設定を使用できるプロパティと列挙型を提供します。[MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/)列挙型は、画像がどのようにレンダリングまたは処理されるかを決定する値に設定できます：`Sequential`、 `TextOnly`、 `Visual`。

### **画像を順次変換**

結果のMarkdownに画像が1つずつ順番に表示されるようにしたい場合は、順次オプションを選択する必要があります。このPHPコードは、画像を含むプレゼンテーションをMarkdownに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setShowHiddenSlides(true);
    $markdownSaveOptions->setShowSlideNumber(true);
    $markdownSaveOptions->setFlavor(Flavor->Github);
    $markdownSaveOptions->setExportType(MarkdownExportType::Sequential);
    $markdownSaveOptions->setNewLineType(NewLineType::Windows);
    $pres->save("doc.md", array(1, 2, 3, 4, 5, 6, 7, 8, 9 ), SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **画像を視覚的に変換**

結果のMarkdownに画像をまとめて表示したい場合は、視覚的オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書内に相対パスが構築されます）、または好みのパスとフォルダー名を指定することができます。

このPHPコードは、操作を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $outPath = "c:/documents";
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setExportType(MarkdownExportType::Visual);
    $markdownSaveOptions->setImagesSaveFolderName("md-images");
    $markdownSaveOptions->setBasePath($outPath);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```