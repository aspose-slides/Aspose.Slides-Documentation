---
title: Převod PPTX na PPT v Pythonu
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/python-java/convert-pptx-to-ppt/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPTX
- PPTX na PPT
- uložit PPTX jako PPT
- exportovat PPTX do PPT
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Převod PPTX do staršího formátu PPT v Pythonu pomocí Aspose.Slides pro Python přes Java. Obsahuje ukázkový kód a poznámky o kompatibilitě a chráněných souborech."
---
## **Přehled**

Aspose.Slides pro Python pomocí Java umožňuje převést prezentaci PPTX do staršího formátu PPT, který používal PowerPoint 97–2003, aniž by byl nainstalován Microsoft PowerPoint. Načtěte soubor PPTX a uložte jej ve výstupním formátu PPT, jak je uvedeno níže.

## **Převod PPTX na PPT**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s výstupní cestou a [SaveFormat.Ppt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Ppt).

Následující příklad spustí virtuální stroj Java, pokud je to potřeba, a převádí `template.pptx` na `output.ppt` pomocí výchozích možností. Nahraďte cesty vlastními názvy souborů. Blok `finally` uvolní prostředky prezentace i v případě, že ukládání selže.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Načtěte PPTX prezentaci.
presentation = Presentation("template.pptx")
try:
    # Uložte prezentaci ve formátu PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Argument [SaveFormat.Ppt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Ppt) určuje výstupní formát; pouhá změna přípony souboru nepřevádí prezentaci. Uchovejte původní soubor PPTX, abyste se k němu mohli vrátit, pokud novější funkce nemá ekvivalent v PPT.

## **Převod PPTX do jiných formátů**

Aspose.Slides také podporuje další výstupní formáty. Viz odpovídající články pro možnosti specifické pro formát a příklady:

- [Převod PowerPointu do PDF v Pythonu](/slides/cs/python-java/convert-powerpoint-to-pdf/)
- [Převod PowerPointu do XPS v Pythonu](/slides/cs/python-java/convert-powerpoint-to-xps/)
- [Převod PowerPointu do HTML v Pythonu](/slides/cs/python-java/convert-powerpoint-to-html/)
- [Ukládání prezentací jako ODP v Pythonu](/slides/cs/python-java/save-presentation/)
- [Převod PowerPointu do PNG v Pythonu](/slides/cs/python-java/convert-powerpoint-to-png/)

## **Často kladené otázky**

**Přežijí po převodu na PPT všechny efekty a funkce PPTX?**

Ne vždy. Starší formát PPT nepodporuje každou funkci dostupnou v PPTX. Některé efekty, objekty nebo chování mohou být zjednodušeny nebo zobrazeny odlišně. Prohlédněte si převedenou prezentaci v zamýšleném prohlížeči, zejména pokud obsahuje novější funkce PowerPointu.

**Mohu převést pouze vybrané snímky na PPT?**

Ukládání do PPT zapíše celou prezentaci. Chcete-li převést vybrané snímky, vytvořte novou prezentaci, odstraňte její úvodní prázdný snímek, naklonujte požadované snímky do ní a uložte ji jako PPT. Viz [Clone Slides in Python](/slides/cs/python-java/clone-slides/).

**Mohu převést soubor PPTX chráněný heslem?**

Ano, pokud při načítání zdrojové prezentace zadáte správné heslo. Také můžete nastavit ochranu výstupního souboru. Viz [Password-Protected Presentations](/slides/cs/python-java/password-protected-presentation/).