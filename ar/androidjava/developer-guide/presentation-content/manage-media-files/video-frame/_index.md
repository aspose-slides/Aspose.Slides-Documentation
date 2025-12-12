---
title: إدارة إطارات الفيديو في العروض التقديمية على Android
linktitle: إطار فيديو
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

يمكن للفيديو الموضوع في العرض التقديمي بشكل مناسب أن يجعل رسالتك أكثر جاذبية ويزيد من مستويات التفاعل مع جمهورك.  

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتتمكن من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.  

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
1. الحصول على مرجع الشريحة عبر فهرستها.  
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمينه مع العرض.  
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدل.  

هذا الكود Java يوضح كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
```java
// إنشاء كائن من فئة Presentation
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


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى الطريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):
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

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) يدعم مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثل YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابطه على الويب.  

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
1. الحصول على مرجع الشريحة عبر فهرستها.  
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.  
1. تعيين صورة مصغرة لإطار الفيديو.  
1. حفظ العرض التقديمي.  

هذا الكود Java يوضح كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:
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


## **استخراج الفيديو من شريحة**

إلى جانب إضافة مقاطع فيديو إلى الشرائح، يسمح Aspose.Slides باستخراج الفيديوهات المضمّنة في العروض التقديمية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لتحميل العرض الذي يحتوي على الفيديو.  
2. التجول عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/).  
3. التجول عبر جميع كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).  
4. حفظ الفيديو إلى القرص.  

هذا الكود Java يوضح كيفية استخراج الفيديو من شريحة في عرض تقديمي:
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


## **FAQ**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في وضع التشغيل ([playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)) (تلقائي أو عند النقر) وميزة التكرار ([looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).  

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُدرج البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض بنسبة حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة فقط، لذا يكون الزيادة أصغر.  

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال محتوى الفيديو ([video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.  

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. للفيديو المضمّن نوع محتوى ([content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--)) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.