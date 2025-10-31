---
title: تحويل عروض OpenDocument التقديمية في Python
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
description: تحويل ملفات OpenDocument ODP إلى PDF أو PPT أو PPTX أو XPS أو HTML أو TIFF أو SWF باستخدام Python و Aspose.Slides: أمثلة على الشفرة، جودة عالية، تحويل دفعي، وتخصيص.
---

## **تحويل ملفات ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) يتيح لك تحويل عروض OpenOffice ODP إلى صيغ متعددة. واجهة البرمجة المستخدمة لتحويل ملفات ODP إلى صيغ مستندات أخرى هي نفسها المستخدمة في عمليات تحويل PowerPoint (PPT و PPTX).

- [تحويل ODP إلى HTML](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/ar/python-net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF Flash](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكنك القيام بذلك بهذه الطريقة:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **الأسئلة المتكررة**

**هل يمكنني تحويل ODP إلى PPTX دون تثبيت LibreOffice أو OpenOffice؟**

نعم. Aspose.Slides هي مكتبة مستقلة تمامًا تتعامل مع صيغ PowerPoint و OpenOffice دون الحاجة إلى أي تطبيقات خارجية.

**هل تقوم Aspose.Slides بفتح وحفظ ملفات ODP/OTP المحمية بكلمة مرور؟**

نعم. يمكنه [تحميل العروض المشفرة](/slides/ar/python-net/password-protected-presentation/) عندما تزود كلمة المرور ويمكنه أيضًا حفظ العروض مع إعدادات التشفير والحماية.

**هل يمكنني استخراج ملفات الوسائط المدمجة (صوت/فيديو) من ODP قبل تحويله؟**

نعم. تسمح لك Aspose.Slides بالوصول إلى واستخراج [الصوت](/slides/ar/python-net/audio-frame/) و[الفيديو](/slides/ar/python-net/video-frame/) المدمجين من العروض، وهو ما يكون مفيدًا للمعالجة ما قبل التحويل أو لإعادة الاستخدام بشكل منفصل.

**هل يمكنني حفظ ODP المحول كـ Strict Office Open XML؟**

نعم. عند الحفظ بصيغة PPTX يمكنك تمكين Strict OOXML عبر [خيارات الحفظ](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) لتلبية متطلبات التوافق الأكثر صرامة.