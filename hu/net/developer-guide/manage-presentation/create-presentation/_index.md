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
description: "Készítsen prezentációkat .NET-ben az Aspose.Slides segítségével — hozzon létre PPT, PPTX és ODP fájlokat, használja ki az OpenDocument támogatást, és mentse őket programozottan a megbízható eredmények érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre egy bemutatót az Aspose.Slides segítségével, hogyan adhat szövegdobozt az első diájához, és hogyan mentheti az eredményt fájlként. Azt is bemutatja, hogyan hozhat létre és menthet egy üres bemutatót, valamint hogyan nyithat meg egy meglévő, támogatott formátumú bemutatót, és mentheti egy másik formátumba. A végén egy rövid GYIK a formátumokkal, sablonokkal, diaméretekkel, egységekkel, memóriahasználattal, szálkezeléssel, licenceléssel, digitális aláírásokkal és VBA‑támogatással kapcsolatos gyakori kérdéseket tárgyalja.

Mielőtt elkezdené, adja hozzá az Aspose.Slides‑t a projektjéhez a NuGet‑ről. Lásd a [Telepítés](/slides/hu/net/installation/) oldalt a Windows, Linux és macOS rendszerekhez használható csomagról.

## **PowerPoint prezentáció létrehozása**

A prezentáció létrehozásához és egy szövegdoboz elhelyezéséhez az első dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból. Egy új prezentáció már tartalmaz egy üres diát.
2. Szerezze meg azt a diát a [Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményből az indexével, 0.
3. Adjon hozzá egy téglalapot a [AddAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addautoshape/) metódussal, és állítsa be a [text](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/text/) értékét.
4. Mentse a prezentációt PPTX fájlként a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódussal.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

A téglalap bal felső sarka 50 ponttal van a dia bal szélétől és 50 ponttal a felső szélétől; a téglalap 400 pont széles és 100 pont magas. A mentett fájl egy diát tartalmaz, amelyen ez a téglalap és a szövege szerepel. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelési vízjelet is felhelyez; lásd a [Licencelés](/slides/hu/net/licensing/) oldalt.

## **Prezentáció létrehozása és mentése**

<a name="csharp-create-save-presentation"></a>

Üres prezentáció létrehozásához és mentéséhez hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból, és mentse a [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) felsorolás bármely formátumában. Az eredmény egy egyetlen üres diát tartalmazó prezentáció.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Prezentáció megnyitása és mentése**

<a name="csharp-open-save-presentation"></a>

Egy prezentáció átalakításához egyik formátumból a másikba nyissa meg a fájl elérési útját átadva a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/presentation/) konstruktorának, majd mentse a célformátumba. Az Aspose.Slides a bemeneti formátumot, például PPT, PPTX vagy ODP, a fájlból saját maga ismeri fel.

Az alábbi példa egy *Sample.odp* nevű OpenDocument prezentációt vár a munkakönyvtárban, és PPTX‑ként menti.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **GYIK**

### Milyen formátumokra mentheti az új prezentációt?

Menthet [PPTX, PPT és ODP](/slides/hu/net/save-presentation/) formátumokba, valamint exportálhat [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), [XPS](/slides/hu/net/convert-powerpoint-to-xps/), [HTML](/slides/hu/net/convert-powerpoint-to-html/), [SVG](/slides/hu/net/render-a-slide-as-an-svg-image/) és [képek](/slides/hu/net/convert-powerpoint-to-png/) formátumokba, többek között.

### Kezdhetek egy sablonból (POTX/POTM), és menthetem egyszerű PPTX‑ként?

Igen. Töltse be a sablont, majd mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/net/supported-file-formats/).

### Hogyan szabályozhatom a dia méretét/méretarányát a prezentáció létrehozásakor?

Állítsa be a [dia méretét](/slides/hu/net/slide-size/) (beleértve az 4:3 és 16:9 előre beállított vagy egyéni méreteket), és válassza ki, hogyan méreteződjön a tartalom.

### Milyen egységekben mérik a méreteket és a koordinátákat?

Pontokban: 1 hüvelyk 72 egységnek felel meg.

### Hogyan kezeljem a nagyon nagy prezentációkat (sok médiafájllal) a memóriahasználat csökkentése érdekében?

Használjon [BLOB kezelési stratégiákat](/slides/hu/net/manage-blob/), korlátozza a memóriában tárolt adatot ideiglenes fájlok használatával, és részesítse előnyben a fájlalapú munkafolyamatokat a tisztán memóriában lévő adatfolyamok helyett.

### Létrehozhatok/menthetek prezentációkat párhuzamosan?

Nem lehet ugyanazon a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányon műveleteket végezni [több szálról](/slides/hu/net/multithreading/). Indítson külön, elszigetelt példányokat szálonként vagy folyamatonként.

### Hogyan távolíthatom el a próbaverzió vízjelét és korlátozásait?

[Alkalmazzon licencet](/slides/hu/net/licensing/) egyszer a folyamat során. A licenc XML‑nek változatlanul kell maradnia, és a licenc beállítását szinkronizálni kell, ha több szál is érintett.

### Aláírhatom digitálisan a létrehozott PPTX‑t?

Igen. A [digitális aláírások](/slides/hu/net/digital-signature-in-powerpoint/) (létrehozása és ellenőrzése) támogatottak a prezentációknál.

### Támogatottak a makrók (VBA) a létrehozott prezentációkban?

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/net/presentation-via-vba/), és menthet makróval engedélyezett fájlokat, például PPTM/PPSM.