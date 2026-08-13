---
title: إدارة عقد شكل SmartArt في العروض التقديمية على Android
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/androidjava/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعد
- تنسيق التعبئة
- عرض العقدة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides لنظام Android. احصل على أمثلة شفرة Java واضحة ونصائح لتبسيط عروضك التقديمية."
---
## **نظرة عامة**

يتم تنظيم رسومات SmartArt في عروض PowerPoint من خلال عقد تحتوي على نص وتحدد بنية المخطط. يتيح Aspose.Slides لك العمل مع هذه العقد الخاصة بـ SmartArt برمجيًا: إضافة عقد جديدة وعُقَد فرعية، وإدراج عُقَد فرعية في موقع محدد، والوصول إلى العقد الموجودة، وقراءة نصها ومستواها وموقعها.

تشرح هذه المقالة كيفية إدارة عقد الأشكال SmartArt. وتوضح طريقة إزالة العقد، والعمل مع العُقَد الفرعية حسب الفهرس أو الموقع، وتحويل عقدة المساعد إلى عقدة عادية، وضبط موقع وحجم ودوران أشكال عقد SmartArt، وتعيين تنسيقات ملء العقد، وإنشاء صورة مصغرة لعقدة SmartArt.

## **إضافة عقدة SmartArt**
قدمت Aspose.Slides for Android عبر Java أبسط واجهة برمجة تطبيقات لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك الكود المثال التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) وتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
5. [إضافة عقدة جديدة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) وتعيين النص في TextFrame.
6. الآن، [إضافة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) في العقدة [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) المضافة حديثًا وتعيين النص في TextFrame.
7. حفظ العرض.

```java
import com.aspose.slides.*;

// تحميل العرض التقديمي المطلوب
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

## **إضافة عقدة SmartArt في موقع محدد**
في الكود المثال التالي شرحنا كيفية إضافة العُقَد الفرعية التابعة للعقد المختلفة لشكل SmartArt في موقع معين.

1. إنشاء مثيل من الفئة Presentation.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. إضافة شكل [**StackedList**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArt) في الشريحة التي تم الوصول إليها.
4. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
5. الآن، أضف [**Child Node**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) للعقدة [**Node**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtNode) المختارة في الموقع 2 وتعيين نصها.
6. حفظ العرض.

```java
import com.aspose.slides.*;

// إنشاء مثال عرض تقديمي
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
سيساعدك الكود المثال التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أن LayoutType الخاص بـ SmartArt يتم اختياره عند إضافة الشكل؛ تعديل ذلك لاحقًا باستخدام **setLayout** يعيد بناء المخطط بالكامل، لذا يتم إعادة حساب مواقع وأحجام العقد التي قد تكون قد ضبطتها.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) وتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
5. التنقل عبر جميع [**Nodes**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
6. الوصول إلى وعرض معلومات مثل موقع عقدة SmartArt، المستوى والنص.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation
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

## **الوصول إلى عقدة SmartArt الفرعية**
سيساعدك الكود المثال التالي على الوصول إلى العُقَد الفرعية التابعة للعقد المختلفة لشكل SmartArt.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) وتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
5. التنقل عبر جميع [**Nodes**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
6. لكل عقدة [**Node**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtNode) مختارة، التنقل عبر جميع [**Child Nodes**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) داخل العقدة المحددة.
7. الوصول إلى وعرض معلومات مثل موقع العقدة الفرعية، المستوى والنص.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation
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
                
                // التنقل عبر العقد الفرعية في عقدة SmartArt الفهرس i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // الوصول إلى العقدة الفرعية في عقدة SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // طباعة معلمات العقدة الفرعية لـ SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة SmartArt الفرعية في موقع محدد**
سنستعرض في هذا المثال كيفية الوصول إلى العُقَد الفرعية في موقع معين تتبع للعقد المختلفة لشكل SmartArt.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) .
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. إضافة شكل [**StackedList**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) من نوع SmartArt.
4. الوصول إلى شكل SmartArt المضاف.
5. الوصول إلى العقدة ذات الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
6. الآن، الوصول إلى [**Child Node**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) في الموقع 1 للعقدة المختارة باستخدام طريقة **get_Item()**.
7. الوصول إلى وعرض معلومات مثل موقع العقدة الفرعية، المستوى والنص.

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
    
    // طباعة معلمات العقدة الفرعية لـ SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) وتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
5. التحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.
6. تحديد عقدة SmartArt المراد حذفها.
7. الآن، إزالة العقدة المحددة باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
8. حفظ العرض.

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

## **إزالة عقدة SmartArt من موقع محدد**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موقع معين.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) وتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
5. تحديد عقدة شكل SmartArt في الفهرس 0.
6. الآن، التحقق مما إذا كانت العقدة المختارة تحتوي على أكثر من عقدتين فرعيتين.
7. الآن، إزالة العقدة في **الموقع 1** باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
8. حفظ العرض.

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
الآن يدعم Aspose.Slides for Android عبر Java تعيين خصائص [SmartArtShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShape#setX-float-) و [Y](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShape#setY-float-). يوضح المقتطف التالي كيفية تعيين موضع وشكل ودوران مخصصين لـ SmartArtShape؛ يرجى ملاحظة أن إضافة عقد جديدة يتسبب في إعادة حساب مواضع وأحجام جميع العقد. كما يمكن للمستخدم ضبط المواقع وفق المتطلبات باستخدام إعدادات الموقع المخصصة.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation
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

## **التحقق من عقدة المساعد**
{{% alert color="info" %}} 

في هذه المقالة سنستكشف المزيد من ميزات أشكال SmartArt المضافة إلى شرائح العرض برمجيًا باستخدام Aspose.Slides for Android عبر Java.

{{% /alert %}} 

سنستخدم شكل SmartArt المصدر التالي لتحقيقاتنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt المصدر في الشريحة**|

في الكود المثال التالي سنستكشف كيفية تحديد **Assistant Nodes** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) وتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
5. التنقل عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت **Assistant Nodes** باستخدام [**Assistant Nodes**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
6. تغيير حالة عقدة المساعد إلى عقدة عادية.
7. حفظ العرض.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation
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
    
            // التنقل عبر جميع عقد شكل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISSmartArtNode node = smart.getAllNodes().get_Item(i);
                // التحقق مما إذا كانت العقدة عقدة مساعد
                if (node.isAssistant()) 
                {
                    // تعيين عقدة المساعد إلى false وجعلها عقدة عادية
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
|**الشكل: تم تغيير عقد المساعد في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق ملء العقدة**
يتيح Aspose.Slides for Android عبر Java إمكانية إضافة أشكال SmartArt مخصصة وتعيين تنسيق ملئها. تشرح هذه المقالة كيفية إنشاء أو الوصول إلى أشكال SmartArt وتعيين تنسيق ملئها باستخدام Aspose.Slides for Android عبر Java.

يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. إضافة شكل [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArt) بتحديد [**LayoutType**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) الخاص به.
4. تعيين [**FillFormat**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShape#getFillFormat--) لعقد شكل SmartArt.
5. كتابة العرض المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء عرض تقديمي
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

## **إنشاء صورة مصغرة لعقدة SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة من SmartArt باتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
2. [إضافة SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. الحصول على مرجع العقدة باستخدام فهرستها.
4. الحصول على صورة المصغرة.
5. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.

```java
import com.aspose.slides.*;

// إنشاء فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إضافة SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // الحصول على مرجع العقدة باستخدام فهرستها
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // الحصول على صورة مصغرة
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

## **الأسئلة الشائعة**

### هل يتم دعم الرسوم المتحركة لـ SmartArt؟

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/androidjava/shape-animation/) (دخول، خروج، تركيز، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الضرورة.

### كيف يمكنني تحديد موقع SmartArt معين على شريحة إذا كان المعرف الداخلي غير معروف؟

استخدم وابحث بواسطة [النص البديل](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getAlternativeText--). يتيح تعيين AltText مميز على SmartArt العثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

### هل سيظل مظهر SmartArt محفوظًا عند تحويل العرض إلى PDF؟

نعم. يقوم Aspose.Slides بتصوير SmartArt بدقة بصرية عالية أثناء [تصدير PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان وال Effects.

### هل يمكنني استخراج صورة كاملة لـ SmartArt (للمعاينات أو التقارير)?

نعم. يمكنك تحويل شكل SmartArt إلى [تنسيقات نقطية](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) أو إلى [SVG](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) لإخراج متجه قابل للتوسيع، مما يجعله مناسبًا للصور المصغرة أو التقارير أو الاستخدام على الويب.