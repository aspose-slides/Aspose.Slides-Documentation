---
title: مدیریت صدا در ارائه‌ها با استفاده از JavaScript
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/nodejs-java/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر بندانگشتی
- افزودن صدا
- خصوصیات صدا
- گزینه‌های صدا
- استخراج صدا
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای Node.js — مثال‌هایی برای تعبیه، برش، حلقه‌گذاری و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **مرور کلی**

این مقاله نحوه کار با فریم‌های صوتی در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه صوت تعبیه‌شده به اسلایدها اضافه کنید، تصویر بندانگشتی فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، حلقه‌گذاری، مخفی‌سازی، بریدن و زمان‌های محو شدن را تنظیم کنید و صوت استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای Node.js از طریق Java به شما امکان افزودن فایل‌های صوتی به اسلایدها را می‌دهد. فایل‌های صوتی به‌صورت فریم‌های صوتی در اسلایدها تعبیه می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.
3. جریان فایل صوتی را که می‌خواهید در اسلاید تعبیه کنید، بارگذاری کنید.
4. فریم صوتی تعبیه‌شده (شامل فایل صوتی) را به اسلاید اضافه کنید.
5. [PlayMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AudioPlayModePreset) و `Volume` را که توسط شیء [AudioFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AudioFrame) در دسترس هستند، تنظیم کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک فریم صوتی تعبیه‌شده به یک اسلاید اضافه کنید:

```javascript
// یک شی از کلاس Presentation ایجاد می‌کند که نمایان‌گر فایل ارائه است
const pres = new aspose.slides.Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    const sld = pres.getSlides().get_Item(0);
    // فایل صوتی wav را به‌صورت جریان بارگذاری می‌کند
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // فریم صوتی را اضافه می‌کند
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // حالت پخش و حجم صدا را تنظیم می‌کند
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // فایل PowerPoint را روی دیسک می‌نویسد
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر تصویر بندانگشتی فریم صوتی**

هنگامی که یک فایل صوتی به ارائه اضافه می‌کنید، صوت به‌صورت فریمی با تصویر پیش‌فرض استاندارد ظاهر می‌شود (به تصویر در بخش زیر مراجعه کنید). می‌توانید تصویر پیش‌نمایش فریم صوتی را (تصویر دلخواه خود را تنظیم کنید) تغییر دهید.

این کد JavaScript نشان می‌دهد چگونه تصویر بندانگشتی یا پیش‌نمایش فریم صوتی را تغییر دهید:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // یک فریم صوتی را به اسلاید اضافه می‌کند با موقعیت و اندازهٔ مشخص.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // یک تصویر را به منابع ارائه اضافه می‌کند.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // تصویر را برای فریم صوتی تنظیم می‌کند.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // ارائهٔ اصلاح‌شده را روی دیسک ذخیره می‌کند
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **تغییر گزینه‌های پخش صوت**

Aspose.Slides برای Node.js از طریق Java به شما اجازه می‌دهد گزینه‌هایی که پخش یا خصوصیات صوت را کنترل می‌کنند، تغییر دهید. به‌عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صوت را به‌صورت حلقه‌ای پخش کنید یا حتی نماد صوت را مخفی کنید.

پنل **Audio Options** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** در PowerPoint که با خصوصیات [AudioFrame] در Aspose.Slides مطابقت دارند:
- لیست کشویی **Start** مطابق با متد [AudioFrame.setPlayMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setPlayMode) است
- **Volume** مطابق با متد [AudioFrame.setVolume](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setVolume) است
- **Play Across Slides** مطابق با متد [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) است
- **Loop until Stopped** مطابق با متد [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) است
- **Hide During Show** مطابق با متد [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) است
- **Rewind after Playing** مطابق با متد [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setRewindAudio) است

گزینه‌های **Editing** در PowerPoint که با خصوصیات [AudioFrame] در Aspose.Slides مطابقت دارند:

- **Fade In** مطابق با متد [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) است
- **Fade Out** مطابق با متد [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) است
- **Trim Audio Start Time** مطابق با متد [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) است
- مقدار **Trim Audio End Time** برابر است با مدت زمان صوت منهای مقدار متد [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

کنترل **Volume** در پنل کنترل صدا در PowerPoint مطابق با متد [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#setVolumeValue) است. این امکان را می‌دهد تا حجم صدا را به صورت درصدی تغییر دهید.

نحوه تغییر گزینه‌های پخش صوت به این صورت است:

1. [Сreate](#create-audio-frame) یا دریافت Audio Frame.
2. مقادیر جدید برای خصوصیات Audio Frame که می‌خواهید تنظیم کنید، تعیین کنید.
3. فایل PowerPoint اصلاح‌شده را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه گزینه‌های یک صوت تنظیم می‌شوند:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // شکل AudioFrame را دریافت می‌کند
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // حالت پخش را روی کلیک تنظیم می‌کند
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // حجم صدا را روی کم تنظیم می‌کند
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // صدا را برای پخش در تمام اسلایدها تنظیم می‌کند
    audioFrame.setPlayAcrossSlides(true);
    // حلقه پخش صدا را غیرفعال می‌کند
    audioFrame.setPlayLoopMode(false);
    // فریم AudioFrame را در طول نمایش اسلاید مخفی می‌کند
    audioFrame.setHideAtShowing(true);
    // پس از پخش، صدا را به ابتدا باز می‌گرداند
    audioFrame.setRewindAudio(true);
    // فایل PowerPoint را روی دیسک ذخیره می‌کند
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال JavaScript نشان می‌دهد چگونه فریم صوتی جدیدی با صوت تعبیه‌شده اضافه کنید، آن را بریده و زمان‌های محو شدن را تنظیم کنید:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // آغاز برش را به ۱٫۵ ثانیه تنظیم می‌کند
    audioFrame.setTrimFromStart(1500);
    // پایان برش را به ۲ ثانیه تنظیم می‌کند
    audioFrame.setTrimFromEnd(2000);

    // مدت زمان محو شدن ورودی (fade‑in) را به ۲۰۰ میلی‌ثانیه تنظیم می‌کند
    audioFrame.setFadeInDuration(200);
    // مدت زمان محو شدن خروجی (fade‑out) را به ۵۰۰ میلی‌ثانیه تنظیم می‌کند
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صوت تعبیه‌شده بازیابی شود و حجم آن را روی ۸۵٪ تنظیم کنید:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // یک شکل فریم صوتی دریافت می‌کند
    const audioFrame = slide.getShapes().get_Item(0);

    // حجم صدا را به ۸۵٪ تنظیم می‌کند
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **مدیریت زیرنویس‌های صوتی**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته به فریم صوتی از طریق متد [getCaptionTracks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) اضافه کنید. این متد یک [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) برمی‌گرداند که به شما اجازه می‌دهد مسیرهای زیرنویس WebVTT را اضافه، در مسیرهای موجود مرور کنید و در صورت نیاز آن‌ها را حذف کنید.

**افزودن زیرنویس صوتی**

از متد [getCaptionTracks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) برای متصل کردن یک یا چند مسیر زیرنویس به یک فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس مسیر زیرنویس جدیدی از یک فایل `.vtt` بارگذاری می‌شود.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // یک مسیر زیرنویس جدید از یک فایل WebVTT اضافه می‌کند.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**استخراج زیرنویس صوتی**

می‌توانید در مسیرهای زیرنویس مرتبط با فریم صوتی گردش کنید و آنها را به‌صورت فایل‌های `.vtt` ذخیره کنید. هر مسیر زیرنویس داده‌های باینری و شناسهٔ یکتای خود را در اختیار می‌گذارد که می‌تواند هنگام صادرات زیرنویس‌ها استفاده شود.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // مسیر زیرنویس را به‌صورت فایل .vtt ذخیره می‌کند.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**حذف زیرنویس صوتی**

برای حذف زیرنویس‌ها از فریم صوتی، از متدهای ارائه‌شده توسط [CaptionsCollection] استفاده کنید، مانند [clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#removeAt). مثال زیر همه مسیرهای زیرنویس را از فریم صوتی حذف می‌کند.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // نوع: aspose.slides.AudioFrame

    // تمام مسیرهای زیرنویس را از فریم صوتی حذف می‌کند.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج صدا**

Aspose.Slides برای Node.js از طریق Java به شما امکان استخراج صدای استفاده‌شده در انتقال‌های نمایش اسلاید را می‌دهد. به‌عنوان مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید و ارائه حاوی صوت را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق شاخص آن دریافت کنید.
3. به [slideshow transitions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) اسلاید دسترسی پیدا کنید.
4. صدای بایت‌دیتا را استخراج کنید.

این کد JavaScript نشان می‌دهد چگونه صدای استفاده‑شده در یک اسلاید استخراج شود:

```javascript
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // به اسلاید مورد نظر دسترسی پیدا می‌کند
    const slide = pres.getSlides().get_Item(0);
    // افکت‌های انتقال نمایش اسلاید را برای اسلاید دریافت می‌کند
    const transition = slide.getSlideShowTransition();
    // صدا را به صورت آرایه بایت استخراج می‌کند
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم همان دارایی صوتی را در اسلایدهای متعدد بدون افزایش حجم فایل استفاده دوباره کنم؟**

بله. صوت را یک‌بار به [audio collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getaudios/) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی که به آن دارایی موجود اشاره دارند، ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری کرده و اندازهٔ ارائه را تحت کنترل نگه می‌دارد.

**آیا می‌توانم صدای موجود در یک فریم صوتی را بدون بازسازی شکل جایگزین کنم؟**

بله. برای صدای پیوندی، مسیر [link path](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) را به فایل جدید تنظیم کنید. برای صدای تعبیه‌شده، شیء [embedded audio](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) را با دیگری از [audio collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getaudios/) ارائه تعویض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش بدون تغییر باقی می‌مانند.

**آیا بریدن (trim) داده‌های صوتی زیرین ذخیره‌شده در ارائه را تغییر می‌دهد؟**

خیر. بریدن فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صوت دست‌نخورده باقی می‌مانند و از طریق صوت تعبیه‌شده یا مجموعهٔ صوت ارائه قابل دسترسی هستند.