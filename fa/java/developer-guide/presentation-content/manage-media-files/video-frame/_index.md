---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از جاوا
linktitle: فریم ویدئو
type: docs
weight: 10
url: /fa/java/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- بازیابی ویدئو
- فریم ویدئو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یادگیری برنامه‌نویسی برای افزودن و استخراج فریم‌های ویدئویی در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

یک ویدئوی مناسب در ارائه می‌تواند پیام شما را جذاب‌تر کند و سطح مشارکت مخاطبان را افزایش دهد.  

PowerPoint به شما اجازه می‌دهد ویدئوها را به یک اسلاید در ارائه به دو طریق اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (در کامپیوتر شما ذخیره شده)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای این‌که بتوانید ویدئوها (اشیای ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.  

## **ایجاد فریم‌های ویدئویی توکار**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه‌تان جاسازی کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو همراه با ارائه پاس بدهید.  
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) اضافه کنید تا فریم برای ویدئو ایجاد شود.  
1. ارائه تغییر یافته را ذخیره کنید.  

این کد جاوا نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به‌صورت محلی را به یک ارائه اضافه کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("pres.pptx");
try {
    // ویدئو را بارگذاری می‌کند
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // اسلاید اول را دریافت می‌کند و فریم ویدئویی اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

به‌علاوه می‌توانید با عبور مسیر فایل ویدئو به صورت مستقیم به متد [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) یک ویدئو اضافه کنید:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **ایجاد فریم‌های ویدئویی با ویدئو از منابع وب**

Microsoft [PowerPoint 2013 و نسخه‌های جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به‌صورت آنلاین (مثلاً در YouTube) موجود باشد، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) اضافه کنید و لینک ویدئو را پاس بدهید.  
1. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید.  
1. ارائه را ذخیره کنید.  

این کد جاوا نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در ارائه PowerPoint اضافه کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // یک VideoFrame اضافه می‌کند
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // تصویر بندانگشتی را بارگذاری می‌کند
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **برش فریم ویدئویی**

Aspose.Slides به شما اجازه می‌دهد بخش قابل پخش ویدئو را با تنظیم مقادیر trim‑from‑start و trim‑from‑end از طریق [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) کنترل کنید. هر دو مقدار بر حسب میلی‌ثانیه مشخص می‌شوند و به ترتیب زمان صرف‌نظر شده از ابتدا و انتهای ویدئو را تعریف می‌کنند. این تنظیمات فقط تنظیمات پخش ویدئو را در ارائه تغییر می‌دهند؛ دادهٔ باینری ویدئوی توکار را برش یا تغییر نمی‌دهند.  

**تنظیمات برش**

برای ایجاد یک فریم ویدئویی و تنظیم برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.  
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) به ارائه اضافه کنید.  
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.  
1. مقدارهای trim‑from‑start و trim‑from‑end را از طریق [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) تنظیم کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

کد زیر ۲٫۵ ثانیهٔ اولیه و یک ثانیهٔ انتهایی یک ویدئوی توکار را هنگام پخش نادیده می‌گیرد:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**خواندن تنظیمات برش**

برای بررسی تنظیمات برش موجود، ارائه‌ای را بارگذاری کنید، شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) را در میان اشکال اسلاید اول پیدا کنید و مقادیر را از طریق [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) و [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--) بخوانید.  

کد زیر اولین فریم ویدئویی را در اسلاید اول پیدا می‌کند و تنظیمات برش آن را بر حسب میلی‌ثانیه گزارش می‌دهد:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بستهٔ ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها به فرمت WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.  

**افزودن زیرنویس به فریم ویدئویی**

برای افزودن زیرنویس به فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.  
1. یک ویدئو به ارائه اضافه کنید.  
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.  
1. از [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) که توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) بازگردانده می‌شود، برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک فریم ویدئویی اضافه کنید:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // یک مسیر زیرنویس جدید از یک فایل WebVTT اضافه می‌کند.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) همچنین یک overload دارد که امکان افزودن زیرنویس‌ها از یک جریان (stream) را می‌دهد.  

**استخراج زیرنویس از فریم ویدئویی**

برای استخراج زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای را که شامل ویدئو است بارگذاری کنید.  
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) هدف را پیدا کنید.  
1. از طریق [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) مسیرهای زیرنویس را مرور کنید.  
1. هر مسیر زیرنویس را در یک فایل `.vtt` ذخیره کنید.  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // مسیر زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به‌صورت رشتهٔ UTF‑8 ارائه می‌دهد.  

**حذف زیرنویس از فریم ویدئویی**

برای حذف زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای را که شامل ویدئو است بارگذاری کنید.  
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) هدف را دریافت کنید.  
1. مسیرهای زیرنویس را از [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) حذف کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // تمام زیرنویس‌ها را از فریم ویدئویی حذف می‌کند.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر فقط یک مسیر زیرنویس را می‌خواهید حذف کنید، به جای [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#clear--) از متدهای [remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#removeAt-int-) استفاده کنید.  

## **استخراج ویدئو از اسلایدها**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای توکار در ارائه‌ها را می‌دهد.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) برای بارگذاری ارائهٔ حاوی ویدئو ایجاد کنید.  
2. از میان تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) مرور کنید.  
3. از میان تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) برای یافتن یک [VideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/) جستجو کنید.  
4. ویدئو را روی دیسک ذخیره کنید.  

```java
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // پسوند فایل را دریافت می‌کند
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**کدام پارامترهای پخش ویدئو برای VideoFrame قابل تغییر هستند؟**  

شما می‌توانید حالت پخش [playback mode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/#setPlayMode-int-) (خودکار یا با کلیک) و حلقه‌زدن [looping](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/) در دسترس هستند.  

**آیا افزودن یک ویدئو بر حجم فایل PPTX تأثیر می‌گذارد؟**  

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، دادهٔ باینری آن در سند گنجانده می‌شود؛ بنابراین حجم ارائه به نسبت اندازهٔ فایل افزایشی می‌یابد. وقتی یک ویدئوی آنلاین اضافه می‌کنید، تنها یک لینک و یک تصویر بندانگشتی جاسازی می‌شود، لذا افزایش حجم کمتر است.  

**آیا می‌توانم ویدئو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه‌اش تعویض کنم؟**  

بله. می‌توانید محتوای ویدئویی [video content](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) را داخل فریم تعویض کنید و هندسهٔ شکل را حفظ کنید؛ این سناریوی رایجی برای به‌روزرسانی رسانه در یک طرح موجود است.  

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی توکار را تشخیص داد؟**  

بله. یک ویدئوی توکار دارای یک [content type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی روی دیسک.