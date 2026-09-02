---
title: Prezentációs diák képekké konvertálása C++-ban
linktitle: Dia képpé
type: docs
weight: 41
url: /hu/cpp/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képpé
- dia mentése képként
- dia PNG-be
- dia JPEG-be
- dia bitképbe
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Dia, PPT, PPTX és ODP formátumok képpé konvertálása C++-ban az Aspose.Slides segítségével – gyors, magas minőségű renderelés tiszta kódrészletekkel."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy egyszerűen konvertálja a PowerPoint és OpenDocument bemutatódiákot különféle képformátumokra, többek között BMP, PNG, JPG (JPEG), GIF és mások.

A dia képbe való konvertálásához kövesse az alábbi lépéseket:

1. Határozza meg a kívánt konverziós beállításokat, és válassza ki az exportálni kívánt diákat a következő használatával:
    - az [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfészt, vagy
    - az [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/) interfészt.
2. Generálja a dia képét a [GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) metódus meghívásával.

A [Bitmap](https://reference.aspose.com/slides/hu/cpp/system.drawing/bitmap/) egy objektum, amely lehetővé teszi a pixeladatok alapján definiált képek kezelését. Ennek az osztálynak egy példányával képeket menthet számos formátumban (BMP, JPG, PNG stb.).

## **Diák konvertálása bitképbe és a képek mentése PNG formátumban**

Konvertálhat egy diát bitkép objektummá, és közvetlenül felhasználhatja az alkalmazásában. Alternatívaként a diát bitképpé konvertálhatja, majd a képet JPEG‑ben vagy bármely más kívánt formátumban mentheti.

Ez a C++ kód bemutatja, hogyan konvertálhatja egy prezentáció első diaját bitkép objektummá, majd mentheti a képet PNG formátumban:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertálja a prezentáció első diáját bitképpé.
auto image = presentation->get_Slide(0)->GetImage();

// Mentse a képet PNG formátumban.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Diák konvertálása képekké egyéni méretekkel**

Lehet, hogy egy adott méretű képre van szüksége. A [GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) egyik túlterhelésének használatával a diát egy adott méretű (szélesség és magasság) képpé konvertálhatja.

Ez a mintakód bemutatja, hogyan kell ezt megtenni:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertálja a prezentáció első diáját a megadott mérettel rendelkező bitképpé.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Mentse a képet JPEG formátumban.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Diák konvertálása képekké megjegyzésekkel és hozzászólásokkal**

Egyes diáknak megjegyzései és hozzászólásai lehetnek.

Az Aspose.Slides két interfészt biztosít — a [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) és a [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/) — amelyek lehetővé teszik a prezentációs diák képekké való renderelésének szabályozását. Mindkét interfész tartalmazza a `set_SlidesLayoutOptions` metódust, amely lehetővé teszi a megjegyzések és hozzászólások egy dia képbe konvertálásakor való renderelésének beállítását.

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztállyal megadhatja a kívánt pozíciót a megjegyzések és hozzászólások számára a létrejövő képen.

Ez a C++ kód bemutatja, hogyan konvertálhat egy diát megjegyzésekkel és hozzászólásokkal:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Töltsön be egy prezentáció fájlt.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Állítsa be a jegyzetek pozícióját.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Állítsa be a megjegyzések pozícióját.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Állítsa be a megjegyzések terület szélességét.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Állítsa be a megjegyzések terület színét.

// Hozzon létre renderelési beállításokat.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Konvertálja a prezentáció első diáját képpé.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Mentse a képet GIF formátumban.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Megjegyzés" color="warning" %}} 
Bármely dia‑kép konvertálási folyamat során a [set_NotesPosition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) metódus nem tudja alkalmazni a `BottomFull` értéket (a megjegyzés pozíciójának megadására), mivel a megjegyzés szövege túl nagy lehet, és nem fér bele a megadott képméretbe.
{{% /alert %}} 

## **Diák konvertálása képekké TIFF beállítások használatával**

Az [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfész nagyobb irányítást biztosít a létrejövő TIFF képen, lehetővé téve olyan paraméterek megadását, mint a méret, felbontás, színpaletta és egyéb.

Ez a C++ kód egy konverziós folyamatot mutat be, ahol a TIFF opciók segítségével fekete‑fehér képet állítunk elő 300 DPI felbontással és 2160 × 2800 mérettel:

```cpp 
// Töltsön be egy prezentáció fájlt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Szerezze meg a prezentáció első diáját.
auto slide = presentation->get_Slide(0);

// Állítsa be a kimeneti TIFF kép beállításait.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Állítsa be a kép méretét.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Állítsa be a pixel formátumot (fekete-fehér).
tiffOptions->set_DpiX(300);                                         // Állítsa be a vízszintes felbontást.
tiffOptions->set_DpiY(300);                                         // Állítsa be a függőleges felbontást.

// Konvertálja a diát a megadott beállításokkal képpé.
auto image = slide->GetImage(tiffOptions);

// Mentse a képet TIFF formátumban.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Minden dia konvertálása képekké**

Az Aspose.Slides lehetővé teszi, hogy egy prezentáció összes diaját képekké konvertálja, ezzel a teljes bemutatót képsorozattá alakítva.

Ez a mintakód bemutatja, hogyan konvertálhat egy prezentáció összes diaját képekké C++‑ban:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Renderelje a prezentációt diánként képként.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kezelje a rejtett diákot (ne renderelje a rejtett diákat).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Konvertálja a diát képpé.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Mentse a képet JPEG formátumban.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Színes Emoji renderelés**

{{% alert title="Megjegyzés" color="warning" %}} 
A színes emojik helyes rendereléséhez a prezentáció diák képekké konvertálásakor a prezentációban használt emoji betűtípusoknak telepítve kell lenniük, és elérhetőnek kell lenniük a konvertálást végző rendszeren. Például, ha a prezentáció a **Segoe UI Emoji** betűtípust használja, és ez hiányzik, az emoji‑k monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **FAQ**

**Támogatja-e az Aspose.Slides a diák animációval történő renderelését?**

Nem, a `GetImage` metódus csak a dia statikus képét menti, animációk nélkül.

**Exportálhatók-e a rejtett diák képekként?**

Igen, a rejtett diák is feldolgozhatók, mint a normálak. Csak gondoskodjon arról, hogy szerepeljenek a feldolgozási ciklusban.

**Menthetők-e a képek árnyékokkal és effektusokkal?**

Igen, az Aspose.Slides támogatja az árnyékok, átlátszóság és egyéb grafikai hatások renderelését a diák képként való mentésekor.