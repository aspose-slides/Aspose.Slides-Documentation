---
title: Gestire progetti VBA nelle presentazioni usando Python
linktitle: Presentazione tramite VBA
type: docs
weight: 250
url: /it/python-java/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- aggiungi macro
- rimuovi macro
- estrai macro
- aggiungi VBA
- rimuovi VBA
- estrai VBA
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come generare e manipolare presentazioni PowerPoint e OpenDocument tramite VBA con Aspose.Slides per Python via Java per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Aspose.Slides fornisce classi e interfacce per lavorare con macro e codice VBA.

{{% alert title="Avviso" color="warning" %}} 

Quando converti una presentazione contenente macro in un formato di file diverso (PDF, HTML, ecc.), Aspose.Slides ignora tutte le macro (le macro non vengono riportate nel file risultante).

Quando aggiungi macro a una presentazione o la risalvi contenente macro, Aspose.Slides scrive semplicemente i byte delle macro.

Aspose.Slides **non** esegue mai le macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/python-java/aspose.slides/vbaproject/) per consentirti di creare progetti VBA (e riferimenti di progetto) e modificare i moduli esistenti. Puoi utilizzare la classe [VbaProject](https://reference.aspose.com/slides/it/python-java/aspose.slides/vbaproject/) per gestire il VBA incorporato in una presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Usa il costruttore [VbaProject](https://reference.aspose.com/slides/it/python-java/aspose.slides/vbaproject/#vbaproject) per aggiungere un nuovo progetto VBA.
3. Aggiungi un modulo al progetto VBA.
4. Imposta il codice sorgente del modulo.
5. Aggiungi riferimenti a `stdole`.
6. Aggiungi riferimenti a **Microsoft Office**.
7. Associa i riferimenti al progetto VBA.
8. Salva la presentazione.

Questo codice Python mostra come aggiungere una macro VBA da zero a una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Crea un nuovo progetto VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Aggiungi un modulo vuoto e imposta il suo codice sorgente.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Crea riferimenti a stdole e Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Aggiungi riferimenti al progetto VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Salva la presentazione.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 

Potresti voler provare **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), che è un'app web gratuita per rimuovere macro da documenti PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Rimuovere macro VBA**

Utilizzando il metodo [getVbaProject](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getvbaproject) della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), è possibile rimuovere una macro VBA.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente la macro.
2. Accedi al modulo macro e rimuovilo.
3. Salva la presentazione modificata.

Questo codice Python mostra come rimuovere una macro VBA:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carica la presentazione contenente la macro.
presentation = Presentation("VBA.pptm")
try:
    # Accedi al modulo VBA e rimuovilo.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Salva la presentazione.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Estrai macro VBA**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente la macro.
2. Verifica se la presentazione contiene un progetto VBA.
3. Scorri tutti i moduli contenuti nel progetto VBA per visualizzare le macro.

Questo codice Python mostra come estrarre le macro VBA da una presentazione contenente macro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Carica la presentazione contenente la macro.
presentation = Presentation("VBA.pptm")
try:
    # Verifica se la presentazione contiene un progetto VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Verificare se un progetto VBA è protetto da password**

Utilizzando il metodo [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/vbaproject/#ispasswordprotected), è possibile determinare se le proprietà di un progetto sono protette da password.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica una presentazione che contiene una macro.
2. Verifica se la presentazione contiene un [progetto VBA](https://reference.aspose.com/slides/it/python-java/aspose.slides/vbaproject/).
3. Verifica se il progetto VBA è protetto da password per visualizzare le sue proprietà.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Verifica se la presentazione contiene un progetto VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Cosa succede alle macro se salvo la presentazione come PPTX?**

Le macro verranno rimosse perché PPTX non supporta VBA. Per mantenere le macro, scegli PPTM, PPSM o POTM.

**Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare i dati?**

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo all'interno di PowerPoint con le impostazioni di sicurezza appropriate.

**È supportato il lavoro con controlli ActiveX collegati al codice VBA?**

Sì, è possibile accedere ai [controlli ActiveX](/slides/it/python-java/activex/), modificare le loro proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.