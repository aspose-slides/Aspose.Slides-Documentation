---
title: إدارة SmartArt
type: docs
weight: 10
url: /ar/nodejs-java/manage-smartart/
---

## **الحصول على النص من SmartArt**
تم الآن إضافة طريقة TextFrame إلى الفئة [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) و الفئة [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) إذا لم يكن لديه نص العقد فقط. سيساعدك رمز العينة التالي في الحصول على النص من عقدة SmartArt.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير نوع تخطيط SmartArt**
لتغيير نوع تخطيط [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) يرجى اتباع الخطوات التالية:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.
  في المثال أدناه، تم إضافة موصل بين شكلين.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // تغيير LayoutType إلى BasicProcess
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // حفظ العرض التقديمي
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **التحقق من الخاصية المخفية في SmartArt**
يرجى ملاحظة: طريقة [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) تُرجع true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من الخاصية المخفية لأي عقدة من [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) يرجى اتباع الخطوات التالية:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من الخاصية [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--) .
- حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، تم إضافة موصل بين شكلين.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // إضافة عقدة إلى SmartArt
    var node = smart.getAllNodes().addNode();
    // التحقق من الخاصية isHidden
    var hidden = node.isHidden();// Returns true
    if (hidden) {
        // إجراء بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على أو تعيين نوع مخطط المؤسسة**
تسمح الطرق [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) و [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) بالحصول على أو تعيين نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المؤسسة يرجى اتباع الخطوات التالية:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
- الحصول على أو [تعيين نوع مخطط المؤسسة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- حفظ العرض التقديمي كملف PPTX.
  في المثال أدناه، تم إضافة موصل بين شكلين.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // الحصول على أو تعيين نوع مخطط المؤسسة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء مخطط مؤسسة صورة**
توفر Aspose.Slides لـ Node.js عبر Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
4. حفظ العرض التقديمي المعدل كملف PPTX.

يُستخدم الكود التالي لإنشاء المخطط.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على أو تعيين حالة SmartArt**
لتغيير نوع تخطيط [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إضافة [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
3. [الحصول](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) أو [تعيين](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) حالة مخطط SmartArt.
4. حفظ العرض التقديمي كملف PPTX.

يُستخدم الكود التالي لإنشاء المخطط.
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // الحصول على حالة مخطط SmartArt أو تعيينها
    smart.setReversed(true);
    var flag = smart.isReversed();
    // حفظ العرض التقديمي
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يدعم SmartArt الانعكاس/العكس للغات RTL؟**

نعم. طريقة [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) تغير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ الشكل SmartArt](/slides/ar/nodejs-java/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة بالكامل](/slides/ar/nodejs-java/clone-slides/) التي تحتوي على هذا الشكل. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بتصيير SmartArt إلى صورة نقطية للمعاينة أو التصدير للويب؟**

[تصيير الشريحة](/slides/ar/nodejs-java/convert-powerpoint-to-png/) (أو العرض التقديمي بأكمله) إلى PNG/JPEG عبر واجهة البرمجة التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا اختيار SmartArt محدد على شريحة إذا كان هناك عدة عناصر؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt Text) أو [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) والبحث عن الشكل عبر ذلك attribute باستخدام [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)، ثم التحقق من النوع لتأكيد أنه [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). توضح الوثائق التقنيات النموذجية للعثور على الأشكال والعمل معها.