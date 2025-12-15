---
title: الحصول على حدود الفقرة من العروض التقديمية على Android
linktitle: الفقرة
type: docs
weight: 60
url: /ar/androidjava/paragraph/
keywords:
- حدود الفقرة
- حدود جزء النص
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم جزء النص
- إطار النص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة وجزء النص في Aspose.Slides for Android عبر Java لتحسين موضع النص في عروض PowerPoint التقديمية."
---

## **الحصول على إحداثيات الفقرة والقسم داخل إطار النص**
باستخدام Aspose.Slides for Android عبر Java، يمكن للمطورين الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على [إحداثيات الجزء](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) داخل مجموعة الأجزاء لفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على إحداثيات المستطيل للفقرة بالإضافة إلى موضع الجزء داخل الفقرة.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **الحصول على إحداثيات المستطيل لفقرة**
باستخدام طريقة [**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) يمكن للمطورين الحصول على مستطيل حدود الفقرة.
```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على حجم الفقرة والجزء داخل TextFrame لخلية جدول**
للحصول على حجم [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) أو [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) وإحداثياته في TextFrame لخلية جدول، يمكنك استخدام طرق [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) و[IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--).
يوضح هذا الكود النموذجي العملية الموضحة:
```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**بأي وحدات يتم إرجاع الإحداثيات للفقرة وأجزاء النص؟**  
بالنقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف الكلمات على حدود الفقرة؟**  
نعم. إذا تم تمكين [wrapping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) في الـ[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/)، ينكسر النص ليتناسب مع عرض المنطقة، مما يغير الحدود الفعلية للفقرة.

**هل يمكن تعيين إحداثيات الفقرة إلى بكسلات في الصورة المصدرة بشكل موثوق؟**  
نعم. حمّل النقاط إلى بكسلات باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على DPI المختار للتصيير/التصدير.

**كيف أحصل على معلمات تنسيق الفقرة “الفعّالة” مع مراعاة وراثة الأنماط؟**  
استخدم [effective paragraph formatting data structure](/slides/ar/androidjava/shape-effective-properties/); تُعيد القيم النهائية المجمعة للمسافات البادئة، الفواصل، الالتفاف، RTL، وغيرها.