---
title: Převod ODP na PPTX v JavaScriptu
linktitle: ODP na PPTX
type: docs
weight: 10
url: /cs/nodejs-java/convert-odp-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod ODP na PPTX pomocí Aspose.Slides pro Node.js. Přehledné příklady kódu v JavaScriptu, tipy pro dávkové zpracování a vysoce kvalitní výsledky—bez potřeby PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Převod ODP na PPTX/PPT prezentaci**
Aspose.Slides pro Node.js přes Java nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), která představuje soubor prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) nyní může také přistupovat k ODP pomocí konstruktoru [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) při vytvoření objektu. Následující příklad ukazuje, jak převést ODP prezentaci na PPTX prezentaci.

```javascript
// Otevřít soubor ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Uložení prezentace ODP do formátu PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Živý příklad**
Můžete navštívit webovou aplikaci [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/), která je postavena na **Aspose.Slides API**. Aplikace ukazuje, jak lze převod ODP na PPTX implementovat pomocí Aspose.Slides API.

## **Často kladené otázky**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje žádné aplikace třetích stran pro čtení nebo zápis ODP/PPTX.

**Jsou během převodu zachovány hlavní snímky, rozvržení a motivy?**

Ano. Knihovna používá kompletní objektový model prezentace a zachovává strukturu, včetně hlavních snímků a rozvržení, takže design zůstane po převodu správný.

**Mohu převádět soubory ODP chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevírání a práci s [protected presentations](/slides/cs/nodejs-java/password-protected-presentation/) (včetně ODP), pokud zadáte heslo, a také nastavení šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené konverzní služby?**

Ano. Můžete použít lokální knihovnu ve svém backendu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); obě možnosti podporují převod ODP → PPTX.