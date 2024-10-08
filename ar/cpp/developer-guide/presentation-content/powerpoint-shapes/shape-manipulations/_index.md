---
title: التلاعب بالأشكال
type: docs
weight: 40
url: /ar/cpp/shape-manipulations/
---

## **البحث عن شكل في الشريحة**
سيتناول هذا الموضوع تقنية بسيطة لتسهيل عمل المطورين في العثور على شكل معين في شريحة دون استخدام معرّفه الداخلي. من المهم معرفة أن ملفات PowerPoint Presentation ليس لها أي وسيلة لتعريف الأشكال على الشريحة باستثناء معرف فريد داخلي. يبدو أنه من الصعب على المطورين العثور على شكل باستخدام معرفه الفريد الداخلي. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل محدد. يمكنك استخدام MS PowerPoint لتحديد النص البديل للأشياء التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مرغوب، يمكنك فتح تلك العروض التقديمية باستخدام Aspose.Slides لـ C++ والتكرار عبر جميع الأشكال المضافة إلى الشريحة. أثناء كل تكرار، يمكنك التحقق من النص البديل للشكل، والشكل الذي يحمل النص البديل المطابق سيكون الشكل المطلوب منك. لإظهار هذه التقنية بطريقة أفضل، قمنا بإنشاء طريقة، [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) تقوم بالتحقق والعثور على شكل محدد في الشريحة ثم تعيد ببساطة ذلك الشكل.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **نسخ الشكل**
لنسخ شكل إلى شريحة باستخدام Aspose.Slides لـ C++:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. نسخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **إزالة الشكل**
Aspose.Slides لـ C++ يتيح للمطورين إزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل ذو النص البديل المحدد.
1. إزالة الشكل.
1. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **إخفاء الشكل**
Aspose.Slides لـ C++ يتيح للمطورين إخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل ذو النص البديل المحدد.
1. إخفاء الشكل.
1. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}


## **تغيير ترتيب الشكل**
Aspose.Slides لـ C++ يتيح للمطورين إعادة ترتيب الأشكال. إعادة ترتيب الشكل تحدد أي شكل في المقدمة أو أي شكل في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص في إطار نص الشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **الحصول على معرف الشكل Interop**
Aspose.Slides لـ C++ يتيح للمطورين الحصول على معرّف شكل فريد في نطاق الشريحة في مقابل خاصية UniqueId، التي تسمح بالحصول على معرّف فريد في نطاق العرض التقديمي. تمت إضافة خاصية OfficeInteropShapeId إلى واجهات IShape وفئة Shape على التوالي. القيمة التي يتم إرجاعها بواسطة خاصية OfficeInteropShapeId تتوافق مع قيمة المعرف لجسم Microsoft.Office.Interop.PowerPoint.Shape. أدناه يتم إعطاء مثال على الكود.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **تعيين خاصية النص البديل**
Aspose.Slides لـ C++ يتيح للمطورين تعيين النص البديل لأي شكل. لتعيين النص البديل لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض الأعمال مع الشكل المُضاف حديثًا.
1. التجول عبر الأشكال للعثور على شكل.
1. تعيين النص البديل.
1. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **الوصول إلى تنسيقات التخطيط للشكل**
Aspose.Slides لـ C++ يتيح للمطورين الوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيف يمكنك الوصول إلى خصائص **FillFormat** و **LineFormat** لشكل.

أدناه يتم إعطاء مثال على الكود.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **عرض الشكل كـ SVG**
الآن يدعم Aspose.Slides لـ C++ عرض شكل كـ svg. تمت إضافة طريقة WriteAsSvg (وفرعها) إلى فئة Shape وواجهة IShape. تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يظهر مقطع الكود أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **محاذاة الأشكال**
Aspose.Slides يسمح بمحاذاة الأشكال سواء بالنسبة لهامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة طريقة مفرطة [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). تُعرّف تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) خيارات المحاذاة الممكنة.

**مثال 1**

يقوم كود المصدر أدناه بمحاذاة الأشكال ذات الفهارس 1 و2 و4 على طول الحافة العلوية للشريحة.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**مثال 2**

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة لأدنى شكل في المجموعة.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```