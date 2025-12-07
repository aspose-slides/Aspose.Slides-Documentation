---
title: C++ で XAML にプレゼンテーションをエクスポート
linktitle: プレゼンテーションを XAML に
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
- PowerPoint を XAML に
- OpenDocument を XAML に
- プレゼンテーションを XAML に
- PPT を XAML に
- PPTX を XAML に
- ODP を XAML に
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PowerPoint と OpenDocument のスライドを XAML に変換します—高速で Office が不要、レイアウトをそのまま保持するソリューションです。"
---

## **プレゼンテーションを XAML にエクスポート**

{{% alert color="primary" %}} 
[Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/)で XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 
{{% /alert %}} 

## **XAML について**

XAML は、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin フォームを使用するアプリ向けに、ユーザーインターフェイスを構築または記述できる記述型プログラミング言語です。  

XML ベースの言語である XAML は、Microsoft が提供する GUI 記述用のバリアントです。ほとんどの場合、デザイナーを使って XAML ファイルを作業することになるでしょうが、手動で GUI を記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この C++ コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

IXamlOptions インターフェイスからオプションを選択して、エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定できます。 

たとえば、エクスポート時に非表示スライドを XAML に追加したい場合は、[set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) メソッドに true を渡すことができます。このサンプル C++ コードをご覧ください: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) の [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) を使用します。これは元のフォントが存在しない場合の代替フォントとして使用され、予期しない置換を防止します。 

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、具体的な挙動や特定の構文のサポートはターゲットプラットフォームに依存します。環境でマークアップをテストしてください。 

**非表示スライドはサポートされていますか？ デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) の [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) を使用してこの動作を制御できます。必要なければ無効のままにしてください。