---
title: مدیریت قاب‌های صوتی در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: قاب صوتی
type: docs
weight: 10
url: /fa/nodejs-java/audio-frame/
keywords:
- صدا
- قاب صوتی
- تصویر کوچک
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صوت
- استخراج صدا
- Node.js
- JavaScript
- Aspose.Slides
description: "صدا را در اسلایدها جاسازی کنید، نماد صوتی را تغییر دهید، پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلاید را با Aspose.Slides برای Node.js از طریق Java استخراج کنید."
---
## **بررسی کلی**

یک قاب صوتی به شما امکان می‌دهد یک صدا را روی اسلاید پخش کنید. با Aspose.Slides برای Node.js از طریق Java، می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویر نماینده آن را انتخاب کنید، پخش را تنظیم کنید و زیرنویس‌ها را پیوست کنید. همچنین می‌توانید صدایی که به یک انتقال اسلاید اختصاص یافته است را بازیابی کنید.

## **ایجاد قاب‌های صوتی**

از [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) برای جاسازی یک کلیپ صوتی محلی در اولین اسلاید استفاده کنید. اولین دو مختصات موقعیت قاب را روی اسلاید تعیین می‌کند و دو مقدار بعدی عرض و ارتفاع آن را به واحد پوینت تنظیم می‌کند. این مثال به [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) فراخوانی می‌کند تا کلیپ به‌صورت خودکار شروع شود و به [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) فراخوانی می‌کند تا پیش‌تنظیم صدای بلند را انتخاب کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تغییر تصویر کوچک قاب صوتی**

به‌صورت پیش‌فرض، یک قاب صوتی یک نماد بلندگو را نمایش می‌دهد. برای نمایش تصویر کوچک سفارشی، یک تصویر را با [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه کنید و آن را با [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) بر روی تصویر قاب تنظیم کنید. این مثال از `eagle.jpeg` به‌عنوان تصویر کوچک برای کلیپ صوتی جاسازی‌شده استفاده می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تغییر گزینه‌های پخش صوت**

کنترل‌های **Audio Options** PowerPoint تعیین می‌کنند که یک کلیپ چه زمانی شروع شود، چه مقدار صدا داشته باشد و در طول نمایش اسلاید چگونه رفتار کند.

![کنترل‌های Audio Options PowerPoint برای یک قاب صوتی](audio_frame_0.png)

| کنترل PowerPoint | متد Aspose.Slides برای Node.js از طریق Java |
| --- | --- |
| شروع | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| پیش‌تنظیم صدا | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| پخش در تمام اسلایدها | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| حلقه تا توقف | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| مخفی در طول نمایش | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| بازپخش پس از پخش | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| محو شدن ورود | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| محو شدن خروج | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| برش زمان شروع صدا | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| برش زمان پایان صدا | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| نوار لغزنده حجم | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

این مثال اولین قاب صوتی را در اولین اسلاید پیدا می‌کند، به [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) فراخوانی می‌کند تا پخش را با کلیک شروع کند و پیش‌تنظیم صدای پایین را انتخاب می‌کند. کلیپ در تمام اسلایدها ادامه می‌یابد در حالی که حلقه غیرفعال است. نماد در طول نمایش مخفی می‌ماند و پس از پخش، کلیپ به‌صورت معکوس پخش می‌شود.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

برای کلیپی که طول آن بیش از 3.5 ثانیه است، این مثال اولین 1.5 ثانیه و آخرین 2 ثانیه را حذف می‌کند. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) مدت زمان حذف‌شده از انتهای کلیپ را می‌گیرد. برای به دست آوردن زمان پایان نشان‌داده‌شده در PowerPoint، آن افست را از مدت زمان کامل کلیپ کم می‌کنید. کلیپ برش‌خورده در طول 200 میلی‌ثانیه محو ورود می‌شود و در 500 میلی‌ثانیه محو خروج می‌گیرد. تمام چهار متد مقدارها را بر حسب میلی‌ثانیه می‌پذیرند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیم حجم پخش به درصد مشخصی، از [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) استفاده کنید. این مثال اولین قاب صوتی را در اولین اسلاید به 85 ٪ تنظیم می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **مدیریت زیرنویس‌های صوتی**

هر قاب صوتی دسترسی به مسیرهای زیرنویس خود را از طریق [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) فراهم می‌آورد. از این مجموعه برای پیوست کردن زیرنویس‌های WebVTT به کلیپ، استخراج مسیرهای موجود یا حذف آن‌ها استفاده کنید.

### **افزودن زیرنویس صوتی**

این مثال یک کلیپ صوتی را در اولین اسلاید جاسازی می‌کند و از [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) برای پیوست یک مسیر WebVTT محلی استفاده می‌کند. آرگومان اول برچسب مسیر را تامین می‌کند و آرگومان دوم فایلی که حاوی زیرنویس‌های زمان‌بندی شده است را شناسایی می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر مسیر زیرنویس پیوست‌شده به یک قاب صوتی در اولین اسلاید را استخراج می‌کند. بایت‌های بازگشتی توسط [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) را به یک فایل WebVTT می‌نویسد و شناسه بازگشتی توسط [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) را به عنوان نام فایل استفاده می‌کند تا هر مسیر خروجی جداگانه‌ای داشته باشد.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **حذف زیرنویس‌های صوتی**

از [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) برای حذف یک مسیر فردی استفاده کنید. این مثال از [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) برای حذف تمام زیرنویس‌ها از اولین قاب صوتی در اولین اسلاید استفاده می‌کند، در حالی که کلیپ حفظ می‌شود.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **یافتن خطی در زیرنویس‌های صوتی**

برای یافتن خطی در زیرنویس‌های صوتی در اولین اسلاید، متن بازگشتی توسط [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) را در حافظه جستجو کنید. در یک Cue متن ساده WebVTT، خط زمان‌بندی شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی Cue را پایان می‌دهد. این مثال برچسب مسیر و هر خط زیرنویسی که شامل «café» باشد را چاپ می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج صوت**

یک انتقال اسلاید می‌تواند صدای خاص خود را داشته باشد. برای بازیابی آن، بر روی انتقال اسلاید به [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) فراخوانی کنید. این مثال بایت‌های بازگشتی توسط [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) را می‌گیرد و تعداد بایت‌ها را چاپ می‌کند. اگر اولین اسلاید صدای انتقال نداشته باشد، به جای آن پیام چاپ می‌شود.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم همان کلیپ صوتی را در اسلایدهای متعدد بدون تکرار استفاده کنم؟**

بله. کلیپ را یک بار به [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) ارائه اضافه کنید و همان شی صوتی را برای هر اسلاید به [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) پاس دهید.

**آیا می‌توانم صدا را در یک قاب صوتی موجود جایگزین کنم؟**

بله. برای صدای پیوندی، از [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) برای اشاره به فایل جایگزین استفاده کنید. برای صداهای جاسازی‌شده، کلیپ دیگری را از مجموعه صوتی ارائه با [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio) انتخاب کنید. هر دو روش قاب موجود را حفظ می‌کنند.

**آیا برش صدا باعث تغییر داده‌های صوتی ذخیره‌شده در ارائه می‌شود؟**

خیر. متدهای [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) و [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) فقط مرزهای پخش را تنظیم می‌کنند. شما هنوز می‌توانید کلیپ کامل را از [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) بازیابی کنید.