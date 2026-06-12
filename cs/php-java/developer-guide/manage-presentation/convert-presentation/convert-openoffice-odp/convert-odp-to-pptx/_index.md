---
title: Převod ODP do PPTX v PHP
linktitle: ODP do PPTX
type: docs
weight: 10
url: /cs/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Převod ODP do PPTX pomocí Aspose.Slides pro PHP přes Java. Čisté ukázky kódu, tipy pro dávkové zpracování a výsledky vysoké kvality -- není potřeba PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci ODP do formátu PPTX pomocí Aspose.Slides.

## **Převod ODP do PPTX/PPT prezentace**
Aspose.Slides pro PHP přes Java nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation), která představuje soubor prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) nyní může také přistupovat k ODP pomocí konstruktoru [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#Presentation-java.lang.String-), když je objekt vytvořen. Následující příklad ukazuje, jak převést prezentaci ODP na prezentaci PPTX.

```php
// Otevřít soubor ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Ukládání prezentace ODP do formátu PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Ukázkový příklad**
Můžete navštívit webovou aplikaci [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/), která je postavena s **Aspose.Slides API.** Aplikace ukazuje, jak lze převod ODP na PPTX implementovat pomocí Aspose.Slides API.

## **FAQ**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice k převodu ODP na PPTX?**

Ne. Aspose.Slides funguje samostatně a nevyžaduje žádné aplikace třetích stran pro čtení nebo zápis ODP/PPTX.

**Zůstávají při převodu zachovány hlavní snímky, rozvržení a motivy?**

Ano. Knihovna používá kompletní model objektu prezentace a zachovává strukturu, včetně hlavních snímků a rozvržení, takže design zůstává po převodu správný.

**Mohu převádět soubory ODP chráněné heslem?**

Ano. Aspose.Slides podporuje detekci ochrany, otevírání a práci s [chráněnými prezentacemi](/slides/cs/php-java/password-protected-presentation/) (včetně ODP), když zadáte heslo, a také konfiguraci šifrování a přístup k vlastnostem dokumentu.

**Je Aspose.Slides vhodný pro cloudové nebo REST‑založené služby převodu?**

Ano. Můžete použít lokální knihovnu ve svém backendu nebo [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/) (REST API); obě možnosti podporují převod ODP → PPTX.