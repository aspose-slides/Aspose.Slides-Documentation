---
title: Clona diapositive della presentazione in Python
linktitle: Clona diapositive
type: docs
weight: 35
url: /it/python-java/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per Python via Java. Segui i nostri chiari esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di realizzare una copia esatta o una replica di qualcosa. Aspose.Slides per Python via Java consente anche di creare una copia o un clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione delle diapositive crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diversi modi possibili per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno di una presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona insieme alla sua diapositiva master in un'altra presentazione.

In Aspose.Slides for Python via Java, la raccolta di diapositive (una raccolta di [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) oggetti) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) e [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone) per eseguire i tipi di clonazione diapositive sopra descritti.

## **Clona una diapositiva alla fine di una presentazione**

Se desideri clonare una diapositiva e quindi usarla nello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) facendo riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
3. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone).
4. Scrivi il file di presentazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanzia la classe Presentation che rappresenta un file di presentazione
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Clona la diapositiva desiderata alla fine della raccolta di diapositive nella stessa presentazione
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Scrivi la presentazione modificata su disco
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**

Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla raccolta di diapositive restituita da [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) sull'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
3. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone).
4. Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata all'indice 1 – posizione 2 – della presentazione) all'indice 2 – posizione 3 – della presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanzia la classe Presentation che rappresenta un file di presentazione
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Ottieni la raccolta di diapositive nella presentazione
    slides = presentation.getSlides()

    # Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Scrivi la presentazione modificata su disco
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clona una diapositiva alla fine di un'altra presentazione**

Se è necessario clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che contiene la presentazione da cui la diapositiva sarà clonata.
2. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che contiene la presentazione di destinazione a cui la diapositiva sarà aggiunta.
3. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) facendo riferimento alla raccolta di diapositive restituita da [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) sull'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) della presentazione di destinazione.
4. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) e passa la diapositiva dalla presentazione di origine come parametro al metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone).
5. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dall'indice 0 della presentazione di origine) alla fine della presentazione di destinazione.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

    # Instanzia la classe Presentation per caricare il file di presentazione sorgente
    source_presentation = Presentation("CloneAtEndOfAnother.pptx")
    try:
        # Instanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
        destination_presentation = Presentation()
        try:
            # Clona la diapositiva desiderata dalla presentazione sorgente alla fine della raccolta di diapositive nella presentazione di destinazione
            slides = destination_presentation.getSlides()

            slides.addClone(source_presentation.getSlides().get_Item(0))

            # Scrivi la presentazione di destinazione su disco
            destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
        finally:
            destination_presentation.dispose()
    finally:
        source_presentation.dispose()
```

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**

Se è necessario clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che contiene la presentazione sorgente da cui la diapositiva sarà clonata.
2. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che contiene la presentazione a cui la diapositiva sarà aggiunta.
3. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) facendo riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) della presentazione di destinazione.
4. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) e passa la diapositiva dalla presentazione sorgente insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone).
5. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dall'indice zero della presentazione sorgente) all'indice 1 (posizione 2) della presentazione di destinazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanzia la classe Presentation per caricare il file di presentazione sorgente
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    destination_presentation = Presentation()
    try:
        # Clona la diapositiva desiderata dalla presentazione sorgente all'indice specificato nella presentazione di destinazione
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Scrivi la presentazione di destinazione su disco
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clona una diapositiva con la sua diapositiva master in un'altra presentazione**

Se è necessario clonare una diapositiva con una diapositiva master da una presentazione e usarla in un'altra presentazione, è necessario prima clonare la diapositiva master desiderata dalla presentazione sorgente a quella di destinazione. Quindi utilizzare la diapositiva master clonata durante la clonazione della diapositiva. Il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) si aspetta una diapositiva master dalla presentazione di destinazione anziché da quella sorgente. Per clonare la diapositiva con un master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che contiene la presentazione sorgente da cui la diapositiva sarà clonata.
2. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che contiene la presentazione di destinazione a cui la diapositiva sarà clonata.
3. Accedi alla diapositiva da clonare insieme alla diapositiva master.
4. Ottieni l'oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/) facendo riferimento alla raccolta Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) della presentazione di destinazione.
5. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#addClone) esposto dall'oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/) e passa il master dal PPTX sorgente da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#addClone).
6. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) facendo riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) della presentazione di destinazione.
7. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) e passa la diapositiva dalla presentazione sorgente da clonare e la diapositiva master come parametro al metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone).
8. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione sorgente) alla fine della presentazione di destinazione utilizzando il master della diapositiva sorgente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanzia la classe Presentation per caricare il file di presentazione sorgente
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instanzia la classe Presentation per la presentazione di destinazione (dove la diapositiva deve essere clonata)
    destination_presentation = Presentation()
    try:
        # Instanzia la diapositiva dalla raccolta di diapositive nella presentazione sorgente insieme a
        # Diapositiva master
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Clona la diapositiva master desiderata dalla presentazione sorgente nella raccolta di master nella
        # presentazione di destinazione
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Clona la diapositiva desiderata dalla presentazione sorgente con il master desiderato alla fine della
        # raccolta di diapositive nella presentazione di destinazione
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Salva la presentazione di destinazione su disco
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clona una diapositiva alla fine di una sezione specificata**

Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [**addClone**](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) esposto dalla classe [**SlideCollection**](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/). Aspose.Slides per Python via Java consente di clonare una diapositiva dalla prima sezione e quindi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Salva la presentazione di destinazione su disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Assicurati che le dimensioni delle diapositive corrispondano**

Quando si clonano diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni delle diapositive della sorgente. Se le dimensioni delle diapositive differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le loro coordinate e dimensioni originali vengono conservate, il che può far apparire il contenuto disallineato o esteso oltre i bordi della diapositiva.

Puoi impostare le dimensioni delle diapositive della presentazione di destinazione per farle corrispondere a quelle della sorgente prima di clonare il master e la diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Fallo prima di clonare il master e la diapositiva.

## **FAQ**

**Le note del relatore e i commenti del revisore vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li desideri, [rimuovili](/slides/it/python-java/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), quel collegamento è preservato come un [oggetto OLE](/slides/it/python-java/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone a uno specifico indice di diapositiva e collocarlo in una [sezione](/slides/it/python-java/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.