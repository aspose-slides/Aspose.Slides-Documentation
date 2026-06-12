---
title: Gestire apice e pedice in Python
linktitle: Apice e pedice
type: docs
weight: 80
url: /it/python-net/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungere apice
- aggiungere pedice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Padroneggia apice e pedice in Aspose.Slides per Python tramite .NET e migliora le tue presentazioni con una formattazione del testo professionale per un impatto massimo."
---
## **Panoramica**

Aspose.Slides offre funzionalità per integrare testo in apice e pedice nelle presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai a applicare in modo fluido gli stili di apice e pedice e a garantire risultati professionali in ogni diapositiva.

## **Aggiungere testo in apice e pedice**

Puoi aggiungere testo in apice e pedice a qualsiasi porzione di paragrafo. In Aspose.Slides, utilizza la proprietà `escapement` della classe [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/) per controllarlo.

`escapement` è una percentuale da **-100% a 100%**:

- **> 0** → apice (ad es., 25% = lieve sollevamento; 100% = apice completo)
- **0** → linea di base (nessun apice/pedice)
- **< 0** → pedice (ad es., -25% = lieve abbassamento; -100% = pedice completo)

Passaggi:

1. Crea una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e ottieni una diapositiva.
2. Aggiungi un rettangolo [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) e accedi al suo [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
3. Cancella i paragrafi esistenti.
4. Per l'apice: crea un paragrafo e una porzione, imposta `portion.portion_format.escapement` su un valore compreso tra **0 e 100**, imposta il testo e aggiungi la porzione.
5. Per il pedice: crea un altro paragrafo e una porzione, imposta `escapement` su un valore compreso tra **-100 e 0**, imposta il testo e aggiungi la porzione.
6. Salva la presentazione come PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Ottieni una diapositiva.
    slide = presentation.slides[0]

    # Crea una casella di testo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Crea un paragrafo per il testo in apice.
    superscript_paragraph = slides.Paragraph()

    # Crea una porzione di testo con testo normale.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Crea una porzione di testo con testo in apice.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Crea un paragrafo per il testo in pedice.
    subscript_paragraph = slides.Paragraph()

    # Crea una porzione di testo con testo normale.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Crea una porzione di testo con testo in pedice.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Aggiungi i paragrafi alla casella di testo.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso applicare apice/pedice in tabelle e altri contenitori, non solo nelle caselle di testo regolari?**

Sì. Puoi formattare il testo come apice o pedice all'interno di qualsiasi oggetto che espone un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) (incluse le celle delle tabelle). La formattazione si applica alle porzioni di testo all'interno di quel frame.

**Gli apici/pedici verranno conservati durante l'esportazione in PDF, HTML o immagini?**

Sì. Aspose.Slides conserva la formattazione di apice/pedice durante l'esportazione nei formati più comuni come [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/it/python-net/convert-powerpoint-to-html/) e [immagini raster](/slides/it/python-net/convert-powerpoint-to-png/) perché il motore di rendering rispetta la formattazione a livello di porzione.

**Posso combinare apice/pedice con collegamenti ipertestuali nello stesso frammento di testo?**

Sì. I [Hyperlinks](/slides/it/python-net/manage-hyperlinks/) sono assegnati a livello di porzione (frammento), quindi una porzione può avere contemporaneamente un collegamento ipertestuale e essere formattata come apice o pedice.