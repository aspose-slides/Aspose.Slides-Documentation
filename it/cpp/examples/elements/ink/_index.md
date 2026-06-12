---
title: Inchiostro
type: docs
weight: 180
url: /it/cpp/examples/elements/ink/
keywords:
- esempio di codice
- inchiostro
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavora con l'Inchiostro in Aspose.Slides per C++: disegna, importa e modifica i tratti, regola colore e spessore, ed esporta in PPT, PPTX e ODP usando esempi C++."
---
Questo articolo fornisce esempi di come accedere a forme di inchiostro esistenti e rimuoverle usando **Aspose.Slides for C++**.

> ❗ **Nota:** Le forme di inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuove tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.

## **Accedi all'Inchiostro**
Leggi i tag dalla prima forma di inchiostro in una diapositiva.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Usa tagName secondo necessità.
        }
    }

    presentation->Dispose();
}
```

## **Rimuovi l'Inchiostro**
Elimina una forma di inchiostro dalla diapositiva se esiste.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```