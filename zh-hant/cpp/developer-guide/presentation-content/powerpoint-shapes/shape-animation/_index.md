---
title: 在簡報中使用 C++ 套用圖形動畫
linktitle: 圖形動畫
type: docs
weight: 60
url: /zh-hant/cpp/shape-animation/
keywords:
- 圖形
- 動畫
- 效果
- 動畫圖形
- 動畫文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立與自訂圖形動畫。脫穎而出！"
---
## **簡介**

動畫是可套用於文字、影像、圖形或[圖表](/slides/zh-hant/cpp/animated-charts/)的視覺效果。它們為簡報或其組成部分賦予活力。

## **為何在簡報中使用動畫？**

使用動畫，您可以  

* 控制資訊流動  
* 強調重要重點  
* 增加觀眾的興趣或參與度  
* 讓內容更易於閱讀、吸收或處理  
* 吸引讀者或觀眾注意簡報中的重要部分  

PowerPoint 提供眾多選項與工具，用於在**進入**、**退出**、**強調**和**移動路徑**類別中的動畫與動畫效果。

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation) 命名空間中提供您處理動畫所需的類別與型別，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列舉中提供超過**150 個動畫效果**。這些效果基本上與 PowerPoint 中使用的效果相同（或等效）。

## **將動畫套用至文字方塊**

Aspose.Slides for C++ 允許您將動畫套用至圖形中的文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape)。  
4. 將文字加入 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3)。  
5. 取得主要的效果序列。  
6. 將動畫效果加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape)。  
7. 將 [TextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) 屬性設定為 [BuildType Enumeration](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) 中的值。  
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 C++ 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs* 值：

```c++
// 實例化一個代表簡報檔案的 Presentation 類別。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 新增帶有文字的 AutoShape。
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// 取得投影片的主要序列。
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// 為圖形新增 Fade 動畫效果。
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 依第一層段落為圖形文字添加動畫。
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// 將 PPTX 檔案儲存到磁碟。
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

除了將動畫套用至文字外，您還可以將動畫套用至單一[段落](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_paragraph)。請參閱[**Animated Text**](/slides/zh-hant/cpp/animated-text/)。

{{% /alert %}} 

## **將動畫套用至圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 在投影片上加入或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_picture_frame)。  
4. 取得主要的效果序列。  
5. 將動畫效果加入 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_picture_frame)。  
6. 將簡報寫入磁碟為 PPTX 檔案。

以下 C++ 程式碼示範如何將 `Fly` 效果套用至圖片框：

```c++
// 實例化一個代表簡報檔案的 Presentation 類別。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 載入要加入簡報影像集合的圖像
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// 將圖片框新增至投影片
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// 取得投影片的主要序列。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 為圖片框新增從左側飛入的動畫效果
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 將 PPTX 檔案儲存至磁碟
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **將動畫套用至圖形**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape)。  
4. 加入一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape)（點擊此物件時會播放動畫）。  
5. 在 Bevel 圖形上建立效果序列。  
6. 建立自訂的 `UserPath`。  
7. 加入移動至 `UserPath` 的指令。  
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 C++ 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至圖形：

```c++
	// 文件目錄的路徑。
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 載入簡報
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 存取第一張投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 存取所選投影片的圖形集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 為現有圖形從頭建立 PathFootball 效果。
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// 新增 PathFootBall 動畫效果
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// 建立類似「按鈕」的圖形。
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// 為此按鈕建立效果序列。
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // 建立自訂使用者路徑。只有在按鈕被點擊後，我們的物件才會移動。
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// 新增移動指令，因為建立的路徑目前為空。
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	//PointF point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //將 PPTX 檔案寫入磁碟
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **取得套用於圖形的動畫效果**

以下範例說明如何使用 [ISequence](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/) 介面中的 `GetEffectsByShape` 方法，以取得套用於圖形的全部動畫效果。

**範例 1：取得套用於普通投影片上圖形的動畫效果**

先前您已學習如何在 PowerPoint 簡報中為圖形加入動畫效果。以下範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一個普通投影片的第一個圖形所套用的效果。

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**範例 2：取得所有動畫效果，包括從佔位元件繼承的效果**

如果普通投影片上的圖形具有位於版面投影片和/或母版投影片的佔位元件，且這些佔位元件已加入動畫效果，則在投影片放映期間，該圖形的所有效果都會被播放，包含從佔位元件繼承的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中有一張投影片僅包含一個頁腳圖形，文字為「Made with Aspose.Slides」，且已套用 **Random Bars** 效果。

![投影片圖形動畫效果](slide-shape-animation.png)

再假設在 **layout** 投影片的頁腳佔位元件上套用了 **Split** 效果。

![版面圖形動畫效果](layout-shape-animation.png)

最後，在 **master** 投影片的頁腳佔位元件上套用了 **Fly In** 效果。

![母片圖形動畫效果](master-shape-animation.png)

以下範例程式碼示範如何使用 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面的 `GetBasePlaceholder` 方法，取得圖形佔位元件，並取得套用於頁腳圖形的動畫效果，包含來自版面與母片投影片佔位元件的繼承效果。

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

// 取得普通投影片上圖形的動畫效果。
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// 取得版面投影片上佔位元件的動畫效果。
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// 取得母片投影片上佔位元件的動畫效果。
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
Type: 47, subtype: 2              // 飛入, 底部
Type: 134, subtype: 45            // 分割, 垂直進入
Type: 126, subtype: 22            // 隨機條紋, 水平
```

## **變更動畫效果時間屬性**

Aspose.Slides for C++ 允許您變更動畫效果的時間屬性。

以下為 Microsoft PowerPoint 中的動畫時間面板：

![Animation Timing 面板](shape-animation.png)

- PowerPoint 時間 **Start** 下拉式清單對應 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) 屬性。  
- PowerPoint 時間 **Duration** 對應 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) 屬性。動畫的持續時間（以秒為單位）是動畫完成一次循環所需的總時間。  
- PowerPoint 時間 **Delay** 對應 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) 屬性。  

以下說明如何變更 Effect Timing 屬性：

1. 套用（[Apply](#apply-animation-to-shape)）或取得動畫效果。  
2. 為您需要的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 屬性設定新值。  
3. 儲存已修改的 PPTX 檔案。  

以下 C++ 程式碼示範此操作：

```c++
// 實例化一個代表簡報檔案的 Presentation 類別。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 取得投影片的主要序列。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 取得主要序列的第一個效果。
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// 將效果的 TriggerType 變更為點擊時開始
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 變更效果的持續時間
effect->get_Timing()->set_Duration(3.f);

// 變更效果的 TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// 將 PPTX 檔案儲存至磁碟
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，讓您在動畫效果中使用音效：

- [set_Sound()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **新增動畫效果音效**

以下 C++ 程式碼示範如何加入動畫效果音效，並在下一個效果開始時停止該音效：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 新增音訊至簡報的音訊集合
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 取得投影片的主要序列。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// 取得主要序列的第一個效果
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// 檢查效果是否為「無音效」
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 為第一個效果新增音效
    firstEffect->set_Sound(effectSound);
}

// 取得投影片的第一個互動序列。
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// 設定效果的「停止先前音效」旗標
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// 將 PPTX 檔案寫入磁碟
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 取得主要的效果序列。  
4. 擷取每個動畫效果所嵌入的 [set_Sound()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effect/set_sound/)。  

以下 C++ 程式碼示範如何擷取嵌入於動畫效果中的音效：

```c++
// 實例化一個代表簡報檔案的 Presentation 類別。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 取得投影片的主要序列。
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **動畫結束後**

Aspose.Slides for C++ 允許您變更動畫效果的 After animation 屬性。

以下為 Microsoft PowerPoint 中的動畫效果面板與擴充功能表：

![Animation Effect 面板](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉式清單對應以下屬性：

- [set_AfterAnimationType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) 屬性描述 After animation 類型：
  * PowerPoint **More Colors** 對應 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 類型；  
  * PowerPoint **Don't Dim** 對應 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 類型（預設 after animation 類型）；  
  * PowerPoint **Hide After Animation** 對應 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 類型；  
  * PowerPoint **Hide on Next Mouse Click** 對應 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 類型；  
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) 屬性定義 after animation 的顏色格式。此屬性需與 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 類型共用。若將類型變更為其他，則 after animation 顏色會被清除。

以下 C++ 程式碼示範如何變更動畫結束後的效果：

```c++
// 實例化一個代表簡報檔案的 Presentation 類別
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 取得主要序列的第一個效果
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 將 After animation 類型變更為 Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// 設定 After animation 的調暗顏色
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// 將 PPTX 檔案寫入磁碟
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **動畫文字**

Aspose.Slides 提供以下屬性，讓您操作動畫效果的 *Animate text* 區塊：

- [set_AnimateTextType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 描述動畫文字的類型。圖形文字可以以以下方式動畫化：
  - 全部一次 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/animatetexttype/) 類型)  
  - 逐字 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/animatetexttype/) 類型)  
  - 逐字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/animatetexttype/) 類型)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 設定動畫文字部件（字或字母）之間的延遲。正值表示效果持續時間的百分比，負值表示以秒為單位的延遲。

以下說明如何變更 Effect Animate text 屬性：

1. 套用（[Apply](#apply-animation-to-shape)）或取得動畫效果。  
2. 將 [set_BuildType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation.itextanimation/set_buildtype/) 屬性設定為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/buildtype/) 值，以關閉 *By Paragraphs* 動畫模式。  
3. 為 [set_AnimateTextType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation.ieffect/set_animatetexttype/) 及 [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation.ieffect/set_delaybetweentextparts/) 屬性設定新值。  
4. 儲存已修改的 PPTX 檔案。  

以下 C++ 程式碼示範此操作：

```c++
// 實例化一個代表簡報檔案的 Presentation 類別。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 取得主要序列的第一個效果
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 將效果的文字動畫類型變更為 As One Object
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// 將效果的 Animate text 類型變更為 By word
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// 設定字與字之間的延遲為效果持續時間的 20%
firstEffect->set_DelayBetweenTextParts(20.0f);

// 將 PPTX 檔案寫入磁碟
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **常見問題**

**如何在將簡報發佈到網路上時確保動畫被保留？**

[Export to HTML5](/slides/zh-hant/cpp/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animateshapes/) 與 [transition](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animatetransitions/) 動畫的 [options](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/)。純 HTML 不會播放投影片動畫，而 HTML5 會播放。

**變更圖形的 Z 順序（圖層順序）會如何影響動畫？**

動畫與繪製順序是獨立的：效果控制出現/消失的時間與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/get_zorderposition/) 決定哪個圖形覆蓋哪個圖形。可見的結果由二者的組合決定。（這是一般 PowerPoint 的行為；Aspose.Slides 的效果與圖形模型遵循相同邏輯。）

**將動畫轉換為影片時，某些效果會有相容性限制嗎？**

一般而言，[動畫受到支援](/slides/zh-hant/cpp/convert-powerpoint-to-video/)，但在少數情況或特定效果下可能會以不同方式呈現。建議使用您所用的效果以及相同版本的函式庫進行測試。