---
title: تحويل PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/java/convert-powerpoint-to-tiff-with-notes/
keywords: "تحويل PowerPoint إلى TIFF مع الملاحظات"
description: "تحويل PowerPoint إلى TIFF مع الملاحظات في Aspose.Slides."
---

## **تحويل PPT(X) في عرض شريحة الملاحظات إلى TIFF**
يمكن استخدام الطريقة [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي تقدمها فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل في عرض شريحة الملاحظات إلى TIFF. ت 업데이트 الكود أدناه العرض التقديمي النموذج إلى صور TIFF في عرض شريحة الملاحظات، كما هو مبين أدناه:

```java
//إنشاء كائن عرض تقديمي يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //حفظ العرض التقديمي كملاحظات TIFF
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

ت تحديث الكود أعلاه العرض التقديمي النموذج إلى صور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

|**عرض العرض التقديمي المصدر مع ملاحظات الشريحة**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**صورة TIFF الناتجة في عرض شريحة الملاحظات**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على Aspose [محول PowerPoint إلى ملصق المجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}