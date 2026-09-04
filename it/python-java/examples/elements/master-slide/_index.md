---
title: Diapositiva master
type: docs
weight: 30
url: /it/python-java/examples/elements/master-slide/
keywords:
- esempio di codice
- diapositiva master
- aggiungi diapositiva master
- accedi alla diapositiva master
- rimuovi diapositiva master
- diapositiva master inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci le diapositive master con Aspose.Slides per Python via Java: crea, accedi, rimuovi e pulisci i master in presentazioni PowerPoint e OpenDocument."
---
Le diapositive master costituiscono il livello superiore della gerarchia di ereditarietà delle diapositive in PowerPoint. Una **diapositiva master** definisce gli elementi di design comuni come sfondi, loghi e formattazione del testo. Le **diapositive layout** ereditano dalle diapositive master e le **diapositive normali** ereditano dalle diapositive layout.

Questo articolo dimostra come creare, modificare e gestire le diapositive master utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungere una Diapositiva Master**

Questo esempio mostra come creare una nuova diapositiva master clonando quella predefinita. Successivamente aggiunge un banner con il nome dell'azienda a tutte le diapositive mediante l'ereditarietà del layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Clona la diapositiva master predefinita.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Aggiungi un banner con il nome dell'azienda nella parte superiore della diapositiva master.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Assegna la nuova diapositiva master a una diapositiva layout.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Assegna la diapositiva layout alla prima diapositiva nella presentazione.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Le diapositive master offrono un modo per applicare un branding coerente o elementi di design condivisi su tutte le diapositive. Le modifiche apportate a un master vengono automaticamente riflesse sulle diapositive layout e normali dipendenti.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Le forme e la formattazione aggiunte a una diapositiva master vengono ereditate dalle diapositive layout e, a loro volta, da tutte le diapositive normali che utilizzano tali layout. L'immagine seguente illustra come una casella di testo aggiunta a una diapositiva master venga automaticamente visualizzata nella diapositiva finale.
{{% /alert %}}

![Esempio di Ereditarietà Master](master-slide-banner.png)

## **Accedere a una Diapositiva Master**

È possibile accedere alle diapositive master tramite la collezione master della presentazione. Questo esempio recupera la prima diapositiva master e ne modifica il tipo di sfondo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Rimuovere una Diapositiva Master**

Una diapositiva master può essere rimossa per indice o per riferimento dopo che non è più utilizzata. Questo esempio assegna una diapositiva master clonata alla presentazione e poi rimuove il master originale per indice.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Rimuovi la diapositiva master originale non utilizzata per indice.
    presentation.getMasters().removeAt(0)

    # In alternativa, rimuovi una diapositiva master non utilizzata per riferimento:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Rimuovere le Diapositive Master Non Utilizzate**

Alcune presentazioni contengono diapositive master che non sono in uso. Rimuovere queste diapositive può aiutare a ridurre le dimensioni del file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Rimuovi tutte le diapositive master inutilizzate, inclusi quelli contrassegnati come Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```