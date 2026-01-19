---
title: تحويل عروض OpenDocument في Python
linktitle: تحويل OpenDocument
type: docs
weight: 10
url: /ar/python-net/convert-openoffice-odp/
keywords:
- تحويل OpenDocument
- تحويل ODP
- ODP إلى PDF
- ODP إلى PPT
- ODP إلى PPTX
- ODP إلى XPS
- ODP إلى HTML
- ODP إلى TIFF
- ODP إلى SWF
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "تحويل ملف OpenDocument ODP إلى PDF أو PPT أو PPTX أو XPS أو HTML أو TIFF أو SWF باستخدام Python و Aspose.Slides: أمثلة على الشيفرة، دقة عالية، تحويل دفعي، وتخصيص."
---

## **تحويل ملفات ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) يتيح لك تحويل عروض OpenOffice ODP إلى صيغ متعددة. API المستخدم لتحويل ملفات ODP إلى صيغ مستندات أخرى هو نفسه المستخدم لتحويل PowerPoint (PPT و PPTX).

تُظهر لك هذه الأمثلة كيفية تحويل مستندات ODP إلى صيغ أخرى (فقط قم بتغيير ملف ODP المصدر):

- [تحويل ODP إلى HTML](/slides/ar/python-net/convert-powerpoint-to-html/)
- [تحويل ODP إلى PDF](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/ar/python-net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF Flash](/slides/ar/python-net/convert-powerpoint-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-to-tiff-with-notes/)

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكنك القيام بذلك بهذه الطريقة:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **الأسئلة الشائعة**

**هل يمكنني تحويل ODP إلى PPTX بدون تثبيت LibreOffice أو OpenOffice؟**

نعم. Aspose.Slides هي مكتبة مستقلة بالكامل تتعامل مع صيغ PowerPoint و OpenOffice دون الحاجة إلى أي تطبيقات خارجية.

**هل يفتح Aspose.Slides ويحفظ ملفات ODP/OTP المحمية بكلمة مرور؟**

نعم. يمكنه [تحميل العروض المشفرة](/slides/ar/python-net/password-protected-presentation/) عند تقديم كلمة المرور ويمكنه أيضًا حفظ العروض مع إعدادات التشفير والحماية.

**هل يمكنني استخراج ملفات الوسائط المدمجة (audio/video) من ODP قبل تحويله؟**

نعم. Aspose.Slides يتيح لك الوصول إلى واستخراج [الصوت](/slides/ar/python-net/audio-frame/) و [الفيديو](/slides/ar/python-net/video-frame/) المدمجة من العروض، وهو مفيد لمعالجة ما قبل التحويل أو لإعادة الاستخدام بشكل منفصل.

**هل يمكنني حفظ ODP المحول كـ Strict Office Open XML؟**

نعم. عند حفظ إلى PPTX يمكنك تمكين Strict OOXML عبر [خيارات الحفظ](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) لتلبية متطلبات الامتثال الأكثر صرامة.