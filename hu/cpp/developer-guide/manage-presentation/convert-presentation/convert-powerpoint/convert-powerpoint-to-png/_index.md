---
title: PowerPoint diák konvertálása PNG formátumba C++-ban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/cpp/convert-powerpoint-to-png/
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
- C++
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for C++ segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint bemutatókat PNG képekké konvertálni az Aspose.Slides használatával. Megmutatja, hogyan tölthetőek be a bemutató fájlok PPT, PPTX és ODP formátumokban, hogyan jeleníthetők meg a diák képként, és hogyan menthetők a PNG formátumban.

A cikk azt is bemutatja, hogyan testreszabhatók a létrehozott PNG képek méretezési értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG formátumba**

Kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) példányt.
2. Szerezze be a dia objektumot a [Presentation::get_Slides()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) gyűjteményből az [ISlide](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide) felület alatt.
3. Használja az [ISlide::GetImage()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage) metódust az egyes diák előnézeti képének létrehozásához.
4. Használja az [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) metódust a dia előnézeti kép PNG formátumba mentéséhez.

Ez a C++ kód megmutatja, hogyan konvertálhat egy PowerPoint bemutatót PNG formátumba:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint konvertálása PNG formátumba egyedi méretekkel**

Ha egy adott méretarányú PNG fájlokat szeretne kapni, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a létrejövő előnézeti kép méreteit.

Ez a C++ kód bemutatja a leírt műveletet:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint konvertálása PNG formátumba egyedi mérettel**

Ha egy adott méretű PNG fájlokat szeretne, megadhatja a kívánt `width` és `height` paramétereket az `ImageSize` számára.

Ez a kód megmutatja, hogyan konvertálhat egy PowerPointot PNG formátumba a képek méretének megadásával:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **Gyakran Ismételt Kérdések**

**Hogyan exportálhatok csak egy adott alakzatot (például diagramot vagy képet) a teljes dia helyett?**

Az Aspose.Slides támogatja az [egyedi alakzatok előnézeti képeinek generálását](/slides/hu/cpp/create-shape-thumbnails/); egy alakzatot PNG képpé renderelhet.

**Támogatott-e a párhuzamos konvertálás egy szerveren?**

Igen, de [ne ossza meg](/slides/hu/cpp/multithreading/) egyetlen bemutató példányt a szálak között. Használjon külön példányt szálanként vagy folyamatként.

**Mik a próbaverzió korlátozásai PNG exportáláskor?**

Az értékelő mód vízjelet helyez a kimeneti képekre, és [más korlátozásokat](/slides/hu/cpp/licensing/) alkalmaz, amíg licencet nem adnak meg.