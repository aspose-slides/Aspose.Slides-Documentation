---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از جاوا
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/java/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- درج ویدئو
- استخراج ویدئو
- دریافت ویدئو
- فریم ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای جاوا اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides for Java به شما امکان اضافه کردن فریم‌های ویدئویی به اسلایدها، تنظیم تنظیمات پخش، مدیریت زیرنویس‌ها و استخراج داده‌های ویدیوی توکار را می‌دهد.

PowerPoint ویدیوهای محلی و لینک‌های به ویدیوهای آنلاین، مانند ویدیوهای YouTube را پشتیبانی می‌کند.

برای نمایش داده‌های ویدئو و فریم‌های ویدئویی، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئوی توکار**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه خود توکار کنید.

این مثال یک ویدئوی محلی را در اولین اسلاید یک ارائه موجود توکار می‌کند و نتیجه را ذخیره می‌سد. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان باز می‌ماند تا زمان اتمام ذخیره‌سازی زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) آن را در حین استفاده ارائه قفل نگه می‌دارد.

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

همچنین می‌توانید مسیر ویدئوی محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) پاس دهید. این مثال ویدئو را در اولین اسلاید یک ارائه جدید توکار می‌کند. ویدئو باید تا زمان ذخیره‌سازی ارائه قابل دسترس بماند.

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

## **ایجاد یک فریم ویدئویی با ویدئویی از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ویدئوهای آنلاین را در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدئویی ایجاد کنید که به یک ویدئوی آنلاین، مانند یک ویدئوی YouTube، لینک داشته باشد.

این مثال لینک ویدئوی YouTube و تصویر بندانگشت آن را به اولین اسلاید اضافه می‌کند. شناسه ویدئو را تغییر دهید تا ویدئوی دیگری استفاده شود. متد [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) درخواست پخش خودکار را می‌کند. دانلود تصویر بندانگشت و پخش ویدئو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید پخش ویدئو آنلاین را پشتیبانی کند.

```java
import com.aspose.slides.*;
import java.io InputStream;
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

## **پخش یک ویدئو در حالت تمام صفحه**

در یک ارائه آموزشی، می‌توانید یک دموی نرم‌افزاری را در حالت تمام صفحه پخش کنید تا مخاطبان جزئیات را ببینند. با فراخوانی [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) با مقدار `true` این رفتار را در حین پخش فعال کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید با فریم ویدئویی موجود در اولین اسلاید داشته باشد.

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

پخش تمام صفحه نحوه نمایش ویدئو را کنترل می‌کند. به طور مستقل، [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) تعیین می‌کند که آیا پخش به صورت خودکار یا با کلیک شروع شود، و [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **به عقب برگرداندن ویدئوی پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدئوی دموی به ابتدای آن باعث می‌شود برای ارائه‌دهنده آماده پخش دوباره باشد. با فراخوانی [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) با مقدار `true` ویدئو پس از پایان پخش به ابتدای خود باز می‌گردد.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و بازگرداندن را فعال می‌سازد. حلقه‌زدن غیرفعال می‌شود تا پخش بتواند تمام شود و پخش روی کلیک تنظیم می‌شود. ارائه ورودی باید حداقل یک اسلاید با فریم ویدئویی موجود در اولین اسلاید داشته باشد.

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

بازگرداندن ویدئو را به ابتدای آن بر می‌گرداند بدون اینکه دوباره آن را شروع کند. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) با `true` پخش را به صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدئو به پایان برسد و آماده بازپخش بماند، حلقه‌زدن را غیرفعال نگه دارید. متد [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) به‌صورت مستقل کنترل شروع خودکار یا روی کلیک را انجام می‌دهد؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. تنظیم حالت پخش پس از تنظیم حلقه انجام می‌شود، همان‌طور که در مثال نشان داده شده است. بازگرداندن مستقل از [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) کار می‌کند.

## **برش فریم ویدئویی**

از [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) برای چشم‌پوشی از قسمتی از ابتدا یا انتهای ویدئو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدئوی توکار تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدئوی محلی را توکار می‌کند و در هنگام پخش ۲٫۵ ثانیه اول و ۱ ثانیه آخر را نادیده می‌گیرد. از ویدئویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا بخشی قابل پخش باقی بماند.

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

**خواندن تنظیمات برش**

این مثال مقادیر برش فریم ویدئویی اول در اولین اسلاید را برحسب میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در فرمت WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

**افزودن زیرنویس‌ها به فریم ویدئویی**

این مثال یک ویدئوی محلی را توکار می‌کند و یک ترک زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌مکان زیرنویس‌ها باید با ویدئو مطابقت داشته باشد. ارائه ذخیره‌شده شامل هر دو ویدئو و زیرنویس‌های آن می‌شود.

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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) همچنین یک overload دارد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئویی**

این مثال تمام ترک‌های زیرنویس را از فریم‌های ویدئویی اولین اسلاید به عنوان فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های ترتیبی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد ترک‌های استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به صورت رشته UTF-8 نمایش می‌دهد.

**حذف زیرنویس‌ها از فریم ویدئویی**

این مثال تمام زیرنویس‌ها را از فریم ویدئویی در اولین موقعیت شکل در اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود که اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدئویی باشد.

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

اگر فقط نیاز به حذف یک ترک زیرنویس دارید، به جای [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) از متدهای [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) استفاده کنید.

## **استخراج ویدئو از یک اسلاید**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای توکار در ارائه‌ها را می‌دهد.

این مثال ویدئوهای توکار را از هر اسلاید به فایل‌های باینری شماره‌دار جداگانه استخراج می‌کند. ویدئوهای لینک‌شده صرفنظر می‌شوند زیرا داده توکاری ندارند. کنسول نوع MIME هر ویدئو و تعداد کل را چاپ می‌کند. خروجی با پسوند عمومی `.bin` است؛ در صورت نیاز می‌توانید آن را به مطابق با نوع رسانه گزارش‌شده تغییر دهید.

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

## **سؤالات متداول**

**کدام پارامترهای پخش ویدئو برای فریم ویدئویی قابل تغییر هستند؟**

می‌توانید [حالت پخش](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (خودکار یا با کلیک) و [حلقه‌زدن](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو بر اندازه فایل PPTX تأثیر می‌گذارد؟**

بله. زمانی که ویدئوی محلی را توکار می‌کنید، داده باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه به نسبت حجم فایل افزایش می‌یابد. زمانی که به یک ویدئوی آنلاین لینک می‌دهید و تصویر بندانگشتی اضافه می‌کنید، نمایشگر فقط لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه داده ویدئو، لذا افزایش اندازه معمولاً کمتر است.

**آیا می‌توانم ویدئو را در یک فریم ویدئویی موجود بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**

بله. می‌توانید محتویات [ویدئو](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) را درون فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این سناریوی رایج برای به‌روزرسانی رسانه در یک طرح‌بندی موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی توکار را تعیین کرد؟**

بله. یک ویدئوی توکار دارای [نوع محتوا](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.