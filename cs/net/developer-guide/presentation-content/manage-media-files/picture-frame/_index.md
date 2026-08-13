---
title: Správa rámů obrázků v prezentacích v .NET
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/net/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování rámu obrázku
- vlastnosti rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přidejte rámy obrázků do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Zjednodušte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Rám obrázku je tvar, který obsahuje obrázek – je to jako obrázek v rámci.  

Obrázek můžete do snímku přidat pomocí rámu obrázku. Tímto způsobem můžete obrázek formátovat úpravou rámu obrázku.

{{% alert  title="Tip" color="info" %}} 

Aspose poskytuje zdarma konvertory—[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt)—které umožňují rychle vytvářet prezentace z obrázků. 

{{% /alert %}} 

## **Vytvoření rámu obrázku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection), který je spojen s objektem prezentace a bude použit k vyplnění tvaru. 
4. Určete šířku a výšku obrázku. 
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe) na základě šířky a výšky obrázku pomocí metody `AddPictureFrame`, která je k dispozici u objektu tvaru spojeného s odkazovaným snímkem. 
6. Přidejte rám obrázku (obsahující obrázek) do snímku. 
7. Uložte upravenou prezentaci jako soubor PPTX. 

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{
    // Získá první snímek
    ISlide slide = pres.Slides[0];

    // Načte obrázek a přidá jej do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidá rám obrázku se stejnou výškou a šířkou
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplikuje určité formátování na rám obrázku
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Uloží prezentaci do souboru PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Rámy obrázků vám umožňují rychle vytvářet snímky prezentace na základě obrázků. Když zkombinujete rám obrázku s možnostmi ukládání Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu a převádět obrázky z jednoho formátu do druhého. Můžete se podívat na tyto stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Vytvoření rámu obrázku s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější rám obrázku. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte referenci na snímek podle jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace. 
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection), který je spojen s objektem prezentace a bude použit k vyplnění tvaru. 
5. Určete relativní šířku a výšku obrázku v rámci obrázkového rámu. 
6. Uložte upravenou prezentaci jako soubor PPTX. 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancuje třídu Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Načte obrázek a přidá jej do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá rám obrázku do snímku
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Nastaví relativní měřítko šířky a výšky
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Uloží prezentaci
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extrahování rastrových obrázků z rámů obrázků**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu "sample.pptx" a uložit jej ve formátu PNG. 

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extrahování SVG obrázků z rámů obrázků**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/), Aspose.Slides pro .NET vám umožní získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) obsahuje SVG obsah, a poté uložit tento obrázek na disk nebo do proudu v jeho nativním SVG formátu. 

Následující příklad kódu demonstruje, jak extrahovat SVG obrázek z rámu obrázku: 

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Získání průhlednosti obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento C# kód demonstruje operaci: 

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Získání jasu a kontrastu obrázku**

Aspose.Slides vám umožňuje získat efekt jasu a kontrastu aplikovaný na obrázek. Rozhraní [ILuminance](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iluminance/) představuje tento transformační efekt obrázku. 

Tento C# kód ukazuje, jak získat nastavení jasu a kontrastu z rámu obrázku: 

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Všechny efekty aplikované na obrázky lze najít v [Aspose.Slides.Effects](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/). 
{{% /alert %}}

## **Formátování rámu obrázku**

Aspose.Slides poskytuje mnoho možností formátování, které lze použít na rám obrázku. Pomocí těchto možností můžete upravit rám obrázku tak, aby vyhovoval konkrétním požadavkům. 

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/). 
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection), který je spojen s objektem prezentace a bude použit k vyplnění tvaru. 
4. Určete šířku a výšku obrázku. 
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [AddPictureFrame](http://www.aspose.com/api/net/slides/cs/aspose.slides/ishapecollection/methods/addpictureframe), která je k dispozici v objektu [IShapes](http://www.aspose.com/api/net/slides/cs/aspose.slides/ishapecollection) spojeném s odkazovaným snímkem. 
6. Přidejte rám obrázku (obsahující obrázek) do snímku. 
7. Nastavte barvu čáry rámu obrázku. 
8. Nastavte šířku čáry rámu obrázku. 
9. Otočte rám obrázku zadáním kladné nebo záporné hodnoty. 
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček. 
10. Přidejte rám obrázku (obsahující obrázek) do snímku. 
11. Uložte upravenou prezentaci jako soubor PPTX. 

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancuje třídu Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Získá první snímek
    ISlide slide = presentation.Slides[0];

    // Načte obrázek a přidá jej do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá rám obrázku se stejnou výškou a šířkou jako obrázek
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplikuje určité formátování na rám obrázku
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Uloží prezentaci do souboru PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
Aspose nedávno vyvinul [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud někdy potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky z fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete použít tuto službu. 
{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se zabránilo velké velikosti prezentace, můžete přidávat obrázky (nebo videa) pomocí odkazů místo vkládání souborů přímo do prezentací. Tento C# kód ukazuje, jak přidat obrázek a video do zástupného prvku: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ořezávání obrázků**

Tento C# kód ukazuje, jak oříznout existující obrázek ve snímku: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Vytvoří nový objekt obrázku
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá PictureFrame do snímku
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Ořízne obrázek (hodnoty v procentech)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Uloží výsledek
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Odstranění oříznutých oblastí obrázku**

Pokud chcete smazat oříznuté oblasti obrázku obsaženého v rámci, můžete použít metodu [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud ořezání není nutné. 

Tento C# kód demonstruje operaci: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získá PictureFrame z prvního snímku
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Odstraní oříznuté oblasti obrázku PictureFrame a vrátí oříznutý obrázek
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Uloží výsledek
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="POZNÁMKA" color="warning" %}} 

Metoda [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze v zpracovaném [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/), může toto nastavení snížit velikost prezentace. V opačném případě se zvýší počet obrázků v výsledné prezentaci.  

Tato metoda při operaci ořezávání převádí metafily WMF/EMF na rastrový PNG obraz. 
{{% /alert %}}

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/compressimage/). Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti. 

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Formát obrázku → Komprimovat obrázky → Rozlišení**. 

Následující C# příklady ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelně odstraněním oříznutých oblastí: 

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Zkomprimuje obrázek s cílovým rozlišením 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Zkontroluje výsledek komprese.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Nebo přímo použitím vlastního DPI hodnoty: 

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Zkomprimuje obrázek na 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="POZNÁMKA" color="warning" %}} 

Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.  
Pokud je obrázek metafilem (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG se zachová nebo mírně sníží v závislosti na rozlišení, podobně jako PowerPoint zachází s JPEGy vysokého rozlišení. 
{{% /alert %}}

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít vlastnost [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframelock/aspectratiolocked/), která nastaví volbu *Uzamknout poměr stran*. 

Tento C# kód ukazuje, jak uzamknout poměr stran tvaru: 

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Nastaví tvar tak, aby při změně velikosti zachoval poměr stran
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="POZNÁMKA" color="warning" %}} 

Toto nastavení *Uzamknout poměr stran* zachovává pouze poměr stran tvaru, nikoli obrázek, který obsahuje. 
{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí vlastností [StretchOffsetLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsetright) a [StretchOffsetBottom](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) z rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat) můžete zadat výplňový obdélník. 

Když je pro obrázek zadáno natažení, zdrojový obdélník je měřen tak, aby zapadal do určeného výplňového obdélníku. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento udává vnitřní odsazení, záporné procento vnější odsazení. 

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/). 
2. Získejte referenci na snímek podle jeho indexu. 
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek. 
5. Nastavte typ výplně tvaru. 
6. Nastavte režim výplně obrázkem tvaru. 
7. Přidejte obrázek pro vyplnění tvaru. 
8. Určete posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru. 
9. Uložte upravenou prezentaci jako soubor PPTX. 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Nastaví obrázek natáhnutý ze všech stran těla tvaru
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

### Jak zjistit, které formáty obrázků jsou podporovány pro PictureFrame?

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá schopnosti enginu pro snímky a konverzi obrázků. 

### Jak přidání desítek velkých obrázků ovlivní velikost a výkon PPTX?

Vkládání velkých obrázků zvyšuje velikost souboru a spotřebu paměti; propojení obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky jako odkazy pro snížení velikosti souboru. 

### Jak mohu zamknout objekt obrázku před náhodným přesunem/změnou velikosti?

Použijte [uzamčení tvarů](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/pictureframelock/) pro [PictureFrame] (například zakázat přesun nebo změnu velikosti). Mechanismus uzamčení je popsán pro tvary v samostatném [článku o ochraně](/slides/cs/net/applying-protection-to-presentation/) a je podporován pro různé typy tvarů, včetně [PictureFrame]. 

### Je zachována vektorová věrnost SVG při exportu prezentace do PDF/obrázků?

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame] jako původní vektor. Při [exportu do PDF](/slides/cs/net/convert-powerpoint-to-pdf/) nebo [rastrovaných formátů](/slides/cs/net/convert-powerpoint-to-png/) může být výsledek v závislosti na nastavení exportu rasterizován; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním při extrakci.