---
title: تحويل PPT و PPTX إلى JPG في C++
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/cpp/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض التقديمي كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في C++ باستخدام Aspose.Slides مع أمثلة كود سريعة وموثوقة."
---

## **نظرة عامة**

تحويل عروض PowerPoint وOpenDocument إلى صور JPG يساعد في مشاركة الشرائح، تحسين الأداء، وإدراج المحتوى في مواقع الويب أو التطبيقات. يتيح Aspose.Slides for C++ تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت تريد حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides لك تحويل العرض بالكامل أو شريحة محددة إلى تنسيقات صور.

## **تحويل شرائح العرض إلى صور JPG**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) من مجموعة شرائح العرض.
1. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) .
1. استدعاء الطريقة [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) على كائن الصورة. تمرير اسم ملف الإخراج وتنسيق الصورة كوسائط.

{{% alert color="primary" %}} 

**ملاحظة:** تحويل PPT أو PPTX أو ODP إلى JPG يختلف عن التحويل إلى تنسيقات أخرى في واجهة برمجة التطبيقات Aspose.Slides for C++. بالنسبة للتنسيقات الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). ومع ذلك، لتحويل JPG، تحتاج إلى استخدام الطريقة [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) .

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة للشرائح بالمقياس المحدد.
    auto image = slide->GetImage(scaleX, scaleY);

    // حفظ الصورة على القرص بتنسيق JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، مما يضمن أن النتيجة تلبي متطلباتك للدقة ونسبة العرض إلى الارتفاع. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق التي تتطلب أبعادًا دقيقة للصور.
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة للشرائح بالحجم المحدد.
    auto image = slide->GetImage(imageSize);

    // حفظ الصورة على القرص بتنسيق JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **إظهار التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for C++ ميزة تسمح لك بعرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الخاصية مفيدة جدًا لحفظ الملاحظات أو ردود الفعل أو المناقشات التي أضافها المتعاونون في عروض PowerPoint. بتمكين هذا الخيار، تضمن أن تكون التعليقات مرئية في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة إلى فتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض باسم "sample.pptx"، مع شريحة تحتوي على تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الكود التالي بلغة C++ يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:
```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // تعيين الخيارات لتعليقات الشريحة.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // تحويل الشريحة الأولى إلى صورة.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```


النتيجة:

![صورة JPG مع التعليقات](image_with_comments.png)

## **انظر أيضًا**

- [تحويل PowerPoint إلى GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/cpp/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

لرؤية كيف يقوم Aspose.Slides بتحويل PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية على الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}}

![محول PPTX إلى JPG عبر الإنترنت مجاني](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب مجاني للـ[Collage](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة على الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الواردة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم هذه الطريقة التحويل الجماعي؟**

نعم، يتيح Aspose.Slides التحويل الجماعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية وغيرها من الكائنات المعقدة؟**

نعم، يعرض Aspose.Slides جميع المحتويات بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال والمزيد. ومع ذلك، قد يختلف دقة العرض قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides حدًا صارمًا على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور ذات دقة عالية.