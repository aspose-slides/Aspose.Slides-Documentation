---
title: Převod ODP na PPTX v .NET
linktitle: ODP na PPTX
type: docs
weight: 10
url: /cs/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Převod ODP na PPTX pomocí Aspose.Slides pro .NET. Čisté ukázky kódu v C#, tipy pro dávkové zpracování a vysoce kvalitní výsledky - není potřeba PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Převod ODP na PPTX**

Aspose.Slides pro .NET nabízí třídu **Presentation**, která představuje soubor prezentace. [**Presentation**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) třída nyní může také přistupovat k ODP prostřednictvím konstruktoru Presentation při vytvoření objektu. Následující příklad ukazuje, jak převést prezentaci ODP na prezentaci PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Kroky: Převod ODP na PPTX v C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Kroky: Převod ODP na PowerPoint v C#</strong></a>

```c#
// Otevřete soubor ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Ukládání prezentace ODP do formátu PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Živý příklad**

Můžete navštívit webovou aplikaci [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/), která je postavena na **Aspose.Slides API**. Aplikace ukazuje, jak lze převod ODP na PPTX implementovat pomocí Aspose.Slides API.

## **Často kladené otázky**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje žádné aplikace třetích stran pro čtení nebo zápis ODP/PPTX.

**Zůstávají během převodu zachovány hlavní snímky, rozložení a motivy?**

Ano. Knihovna používá kompletní objektový model prezentace a zachovává strukturu, včetně hlavních snímků a rozložení, takže design zůstane po převodu správný.

**Mohu převést soubory ODP chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevírání a práci s [protected presentations](/slides/cs/net/password-protected-presentation/) (včetně ODP), pokud zadáte heslo, a také konfiguraci šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené konverzní služby?**

Ano. Můžete použít místní knihovnu ve svém backendu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); obě možnosti podporují převod ODP → PPTX.