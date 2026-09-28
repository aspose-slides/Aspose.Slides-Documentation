---
title: تطبيق أو تغيير تخطيطات الشرائح في بايثون عبر جافا
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/python-java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- نائبة
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة عنوان
- عنوان ومحتوى
- رأس القسم
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
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لبايثون عبر جافا، إضافة نائبات، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يُعرّف تخطيط الشريحة مواضع وتنسيق النائبات مثل العناوين والنصوص والصور والمخططات والجداول. يوفّر تطبيق التخطيط بنية متسقة للشرائح مع السماح لكل شريحة بمحتواها الخاص.

أكثر التخطيطات شيوعًا هي:

- **شريحة العنوان**: تحتوي على نائبة العنوان ونائبة العنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على نائبة عنوان ونائبة محتوى عامة.
- **فارغة**: لا تحتوي على نائبات محتوى وتكون مفيدة عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

العرض التقديمي يحتوي على ثلاثة مستويات مترابطة:

1. تُعرّف [شريحة رئيسية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/) السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. تنتمي [شريحة تخطيط](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/) إلى شريحة رئيسية وتحدّد ترتيبًا معينًا للنائبات.
1. تستخدم [شريحة عادية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

ترث الشريحة العادية السمة والتنسيق من التخطيط، ويرث التخطيط من شريحة الرئيس. قيمة تُحدد مباشرةً على الشريحة العادية تُعيد كتابة القيمة الموروثة على ذلك المستوى. عند إنشاء شريحة عادية، تُولد أشكال النائبات من التخطيط المحدد، بينما ينتمي المحتوى المدخل إلى تلك النائبات إلى الشريحة العادية.

أضف النائبات المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة نائبة أخرى إلى التخطيط لاحقًا لا تُضيف شكل نائبة مكافئ إلى الشرائح العادية الموجودة تلقائيًا.

لهذا العلاقة نتيجتان مهمتان:

- تعديل التنسيق الموروث أو شكل النائبة الموجودة على التخطيط يمكن أن يُحدّث كل الشريحة التي تعتمد عليه. قبل تحرير تخطيط مُستَخدم، افحص الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن إزالة تخطيط ما يزال مستخدمًا من قبل شريحة. عيّن الشرائح التابعة له إلى تخطيط آخر أولاً، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى العلوي من هذه الهرمية، انظر [شريحة رئيسية](/slides/ar/python-java/slide-master/).

لإخفاء الشعارات الموروثة أو الأشكال الزخرفية من شريحة رئيسية على شريحة واحدة أو عبر تخطيط مشترك، انظر [Control the Visibility of Master Graphics](/slides/ar/python-java/slide-master/). يوضح المثال مقارنة شريحتين تستخدمان نفس الرئيس.

## **تحديد وتطبيق تخطيط الشريحة**

استخدم نوع التخطيط عندما يتبع العرض التعريفات القياسية لتخطيطات PowerPoint. يمكن تحرير أسماء التخطيطات من قبل المستخدم ويمكن تعريبها، لذا فإن الاختيار بناءً على الاسم يكون أقل موثوقية ما لم تتحكم في القالب المصدر.

يبحث المثال التالي عن **العنوان والمحتوى** في أول شريحة رئيسية. إذا كان ذلك التخطيط غير متوفر، ينتقل عمداً إلى **فارغة**. الفحص الثاني للـ `None` ضروري لأن العرض قد يحتوي فقط على تخطيطات مخصصة. ثم يُطبق التخطيط المحدد على أول شريحة عادية عبر طريقة [Slide.setLayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setLayoutSlide).

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

تغيير تخطيط الشريحة لا يزيل الأشكال العادية التي أضيفت مباشرةً إلى الشريحة. ومع ذلك، يمكن أن تتغيّر مواضع النائبات، التنسيق الموروث، والارتباط بين النائبات الموجودة والتخطيط الجديد، لذا افحص الناتج عند الانتقال بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا يُنشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterlayoutslidecollection/#add) على مجموعة تخطيطات الشريحة الرئيسة المستهدفة.

يضيف المثال التالي دائمًا تخطيطًا جديدًا **العنوان والمحتوى** يُسمّى `Report Title and Content`، ثم يضيف شريحة عادية تعتمد عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

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

أضف تخطيطًا فقط عندما يحتاج القالب فعلاً إلى بنية قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب موجودًا بالفعل، اختره وأعد استخدامه بدلاً من إنشاء نسخة مكررة.

## **إضافة نائبات إلى شريحة تخطيط**

توفر طريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getPlaceholderManager) كائنًا من نوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال نائبة إلى التخطيط.

| نائبة PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutplaceholdermanager/) الطريقة |
| ---------------- | ------------------------------------------------------------ |
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

يتأكد المثال التالي من وجود تخطيط **فارغة**، يضيف إليه أربعة نائبات، ثم ينشئ شريحة عادية تستخدم التخطيط المعدَّل. الترتيب مقصود: تُضاف النائبات قبل إنشاء الشريحة العادية، بحيث يستطيع Aspose.Slides توليد أشكال النائبة المقابلة على تلك الشريحة.

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

الناتج:

![النائبات على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو شكل النائبة الموجودة على التخطيط يمكن أن يؤثر على الشرائح التابعة. النائبة المضافة حديثًا لا تُملأ تلقائيًا في الشرائح العادية القائمة. اختبر تغييرات التخطيط على نسخة من العرض وافحص كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام كما هي.

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

لإزالة تخطيط محدد واحد، استدعِ أولاً طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#hasDependingSlides) أو [getDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getDependingSlides). أعد تعيين أي شرائح تابعة قبل استدعاء [LayoutSlide.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#remove). محاولة إزالة تخطيط مُستَخدم تُطلق استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/).

## **التحكم في إظهار التذييل على شريحة التخطيط**

للتخطيط خاصية تذييل، رقم الشريحة، وتاريخ/وقت نائبة خاصة به. استخدم طريقة [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) للتحكم في تلك النائبات لتخطيط واحد. هذا مفيد عندما يُراد أن تُظهر تخطيطات المحتوى التذييلات بينما لا تُظهر تخطيطات العنوان ذلك.

يختار المثال التالي تخطيطًا بأمان ويجعل عناصر التذييل الخاصة به مرئية:

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

## **التحكم في إظهار التذييل على الشريحة الرئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل متسقة عبر هيكل شريحة رئيسية، استدعِ طريقة [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getHeaderFooterManager). تعمل طرق النشر في [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslideheaderfootermanager/) على الشريحة الرئيسة وتخطيطاتها التابعة والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

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

## **الأسئلة الشائعة**

**ما هو الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

تُعرّف الشريحة الرئيسية سمة العرض وتنسيق العناصر المشتركة. تنتمي شريحة التخطيط إلى شريحة رئيسية وتحدد ترتيبًا قابلاً لإعادة الاستخدام للنائبات. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوى كل شريحة على حدة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستعمال طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/globallayoutslidecollection/#addClone). عند النسخ بين عروض تقديمية، تحقَّق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط مُستخدم بالفعل؟**

تُورّث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. يمكن أن يتغيّر شكل النائبة والتنسيق الموروث على العديد من الشرائح دفعة واحدة. استخدم [getDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getDependingSlides) لتحديد الشرائح المتأثرة قبل تحرير التخطيط.

**ماذا يحدث إذا قمت بإزالة تخطيط ما زال قيد الاستخدام؟**

يطلق Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/). عيّن الشرائح التابعة أولاً إلى تخطيط آخر، أو استعمل [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات غير المرجعية فقط.