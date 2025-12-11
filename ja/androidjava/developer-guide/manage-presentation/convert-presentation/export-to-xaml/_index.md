---
title: Android で XAML にプレゼンテーションをエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/androidjava/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint および OpenDocument スライドを XAML に変換します。迅速で Office 不要のソリューションで、レイアウトをそのまま保持します。"
---

## **プレゼンテーションを XAML にエクスポート**

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/) では、XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。

{{% /alert %}} 

## **XAML について**

XAML は記述的なプログラミング言語で、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを作成または記述することができます。

XAML は XML ベースの言語で、Microsoft が提供する GUI を記述するためのバリアントです。多くの場合デザイナーを使用して XAML ファイルを操作しますが、GUI を手動で記述・編集することも可能です。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この Java コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションを、[IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) インターフェイスから選択できます。

例えば、エクスポート時にプレゼンテーションの非表示スライドを XAML に追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) プロパティを true に設定します。サンプルの Java コードをご覧ください。
```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) の [デフォルトの標準フォント](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) を設定します — 元のフォントが存在しない場合のフォールバックフォントとして使用されます。これにより予期しない置き換えを防止できます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、正確な動作や特定の構文のサポートは対象プラットフォームに依存します。環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは、非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) でこの動作を制御できます — エクスポートが不要な場合は無効にしたままにしてください。