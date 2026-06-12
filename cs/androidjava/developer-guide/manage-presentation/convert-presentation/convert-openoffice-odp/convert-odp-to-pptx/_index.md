---
title: Převod ODP na PPTX na Androidu
linktitle: ODP na PPTX
type: docs
weight: 10
url: /cs/androidjava/convert-odp-to-pptx/
keywords:
- převod OpenDocument
- převod prezentace
- převod snímku
- převod ODP
- OpenDocument na PPTX
- ODP na PPTX
- uložit ODP jako PPTX
- exportovat ODP do PPTX
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Převod ODP na PPTX pomocí Aspose.Slides pro Android. Čisté ukázky kódu v Javě, tipy pro dávkové zpracování a vysoce kvalitní výsledky - není potřeba PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Převod ODP na PPTX/PPT prezentaci**
Aspose.Slides pro Android prostřednictvím Java nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), která představuje soubor prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) nyní může také přistupovat k ODP pomocí konstruktoru [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-), když je objekt vytvořen. Následující příklad ukazuje, jak převést prezentaci ODP na prezentaci PPTX.

```java
// Otevřít soubor ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Ukládání ODP prezentace do formátu PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Živý příklad**
Můžete navštívit webovou aplikaci [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/), která je postavena na **Aspose.Slides API**. Aplikace ukazuje, jak lze převod ODP na PPTX implementovat pomocí Aspose.Slides API.

## **Často kladené otázky**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje žádné aplikace třetích stran pro čtení nebo zápis ODP/PPTX.

**Jsou během převodu zachovány master snímky, rozvržení a motivy?**

Ano. Knihovna používá kompletní objektový model prezentace a zachovává strukturu, včetně master snímků a rozvržení, takže design zůstane po převodu správný.

**Mohu převést soubory ODP chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevření a práci s [protected presentations](/slides/cs/androidjava/password-protected-presentation/) (včetně ODP), pokud zadáte heslo, a také konfiguraci šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené konverzní služby?**

Ano. Můžete použít lokální knihovnu ve svém vlastním backendu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); obě možnosti podporují převod ODP → PPTX.