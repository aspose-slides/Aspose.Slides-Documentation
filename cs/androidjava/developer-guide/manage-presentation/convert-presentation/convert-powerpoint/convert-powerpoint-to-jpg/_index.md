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
- Android
- Java
- Aspose.Slides
description: "Převádějte snímky PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v jazyce Java s Aspose.Slides pro Android pomocí rychlých a spolehlivých ukázek kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument do JPG obrázků usnadňuje sdílení snímků, optimalizaci výkonu a vkládání obsahu do webových stránek nebo aplikací. Aspose.Slides pro Android prostřednictvím Java vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento návod vysvětluje různé metody převodu.

S těmito funkcemi můžete snadno vytvořit vlastní prohlížeč prezentací a vytvořit miniaturu pro každý snímek. To může být užitečné, pokud chcete chránit snímky před kopírováním nebo prezentovat prezentaci v režimu jen pro čtení. Aspose.Slides vám umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod snímků prezentace na JPG obrázky**

Zde jsou kroky pro převod souboru PPT, PPTX nebo ODP na JPG:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) ze sbírky vrácené metodou [Presentation.getSlides()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlides--) .
1. Vytvořte obrázek snímku pomocí metody [ISlide.getImage(float,float)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-float-float-) .
1. Zavolejte metodu [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) na objektu obrázku. Předávejte název výstupního souboru a formát obrázku jako argumenty.

{{% alert color="info" %}} 

**Poznámka:** Převod PPT, PPTX nebo ODP na JPG se liší od převodu do jiných formátů v API Aspose.Slides Android prostřednictvím Java. Pro jiné formáty obvykle používáte metodu [IPresentation.save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) . Pro převod do JPG však musíte použít metodu [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) .

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Vytvořte obrázek snímku v zadaném měřítku.
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

Chcete‑li změnit rozměry výsledných JPG obrázků, můžete nastavit velikost obrázku předáním parametru do metody [ISlide.getImage(Size)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) . To vám umožní generovat obrázky s konkrétními šířkou a výškou, aby výstup splňoval požadavky na rozlišení a poměr stran. Tato flexibilita je užitečná při tvorbě obrázků pro webové aplikace, zprávy nebo dokumentaci, kde jsou požadovány přesné rozměry obrázku.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Vytvořte obrázek snímku ve specifikované velikosti.
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

Aspose.Slides pro Android prostřednictvím Java poskytuje funkci, která umožňuje vykreslit komentáře na snímcích prezentace při jejich převodu do JPG obrázků. Tato funkce je užitečná pro zachování anotací, zpětné vazby nebo diskusí přidaných spolupracovníky v PowerPoint prezentacích. Aktivací této volby zajistíte, že komentáře budou viditelné v generovaných obrázcích, což usnadní revizi a sdílení zpětné vazby bez nutnosti otevírat původní soubor prezentace.

Předpokládejme, že máme soubor prezentace „sample.pptx“ se snímkem, který obsahuje komentáře:

![Snímek s komentáři](slide_with_comments.png)

Následující kód v jazyce Java převádí snímek na JPG obrázek při zachování komentářů:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Převeďte první snímek na obrázek.
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

Další možnosti převodu PPT, PPTX nebo ODP na obrázky:

- [Převod PowerPoint na GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/)
- [Převod PowerPoint na PNG](/slides/cs/androidjava/convert-powerpoint-to-png/)
- [Převod PowerPoint na TIFF](/slides/cs/androidjava/convert-powerpoint-to-tiff/)
- [Převod PowerPoint na SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Pro vyzkoušení, jak Aspose.Slides převádí PowerPoint prezentace na JPG obrázky, použijte tyto bezplatné online převodníky: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/cs/conversion/pptx-to-jpg) a [PPT to JPG](https://products.aspose.app/slides/cs/conversion/ppt-to-jpg) .

{{% /alert %}} 

![Bezplatný online převodník PPTX na JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose poskytuje [ZDARMA webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG s JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG s PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně. 

Pomocí stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Další informace naleznete na těchto stránkách: převod [obrázku na JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/) ; převod [JPG na obrázek](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/) ; převod [JPG na PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/) , převod [PNG na JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/) ; převod [PNG na SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/) , převod [SVG na PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/) .

{{% /alert %}}

## **Často kladené otázky**

### Podporuje tato metoda hromadný převod?

Ano, Aspose.Slides umožňuje hromadný převod více snímků na JPG v jedné operaci.

### Podporuje převod SmartArt, grafy a další složité objekty?

Ano, Aspose.Slides vykresluje celý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslení se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících písem.

### Existují omezení počtu snímků, které lze zpracovat?

Aspose.Slides sám neklade žádná striktní omezení na počet snímků, které můžete zpracovat. Nicméně můžete narazit na chybu nedostatku paměti při práci s velkými prezentacemi nebo vysoce rozlišenými obrázky.