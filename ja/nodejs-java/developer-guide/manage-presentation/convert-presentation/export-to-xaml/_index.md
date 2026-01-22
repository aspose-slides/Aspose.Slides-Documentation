---
title: JavaScript でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションを XAML に変換
type: docs
weight: 30
url: /ja/nodejs-java/export-to-xaml/
keywords:
- PowerPoint のエクスポート
- OpenDocument のエクスポート
- プレゼンテーションのエクスポート
- PowerPoint の変換
- OpenDocument の変換
- プレゼンテーションの変換
- PowerPoint を XAML に変換
- OpenDocument を XAML に変換
- プレゼンテーションを XAML に変換
- PPT を XAML に変換
- PPTX を XAML に変換
- ODP を XAML に変換
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js 用 Aspose.Slides を使用し、JavaScript で PowerPoint と OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保持する、迅速で Office 不要のソリューションです。"
---

## **プレゼンテーションの XAML へのエクスポート**

Aspose.Slides は XAML エクスポートをサポートしています。プレゼンテーションを XAML に変換できます。

## **XAML について**

XAML は記述型プログラミング言語で、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用するアプリのユーザークラスを構築または記述するために使用されます。

XML ベースの言語である XAML は、GUI を記述するための Microsoft の独自形式です。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、GUI を手動で記述・編集することも可能です。

## **既定のオプションでプレゼンテーションを XAML にエクスポートする**

この JavaScript コードは、既定の設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
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


## **カスタム オプションでプレゼンテーションを XAML にエクスポートする**

エクスポート プロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションは、[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) クラスから選択できます。

たとえば、エクスポート時にプレゼンテーション内の非表示スライドも XAML に含めたい場合は、[setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) メソッドを true に設定します。このサンプル JavaScript コードをご覧ください:
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

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) を使用します。元のフォントが欠落している場合のフォールバック フォントとして使用され、予期しない置き換えを防止します。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、具体的な動作や特定構文のサポートは対象プラットフォームに依存します。使用環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合はこのオプションを無効にしてください。