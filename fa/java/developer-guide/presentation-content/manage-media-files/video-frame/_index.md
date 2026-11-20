---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با استفاده از جاوا
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/java/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- جاسازی ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- فریم ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای جاوا اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **معرفی**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides برای Java به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تغییر دهید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیو جاساز شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، از جمله ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدیوی جاساز شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه‌تان جاساز کنید.

این مثال یک ویدیو محلی را بر روی اسلاید اول یک ارائه موجود جاساز می‌کند و نتیجه را ذخیره می‌کند. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان تا پایان ذخیره باز می‌ماند زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) آن را قفل نگه می‌دارد در حالی که ارائه از آن استفاده می‌کند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید مسیر ویدیو محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) پاس دهید. این مثال ویدیو را بر روی اسلاید اول یک ارائه جدید جاساز می‌کند. ویدیو باید تا زمان ذخیره ارائه قابل دسترسی باقی بماند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد یک فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید یک فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، پیوند دارد.

این مثال لینک ویدیو YouTube و تصویر بند انگشتی آن را به اسلاید اول اضافه می‌کند. برای استفاده از ویدیو دیگر شناسه ویدیو را جایگزین کنید. متد [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) درخواست پخش خودکار را می‌کند. دریافت تصویر بند انگشتی و پخش ویدیو به دسترسی به اینترنت نیاز دارد. نمایشگر ارائه نیز باید از پخش ویدیو آنلاین پشتیبانی کند.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پخش یک ویدیو در حالت تمام صفحه**

در یک ارائه آموزشی، می‌توانید یک دموی نرم‌افزاری را در حالت تمام صفحه پخش کنید تا مخاطبان جزئیات را ببینند. با فراخوانی [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) با مقدار `true` این رفتار را در طول پخش فعال کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود داشته باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پخش تمام صفحه نحوه نمایش ویدیو را کنترل می‌کند. به طور مستقل، [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) تعیین می‌کند که آیا به صورت خودکار یا با کلیک شروع شود، و [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن یک ویدیو دموی به ابتدای خود آن را برای اجرای مجدد توسط ارائه‌دهنده آماده می‌کند. با فراخوانی [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) با مقدار `true` ویدیو را پس از پایان پخش به ابتدای خود باز می‌گردانید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و بازگردانی را فعال می‌سازد. حلقه‌زدن را غیرفعال می‌کند تا پخش بتواند به پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود داشته باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بازگردانی ویدیو را بدون شروع مجدد به ابتدای آن باز می‌گرداند. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) با مقدار `true` پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدیو به پایان برسد و آماده‌ی پخش مجدد باشد، حلقه‌زدن را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) به‌صورت مستقل کنترل می‌کند که پخش به‌صورت خودکار یا با کلیک آغاز شود؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. همان‌طور که در مثال نشان داده شده، حالت پخش را پس از تنظیم حلقه تنظیم کنید. بازگردانی به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) کار می‌کند.

## **قصاص یک فریم ویدیو**

از [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) برای صرفنظر کردن از بخشی از ابتدای یا انتهای ویدیو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. قصاص تنظیمات پخش را بدون تغییر داده‌های ویدیو جاساز شده تغییر می‌دهد.

**تنظیمات قصاص**

این مثال یک ویدیو محلی را جاساز می‌کند و در طول پخش، ۲.۵ ثانیه اول و یک ثانیه آخر را صرفنظر می‌کند. از ویدیویی طولانی‌تر از ۳.۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**خواندن تنظیمات قصاص**

این مثال مقادیر قصاص اولین فریم ویدیو در اسلاید اول را بر حسب میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیویی نداشته باشد، چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

### **افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را جاساز می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌سنجی زیرنویس‌ها باید با ویدیو همخوانی داشته باشد. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان اضافه کنید.

### **استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدیو در اسلاید اول به صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. اعداد متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

هر شیء [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به عنوان یک رشته UTF-8 نمایش می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود که اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدیو باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر نیاز دارید تنها یک مسیر زیرنویس را حذف کنید، به جای [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--)، از متدهای [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) استفاده کنید.

### **جستجوی زیرنویس‌های ویدیو**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) کل مسیر WebVTT را به همراه سرصفحه، خطوط زمان‌بندی و متن زیرنویس بر می‌گرداند. می‌توانید نشانه‌ها را در حافظه جستجو کنید تا عبارت گفتاری و زمان‌سنجی آن را پیدا کنید. به عنوان مثال، یک مسیر English در اسلاید ۲ ممکن است متن زیر را داشته باشد.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

این مثال فایل `captioned_media.pptx` را باز می‌کند و از [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) برای خواندن مسیرهای هر فریم ویدیو سطح بالا در هر اسلاید استفاده می‌کند. در یک نشانه متن ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی نشانه را پایان می‌دهد. زمانی که زیرنویس شامل “café” در هر ترکیب حروفی باشد، مثال شماره اسلاید، برچسب مسیر، خط زمان‌بندی اصلی و کل زیرنویس را چاپ می‌کند.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

جستجو برای “café” یک تطبیق برای مسیر نمونه تولید می‌کند. جستجو سرصفحه مسیر را حذف کرده و تنظیمات زمان‌بندی را در خروجی حفظ می‌کند.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدیو از یک اسلاید**

علاوه بر افزودن ویدیو به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای جاساز شده در ارائه‌ها را می‌دهد.

این مثال ویدیوهای جاساز شده را از هر اسلاید استخراج کرده و در فایل‌های باینری جداگانه و شماره‌دار ذخیره می‌کند. ویدیوهای پیوند داده شده نادیده گرفته می‌شوند زیرا داده جاسازی‌شده‌ای ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را برای تطبیق با نوع رسانه گزارش شده تغییر دهید.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک فریم ویدیو تغییر کنند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (خودکار یا با کلیک) و [حلقه‌زدن](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو بر اندازه فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را جاساز می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه با نسبت به حجم فایل افزایش می‌یابد. وقتی به یک ویدیو آنلاین پیوند می‌دهید و تصویر بند انگشتی اضافه می‌کنید، ارائه لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه داده‌های ویدیو، بنابراین افزایش اندازه معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدیو موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) را داخل فریم تعویض کنید در حالی که هندسه شکل را حفظ می‌کنید؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو جاساز شده را تعیین کرد؟**

بله. یک ویدیو جاساز شده دارای یک [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، به‌عنوان مثال هنگام ذخیره‌سازی بر روی دیسک.