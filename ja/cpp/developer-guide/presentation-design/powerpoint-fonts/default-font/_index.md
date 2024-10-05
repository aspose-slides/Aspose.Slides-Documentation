---
title: デフォルトフォント
type: docs
weight: 30
url: /cpp/default-font/
keywords: 
- フォント
- デフォルトフォント
- プレゼンテーションのレンダリング
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides for C++
description: PowerPoint C++ APIを使用すると、PDF、XPS、またはサムネイルにプレゼンテーションをレンダリングするためのデフォルトフォントを設定できます。
---

## **デフォルトフォントの設定**
Aspose.Slides for C++を使用すると、PowerPointプレゼンテーションでデフォルトフォントを設定できます。新しいメソッド[set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492)が[**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/)クラスに追加されました。このメソッドは、プレゼンテーションを異なるフォーマットに保存する際に、すべての欠落しているフォントの代わりに使用されるデフォルトフォントを設定することを可能にします。

以下のコードスニペットは、異なるデフォルトレギュラーフォントでプレゼンテーションを[HTML](https://docs.fileformat.com/web/html/)および[PDF](https://docs.fileformat.com/pdf/)に保存する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slidesを使用すると、PDF、XPS、またはサムネイルにプレゼンテーションをレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontの定義方法を示します。以下の手順に従って、Aspose.Slides for C++ APIを使用して外部ディレクトリからフォントをロードします。

1. LoadOptionsのインスタンスを作成します。
1. DefaultRegularFontを希望のフォントに設定します。以下の例では、Wingdingsを使用しました。
1. DefaultAsianFontを希望のフォントに設定します。次のサンプルでもWingdingsを使用しました。
1. Presentationを使用してプレゼンテーションをロードし、ロードオプションを設定します。
1. 最後に、スライドのサムネイル、PDF、およびXPSを生成して結果を確認します。

上記の実装は以下の通りです。

```cpp
// ロードオプションを使用してデフォルトレギュラーおよびアジアフォントを指定します
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```