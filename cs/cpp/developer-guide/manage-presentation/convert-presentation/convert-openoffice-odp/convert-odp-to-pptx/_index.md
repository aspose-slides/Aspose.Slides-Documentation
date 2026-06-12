---
title: Převod ODP do PPTX v C++
linktitle: ODP na PPTX
type: docs
weight: 10
url: /cs/cpp/convert-odp-to-pptx/
keywords:
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést ODP
- OpenDocument do PPTX
- ODP do PPTX
- uložit ODP jako PPTX
- exportovat ODP do PPTX
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Převod ODP do PPTX pomocí Aspose.Slides pro C++. Cisté ukázky kodu, tipy pro davkove zpracovani a vysoke kvality vysledky - neni potreba PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Převod ODP na PPTX**

Aspose.Slides pro .NET poskytuje třídu Presentation, která představuje soubor prezentace. [**Presentation**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) třída nyní může také přistupovat k ODP přes konstruktor Presentation, když je objekt vytvořen. Následující příklad ukazuje, jak převést prezentaci ODP na prezentaci PPTX.

``` cpp
// Cesta k adresáři dokumentů.
String dataDir = GetDataPath();

// Otevřít soubor ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Uložení prezentace ODP do formátu PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Živý příklad**

Můžete navštívit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/) webovou aplikaci, která je postavena na **Aspose.Slides API.** Aplikace ukazuje, jak lze převod ODP na PPTX implementovat pomocí Aspose.Slides API.

## **Často kladené otázky**

**Musím nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje žádné aplikace třetích stran pro čtení nebo zápis souborů ODP/PPTX.

**Jsou během konverze zachovány hlavní snímky, rozvržení a motivy?**

Ano. Knihovna používá kompletní model objektu prezentace a zachovává strukturu, včetně hlavních snímků a rozvržení, takže design zůstává po konverzi správný.

**Mohu převádět soubory ODP chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevírání a práci s [protected presentations](/slides/cs/cpp/password-protected-presentation/) (včetně ODP), pokud zadáte heslo, a také nastavení šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené konverzní služby?**

Ano. Můžete použít lokální knihovnu ve svém vlastním backendu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); obě možnosti podporují konverzi ODP → PPTX.