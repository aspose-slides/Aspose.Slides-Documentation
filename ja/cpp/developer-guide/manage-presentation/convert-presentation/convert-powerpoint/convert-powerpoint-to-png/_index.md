---
title: C++ で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用してプレゼンテーションスライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションをロードし、各スライドをレンダリングして、個別の PNG 画像として保存できます。

以下の例では、デフォルトスケールでのレンダリング、スケールの拡大、ピクセル単位での出力サイズの指定、そしてグラデーションレンダリングスタイルの選択を示しています。

## **PowerPoint を PNG に変換**

プレゼンテーションは [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスで読み込み、[Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) アクセッサを通じてスライドにアクセスします。この例では、パラメータなしで [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) を使用して各スライドをサムネイルとしてレンダリングします。その後、[IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) に [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) を指定して、レンダリングされた各スライドを PNG 画像として保存します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="注意" %}}
パラメータなしの [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルになります。出力サイズを制御するには、以下に示すスケールファクタを使用したオーバーロードまたは明示的な画像サイズを使用してください。
{{% /alert %}}

## **カスタム寸法で PowerPoint を PNG に変換**

水平および垂直のスケールファクタを [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) に渡すことで、レンダリングサイズを制御できます。この例では、両方のファクタが 2 となり、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像になります。同じスケールファクタを使用すると、スライドのアスペクト比が保たれます。各画像は [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) により PNG 形式で保存されます。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **カスタムサイズで PowerPoint を PNG に変換**

ピクセル単位で出力サイズを指定するには、スケールファクタの代わりにサイズを [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) に渡します。この例では、各スライドを 960 × 720 ピクセルでレンダリングし、結果を [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) で保存します。画像が伸びるのを防ぐため、スライドのアスペクト比に合わせたサイズを選択してください。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **グラデーションレンダリングスタイルの選択**

スライドにグラデーション塗りが含まれているが、エクスポートされた PNG の遷移が PowerPoint で見えるものよりも明るくなる、または異なる場合があります。そのような場合は、[RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) の [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) メソッドを使用して、グラデーションのレンダリング方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドには、上部がシアンからオレンジ、下部が青から黄への 2 つの線形グラデーションが含まれています。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例では、このプレゼンテーションを読み込み、[ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) を使用して同じ最初のスライドを両方のモードでレンダリングします。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

| Default | PowerPointUI |
| --- | --- |
| ![デフォルトでレンダリングされたシアンからオレンジ、および青から黄へのグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色がより明るくなるのに対し、`PowerPointUI` は中間色がより暗くなります。差異はグラデーションの色とストップに依存します。

標準の Aspose.Slides の出力で問題ない場合は `Default` を選択してください。PowerPoint の外観に合わせることが優先事項の場合は `PowerPointUI` を試してください。両方の出力を目的の結果と比較してください。どちらのモードが常に優れているわけでもありません。

## **FAQ**

**スライド全体ではなく、チャートや画像などの特定のシェイプだけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は、[個々のシェイプのサムネイル生成](/slides/ja/cpp/shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上で並列変換はサポートされていますか？**

はい。各スレッドまたはプロセスごとに個別のプレゼンテーションインスタンスを使用してください。[スレッド間で単一インスタンスを共有しない](/slides/ja/cpp/multithreading/)ことが推奨されます。

**PNG にエクスポートする際の評価版の制限は何ですか？**

評価モードでは、出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/cpp/licensing/) が適用されます。