---
title: إدارة إطارات الفيديو في العروض التقديمية على Android
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. دليل سريع خطوة بخطوة."
---
## **مقدمة**

يمكن للفيديوهات المساعدة في شرح الأفكار وجذب الجمهور. يتيح Aspose.Slides for Android عبر Java إمكانية إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة الترجمات، واستخراج بيانات الفيديو المدمجة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات عبر الإنترنت، مثل فيديوهات YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى الشريحة مخزناً محلياً، يمكنك إنشاء إطار فيديو لدمج الفيديو في العرض التقديمي.

هذا المثال يدمج فيديو محلي في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يبقى تدفق البيانات مفتوحاً حتى ينتهي الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) يبقيه مقفلاً أثناء استخدام العرض التقديمي له.

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

يمكنك أيضاً تمرير مسار الفيديو المحلي مباشرةً إلى [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). يعمل هذا المثال على دمج الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو قابلاً للوصول حتى يتم حفظ العرض التقديمي.

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

هذا المثال يضيف رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. طريقة [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) تطلب تشغيل تلقائي. تنزيل الصورة المصغرة وتشغيل الفيديو يتطلبان اتصالاً بالإنترنت. يجب أن يدعم عارض العرض التقديمي أيضاً تشغيل الفيديو عبر الإنترنت.

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

في عرض تدريبي، يمكنك تشغيل عرض توضيحي للبرمجيات في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) مع `true` لتفعيل هذا السلوك أثناء التشغيل.

هذا المثال يفتح عرضاً تقديمياً، يجد أول [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) في الشريحة الأولى، ويُفَعِّل التشغيل بملء الشاشة. يجب أن يحتوي العرض المُدخل على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

التحكم في التشغيل بملء الشاشة يحدد طريقة عرض الفيديو. بشكل مستقل، تتحكم [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) في ما إذا كان يتكرر. لاختيار سلوك البداية، عيّن وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البداية والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تدريبي، إرجاع فيديو العرض التوضيحي إلى بدايته يجعل الفيديو جاهزًا للمُقدِّم لإعادة تشغيله. استدعِ [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) مع `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

هذا المثال يفتح عرضاً تقديمياً، يجد أول [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) في الشريحة الأولى، ويُفَعِّل الإرجاع. يوقف التكرار حتى يكتمل التشغيل ويضبط التشغيل لتبدأ عند النقر. يجب أن يحتوي العرض المُدخل على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

الإرجاع يعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) مع `true` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويبقى جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) بشكل مستقل في بدء التشغيل تلقائيًا أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) بحيث يتحكم المُقدِّم في توقيت بدء التشغيل. اضبط وضع التشغيل بعد ضبط إعداد التكرار كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **تقليم إطار فيديو**

استخدم [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بوحدات المللي ثانية. يغيّر التقليم إعدادات التشغيل دون تعديل بيانات الفيديو المدمجة.

**تعيين إعدادات التقطيع**

هذا المثال يدمج فيديو محلي ويتخطى أول 2.5 ثانية وآخر ثانية أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية بحيث يبقى مقطع قابل للتشغيل.

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

**قراءة إعدادات التقطيع**

هذا المثال يطبع قيم التقطيع للإطار الفيديو الأول في الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لا يُطبع شيء. ينتج المثال السابق القيم 2500 و1000.

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

يتيح Aspose.Slides لك إدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ الترجمات بصيغة WebVTT وتُعرض عبر طريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **إضافة ترجمات إلى إطار فيديو**

هذا المثال يدمج فيديو محلي ويضيف مسار ترجمة WebVTT مسمى English. يجب أن تتطابق طوابع الوقت للترجمة مع الفيديو. يتضمن العرض المحفوظ كلًا من الفيديو وترجماته.

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

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) طريقة تحميل تسمح لك بإضافة ترجمات من تدفق بيانات.

### **استخراج ترجمات من إطار فيديو**

هذا المثال يحفظ جميع مسارات الترجمات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تحافظ الأرقام المتسلسلة على تمييز ملفات الإخراج. يُبلغ وحدة التحكم عن عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن من [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) يُظهر معرف الترجمة، والملصق، والبيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

### **إزالة الترجمات من إطار فيديو**

هذا المثال يزيل جميع الترجمات من إطار الفيديو الموجود في الموضع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يُفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

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

إذا احتجت إلى إزالة مسار ترجمة واحد فقط، استخدم طريقتي [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) بدلاً من [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

### **بحث عن ترجمات الفيديو**

طريقة [ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) تُعيد المسار الكامل لـ WebVTT بما فيه الرأس، وخطوط التوقيت، ونص الترجمة. يمكنك البحث في الإشارات في الذاكرة لتحديد عبارة منطوقة وطابعها الزمني. على سبيل المثال، قد يحتوي مسار إنجليزي على الشريحة 2 على النص التالي.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

يفتح المثال الملف `captioned_media.pptx` ويستخدم [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) لقراءة مسارات كل إطار فيديو من المستوى الأعلى في كل شريحة. في إشارة نصية عادية، يحتوي سطر التوقيت على `-->`، ويسطر فارغ ينهي الإشارة. عندما تحتوي الترجمة على كلمة “café” بأي حالة حرفية، يطبع المثال رقم الشريحة، وملصق المسار، وسطر التوقيت الأصلي، والترجمة الكاملة.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

البحث عن “café” يُنتج مطابقة واحدة للمسار النموذجي. يستبعد البحث رأس المسار ويحافظ على إعداد التوقيت في الناتج.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، يتيح Aspose.Slides استخراج الفيديوهات المدمجة في العروض التقديمية.

هذا المثال يستخرج الفيديوهات المدمجة من كل شريحة إلى ملفات ثنائية رقمية منفصلة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مدمجة. تُظهر وحدة التحكم نوع MIME لكل فيديو وإجمالي عدد الفيديوهات. يستخدم الإخراج الامتداد العام `.bin`؛ يمكنك تغييره ليتطابق مع نوع الوسائط المبلغ عنه عند الضرورة.

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

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند دمج فيديو محلي، تُضاف البيانات الثنائية إلى المستند، وبالتالي يزيد حجم العرض التقديمي بما يتناسب مع حجم الملف. عند ربط فيديو عبر الإنترنت وإضافة صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا عادةً ما يكون الارتفاع في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على شكل الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. للفيديو المدمج نوع [محتوى](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.