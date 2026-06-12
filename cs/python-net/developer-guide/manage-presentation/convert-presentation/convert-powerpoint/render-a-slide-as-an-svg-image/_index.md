---
title: Vykreslit snímky prezentace jako SVG obrázky v Pythonu
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/python-net/render-a-slide-as-an-svg-image/
keywords:
- snímek na SVG
- prezentace na SVG
- PowerPoint na SVG
- OpenDocument na SVG
- PPT na SVG
- PPTX na SVG
- ODP na SVG
- vykreslit snímek
- převést snímek
- exportovat snímek
- vektorový obrázek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Python via .NET vykreslovat snímky PowerPoint a OpenDocument jako SVG obrázky. Vysoce kvalitní vizuály s jednoduchými ukázkami kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides vykreslit snímky prezentace jako SVG obrázky. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro webový vývoj.

Dozvíte se, jak načíst soubor prezentace, projít její snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `write_as_svg`.

## **Formát SVG**

SVG – zkratka pro Scalable Vector Graphics – je standardní grafický typ nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.

SVG je jedním z mála formátů obrázků, který splňuje velmi vysoké standardy v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů se běžně používá ve webovém vývoji.

Můžete chtít použít SVG soubory, když potřebujete:

- **vytisknout vaši prezentaci ve *velmi velkém formátu*.** SVG obrázky lze zvětšit na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků tolikrát, kolik potřebujete, aniž by došlo ke ztrátě kvality.
- **používat grafy a diagramy z vašich snímků v *různých médiích nebo platformách*.** Většina čteček dokáže interpretovat SVG soubory.
- **používat *co nejmenší velikosti obrázků*.** SVG soubory jsou obecně menší než jejich vysokorozlišovací ekvivalenty v jiných formátech, zejména v těch, které jsou založeny na bitmapách (JPEG nebo PNG).

## **Vykreslení snímku jako SVG obrázku**

Aspose.Slides for Python via .NET vám umožňuje exportovat snímky ve vašich prezentacích jako SVG obrázky. Proveďte následující kroky k vygenerování SVG obrázků:

1. Vytvořte instanci třídy `Presentation`.
2. Projděte všechny snímky v prezentaci.
3. Zapište každý snímek do vlastního SVG souboru pomocí `FileStream`.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT do SVG z Aspose.Slides for Python via .NET. 
{{% /alert %}} 

Tento ukázkový kód v Pythonu vám ukáže, jak převést PPT do SVG pomocí Aspose.Slides:

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace 
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```

## **Často kladené otázky**

**Proč se může výsledný SVG zobrazovat odlišně v různých prohlížečích?**

Podpora konkrétních SVG funkcí je v prohlížečových jádrech implementována odlišně. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/) pomáhají vyhladit nekompatibility.

**Je možné exportovat nejen snímky, ale také jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatný SVG](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/), což je výhodné pro ikony, piktogramy a opětovné využití grafiky.

**Lze spojit více snímků do jednoho SVG (strip/dokumentu)?**

Standardní scénář je jeden snímek → jeden SVG. Spojení několika snímků do jediného SVG plátna je krok po zpracování prováděný na úrovni aplikace.