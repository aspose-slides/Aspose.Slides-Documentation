---
title: PHPでプレゼンテーションをXAMLにエクスポート
linktitle: プレゼンテーションをXAMLへ
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
description: "Javaを介したPHP用Aspose.Slidesを使用して、PowerPointおよびOpenDocumentのスライドをXAMLに変換します — レイアウトを維持した高速なOffice不要のソリューション。"
---

## **プレゼンテーションをXAMLにエクスポート**

Aspose.Slides は XAML エクスポートをサポートしています。プレゼンテーションを XAML に変換できます。

## **XAML について**

XAML は、アプリのユーザーインターフェイスを構築または記述できる記述型プログラミング言語で、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用する場合に適しています。  

XAML は XML ベースの言語で、Microsoft が GUI を記述するために提供するバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、GUI を手書きで作成・編集することも可能です。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この PHP コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示します：
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

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定する、[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) クラスからオプションを選択できます。

たとえば、エクスポート時にプレゼンテーションの非表示スライドを XAML に追加させたい場合、[setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) メソッドに `true` を指定できます。この PHP コードサンプルをご覧ください：
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

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) の [デフォルトの通常フォント](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) を設定します — 元のフォントが欠落している場合のフォールバックフォントとして使用されます。これにより予期しない置換を防げます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft XAML スタックとの互換性を目指していますが、具体的な動作や特定構文のサポートはターゲットプラットフォームに依存します。環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは、非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) でこの動作を制御できます — エクスポートが不要な場合は無効にしておいてください。