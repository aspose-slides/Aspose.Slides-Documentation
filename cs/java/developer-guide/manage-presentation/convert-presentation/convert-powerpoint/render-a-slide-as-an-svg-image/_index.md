---
title: Vykreslit snímky prezentace jako SVG obrázky v Javě
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Javu vykreslovat PowerPoint snímky jako SVG obrázky. Vysoce kvalitní vizuály s jednoduchými ukázkami kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides vykreslovat snímky prezentace jako SVG obrázky. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro webový vývoj.

Naučíte se, jak načíst soubor prezentace, procházet její snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `writeAsSvg`.

## **Formát SVG**

SVG—zkratka pro Scalable Vector Graphics—je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.

SVG je jedním z mála formátů obrázků, který splňuje velmi vysoké standardy v těchto ohledech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů je běžně používán ve vývoji webu.

Můžete chtít použít SVG soubory, když potřebujete

- **vytisknout svou prezentaci ve *velmi velkém formátu*.** SVG obrázky lze škálovat na libovolné rozlišení nebo úroveň. Můžete velikost SVG obrázků měnit tolikrát, kolik potřebujete, aniž byste obětovali kvalitu.
- **použít grafy a diagramy ze svých snímků v *různých médiích nebo platformách*.** Většina prohlížečů dokáže SVG soubory interpretovat.
- **použít *co nejmenší velikosti obrázků*.** SVG soubory jsou obecně menší než jejich vysoce rozlišené ekvivalenty v jiných formátech, zejména v formátech založených na bitmapě (JPEG nebo PNG).

## **Vykreslit snímek jako SVG obrázek**

Aspose.Slides pro Java vám umožňuje exportovat snímky z vašich prezentací jako SVG obrázky. Proveďte následující kroky k vytvoření SVG obrázků:

1. Vytvořte instanci třídy `Presentation`.
2. Procházejte všechny snímky v prezentaci.
3. Zapíšte každý snímek do jeho vlastního SVG souboru pomocí `FileOutputStream`.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT na SVG z Aspose.Slides pro Java.
{{% /alert %}} 

Tento ukázkový kód v Javě vám ukazuje, jak převést PPT na SVG pomocí Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Proč může vypadat výsledný SVG různě v různých prohlížečích?**

Podpora konkrétních funkcí SVG je implementována různými prohlížečovými jádry odlišně. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/) pomáhají vyrovnávat nekompatibility.

**Je možné exportovat nejen snímky, ale i jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatný SVG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), což je praktické pro ikony, piktogramy a opětovné použití grafiky.

**Lze více snímků sloučit do jednoho SVG (strip/dokumentu)?**

Standardní scénář je jeden snímek → jeden SVG. Sloučení několika snímků do jediné SVG plochy je krok po zpracování prováděný na úrovni aplikace.