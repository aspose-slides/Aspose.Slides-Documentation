---
title: Převod ODP do PPTX v Pythonu
linktitle: ODP do PPTX
type: docs
weight: 10
url: /cs/python-net/convert-odp-to-pptx/
keywords:
- převod OpenDocument
- převod ODP
- OpenDocument do PPTX
- ODP do PPTX
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Převod ODP do PPTX pomocí Aspose.Slides pro Python přes .NET. Čisté ukázky kódu, tipy pro dávkové zpracování a výsledky vysoké kvality - není potřeba PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Export ODP do PPTX**

Aspose.Slides pro Python přes .NET nabízí třídu Presentation, která představuje soubor prezentace. [**Presentation**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) třída může nyní také přistupovat k ODP prostřednictvím konstruktoru Presentation při vytváření instance objektu. Následující příklad ukazuje, jak převést prezentaci ODP na PPTX prezentaci.

```py
# Import Aspose.Slides pro Python přes .NET modul
import aspose.slides as slides

# Otevřít soubor ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Uložení ODP prezentace do formátu PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukázkový příklad**

Můžete navštívit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/) webovou aplikaci, která je postavena pomocí **Aspose.Slides API**. Aplikace demonstruje, jak lze převod ODP na PPTX implementovat s Aspose.Slides API.

## **Často kladené otázky**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje aplikace třetích stran pro čtení nebo zápis ODP/PPTX.

**Zůstávají během konverze zachovány hlavní snímky, rozvržení a motivy?**

Ano. Knihovna používá kompletní objektový model prezentace a zachovává strukturu, včetně hlavních snímků a rozvržení, takže návrh zůstane po konverzi správný.

**Mohu převádět soubory ODP chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevírání a práci s [protected presentations](/slides/cs/python-net/password-protected-presentation/) (včetně ODP), když poskytnete heslo, stejně jako konfiguraci šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené konverzní služby?**

Ano. Můžete použít lokální knihovnu ve svém back‑endu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); obě možnosti podporují konverzi ODP → PPTX.