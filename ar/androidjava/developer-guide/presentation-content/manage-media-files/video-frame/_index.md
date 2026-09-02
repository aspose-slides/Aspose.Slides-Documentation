---
title: "إدارة إطارات الفيديو في العروض التقديمية على Android"
linktitle: "إطار الفيديو"
type: docs
weight: 10
url: /ar/androidjava/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- تضمين فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لأندرويد عبر جافا. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن أن تجعل مقطع الفيديو الموضوع في العرض التقديمي أكثر إقناعًا وتزيد مستويات التفاعل مع الجمهور.

يتيح PowerPoint إضافة مقاطع الفيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع الفيديو (كائنات الفيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. أنشئ مثيلًا من فئة [Presentation ](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation)class.
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) ومرّر مسار ملف الفيديو لتضمينه مع العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. احفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```java
// ينشئ كائن من فئة Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // يحمّل الفيديو
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // يحصل على الشريحة الأولى ويضيف إطار فيديو
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // يحفظ العرض التقديمي على القرص
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **إنشاء إطار فيديو من مصدر ويب**

تدعم الإصدارات الحديثة من Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. إذا كان الفيديو الذي ترغب في استخدامه متاحًا عبر الإنترنت (مثل YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الخاص به.

1. أنشئ مثيلًا من فئة [Presentation ](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation)class
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) ومرّر الرابط إلى الفيديو.
1. اضبط صورة مصغرة لإطار الفيديو.
1. احفظ العرض التقديمي.

يعرض هذا الكود Java كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
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
    // يضيف إطار فيديو
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // يحمّل الصورة المصغرة
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

## **قص إطار فيديو**

تتيح Aspose.Slides التحكم في الجزء الذي يُشغل من الفيديو عن طريق ضبط قيمتي trim‑from‑start وtrim‑from‑end عبر [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). تُحدد القيمتين بالميليثانية وتُعرّف مقدار الوقت الذي يتم تخطيه من بداية الفيديو ونهايته على التوالي. تُغيّر هذه الإعدادات سلوك تشغيل الفيديو في العرض التقديمي؛ ولا تقوم بقطع أو تعديل بيانات الفيديو المضمّنة.

**ضبط إعدادات القص**

لإنشاء إطار فيديو وضبط إعدادات القص الخاصة به:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)class.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) إلى العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) إلى شريحة.
1. اضبط قيمتي trim‑from‑start وtrim‑from‑end عبر [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. احفظ العرض التقديمي المعدل.

المثال التالي يتخطى الثواني 2.5 الأولى والثانية الأخيرة من فيديو مضمّن أثناء التشغيل:

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

**قراءة إعدادات القص**

لفحص إعدادات القص الموجودة، حمّل عرضًا تقديميًا، وابحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) بين الأشكال في الشريحة الأولى، ثم اقرأ القيم عبر [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) و[IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

المثال التالي يجد أول إطار فيديو في الشريحة الأولى ويُبلغ عن إعدادات القص بالميليثانية:

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

## **إدارة ترجمات الفيديو**

تتيح Aspose.Slides إدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن الترجمات بتنسيق WebVTT وتُتاح عبر طريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**إضافة ترجمات إلى إطار فيديو**

لإضافة ترجمات إلى إطار فيديو:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)class.
1. أضف فيديو إلى العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) إلى شريحة.
1. استخدم [ICaptionsCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/) المرتجع من [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) لإضافة مسار ترجة WebVTT.
1. احفظ العرض التقديمي المعدل.

يعرض الكود التالي كيفية إضافة ترجمات إلى إطار فيديو:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // يضيف مسار ترجمات جديد من ملف WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/) أيضًا نسخة زائدة تتيح لك إضافة ترجمات من تدفق بيانات.

**استخراج الترجمات من إطار فيديو**

لاستخراج الترجمات من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
1. ابحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) المستهدف.
1. تكرّر عبر مسارات الترجمات التي تُعيدها [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. احفظ كل مسار ترجة في ملف `.vtt`.

يعرض الكود التالي كيفية استخراج الترجمات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // يحفظ مسار الترجمات إلى ملف WebVTT.
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

كل كائن [ICaptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptions/) يُظهر معرّف الترجة، التسمية، البيانات الثنائية، وبيانات الترجة كسلسلة UTF‑8.

**إزالة الترجمات من إطار فيديو**

لإزالة الترجمات من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
1. احصل على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) المستهدف.
1. أزل مسارات الترجمات من المجموعة التي تُعيدها [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. احفظ العرض التقديمي المعدل.

يعرض الكود التالي كيفية إزالة جميع الترجمات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // يزيل جميع الترجمات من إطار الفيديو.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت تحتاج إلى إزالة مسار ترجة واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) بدلًا من [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **استخراج فيديو من شريحة**

إلى جانب إضافة مقاطع فيديو إلى الشرائح، تتيح Aspose.Slides استخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation)class لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. تكرّر عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/).
3. تكرّر عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/) .
4. احفظ الفيديو إلى القرص.

يعرض هذا الكود Java كيفية استخراج الفيديو من شريحة عرض تقديمي:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي 
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

                // يحصل على امتداد الملف
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

## **الأسئلة المتداولة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في وضع التشغيل ([playback mode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)) (تلقائي أو عند النقر) و[looping](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تُضمّن فيديوًا محليًا، تُدرج البيانات الثنائية في المستند، لذا يزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عند إضافة فيديو عبر الإنترنت، يُضمّن رابط وصورة مصغرة فقط، لذا يكون الارتفاع في الحجم أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على هندسة الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع محتوى](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، مثلاً عند حفظه إلى القرص.