---
title: "مدیریت فریم‌های ویدیو در ارائه‌ها بر روی اندروید"
linktitle: "فریم ویدیو"
type: docs
weight: 10
url: /fa/androidjava/video-frame/
keywords:
- اضافه کردن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- فریم ویدیو
- منبع وب
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یادگیری برنامه‌نویسی برای افزودن و استخراج فریم‌های ویدیو به صورت برنامه‌نویسی در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java. راهنمای سریع و گام‌به‌گام."
---
## **معرفی**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کرده و مخاطبان را جذب کنند. Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیو توکار را استخراج کنید.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایاندن داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) ، [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌آورد.

## **ایجاد فریم ویدیو توکار**

اگر فایل ویدیویی که می‌خواهید به اسلاید اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود تعبیه کنید.

این مثال یک ویدیو محلی را در اولین اسلاید یک ارائه موجود تعبیه می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب نقطه (points) است. جریان (stream) تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) آن را در حالی که ارائه از آن استفاده می‌کند قفل نگه می‌دارد.

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

همچنین می‌توانید مسیر ویدیوی محلی را مستقیم به متد [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) بدهید. این مثال ویدیو را در اولین اسلاید یک ارائهٔ جدید تعبیه می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه در دسترس بماند.

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

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، پیوند دارد.

این مثال پیوند ویدیو YouTube و تصویر بندانگشتی آن را به اولین اسلاید اضافه می‌کند. برای استفاده از ویدیو دیگری، شناسه ویدیو را تغییر دهید. متد [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) درخواست پخش خودکار را می‌کند. دانلود تصویر بندانگشتی و پخش ویدیو به دسترسی به اینترنت نیاز دارد. نمایشگر ارائه نیز باید پخش ویدیوهای آنلاین را پشتیبانی کند.

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

در یک ارائه آموزشی، می‌توانید یک دموی نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. با فراخوانی [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) با مقدار `true` این رفتار را در حین پخش فعال می‌کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائهٔ ورودی باید حداقل یک اسلاید با فریم ویدیو موجود در اولین اسلاید داشته باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به‌طور مستقل، [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود و [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) تعیین می‌کند که آیا حلقه شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto یا VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **برگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدیو دموی به ابتدای خود باعث می‌شود برای ارائه‌کننده آماده پخش مجدد باشد. با فراخوانی [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) با مقدار `true` ویدیو پس از پایان پخش به ابتدای خود بازمی‌گردد.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و بازگردانی را فعال می‌سازد. حلقه‌پذیری را غیرفعال می‌کند تا پخش بتواند به پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائهٔ ورودی باید حداقل یک اسلاید با فریم ویدیو موجود در اولین اسلاید داشته باشد.

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

بازگردانی ویدیو را به ابتدای آن می‌برد بدون اینکه دوباره شروع شود. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) با مقدار `true` پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدیو به پایان برسد و آمادهٔ بازپخش بماند، حلقه‌پذیری را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) به‌صورت مستقل کنترل شروع خودکار یا با کلیک را بر عهده دارد؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌کننده زمان شروع پخش را تعیین کند. تنظیم حالت پخش پس از تنظیم حلقه، همان‌طور که در مثال نشان داده شده، انجام می‌شود. بازگردانی به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) عمل می‌کند.

## **قصر (Trim) فریم ویدیو**

از [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) برای گذر زمان بخشی از ابتدای یا انتهای ویدیو در حین پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. قصر (Trim) تنظیمات پخش را بدون تغییر داده‌های ویدیو توکار تغییر می‌دهد.

**تنظیمات قصر**

این مثال یک ویدیو محلی را تعبیه می‌کند و در حین پخش اولین ۲٫۵ ثانیه و آخرین یک ثانیه را نادیده می‌گیرد. از ویدیویی با طول بیش از ۳٫۵ ثانیه استفاده کنید تا بخش قابل پخش باقی بماند.

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

**خواندن تنظیمات قصر**

این مثال مقادیر قصر فریم ویدیو اول در اولین اسلاید را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته (closed captions) برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

**افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را تعبیه می‌کند و یک ردیف زیرنویس WebVTT با عنوان English اضافه می‌نماید. برچسب‌های زمانی زیرنویس باید با ویدیو هم‌خوانی داشته باشند. ارائهٔ ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن می‌شود.

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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) همچنین یک overload دارد که به شما امکان می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمامی ردیف‌های زیرنویس را از فریم‌های ویدیو در اولین اسلاید به‌صورت فایل‌های جداگانهٔ WebVTT ذخیره می‌کند. شماره‌گذاری ترتیبی فایل‌های خروجی را متمایز نگه می‌دارد. کنسول تعداد ردیف‌های استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت رشته UTF-8 در دسترس قرار می‌دهد.

**حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمامی زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدیو باشد.

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

اگر نیاز به حذف تنها یک ردیف زیرنویس دارید، به جای [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) از متدهای [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیو به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدیوهای تعبیه‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای تعبیه‌شده را از هر اسلاید به فایل‌های باینری شماره‌دار جداگانه استخراج می‌کند. ویدیوهای پیوندی (linked) نادیده گرفته می‌شوند زیرا دادهٔ تعبیه‌شده‌ای ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز می‌توانید آن را مطابق با نوع رسانهٔ گزارش‌شده تغییر دهید.

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

## **سؤالات متداول**

**کدام پارامترهای پخش ویدیو می‌تواند برای یک فریم ویدیو تغییر یابد؟**

می‌توانید [حالت پخش](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto یا on click) و [حلقه‌پذیری](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو باعث افزایش حجم فایل PPTX می‌شود؟**

بله. وقتی یک ویدیو محلی را تعبیه می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه به نسبت اندازهٔ فایل افزایش می‌یابد. وقتی به یک ویدیو آنلاین پیوند می‌دهید و تصویر پیش‌نمایش اضافه می‌کنید، ارائه فقط پیوند و تصویر پیش‌نمایش را ذخیره می‌کند نه دادهٔ ویدیو، بنابراین افزایشت حجم معمولاً کمتر است.

**آیا می‌توان ویدیو در یک فریم ویدیو موجود را بدون تغییر موقعیت و اندازه‌اش جایگزین کرد؟**

بله. می‌توانید محتوای [ویدیو](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) را داخل فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این سناریوی رایجی برای به‌روزرسانی رسانه در یک طرح‌بندی موجود است.

**آیا می‌توان نوع محتوا (MIME) ویدیو توکار را تعیین کرد؟**

بله. یک ویدیو توکار دارای [نوع محتوا](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.