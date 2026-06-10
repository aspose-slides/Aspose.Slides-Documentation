---
title: PowerPoint diák konvertálása PNG-re .NET-ben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/net/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat magas minőségű PNG képekké gyorsan az Aspose.Slides for .NET segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat PNG‑képekké konvertálni az Aspose.Slides használatával. Megmutatja, hogyan lehet PPT, PPTX és ODP formátumú prezentációs fájlokat betölteni, a diák képekké renderelni, és az eredményeket PNG formátumban menteni.  

A cikk azt is bemutatja, hogyan lehet testre szabni a létrehozott PNG‑képeket méretezési értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG‑be**

Kövesse az alábbi lépéseket:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányát.
2. Szerezze meg a diát az [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/properties/slides) gyűjteményből az [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide) interfész alatt. 
3. Használja az [ISlide.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) metódust minden dia bélyegképének lekéréséhez. 
4. Használja az [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.ipresentation/save/methods/5) metódust a dia bélyegkép PNG formátumba mentéséhez. 

Ez a C# kód bemutatja, hogyan lehet egy PowerPoint‑prezentációt PNG‑vé konvertálni. A Presentation objektum képes PPT, PPTX, ODP stb. betöltésére, majd a prezentáció minden diája PNG vagy más képformátumba kerül átalakításra.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint konvertálása PNG‑be egyedi méretekkel**

Ha egy adott méretezés szerinti PNG‑fájlokat szeretne, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a létrejövő bélyegkép méreteit.  

Ez a C# kód bemutatja a leírt műveletet:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint konvertálása PNG‑be egyedi mérettel**

Ha egy adott méretű PNG‑fájlokat szeretne, átadhatja a kívánt `width` és `height` argumentumokat az `imageSize` számára.  

Ez a kód bemutatja, hogyan lehet egy PowerPoint‑ot PNG‑vé konvertálni a képek méretének megadásával: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **GYIK**

**Hogyan exportálhatok csak egy konkrét alakzatot (például diagramot vagy képet) a teljes dia helyett?**  

Az Aspose.Slides támogatja az [generating thumbnails for individual shapes](/slides/hu/net/create-shape-thumbnails/); egy alakzatot PNG‑képpé renderelhet.

**Támogatott a párhuzamos konvertálás szerveren?**  

Igen, de [don’t share](/slides/hu/net/multithreading/) egyetlen prezentációpéldányt a szálak között. Használjon külön példányt szálanként vagy folyamatanként.

**Mik a próbaverziós korlátozások PNG‑exportálás esetén?**  

Az értékelő mód vízjelet ad a kimeneti képekhez, és [other restrictions](/slides/hu/net/licensing/) alkalmaz, amíg licenc nem kerül beállításra.