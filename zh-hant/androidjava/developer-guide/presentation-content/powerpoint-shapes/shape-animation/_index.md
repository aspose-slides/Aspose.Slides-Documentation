---
title: 在 Android 上於簡報中套用圖形動畫
linktitle: 圖形動畫
type: docs
weight: 60
url: /zh-hant/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中建立與自訂圖形動畫。脫穎而出！"
---
## **簡介**

動畫是可套用於文字、圖片、圖形或[圖表](https://docs.aspose.com/slides/zh-hant/androidjava/animated-charts/)的視覺效果。它們為簡報或其組成部分賦予活力。

## **為何在簡報中使用動畫？**

* 控制資訊流向  
* 強調重點  
* 提升觀眾的興趣或參與度  
* 使內容更易閱讀、吸收或處理  
* 吸引讀者或觀看者注意簡報中的重要部分  

PowerPoint 提供了許多動畫與動畫效果的選項與工具，涵蓋**入口**、**退出**、**強調**和**移動路徑**等類別。

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空間下提供您處理動畫所需的類別與類型，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttype) 列舉中提供超過 **150 個動畫效果**。這些效果本質上與 PowerPoint 中使用的效果相同（或等效）。

## **將動畫套用至文字方塊**

Aspose.Slides for Android via Java 允許您將動畫套用於圖形中的文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape)。  
4. 將文字加入 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)。  
5. 取得主要的效果序列。  
6. 為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape) 新增動畫效果。  
7. 將 `TextAnimation.BuildType` 屬性設定為 `BuildType` 列舉中的值。  
8. 將簡報寫入磁碟，以 PPTX 檔案儲存。  

以下 Java 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs* 值：

```java
// 實例化一個表示簡報檔案的簡報類別。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增帶文字的 AutoShape
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // 取得投影片的主要序列。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // 為圖形新增 Fade 動畫效果
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 依第一層段落為圖形文字添加動畫
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // 將 PPTX 檔案儲存到磁碟
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 
除了將動畫套用於文字之外，您還可以將動畫套用至單一[段落](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph)。請參閱[**動畫文字**](/slides/zh-hant/androidjava/animated-text/)。
{{% /alert %}} 

## **將動畫套用至圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe)。  
4. 取得主要的效果序列。  
5. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe) 新增動畫效果。  
6. 將簡報寫入磁碟，以 PPTX 檔案儲存。  

以下 Java 程式碼示範如何將 `Fly` 效果套用至圖片框：

```java
// 實例化一個表示簡報檔案的簡報類別。
Presentation pres = new Presentation();
try {
    // 載入要加入簡報影像集合的圖片
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 將圖片框加入投影片
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // 取得投影片的主要序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 為圖片框新增從左側飛入的動畫效果
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 將 PPTX 檔案儲存到磁碟
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **將動畫套用至圖形**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape)。  
4. 加入一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape)（當點擊此物件時，動畫會播放）。  
5. 為斜角形狀建立效果序列。  
6. 建立自訂的 `UserPath`。  
7. 新增指令以移動至 `UserPath`。  
8. 將簡報寫入磁碟，以 PPTX 檔案儲存。  

以下 Java 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至圖形：

```java
// 實例化一個表示 PPTX 檔案的 Presentation 類別。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 為現有圖形從頭建立 PathFootball 效果。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // 新增 PathFootBall 動畫效果
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 建立某種「按鈕」。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 為此按鈕建立效果序列。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // 建立自訂使用者路徑。物件僅在按鈕被點擊後移動。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 加入移動指令，因為建立的路徑是空的。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得套用於圖形的動畫效果**

以下範例說明如何使用 [ISequence](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/) 介面的 `getEffectsByShape` 方法，以取得套用於圖形的所有動畫效果。

**範例 1：取得普通投影片上圖形的動畫效果**

先前您已學習如何在 PowerPoint 簡報中為圖形新增動畫效果。以下範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一張普通投影片上第一個圖形所套用的效果。

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 取得投影片的主要動畫序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 取得第一張投影片上的第一個圖形。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 取得套用於圖形的動畫效果。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**範例 2：取得所有動畫效果，包括從占位符繼承的效果**

如果普通投影片上的圖形具有位於佈局投影片和/或母片投影片上的占位符，且這些占位符已加入動畫效果，則在投影片放映期間，該圖形的所有效果都會播放，包括繼承自占位符的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中只有一張投影片，僅包含一個文字為「Made with Aspose.Slides」的頁腳圖形，且已套用 **Random Bars** 效果。

![投影片圖形動畫效果](slide-shape-animation.png)

再假設在 **layout** 投影片的頁腳占位符上套用 **Split** 效果。

![佈局圖形動畫效果](layout-shape-animation.png)

最後，在 **master** 投影片的頁腳占位符上套用 **Fly In** 效果。

![母片圖形動畫效果](master-shape-animation.png)

以下範例程式碼示範如何使用 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 介面的 `getBasePlaceholder` 方法，存取圖形占位符，並取得套用於頁腳圖形的動畫效果，包括來自佈局與母片投影片上占位符的繼承效果。

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// 取得普通投影片上圖形的動畫效果。
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// 取得版面投影片上占位符的動畫效果。
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// 取得母片投影片上占位符的動畫效果。
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
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

Aspose.Slides for Android via Java 允許您變更動畫效果的 Timing（時間）屬性。

以下是 Microsoft PowerPoint 中的動畫 Timing 面板：

![範例1 圖形動畫](shape-animation.png)

以下是 PowerPoint Timing 與 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IEffect#getTiming--) 屬性之對應關係：

- PowerPoint Timing **Start** 下拉式清單對應至 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITiming#getTriggerType--) 屬性。  
- PowerPoint Timing **Duration** 對應至 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITiming#getDuration--) 屬性。動畫的持續時間（以秒為單位）是動畫完成一個循環所需的總時間。  
- PowerPoint Timing **Delay** 對應至 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) 屬性。  

以下示範如何變更 Effect Timing（效果時間）屬性：

1. [套用](#apply-animation-to-shape) 或取得動畫效果。  
2. 為您需要的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IEffect#getTiming--) 屬性設定新值。  
3. 儲存已修改的 PPTX 檔案。  

以下 Java 程式碼示範此操作：

```java
// 實例化一個表示簡報檔案的簡報類別。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 取得投影片的主要序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 取得主要序列的第一個效果。
    IEffect effect = sequence.get_Item(0);

    // 將效果的 TriggerType 更改為點擊開始
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 更改效果的持續時間
    effect.getTiming().setDuration(3f);

    // 更改效果的 TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // 將 PPTX 檔案儲存到磁碟
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，以便您在動畫效果中使用音效：

- [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **新增動畫效果音效**

以下 Java 程式碼示範如何新增動畫效果音效，並在下一個效果開始時停止它：

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 將音訊新增至簡報的音訊集合
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得投影片的主要序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 取得主要序列的第一個效果
    IEffect firstEffect = sequence.get_Item(0);

    // 檢查效果是否為「無聲音」
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 為第一個效果新增聲音
        firstEffect.setSound(effectSound);
    }

    // 取得投影片的第一個互動序列。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 設定效果「停止先前聲音」旗標
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 取得主要的效果序列。  
4. 擷取每個動畫效果所嵌入的 [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。  

以下 Java 程式碼示範如何擷取嵌入於動畫效果中的音效：

```java
// 實例化一個表示簡報檔案的簡報類別。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得投影片的主要序列。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 以位元組陣列擷取效果聲音
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **動畫結束後**

Aspose.Slides for Android via Java 允許您變更動畫效果的 After animation（結束後）屬性。

以下是 Microsoft PowerPoint 中的動畫效果面板與擴充功能表：

![範例1 動畫結束後](shape-after-animation.png)

PowerPoint 效果 **After animation** 下拉式清單對應以下屬性：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 屬性，用於描述 After animation（結束後）類型：  
  * PowerPoint **More Colors** 對應至 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#Color) 類型；  
  * PowerPoint **Don't Dim** 項目對應至 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) 類型（預設的結束後類型）；  
  * PowerPoint **Hide After Animation** 項目對應至 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 類型；  
  * PowerPoint **Hide on Next Mouse Click** 項目對應至 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 類型；  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 屬性，用於定義結束後的顏色格式。此屬性與 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#Color) 類型共同運作。若將類型變更為其他，則結束後的顏色將被清除。  

以下 Java 程式碼示範如何變更結束後的動畫效果：

```java
// 實例化一個表示簡報檔案的簡報類別
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 將結束後的動畫類型更改為顏色
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // 設定結束後動畫的暗淡顏色
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **動畫文字**

Aspose.Slides 提供以下屬性，以便您操作動畫效果的 *Animate text*（動畫文字）區塊：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) 用於描述動畫文字的類型。圖形文字可以以下列方式呈現動畫：  
  * 同時全部呈現（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) 類型）  
  * 逐字（[AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/animatetexttype/#ByWord) 類型）  
  * 逐字元（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/animatetexttype/#ByLetter) 類型）  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 用於設定動畫文字片段（字或字元）之間的延遲。正值表示效果持續時間的百分比，負值則表示以秒為單位的延遲。  

以下示範如何變更 Effect Animate text（動畫文字）屬性：

1. [套用](#apply-animation-to-shape) 或取得動畫效果。  
2. 將 [setBuildType(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) 屬性設定為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/buildtype/#AsOneObject) 值，以關閉 *By Paragraphs*（依段落）動畫模式。  
3. 為 [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) 與 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 屬性設定新值。  
4. 儲存已修改的 PPTX 檔案。  

以下 Java 程式碼示範此操作：

```java
// 實例化一個表示簡報檔案的簡報類別。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 將效果的文字動畫類型更改為「As One Object」
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 將效果的動畫文字類型更改為「By word」
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 設定單字之間的延遲為效果持續時間的 20%
    firstEffect.setDelayBetweenTextParts(20f);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**如何確保在將簡報發布到 Web 時保留動畫？**  
[Export to HTML5](/slides/zh-hant/androidjava/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [transition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 動畫的 [options](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/) 設定。純 HTML 無法播放投影片動畫，而 HTML5 則可以。

**變更圖形的 Z 軸順序（圖層順序）會如何影響動畫？**  
動畫與繪製順序互相獨立：效果控制出現/消失的時間與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getZOrderPosition--) 決定哪個圖形覆蓋哪個。最終可見結果由兩者的組合決定。（這是 PowerPoint 的一般行為；Aspose.Slides 的效果與圖形模型遵循相同邏輯。）

**將某些動畫效果轉換為影片時是否存在限制？**  
一般而言，[動畫是受支援的](/slides/zh-hant/androidjava/convert-powerpoint-to-video/)，但在少數情況或特定效果下可能會有不同的呈現方式。建議使用您所使用的效果以及相應的函式庫版本進行測試。