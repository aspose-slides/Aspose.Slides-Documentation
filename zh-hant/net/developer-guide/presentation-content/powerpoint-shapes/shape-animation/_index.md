---
title: 在 .NET 簡報中套用形狀動畫
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
description: "探索如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立與自訂形狀動畫。脫穎而出！"
---
## **簡介**

動畫是可套用於文字、圖像、形狀或[圖表](/slides/zh-hant/net/animated-charts/)的視覺效果。它們為簡報或其組成部分注入活力。

## **為何在簡報中使用動畫？**

使用動畫，您可以

* 控制資訊的流動
* 強調重要重點
* 增加觀眾的興趣或參與度
* 讓內容更易閱讀、吸收或處理
* 吸引讀者或觀眾的注意力至簡報中的重要部分

PowerPoint 在 **進場**、**退出**、**強調** 與 **動作路徑** 類別中提供了許多動畫選項與工具。

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/) 命名空間下提供您需要的類別與型別，以操作動畫，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype) 列舉中提供超過 **150 種動畫效果**。這些效果本質上與 PowerPoint 使用的效果相同（或等價）。

## **將動畫套用到文字方塊**

Aspose.Slides for .NET 允許您將動畫套用至形狀中的文字。

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的執行個體。
2. 透過索引取得投影片的參考。
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)。
4. 為 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/properties/textframe) 加入文字。
5. 取得主要的效果序列。
6. 為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape) 加入動畫效果。
7. 將 [TextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/textanimation/properties/buildtype) 屬性設定為來自 [BuildType 列舉](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype) 的值。
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 C# 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs*：

```c#
// 實例化表示簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // 新增含文字的 AutoShape
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // 取得投影片的主要序列。
    ISequence sequence = sld.Timeline.MainSequence;

    // 為形狀加入 Fade 動畫效果
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 依第一層段落動畫化形狀文字
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // 將 PPTX 檔案儲存至磁碟
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

除了將動畫套用到文字，您也可以將動畫套用到單一 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph)。請參閱[**動畫文字**](/slides/zh-hant/net/animated-text/)。

{{% /alert %}} 

## **將動畫套用到 PictureFrame**

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的執行個體。
2. 透過索引取得投影片的參考。
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe)。
5. 取得主要的效果序列。
6. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe) 加入動畫效果。
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 C# 程式碼示範如何將 `Fly` 效果套用至圖片框：

```c#
// 實例化表示簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation())
{
    // 載入要加入簡報影像集合的圖片
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 新增圖片框至投影片
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 取得投影片的主要序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 為圖片框加入從左側飛入的動畫效果
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 將 PPTX 檔案儲存至磁碟
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **將動畫套用到形狀**

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的執行個體。
2. 透過索引取得投影片的參考。
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)。
4. 新增一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)（當此物件被點擊時，動畫會播放）。
5. 為斜角形狀建立效果序列。
6. 建立自訂的 `UserPath`。
7. 為 `UserPath` 加入移動指令。
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 C# 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至形狀：

```c#
// 實例化表示簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 為現有形狀從頭建立 PathFootball 效果。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // 加入 PathFootBall 動畫效果。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 建立類似「按鈕」的物件。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 為按鈕建立效果序列。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // 建立自訂使用者路徑。物件僅在按鈕被點擊後才會移動。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 為移動加入指令，因為已建立的路徑為空。
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

## **取得套用於形狀的動畫效果**

以下範例說明如何使用 [ISequence](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/) 介面的 `GetEffectsByShape` 方法，取得套用於形狀的所有動畫效果。

**範例 1：取得一般投影片上形狀的動畫效果**

先前您已學會如何在 PowerPoint 簡報中為形狀新增動畫效果。以下示範程式碼說明如何取得簡報 `AnimExample_out.pptx` 中第一張普通投影片上第一個形狀所套用的效果。

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // 獲取投影片的主要動畫序列。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 獲取第一張投影片上的第一個形狀。
    IShape shape = firstSlide.Shapes[0];

    // 獲取套用於形狀的動畫效果。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**範例 2：取得所有動畫效果，包括來自版位的繼承效果**

如果普通投影片上的形狀具有位於版面配置投影片及/或母片投影片的版位，且這些版位已加入動畫效果，則在投影片放映時，該形狀將播放所有效果，包含從版位繼承的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中只有一張投影片，該投影片僅包含一個頁腳形狀，文字為「Made with Aspose.Slides」，且對該形狀套用了 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假設在 **版面配置** 投影片的頁腳版位上套用了 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最後，在 **母片** 投影片的頁腳版位上套用了 **Fly In** 效果。

![Master shape animation effect](master-shape-animation.png)

以下示範程式碼說明如何使用 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面的 `GetBasePlaceholder` 方法，存取形狀版位並取得套用於頁腳形狀的動畫效果，包含來自版面配置與母片版位的繼承效果。

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得普通投影片上形狀的動畫效果。
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // 取得版面配置投影片上版位的動畫效果。
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // 取得母片投影片上版位的動畫效果。
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

輸出：
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **變更動畫效果的時序屬性**

Aspose.Slides for .NET 允許您變更動畫效果的時序屬性。

以下是 Microsoft PowerPoint 中的「動畫時序」窗格與延伸功能表：

![example1_image](shape-animation.png)

PowerPoint 時序與 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/properties/timing) 屬性之對應關係如下：
- PowerPoint 時序 **Start** 下拉清單對應 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/properties/triggertype) 屬性。
- PowerPoint 時序 **Duration** 對應 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/properties/duration) 屬性。動畫的持續時間（秒）為動畫完成一個週期所需的總時間。
- PowerPoint 時序 **Delay** 對應 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 屬性。
- PowerPoint 時序 **Repeat** 下拉清單對應以下屬性：
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount) 屬性，描述效果重複的 **次數**；
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide) 旗標，指定是否在投影片結束前持續重複；
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick) 旗標，指定是否在下一次點擊前持續重複。
- PowerPoint 時序 **Rewind when done playing** 勾選框對應 [Effect.Timing.Rewind](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/rewind/) 屬性。

變更 Effect Timing 屬性的步驟如下：

1. [套用](#apply-animation-to-shape)或取得動畫效果。
2. 為您需要的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/properties/timing) 屬性設定新值。
3. 儲存修改後的 PPTX 檔案。

以下 C# 程式碼示範此操作：

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Gets the main sequence of the slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Gets the first effect of main sequence.
    IEffect effect = sequence[0];

    // Changes effect TriggerType to start on click
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Changes effect Duration
    effect.Timing.Duration = 3f;

    // Changes effect TriggerDelayTime
    effect.Timing.TriggerDelayTime = 0.5f;

    // If the effect Repeat value is "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Changes effect Repeat to "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Changes effect Repeat to "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Turns the effect Rewind on
        effect.Timing.Rewind = true;
    
    // Saves the PPTX file to disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，以讓您在動畫效果中使用音效：
- [IEffect.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/sound/)
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/stopprevioussound/)

### **新增動畫效果音效**

以下 C# 程式碼示範如何新增動畫效果音效，並在下一個效果開始時停止該音效：

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// 將音訊加入簡報的音訊集合
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 取得投影片的主要序列
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 取得主要序列的第一個效果
	IEffect firstEffect = sequence[0];

	// 檢查效果是否為「無音效」
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 為第一個效果加入音效
		firstEffect.Sound = effectSound;
	}

	// 取得投影片的第一個互動序列
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 設定效果的「停止先前音效」旗標
	interactiveSequence[0].StopPreviousSound = true;

	// 將 PPTX 檔案寫入磁碟
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
2. 透過索引取得投影片的參考。
3. 取得主要的效果序列。
4. 擷取嵌入於每個動畫效果的 [Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effect/sound/) 。

以下 C# 程式碼示範如何擷取嵌入於動畫效果中的音效：

```c#
// 實例化表示簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得投影片的主要序列。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // 以位元組陣列形式擷取效果音效
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **動畫結束後的設定**

Aspose.Slides for .NET 允許您變更動畫效果的「After animation」屬性。

以下是 Microsoft PowerPoint 中的「動畫效果」窗格與延伸功能表：

![example1_image](shape-after-animation.png)

PowerPoint 的 **After animation** 下拉清單對應以下屬性：

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/afteranimationtype/) 屬性，描述動畫結束後的類型：
  * PowerPoint **More Colors** 對應 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型；
  * PowerPoint **Don't Dim** 對應 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型（預設）；
  * PowerPoint **Hide After Animation** 對應 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型；
  * PowerPoint **Hide on Next Mouse Click** 對應 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型；
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/afteranimationcolor/) 屬性定義動畫結束後的顏色格式。此屬性與 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 類型共同作用。若將類型變更為其他，動畫結束顏色將被清除。

以下 C# 程式碼示範如何變更動畫結束效果：

```c#
// 實例化表示簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 將 AfterAnimation 類型變更為 Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // 設定 AfterAnimation 的暗淡顏色
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // 將 PPTX 檔案寫入磁碟
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **動畫文字**

Aspose.Slides 提供以下屬性，以讓您操作動畫效果的 *Animate text* 區塊：

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/animatetexttype/) 描述文字動畫的類型。形狀文字可以以以下方式動畫化：
  - 一次全部 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animatetexttype/) 類型)
  - 逐字 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animatetexttype/) 類型)
  - 逐字元 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animatetexttype/) 類型)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 設定動畫文字部份（字或字元）之間的延遲。正值表示效果持續時間的百分比，負值則表示以秒為單位的延遲。

變更 Effect Animate text 屬性的步驟如下：

1. [套用](#apply-animation-to-shape)或取得動畫效果。
2. 將 [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itextanimation/buildtype/) 屬性設定為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype/) 以關閉 *By Paragraphs* 模式。
3. 為 [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/animatetexttype/) 與 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 設定新值。
4. 儲存修改後的 PPTX 檔案。

以下 C# 程式碼示範此操作：

```c#
// 實例化表示簡報檔案的 Presentation 類別。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 將效果的文字動畫類型變更為「As One Object」
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 將效果的動畫文字類型變更為「By word」
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 設定字與字之間的延遲為效果持續時間的 20%
    firstEffect.DelayBetweenTextParts = 20f;

    // 將 PPTX 檔案寫入磁碟
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**如何確保在將簡報發佈至網路時保留動畫？**

使用 [Export to HTML5](/slides/zh-hant/net/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animateshapes/) 與 [transition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animatetransitions/) 動畫的[選項](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/)。純 HTML 不會播放投影片動畫，而 HTML5 則會。

**變更形狀的 z-order（圖層順序）會如何影響動畫？**

動畫與繪製順序互相獨立：效果控制出現/消失的時機與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/zorderposition/) 決定哪個覆蓋哪個。最終可見結果由兩者的組合決定。（此為 PowerPoint 的一般行為，Aspose.Slides 的效果與形狀模型遵循相同邏輯。）

**在將某些動畫效果轉換為影片時是否有限制？**

一般而言，[動畫受支援](/slides/zh-hant/net/convert-powerpoint-to-video/)，但少數情況或特定效果可能會以不同方式呈現。建議使用您所使用的效果與當前函式庫版本進行測試。