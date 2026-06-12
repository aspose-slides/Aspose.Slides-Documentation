---
title: Sezione
type: docs
weight: 90
url: /it/python-net/examples/elements/section/
keywords:
- sezione
- sezione diapositiva
- aggiungi sezione
- accedi sezione
- rimuovi sezione
- rinomina sezione
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive in Python con Aspose.Slides: crea, rinomina, riordina facilmente, sposta le diapositive tra le sezioni e controlla la visibilità per PPT, PPTX e ODP."
---
Esempi per la gestione delle sezioni di presentazione—aggiungere, accedere, rimuovere e rinominare programmaticamente utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi una sezione**

Crea una sezione che inizia in una diapositiva specifica.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi una nuova sezione e specifica la diapositiva che segna l'inizio della sezione.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a una sezione**

Ottieni una sezione da una presentazione.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Accedi a una sezione per indice.
        section = presentation.sections[0]
```

## **Rimuovi una sezione**

Elimina una sezione precedentemente aggiunta.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Rimuovi la sezione.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rinomina una sezione**

Modifica il nome di una sezione esistente.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Rinomina la sezione.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```