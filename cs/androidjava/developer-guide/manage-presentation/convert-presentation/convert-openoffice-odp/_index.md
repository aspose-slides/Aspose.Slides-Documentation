---
title: Převod prezentací OpenDocument na Androidu
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/androidjava/convert-openoffice-odp/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides pro Android vám umožňuje snadno převádět ODP na PDF, HTML a formáty obrázků. Zvyšte výkon svých Java aplikací rychlým a přesným převodem prezentací."
---
## **Úvod**

[**Aspose.Slides API**](https://products.aspose.com/slides/cs/androidjava/) umožňuje převádět prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS atd.). API použité k převodu souborů ODP do jiných formátů dokumentů je stejné jako to, které se používá pro operace převodu PowerPointu (PPT a PPTX).

Například pokud potřebujete převést prezentaci ODP do PDF, můžete tak učinit následujícím způsobem:

```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Často kladené otázky**

**Co když se po převodu změní formátování mého souboru ODP?**

ODP a PowerPoint používají odlišné modely prezentací a některé prvky—jako tabulky, vlastní písma nebo styly výplně—nemusí být vykresleny naprosto stejně. Doporučuje se zkontrolovat výstup a v případě potřeby upravit rozvržení nebo formátování v kódu.

**Potřebuji mít nainstalovaný OpenOffice nebo LibreOffice k použití převodu ODP?**

Ne, Aspose.Slides je samostatná knihovna a nevyžaduje, aby byl na vašem systému nainstalován OpenOffice nebo LibreOffice.

**Mohu během převodu ODP přizpůsobit výstupní formát (např. nastavit možnosti PDF)?**

Ano, Aspose.Slides poskytuje bohaté možnosti přizpůsobení výstupu. Například při ukládání do PDF můžete pomocí třídy [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) kontrolovat kompresi, kvalitu obrázků, vykreslování textu a další.

**Je Aspose.Slides vhodný pro zpracování ODP na serverové nebo cloudové úrovni?**

Rozhodně. Aspose.Slides je navržen tak, aby fungoval jak v desktopových, tak serverových prostředích, včetně cloudových platforem jako Azure, AWS a kontejnerů Docker, bez jakýchkoli UI závislostí.