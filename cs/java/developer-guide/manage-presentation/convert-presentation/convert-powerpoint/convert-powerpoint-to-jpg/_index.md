---
title: Převod PPT a PPTX do JPG v Javě
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /cs/java/convert-powerpoint-to-jpg/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint do JPG
- prezentace do JPG
- snímek do JPG
- PPT do JPG
- PPTX do JPG
- uložit PowerPoint jako JPG
- uložit prezentaci jako JPG
- uložit snímek jako JPG
- uložit PPT jako JPG
- uložit PPTX jako JPG
- exportovat PPT do JPG
- exportovat PPTX do JPG
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v Javě pomocí Aspose.Slides pro Java s využitím rychlých a spolehlivých ukázek kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument do JPG obrázků pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu na webové stránky nebo aplikace. Aspose.Slides vám umožňuje transformovat soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody převodu.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit miniaturu pro každý snímek. To může být užitečné, pokud chcete chránit snímky před kopírováním nebo ukázat prezentaci v režimu jen pro čtení. Aspose.Slides vám umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod PowerPoint PPT/PPTX do JPG**

Zde jsou kroky pro převod PPT/PPTX do JPG:

1. Vytvořte instanci typu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide) z kolekce [Presentation.getSlides()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--).
3. Vytvořte miniaturu každého snímku a poté ji převeďte na JPG. Metoda [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide#getImage-float-float-) se používá k získání miniatury snímku a vrací objekt [Images](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Images). Metodu [getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) je třeba zavolat z požadovaného snímku typu [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide); měřítka výsledné miniatury se předávají metodě.
4. Po získání miniatury snímku zavolejte z objektu miniatury metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)). Předávejte jí název výsledného souboru a formát obrázku.

{{% alert color="primary" %}}
**Poznámka**: Převod PPT/PPTX do JPG se liší od převodu na jiné typy v API Aspose.Slides. Pro jiné typy obvykle používáte [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), ale zde potřebujete metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Vytvoří obrázek v plném měřítku
        IImage slideImage = sld.getImage(1f, 1f);

        // Uloží obrázek na disk ve formátu JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převod PowerPoint PPT/PPTX do JPG s vlastním rozměrem**

Chcete-li změnit rozměry výsledné miniatury a JPG obrázku, můžete nastavit hodnoty *ScaleX* a *ScaleY* předáním do metod [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definuje rozměry
    int desiredX = 1200;
    int desiredY = 800;
    // Získá škálované hodnoty X a Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Vytvoří obrázek v plném měřítku
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Uloží obrázek na disk ve formátu JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vykreslení komentářů při ukládání snímků jako obrázky**

Aspose.Slides pro Java poskytuje funkci, která umožňuje vykreslit komentáře ve snímcích prezentace při jejich převodu na obrázky. Tento Java kód ukazuje, jak to funguje:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose poskytuje [ZDARMA webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit obrázky [JPG do JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG do PNG, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně.  

Použijte stejné principy popsané v tomto článku k převodu obrázků z jednoho formátu do druhého. Další informace najdete na těchto stránkách: převod [obrázku do JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/); převod [JPG do obrázku](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/); převod [JPG do PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/), převod [PNG do JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/); převod [PNG do SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/), převod [SVG do PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/).
{{% /alert %}}

## **Často kladené otázky**

**Podporuje tato metoda hromadný převod?**

Ano, Aspose.Slides umožňuje hromadný převod více snímků do JPG v jedné operaci.

**Podporuje převod SmartArt, grafy a další komplexní objekty?**

Ano, Aspose.Slides vykresluje celý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslování se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících písem.

**Existují nějaká omezení počtu snímků, které lze zpracovat?**

Aspose.Slides sám neklade žádná přísná omezení na počet snímků, které můžete zpracovat. Nicméně při práci s velkými prezentacemi nebo vysokým rozlišením obrázků můžete narazit na chybu nedostatku paměti.

## **Viz také**

Podívejte se na další možnosti převodu PPT/PPTX do obrázku, například:

- [Převod PPT/PPTX na SVG](/slides/cs/java/render-a-slide-as-an-svg-image/).