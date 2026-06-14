---
title: 在簡報中使用 JavaScript 套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 以及 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中建立與自訂形狀動畫，讓您的簡報脫穎而出！"
---
## **簡介**

動畫是可套用於文字、圖像、形狀或[圖表](/slides/zh-hant/nodejs-java/animated-charts/)的視覺效果。它們為簡報或其組成部分賦予活力。

## **為何在簡報中使用動畫？**

使用動畫，您可以 

* 控制資訊的流向
* 強調重要重點
* 增加觀眾的興趣或參與度
* 讓內容更容易閱讀、吸收或處理
* 吸引讀者或觀眾的注意力至簡報中的重要部分

PowerPoint 提供許多選項與工具，讓您在**進入**、**退出**、**強調**和**移動路徑**類別中設定動畫與動畫效果。 

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空間下提供您使用動畫所需的類別與類型，
* Aspose.Slides 於[EffectType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttype) 列舉中提供超過 **150 種動畫效果**。這些效果實質上與 PowerPoint 中使用的效果相同（或等效）。

## **將動畫套用至文字方塊**

Aspose.Slides for Node.js via Java 允許您將動畫套用至形狀內的文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片參考。
3. 新增一個 `rectangle` [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape)。
4. 使用 [AutoShape.addTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 新增文字。
5. 取得主要效果序列。
6. 為 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape) 新增動畫效果。
7. 使用 `BuildType` 列舉的值呼叫 `TextAnimation.setBuildType` 方法。
8. 將簡報寫入磁碟，以 PPTX 檔案儲存。

以下 JavaScript 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs*：

```javascript
// 實例化一個代表簡報檔案的簡報類別。
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 新增帶有文字的 AutoShape
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // 取得投影片的主要序列。
    var sequence = sld.getTimeline().getMainSequence();
    // 為形狀新增淡入動畫效果
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 依第一層段落為形狀文字設定動畫
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // 將 PPTX 檔案儲存至磁碟
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

除了將動畫套用至文字，您也可以將動畫套用至單一[段落](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph)。請參閱[**動畫文字**](/slides/zh-hant/nodejs-java/animated-text/)。

{{% /alert %}} 

## **將動畫套用至圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片參考。
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe)。
4. 取得主要效果序列。
5. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe) 新增動畫效果。
6. 將簡報寫入磁碟，以 PPTX 檔案儲存。

以下 JavaScript 程式碼示範如何將 `Fly` 效果套用至圖片框：

```javascript
// 實例化一個代表簡報檔案的簡報類別。
var pres = new aspose.slides.Presentation();
try {
    // 載入要加入簡報影像集合的圖像
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 新增圖片框至投影片
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // 取得投影片的主要序列。
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 為圖片框新增從左側飛入的動畫效果
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // 將 PPTX 檔案儲存至磁碟
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將動畫套用至形狀**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片參考。
3. 新增一個 `rectangle` [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape)。
4. 新增一個 `Bevel` [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape)（點擊此物件時會播放動畫）。
5. 為斜角形狀建立效果序列。
6. 建立自訂的 `UserPath`。
7. 為 `UserPath` 新增移動指令。
8. 將簡報寫入磁碟，以 PPTX 檔案儲存。

以下 JavaScript 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至形狀：

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 類別。
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 為現有形狀從頭建立 PathFootball 效果。
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // 新增 PathFootBall 動畫效果
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // 建立某種「按鈕」。
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // 為此按鈕建立效果序列。
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // 建立自訂使用者路徑。只有在按鈕被點擊後，我們的物件才會移動。
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 為移動新增指令，因為建立的路徑目前是空的。
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **取得套用於形狀的動畫效果**

下列範例示範如何使用 [Sequence](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/) 類別的 `getEffectsByShape` 方法，取得套用於形狀的所有動畫效果。

**範例 1：取得普通投影片上形狀的動畫效果**

先前您已了解如何在 PowerPoint 簡報中為形狀加入動畫效果。下列範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一張普通投影片之第一個形狀所套用的效果。

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // 取得投影片的主要動畫序列。
    var sequence = firstSlide.getTimeline().getMainSequence();

    // 取得第一張投影片上的第一個形狀。
    var shape = firstSlide.getShapes().get_Item(0);

    // 取得套用於該形狀的動畫效果。
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**範例 2：取得所有動畫效果，包括從占位符繼承的效果**

如果普通投影片上的形狀有占位符，而這些占位符位於版面投影片和/或母片投影片，且對這些占位符已加入動畫效果，則在投影片播放時，形狀會播放所有效果，包括從占位符繼承的效果。

假設我們有一個 PowerPoint 簡報檔 `sample.pptx`，其中唯一一張投影片只包含一個頁腳形狀，文字為「Made with Aspose.Slides」，且已套用 **Random Bars** 效果。

![投影片形狀動畫效果](slide-shape-animation.png)

再假設 **Split** 效果已套用於 **版面** 投影片上的頁腳占位符。

![版面形狀動畫效果](layout-shape-animation.png)

最後，**Fly In** 效果已套用於 **母片** 投影片上的頁腳占位符。

![母片形狀動畫效果](master-shape-animation.png)

以下範例程式碼示範如何使用 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 類別的 `getBasePlaceholder` 方法，存取形狀占位符，並取得套用於頁腳形狀的動畫效果，包括從版面與母片投影片的占位符繼承的效果。

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

輸出：
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // 飛入, 底部
Type: 134, subtype: 45            // 分割, 垂直進入
Type: 126, subtype: 22            // 隨機條, 水平
```

## **變更動畫效果的時間屬性**

Aspose.Slides for Node.js via Java 允許您變更動畫效果的時間屬性。

這是 Microsoft PowerPoint 中的動畫時間窗格：

![範例1_圖像](shape-animation.png)

以下是 PowerPoint 時間與 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Effect#getTiming--) 屬性之間的對應：

- PowerPoint 時間 **Start** 下拉選單對應到 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Timing#getTriggerType--) 屬性。
- PowerPoint 時間 **Duration** 對應到 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Timing#getDuration--) 屬性。動畫的持續時間（秒）為動畫完成一次循環所需的總時間。
- PowerPoint 時間 **Delay** 對應到 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) 屬性。

以下說明如何變更 Effect Timing 屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。
2. 為您需要的 [Effect.Timing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Effect#getTiming--) 屬性設定新值。
3. 儲存已修改的 PPTX 檔案。

以下 JavaScript 程式碼示範此操作：

```javascript
// 實例化一個代表簡報檔案的簡報類別。
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // 取得投影片的主要序列。
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 取得主要序列的第一個效果。
    var effect = sequence.get_Item(0);
    // 將效果的 TriggerType 變更為點擊時開始
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // 變更效果的持續時間
    effect.getTiming().setDuration(3.0);
    // 變更效果的 TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5);
    // 將 PPTX 檔案儲存至磁碟
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **動畫效果音效**

Aspose.Slides 提供以下屬性，讓您在動畫效果中使用音效：

- [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **新增動畫效果音效**

以下 JavaScript 程式碼示範如何新增動畫效果音效，並在下一個效果開始時停止該音效：

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // 將音訊加入簡報的音訊集合
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // 取得投影片的主要序列。
    var sequence = firstSlide.getTimeline().getMainSequence();
    // 取得主要序列的第一個效果
    var firstEffect = sequence.get_Item(0);
    // 檢查效果是否為「無聲」
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // 為第一個效果新增音效
        firstEffect.setSound(effectSound);
    }
    // 取得投影片的第一個互動序列。
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // 設定效果的「停止先前音效」旗標
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片參考。 
3. 取得主要效果序列。 
4. 擷取每個動畫效果所嵌入的 [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)。

以下 JavaScript 程式碼示範如何擷取嵌入於動畫效果中的音效：

```javascript
// 實例化一個代表簡報檔案的簡報類別。
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 取得投影片的主要序列。
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // 抽取效果音訊為位元組陣列
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **動畫結束後的設定**

Aspose.Slides for Node.js via Java 允許您變更動畫效果的「After animation」屬性。

這是 Microsoft PowerPoint 中的動畫效果窗格與延伸功能表：

![範例1_圖像](shape-after-animation.png)

PowerPoint 「After animation」下拉選單對應以下屬性：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) 方法，可描述 After animation 類型；
  * PowerPoint **More Colors** 對應 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#Color) 類型；
  * PowerPoint **Don't Dim** 項目對應 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) 類型（預設 After animation 類型）；
  * PowerPoint **Hide After Animation** 項目對應 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 類型；
  * PowerPoint **Hide on Next Mouse Click** 項目對應 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 類型；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) 方法，可定義 After animation 的顏色格式。此方法需配合 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#Color) 類型使用。如將類型變更為其他，則會清除 After animation 顏色。

以下 JavaScript 程式碼示範如何變更 After animation 效果：

```javascript
// 實例化一個代表簡報檔案的簡報類別
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // 取得主要序列的第一個效果
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // 將 After animation 類型變更為顏色
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // 設定 After animation 的暗淡顏色
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **動畫文字**

Aspose.Slides 提供以下屬性，讓您使用動畫效果的 *Animate text* 區塊：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) 可描述效果的動畫文字類型。形狀文字可依以下方式動畫化：
  - 全部一次顯示（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) 類型）
  - 依字詞（[AnimateTextType.ByWord](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/animatetexttype/#ByWord) 類型）
  - 依字母（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/animatetexttype/#ByLetter) 類型）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) 設定動畫文字部件（字詞或字母）之間的延遲。正值表示效果持續時間的百分比；負值表示以秒為單位的延遲。

以下說明如何變更 Effect Animate text 屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。
2. 將 [setBuildType(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) 方法設定為 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/buildtype/#AsOneObject) 值，以關閉 *By Paragraphs* 動畫模式。
3. 為 [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) 與 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) 屬性設定新值。
4. 儲存已修改的 PPTX 檔案。

以下 JavaScript 程式碼示範此操作：

```javascript
// 實例化一個代表簡報檔案的簡報類別。
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // 取得主要序列的第一個效果
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // 將效果的文字動畫類型變更為「作為單一物件」
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // 將效果的動畫文字類型變更為「依字詞」
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // 設定字詞之間的延遲為效果持續時間的 20%
    firstEffect.setDelayBetweenTextParts(20.0);
    // 將 PPTX 檔案寫入磁碟
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**如何確保在將簡報發布至網站時保留動畫？**

[匯出為 HTML5](/slides/zh-hant/nodejs-java/export-to-html5/) 並啟用負責[形狀](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/setanimateshapes/)與[轉場](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/setanimatetransitions/)動畫的[選項](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/)。純 HTML 無法播放投影片動畫，而 HTML5 可以。

**變更形狀的 Z 序（圖層順序）會如何影響動畫？**

動畫與繪圖順序是獨立的：效果控制出現/消失的時機與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getzorderposition/) 決定哪個覆蓋哪個。最終可見結果取決於兩者的組合。（這是一般 PowerPoint 的行為；Aspose.Slides 的效果與形狀模型遵循相同邏輯。）

**在將動畫轉換為影片時，某些效果是否有限制？**

一般而言，[動畫受到支援](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/)，但極少數情況或特定效果可能會以不同方式呈現。建議使用您實際使用的效果以及目前的函式庫版本進行測試。