---
title: تحويل عروض OpenDocument في بايثون
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
description: "تحويل ملفات OpenDocument ODP إلى PDF أو PPT أو PPTX أو XPS أو HTML أو TIFF أو SWF باستخدام بايثون و Aspose.Slides: أمثلة على الشيفرات، دقة عالية، تحويل دفعي، وتخصيص."
---

## **تحويل ملفات ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) تتيح لك تحويل عروض OpenDocument (ODP) إلى العديد من الصيغ (HTML، PDF، TIFF، SWF، XPS، إلخ). واجهة البرمجة التطبيقات (API) المستخدمة لتحويل ملفات ODP إلى صيغ مستندات أخرى هي نفسها المستخدمة لعمليات تحويل PowerPoint (PPT وPPTX).

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكنك القيام بذلك كما يلي:
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **الأسئلة الشائعة**

**هل يمكنني تحويل ODP إلى PPTX دون تثبيت LibreOffice أو OpenOffice؟**

نعم. Aspose.Slides مكتبة مستقلة بالكامل تتعامل مع صيغ PowerPoint وOpenOffice دون الحاجة إلى أي تطبيقات خارجية.

**هل يفتح Aspose.Slides ويحفظ الملفات المحمية بكلمة مرور ODP/OTP؟**

نعم. يمكنه [تحميل العروض المشفرة](/slides/ar/python-net/password-protected-presentation/) عندما تزود كلمة المرور، ويمكنه أيضاً حفظ العروض مع إعدادات التشفير والحماية.

**هل يمكنني استخراج ملفات الوسائط المضمنة (صوت/فيديو) من ODP قبل تحويله؟**

نعم. يتيح لك Aspose.Slides الوصول إلى واستخراج [الصوت](/slides/ar/python-net/audio-frame/) و[الفيديو](/slides/ar/python-net/video-frame/) المضمنين من العروض، وهو مفيد لمعالجة ما قبل التحويل أو إعادة الاستخدام بشكل منفصل.

**هل يمكنني حفظ ODP المحوَّل بتنسيق Strict Office Open XML؟**

نعم. عند الحفظ إلى PPTX يمكنك تمكين Strict OOXML عبر [خيارات الحفظ](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) لتلبية متطلبات التوافق الأكثر صرامة.