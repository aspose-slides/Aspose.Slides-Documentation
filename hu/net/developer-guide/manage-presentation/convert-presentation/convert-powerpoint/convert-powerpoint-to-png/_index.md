---
title: PowerPoint-diák konvertálása PNG-re .NET környezetben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/net/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálás
- prezentáció konvertálás
- dia konvertálás
- PPT konvertálás
- PPTX konvertálás
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
description: "Konvertálja a PowerPoint-prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for .NET segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhatók a PowerPoint‑prezentációk PNG képekké az Aspose.Slides használatával. Megmutatja, hogyan tölthető be a prezentációs fájlok PPT, PPTX és ODP formátumokban, hogyan renderelhetők a diák képekké, és hogyan menthetők az eredmények PNG formátumban.

A cikk továbbá bemutatja, hogyan testreszabhatók a generált PNG képek skálázási értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG-re**

Kövesse ezeket a lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztálypéldányt.  
2. Szerezze be a diát az [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/properties/slides) gyűjteményből az [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide) interfész alatt.  
3. Használja az [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) metódust, hogy a diát a kívánt méretezésben renderelje.  
4. Használja az [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.ipresentation/save/methods/5) metódust a diakép PNG formátumba mentéséhez.  

Ez a C# kód bemutatja, hogyan konvertálható egy PowerPoint‑prezentáció PNG‑re. A Presentation objektum betölti a PPT, PPTX, ODP stb. formátumú fájlokat, majd a prezentáció minden diája PNG formátumba vagy más képpformátumba konvertálható.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Megjegyzés:** `1f, 1f` méretezési argumentumok a diát teljes méretben renderelik, így egy 720×540 pt méretű dia 720×540 px képet eredményez. A paraméter nélküli [GetImage()](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) túlterhelés egy sokkal kisebb előnézeti bélyegképet ad vissza. 
{{% /alert %}} 

## **PowerPoint konvertálása PNG-re egyedi méretekkel**

Ha egy bizonyos méretarány körül PNG fájlokat szeretne kapni, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a létrehozott bélyegkép méreteit. 

Ez a C# kód demonstrálja a leírt műveletet:

```c#
using Aspose.Slides;

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

## **PowerPoint konvertálása PNG-re egyedi mérettel**

Ha egy bizonyos méret körül PNG fájlokat szeretne kapni, átadhatja a kívánt `width` és `height` argumentumokat az `imageSize` paraméternek. 

Ez a kód bemutatja, hogyan konvertálhat egy PowerPoint‑prezentációt PNG‑re a képek méretének megadásával: 

```c#
using System.Drawing;
using Aspose.Slides;

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

### Hogyan exportálhatok csak egy adott alakzatot (például diagramot vagy képet) a teljes dia helyett?

Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképeinek generálását](/slides/hu/net/create-shape-thumbnails/); egy alakzatot PNG képpé renderelhet.

### Támogatott-e a párhuzamos konvertálás egy szerveren?

Igen, de [ne ossza meg](/slides/hu/net/multithreading/) egyetlen presentation példányt szálak között. Használjon külön példányt szálanként vagy folyamatanként.

### Mik a próbaverzió korlátozásai PNG exportálásakor?

Az értékelő mód vízjelet helyez a kimeneti képekre, és [egyéb korlátozásokat](/slides/hu/net/licensing/) alkalmaz, amíg a licenc nincs aktiválva.