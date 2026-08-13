---
title: Gestisci i font nelle presentazioni su Android
linktitle: Gestisci i font
type: docs
weight: 10
url: /it/androidjava/manage-fonts/
keywords:
- gestire i font
- proprietà dei font
- paragrafo
- formattazione del testo
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Controlla i font in Java con Aspose.Slides per Android: incorpora, sostituisci e carica font personalizzati per mantenere le presentazioni PPT, PPTX e ODP chiare, sicure per il brand e coerenti."
---
## **Panoramica**

Aspose.Slides ti consente di gestire le proprietà dei caratteri nel testo di una presentazione direttamente dal tuo codice. Puoi accedere al testo nelle diapositive tramite forme, riquadri di testo, paragrafi e porzioni, e quindi applicare la formattazione al testo selezionato.

Questo articolo spiega come configurare le proprietà correlate ai caratteri per il testo esistente in una presentazione, includendo famiglia di caratteri, stili grassetto e corsivo, allineamento del paragrafo e colore del carattere. Mostra inoltre come creare una casella di testo, aggiungere del testo al suo interno e impostare le proprietà del carattere come famiglia, grassetto, corsivo, sottolineatura, dimensione e colore prima di salvare il risultato come file PPTX.

## **Gestire le proprietà dei caratteri**
{{% alert color="info" %}} 

Le presentazioni contengono solitamente sia testo che immagini. Il testo può essere formattato in diversi modi, sia per evidenziare sezioni e parole specifiche sia per conformarsi agli stili aziendali. La formattazione del testo aiuta gli utenti a variare l’aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides per Android via Java per configurare le proprietà dei caratteri dei paragrafi di testo sulle diapositive.

{{% /alert %}} 

Per gestire le proprietà dei caratteri di un paragrafo usando Aspose.Slides per Android via Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento a una diapositiva usando il suo indice.
1. Accedi alle forme [Placeholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/) nella diapositiva e castale a [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Recupera il [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) esposto da [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Giustifica il paragrafo.
1. Accedi al [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) di testo di un [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/).
1. Definisci il carattere usando [FontData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontdata/) e imposta il **Font** del [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) di conseguenza.
   1. Imposta il carattere in grassetto.
   1. Imposta il carattere in corsivo.
1. Imposta il colore del carattere usando il [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/) esposto dall'oggetto [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Salva la presentazione modificata in un file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito. Prende una presentazione non modificata e formatta i caratteri su una delle diapositive. Gli screenshot seguenti mostrano il file di input e come i frammenti di codice lo modificano. Il codice cambia il carattere, il colore e lo stile del carattere.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di input**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanzia un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accesso a una diapositiva usando la sua posizione
	ISlide slide = pres.getSlides().get_Item(0);

	// Accesso al primo e al secondo segnaposto nella diapositiva e cast a AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accesso al primo Paragrafo
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Giustifica il paragrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accesso alla prima porzione
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definisci nuovi font
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Assegna i nuovi font alla porzione
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Imposta il font in grassetto
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Imposta il font in corsivo
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Imposta il colore del font
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Salva il PPTX su disco
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Impostare le proprietà dei caratteri del testo**
{{% alert color="info" %}} 

Come indicato in **Gestire le proprietà dei caratteri**, un [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) viene usato per contenere testo con uno stile di formattazione simile in un paragrafo. Questo articolo mostra come utilizzare Aspose.Slides per Android via Java per creare una casella di testo con del contenuto testuale e poi definire un carattere specifico, oltre a varie altre proprietà della categoria famiglia di caratteri.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà dei caratteri del testo al suo interno:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) di tipo **Rectangle** alla diapositiva.
1. Rimuovi lo stile di riempimento associato al [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Accedi al [TextFrame] dell'[AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/).
1. Accedi all'oggetto [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/).
1. Definisci il carattere da utilizzare per il [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Imposta altre proprietà del carattere come grassetto, corsivo, sottolineatura, colore e altezza usando le proprietà rilevanti esposte dall'oggetto [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Scrivi la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra è fornita di seguito.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà dei caratteri impostate da Aspose.Slides per Android via Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanzia un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
	// Ottieni la prima diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Aggiungi un AutoShape di tipo Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Rimuovi qualsiasi stile di riempimento associato all'AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Accedi al TextFrame associato all'AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Accedi alla Portion associata al TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Imposta il Font per la Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Imposta la proprietà Bold del Font
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Imposta la proprietà Italic del Font
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Imposta la proprietà Underline del Font
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Imposta l'altezza del Font
	port.getPortionFormat().setFontHeight(25);
	
	// Imposta il colore del Font
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Salva la presentazione su disco
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```