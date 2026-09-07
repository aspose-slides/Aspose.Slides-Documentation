---
title: Převést prezentace PowerPoint do XPS v Pythonu
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /cs/python-java/convert-powerpoint-to-xps/
keywords:
- převést PowerPoint
- převést prezentaci
- převést PPT
- převést PPTX
- PowerPoint do XPS
- prezentace do XPS
- PPT do XPS
- PPTX do XPS
- uložit PPT jako XPS
- uložit PPTX jako XPS
- exportovat PPT do XPS
- exportovat PPTX do XPS
- Python
- Java
- Aspose.Slides
description: "Převést prezentace PowerPoint PPT a PPTX do XPS v Pythonu pomocí Aspose.Slides for Python via Java, s výchozími nebo vlastními nastaveními exportu."
---
## **Přehled**

Aspose.Slides for Python via Java umožňuje převádět prezentace PowerPoint do XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být XPS užitečný, a ukazuje, jak exportovat prezentaci pomocí výchozích nastavení nebo vlastních nastavení [XpsOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xpsoptions/).

## **O XPS**

XPS (XML Paper Specification) je formát dokumentu založený na XML, vyvinutý společností Microsoft. Popisuje pevné stránky, zachovává rozvržení textu a grafiky pro prohlížení a tisk s kompatibilním softwarem.

## **Kdy použít formát Microsoft XPS**

XPS použijte, když dokumentový workflow vyžaduje soubory s pevnou rozložením pro sdílení nebo tisk pomocí nástrojů kompatibilních s XPS. Příjemci potřebují software, který podporuje XPS. Pokud váš workflow vyžaduje místo toho PDF, podívejte se na [Převést PowerPoint do PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Pro vyzkoušení převodu prezentace PPT nebo PPTX do XPS použijte [bezplatný online převodník](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}

| Vstupní prezentace PowerPoint | Výstupní dokument XPS |
| --- | --- |
| ![Původní prezentace PowerPoint](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Prezentace převedená do XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Konverze XPS s Aspose.Slides**

Použijte metodu [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) s [SaveFormat.Xps](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Xps) pro export prezentace. Můžete použít výchozí nastavení exportu nebo poskytnout [XpsOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xpsoptions/) k přizpůsobení výstupu.

Každý níže uvedený příklad spustí virtuální stroj Java, pokud je to potřeba, a po použití uvolní prezentaci. Nahraďte vstupní název souboru cestou k vašemu souboru PPT nebo PPTX.

### **Převést prezentace do XPS pomocí výchozích nastavení**

Následující kód v Pythonu převádí prezentaci do XPS pomocí výchozích nastavení:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Uložte prezentaci jako dokument XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Převést prezentace do XPS pomocí vlastních nastavení**

Následující příklad používá [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) k uložení metafile jako PNG obrázků ve výsledném dokumentu XPS:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Uložte prezentaci s vlastními nastaveními XPS.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu uložit XPS do proudu místo do souboru?**

Ano. Metoda [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) má přetížení, která přijímají výstupní stream Java. S Pythonem přes Java použijte kompatibilní Java stream přes JPype, například Java byte-array output stream, abyste udrželi exportovaná data v paměti.

**Jsou skryté snímky zahrnuty ve výstupu XPS?**

Skryté snímky jsou ve výchozím nastavení vyloučeny. Chcete‑li je zahrnout, nastavte [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) na `True` před uložením.

**Jsou animace a přechody snímků zachovány v XPS?**

Ne. XPS obsahuje pevné stránky, takže exportované snímky nepřehrávají animace ani efekty přechodů.