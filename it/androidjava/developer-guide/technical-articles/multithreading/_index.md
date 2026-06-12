---
title: Multithreading in Aspose.Slides per Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /it/androidjava/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per Android via Java potenzia l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazioni efficienti."
---
## **Introduzione**

Mentre il lavoro parallelo con le presentazioni è possibile (oltre a parsing/caricamento/clonazione) e tutto procede bene (la maggior parte delle volte), c'è una piccola possibilità che si ottengano risultati errati quando si utilizza la libreria in più thread.

Raccomandiamo fermamente di **non** utilizzare un'unica istanza di [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) in un ambiente multithread, poiché potrebbe causare errori o guasti imprevedibili difficili da rilevare.

Non è **sicuro** caricare, salvare e/o clonare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) in più thread. Tali operazioni non sono **supportate**. Se è necessario eseguire queste attività, è necessario parallelizzare le operazioni usando diversi processi a thread singolo — e ciascuno di questi processi deve utilizzare la propria istanza di presentazione.

## **Converti le Diapositive della Presentazione in Immagini in Parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare una singola istanza di `Presentation` in più thread, suddividiamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, utilizzando ciascuna presentazione in un thread separato. L'esempio di codice seguente mostra come fare.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Estrai la diapositiva i in una presentazione separata.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Converti la diapositiva in un'immagine in un'attività separata.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Attendi che tutte le attività siano completate.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **FAQ**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente eseguirla una sola volta per **processo/domain dell'applicazione** prima che i **thread** inizino. Se la [configurazione della licenza](/slides/it/androidjava/licensing/) può essere invocata contemporaneamente (ad esempio durante l'inizializzazione lazy), sincronizza quella chiamata perché il metodo di configurazione della licenza stesso non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra thread?**

Passare oggetti di presentazione "live" tra thread non è consigliato: usa istanze indipendenti per thread o precrea presentazioni/container di diapositive separati per ciascun thread. Questo approccio segue la raccomandazione generale di non condividere un'unica istanza di presentazione tra thread.

**È sicuro parallelizzare l'esportazione verso formati diversi (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza di `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività tipicamente si parallelizzano correttamente; evita oggetti di presentazione condivisi e flussi I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializza tutte le [impostazioni dei font](/slides/it/androidjava/powerpoint-fonts/) globali prima di avviare i thread e non modificarle durante il lavoro parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.