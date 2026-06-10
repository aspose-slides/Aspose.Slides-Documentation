---
title: Felső- és alsóindex kezelése Pythonban
linktitle: Felső- és alsóindex
type: docs
weight: 80
url: /hu/python-net/superscript-and-subscript/
keywords:
- felsőindex
- alsóindex
- felsőindex hozzáadása
- alsóindex hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Mestere a felső- és alsóindexet az Aspose.Slides Python verziójában a .NET-en keresztül, és emelje fel prezentációit professzionális szövegformázással a maximális hatásért."
---
## **Áttekintés**

Az Aspose.Slides olyan funkciókat kínál, amelyek lehetővé teszik a felső‑ és alsóindex szöveg beillesztését a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkba. Akár kémiai képleteket, matematikai egyenleteket szeretne kiemelni, akár lábjegyzetekkel kívánja megjegyzéseit annotálni, ezek a speciális formázási lehetőségek segítenek a tisztaság és pontosság megőrzésében. Ebben a cikkben megtanulja, hogyan alkalmazhatja zökkenőmentesen a felső‑ és alsóindex stílusokat, és hogyan biztosíthat professzionális eredményeket minden dián.

## **Felső‑ és alsóindex szöveg hozzáadása**

Felső‑ és alsóindex szöveget bármely bekezdésrészhez hozzáadhat. Az Aspose.Slides-ben használja a `escapement` tulajdonságot a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) osztályban ennek vezérléséhez.

`escapement` egy **-100% és 100%** közötti százalék:

- **> 0** → felsőindex (például 25% = enyhe emelés; 100% = teljes felsőindex)
- **0** → alapvonal (nincs felső/alsó index)
- **< 0** → alsóindex (például -25% = enyhe lejjebb; -100% = teljes alsóindex)

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot, és szerezzen egy diát.  
1. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és érje el a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát.  
1. Törölje a meglévő bekezdéseket.  
1. Felsőindexhez: hozzon létre egy bekezdést és egy részt, állítsa be a `portion.portion_format.escapement` értékét **0 és 100** között, adja meg a szöveget, és adja hozzá a részt.  
1. Alsóindexhez: hozzon létre egy új bekezdést és részt, állítsa be az `escapement` értékét **-100 és 0** között, adja meg a szöveget, és adja hozzá a részt.  
1. Mentse a prezentációt PPTX formátumban.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Szerezzünk egy diát.
    slide = presentation.slides[0]

    # Hozzunk létre egy szövegmezőt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Hozzunk létre egy bekezdést a felsőindex szöveghez.
    superscript_paragraph = slides.Paragraph()

    # Hozzunk létre egy szövegrészt normál szöveggel.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Hozzunk létre egy szövegrészt felsőindex szöveggel.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Hozzunk létre egy bekezdést az alsóindex szöveghez.
    subscript_paragraph = slides.Paragraph()

    # Hozzunk létre egy szövegrészt normál szöveggel.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Hozzunk létre egy szövegrészt alsóindex szöveggel.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Adjuk hozzá a bekezdéseket a szövegmezőhöz.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Alkalmazhatok-e felső‑ és alsóindexet táblázatokban és egyéb konténerekben, nem csak szabványos szövegmezőkben?**

Igen. Formázhatja a szöveget felső‑ vagy alsóindexként bármely olyan objektumban, amely [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) (beleértve a táblázatcellákat) elérhetővé teszi. A formázás a keretben lévő szövegrészekre vonatkozik.

**Megmaradnak-e a felső‑ és alsóindexek PDF, HTML vagy képek exportálásakor?**

Igen. Az Aspose.Slides megőrzi a felső‑ és alsóindex formázást a gyakori formátumokba, például a [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), a [HTML](/slides/hu/python-net/convert-powerpoint-to-html/) és a [raszteres képek](/slides/hu/python-net/convert-powerpoint-to-png/) exportálásakor, mivel a renderelési csővezeték tiszteletben tartja a részenkénti szövegformázást.

**Kombinálhatok-e felső‑ vagy alsóindexet hiperlinkeléssel ugyanabban a szövegrészben?**

Igen. A [Hiperhivatkozások](/slides/hu/python-net/manage-hyperlinks/) a részen (fragmentumként) szintjén vannak hozzárendelve, így egy rész egyben tartalmazhat hiperhivatkozást és lehet felső‑ vagy alsóindex formázású.