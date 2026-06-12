---
title: Renderovat snímky prezentace jako SVG obrázky na Androidu
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint na SVG
- prezentace na SVG
- snímek na SVG
- PPT na SVG
- PPTX na SVG
- uložit PPT jako SVG
- uložit PPTX jako SVG
- exportovat PPT do SVG
- exportovat PPTX do SVG
- renderovat snímek
- převést snímek
- exportovat snímek
- vektorový obrázek
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak renderovat snímky PowerPointu jako SVG obrázky pomocí Aspose.Slides pro Android. Vysoce kvalitní vizuály s jednoduchými příklady kódu v jazyce Java."
---
## **Přehled**

Cílem tohoto článku je vysvětlit, jak pomocí Aspose.Slides renderovat snímky prezentace jako SVG obrázky. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro vývoj webu.

Naučíte se, jak načíst soubor prezentace, projít její snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `writeAsSvg`.

## **Formát SVG**

SVG - zkratka pro Scalable Vector Graphics - je standardní typ nebo formát grafiky používaný k renderování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.

SVG patří k několika formátům obrázků, které splňují velmi vysoké standardy v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů se běžně používá ve vývoji webu.

Můžete chtít použít SVG soubory, když potřebujete

- **vytisknout svou prezentaci ve *velmi velkém formátu***. SVG obrázky lze škálovat na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků kolikrát potřebujete, aniž byste ztratili kvalitu.
- **použít grafy a diagramy ze svých snímků v *různých médiích nebo platformách***. Většina čteček dokáže interpretovat SVG soubory.
- **použít *co nejmenší možné velikosti obrázků***. SVG soubory jsou obecně menší než jejich vysoce rozlišené ekvivalenty v jiných formátech, zejména v těch založených na bitmapě (JPEG nebo PNG).

## **Vykreslení snímku jako SVG obrázku**

Aspose.Slides for Android via Java umožňuje exportovat snímky ve vašich prezentacích jako SVG obrázky. Proveďte následující kroky pro vytvoření SVG obrázků:

1. Vytvořte instanci třídy `Presentation`.
2. Projděte všechny snímky v prezentaci.
3. Zapište každý snímek do samostatného SVG souboru pomocí `FileOutputStream`.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT na SVG z Aspose.Slides for Android via Java.
{{% /alert %}} 

Tento ukázkový kód v jazyce Java ukazuje, jak převést PPT na SVG pomocí Aspose.Slides:

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

**Proč může vypadat výsledné SVG odlišně v různých prohlížečích?**

Podpora konkrétních funkcí SVG je v různých prohlížečových enginech implementována odlišně. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/) pomáhají vyhladit nekompatibility.

**Je možné exportovat nejen snímky, ale také jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatný SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), což je výhodné pro ikony, piktogramy a opětovné použití grafiky.

**Lze více snímků sloučit do jednoho SVG (strip/dokument)?**

Standardní scénář je jeden snímek → jeden SVG. Sloučení několika snímků do jedné SVG plátna je krok zpracování po konverzi, který se provádí na úrovni aplikace.