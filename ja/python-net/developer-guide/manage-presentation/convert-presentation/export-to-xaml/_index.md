---
title: PythonでプレゼンテーションをXAMLにエクスポート
linktitle: XAMLにエクスポート
type: docs
weight: 30
url: /ja/python-net/export-to-xaml/
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
- PPTからXAMLへ
- PPTXからXAMLへ
- ODPからXAMLへ
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint および OpenDocument のスライドを XAML に変換します—レイアウトを保持した高速かつ Office 不要のソリューションです。"
---

## **概要**

{{% alert title="Info" color="info" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) では、XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 

{{% /alert %}} 

XAML は、特に WPF（Windows Presentation Foundation）や UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できる記述型プログラミング言語です。  

XML ベースの言語である XAML は、Microsoft が GUI を記述するために提供しているバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、手動で GUI を記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポートする**

以下の Python コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポートする**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションは、[IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) インターフェイスから選択できます。 

たとえば、エクスポート時に非表示スライドも XAML に含めたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) プロパティを true に設定します。以下のサンプル Python コードをご参照ください: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを保証するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) を設定します。元のフォントが見つからない場合のフォールバックフォントとして使用され、予期しない置き換えを防止します。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、具体的な動作や特定構文のサポートはターゲットプラットフォームに依存します。ご自身の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするには？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) の [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) でこの動作を制御できます。エクスポートが不要な場合は無効にしたままにしてください。