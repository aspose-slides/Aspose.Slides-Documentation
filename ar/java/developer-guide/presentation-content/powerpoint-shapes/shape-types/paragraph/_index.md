---
title: الحصول على حدود الفقرة من العروض التقديمية في جافا
linktitle: فقرة
type: docs
weight: 60
url: /ar/java/paragraph/
keywords:
- حدود الفقرة
- حدود جزء النص
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم جزء النص
- إطار النص
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة وجزء النص في Aspose.Slides for Java لتحسين موضع النص في عروض PowerPoint التقديمية."
---

## **الحصول على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides for Java، يمكن للمطورين الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على [إحداثيات الجزء](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) داخل مجموعة الأجزاء لفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على إحداثيات المستطيل للفقرة بالإضافة إلى موقع الجزء داخل الفقرة.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **الحصول على إحداثيات المستطيل للفقرة**
باستخدام طريقة [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) يمكن للمطورين الحصول على مستطيل حدود الفقرة.
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
للحصول على حجم و إحداثيات [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) أو [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) داخل TextFrame لخلية جدول، يمكنك استخدام طريقتي [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) و [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--).

يظهر هذا المثال الشيفرة التي توضح العملية الموصوفة:
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

**ما الوحدات التي تُقاس بها الإحداثيات العائدة للفقرة وأقسام النص؟**  
بالنقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد في الشريحة.

**هل يؤثر الالتفاف النصي على حدود الفقرة؟**  
نعم. إذا تم تمكين [الالتفاف](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-) في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)، يتم كسر النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن تحويل إحداثيات الفقرة بشكل موثوق إلى بكسلات في الصورة المصدرة؟**  
نعم. يمكن تحويل النقاط إلى بكسلات باستخدام: البكسلات = النقاط × (DPI / 72). تعتمد النتيجة على قيمة DPI المختارة عند العرض/التصدير.

**كيف يمكنني الحصول على معلمات تنسيق الفقرة "الفعّالة"، مع مراعاة وراثة الأنماط؟**  
استخدم [effective paragraph formatting data structure](/slides/ar/java/shape-effective-properties/); فهو يُعيد القيم النهائية المجمعة للمسافات البادئة، التباعد، الالتفاف، الاتجاه من اليمين إلى اليسار، وأكثر.