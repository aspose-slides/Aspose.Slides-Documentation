---
title: PowerPoint-prezentációk konvertálása animált GIF-ekre .NET-ben
linktitle: PowerPoint GIF-re
type: docs
weight: 65
url: /hu/net/convert-powerpoint-to-animated-gif/
keywords:
- animált GIF
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint GIF-re
- prezentáció GIF-re
- dia GIF-re
- PPT GIF-re
- PPTX GIF-re
- PPT mentése GIF-ként
- PPTX mentése GIF-ként
- PPT exportálása GIF-ként
- PPTX exportálása GIF-ként
- alapértelmezett beállítások
- egyéni beállítások
- .NET
- C#
- Aspose.Slides
description: "Könnyedén konvertálhat PowerPoint-prezentációkat (PPT, PPTX) animált GIF-ekre az Aspose.Slides for .NET segítségével. Gyors, magas minőségű eredmények."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy néhány kódsorból PowerPoint‑prezentációkat animált GIF fájlokká konvertáljon. Ez akkor hasznos, amikor a diák tartalmát könnyű, széles körben támogatott animált formátumban szeretné megosztani, amely beágyazható weboldalakba, üzenetküldőkbe vagy dokumentációba. Ez a cikk bemutatja, hogyan exportálhatja a prezentációt GIF‑ként az alapértelmezett beállításokkal, és hogyan testreszabhatja a kimenetet a keretméret, dia‑késleltetés és átmeneti képkockasebesség beállításával a [GifOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/gifoptions/) segítségével.

## **Prezentációk konvertálása animált GIF‑be alapértelmezett beállításokkal**

Ez a C# példakód bemutatja, hogyan konvertálhat egy prezentációt animált GIF‑be standard beállításokkal:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Az animált GIF alapértelmezett paraméterekkel jön létre. 

{{%  alert  title="TIPP"  color="primary"  %}} 
Ha inkább testre szabná a GIF paramétereit, használja a [GifOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/gifoptions) osztályt. Lásd az alábbi minta‑kódot. 
{{% /alert %}} 

## **Prezentációk konvertálása animált GIF‑be egyéni beállításokkal**

Ez a példakód bemutatja, hogyan konvertálhat egy prezentációt animált GIF‑be egyéni beállításokkal C#‑ban:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // a létrehozott GIF mérete  
        DefaultDelay = 2000, // mennyi ideig jelenik meg minden dia, amíg a következőre cserélődik
        TransitionFps = 35 // növelje az FPS-t a jobb átmeneti animáció minőségért
    });
}
```

{{% alert title="Információ" color="info" %}}
Érdemes kipróbálni az Aspose által fejlesztett INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertert. 
{{% /alert %}}

## **GYIK**

**Mi a teendő, ha a prezentációban használt betűtípusok nincsenek telepítve a rendszerben?**

Telepítse a hiányzó betűtípusokat vagy [állítsa be a tartalék betűtípusokat](/slides/hu/net/powerpoint-fonts/). Az Aspose.Slides helyettesíti őket, de a megjelenés eltérhet. A márkaképzéshez mindig győződjön meg arról, hogy a szükséges betűkészletek kifejezetten elérhetők.

**Hozzáadhatok vízjelet a GIF‑keretekhez?**

Igen. [Adjon hozzá félig átlátszó objektumot/logót](/slides/hu/net/watermark/) a mester diára vagy az egyes diákra exportálás előtt – a vízjel minden keretben megjelenik.