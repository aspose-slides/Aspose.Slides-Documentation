---
title: توطين العرض
type: docs
weight: 100
url: /php-java/presentation-localization/
---

## **تغيير اللغة لنص العرض والشكل**
- قم بإنشاء نسخة من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- احصل على مرجع من الشريحة باستخدام فهرسها.
- أضف [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- أضف بعض النصوص إلى TextFrame.
- [تعيين معرف اللغة](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) للنص.
- احفظ العرض كملف PPTX.

يتم توضيح تنفيذ الخطوات أعلاه أدناه في مثال.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("نص لتطبيق لغة التدقيق الإملائي");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```