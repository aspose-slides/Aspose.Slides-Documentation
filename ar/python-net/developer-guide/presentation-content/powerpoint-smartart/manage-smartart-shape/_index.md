---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /python-net/manage-smartart-shape/
keywords: "شكل SmartArt، أسلوب شكل SmartArt، أسلوب لون شكل SmartArt، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إدارة SmartArt في عروض PowerPoint باستخدام بايثون"
---

## **إنشاء شكل SmartArt**
تسهل Aspose.Slides لبايثون عبر .NET الآن إضافة أشكال SmartArt مخصصة في الشرائح من الصفر. قدمت Aspose.Slides لبايثون عبر .NET أبسط واجهة برمجة تطبيقات لإنشاء أشكال SmartArt بأبسط طريقة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType الخاص به.
- كتابة العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# إنشاء العرض التقديمي
with slides.Presentation() as pres:
    # الوصول إلى شريحة العرض
    slide = pres.slides[0]

    # إضافة شكل Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # حفظ العرض التقديمي
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال SmartArt المضافة في شريحة العرض. في الكود النموذجي سوف نتنقل عبر كل شكل داخل الشريحة ونتحقق مما إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt، فسوف نقوم بتحويل نوعه إلى مثيل SmartArt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المرغوب
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:
        # التحقق مما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # تحويل الشكل إلى SmartArtEx
            print("اسم الشكل:" + shape.name)
```



## **الوصول إلى شكل SmartArt مع نوع تخطيط محدد**
سيساعد الكود النموذجي التالي على الوصول إلى شكل SmartArt مع نوع تخطيط محدد. يرجى ملاحظة أنه لا يمكنك تغيير نوع التخطيط لشكل SmartArt حيث إنه للقراءة فقط ويُعيّن فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- تحقق من شكل SmartArt مع نوع التخطيط المحدد وقم بما هو مطلوب بعدها.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # التحقق من تخطيط SmartArt
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("قم بفعل شيء هنا....")
```



## **تغيير أسلوب شكل SmartArt**
سيساعد الكود النموذجي التالي على الوصول إلى شكل SmartArt مع نوع تخطيط محدد.

- إنشاء مثيل من `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- العثور على شكل SmartArt مع نمط محدد.
- تعيين نمط جديد لشكل SmartArt.
- حفظ العرض التقديمي.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # التحقق من نمط SmartArt
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # تغيير نمط SmartArt
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # حفظ العرض التقديمي
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تغيير أسلوب لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الكود النموذجي التالي سنقوم بالوصول إلى شكل SmartArt مع نمط لون محدد وسنقوم بتغيير نمطه.

- إنشاء مثيل من `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- العثور على شكل SmartArt مع نمط لون محدد.
- تعيين نمط لون جديد لشكل SmartArt.
- حفظ العرض التقديمي.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # التحقق من نوع لون SmartArt
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # تغيير نوع لون SmartArt
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # حفظ العرض التقديمي
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```