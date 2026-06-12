---
title: Převod snímků PowerPoint na PNG v Javě
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/java/convert-powerpoint-to-png/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- Java
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro Java, s přesnými a automatizovanými výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint na obrázky PNG pomocí Aspose.Slides. Ukazuje, jak načíst soubory prezentací ve formátech jako PPT, PPTX a ODP, vykreslit snímky jako obrázky a uložit výsledky ve formátu PNG.

Článek také ukazuje, jak přizpůsobit generované obrázky PNG nastavením hodnot měřítka nebo určením požadované šířky a výšky.

## **Převod PowerPointu na PNG**

Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte objekt snímku z kolekce [Presentation.getSlides()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) pod rozhraním [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide).
3. Použijte metodu [ISlide.getImage()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide) k získání náhledového obrázku pro každý snímek.
4. Použijte metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) k uložení náhledového obrázku snímku do formátu PNG.

Tento kód v jazyce Java vám ukazuje, jak převést prezentaci PowerPoint na PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převod PowerPointu na PNG s vlastními rozměry**

Pokud chcete získat soubory PNG v určitém měřítku, můžete nastavit hodnoty `desiredX` a `desiredY`, které určují rozměry výsledného náhledu.

Tento kód v jazyce Java demonstruje popsanou operaci:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pokud chcete získat soubory PNG v určité velikosti, můžete předat své preferované argumenty `width` a `height` pro `ImageSize`.

Tento kód vám ukazuje, jak převést PowerPoint na PNG při specifikaci velikosti obrázků:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celé snímku?**

Aspose.Slides podporuje [generování náhledových obrázků pro jednotlivé tvary](/slides/cs/java/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je paralelní převod podporován na serveru?**

Ano, ale [nesdílejte](/slides/cs/java/multithreading/) jednu instanci prezentace napříč vlákny. Používejte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení zkušební verze při exportu do PNG?**

Režim hodnocení přidává vodoznak do výstupních obrázků a vynucuje [další omezení](/slides/cs/java/licensing/), dokud není licence aplikována.