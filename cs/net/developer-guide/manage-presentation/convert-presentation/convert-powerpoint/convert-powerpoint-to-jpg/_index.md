---
title: Převod PPT a PPTX na JPG v .NET
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/net/convert-powerpoint-to-jpg/
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
- .NET
- C#
- Aspose.Slides
description: "Převést snímky PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v C# pomocí Aspose.Slides pro .NET s rychlými, spolehlivými ukázkami kódu."
---
## **Úvod**

Konverze prezentací PowerPoint a OpenDocument do JPG obrázků pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu na webové stránky nebo do aplikací. Aspose.Slides pro .NET vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody konverze.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit náhled pro každý snímek. To může být užitečné, pokud chcete chránit snímky před kopírováním nebo předvést prezentaci v režimu jen pro čtení. Aspose.Slides vám umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod snímků prezentace na JPG obrázky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide) z kolekce [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/slides).
1. Vytvořte obrázek snímku pomocí metody [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/#getimage_5).
1. Zavolejte metodu [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/#save_3) na objektu obrázku. Jako argumenty předávejte název výstupního souboru a formát obrázku.

{{% alert color="info" %}} 
**Note:** Konverze PPT, PPTX nebo ODP na JPG se liší od konverze do jiných formátů v API Aspose.Slides .NET. Pro jiné formáty obvykle používáte metodu [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/#save_5). Pro konverzi na JPG však musíte použít metodu [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Vytvořte obrázek snímku v určeném měřítku.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Uložte obrázek na disk ve formátu JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Převod snímků na JPG s vlastními rozměry**

Chcete-li změnit rozměry výsledných JPG obrázků, můžete nastavit velikost obrázku předáním parametru do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/#getimage_6). To vám umožní generovat obrázky s konkrétními hodnotami šířky a výšky, čímž zajistíte, že výstup splní vaše požadavky na rozlišení a poměr stran. Tato flexibilita je zvláště užitečná při vytváření obrázků pro webové aplikace, zprávy nebo dokumentaci, kde jsou vyžadovány přesné rozměry obrázků.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Vytvořte obrázek snímku v určené velikosti.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Uložte obrázek na disk ve formátu JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Vykreslení komentářů při ukládání snímků jako obrázků**

Aspose.Slides pro .NET poskytuje funkci, která umožňuje vykreslit komentáře na snímcích prezentace při jejich konverzi do JPG obrázků. Tato funkčnost je zvláště užitečná pro zachování anotací, zpětné vazby nebo diskusí přidaných spolupracovníky v PowerPoint prezentacích. Povolením této možnosti zajistíte, že komentáře budou viditelné v generovaných obrázcích, což usnadní revizi a sdílení zpětné vazby bez nutnosti otevírat původní soubor prezentace.

Řekněme, že máme soubor prezentace „sample.pptx“ se snímkem, který obsahuje komentáře:

![Snímek s komentáři](slide_with_comments.png)

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Nastavte možnosti pro komentáře ke snímku.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Převést první snímek na obrázek.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Výsledek:

![JPG obrázek s komentáři](image_with_comments.png)

## **Viz také**

- [Převod PowerPointu na GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/)
- [Převod PowerPointu na PNG](/slides/cs/net/convert-powerpoint-to-png/)
- [Převod PowerPointu na TIFF](/slides/cs/net/convert-powerpoint-to-tiff/)
- [Převod PowerPointu na SVG](/slides/cs/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Chcete-li vidět, jak Aspose.Slides převádí PowerPoint na JPG obrázky, vyzkoušejte tyto bezplatné online převaděče: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/cs/conversion/pptx-to-jpg) a [PPT to JPG](https://products.aspose.app/slides/cs/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Bezplatný online převaděč PPTX na JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
Aspose nabízí [ZDARMA Collage webovou aplikaci](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete spojovat [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvářet [fotogalerie](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně.

Pomocí stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Další informace najdete na těchto stránkách: převod [obrázku na JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/).
{{% /alert %}}

## **Často kladené otázky**

### Podporuje tato metoda dávkovou konverzi?

Ano, Aspose.Slides umožňuje dávkovou konverzi více snímků do JPG v jediném operaci.

### Podporuje konverze SmartArt, grafy a další složité objekty?

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalšího. Přesnost vykreslení se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících fontů.

### Existují nějaká omezení počtu snímků, které lze zpracovat?

Aspose.Slides sám neukládá žádná přísná omezení počtu snímků, které můžete zpracovat. Může se však objevit chyba nedostatku paměti při práci s velkými prezentacemi nebo obrázky vysokého rozlišení.