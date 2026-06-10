---
title: PowerPoint előadások konvertálása SWF Flash formátumba .NET-ben
linktitle: PowerPoint SWF-re
type: docs
weight: 80
url: /hu/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) konvertálása SWF Flash formátumba .NET-ben az Aspose.Slides segítségével. Lépésről‑lépésre C# kódminták, gyors és minőségi kimenet, PowerPoint automatizálás nélkül."
---
## **Áttekintés**

Ez a cikk azt magyarázza el, hogyan konvertálhatók PowerPoint előadások SWF formátumba az Aspose.Slides használatával. Megmutatja, hogyan menthetünk egy előadást SWF fájlként a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódussal, és hogyan konfigurálhatjuk az exportálást a [SwfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions/) segítségével, beleértve a megjelenítő beállításait valamint a jegyzetek vagy megjegyzések elrendezését.

## **Prezentációk konvertálása Flash-re**

A [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save/index) metódus, amelyet a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály biztosít, használható a teljes előadás SWF dokumentummá konvertálásához. A generált SWF-be megjegyzéseket is belefoglalhat a [SWFOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions) osztály és a [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/inotescommentslayoutingoptions) interfész használatával. Az alábbi példa bemutatja, hogyan konvertálhatunk egy előadást SWF dokumentummá a SWFOptions osztály által biztosított beállításokkal.

```c#
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Prezentáció és jegyzetoldalak mentése
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **GYIK**

**Bevonhatok rejtett diákot az SWF-be?**

Igen. Engedélyezze a [ShowHiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions/showhiddenslides/) opciót a [SwfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions/) osztályban. Alapértelmezés szerint a rejtett diák nem kerülnek exportálásra.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretét?**

Használja a [Compressed](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions/compressed/) jelzőt (alapértelmezés szerint engedélyezve), és állítsa be a [JpegQuality](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions/jpegquality/) értékét a fájlméret és a képminőség egyensúlyozásához.

**Mi a 'ViewerIncluded' célja, és mikor kell letiltani?**

[ViewerIncluded](https://reference.aspose.com/slides/hu/net/aspose.slides.export/swfoptions/viewerincluded/) beágyazott lejátszó UI-t (navigációs vezérlők, panelek, keresés) ad a SWF-hez. Tiltsa le, ha saját lejátszót kíván használni, vagy egy UI nélküli, egyszerű SWF keretre van szüksége.

**Mi történik, ha a forrásgépen hiányzik egy betűtípus az export során?**

Az Aspose.Slides a [DefaultRegularFont](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/defaultregularfont/) beállításban a [SwfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/) osztályon keresztül megadott betűtípust fogja helyettesíteni, hogy elkerülje a nem kívánt visszaesést.