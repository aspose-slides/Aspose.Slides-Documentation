---
title: توطين العرض
type: docs
weight: 100
url: /androidjava/presentation-localization/
---

## **تغيير اللغة لنص العرض والشكل**
- أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) فئة.
- احصل على مرجع شريحة باستخدام فهرسها.
- أضف [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- أضف بعض النص إلى TextFrame.
- [تعيين معرف اللغة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) للنص.
- اكتب العرض كملف PPTX.

تم توضيح تنفيذ الخطوات أعلاه في مثال أدناه.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("نص لتطبيق لغة تدقيق الإملاء");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```