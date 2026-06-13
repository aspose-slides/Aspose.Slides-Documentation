---
title: แปลงงานนำเสนอ OpenDocument ด้วย C++
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/cpp/convert-openoffice-odp/
keywords:
- แปลง ODP
- ODP เป็นรูปภาพ
- ODP เป็น GIF
- ODP เป็น HTML
- ODP เป็น JPG
- ODP เป็น MD
- ODP เป็น PDF
- ODP เป็น PNG
- ODP เป็น PPT
- ODP เป็น PPTX
- ODP เป็น TIFF
- ODP เป็นวิดีโอ
- ODP เป็น Word
- ODP เป็น XPS
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "Aspose.Slides สำหรับ C++ ช่วยให้คุณแปลง ODP เป็น PDF, HTML และรูปภาพได้อย่างง่ายดาย เร่งประสิทธิภาพแอป C++ ของคุณด้วยการแปลงงานนำเสนอที่เร็วและแม่นยำ"
---
[**Aspose.Slides API**](https://products.aspose.com/slides/th/cpp/) ช่วยให้คุณแปลงงานนำเสนอ OpenDocument (ODP) ไปยังหลายรูปแบบ (HTML, PDF, TIFF, SWF, XPS ฯลฯ) API ที่ใช้ในการแปลงไฟล์ ODP ไปยังรูปแบบเอกสารอื่น ๆ นั้นเหมือนกับที่ใช้สำหรับการแปลง PowerPoint (PPT และ PPTX)

ตัวอย่างเช่น หากคุณต้องการแปลงงานนำเสนอ ODP เป็น PDF คุณสามารถทำได้ตามด้านล่าง:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```