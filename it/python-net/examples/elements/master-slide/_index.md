---
title: Diapositiva Master
type: docs
weight: 30
url: /it/python-net/examples/elements/master-slide/
keywords:
- diapositiva master
- aggiungere diapositiva master
- accedere a diapositiva master
- rimuovere diapositiva master
- diapositiva master inutilizzata
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le diapositive master in Python con Aspose.Slides: crea, modifica, clona e formatta temi, sfondi, segnaposti per uniformare le diapositive in PowerPoint e OpenDocument."
---
Le diapositive master costituiscono il livello più alto della gerarchia di ereditarietà delle diapositive in PowerPoint. Una **diapositiva master** definisce gli elementi di design comuni, come sfondi, loghi e formattazione del testo. **Le diapositive layout** ereditano dalle diapositive master, e **le diapositive normali** ereditano dalle diapositive layout.

Questo articolo dimostra come creare, modificare e gestire le diapositive master utilizzando Aspose.Slides per Python via .NET.

## **Aggiungere una Diapositiva Master**

Questo esempio mostra come creare una nuova diapositiva master clonando quella predefinita.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Clona la diapositiva master predefinita.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Suggerimento 1:** Le diapositive master offrono un modo per applicare un branding coerente o elementi di design condivisi su tutte le diapositive. Qualsiasi modifica apportata al master verrà automaticamente riflessa sulle diapositive layout e normali dipendenti.  
> 
> 💡 **Suggerimento 2:** Qualsiasi forma o formattazione aggiunta a una diapositiva master viene ereditata dalle diapositive layout e, a loro volta, da tutte le diapositive normali che utilizzano quei layout.  
> 
> L'immagine sottostante illustra come una casella di testo aggiunta su una diapositiva master venga automaticamente visualizzata sulla diapositiva finale.

![Esempio di Ereditarietà del Master](master-slide-banner.png)

## **Accedere a una Diapositiva Master**

È possibile accedere alle diapositive master tramite la collezione `Presentation.masters`. Ecco come recuperarle e lavorare con esse:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Accedi alla prima diapositiva master.
        first_master_slide = presentation.masters[0]
```

## **Rimuovere una Diapositiva Master**

Le diapositive master possono essere rimosse sia per indice che per riferimento.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Rimuovi per indice.
        presentation.masters.remove_at(0)

        # Oppure rimuovi per riferimento.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere le Diapositive Master Inutilizzate**

Alcune presentazioni contengono diapositive master non in uso. Rimuovere queste diapositive può contribuire a ridurre le dimensioni del file.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Rimuovi tutte le diapositive master inutilizzate (anche quelle contrassegnate come Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Suggerimento:** Utilizza `remove_unused(True)` per pulire le diapositive master inutilizzate e ridurre le dimensioni della presentazione.