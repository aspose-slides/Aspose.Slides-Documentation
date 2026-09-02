---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام Java
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/java/video-frame/
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
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. دليل سريع عملي."
---
## **المقدمة**

يمكن للفيديو الموضوع في المكان المناسب داخل عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك.

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:
* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/)، والواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/)، وأنواع أخرى ذات صلة.

## **إنشاء إطارات فيديو مدمجة**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation)class.
1. الحصول على مرجع الشريحة عبر فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمينه مع العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدّل.

يعرض لك هذا الكود الجاڤا كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```java
// ينشئ كائن من فئة Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // يقوم بتحميل الفيديو
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

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **إنشاء إطارات فيديو من مصادر ويب**

Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) يدعم مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال رابط الويب الخاص به.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation)class
1. الحصول على مرجع الشريحة عبر فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تحديد صورة مصغرة لإطار الفيديو.
1. حفظ العرض التقديمي.

يعرض لك هذا الكود الجاڤا كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

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

    // يحمِّل الصورة المصغرة
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

Aspose.Slides يسمح لك بالتحكم في الجزء الذي يُشغَّل من الفيديو عن طريق ضبط قيم trim-from-start و trim-from-end عبر [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). تُحدَّد القيمتين بالميليثانية وتعرِّف مقدار الوقت المتSkipped من بداية ونهاية الفيديو على التوالي. هذه الإعدادات تُغيِّر إعدادات تشغيل الفيديو في العرض؛ لا تقوم بقطع أو تعديل بيانات الفيديو المدمجة.

**ضبط إعدادات القص**

لإنشاء إطار فيديو وضبط إعدادات القص الخاصة به:
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)class.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/) إلى العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) إلى شريحة.
1. ضبط قيم trim-from-start و trim-from-end عبر [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. حفظ العرض التقديمي المعدّل.

يقوم مثال الكود التالي بتخطي أول 2.5 ثانية وآخر ثانية من الفيديو المضمن أثناء التشغيل:

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

لتفحص إعدادات القص الحالية، احمل عرضًا تقديميًا، وابحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) بين الأشكال في الشريحة الأولى، واقرأ القيم عبر [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) و[IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

يعثر مثال الكود التالي على أول إطار فيديو في الشريحة الأولى ويعرض إعدادات القص الخاصة به بالميليثانية:

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

## **إدارة تسميات الفيديو**

Aspose.Slides يسمح لك بإدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتُتاح عبر طريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)class.
1. إضافة فيديو إلى العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) إلى شريحة.
1. استخدم [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/) المسترجعة من خلال [getCaptionTracks](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) لإضافة مسار تسمية WebVTT.
1. حفظ العرض التقديمي المعدّل.

يعرض لك الكود التالي كيفية إضافة تسميات إلى إطار فيديو:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // يضيف مسار تسميات جديد من ملف WebVTT.
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر واجهة [ICaptionsCollection] أيضًا نسخة محملة تسمح لك بإضافة تسميات من تدفق.

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:
1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. العثور على كائن [IVideoFrame] المستهدف.
1. التكرار عبر مسارات التسميات في [ICaptionsCollection].
1. حفظ كل مسار تسمية إلى ملف `.vtt`.

يعرض لك الكود التالي كيفية استخراج التسميات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // يحفظ مسار التسميات إلى ملف WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

كل كائن [ICaptions] يكشف عن معرف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:
1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. الحصول على كائن [IVideoFrame] المستهدف.
1. إزالة مسارات التسميات من [ICaptionsCollection].
1. حفظ العرض التقديمي المعدّل.

يعرض لك الكود التالي كيفية إزالة جميع التسميات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // يزيل جميع التسميات من إطار الفيديو.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#removeAt-int-) بدلًا من [clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#clear--).

## **استخراج الفيديو من الشرائح**

بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، يتيح لك Aspose.Slides استخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/).
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/). 
4. حفظ الفيديو إلى القرص.

يعرض لك هذا الكود الجاڤا كيفية استخراج الفيديو من شريحة عرض تقديمي:

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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُضمَّن البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي ب proportion إلى حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة فقط، لذا يكون الارتفاع في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع محتوى](https://reference.aspose.com/slides/ar/java/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.