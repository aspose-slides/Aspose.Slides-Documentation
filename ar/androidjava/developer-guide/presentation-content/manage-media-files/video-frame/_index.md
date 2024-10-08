---
title: إطار الفيديو
type: docs
weight: 10
url: /ar/androidjava/video-frame/
keywords: "أضف فيديو، أنشئ إطار فيديو، استخراج الفيديو، عرض PowerPoint، جافا، Aspose.Slides لـ Android عبر جافا"
description: "أضف إطار فيديو إلى عرض PowerPoint في جافا"
---

يمكن أن يجعل الفيديو الموضوع بشكل جيد في العرض رسالتك أكثر جاذبية ويزيد من مستويات التفاعل مع جمهورك. 

تتيح لك PowerPoint إضافة مقاطع الفيديو إلى الشريحة في العرض بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو على الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع الفيديو (أجسام الفيديو) إلى عرض تقديمي، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) وأنواع ذات صلة أخرى.

## **إنشاء إطار فيديو مضمن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. أنشئ مثيل من فئة [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها. 
1. أضف كائن [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) ومرر مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. أضف كائن [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. احفظ العرض التقديمي المعدل. 

توضح لك هذه الشيفرة بلغة جافا كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```java
// Instantiates the Presentation class
Presentation pres = new Presentation("pres.pptx");
try {
    // Loads the video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Gets the first slide and adds a videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Saves the presentation to disk
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار ملفه مباشرة إلى الطريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

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

تدعم [Microsoft PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (على سبيل المثال، على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال رابط الويب الخاص به. 

1. أنشئ مثيل من فئة [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها. 
1. أضف كائن [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) ومرر الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. احفظ العرض التقديمي. 

توضح لك هذه الشيفرة بلغة جافا كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```java
// Instantiates a Presentation object that represents a presentation file 
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
    // Adds a videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Loads thumbnail
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

## **استخراج فيديو من الشريحة**

بجانب إضافة مقاطع الفيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لتحميل العرض التقديمي المحتوي على الفيديو.
2. قم بتكرار جميع كائنات [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/).
3. قم بتكرار جميع كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).
4. احفظ الفيديو على القرص.

توضح لك هذه الشيفرة بلغة جافا كيفية استخراج الفيديو الموجود في شريحة عرض تقديمي:

```java
// Instantiates a Presentation object that represents a presentation file 
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

                //Gets the File Extension
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