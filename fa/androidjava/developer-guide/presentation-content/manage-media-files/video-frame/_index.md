---
title: مدیریت فریم‌های ویدیو در ارائه‌ها در اندروید
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید که به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java اضافه و استخراج کنید. راهنمای سریع قدم‌به‌قدم."
---
## **معرفی**

یک ویدیو به‌خوبی در یک ارائه می‌تواند پیام شما را جذاب‌تر کرده و سطح تعامل با مخاطبان را افزایش دهد. 

PowerPoint به شما امکان می‌دهد که ویدیوها را به اسلایدی در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدیو محلی (ذخیره‌شده بر روی دستگاه شما)
* افزودن یک ویدیو آنلاین (از منبع وبی مانند یوتیوب).

برای این که بتوانید ویدیوها (شیءهای ویدیو) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/)، [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) و سایر نوع‌های مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدیو جاسازی‌شده**

اگر فایل ویدیو که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع اسلاید را از طریق اندیس آن دریافت کنید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدیو را برای جاسازی ویدیو در ارائه پاس دهید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) اضافه کنید تا فریم برای ویدیو ایجاد شود.
1. ارائهٔ تغییر یافته را ذخیره کنید. 

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("pres.pptx");
try {
    // ویدیو را بارگذاری می‌کند
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // اسلاید اول را دریافت می‌کند و یک فریم ویدیو اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

به‌طور جایگزین، می‌توانید با عبور دادن مسیر فایل ویدیو مستقیماً به روش [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) یک ویدیو اضافه کنید:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدیوهای یوتیوب در ارائه‌ها پشتیبانی می‌کند. اگر ویدیویی که می‌خواهید استفاده کنید به‌صورت آنلاین در دسترس باشد (مثلاً در یوتیوب)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید
1. مرجع اسلاید را از طریق اندیس آن دریافت کنید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideo/) اضافه کنید و لینک ویدیو را پاس دهید.
1. یک تصویر بندانگشتی برای فریم ویدیو تنظیم کنید.
1. ارائه را ذخیره کنید. 

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند
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
    // یک فریم ویدیو اضافه می‌کند
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

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته‌شده برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره شده و از طریق روش [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

**افزودن زیرنویس به فریم ویدیو**

برای افزودن زیرنویس به فریم ویدیو:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ویدیو به ارائه اضافه کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) را به اسلاید اضافه کنید.
1. از [ICaptionsCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/) برگشتی توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // یک مسیر زیرنویس جدید را از فایل WebVTT اضافه می‌کند
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که به شما امکان افزودن زیرنویس‌ها از یک جریان را می‌دهد.

**استخراج زیرنویس‌ها از فریم ویدیو**

برای استخراج زیرنویس‌ها از فریم ویدیو:

1. ارائه‌ای که شامل ویدیو است را بارگذاری کنید.
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) هدف را پیدا کنید.
1. از مسیرهای زیرنویس برگشتی توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) عبور کنید.
1. هر مسیر زیرنویس را به یک فایل `.vtt` ذخیره کنید.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // مسیر زیرنویس را به یک فایل WebVTT ذخیره می‌کند.
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

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری، و دادهٔ زیرنویس را به‌صورت رشتهٔ UTF-8 نشان می‌دهد.

**حذف زیرنویس‌ها از فریم ویدیو**

برای حذف زیرنویس‌ها از فریم ویدیو:

1. ارائه‌ای که شامل ویدیو است را بارگذاری کنید.
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) هدف را دریافت کنید.
1. مسیرهای زیرنویس را از مجموعهٔ برگشتی توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) حذف کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // تمام زیرنویس‌ها را از فریم ویدیو حذف می‌کند.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر نیاز دارید تنها یک مسیر زیرنویس را حذف کنید، به‌جای [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#clear--)، از متدهای [remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید تا ارائه حاوی ویدیو را بارگذاری کنید.
2. در تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) پیمایش کنید.
3. در تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/) پیدا کنید.
4. ویدیو را روی دیسک ذخیره کنید.

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

## **سؤالات متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای VideoFrame تغییر یابند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (به‌صورت خودکار یا با کلیک) و [تکرارپذیری](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق خواص شیء [VideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدیو بر اندازهٔ فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شوند، بنابراین اندازهٔ ارائه به نسبت اندازهٔ فایل بزرگ می‌شود. وقتی یک ویدیو آنلاین اضافه می‌کنید، یک لینک و یک تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش اندازه کمتر است.

**آیا می‌توانم ویدیو را در یک VideoFrame موجود جایگزین کنم بدون اینکه موقعیت و اندازهٔ آن تغییر کند؟**

بله. می‌توانید محتوای ویدیو را درون فریم جابجا کنید در حالی که موقعیت و اندازهٔ شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو جاسازی‌شده را تعیین کرد؟**

بله. یک ویدیو جاسازی‌شده دارای یک [نوع محتوا](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی آن روی دیسک.