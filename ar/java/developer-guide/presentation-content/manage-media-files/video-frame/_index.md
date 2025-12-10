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
- إطار الفيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. دليل سريع خطوة بخطوة."
---

يمكن لمقاطع الفيديو الموضوعة بشكل جيد في عرض تقديمي أن تجعل رسالتك أكثر إقناعًا وتزيد من مستويات التفاعل مع جمهورك.

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لسماحك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، يوفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطارات فيديو مدمجة**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع شريحة عبر فهرستها.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) ومرّر مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. احفظ العرض التقديمي المعدل.

يعرض لك هذا الشيفرة Java كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
```java
// ينشئ فئة Presentation
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


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى الطريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **إنشاء إطارات فيديو مع فيديو من مصادر الويب**

تدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (على سبيل المثال على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابطه على الويب.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
1. احصل على مرجع شريحة عبر فهرستها.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) ومرّر الرابط إلى الفيديو.
1. حدد صورة مصغرة لإطار الفيديو.
1. احفظ العرض التقديمي.

يعرض لك هذا الشيفرة Java كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint التقديمي:
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
    // يضيف videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // يحمل الصورة المصغرة
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


## **استخراج الفيديو من الشرائح**

بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، يتيح لك Aspose.Slides استخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التنقل عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/).
3. التنقل عبر جميع كائنات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).
4. احفظ الفيديو إلى القرص.

يعرض لك هذا الشيفرة Java كيفية استخراج الفيديو من شريحة عرض تقديمي:
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

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو (VideoFrame)؟**  
يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**  
نعم. عندما تقوم بتضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما تضيف فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**  
نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**  
نعم. للفيديو المدمج [نوع محتوى](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.