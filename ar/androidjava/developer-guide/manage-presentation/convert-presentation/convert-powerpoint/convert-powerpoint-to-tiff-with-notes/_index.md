---
title: تحويل PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "تحويل PowerPoint إلى TIFF مع الملاحظات"
description: "تحويل PowerPoint إلى TIFF مع الملاحظات في Aspose.Slides."
---

## **تحويل PPT(X) في عرض شريحة الملاحظات إلى TIFF**
يمكن استخدام الطريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة من قبل فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل في عرض شريحة الملاحظات إلى TIFF. تقوم مقتطفات الشيفرة أدناه بتحديث العرض التقديمي النموذجي إلى صور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

```java
//Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Saving the presentation to TIFF notes
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

تقوم مقتطفات الشيفرة أعلاه بتحديث العرض التقديمي النموذجي إلى صور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

|**عرض العرض التقديمي المصدر مع ملاحظات الشرائح**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**صورة TIFF الناتجة في عرض شريحة الملاحظات**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على [محول PowerPoint إلى ملصق المجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) من Aspose.

{{% /alert %}}