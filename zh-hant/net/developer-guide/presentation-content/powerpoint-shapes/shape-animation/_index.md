---
title: 在 .NET 中於簡報套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/net/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立與自訂形狀動畫。脫穎而出！"
---
## **簡介**

動畫是可套用於文字、影像、圖形或[圖表](/slides/zh-hant/net/animated-charts/)的視覺效果。它們為簡報或其組成部分增添生氣。 

## **為何在簡報中使用動畫？**

使用動畫，您可以 

* 控制資訊的流向
* 強調重要要點
* 提升觀眾的興趣或參與度
* 讓內容更容易閱讀、吸收或處理
* 吸引讀者或觀眾注意簡報中的重要部分

PowerPoint 在**進入**、**退出**、**強調**與**動作路徑**類別中提供了許多動畫及動畫效果的選項與工具。 

## **Aspose.Slides 中的動畫**

* Aspose.Slides 提供您在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/) 命名空間下使用動畫所需的類別與型別，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype) 列舉中提供超過 **150 個動畫效果**。這些效果本質上與 PowerPoint 中使用的效果相同（或等效）。  

## **將動畫套用至文字方塊**

Aspose.Slides for .NET 允許您將動畫套用至圖形中的文字。 

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)。  
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/properties/textframe) 加入文字。  
5. 取得主要的效果序列。  
6. 為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape) 新增動畫效果。  
7. 將 [TextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/textanimation/properties/buildtype) 屬性設定為 [BuildType Enumeration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype) 中的值。  
8. 將簡報寫入磁碟為 PPTX 檔案。  

以下 C# 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs* 值：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 實例化一個代表簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 新增帶文字的 AutoShape
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // 新增三個段落，使逐段落建構具有可逐步處理的內容。
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // 取得投影片的主要序列。
    ISequence sequence = sld.Timeline.MainSequence;

    // 為形狀新增 Fade 動畫效果
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 依第一層段落為形狀文字套用動畫
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // 將 PPTX 檔案儲存至磁碟
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

除了將動畫套用至文字之外，您還可以將動畫套用至單一[段落](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph)。請參閱[**Animated Text**](/slides/zh-hant/net/animated-text/)。

{{% /alert %}} 

## **將動畫套用至圖片框 (PictureFrame)**

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe)。  
5. 取得主要的效果序列。  
6. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe) 新增動畫效果。  
8. 将简报写入磁碟为 PPTX 檔案。  

以下 C# 程式碼示範如何將 `Fly` 效果套用至圖片框：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 實例化一個代表簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation())
{
    // 載入要加入簡報圖像集合的圖片
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 在投影片上新增圖片框
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 取得投影片的主要序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 為圖片框新增從左側飛入的動畫效果
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 將 PPTX 檔案儲存至磁碟
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **將動畫套用至圖形**

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)。  
4. 新增一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)（當此物件被點擊時，動畫將播放）。  
5. 為斜角形狀建立效果序列。  
6. 建立自訂 `UserPath`。  
7. 加入移動至 `UserPath` 的指令。  
8. 将简报写入磁碟为 PPTX 檔案。  

以下 C# 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至圖形：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 實例化一個代表簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 為現有圖形從頭建立 PathFootball 效果。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // 新增 PathFootBall 動畫效果。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 建立某種「按鈕」。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 為按鈕建立效果序列。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // 建立自訂使用者路徑。我們的物件僅在按鈕被點擊後才會移動。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 新增移動指令，因為建立的路徑目前是空的。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // 將 PPTX 檔案寫入磁碟
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **取得套用於圖形的動畫效果**

以下範例示範如何使用 [ISequence](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/) 介面的 `GetEffectsByShape` 方法，取得套用於圖形的所有動畫效果。  

**範例 1：取得套用於一般投影片上圖形的動畫效果**

先前您已學習如何在 PowerPoint 簡報中為圖形加入動畫效果。以下範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一張一般投影片上第一個圖形的效果。

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // 取得投影片的主要動畫序列。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 取得第一張投影片上的第一個圖形。
    IShape shape = firstSlide.Shapes[0];

    // 取得套用於圖形的動畫效果。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**範例 2：取得所有動畫效果，包括從佔位符繼承的效果**

如果一般投影片上的圖形擁有位於佈局投影片和/或母片投影片的佔位符，且這些佔位符已加入動畫效果，則在投影片放映時，該圖形的所有效果都會播放，包含從佔位符繼承的效果。  

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中唯一的投影片僅包含一個文字為「Made with Aspose.Slides」的頁腳圖形，且已套用 **Random Bars** 效果。  

![Slide shape animation effect](slide-shape-animation.png)

再假設在 **layout** 投影片的頁腳佔位符上套用了 **Split** 效果。  

![Layout shape animation effect](layout-shape-animation.png)

最後，在 **master** 投影片的頁腳佔位符上套用了 **Fly In** 效果。  

![Master shape animation effect](master-shape-animation.png)

以下範例程式碼示範如何使用 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面的 `GetBasePlaceholder` 方法，取得圖形佔位符，並取得套用於頁腳圖形的動畫效果，包含來自佈局與母片投影片上佔位符的繼承效果。  

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得普通投影片上圖形的動畫效果。
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // 取得版面投影片上佔位符的動畫效果。
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // 取得母版投影片上佔位符的動畫效果。
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **變更動畫效果時間屬性**

Aspose.Slides for .NET 允許您變更動畫效果的 Timing（時間）屬性。  

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

以下是 PowerPoint Timing 與 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/properties/timing) 屬性之對應關係：

- PowerPoint Timing **Start** 下拉選單對應 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/properties/triggertype) 屬性。  
- PowerPoint Timing **Duration** 對應 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/properties/duration) 屬性。動畫的持續時間（以秒為單位）是動畫完成一次循環所需的總時間。  
- PowerPoint Timing **Delay** 對應 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 屬性。  
- PowerPoint Timing **Repeat** 下拉選單對應以下屬性：  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount) 屬性，用於描述效果重複的*次數*；  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide) 旗標，指定效果是否重複至投影片結束；  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick) 旗標，指定效果是否重複至下一次點擊。  
- PowerPoint Timing **Rewind when done playing** 核取方塊對應 [Effect.Timing.Rewind](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/rewind/) 屬性。  

以下說明如何變更 Effect Timing（效果時間）屬性：

1. [Apply](#apply-animation-to-shape) 或取得動畫效果。  
2. 為所需的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/properties/timing) 屬性設定新值。  
3. 儲存已修改的 PPTX 檔案。  

以下 C# 程式碼示範此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 實例化一個代表簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // 取得投影片的主要序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 取得主要序列的第一個效果。
    IEffect effect = sequence[0];

    // 將效果的 TriggerType 變更為點擊時開始
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 變更效果持續時間
    effect.Timing.Duration = 3f;

    // 變更效果的 TriggerDelayTime
    effect.Timing.TriggerDelayTime = 0.5f;

    // 如果效果的 Repeat 值為「none」
    if (effect.Timing.RepeatCount == 1f)
    {
        // 將效果 Repeat 變更為「直到下一次點擊」
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 將效果 Repeat 變更為「直到投影片結束」
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 開啟效果的 Rewind
        effect.Timing.Rewind = true;
    
    // 將 PPTX 檔案儲存至磁碟
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，讓您在動畫效果中處理音效：

- [IEffect.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/stopprevioussound/)  

### **新增動畫效果音效**

以下 C# 程式碼示範如何為動畫效果新增音效，並在下一個效果開始時停止該音效：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// 新增音訊至簡報的音訊集合
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 取得投影片的主要序列。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 取得主要序列的第一個效果
	IEffect firstEffect = sequence[0];

	// 檢查該效果是否為「無音效」
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 為第一個效果加入音效
		firstEffect.Sound = effectSound;
	}

	// 取得投影片的第一個互動序列。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 設定效果的「停止先前音效」旗標
	interactiveSequence[0].StopPreviousSound = true;

	// 將 PPTX 檔案寫入磁碟
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 取得主要的效果序列。  
4. 擷取嵌入於每個動畫效果中的 [Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/sound/) 。  

以下 C# 程式碼示範如何擷取嵌入於動畫效果中的音效：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// 實例化一個代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得投影片的主要序列。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // 將效果音效提取為位元組陣列
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **動畫結束後**

Aspose.Slides for .NET 允許您變更動畫效果的 After animation（結束後）屬性。  

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉選單對應以下屬性：

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/afteranimationtype/) 屬性，用於描述 After animation 類型：  
  * PowerPoint **More Colors** 對應 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型；  
  * PowerPoint **Don't Dim** 項目對應 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型（預設的 After animation 類型）；  
  * PowerPoint **Hide After Animation** 項目對應 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型；  
  * PowerPoint **Hide on Next Mouse Click** 項目對應 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型；  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/afteranimationcolor/) 屬性，用於定義 After animation 的顏色格式。此屬性與 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型共同作用。如將類型變更為其他，則會清除 After animation 的顏色。  

以下 C# 程式碼示範如何變更 After animation 效果：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 實例化一個代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 將後置動畫類型變更為 Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // 設定後置動畫暗淡顏色
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // 將 PPTX 檔案寫入磁碟
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **動畫文字**

Aspose.Slides 提供以下屬性，讓您處理動畫效果的 *Animate text* 區塊：

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/animatetexttype/) 用於描述效果的文字動畫類型。圖形文字可透過以下方式動畫化：  
  - 同時播放 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animatetexttype/) 類型)  
  - 逐詞 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animatetexttype/) 類型)  
  - 逐字 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animatetexttype/) 類型)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 用於設定動畫文字部份（詞或字）之間的延遲。正值表示效果持續時間的百分比，負值表示以秒為單位的延遲。  

以下說明如何變更 Effect Animate text（效果文字動畫）屬性：

1. [Apply](#apply-animation-to-shape) 或取得動畫效果。  
2. 將 [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itextanimation/buildtype/) 屬性設定為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype/) 值，以關閉 *By Paragraphs* 動畫模式。  
3. 為 [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/animatetexttype/) 與 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 屬性設定新值。  
4. 儲存已修改的 PPTX 檔案。  

以下 C# 程式碼示範此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 實例化一個代表簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 將效果的文字動畫類型變更為「作為單一物件」
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 將效果的動畫文字類型變更為「逐字」
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 設定詞與詞之間的延遲為動畫持續時間的 20%
    firstEffect.DelayBetweenTextParts = 20f;

    // 將 PPTX 檔案寫入磁碟
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

### 如何確保在將簡報發佈至網路時保留動畫？

[Export to HTML5](/slides/zh-hant/net/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animateshapes/) 與 [transition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animatetransitions/) 動畫的[選項](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/)。純 HTML 無法播放投影片動畫，而 HTML5 能播放。

### 改變圖形的 Z 軸順序（層次順序）如何影響動畫？

動畫與繪圖順序是獨立的：效果控制出現/消失的時間與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/zorderposition/) 決定哪個圖形覆蓋哪個。最終的可視結果由兩者的組合決定。（這是一般 PowerPoint 的行為；Aspose.Slides 的效果與圖形模型遵循相同邏輯。）

### 將特定動畫效果轉換為影片時是否有限制？

一般而言，[動畫受到支援](/slides/zh-hant/net/convert-powerpoint-to-video/)，但在少數情況或特定效果上可能會有不同的呈現方式。建議使用您實際的效果與相應的函式庫版本進行測試。