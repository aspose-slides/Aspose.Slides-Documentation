---
title: Forme di presentazione di gruppo su Android
linktitle: Gruppo di forme
type: docs
weight: 40
url: /it/androidjava/group/
keywords:
- forma di gruppo
- gruppo di forme
- aggiungi gruppo
- testo alternativo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a raggruppare e separare le forme nei deck di PowerPoint usando Aspose.Slides per Android—guida rapida, passo dopo passo, con codice Java gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme di gruppo in Aspose.Slides. Mostra come aggiungere una forma di gruppo a una diapositiva, inserire forme al suo interno e salvare la presentazione aggiornata. Dimostra anche come accedere alle forme memorizzate all'interno di un gruppo e leggere i valori di `AlternativeText`. Inoltre, l'articolo copre brevemente le funzionalità correlate alle forme di gruppo, come gruppi annidati, ordine Z e opzioni di blocco.

## **Aggiungere una Forma di Gruppo**
Aspose.Slides supporta il lavoro con le forme di gruppo sulle diapositive. Questa funzionalità aiuta gli sviluppatori a creare presentazioni più ricche. Aspose.Slides per Android via Java supporta l'aggiunta o l'accesso alle forme di gruppo. È possibile aggiungere forme a una forma di gruppo aggiunta per popolarla o accedere a qualsiasi proprietà della forma di gruppo. Per aggiungere una forma di gruppo a una diapositiva usando Aspose.Slides per Android via Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Aggiungi una forma di gruppo alla diapositiva.
1. Aggiungi le forme alla forma di gruppo aggiunta.
1. Salva la presentazione modificata come file PPTX.

```java
    // Istanzia la classe Presentation
    Presentation pres = new Presentation();
    try {
        // Ottieni la prima diapositiva
        ISlide sld = pres.getSlides().get_Item(0);

        // Accesso alla raccolta di forme delle diapositive
        IShapeCollection slideShapes = sld.getShapes();

        // Aggiunta di una forma di gruppo alla diapositiva
        IGroupShape groupShape = slideShapes.addGroupShape();
        
        // Aggiunta di forme all'interno della forma di gruppo aggiunta
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // Aggiunta del frame della forma di gruppo
        groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

        // Scrivi il file PPTX su disco
        pres.save("GroupShape.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **Accedere alla Proprietà AltText**
Questo argomento mostra passaggi semplici, completi di esempi di codice, per aggiungere una forma di gruppo e accedere alla proprietà AltText delle forme di gruppo sulle diapositive. Per accedere all'AltText di una forma di gruppo in una diapositiva usando Aspose.Slides per Android via Java:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che rappresenta il file PPTX.
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Accedi alla raccolta di forme delle diapositive.
1. Accedi alla forma di gruppo.
1. Accedi alla proprietà [AlternativeText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getAlternativeText--).

```java
// Istanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Accesso alla raccolta di forme delle diapositive
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Accesso alla forma di gruppo.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Accesso alla proprietà AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Il raggruppamento nidificato (un gruppo dentro un altro gruppo) è supportato?**

Sì. [GroupShape] dispone di un metodo [getParentGroup] che indica direttamente il supporto alla gerarchia (un gruppo può essere figlio di un altro gruppo).

**Come posso controllare l'ordine Z del gruppo rispetto agli altri oggetti sulla diapositiva?**

Usa il metodo [getZOrderPosition] di [GroupShape] per esaminare la sua posizione nella pila di visualizzazione.

**Posso impedire lo spostamento, la modifica o lo sgrouping?**

Sì. La sezione di blocco del gruppo è esposta tramite [getGroupShapeLock], che consente di limitare le operazioni sull'oggetto.