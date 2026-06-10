---
title: PowerPoint prezentációk konvertálása SWF Flash-re C++-ban
linktitle: PowerPoint SWF-re
type: docs
weight: 80
url: /hu/cpp/convert-powerpoint-to-swf-flash/
keywords:
  - PowerPoint konvertálás
  - prezentáció konvertálás
  - dia konvertálás
  - PPT konvertálás
  - PPTX konvertálás
  - PowerPoint SWF-re
  - prezentáció SWF-re
  - dia SWF-re
  - PPT SWF-re
  - PPTX SWF-re
  - PowerPoint Flash-re
  - prezentáció Flash-re
  - dia Flash-re
  - PPT Flash-re
  - PPTX Flash-re
  - PPT mentése SWF-ként
  - PPTX mentése SWF-ként
  - PPT exportálása SWF-be
  - PPTX exportálása SWF-be
  - PowerPoint
  - prezentáció
  - C++
  - Aspose.Slides
description: "PowerPoint (PPT/PPTX) konvertálása SWF Flash-re C++-ban az Aspose.Slides segítségével. Lépésről lépésre kódrészletek, gyors minőségi kimenet, PowerPoint automatizálás nélkül."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat SWF formátumba konvertálni az Aspose.Slides használatával. Megmutatja, hogyan lehet egy prezentációt SWF fájlként menteni a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódussal, és hogyan lehet az exportálást a [SwfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/) segítségével beállítani, beleértve a néző beállításait, valamint a jegyzetek vagy megjegyzések elrendezését.

## **Prezentációk konvertálása Flash‑re**

A [Save](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metódus, amelyet a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály biztosít, használható a teljes prezentáció SWF dokumentummá konvertálásához. A generált SWF‑be megjegyzéseket is be lehet illeszteni a [SWFOptions](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.swf_options) osztály és a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztály használatával. Az alábbi példa bemutatja, hogyan lehet egy prezentációt SWF dokumentummá konvertálni a SWFOptions osztály által biztosított lehetőségek használatával.

``` cpp
// A dokumentumok könyvtárának útvonala.
    System::String dataDir = GetDataPath();

    // Példányosít egy Presentation objektumot, amely egy prezentációfájlt képvisel
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // A prezentáció és a jegyzetoldalak mentése
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **GYIK**

**Beilleszthetek rejtett diákot az SWF‑be?**

Igen. Használja a [set_ShowHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) metódust a [SwfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/) osztályban. Alapértelmezés szerint a rejtett diák nincsenek exportálva.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretét?**

Használja a [set_Compressed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/set_compressed/) metódust, és állítsa be a [JPEG quality](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/set_jpegquality/) értékét a fájlméret és a képminőség egyensúlyához.

**Mi a célja a ‘set_ViewerIncluded’ metódusnak, és mikor kellene használnom?**

A [set_ViewerIncluded](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) beágyazott lejátszó UI‑t (navigációs vezérlők, panelek, keresés) ad hozzá. Tiltsa le, ha saját lejátszót kíván használni, vagy ha UI nélkül, „csupasz” SWF‑keretet szeretne.

**Mi történik, ha egy forrásbetűtípus hiányzik az exportáló gépen?**

Az Aspose.Slides helyettesíti a betűtípust, amelyet a [set_DefaultRegularFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) metódussal ad meg a [SwfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/swfoptions/) osztályban, hogy elkerülje a nem kívánt visszaesést.