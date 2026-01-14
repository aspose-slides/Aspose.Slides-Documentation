---
title: Python を使用した XAML へのプレゼンテーションのエクスポート
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
- PowerPoint を XAML に変換
- OpenDocument を XAML に変換
- プレゼンテーションを XAML に変換
- PPT を XAML に変換
- PPTX を XAML に変換
- ODP を XAML に変換
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint および OpenDocument スライドを XAML に変換します。レイアウトをそのまま保つ、迅速で Office 不要のソリューションです。"
---

## **概要**

{{% alert title="Info" color="info" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) で、XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 

{{% /alert %}} 

XAML は、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できる記述的プログラミング言語です。  

XML ベースの言語である XAML は、Microsoft が提供する GUI を記述するためのバリアントです。ほとんどの場合、デザイナーを使って XAML ファイルを操作することになるでしょうが、GUI を手動で記述・編集することも可能です。 

## **デフォルトオプションで XAML にプレゼンテーションをエクスポート**

この Python コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **カスタムオプションで XAML にプレゼンテーションをエクスポート**

[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) クラスからエクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションを選択できます。 

例えば、エクスポート時に非表示スライドも XAML に含めたい場合は、[export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) プロパティを `True` に設定できます。このサンプル Python コードをご覧ください： 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **FAQ**

**元のフォントがマシンにない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) を設定します。これが元のフォントが欠落している場合のフォールバックフォントとして使用されます。予期しない置き換えを防ぐのに役立ちます。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

XAML は、WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、具体的な動作や特定の構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは、非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) を使用してこの動作を制御できます。エクスポートが不要な場合は無効にしたままにしてください。