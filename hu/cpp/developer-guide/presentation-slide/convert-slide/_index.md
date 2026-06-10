---
title: Diák konvertálása képekké C++-ban
linktitle: Dia kép
type: docs
weight: 41
url: /hu/cpp/convert-slide/
keywords: 
- dia konvertálása
- dia exportálása
- dia képre
- dia mentése képként
- dia PNG-re
- dia JPEG-re
- dia bitmapre
- dia TIFF-re
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP diákat képekké C++-ban az Aspose.Slides segítségével – gyors, magas minőségű renderelés világos kódpéldákkal."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy könnyedén átalakítsa a PowerPoint és az OpenDocument prezentációs diákat különféle képformátumokká, többek közt BMP, PNG, JPG (JPEG), GIF és egyebek.

A dia képformátumba konvertálásához kövesse az alábbi lépéseket:

1. Határozza meg a kívánt konverziós beállításokat, és válassza ki a kívánt diák exportálásához a következőket:
    - Az [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfész,
    - Az [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/) interfész.
2. A dia képét a [GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) metódus meghívásával hozza létre.

A [Bitmap](https://reference.aspose.com/slides/hu/cpp/system.drawing/bitmap/) egy olyan objektum, amely lehetővé teszi a pixeladatok alapján definiált képek kezelését. Ennek az osztálynak egy példányával különféle formátumokban (BMP, JPG, PNG stb.) mentheti a képeket.

## **Diák konvertálása bitmap formátumba és a képek mentése PNG formátumban**

Konvertálhatja a diát bitmap objektummá, és közvetlenül felhasználhatja az alkalmazásban. Alternatívaként konvertálhatja a diát bitmapre, majd a képet JPEG vagy bármely más kívánt formátumban mentheti.

Ez a C++ kód bemutatja, hogyan konvertálja egy prezentáció első diáját bitmap objektummá, majd PNG formátumban menti a képet:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertálja a prezentáció első diáját bitmapre.
auto image = presentation->get_Slide(0)->GetImage();

// Mentse a képet PNG formátumban.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Diák konvertálása képekké egyéni méretekkel**

Lehet, hogy egy adott méretű képre van szüksége. A [GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) egy overload-jának használatával konvertálhatja a diát a kívánt szélességű és magasságú képpé.

Ez a mintakód bemutatja, hogyan valósítható meg:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertálja a prezentáció első diáját bitmapre a megadott mérettel.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Mentse a képet JPEG formátumban.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Diák konvertálása megjegyzésekkel és kommentárokkal képekké**

Egyes diák megjegyzéseket és kommentárokat tartalmazhatnak.

Az Aspose.Slides két interfészt biztosít – az [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) és az [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/) – amelyek lehetővé teszik a prezentációs diák képre való renderelésének szabályozását. Mindkét interfész tartalmazza a `set_SlidesLayoutOptions` metódust, amely lehetővé teszi a dián lévő megjegyzések és kommentárok renderelésének beállítását a kép konvertálásakor.

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztállyal megadhatja a megjegyzések és kommentárok kívánt pozícióját a keletkező képen.

Ez a C++ kód bemutatja, hogyan konvertálja a megjegyzésekkel és kommentárokkal rendelkező diát:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Állítsa be a jegyzetek pozícióját.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Állítsa be a megjegyzések pozícióját.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Állítsa be a megjegyzések területének szélességét.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Állítsa be a megjegyzések területének színét.

// Create the rendering options.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convert the first slide of the presentation to an image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Save the image in the GIF format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Bármely dia‑kép konvertálási folyamatban a [set_NotesPosition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) metódus nem alkalmazható a `BottomFull` értékkel (a megjegyzés pozíciójának meghatározásához), mivel a megjegyzés szövege túl nagy lehet, és nem fér bele a megadott képméretbe.
{{% /alert %}} 

## **Diák konvertálása képekké TIFF beállítások használatával**

Az [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfész nagyobb szabályozást tesz lehetővé a keletkező TIFF kép felett, mivel lehetővé teszi olyan paraméterek megadását, mint a méret, felbontás, színpaletta és egyebek.

Ez a C++ kód bemutat egy konvertálási folyamatot, ahol a TIFF beállítások segítségével fekete‑fehér képet állítunk elő 300 DPI felbontással és 2160 × 2800 mérettel:

```cpp 
// Töltsön be egy prezentációs fájlt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Szerezze be a prezentáció első diáját.
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

Az Aspose.Slides lehetővé teszi a prezentáció összes diájának képekké konvertálását, ezzel a teljes prezentációt képsorozattá alakítva.

Ez a mintakód bemutatja, hogyan konvertálja a prezentáció összes diáját C++-ban képekké:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// A prezentáció képekké renderelése diaról diara.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Rejtett diák kezelése (ne renderelje a rejtett diákot).
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

## **FAQ**

**Az Aspose.Slides támogatja-e a diák animációval történő renderelését?**  
Nem, a `GetImage` metódus csak a dia statikus képét menti, animációk nélkül.

**Rejtett diák exportálhatók-e képekként?**  
Igen, a rejtett diák is feldolgozhatók, mint a normálak. Csak ügyeljen arra, hogy a feldolgozási ciklusban szerepeljenek.

**Menthetők-e a képek árnyékokkal és hatásokkal?**  
Igen, az Aspose.Slides támogatja az árnyékok, átlátszóság és egyéb grafikai hatások renderelését a diák képként való mentésekor.