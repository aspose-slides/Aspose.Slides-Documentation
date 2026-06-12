---
title: Gestire apice e pedice nelle presentazioni su Android
linktitle: Apice e pedice
type: docs
weight: 80
url: /it/androidjava/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungere apice
- aggiungere pedice
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Padroneggia apice e pedice in Aspose.Slides per Android tramite Java e migliora le tue presentazioni con una formattazione del testo professionale per un impatto massimo."
---
## **Panoramica**

Aspose.Slides offre funzionalità per integrare testo in apice e pedice nelle tue presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai come applicare senza sforzo gli stili di apice e pedice e garantire risultati professionali in ogni diapositiva.

## **Gestire testo in apice e pedice**
È possibile aggiungere testo in apice o pedice all'interno di qualsiasi porzione di paragrafo. Per aggiungere testo in apice o pedice in un frame di testo di Aspose.Slides è necessario utilizzare il metodo [**setEscapement**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) della classe [PortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PortionFormat).

Questa proprietà restituisce o imposta il testo in apice o pedice (valore da -100 % (pedice) a 100 % (apice)). Per esempio:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Ottenere il riferimento di una diapositiva utilizzando il suo Index.
- Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) di tipo [Rectangle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Accedere al [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrame) associato al [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape).
- Cancellare i paragrafi esistenti
- Creare un nuovo oggetto paragrafo per contenere testo in apice e aggiungerlo alla [IParagraphs collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) del [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrame).
- Creare un nuovo oggetto portion
- Impostare la proprietà Escapement per la portion tra 0 e 100 per aggiungere apice. (0 significa nessun apice)
- Impostare del testo per [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Portion) e poi aggiungerlo nella collezione di portion del paragrafo.
- Creare un nuovo oggetto paragrafo per contenere testo in pedice e aggiungerlo alla IParagraphs collection del ITextFrame.
- Creare un nuovo oggetto portion
- Impostare la proprietà Escapement per la portion tra 0 e -100 per aggiungere pedice. (0 significa nessun pedice)
- Impostare del testo per [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Portion) e poi aggiungerlo nella collezione di portion del paragrafo.
- Salvare la presentazione come file PPTX.

L'implementazione dei passaggi sopra descritti è mostrata di seguito.

```java
// Istanziare una classe Presentation che rappresenta un PPTX
Presentation pres = new Presentation();
try {
    // Recuperare la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Creare una casella di testo
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Creare un paragrafo per il testo in apice
    IParagraph superPar = new Paragraph();

    // Creare una porzione con testo normale
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Creare una porzione con testo in apice
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Creare un paragrafo per il testo in pedice
    IParagraph paragraph2 = new Paragraph();

    // Creare una porzione con testo normale
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Creare una porzione con testo in pedice
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Aggiungere i paragrafi alla casella di testo
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Il testo in apice e pedice verrà conservato durante l'esportazione in PDF o altri formati?**

Sì, Aspose.Slides conserva correttamente la formattazione di apice e pedice durante l'esportazione delle presentazioni in PDF, PPT/PPTX, immagini e altri formati supportati. La formattazione specializzata rimane intatta in tutti i file di output.

**Il testo in apice e pedice può essere combinato con altri stili di formattazione come grassetto o corsivo?**

Sì, Aspose.Slides consente di mescolare vari stili di testo all'interno di una singola portion. È possibile abilitare grassetto, corsivo, sottolineatura e applicare contemporaneamente apice o pedice configurando le proprietà corrispondenti in [PortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portionformat/).

**La formattazione di apice e pedice funziona per il testo all'interno di tabelle, grafici o SmartArt?**

Sì, Aspose.Slides supporta la formattazione nella maggior parte degli oggetti, incluse tabelle e elementi di grafico. Quando si lavora con SmartArt, è necessario accedere agli elementi appropriati (come [SmartArtNode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/smartartnode/)) e ai loro contenitori di testo, quindi configurare le proprietà di [PortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portionformat/) in modo simile.