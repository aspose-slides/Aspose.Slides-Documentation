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
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای جاوا اضافه و استخراج کنید. راهنمای سریع گام به گام."
---
## **مقدمه**

یک ویدیو به‌طور مناسب در یک ارائه می‌تواند پیام شما را قانع‌کننده‌تر کند و سطح تعامل با مخاطبان را افزایش دهد. 

PowerPoint به شما اجازه می‌دهد ویدیوها را به یک اسلاید در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدیو محلی (ذخیره شده بر روی دستگاه شما)
* افزودن یک ویدیو آنلاین (از منبع وبی مانند یوتیوب).

برای افزودن ویدیوها (اشیاء ویدیو) به یک ارائه، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) و انواع مرتبط دیگر را فراهم می‌کند. 

## **ایجاد فریم‌های ویدیو جاسازی‌شده**

اگر فایل ویدیو که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدیو را برای جاسازی ویدیو در ارائه پاس بدهید. 
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) اضافه کنید تا فریمی برای ویدیو ایجاد شود.  
1. ارائه اصلاح‌شده را ذخیره کنید. 

این کد Java نشان می‌دهد چگونه یک ویدیو ذخیره‌شده به صورت محلی را به یک ارائه اضافه کنید:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("pres.pptx");
try {
    // ویدیو را بارگذاری می‌کند
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // اسلاید اول را دریافت می‌کند و یک فریم ویدیو اضافه می‌نماید
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

به‌طور جایگزین، می‌توانید ویدیو را با پاس دادن مستقیم مسیر فایل آن به متد [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) اضافه کنید:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **ایجاد فریم‌های ویدیو با ویدیو از منابع وب**

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدیوهای یوتیوب در ارائه‌ها پشتیبانی می‌کند. اگر ویدیویی که می‌خواهید استفاده کنید به‌صورت آنلاین در دسترس باشد (مثلاً در یوتیوب)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideo/) اضافه کنید و لینک ویدیو را پاس بدهید.
1. تصویر بندانگشتی برای فریم ویدیو تنظیم کنید. 
1. ارائه را ذخیره کنید. 

این کد Java نشان می‌دهد چگونه یک ویدیو از وب را به یک اسلاید در ارائه PowerPoint اضافه کنید:

```java
// یک شیء Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است 
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

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) در دسترس هستند.

**افزودن زیرنویس به یک فریم ویدیو**

برای افزودن زیرنویس به یک فریم ویدیو:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ویدیو به ارائه اضافه کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) را به یک اسلاید اضافه کنید.
1. از [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) که توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) برگردانده می‌شود استفاده کنید تا یک ردیف زیرنویس WebVTT اضافه کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک فریم ویدیو اضافه کنید:

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

**استخراج زیرنویس‌ها از یک فریم ویدیو**

برای استخراج زیرنویس‌ها از یک فریم ویدیو:

1. ارائه‌ای که حاوی ویدیو است را بارگذاری کنید.
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) هدف را پیدا کنید.
1. از طریق ردیف‌های زیرنویس در [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) پیمایش کنید.
1. هر ردیف زیرنویس را در یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از یک فریم ویدیو استخراج کنید:

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

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت رشته UTF-8 ارائه می‌دهد.

**حذف زیرنویس‌ها از یک فریم ویدیو**

برای حذف زیرنویس‌ها از یک فریم ویدیو:

1. ارائه‌ای که حاوی ویدیو است را بارگذاری کنید.
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivideoframe/) هدف را دریافت کنید.
1. ردیف‌های زیرنویس را از [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) حذف کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه همه زیرنویس‌ها را از یک فریم ویدیو حذف کنید:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // تمام زیرنویس‌ها را از فریم ویدیو حذف می‌کند.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر نیاز دارید تنها یک ردیف زیرنویس را حذف کنید، به‌جای [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#clear--)، از متدهای [remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#removeAt-int-) استفاده کنید.

## **استخراج ویدیو از اسلایدها**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید تا ارائه حاوی ویدیو را بارگذاری کنید. 
2. از تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) پیمایش کنید.
3. از تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/) پیدا کنید. 
4. ویدیو را بر روی دیسک ذخیره کنید.

این کد Java نشان می‌دهد چگونه ویدیو موجود در یک اسلاید ارائه را استخراج کنید:

```java
// یک شیء Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است 
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

**کدام پارامترهای پخش ویدیو می‌توانند برای VideoFrame تغییر کنند؟**

شما می‌توانید حالت [پخش](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/#setPlayMode-int-) (خودکار یا با کلیک) و [حلقه‌دار کردن](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو بر اندازه فایل PPTX تأثیر می‌گذارد؟**

بله. زمانی که یک ویدیو محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی یک ویدیو آنلاین اضافه می‌کنید، فقط یک لینک و تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش اندازه کمتر است.

**آیا می‌توانم ویدیو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [ویدیو](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) را داخل فریم تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو جاسازی‌شده را تعیین کرد؟**

بله. یک ویدیو جاسازی‌شده دارای یک [نوع محتوا](https://reference.aspose.com/slides/fa/java/com.aspose.slides/video/#getContentType--) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.