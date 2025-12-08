---
title: فقرة
type: docs
weight: 60
url: /ar/nodejs-java/paragraph/
---

## **الحصول على إحداثيات الفقرة والجزء داخل TextFrame**
باستخدام Aspose.Slides for Node.js عبر Java، أصبح بإمكان المطورين الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على [إحداثيات الجزء](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) داخل مجموعة الأجزاء للفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على إحداثيات المستطيل للفقرة جنبًا إلى جنب مع موضع الجزء داخل الفقرة.
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```



## **الحصول على إحداثيات المستطيل للفقرة**
باستخدام طريقة [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) يمكن للمطورين الحصول على مستطيل حدود الفقرة.
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول**

للحصول على حجم وإحداثيات [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) أو [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) داخل إطار نص خلية جدول، يمكنك استخدام الطريقتين [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) و [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--).

يوضح هذا الكود المثال العملية الموضحة:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**بأي وحدات تُرجع الإحداثيات للفقرة وأجزاء النص؟**

بالنقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف النص على حدود الفقرة؟**

نعم. إذا تم تمكين [الالتفاف](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) في [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)، يتم تقسيم النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن تحويل إحداثيات الفقرة إلى بكسلات في الصورة المصدرة بشكل موثوق؟**

نعم. يمكن تحويل النقاط إلى بكسلات باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على DPI المختار للتصوير/التصدير.

**كيف يمكنني الحصول على معلمات تنسيق الفقرة "الفعّالة" مع الأخذ في الاعتبار وراثة النمط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/nodejs-java/shape-effective-properties/); فهي تُرجع القيم المجمعة النهائية للمسافات البادئة، والمسافات، والالتفاف، والاتجاه من اليمين إلى اليسار، وغيرها.