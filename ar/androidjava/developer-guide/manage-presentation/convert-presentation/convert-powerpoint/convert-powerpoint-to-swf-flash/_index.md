---
title: تحويل PowerPoint إلى SWF فلاش
type: docs
weight: 80
url: /ar/androidjava/convert-powerpoint-to-swf-flash/
keywords: "PPT، PPTX إلى SWF"
description: "تحويل PowerPoint PPT، PPTX إلى SWF باستخدام Java"
---

## **تحويل PPT(X) إلى SWF**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) لتحويل العرض التقديمي بأكمله إلى مستند **SWF**. يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند **SWF** باستخدام الخيارات المقدمة من فئة [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). يمكنك أيضًا تضمين التعليقات في SWF الناتج باستخدام فئة [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) وواجهة [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // حفظ العرض التقديمي
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```