---
title: Gestire i caratteri nelle presentazioni usando Java
linktitle: Gestire i caratteri
type: docs
weight: 10
url: /it/java/manage-fonts/
keywords:
- gestire i caratteri
- proprietà dei caratteri
- paragrafo
- formattazione del testo
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Controlla i caratteri in Java con Aspose.Slides: incorpora, sostituisci e carica caratteri personalizzati per mantenere le presentazioni PPT, PPTX e ODP chiare, coerenti con il brand e uniformi."
---
## **Panoramica**

Aspose.Slides consente di gestire le proprietà dei caratteri nel testo di una presentazione direttamente dal codice. È possibile accedere al testo nelle diapositive tramite forme, riquadri di testo, paragrafi e porzioni, per poi applicare la formattazione al testo selezionato.

Questo articolo spiega come configurare le proprietà relative ai caratteri per il testo esistente in una presentazione, inclusi famiglia di caratteri, stili grassetto e corsivo, allineamento del paragrafo e colore del carattere. Mostra inoltre come creare una casella di testo, aggiungere testo al suo interno e impostare proprietà dei caratteri come famiglia, grassetto, corsivo, sottolineatura, dimensione e colore prima di salvare il risultato come file PPTX.

## **Gestire le proprietà relative ai caratteri**
{{% alert color="info" %}} 

Le presentazioni contengono generalmente sia testo che immagini. Il testo può essere formattato in vari modi, sia per evidenziare sezioni e parole specifiche sia per conformarsi a stili aziendali. La formattazione del testo aiuta gli utenti a variare l’aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides for Java per configurare le proprietà dei caratteri dei paragrafi di testo nelle diapositive.

{{% /alert %}} 

Per gestire le proprietà dei caratteri di un paragrafo usando Aspose.Slides for Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Ottieni il riferimento a una diapositiva utilizzando il suo indice.
3. Accedi alle forme [Placeholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/) nella diapositiva e esegui il cast a [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
4. Ottieni il [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) esposto da [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
5. Giustifica il paragrafo.
6. Accedi al testo [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) di un [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/).
7. Definisci il carattere usando [FontData](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontdata/) e imposta il **Font** della [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) di testo di conseguenza.
   1. Imposta il carattere in grassetto.
   1. Imposta il carattere in corsivo.
8. Imposta il colore del carattere usando il [FillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/fillformat/) esposto dall'oggetto [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
9. Salva la presentazione modificata in un file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito. Prende una presentazione senza formattazione e applica lo stile ai caratteri su una delle diapositive. Gli screenshot seguenti mostrano il file di input e come le sezioni di codice lo modificano. Il codice cambia il carattere, il colore e lo stile del carattere.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di input**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accedere a una diapositiva usando la sua posizione
	ISlide slide = pres.getSlides().get_Item(0);

	// Accedere al primo e al secondo placeholder nella diapositiva e fare il cast a AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accedere al primo Paragrafo
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Giustificare il paragrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accedere alla prima porzione
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definire nuovi caratteri
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Assegnare i nuovi caratteri alla porzione
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Impostare il carattere in grassetto
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Impostare il carattere in corsivo
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Impostare il colore del carattere
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Salvare il PPTX su disco
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Impostare le proprietà dei caratteri del testo**
{{% alert color="info" %}} 

Come indicato in **Gestire le proprietà relative ai caratteri**, una [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) viene utilizzata per contenere testo con uno stile di formattazione simile all'interno di un paragrafo. Questo articolo mostra come usare Aspose.Slides for Java per creare una casella di testo con del contenuto e poi definire un carattere specifico, oltre a varie altre proprietà della categoria famiglia di caratteri.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà dei caratteri del testo contenuto:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Ottieni il riferimento a una diapositiva utilizzando il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/) di tipo **Rectangle** alla diapositiva.
4. Rimuovi lo stile di riempimento associato al [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
5. Accedi al [TextFrame] del [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
6. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/).
7. Accedi all'oggetto [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/).
8. Definisci il carattere da utilizzare per la [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
9. Imposta altre proprietà del carattere come grassetto, corsivo, sottolineatura, colore e altezza usando le proprietà rilevanti esposte dall'oggetto [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
10. Scrivi la presentazione modificata in un file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà dei caratteri impostate da Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
	// Ottenere la prima diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Aggiungere un AutoShape di tipo Rettangolo
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Rimuovere eventuale stile di riempimento associato all'AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Accedere al TextFrame associato all'AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Accedere alla Portion associata al TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Impostare il Font per la Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Impostare la proprietà Grassetto del Font
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Impostare la proprietà Corsivo del Font
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Impostare la proprietà Sottolineato del Font
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Impostare l'Altezza del Font
	port.getPortionFormat().setFontHeight(25);
	
	// Impostare il colore del Font
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Salvare la presentazione su disco
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```