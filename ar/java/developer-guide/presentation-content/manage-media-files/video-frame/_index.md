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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Java. دليل سريع خطوة بخطوة."
---
يمكن للفيديو المناسب في العرض التقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك.

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/)، وأنواع أخرى ذات صلة.

## **إنشاء إطارات فيديو مدمجة**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation)class.
1. احصل على مرجع الشريحة عبر فهرستها. 
1. أضف كائنًا من نوع [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/) ومرر مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي. 
1. أضف كائنًا من نوع [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. احفظ العرض التقديمي المعدل. 

يعرض لك هذا الشيفرة Java كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```java
// إنشاء كائن من الفئة Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // تحميل الفيديو
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // الحصول على الشريحة الأولى وإضافة إطار فيديو
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // حفظ العرض التقديمي على القرص
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى الطريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **إنشاء إطارات فيديو باستخدام فيديو من مصادر ويب**

يدعم Microsoft [PowerPoint 2013 والأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الإلكتروني الخاص به.

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation)class
1. احصل على مرجع الشريحة عبر فهرستها. 
1. أضف كائنًا من نوع [IVideo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideo/) ومرر الرابط إلى الفيديو.
1. حدد صورةً مصغرة لإطار الفيديو. 
1. احفظ العرض التقديمي. 

يعرض لك هذا الشيفرة Java كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint التقديمي:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
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
    // إضافة إطار فيديو
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // تحميل الصورة المصغرة
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

## **إدارة تسميات الفيديو**

تسمح لك Aspose.Slides بإدارة التسميات التوضيحية المغلقة لإطارات الفيديو في عروض PowerPoint التقديمية. يتم تخزين التسميات بتنسيق WebVTT وتُعرض عبر الطريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) class.
1. أضف فيديو إلى العرض التقديمي.
1. أضف كائنًا من نوع [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) إلى شريحة.
1. استخدم [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/) التي تُرجعها [getCaptionTracks](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) لإضافة مسار تسمية WebVTT.
1. احفظ العرض التقديمي المعدل.

يوضح لك الشيفرة التالية كيفية إضافة تسميات إلى إطار فيديو:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // إضافة مسار تسميات جديد من ملف WebVTT.
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر واجهة [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/) أيضًا نسخة مفرطة تسمح لك بإضافة تسميات من تدفق بيانات.

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:

1. حمِّل العرض التقديمي الذي يحتوي على الفيديو.
1. ابحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) المستهدف.
1. تجول عبر مسارات التسميات في [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/).
1. احفظ كل مسار تسمية إلى ملف `.vtt`.

يوضح لك الشيفرة التالية كيفية استخراج التسميات من إطار فيديو:

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

كل كائن [ICaptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptions/) يعرض معرف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:

1. حمِّل العرض التقديمي الذي يحتوي على الفيديو.
1. احصل على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) المستهدف.
1. أزل مسارات التسميات من [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/).
1. احفظ العرض التقديمي المعدل.

يوضح لك الشيفرة التالية كيفية إزالة جميع التسميات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // إزالة جميع التسميات من إطار الفيديو.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم الطريقة [remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#removeAt-int-) بدلاً من [clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#clear--).

## **استخراج الفيديو من الشرائح**

بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) class لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. تجول عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/).
3. تجول عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/). 
4. احفظ الفيديو على القرص.

يعرض لك هذا الشيفرة Java كيفية استخراج الفيديو من شريحة عرض تقديمي:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
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

                // الحصول على امتداد الملف
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

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُضمّن البيانات الثنائية في المستند، لذا يزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عند إضافة فيديو عبر الإنترنت، يُضمّن رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. يحتوي الفيديو المضمن على [نوع محتوى](https://reference.aspose.com/slides/ar/java/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.