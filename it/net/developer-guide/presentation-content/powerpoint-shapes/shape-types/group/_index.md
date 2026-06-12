---
title: Forme di gruppo nella presentazione in .NET
linktitle: Gruppo di forme
type: docs
weight: 40
url: /it/net/group/
keywords:
- forma di gruppo
- gruppo di forme
- aggiungere gruppo
- testo alternativo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a raggruppare e separare forme nei deck di PowerPoint usando Aspose.Slides per .NET—guida rapida, passo passo, con codice C# gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme di gruppo in Aspose.Slides. Mostra come aggiungere una forma di gruppo a una diapositiva, inserire forme al suo interno e salvare la presentazione aggiornata. Dimostra inoltre come accedere alle forme memorizzate all'interno di un gruppo e leggere i valori di `AlternativeText`. Inoltre, l'articolo tratta brevemente le funzionalità correlate alle forme di gruppo, come i gruppi nidificati, l'ordine Z e le opzioni di blocco.

## **Aggiungere una forma di gruppo**
Aspose.Slides supporta il lavoro con le forme di gruppo sulle diapositive. Questa funzionalità aiuta gli sviluppatori a creare presentazioni più ricche. Aspose.Slides per .NET supporta l'aggiunta o l'accesso a forme di gruppo. È possibile aggiungere forme a una forma di gruppo aggiunta per popolarla o accedere a qualsiasi proprietà della forma di gruppo. Per aggiungere una forma di gruppo a una diapositiva usando Aspose.Slides per .NET:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi una forma di gruppo alla diapositiva.
4. Aggiungi le forme alla forma di gruppo aggiunta.
5. Salva la presentazione modificata come file PPTX.

L'esempio seguente aggiunge una forma di gruppo a una diapositiva.

```c#
    // Istanzia la classe Presentation 
    using (Presentation pres = new Presentation())
    {
        // Ottieni la prima diapositiva 
        ISlide sld = pres.Slides[0];

        // Accesso alla raccolta di forme delle diapositive 
        IShapeCollection slideShapes = sld.Shapes;

        // Aggiungere una forma di gruppo alla diapositiva 
        IGroupShape groupShape = slideShapes.AddGroupShape();

        // Aggiungere forme all'interno della forma di gruppo aggiunta 
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // Aggiungere il frame della forma di gruppo 
        groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

        // Scrivi il file PPTX su disco 
        pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
    }
```

## **Accedere alla proprietà AltText**
Questo argomento mostra passaggi semplici, completi di esempi di codice, per aggiungere una forma di gruppo e accedere alla proprietà AltText delle forme di gruppo sulle diapositive. Per accedere ad AltText di una forma di gruppo in una diapositiva usando Aspose.Slides per .NET:

1. Istanzia la classe `Presentation` che rappresenta un file PPTX.
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Accedi alla raccolta di forme delle diapositive.
4. Accedi alla forma di gruppo.
5. Accedi alla proprietà AltText.

L'esempio seguente accede al testo alternativo della forma di gruppo.

```c#
// Istanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation("AltText.pptx");

// Ottieni la prima diapositiva
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Accesso alla raccolta di forme delle diapositive
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Accesso alla forma di gruppo.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Accesso alla proprietà AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**È supportato il raggruppamento nidificato (un gruppo all'interno di un altro gruppo)?**

Sì. [GroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/groupshape/) ha una proprietà [ParentGroup](https://reference.aspose.com/slides/it/net/aspose.slides/shape/parentgroup/) che indica direttamente il supporto alla gerarchia (un gruppo può essere figlio di un altro gruppo).

**Come posso controllare l'ordine Z del gruppo rispetto agli altri oggetti sulla diapositiva?**

Utilizza la proprietà [ZOrderPosition](https://reference.aspose.com/slides/it/net/aspose.slides/shape/zorderposition/) del [GroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/groupshape/) per verificare la sua posizione nello stack di visualizzazione.

**Posso impedire lo spostamento, la modifica o il degruppo?**

Sì. La sezione di blocco del gruppo è esposta tramite [GroupShapeLock](https://reference.aspose.com/slides/it/net/aspose.slides/groupshape/groupshapelock/), che consente di limitare le operazioni sull'oggetto.