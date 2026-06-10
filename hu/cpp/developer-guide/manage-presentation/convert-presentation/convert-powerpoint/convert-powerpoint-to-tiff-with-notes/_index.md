---
title: PowerPoint bemutatók konvertálása TIFF-be jegyzetekkel C++-ban
linktitle: PowerPoint TIFF-be jegyzetekkel
type: docs
weight: 100
url: /hu/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-be
- bemutató TIFF-be
- dia TIFF-be
- PPT TIFF-be
- PPTX TIFF-be
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- PowerPoint jegyzetekkel
- bemutató jegyzetekkel
- dia jegyzetekkel
- PPT jegyzetekkel
- PPTX jegyzetekkel
- TIFF jegyzetekkel
- C++
- Aspose.Slides
description: "Konvertálja a PowerPoint bemutatókat TIFF-be jegyzetekkel az Aspose.Slides for C++ segítségével. Ismerje meg, hogyan exportálhatja hatékonyan a dia előadói jegyzetekkel."
---
## **Bevezetés**

Aspose.Slides for C++ egyszerű megoldást kínál a PowerPoint és OpenDocument bemutatók (PPT, PPTX és ODP) jegyzetekkel együtt TIFF formátumba konvertálására. Ez a formátum széles körben használatos magas minőségű képtárolásra, nyomtatásra és dokumentumarchiválásra. Az Aspose.Slides segítségével nem csak az egész bemutatót exportálhatja előadói jegyzetekkel, hanem diaképbélyegeket is generálhat a Jegyzet Dias nézetben. A konverziós folyamat egyszerű és hatékony, a `Save` metódust használva a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban, amely az egész bemutatót TIFF képek sorozatává alakítja, miközben megőrzi a jegyzeteket és az elrendezést.

## **Konvertáljon egy bemutatót TIFF-be jegyzetekkel**

PowerPoint vagy OpenDocument bemutató TIFF-be jegyzetekkel mentése az Aspose.Slides for C++ használatával a következő lépéseket tartalmazza:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt: Töltse be a PowerPoint vagy OpenDocument fájlt.
1. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztályt annak meghatározására, hogyan jelenjenek meg a jegyzetek és megjegyzések.
1. Mentse a bemutatót TIFF formátumba: Adja át a beállított opciókat a [Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak.

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![A bemutató dia előadói jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan konvertálhatja a bemutatót TIFF képpé a Jegyzet Dias nézetben a [set_SlidesLayoutOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) metódus használatával.

```cpp
// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // A jegyzeteket a dia alján jeleníti meg.

// Állítsa be a TIFF opciókat a jegyzetek elrendezésével.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Mentse a bemutatót TIFF-be előadói jegyzetekkel.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Az eredmény:

![A TIFF kép előadói jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Tekintse meg az Aspose [Ingyenes PowerPoint poszter konvertáló](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Szabályozhatom a jegyzetek területének pozícióját a kapott TIFF-ben?**

Igen. Használja a [notes layout settings](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) beállítást, hogy válasszon a `None`, `BottomTruncated` vagy `BottomFull` lehetőségek közül, amelyek rendre a jegyzetek elrejtését, egyetlen oldalra való illesztését vagy további oldalakra történő folytatását biztosítják.

**Hogyan csökkenthetjük a jegyzetekkel rendelkező TIFF fájl méretét látható minőségromlás nélkül?**

Válasszon egy [efficient compression](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (pl. `LZW` vagy `RLE`), állítson be megfelelő DPI-t, és ha elfogadható, alkalmazzon alacsonyabb [pixel format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (például 8 bpp vagy 1 bpp monokróm esetén). Az [image dimensions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_imagesize/) enyhe csökkentése szintén segíthet anélkül, hogy észrevehetően rontaná az olvashatóságot.

**Befolyásolja a jegyzetek betűtípusa az eredményt, ha az eredeti betűtípusok hiányoznak a rendszerről?**

Igen. A hiányzó betűtípusok [helyettesítés](/slides/hu/cpp/font-selection-sequence/) műveletet indítanak, ami megváltoztathatja a szöveg metrikáit és megjelenését. Ennek elkerülésére [supply the required fonts](/slides/hu/cpp/custom-font/) vagy állítson be alapértelmezett [fallback font](/slides/hu/cpp/fallback-font/) betűtípust, hogy a kívánt típusok legyenek használva.