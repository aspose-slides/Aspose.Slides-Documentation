---
title: Vykreslit snímky prezentace jako SVG obrázky v C++
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- uložit PPT jako SVG
- uložit PPTX jako SVG
- exportovat PPT do SVG
- exportovat PPTX do SVG
- vykreslit snímek
- převést snímek
- exportovat snímek
- vektorový obrázek
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro C++ vykreslit snímky PowerPoint jako SVG obrázky. Vysoce kvalitní vizuály s jednoduchými ukázkami kódu."
---
## **Přehled**

Tento článek vysvětluje, jak vykreslovat snímky prezentace jako SVG obrázky pomocí Aspose.Slides. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro webový vývoj.

Dozvíte se, jak načíst soubor prezentace, projít její snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `WriteAsSvg`.

## **Formát SVG**

SVG — zkratka pro Scalable Vector Graphics — je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.

SVG je jedním z mála formátů pro obrázky, které splňují velmi vysoké standardy v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů je běžně používán ve webovém vývoji.

Můžete chtít používat SVG soubory, když potřebujete

- **vytisknout prezentaci ve *velmi velkém formátu*.** SVG obrázky lze zvětšit na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků tolikrát, kolik je potřeba, aniž byste ztratili kvalitu.
- **použít grafy a diagramy ze svých snímků v *různých médiích nebo platformách*.** Většina čteček dokáže interpretovat SVG soubory.
- **dosáhnout *nejmenších možných velikostí obrázků*.** SVG soubory jsou obecně menší než jejich vysokorozlišovací ekvivalenty v jiných formátech, zejména v bitmapových formátech (JPEG nebo PNG).

## **Vykreslení snímku jako SVG obrázku**

Aspose.Slides pro C++ vám umožňuje exportovat snímky v prezentacích jako SVG obrázky. Proveďte následující kroky k vytvoření SVG obrázků:

1. Vytvořte instanci třídy Presentation.
2. Projděte všechny snímky v prezentaci.
3. Zapíšete každý snímek do vlastního SVG souboru pomocí FileStream.

{{% alert color="primary" %}} 

Můžete si vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT na SVG z Aspose.Slides pro C++.

{{% /alert %}} 

Tento ukázkový kód v C++ vám ukazuje, jak převést PPT na SVG pomocí Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **Často kladené otázky**

**Proč se výsledné SVG může lišit mezi prohlížeči?**

Podpora konkrétních funkcí SVG je implementována různě v enginech prohlížečů. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/) pomáhají vyhladit nekompatibility.

**Je možné exportovat nejen snímky, ale i jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatný SVG](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/), což je praktické pro ikony, piktogramy a opětovné použití grafiky.

**Lze sloučit několik snímků do jednoho SVG (pruh/dokumentu)?**

Standardní scénář je jeden snímek → jeden SVG. Sloučení více snímků do jednoho SVG plátna je krok po zpracování prováděný na úrovni aplikace.