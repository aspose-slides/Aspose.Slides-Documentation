---
title: Převod prezentací OpenDocument v JavaScriptu
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/nodejs-java/convert-openoffice-odp/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides pro Node.js vám umožní snadno převádět ODP do PDF, HTML a obrazových formátů. Zvyšte výkon vašich aplikací pomocí rychlé a přesné konverze prezentací."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/cs/nodejs-java/) umožňuje konvertovat prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS atd.). API používané pro konverzi souborů ODP do jiných formátů dokumentů je stejné jako to, které se používá pro konverzní operace PowerPoint (PPT a PPTX).

Například, pokud potřebujete převést prezentaci ODP do PDF, můžete tak učinit následovně:

```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Často kladené otázky**

**Co když se po konverzi změní formátování mého souboru ODP?**

ODP a PowerPoint používají odlišné modely prezentací a některé prvky — například tabulky, vlastní písma nebo výplňové styly — se nemusí vykreslovat úplně stejně. Doporučuje se provést kontrolu výstupu a v případě potřeby upravit rozvržení nebo formátování v kódu.

**Potřebuji mít nainstalovaný OpenOffice nebo LibreOffice pro použití konverze ODP?**

Ne, Aspose.Slides je samostatná knihovna a nevyžaduje, aby byl na vašem systému nainstalován OpenOffice nebo LibreOffice.

**Mohu během konverze ODP přizpůsobit výstupní formát (např. nastavit možnosti PDF)?**

Ano, Aspose.Slides poskytuje bohaté možnosti pro přizpůsobení výstupu. Například při ukládání do PDF můžete pomocí třídy [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/) řídit kompresi, kvalitu obrázků, vykreslování textu a další.

**Je Aspose.Slides vhodný pro serverové nebo cloudové zpracování ODP?**

Rozhodně. Aspose.Slides je navržen tak, aby fungoval jak v desktopových, tak serverových prostředích, včetně cloudových platforem jako Azure, AWS a Docker kontejnery, bez jakýchkoli závislostí na uživatelském rozhraní.