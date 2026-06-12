---
title: Převod PPT a PPTX na JPG na Androidu
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/androidjava/convert-powerpoint-to-jpg/
keywords: 
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na JPG
- prezentaci na JPG
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
- Android
- Java
- Aspose.Slides
description: "Převést snímky PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v Javě s Aspose.Slides pro Android pomocí rychlých a spolehlivých příkladů kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument na obrázky JPG pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu do webových stránek nebo aplikací. Aspose.Slides pro Android přes Java vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní obrázky JPEG. Tento průvodce popisuje různé metody převodu.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit miniaturu pro každý snímek. To může být užitečné, pokud chcete chránit snímky před kopírováním nebo prezentovat prezentaci v režimu pouze pro čtení. Aspose.Slides umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod snímků prezentace na obrázky JPG**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) ze sbírky vrácené metodou [Presentation.getSlides()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlides--) .
1. Vytvořte obrázek snímku pomocí metody [ISlide.getImage(float, float)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-float-float-) .
1. Zavolejte metodu [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) na objektu obrázku. Jako argumenty předejte název výstupního souboru a formát obrázku.

{{% alert color="primary" %}} 
**Poznámka:** PPT, PPTX nebo ODP na JPG konverze se liší od konverze do jiných formátů v API Aspose.Slides pro Android přes Java. Pro jiné formáty obvykle používáte metodu [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Nicméně pro JPG konverzi musíte použít metodu [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) .
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Vytvořte obrázek snímku s určeným měřítkem.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Uložte obrázek na disk ve formátu JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků na JPG s vlastním rozměrem**

Chcete‑li změnit rozměry výsledných JPG obrázků, můžete nastavit velikost obrázku předáním argumentu do metody [ISlide.getImage(Size)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). To vám umožní generovat obrázky se specifickou šířkou a výškou, což zajišťuje, že výstup splní vaše požadavky na rozlišení a poměr stran. Tato flexibilita je zvláště užitečná při generování obrázků pro webové aplikace, zprávy nebo dokumentaci, kde jsou požadovány přesné rozměry obrázku.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Vytvořte obrázek snímku s určenou velikostí.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Uložte obrázek na disk ve formátu JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Vykreslení komentářů při ukládání snímků jako obrázků**

Aspose.Slides pro Android přes Java poskytuje funkci, která vám umožní při převodu snímků do JPG obrázků vykreslit komentáře na snímcích prezentace. Tato funkce je zvláště užitečná pro zachování poznámek, zpětné vazby nebo diskusí přidaných spolupracovníky v PowerPoint prezentacích. Povolením této možnosti zajistíte, že komentáře budou viditelné v generovaných obrázcích, což usnadňuje revizi a sdílení zpětné vazby, aniž byste museli otevírat původní soubor prezentace.

Řekněme, že máme soubor prezentace "sample.pptx" se snímkem, který obsahuje komentáře:

![Snímek s komentáři](slide_with_comments.png)

Následující kód v Javě převádí snímek na JPG obrázek při zachování komentářů:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Převést první snímek na obrázek.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

Výsledek:

![JPG obrázek s komentáři](image_with_comments.png)

## **Viz také**

Prohlédněte si další možnosti převodu PPT, PPTX nebo ODP na obrázky, například:

- [Převod PowerPointu na GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/)
- [Převod PowerPointu na PNG](/slides/cs/androidjava/convert-powerpoint-to-png/)
- [Převod PowerPointu na TIFF](/slides/cs/androidjava/convert-powerpoint-to-tiff/)
- [Převod PowerPointu na SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Abyste viděli, jak Aspose.Slides převádí PowerPoint prezentace na JPG obrázky, vyzkoušejte tyto bezplatné online konvertory: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/cs/conversion/pptx-to-jpg) a [PPT to JPG](https://products.aspose.app/slides/cs/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Bezplatný online konvertor PPTX na JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose nabízí [ZDARMA Collage webovou aplikaci](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit obrázky [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně. 

Pomocí stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Další informace najdete na těchto stránkách: převod [obrázku na JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/).
{{% /alert %}}

## **Často kladené otázky**

**Podporuje tato metoda hromadný převod?**

Ano, Aspose.Slides umožňuje hromadný převod více snímků na JPG v jedné operaci.

**Podporuje převod objekty SmartArt, grafy a další složité objekty?**

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslení se však může mírně lišit oproti PowerPointu, zejména při použití vlastních nebo chybějících fontů.

**Existují nějaká omezení počtu snímků, které lze zpracovat?**

Aspose.Slides sám neklade žádná striktní omezení na počet snímků, které můžete zpracovat. Nicméně při práci s velkými prezentacemi nebo obrázky vysokého rozlišení můžete narazit na chybu nedostatku paměti.