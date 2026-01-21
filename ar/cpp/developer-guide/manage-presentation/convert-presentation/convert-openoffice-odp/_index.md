---
title: تحويل عروض OpenDocument في C++
linktitle: تحويل OpenDocument
type: docs
weight: 10
url: /ar/cpp/convert-openoffice-odp/
keywords:
- تحويل ODP
- ODP إلى صورة
- ODP إلى GIF
- ODP إلى HTML
- ODP إلى JPG
- ODP إلى MD
- ODP إلى PDF
- ODP إلى PNG
- ODP إلى PPT
- ODP إلى PPTX
- ODP إلى TIFF
- ODP إلى فيديو
- ODP إلى Word
- ODP إلى XPS
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "يتيح لك Aspose.Slides لـ C++ تحويل ODP إلى PDF و HTML وتنسيقات الصور بسهولة. عزز تطبيقات C++ الخاصة بك بتحويل عروض سريع ودقيق."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) يتيح لك تحويل عروض OpenDocument (ODP) إلى تنسيقات متعددة (HTML، PDF، TIFF، SWF، XPS، إلخ). API المستخدمة لتحويل ملفات ODP إلى تنسيقات مستندات أخرى هي نفسها المستخدمة في عمليات تحويل PowerPoint (PPT و PPTX).

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكنك القيام بذلك على النحو التالي:
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
