---
title: Převod ODP na PPTX v Pythonu
linktitle: ODP na PPTX
type: docs
weight: 10
url: /cs/python-java/convert-odp-to-pptx/
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
- Python
- Java
- Aspose.Slides
description: "Převod ODP prezentací do PPTX pomocí Aspose.Slides pro Python via Java. Použijte kompletní ukázku v Pythonu bez nutnosti instalovat PowerPoint nebo LibreOffice."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides for Python via Java převést prezentaci OpenDocument (ODP) do formátu PowerPoint (PPTX).

## **Převod ODP na PPTX**

Třída [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) může načíst soubor ODP přímo. Načtenou prezentaci uložte ve formátu PPTX pomocí [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/).

Postupujte podle [instalační instrukce](/slides/cs/python-java/installation/) před spuštěním příkladu. Umístěte prezentaci ODP pojmenovanou `AccessOpenDoc.odp` do pracovního adresáře. Následující kód spustí JVM, pokud je to nutné, otevře soubor ODP a uloží jej jako `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Uložte prezentaci ODP ve formátu PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Živý příklad**

Vyzkoušejte webovou aplikaci [Aspose.Slides Conversion](https://products.aspose.app/slides/cs/conversion/) a zobrazte převod ODP na PPTX poháněný Aspose.Slides.

## **Často kladené otázky**

**Potřebuji nainstalovat Microsoft PowerPoint nebo LibreOffice pro převod ODP na PPTX?**

Ne. Aspose.Slides for Python via Java čte a zapisuje soubory prezentací bez těchto aplikací. Potřebujete balíček Python a kompatibilní Java runtime.

**Jsou během převodu zachovány hlavní snímky, rozvržení a motivy?**

Aspose.Slides mapuje strukturu a formátování zdrojové prezentace do PPTX. Nicméně ODP a PPTX podporují různé funkce, takže některé prvky mohou po převodu vypadat odlišně. Zajistěte dostupnost potřebných fontů a přezkoumejte prezentace s komplikovaným formátováním. Viz [Převod OpenDocument](/slides/cs/python-java/convert-openoffice-odp/) pro informace o kompatibilitě.

**Mohu převádět soubory ODP chráněné heslem?**

Ano, pokud poskytnete heslo potřebné k otevření souboru. Viz [prezentace chráněné heslem](/slides/cs/python-java/password-protected-presentation/) pro podrobnosti o načítání chráněných souborů před jejich uložením do jiného formátu.

**Je Aspose.Slides vhodný pro cloudové nebo RESTové konverzní služby?**

Ano. Můžete použít Aspose.Slides for Python via Java ve vašem backendu s požadovaným Java runtime. Pro REST API viz [Aspose.Slides Cloud](https://products.aspose.cloud/slides/cs/family/).