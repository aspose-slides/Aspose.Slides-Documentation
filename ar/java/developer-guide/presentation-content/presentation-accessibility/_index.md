---
title: إدارة إمكانية الوصول للعرض التقديمي في جافا
linktitle: إمكانية وصول العرض التقديمي
type: docs
weight: 30
url: /ar/java/presentation-accessibility/
keywords:
- إمكانية وصول العرض التقديمي
- نص بديل
- عنوان النص البديل
- وصف النص البديل
- وضع علامة كزخرفة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيف تساعد Aspose.Slides for Java في أتمتة فحص إمكانية وصول العروض التقديمية في ملفات PPT و PPTX و ODP — تعزيز تجربة قارئ الشاشة وزيادة الامتثال."
---
## **المقدمة**

يساعد النص البديل الأشخاص الذين يستخدمون تقنيات المساعدة على فهم معنى الصور والمخططات والأشكال الإعلامية الأخرى. توضح هذه المقالة كيفية قراءة وتحديث عناوين النص البديل ووصفه باستخدام Aspose.Slides for Java، وكيفية التمييز بين أوصاف إمكانية الوصول وأسماء الأشكال المستخدمة في الشيفرة، وكيفية التحقق مما إذا كان الشكل مُعلمًا كزخرفة.

تدعم هذه الميزات إمكانية الوصول إلى العرض التقديمي، لكنها لا تضمن ذلك. كما يجب مراجعة ترتيب القراءة، وتباين الألوان، وقابلية قراءة النص، وغيرها من متطلبات إمكانية الوصول.

## **إدارة عناوين النص البديل والوصف**

استخدم النص البديل لشرح معنى الصور والمخططات والأشكال الإعلامية الأخرى للأشخاص الذين لا يرونها. الطرق والمحتوى التالي يخدم أغراضًا مختلفة:

| الطريقة أو المحتوى | الغرض |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | عنوان قصير للوصف البديل. |
| [getAlternativeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getAlternativeText--) | وصف ذي معنى لمحتوى الشكل أو هدفه في سياق الشريحة. |
| [getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--) | اسم الشكل، الذي يمكن للشيفرة استخدامه للعثور على شكل معين في العرض. |
| النص الظاهر | المحتوى المعروض على الشريحة، مثل نص الشكل أو عنوان المخطط وعناوينه. لا يغيّر تحديث النص البديل هذا المحتوى. |

عند إعادة استخدام عرض تقديمي كقالب، قد يجد الشيفرة الشكل بالاسم الذي تُعيده الدالة [getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--) قبل تحديثه. هذا الاسم يخدم غرضًا مختلفًا عن النص البديل، الذي يوضح ما ينقله البصري للقارئ. يسمح البحث بالاسم للمؤلفين بتحسين أو ترجمة الأوصاف دون تغيير طريقة العثور على الشكل في الشيفرة. يمكن تعديل الأسماء ولا يُضمن تفردها، لذا تحقق من أن الاسم يطابق الشكل المقصود؛ راجع [تحديد وإيجاد الأشكال](/slides/ar/java/shape-manipulations/#identify-and-find-shapes).

المثال التالي يتطلب وجود ملف `input.pptx` يحتوي على صورة لمدخل مكتب كأول شكل في الشريحة الأولى. يجب ألا تُعلم الصورة كزخرفة. يقرأ المثال ويطبع عنوان النص البديل الحالي ووصفه، ثم يُحدّث القيمتين ويحفظ العرض كـ `output.pptx`. عدّل الصياغة لتتناسب مع الصورة الفعلية والمعلومات التي تنقلها.

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

إضافة النص البديل وحده لا يضمن إمكانية وصول العرض أو الامتثال للمعايير. راجع الأوصاف لضمان الدقة والملاءمة، وتحقق أيضًا من ترتيب القراءة، وتباين الألوان، وقابلية قراءة النص، وغيرها من متطلبات إمكانية الوصول. لا يجب تعليم العناصر البصرية الإعلامية كزخرفة؛ القسم التالي يوضح كيفية التحقق من [isDecorative](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#isDecorative--).

## **وضع علامة كزخرفة**

تُستخدم علامة الزخرفة لتعليم العناصر البصرية الزخرفية فقط بحيث يتخطاها قارئ الشاشة، مما يقلل الضوضاء ويحافظ على تركيز القارئ على المحتوى المفيد. يُطبق ذلك على الخلفيات، والزخارف، والفواصل—ليس على المخططات، أو الأيقونات، أو الصور التي تنقل معلومات. تُظهر Aspose.Slides هذه العلامة للتحقق والتمييز، مما يتيح فحوصات إمكانية وصول آلية وتنظيفًا.

![وضع علامة كزخرفة](mark_as_decorative.png)

يعرض المقتطف البرمجي التالي كيفية تحديد ما إذا كان الشكل مُعلمًا كزخرفة.

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

## **الأسئلة الشائعة**

**ما الذي يجب وضعه في عنوان النص البديل والوصف؟**

استخدم عنوانًا قصيرًا لتحديد الموضوع ووصفًا لشرح المعلومات التي ينقلها العنصر البصري في سياق الشريحة. بالنسبة للمخطط، صِف الاتجاه أو المقارنة ذات الصلة بدلاً من الاكتفاء بقول "مخطط".

**هل يجب استخدام النص البديل لتحديد المواقع الأشكال في القالب؟**

يفضل العثور على الشكل بالاسم الذي تُعيده الدالة [getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--) والتأكد من أنه الشكل المتوقع. قد يتم تعديل النص البديل أو ترجمته، مما قد يعرقل الشيفرة التي تبحث عن وصف دقيق؛ راجع [تحديد وإيجاد الأشكال](/slides/ar/java/shape-manipulations/).

**متى ينبغي تعليم الشكل كزخرفة؟**

استخدم علامة الزخرفة للعناصر البصرية التي لا تضيف معلومات، مثل الزخارف الزينة. الصور والمخططات التي تنقل معنى تحتاج إلى وصف مناسب بدلاً من ذلك.

**هل يجعل إضافة النص البديل العرض التقديمي متاحًا بالكامل؟**

لا. النص البديل يعالج جزءًا فقط من إمكانية الوصول. يجب كذلك مراجعة ترتيب القراءة، وتباين الألوان، وقابلية قراءة النص، وغيرها من المتطلبات ذات الصلة؛ إعداد هذه الخصائص وحدها لا يضمن الامتثال.