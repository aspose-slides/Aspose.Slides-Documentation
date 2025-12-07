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

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع الإلكترونية أو التطبيقات. يتيح Aspose.Slides للغة C++ تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت تريد حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة محددة إلى صيغ صور.

## **تحويل شرائح العرض إلى صور JPG**

1. قم بإنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. احصل على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) من مجموعة شرائح العرض.
3. أنشئ صورة للشريحة باستخدام الطريقة [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) .
4. استدعِ الطريقة [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) على كائن الصورة. مرّر اسم ملف الإخراج وصيغة الصورة كمعاملات.

{{% alert color="primary" %}} 
**ملاحظة:** يختلف تحويل PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في واجهة برمجة تطبيقات Aspose.Slides للغة C++. بالنسبة إلى الصيغ الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) . ومع ذلك، بالنسبة إلى التحويل إلى JPG، يجب عليك استخدام الطريقة [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) .
{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة شريحة بالمقياس المحدد.
    auto image = slide->GetImage(scaleX, scaleY);

    // حفظ الصورة إلى القرص بتنسيق JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك تعيين حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) . يتيح لك ذلك إنشاء صور بأبعاد عرض وارتفاع محددة، مما يضمن أن يكون الناتج متوافقًا مع متطلباتك من حيث الدقة ونسبة الجانب. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث تُطلب أبعاد صور دقيقة.
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


## **تضمين التعليقات عند حفظ الشرائح كصور**

يقدم Aspose.Slides للغة C++ ميزة تسمح لك بتضمين التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على الشروح، الملاحظات أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. من خلال تمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة إلى فتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض تقديمي باسم "sample.pptx" يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

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

## **انظر أيضاً**

شاهد خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/cpp/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides لملفات PowerPoint إلى صور JPG، جرب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg) .
{{% /alert %}}

![محول PPTX إلى JPG مجاني على الإنترنت](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
توفر Aspose تطبيق ويب مجاني لإنشاء الكولاج [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG to JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، إنشاء [photo grids](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذا المقال، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)؛ تحويل [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)؛ تحويل [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)؛ تحويل [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)؛ تحويل [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)؛ تحويل [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/) .
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم هذا الأسلوب التحويل على دفعات؟**

نعم، يتيح Aspose.Slides التحويل على دفعات لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية وغيرها من الكائنات المعقدة؟**

نعم، يقوم Aspose.Slides بتصيير جميع المحتويات بما في ذلك SmartArt، الرسوم البيانية، الجداول، الأشكال، والمزيد. ومع ذلك، قد يختلف دقة التصيير قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides نفسه أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور عالية الدقة.