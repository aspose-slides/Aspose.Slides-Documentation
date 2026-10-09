---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با استفاده از Node.js
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/nodejs-java/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- جاسازی ویدیو
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
description: "یاد بگیرید به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کنند و مخاطب را درگیر سازند. Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیوی جاسازی‌شده را استخراج کنید.

پاورپوینت از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای یوتیوب، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) ، کلاس [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) و انواع مرتبط دیگر را فراهم می‌کند.

## **ایجاد یک فریم ویدیو جاسازی‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال یک ویدیو محلی را در اسلاید اول یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب نقاط هستند. جریان تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) آن را در حینی که ارائه از آن استفاده می‌کند، قفل نگه می‌دارد.

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

به‌علاوه می‌توانید مسیر ویدیو محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) پاس بدهید. این مثال ویدیو را در اسلاید اول یک ارائه جدید جاسازی می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه در دسترس باقی بماند.

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

## **ایجاد یک فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو یوتیوب، پیوند دارد.

این مثال پیوند یک ویدیو یوتیوب و تصویر کوچک آن را به اسلاید اول اضافه می‌کند. شناسه ویدیو را برای استفاده از ویدیو دیگری جایگزین کنید. متد [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) پخش خودکار را درخواست می‌کند. دانلود تصویر کوچک و پخش ویدیو به دسترسی به اینترنت نیاز دارد. نمایانگر ارائه نیز باید از پخش ویدیو آنلاین پشتیبانی کند.

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

## **پخش یک ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک دموی نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. برای فعال‌سازی این رفتار در حین پخش، [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) را با مقدار `true` فراخوانی کنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود داشته باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به‌صورت مستقل، [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک آغاز شود و [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) تعیین می‌کند که آیا تکرار شود. برای انتخاب رفتار آغاز، حالت پخش را به [VideoPlayModePreset.Auto یا VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات آغاز و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدیو دموی به ابتدای خود آن را برای نمایش مجدد توسط ارائه‌دهنده آماده می‌کند. برای بازگرداندن ویدیو به ابتدای آن پس از اتمام پخش، [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) را با مقدار `true` فراخوانی کنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و بازگردانی را فعال می‌سازد. حلقه‌زدن را غیرفعال می‌کند تا پخش بتواند تمام شود و پخش را برای آغاز با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول فریم ویدیو موجود داشته باشد.

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

بازگردانی ویدیو را به ابتدای آن برمی‌گرداند بدون اینکه دوباره آغاز شود. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) با مقدار `true` پخش را به‌صورت خودکار تکرار می‌کند. هنگامیکه می‌خواهید ویدیو تمام شود و آمادهٔ بازپخش بماند، حلقه‌زدن را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) به‌صورت مستقل کنترل می‌کند که پخش به‌صورت خودکار یا با کلیک آغاز شود؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. حالت پخش را پس از تنظیم حلقه همان‌طور که در مثال نشان داده شده تنظیم کنید. بازگردانی به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) عمل می‌کند.

## **برش یک فریم ویدیو**

از [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) برای نادیده گرفتن بخشی از ابتدای یا انتهای ویدیو در حین پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدیوی جاسازی‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدیو محلی را جاسازی می‌کند و در حین پخش، ۲٫۵ ثانیه اول و یک ثانیه آخر را نادیده می‌گیرد. از ویدیویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

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

این مثال مقادیر برش اولین فریم ویدیو در اسلاید اول را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های پاورپوینت را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

**افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌مکان‌های زیرنویس باید با ویدیو مطابقت داشته باشند. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

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

کلاس [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) همچنین متد [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) را برای افزودن زیرنویس‌ها از یک جریان ارائه می‌دهد.

**استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس از فریم‌های ویدیو در اسلاید اول را به‌صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. اعداد متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت رشته UTF-8 نمایش می‌دهد.

**حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌کند که اسلاید و شکل وجود داشته و شکل یک فریم ویدیو است.

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

اگر نیاز دارید تنها یک مسیر زیرنویس را حذف کنید، به‌جای [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به فایل‌های باینری جداگانه و شماره‌دار استخراج می‌کند. ویدیوهای پیوندی چون دادهٔ جاسازی‌شده ندارند، نادیده گرفته می‌شوند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را به نوع رسانه گزارش‌شده تغییر دهید.

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

## **سؤالات متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک فریم ویدیو تغییر کنند؟**

می‌توانید [حالت پخش](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (خودکار یا با کلیک) و [حلقه‌زدن](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو بر حجم فایل PPTX تأثیر دارد؟**

بله. وقتی یک ویدیو محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شوند، بنابراین اندازه ارائه به نسبت اندازهٔ فایل بزرگ‌تر می‌شود. وقتی به یک ویدیو آنلاین پیوند می‌دهید و تصویر کوچک اضافه می‌کنید، ارائه پیوند و تصویر پیش‌نمایش را به‌جای دادهٔ ویدیو ذخیره می‌کند، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدیو موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) را در داخل فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو جاسازی‌شده را تعیین کرد؟**

بله. یک ویدیو جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی در دیسک.