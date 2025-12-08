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
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحويل ملفات OpenDocument ODP إلى PDF أو PPT أو PPTX أو XPS أو HTML أو TIFF أو SWF في Python باستخدام Aspose.Slides: أمثلة على الشيفرة، دقة عالية، تحويل دفعي، وتخصيص."
---

## **تحويل ملفات ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) توفر لك القدرة على تحويل عروض OpenOffice ODP إلى العديد من الصيغ. واجهة برمجة التطبيقات المستخدمة لتحويل ملفات ODP إلى صيغ مستندات أخرى هي نفسها المستخدمة في عمليات تحويل PowerPoint (PPT و PPTX).

توضح لك هذه الأمثلة كيفية تحويل مستندات ODP إلى صيغ أخرى (فقط غيّر ملف ODP المصدر):

- [تحويل ODP إلى HTML](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/ar/python-net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF Flash](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكن القيام بذلك بهذه الطريقة:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **الأسئلة الشائعة**

**هل يمكنني تحويل ODP إلى PPTX دون تثبيت LibreOffice أو OpenOffice؟**

نعم. Aspose.Slides مكتبة مستقلة تمامًا تتعامل مع صيغ PowerPoint و OpenOffice دون الحاجة إلى أي تطبيقات خارجية.

**هل يفتح Aspose.Slides ويحفظ ملفات ODP/OTP المحمية بكلمة مرور؟**

نعم. يمكنه [تحميل العروض المشفرة](/slides/ar/python-net/password-protected-presentation/) عندما تقدم كلمة المرور، ويمكنه أيضًا حفظ العروض مع إعدادات التشفير والحماية.

**هل يمكنني استخراج ملفات الوسائط المضمنة (صوت/فيديو) من ODP قبل تحويله؟**

نعم. يتيح لك Aspose.Slides الوصول إلى واستخراج [الصوت](/slides/ar/python-net/audio-frame/) و[الفيديو](/slides/ar/python-net/video-frame/) المضمنين من العروض، وهو مفيد لمعالجة ما قبل التحويل أو لإعادة الاستخدام بشكل منفصل.

**هل يمكنني حفظ ODP المحول كـ Strict Office Open XML؟**

نعم. عند الحفظ إلى PPTX يمكنك تمكين Strict OOXML عبر [خيارات الحفظ](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) لتلبية متطلبات الامتثال الأكثر صرامة.