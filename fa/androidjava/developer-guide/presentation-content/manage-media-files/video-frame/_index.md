---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها در اندروید
linktitle: فریم ویدئو
type: docs
weight: 10
url: /fa/androidjava/video-frame/
keywords:
- اضافه کردن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- بازیابی ویدئو
- فریم ویدئو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای اندروید از طریق جاوا، نحوه افزودن و استخراج فریم‌های ویدئویی به‌صورت برنامه‌نویسی در اسلایدهای PowerPoint و OpenDocument را بیاموزید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

یک ویدئوی به‌جا در یک ارائه می‌تواند پیام شما را جذاب‌تر کرده و سطح مشارکت مخاطبان را افزایش دهد.  

PowerPoint به شما دو روش برای افزودن ویدئو به یک اسلاید در ارائه ارائه می‌دهد:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره‌شده در دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای این که بتوانید ویدئوها (اشیای ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/)، [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید.  

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه عبور دهید.  
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) اضافه کنید تا فریمی برای ویدئو ایجاد شود.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

این کد Java نشان می‌دهد چگونه یک ویدئوی محلی را به یک ارائه اضافه کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("pres.pptx");
try {
    // ویدئو را بارگذاری می‌کند
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // اسلاید اول را دریافت می‌کند و یک فریم ویدئویی اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

به‌جای این می‌توانید ویدئو را با عبور مستقیم مسیر فایل آن به متد [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) اضافه کنید:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **ایجاد یک فریم ویدئوی با ویدئویی از منبع وب**

نسخه‌های جدیدتر Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدئوهای آنلاین در ارائه‌ها پشتیبانی می‌کنند. اگر ویدئویی که می‌خواهید استفاده کنید به‌صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/) اضافه کنید و لینک ویدئو را عبور دهید.  
1. برای فریم ویدئو یک تصویر بندانگشتی تنظیم کنید.  
1. ارائه را ذخیره کنید.  

این کد Java نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در یک ارائه PowerPoint اضافه کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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
    // یک فریم ویدئو اضافه می‌کند
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // بارگذاری تصویر بندانگشتی
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

## **قص کردن یک فریم ویدئوی**

Aspose.Slides به شما امکان می‌دهد که بخش‌های پخش ویدئو را از طریق مقادیر trim‑from‑start و trim‑from‑end تنظیم کنید، با استفاده از [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). هر دو مقدار بر حسب میلی‌ثانیه مشخص می‌شوند و میزان زمان صرف‌نظر شده از آغاز و انتهای ویدئو را تعریف می‌کنند. این تنظیمات فقط تنظیمات پخش ویدئو را در ارائه تغییر می‌دهند؛ دادهٔ باینری ویدئوی جاسازی‌شده را قطع یا تغییر نمی‌دهند.

**تنظیمات قص**

برای ایجاد یک فریم ویدئو و تنظیم مقادیر قص آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.  
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/) به ارائه اضافه کنید.  
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.  
1. مقادیر trim‑from‑start و trim‑from‑end را از طریق [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

کد زیر اولین ۲.۵ ثانیه و آخرین ثانیهٔ یک ویدئوی جاسازی‌شده را در زمان پخش نادیده می‌گیرد:

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

**خواندن تنظیمات قص**

برای بررسی تنظیمات قص موجود، یک ارائه را بارگذاری کنید، یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) را در میان اشکال اسلاید اول پیدا کنید و مقادیر را از طریق [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) و [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--) بخوانید.  

کد زیر اولین فریم ویدئویی را در اسلاید اول پیدا می‌کند و تنظیمات قص آن را برحسب میلی‌ثانیه گزارش می‌دهد:

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

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

**افزودن زیرنویس به فریم ویدئویی**

برای افزودن زیرنویس به فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.  
1. یک ویدئو به ارائه اضافه کنید.  
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.  
1. از [ICaptionsCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/) که توسط متد [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) برگردانده می‌شود، برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک فریم ویدئویی اضافه کنید:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/) همچنین یک overload ارائه می‌دهد که به شما امکان می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئویی**

برای استخراج زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.  
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) هدف را پیدا کنید.  
1. در مسیرهای زیرنویس برگردانده‌شده توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) تکرار کنید.  
1. هر مسیر زیرنویس را در یک فایل `.vtt` ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از یک فریم ویدئویی استخراج کنید:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // مسیر زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و دادهٔ متن زیرنویس را به‌صورت یک رشته UTF‑8 نشان می‌دهد.

**حذف زیرنویس‌ها از فریم ویدئویی**

برای حذف زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.  
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) هدف را دریافت کنید.  
1. مسیرهای زیرنویس را از مجموعه‌ای که توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) برگردانده می‌شود، حذف کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از یک فریم ویدئویی حذف کنید:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // تمام زیرنویس‌ها را از فریم ویدئویی حذف می‌کند.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر فقط می‌خواهید یک مسیر زیرنویس را حذف کنید، به‌جای متد [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#clear--) از متدهای [remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) استفاده کنید.

## **استخراج ویدئو از یک اسلاید**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدئوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید تا ارائهٔ حاوی ویدئو را بارگذاری کنید.  
2. تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) را مرور کنید.  
3. تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را مرور کرده و یک [VideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/) پیدا کنید.  
4. ویدئو را بر روی دیسک ذخیره کنید.  

این کد Java نشان می‌دهد چگونه ویدئوی موجود در یک اسلاید ارائه را استخراج کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
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

                //                پسوند فایل را دریافت می‌کند
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

## **سؤال‌های متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای یک VideoFrame تغییر کنند؟**

می‌توانید حالت پخش ([playback mode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)) (خودکار یا با کلیک) و حلقه‌دار بودن ([looping](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو باعث افزایش حجم فایل PPTX می‌شود؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، دادهٔ باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی ویدئوی آنلاین را اضافه می‌کنید، یک لینک و تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش حجم کمتر است.

**آیا می‌توانم ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازهٔ آن جایگزین کنم؟**

بله. می‌توانید محتوای ویدئوی داخل فریم را با استفاده از متد [setEmbeddedVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) تعویض کنید در حالی که شکل هندسی فریم حفظ می‌شود؛ این سناریوی رایجی برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.