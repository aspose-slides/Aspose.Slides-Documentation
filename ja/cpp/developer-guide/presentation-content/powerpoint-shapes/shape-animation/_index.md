---
title: C++ を使用してプレゼンテーションにシェイプ アニメーションを適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/cpp/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーション の追加
- アニメーション の取得
- アニメーション の抽出
- エフェクト の追加
- エフェクト の取得
- エフェクト の抽出
- エフェクト サウンド
- アニメーション の適用
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法をご紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](/slides/ja/cpp/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。 

## **プレゼンテーションでアニメーションを使用する理由**

* 情報の流れを制御する  
* 重要なポイントを強調する  
* 聴衆の関心や参加を高める  
* コンテンツを読みやすく、理解しやすく、処理しやすくする  
* 読者や視聴者の注意をプレゼンテーションの重要な部分へ引きつける  

PowerPoint は、**entrance**、**exit**、**emphasis**、**motion paths** のカテゴリにまたがるアニメーションとアニメーション効果の多くのオプションとツールを提供します。 

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、アニメーションを操作するために必要なクラスと型を [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) 名前空間で提供します、  
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙型で **150** を超えるアニメーション効果を提供します。これらの効果は、基本的に PowerPoint で使用されるものと同じ（または同等）です。 

## **テキストボックスへのアニメーション適用**

Aspose.Slides for C++ を使用すると、図形内のテキストにアニメーションを適用できます。 

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) を追加します。  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) にテキストを追加します。  
5. 主要なエフェクトシーケンスを取得します。  
6. [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) にアニメーション効果を追加します。  
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) プロパティを [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) の値に設定します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。  

この C++ コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *By 1st Level Paragraphs* 値に設定する方法を示します：  
```c++
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 新しい AutoShape をテキスト付きで追加
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// スライドのメインシーケンスを取得
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// シェイプに Fade アニメーション効果を追加
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// シェイプのテキストを第1レベル段落単位でアニメーション
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// PPTX ファイルをディスクに保存
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert color="primary"  %}} 
テキストへのアニメーション適用に加えて、単一の [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph) にもアニメーションを適用できます。[**Animated Text**](/slides/ja/cpp/animated-text/) を参照してください。  
{{% /alert %}} 

## **PictureFrame へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) を追加または取得します。  
4. 主要なエフェクトシーケンスを取得します。  
5. [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) にアニメーション効果を追加します。  
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。  

この C++ コードは、`Fly` 効果を picture frame に適用する方法を示します：  
```c++
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを生成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// プレゼンテーションの画像コレクションに追加する画像を読み込みます
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// スライドに画像フレームを追加します
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// スライドのメインシーケンスを取得します
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 画像フレームに左から飛び込むアニメーション効果を追加します
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX ファイルをディスクに保存します
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Shape へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) を追加します。  
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) を追加します（このオブジェクトをクリックすると、アニメーションが再生されます）。  
5. Bevel 図形上でエフェクトシーケンスを作成します。  
6. カスタム `UserPath` を作成します。  
7. `UserPath` へ移動するコマンドを追加します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。  

この C++ コードは、`PathFootball`（パスフットボール）効果を shape に適用する方法を示します：  
```c++
	// ドキュメントディレクトリへのパスです。
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// プレゼンテーションをロードします
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドにアクセスします
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 選択したスライドのシェイプコレクションにアクセスします
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 既存シェイプ用に最初から PathFootball エフェクトを作成します。
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall アニメーション効果を追加します
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// 何らかの「ボタン」を作成します。
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// このボタン用のエフェクトシーケンスを作成します。
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // カスタムユーザーパスを作成します。ボタンがクリックされた後にのみオブジェクトが移動します。
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


## **Shape に適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/) インターフェイスの `GetEffectsByShape` メソッドを使用して、shape に適用されたすべてのアニメーション効果を取得する方法を示します。  

**例 1: 通常スライド上の shape に適用されたアニメーション効果の取得**  

以前、PowerPoint プレゼンテーションの shape にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初の shape に適用された効果を取得する方法を示します。  
```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// スライドのメインアニメーションシーケンスを取得します。
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

通常スライド上の shape がレイアウトスライドやマスタースライド上のプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中に shape のすべての効果が再生され、プレースホルダーから継承された効果も含まれます。  

たとえば、`sample.pptx` という PowerPoint プレゼンテーションファイルがあり、1 枚のスライドにフッター shape があり、テキストは「Made with Aspose.Slides」で、**Random Bars** 効果がその shape に適用されているとします。  
![スライド shape アニメーション効果](slide-shape-animation.png)  

また、**layout** スライドのフッタープレースホルダーに **Split** 効果が適用されているとします。  
![レイアウト shape アニメーション効果](layout-shape-animation.png)  

最後に、**master** スライドのフッタープレースホルダーに **Fly In** 効果が適用されているとします。  
![マスター shape アニメーション効果](master-shape-animation.png)  

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスの `GetBasePlaceholder` メソッドを使用して shape のプレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものを含むフッター shape に適用されたアニメーション効果を取得する方法を示します。  
```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
  
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 通常スライド上のシェイプのアニメーション効果を取得します。
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// レイアウトスライド上のプレースホルダーのアニメーション効果を取得します。
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
  

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly、ボトム
Type: 134, subtype: 45            // Split、VerticalIn
Type: 126, subtype: 22            // RandomBars、水平
```


## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for C++ を使用すると、アニメーション効果の Timing プロパティを変更できます。  

これは Microsoft PowerPoint の Animation Timing ペインです：  
![アニメーションタイミングペイン](shape-animation.png)  

これらは PowerPoint Timing と [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) プロパティ間の対応です：  

- PowerPoint Timing の **Start** ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) プロパティに対応します。  
- PowerPoint Timing の **Duration** は、[Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) プロパティに対応します。アニメーションの継続時間（秒）は、アニメーションが 1 サイクルを完了するまでの総時間です。  
- PowerPoint Timing の **Delay** は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) プロパティに対応します。  

Effect Timing プロパティを変更する手順は次のとおりです：  

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。  
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) プロパティに新しい値を設定します。  
3. 修正した PPTX ファイルを保存します。  

この C++ コードは操作を示しています：  
```c++
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// メインシーケンスの最初のエフェクトを取得します。
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// エフェクトの TriggerType をクリックで開始するように変更します。
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// エフェクトの Duration を変更します。
effect->get_Timing()->set_Duration(3.f);

// エフェクトの TriggerDelayTime を変更します。
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX ファイルをディスクに保存します。
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するための以下のプロパティを提供します：  

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **アニメーション効果サウンドの追加**

この C++ コードは、アニメーション効果サウンドを追加し、次の効果が開始するときにそれを停止する方法を示します：  
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// プレゼンテーションのオーディオコレクションにオーディオを追加します
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// スライドのメインシーケンスを取得します。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// メインシーケンスの最初のエフェクトを取得します
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// エフェクトが「サウンドなし」かチェックします
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 最初のエフェクトにサウンドを追加します
    firstEffect->set_Sound(effectSound);
}

// スライドの最初のインタラクティブシーケンスを取得します。
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// エフェクトの「前のサウンドを止める」フラグを設定します
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX ファイルをディスクに保存します
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```


### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 主要なエフェクトシーケンスを取得します。  
4. 各アニメーション効果に埋め込まれた [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) を抽出します。  

この C++コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します：  
```c++
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
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


## **アフターアニメーション**

Aspose.Slides for C++ を使用すると、アニメーション効果の After animation プロパティを変更できます。  

これは Microsoft PowerPoint の Animation Effect ペインと拡張メニューです：  
![アニメーション効果ペイン](shape-after-animation.png)  

PowerPoint Effect の **After animation** ドロップダウンリストは、以下のプロパティに対応します：  

- [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) プロパティは、After animation のタイプを示します：  
  * PowerPoint **More Colors** は、[AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) タイプに対応します；  
  * PowerPoint **Don't Dim** は、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) タイプ（デフォルトの after animation タイプ）に対応します；  
  * PowerPoint **Hide After Animation** は、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) タイプに対応します；  
  * PowerPoint **Hide on Next Mouse Click** は、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) タイプに対応します；  
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) プロパティは、after animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) タイプと連動します。タイプを別のものに変更すると、after animation のカラーはクリアされます。  

この C++ コードは、after animation 効果を変更する方法を示します：  
```c++
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// メインシーケンスの最初のエフェクトを取得します
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// アフターアニメーションのタイプを Color に変更します
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// アフターアニメーションの薄暗くなる色を設定します
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX ファイルをディスクに書き込みます
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```


## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するための以下のプロパティを提供します：  

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) は、効果のアニメートテキストタイプを示します。shape のテキストは次のようにアニメーション化できます：  
  * 一度に全体 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) タイプ)  
  * 単語ごとに ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) タイプ)  
  * 文字ごとに ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) タイプ)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) は、アニメートされたテキスト部品（単語または文字）間の遅延を設定します。正の値は効果継続時間の割合を示し、負の値は秒単位の遅延を示します。  

Effect Animate text プロパティを変更する手順は次のとおりです：  

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。  
2. [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) の値に設定し、*By Paragraphs* アニメーションモードをオフにします。  
3. [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) と [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) プロパティに新しい値を設定します。  
4. 修正した PPTX ファイルを保存します。  

この C++ コードは操作を示しています：  
```c++
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// メインシーケンスの最初のエフェクトを取得します
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// エフェクトのテキストアニメーションタイプを "As One Object" に変更します
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// エフェクトのアニメートテキストタイプを "By word" に変更します
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// エフェクトの継続時間の 20% に単語間の遅延を設定します
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX ファイルをディスクに書き込みます
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```


## **FAQ**

**プレゼンテーションをウェブに公開する際にアニメーションを保持するにはどうすればよいですか？**  
[Export to HTML5](/slides/ja/cpp/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) および [transition](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) アニメーションを有効にするオプションを有効にします。プレーン HTML ではスライドアニメーションは再生されませんが、HTML5 では再生されます。  

**shape の Z オーダー（レイヤー順序）を変更するとアニメーションにどのような影響がありますか？**  
アニメーションと描画順序は独立しています。エフェクトは表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) はどの要素が他の要素を覆うかを決定します。可視結果は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides のエフェクトと shape のモデルも同じロジックに従います。）  

**特定の効果をビデオに変換する際に制限はありますか？**  
一般に、[アニメーションはサポートされています](/slides/ja/cpp/convert-powerpoint-to-video/)、ただしまれなケースや特定の効果は異なる方式でレンダリングされる可能性があります。使用する効果とライブラリのバージョンでテストすることを推奨します。