---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /ja/python-net/export-to-xaml/
keywords: "PowerPointプレゼンテーションのエクスポート, PowerPointの変換, XAML, PowerPointからXAML, PPTからXAML, PPTXからXAML, Python"
description: "PowerPointプレゼンテーションをXAMLにエクスポートまたは変換"
---

# プレゼンテーションをXAMLにエクスポートする

{{% alert title="情報" color="info" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/)では、XAMLエクスポートのサポートを実装しました。これにより、プレゼンテーションをXAMLにエクスポートできるようになりました。 

{{% /alert %}} 

# XAMLについて

XAMLは、アプリケーションのユーザーインターフェイスを構築または記述するための記述型プログラミング言語であり、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarinフォームを使用するアプリに使用されます。

XAMLはXMLベースの言語で、MicrosoftのGUIを記述するためのバリアントです。XAMLファイル作成にはデザイナーを使用することが一般的ですが、GUIを手動で記述および編集することも可能です。

## デフォルトオプションを使用してプレゼンテーションをXAMLにエクスポートする

以下のPythonコードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## カスタムオプションを使用してプレゼンテーションをXAMLにエクスポートする

[IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/)インターフェイスからオプションを選択し、エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにどのようにエクスポートするかを決定できます。

たとえば、XAMLにエクスポートする際に、プレゼンテーションから隠れたスライドを追加したい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/)プロパティをtrueに設定できます。以下はそのサンプルPythonコードです：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```