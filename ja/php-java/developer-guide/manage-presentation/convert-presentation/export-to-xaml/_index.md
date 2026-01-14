---
title: PHPでプレゼンテーションをXAMLにエクスポート
linktitle: プレゼンテーションからXAMLへ
type: docs
weight: 30
url: /ja/php-java/export-to-xaml/
keywords:
- PowerPointをエクスポート
- OpenDocumentをエクスポート
- プレゼンテーションをエクスポート
- PowerPointを変換
- OpenDocumentを変換
- プレゼンテーションを変換
- PowerPointからXAMLへ
- OpenDocumentからXAMLへ
- プレゼンテーションからXAMLへ
- PPTをXAMLへ
- PPTXをXAMLへ
- ODPをXAMLへ
- PPTをXAMLとして保存
- PPTXをXAMLとして保存
- ODPをXAMLとして保存
- PPTをXAMLにエクスポート
- PPTXをXAMLにエクスポート
- ODPをXAMLにエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint と OpenDocument のスライドを XAML に変換します — レイアウトを保持した迅速な Office フリーのソリューションです。"
---

## **プレゼンテーションを XAML にエクスポート**

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/) では XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。

{{% /alert %}} 

## **XAML について**

XAML は記述型プログラミング言語であり、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述するために使用できます。

XML ベースの言語である XAML は、Microsoft が GUI を記述するために提供する独自のバリエーションです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、GUI を直接記述・編集することも可能です。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この PHP コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
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


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) クラスからオプションを選択して、エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定できます。

たとえば、エクスポート時にプレゼンテーションに含まれる非表示スライドも XAML に追加したい場合は、`true` の値で [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) メソッドを使用します。以下のサンプル PHP コードをご参照ください:
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


## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) の [デフォルトの通常フォント](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) を設定します。元のフォントが見つからない場合にフォールバックとして使用され、予期しない置換を防止できます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、正確な動作や特定の構文のサポートはターゲット プラットフォームに依存します。ご利用の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか、デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。