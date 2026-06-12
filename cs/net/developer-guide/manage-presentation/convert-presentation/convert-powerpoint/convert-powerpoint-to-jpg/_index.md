---
title: Převod PPT a PPTX na JPG v .NET
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/net/convert-powerpoint-to-jpg/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
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
description: "Převod snímků PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v C# pomocí Aspose.Slides pro .NET s rychlými a spolehlivými ukázkami kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument na obrázky JPG pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu do webových stránek nebo aplikací. Aspose.Slides pro .NET vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody převodu.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit náhled pro každý snímek. To může být užitečné, pokud chcete chránit snímky prezentace před kopírováním nebo ukázat prezentaci v režimu jen ke čtení. Aspose.Slides umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod snímků prezentace na obrázky JPG**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide) z kolekce [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/slides) .
3. Vytvořte obrázek snímku pomocí metody [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/#getimage_5) .
4. Zavolejte metodu [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/#save_3) na objektu obrázku. Jako argumenty předávejte název výstupního souboru a formát obrázku.

{{% alert color="primary" %}} 
**Poznámka:** Převod PPT, PPTX nebo ODP na JPG se liší od převodu do jiných formátů v Aspose.Slides .NET API. Pro jiné formáty typicky používáte metodu [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/#save_5). Nicméně pro převod na JPG musíte použít metodu [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
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

## **Převod snímků na JPG s přizpůsobenými rozměry**

Aby bylo možné změnit rozměry výsledných JPG obrázků, můžete nastavit velikost obrázku předáním parametru do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/#getimage_6). To vám umožní generovat obrázky s konkrétními hodnotami šířky a výšky, což zajišťuje, že výstup splňuje vaše požadavky na rozlišení a poměr stran. Tato flexibilita je zvláště užitečná při vytváření obrázků pro webové aplikace, zprávy nebo dokumentaci, kde jsou vyžadovány přesné rozměry obrázku.

```c#
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

## **Vykreslení komentářů při ukládání snímků jako obrázky**

Aspose.Slides pro .NET poskytuje funkci, která umožňuje vykreslit komentáře na snímcích prezentace při jejich převodu na JPG obrázky. Tato funkčnost je zvláště užitečná pro zachování anotací, zpětné vazby nebo diskusí přidaných spolupracovníky v PowerPoint prezentacích. Povolením této možnosti zajistíte, že komentáře budou viditelné v generovaných obrázcích, což usnadní revizi a sdílení zpětné vazby, aniž byste museli otevřít původní soubor prezentace.

Předpokládejme, že máme soubor prezentace „sample.pptx“ s snímkem, který obsahuje komentáře:

![Snímek s komentáři](slide_with_comments.png)

Následující C# kód převádí snímek na JPG obrázek a zachovává komentáře:

```c#
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

## **Další informace**

Podívejte se na další možnosti převodu PPT, PPTX nebo ODP na obrázky, například:

- [Převod PowerPoint na GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/)
- [Převod PowerPoint na PNG](/slides/cs/net/convert-powerpoint-to-png/)
- [Převod PowerPoint na TIFF](/slides/cs/net/convert-powerpoint-to-tiff/)
- [Převod PowerPoint na SVG](/slides/cs/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Chcete-li vidět, jak Aspose.Slides převádí PowerPoint na JPG obrázky, vyzkoušejte tyto bezplatné online převodníky: PowerPoint [PPTX na JPG](https://products.aspose.app/slides/cs/conversion/pptx-to-jpg) a [PPT na JPG](https://products.aspose.app/slides/cs/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Bezplatný online převodník PPTX na JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose poskytuje [ZDARMA kolážovou webovou aplikaci](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně.

Použitím stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Pro více informací navštivte tyto stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/).
{{% /alert %}}

## **Často kladené otázky**

**Podporuje tato metoda hromadný převod?**

Ano, Aspose.Slides umožňuje hromadný převod více snímků na JPG v jedné operaci.

**Podporuje převod SmartArt, grafy a další složité objekty?**

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalšího. Přesnost vykreslení se však může mírně lišit oproti PowerPointu, zejména při použití vlastních nebo chybějících písem.

**Existují omezení počtu snímků, které lze zpracovat?**

Aspose.Slides samo o sobě neklade žádná přísná omezení na počet snímků, které můžete zpracovat. Nicméně můžete narazit na chybu nedostatku paměti při práci s velkými prezentacemi nebo obrázky s vysokým rozlišením.