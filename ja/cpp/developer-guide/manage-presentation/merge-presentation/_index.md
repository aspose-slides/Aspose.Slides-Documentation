---
title: C++ でプレゼンテーションを効率的に結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/cpp/merge-presentation/
keywords:
- PowerPoint の結合
- プレゼンテーションの結合
- スライドの結合
- PPT の結合
- PPTX の結合
- ODP の結合
- PowerPoint の統合
- プレゼンテーションの統合
- スライドの統合
- PPT の統合
- PPTX の統合
- ODP の統合
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを簡単に結合し、ワークフローを効率化します。"
---
## **概要**

Aspose.Slides を使用すると、あるプレゼンテーションから別のプレゼンテーションへスライドをクローンすることで、プレゼンテーションを結合できます。本記事では、プレゼンテーション全体または選択したスライドを結合する方法、結合時にスライドマスターまたは特定のレイアウトを使用する方法、サイズが異なるスライドを含むプレゼンテーションの取り扱い、結合したスライドをプレゼンテーションのセクションに追加する方法を説明します。また、結合されたコンテンツに関する実用的な注意点（スピーカーノート、コメント、パスワード保護されたソースファイル、スレッド使用）も取り上げます。

## **プレゼンテーションの結合**

あるプレゼンテーションを別のプレゼンテーションに結合すると、スライドが単一のプレゼンテーションにまとめられ、1 つのファイルになります。

{{% alert title="Info" color="info" %}}

PowerPoint や OpenOffice などのほとんどのプレゼンテーションソフトウェアには、ユーザーがこのようにプレゼンテーションを結合できる機能がありません。

[**Aspose.Slides for C++**](https://products.aspose.com/slides/ja/cpp/) は、さまざまな方法でプレゼンテーションを結合できる機能を提供します。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなく結合できます。

**関連項目**

[スライドのクローン作成](https://docs.aspose.com/slides/ja/cpp/clone-slides/)*.*

{{% /alert %}}

### **結合できるもの**

Aspose.Slides を使用すると、以下を結合できます。

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドだけが 1 つのプレゼンテーションにまとめられます
* 同一形式（PPT→PPT、PPTX→PPTX など）および異なる形式（PPT→PPTX、PPTX→ODP など）のプレゼンテーション同士の結合

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は次のファイルの結合もサポートします。

* [画像](https://products.aspose.com/slides/ja/cpp/merger/image-to-image/)、例: [JPG から JPG](https://products.aspose.com/slides/ja/cpp/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/ja/cpp/merger/png-to-png/)
* 文書、例: [PDF から PDF](https://products.aspose.com/slides/ja/cpp/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/ja/cpp/merger/html-to-html/)
* 異種ファイルの結合、例: [画像から PDF](https://products.aspose.com/slides/ja/cpp/merger/image-to-pdf/) や [JPG から PDF](https://products.aspose.com/slides/ja/cpp/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/ja/cpp/merger/tiff-to-pdf/)

{{% /alert %}}

### **結合オプション**

次のいずれかを決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーション全体で同一のスタイルを使用するか

プレゼンテーションを結合するには、Aspose.Slides が提供する [AddClone](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) メソッド（[ISlideCollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_slide_collection) インターフェイス）を使用します。`AddClone` メソッドには複数の実装があり、結合プロセスのパラメーターを指定できます。各 Presentation オブジェクトには [Slides](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) コレクションがあるため、結合先のプレゼンテーションから `AddClone` を呼び出すことができます。

`AddClone` メソッドは、元スライドのクローンである `ISlide` オブジェクトを返します。出力プレゼンテーションのスライドは、単にソーススライドのコピーです。そのため、結果として得られたスライドに対して（スタイルや書式設定、レイアウトの適用など）変更を加えても、元のプレゼンテーションに影響はありません。

## **プレゼンテーションの結合** 

Aspose.Slides は、スライドがレイアウトとスタイルを保持したまま結合できる [**AddClone (ISlide)**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) メソッドを提供します（デフォルトパラメーター）。  

以下の C++ コードは、プレゼンテーションを結合する方法を示しています。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **スライドマスターを使用したプレゼンテーションの結合**

Aspose.Slides は、[**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) メソッドを提供し、スライドマスターのテンプレートを適用しながらスライドを結合できます。この方法により、必要に応じて出力プレゼンテーションのスライドスタイルを変更できます。

以下の C++ コードは、上記操作を実演しています。

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

スライドマスターのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブールパラメーターが `true` に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用したい場合は、結合時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) メソッドを使用してください。

## **プレゼンテーションから特定のスライドを結合**

複数のプレゼンテーションから特定のスライドだけを結合すると、カスタムスライドデッキの作成に便利です。Aspose.Slides C++ は、必要なスライドだけを選択してインポートでき、元スライドの書式、レイアウト、デザインを保持します。

以下の C++ コードは、新しいプレゼンテーションを作成し、別の 2 つのプレゼンテーションからタイトルスライドを追加してファイルに保存する例です。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 上記のコードで宣言されています。
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

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

## **スライドレイアウトを指定したプレゼンテーションの結合**

この C++ コードは、プレゼンテーションからスライドを結合し、好きなスライドレイアウトを適用して 1 つの出力プレゼンテーションを作成する方法を示しています。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **異なるスライドサイズのプレゼンテーションの結合**

{{% alert title="Note" color="warning" %}} 

サイズが異なるスライドを持つプレゼンテーションは結合できません。

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションを結合するには、いずれかのプレゼンテーションのサイズを調整して、もう一方と同じサイズに合わせる必要があります。

以下のサンプルコードは、上記操作を実演しています。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

## **スライドをプレゼンテーションのセクションに結合**

この C++ コードは、特定のスライドをプレゼンテーションのセクションに結合する方法を示しています。

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

{{% alert title="Tip" color="info" %}}

Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/ja/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/ja/collage/jpg) や PNG から PNG の画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/ja/collage/photo-grid) を作成したりできます。

{{% /alert %}}

## **FAQ**

### 結合時にスピーカーノートは保持されますか？

はい。スライドをクローンすると、Aspose.Slides はノート、書式設定、アニメーションを含むすべてのスライド要素を引き継ぎます。

### コメントとその作成者は転送されますか？

コメントはスライドコンテンツの一部としてコピーされます。コメント作成者のラベルは、結果のプレゼンテーション内のコメントオブジェクトとして保持されます。

### ソースプレゼンテーションがパスワードで保護されている場合は？

[LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/) を使用して [パスワードで保護されたプレゼンテーションを開く](/slides/ja/cpp/password-protected-presentation/) 必要があります。ロード後、そのスライドは保護されていないターゲットファイル（または保護されたファイル）へ安全にクローンできます。

### 結合操作はどの程度スレッドセーフですか？

同じ [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを [複数スレッド](/slides/ja/cpp/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント ― 1 スレッド」です。別々のファイルは別スレッドで並行処理できます。