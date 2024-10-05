---
title: プレゼンテーションのマージ - C++ PowerPoint API
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /cpp/merge-presentation/
keywords: "PowerPointのマージ, PPTX, PPT, PowerPointの結合, プレゼンテーションのマージ, プレゼンテーションの結合, C++"
description: この記事では、C++ PowerPoint APIまたはライブラリを使用してPowerPointプレゼンテーションをマージまたは結合する方法を説明します。
---

{{% alert  title="ヒント" color="primary" %}} 

**Asposeの無料オンライン** [マージアプリ](https://products.aspose.app/slides/merger) をチェックしてみてください。これにより、同じ形式（PPTからPPT、PPTXからPPTXなど）でPowerPointプレゼンテーションをマージしたり、異なる形式（PPTからPPTX、PPTXからODPなど）でプレゼンテーションをマージしたりすることができます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションのマージ**

一つのプレゼンテーションを別のプレゼンテーションにマージすることは、実質的にはそれらのスライドを一つのプレゼンテーションに結合し、一つのファイルを得ることを意味します。

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointやOpenOffice）は、そのようにプレゼンテーションを結合する機能がありません。

しかし、[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)を使用すれば、さまざまな方法でプレゼンテーションをマージできます。品質やデータの損失を気にすることなく、すべてのシェイプ、スタイル、テキスト、フォーマット、コメント、アニメーションなどを持つプレゼンテーションをマージすることができます。

**参照**

[スライドの複製](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **マージできるもの**

Aspose.Slidesでは、以下をマージできます。

* 完全なプレゼンテーション。すべてのスライドが一つのプレゼンテーションに収まります。
* 特定のスライド。選択したスライドが一つのプレゼンテーションに収まります。
* 同一フォーマットのプレゼンテーション（PPTからPPT、PPTXからPPTXなど）や異なるフォーマット（PPTからPPTX、PPTXからODPなど）を一つにマージします。

{{% alert title="注意" color="warning" %}} 

プレゼンテーションのほかにも、Aspose.Slidesでは他のファイルをマージできます：

* [画像](https://products.aspose.com/slides/cpp/merger/image-to-image/)、例えば [JPGからJPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) や [PNGからPNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* ドキュメント、例えば [PDFからPDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) や [HTMLからHTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* 異なる二つのファイル、例えば [画像からPDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) や [JPGからPDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) または [TIFFからPDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/)。

{{% /alert %}}

### **マージオプション**

マージ時に、次のオプションを適用できます。

* 出力プレゼンテーション内の各スライドがユニークなスタイルを保持するかどうか。
* 出力プレゼンテーション内のすべてのスライドに特定のスタイルを使用するかどうか。

プレゼンテーションをマージするために、Aspose.Slidesは[AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)メソッド（[ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)インターフェースから）を提供しています。`AddClone`メソッドには、プレゼンテーションのマージプロセスパラメータを定義する複数の実装があります。すべてのPresentationオブジェクトには[Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)コレクションがあるため、スライドをマージしたいプレゼンテーションから`AddClone`メソッドを呼ぶことができます。

`AddClone`メソッドは、ソーススライドのクローンである`ISlide`オブジェクトを返します。出力プレゼンテーションのスライドは、すべてソースからのスライドのコピーです。したがって、結果のスライド（たとえば、スタイル、フォーマットオプション、レイアウトを適用するなど）に変更を加えても、ソースプレゼンテーションに影響を与えることはありません。

## **プレゼンテーションのマージ** 

Aspose.Slidesは、[**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)メソッドを提供しており、スライドのレイアウトやスタイルを保持しながらスライドを結合することができます（デフォルトパラメータ）。

このC++コードは、プレゼンテーションをマージする方法を示しています：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **スライドマスターを使用したプレゼンテーションのマージ**

Aspose.Slidesは、[**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640)メソッドを提供し、スライドマスタープレゼンテーションテンプレートを適用しながらスライドを結合できます。この方法で、必要に応じて出力プレゼンテーションのスライドスタイルを変更できます。

このC++コードは、説明した操作を示しています：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone`メソッドの`allowCloneMissingLayout`ブールパラメータがtrueに設定されていると、ソーススライドのレイアウトが使用されます。そうでない場合は、[PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに異なるスライドレイアウトを持たせたい場合、マージ時に[AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1)メソッドを使用してください。

## **特定のスライドをプレゼンテーションからマージ**

このC++コードは、異なるプレゼンテーションから特定のスライドを選択し、結合して一つの出力プレゼンテーションを作成する方法を示しています：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **スライドレイアウトを使用したプレゼンテーションのマージ**

このC++コードは、プレゼンテーションからスライドを結合し、希望のスライドレイアウトを適用して一つの出力プレゼンテーションを取得する方法を示しています：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **異なるスライドサイズを持つプレゼンテーションのマージ**

{{% alert title="注意" color="warning" %}} 

異なるスライドサイズを持つプレゼンテーションをマージすることはできません。 

{{% /alert %}}

異なるスライドサイズのプレゼンテーションを2つマージするには、いずれかのプレゼンテーションのサイズを変更して、もう一方のプレゼンテーションのサイズと一致させる必要があります。

このサンプルコードは、説明した操作を示しています：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションセクションにスライドをマージ**

このC++コードは、プレゼンテーションのセクションに特定のスライドをマージする方法を示しています：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

スライドはセクションの最後に追加されます。

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用して、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)またはPNGからPNG画像をマージしたり、[写真グリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。

{{% /alert %}}