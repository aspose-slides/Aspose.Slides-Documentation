---
title: إطار الصوت - إدراج واستخراج الصوت في PowerPoint باستخدام C#
linktitle: إطار الصوت
type: docs
weight: 10
url: /net/audio-frame/
keywords: "صورة مصغرة للصوت، إضافة صوت، إطار الصوت، خصائص الصوت، استخراج الصوت، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة الصوت إلى عرض PowerPoint في C# أو .NET"
---

## **إنشاء إطار الصوت**
تسمح Aspose.Slides لـ .NET بإضافة ملفات الصوت إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بتحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. اضبط [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) و`Volume` المعرضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. احفظ العرض التقديمي المعدل.

يوضح كود C# كيف يمكنك إضافة إطار صوت مضمن إلى الشريحة:

```c#
// يهيئ فئة presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];
    
    // يحمل ملف الصوت wav إلى التدفق
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // يحدد وضع التشغيل وحجم الصوت
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // يكتب ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **تغيير صورة إطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار بصور افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة إطار الصوت (تعيين الصورة المفضلة لديك).

يوضح كود C# كيف يمكنك تغيير صورة إطار الصوت أو صورة المعاينة:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // يضيف إطار صوت إلى الشريحة بموقع وحجم محددين.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // يضيف صورة إلى موارد العرض التقديمي.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // يحدد الصورة لإطار الصوت.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//يحفظ العرض التقديمي المعدل على القرص
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **تغيير خيارات تشغيل الصوت**

تسمح Aspose.Slides لـ .NET بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط حجم الصوت، أو تعيين الصوت للتشغيل بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات الصوت في PowerPoint التي تتوافق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- قائمة خيارات الصوت **البداية** تطابق خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- خيارات الصوت **الحجم** تطابق خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- خيارات الصوت **التشغيل عبر الشرائح** تطابق خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- خيارات الصوت **التكرار حتى التوقف** تطابق خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- خيارات الصوت **الإخفاء أثناء العرض** تطابق خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- خيارات الصوت **إعادة التشغيل بعد التشغيل** تطابق خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

إليك كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

يوضح كود C# عملية يتم فيها ضبط خيارات الصوت:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // يحدد وضع التشغيل للتشغيل عند النقر
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // يحدد حجم الصوت على منخفض
    audioFrame.Volume = AudioVolumeMode.Low;

    // يحدد الصوت للتشغيل عبر الشرائح
    audioFrame.PlayAcrossSlides = true;

    // يعطل التكرار للصوت
    audioFrame.PlayLoopMode = false;

    // يخفي AudioFrame أثناء عرض الشرائح
    audioFrame.HideAtShowing = true;

    // يعيد تشغيل الصوت إلى البداية بعد التشغيل
    audioFrame.RewindAudio = true;

    // يحفظ ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **استخراج الصوت**
تسمح Aspose.Slides لـ .NET باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وقم بتحميل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على مرجع الشريحة ذات الصلة من خلال فهرسها.
3. الوصول إلى انتقالات عرض الشرائح للشريحة.
4. استخراج الصوت في بيانات بايت.

يوضح كود C# كيف يمكنك استخراج الصوت المستخدم في شريحة:

```c#
string presName = "AudioSlide.pptx";

// يهيئ فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation(presName);

// يصل إلى الشريحة
ISlide slide = pres.Slides[0];

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
ISlideShowTransition transition = slide.SlideShowTransition;

// يستخرج الصوت في مصفوفة بايت
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```