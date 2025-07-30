---
title: تحويل PPTX إلى PPT باستخدام بايثون
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/python-net/convert-pptx-to-ppt/
keywords:
- PPTX إلى PPT
- تحويل PPTX إلى PPT
- تحويل PowerPoint
- تحويل العرض التقديمي
- Python
- Aspose.Slides
description: "حوِّل بسهولة ملفات PPTX إلى PPT باستخدام Aspose.Slides for Python via .NET—مع ضمان التوافق السلس مع تنسيقات PowerPoint والحفاظ على تخطيط العرض التقديمي وجودته."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض باوربوينت بصيغة PPTX إلى صيغة PPT باستخدام بايثون. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في بايثون

## **بايثون تحويل PPTX إلى PPT**

للحصول على كود بايثون كمثال لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم ببساطة بتحميل ملف PPTX وحفظه بصيغة PPT. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX في العديد من التنسيقات الأخرى مثل PDF وXPS وODP وHTML وما إلى ذلك كما تم مناقشته في هذه المقالات.

- [بايثون تحويل PPTX إلى PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [بايثون تحويل PPTX إلى XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [بايثون تحويل PPTX إلى HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [بايثون تحويل PPTX إلى ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [بايثون تحويل PPTX إلى صورة](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى [**حفظ**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في فئة [**عرض تقديمي**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يقوم كود بايثون المثال أدناه بتحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.

```py
import aspose.slides as slides

# إنشاء كائن عرض تقديمي يمثل ملف PPTX
pres = slides.Presentation("presentation.pptx")

# حفظ عرض PPTX بصيغة PPT
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```