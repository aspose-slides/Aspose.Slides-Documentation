---
title: "Porozumění rozdílu: PPT vs PPTX"
linktitle: "PPT vs PPTX"
type: docs
weight: 10
url: /cs/python-java/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT nebo PPTX
- starý formát
- moderní formát
- binární formát
- Office Open XML
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Porovnejte formáty PPT a PPTX, kompatibilitu a možnosti převodu pomocí Aspose.Slides pro Python via Java, včetně ukázky kódu v Pythonu."
---
## **Přehled**

PPT a PPTX jsou formáty prezentací PowerPoint s odlišnou vnitřní strukturou a podporou funkcí. PPT je starý binární formát používaný v PowerPoint 97–2003. PPTX je formát Office Open XML představený v PowerPoint 2007. Tento článek porovnává formáty a ukazuje, jak převést soubor PPT na PPTX pomocí Aspose.Slides for Python via Java.

## **Co je PPT?**

[PPT](https://docs.fileformat.com/presentation/ppt/) ukládá data prezentace v binární struktuře. Čtení nebo úprava jeho obsahu vyžaduje software, který tuto strukturu rozumí. PPT je užitečný při výměně souborů se staršími verzemi PowerPointu, ale jeho schopnost představovat novější funkce prezentací je omezená.

## **Co je PPTX?**

[PPTX](https://docs.fileformat.com/presentation/pptx/) je založen na Office Open XML. Soubor PPTX je balíček ZIP obsahující XML části, média a vztahy mezi těmito částmi. Tato struktura činí formát snazší k prozkoumání a rozšíření než binární PPT. PowerPoint používá PPTX jako výchozí formát prezentací od verze PowerPoint 2007.

## **PPT vs PPTX**

| Aspekt | PPT | PPTX |
| --- | --- | --- |
| Vnitřní struktura | Binární záznamy | ZIP balíček s XML a médii |
| Typické požadavky na kompatibilitu | Postupy PowerPoint 97–2003 | Postupy PowerPoint 2007 a novější |
| Novější funkce prezentace | Omezená podpora; některý obsah může být zjednodušen | Širší podpora nových objektů a efektů |
| Doporučené použití | Výměna se systémy, které vyžadují PPT | Nové prezentace a průběžná úprava |

Převod mezi formáty zahrnuje více než pouhé změnění přípony souboru. Některé funkce PPTX nemají přímý ekvivalent v PPT. PowerPoint může ukládat dodatečné informace ve speciálních PPT záznamech, například data MetroBlob, aby zachoval novější obsah pro pozdější použití. Starší verze PowerPointu nemohou zobrazit celý tento obsah, takže jeho uložení nezaručuje, že se prezentace ve všech prohlížečích bude zobrazovat nebo chovat stejně.

Aspose.Slides for Python via Java poskytuje společné API pro načítání a ukládání obou formátů. Podporuje převod v obou směrech, ale rozdíly ve formátech a nepodporované funkce mohou výsledek ovlivnit. Kde je to možné, upřednostněte PPTX a přezkoumejte prezentace převedené do PPT v zamýšleném prohlížeči.

{{% alert color="info" title="Poznámka" %}}

Vyzkoušejte [Aspose.Slides Conversion app](https://products.aspose.app/slides/cs/conversion/) a online porovnejte výsledky převodu PPT‑to‑PPTX a PPTX‑to‑PPT.

{{% /alert %}}

## **Převod PPT do PPTX v Pythonu**

Načtěte soubor PPT pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a potom zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx). Microsoft PowerPoint není vyžadován.

Příklad spustí virtuální stroj Java, pokud je to potřeba, a uvolní zdroje prezentace v bloku `finally`. Nahraďte vstupní a výstupní cesty vlastními názvy souborů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Načtěte starou prezentaci PPT.
presentation = Presentation("presentation.ppt")
try:
    # Uložte prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro více příkladů viz [Convert PPT to PPTX in Python](/slides/cs/python-java/convert-ppt-to-pptx/). Pro opačný převod a související otázky kompatibility viz [Convert PPTX to PPT in Python](/slides/cs/python-java/convert-pptx-to-ppt/).

## **Často kladené otázky**

**Má smysl uchovávat staré prezentace v PPT, pokud se otevírají bez chyb?**

Můžete ponechat PPT, pokud to vyžaduje existující workflow. Pro průběžnou úpravu a novější funkce zvažte [převod na PPTX](/slides/cs/python-java/convert-ppt-to-pptx/). Ponechte originál, dokud nezkontrolujete převedenou prezentaci.

**Které prezentace bych měl nejdříve převést na PPTX?**

Upřednostněte soubory, které jsou často upravovány nebo sdíleny, obsahují složité [charts](/slides/cs/python-java/create-chart/) nebo [shapes](/slides/cs/python-java/shape-manipulations/), nebo spouštějí varování o kompatibilitě při [opened](/slides/cs/python-java/open-presentation/). Po převodu zkontrolujte jejich vzhled a chování během prezentace.

**Zůstane ochrana heslem zachována při převodu mezi PPT a PPTX?**

Nepředpokládejte, že výstupní ochrana automaticky odpovídá zdroji. Při načítání šifrovaného souboru zadejte požadované heslo, explicitně nastavte výstupní ochranu a ověřte uložený soubor. Viz [Password‑Protected Presentations](/slides/cs/python-java/password-protected-presentation/).

**Proč některé efekty při převodu PPTX na PPT zmizí nebo se zjednoduší?**

PPT nedokáže reprezentovat každý novější objekt, vlastnost nebo efekt. Některé informace mohou být zachovány pro pozdější obnovu, ale starší prohlížeče nemohou zobrazit vše. Uchovávejte originál PPTX, pokud potřebujete zachovat novější funkce.