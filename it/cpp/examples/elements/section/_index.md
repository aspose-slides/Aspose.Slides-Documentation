---
title: Sezione
type: docs
weight: 90
url: /it/cpp/examples/elements/section/
keywords:
- esempio di codice
- sezione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive in Aspose.Slides per C++: crea, rinomina, riordina e raggruppa le diapositive con esempi C++ per PPT, PPTX e ODP."
---
Esempi per gestire le sezioni di presentazione — aggiungere, accedere, rimuovere e rinominare programmaticamente utilizzando **Aspose.Slides for C++**.

## **Aggiungi una sezione**

Crea una sezione che inizia da una diapositiva specifica.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Specifica la diapositiva che segna l'inizio della sezione.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Accedi a una sezione**

Leggi le informazioni della sezione da una presentazione.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Accedi a una sezione per indice.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Rimuovi una sezione**

Elimina una sezione precedentemente aggiunta.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Rimuovi la prima sezione.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Rinomina una sezione**

Cambia il nome di una sezione esistente.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```