---
title: إضافة التوقيعات الرقمية إلى العروض التقديمية باستخدام بايثون
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/python-net/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيف تقوم بالتوقيع الرقمي على ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---
## **المقدمة**

**الشهادة الرقمية** تُستخدم لإنشاء عرض تقديمي للـ PowerPoint محمي بكلمة مرور، مع الإشارة إلى أنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية بالتواصل مع منظمة معتمدة - سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض التقديمي عبر File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض التقديمي على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض التقديمي، سيظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض التقديمي أو للتحقق من صحة توقيعات العرض، توفر **Aspose.Slides API** الفئة [**DigitalSignature**](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/) ، الفئة [**DigitalSignatureCollection**](https://reference.aspose.com/slides/ar/python-net/aspose.slides/DigitalSignatureCollection/) ، والخاصية [**Presentation.digital_signatures**](https://