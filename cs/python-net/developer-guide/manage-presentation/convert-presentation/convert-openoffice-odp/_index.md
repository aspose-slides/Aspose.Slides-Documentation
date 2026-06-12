---
title: Převod prezentací OpenDocument v Pythonu
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/python-net/convert-openoffice-odp/
keywords:
- převod OpenDocument
- převod ODP
- ODP na PDF
- ODP na PPT
- ODP na PPTX
- ODP na XPS
- ODP na HTML
- ODP na TIFF
- ODP na SWF
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Převést OpenDocument ODP na PDF, PPT, PPTX, XPS, HTML, TIFF nebo SWF v Pythonu s Aspose.Slides: příklady kódu, vysoká věrnost, hromadný převod a přizpůsobení."
---
## **Úvod**

[**Aspose.Slides API**](https://products.aspose.com/slides/cs/python-net/) umožňuje převádět prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS, atd.). API použité k převodu souborů ODP do jiných formátů dokumentů je stejné jako to, které se používá pro operace převodu PowerPoint (PPT a PPTX).

Například pokud potřebujete převést ODP prezentaci do PDF, můžete tak učinit následovně:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **Často kladené otázky**

**Mohu převést ODP na PPTX bez instalace LibreOffice nebo OpenOffice?**

Ano. Aspose.Slides je plně samostatná knihovna, která zpracovává jak formáty PowerPoint, tak OpenOffice, aniž by vyžadovala jakékoli externí aplikace.

**Otevírá a ukládá Aspose.Slides soubory ODP/OTP chráněné heslem?**

Ano. Může [načíst šifrované prezentace](/slides/cs/python-net/password-protected-presentation/), když zadáte heslo, a také může ukládat prezentace s nastavením šifrování a ochrany.

**Mohu extrahovat vložené mediální soubory (audio/video) z ODP před jejím převodem?**

Ano. Aspose.Slides umožňuje přístup k vloženému [audio](/slides/cs/python-net/audio-frame/) a [video](/slides/cs/python-net/video-frame/) v prezentacích a jejich extrakci, což je užitečné při předběžném zpracování před konverzí nebo samostatném opětovném použití.

**Mohu uložit převedené ODP jako Strict Office Open XML?**

Ano. Při ukládání do PPTX můžete povolit Strict OOXML pomocí [možností ukládání](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/), abyste splnili přísnější požadavky na kompatibilitu.