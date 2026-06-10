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
- relatív skála
- kép effektus
- méreptartási arány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Adjon hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for .NET segítségével. Egyszerűsítse munkafolyamatát és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely képet tartalmaz—mint egy képet a keretben.  

Képet adhat hozzá egy diára képkereten keresztül. Így a képet a képkeret formázásával formázhatja.  

{{% alert  title="Tipp" color="primary" %}}  
Aspose ingyenes konvertálókat biztosít—[JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan prezentációkat hozzanak létre képekből.  
{{% /alert %}}  

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy képet ad hozzá az [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amely a prezentáció objektumhoz tartozik és a forma kitöltésére lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe) objektumot a kép szélessége és magassága alapján az `AddPictureFrame` metóduson keresztül, amely a hivatkozott dia alakzatobjektuma által van elérve.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Mentse a módosított bemutatót PPTX fájlként.  

Ez a C# kód megmutatja, hogyan hozhat létre egy képkeretet:

```c#
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{
    // Lekéri az első diát
    ISlide slide = pres.Slides[0];

    // Betölt egy képet és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet azonos magassággal és szélességgel
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Alkalmaz némi formázást a képkeretre
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Elmenti a prezentációt PPTX fájlba
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}}  
A képkeretek lehetővé teszik, hogy gyorsan készítsen prezentációs diát képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, kezelheti a be- és kimeneti műveleteket a képek formátumok közti átalakításához. Érdemes megnézni ezeket az oldalakat: convert [image to JPG](https://products.aspose.com/slides/hu/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hu/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hu/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hu/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hu/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hu/net/conversion/svg-to-png/).  
{{% /alert %}}  

## **Képkeret létrehozása relatív méretezéssel**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy képet ad hozzá az [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amely a prezentáció objektumhoz tartozik és a forma kitöltésére lesz használva.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Mentse a módosított bemutatót PPTX fájlként.  

Ez a C# kód megmutatja, hogyan hozhat létre egy képkeretet relatív méretezéssel:

```c#
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Betölt egy képet és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Képkeretet ad a diára
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Beállítja a relatív méretezés szélességét és magasságát
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Elmenti a prezentációt
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Raszer képek kinyerése képkeretekből**

Képet nyerhet ki raszer formátumban a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe) objektumokból, és elmentheti PNG, JPG vagy egyéb formátumban. Az alábbi kódrészlet azt mutatja be, hogyan nyerhet ki egy képet a „sample.pptx” dokumentumból, majd mentheti PNG formátumban.

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

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyeket [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) alakzatokba helyeztek, az Aspose.Slides for .NET lehetővé teszi az eredeti vektoros képek teljes pontosságú visszanyerését. A dia alakzategyüttesének bejárásával azonosíthatja a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) elemeket, ellenőrizheti, hogy a mögöttes [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) SVG tartalmat tartalmaz‑e, majd elmentheti a képet lemezre vagy áramlásba natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy SVG képet egy képkeretből:

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

## **Kép átlátszóságának lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági effektust. Ez a C# kód demonstrálja a műveletet:

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

{{% alert color="primary" %}}  
Minden, képekre alkalmazott effektus megtalálható a [Aspose.Slides.Effects](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/) névtérben.  
{{% /alert %}}  

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket a képkeretre lehet alkalmazni. Ezekkel a beállításokkal módosíthatja a képkeretet, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage) objektumot úgy, hogy képet ad hozzá az [IImagescollection](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) gyűjteményhez, amely a prezentáció objektumhoz tartozik és a forma kitöltésére lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján az [AddPictureFrame](http://www.aspose.com/api/net/slides/hu/aspose.slides/ishapecollection/methods/addpictureframe) metóduson keresztül, amely a [IShapes](http://www.aspose.com/api/net/slides/hu/aspose.slides/ishapecollection) objektumhoz van rendelve a hivatkozott dián.  
6. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az ábrát az óramutató járásával megegyező irányba forgat.  
   * A negatív érték az ábrát az óramutató járásával ellentétes irányba forgat.  
10. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Mentse a módosított bemutatót PPTX fájlként.  

Ez a C# kód demonstrálja a képkeret formázási folyamatát:

```c#
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Lekéri az első diát
    ISlide slide = presentation.Slides[0];

    // Betölt egy képet és hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáad egy képkeretet, amely a képnek megfelelő magassággal és szélességgel rendelkezik
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
Az Aspose nemrég fejlesztett egy [free Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha valaha [JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket kell egyesítenie, vagy [rácsokat szeretne létrehozni fényképekből](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást.  
{{% /alert %}}  

## **Kép hozzáadása hivatkozásként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) hozzáadhat hivatkozásokon keresztül azáltal, hogy nem ágyazza be a fájlokat közvetlenül a prezentációba. Ez a C# kód megmutatja, hogyan adhat képet és videót egy helyőrzőhöz:

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

Ez a C# kód megmutatja, hogyan vághat le egy már meglévő képet egy dián:

```c#
using (Presentation presentation = new Presentation())
{
    // Létrehoz egy új kép objektumot
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Képkeretet ad egy diára
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Levágja a képet (százalék értékek)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Elmenti az eredményt
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Kivágott területek törlése képből**

Ha a keretben lévő kép kivágott részeit szeretné törölni, használhatja az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust. Ez a metódus visszaadja a kivágott képet, vagy az eredeti képet, ha a vágás nem szükséges.

Ez a C# kód demonstrálja a műveletet:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a képkeretet az első diáról
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Törli a képkeret képének kivágott területeit, és visszaadja a kivágott képet
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}  
Az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódus a kivágott képet a prezentáció képgyűjteményéhez adja hozzá. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/)‑ben van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végleges prezentációban lévő képek száma növekedni fog.  

A metódus a vágási művelet során a WMF/EMF metafájlokat raszer PNG képpé konvertál.  
{{% /alert %}}  

## **Képek tömörítése**

A [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/compressimage/) metódussal tömöríthet egy képet a prezentációban.  
Ez a metódus a képet a forma mérete és a megadott felbontás alapján csökkenti, a vágott területek törlésének lehetőségével.  

A funkció hasonlóan működik, mint a PowerPoint **Picture Format → Compress Pictures → Resolution** beállítása.  

Az alábbi C# példák bemutatják, hogyan lehet egy képet tömöríteni a prezentációban, célfelbontás megadásával és opcionálisan a vágott területek eltávolításával:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Tömöríti a képet 150 DPI (webes felbontás) célfelbontással, és eltávolítja a kivágott területeket.
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

Vagy egy egyedi DPI érték közvetlen megadásával:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Tömöríti a képet 150 DPI (webes felbontás) értékre, eltávolítva a kivágott területeket.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}  
A metódus a képet a forma mérete és a megadott DPI alapján alacsonyabb felbontásra konvertálja. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minősége megmarad vagy enyhén csökken a felbontástól függően, ahogyan a PowerPoint kezeli a nagy felbontású JPEG‑eket.  
{{% /alert %}}  

## **Méreptartási arány zárolása**

Ha azt szeretné, hogy egy képet tartalmazó forma megőrizze a méreptartási arányát a kép méretének módosítása után is, használhatja az [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframelock/aspectratiolocked/) tulajdonságot a *Lock Aspect Ratio* beállítás beállításához.  

Ez a C# kód megmutatja, hogyan lehet zárolni egy forma méreptartási arányát:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Beállítja a formát, hogy a méretezés során megőrizze a méreptartási arányt
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}  
Ez a *Lock Aspect Ratio* beállítás csak a forma arányát, a benne lévő képet nem érinti.  
{{% /alert %}}  

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetright) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) tulajdonságok a [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat) osztályból lehetővé teszik egy kitöltő téglalap meghatározását.  

Amikor egy képhez nyújtás van megadva, a forrás téglalap skálázódik, hogy illeszkedjen a megadott kitöltő téglalaphoz. A kitöltő téglalap minden élét egy százalékos eltolás határozza meg a forma határoló dobozának megfelelő élétől. A pozitív százalékos érték belülre tolját, a negatív pedig kifelé tolját.  

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be a forma kitöltés típusát.  
6. Állítsa be a forma képkitöltési módját.  
7. Adjon hozzá egy képet a forma kitöltéséhez.  
8. Adja meg a kép eltolásait a forma határoló dobozának megfelelő élétől.  
9. Mentse a módosított bemutatót PPTX fájlként.  

Ez a C# kód demonstrálja a StretchOff tulajdonság használatát:

```c#
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

**Hogyan tudom megtudni, mely képformátumok támogatottak a PictureFrame számára?**  

Az Aspose.Slides támogatja a raszer képeket (PNG, JPEG, BMP, GIF, stb.) és a vektoros képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedi a dia- és képkonvertáló motor képességeit.  

**Hogyan befolyásolja a PPTX méretét és teljesítményét a tucatnyi nagy kép hozzáadása?**  

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként való hozzáadása segít csökkenteni a prezentáció méretét, de az külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek hivatkozásként történő hozzáadását a fájlméret csökkentése érdekében.  

**Hogyan zárhatom le a képobjektumot a véletlen áthelyezés/átméretezés ellen?**  

Használjon [shape locks](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/pictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásával). A zárolási mechanizmust a formákra vonatkozó külön [protection article](/slides/hu/net/applying-protection-to-presentation/) részletezi, és különböző forma típusokra, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/)‑re is érvényes.  

**Megmarad-e az SVG vektorgrafika pontossága, amikor a prezentációt PDF-re/képre exportáljuk?**  

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/)‑ből eredeti vektorként. Amikor [PDF-re exportálunk](/slides/hu/net/convert-powerpoint-to-pdf/) vagy [raszer formátumokra](/slides/hu/net/convert-powerpoint-to-png/), az eredmény a beállított export opcióktól függően raszerítható; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektorként van tárolva.