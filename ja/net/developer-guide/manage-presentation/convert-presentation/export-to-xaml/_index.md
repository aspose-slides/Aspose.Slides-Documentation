---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /ja/net/export-to-xaml/
keywords: "PowerPoint プレゼンテーションのエクスポート, PowerPoint の変換, XAML, PowerPoint を XAML に変換, PPT を XAML に変換, PPTX を XAML に変換, C#, Csharp, .NET"
description: "PowerPoint プレゼンテーションを XAML にエクスポートまたは変換"
---

# **プレゼンテーションをXAMLにエクスポート**

{{% alert title="Info" color="info" %}} 
[Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/)でXAMLエクスポートのサポートを実装しました。これでプレゼンテーションをXAMLにエクスポートできるようになりました。 
{{% /alert %}} 

# **XAMLについて**

XAMLは、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Formsで使用されるアプリのユーザーインターフェイスを構築または記述できる記述型プログラミング言語です。  

XMLベースの言語であるXAMLは、MicrosoftがGUIを記述するために提供しているバリアントです。多くの場合、デザイナーを使用してXAMLファイルを操作しますが、手動でGUIを記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションをXAMLにエクスポート**

このC#コードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **カスタムオプションでプレゼンテーションをXAMLにエクスポート**

エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにエクスポートする方法を決定するオプションは、[IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions)インターフェイスから選択できます。 

たとえば、エクスポート時に隠しスライドをXAMLに含めたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides)プロパティをtrueに設定します。以下のC#サンプルをご参照ください： 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **よくある質問**

**元のフォントがマシンに存在しない場合、フォントの予測可能性を確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/)の[DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/)を設定します。元のフォントが欠落しているときのフォールバックフォントとして使用され、予期しない置換を防止します。 

**エクスポートされたXAMLはWPF専用ですか、それとも他のXAMLスタックでも使用可能ですか？**

XAMLはWPF、UWP、Xamarin.Formsで使用される汎用UIマークアップ言語です。エクスポートはMicrosoftのXAMLスタックとの互換性を対象としており、具体的な動作や特定構文のサポートは対象プラットフォームに依存します。実際の環境でマークアップをテストしてください。 

**隠しスライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは隠しスライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/)の[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/)でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。