---
title: 在 Java 中於簡報套用圖形動畫
linktitle: 圖形動畫
type: docs
weight: 60
url: /zh-hant/java/shape-animation/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立與自訂圖形動畫。脫穎而出！"
---
## **簡介**

動畫是可套用於文字、影像、圖形或[圖表](https://docs.aspose.com/slides/zh-hant/java/animated-charts/)的視覺效果。它們為簡報或其組成元素注入生命。

## **為何在簡報中使用動畫？**

* 控制資訊的流向
* 強調重要重點
* 增加觀眾的興趣或參與度
* 讓內容更易閱讀、吸收或處理
* 吸引讀者或觀眾注意簡報中的重要部分

PowerPoint 提供許多選項與工具，以在**進入**、**退出**、**強調**和**移動路徑**類別中設定動畫與動畫效果。

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空間下提供您需要處理動畫的類別與型別，
* Aspose.Slides 在[EffectType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttype) 列舉中提供超過**150 個動畫效果**。這些效果基本上與 PowerPoint 中使用的效果相同（或等效）。

## **套用動畫至文字方塊**

Aspose.Slides for Java 允許您對形狀中的文字套用動畫。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片參考。
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape)。
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) 新增文字。
5. 取得主要的效果序列。
6. 為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape) 新增動畫效果。
7. 設定 `TextAnimation.BuildType` 屬性為 `BuildType` 列舉中的值。
8. 將簡報寫入磁碟，儲存為 PPTX 檔。

此 Java 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為*By 1st Level Paragraphs*值：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 類別。
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

    // 依第一層段落為圖形文字設定動畫
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // 將 PPTX 檔案儲存至磁碟
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

除了將動畫套用至文字之外，您還可以將動畫套用至單一[Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph)。參見[**動畫文字**](/slides/zh-hant/java/animated-text/).

{{% /alert %}} 

## **套用動畫至圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片參考。
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe)。
4. 取得主要的效果序列。
5. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe) 新增動畫效果。
6. 將簡報寫入磁碟，儲存為 PPTX 檔。

此 Java 程式碼示範如何將 `Fly` 效果套用至圖片框：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation();
try {
    // 載入要加入簡報影像集合的影像
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 新增圖片框至投影片
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // 取得投影片的主要序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 為圖片框新增從左側 Fly 動畫效果
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 將 PPTX 檔案儲存至磁碟
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **套用動畫至圖形**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片參考。
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape)。
4. 新增一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape)（當此物件被點擊時，動畫會播放）。
5. 為斜角圖形建立效果序列。
6. 建立自訂的 `UserPath`。
7. 新增移動至 `UserPath` 的指令。
8. 將簡報寫入磁碟，儲存為 PPTX 檔。

此 Java 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至圖形：

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// 實例化一個代表 PPTX 檔案的 Presentation 類別。
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

     // 建立自訂使用者路徑。僅在按鈕被點擊後才會移動物件。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 為移動新增指令，因為建立的路徑目前是空的。
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得套用於圖形的動畫效果**

以下範例示範如何使用 [ISequence](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/) 介面的 `getEffectsByShape` 方法，取得套用於圖形的所有動畫效果。

**範例 1：取得常規投影片上圖形套用的動畫效果**

先前您已學習如何在 PowerPoint 簡報中為圖形新增動畫效果。以下範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一張常規投影片的第一個圖形所套用的效果。

```java
import com.aspose.slides.*;

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

如果常規投影片上的圖形具有位於版面配置投影片和/或母片投影片的占位符，且這些占位符已加入動畫效果，則在投影片放映時，該圖形的所有效果都會播放，包括從占位符繼承的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中唯一一張投影片只包含一個頁腳圖形，文字為「Made with Aspose.Slides」，且已套用 **Random Bars** 效果。

![投影片圖形動畫效果](slide-shape-animation.png)

再假設在 **版面配置** 投影片的頁腳占位符上套用了 **Split** 效果。

![版面配置圖形動畫效果](layout-shape-animation.png)

最後，在 **母片** 投影片的頁腳占位符上套用了 **Fly In** 效果。

![母片圖形動畫效果](master-shape-animation.png)

以下範例程式碼示範如何使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面的 `getBasePlaceholder` 方法，存取圖形占位符並取得套用於頁腳圖形的動畫效果，包括來自版面配置與母片投影片的占位符所繼承的效果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// 取得常規投影片上圖形的動畫效果。
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// 取得版面配置投影片上占位符的動畫效果。
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// 取得母片投影片上占位符的動畫效果。
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **變更動畫效果時序屬性**

Aspose.Slides for Java 允許您變更動畫效果的 Timing 屬性。

這是 Microsoft PowerPoint 中的動畫 Timing 面板：

![範例 1 圖像](shape-animation.png)

以下是 PowerPoint Timing 與 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IEffect#getTiming--) 屬性之對應關係：

- PowerPoint Timing **Start** 下拉選單對應 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITiming#getTriggerType--) 屬性。 
- PowerPoint Timing **Duration** 對應 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITiming#getDuration--) 屬性。動畫的持續時間（以秒為單位）是動畫完成一次循環的總時間。 
- PowerPoint Timing **Delay** 對應 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITiming#getTriggerDelayTime--) 屬性。 

以下說明如何變更 Effect Timing 屬性：

1. [套用](#apply-animation-to-shape) 或取得動畫效果。
2. 為您需要的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IEffect#getTiming--) 屬性設定新值。 
3. 儲存已修改的 PPTX 檔。

此 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 取得投影片的主要序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 取得主要序列的第一個效果。
    IEffect effect = sequence.get_Item(0);

    // 將效果的 TriggerType 更改為點擊時開始
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 更改效果的持續時間
    effect.getTiming().setDuration(3f);

    // 更改效果的 TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // 將 PPTX 檔案儲存至磁碟
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，讓您在動畫效果中使用音效：

- [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **新增動畫效果音效**

此 Java 程式碼示範如何為動畫效果新增音效，並在下一個效果開始時停止它：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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
        // 為第一個效果新增音效
        firstEffect.setSound(effectSound);
    }

    // 取得投影片的第一個互動序列。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 設定效果的「停止先前音效」旗標
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片參考。 
3. 取得主要的效果序列。 
4. 擷取每個動畫效果所嵌入的 [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。

此 Java 程式碼示範如何擷取嵌入於動畫效果中的音效：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得投影片的主要序列。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 擷取效果音效的位元組陣列
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **動畫結束後**

Aspose.Slides for Java 允許您變更動畫效果的 After animation 屬性。

這是 Microsoft PowerPoint 中的 Animation Effect 面板及延伸選單：

![範例 1 圖像](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉選單對應以下屬性：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 屬性描述 After animation 類型：
  * PowerPoint **More Colors** 對應 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#Color) 類型；
  * PowerPoint **Don't Dim** 列項對應 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#DoNotDim) 類型（預設的 after animation 類型）；
  * PowerPoint **Hide After Animation** 項目對應 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 類型；
  * PowerPoint **Hide on Next Mouse Click** 項目對應 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 類型；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 屬性定義 after animation 的顏色格式。此屬性與 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#Color) 類型一起使用。如果將類型變更為其他，則 after animation 顏色將被清除。

此 Java 程式碼示範如何變更 after animation 效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 將後動畫類型變更為 Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // 設定後動畫的暗淡顏色
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **文字動畫**

Aspose.Slides 提供以下屬性，讓您使用動畫效果的*Animate text*區塊：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 描述動畫文字的類型。圖形文字可以以以下方式動畫化：
  - 全部一次 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animatetexttype/#AllAtOnce) 類型)
  - 逐字 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animatetexttype/#ByWord) 類型)
  - 逐字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animatetexttype/#ByLetter) 類型)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 設定動畫文字部分（單字或字母）之間的延遲。正值表示效果持續時間的百分比，負值表示以秒為單位的延遲。

以下說明如何變更 Effect Animate text 屬性：

1. [套用](#apply-animation-to-shape) 或取得動畫效果。
2. 設定 [setBuildType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextanimation/#setBuildType-int-) 屬性為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/buildtype/#AsOneObject) 值，以關閉 *By Paragraphs* 動畫模式。
3. 為 [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 與 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 屬性設定新值。
4. 儲存已修改的 PPTX 檔。

此 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 將效果的文字動畫類型變更為「As One Object」
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 將效果的 Animate text 類型變更為「By word」
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 設定單詞之間的延遲為效果持續時間的 20%
    firstEffect.setDelayBetweenTextParts(20f);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

### 如何確保在將簡報發布至 Web 時保留動畫？

[Export to HTML5](/slides/zh-hant/java/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [transition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 動畫的 [options](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/)。純 HTML 無法播放投影片動畫，而 HTML5 可以。

### 更改圖形的 z-order（圖層順序）如何影響動畫？

動畫與繪製順序是獨立的：效果控制顯示/隱藏的時間與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getZOrderPosition--) 決定什麼覆蓋什麼。最終的可見結果取決於兩者的組合。（這是 PowerPoint 的一般行為，Aspose.Slides 的效果與圖形模型遵循相同邏輯。）

### 將動畫轉換為影片時，某些效果是否有限制？

一般而言，支援[動畫](/slides/zh-hant/java/convert-powerpoint-to-video/)，但在罕見情況或特定效果下可能會以不同方式呈現。建議使用您所使用的效果以及相應的函式庫版本進行測試。