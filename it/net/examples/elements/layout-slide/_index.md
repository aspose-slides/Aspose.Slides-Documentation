---
title: Diapositiva di Layout
type: docs
weight: 20
url: /it/net/examples/elements/layout-slide/
keywords:
- diapositiva di layout
- aggiungi diapositiva di layout
- accedi a diapositiva di layout
- rimuovi diapositiva di layout
- diapositiva di layout non utilizzata
- clona diapositiva di layout
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Diapositive master di layout in Aspose.Slides per .NET: scegli, applica e personalizza i layout delle diapositive, i segnaposti e i master con esempi C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con **Layout Slides** in Aspose.Slides per .NET. Una diapositiva di layout definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere le diapositive di layout, nonché pulire quelle non utilizzate per ridurre le dimensioni della presentazione.

## **Aggiungere una Diapositiva di Layout**

È possibile creare una diapositiva di layout personalizzata per definire una formattazione riutilizzabile. Ad esempio, potresti aggiungere una casella di testo che appare su tutte le diapositive che utilizzano questo layout.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Crea una diapositiva di layout con un tipo di layout vuoto e un nome personalizzato.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Aggiungi una casella di testo alla diapositiva di layout.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Aggiungi due diapositive usando questo layout; entrambe erediteranno il testo dal layout.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Nota 1:** Le diapositive di layout fungono da modelli per le diapositive individuali. È possibile definire elementi comuni una volta e riutilizzarli in molte diapositive.
> 
> 💡 **Nota 2:** Quando aggiungi forme o testo a una diapositiva di layout, tutte le diapositive basate su quel layout visualizzeranno automaticamente questo contenuto condiviso.
> Lo screenshot sottostante mostra due diapositive, ognuna delle quali eredita una casella di testo dalla stessa diapositiva di layout.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Accedere a una Diapositiva di Layout**

Le diapositive di layout possono essere accessate per indice o per tipo di layout (ad esempio, `Blank`, `Title`, `SectionHeader`, ecc.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Accedi a una diapositiva di layout per indice.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Accedi a una diapositiva di layout per tipo.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Rimuovere una Diapositiva di Layout**

È possibile rimuovere una diapositiva di layout specifica se non è più necessaria.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Ottieni una diapositiva di layout per tipo ed eliminala.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Rimuovere le Diapositive di Layout Non Utilizzate**

Per ridurre le dimensioni della presentazione, potresti desiderare di rimuovere le diapositive di layout che non sono utilizzate da alcuna diapositiva normale.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Rimuove automaticamente tutte le diapositive di layout non referenziate da alcuna diapositiva.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Clonare una Diapositiva di Layout**

È possibile duplicare una diapositiva di layout utilizzando il metodo `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Ottieni una diapositiva di layout esistente per tipo.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clona la diapositiva di layout alla fine della collezione di diapositive di layout.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Riepilogo:** Le diapositive di layout sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente il pieno controllo su creazione, gestione e ottimizzazione delle diapositive di layout.