---
title: تطبيق أو تغيير تخطيطات الشرائح في بايثون عبر جافا
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/python-java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة عنوان
- عنوان ومحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق، إنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لبايثون عبر جافا، إضافة عناصر نائب، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يعرف تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والمخططات والجداول. يضيف تطبيق تخطيط إلى الشرائح هيكلًا متسقًا مع السماح لكل شريحة بمحتواها الخاص.

تشمل التخطيطات الأكثر شيوعًا:

- **شريحة عنوان**: تحتوي على عناصر نائب للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على أي عناصر نائب ويُستَخدم عندما يتم وضع كل شكل يدويًا.

## **فهم توريث التخطيط**

تحتوي العرض التقديمي على ثلاثة مستويات مترابطة:

1. A [شريحة رئيسية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/) تعرف السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. A [شريحة تخطيط](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/) تنتمي إلى شريحة رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
1. A [شريحة عادية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

تتورّث الشريحة العادية السمة والتنسيق من تخطيطها، ويرث التخطيط من شريحة رئيسية. أي قيمة تُحدَّد مباشرةً على شريحة عادية تتجاوز القيمة الموروثة على ذلك المستوى. عند إنشاء شريحة عادية، تُولد أشكال العناصر النائبة منها بناءً على التخطيط المحدد، بينما يخص المحتوى المدخل إلى تلك العناصر النائبة الشريحة العادية نفسها.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية القائمة.

للعلاقة نتيجتين مهمتين:

- تغيير التنسيق الموروث أو شكل العنصر النائب الموجود في التخطيط يمكن أن يُحدّث كل الشريحة التي تعتمد عليه. قبل تعديل تخطيط مستخدم بالفعل، افحص الشرائح التابعة له وراجع النتيجة المتوقعة.
- لا يمكن إزالة تخطيط ما يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولًا، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، راجع [شريحة رئيسية](/slides/ar/python-java/slide-master/).

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوع تخطيط عندما يتبع العرض التقديمي تعريفات تخطيط PowerPoint القياسية. يمكن تعديل أسماء التخطيطات من قبل المستخدم ويمكن ترجمتها، لذا فإن الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **Title and Content** في أول شريحة رئيسية. إذا كان ذلك التخطيط غير متوفر، فإنه يعيد إلى **Blank** عن قصد. الفحص الثاني للـ `None` ضروري لأن العرض قد يحتوي على تخطيطات مخصصة فقط. ثم يُطبق التخطيط المحدد على أول شريحة عادية عبر طريقة [Slide.setLayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تغيير تخطيط الشريحة لا يزيل الأشكال العادية التي أضيفت مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الموجودة والتخطيط الجديد، لذا تحقق من النتيجة عند الانتقال بين تخطيطات مختلفة جذريًا.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterlayoutslidecollection/#add) على مجموعة تخطيطات الشريحة الرئيسة المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **Title and Content** باسم `Report Title and Content`، ثم يضيف شريحة عادية تستند إليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

أضف تخطيطًا فقط عندما يحتاج القالب إلى هيكل قابل لإعادة الاستخدام آخر بحق. إذا كان هناك تخطيط مناسب موجود بالفعل، فاختره وأعد استخدامه بدلًا من إنشاء نسخة مكررة.

## **إضافة عناصر نائب إلى شريحة تخطيط**

توفر طريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getPlaceholderManager) كائنًا من نوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال عناصر نائب إلى التخطيط.

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| ---------------------- | ---------------------------------- |
| ![المحتوى](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![المحتوى (عمودي)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![نص](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![نص (عمودي)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![صورة](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![مخطط](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![وسائط](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![صورة عبر الإنترنت](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

المثال التالي يتحقق من وجود التخطيط **Blank**، يضيف إليه أربعة عناصر نائب، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب متعمّد: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="تحذير" %}}
تغيير التنسيق الموروث أو شكل العناصر النائبة الموجودة في التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا لا يُضاف تلقائيًا إلى الشرائح العادية القائمة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وافحص كل شريحة مُعتمدة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا يزال يتم استخدامها كما هي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لإزالة تخطيط محدد، استخدم أولًا طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#hasDependingSlides) أو [getDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getDependingSlides). أعد تعيين أي شرائح تابعة قبل استدعاء [LayoutSlide.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#remove). محاولة إزالة تخطيط مستخدم تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/).

## **التحكم في إظهار التذييل على شريحة تخطيط**

يحتوي التخطيط على تذييل خاص به، وعناصر نائب لرقم الشريحة وتاريخ/وقت. استخدم طريقة [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما، على سبيل المثال، تُظهر تخطيطات المحتوى التذييلات بينما لا تُظهر تخطيطات العنوان ذلك.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر التذييل الخاصة به مرئية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحكم في إظهار التذييل على شريحة رئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل متسقة عبر شجرة شريحة رئيسية، استخدم طريقة [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getHeaderFooterManager). تعمل طرق النشر في [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslideheaderfootermanager/) على الشريحة الرئيسة وتخطيطاتها التابعة والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما الفرق بين شريحة رئيسية وشريحة تخطيط؟**

تُعرّف الشريحة الرئيسية سمة العرض التقديمي وتنسيقها المشترك. تنتمي شريحة التخطيط إلى شريحة رئيسية وتُعرّف ترتيبًا واحدًا قابلًا لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوىً خاصًا بالشريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/globallayoutslidecollection/#addClone). عند النسخ بين عروض تقديمية، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أعدّل تخطيطًا قيد الاستخدام بالفعل؟**

تورّث الشرائح التابعة تغييرات التخطيط ما لم تتجاوز التنسيقات أو الكائنات المتأثرة محليًا. يمكن أن يتغيّر شكل العنصر النائب والتنسيق الموروث على العديد من الشرائح مرة واحدة. استخدم [getDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getDependingSlides) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

ترمي Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولًا، أو استخدم [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات غير المشار إليها فقط.