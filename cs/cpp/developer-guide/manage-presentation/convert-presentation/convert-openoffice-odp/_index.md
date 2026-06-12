---
title: Převod prezentací OpenDocument v C++
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/cpp/convert-openoffice-odp/
keywords:
- převod ODP
- ODP na obrázek
- ODP na GIF
- ODP na HTML
- ODP na JPG
- ODP na MD
- ODP na PDF
- ODP na PNG
- ODP na PPT
- ODP na PPTX
- ODP na TIFF
- ODP na video
- ODP na Word
- ODP na XPS
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Aspose.Slides pro C++ vám umožňuje snadno převádět ODP na PDF, HTML a obrazové formáty. Zvyšte výkon svých C++ aplikací díky rychlému a přesnému převodu prezentací."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/cs/cpp/) umožňuje převádět prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS atd.). API používané k převodu souborů ODP do jiných formátů dokumentů je stejné jako to, které se používá pro konverzní operace PowerPointu (PPT a PPTX).

Například pokud potřebujete převést prezentaci ODP do PDF, můžete tak učinit následovně:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```