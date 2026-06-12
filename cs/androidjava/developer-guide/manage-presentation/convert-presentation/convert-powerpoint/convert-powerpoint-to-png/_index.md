---
title: Převod snímků PowerPoint do PNG na Androidu
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /cs/androidjava/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do PNG
- prezentace do PNG
- snímek do PNG
- PPT do PNG
- PPTX do PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- Android
- Java
- Aspose.Slides
description: "Rychle převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky pomocí Aspose.Slides pro Android v Java, zajišťující přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do PNG obrázků pomocí Aspose.Slides. Ukazuje, jak načíst soubory prezentací v formátech jako PPT, PPTX a ODP, vykreslit snímky jako obrázky a uložit výsledek ve formátu PNG.

Článek také ukazuje, jak přizpůsobit generované PNG obrázky nastavením hodnot měřítka nebo určením požadované šířky a výšky.

## **Převést PowerPoint do PNG**

Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získáte objekt snímku z kolekce [Presentation.getSlides()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) pod rozhraním [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide) .
3. Použijte metodu [ISlide.getImage()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide), abyste získali miniaturu pro každý snímek.
4. Použijte metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)), abyste uložili miniaturu snímku ve formátu PNG.

Tento Java kód ukazuje, jak převést prezentaci PowerPoint do PNG:

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

## **Převést PowerPoint do PNG s vlastními rozměry**

Pokud chcete získat PNG soubory s určitým měřítkem, můžete nastavit hodnoty `desiredX` a `desiredY`, které určují rozměry výsledné miniatury. 

Tento kód v Javě demonstruje popsanou operaci:

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

## **Převést PowerPoint do PNG s vlastní velikostí**

Pokud chcete získat PNG soubory s určitou velikostí, můžete předat požadované argumenty `width` a `height` pro `ImageSize`. 

Tento kód ukazuje, jak převést PowerPoint do PNG a přitom zadat velikost obrázků: 

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

## **FAQ**

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/androidjava/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je paralelní převod podporován na serveru?**

Ano, ale [nesdílejte](/slides/cs/androidjava/multithreading/) jedinou instanci prezentace mezi vlákny. Použijte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení zkušební verze při exportu do PNG?**

Režim hodnocení přidává do výstupních obrázků vodoznak a vynucuje [další omezení](/slides/cs/androidjava/licensing/), dokud není použita licence.