---
title: "إدارة رسومات SmartArt في العروض التقديمية باستخدام Python"
linktitle: "رسومات SmartArt"
type: docs
weight: 20
url: /ar/python-net/manage-smartart-shape/
keywords:
- "كائن SmartArt"
- "رسمة SmartArt"
- "نمط SmartArt"
- "لون SmartArt"
- "إنشاء SmartArt"
- "إضافة SmartArt"
- "تحرير SmartArt"
- "تغيير SmartArt"
- "الوصول إلى SmartArt"
- "نوع تخطيط SmartArt"
- "PowerPoint"
- "العرض التقديمي"
- "Python"
- "Aspose.Slides"
description: "أتمتة إنشاء وتحرير وتنسيق SmartArt في PowerPoint باستخدام Python عبر .NET مع Aspose.Slides، مع أمثلة شفرة مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء أشكال SmartArt**

يتيح لك Aspose.Slides for Python عبر .NET إضافة أشكال SmartArt مخصصة إلى الشرائح من الصفر. تجعل لك API ذلك سهلًا. لإضافة شكل SmartArt إلى شريحة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على الشريحة المستهدفة بواسطة الفهرس الخاص بها.
3. إضافة شكل SmartArt مع تحديد نوع التخطيط الخاص به.
4. حفظ العرض التقديمي المعدل كملف PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# إنشاء كائن فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى شريحة العرض التقديمي.
    slide = presentation.slides[0]
    # إضافة شكل SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الوصول إلى أشكال SmartArt على الشرائح**

يعرض الشيفرة التالية كيفية الوصول إلى أشكال SmartArt على شريحة. تقوم العينة بالتنقل عبر كل شكل على الشريحة وتتحقق مما إذا كان كائنًا من نوع [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) .
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# تحميل ملف عرض تقديمي.
with slides.Presentation("SmartArt.pptx") as presentation:
    # التكرار عبر كل شكل في الشريحة الأولى.
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل شكل SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # طباعة اسم الشكل.
            print("Shape name:", shape.name)
```


## **الوصول إلى أشكال SmartArt بنوع تخطيط محدد**

يعرض المثال التالي كيفية الوصول إلى شكل SmartArt بنوع تخطيط محدد. لاحظ أنه لا يمكنك تغيير نوع تخطيط SmartArt؛ فهو للقراءة فقط ويتم تعيينه عند إنشاء الشكل.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
2. الحصول على إشارة إلى الشريحة الأولى بواسطة الفهرس.
3. التنقل عبر كل شكل على الشريحة الأولى.
4. التحقق مما إذا كان الشكل كائنًا من نوع [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) .
5. إذا كان نوع تخطيط شكل SmartArt يطابق ما تحتاجه، قم بتنفيذ الإجراءات المطلوبة.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # التكرار عبر كل شكل في الشريحة الأولى.
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل شكل SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # التحقق من نوع تخطيط SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **تغيير نمط شكل SmartArt**

يعرض المثال التالي كيفية تحديد مواقع أشكال SmartArt وتغيير نمطها:

1. إنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل الملف الذي يحتوي على شكل (أشكال) SmartArt.
2. الحصول على إشارة إلى الشريحة الأولى بواسطة الفهرس.
3. التنقل عبر كل شكل على الشريحة الأولى.
4. العثور على شكل SmartArt بالنمط المحدد.
5. تعيين النمط الجديد لشكل SmartArt.
6. حفظ العرض التقديمي.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # التكرار عبر كل شكل في الشريحة الأولى.
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل شكل SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # التحقق من نمط SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # تغيير نمط SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # حفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **تغيير نمط اللون لأشكال SmartArt**

يعرض هذا المثال كيفية تغيير نمط اللون لشكل SmartArt. يحدد الشيفرة عينة شكل SmartArt بنمط لون محدد ويقوم بتحديثه.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على شكل (أشكال) SmartArt.
2. الحصول على إشارة إلى الشريحة الأولى بواسطة الفهرس.
3. التنقل عبر كل شكل على الشريحة الأولى.
4. التحقق مما إذا كان الشكل كائنًا من نوع [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) .
5. تحديد شكل SmartArt بالنمط اللوني المحدد.
6. تعيين نمط اللون الجديد لذلك الشكل SmartArt.
7. حفظ العرض التقديمي.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # التكرار عبر كل شكل في الشريحة الأولى.
    for shape in presentation.slides[0].shapes:
        # التحقق مما إذا كان الشكل شكل SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # التحقق من نوع اللون.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # تغيير نوع اللون.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # حفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/python-net/powerpoint-animation/) عبر واجهة برمجة تطبيقات الرسوم المتحركة (دخول، خروج، تأكيد، مسارات الحركة) تمامًا كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt معين على شريحة إذا لم أكن أعرف معرفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة — هذه طريقة موصى بها لتحديد موقع الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/python-net/group/).

**كيف أحصل على صورة لـ SmartArt معين (مثلاً للمعاينة أو التقرير)؟**

صدّر صورة مصغرة/صورة للشكل؛ المكتبة يمكنها [تصيير الأشكال الفردية](/slides/ar/python-net/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل ستُحافظ مظهر SmartArt عند تحويل العرض التقديمي بالكامل إلى PDF؟**

نعم. محرك التصيير يهدف إلى دقة عالية لتصدير [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.