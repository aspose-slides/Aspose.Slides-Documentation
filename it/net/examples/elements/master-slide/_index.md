---
title: Diapositiva master
type: docs
weight: 30
url: /it/net/examples/elements/master-slide/
keywords:
- diapositiva master
- aggiungi diapositiva master
- accedi a diapositiva master
- rimuovi diapositiva master
- diapositiva master inutilizzata
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esplora gli esempi di diapositiva master di Aspose.Slides per .NET: crea, modifica e stile i master, i segnaposti e i temi in PPT, PPTX e ODP con codice C# chiaro."
---
Le diapositive master costituiscono il livello superiore della gerarchia di ereditarietà delle diapositive in PowerPoint. Una **diapositiva master** definisce elementi di design comuni come sfondi, loghi e formattazione del testo. Le **diapositive layout** ereditano dalle diapositive master e le **diapositive normali** ereditano dalle diapositive layout.

Questo articolo dimostra come creare, modificare e gestire le diapositive master utilizzando Aspose.Slides per .NET.

## **Aggiungi una diapositiva master**

Questo esempio mostra come creare una nuova diapositiva master clonando quella predefinita. Successivamente aggiunge un banner con il nome dell'azienda a tutte le diapositive tramite l'ereditarietà del layout.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Clona la diapositiva master predefinita.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Aggiungi un banner con il nome dell'azienda nella parte superiore della diapositiva master.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assegna la nuova diapositiva master a una diapositiva layout.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Assegna la diapositiva layout alla prima diapositiva della presentazione.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Nota 1:** Le diapositive master offrono un modo per applicare un branding coerente o elementi di design condivisi a tutte le diapositive. Qualsiasi modifica apportata al master sarà automaticamente riflessa sulle diapositive layout e normali dipendenti.

> 💡 **Nota 2:** Qualsiasi forma o formattazione aggiunta a una diapositiva master viene ereditata dalle diapositive layout e, a loro volta, da tutte le diapositive normali che utilizzano quei layout.
> L'immagine qui sotto illustra come una casella di testo aggiunta su una diapositiva master venga renderizzata automaticamente sulla diapositiva finale.

![Esempio di ereditarietà master](master-slide-banner.png)

## **Accedi a una diapositiva master**

Puoi accedere alle diapositive master utilizzando la collezione `Presentation.Masters`. Ecco come recuperarLe e lavorare con esse:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Accedi alla prima diapositiva master.
    var firstMasterSlide = presentation.Masters[0];

    // Cambia il tipo di sfondo.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Rimuovi una diapositiva master**

Le diapositive master possono essere rimosse sia per indice sia per riferimento.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Rimuovi una diapositiva master per indice.
    presentation.Masters.RemoveAt(0);

    // Rimuovi una diapositiva master per riferimento.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Rimuovi le diapositive master inutilizzate**

Alcune presentazioni contengono diapositive master che non sono in uso. Rimuovere queste diapositive può aiutare a ridurre le dimensioni del file.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Rimuovi tutte le diapositive master inutilizzate (anche quelle contrassegnate come Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```