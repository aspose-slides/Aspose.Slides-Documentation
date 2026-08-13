---
title: Képkeretek kezelése prezentációkban .NET-ben
linktitle: Képkeret
type: docs
weight: 10
url: /hu/net/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszteres kép
- vektorkép
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- képeffekt
- méretarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for .NET segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely egy képet tartalmaz—úgy, mint egy kép egy keretben. 

Képet egy diahoz adhatunk egy képkereten keresztül. Így a képet a képkeret formázásával formázhatjuk.

{{% alert  title="Tipp" color="info" %}} 

Az Aspose ingyenes konvertereket kínál—[JPEG PowerPointba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPointba](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan prezentációkat hozzunk létre képekből. 

{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Prezentáció ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból. 
2. Szerezze meg egy dia hivatkozását az indexén keresztül. 
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy egy képet ad a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak. 
4. Adja meg a kép szélességét és magasságát. 
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe) objektumot a kép szélessége és magassága alapján a hivatkozott diához tartozó alakzat objektum által biztosított `AddPictureFrame` metódussal. 
6. Adjon hozzá egy képkeretet (a képet tartalmazva) a diára. 
7. Írja a módosított prezentációt PPTX fájlként. 

Ez a C# kód megmutatja, hogyan kell képkeretet létrehozni:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{
    // Lekéri az első diát
    ISlide slide = pres.Slides[0];

    // Betölti a képet, és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet ugyanazzal a magassággal és szélességgel
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Alkalmaz néhány formázást a képkeretre
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Elmenti a prezentációt PPTX fájlként
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Az képkeretek lehetővé teszik, hogy gyorsan létrehozzunk prezentációs diákat képek alapján. Ha a képkeretet az Aspose.Slides mentési beállításaival kombinálja, manipulálhatja a bemenet/kimenet műveleteket a képek egyik formátumból a másikba konvertálásához. Érdemes megtekinteni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/net/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/net/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/net/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/net/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/net/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

Az kép relatív méretezésének módosításával egy összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból. 
2. Szerezze meg egy dia hivatkozását az indexén keresztül. 
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez. 
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy egy képet ad a [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak. 
5. Adja meg a kép relatív szélességét és magasságát a képkeretben. 
6. Írja a módosított prezentációt PPTX fájlként. 

Ez a C# kód megmutatja, hogyan kell képkeretet létrehozni relatív méretezéssel:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Betölti a képet, és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet a diára
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Beállítja a relatív méretezés szélességét és magasságát
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Elmenti a prezentációt
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Raszteres képek kinyerése képkeretekből**

Raszteres képeket nyerhet ki [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe) objektumokból, és elmentheti PNG, JPG vagy más formátumokban. Az alábbi kódrészlet bemutatja, hogyan kell egy képet kinyerni a „sample.pptx” dokumentumból és PNG formátumban menteni.

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

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, melyek [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) alakzatokban helyezkednek el, az Aspose.Slides for .NET lehetővé teszi az eredeti vektoros képek teljes hitelességével történő visszakeresését. A dia alakzatgyűjteményének bejárásával azonosítható minden [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/), ellenőrizhető, hogy a hozzá tartozó [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) SVG tartalmat tartalmaz‑e, majd a képet lemezre vagy adatfolyamra menthetjük a natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan kell egy SVG képet kinyerni egy képkeretből:

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

## **Kép átlátszóságának lekérése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott átlátszósági hatás lekérését. A következő C# kód demonstrálja a műveletet:

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

## **Kép fényerő és kontraszt lekérése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott fényerő‑kontraszt hatás lekérését. Az [ILuminance](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iluminance/) interfész képzi ezt a képtranszformációs hatást.

Ez a C# kód bemutatja, hogyan kell a fényerő‑ és kontraszt‑beállításokat lekérni egy képkeretből:

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
Minden képekre alkalmazott effektus megtalálható a [Aspose.Slides.Effects](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/) névtérben. 
{{% /alert %}}

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket képkeretre alkalmazhat. Ezekkel a beállításokkal a képkeretet úgy alakíthatja, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Prezentáció](http://www.aspose.com/api/net/slides/hu/aspose.slides/)osztályból. 
2. Szerezze meg egy dia hivatkozását az indexén keresztül. 
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy egy képet ad a [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak. 
4. Adja meg a kép szélességét és magasságát. 
5. Hozzon létre egy `PictureFrame`-et a kép szélessége és magassága alapján a [AddPictureFrame](http://www.aspose.com/api/net/slides/hu/aspose.slides/ishapecollection/methods/addpictureframe) metódus segítségével, amelyet a hivatkozott diához tartozó [IShapes](http://www.aspose.com/api/net/slides/hu/aspose.slides/ishapecollection) objektum biztosít. 
6. Adjon hozzá a képkeretet (a képet tartalmazva) a diához. 
7. Állítsa be a képkeret vonalszínét. 
8. Állítsa be a képkeret vonalvastagságát. 
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával. 
   * A pozitív érték a képet az óramutató járásával megegyező irányban forgatja. 
   * A negatív érték a képet az óramutató járásával ellentétes irányban forgatja. 
10. Adjon hozzá a képkeretet (a képet tartalmazva) a diához. 
11. Írja a módosított prezentációt PPTX fájlként. 

Ez a C# kód bemutatja a képkeret formázási folyamatát:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Lekéri az első diát
    ISlide slide = presentation.Slides[0];

    // Betölti a képet, és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet a kép egyenlő magasságával és szélességével
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Alkalmaz néhány formázást a képkeretre
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Elmenti a prezentációt PPTX fájlként
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Az Aspose nemrég egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) eszközt fejlesztett ki. Ha JPG/JPEG vagy PNG képeket szeretne összevonni, illetve fotókból rácsot készíteni, használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása linkként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) hozzáadhat linkeken keresztül ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációkba. Ez a C# kód megmutatja, hogyan adjon képet és videót egy helyőrzőhöz:

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

## **Képek vágása**

Ez a C# kód megmutatja, hogyan kell egy meglévő képet vágni egy dián:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Létrehoz egy új kép objektumot
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Képkeretet ad hozzá egy diához
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Levágja a képet (százalékos értékek)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Elmenti az eredményt
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Vágott területek törlése a képkeretben**

Ha a keretben lévő kép vágott területeit szeretné eltávolítani, használja az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust. Ez a metódus a vágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a C# kód demonstrálja a műveletet:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a PictureFrame-et az első diáról
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Törli a PictureFrame kép vágott területeit és visszaadja a vágott képet
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

Az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódus a vágott képet a prezentáció képgyűjteményéhez adja. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) használja, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végleges prezentációban lévő képek száma megnő.

Ez a metódus a WMF/EMF metafájlokat raszteres PNG képpé konvertálja a vágási művelet során. 

{{% /alert %}}

## **Képek tömörítése**

A [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/compressimage/) metódus segítségével tömöríthet egy képet a prezentációban. 
Ez a metódus a kép méretét a alakzat mérete és a megadott felbontás alapján csökkenti, a vágott területek törlésének lehetőségével. 

A kép méretét és felbontását úgy állítja be, mint a PowerPoint **Kép formátum → Képek tömörítése → Felbontás** funkciója.

Az alábbi C# példák bemutatják, hogyan lehet egy képet tömöríteni a prezentációban célfelbontás megadásával, és opcionálisan a vágott területek eltávolításával:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Tömöríti a képet 150 DPI (web felbontás) célfelbontással, és eltávolítja a vágott területeket.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Ellenőrzi a tömörítés eredményét.
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

Vagy egyedi DPI érték közvetlen használatával:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Tömöríti a képet 150 DPI-re (web felbontás), eltávolítva a vágott területeket.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

A metódus a képet a alakzat mérete és a megadott DPI alapján alacsonyabb felbontásra konvertálja. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minőség megmarad, vagy a felbontás függvényében kissé csökken, ahogyan azt a PowerPoint kezeli a magas felbontású JPEG‑eknél. 

{{% /alert %}}

## **Méreparány zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa a méretarányát a kép méretének módosítása után is, használhatja az [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframelock/aspectratiolocked/) tulajdonságot a *Méreparány zárolása* beállításának megadásához. 

Ez a C# kód megmutatja, hogyan kell zárolni egy alakzat méretarányát:

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

    // Beállítja, hogy az alakzat megőrizze a méretarányt átméretezéskor
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

Ez a *Méreparány zárolása* beállítás csak az alakzat méretarányát őrzi meg, nem a benne lévő képet. 

{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetright) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) tulajdonságok használatával az [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat) osztályból megadhat egy kitöltő téglalapot. 

Ha egy képre nyújtás van megadva, egy forrástéglalap skálázódik, hogy illeszkedjen a megadott kitöltő téglalaphoz. A kitöltő téglalap minden élét egy százalékos eltolás határozza meg az alakzat keretének megfelelő élétől. A pozitív százalék egy belülre tolt területet, a negatív százalék egy kifelé tolt területet jelent.

1. Hozzon létre egy példányt a [Prezentáció](http://www.aspose.com/api/net/slides/hu/aspose.slides/)osztályból. 
2. Szerezze meg egy dia hivatkozását az indexén keresztül. 
3. Adjon hozzá egy `AutoShape` téglalapot. 
4. Hozzon létre egy képet. 
5. Állítsa be az alakzat kitöltési típusát. 
6. Állítsa be az alakzat képkitöltési módját. 
7. Adjon hozzá egy képet, amely kitölti az alakzatot. 
8. Adja meg a kép eltolásait az alakzat keretének megfelelő élétől. 
9. Írja a módosított prezentációt PPTX fájlként. 

Ez a C# kód bemutatja, hogyan használható a StretchOff tulajdonság:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Beállítja a képet, hogy a forma testében minden oldalról nyújtott legyen
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

### Hogyan tudom megtudni, mely képtípusok támogatottak a PictureFrame esetén?

Az Aspose.Slides támogatja mind a raszteres képeket (PNG, JPEG, BMP, GIF stb.), mind a vektoros képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) objektumhoz rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia és a képkonvertáló motor képességeivel.

### Hogyan befolyásolja a tucatnyi nagy képpont hozzáadása a PPTX méretét és teljesítményét?

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek linkként való hozzáadása segít csökkenteni a prezentáció méretét, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek linkként való hozzáadását a fájlméret csökkentése érdekében.

### Hogyan tudom zárolni egy képobjektust a véletlen mozgatás/átméretezés ellen?

Használja a [alakzatzárolásokat](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/pictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásához). A zárolási mechanizmust külön [védelem cikkben](/slides/hu/net/applying-protection-to-presentation/) ismertetik, és számos alakzattípusra, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) objektumokra is vonatkozik.

### Megtartja-e a SVG vektor hűségét a prezentáció PDF/ képek formátumba exportálásakor?

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) objektumból eredeti vektorként. PDF‑re vagy [raszteres formátumokra](/slides/hu/net/convert-powerpoint-to-png/) exportáláskor a beállításoktól függően a kimenet rasterizálódhat; a fakt, hogy az eredeti SVG vektoros formátumban marad, a kinyerési viselkedés megmutatja.