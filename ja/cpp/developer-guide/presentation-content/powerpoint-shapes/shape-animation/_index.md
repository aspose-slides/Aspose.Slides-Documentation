---
title: C++ を使用したプレゼンテーションでのシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/cpp/shape-animation/
keywords:
- シェイプ
- アニメーション
- 効果
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- 効果の追加
- 効果の取得
- 効果の抽出
- 効果サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法をご紹介します。目立ちましょう！"
---
## **はじめに**

アニメーションはテキスト、画像、図形、または[チャート](/slides/ja/cpp/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に生命を与えます。 

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の興味や参加意欲を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は **入口**、**終了**、**強調**、**モーション パス** のカテゴリにまたがるアニメーションやアニメーション効果の多くのオプションとツールを提供します。 

## **Aspose.Slides のアニメーション**

* Aspose.Slides はアニメーションを操作するために必要なクラスと型を [Aspose.Slides.Animation](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides.animation) 名前空間で提供します,
* Aspose.Slides は [EffectType](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙体で **150** 以上のアニメーション効果を提供します。これらの効果は基本的に PowerPoint で使用されるものと同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for C++ を使用すると、図形内のテキストにアニメーションを適用できます。 

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape) を追加します。 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) にテキストを追加します。
5. メインのエフェクト シーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape) にアニメーション効果を追加します。 
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) プロパティを [BuildType Enumeration](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C++ コードは、`Fade` 効果を AutoShape に適用し、テキスト アニメーションを *By 1st Level Paragraphs* の値に設定する方法を示しています：

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_paragraph)にもアニメーションを適用できます。詳しくは[**Animated Text**](/slides/ja/cpp/animated-text/)をご覧ください。

{{% /alert %}} 

## **PictureFrameへのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [PictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_picture_frame) を追加するか取得します。 
4. メインのエフェクト シーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_picture_frame) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C++ コードは、`Fly` 効果を picture frame に適用する方法を示しています：

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// プレゼンテーションの画像コレクションに追加する画像をロードします。
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// スライドに画像フレームを追加します。
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// スライドのメイン シーケンスを取得します。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 画像フレームに左からのフライ アニメーション効果を追加します。
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX ファイルをディスクに保存します。
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Shapeへのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape) を追加します。 
4. `Bevel` の [IAutoShape] を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. Bevel 形状に対してエフェクト シーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` へ移動するコマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C++ コードは、`PathFootball`（パスフットボール）効果を shape に適用する方法を示しています：

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// ドキュメント ディレクトリへのパス。
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// プレゼンテーションを読み込みます
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドにアクセスします
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 選択されたスライドのシェイプ コレクションにアクセスします
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 既存のシェイプに対して最初から PathFootball 効果を作成します。
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall アニメーション効果を追加します。
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// 何らかの「ボタン」を作成します。
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// このボタン用のエフェクト シーケンスを作成します。
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // カスタム ユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// 作成されたパスが空なので、移動コマンドを追加します。
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // PPTX ファイルをディスクに書き込みます
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Shapeに適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/) インターフェイスの `GetEffectsByShape` メソッドを使用して、Shape に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常のスライド上の Shape に適用されたアニメーション効果の取得**

以前は、PowerPoint プレゼンテーションの Shape にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライドの最初の Shape に適用された効果を取得する方法を示しています。

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// スライドのメイン アニメーション シーケンスを取得します。
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// 最初のスライド上の最初のシェイプを取得します。
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// シェイプに適用されたアニメーション効果を取得します。
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果の取得**

通常のスライド上の Shape にレイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にその Shape のすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

たとえば、`sample.pptx` という PowerPoint ファイルにフッター Shape が 1 つだけ含まれ、テキストが「Made with Aspose.Slides」で、**Random Bars** 効果がその Shape に適用されているとします。

![スライド形状アニメーション効果](slide-shape-animation.png)

さらに、レイアウトスライドのフッター プレースホルダーに **Split** 効果が適用されているとします。

![レイアウト形状アニメーション効果](layout-shape-animation.png)

最後に、マスタースライドのフッター プレースホルダーに **Fly In** 効果が適用されているとします。

![マスター形状アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) インターフェイスの `GetBasePlaceholder` メソッドを使用して Shape のプレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものを含めてフッター Shape に適用されたアニメーション効果を取得する方法を示しています。

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 正常なスライド上のシェイプのアニメーション効果を取得します。
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// レイアウト スライド上のプレースホルダーのアニメーション効果を取得します。
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// マスタースライド上のプレースホルダーのアニメーション効果を取得します。
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // フライ, 下
Type: 134, subtype: 45            // スプリット, 縦方向
Type: 126, subtype: 22            // ランダムバー, 水平
```

## **アニメーション効果のタイミング プロパティの変更**

Aspose.Slides for C++ を使用すると、アニメーション効果の Timing プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション タイミング ペインです：

![example1_image](shape-animation.png)

PowerPoint の Timing と [Effect.Timing](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) プロパティの対応は次のとおりです。

- PowerPoint Timing **Start** のドロップダウン リストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) プロパティに一致します。 
- PowerPoint Timing **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) プロパティに一致します。アニメーションの継続時間（秒）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。 
- PowerPoint Timing **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) プロパティに一致します。 

Effect Timing プロパティを変更する手順は次のとおりです。

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) プロパティに新しい値を設定します。 
3. 変更した PPTX ファイルを保存します。

この C++ コードは操作を示しています：

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// スライドのメイン シーケンスを取得します。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// メイン シーケンスの最初のエフェクトを取得します。
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// エフェクトの TriggerType をクリックで開始するように変更します
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// エフェクトの Duration を変更します
effect->get_Timing()->set_Duration(3.f);

// エフェクトの TriggerDelayTime を変更します
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX ファイルをディスクに保存します
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **アニメーション効果サウンド**

Aspose.Slides はアニメーション効果のサウンドを扱うために次のプロパティを提供します: 

- [set_Sound()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **アニメーション効果サウンドの追加**

この C++ コードは、アニメーション効果サウンドを追加し、次の効果が開始したときにサウンドを停止する方法を示しています：

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// プレゼンテーションのオーディオ コレクションにオーディオを追加します
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// スライドのメイン シーケンスを取得します。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// メイン シーケンスの最初のエフェクトを取得します。
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// エフェクトに「サウンドなし」かどうかチェックします
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 最初のエフェクトにサウンドを追加します
    firstEffect->set_Sound(effectSound);
}

// スライドの最初のインタラクティブ シーケンスを取得します。
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// エフェクトの「前のサウンドを停止」フラグを設定します
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX ファイルをディスクに書き込みます
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. メインのエフェクト シーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [set_Sound()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effect/set_sound/) を抽出します。 

この C++ コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています：

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// スライドのメイン シーケンスを取得します。
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **アニメーション後**

Aspose.Slides for C++ を使用すると、アニメーション効果の After アニメーション プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション 効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウン リストは以下のプロパティに対応しています: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) プロパティは After アニメーションのタイプを表します :
  * PowerPoint **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) タイプに一致します；
  * PowerPoint **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) タイプに一致します（デフォルトの After アニメーションタイプ）；
  * PowerPoint **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) タイプに一致します；
  * PowerPoint **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) タイプに一致します；
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) プロパティは After アニメーションのカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) タイプと組み合わせて使用します。タイプを他に変更すると、After アニメーションのカラーはクリアされます。

この C++ コードは After アニメーション効果を変更する方法を示しています：

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// メイン シーケンスの最初のエフェクトを取得します
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// After アニメーションのタイプを Color に変更します
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// After アニメーションの dim カラーを設定します
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX ファイルをディスクに書き込みます
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **テキストのアニメーション**

Aspose.Slides はアニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します:

- [set_AnimateTextType()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) は効果のアニメート テキスト タイプを表します。Shape のテキストは次のいずれかでアニメーション化できます:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/animatetexttype/) タイプ)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/animatetexttype/) タイプ)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/animatetexttype/) タイプ)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) はアニメートされたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを示し、負の値は秒単位の遅延を示します。

Effect Animate text プロパティを変更する手順は次のとおりです:

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. [set_BuildType()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation.itextanimation/set_buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/buildtype/) の値に設定し、*By Paragraphs* アニメーション モードをオフにします。
3. [set_AnimateTextType()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) と [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) の新しい値を設定します。
4. 変更した PPTX ファイルを保存します。

この C++ コードは操作を示しています：

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// メイン シーケンスの最初のエフェクトを取得します
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// エフェクトのテキスト アニメーション タイプを「As One Object」に変更します
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// エフェクトのアニメート テキスト タイプを「By word」に変更します
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// 単語間の遅延を効果の期間の 20% に設定します
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX ファイルをディスクに保存します
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### プレゼンテーションを Web に公開する際にアニメーションが保持されていることをどう確認できますか？

[HTML5 へエクスポート](/slides/ja/cpp/export-to-html5/)し、[shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/set_animateshapes/) と [transition](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/set_animatetransitions/) アニメーションを担当する [options](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/) を有効にします。プレーン HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

### シェイプの z 順序（レイヤー順序）を変更すると、アニメーションにどのような影響がありますか？

アニメーションと描画順序は独立しています。効果は表示/非表示のタイミングと種類を制御し、[z-order](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/get_zorderposition/) はどのオブジェクトが他を覆うかを決定します。最終的な表示は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides の効果とシェイプのモデルも同じロジックに従います。）

### 特定の効果を動画に変換する際に制限はありますか？

一般的に[アニメーションはサポートされています](/slides/ja/cpp/convert-powerpoint-to-video/)、ただし稀なケースや特定の効果は異なる方法でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。