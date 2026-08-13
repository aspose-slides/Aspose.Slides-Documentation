---
title: Převod PPT a PPTX na JPG v Javě
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/java/convert-powerpoint-to-jpg/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na JPG
- prezentace na JPG
- snímek na JPG
- PPT na JPG
- PPTX na JPG
- uložit PowerPoint jako JPG
- uložit prezentaci jako JPG
- uložit snímek jako JPG
- uložit PPT jako JPG
- uložit PPTX jako JPG
- exportovat PPT do JPG
- exportovat PPTX do JPG
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v Javě pomocí Aspose.Slides pro Java s rychlými a spolehlivými ukázkami kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument do obrázků JPG pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu na webové stránky nebo do aplikací. Aspose.Slides umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody převodu.

Díky těmto funkcím je snadné vytvořit vlastní prohlížeč prezentací a vytvořit náhledový obrázek pro každý snímek. To může být užitečné, pokud chcete chránit snímky prezentace před kopírováním nebo ukázat prezentaci v režimu jen pro čtení. Aspose.Slides umožňuje převést celou prezentaci nebo konkrétní snímek do formátů obrázků.

## **Převod PowerPoint PPT/PPTX na JPG**

Zde jsou kroky pro převod PPT/PPTX na JPG:

1. Vytvořte instanci typu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide) z kolekce [Presentation.getSlides()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--).
3. Vytvořte náhled každého snímku a poté jej převedete na JPG. Metoda [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide#getImage-float-float-) se používá k získání náhledu snímku, vrací objekt [Images](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Images). Metodu [getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) je třeba zavolat z požadovaného snímku typu [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide); měřítka výsledného náhledu se předávají do metody.
4. Po získání náhledu snímku zavolejte metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) z objektu náhledu. Předávejte jí název výsledného souboru a formát obrázku.

{{% alert color="info" %}}
**Poznámka**: Převod PPT/PPTX na JPG se liší od převodu na jiné typy v Aspose.Slides API. Pro jiné typy obvykle používáte metodu [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), ale zde potřebujete metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}}

```java
import com.aspose.slides.*;

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

## **Převod PowerPoint PPT/PPTX na JPG s vlastním rozměrem**

Chcete‑li změnit rozměr výsledného náhledu a JPG obrázku, můžete nastavit hodnoty *ScaleX* a *ScaleY* předáním do metod [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definuje rozměry
    int desiredX = 1200;
    int desiredY = 800;
    // Získá měřené hodnoty X a Y
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

## **Vykreslení komentářů při ukládání snímků jako obrázků**

Aspose.Slides pro Java poskytuje funkci, která umožňuje vykreslit komentáře ve snímcích prezentace při převodu těchto snímků na obrázky. Tento Java kód ukazuje operaci:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}
Aspose poskytuje [ZDARMA aplikaci Collage web](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit obrázky [JPG do JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG do PNG, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně.

Pomocí stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Pro více informací viz tyto stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Podporuje tato metoda dávkový převod?

Ano, Aspose.Slides umožňuje hromadný převod více snímků na JPG v jedné operaci.

### Podporuje převod SmartArt, grafy a další složité objekty?

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslení se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících písem.

### Existují nějaká omezení počtu snímků, které lze zpracovat?

Aspose.Slides sám neklade žádná přísná omezení na počet snímků, které můžete zpracovat. Nicméně při práci s velkými prezentacemi nebo obrázky vysokého rozlišení můžete narazit na chybu nedostatku paměti.

## **Další informace**

Podívejte se na další možnosti převodu PPT/PPTX na obrázek, například:

- [Převod PPT/PPTX na SVG](/slides/cs/java/render-a-slide-as-an-svg-image/).