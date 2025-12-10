---
title: .NET でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/net/export-to-xaml/
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
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint および OpenDocument のスライドを XAML に変換します——レイアウトをそのまま保つ、迅速で Office 不要のソリューションです。"
---

## **プレゼンテーションを XAML にエクスポート**

{{% alert title="Info" color="info" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) で XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 

{{% /alert %}} 

## **XAML について**

XAML は、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できる記述的プログラミング言語です。  

XML ベースの言語である XAML は、Microsoft が提供する GUI 記述用のバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作することになるでしょうが、GUI を手動で記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この C# コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) インターフェイスからオプションを選択して、エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定できます。  

たとえば、XAML にエクスポートする際に Aspose.Slides にプレゼンテーションの非表示スライドを追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) プロパティを true に設定できます。このサンプル C# コードをご覧ください：  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**  
[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) を設定します。これにより、元のフォントが見つからない場合のフォールバックフォントとして使用され、予期しない置き換えを防止できます。  

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**  
XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、具体的な動作や特定の構文のサポートは対象プラットフォームに依存します。ご使用の環境でマークアップをテストしてください。  

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**  
デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) の [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。