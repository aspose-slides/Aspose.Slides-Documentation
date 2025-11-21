---
title: .NET でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: .NET で Aspose.Slides を使用して PowerPoint と OpenDocument のスライドを XAML に変換します - レイアウトを維持する迅速な Office 不要のソリューション。
---

# **プレゼンテーションの XAML へのエクスポート**

{{% alert title="Info" color="info" %}} 
Aspose.Slides 21.6 のリリースノートで XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 
{{% /alert %}} 

# **XAML について**

XAML は記述的なプログラミング言語で、特に WPF（Windows Presentation Foundation）や UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できます。  

XML ベースの言語である XAML は、Microsoft が GUI を記述するために提供するバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、直接 GUI を記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この C# コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

エクスポート処理を制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションは、[IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) インターフェイスから選択できます。  

たとえば、エクスポート時に非表示スライドも XAML に含めたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) プロパティを true に設定します。以下のサンプル C# コードをご参照ください: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **よくある質問**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**  

[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) を設定します。元のフォントが見つからないときのフォールバックフォントとして使用され、予期しない置き換えを防止します。  

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**  

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を目指していますが、具体的な挙動や特定構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。  

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**  

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) の [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) を無効にしておくことで、エクスポートから除外できます。