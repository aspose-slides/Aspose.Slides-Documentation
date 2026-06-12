---
title: Gestire progetti VBA nelle presentazioni con Python
linktitle: Presentazione tramite VBA
type: docs
weight: 250
url: /it/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- aggiungere macro
- rimuovere macro
- estrarre macro
- aggiungere VBA
- rimuovere VBA
- estrarre VBA
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come generare e manipolare presentazioni PowerPoint e OpenDocument tramite VBA con Aspose.Slides per Python via .NET per ottimizzare il tuo flusso di lavoro."
---
## **Panoramica**

Questo articolo esamina le principali funzionalità di Aspose.Slides per Python via .NET per lavorare con le macro nelle presentazioni PowerPoint. La libreria offre strumenti pratici per aggiungere, rimuovere ed estrarre macro, consentendo di automatizzare la creazione e la modifica delle presentazioni.

Con Aspose.Slides, puoi:

- Accelerare lo sviluppo delle presentazioni—l'automazione delle attività di routine riduce il tempo necessario per preparare il materiale.
- Garantire flessibilità—la possibilità di gestire le macro consente di adattare le presentazioni a compiti e scenari specifici.
- Integrare dati—una semplice integrazione con fonti dati esterne aiuta a mantenere aggiornato il contenuto delle diapositive.
- Semplificare la manutenzione—la gestione centralizzata delle macro rende più facile applicare modifiche e aggiornare le presentazioni.

L'articolo prosegue presentando esempi pratici su come utilizzare Aspose.Slides per lavorare efficacemente con le macro in PowerPoint.

Il namespace [aspose.slides.vba](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/) fornisce classi per lavorare con macro e codice VBA.

{{% alert title="Nota" color="warning" %}}

Quando converti una presentazione che contiene macro in un altro formato (PDF, HTML, ecc.), Aspose.Slides ignora le macro—non vengono trasferite nel file di output.

Quando aggiungi macro a una presentazione o salvi nuovamente una presentazione che contiene macro, Aspose.Slides scrive i byte della macro così come sono.

Aspose.Slides **non** esegue mai macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/vbaproject/) per creare progetti VBA (e riferimenti di progetto) e per modificare i moduli esistenti.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Usa il costruttore [VbaProject](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/vbaproject/#constructors) per aggiungere un nuovo progetto VBA.
1. Aggiungi un modulo al progetto VBA.
1. Imposta il codice sorgente del modulo.
1. Aggiungi un riferimento a `<stdole>`.
1. Aggiungi un riferimento a **Microsoft Office**.
1. Associa i riferimenti al progetto VBA.
1. Salva la presentazione.

Il seguente codice Python mostra come aggiungere una macro VBA da zero a una presentazione:

```python
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    # Crea un nuovo progetto VBA.
    presentation.vba_project = slides.vba.VbaProject()

    # Aggiungi un modulo vuoto al progetto VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Imposta il codice sorgente del modulo.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Crea un riferimento a <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Crea un riferimento a Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Aggiungi i riferimenti al progetto VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Salva la presentazione.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

Potresti provare il **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), un'app web gratuita per rimuovere macro da documenti PowerPoint, Excel e Word.

{{% /alert %}}

## **Rimuovere macro VBA**

Utilizzando la proprietà [vba_project](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/vba_project/) della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), è possibile rimuovere una macro VBA.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione che contiene la macro.
1. Accedi al modulo macro e rimuovilo.
1. Salva la presentazione modificata.

Il seguente codice Python mostra come rimuovere una macro VBA:

```python
import aspose.slides as slides

# Carica la presentazione che contiene la macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Accedi al modulo VBA.
    vba_module = presentation.vba_project.modules[0]

    # Rimuovi il modulo VBA.
    presentation.vba_project.modules.remove(vba_module)

    # Salva la presentazione.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Estrarre macro VBA**

Utilizzando la proprietà `modules` nella classe [VbaProject](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/vbaproject/), è possibile accedere a tutti i moduli di un progetto VBA. La classe [VbaModule](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/vbamodule/) può essere usata per estrarre proprietà del modulo come nome e codice.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione che contiene la macro.
1. Verifica se la presentazione contiene un progetto VBA.
1. Scorri tutti i moduli nel progetto VBA per visualizzare le macro.

Il seguente codice Python mostra come estrarre macro VBA da una presentazione:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Verifica se la presentazione contiene un progetto VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Verificare se un progetto VBA è protetto da password**

Utilizzando la proprietà [VbaProject.is_password_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/vbaproject/is_password_protected/), è possibile determinare se le proprietà di un progetto sono protette da password.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica una presentazione che contiene una macro.
1. Verifica se la presentazione contiene un [VBA project](https://reference.aspose.com/slides/it/python-net/aspose.slides.vba/vbaproject/).
1. Controlla se il progetto VBA è protetto da password per visualizzarne le proprietà.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Verifica se la presentazione contiene un progetto VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Cosa succede alle macro se salvo la presentazione come PPTX?**

Le macro verranno rimosse perché PPTX non supporta VBA. Per conservare le macro, scegli PPTM, PPSM o POTM.

**Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare i dati?**

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo all'interno di PowerPoint con le impostazioni di sicurezza appropriate.

**È supportato il lavoro con controlli ActiveX collegati a codice VBA?**

Sì, è possibile accedere ai [controlli ActiveX](/slides/it/python-net/activex/) esistenti, modificarne le proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.