---
title: C++ でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint および OpenDocument のスライドを XAML に変換します—高速で Office が不要なソリューションで、レイアウトをそのまま保持します。"
---

## **XAML へのプレゼンテーションのエクスポート**

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/)で、XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML 形式でエクスポートできるようになりました。 

{{% /alert %}} 

## **XAML について**

XAML は記述型プログラミング言語で、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述するために使用されます。  

XML ベースの言語である XAML は、Microsoft が GUI を記述するために提供する独自のバリアントです。通常はデザイナーを使用して XAML ファイルを操作しますが、手動で GUI を記述・編集することも可能です。 

## **既定オプションで XAML にエクスポートする**

以下の C++ コードは、既定設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **カスタムオプションで XAML にエクスポートする**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定する [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) インターフェイスからオプションを選択できます。 

たとえば、エクスポート時に非表示スライドも XAML に含めたい場合は、[set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) メソッドに true を渡します。以下のサンプル C++ コードをご覧ください: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) の [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) を使用します。元のフォントが見つからない場合の代替フォントとして使用され、予期しない置換を防止します。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、正確な動作や特定の構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) の [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。