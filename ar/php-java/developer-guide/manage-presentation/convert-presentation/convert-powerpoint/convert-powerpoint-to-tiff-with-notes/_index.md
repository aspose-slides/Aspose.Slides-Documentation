---
title: تحويل PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/php-java/convert-powerpoint-to-tiff-with-notes/
keywords: "تحويل PowerPoint إلى TIFF مع الملاحظات"
description: "تحويل PowerPoint إلى TIFF مع الملاحظات في Aspose.Slides."
---

## **تحويل PPT(X) في عرض شريحة الملاحظات إلى TIFF**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة من قبل فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لتحويل العرض التقديمي بأكمله في عرض شريحة الملاحظات إلى TIFF. تحديث مقتطفات الكود أدناه العرض التقديمي النموذجي إلى صور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

```php
//تجسيد كائن عرض تقديمي يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    $opts = new TiffOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # حفظ العرض التقديمي إلى ملاحظات TIFF
    $pres->save("Tiff-Notes.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

تحديث مقتطفات الكود أعلاه العرض التقديمي النموذجي إلى صور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

|**عرض العرض التقديمي المصدر مع ملاحظات الشريحة**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**صورة TIFF الناتجة في عرض شريحة الملاحظات**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على Aspose [محول PowerPoint إلى ملصق مجاناً](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}