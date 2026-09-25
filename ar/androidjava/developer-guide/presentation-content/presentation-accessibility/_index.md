---
title: "إدارة إمكانية وصول العروض التقديمية على Android"
linktitle: "إمكانية وصول العرض التقديمي"
type: docs
weight: 30
url: /ar/androidjava/presentation-accessibility/
keywords:
- "إمكانية وصول العرض التقديمي"
- "النص البديل"
- "عنوان النص البديل"
- "وصف النص البديل"
- "تحديد كديكوري"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Android"
- "Java"
- "Aspose.Slides"
description: "اكتشف كيف يساعد Aspose.Slides for Android عبر Java في أتمتة فحص إمكانية وصول العروض التقديمية في ملفات PPT و PPTX و ODP — تحسين تجربة قارئ الشاشة وتعزيز الامتثال."
---
## **مقدمة**

يساعد النص البديل الأشخاص الذين يستخدمون تقنيات المساعدة على فهم معنى الصور والمخططات والأشكال الإعلامية الأخرى. يشرح هذا المقال كيفية قراءة وتحديث عناوين النص البديل ووصفه باستخدام Aspose.Slides for Android عبر Java، وتمييز أوصاف إمكانية الوصول عن أسماء الأشكال المستخدمة في الشيفرة، والتحقق مما إذا كان الشكل محددًا كديكوري.

هذه الميزات تدعم إمكانية الوصول إلى العروض التقديمية، لكنها لا تضمنها. يجب أيضًا مراجعة ترتيب القراءة، وتباين الألوان، وقابلية قراءة النص، ومتطلبات إمكانية الوصول الأخرى.

## **إدارة عناوين النص البديل ووصفه**

استخدم النص البديل لتوضيح معنى الصور والمخططات والأشكال الإعلامية للأشخاص الذين لا يستطيعون رؤيتها. الطرق والمحتويات التالية تخدم أغراضًا مختلفة:

| الطريقة أو المحتوى | الهدف |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | عنوان قصير للوصف البديل. |
| [getAlternativeText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | وصف معنوي لمحتوى الشكل أو هدفه في سياق الشريحة. |
| [getName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getName--) | اسم الشكل، الذي يمكن للشيفرة استخدامه للعثور على شكل محدد في العرض. |
| النص الظاهر | المحتوى المعروض على الشريحة، مثل نص الشكل أو عنوان المخطط والتسميات. تحديث النص البديل لا يغيّر هذا المحتوى. |

عند إعادة استخدام عرض تقديمي كقالب، قد تجد الشيفرة شكلًا بالاسم الذي تعيده الدالة [getName] قبل تحديثه. هذا الاسم يخدم غرضًا مختلفًا عن النص البديل، الذي يوضح ما ينقله العنصر البصري للقارئ. يسمح البحث بالاسم للمؤلفين بتحسين أو ترجمة الأوصاف دون تغيير طريقة العثور على الشكل في الشيفرة. يمكن تحرير الأسماء ولا يضمن أن تكون فريدة، لذا تحقق من أن الاسم يطابق الشكل المقصود؛ راجع [Identify and Find Shapes](/slides/ar/androidjava/shape-manipulations/#identify-and-find-shapes).

يتطلب المثال التالي ملف `input.pptx` يحتوي على صورة لمدخل مكتب كأول شكل في الشريحة الأولى. يجب ألا تكون الصورة محددة كديكوري. يقرأ المثال وينطبع عنوان النص البديل الحالي ووصفه، ثم يحدث القيمتين، ويحفظ العرض باسم `output.pptx`. عدّل الصياغة لتتناسب مع الصورة الفعلية والمعلومات التي تنقلها.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إضافة النص البديل وحده لا يضمن إمكانية وصول العرض التقديمي أو الامتثال لمعايير الوصول. راجع الأوصاف للتأكد من دقتها وصلتها، وتحقق أيضًا من ترتيب القراءة، وتباين الألوان، وقابلية قراءة النص، والمتطلبات الأخرى للوصول. لا يجب تحديد العناصر البصرية الإعلامية كديكوري؛ يوضح القسم التالي كيفية التحقق من [isDecorative](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **تحديد كديكوري**

تحديد كديكوري يعلّم العناصر البصرية الزخرفية فقط بحيث تتجاوزها قارئات الشاشة، مما يقلل الضوضاء ويحافظ على تركيز المستخدم على المحتوى المفيد. طبّقها على الخلفيات، والزخارف، والمسافات الفاصلة—ولا تستخدمها أبداً على المخططات أو الأيقونات أو الصور التي تنقل معلومات. توفر Aspose.Slides هذه الخاصية للكشف والتحقق، مما يتيح فحوصات وصول آلية وتنظيف.

![تحديد كديكوري](mark_as_decorative.png)

يوضح مثال التعليمات البرمجية التالي كيفية تحديد ما إذا كان الشكل محددًا كديكوري.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتداولة**

**ماذا يجب أن أضع في عنوان النص البديل ووصفه؟**

استخدم عنوانًا قصيرًا لتحديد الموضوع ووصفًا لتوضيح المعلومات التي ينقلها العنصر البصري في سياق الشريحة. بالنسبة للمخطط، صِف الاتجاه أو المقارنة ذات الصلة بدلاً من القول فقط "مخطط".

**هل يجب استخدام النص البديل لتحديد موقع الأشكال في القالب؟**

يفضل العثور على الشكل بالاسم الذي تُعيده الدالة [getName] والتحقق من أنه الشكل المتوقع. قد يتم تحرير النص البديل أو ترجمته، مما قد يكسر الشيفرة التي تبحث عن وصف مطلق؛ راجع [Identify and Find Shapes](/slides/ar/androidjava/shape-manipulations/).

**متى يجب تحديد الشكل كديكوري؟**

استخدم علم الديكورية للعناصر البصرية التي لا تضيف معلومات، مثل الزخارف الزينة. الصور والمخططات التي تنقل معنى تحتاج إلى وصف مناسب بدلاً من ذلك.

**هل يجعل إضافة النص البديل العرض التقديمي قابلاً للوصول بالكامل؟**

لا. النص البديل يعالج جزءًا فقط من الوصول. يجب أيضًا مراجعة ترتيب القراءة، وتباين الألوان، وقابلية قراءة النص، والمتطلبات الأخرى ذات الصلة؛ ضبط هذه الخصائص وحدها لا يضمن الامتثال.