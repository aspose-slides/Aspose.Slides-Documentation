---
title: AndroidでプレゼンテーションをXAMLにエクスポート
linktitle: プレゼンテーションをXAMLへ
type: docs
weight: 30
url: /ja/androidjava/export-to-xaml/
keywords:
- PowerPointのエクスポート
- OpenDocumentのエクスポート
- プレゼンテーションのエクスポート
- PowerPointの変換
- OpenDocumentの変換
- プレゼンテーションの変換
- PowerPointからXAMLへ
- OpenDocumentからXAMLへ
- プレゼンテーションからXAMLへ
- PPTからXAMLへ
- PPTXからXAMLへ
- ODPからXAMLへ
- PPTをXAMLとして保存
- PPTXをXAMLとして保存
- ODPをXAMLとして保存
- PPTをXAMLにエクスポート
- PPTXをXAMLにエクスポート
- ODPをXAMLにエクスポート
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint と OpenDocument のスライドを XAML に変換します—高速で Office 不要のソリューションで、レイアウトをそのまま保持します。"
---

## **プレゼンテーションをXAMLにエクスポート**

Aspose.Slides は XAML エクスポートをサポートしています。プレゼンテーションを XAML に変換できます。

## **XAML について**

XAML は記述型プログラミング言語で、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できます。  

XAML は XML ベースの言語で、Microsoft が提供する GUI 記述用のバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを編集しますが、GUI を手動で記述・編集することも可能です。

## **デフォルトオプションでプレゼンテーションをXAMLにエクスポート**

この Java コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **カスタムオプションでプレゼンテーションをXAMLにエクスポート**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定する [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) インターフェイスからオプションを選択できます。

たとえば、エクスポート時に非表示スライドを XAML に含めたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) プロパティを true に設定します。このサンプル Java コードをご覧ください。
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

Set [デフォルトの標準フォント](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — it is used as a fallback font when the original is missing. This helps avoid unexpected substitutions.

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、具体的な動作や特定の構文のサポートはターゲットプラットフォームに依存します。ご使用の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは、非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。