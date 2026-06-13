---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/nodejs-java/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل انیمیشن‌دار
- متن انیمیشن‌دار
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدای افکت
- اعمال انیمیشن
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه انیمیشن‌های شکل را در ارائه‌های PowerPoint با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق Java ایجاد و سفارشی کنید. متمایز شوید!"
---
## **مقدمه**

انیمیشن‌ها اثرات بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](/slides/fa/nodejs-java/animated-charts/) اعمال شوند. آن‌ها زندگی به ارائه‌ها یا اجزای آن می‌بخشند.

## **چرا در ارائه‌ها از انیمیشن‌ها استفاده کنیم؟**

با استفاده از انیمیشن‌ها می‌توانید  

* جریان اطلاعات را کنترل کنید  
* نکات مهم را برجسته کنید  
* علاقه یا مشارکت مخاطبان خود را افزایش دهید  
* محتوا را برای خواندن، جذب یا پردازش آسان‌تر کنید  
* توجه خوانندگان یا بینندگان را به بخش‌های مهم در یک ارائه جلب کنید  

PowerPoint گزینه‌ها و ابزارهای متعددی برای انیمیشن‌ها و افکت‌های انیمیشن در دسته‌های **ورود**, **خروج**, **تاکید** و **مسیرهای حرکتی** فراهم می‌کند.  

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و انواع مورد نیاز برای کار با انیمیشن‌ها را تحت فضای نام `Aspose.Slides.Animation` ارائه می‌دهد،  
* Aspose.Slides بیش از **150 افکت انیمیشن** تحت شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttype) دارد. این افکت‌ها در اصل همان افکت‌های استفاده‌شده در PowerPoint هستند.  

## **اعمال انیمیشن بر TextBox**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد انیمیشن را به متن داخل یک شکل اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. یک مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک `rectangle` [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape) اضافه کنید.  
4. با استفاده از [AutoShape.addTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) متن اضافه کنید.  
5. یک دنباله اصلی افکت‌ها دریافت کنید.  
6. یک افکت انیمیشن به [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape) اضافه کنید.  
7. متد `TextAnimation.setBuildType` را با مقدار از شمارش‌گر `BuildType` فراخوانی کنید.  
8. ارائه را به صورت فایل PPTX روی دیسک ذخیره کنید.  

این کد Javascript نشان می‌دهد چگونه افکت `Fade` را به AutoShape اعمال کرده و انیمیشن متن را روی مقدار *By 1st Level Paragraphs* تنظیم کنید:

```javascript
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    //   یک AutoShape جدید با متن اضافه می‌کند
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    //   دنباله اصلی اسلاید را دریافت می‌کند.
    var sequence = sld.getTimeline().getMainSequence();
    //   افکت انیمیشن Fade را به شکل اضافه می‌کند
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    //   متن شکل را بر اساس پاراگراف‌های سطح اول انیمیشن می‌کند
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    //   فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

علاوه بر اعمال انیمیشن بر متن، می‌توانید انیمیشن را به یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph) واحد نیز اعمال کنید. ببینید [**Animated Text**](/slides/fa/nodejs-java/animated-text/).  

{{% /alert %}} 

## **اعمال انیمیشن بر PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe) به اسلاید اضافه یا دریافت کنید.  
4. دنباله اصلی افکت‌ها را دریافت کنید.  
5. یک افکت انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe) اضافه کنید.  
6. ارائه را به صورت فایل PPTX روی دیسک ذخیره کنید.  

این کد Javascript نشان می‌دهد چگونه افکت `Fly` را به یک فریم تصویر اعمال کنید:

```javascript
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
var pres = new aspose.slides.Presentation();
try {
    // تصویر را که قرار است به مجموعه تصاویر ارائه اضافه شود بارگذاری می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // قاب تصویر را به اسلاید اضافه می‌کند
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // دنباله اصلی اسلاید را دریافت می‌کند.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // افکت انیمیشن Fly از سمت چپ را به قاب تصویر اضافه می‌کند
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اعمال انیمیشن بر Shape**

1. یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک `rectangle` [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape) اضافه کنید.  
4. یک `Bevel` [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).  
5. یک دنباله افکت‌ها را برای شکل bevel ایجاد کنید.  
6. یک `UserPath` سفارشی ایجاد کنید.  
7. دستورات برای حرکت به `UserPath` اضافه کنید.  
8. ارائه را به صورت فایل PPTX روی دیسک ذخیره کنید.  

این کد Javascript نشان می‌دهد چگونه افکت `PathFootball` (مسیر فوتبال) را به یک شکل اعمال کنید:

```javascript
// یک کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // افکت PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // افکت انیمیشن PathFootBall را اضافه می‌کند
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // یک نوع "دکمه" ایجاد می‌کند.
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // دنباله‌ای از افکت‌ها برای این دکمه ایجاد می‌کند.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // مسیر کاربری سفارشی ایجاد می‌کند. شیء ما فقط پس از کلیک روی دکمه جابجا می‌شود.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // دستورات حرکت را اضافه می‌کند چون مسیر ایجاد شده خالی است.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دریافت افکت‌های انیمیشن اعمال‌شده بر Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `getEffectsByShape` کلاس [Sequence](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/) برای دریافت تمام افکت‌های انیمیشن اعمال‌شده بر یک شکل استفاده کنید.

**مثال ۱: دریافت افکت‌های انیمیشن اعمال‌شده بر یک شکل در یک اسلاید عادی**

قبلاً یاد گرفتید چگونه افکت‌های انیمیشن را به اشکال در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های اعمال‌شده بر اولین شکل در اولین اسلاید عادی در ارائه `AnimExample_out.pptx` را دریافت کنید.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // دنباله اصلی انیمیشن اسلاید را دریافت می‌کند.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // اولین شکل در اولین اسلاید را دریافت می‌کند.
    var shape = firstSlide.getShapes().get_Item(0);

    // افکت‌های انیمیشن اعمال شده بر شکل را دریافت می‌کند.
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

**مثال ۲: دریافت تمام افکت‌های انیمیشن، از جمله آنهایی که از placeholders به ارث می‌رسند**

اگر یک شکل در اسلاید عادی placeholders داشته باشد که در اسلاید چیدمان و/یا اسلاید اصلی قرار دارند و افکت‌های انیمیشن به این placeholders اضافه شده باشد، تمام افکت‌های شکل در طول نمایش اسلاید اجرا می‌شوند، از جمله آنهایی که از placeholders به ارث رسیده‌اند.

فرض کنید فایلی PowerPoint به نام `sample.pptx` داریم که یک اسلاید شامل فقط یک شکل پاورقی با متن «Made with Aspose.Slides» دارد و افکت **Random Bars** بر روی شکل اعمال شده است.

![اثر انیمیشن شکل اسلاید](slide-shape-animation.png)

همچنین فرض کنید که افکت **Split** بر روی placeholder پاورقی در اسلاید **layout** اعمال شده است.

![اثر انیمیشن شکل لایه‌بندی](layout-shape-animation.png)

و در نهایت، افکت **Fly In** بر روی placeholder پاورقی در اسلاید **master** اعمال شده است.

![اثر انیمیشن شکل اصلی](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `getBasePlaceholder` کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) برای دسترسی به placeholders شکل و دریافت افکت‌های انیمیشن اعمال‌شده بر شکل پاورقی، از جمله آنهایی که از placeholders در اسلایدهای layout و master به ارث رسیده‌اند، استفاده کنید.

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

خروجی:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // پرواز، پایین
Type: 134, subtype: 45            // تقسیم، عمودی به داخل
Type: 126, subtype: 22            // نوارهای تصادفی، افقی
```

## **تغییر ویژگی‌های زمان‌بندی افکت انیمیشن**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد ویژگی‌های Timing یک افکت انیمیشن را تغییر دهید.

این پنل Timing انیمیشن در Microsoft PowerPoint است:

![example1_image](shape-animation.png)

این تطابق‌ها بین Timing در PowerPoint و خصوصیات [Effect.Timing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Effect#getTiming--) هستند:

- لیست کشویی **Start** در PowerPoint با خصوصیت [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Timing#getTriggerType--) مطابقت دارد.  
- **Duration** در PowerPoint با خصوصیت [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Timing#getDuration--) مطابقت دارد. مدت زمان یک انیمیشن (به ثانیه) کل زمان لازم برای تکمیل یک چرخه است.  
- **Delay** در PowerPoint با خصوصیت [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) مطابقت دارد.  

این نحوه تغییر خصوصیات Timing افکت است:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.  
2. مقادیر جدید برای خصوصیات [Effect.Timing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Effect#getTiming--) که نیاز دارید، تنظیم کنید.  
3. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد Javascript عملکرد را نشان می‌دهد:

```javascript
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // دنباله اصلی اسلاید را دریافت می‌کند.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // اولین افکت دنباله اصلی را دریافت می‌کند.
    var effect = sequence.get_Item(0);
    // نوع TriggerType افکت را به شروع با کلیک تغییر می‌دهد
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // مدت زمان افکت را تغییر می‌دهد
    effect.getTiming().setDuration(3.0);
    // زمان تاخیر TriggerDelayTime افکت را تغییر می‌دهد
    effect.getTiming().setTriggerDelayTime(0.5);
    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **صدا در افکت انیمیشن**

Aspose.Slides این خصوصیات را برای کار با صداها در افکت‌های انیمیشن فراهم می‌کند:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **افزودن صدا به افکت انیمیشن**

این کد Javascript نشان می‌دهد چگونه صدا به یک افکت انیمیشن اضافه کنید و هنگام شروع افکت بعدی صدا را متوقف کنید:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // صوت را به مجموعه صوت‌های ارائه اضافه می‌کند
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // دنباله اصلی اسلاید را دریافت می‌کند.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // اولین افکت دنباله اصلی را دریافت می‌کند
    var firstEffect = sequence.get_Item(0);
    // بررسی می‌کند که افکت صدایی ندارد
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // صوت را برای اولین افکت اضافه می‌کند
        firstEffect.setSound(effectSound);
    }
    // دنباله تعاملی اول اسلاید را دریافت می‌کند.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // پرچم "توقف صدای قبلی" افکت را تنظیم می‌کند
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **استخراج صدا از افکت انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. دنباله اصلی افکت‌ها را دریافت کنید.  
4. صداهای امبدد شده در هر افکت انیمیشن را با استفاده از [setSound(IAudio value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) استخراج کنید.  

این کد Javascript نشان می‌دهد چگونه صداهای امبدد شده در یک افکت انیمیشن را استخراج کنید:

```javascript
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // دنباله اصلی اسلاید را دریافت می‌کند.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // صدا افکت را به صورت آرایه بایت استخراج می‌کند
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **پس از انیمیشن**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد خصوصیت After animation یک افکت انیمیشن را تغییر دهید.

این پنل افکت انیمیشن و منوی گسترش یافته در Microsoft PowerPoint است:

![example1_image](shape-after-animation.png)

لیست کشویی **After animation** در PowerPoint با این خصوصیات مطابقت دارد:  

- متد [setAfterAnimationType(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) که نوع After animation را توصیف می‌کند؛  
  * **More Colors** در PowerPoint با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#Color) همخوانی دارد؛  
  * آیتم **Don't Dim** در PowerPoint با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (نوع پیش‌فرض after animation) مطابقت دارد؛  
  * آیتم **Hide After Animation** با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) همخوانی دارد؛  
  * آیتم **Hide on Next Mouse Click** با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) مطابقت دارد؛  
- متد [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) که قالب رنگ after animation را تعریف می‌کند. این متد همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#Color) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ after animation پاک خواهد شد.  

این کد Javascript نشان می‌دهد چگونه یک افکت after animation را تغییر دهید:

```javascript
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // اولین افکت دنباله اصلی را دریافت می‌کند
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // نوع after animation را به Color تغییر می‌دهد
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // رنگ after animation dim را تنظیم می‌کند
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **انیمیشن متن**

Aspose.Slides این خصوصیات را برای کار با بلوک *Animate text* یک افکت انیمیشن فراهم می‌کند:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) که نوع animate text افکت را توصیف می‌کند. متن شکل می‌تواند به صورت:  
  - همزمان همه (نوع [AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - به‌صورت کلمه به کلمه (نوع [AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/animatetexttype/#ByWord))  
  - به‌صورت حرف به حرف (نوع [AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/animatetexttype/#ByLetter))  
  انیمیشن شود؛  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) تاخیر بین بخش‌های متن انیمیشن شده (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت را نشان می‌دهد؛ مقدار منفی تاخیر بر حسب ثانیه است.  

نحوه تغییر خصوصیات Animate text افکت به این صورت است:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.  
2. متد [setBuildType(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) را روی مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/buildtype/#AsOneObject) تنظیم کنید تا حالت *By Paragraphs* را غیرفعال کنید.  
3. مقادیر جدید برای خصوصیات [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) تنظیم کنید.  
4. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد Javascript عملیات را نشان می‌دهد:

```javascript
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // اولین افکت دنباله اصلی را دریافت می‌کند
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // نوع انیمیشن متن افکت را به "As One Object" تغییر می‌دهد
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // نوع انیمیشن متن افکت را به "By word" تغییر می‌دهد
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // تاخیر بین کلمات را به 20% از مدت افکت تنظیم می‌کند
    firstEffect.setDelayBetweenTextParts(20.0);
    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟**

از [Export to HTML5](/slides/fa/nodejs-java/export-to-html5/) استفاده کنید و گزینه‌های responsible برای انیمیشن‌های [shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/setanimateshapes/) و [transition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/setanimatetransitions/) را فعال کنید. HTML ساده انیمیشن اسلاید را پخش نمی‌کند، درحالی‌که HTML5 این کار را انجام می‌دهد.  

**تغییر ترتیب لایه (z-order) اشکال چه تاثیری بر انیمیشن دارد؟**

ترتیب انیمیشن و ترسیم مستقل هستند: یک افکت زمان‌بندی و نوع ظاهر/ناپدید شدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getzorderposition/) تعیین می‌کند چه چیزی چه چیز را می‌پوشاند. نتیجه قابل مشاهده ترکیب این دو است. (این رفتار کلی PowerPoint است؛ مدل افکت‌ها و اشکال Aspose.Slides نیز همین منطق را دنبال می‌کند.)  

**آیا محدودیتی هنگام تبدیل انیمیشن‌ها به ویدیو برای برخی افکت‌ها وجود دارد؟**

به‌طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/nodejs-java/convert-powerpoint-to-video/)، اما در موارد نادر یا برای افکت‌های خاص ممکن است به صورت متفاوتレンدی

 شود. توصیه می‌شود که افکت‌های مورد استفاده و نسخه کتابخانه را آزمایش کنید.