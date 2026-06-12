---
title: Vkládání písem do prezentací na Androidu
linktitle: Vkládání písma
type: docs
weight: 40
url: /cs/androidjava/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písma
- získat vložené písmo
- přidat vložené písmo
- odstranit vložené písmo
- komprimovat vložené písmo
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vkládejte TrueType písma do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Android v jazyce Java, což zajišťuje přesné vykreslování na všech platformách."
---
## **Úvod**

**Vložená písma v PowerPointu** jsou užitečná, když chcete, aby se vaše prezentace zobrazovala správně na jakémkoli systému nebo zařízení. Pokud jste použili písmo třetí strany nebo nestandardní písmo, protože jste byli kreativní, máte ještě více důvodů písmo vložit. V opačném případě (bez vložených písem) se texty nebo čísla na snímcích, rozvržení, stylování atd. mohou změnit nebo se proměnit v matoucí obdélníky. 

Třídy [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontdata/) a [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) a jejich rozhraní obsahují většinu vlastností a metod, které potřebujete pro práci s vloženými písmy v prezentacích PowerPoint.

## **Získání a odebrání vložených písem**

Aspose.Slides poskytuje metodu [getEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (vystavenou třídou [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager)), která vám umožní získat (nebo zjistit) písma vložená v prezentaci. Pro odebrání písem se používá metoda [removeEmbeddedFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (vystavená stejnou třídou).

Tento Java kód ukazuje, jak získat a odebrat vložená písma z prezentace:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Vykreslí snímek obsahující textový rámec používající vložené "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Uloží obrázek na disk ve formátu JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Získá všechna vložená písma
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Najde písmo "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Odstraní písmo "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Vykreslí prezentaci; písmo "Calibri" je nahrazeno existujícím
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Uloží obrázek na disk ve formátu JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Uloží prezentaci bez vloženého písma "Calibri" na disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání vložených písem**

Pomocí výčtu [EmbedFontCharacters](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/embedfontcharacters/) a dvou přetížení metody [addEmbeddedFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) můžete vybrat preferované (vkládací) pravidlo pro vložení písem do prezentace. Tento Java kód ukazuje, jak vložit a přidat písma do prezentace:

```java
// Načte prezentaci
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Uloží prezentaci na disk
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Komprimace vložených písem**

Aby bylo možné komprimovat písma vložená v prezentaci a snížit její velikost souboru, Aspose.Slides poskytuje metodu [compressEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (vystavenou třídou [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/)).

Tento Java kód ukazuje, jak komprimovat vložená písma PowerPointu:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jak zjistím, že konkrétní písmo v prezentaci bude i přes vložení při vykreslování nahrazeno?**

Zkontrolujte [substitution information](/slides/cs/androidjava/font-substitution/) ve správci písem a [fallback/substitution rules](/slides/cs/androidjava/fallback-font/): pokud je písmo nedostupné nebo omezené, bude použito náhradní písmo.

**Stojí za to vkládat „systémová“ písma jako Arial/Calibri?**

Obvykle ne – jsou téměř vždy dostupná. Ale pro úplnou přenositelnost v „štíhlých“ prostředích (Docker, Linux server bez předinstalovaných písem) může vložení systémových písem eliminovat riziko neočekávaných náhrad.