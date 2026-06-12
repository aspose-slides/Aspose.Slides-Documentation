---
title: "Gestisci i caratteri nelle presentazioni usando JavaScript"
linktitle: "Gestisci i caratteri"
type: docs
weight: 10
url: /it/nodejs-java/manage-fonts/
keywords:
  - "gestire i caratteri"
  - "proprietà dei caratteri"
  - "paragrafo"
  - "formattazione del testo"
  - "PowerPoint"
  - "OpenDocument"
  - "presentazione"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "Controlla i caratteri con Aspose.Slides per Node.js via Java: incorpora, sostituisci e carica caratteri personalizzati per mantenere le presentazioni PPT, PPTX e ODP chiare e coerenti."
---
## **Introduzione**

Le presentazioni di solito contengono sia testo che immagini. Il testo può essere formattato in diversi modi, sia per evidenziare specifiche sezioni e parole sia per conformarsi a stili aziendali. La formattazione del testo aiuta gli utenti a variare l’aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides per Node.js via Java per configurare le proprietà del carattere dei paragrafi di testo sulle diapositive.

## **Gestire le proprietà del carattere correlate**

Per gestire le proprietà del carattere di un paragrafo usando Aspose.Slides per Node.js via Java:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento a una diapositiva usando il suo indice.
1. Accedi alle forme [Placeholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholder/) nella diapositiva e effettuane il cast a [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
1. Recupera il [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) esposto da [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
1. Giustifica il paragrafo.
1. Accedi al [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) di testo di un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/).
1. Definisci il carattere usando [FontData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontdata/) e imposta il **Font** del testo del [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) di conseguenza.
   1. Imposta il carattere in grassetto.
   1. Imposta il carattere in corsivo.
1. Imposta il colore del carattere usando il [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/) esposto dall’oggetto [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/).
1. Salva la presentazione modificata in un file PPTX.

L’implementazione dei passaggi sopra è fornita di seguito. Prende una presentazione non formattata e applica la formattazione dei caratteri a una delle diapositive. Gli screenshot seguenti mostrano il file di ingresso e come le sezioni di codice lo modificano. Il codice cambia il carattere, il colore e lo stile del carattere.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di ingresso**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```javascript
// Instanzia un oggetto Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accesso a una diapositiva usando la sua posizione
    var slide = pres.getSlides().get_Item(0);
    // Accesso al primo e al secondo placeholder nella diapositiva e cast a AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Accesso al primo Paragrafo
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Giustifica il paragrafo
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Accesso alla prima porzione
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definisci nuovi caratteri
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Assegna nuovi caratteri alla porzione
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Imposta il carattere in grassetto
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Imposta il carattere in corsivo
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Imposta il colore del carattere
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Salva il PPTX su disco
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta le proprietà del carattere del testo**
{{% alert color="primary" %}} 

Come menzionato in **Managing Font Related Properties**, un [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) viene usato per contenere testo con uno stesso stile di formattazione in un paragrafo. Questo articolo mostra come utilizzare Aspose.Slides per Node.js via Java per creare una casella di testo con del testo e poi definire un carattere particolare, nonché varie altre proprietà della famiglia di caratteri.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà del carattere del testo al suo interno:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento a una diapositiva usando il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) di tipo **Rectangle** alla diapositiva.
1. Rimuovi lo stile di riempimento associato all’[AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
1. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dell’[AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
1. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
1. Accedi all’oggetto [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
1. Definisci il carattere da utilizzare per il [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/).
1. Imposta altre proprietà del carattere come grassetto, corsivo, sottolineatura, colore e altezza usando le proprietà pertinenti esposte dall’oggetto [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/).
1. Scrivi la presentazione modificata in un file PPTX.

L’implementazione dei passaggi sopra è fornita di seguito.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà del carattere impostate da Aspose.Slides per Node.js via Java**|

```javascript
// Instanzia un oggetto Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi un AutoShape di tipo Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Rimuovi qualsiasi stile di riempimento associato al AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accedi al TextFrame associato al AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Accedi alla Portion associata al TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Imposta il Font per la Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Imposta la proprietà Bold del Font
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Imposta la proprietà Italic del Font
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Imposta la proprietà Underline del Font
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Imposta l'altezza del Font
    port.getPortionFormat().setFontHeight(25);
    // Imposta il colore del Font
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Salva la presentazione su disco
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```