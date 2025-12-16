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
- إزالة عقدة
- موضع مخصص
- عقدة مساعد
- تنسيق التعبئة
- تصيير العقدة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides لنظام Android. احصل على أمثلة شفرة Java واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **إضافة عقدة SmartArt**
Aspose.Slides for Android via Java يوفر أبسط واجهة برمجية لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك الكود النموذجي التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. استعراض كل شكل داخل الشريحة الأولى.  
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وتحويله إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان كذلك.  
1. [إضافة عقدة جديدة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) إلى مجموعة العقد **NodeCollection** داخل شكل SmartArt وتعيين النص في TextFrame.  
1. الآن، [إضافة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) **عقدة فرعية** إلى عقدة SmartArt التي أضيفت حديثًا وتعيين النص في TextFrame.  
1. حفظ العرض التقديمي.  
```java
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // استعراض كل شكل داخل الشريحة الأولى
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
    
            // إضافة عقدة فرعية جديدة إلى العقدة الأصلية. سيتم إضافتها في نهاية المجموعة
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
في الكود النموذجي التالي شرحنا كيفية إضافة العقد الفرعية التي تنتمي إلى العقد المختلفة لشكل SmartArt في موضع معين.

1. إنشاء نسخة من فئة Presentation.  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. إضافة شكل [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) إلى الشريحة التي تم الوصول إليها.  
1. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.  
1. الآن، إضافة **العقدة الفرعية** للـ **Node** المحدد في الموضع 2 وتعيين نصها.  
1. حفظ العرض التقديمي.  
```java
// إنشاء نسخة من العرض التقديمي
Presentation pres = new Presentation();
try {
    // الوصول إلى شريحة العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // الوصول إلى عقدة SmartArt عند الفهرس 0
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
الكود التالي سيساعدك على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. استعراض كل شكل داخل الشريحة الأولى.  
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وتحويله إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان كذلك.  
1. استعراض جميع **العقد** داخل شكل SmartArt.  
1. الوصول وعرض معلومات مثل موضع عقدة SmartArt، المستوى والنص.  
```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // المرور عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل النوع إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // المرور عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // الوصول إلى عقدة SmartArt عند الفهرس i
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
الكود التالي سيساعدك على الوصول إلى العقد الفرعية التي تنتمي إلى العقد المختلفة لشكل SmartArt.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. استعراض كل شكل داخل الشريحة الأولى.  
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وتحويله إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان كذلك.  
1. استعراض جميع **العقد** داخل شكل SmartArt.  
1. لكل **Node** مختار في شكل SmartArt، استعراض جميع **العقد الفرعية** داخل العقدة المحددة.  
1. الوصول وعرض معلومات مثل موضع **العقدة الفرعية**، المستوى والنص.  
```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // المرور عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // المرور عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // الوصول إلى عقدة SmartArt عند الفهرس i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // المرور عبر العقد الفرعية في عقدة SmartArt عند الفهرس i
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
في هذا المثال سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين تنتمي إلى العقد المختلفة لشكل SmartArt.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. إضافة شكل SmartArt من نوع [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
1. الوصول إلى شكل SmartArt المضاف.  
1. الوصول إلى العقدة ذات الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.  
1. الآن، الوصول إلى **العقدة الفرعية** في الموضع 1 للعقدة المستهدفة باستخدام طريقة **get_Item()**.  
1. الوصول وعرض معلومات مثل موضع **العقدة الفرعية**، المستوى والنص.  
```java
// إنشاء نسخة من العرض التقديمي
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt في الشريحة الأولى
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // الوصول إلى عقدة SmartArt عند الفهرس 0
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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. استعراض كل شكل داخل الشريحة الأولى.  
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وتحويله إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان كذلك.  
1. التحقق مما إذا كان لدى SmartArt أكثر من 0 عقد.  
1. اختيار عقدة SmartArt التي سيتم حذفها.  
1. الآن، إزالة العقدة المحددة باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
1. حفظ العرض التقديمي.  
```java
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // استعراض كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // الوصول إلى عقدة SmartArt عند الفهرس 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // إزالة العقدة المختارة
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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
1. استعراض كل شكل داخل الشريحة الأولى.  
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وتحويله إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان كذلك.  
1. اختيار عقدة شكل SmartArt في الفهرس 0.  
1. الآن، التحقق مما إذا كانت العقدة المختارة تحتوي على أكثر من عقدتين فرعيتين.  
1. الآن، إزالة العقدة في **الموضع 1** باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
1. حفظ العرض التقديمي.  
```java
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // استعراض كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof SmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // الوصول إلى عقدة SmartArt عند الفهرس 0
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
الآن يدعم Aspose.Slides for Android via Java تعيين خصائص [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) لـ [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) و [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-). يوضح المقتطف التالي كيفية تعيين موضع SmartArtShape مخصص، وحجمه، وتدويره. يرجى ملاحظة أن إضافة عقد جديدة يتسبب في إعادة حساب المواضع والأحجام لجميع العقد. كما يمكن للمستخدم ضبط مواضع العقد وفق المتطلبات.  
```java
// إنشاء فئة Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // نقل شكل SmartArt إلى موقع جديد
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

    // تغيير تدوير شكل SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```


## **التحقق من عقدة المساعد**
{{% alert color="primary" %}} 

في هذه المقالة سنستكشف المزيد من ميزات أشكال SmartArt المضافة إلى شرائح العرض برمجياً باستخدام Aspose.Slides for Android via Java.

{{% /alert %}} 

سنستخدم شكل SmartArt المصدر التالي في تحقيقاتنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt المصدر في الشريحة**|

في الكود التالي سنستكشف كيفية تحديد **العقد المساعدة** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
1. الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.  
1. استعراض كل شكل داخل الشريحة الأولى.  
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وتحويله إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان كذلك.  
1. استعراض جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت **عقد مساعد** من خلال [**Assistant Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
1. تغيير حالة عقدة المساعد إلى عقدة عادية.  
1. حفظ العرض التقديمي.  
```java
// إنشاء نسخة من العرض التقديمي
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // المرور عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // المرور عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // التحقق مما إذا كانت العقدة عقدة مساعد
                if (node.isAssistant()) 
                {
                    // تعيين عقدة المساعد إلى false وجعلها عقدة عادية
                    node.isAssistant();
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
Aspose.Slides for Android via Java يجعل من الممكن إضافة أشكال SmartArt مخصصة وتعيين تنسيق ملئها. تشرح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق ملئها باستخدام Aspose.Slides for Android عبر Java.

يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.  
1. إضافة شكل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) عن طريق تعيين **LayoutType** الخاص به.  
1. تعيين **FillFormat** لعقد شكل SmartArt.  
1. كتابة العرض التقديمي المعدل كملف PPTX.  
```java
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
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية من SmartArt باتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. [إضافة SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. الحصول على مرجع عقدة باستخدام الفهرس الخاص بها.  
1. الحصول على صورة المصغرة.  
1. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.  
```java
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX 
Presentation pres = new Presentation();
try {
    // إضافة SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // الحصول على مرجع عقدة باستخدام الفهرس الخاص بها  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // استخراج الصورة المصغرة
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


## **الأسئلة المتكررة**

**هل تدعم رسوميات SmartArt المتحركة؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوميات القياسية](/slides/ar/androidjava/shape-animation/) (دخول، خروج، تأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt معين على الشريحة إذا كان معرفه الداخلي غير معروف؟**

قم بتعيين والبحث باستخدام [النص البديل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--). ضبط AltText مميز على SmartArt يتيح لك العثور عليه برمجياً دون الاعتماد على المعرفات الداخلية.

**هل سيُحافظ على مظهر SmartArt عند تحويل العرض التقديمي إلى PDF؟**

نعم. يقوم Aspose.Slides بتصدير SmartArt بجودة بصرية عالية أثناء [تصدير PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكن استخراج صورة لكامل SmartArt (للمعاينات أو التقارير)؟**

نعم. يمكنك تصيير شكل SmartArt إلى [صيغ نقطية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) أو إلى [SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) لإخراج متجه قابل للتحجيم، مما يجعله مناسبًا للمصغرات، التقارير أو الاستخدام على الويب.  
{{95c463e2-d38f-49df-9366-c47435d38093}}