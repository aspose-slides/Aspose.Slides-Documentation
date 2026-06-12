---
title: Gestisci Apice e Pedice nelle Presentazioni con PHP
linktitle: Apice e Pedice
type: docs
weight: 80
url: /it/php-java/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungi apice
- aggiungi pedice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Padroneggia apice e pedice in Aspose.Slides per PHP via Java e migliora le tue presentazioni con una formattazione del testo professionale per il massimo impatto."
---
## **Panoramica**

Aspose.Slides offre funzionalità per integrare testo in apice e pedice nelle tue presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai come applicare senza soluzione di continuità gli stili di apice e pedice e garantire risultati professionali in ogni diapositiva.

## **Gestire il Testo in Apice e Pedice**
È possibile aggiungere testo in apice e pedice all'interno di qualsiasi porzione di paragrafo. Per aggiungere testo in Apice o Pedice in un frame di testo Aspose.Slides è necessario usare il metodo [**setEscapement**](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setEscapement) della classe [PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/PortionFormat).

Questa proprietà restituisce o imposta il testo in apice o pedice (valore da -100% (pedice) a 100% (apice)). Per esempio:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Ottenere il riferimento di una diapositiva usando il suo Index.
- Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) di tipo [Rectangle](https://reference.aspose.com/slides/it/php-java/aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) associato al [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
- Cancellare i paragrafi esistenti
- Creare un nuovo oggetto paragrafo per contenere il testo in apice e aggiungerlo alla collezione IParagraphs del [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).
- Creare un nuovo oggetto portion
- Impostare la proprietà Escapement per la portion tra 0 e 100 per aggiungere l'apice. (0 significa nessun apice)
- Impostare del testo per [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/Portion) e quindi aggiungerlo alla collezione portion del paragrafo.
- Creare un nuovo oggetto paragrafo per contenere il testo in pedice e aggiungerlo alla collezione IParagraphs del ITextFrame.
- Creare un nuovo oggetto portion
- Impostare la proprietà Escapement per la portion tra 0 e -100 per aggiungere il pedice. (0 significa nessun pedice)
- Impostare del testo per [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/Portion) e quindi aggiungerlo alla collezione portion del paragrafo.
- Salvare la presentazione come file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito.

```php
  # Instanzia una classe Presentation che rappresenta un PPTX
  $pres = new Presentation();
  try {
    # Ottieni la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Crea una casella di testo
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Crea un paragrafo per il testo in apice
    $superPar = new Paragraph();
    # Crea una porzione con testo normale
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Crea una porzione con testo in apice
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Crea un paragrafo per il testo in pedice
    $paragraph2 = new Paragraph();
    # Crea una porzione con testo normale
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Crea una porzione con testo in pedice
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Aggiungi i paragrafi alla casella di testo
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**L'apice e il pedice verranno conservati durante l'esportazione in PDF o altri formati?**

Sì, Aspose.Slides conserva correttamente la formattazione di apice e pedice durante l'esportazione delle presentazioni in PDF, PPT/PPTX, immagini e altri formati supportati. La formattazione specializzata rimane intatta in tutti i file di output.

**L'apice e il pedice possono essere combinati con altri stili di formattazione come grassetto o corsivo?**

Sì, Aspose.Slides consente di mescolare vari stili di testo all'interno di una singola portion di testo. È possibile abilitare grassetto, corsivo, sottolineatura e applicare contemporaneamente apice o pedice configurando le proprietà corrispondenti in [PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/).

**La formattazione di apice e pedice funziona per il testo all'interno di tabelle, grafici o SmartArt?**

Sì, Aspose.Slides supporta la formattazione nella maggior parte degli oggetti, incluse tabelle e elementi di grafico. Quando si lavora con SmartArt, è necessario accedere agli elementi appropriati (come [SmartArtNode](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/)) e ai loro contenitori di testo, quindi configurare le proprietà di [PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/) in modo analogo.