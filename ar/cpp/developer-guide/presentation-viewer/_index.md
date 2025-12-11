---
title: إنشاء عارض عروض تقديمية في C++
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/cpp/presentation-viewer/
keywords:
- عرض العرض التقديمي
- عارض العروض التقديمية
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء عارض عروض تقديمية مخصص في C++ باستخدام Aspose.Slides. عرض ملفات PowerPoint وOpenDocument بسهولة دون الحاجة إلى Microsoft PowerPoint."
---

يُستخدم Aspose.Slides for C++ لإنشاء ملفات عروض تقديمية تحتوي على شرائح. يمكن عرض هذه الشرائح عن طريق فتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في مثل هذه الحالات، يسمح Aspose.Slides بتصدير شريحة فردية كصورة. يصف هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة حسب الفهرس الخاص بها.
3. فتح تدفق ملف.
4. حفظ الشريحة كصورة SVG إلى تدفق الملف.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **إنشاء SVG بمعرف شكل مخصص**

يمكن استخدام Aspose.Slides لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص. للقيام بذلك، استخدم طريقة `set_Id` من [ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/). يمكن استخدام `CustomSvgShapeFormattingController` لتعيين معرف الشكل.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **إنشاء صورة مصغرة للشريحة**

يساعدك Aspose.Slides في إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة حسب الفهرس.
3. الحصول على الصورة المصغرة للشريحة المرجعية وفق مقياس محدد.
4. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **إنشاء صورة مصغرة للشريحة بأبعاد معرفة من قبل المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة حسب الفهرس.
3. الحصول على الصورة المصغرة للشريحة المرجعية بالأبعاد المحددة.
4. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **إنشاء صورة مصغرة للشريحة مع ملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) .
2. استخدام طريقة `RenderingOptions.set_SlidesLayoutOptions` لتحديد موضع ملاحظات المتحدث.
3. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
4. الحصول على مرجع الشريحة حسب الفهرس.
5. الحصول على الصورة المصغرة للشريحة المرجعية باستخدام خيارات العرض.
6. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **مثال حي**

يمكنك تجربة تطبيق [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) المجاني لترى ما يمكنك تنفيذه باستخدام Aspose.Slides API:

![عارض PowerPoint عبر الإنترنت](online-PowerPoint-viewer.png)

## **الأسئلة المتكررة**

**هل يمكنني تضمين عارض عروض تقديمية في تطبيق ويب؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لتصيير الشرائح كصور أو HTML وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض مخصص؟**

النهج الموصى به هو تصيير كل شريحة كصورة (مثل PNG أو SVG) أو تحويلها إلى HTML باستخدام Aspose.Slides، ثم عرض النتيجة داخل صندوق صورة (لسطح المكتب) أو حاوية HTML (للويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

في حال العروض الكبيرة، يُنصح باستخدام التحميل الكسول أو تصيير الشرائح عند الطلب. يعني ذلك توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.