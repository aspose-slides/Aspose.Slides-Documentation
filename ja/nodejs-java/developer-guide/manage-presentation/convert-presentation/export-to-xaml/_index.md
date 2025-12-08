---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /ja/nodejs-java/export-to-xaml/
---

## **プレゼンテーションのXAMLへのエクスポート**

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-6-release-notes/), we implemented support for XAML export. You can now export your presentations to XAML.

Aspose.Slides 21.6 で、XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。

{{% /alert %}} 

## **XAML について**

XAML は記述型プログラミング言語で、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリ向けにユーザークラスを構築または記述することができます。

XML ベースの言語である XAML は、GUI を記述するための Microsoft のバリアントです。ほとんどの場合、デザイナーを使って XAML ファイルを操作しますが、GUI を手動で記述・編集することも可能です。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この JavaScript コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) クラスからエクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションを選択できます。

例えば、XAML にエクスポートする際に隠しスライドも含めたい場合は、[setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) メソッドを true に設定できます。このサンプル JavaScript コードをご覧ください:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) を使用します。元のフォントが見つからない場合のフォールバックフォントとして使用され、予期しない置き換えを防止します。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としており、具体的な動作や特定の構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。

**隠しスライドはサポートされていますか？また、デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは隠しスライドは含まれません。これを制御するには、[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) を使用します。エクスポートが不要な場合は無効のままにしてください。