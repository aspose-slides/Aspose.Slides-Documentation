---
title: Gestire i font nelle presentazioni con PHP
linktitle: Gestire i font
type: docs
weight: 10
url: /it/php-java/manage-fonts/
keywords:
- gestire i font
- proprietà del font
- paragrafo
- formattazione del testo
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Controlla i font in PHP con Aspose.Slides: incorpora, sostituisci e carica font personalizzati per mantenere le presentazioni PPT, PPTX e ODP chiare, coerenti con il branding e costanti."
---
## **Gestire le proprietà dei caratteri**
{{% alert color="primary" %}} 

Le presentazioni contengono di solito sia testo che immagini. Il testo può essere formattato in vari modi, sia per evidenziare sezioni e parole specifiche sia per conformarsi a stili aziendali. La formattazione del testo aiuta gli utenti a variare l’aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides for PHP via Java per configurare le proprietà dei caratteri dei paragrafi di testo sulle diapositive.

{{% /alert %}} 

Per gestire le proprietà dei caratteri di un paragrafo usando Aspose.Slides for PHP via Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Accedi alle forme [Placeholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholder/) nella diapositiva e castale a [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
1. Recupera il [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) esposto da [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
1. Allinea il paragrafo giustificandolo.
1. Accedi al [Portion] di testo di un [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/).
1. Definisci il carattere usando [FontData](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontdata/) e imposta il **Font** del testo [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) di conseguenza.
   1. Imposta il carattere in grassetto.
   1. Imposta il carattere in corsivo.
1. Imposta il colore del carattere usando il [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/) esposto dall'oggetto [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/).
1. Salva la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito. Prende una presentazione non formattata e applica le modifiche ai font su una delle diapositive. Gli screenshot che seguono mostrano il file di input e come le sezioni di codice lo modificano. Il codice cambia il font, il colore e lo stile del font.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di input**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```php
  # Instanziare un oggetto Presentation che rappresenta un file PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accedere a una diapositiva usando la sua posizione
    $slide = $pres->getSlides()->get_Item(0);
    # Accedere al primo e al secondo placeholder nella diapositiva e castarlo come AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accedere al primo Paragrafo
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Giustificare il paragrafo
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Accedere alla prima porzione
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definire nuovi font
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Assegnare i nuovi font alla porzione
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Impostare il font in Grassetto
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Impostare il font in Corsivo
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Impostare il colore del font
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Salvare il PPTX su disco
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare le proprietà dei caratteri del testo**
{{% alert color="primary" %}} 

Come menzionato in **Gestire le proprietà dei caratteri**, un [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) viene utilizzato per contenere testo con uno stile di formattazione simile in un paragrafo. Questo articolo mostra come utilizzare Aspose.Slides for PHP via Java per creare una casella di testo con del testo e poi definire un carattere specifico, nonché varie altre proprietà della famiglia di caratteri.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà dei caratteri del suo contenuto:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) di tipo **Rectangle** alla diapositiva.
1. Rimuovi lo stile di riempimento associato al [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
1. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) del [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
1. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).
1. Accedi all'oggetto [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).
1. Definisci il carattere da utilizzare per il [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/).
1. Imposta altre proprietà del carattere come grassetto, corsivo, sottolineato, colore e altezza usando le relative proprietà esposte dall'oggetto [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/).
1. Scrivi la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà dei caratteri impostate da Aspose.Slides for PHP via Java**|

```php
  # Instanziare un oggetto Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Ottenere la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungere un AutoShape di tipo Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Rimuovere qualsiasi stile di riempimento associato all'AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accedere al TextFrame associato all'AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Accedere alla Portion associata al TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Impostare il Font per la Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Impostare la proprietà Grassetto del Font
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Impostare la proprietà Corsivo del Font
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Impostare la proprietà Sottolineato del Font
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Impostare l'Altezza del Font
    $port->getPortionFormat()->setFontHeight(25);
    # Impostare il colore del Font
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Salvare la presentazione su disco
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```