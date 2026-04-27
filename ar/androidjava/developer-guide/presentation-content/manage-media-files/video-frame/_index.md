---
title: إدارة إطارات الفيديو في العروض التقديمية على Android
linktitle: إطار الفيديو
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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. دليل سريع خطوة بخطوة."
---
يمكن للفيديو الموضوع في المكان المناسب داخل العرض التقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستوى التفاعل مع جمهورك. 

PowerPoint يسمح لك بإضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation)class.
1. الحصول على مرجع الشريحة عبر فهرسها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض التقديمي المُعدَّل. 

هذا كود Java يوضح لك كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```java
// ينشئ كائن من فئة Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // يحمل الفيديو
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // يحصل على الشريحة الأولى ويضيف إطار فيديو
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // يحفظ العرض التقديمي إلى القرص
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


## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) يدعم مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الإلكتروني الخاص به. 

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation)class
1. الحصول على مرجع الشريحة عبر فهرسها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

هذا كود Java يوضح لك كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```java
// ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي
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

## **إدارة تسميات الفيديو**

Aspose.Slides تسمح لك بإدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بصيغة WebVTT وتتوفر عبر الطريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**إضافة تسميات إلى إطار الفيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) class.
1. إضافة فيديو إلى العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) إلى شريحة.
1. استخدام [ICaptionsCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/) المسترجعة من [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) لإضافة مسار تسميات WebVTT.
1. حفظ العرض التقديمي المعدل.

الكود التالي يوضح لك كيفية إضافة تسميات إلى إطار فيديو:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // يضيف مسار تسميات جديد من ملف WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/) توفر أيضًا نسخة تحميل تسمح لك بإضافة تسميات من تدفق بيانات.

**استخراج تسميات من إطار الفيديو**

لاستخراج تسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. العثور على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) الهدف.
1. التكرار عبر مسارات التسميات المسترجعة من [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. حفظ كل مسار تسمية في ملف `.vtt`.

الكود التالي يوضح لك كيفية استخراج تسميات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // يحفظ مسار التسميات إلى ملف WebVTT.
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

كل كائن [ICaptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptions/) يُظهر معرّف التسمية، التسمية، البيانات الثنائية، وبيانات التسمية كسلسلة UTF-8.

**إزالة تسميات من إطار الفيديو**

لإزالة تسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. الحصول على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) الهدف.
1. إزالة مسارات التسميات من المجموعة المسترجعة من [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. حفظ العرض التقديمي المعدل.

الكود التالي يوضح لك كيفية إزالة جميع التسميات من إطار فيديو:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // يزيل جميع التسميات من إطار الفيديو.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم الطرق [remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) بدلاً من [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **استخراج فيديو من شريحة**

إلى جانب إضافة فيديوهات إلى الشرائح، تسمح لك Aspose.Slides باستخراج الفيديوهات المدمجة في العروض التقديمية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/).
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/).
4. حفظ الفيديو إلى القرص.

هذا كود Java يوضح لك كيفية استخراج الفيديو من شريحة عرض تقديمي:

```java
// ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي 
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

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بدمج فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما تضيف فيديو عبر الإنترنت، يُدمج الرابط وصورة مصغرة فقط، لذا يكون الزيادة أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. للفيديو المدمج نوع محتوى [content type](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.