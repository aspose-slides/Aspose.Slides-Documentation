---
title: Převod ODP na PPTX v Javě
linktitle: ODP na PPTX
type: docs
weight: 10
url: /cs/java/convert-odp-to-pptx/
keywords:
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést ODP
- OpenDocument na PPTX
- ODP na PPTX
- uložit ODP jako PPTX
- exportovat ODP do PPTX
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Převod ODP na PPTX pomocí Aspose.Slides pro Java. Čisté příklady kódu v Javě, tipy pro dávkové zpracování a vysoce kvalitní výsledky - bez potřeby PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Převod ODP na PPTX/PPT prezentaci**
Aspose.Slides pro Java nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která představuje soubor prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) nyní může také přistupovat k ODP prostřednictvím konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) při vytváření objektu. Následující příklad ukazuje, jak převést ODP prezentaci na PPTX prezentaci.

```java
// Otevřete soubor ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Ukládání ODP prezentace do formátu PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ukázkový příklad**
Můžete navštívit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/) webovou aplikaci, která je postavena na **Aspose.Slides API**. Aplikace demonstruje, jak lze převod ODP na PPTX implementovat pomocí Aspose.Slides API.

## **Často kladené otázky**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje žádné aplikace třetích stran pro čtení nebo zápis ODP/PPTX.

**Jsou během převodu zachovány hlavní snímky, rozvržení a motivy?**

Ano. Knihovna používá kompletní objektový model prezentace a zachovává strukturu, včetně hlavních snímků a rozvržení, takže design zůstává po převodu správný.

**Mohu převádět ODP soubory chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevírání a práci s [chráněnými prezentacemi](/slides/cs/java/password-protected-presentation/) (včetně ODP), pokud zadáte heslo, a také konfiguraci šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené konverzní služby?**

Ano. Můžete použít lokální knihovnu ve svém vlastním backendu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); oba možnosti podporují převod ODP → PPTX.