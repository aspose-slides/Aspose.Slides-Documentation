---
title: Gestire i caratteri nelle presentazioni su Android
linktitle: Gestire i caratteri
type: docs
weight: 10
url: /it/androidjava/manage-fonts/
keywords:
- gestire i caratteri
- proprietà dei caratteri
- paragrafo
- formattazione del testo
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Controlla i caratteri in Java con Aspose.Slides per Android: incorpora, sostituisci e carica caratteri personalizzati per mantenere le presentazioni PPT, PPTX e ODP chiare, coerenti con il brand e consistenti."
---
## **Panoramica**

Aspose.Slides consente di gestire le proprietà dei caratteri nel testo di una presentazione direttamente dal codice. È possibile accedere al testo nelle diapositive tramite forme, riquadri di testo, paragrafi e porzioni, quindi applicare formattazioni al testo selezionato.

Questo articolo spiega come configurare le proprietà dei caratteri per il testo esistente in una presentazione, includendo famiglia di caratteri, stili grassetto e corsivo, allineamento del paragrafo e colore del carattere. Mostra inoltre come creare una casella di testo, aggiungere del testo al suo interno e impostare proprietà del carattere come famiglia, grassetto, corsivo, sottolineato, dimensione e colore prima di salvare il risultato come file PPTX.

## **Gestire le proprietà dei caratteri**
{{% alert color="primary" %}} 

Le presentazioni contengono solitamente sia testo sia immagini. Il testo può essere formattato in vari modi, sia per evidenziare sezioni e parole specifiche sia per conformarsi agli stili aziendali. La formattazione del testo aiuta gli utenti a variare l'aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides per Android tramite Java per configurare le proprietà dei caratteri dei paragrafi di testo nelle diapositive.

{{% /alert %}} 

Per gestire le proprietà dei caratteri di un paragrafo usando Aspose.Slides per Android tramite Java:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottenere un riferimento a una diapositiva utilizzando il suo indice.
1. Accedere alle forme [Placeholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/) nella diapositiva e convertirle in [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Recuperare il [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) fornito da [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Giustificare il paragrafo.
1. Accedere al testo del [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) tramite la sua [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Definire il carattere usando [FontData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontdata/) e impostare il **Font** della [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) di conseguenza.
   1. Impostare il carattere in grassetto.
   1. Impostare il carattere in corsivo.
1. Impostare il colore del carattere usando il [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/) esposto dall'oggetto [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Salvare la presentazione modificata in un file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito. Prende una presentazione grezza e formatta i caratteri su una delle diapositive. Gli screenshot seguenti mostrano il file di input e come i frammenti di codice lo modificano. Il codice cambia il carattere, il colore e lo stile del carattere.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di input**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```java
// Istanziare un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accesso a una diapositiva usando la sua posizione
	ISlide slide = pres.getSlides().get_Item(0);

	// Accesso al primo e al secondo placeholder nella diapositiva e casting a AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accesso al primo Paragrafo
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Giustificare il paragrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accesso alla prima porzione
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definire nuovi caratteri
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Assegnare nuovi caratteri alla porzione
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Impostare il carattere in Grassetto
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Impostare il carattere in Corsivo
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

## **Impostare le proprietà del carattere del testo**
{{% alert color="primary" %}} 

Come indicato in **Gestire le proprietà dei caratteri**, una [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) viene utilizzata per contenere testo con uno stile di formattazione simile all'interno di un paragrafo. Questo articolo mostra come utilizzare Aspose.Slides per Android tramite Java per creare una casella di testo con del testo e quindi definire un carattere specifico e varie altre proprietà della famiglia di caratteri.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà del carattere del testo al suo interno:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottenere il riferimento a una diapositiva usando il suo indice.
1. Aggiungere alla diapositiva un [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) di tipo **Rectangle**.
1. Rimuovere lo stile di riempimento associato al [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Accedere al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) del [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/).
1. Aggiungere del testo al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/).
1. Accedere all'oggetto [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/).
1. Definire il carattere da utilizzare per la [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Impostare altre proprietà del carattere come grassetto, corsivo, sottolineato, colore e altezza usando le relative proprietà esposte dall'oggetto [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/).
1. Scrivere la presentazione modificata in un file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà del carattere impostate da Aspose.Slides per Android tramite Java**|

```java
// Istanziare un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
	// Ottieni la prima diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Aggiungi un AutoShape di tipo Rettangolo
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