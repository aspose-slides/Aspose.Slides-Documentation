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
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في C++ باستخدام Aspose.Slides وأمثلة شفرة سريعة وموثوقة."
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع أو التطبيقات. يتيح Aspose.Slides للـ C++ تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروضك الخاص وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت تريد حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides لك تحويل العرض بالكامل أو شريحة معينة إلى صيغ الصور.

## **تحويل شرائح العرض إلى صور JPG**

فيما يلي الخطوات لتحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) من مجموعة شرائح العرض.
1. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).
1. استدعاء الطريقة [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) على كائن الصورة. مرّر اسم ملف الإخراج وصيغة الصورة كمعاملات.

{{% alert color="primary" %}} 

**ملاحظة:** يختلف التحويل من PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في واجهة Aspose.Slides للـ C++. بالنسبة للصيغ الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). ومع ذلك، للتحويل إلى JPG، تحتاج إلى استخدام الطريقة [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة الشريحة بالمقياس المحدد.
    auto image = slide->GetImage(scaleX, scaleY);

    // حفظ الصورة إلى القرص بتنسيق JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). يتيح لك ذلك إنشاء صور بأبعاد عرض وارتفاع محددة، مما يضمن أن المخرج يلبي متطلباتك من حيث الدقة والنسبة. هذه المرونة مفيدة خصوصًا عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق التي تتطلب أبعاد صورة دقيقة.
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة شريحة بالحجم المحدد.
    auto image = slide->GetImage(imageSize);

    // حفظ الصورة إلى القرص بتنسيق JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **رسم التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides للـ C++ ميزة تتيح لك رسم التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على الملاحظات أو التعليقات أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. من خلال تفعيل هذا الخيار، تضمن أن تكون التعليقات مرئية في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة لفتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض باسم "sample.pptx" يحتوي على شريحة بها تعليقات:

![The slide with comments](slide_with_comments.png)

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

    // تعيين خيارات تعليقات الشريحة.
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

![The JPG image with comments](image_with_comments.png)

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [Convert PowerPoint to GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/ar/cpp/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides لملفات PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}}

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب مجاني لإنشاء الكولاج [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG to JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [photo grids](https://products.aspose.app/slides/collage/photo-grid)، وغيرها. 

باستخدام المبادئ نفسها الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم هذا الأسلوب التحويل على دفعات؟**

نعم، يتيح Aspose.Slides تحويل دفعة من الشرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل العناصر المعقدة مثل SmartArt والرسوم البيانية؟**

نعم، يقوم Aspose.Slides برسم كل المحتوى، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. قد تختلف دقة العرض قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides أي حدود صارمة على عدد الشرائح التي يمكن معالجتها. ومع ذلك، قد تواجه خطأ نقص الذاكرة عند التعامل مع عروض تقديمية ضخمة أو صور عالية الدقة.