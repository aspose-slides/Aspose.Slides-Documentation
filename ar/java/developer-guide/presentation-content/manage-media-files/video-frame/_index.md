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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Java. دليل سريع عملي."
---
## **مقدمة**

يمكن للمقاطع الفيديو أن تساعد في شرح الأفكار وجذب الجمهور. تتيح لك Aspose.Slides for Java إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة الترجمات، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint مقاطع الفيديو المحلية والروابط إلى مقاطع الفيديو على الإنترنت، مثل مقاطع YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزّنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي الخاص بك.

يضمّن هذا المثال فيديوًا محليًا على الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدة النقاط. يبقى التدفق مفتوحًا حتى ينتهي الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) يحتفظ به مقفلًا أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرةً إلى [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). يضمّن هذا المثال الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

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

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط إلى فيديو على الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. تطلب الطريقة [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) تشغيلًا تلقائيًا. يتطلب تنزيل الصورة المصغرة وتشغيل الفيديو اتصالًا بالإنترنت. يجب أن يدعم عارض العروض التقديمية أيضًا تشغيل الفيديو عبر الإنترنت.

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

في عرض تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) مع `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) على الشريحة الأولى، ويفعّل تشغيل ملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود على الشريحة الأولى.

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

تتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، تتحكم [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) في ما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تدريبي، إرجاع فيديو العرض التوضيحي إلى بدايته يجعله جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) مع `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) على الشريحة الأولى، ويفعّل الإرجاع. يعطل التكرار حتى يمكن لإنهاء التشغيل، ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود على الشريحة الأولى.

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

يرجع الإرجاع الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) مع `true` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) بصورة مستقلة في التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) حتى يتحكم المقدم في وقت بدء التشغيل. اضبط وضع التشغيل بعد ضبط إعداد التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **تقليم إطار الفيديو**

استخدم [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) و[IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) لتجاوز جزء من بداية أو نهاية الفيديو أثناء التشغيل. كلا القيمتين بالمللي ثانية. يغيّر التقليم إعدادات التشغيل دون تعديل بيانات الفيديو المضمّن.

**ضبط إعدادات التقليم**

يضمّن هذا المثال فيديوًا محليًا ويتخطى أول 2.5 ثانية والثانية الأخيرة أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثانية لضمان بقاء جزء قابل للتشغيل.

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

يطبع هذا المثال قيم التقليم لإطار الفيديو الأول على الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يُطبع شيء. ينتج المثال السابق القيم 2500 و1000.

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

تتيح لك Aspose.Slides إدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ الترجمات بصيغة WebVTT وتُعرض عبر طريقة [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **إضافة ترجمات إلى إطار فيديو**

يضمّن هذا المثال فيديوًا محليًا ويضيف مسار ترجمات WebVTT بعنوان English. يجب أن تتطابق طوابع التوقيت مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وترجماته.

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

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) أيضًا نسخة زائدة تسمح لك بإضافة ترجمات من تدفق.

### **استخراج ترجمات من إطار فيديو**

يحفظ هذا المثال جميع مسارات الترجمات من إطارات الفيديو على الشريحة الأولى كملفات WebVTT منفصلة. تُحافظ الأرقام المتسلسلة على تمييز ملفات الإخراج. يُبلغ الطرفية عن عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) يُظهر معرف الترجمة، التسمية، البيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

### **إزالة ترجمات من إطار فيديو**

يزيل هذا المثال جميع الترجمات من إطار الفيديو في الموضع الأول للشكل على الشريحة الأولى ويحفظ النتيجة. يفترض أن الشريحة والشكل موجودان وأن الشكل هو إطار فيديو.

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

إذا احتجت لإزالة مسار ترجمة واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) بدلاً من [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

### **البحث في ترجمات الفيديو**

تُرجع الطريقة [ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) مسار WebVTT الكامل، بما في ذلك الرأس، أسطر التوقيت، ونص الترجمة. يمكنك البحث في الإشارات في الذاكرة للعثور على عبارة منطوقة وتوقيتها. على سبيل المثال، قد يحتوي مسار إنجليزي على الشريحة 2 على النص التالي.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

يفتح المثال الملف `captioned_media.pptx` ويستخدم [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) لقراءة مسارات كل إطار فيديو من المستوى الأعلى على كل شريحة. في إشارة نصية عادية، يحتوي سطر التوقيت على `-->`، ويسطر فارغ ينهي الإشارة. عندما تحتوي الترجمة على كلمة “café” بأي حالة حرفية، يطبع المثال رقم الشريحة، تسمية المسار، سطر التوقيت الأصلي، والترجمة الكاملة.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

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
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
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

يُنتج البحث عن “café” تطابقًا واحدًا للمسار النموذجي. يستبعد البحث رأس المسار ويحافظ على إعداد التوقيت في الإخراج.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

يستخرج هذا المثال مقاطع الفيديو المضمّنة من كل شريحة إلى ملفات ثنائية مرقمة منفصلة. يتم تخطي الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمّنة. تُظهر الطرفية نوع MIME لكل فيديو والإجمالي. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتوافق مع نوع الوسائط المعلن عند الحاجة.

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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**هل يؤدي إضافة فيديو إلى زيادة حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُضمّن البيانات الثنائية في المستند، لذلك يزداد حجم العرض التقديمي proportionally لحجم الملف. عندما تربط بفيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة في الحجم عادة أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. للفيديو المضمّن [نوع محتوى](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.