---
title: إنشاء أو إدارة عقدة شكل SmartArt في PowerPoint باستخدام JavaScript
linktitle: إدارة عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/nodejs-java/manage-smartart-shape-node/
keywords: سمارتآرت باوربوينت, عقد سمارتآرت, موضع سمارتآرت, إزالة سمارتآرت, إضافة عقد سمارتآرت, عرض باوربوينت, باوربوينت جافا, واجهة برمجة تطبيقات جافاسكريبت لباوربوينت
description: إدارة عقدة SmartArt والعقد الفرعية في عروض PowerPoint باستخدام JavaScript
---

## **إضافة عقدة SmartArt في عرض PowerPoint باستخدام JavaScript**
Aspose.Slides for Node.js via Java يوفر أبسط واجهة برمجة تطبيقات لإدارة أشكال SmartArt بطريقة سهلة. سيساعدك الكود النموذجي أدناه على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويل النوع المحدد إلى [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا كان SmartArt.
5. [إضافة عقدة جديدة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) وتعيين النص في TextFrame.
6. الآن، [إضافة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) في العقدة التي تم إضافتها حديثًا [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتعيين النص في TextFrame.
7. حفظ العرض.
```javascript
// تحميل العرض المطلوب
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // الانتقال عبر كل شكل داخل الشريحة الأولى
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // تحويل نوع الشكل إلى SmartArt
            var smart = shape;
            // إضافة عقدة SmartArt جديدة
            var TemNode = smart.getAllNodes().addNode();
            // إضافة نص
            TemNode.getTextFrame().setText("Test");
            // إضافة عقدة فرعية جديدة في العقدة الأصلية. سيتم إضافتها في نهاية المجموعة
            var newNode = TemNode.getChildNodes().addNode();
            // إضافة نص
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // حفظ العرض
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة عقدة SmartArt في موضع محدد**
في الكود النموذجي التالي شرحنا كيفية إضافة العقد الفرعية التابعة للعقد المناسبة في شكل SmartArt في موضع معين.

1. إنشاء كائن من فئة Presentation.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. إضافة شكل [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) في الشريحة التي تم الوصول إليها.
4. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
5. الآن، إضافة [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) للعقدة [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) المحددة في الموضع 2 وتعيين نصها.
6. حفظ العرض.
```javascript
// إنشاء نسخة من العرض
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى شريحة العرض
    var slide = pres.getSlides().get_Item(0);
    // إضافة Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // الوصول إلى عقدة SmartArt في الفهرس 0
    var node = smart.getAllNodes().get_Item(0);
    // إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأصلية
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // إضافة نص
    chNode.getTextFrame().setText("Sample Text Added");
    // حفظ العرض
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى عقدة SmartArt في عرض PowerPoint باستخدام JavaScript**
الكود النموذجي التالي سيساعد على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويُحدد فقط عند إضافة شكل SmartArt.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويل النوع المحدد إلى [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا كان SmartArt.
5. التنقل عبر جميع [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
6. الوصول وعرض معلومات مثل موقع عقدة SmartArt، المستوى والنص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل نوع الشكل إلى SmartArt
            var smart = shape;
            // التنقل عبر جميع العقد داخل SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // الوصول إلى عقدة SmartArt في الفهرس i
                var node = smart.getAllNodes().get_Item(j);
                // طباعة معلمات عقدة SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى عقدة SmartArt الفرعية**
الكود النموذجي التالي سيساعد على الوصول إلى العقد الفرعية التابعة للعقد المناسبة في شكل SmartArt.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويل النوع المحدد إلى [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا كان SmartArt.
5. التنقل عبر جميع [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
6. لكل [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) محدد في شكل SmartArt، التنقل عبر جميع [**Child Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) داخل العقدة المعينة.
7. الوصول وعرض معلومات مثل موقع [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)، المستوى والنص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل نوع الشكل إلى SmartArt
            var smart = shape;
            // التنقل عبر جميع العقد داخل SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // الوصول إلى عقدة SmartArt في الفهرس i
                var node0 = smart.getAllNodes().get_Item(i);
                // التنقل عبر العقد الفرعية في عقدة SmartArt في الفهرس i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // الوصول إلى العقدة الفرعية في عقدة SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // طباعة معلمات العقدة الفرعية في SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى عقدة SmartArt الفرعية في موضع محدد**
في هذا المثال سنتعلم كيفية الوصول إلى العقد الفرعية في مواضع معينة تابعة للعقد المناسبة في شكل SmartArt.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. إضافة شكل [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) من نوع SmartArt.
4. الوصول إلى شكل SmartArt المضاف.
5. الوصول إلى العقدة بالفهارس 0 لشكل SmartArt الذي تم الوصول إليه.
6. الآن، الوصول إلى [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) في الموضع 1 للعقدة المحددة باستخدام طريقة **get_Item()**.
7. الوصول وعرض معلومات مثل موقع [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)، المستوى والنص.
```javascript
// إنشاء كائن العرض
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة شكل SmartArt في الشريحة الأولى
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // الوصول إلى عقدة SmartArt في الفهرس 0
    var node = smart.getAllNodes().get_Item(0);
    // الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأصلية
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // طباعة معلمات العقدة الفرعية في SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة عقدة SmartArt في عرض PowerPoint باستخدام JavaScript**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويل النوع المحدد إلى [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا كان SmartArt.
5. التحقق مما إذا كان [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) يحتوي على أكثر من 0 عقد.
6. تحديد عقدة SmartArt التي سيتم حذفها.
7. الآن، إزالة العقدة المحددة باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
8. حفظ العرض.
```javascript
// تحميل العرض المطلوب
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل نوع الشكل إلى SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // الوصول إلى عقدة SmartArt في الفهرس 0
                var node = smart.getAllNodes().get_Item(0);
                // إزالة العقدة المحددة
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // حفظ العرض
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة عقدة SmartArt في موضع محدد**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويل النوع المحدد إلى [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا كان SmartArt.
5. تحديد عقدة شكل SmartArt في الفهرس 0.
6. الآن، التحقق مما إذا كانت العقدة المحددة تحتوي على أكثر من عقدتين فرعيتين.
7. الآن، إزالة العقدة في **الموضع 1** باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
8. حفظ العرض.
```javascript
// تحميل العرض المطلوب
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // تحويل نوع الشكل إلى SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // الوصول إلى عقدة SmartArt في الفهرس 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // إزالة العقدة الفرعية في الموضع 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // حفظ العرض
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين موضع مخصص للعقدة الفرعية في SmartArt**
الآن يدعم Aspose.Slides for Node.js via Java تعيين خصائص [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) للـ [X](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setX-float-) و [Y](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setY-float-). يوضح المقتطف التالي كيفية تعيين موضع وشكل وتدوير SmartArtShape مخصَّص، يرجى ملاحظة أن إضافة عقد جديدة يؤدي إلى إعادة حساب مواضع أحجام جميع العقد. ومع إعدادات الموضع المخصَّصة، يمكن للمستخدم ضبط العقد وفق المتطلبات.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // نقل شكل SmartArt إلى موقع جديد
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // تغيير عرض شكل SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // تغيير ارتفاع شكل SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // تغيير دوران شكل SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **التحقق من عقدة المساعد**
{{% alert color="primary" %}} 

في هذه المقالة سنستكشف المزيد من ميزات أشكال SmartArt التي تم إضافتها في شرائح العرض برمجيًا باستخدام Aspose.Slides for Node.js via Java.

{{% /alert %}} 

سنعتمد الشكل SmartArt التالي في تحقيقنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: الشكل SmartArt المصدر في الشريحة**|

في الكود النموذجي التالي سنستكشف كيفية تحديد **العقد المساعدة** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
2. الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.
3. التنقل عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويل النوع المحدد إلى [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا كان SmartArt.
5. التنقل عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت [**Assistant Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
6. تغيير حالة عقدة المساعد إلى عقدة عادية.
7. حفظ العرض.
```javascript
// إنشاء نسخة عرض
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // الانتقال عبر كل شكل داخل الشريحة الأولى
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل النوع إلى SmartArt
            var smart = shape;
            // التنقل عبر جميع العقد في شكل SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // التحقق مما إذا كانت العقدة عقدة مساعد
                if (node.isAssistant()) {
                    // ضبط عقدة المساعد إلى غير مساعد وجعلها عقدة عادية
                    node.isAssistant();
                }
            }
        }
    }
    // حفظ العرض
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**الشكل: تم تغيير عقد المساعد في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق تعبئة العقدة**
Aspose.Slides for Node.js via Java يجعل من الممكن إضافة أشكال SmartArt مخصصة وتعيين تنسيق تعبئتها. توضح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق تعبئتها باستخدام Aspose.Slides for Node.js via Java.

يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
3. إضافة شكل [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) بتعيين [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) الخاص به.
4. تعيين [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) لعقد شكل SmartArt.
5. كتابة العرض المعدل كملف PPTX.
```javascript
// إنشاء كائن العرض
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة
    var slide = pres.getSlides().get_Item(0);
    // إضافة شكل SmartArt والعقد
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // ضبط تعبئة العقدة
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // حفظ العرض
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء صورة مصغرة لعقدة SmartArt الفرعية**
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية من SmartArt باتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. [إضافة SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
3. الحصول على مرجع عقدة باستخدام الفهرس الخاص بها.
4. الحصول على صورة المصغرة.
5. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // الحصول على مرجع عقدة باستخدام الفهرس الخاص بها
    var node = smart.getNodes().get_Item(1);
    // الحصول على الصورة المصغرة
    var slideImage = node.getShapes().get_Item(0).getImage();
    // حفظ الصورة المصغرة
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل تدعم رسوميات SmartArt؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/nodejs-java/shape-animation/) (دخول، خروج، تأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني العثور على SmartArt معين في شريحة إذا لم أعرف معرفه الداخلي؟**

قم بتعيين والبحث باستخدام [النص البديل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/). يساعد تعيين AltText مميز على SmartArt في العثور عليه دون الاعتماد على المعرفات الداخلية.

**هل ستُحافظ مظهر SmartArt عند تحويل العرض إلى PDF؟**

نعم. يقوم Aspose.Slides بتصوير SmartArt بدقة بصرية عالية أثناء [تصدير PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكن استخراج صورة كاملة لـ SmartArt (للمعاينات أو التقارير)؟**

نعم. يمكنك تصوير شكل SmartArt إلى [تنسيقات نقطية](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) أو إلى [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) للحصول على مخرجات متجهة قابلة للقياس، ما يجعله مناسبًا للصور المصغرة، التقارير، أو الاستخدام على الويب.