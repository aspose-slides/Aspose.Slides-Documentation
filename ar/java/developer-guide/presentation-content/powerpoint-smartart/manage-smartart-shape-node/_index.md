---
title: إنشاء أو إدارة عقدة شكل SmartArt في PowerPoint باستخدام Java
linktitle: إدارة عقدة شكل SmartArt
type: docs
weight: 30
url: /java/manage-smartart-shape-node/
keywords: smartart باوربوينت, عقد smartart, موضع smartart, إزالة smartart, إضافة عقد smartart, عرض باوربوينت, باوربوينت جافا, واجهة برمجة التطبيقات باوربوينت جافا
description: إدارة عقدة الفن الذكي والعقدة الفرعية في عروض PowerPoint باستخدام Java
---

## **إضافة عقدة SmartArt في عرض PowerPoint باستخدام Java**
قدمت Aspose.Slides لجافا أبسط واجهة برمجة التطبيقات لإدارة أشكال SmartArt بطريقة سهلة. سيساعدك الكود المثال التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) ومحمل العرض مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التجول عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) وتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. [إضافة عقدة جديدة](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) وضبط النص في TextFrame.
1. الآن، [أضف](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**عقدة فرعية**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) في عقدة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) الجديدة واضبط النص في TextFrame.
1. حفظ العرض.

```java
// تحميل العرض المرغوب
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // التجول عبر كل شكل داخل الشريحة الأولى
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
    
            // إضافة عقدة فرعية جديدة في العقدة الرئيسية. سيتم إضافتها في نهاية المجموعة.
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // إضافة نص
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // حفظ العرض
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة عقدة SmartArt في موضع محدد**
في الكود المثال التالي، قمنا بشرح كيفية إضافة العقد الفرعية التي تنتمي إلى العقد المقابلة لشكل SmartArt في موضع معين.

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. إضافة شكل SmartArt من نوع [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) في الشريحة التي تم الوصول إليها.
1. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
1. الآن، أضف [**عقدة فرعية**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) للعقدة المحددة [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) في الموضع 2 واضبط نصها.
1. حفظ العرض.

```java
// إنشاء مثيل العرض
Presentation pres = new Presentation();
try {
    // الوصول إلى شريحة العرض
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // الوصول إلى عقدة SmartArt في الفهرس 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // إضافة عقدة فرعية جديدة في الموضع 2 في العقدة الرئيسية
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // إضافة نص
    chNode.getTextFrame().setText("Sample Text Added");

    // حفظ العرض
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة SmartArt في عرض PowerPoint باستخدام Java**
سيساعدك الكود المثال التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType من SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) ومحمل العرض مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التجول عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) وتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التجول عبر جميع [**العقد**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. الوصول وإظهار معلومات مثل موضع عقدة SmartArt، المستوى والنص.

```java
// إنشاء مثيل فئة Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التجول عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // التجول عبر جميع العقد داخل SmartArt
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

## **الوصول إلى عقدة Child Node من SmartArt**
سيساعدك الكود المثال التالي على الوصول إلى العقد الفرعية التي تنتمي إلى العقد المقابلة لشكل SmartArt.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) ومحمل العرض مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التجول عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) وتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التجول عبر جميع [**العقد**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. بالنسبة لكل شكل SmartArt محدد [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode)، التجول عبر جميع [**العقد الفرعية**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) داخل عقدة معينة.
1. الوصول وإظهار معلومات مثل موضع [**عقدة Child**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)، المستوى والنص.

```java
// إنشاء مثيل فئة Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التجول عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // التجول عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // الوصول إلى عقدة SmartArt في الفهرس i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // التجول عبر العقد الفرعية في عقدة SmartArt في الفهرس i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // الوصول إلى العقدة الفرعية في عقدة SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // طباعة معلمات عقدة SmartArt الفرعية
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة Child Node في موضع محدد**
في هذا المثال، سنتعلم الوصول إلى العقد الفرعية في موضع معين تنتمي إلى العقد المقابلة لشكل SmartArt.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. إضافة شكل SmartArt من نوع [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. الوصول إلى شكل SmartArt المضاف.
1. الوصول إلى العقدة في الفهرس 0 لشكل SmartArt المضاف.
1. الآن، الوصول إلى [**عقدة Child**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) في الموضع 1 لربط العقدة الشجرية باستخدام **get_Item()**.
1. الوصول وإظهار معلومات مثل موضع [**عقدة Child**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)، المستوى والنص.

```java
// إنشاء مثيل العرض
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt في الشريحة الأولى
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // الوصول إلى عقدة SmartArt في الفهرس 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // الوصول إلى عقدة الفرعية في الموضع 1 في العقدة الرئيسية
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // طباعة معلمات عقدة SmartArt الفرعية
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt في عرض PowerPoint باستخدام Java**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) ومحمل العرض مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التجول عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) وتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التحقق مما إذا كان [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) لديه أكثر من 0 عقد.
1. تحديد عقدة SmartArt المراد حذفها.
1. الآن، إزالة العقدة المختارة باستخدام [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) الطريقة.
1. حفظ العرض.

```java
// تحميل العرض المرغوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // التجول عبر كل شكل داخل الشريحة الأولى
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
    
                // إزالة العقدة المختارة
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // حفظ العرض
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) ومحمل العرض مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التجول عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) وتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. تحديد عقدة الشكل SmartArt في الفهرس 0.
1. الآن، التحقق مما إذا كانت العقدة SmartArt المختارة تحتوي على أكثر من 2 عقدة فرعية.
1. الآن، إزالة العقدة في **الموضع 1** باستخدام [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) الطريقة.
1. حفظ العرض.

```java
// تحميل العرض المرغوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // التجول عبر كل شكل داخل الشريحة الأولى
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
    
    // حفظ العرض
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين موضع مخصص لعقدة فرعية في SmartArt**
الآن تدعم Aspose.Slides لجافا تعيين خصائص موضع [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) و[Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-). يوضح الكود التالي كيفية ضبط موضع SmartArtShape مخصص، الحجم والدوران. يرجى ملاحظة أن إضافة عقد جديدة تتسبب في إعادة حساب المواضع والأحجام لجميع العقد. أيضًا، مع إعدادات الموضع المخصص، يمكن للمستخدم تعيين العقد وفقًا لمتطلباته.

```java
// إنشاء مثيل فئة Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // نقل شكل SmartArt إلى موضع جديد
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // تغيير عرض أشكال SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // تغيير ارتفاع أشكال SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // تغيير دوران أشكال SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **تحقق من عقدة المساعد**
{{% alert color="primary" %}} 

في هذه المقالة، سنقوم بمزيد من التحقيق في ميزات أشكال SmartArt المضافة في الشرائح البرمجية باستخدام Aspose.Slides لجافا.

{{% /alert %}} 

سوف نستخدم شكل SmartArt المصدر التالي لتحقيقنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt المصدر في شريحة**|

في الكود المثال التالي، سنحقق كيفية تحديد **العقد المساعدة** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) ومحمل العرض مع شكل SmartArt.
1. الحصول على مرجع الشريحة الثانية باستخدام فهرسها.
1. التجول عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) وتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. التجول عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت [**عقد مساعد**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. تغيير حالة العقدة المساعد إلى عقدة عادية.
1. حفظ العرض.

```java
// إنشاء مثيل العرض
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // التجول عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // التجول عبر جميع العقد في شكل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // التحقق مما إذا كانت العقدة عقدة مساعد
                if (node.isAssistant()) 
                {
                    // ضبط العقدة المساعدة على خطأ وجعلها عقدة عادية
                    node.isAssistant();
                }
            }
        }
    }
    
    // حفظ العرض
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**الشكل: تم تغيير العقد المساعدة في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق التعبئة للعقدة**
تجعل Aspose.Slides لجافا من الممكن إضافة أشكال SmartArt مخصصة وتعيين تنسيق التعبئة. تشرح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة باستخدام Aspose.Slides لجافا.

يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة شكل [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) من خلال تعيين [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. تعيين [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) لعقد أشكال SmartArt.
1. كتابة العرض المعدل كملف PPTX.

```java
// إنشاء مثيل العرض
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt والعقد
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // تعيين لون التعبئة للعقدة
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // حفظ العرض
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء صورة مصغرة لعقدة Child من SmartArt**
يمكن للمطورين إنشاء صورة مصغرة للعقدة الفرعية لشكل SmartArt من خلال اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. [إضافة SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. الحصول على مرجع لعقدة باستخدام فهرسها.
1. الحصول على صورة المصغرة.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

```java
// إنشاء مثيل فئة Presentation التي تمثل ملف PPTX 
Presentation pres = new Presentation();
try {
    // إضافة SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // الحصول على مرجع لعقدة باستخدام فهرسها  
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