---
title: إطار الفيديو
type: docs
weight: 10
url: /java/video-frame/
keywords: "إضافة فيديو، إنشاء إطار فيديو، استخراج فيديو، عرض تقديمي في PowerPoint، Java، Aspose.Slides لـ Java"
description: "إضافة إطار فيديو إلى عرض PowerPoint تقديمي في Java"
---

يمكن أن يساعد الفيديو الموضوع بشكل جيد في العرض التقديمي رسالتك في أن تكون أكثر إقناعًا وزيادة مستويات التفاعل مع جمهورك.

تسمح PowerPoint لك بإضافة مقاطع الفيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع الفيديو (كائنات الفيديو) إلى عرض تقديمي، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض التقديمي المعدل.

يوضح لك هذا الكود Java كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

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

بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار الملف مباشرة إلى طريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **إنشاء إطار فيديو مع فيديو من مصدر على الويب**

تدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (على سبيل المثال، على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال رابط الويب الخاص به.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو.
1. حفظ العرض التقديمي.

يوضح لك هذا الكود Java كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```java
// إنشاء كائن Presentation يمثل ملف العرض التقديمي 
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

## **استخراج الفيديو من الشريحة**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، تتيح لك Aspose.Slides استخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التكرار من خلال جميع كائنات [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/).
3. التكرار من خلال جميع كائنات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للبحث عن [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).
4. حفظ الفيديو على القرص.

يوضح لك هذا الكود Java كيفية استخراج الفيديو الموجود على شريحة عرض:

```java
// إنشاء كائن Presentation يمثل ملف العرض التقديمي 
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