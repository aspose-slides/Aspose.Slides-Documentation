---
title: إدارة أشكال العرض التقديمي في C++
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/cpp/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على شريحة
- العثور على شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- نص بديل للشكل
- تنسيقات تخطيط الشكل
- شكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعلّم إنشاء وتعديل وتحسين الأشكال في Aspose.Slides للـ C++ وتقديم عروض PowerPoint عالية الأداء."
---

## **العثور على شكل في شريحة**
سيتناول هذا الموضوع تقنية بسيطة لتسهيل عملية العثور على شكل معين في شريحة دون استخدام المعرّف الداخلي الخاص به. من المهم أن نعرف أن ملفات عرض PowerPoint لا تملك أي طريقة لتحديد الأشكال في الشريحة باستثناء معرّف فريد داخلي. يبدو أن العثور على شكل باستخدام معرّفه الفريد الداخلي صعب على المطورين. جميع الأشكال التي تُضاف إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مطلوب، يمكنك فتح هذا العرض باستخدام Aspose.Slides للـ C++ والتكرار عبر جميع الأشكال المضافة إلى شريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل، وسيكون الشكل الذي يطابق النص البديل هو الشكل الذي تحتاجه. لتوضيح هذه التقنية بطريقة أفضل، لقد أنشأنا طريقة [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) التي تقوم بالعثور على شكل معين في شريحة وتعيد ذلك الشكل ببساطة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **استنساخ شكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides للـ C++:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
3. الوصول إلى مجموعة أشكال الشريحة المصدر.
4. إضافة شريحة جديدة إلى العرض.
5. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
6. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **إزالة شكل**
تمكن Aspose.Slides للـ C++ المطورين من إزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. الوصول إلى الشريحة الأولى.
3. العثور على الشكل ذو النص البديل المحدد.
4. إزالة الشكل.
5. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **إخفاء شكل**
تمكن Aspose.Slides للـ C++ المطورين من إخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. الوصول إلى الشريحة الأولى.
3. العثور على الشكل ذو النص البديل المحدد.
4. إخفاء الشكل.
5. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **تغيير ترتيب الشكل**
تمكن Aspose.Slides للـ C++ المطورين من إعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة شكل.
4. إضافة بعض النص داخل إطار نص الشكل.
5. إضافة شكل آخر بنفس الإحداثيات.
6. إعادة ترتيب الأشكال.
7. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **الحصول على معرف الشكل Interop**
تمكن Aspose.Slides للـ C++ المطورين من الحصول على معرف فريد للشكل ضمن نطاق الشريحة على عكس خاصية UniqueId التي تسمح بالحصول على معرف فريد ضمن نطاق العرض. تمت إضافة خاصية OfficeInteropShapeId إلى واجهات IShape وفئة Shape على التوالي. القيمة التي تُعيدها خاصية OfficeInteropShapeId تتطابق مع قيمة المعرف Id لكائن Microsoft.Office.Interop.PowerPoint.Shape. فيما يلي مثال على الشيفرة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **تعيين خاصية AlternativeText**
تمكن Aspose.Slides للـ C++ المطورين من تعيين AlternateText لأي شكل. لتعيين AlternateText لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. القيام ببعض الأعمال مع الشكل المضاف حديثًا.
5. التجول عبر الأشكال للعثور على الشكل المطلوب.
6. تعيين AlternativeText.
7. حفظ الملف على القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **الوصول إلى تنسيقات التخطيط لشكل**
تمكن Aspose.Slides للـ C++ المطورين من الوصول إلى تنسيقات التخطيط لشكل. تُظهر هذه المقالة كيفية الوصول إلى خصائص **FillFormat** و **LineFormat** لشكل.

فيما يلي مثال على الشيفرة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **رسم الشكل كـ SVG**
الآن تدعم Aspose.Slides للـ C++ رسم شكل بصيغة SVG. تم إضافة الطريقة WriteAsSvg (وتجاوزها) إلى فئة Shape وواجهة IShape. تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح مقتطف الشيفرة أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **محاذاة الأشكال**
تمكن Aspose.Slides من محاذاة الأشكال إما بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة طريقة مُحملة [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) . تُعرّف تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) خيارات المحاذاة الممكنة.

**مثال 1**
الكود المصدر أدناه يقوم بمحاذاة الأشكال ذات المؤشرات 1 و2 و4 على الحافة العليا للشريحة.
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
يوضح المثال أدناه كيفية محاذاة المجموعة الكاملة من الأشكال بالنسبة للشكل الأدنى تمامًا في المجموعة.
``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **خصائص الانعكاس**
في Aspose.Slides، توفر الفئة [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) التحكم في الانعكاس الأفقي والعمودي للأشكال عبر خصائص `flipH` و `flipV`. كلا الخصائص من نوع [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/)، وتسمح بالقيم `True` للدلالة على الانعكاس، `False` لعدم الانعكاس، أو `NotDefined` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء نسخة جديدة من [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) باستخدام موضع وحجم الشكل الحالي، والقيم المطلوبة لـ `flipH` و `flipV`، وزاوية الدوران. عند إسناد هذه النسخة إلى [Frame] الخاص بالشكل وحفظ العرض، يتم تطبيق تحويلات الانعكاس وتثبيتها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx حيث تحتوي الشريحة الأولى على شكل واحد بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![الشكل المراد انعكاسه](shape_to_be_flipped.png)

مثال الشيفرة التالي يستعيد خصائص الانعكاس الحالية للشكل ويعكسه أفقيًا وعموديًا.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// استرجاع خاصية الانعكاس الأفقي للشكل.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// استرجاع خاصية الانعكاس العمودي للشكل.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // انعكاس أفقي.
auto flipV = NullableBool::True; // انعكاس أفقي.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:
![الشكل المعكوس](flipped_shape.png)

## **الأسئلة المتكررة**
**هل يمكنني دمج الأشكال (جمع/تقاطع/طرح) في شريحة كما في محرر سطح المكتب؟**
لا توجد واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقريب ذلك عن طريق إنشاء المخطط المطلوب بنفسك — على سبيل المثال، احسب الهندسة الناتجة (باستخدام [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)) وأنشئ شكلًا جديدًا بهذا المخطط، واختياريًا قم بإزالة الأشكال الأصلية.

**كيف يمكنني التحكم في ترتيب الطبقات (z-order) بحيث يبقى الشكل دائمًا في القمة؟**
غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) الخاصة بالشريحة. للحصول على نتائج قابلة للتنبؤ، قم بإنهاء ترتيب z بعد جميع التعديلات الأخرى على الشريحة.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تحريره في PowerPoint؟**
نعم. قم بتعيين [علامات الحماية على مستوى الشكل](/slides/ar/cpp/applying-protection-to-presentation/) (مثل قفل التحديد، التحريك، تغيير الحجم، تحرير النص). إذا لزم الأمر، يمكنك تطبيق القيود على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى واجهة المستخدم، ليست ميزة أمان؛ للحصول على حماية أقوى، يمكن دمجها مع قيود على مستوى الملف مثل التوصيات للقراءة فقط أو كلمات مرور [/slides/cpp/password-protected-presentation/]( /slides/cpp/password-protected-presentation/).