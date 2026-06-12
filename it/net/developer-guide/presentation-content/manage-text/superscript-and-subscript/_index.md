---
title: Gestisci apice e pedice nelle presentazioni in .NET
linktitle: Apice e Pedice
type: docs
weight: 80
url: /it/net/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungi apice
- aggiungi pedice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Domina apice e pedice in Aspose.Slides per .NET e migliora le tue presentazioni con una formattazione del testo professionale per il massimo impatto."
---
## **Panoramica**

Aspose.Slides for .NET offre funzionalità per integrare testo in apice e pedice nelle tue presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai come applicare senza sforzo gli stili di apice e pedice e garantire risultati professionali in ogni diapositiva.

## **Aggiungere testo in apice e pedice**

Puoi aggiungere testo in apice e pedice all'interno di qualsiasi paragrafo di una presentazione. Per farlo con Aspose.Slides, devi utilizzare la proprietà `Escapement` della classe [PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/portionformat/) .

Questa proprietà consente di impostare testo in apice o pedice, con valori che vanno da -100% (pedice) a 100% (apice).

Passaggi di implementazione:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) di tipo `Rectangle` alla diapositiva.
1. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) associato all'[IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).
1. Cancella i paragrafi esistenti.
1. Crea un nuovo [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) per il testo in apice e aggiungilo alla collezione di paragrafi dell'[ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/).
1. Crea un nuovo oggetto di porzione di testo.
1. Imposta la proprietà `Escapement` per la porzione di testo tra 0 e 100 per applicare l'apice (0 significa nessun apice).
1. Imposta del testo per la [Portion](https://reference.aspose.com/slides/it/net/aspose.slides/portion/) e aggiungilo alla collezione di porzioni del paragrafo.
1. Crea un altro [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) per il testo in pedice e aggiungilo alla collezione di paragrafi.
1. Crea un nuovo oggetto di porzione di testo.
1. Imposta la proprietà `Escapement` per la porzione di testo tra 0 e -100 per applicare il pedice (0 significa nessun pedice).
1. Imposta del testo per la [Portion](https://reference.aspose.com/slides/it/net/aspose.slides/portion/) e aggiungilo alla collezione di porzioni del paragrafo.
1. Salva la presentazione come file PPTX.

Il codice C# seguente implementa questi passaggi:

```c#
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Crea una casella di testo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Crea un paragrafo per il testo in apice.
    IParagraph superPar = new Paragraph();

    // Crea una porzione di testo con testo normale.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Crea una porzione di testo con apice.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Crea un paragrafo per il testo in pedice.
    IParagraph paragraph2 = new Paragraph();

    // Crea una porzione di testo con testo normale.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Crea una porzione di testo con pedice.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Aggiungi i paragrafi alla casella di testo.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Apice e Pedice](superscript_and_subscript.png)

## **FAQ**

**L'apice e il pedice verranno conservati durante l'esportazione in PDF o altri formati?**

Sì, Aspose.Slides per .NET conserva correttamente la formattazione di apice e pedice quando esporta le presentazioni in PDF, PPT/PPTX, immagini e altri formati supportati. La formattazione specializzata rimane intatta in tutti i file di output.

**L'apice e il pedice possono essere combinati con altri stili di formattazione come grassetto o corsivo?**

Sì, Aspose.Slides consente di mescolare vari stili di testo all'interno di una singola porzione di testo. È possibile abilitare grassetto, corsivo, sottolineatura e applicare simultaneamente apice o pedice configurando le proprietà corrispondenti in [PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/portionformat/).

**La formattazione di apice e pedice funziona per il testo all'interno di tabelle, grafici o SmartArt?**

Sì, Aspose.Slides per .NET supporta la formattazione nella maggior parte degli oggetti, incluse tabelle e elementi di grafico. Quando si lavora con SmartArt, è necessario accedere agli elementi appropriati (come [SmartArtNode](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartartnode/)) e ai loro contenitori di testo, per poi configurare le proprietà di [PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/portionformat/) in modo simile.