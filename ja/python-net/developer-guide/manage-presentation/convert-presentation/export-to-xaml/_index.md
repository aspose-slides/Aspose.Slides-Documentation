---
title: Python で XAML へプレゼンテーションをエクスポート
linktitle: XAML へエクスポート
type: docs
weight: 30
url: /ja/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint および OpenDocument スライドを XAML に変換します—レイアウトをそのまま保持する、迅速で Office 不要のソリューションです。"
---

## **概要**

{{% alert title="情報" color="info" %}} 
[Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) で XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 
{{% /alert %}} 

XAML は記述的なプログラミング言語で、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述することができます。  

XML ベースの言語である XAML は、Microsoft が提供する GUI 記述用の言語です。多くの場合、デザイナーで XAML ファイルを操作することになるでしょうが、手動で GUI を記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この Python コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) インターフェイスからオプションを選択して、エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定できます。 

たとえば、XAML にエクスポートする際に Aspose.Slides がプレゼンテーションの非表示スライドを追加するようにしたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) プロパティを true に設定します。以下のサンプル Python コードをご参照ください。 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **よくある質問**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**  

元のフォントが見つからないときのフォールバックとして、[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) を設定します。これにより、予期しないフォント置き換えを防止できます。  

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**  

XAML は WPF、UWP、Xamarin.Forms で使用される一般的な UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、具体的な動作や特定構文のサポートは対象プラットフォームによって異なります。ご利用の環境でマークアップをテストしてください。  

**非表示スライドはサポートされていますか？また、デフォルトでエクスポートされないようにするにはどうすればよいですか？**  

既定では非表示スライドは含まれません。この動作は [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) で制御できます。エクスポートが不要な場合は無効のままにしてください。