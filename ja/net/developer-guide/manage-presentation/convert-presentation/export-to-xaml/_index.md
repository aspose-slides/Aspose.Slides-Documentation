---
title: .NET でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションを XAML に変換
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
description: ".NET で Aspose.Slides を使用して PowerPoint および OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保持する、迅速で Office 不要のソリューションです。"
---

# **プレゼンテーションの XAML へのエクスポート**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 

{{% /alert %}} 

# **XAML について**

XAML は記述型プログラミング言語で、特に WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できます。  

XML ベースの言語である XAML は、Microsoft の GUI 記述用バリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、GUI を手動で記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この C# コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています:  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションは、[IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) インターフェイスから選択できます。  

例えば、エクスポート時に非表示スライドも XAML に含めたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) プロパティを true に設定します。以下のサンプル C# コードをご覧ください:  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **よくある質問**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

元のフォントが欠如している場合のフォールバックフォントとして、[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) を設定します。これにより予期しない置換を回避できます。  

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としており、具体的な挙動や特定の構文のサポートはターゲットプラットフォームに依存します。ご利用の環境でマークアップをテストしてください。  

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは、非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) の [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。