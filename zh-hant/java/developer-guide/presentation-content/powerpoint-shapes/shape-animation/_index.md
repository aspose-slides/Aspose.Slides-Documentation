---
title: 使用 Java 在簡報中套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/java/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
- 新增動畫
- 取得動畫
- 抽取動畫
- 新增效果
- 取得效果
- 抽取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "發現如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立與自訂形狀動畫。脫穎而出！"
---
## **介紹**

動畫是可以套用於文字、圖片、圖形或[圖表](https://docs.aspose.com/slides/zh-hant/java/animated-charts/)的視覺效果。它們為簡報或其組件注入生命。

## **為什麼在簡報中使用動畫？**

使用動畫，您可以

* 控制資訊流向
* 強調重要重點
* 增加觀眾的興趣或參與度
* 讓內容更容易閱讀、吸收或處理
* 吸引讀者或觀眾注意簡報中的重要部份

PowerPoint 在 **入口**、**退出**、**強調** 與 **路徑動畫** 四大類別中提供多種動畫與動畫效果選項與工具。

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空間下提供您處理動畫所需的類別與型別，
* Aspose.Slides 於 [EffectType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttype) 列舉中提供超過 **150 種動畫效果**。這些效果本質上與 PowerPoint 中使用的效果相同（或等價）。

## **將動畫套用至文字方塊**

Aspose.Slides for Java 允許您對圖形中的文字套用動畫。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
2. 透過索引取得投影片參考。
3. 新增 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape)。
4. 新增文字至 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)。
5. 取得主要效果序列。
6. 為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape) 新增動畫效果。
7. 將 `TextAnimation.BuildType` 屬性設定為 `BuildType` 列舉中的值。
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 Java 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs*：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增帶有文字的 AutoShape
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // 取得投影片的主要序列。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // 為形狀新增 Fade 動畫效果
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 依第一層段落動畫化形狀文字
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // 將 PPTX 檔案儲存至磁碟
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

除了將動畫套用至文字外，您亦可將動畫套用至單一[Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph)。請參閱[**Animated Text**](/slides/zh-hant/java/animated-text/)。

{{% /alert %}} 

## **將動畫套用至 PictureFrame**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
2. 透過索引取得投影片參考。
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe)。
4. 取得主要效果序列。
5. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe) 新增動畫效果。
6. 將簡報寫入磁碟為 PPTX 檔案。

以下 Java 程式碼示範如何將 `Fly` 效果套用至圖片框：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation();
try {
    // 載入將加入簡報影像集合的圖片
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

    // 為圖片框新增從左側飛入的動畫效果
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 將 PPTX 檔案儲存至磁碟
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **將動畫套用至 Shape**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
2. 透過索引取得投影片參考。
3. 新增 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape)。
4. 新增一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape)（當此物件被點擊時，即會播放動畫）。
5. 為斜角形建立效果序列。
6. 建立自訂 `UserPath`。
7. 為 `UserPath` 新增移動指令。
8. 將簡報寫入磁碟為 PPTX 檔案。

以下 Java 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至形狀：

```java
// Instantiates a Presentation class that represents a PPTX file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Creates PathFootball effect for existing shape from scratch.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Adds the PathFootBall animation effect
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creates some kind of "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creates a sequence of effects for this button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Creates a custom user path. Our object will be moved only after the button is clicked.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Adds commands for moving since created path is empty.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得套用於 Shape 的動畫效果**

以下範例說明如何使用 [ISequence](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/) 介面的 `getEffectsByShape` 方法，取得套用於某個形狀的全部動畫效果。

**範例 1：取得套用於普通投影片上形狀的動畫效果**

先前您已了解如何在 PowerPoint 簡報中為形狀添加動畫效果。以下範例程式碼示範如何取得投影片 `AnimExample_out.pptx` 中第一張普通投影片第一個形狀的效果。

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 取得投影片的主要動畫序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 取得第一張投影片上的第一個形狀。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 取得套用於該形狀的動畫效果。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**範例 2：取得所有動畫效果，包括從佔位符繼承的效果**

若普通投影片上的形狀具有來自版面投影片或母片投影片的佔位符，且這些佔位符已添加動畫效果，則在投影片放映期間，該形狀會播放所有效果，包括從佔位符繼承的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中唯一一張投影片只包含一個頁腳形狀，文字為「Made with Aspose.Slides」，且已套用 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假設在 **版面** 投影片的頁腳佔位符上已套用 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最後，在 **母片** 投影片的頁腳佔位符上套用 **Fly In** 效果。

![Master shape animation effect](master-shape-animation.png)

以下範例程式碼示範如何使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面的 `getBasePlaceholder` 方法，存取形狀佔位符，並取得套用於頁腳形狀的動畫效果，包含從版面與母片投影片佔位符繼承的效果。

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
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

輸出：
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **變更動畫效果的時間屬性**

Aspose.Slides for Java 允許您變更動畫效果的時間屬性。

以下為 Microsoft PowerPoint 中的動畫時間面板：

![example1_image](shape-animation.png)

PowerPoint 時間與 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IEffect#getTiming--) 屬性之對應關係如下：

- PowerPoint 時間 **Start** 下拉清單對應 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITiming#getTriggerType--) 屬性。 
- PowerPoint 時間 **Duration** 對應 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITiming#getDuration--) 屬性。動畫的持續時間（以秒為單位）為動畫完成一次循環所需的總時間。 
- PowerPoint 時間 **Delay** 對應 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITiming#getTriggerDelayTime--) 屬性。 

以下說明如何變更 Effect Timing 屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。
2. 為需要變更的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IEffect#getTiming--) 屬性設定新值。 
3. 儲存修改後的 PPTX 檔案。

以下 Java 程式碼示範此操作：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 取得投影片的主要序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 取得主要序列的第一個效果。
    IEffect effect = sequence.get_Item(0);

    // 將效果的 TriggerType 變更為點擊時開始
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 變更效果的持續時間
    effect.getTiming().setDuration(3f);

    // 變更效果的 TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // 將 PPTX 檔案儲存至磁碟
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，讓您在動畫效果中處理音效：

- [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **新增動畫效果音效**

以下 Java 程式碼示範如何新增動畫效果音效，並在下一個效果開始時停止該音效：

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 新增音訊至簡報的音訊集合
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得投影片的主要序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 取得主要序列的第一個效果。
    IEffect firstEffect = sequence.get_Item(0);

    // 檢查效果是否為「No Sound」(無音效)
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 為第一個效果新增音效
        firstEffect.setSound(effectSound);
    }

    // 取得投影片的第一個互動序列。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 設定效果的「停止前一個音效」旗標
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
2. 透過索引取得投影片參考。 
3. 取得主要效果序列。 
4. 擷取每個動畫效果所嵌入的 [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。

以下 Java 程式碼示範如何擷取嵌入於動畫效果中的音效：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得投影片的主要序列。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 將效果音訊提取為位元組陣列
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **動畫結束後的設定**

Aspose.Slides for Java 允許您變更動畫效果的「動畫結束後」屬性。

以下為 Microsoft PowerPoint 中的動畫效果面板與延伸功能表：

![example1_image](shape-after-animation.png)

PowerPoint 的 **After animation** 下拉清單對應以下屬性：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 屬性描述動畫結束後的類型：
  * PowerPoint **More Colors** 對應 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#Color)；
  * PowerPoint **Don't Dim** 對應 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#DoNotDim)（預設類型）；
  * PowerPoint **Hide After Animation** 對應 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation)；
  * PowerPoint **Hide on Next Mouse Click** 對應 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick)；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 屬性定義動畫結束後的顏色格式。此屬性僅於 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#Color) 類型下有效。若將類型切換為其他，則會清除動畫結束後的顏色。

以下 Java 程式碼示範如何變更動畫結束後的設定：

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 將動畫結束後的類型變更為 Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // 設定動畫結束後的暗淡顏色
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **動畫文字**

Aspose.Slides 提供以下屬性，讓您操作動畫效果的 *Animate text* 區塊：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 描述動畫文字的類型。形狀文字可依以下方式動畫化：
  - 一次全部顯示（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animatetexttype/#AllAtOnce)）
  - 逐字（[AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animatetexttype/#ByWord)）
  - 逐字母（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animatetexttype/#ByLetter)）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 設定動畫文字各部份（字或字母）之間的延遲。正值表示效果持續時間的百分比，負值則以秒為單位。

以下說明如何變更 Effect Animate text 屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。
2. 將 [setBuildType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextanimation/#setBuildType-int-) 屬性設定為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/buildtype/#AsOneObject) 以關閉 *By Paragraphs* 動畫模式。
3. 為 [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 與 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 設定新值。
4. 儲存修改後的 PPTX 檔案。

以下 Java 程式碼示範此操作：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 取得主要序列的第一個效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 將效果的文字動畫類型變更為「As One Object」
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 將效果的動畫文字類型變更為「By word」
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 設定字詞之間的延遲為效果持續時間的 20%
    firstEffect.setDelayBetweenTextParts(20f);

    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**如何確保在將簡報發佈至網路時動畫不會遺失？**

[匯出為 HTML5](/slides/zh-hant/java/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [transition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 動畫的 [options](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/)。純 HTML 無法播放投影片動畫，而 HTML5 能夠播放。

**變更形狀的 Z 順序（圖層順序）會如何影響動畫？**

動畫與繪製順序相互獨立：效果控制出現/消失的時機與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getZOrderPosition--) 決定哪個物件遮蓋哪個。最終呈現結果是兩者結合的結果。（這是 PowerPoint 的一般行為，Aspose.Slides 的效果與形狀模型亦遵循相同邏輯。）

**將某些動畫轉換為影片時是否有限制？**

一般而言，[動畫受支援](/slides/zh-hant/java/convert-powerpoint-to-video/)，但個別稀有情況或特定效果可能會有不同的呈現方式。建議以實際使用的效果與所使用的函式庫版本進行測試。