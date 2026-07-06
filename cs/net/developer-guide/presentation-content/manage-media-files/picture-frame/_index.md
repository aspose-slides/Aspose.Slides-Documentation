---
title: Správa obrázkových rámečků v prezentacích v .NET
linktitle: Obrázkový rámeček
type: docs
weight: 10
url: /cs/net/picture-frame/
keywords:
- obrázkový rámeček
- přidat obrázkový rámeček
- vytvořit obrázkový rámeček
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování obrázkového rámečku
- vlastnosti obrázkového rámečku
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
description: "Přidejte obrázkové rámečky do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Zefektivněte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Obrázkový rámeček je tvar, který obsahuje obrázek – je to jako obrázek v rámečku.  

Můžete přidat obrázek na snímek pomocí obrázkového rámečku. Tímto způsobem můžete formátovat obrázek formátováním obrázkového rámečku.

{{% alert title="Tip" color="primary" %}} 
Aspose poskytuje bezplatné konvertory – [JPEG na PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG na PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) – které umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvoření obrázkového rámečku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection) přidružené k objektu prezentace, který bude použit k vyplnění tvaru.  
4. Zadejte šířku a výšku obrázku.  
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe) na základě šířky a výšky obrázku pomocí metody `AddPictureFrame`, kterou poskytuje objekt tvaru přidružený k referencovanému snímku.  
6. Přidejte obrázkový rámeček (obsahující obrázek) na snímek.  
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit obrázkový rámeček:

```c#
// Instancuje třídu Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{
    // Získá první snímek
    ISlide slide = pres.Slides[0];

    // Nahraje obrázek a přidá jej do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidá obrázkový rámeček se stejnou výškou a šířkou
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplikuje určité formátování na obrázkový rámeček
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Uloží prezentaci do souboru PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Obrázkové rámečky vám umožňují rychle vytvářet snímky prezentace na základě obrázků. Když kombinujete obrázkový rámeček s možnostmi ukládání v Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu a konvertovat obrázky z jednoho formátu do druhého. Můžete také navštívit tyto stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/); převod [PNG na JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/); převod [SVG na PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/). 
{{% /alert %}} 

## **Vytvoření obrázkového rámečku s relativní měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější obrázkový rámeček.  

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Přidejte obrázek do kolekce obrázků prezentace.  
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection) přidružené k objektu prezentace, který bude použit k vyplnění tvaru.  
5. Zadejte relativní šířku a výšku obrázku v obrázkovém rámečku.  
6. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit obrázkový rámeček s relativním měřítkem:

```c#
// Instancuje třídu Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Nahraje obrázek a přidá jej do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá obrázkový rámeček na snímek
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Nastaví relativní měřítko šířky a výšky
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Uloží prezentaci
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extrahování rastrových obrázků z obrázkových rámečků**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extrahování SVG obrázků z obrázkových rámečků**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/), Aspose.Slides pro .NET vám umožní získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/), zjistit, zda podkladový [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) obsahuje SVG, a poté tento obrázek uložit na disk nebo do proudu v jeho nativním SVG formátu.

Následující ukázka kódu demonstruje, jak extrahovat SVG obrázek z obrázkového rámečku:

```cs
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

Aspose.Slides umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento C# kód demonstruje operaci:

```c#
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

Aspose.Slides umožňuje získat efekt jasu a kontrastu aplikovaný na obrázek. Rozhraní [ILuminance](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iluminance/) představuje tento transformační efekt obrázku.

Tento C# kód ukazuje, jak získat nastavení jasu a kontrastu z obrázkového rámečku:

```csharp
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

{{% alert color="primary" %}} 
Všechny efekty aplikované na obrázky najdete v [Aspose.Slides.Effects](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/). 
{{% /alert %}} 

## **Formátování obrázkového rámečku**

Aspose.Slides poskytuje řadu možností formátování, které lze použít na obrázkový rámeček. Pomocí těchto možností můžete upravit obrázkový rámeček tak, aby vyhovoval konkrétním požadavkům.

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection) přidružené k objektu prezentace, který bude použit k vyplnění tvaru.  
4. Zadejte šířku a výšku obrázku.  
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [AddPictureFrame](http://www.aspose.com/api/net/slides/cs/aspose.slides/ishapecollection/methods/addpictureframe), která je k dispozici u objektu [IShapes](http://www.aspose.com/api/net/slides/cs/aspose.slides/ishapecollection) přidruženého k referencovanému snímku.  
6. Přidejte obrázkový rámeček (obsahující obrázek) na snímek.  
7. Nastavte barvu čáry obrázkového rámečku.  
8. Nastavte šířku čáry obrázkového rámečku.  
9. Otočte obrázkový rámeček zadáním kladné nebo záporné hodnoty.  
   * Kladná hodnota otáčí obrázek ve směru hodinových ručiček.  
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.  
10. Přidejte obrázkový rámeček (obsahující obrázek) na snímek.  
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód demonstruje proces formátování obrázkového rámečku:

```c#
// Instancuje třídu Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Získá první snímek
    ISlide slide = presentation.Slides[0];

    // Nahraje obrázek a přidá jej do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá obrázkový rámeček se stejnou výškou a šířkou jako obrázek
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplikuje určité formátování na obrázkový rámeček
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Uloží prezentaci do souboru PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
Aspose nedávno vyvinul [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete sloučit JPG/JPEG nebo PNG obrázky, vytvořit mřížky ze fotografií, můžete použít tuto službu. 
{{% /alert %}} 

## **Přidání obrázku jako odkazu**

Aby se zmenšila velikost prezentace, můžete přidávat obrázky (nebo videa) prostřednictvím odkazů místo vkládání souborů přímo do prezentace. Tento C# kód ukazuje, jak přidat obrázek a video do zástupce:

```c#
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

Tento C# kód ukazuje, jak oříznout existující obrázek na snímku:

```c#
using (Presentation presentation = new Presentation())
{
    // Vytvoří nový objekt obrázku
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá obrázkový rámeček do snímku
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Ořízne obrázek (procentuální hodnoty)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Uloží výsledek
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Odstranění oříznutých oblastí obrázku v rámečku**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud ořez není potřeba.

Tento C# kód demonstruje tuto operaci:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získá obrázkový rámeček z prvního snímku
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Odstraní oříznuté oblasti obrázku v obrázkovém rámečku a vrátí oříznutý obrázek
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Uloží výsledek
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit jen v zpracovávaném [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/), může toto nastavení snížit velikost prezentace. V opačném případě se počet obrázků v výsledné prezentaci zvýší.  

Metoda při ořezávání konvertuje WMF/EMF metafily na rastrový PNG obrázek. 
{{% /alert %}} 

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/compressimage/).  
Tato metoda komprimuje obrázek snížením jeho velikosti podle velikosti tvaru a zadaného rozlišení s volbou odstranění oříznutých oblastí.  

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Formát obrázku → Komprimovat obrázky → Rozlišení**.

Následující C# příklady ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelným odstraněním oříznutých oblastí:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimuje obrázek s cílovým rozlišením 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
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

Nebo použitím vlastní hodnoty DPI přímo:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimuje obrázek na 150 DPI (webové rozlišení), odstraňuje oříznuté oblasti.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda konvertuje obrázek na nižší rozlišení podle velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.  
Pokud je obrázek metafilem (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG je zachována nebo mírně snížena v závislosti na rozlišení, podobně jako PowerPoint zachází s JPEG ve vysokém rozlišení. 
{{% /alert %}} 

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít vlastnost [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframelock/aspectratiolocked/) k nastavení volby *Uzamknout poměr stran*.  

Tento C# kód ukazuje, jak uzamknout poměr stran tvaru:

```c#
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

{{% alert title="NOTE" color="warning" %}} 
Toto nastavení *Uzamknout poměr stran* zachovává pouze poměr stran tvaru, nikoli obrázku, který obsahuje. 
{{% /alert %}} 

## **Použití vlastnosti StretchOff**

Pomocí vlastností [StretchOffsetLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsetright) a [StretchOffsetBottom](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) z rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat) můžete určit výplňový obdélník.  

Když je pro obrázek definováno roztažení, zdrojový obdélník se škáluje tak, aby zapadl do určeného výplňového obdélníku. Každá hrana výplňového obdélníku je definována procentuálním posunem od odpovídající hrany ohraničujícího rámečku tvaru. Kladné procento udává vnitřní odsazení, záporné procento pak vnější posun.  

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Přidejte obdélník `AutoShape`.  
4. Vytvořte obrázek.  
5. Nastavte typ výplně tvaru.  
6. Nastavte režim výplně obrázkem tvaru.  
7. Přidejte nastavený obrázek pro výplň tvaru.  
8. Zadejte posuny obrázku od odpovídající hrany ohraničujícího rámečku tvaru.  
9. Uložte upravenou prezentaci jako soubor PPTX.  

Tento C# kód demonstruje proces, ve kterém je použita vlastnost StretchOff:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Nastaví obrázek roztažený ze všech stran v těle tvaru
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Jak zjistím, které formáty obrázků jsou podporovány pro PictureFrame?**  
Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (např. SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá schopnosti enginu pro snímky a konverzi obrázků.

**Jaký vliv bude mít přidání desítek velkých obrázků na velikost a výkon PPTX?**  
Vkládání velkých obrázků zvyšuje velikost souboru i spotřebu paměti; propojování obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky pomocí odkazu ke snížení velikosti souboru.

**Jak mohu uzamknout objekt obrázku před neúmyslným přesunutím/změnou velikosti?**  
Použijte [zámky tvarů](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/pictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/) (např. zakázat přesouvání nebo změnu velikosti). Mechanismus zamykání je popsán pro tvary v samostatném [článku o ochraně](/slides/cs/net/applying-protection-to-presentation/) a je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/).

**Zachovává se vektorová věrnost SVG při exportu prezentace do PDF/obrázků?**  
Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/net/convert-powerpoint-to-pdf/) nebo [rastrových formátů](/slides/cs/net/convert-powerpoint-to-png/) může být výsledek rasterizován podle nastavení exportu; fakt, že originální SVG je uložen jako vektor, je potvrzeno chováním při extrakci.