---
title: Diapositiva
type: docs
weight: 10
url: /it/net/examples/elements/slide/
keywords:
- diapositiva
- aggiungi diapositiva
- accedi diapositiva
- indice diapositiva
- clona diapositiva
- riordina diapositive
- rimuovi diapositiva
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le diapositive in Aspose.Slides per .NET: crea, clona, riordina, ridimensiona, imposta gli sfondi e applica le transizioni con C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo fornisce una serie di esempi che dimostrano come lavorare con le diapositive usando **Aspose.Slides for .NET**. Imparerai come aggiungere, accedere, clonare, riordinare e rimuovere diapositive utilizzando la classe `Presentation`.

Ogni esempio di seguito include una breve spiegazione seguita da uno snippet di codice in C#.

## **Aggiungi una diapositiva**

Per aggiungere una nuova diapositiva, devi prima selezionare un layout. In questo esempio, usiamo il layout `Blank` e aggiungiamo una diapositiva vuota alla presentazione.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Ogni diapositiva è basata su un layout, che a sua volta è basato su una diapositiva master.
    // Usa il layout Blank per creare una nuova diapositiva.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Aggiungi una nuova diapositiva vuota usando il layout selezionato.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Nota:** Ogni layout di diapositiva deriva da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposti. L’immagine sotto illustra come le diapositive master e i relativi layout sono organizzati in PowerPoint.

![Relazione tra master e layout](master-layout-slide.png)

## **Accedi alle diapositive per indice**

Puoi accedere alle diapositive usando il loro indice, o trovare l’indice di una diapositiva basandoti su un riferimento. Questo è utile per iterare o modificare diapositive specifiche.

```csharp
static void AccessSlide()
{
    // Per impostazione predefinita, una presentazione viene creata con una diapositiva vuota.
    using var presentation = new Presentation();

    // Aggiungi un'altra diapositiva vuota.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Accedi alle diapositive per indice.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Ottieni l'indice della diapositiva da un riferimento, poi accedi a essa per indice.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Clona una diapositiva**

Questo esempio dimostra come clonare una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della raccolta di diapositive.

```csharp
static void CloneSlide()
{
    // Per impostazione predefinita, la presentazione contiene una diapositiva vuota.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Clona la prima diapositiva; verrà aggiunta alla fine della presentazione.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // L'indice della diapositiva clonata è 1 (seconda diapositiva nella presentazione).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Riordina le diapositive**

Puoi cambiare l’ordine delle diapositive spostandone una in una nuova posizione. In questo caso, spostiamo una diapositiva clonata nella prima posizione.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Aggiungi una copia della prima diapositiva (creata per impostazione predefinita).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Sposta la diapositiva clonata nella prima posizione (le altre si spostano verso il basso).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Rimuovi una diapositiva**

Per rimuovere una diapositiva, basta fare riferimento ad essa e chiamare `Remove`. Questo esempio aggiunge una seconda diapositiva e poi rimuove quella originale, lasciando solo la nuova.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Aggiungi una nuova diapositiva vuota in aggiunta alla prima diapositiva predefinita.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Rimuovi la prima diapositiva; rimarrà solo la diapositiva appena aggiunta.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```