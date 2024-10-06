---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /ja/net/export-to-xaml/
keywords: "PowerPointプレゼンテーションをエクスポート, PowerPointを変換, XAML, PowerPointからXAML, PPTからXAML, PPTXからXAML, C#, Csharp, .NET"
description: "PowerPointプレゼンテーションをXAMLにエクスポートまたは変換"
---

# プレゼンテーションをXAMLにエクスポートする

{{% alert title="情報" color="info" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/)で、XAMLエクスポートのサポートを実装しました。これで、プレゼンテーションをXAMLにエクスポートできるようになりました。 

{{% /alert %}} 

# XAMLについて

XAMLは、アプリケーションのユーザーインターフェースを構築または記述するための記述型プログラミング言語であり、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、およびXamarinフォームを使用するアプリに関連しています。  

XAMLはXMLベースの言語で、MicrosoftのGUIを記述するためのバリアントです。通常、デザイナーを使用してXAMLファイルで作業することが多いですが、GUIを書くことや編集することもできます。 

## デフォルトオプションでのプレゼンテーションをXAMLにエクスポートする

このC#コードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## カスタムオプションでのプレゼンテーションをXAMLにエクスポートする

[IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions)インターフェースからオプションを選択でき、エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにエクスポートする方法を決定します。 

たとえば、Aspose.Slidesにプレゼンテーションから隠れたスライドをXAMLにエクスポートする際に追加させたい場合、[ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides)プロパティをtrueに設定できます。このサンプルC#コードを参照してください： 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```