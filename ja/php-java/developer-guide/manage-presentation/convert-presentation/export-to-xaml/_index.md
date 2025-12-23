---
title: PHP でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/php-java/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションから XAML へ
- PPT から XAML へ
- PPTX から XAML へ
- ODP から XAML へ
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のスライドを XAML に変換します — レイアウトをそのまま保つ、迅速で Office 不要のソリューションです。"
---

## **プレゼンテーションを XAML にエクスポート**

{{% alert color="primary" %}} 
[Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/)で XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。
{{% /alert %}} 

## **XAML について**

XAML は、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms で使用されるアプリのユーザー インターフェイスを構築または記述できる記述型プログラミング言語です。  

XML ベースの言語である XAML は、Microsoft が GUI を記述するために提供するバリアントです。通常はデザイナーを使って XAML ファイルを編集しますが、手動で GUI を記述・編集することも可能です。 

## **デフォルト オプションでプレゼンテーションを XAML にエクスポート**

この PHP コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。
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


## **カスタム オプションでプレゼンテーションを XAML にエクスポート**

[IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) インターフェイスからオプションを選択し、エクスポート プロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定します。

たとえば、エクスポート時に非表示スライドを XAML に追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) プロパティを true に設定します。この PHP サンプルを参照してください。
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


## **よくある質問**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) の [デフォルトの標準フォント](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) を設定します。元のフォントが見つからないときのフォールバック フォントとして使用され、予期しない置き換えを防ぎます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としており、具体的な動作や特定構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？また、デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。これを制御するには [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) を使用します。エクスポートが不要な場合は無効のままにしてください。