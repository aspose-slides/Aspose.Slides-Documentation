---
title: Android でプレゼンテーションを XAML にエクスポート
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint および OpenDocument のスライドを XAML に変換します—高速で Office が不要なソリューションで、レイアウトをそのまま保持します。"
---

## **プレゼンテーションを XAML にエクスポート**

{{% alert color="primary" %}} 
Aspose.Slides 21.6 で XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。{{% /alert %}} 

## **XAML について**

XAML は、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin.Forms で使用されるアプリのユーザーインターフェイスを構築または記述するための記述型プログラミング言語です。  

XML ベースの言語である XAML は、GUI を記述するための Microsoft のバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、GUI を手動で記述・編集することも可能です。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この Java コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示します:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

IXamlOptions インターフェイスからオプションを選択でき、エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定します。

たとえば、エクスポート時に Aspose.Slides がプレゼンテーションの非表示スライドを XAML に追加するようにしたい場合、ExportHiddenSlides プロパティを true に設定できます。このサンプル Java コードをご覧ください:
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
XamlOptions でデフォルトの標準フォントを設定します—元のフォントがない場合の代替フォントとして使用されます。これにより予期しない置換を防げます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**  
XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、具体的な動作や特定構文のサポートは対象プラットフォームによります。ご自身の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか、デフォルトでエクスポートされないようにするにはどうすればよいですか？**  
デフォルトでは非表示スライドは含まれません。XamlOptions の setExportHiddenSlides でこの動作を制御できます—エクスポートが不要な場合は無効にしておいてください。