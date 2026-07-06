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
- vektoros kép
- kép vágása
- kivágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- képhatás
- képarány
- kép átlátszósága
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Adj hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for .NET segítségével. Egyszerűsítsd a munkafolyamatot és javítsd a diák tervezését."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely képet tartalmaz — olyan, mint egy kép keretben.  

Képet egy diára a képkereten keresztül adhatunk hozzá. Így a kép formázása a képkeret formázásával történik.

{{% alert title="Tipp" color="primary" %}} 
Az Aspose ingyenes konvertereket kínál — [JPEG‑t PowerPoint‑ba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG‑t PowerPoint‑ba](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyek lehetővé teszik a felhasználók számára, hogy gyorsan prezentációkat hozzanak létre képekből. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Prezentáció ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy képet ad hozzá a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe) objektumot a kép szélessége és magassága alapján a `AddPictureFrame` módszerrel, amely a hivatkozott diához kapcsolódó alakzatobjektumon keresztül érhető el.  
6. Adjon hozzá egy képkeretet (a képet tartalmazó) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

```c#
// Példányosítja a Presentation osztályt, amely PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{
    // Lekéri az első diát
    ISlide slide = pres.Slides[0];

    // Betölt egy képet, és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet ugyanazzal a magassággal és szélességgel
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Alkalmaz némi formázást a képkeretre
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Elmenti a prezentációt egy PPTX fájlba
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
A képkeretek gyorsan létrehozhatnak olyan prezentációs diákat, amelyek képek alapján készülnek. Ha a képkeretet az Aspose.Slides mentési beállításaival kombinálja, a bemeneti/kimeneti műveleteket felhasználva könnyen konvertálhat képeket egyik formátumból a másikba. Érdemes megnézni ezeket az oldalakat: konvertálás [kép JPG‑re](https://products.aspose.com/slides/hu/net/conversion/image-to-jpg/); konvertálás [JPG‑t képre](https://products.aspose.com/slides/hu/net/conversion/jpg-to-image/); konvertálás [JPG‑t PNG‑re](https://products.aspose.com/slides/hu/net/conversion/jpg-to-png/), konvertálás [PNG‑t JPG‑re](https://products.aspose.com/slides/hu/net/conversion/png-to-jpg/); konvertálás [PNG‑t SVG‑re](https://products.aspose.com/slides/hu/net/conversion/png-to-svg/), konvertálás [SVG‑t PNG‑re](https://products.aspose.com/slides/hu/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy képet ad hozzá a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

```c#
// Példányosítja a Presentation osztályt, amely PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Betölt egy képet, és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet a diához
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Beállítja a relatív méretezés szélességét és magasságát
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Elmenti a prezentációt
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Raszteres képek kinyerése képkeretekből**

Képet kinyerhet a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe) objektumokból, és elmentheti PNG, JPG vagy más formátumban. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a „sample.pptx” dokumentumból, és mentheti PNG formátumban.  

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

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyeket [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) alakzatokba ágyaztak, az Aspose.Slides for .NET lehetővé teszi az eredeti vektoros képek teljes hűségű visszanyerését. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) objektumokat, ellenőrizheti, hogy a mögöttes [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) SVG tartalmat hordoz‑e, majd elmentheti az eredeti SVG formátumban lemezre vagy streambe.  

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

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott átlátszósági effektus lekérdezését. Ez a C# kód mutatja a műveletet:  

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

## **Kép fényerőnek és kontrasztnak a lekérdezése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott fényerő‑ és kontraszt‑effektus lekérdezését. Az [ILuminance](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iluminance/) interfész képviseli ezt a képtranszformációs hatást.  

Ez a C# kód bemutatja, hogyan kérdezhetők le a fényerő‑ és kontraszt‑beállítások egy képkeretből:  

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
Az összes képre alkalmazott effektus megtalálható a [Aspose.Slides.Effects](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/) névtérben.  
{{% /alert %}}

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget biztosít, amelyeket egy képkeretre alkalmazhat. Ezekkel a beállításokkal a képkeretet a kívánt követelményekhez igazíthatja.  

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/)osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy képet ad hozzá a [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amelyet a prezentáció objektum használ a forma kitöltéséhez.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame`‑et a kép szélessége és magassága alapján a [AddPictureFrame](http://www.aspose.com/api/net/slides/hu/aspose.slides/ishapecollection/methods/addpictureframe) módszerrel, amely a [IShapes](http://www.aspose.com/api/net/slides/hu/aspose.slides/ishapecollection) objektumon keresztül érhető el a hivatkozott dián.  
6. Adja hozzá a képkeretet (a képet tartalmazó) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az alakzatot az óramutató járásával megegyező irányba forgat.  
   * A negatív érték az óramutató járásával ellentétes irányba forgat.  
10. Adja hozzá a képkeretet (a képet tartalmazó) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

```c#
// Példányosítja a Presentation osztályt, amely PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Lekéri az első diát
    ISlide slide = presentation.Slides[0];

    // Betölt egy képet, és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet a kép ekvivalens magasságával és szélességével
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Alkalmaz némi formázást a képkeretre
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Elmenti a prezentációt PPTX fájlba
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha JPG/JPEG vagy PNG képeket szeretne egyesíteni, vagy rácsot készíteni fényképekből, ezt a szolgáltatást használhatja. 
{{% /alert %}}

## **Kép hozzáadása linkként**

A nagy prezentációs méretek elkerülése érdekében a képeket (vagy videókat) linkeken keresztül adhatja hozzá a beágyazás helyett. Ez a C# kód bemutatja, hogyan adhat képet és videót egy helyőrzőhöz:  

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

## **Képek vágása**

Ez a C# kód bemutatja, hogyan vághat le egy meglévő képet egy dián:  

```c#
using (Presentation presentation = new Presentation())
{
    // Létrehozza az új kép objektumot
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy PictureFrame-et egy diához
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

## **Kivágott területek törlése képből**

Ha a keretben lévő kép kivágott részeit szeretné törölni, használja az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust. A metódus visszaadja a kivágott képet, vagy az eredeti képet, ha a vágás nem szükséges.  

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a PictureFrame-et az első diáról
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Törli a PictureFrame kép kivágott területeit és visszaadja a kivágott képet
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
Az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódus hozzáadja a kivágott képet a prezentáció képgyűjteményéhez. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) használja, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a keletkező prezentációban a képek száma növekedni fog.  

Ez a metódus a vágási művelet során a WMF/EMF metafájlokat raszteres PNG képpé konvertálja. 
{{% /alert %}}

## **Képek tömörítése**

Képet tömöríthet egy prezentációban az [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/compressimage/) metódussal.  
Ez a metódus a kép méretét csökkenti a forma mérete és a megadott felbontás alapján, lehetővé téve a kivágott területek törlését is.  

A módszer úgy módosítja a kép méretét és felbontását, mint a PowerPoint **Képformátum → Képek tömörítése → Felbontás** funkciója.  

Az alábbi C# példák bemutatják, hogyan tömöríthet egy képet a prezentációban egy célfelbontás megadásával, és opcionálisan a kivágott területek eltávolításával:  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Tömöríti a képet 150 DPI (web felbontás) célfelbontással, és eltávolítja a kivágott területeket.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
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

Vagy egy egyéni DPI‑érték közvetlen használatával:  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Tömöríti a képet 150 DPI (web felbontás) méretre, eltávolítva a kivágott területeket.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
A metódus a képet alacsonyabb felbontásra konvertálja a forma mérete és a megadott DPI alapján. A kivágott területek törlése is optimalizálja a fájlméretet.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. A JPEG minősége a felbontás függvényében marad vagy enyhén csökken, hasonlóan a PowerPoint viselkedéséhez. 
{{% /alert %}}

## **Oldalarány zárolása**

Ha egy képet tartalmazó alakzatnak meg szeretné tartani az oldalarányát akkor is, ha a kép mérete változik, használhatja az [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframelock/aspectratiolocked/) tulajdonságot az *Oldalarány zárolása* beállításhoz.  

Ez a C# kód megmutatja, hogyan zárolhatja egy alakzat oldalarányát:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Beállítja a formát, hogy az átméretezéskor megtartsa az oldalarányt
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
Ez az *Oldalarány zárolása* beállítás csak az alakzat oldalarányát őrzi meg, nem a benne lévő képet. 
{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetright) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) tulajdonságokat az [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat) osztály segítségével megadhatja egy kitöltő téglalapként.  

Ha egy kép nyújtása meg van adva, egy forrástéglalap skálázódik, hogy illeszkedjen a megadott kitöltő téglalapba. A kitöltő téglalap minden élét a forma körülhatároló keretének megfelelő élétől számított százalékos eltolás határozza meg. A pozitív százalék belső eltolást, a negatív százalék külső eltolást jelent.  

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/)osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltési típusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon meg egy képet a forma kitöltéséhez.  
8. Adja meg a kép eltolásait a forma körülhatároló keretének megfelelő élhez képest.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Beállítja a képet, hogy minden oldalról nyújtott legyen a forma testében
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Hogyan tudom megtudni, mely képformátumok támogatottak a PictureFrame‑hez?**  
Az Aspose.Slides támogatja a raszteres képeket (PNG, JPEG, BMP, GIF stb.) és a vektoros képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia- és képkonverziós motor képességeivel.

**Hogyan befolyásolja a több tucat nagy kép PPTX méretét és teljesítményét?**  
A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek linkkel való hozzáadása segít csökkenteni a prezentáció méretét, de az külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek linkkel való hozzáadását a fájlméret csökkentése érdekében.

**Hogyan zárolhatok egy képobjektumot a véletlen mozgatás/átméretezés ellen?**  
Használjon [alakzatzárolásokat](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/pictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) számára (például a mozgatás vagy átméretezés letiltása). A zárolási mechanizmust külön [védelmi cikk]( /slides/hu/net/applying-protection-to-presentation/) ismerteti, és több alakzattípusra is vonatkozik, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) elemeket is.

**Megmarad-e az SVG vektorhűség, ha a prezentációt PDF‑be vagy képekbe exportálom?**  
Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/)‑ből eredeti vektorként. PDF‑re vagy raszteres formátumokra ([PDF](/slides/hu/net/convert-powerpoint-to-pdf/) vagy [PNG](/slides/hu/net/convert-powerpoint-to-png/)) exportálás esetén az eredmény rasterizálódhat a kimeneti beállításoktól függően; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektor marad.