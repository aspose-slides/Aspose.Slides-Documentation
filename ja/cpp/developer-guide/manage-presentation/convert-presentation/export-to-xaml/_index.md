---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /cpp/export-to-xaml/

---

# プレゼンテーションのXAMLへのエクスポート

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) では、XAMLエクスポートのサポートを実装しました。これで、プレゼンテーションをXAMLにエクスポートできるようになりました。

{{% /alert %}} 

# XAMLについて

XAMLは、アプリのユーザーインターフェイスを構築または記述するための記述型プログラミング言語であり、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、およびXamarinフォームを使用するアプリに使用されます。  

XAMLはXMLベースの言語で、MicrosoftのGUIを記述するためのバリアントです。通常、デザイナーを使用してXAMLファイルを操作しますが、GUIを手動で作成および編集することも可能です。 

## デフォルトオプションでのプレゼンテーションのXAMLへのエクスポート

このC++コードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## カスタムオプションでのプレゼンテーションのXAMLへのエクスポート

エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにエクスポートする方法を決定するオプションを、[IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options)インターフェースから選択できます。

たとえば、XAMLにエクスポートする際に、プレゼンテーションから隠れたスライドをAspose.Slidesに追加させたい場合は、[set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313)メソッドにtrueを渡すことができます。次のサンプルC++コードを参照してください：

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```