---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها در اندروید
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/androidjava/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- جاسازی ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- فریم ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید که چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java اضافه و استخراج کنید. راهنمای سریع گام به گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کنند و مخاطبان را جذب نمایند. Aspose.Slides برای Android از طریق Java به شما امکان افزودن فریم‌های ویدئویی به اسلایدها، تنظیم تنظیمات پخش، مدیریت زیرنویس‌ها و استخراج داده‌های ویدیویی نهفته را می‌دهد.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایندگی داده‌های ویدئویی و فریم‌های ویدئویی، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) و دیگر انواع مرتبط را فراهم می‌کند.

## **ایجاد فریم ویدیویی جاسازی شده**

اگر فایل ویدئویی‌ای که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال یک ویدئوی محلی را در اولین اسلاید یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان (stream) تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) آن را در حالی که ارائه از آن استفاده می‌کند، قفل نگه می‌دارد.

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

همچنین می‌توانید مسیر ویدئوی محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) پاس بدهید. این مثال ویدیو را در اولین اسلاید یک ارائه جدید جاسازی می‌کند. ویدیو باید تا زمانی که ارائه ذخیره شود، در دسترس بماند.

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

## **ایجاد فریم ویدیویی با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید یک فریم ویدئویی ایجاد کنید که به یک ویدیو آنلاین، مانند ویدیوهای YouTube، پیوند داشته باشد.

این مثال یک پیوند ویدئوی YouTube و تصویر بندانگشتی آن را به اولین اسلاید اضافه می‌کند. شناسه ویدیو را تعویض کنید تا از ویدیو دیگری استفاده کنید. متد [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) پخش خودکار را درخواست می‌کند. دریافت تصویر بندانگشتی و پخش ویدیو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید از پخش ویدیوهای آنلاین پشتیبانی کند.

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

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک دمو نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطبان جزئیات را ببینند. برای فعال‌سازی این رفتار در هنگام پخش، [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) را با `true` فراخوانی کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید داشته باشد که فریم ویدئویی موجود در اولین اسلاید باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به‌صورت مستقل، [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) تعیین می‌کند که آیا پخش به‌صورت خودکار یا با کلیک آغاز شود، و [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto یا VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدیو دمو به آغاز آن باعث می‌شود برای ارائه‌دهنده آماده‌ی پخش مجدد شود. برای بازگرداندن ویدیو به ابتدا پس از اتمام پخش، [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) را با `true` فراخوانی کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و بازگرداندن را فعال می‌کند. حلقه‌زدن را غیرفعال می‌کند تا پخش بتواند به پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که فریم ویدئویی موجود در اولین اسلاید باشد.

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

بازگرداندن ویدیو را به ابتدای آن برمی‌گرداند بدون اینکه دوباره 시작 شود. برعکس، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) با `true` باعث تکرار خودکار پخش می‌شود. وقتی می‌خواهید ویدیو به پایان برسد و آماده‌ی پخش مجدد باشد، حلقه‌زدن را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) به‌طور مستقل راه‌اندازی خودکار یا با کلیک را کنترل می‌کند؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. حالت پخش را پس از تنظیم حلقه، همان‌طور که در مثال نشان داده شده، تنظیم کنید. بازگرداندن به‌طور مستقل از [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) عمل می‌کند.

## **برش فریم ویدئویی**

از [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) برای حذف بخشی از ابتدای یا انتهای یک ویدیو در هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدئوی نهفته تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدئوی محلی را جاسازی می‌کند و اولین ۲٫۵ ثانیه و آخرین یک ثانیه را در هنگام پخش حذف می‌کند. از یک ویدئوی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**خواندن تنظیمات برش**

این مثال مقادیر برش اولین فریم ویدئویی در اولین اسلاید را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در قالب WebVTT ذخیره شده و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

### **افزودن زیرنویس به فریم ویدئویی**

این مثال یک ویدئوی محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌بندهای زیرنویس باید با ویدیو مطابقت داشته باشند. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) همچنین یک overload را فراهم می‌کند که به شما امکان افزودن زیرنویس‌ها از یک جریان (stream) را می‌دهد.

### **استخراج زیرنویس‌ها از فریم ویدئویی**

این مثال تمام مسیرهای زیرنویس از فریم‌های ویدئویی در اولین اسلاید را به‌صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های متوالی خروجی‌ها را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

هر شیء [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) شناساگر زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت رشته UTF-8 نمایش می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدئویی**

این مثال تمام زیرنویس‌ها را از فریم ویدئویی در اولین موقعیت شکل در اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک فریم ویدئویی است.

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

اگر نیاز به حذف فقط یک مسیر زیرنویس دارید، به‌جای [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) از متدهای [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) استفاده کنید.

### **جستجوی زیرنویس‌های ویدئویی**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) کل مسیر WebVTT را بر می‌گرداند، شامل سرصفحه، خطوط زمان‌بندی و متن زیرنویس. می‌توانید نشانه‌ها (cues) را در حافظه جستجو کنید تا یک عبارت گفتاری و زمان‌بندی آن را پیدا کنید. برای مثال، یک مسیر انگلیسی در اسلاید ۲ ممکن است متن زیر را داشته باشد.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

مثال فایل `captioned_media.pptx` را باز می‌کند و از [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) برای خواندن مسیرهای هر فریم ویدئویی سطح بالا در هر اسلاید استفاده می‌کند. در یک cue متنی ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی cue را پایان می‌دهد. وقتی زیرنویس شامل «café» در هر نوع حروف باشد، مثال شماره اسلاید، برچسب مسیر، خط زمان‌بندی اصلی و کل زیرنویس را چاپ می‌کند.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

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
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
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

جستجو برای «café» یک تطابق برای مسیر نمونه تولید می‌کند. جستجو سرصفحه مسیر را حذف می‌کند و تنظیم زمان‌بندی را در خروجی حفظ می‌کند.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به فایل‌های باینری جداگانه و شماره‌دار استخراج می‌کند. ویدیوهای پیوندشده نادیده گرفته می‌شوند زیرا داده‌های جاسازی‌شده ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت لزوم آن را به‌گونه‌ای تغییر دهید که با نوع رسانه گزارش‌شده هم‌خوانی داشته باشد.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک فریم ویدئویی تغییر کنند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (خودکار یا با کلیک) و [حلقه‌زدن](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین حجم ارائه به نسبت حجم فایل رشد می‌کند. وقتی به یک ویدئوی آنلاین پیوند می‌دهید و تصویر بندانگشتی اضافه می‌کنید، ارائه فقط پیوند و تصویر پیش‌نمایش را ذخیره می‌کند نه داده‌های ویدئو، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدئویی موجود جایگزین کنم بدون تغییر موقعیت و اندازه آن؟**

بله. می‌توانید [محتوای ویدیو](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) را درون فریم تعویض کنید در حالی که هندسه شکل را حفظ می‌کنید؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [نوع محتوا](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را خوانده و استفاده کنید، برای مثال هنگام ذخیره‌سازی در دیسک.