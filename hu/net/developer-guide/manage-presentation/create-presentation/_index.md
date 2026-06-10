---
title: Prezentációk létrehozása .NET-ben
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/net/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Prezentációk létrehozása .NET-ben az Aspose.Slides-szal - PPT, PPTX és ODP fájlok előállítása, az OpenDocument támogatásának kihasználása, valamint programozott mentés megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy prezentációt az Aspose.Slides használatával, hogyan adhatunk egyszerű tartalmat egy diára, és hogyan menthetjük az eredményt fájlként. Továbbá megmutatja, hogyan hozhatunk létre és menthetünk új prezentációt, hogyan nyithatunk meg egy meglévő, támogatott formátumú prezentációt, és hogyan menthetjük el egy másik formátumba. Emellett a cikk rövid GYIK‑ot is tartalmaz a formátumokkal, sablonokkal, diaméretezéssel, mértékegységekkel, memóriahasználattal, szálkezeléssel, licenceléssel, digitális aláírásokkal és VBA‑támogatással kapcsolatos gyakori kérdésekről.

## **PowerPoint‑prezentáció létrehozása**
Egyszerű, egyszerű vonal hozzáadásához a prezentáció egy kiválasztott diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy **Presentation** osztálypéldányt.
2. Szerezze meg a dia referenciáját az Index használatával.
3. Adjon hozzá egy **AutoShape** típusú **Line** elemet az **AddAutoShape** metódussal, amelyet a **Shapes** objektum biztosít.
4. Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy vonalat adtunk hozzá a prezentáció első diához.

```c#
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Lekérdezi az első diát
    ISlide slide = presentation.Slides[0];

    // Hozzáad egy autóképző elemet vonal típusban
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Prezentáció létrehozása és mentése**

<a name="csharp-create-save-presentation"><strong>Lépések: Prezentáció létrehozása és mentése C#‑ban</strong></a>

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztálypéldányt.
2. Mentse a _Presentation_-t bármely, a [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) által támogatott formátumba.

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Prezentáció megnyitása és mentése**

<a name="csharp-open-save-presentation"><strong>Lépések: Prezentáció megnyitása és mentése C#‑ban</strong></a>

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztálypéldányt bármely formátummal, például PPT, PPTX, ODP stb.
2. Mentse a _Presentation_-t bármely, a [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) által támogatott formátumba.

```c#
// Töltsön be bármilyen támogatott fájlt a Presentation-be, például ppt, pptx, odp stb.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Milyen formátumokba menthetek egy új prezentációt?**

Menthet [PPTX, PPT és ODP](/slides/hu/net/save-presentation/) formátumokba, valamint exportálhat [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), [XPS](/slides/hu/net/convert-powerpoint-to-xps/), [HTML](/slides/hu/net/convert-powerpoint-to-html/), [SVG](/slides/hu/net/convert-powerpoint-to-png/) és [képek](/slides/hu/net/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek sablonból (POTX/POTM), és menthetem sima PPTX‑ként?**

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/net/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát a prezentáció létrehozásakor?**

Állítsa be a [dia méretét](/slides/hu/net/slide-size/) (beleértve a 4:3 és 16:9 előre beállítottakat vagy egyéni méreteket), és válassza ki, hogyan skálázódjon a tartalom.

**Milyen egységekben mérik a méreteket és a koordinátákat?**

Pontban: 1 hüvelyk = 72 egység.

**Hogyan kezeljem a nagyon nagy prezentációkat (sok médiafájllal) a memóriahasználat csökkentése érdekében?**

Használjon [BLOB-kezelési stratégiákat](/slides/hu/net/manage-blob/), korlátozza a memóriában tárolt adatot átmeneti fájlokkal, és részesítse előnyben a fájlalapú munkafolyamatokat a tisztán memóriaáramok helyett.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**

Nem kezelhet ugyanazon [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt [több szál](/slides/hu/net/multithreading/)ból. Indítson külön, izolált példányokat szálanként vagy folyamatonként.

**Hogyan távolíthatom el a próba‑vízjelet és a korlátozásokat?**

[Alkalmazzon licencet](/slides/hu/net/licensing/) egyszer a folyamatban. A licenc XML‑nek változatlanul kell maradnia, és a licencbeállítást szinkronizálni kell, ha több szál használja.

**Alá tudom-e írni digitálisan a létrehozott PPTX‑et?**

Igen. A [digitális aláírások](/slides/hu/net/digital-signature-in-powerpoint/) (létrehozás és ellenőrzés) támogatottak a prezentációk esetén.

**Támogatottak a makrók (VBA) a létrehozott prezentációkban?**

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/net/presentation-via-vba/), és menthet makró‑engedélyezett fájlokat, például PPTM/PPSM.