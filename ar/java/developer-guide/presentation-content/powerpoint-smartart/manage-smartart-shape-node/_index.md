---
title: إدارة عقد شكل SmartArt في العروض التقديمية باستخدام Java
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/java/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعدة
- تنسيق ملء
- تصيير العقدة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides for Java. احصل على أمثلة كود واضحة ونصائح لتبسيط عروضك التقديمية."
---
## **نظرة عامة**

رسوم SmartArt في عروض PowerPoint منظمة عبر العقد التي تحتوي على النص وتحدد بنية المخطط. يتيح Aspose.Slides لك التعامل مع هذه العقد البرمجية: إضافة عقد جديدة وعقد فرعية، إدراج عقد فرعية في موضع محدد، الوصول إلى العقد الموجودة، وقراءة نصها ومستواها وموقعها.

تشرح هذه المقالة كيفية إدارة عقد شكل SmartArt. تظهر كيفية إزالة العقد، والعمل مع العقد الفرعية حسب الفهرس أو الموقع، وتحويل عقدة مساعدة إلى عقدة عادية، وضبط موضع وحجم ودوران أشكال عقد SmartArt، وتعيين تنسيقات ملء العقد، وإنشاء صورة مصغرة لعقدة فرعية في SmartArt.

## **إضافة عقدة SmartArt**
قامت Aspose.Slides for Java بتوفير أبسط واجهة برمجية لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك المثال البرمجي التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt#getAllNodes--) وحدد النص في TextFrame.
1. الآن، استخدم [Add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) لإضافة [**Child Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#getChildNodes--) في العقدة التي تم إضافتها حديثًا إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وحدد النص في TextFrame.
1. احفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof SmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // إضافة عقدة SmartArt جديدة
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // إضافة نص
            TemNode.getTextFrame().setText("Test");
    
            // إضافة عقدة فرعية جديدة في العقدة الأصلية. سيتم إضافتها في نهاية المجموعة
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // إضافة نص
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // حفظ العرض التقديمي
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة عقدة SmartArt في موضع محدد**
في المثال البرمجي التالي شرحنا كيفية إضافة العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt في موضع معين.

1. إنشاء نسخة من فئة Presentation.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. أضف شكل [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArt) من نوع [**StackedList**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtLayoutType#StackedList) في الشريحة التي تم الوصول إليها.
1. الوصول إلى أول عقدة في شكل SmartArt المضاف.
1. الآن، أضف [**Child Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#getChildNodes--) للعقدة المحددة [**Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtNode) في الموضع 2 وحدد نصها.
1. احفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء نسخة من العرض التقديمي
Presentation pres = new Presentation();
try {
    // الوصول إلى شريحة العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // الوصول إلى عقدة SmartArt في الفهرس 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأصلية
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // إضافة نص
    chNode.getTextFrame().setText("Sample Text Added");

    // حفظ العرض التقديمي
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة SmartArt**
سيساعدك المثال البرمجي التالي في الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنك لا يمكن تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويُحدد فقط عند إضافة الشكل.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التنقل عبر جميع [**Nodes**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. الوصول إلى وعرض معلومات مثل موضع عقدة SmartArt، المستوى والنص.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة العرض التقديمي
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // التنقل عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // الوصول إلى عقدة SmartArt في الفهرس i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // طباعة معلمات عقدة SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة فرعية في SmartArt**
سيساعدك المثال البرمجي التالي في الوصول إلى العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التنقل عبر جميع [**Nodes**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. لكل عقدة [**Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtNode) محددة، التنقل عبر جميع [**Child Nodes**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtNode#getChildNodes--) داخل تلك العقدة.
1. الوصول إلى وعرض معلومات مثل موضع [**Child Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#getChildNodes--)، المستوى والنص.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة العرض التقديمي
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // التنقل عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // الوصول إلى عقدة SmartArt في الفهرس i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // التنقل عبر العقد الفرعية في عقدة SmartArt في الفهرس i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // الوصول إلى العقدة الفرعية في عقدة SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // طباعة معلمات العقدة الفرعية في SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة فرعية في SmartArt في موضع محدد**
في هذا المثال سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين تابعة للعقد المقابلة في شكل SmartArt.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. أضف شكل SmartArt من نوع [**StackedList**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. الوصول إلى شكل SmartArt المضاف.
1. الوصول إلى العقدة في الفهرس 0 للشكل المستهدف.
1. الآن، الوصول إلى [**Child Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#getChildNodes--) في الموضع 1 للعقدة باستخدام طريقة **get_Item()**.
1. الوصول إلى وعرض معلومات مثل موضع [**Child Node**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#getChildNodes--)، المستوى والنص.

```java
import com.aspose.slides.*;

// إنشاء العرض التقديمي
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt في الشريحة الأولى
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // الوصول إلى عقدة SmartArt في الفهرس 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأصلية
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // طباعة معلمات العقدة الفرعية في SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. تحقق مما إذا كان لدى SmartArt أكثر من 0 عقد.
1. تحديد عقدة SmartArt المراد حذفها.
1. الآن، إزالة العقدة المحددة باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. احفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // الوصول إلى عقدة SmartArt في الفهرس 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // إزالة العقدة المحددة
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // حفظ العرض التقديمي
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt من موضع محدد**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. تحديد عقدة شكل SmartArt في الفهرس 0.
1. الآن، تحقق مما إذا كانت العقدة المختارة تحتوي على أكثر من عقدتين فرعيتين.
1. الآن، إزالة العقدة في **الموضع 1** باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. احفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof SmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // الوصول إلى عقدة SmartArt في الفهرس 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // إزالة العقدة الفرعية في الموضع 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // حفظ العرض التقديمي
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين موضع مخصص لعقدة فرعية في كائن SmartArt**
الآن يدعم Aspose.Slides for Java تعيين خصائص [SmartArtShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShape#setX-float-) و [Y](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShape#setY-float-). يوضح المقتطف التالي كيفية تعيين موضع، حجم ودوران SmartArtShape مخصص، كما يرجى ملاحظة أن إضافة عقد جديدة تتسبب في إعادة حساب مواضع وأحجام جميع العقد. كذلك مع إعدادات الموضع المخصص، يمكن للمستخدم تعيين العقد حسب المتطلبات.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة العرض التقديمي
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // نقل شكل SmartArt إلى موضع جديد
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // تغيير عرض شكل SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // تغيير ارتفاع شكل SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // تغيير دوران شكل SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **التحقق من عقدة مساعدة**
{{% alert color="info" %}} 

في هذه المقالة سنستكشف المزيد من ميزات أشكال SmartArt التي تُضاف إلى شرائح العرض برمجيًا باستخدام Aspose.Slides for Java.

{{% /alert %}} 

سنستخدم الشكل SmartArt المصدر التالي في تحقيقنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt المصدر في الشريحة**|

في المثال البرمجي التالي سنستكشف كيفية تحديد **العقد المساعدة** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الثانية باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التنقل عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت [**Assistant Nodes**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtNode#isAssistant--) .
1. تغيير حالة عقدة المساعدة إلى عقدة عادية.
1. احفظ العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء نسخة من العرض التقديمي
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // التنقل عبر جميع العقد داخل شكل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // التحقق مما إذا كانت العقدة عقدة مساعدة
                if (node.isAssistant()) 
                {
                    // تعيين عقدة المساعدة إلى false وجعلها عقدة عادية
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // حفظ العرض التقديمي
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**الشكل: تم تعديل العقد المساعدة في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق ملء للعقدة**
يتيح Aspose.Slides for Java إمكانية إضافة أشكال SmartArt مخصصة وتعيين تنسيق ملئها. تشرح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق الملء باستخدام Aspose.Slides for Java.

يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة شكل [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArt) عن طريق تحديد [**LayoutType**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) الخاص به.
1. تعيين [**FillFormat**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShape#getFillFormat--) لعقد شكل SmartArt.
1. كتابة العرض التقديمي المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء العرض التقديمي
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt والعقد
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // تعيين لون تعبئة العقدة
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // حفظ العرض التقديمي
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء صورة مصغرة لعقدة فرعية في SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية في SmartArt باتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
1. [Add SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. الحصول على مرجع عقدة باستخدام فهرسها.
1. الحصول على صورة المصغرة.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إضافة SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // الحصول على مرجع عقدة باستخدام فهرسها
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // الحصول على الصورة المصغرة
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // حفظ الصورة المصغرة
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### هل تدعم الرسوم المتحركة لـ SmartArt؟

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/java/shape-animation/) (دخول، خروج، تأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

### كيف يمكنني تحديد موقع SmartArt معين على الشريحة إذا كان معرفه الداخلي غير معروف؟

استخدم وابحث عبر [النص البديل]https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getAlternativeText--). تعيين AltText مميز على SmartArt يتيح لك العثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

### هل سيُحافظ على مظهر SmartArt عند تحويل العرض إلى PDF؟

نعم. Aspose.Slides يقوم بتصدير SmartArt بدقة بصرية عالية أثناء [تصدير PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والمؤثرات.

### هل يمكنني استخراج صورة كاملة لـ SmartArt (للمعاينات أو التقارير)؟

نعم. يمكنك تصيير شكل SmartArt إلى [تنسيقات نقطية]https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getImage-int-float-float-) أو إلى [SVG]https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) للحصول على إخراج متجهي قابل للتوسيع، ما يجعله مناسبًا للمصغرات، التقارير، أو الاستخدام على الويب.