---
title: Gestisci i caratteri nelle presentazioni con Java
linktitle: Gestisci i caratteri
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

Aspose.Slides consente di gestire le proprietà dei caratteri nel testo delle presentazioni direttamente dal proprio codice. È possibile accedere al testo nelle diapositive tramite forme, riquadri di testo, paragrafi e porzioni, e quindi applicare la formattazione al testo selezionato.

Questo articolo spiega come configurare le proprietà dei caratteri per il testo esistente in una presentazione, inclusi famiglia del carattere, stili grassetto e corsivo, allineamento del paragrafo e colore del carattere. Mostra inoltre come creare una casella di testo, aggiungere testo al suo interno e impostare le proprietà del carattere come famiglia, grassetto, corsivo, sottolineatura, dimensione e colore prima di salvare il risultato come file PPTX.

## **Gestire le proprietà correlate ai caratteri**
{{% alert color="primary" %}} 

Le presentazioni contengono solitamente sia testo che immagini. Il testo può essere formattato in vari modi, sia per evidenziare sezioni e parole specifiche sia per conformarsi agli stili aziendali. La formattazione del testo aiuta gli utenti a variare l'aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides for Java per configurare le proprietà dei caratteri dei paragrafi di testo nelle diapositive.

{{% /alert %}} 

Per gestire le proprietà dei caratteri di un paragrafo usando Aspose.Slides for Java:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottenere il riferimento di una diapositiva utilizzando il suo indice.
1. Accedere alle forme [Placeholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/) nella diapositiva e convertirle in [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
1. Ottenere il [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) esposto da [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
1. Giustificare il paragrafo.
1. Accedere al testo del [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) tramite la [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
1. Definire il carattere usando [FontData](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontdata/) e impostare il **Font** della [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) di conseguenza.
   1. Impostare il carattere in grassetto.
   1. Impostare il carattere in corsivo.
1. Impostare il colore del carattere usando il [FillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/fillformat/) esposto dall'oggetto [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
1. Salvare la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito. Prende una presentazione non formattata e applica la formattazione dei caratteri a una delle diapositive. Gli screenshot seguenti mostrano il file di input e come le parti di codice lo modificano. Il codice cambia il carattere, il colore e lo stile del carattere.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di input**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```java
// Istanzia un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accesso a una diapositiva usando la sua posizione
	ISlide slide = pres.getSlides().get_Item(0);

	// Accesso al primo e al secondo segnaposto nella diapositiva e casting a AutoShape
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

	// Definisci nuovi caratteri
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Assegna i nuovi caratteri alla porzione
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Imposta il carattere in grassetto
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Imposta il carattere in corsivo
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Imposta il colore del carattere
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

## **Impostare le proprietà del carattere del testo**
{{% alert color="primary" %}} 

Come menzionato in **Gestire le proprietà correlate ai caratteri**, una [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) viene utilizzata per contenere testo con uno stile di formattazione simile all'interno di un paragrafo. Questo articolo mostra come usare Aspose.Slides for Java per creare una casella di testo con del contenuto e quindi definire un carattere specifico e varie altre proprietà della categoria famiglia del carattere.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà del carattere del testo al suo interno:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottenere il riferimento di una diapositiva utilizzando il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/) di tipo **Rectangle** alla diapositiva.
1. Rimuovere lo stile di riempimento associato al [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
1. Accedere al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) dell'[AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/).
1. Aggiungere del testo al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/).
1. Accedere all'oggetto [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/).
1. Definire il carattere da usare per la [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
1. Impostare altre proprietà del carattere come grassetto, corsivo, sottolineatura, colore e altezza usando le proprietà rilevanti esposte dall'oggetto [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/).
1. Scrivere la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà del carattere impostate da Aspose.Slides for Java**|

```java
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
	
	// Imposta la proprietà Grassetto del Font
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Imposta la proprietà Corsivo del Font
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Imposta la proprietà Sottolineatura del Font
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Imposta l'Altezza del Font
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