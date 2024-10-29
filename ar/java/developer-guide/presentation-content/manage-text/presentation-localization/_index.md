---
title: تخصيص العرض التقديمي
type: docs
weight: 100
url: /ar/java/presentation-localization/
---

## **تغيير اللغة لنص العرض التقديمي والشكل**
- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- الحصول على مرجع من الشريحة باستخدام فهرسها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النصوص إلى TextFrame.
- [تعيين معرف اللغة](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) للنص.
- كتابة العرض التقديمي كملف PPTX.

تم توضيح تنفيذ الخطوات المذكورة أعلاه في المثال أدناه.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("النص لتطبيق لغة التدقيق الإملائي");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```