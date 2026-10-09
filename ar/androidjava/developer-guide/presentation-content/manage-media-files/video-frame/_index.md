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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Android عبر Java. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في توضيح الأفكار وجذب جمهور. يتيح Aspose.Slides for Android via Java إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة الترجمات، واستخراج بيانات الفيديو المضمّن.

يدعم PowerPoint مقاطع الفيديو المحلية وروابط الفيديوهات على الإنترنت، مثل مقاطع YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

يقوم هذا المثال بتضمين فيديو محلي في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدة النقاط. يبقى التيار مفتوحًا حتى ينتهي الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) يبقيه مقفلاً أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرةً إلى الدالة [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). يضمّن هذا المثال الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

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

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يرتبط بفيديو على الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. تطلب طريقة [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) تشغيلًا تلقائيًا. يتطلب تحميل الصورة المصغرة وتشغيل الفيديو اتصالًا بالإنترنت. يجب أن يدعم عارض العروض التقديمية تشغيل الفيديو عبر الإنترنت أيضًا.

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

في عرض تدريبي، يمكنك تشغيل عرض توضيحي للبرمجيات في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ الدالة [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) مع القيمة `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، ويجد أول [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

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

تتحكم عملية تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، تتحكم طريقة [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم طريقة [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) في ما إذا كان يكرر التشغيل. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تدريبي، إرجاع فيديو الشرح إلى بدايته يجعله جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ الدالة [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) مع القيمة `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعل الإرجاع. يعطل التكرار بحيث يمكن أن ينتهي التشغيل ويضبط بدء التشغيل على النقر. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

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

تُعيد عملية الإرجاع الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، استدعاء الطريقة [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) مع القيمة `true` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. تتحكم الطريقة [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) بشكل مستقل في بدء التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) ليتم التحكم في بدء التشغيل من قبل المقدم. اضبط وضع التشغيل بعد إعداد التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **قص إطار الفيديو**

استخدم الطريقة [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) والطريقة [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بالمللي ثانية. يغيّر القص إعدادات التشغيل دون تعديل بيانات الفيديو المضمّن.

**تعيين إعدادات القص**

يضمّن هذا المثال فيديوًا محليًا ويتخطى أول 2.5 ثانية والثانية الأخيرة أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثوانٍ حتى يبقى جزء قابل للتشغيل.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**قراءة إعدادات القص**

يطبع هذا المثال قيم القص لإطار الفيديو الأول في الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا كانت تلك الشريحة لا تحتوي على إطار فيديو، لن يُطبع شيء. ينتج المثال القيم 2500 و 1000.

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

يسمح Aspose.Slides لك بإدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن الترجمات بتنسيق WebVTT وتُتيح عبر الطريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**إضافة ترجمات إلى إطار فيديو**

يضمّن هذا المثال فيديوًا محليًا ويضيف مسار ترجمة WebVTT مسمى English. يجب أن تتطابق طوابع الترجمة مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وترجماته.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) أيضًا نسخة محملة تسمح لك بإضافة ترجمات من تيار (stream).

**استخراج الترجمات من إطار فيديو**

يحفظ هذا المثال جميع مسارات الترجمات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. الأرقام المتسلسلة تحافظ على تميز ملفات الإخراج. يُظهر سطر الأوامر عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

كل كائن من نوع [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) يُظهر معرف الترجمة، التسمية، البيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

**إزالة الترجمات من إطار فيديو**

يُزيل هذا المثال جميع الترجمات من إطار الفيديو في الموضع الأول على الشريحة الأولى ويحفظ النتيجة. يُفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

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

إذا كنت بحاجة إلى إزالة مسار ترجمة واحد فقط، استخدم الطريقة [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) أو الطريقة [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) بدلاً من الطريقة [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) .

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، يتيح Aspose.Slides استخراج الفيديوهات المضمّنة في العروض التقديمية.

يستخرج هذا المثال الفيديوهات المضمّنة من كل شريحة إلى ملفات ثنائية مرقمة منفصلة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمّنة. يطبع سطر الأوامر نوع MIME لكل فيديو وإجمالي عدد الفيديوهات. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المذكور إذا لزم الأمر.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
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

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). هذه الخيارات متاحة عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) .

**هل يضيف إضافة فيديو حجمًا إلى ملف PPTX؟**

نعم. عندما تُضمّن فيديوًا محليًا، تُدرج البيانات الثنائية في المستند، فيزداد حجم العرض التقديمي بنسبة حجم الملف. عندما ترتبط بفيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة عادةً أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع محتوى](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.