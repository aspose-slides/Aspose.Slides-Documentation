---
title: 形状アニメーション
type: docs
weight: 60
url: /cpp/shape-animation/
keywords: "PowerPoint アニメーション, アニメーション効果, アニメーションの適用, PowerPoint プレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointアニメーションを適用する"
---

アニメーションは、テキスト、画像、形状、または [チャート](/slides/cpp/animated-charts/) に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

### **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用することで、

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の興味や参加を高める
* コンテンツを読みやすくまたは理解しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は、**入場**、**退場**、**強調**、**動きのパス**カテゴリにわたってアニメーションとアニメーション効果のための多くのオプションとツールを提供しています。

### **Aspose.Slides におけるアニメーション**

* Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) 名前空間の下でアニメーションを扱うために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙型の下で **150 以上のアニメーション効果** を提供しています。これらの効果は、基本的にPowerPointで使用される効果と同じ（または同等）です。

## **テキストボックスにアニメーションを適用する**

Aspose.Slides for C++ は、形状内のテキストにアニメーションを適用することを可能にします。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) にテキストを追加します。
5. 効果のメインシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) にアニメーション効果を追加します。
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) プロパティを [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) からの値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C++ コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *最初のレベルの段落ごとに* 値に設定する方法を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// テキストを持つ新しい AutoShape を追加
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"最初の段落 \n2 番目の段落 \n3 番目の段落");

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// 形状に Fade アニメーション効果を追加します
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 形状のテキストを最初のレベルの段落ごとにアニメーション化します
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// PPTX ファイルをディスクに保存します
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

テキストにアニメーションを適用するだけでなく、単一の [段落](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph) にもアニメーションを適用できます。詳細は [**アニメーション テキスト**](/slides/cpp/animated-text/) をご覧ください。

{{% /alert %}} 

## **PictureFrame にアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) を追加または取得します。
4. 効果のメインシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C++ コードは、画像フレームに `Fly` 効果を適用する方法を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// プレゼンテーションの画像コレクションに追加する画像をロードします
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// スライドに画像フレームを追加します
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 画像フレームに左からの Fly アニメーション効果を追加します
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX ファイルをディスクに保存します
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **形状にアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) を追加します。
4. クリックされるとアニメーションが再生される `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) を追加します。
5. ビベル形状の効果のシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C++ コードは、形状に `PathFootball` 効果を適用する方法を示しています：

```c++
// 文書ディレクトリへのパス
const String outPath = u"../out/AnimationsOnShapes_out.pptx";
const String templatePath = u"../templates/ConnectorLineAngle.pptx";

// プレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 選択されたスライドの形状コレクションにアクセスします
SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

// 既存の形状に PathFootball 効果をゼロから作成します。
SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

ashp->AddTextFrame(u"アニメーションテキストボックス");

// PathFootBall アニメーション効果を追加します
slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
	EffectSubtype::None, EffectTriggerType::AfterPrevious);

// いわゆる「ボタン」を作成します。
SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

// このボタンの効果のシーケンスを作成します。
SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
 
// カスタムユーザーパスを作成します。ボタンがクリックされた後にのみオブジェクトが移動されます。
SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

// 作成したパスは空であるため、移動のためのコマンドを追加します。
SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
const PointF point = PointF (0.076, 0.59);
System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
 
//PointF point2[1] = { -0.076, -0.59 };
const PointF point2 = PointF(-0.076, -0.59 );

System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
 
motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
 
// PPTX ファイルをディスクに書き込みます
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **形状に適用されたアニメーション効果を取得する**

特定の形状に適用されているすべてのアニメーション効果を確認することを決定する場合があります。

この C++ コードは、特定の形状に適用されているすべての効果を取得する方法を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// スライド上の最初の形状を取得します。
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// 形状に適用されたすべてのアニメーション効果を取得します。
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"形状 ") + shape->get_Name() + u" には " + shapeEffects->get_Length() + u" アニメーション効果があります。");
}
```

## **アニメーション効果のタイミングプロパティを変更する**

Aspose.Slides for C++ は、アニメーション効果のタイミングプロパティを変更することを可能にします。

これが Microsoft PowerPoint のアニメーションタイミングペインです：

![example1_image](shape-animation.png)

これらは PowerPoint のタイミングと [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) プロパティとの対応です：

- PowerPoint タイミング **開始** ドロップダウンリストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) プロパティに一致します。 
- PowerPoint タイミング **持続時間** は [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) プロパティに一致します。アニメーションの持続時間（秒単位）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。 
- PowerPoint タイミング **遅延** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) プロパティに一致します。 

これがエフェクトタイミングプロパティを変更する方法です：

1. [アニメーション効果を適用する](#apply-animation-to-shape) または取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) プロパティの新しい値を設定します。
3. 修正された PPTX ファイルを保存します。

この C++ コードは、操作を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// メインシーケンスの最初の効果を取得します。
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// 効果の TriggerType をクリック時に開始するように変更します
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 効果の持続時間を変更します
effect->get_Timing()->set_Duration(3.f);

// 効果の TriggerDelayTime を変更します
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX ファイルをディスクに保存します
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **アニメーション効果の音**

Aspose.Slides は、アニメーション効果の音に関して作業することを可能にする以下のプロパティを提供します： 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **アニメーション効果の音を追加する**

この C++ コードは、アニメーション効果の音を追加し、次の効果が開始されると停止する方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// プレゼンテーションの音声コレクションに音声を追加します
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// メインシーケンスの最初の効果を取得します
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// 効果が「サウンドなし」かどうかを確認します
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 最初の効果に音を追加します
    firstEffect->set_Sound(effectSound);
}

// スライドの最初のインタラクティブシーケンスを取得します。
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// 効果の「前の音を停止」フラグを設定します
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX ファイルをディスクに書き込みます
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **アニメーション効果の音を抽出する**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。 
3. 効果のメインシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれている [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) を抽出します。 

この C++ コードは、アニメーション効果に埋め込まれている音を抽出する方法を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **アニメーションの後**

Aspose.Slides for C++ は、アニメーション効果のアフターアニメーションプロパティを変更することを可能にします。

これが Microsoft PowerPoint のアニメーション効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint 効果 **アフターアニメーション** ドロップダウンリストは、以下のプロパティに一致します： 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) プロパティは、アフターアニメーションタイプを説明します：
  * PowerPoint **その他の色** は [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 型に一致します；
  * PowerPoint **薄暗くしない** リストアイテムは、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 型（デフォルトのアフターアニメーションタイプ）に一致します；
  * PowerPoint **アニメーション後に非表示** アイテムは、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 型に一致します；
  * PowerPoint **次のマウスクリックで非表示** アイテムは、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 型に一致します；
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) プロパティは、アフターアニメーションカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 型と連携して機能します。タイプを別のものに変更すると、アフターアニメーションカラーはクリアされます。

この C++ コードは、アフターアニメーション効果を変更する方法を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// メインシーケンスの最初の効果を取得します
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// アフターアニメーションタイプを色に変更します
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// アフターアニメーションの暗くする色を設定します
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX ファイルをディスクに書き込みます
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **テキストをアニメーション化する**

Aspose.Slides は、アニメーション効果の *テキストをアニメーション化* ブロックとともに作業するための以下のプロパティを提供します：

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) は、効果のアニメートテキストタイプを説明します。形状のテキストはアニメーション化できます：
  - 一度にすべて ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 型)
  - 単語ごと ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 型)
  - 文字ごと ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 型)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) は、アニメーション化されたテキスト部分（単語や文字）の間の遅延を設定します。正の値は効果の持続時間のパーセンテージを指定します。負の値は秒単位の遅延を指定します。

これがアニメーション効果のテキストをアニメーション化プロパティを変更する方法です：

1. [アニメーションを適用する](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) 値に設定して、*段落ごとに* アニメーションモードをオフにします。
3. [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) および [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) プロパティの新しい値を設定します。
4. 修正された PPTX ファイルを保存します。

この C++ コードは、操作を示しています：

```c++
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// メインシーケンスの最初の効果を取得します
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 効果のテキストアニメーションタイプを「1つのオブジェクト」として変更します
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// 効果のアニメートテキストタイプを「単語ごと」に変更します
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// 単語の間の遅延を効果の持続時間の 20% に設定します
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX ファイルをディスクに保存します
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```