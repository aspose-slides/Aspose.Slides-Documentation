---
title: Gestire apice e pedice nelle presentazioni usando JavaScript
linktitle: Apice e Pedice
type: docs
weight: 80
url: /it/nodejs-java/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungi apice
- aggiungi pedice
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Padroneggia apice e pedice in Aspose.Slides per Node.js tramite Java e migliora le tue presentazioni con una formattazione testuale professionale per massimizzare l'impatto."
---
## **Panoramica**

Aspose.Slides fornisce funzionalità per integrare testo in apice e pedice nelle tue presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai come applicare in modo fluido gli stili di apice e pedice e garantire risultati professionali in ogni diapositiva.

## **Gestire il Testo in Apice e Pedice**

È possibile aggiungere testo in apice e pedice all'interno di qualsiasi porzione di paragrafo. Per aggiungere testo in Apice o Pedice nel riquadro di testo di Aspose.Slides è necessario utilizzare il metodo [**setEscapement**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) della classe [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PortionFormat).

Questa proprietà restituisce o imposta il testo in apice o pedice (valore da -100 % (pedice) a 100 % (apice)). Per esempio:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) di tipo [Rectangle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame) associato all'[AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape).
- Cancellare i paragrafi esistenti.
- Creare un nuovo oggetto paragrafo per contenere il testo in apice e aggiungerlo alla [Paragraphs collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame#getParagraphs--) del [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame).
- Creare un nuovo oggetto porzione.
- Impostare la proprietà Escapement per la porzione tra 0 e 100 per aggiungere l'apice. (0 significa nessun apice)
- Impostare del testo per la [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Portion) e quindi aggiungerla alla raccolta di porzioni del paragrafo.
- Creare un nuovo oggetto paragrafo per contenere il testo in pedice e aggiungerlo alla raccolta IParagraphs del ITextFrame.
- Creare un nuovo oggetto porzione.
- Impostare la proprietà Escapement per la porzione tra 0 e -100 per aggiungere il pedice. (0 significa nessun pedice)
- Impostare del testo per la [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Portion) e quindi aggiungerla alla raccolta di porzioni del paragrafo.
- Salvare la presentazione come file PPTX.

L'implementazione dei passaggi sopra è fornita di seguito.

```javascript
// Istanzia una classe Presentation che rappresenta un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Crea una casella di testo
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Crea un paragrafo per il testo in apice
    var superPar = new aspose.slides.Paragraph();
    // Crea una porzione con testo normale
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Crea una porzione con testo in apice
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Crea un paragrafo per il testo in pedice
    var paragraph2 = new aspose.slides.Paragraph();
    // Crea una porzione con testo normale
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Crea una porzione con testo in pedice
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Aggiungi i paragrafi alla casella di testo
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Il testo in apice e pedice verrà conservato durante l'esportazione in PDF o altri formati?**

Sì, Aspose.Slides conserva correttamente la formattazione in apice e pedice quando si esportano le presentazioni in PDF, PPT/PPTX, immagini e altri formati supportati. La formattazione specializzata rimane intatta in tutti i file di output.

**È possibile combinare apice e pedice con altri stili di formattazione come grassetto o corsivo?**

Sì, Aspose.Slides consente di mescolare vari stili di testo all'interno di una singola porzione. È possibile attivare grassetto, corsivo, sottolineatura e contemporaneamente applicare apice o pedice configurando le proprietà corrispondenti in [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/).

**La formattazione in apice e pedice funziona per il testo all'interno di tabelle, grafici o SmartArt?**

Sì, Aspose.Slides supporta la formattazione nella maggior parte degli oggetti, incluse tabelle ed elementi di grafici. Quando si lavora con SmartArt, è necessario accedere agli elementi appropriati (come [SmartArtNode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartnode/)) e ai loro contenitori di testo, quindi configurare le proprietà di [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/) in modo analogo.