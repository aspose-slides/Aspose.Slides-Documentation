---
title: C++でプレゼンテーションを効率的に結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/cpp/merge-presentation/
keywords:
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PowerPoint を統合
- プレゼンテーションを統合
- スライドを統合
- PPT を統合
- PPTX を統合
- ODP を統合
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを簡単に結合し、ワークフローを効率化します。"
---

{{% alert  title="Tip" color="primary" %}} 

**Aspose 無料オンライン**の[Merger アプリ](https://products.aspose.app/slides/merger)を確認してみてください。PowerPoint プレゼンテーションを同じ形式（PPT→PPT、PPTX→PPTX など）で結合したり、異なる形式（PPT→PPTX、PPTX→ODP など）で結合したりできます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

プレゼンテーションを別のものに結合すると、スライドが 1 つのプレゼンテーションにまとめられ、1 ファイルとして取得できます。 

{{% alert title="Info" color="info" %}}

多くのプレゼンテーション ソフト（PowerPoint や OpenOffice）には、プレゼンテーションをこのように結合する機能がありません。 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) は、さまざまな方法でプレゼンテーションを結合できるようにします。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなく結合できます。 

**See also**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **What Can Be Merged**

Aspose.Slides を使用すると、次のものを結合できます  

* **プレゼンテーション全体** – すべてのスライドが 1 つのプレゼンテーションに統合されます  
* **特定のスライド** – 選択したスライドだけが 1 つのプレゼンテーションに統合されます  
* **同じ形式**（PPT→PPT、PPTX→PPTX など）または **異なる形式**（PPT→PPTX、PPTX→ODP など）のプレゼンテーション同士の結合  

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は他のファイルの結合もサポートします。

* [画像](https://products.aspose.com/slides/cpp/merger/image-to-image/)、例として [JPG→JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) や [PNG→PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)  
* 文書、例として [PDF→PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) や [HTML→HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)  
* さらに **2 種類** の異なるファイル、例として [画像→PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) や [JPG→PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/)、[TIFF→PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/)  

{{% /alert %}}

### **Merging Options**

次のオプションで結合方法を制御できます  

* 各スライドが出力プレゼンテーションで固有のスタイルを保持するか  
* すべてのスライドに共通のスタイルを適用するか  

プレゼンテーションを結合するには、Aspose.Slides が提供する [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) メソッド（[ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection) インターフェイス）を使用します。`AddClone` メソッドには複数の実装があり、結合プロセスのパラメータを指定できます。各 Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) コレクションを持っているため、スライドを結合したいプレゼンテーションから `AddClone` を呼び出します。 

`AddClone` は `ISlide` オブジェクトを返し、これは元のスライドのクローンです。出力プレゼンテーションのスライドは単に元スライドのコピーであるため、元のプレゼンテーションに影響を与えることなく、スタイルや書式設定、レイアウトの変更が可能です。 

## **Merge Presentations** 

Aspose.Slides の [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) メソッドは、スライドのレイアウトとスタイルを保持したまま結合できます（デフォルト パラメータ）。 

以下の C++ コードはプレゼンテーションの結合方法を示しています:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Merge Presentations with a Slide Master**

Aspose.Slides の [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) メソッドは、スライドマスター テンプレートを適用しながらスライドを結合します。これにより、必要に応じて出力プレゼンテーションのスライドスタイルを変更できます。 

以下の C++ コードはこの操作を実演しています:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

スライドマスターのレイアウトは自動的に決定されます。適切なレイアウトが判断できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブール パラメータが true に設定されていれば、元スライドのレイアウトが使用されます。そうでなければ [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) がスローされます。 

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用したい場合は、結合時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) メソッドを使用してください。 

## **Merge Specific Slides from Presentations**

複数のプレゼンテーションから特定のスライドだけを結合すると、カスタム スライド デッキを作成できます。Aspose.Slides C++ は必要なスライドのみを選択してインポートでき、元のスライドの書式、レイアウト、デザインを保持します。 

以下の C++ コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加してファイルに保存します:
```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```

```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```


## **Merge Presentations with a Slide Layout**

この C++ コードは、好みのスライド レイアウトを適用しながらプレゼンテーションのスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示します:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

スライド サイズが異なるプレゼンテーションは結合できません。 

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションを結合するには、サイズが合うようにどちらかのプレゼンテーションをリサイズする必要があります。 

このサンプルコードは、上記の操作を示しています:
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


## **Merge Slides to a Presentation Section**

この C++ コードは、特定のスライドをプレゼンテーションのセクションに結合する方法を示します:
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


スライドはセクションの末尾に追加されます。 

{{% alert title="Tip" color="primary" %}}

Aspose が提供する[無料 Collage Web アプリ](https://products.aspose.app/slides/collage)を使用すると、[JPG→JPG](https://products.aspose.app/slides/collage/jpg) や PNG→PNG 画像の結合、[フォト グリッド](https://products.aspose.app/slides/collage/photo-grid) の作成などがオンラインで行えます。 

{{% /alert %}}

## **FAQ**

**結合時にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、ノート、書式設定、アニメーションを含むすべてのスライド要素が保持されます。 

**コメントとその作成者は転送されますか？**

コメントはスライド コンテンツの一部としてコピーされ、コメント作成者のラベルは結果のプレゼンテーション内のコメント オブジェクトとして残ります。 

**元のプレゼンテーションがパスワードで保護されている場合は？**

[LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) を使用してパスワードで開く必要があります（/slides/cpp/password-protected-presentation/）。ロード後、スライドは保護されていないターゲット ファイル（または保護されたファイル）に安全にクローンできます。 

**結合操作はスレッドセーフですか？**

同じ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/cpp/multithreading/)から使用しないでください。推奨ルールは「1 ドキュメント – 1 スレッド」で、別々のファイルは異なるスレッドで並列処理できます。