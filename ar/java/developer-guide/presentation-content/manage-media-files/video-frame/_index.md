---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام Java
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/java/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- دمج فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Java. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب الجمهور. يسمح Aspose.Slides for Java لك بإضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة الترجمات، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint الفيديوهات المحلية وروابط الفيديوهات على الإنترنت، مثل فيديوهات YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) الواجهة [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزّنًا محليًا، يمكنك إنشاء إطار فيديو لدمج الفيديو في عرضك التقديمي.

هذا المثال يدمج فيديو محليًا في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يبقى التدفق مفتوحًا حتى انتهاء الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) يبقيه مقفلًا أثناء استخدام العرض التقديمي له.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا تمرير مسار فيديو محلي مباشرة إلى [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). هذا المثال يدمج الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط إلى فيديو عبر الإنترنت، مثل فيديو YouTube.

هذا المثال يضيف رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرّف الفيديو لاستخدام فيديو آخر. طريقة [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) تطلب التشغيل التلقائي. تنزيل الصورة المصغرة وتشغيل الفيديو يتطلبان اتصالاً بالإنترنت. يجب أن يدعم عارض العروض التقديمية تشغيل الفيديو عبر الإنترنت أيضًا.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تشغيل فيديو في وضع ملء الشاشة**

في عرض تقديمي تعليمي، يمكنك تشغيل عرض توضيحي للبرمجيات في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) مع `true` لتفعيل هذا السلوك أثناء التشغيل.

هذا المثال يفتح عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعل التشغيل بملء الشاشة. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

التحكم في تشغيل ملء الشاشة يحدد كيفية عرض الفيديو. بشكل مستقل، تتحكم [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) فيما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) فيما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). المثال يحافظ على إعدادات البدء والحلقة الحالية.

## **إرجاع الفيديو بعد التشغيل**

في عرض تقديمي تعليمي، إرجاع فيديو العرض إلى بدايته يجعله جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) مع `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

هذا المثال يفتح عرضًا تقديميًا، finds the first [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعل الإرجاع. يقوم بتعطيل الحلقة حتى يمكن للعرض الانتهاء ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الإرجاع يعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) مع `true` يكرر التشغيل تلقائيًا. أبقِ الحلقة معطلة عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) بشكل مستقل في البدء التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم متى يبدأ التشغيل. اضبط وضع التشغيل بعد إعداد الحلقة، كما هو موضح في المثال. الإرجاع يعمل بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **تقليم إطار فيديو**

استخدم [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بوحدات المليثانية. يغيّر التقليم إعدادات التشغيل دون تعديل بيانات الفيديو المضمّن.

**إعدادات التقليم**

هذا المثال يدمج فيديو محليًا ويتخطى الثانيتين والنصف الأولى والثانية الأخيرة أثناء التشغيل. استخدم فيديو أطول من 3.5 ثوانٍ ليبقى جزء قابل للتشغيل.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**قراءة إعدادات التقليم**

هذا المثال يطبع قيم التقليم لإطار الفيديو الأول في الشريحة الأولى بالمليثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يُطبع شيء. المثال السابق ينتج القيم 2500 و1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **إدارة ترجمات الفيديو**

يسمح Aspose.Slides لك بإدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ الترجمات بصيغة WebVTT وتُتاح عبر طريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**إضافة ترجمات إلى إطار فيديو**

هذا المثال يدمج فيديو محليًا ويضيف مسار ترجمة WebVTT معلقًا بـ "English". يجب أن تتطابق طوابع الوقت للترجمة مع الفيديو. يشمل العرض المحفوظ كلًا من الفيديو وترجماته.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

واجهة [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) توفر أيضًا تحميلًا إضافيًا يتيح لك إضافة ترجمات من تدفق.

**استخراج ترجمات من إطار فيديو**

هذا المثال يحفظ جميع مسارات الترجمات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تحافظ الأرقام المتسلسلة على تمييز ملفات الإخراج. يعلن وحدة التحكم عن عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

كل كائن [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) يكشف عن معرّف الترجمة، والملصق، والبيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

**إزالة ترجمات من إطار فيديو**

هذا المثال يزيل جميع الترجمات من إطار الفيديو في الموضع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا احتجت إلى إزالة مسار ترجمة واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) بدلاً من [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **استخراج فيديو من شريحة**

إلى جانب إضافة الفيديوهات إلى الشرائح، يتيح Aspose.Slides لك استخراج الفيديوهات المضمنة في العروض التقديمية.

هذا المثال يستخرج الفيديوهات المضمّنة من كل شريحة إلى ملفات ثنائية منفصلة مرقّمة. تُتخطى الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمنة. يطبع وحدة التحكم نوع MIME لكل فيديو والعدد الإجمالي. يستخدم الناتج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المبلغ عنه عند الحاجة.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تدمج فيديو محلي، تُضمّن البيانات الثنائية في المستند، فيزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما ترتبط بفيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة في الحجم أصغر عادةً.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك تبديل [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. يمتلك الفيديو المدمج [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.