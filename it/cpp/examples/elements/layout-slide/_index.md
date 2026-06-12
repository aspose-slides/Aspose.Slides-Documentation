---
title: Diapositiva layout
type: docs
weight: 20
url: /it/cpp/examples/elements/layout-slide/
keywords:
- esempio di codice
- diapositiva layout
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le diapositive layout master in Aspose.Slides per C++: scegli, applica e personalizza layout diapositive, segnaposti e master con esempi C++ per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con **Layout Slides** in Aspose.Slides per C++. Una diapositiva layout definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere le diapositive layout, nonché pulire quelle non utilizzate per ridurre la dimensione della presentazione.

## **Aggiungi una diapositiva layout**

È possibile creare una diapositiva layout personalizzata per definire una formattazione riutilizzabile. Ad esempio, potresti aggiungere una casella di testo che appare su tutte le diapositive che utilizzano questo layout.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Crea una diapositiva layout con un tipo di layout vuoto e un nome personalizzato.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Aggiungi una casella di testo alla diapositiva layout.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Aggiungi due diapositive usando questo layout; entrambe erediteranno il testo dal layout.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Le diapositive layout fungono da modelli per le singole diapositive. È possibile definire gli elementi comuni una volta e riutilizzarli in molte diapositive.  
> 💡 **Nota 2:** Quando aggiungi forme o testo a una diapositiva layout, tutte le diapositive basate su quel layout visualizzeranno automaticamente questo contenuto condiviso.  
> Lo screenshot qui sotto mostra due diapositive, ciascuna che eredita una casella di testo dallo stesso layout.

![Diapositive che ereditano contenuto del layout](layout-slide-result.png)

## **Accedi a una diapositiva layout**

Le diapositive layout possono essere accessate per indice o per tipo di layout (ad es., `Blank`, `Title`, `SectionHeader`, ecc.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Accedi a una diapositiva layout per indice.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Accedi a una diapositiva layout per tipo.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Rimuovi una diapositiva layout**

È possibile rimuovere una diapositiva layout specifica se non è più necessaria.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Ottieni una diapositiva layout per tipo e rimuovila.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Rimuovi le diapositive layout non utilizzate**

Per ridurre la dimensione della presentazione, potresti voler rimuovere le diapositive layout che non sono utilizzate da nessuna diapositiva normale.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Rimuove automaticamente tutte le diapositive layout non riferite da alcuna diapositiva.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Clona una diapositiva layout**

È possibile duplicare una diapositiva layout usando il metodo `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Ottieni una diapositiva layout esistente per tipo.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Clona la diapositiva layout alla fine della raccolta delle diapositive layout.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Riepilogo:** Le diapositive layout sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente il controllo completo sulla creazione, gestione e ottimizzazione delle diapositive layout.