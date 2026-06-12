---
title: Gestire progetti VBA nelle presentazioni usando JavaScript
linktitle: Presentazione tramite VBA
type: docs
weight: 250
url: /it/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Genera e manipola presentazioni PowerPoint e OpenDocument tramite VBA in JavaScript con Aspose.Slides per Node.js via Java per semplificare il tuo flusso di lavoro."
---
## **Introduzione**

Aspose.Slides fornisce classi per lavorare con macro e codice VBA.

{{% alert title="Nota" color="warning" %}} 

Quando converti una presentazione contenente macro in un formato di file diverso (PDF, HTML, ecc.), Aspose.Slides ignora tutte le macro (le macro non vengono trasferite nel file risultante).

Quando aggiungi macro a una presentazione o salvi nuovamente una presentazione contenente macro, Aspose.Slides scrive semplicemente i byte delle macro.

Aspose.Slides **mai** esegue le macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/vbaproject/) per consentire di creare progetti VBA (e riferimenti a progetti) e modificare i moduli esistenti. Puoi usare la classe [VbaProject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/vbaproject/) per gestire il VBA incorporato in una presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Usa il costruttore [VbaProject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/vbaproject/#VbaProject--) per aggiungere un nuovo progetto VBA.
1. Aggiungi un modulo al VbaProject.
1. Imposta il codice sorgente del modulo.
1. Aggiungi riferimenti a <stdole>.
1. Aggiungi riferimenti a **Microsoft Office**.
1. Associa i riferimenti al progetto VBA.
1. Salva la presentazione.

Questo codice JavaScript mostra come aggiungere una macro VBA da zero a una presentazione:

```javascript
// Crea un'istanza della classe di presentazione
let pres = new aspose.slides.Presentation();
try {
    // Crea un nuovo progetto VBA
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Aggiunge un modulo vuoto al progetto VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Imposta il codice sorgente del modulo
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Crea un riferimento a <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Crea un riferimento a Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Aggiunge riferimenti al progetto VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Salva la presentazione
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Potresti voler provare **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), una app web gratuita utilizzata per rimuovere le macro da documenti PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Rimuovere macro VBA**

Utilizzando la proprietà [VbaProject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getVbaProject--) della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation), è possibile rimuovere una macro VBA.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e carica la presentazione contenente la macro.
1. Accedi al modulo Macro e rimuovilo.
1. Salva la presentazione modificata.

Questo codice JavaScript mostra come rimuovere una macro VBA:

```javascript
// Carica la presentazione contenente la macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Accede al modulo Vba e lo rimuove
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Salva la presentazione
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Estrarre macro VBA**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e carica la presentazione contenente la macro.
2. Verifica se la presentazione contiene un progetto VBA.
3. Scorri tutti i moduli contenuti nel progetto VBA per visualizzare le macro.

Questo codice JavaScript mostra come estrarre le macro VBA da una presentazione contenente macro:

```javascript
// Carica la presentazione contenente la macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Verifica se la presentazione contiene un progetto VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Verificare se un progetto VBA è protetto da password**

Utilizzando il metodo [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), è possibile determinare se le proprietà di un progetto sono protette da password.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica una presentazione che contiene una macro.
2. Verifica se la presentazione contiene un [progetto VBA](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/vbaproject/).
3. Verifica se il progetto VBA è protetto da password per visualizzare le sue proprietà.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Verifica se la presentazione contiene un progetto VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Cosa succede alle macro se salvo la presentazione come PPTX?**

Le macro verranno rimosse perché il formato PPTX non supporta VBA. Per mantenere le macro, scegli PPTM, PPSM o POTM.

**Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare i dati?**

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo in PowerPoint con le impostazioni di sicurezza appropriate.

**È supportato il lavoro con controlli ActiveX collegati a codice VBA?**

Sì, è possibile accedere ai [controlli ActiveX](/slides/it/nodejs-java/activex/), modificarne le proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.