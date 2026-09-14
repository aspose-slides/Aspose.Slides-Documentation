---
title: Aggiungere diapositive alle presentazioni in Python
linktitle: Aggiungi diapositiva
type: docs
weight: 10
url: /it/python-java/add-slide-to-presentation/
keywords:
- aggiungere diapositiva
- creare diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via Java—inserimento di diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere diapositive alle presentazioni PowerPoint in modo programmatico. Una presentazione contiene diapositive master/layout e diapositive normali, e le diapositive normali sono organizzate mediante un indice basato su zero. Ogni diapositiva dispone di un ID univoco e i file di presentazione senza diapositive non sono supportati.

Questo articolo spiega come creare un oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) , accedere alla sua collezione di diapositive, aggiungere una diapositiva vuota, lavorare con la diapositiva appena aggiunta e salvare la presentazione aggiornata. Copre anche argomenti correlati come l'inserimento di diapositive in una posizione specifica, l'uso di layout e la comprensione della diapositiva vuota presente in una presentazione appena creata.

## **Aggiungere una diapositiva a una presentazione**

Prima di discutere come aggiungere diapositive ai file di presentazione, rivediamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene diapositive **master/layout** e diapositive **normali**. Un file di presentazione contiene almeno una diapositiva. I file di presentazione senza diapositive non sono supportati da Aspose.Slides for Python via Java. Ogni diapositiva ha un ID univoco e tutte le diapositive normali sono ordinate secondo un indice basato su zero.

Aspose.Slides for Python via Java consente agli sviluppatori di aggiungere diapositive vuote alle loro presentazioni. Per aggiungere una diapositiva vuota a una presentazione, segui questi passaggi:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
- Ottieni un riferimento all'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) utilizzando il metodo [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) esposto dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
- Aggiungi una diapositiva vuota alla fine della collezione di diapositive della presentazione chiamando il metodo [addEmptySlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addEmptySlide) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) .
- Esegui alcune operazioni con la diapositiva vuota appena aggiunta.
- Infine, scrivi il file di presentazione utilizzando l'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Istanzia la classe Presentation che rappresenta il file di presentazione.
presentation = Presentation()
try:
    # Ottieni la collezione di diapositive.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Aggiungi una diapositiva vuota alla collezione di diapositive.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Esegui alcune operazioni sulla diapositiva appena aggiunta.

    # Salva il file PPTX su disco.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. La libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertClone) , quindi è possibile aggiungere una diapositiva all'indice richiesto anziché solo alla fine.

**I temi/stili vengono preservati quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master e la nuova diapositiva eredita dal layout selezionato e dal relativo master.

**Quale diapositiva è presente in una nuova presentazione "vuota" prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. È importante considerare questo quando si calcolano gli indici di inserimento.

**Come scegliere il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

In genere, scegli il [LayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/) che corrisponde alla struttura richiesta ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidelayouttype/)). Se tale layout manca, puoi [add it to the master](/slides/it/python-java/slide-layout/) e poi usarlo.