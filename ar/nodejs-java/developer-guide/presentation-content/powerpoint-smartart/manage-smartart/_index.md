---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/nodejs-java/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية الإخفاء
- مخطط المنظمة
- مخطط تنظيم الصور
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرّف على كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides لـ Node.js عبر أمثلة شفرة JavaScript واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **الحصول على النص من SmartArt**
تمت إضافة طريقة TextFrame الآن إلى فئة [SmartArtShape] و فئة [SmartArtShape] على التوالي. هذه الخاصية تتيح لك الحصول على كل النص من [SmartArt] إذا لم يكن يحتوي فقط على نص العقد. سيساعدك رمز العينة التالي في الحصول على النص من عقدة SmartArt.
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
من أجل تغيير نوع التخطيط لـ [SmartArt] . يرجى اتباع الخطوات أدناه:
- إنشاء مثيل من فئة [Presentation].
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [SmartArt] BasicBlockList.
- تغيير [LayoutType] إلى BasicProcess.
- كتب العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلًا بين شكلين.
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


## **التحقق من خاصية الرؤية لـ SmartArt**
يرجى ملاحظة: تُرجِع الطريقة [SmartArtNode.isHidden()] قيمة true إذا كانت هذه العقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة من [SmartArt] . يرجى اتباع الخطوات أدناه:
- إنشاء مثيل من فئة [Presentation].
- إضافة [SmartArt] RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية [visibility].
- كتب العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلًا بين شكلين.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // إضافة عقدة إلى SmartArt
    var node = smart.getAllNodes().addNode();
    // التحقق من خاصية isHidden
    var hidden = node.isHidden();// يرجع true
    if (hidden) {
        // تنفيذ بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على أو تعيين نوع مخطط المنظمة**
تسمح الطرق [SmartArtNode.getOrganizationChartLayout()] و [setOrganizationChartLayout(int)] بالحصول على أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المنظمة، يرجى اتباع الخطوات أدناه:
- إنشاء مثيل من فئة [Presentation].
- إضافة [SmartArt] إلى الشريحة.
- الحصول على أو [set the organization chart type].
- كتب العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلًا بين شكلين.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // الحصول على أو تعيين نوع مخطط المنظمة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء مخطط منظمة صور**
توفر Aspose.Slides لـ Node.js عبر Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:
1. إنشاء مثيل من فئة [Presentation].
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
4. كتابة العرض التقديمي المعدل إلى ملف PPTX
الشفرة التالية تُستخدم لإنشاء مخطط.
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
من أجل تغيير نوع تخطيط [SmartArt] . يرجى اتباع الخطوات أدناه:
1. إنشاء مثيل من فئة [Presentation].
2. إضافة [SmartArt] على الشريحة.
3. [Get] أو [Set] حالة مخطط SmartArt.
4. كتب العرض التقديمي كملف PPTX.
الشفرة التالية تُستخدم لإنشاء مخطط.
```javascript
// إنشاء كائن فئة Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // إضافة SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // الحصول على أو تعيين حالة مخطط SmartArt
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

**هل يدعم SmartArt المرآة/العكس للغات RTL؟**
نعم. طريقة [setReversed] تقوم بتبديل اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**
يمكنك [clone the SmartArt shape] عبر مجموعة الأشكال ([ShapeCollection.addClone]) أو [clone the entire slide] التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموضع والتنسيق.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو تصدير الويب؟**
[Render the slide] (or the whole presentation) to PNG/JPEG عبر الـ API الذي يحول الشرائح/العروض إلى صور — سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني اختيار SmartArt معين برمجيًا على شريحة إذا كان هناك عدة؟**
ممارسة شائعة هي استخدام [alternative text] (Alt Text) أو [setName] والبحث عن الشكل عبر تلك الخاصية باستخدام [Slide.getShapes]، ثم التحقق من النوع للتأكد أنه [SmartArt]. توضح الوثائق تقنيات شائعة للعثور على الأشكال والعمل معها.