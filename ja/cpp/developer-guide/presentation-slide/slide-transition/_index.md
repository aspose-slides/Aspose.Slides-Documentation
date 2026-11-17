---
title: C++ を使用したプレゼンテーションのスライド トランジションの管理
linktitle: スライド トランジション
type: docs
weight: 80
url: /ja/cpp/slide-transition/
keywords:
- スライド トランジション
- スライド トランジションの追加
- スライド トランジションの適用
- 高度なスライド トランジション
- Morph トランジション
- トランジション タイプ
- トランジション 効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してスライド トランジションを適用し、自動スライド進行を構成し、Morph やその他のトランジション効果をカスタマイズします。"
---
## **概要**

スライド トランジションは、スライドショー中にスライドが表示される方法を制御します。Aspose.Slides for C++ を使用すると、各スライドにトランジション効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、C++ の例を使用してトランジションを適用し、正確なトランジション期間を設定し、スライドのタイミングを管理し、2 つのスライド間で Morph トランジションを作成します。また、設定を PPTX ファイルに保存する方法も示しています。

## **スライド トランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) を介してスライドのトランジション設定にアクセスします。[set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) を [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列挙体の値で呼び出し、その後プレゼンテーションを保存します。

次の例は、最初のスライドに Circle トランジションを、2 番目のスライドに Comb トランジションを適用します。2 枚以上のスライドが含まれる `input.pptx` ファイルを使用してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **ホイール トランジション**

[set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) メソッドは、[IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) の目的スライドを表示する放射状セクタの数を制御します。[TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) の Wheel を使用して [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) を呼び出し、[IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) として [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) にアクセスする前に行います。

この例は、黒いスライドと金色の矩形が描かれたスライドの 2 つの同一ペアを作成します。目的スライドはスポーク数を 1 と 8 に設定し、[set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) で同じ速度を設定し、[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) で明示的に 8,000 ミリ秒の期間を設定して違いが観察しやすくしています。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

PowerPoint で出力プレゼンテーションを開き、スライドショーを実行します。スライド 1 からスライド 2、次にスライド 3 からスライド 4 へ進みます。PowerPoint の再生では、スポーク数 1 が確認された場合は時計回りに 1 回のスイープでスライドが表示され、スポーク数 8 が確認された場合は 8 つの放射状セクタが同時に表示されます。目的のコンテンツとトランジションのタイミングは同一なので、違いは表示セクタの数だけです。

## **高度なスライド トランジションの追加**

スライドが画面に表示され続ける時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドがこの動作を制御します：

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) はマウスクリックで進めることを許可します。
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) は自動的に進行するようにします。
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) は自動的に進行するまでの遅延（ミリ秒）を指定します。

クリックとタイマーの両方の進行を有効にすると、クリックで進めるか、タイマーが切れるのを待つかのどちらでもスライドショーを進められます。タイマーのみを使用する場合は、[set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) に `false` を渡して呼び出します。遅延はスライドショーが進むタイミングを制御しますが、視覚的なトランジション効果の期間は設定しません。

この例は、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動的に進むようにします。マウスクリックでもこれらのスライドを進めることができます。3 枚以上のスライドが含まれる `input.pptx` ファイルを使用してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

タイマーによる進行が有効かどうかを確認するには、[get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) を呼び出します。保存された遅延だけではタイマーがアクティブであることを示しません。

次の例は、上記で保存したファイルを開き、各有効なタイマーを報告し、遅延が 2 秒を超えるスライドの自動進行を無効にします。そのスライドではマウスクリックを有効にし、更新された設定を保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **トランジション タイミングを正確に制御する**

トランジション効果の正確な長さ（ミリ秒）を指定するには、[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) を使用します。スライドの [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) メソッドは、[ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) を通じてこれらの設定を公開します。

| メソッド | 目的 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | トランジション効果自体の期間をミリ秒で設定します。 |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | スライドが自動的に進むまでの遅延をミリ秒で設定します。タイマーを有効にするには `true` を指定して [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) を呼び出します。 |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | 事前定義された速度カテゴリ（[TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow、Medium、Fast）から選択します。正確な期間が指定されていない場合に使用されます。 |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) はトランジション効果のみを制御し、スライドが表示され続ける時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides はトランジションタイプと [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) が返す値を使用して効果の期間を決定します。

<!-- visual-explanation:slide-transition:start -->
[![個別のバーが 750 ms のトランジション期間と 5,000 ms の自動進行設定を示しています。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*この共有例では、各スライドに 750 ms の Fade トランジションを設定し、別途 5,000 ms の自動進行を有効にします。トランジション期間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは概略設定であり、測定された統合タイムラインではありません。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同じ期間を適用する**

一定のペースを保つために、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) から Fade を選択し、各トランジションに 750 ミリ秒の期間を設定します。また、5,000 ミリ秒後の自動進行を別途有効にし、マウスクリックによる進行を無効にしてから、結果を PPTX として保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // 効果の期間とは独立して自動進行を設定します。
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **スライドごとに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。例えば、タイトルスライドには短いトランジション、セクション導入スライドには長いトランジションを使用します。この例では、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。2 枚以上のスライドが含まれる `input.pptx` ファイルを使用してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **アニメーション出力とトランジションを連携させる**

[animated GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/ja/cpp/export-to-html5/)、または [video](/slides/ja/cpp/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確なトランジション期間を設定して意図したペースに合わせます。例えば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF およびビデオの場合、出力フレームレートと効果期間を合わせます。600 ミリ秒は 30 fps の場合 18 フレームに相当します。HTML5 では、エクスポート設定でアニメーション トランジションを有効にします。選択したエクスポート形式がサポートする効果とタイミングオプションを確認し、出力をプレビューして同期を確認してください。

### **既存のトランジション期間を読み取る**

トランジションを変更する前に [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) を呼び出して、明示的な値が保存されているか確認します。`-1` の値は明示的な期間が設定されていないことを意味し、0 以上の値はミリ秒単位で保存された期間を示します。未設定の値は計算された再生期間ではありません。Aspose.Slides はトランジションタイプと [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) が返す値を使用して期間を決定します。トランジションタイプを設定すると期間が初期化されることがあるため、まず元の設定を調べてください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph トランジション**

Morph トランジションは、連続するスライド間のオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドをクローンし、クローン上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph トランジションを適用します。これにより、対応するオブジェクトが元の状態と変更後の状態の間でアニメーションします。

次の例は、テキスト矩形を含むスライドを作成し、スライドをクローンして、クローン上の矩形の位置とサイズを変更します。その後、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存されたファイルを開き、スライドショー中の効果を確認してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph トランジション タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチングしアニメーション化するかを制御します：

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) は各シェイプを全体のオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) は可能な場合、単語単位でテキストをマッチングしてアニメーションします。
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) は可能な場合、文字単位でテキストをマッチングしてアニメーションします。

[set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) に Morph を指定してから [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) にアクセスします。その値は [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) インターフェイスを提供し、[set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) メソッドでマッチングモードを選択します。

この例は、前のセクションで作成したプレゼンテーションを開き、2 番目のスライドを単語ベースの Morph アニメーションになるように構成します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **トランジション効果の設定**

一部のトランジションは、方向や効果が黒画面から開始するかなどの追加オプションを提供します。利用可能なオプションは選択したトランジションタイプに依存します。まずタイプを設定し、次に [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) が返す適切なインターフェイスを使用します。

次の例は、`input.pptx` の最初のスライドに Cut トランジションを適用します。[IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) を介して [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) に `true` を渡し、トランジションを黒画面から開始させます。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果期間が必要な場合は [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) を使用してください。事前定義された速度カテゴリ（[TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow、Medium、Fast）が十分で明示的な期間が設定されていない場合は [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) を使用します。これらの設定は、トランジション効果を自動進行遅延とは独立して制御します。

**トランジションにオーディオを添付し、ループさせることはできますか？**

はい。[set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) で埋め込みオーディオを割り当て、[set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) に [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) 列挙体の StartSound を指定し、[set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) でループを有効にします。オーディオはスライドショーの次のサウンド イベントが発生するまでループ再生されます。

**すべてのスライドに同じトランジションを適用する最速の方法は何ですか？**

プレゼンテーションの [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) メソッドが返すコレクションをループし、各スライドのトランジションに対して同じ値で [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で一貫した動作になります。

**スライドに現在設定されているトランジションを確認する方法は？**

スライドの [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) メソッドで取得したトランジションに対して [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列挙体の値で、None はトランジション効果が設定されていないことを意味します。