---
title: "C++ でプレゼンテーションを XAML にエクスポート"
linktitle: "プレゼンテーションから XAML へ"
type: docs
weight: 30
url: /ja/cpp/export-to-xaml/
keywords:
- "PowerPoint をエクスポート"
- "OpenDocument をエクスポート"
- "プレゼンテーションをエクスポート"
- "PowerPoint を変換"
- "OpenDocument を変換"
- "プレゼンテーションを変換"
- "PowerPoint から XAML へ"
- "OpenDocument から XAML へ"
- "プレゼンテーションから XAML へ"
- "PPT から XAML へ"
- "PPTX から XAML へ"
- "ODP から XAML へ"
- "PPT を XAML として保存"
- "PPTX を XAML として保存"
- "ODP を XAML として保存"
- "PPT を XAML にエクスポート"
- "PPTX を XAML にエクスポート"
- "ODP を XAML にエクスポート"
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint および OpenDocument スライドを XAML に変換します—レイアウトをそのまま保つ、迅速で Office 不要のソリューションです。"
---

## **プレゼンテーションをXAMLにエクスポート**

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/)で、XAMLエクスポートのサポートを実装しました。これでプレゼンテーションをXAMLにエクスポートできるようになりました。 

{{% /alert %}} 

## **XAMLについて**

XAML は、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できる記述的プログラミング言語です。  

XML ベースの言語である XAML は、Microsoft が提供する GUI 記述用のバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、手動で GUI を記述・編集することも可能です。 

## **既定オプションでプレゼンテーションをXAMLにエクスポート**

以下の C++ コードは、既定設定でプレゼンテーションを XAML にエクスポートする方法を示しています：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **カスタムオプションでプレゼンテーションをXAMLにエクスポート**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定する [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) インターフェイスからオプションを選択できます。 

たとえば、エクスポート時に隠しスライドを XAML に含めたい場合は、[set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) メソッドに true を渡します。サンプル C++ コードは次のとおりです：
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) の [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) を使用します。元のフォントが見つからない場合の代替フォントとして使用され、予期しない置き換えを防止できます。 

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、具体的な動作や特定構文のサポートはターゲットプラットフォームに依存します。ご使用の環境でマークアップをテストしてください。 

**隠しスライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは隠しスライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) の [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。