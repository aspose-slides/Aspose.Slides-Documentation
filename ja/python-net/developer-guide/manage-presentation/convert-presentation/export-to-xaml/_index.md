---
title: Python で XAML にプレゼンテーションをエクスポート
linktitle: XAML にエクスポート
type: docs
weight: 30
url: /ja/python-net/export-to-xaml/
keywords:
- PowerPoint のエクスポート
- OpenDocument のエクスポート
- プレゼンテーションのエクスポート
- PowerPoint の変換
- OpenDocument の変換
- プレゼンテーションの変換
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

XAML は、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用するアプリ向けに、ユーザーインターフェイスを構築または記述できる記述型プログラミング言語です。  

XAML は XML ベースの言語で、Microsoft が提供する GUI 記述用のバリアントです。ほとんどの場合、デザイナーを使って XAML ファイルを操作することになるでしょうが、GUI を手動で記述・編集することも可能です。 

## **デフォルト オプションでプレゼンテーションを XAML にエクスポート**

この Python コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **カスタム オプションでプレゼンテーションを XAML にエクスポート**

エクスポート処理を制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定する [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) クラスからオプションを選択できます。 

たとえば、エクスポート時に非表示スライドを XAML に含めたい場合は、[export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) プロパティを `True` に設定します。このサンプル Python コードをご覧ください: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **よくある質問**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) を設定します。元のフォントが存在しない場合のフォールバックフォントとして使用され、予期しない置き換えを防止できます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用の UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、具体的な動作や特定の構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは、非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。