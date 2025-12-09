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
- PPT を XAML に変換
- PPTX を XAML に変換
- ODP を XAML に変換
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint と OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保つ、Office 不要の高速ソリューション。"
---

# **プレゼンテーションを XAML にエクスポート**

{{% alert title="Info" color="info" %}} 

Aspose.Slides 21.6 では、XAML エクスポートのサポートを実装しました。これでプレゼンテーションを XAML にエクスポートできるようになりました。 

{{% /alert %}} 

# **XAML について**

XAML は記述的なプログラミング言語で、特に WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin Forms を使用するアプリのユーザーインターフェイスを構築または記述できます。  

XAML は XML ベースの言語で、Microsoft が提供する GUI 記述用のバリアントです。ほとんどの場合、デザイナーを使用して XAML ファイルを操作しますが、GUI を直接記述・編集することも可能です。 

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

この C# コードは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

エクスポートプロセスを制御し、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を決定するオプションを、[IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) インターフェイスから選択できます。 

たとえば、XAML にエクスポートする際にプレゼンテーションの非表示スライドを追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) プロパティを true に設定します。このサンプル C# コードをご覧ください： 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **よくある質問**

**元のフォントがマシン上にない場合、フォントを予測可能にするにはどうすればよいですか？**

元のフォントが存在しない場合の代替フォントとして [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) を [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) に設定します。これにより、予期しない置換を回避できます。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

XAML は WPF、UWP、Xamarin.Forms で使用される汎用 UI マークアップ言語です。エクスポートは Microsoft の XAML スタックとの互換性を対象としていますが、具体的な動作や特定構文のサポートはターゲットプラットフォームに依存します。ご自身の環境でマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) を [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) で制御できます。エクスポートが不要な場合は無効のままにしてください。