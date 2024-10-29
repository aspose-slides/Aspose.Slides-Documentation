---
title: إنشاء أو إدارة عقدة شكل SmartArt في PowerPoint باستخدام Java
linktitle: إدارة عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/androidjava/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart nodes, smartart position, remove smartart, smartart nodes add, powerpoint presentation, powerpoint java, powerpoint java api
description: إدارة العقدة فن الذكاء والعقدة الفرعية في عروض PowerPoint باستخدام Java
---

## **إضافة عقدة SmartArt في عرض PowerPoint باستخدام Java**
لقد قدم Aspose.Slides لـ Android عبر Java أبسط واجهة برمجية لإدارة أشكال SmartArt بأبسط الطرق. سيساعدك الكود النموذجي التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وقم بتحميل العرض مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. انتقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المختار إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. [أضف عقدة جديدة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) واضبط النص في TextFrame.
1. الآن، [أضف](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**عقدة فرعية**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) في عقدة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) التي تمت إضافتها حديثًا واضبط النص في TextFrame.
1. احفظ العرض.

```java
// تحميل العرض المرغوب
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // انتقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof SmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // إضافة عقدة جديدة في SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // إضافة النص
            TemNode.getTextFrame().setText("Test");
    
            // إضافة عقدة فرعية جديدة في العقدة الأم. سيتم إضافتها في نهاية المجموعة
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // إضافة النص
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
في الكود النموذجي التالي، شرحنا كيفية إضافة العقد الفرعية التي تنتمي إلى العقد المقابلة لشكل SmartArt في موضع معين.

1. أنشئ مثيل من فئة Presentation.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. أضف شكل [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) في الشريحة التي تم الوصول إليها.
1. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
1. الآن، أضف [**عقدة فرعية**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) للعقدة المحددة [**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) في الموضع 2 واضبط نصها.
1. احفظ العرض.

```java
// إنشاء مثيل من العرض
Presentation pres = new Presentation();
try {
    // الوصول إلى شريحة العرض
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // الوصول إلى العقدة SmartArt في الفهرس 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // إضافة عقدة فرعية جديدة في الموضع 2 في العقدة الأم
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
سيساعدك الكود النموذجي التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. انتقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. انتقل عبر جميع [**العقد**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. الوصول إلى المعلومات وعرضها مثل موضع عقدة SmartArt، المستوى والنص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // انتقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // انتقل عبر جميع العقد داخل SmartArt
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

## **الوصول إلى عقدة الطفل SmartArt**
سيساعدك الكود النموذجي التالي على الوصول إلى العقد الفرعية التي تنتمي إلى العقد المقابلة لشكل SmartArt.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. انتقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. انتقل عبر جميع [**العقد**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. لكل شكل SmartArt مقselected [**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode)، انتقل عبر جميع [**عقد الأطفال**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) داخل العقدة المعنية.
1. الوصول إلى المعلومات وعرضها مثل موضع [**عقدة الأبناء**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)، المستوى والنص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // انتقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // انتقل عبر جميع العقد داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // الوصول إلى عقدة SmartArt في الفهرس i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // الانتقال عبر العقد الفرعية في عقدة SmartArt في الفهرس i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // الوصول إلى العقدة الفرعية في عقدة SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // طباعة معلمات عقدة الطفل SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى عقدة الطفل SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين وتتعلق بالعقد المقابلة لشكل SmartArt.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. أضف شكل [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) من نوع SmartArt.
1. الوصول إلى شكل SmartArt المضاف.
1. الوصول إلى العقدة في الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
1. الآن، الوصول إلى [**عقدة الطفل**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) في الموضع 1 للعقدة التي تم الوصول إليها باستخدام **get_Item()**.
1. الوصول إلى المعلومات وعرضها مثل موضع [**عقدة الطفل**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)، المستوى والنص.

```java
// إنشاء مثيل من العرض
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt في الشريحة الأولى
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // الوصول إلى عقدة SmartArt في الفهرس 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // الوصول إلى العقدة الفرعية في الموضع 1 في العقدة الأم
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // طباعة معلمات عقدة الطفل SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt في عرض PowerPoint باستخدام Java**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. انتقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. تحقق مما إذا كان [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) يحتوي على أكثر من 0 عقد.
1. اختر عقدة SmartArt المراد إزالتها.
1. الآن، قم بإزالة العقدة المحددة باستخدام [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) method.
1. احفظ العرض.

```java
// تحميل العرض المرغوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // انتقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
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
    
    // حفظ العرض
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة عقدة SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. انتقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. اختر عقدة شكل SmartArt في الفهرس 0.
1. الآن، تحقق مما إذا كانت العقدة SmartArt المحددة تحتوي على أكثر من عقدتين فرعيتين.
1. الآن، قم بإزالة العقدة في **الموضع 1** باستخدام [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) method.
1. احفظ العرض.

```java
// تحميل العرض المرغوب
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // انتقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
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

## **تعيين موضع مخصص لعقدة الطفل في SmartArt**
الآن تدعم Aspose.Slides لـ Android عبر Java تعيين خواص [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) و[Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-). يُظهر مقطع الكود أدناه كيفية تعيين موضع SmartArtShape المخصص، الحجم والدوران، وأيضًا يجب ملاحظة أن إضافة عقد جديدة يؤدي إلى إعادة حساب مواضع وأحجام جميع العقد. أيضًا مع إعدادات الموضع المخصصة، يمكن للمستخدم تعيين العقد وفقًا للمتطلبات.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
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
}finally {
    pres.dispose();
}
```

## **التحقق من عقدة المساعد**
{{% alert color="primary" %}} 

في هذه المقالة سنستكشف مزيدًا من ميزات أشكال SmartArt المضافة في شرائح العروض برمجيًا باستخدام Aspose.Slides لـ Android عبر Java.

{{% /alert %}} 

سنستخدم شكل SmartArt المصدر التالي لاستكشافنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt المصدر في الشريحة**|

في الكود النموذجي التالي، سنستكشف كيفية تحديد **عقد المساعدين** في مجموعة عقد SmartArt وتغييرها.

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض مع شكل SmartArt.
1. احصل على مرجع الشريحة الثانية باستخدام فهرسها.
1. انتقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) إذا كان SmartArt.
1. انتقل عبر جميع العقد داخل شكل SmartArt وتحقق مما إذا كانت [**عقد مساعد**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
1. غيّر حالة عقدة المساعد إلى عقدة عادية.
1. احفظ العرض.

```java
// إنشاء مثيل من العرض
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // انتقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // الانتقال عبر جميع عقد شكل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // تحقق مما إذا كانت العقدة عقدة مساعد
                if (node.isAssistant()) 
                {
                    // تعيين العقدة المساعدة إلى false وجعلها عقدة عادية
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
|**الشكل: العقد المساعد قد تم تغييرها في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق ملء العقدة**
تتيح Aspose.Slides لـ Android عبر Java إضافة أشكال SmartArt مخصصة وتعيين تنسيق ملئها. تشرح هذه المقالة كيفية إنشاء أشكال SmartArt والوصول إليها وتعيين تنسيق ملئها باستخدام Aspose.Slides لـ Android عبر Java.

يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة شكل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) عن طريق تعيين [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. تعيين [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) لعقد أشكال SmartArt.
1. كتابة العرض المعدل كملف PPTX.

```java
// إنشاء مثيل من العرض
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt وعقد
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // تعيين لون ملء العقدة
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

## **توليد صورة مصغرة لعقدة الطفل SmartArt**
يمكن للمطورين توليد صورة مصغرة للعقدة الفرعية لشكل SmartArt باتباع الخطوات التالية:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. [إضافة SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. احصل على مرجع عقدة باستخدام فهرسها.
1. احصل على صورة المصغرة.
1. احفظ الصورة المصغرة بتنسيق الصورة المطلوب.

```java
// إنشاء مثيل من العرض الذي يمثل ملف PPTX 
Presentation pres = new Presentation();
try {
    // إضافة SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // احصل على مرجع للعقدة باستخدام فهرسها  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // احصل على الصورة المصغرة
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // احفظ الصورة المصغرة
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```