---
title: Diapositiva
type: docs
weight: 10
url: /it/cpp/examples/elements/slide/
keywords:
- esempio di codice
- diapositiva
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le diapositive in Aspose.Slides per C++: crea, clona, riordina, ridimensiona, imposta sfondi e applica transizioni con C++ per presentazioni PPT, PPTX e ODP."
---
Questo articolo fornisce una serie di esempi che dimostrano come lavorare con le diapositive utilizzando **Aspose.Slides for C++**. Imparerai come aggiungere, accedere, clonare, riordinare e rimuovere le diapositive usando la classe `Presentation`.

Ogni esempio di seguito include una breve spiegazione seguita da uno snippet di codice in C++.

## **Aggiungere una diapositiva**

Per aggiungere una nuova diapositiva, devi prima selezionare un layout. In questo esempio, usiamo il layout `Blank` e aggiungiamo una diapositiva vuota alla presentazione.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Nota:** Ogni layout di diapositiva deriva da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposto. L’immagine qui sotto illustra come le diapositive master e i loro layout associati sono organizzati in PowerPoint.

![Relazione tra master e layout](master-layout-slide.png)

## **Accedere alle diapositive per indice**

Puoi accedere alle diapositive usando il loro indice, o trovare l’indice di una diapositiva basandoti su un riferimento. Questo è utile per iterare o modificare diapositive specifiche.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Aggiungi un'altra diapositiva vuota.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Accedi alle diapositive per indice.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Ottieni l'indice della diapositiva da un riferimento, quindi accedi ad essa per indice.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clonare una diapositiva**

Questo esempio dimostra come clonare una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della collezione di diapositive.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Riordinare le diapositive**

Puoi cambiare l’ordine delle diapositive spostandone una a un nuovo indice. In questo caso, spostiamo una diapositiva clonata nella prima posizione.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Rimuovere una diapositiva**

Per rimuovere una diapositiva, basta riferirsi ad essa e chiamare `Remove`. Questo esempio aggiunge una seconda diapositiva e poi rimuove quella originale, lasciando solo la nuova.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```