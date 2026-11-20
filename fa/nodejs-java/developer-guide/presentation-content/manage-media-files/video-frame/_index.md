---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با استفاده از Node.js
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/nodejs-java/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- دریافت ویدیو
- فریم ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید که چگونه به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **معرفی**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیو تعبیه‌شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)، کلاس [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) و انواع مرتبط دیگر را ارائه می‌دهد.

## **ایجاد فریم ویدیو تعبیه‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود تعبیه کنید.

این مثال یک ویدیو محلی را در اسلاید اول یک ارائه موجود تعبیه می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب نقطه (point) هستند. جریان (stream) تا پایان ذخیره‌سازی باز می‌ماند، زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) در حینی که ارائه از آن استفاده می‌کند، آن را قفل نگه می‌دارد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید مسیر ویدیو محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) بدهید. این مثال ویدیو را در اسلاید اول یک ارائه جدید تعبیه می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه قابل دسترسی بماند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، پیوند دهد.

این مثال یک پیوند ویدیو YouTube و تصویر بندانگشتی آن را به اسلاید اول اضافه می‌کند. شناسه ویدیو را تغییر دهید تا از ویدیوی دیگری استفاده کنید. متد [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) درخواست پخش خودکار را می‌دهد. دانلود تصویر بندانگشتی و پخش ویدیو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید پخش ویدیوهای آنلاین را پشتیبانی کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. برای فعال کردن این رفتار هنگام پخش، [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) را با مقدار `true` صدا بزنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود باشد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به طور مستقل، [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود و [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto یا VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدیو نمایشی به ابتدای خود باعث می‌شود برای ارائه‌دهنده آماده پخش دوباره باشد. برای بازگشت ویدیو به ابتدای خود پس از اتمام پخش، [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) را با مقدار `true` صدا بزنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و بازگردانی را فعال می‌سازد. حلقه‌گذاری را غیرفعال می‌کند تا پخش بتواند پایان یابد و پخش را روی کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود باشد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بازگردانی ویدیو را به ابتدای خود بدون شروع دوباره باز می‌گرداند. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) با مقدار `true` پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدیو به‌مرور زمان تمام شود و آماده بازپخش بماند، حلقه‌گذاری را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) به‌صورت مستقل کنترل استارت خودکار یا با کلیک را انجام می‌دهد؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. تنظیم حالت پخش پس از تنظیم حلقه همان‌گونه که در مثال نشان داده شده است انجام می‌شود. بازگردانی به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) کار می‌کند.

## **قلم‌زنی فریم ویدیو**

از متدهای [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) برای حذف بخشی از ابتدای یا انتهای ویدیو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدیو تعبیه‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدیو محلی را تعبیه می‌کند و در زمان پخش ثانیه اول 2.5 و آخرین یک ثانیه را حذف می‌کند. از ویدیویی طولانی‌تر از 3.5 ثانیه استفاده کنید تا بخشی قابل پخش باقی بماند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**خواندن تنظیمات برش**

این مثال مقادیر برش فریم ویدیو اول در اسلاید اول را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیو نداشته باشد، هیچ‌چیزی چاپ نمی‌شود. مثال قبل مقادیر 2500 و 1000 را تولید می‌کرد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته (closed captions) برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

### **اضافه کردن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را تعبیه می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌برچسب‌های زیرنویس باید با ویدیو مطابقت داشته باشد. ارائه ذخیره‌شده هم ویدیو و هم زیرنویس‌های آن را شامل می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) همچنین متد [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) را برای افزودن زیرنویس‌ها از یک جریان (stream) فراهم می‌کند.

### **استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدیو در اسلاید اول به‌صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های ترتیبی خروجی‌ها را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

هر شیء [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده باینری و متن زیرنویس را به‌صورت رشته UTF-8 ارائه می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌کند اسلاید و شکل موجود هستند و شکل یک فریم ویدیو است.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر نیاز به حذف تنها یک مسیر زیرنویس دارید، به جای [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

### **جستجوی زیرنویس‌های ویدیو**

متد [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) کل مسیر WebVTT را شامل سرآیند، خطوط زمان‌بندی و متن زیرنویس برمی‌گرداند. می‌توانید متن زیرنویس را در حافظه جستجو کنید تا عبارت و زمان‌مهر آن را پیدا کنید. برای مثال، یک مسیر انگلیسی در اسلاید 2 ممکن است شامل این cue باشد:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

این مثال فایل `captioned_media.pptx` را باز می‌کند و با استفاده از [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) مسیرهای هر فریم ویدیو سطح بالا را در همه اسلایدها می‌خواند. در یک cue متنی ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی انتهای cue را نشان می‌دهد. برای هر زیرنویسی که شامل کلمه “café” در هر ترکیب حروف باشد، مثال شماره اسلاید، برچسب مسیر، خط زمان‌بندی اصلی و متن کامل زیرنویس را چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

جستجو برای “café” یک تطابق در مسیر نمونه پیدا می‌کند. جستجو سرآیند مسیر را نادیده می‌گیرد و تنظیم زمان‌بندی و شکستن خط را در خروجی حفظ می‌کند.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدیو از اسلاید**

به‌جز افزودن ویدیو به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدیوهای تعبیه‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای تعبیه‌شده را از هر اسلاید به‌صورت فایل‌های باینری شماره‌گذاری‌شده جداگانه استخراج می‌کند. ویدیوهای پیوندی نادیده گرفته می‌شوند زیرا داده تعبیه‌شده‌ای ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز می‌توانید آن را به‌صورت متناسب با نوع رسانه گزارش‌شده تغییر دهید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **سؤال‌های متداول**

**کدام پارامترهای پخش ویدیو می‌توان برای فریم ویدیو تغییر داد؟**

می‌توانید [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (خودکار یا با کلیک) و [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدیو بر اندازه فایل PPTX تاثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را تعبیه می‌کنید، داده باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه به نسبت حجم فایل رشد می‌کند. وقتی به یک ویدیو آنلاین پیوند می‌دهید و تصویر بندانگشتی اضافه می‌کنید، ارائه فقط پیوند و تصویر پیش‌نمایش را ذخیره می‌کند نه داده ویدیو، بنابراین افزایش اندازه معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدیو موجود بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**

بله. می‌توانید محتویات [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) را داخل فریم تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این یک سناریو رایج برای به‌روزرسانی رسانه در یک طرح‌بندی موجود است.

**آیا می‌توان نوع محتوا (MIME) ویدیو تعبیه‌شده را تعیین کرد؟**

بله. یک ویدیو تعبیه‌شده دارای [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.