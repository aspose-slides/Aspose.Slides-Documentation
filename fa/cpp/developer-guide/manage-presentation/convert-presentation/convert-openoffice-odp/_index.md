---
title: تبدیل ارائه‌های OpenDocument در C++
linktitle: تبدیل OpenDocument
type: docs
weight: 10
url: /fa/cpp/convert-openoffice-odp/
keywords:
- تبدیل ODP
- ODP به تصویر
- ODP به GIF
- ODP به HTML
- ODP به JPG
- ODP به MD
- ODP به PDF
- ODP به PNG
- ODP به PPT
- ODP به PPTX
- ODP به TIFF
- ODP به ویدیو
- ODP به Word
- ODP به XPS
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ به شما امکان تبدیل ODP به PDF، HTML و فرمت‌های تصویر را به آسانی می‌دهد. برنامه‌های C++ خود را با تبدیل سریع و دقیق ارائه‌ها ارتقاء دهید."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/fa/cpp/) به شما امکان تبدیل ارائه‌های OpenDocument (ODP) را به بسیاری از فرمت‌ها (HTML، PDF، TIFF، SWF، XPS و غیره) می‌دهد. API مورد استفاده برای تبدیل فایل‌های ODP به سایر فرمت‌های سند، همان API است که برای عملیات تبدیل PowerPoint (PPT و PPTX) به کار می‌رود.

به عنوان مثال، اگر نیاز به تبدیل یک ارائه ODP به PDF دارید، می‌توانید به روش زیر عمل کنید:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```