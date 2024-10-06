---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /ja/php-java/export-to-xaml/

---

# プレゼンテーションをXAMLにエクスポートする

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/)では、XAMLエクスポートのサポートを実装しました。これで、プレゼンテーションをXAMLにエクスポートできるようになりました。

{{% /alert %}} 

# XAMLについて

XAMLは、アプリケーションのユーザーインターフェイスを構築または記述するための記述型プログラミング言語であり、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、およびXamarinフォームを使用するアプリに適しています。

XAMLはXMLベースの言語であり、MicrosoftのGUIを記述するためのバリアントです。ほとんどの場合、XAMLファイルを作成するにはデザイナーを使用しますが、GUIを記述および編集することもできます。

## デフォルトオプションを使用してプレゼンテーションをXAMLにエクスポートする

このPHPコードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## カスタムオプションを使用してプレゼンテーションをXAMLにエクスポートする

[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions)インターフェイスからオプションを選択して、エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにエクスポートする方法を決定できます。

たとえば、Aspose.Slidesにエクスポート時にプレゼンテーションの隠れたスライドを追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-)プロパティをtrueに設定できます。サンプルPHPコードは次のようになります：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```