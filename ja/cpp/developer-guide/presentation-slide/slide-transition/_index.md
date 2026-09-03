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
- モーフ トランジション
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

スライド トランジションは、スライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for C++ を使用すると、各スライドにトランジション効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、C++ のサンプルを使用してトランジションを適用し、正確なトランジション時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph トランジションを作成する方法を示します。また、設定を PPTX ファイルに保存する方法も示しています。

## **スライド トランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[get_SlideShowTransition](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) を介してスライドのトランジション設定にアクセスします。[set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_type/) に [TransitionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitiontype/) 列挙体の値を渡してから、プレゼンテーションを保存します。

次の例は、最初のスライドに Circle トランジションを、2 番目のスライドに Comb トランジションを適用します。少なくとも 2 枚のスライドが含まれる `input.pptx` ファイルを使用してください。

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

## **高度なスライド トランジションの追加**

スライドが画面に表示される時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドがこの動作を制御します。

- [set_AdvanceOnClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) は、マウスクリックで進めることを許可します。  
- [set_AdvanceAfter](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_advanceafter/) は自動進行を有効にします。  
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) は、自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方を有効にすると、クリックで進めることも、タイマーが経過するのを待つこともできます。タイマーのみを使用する場合は、[set_AdvanceOnClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) に `false` を渡します。遅延はスライドショーの進行時期を制御しますが、ビジュアル トランジション効果の持続時間を設定するものではありません。

この例は、最初の 3 枚のスライドにそれぞれ異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。少なくとも 3 枚のスライドがある `input.pptx` を使用してください。

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

タイマー進行が有効かどうかを確認するには、[get_AdvanceAfter](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_advanceafter/) を呼び出します。保存された遅延だけでは、タイマーがアクティブかどうかは判断できません。

次の例は、上記で保存したファイルを開き、タイマーが有効なスライドを報告し、遅延が 2 秒を超えるスライドの自動進行を無効にします。これらのスライドではマウスクリックを有効にし、更新された設定を保存します。

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

## **トランジション時間を正確に制御する**

[set_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_duration/) を使用して、トランジション効果の正確な長さ（ミリ秒）を指定します。スライドの [get_SlideShowTransition](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) メソッドは、[ISlideShowTransition](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/) を介してこれらの設定を公開します。

| メソッド | 目的 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_duration/) | トランジション効果自体の持続時間（ミリ秒）を設定します。 |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | スライドが自動的に進むまでの遅延（ミリ秒）を設定します。タイマーを有効にするには、[set_AdvanceAfter](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_advanceafter/) に `true` を渡します。 |
| [set_Speed](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_speed/) | [TransitionSpeed](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionspeed/) 列挙体の事前定義された速度カテゴリ（Slow、Medium、Fast）を選択します。正確な期間が指定されていない場合に使用されます。 |

[set_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_duration/) はトランジション効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides はトランジションの種類と [get_Speed](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_speed/) が返す値から効果の持続時間を算出します。

### **すべてのスライドに同じ期間を適用する**

一定のペースを保つために、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitiontype/) から Fade を選択し、各トランジションに 750 ミリ秒の期間を設定します。自動進行は 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして、結果を PPTX として保存します。

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

    // エフェクトの持続時間とは別に自動進行を設定します。
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **スライドごとに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドには短いトランジションを、セクション導入スライドには長いトランジションを設定します。この例は、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。少なくとも 2 枚のスライドがある `input.pptx` を使用してください。

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

### **アニメーション出力とトランジションを調整する**

[animated GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)、[HTML5 プレゼンテーション](/slides/ja/cpp/export-to-html5/)、または [ビデオ](/slides/ja/cpp/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確なトランジション期間を設定して意図したペースに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を別々に調整してナレーションやコンテンツの時間を確保します。

GIF とビデオの場合、フレームレートと効果期間を合わせます。600 ミリ秒は 30 fps で 18 フレームに相当します。HTML5 では、エクスポート設定でアニメーション トランジションを有効にします。選択したエクスポート形式がサポートする効果とタイミング オプションを確認し、プレビューで同期を確認してください。

### **既存のトランジション期間を読み取る**

トランジションを変更する前に [get_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_duration/) を呼び出して、明示的な値が格納されているか確認します。`-1` は明示的な期間が設定されていないことを意味し、0 以上の値はミリ秒単位で格納された期間を示します。未設定の値は再生時間の計算結果ではなく、Aspose.Slides はトランジションの種類と [get_Speed](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_speed/) が返す値からその期間を導出します。トランジションの種類を設定すると期間が初期化されることがあるため、まず元の設定を検査してください。

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

Morph トランジションは、連続するスライド間のオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドをコピーし、コピー上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph トランジションを適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーション化されます。

以下の例は、テキスト矩形を含むスライドを作成し、そのスライドを複製してコピー上の矩形の位置とサイズを変更します。次に、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitiontype/) 列挙体で Morph を選択します。Morph をサポートするプレゼンテーション ビューアで保存されたファイルを開くと、スライドショー中に効果が確認できます。

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

## **Morph トランジションの種類**

[TransitionMorphType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチングしてアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionmorphtype/) は、各シェイプ全体をオブジェクトとして扱います。  
- [ByWord](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionmorphtype/) は、可能な限り単語単位でテキストをアニメーション化します。  
- [ByChar](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionmorphtype/) は、可能な限り文字単位でテキストをアニメーション化します。

Morph を選択したら、[set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_type/) で Morph を設定し、[get_Value](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_value/) で取得したインターフェイスから [IMorphTransition](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/imorphtransition/) を取得し、[set_MorphType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) でマッチングモードを選択します。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドで単語ベースの Morph アニメーションを設定します。

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

一部のトランジションは、方向や黒画面から開始するかどうかなどの追加オプションを公開しています。利用できるオプションは選択したトランジションのタイプに依存します。まずタイプを設定し、次に [get_Value](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_value/) が返す適切なインターフェイスを使用します。

以下の例は、`input.pptx` の最初のスライドに Cut トランジションを適用します。[IOptionalBlackTransition](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/ioptionalblacktransition/) を介して [set_FromBlack](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) に `true` を渡し、黒画面から開始するようにします。

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

はい。正確な効果時間（ミリ秒）が必要な場合は、[set_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_duration/) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionspeed/) カテゴリ（Slow、Medium、Fast）で十分で明示的な期間を設定しない場合は、[set_Speed](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_speed/) を使用します。これらの設定は自動進行遅延とは独立してトランジション効果を制御します。

**トランジションに音声を添付してループさせることはできますか？**

はい。[set_Sound](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_sound/) で埋め込み音声を割り当て、[set_SoundMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_soundmode/) に [TransitionSoundMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitionsoundmode/) 列挙体の StartSound を指定し、[set_SoundLoop](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_soundloop/) でループを有効にします。音声はスライドショーの次の音声イベントが発生するまでループし続けます。

**すべてのスライドに同じトランジションを適用する最速の方法は？**

プレゼンテーションの [get_Slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slides/) が返すコレクションをループし、各スライドのトランジションに対して同じ値で [set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/set_type/) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド間で動作が一貫します。

**スライドに現在設定されているトランジションを確認する方法は？**

スライドの [get_SlideShowTransition](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) が返すトランジションに対して [get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideshowtransition/get_type/) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.slideshow/transitiontype/) 列挙体の値です。None が返された場合、トランジション効果は適用されていません。