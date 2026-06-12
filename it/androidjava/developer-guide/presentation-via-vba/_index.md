---
title: Gestire progetti VBA nelle presentazioni su Android
linktitle: Presentazione tramite VBA
type: docs
weight: 250
url: /it/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Scopri come generare e manipolare presentazioni PowerPoint e OpenDocument tramite VBA con Aspose.Slides per Android via Java per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Aspose.Slides fornisce classi e interfacce per lavorare con macro e codice VBA.

{{% alert title="Note" color="warning" %}} 

Quando si converte una presentazione contenente macro in un formato file diverso (PDF, HTML, ecc.), Aspose.Slides ignora tutte le macro (le macro non vengono trasferite nel file risultante).

Quando si aggiungono macro a una presentazione o si risalva una presentazione contenente macro, Aspose.Slides scrive semplicemente i byte delle macro.

Aspose.Slides **non** esegue mai le macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/vbaproject/) per consentire la creazione di progetti VBA (e riferimenti di progetto) e la modifica di moduli esistenti. È possibile utilizzare l'interfaccia [IVbaProject](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivbaproject/) per gestire il VBA incorporato in una presentazione.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Utilizzare il costruttore [VbaProject](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/vbaproject/#VbaProject--) per aggiungere un nuovo progetto VBA.
1. Aggiungere un modulo al VbaProject.
1. Impostare il codice sorgente del modulo.
1. Aggiungere riferimenti a <stdole>.
1. Aggiungere riferimenti a **Microsoft Office**.
1. Associare i riferimenti al progetto VBA.
1. Salvare la presentazione.

Questo codice Java mostra come aggiungere una macro VBA da zero a una presentazione:

```java
// Crea un'istanza della classe presentation
Presentation pres = new Presentation();
try {
    // Crea un nuovo progetto VBA
    pres.setVbaProject(new VbaProject());
    
    // Aggiunge un modulo vuoto al progetto VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Imposta il codice sorgente del modulo
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Crea un riferimento a <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Crea un riferimento a Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Aggiunge riferimenti al progetto VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Salva la presentazione
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Potresti voler provare **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), una app web gratuita per rimuovere le macro da documenti PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Rimuovere macro VBA**

Utilizzando la proprietà [VbaProject](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getVbaProject--) della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation), è possibile rimuovere una macro VBA.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione contenente la macro.
1. Accedere al modulo Macro e rimuoverlo.
1. Salvare la presentazione modificata.

Questo codice Java mostra come rimuovere una macro VBA:

```java
// Carica la presentazione contenente la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Accede al modulo Vba e lo rimuove 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Salva la presentazione
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Estrazione macro VBA**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione contenente la macro.
2. Verificare se la presentazione contiene un progetto VBA.
3. Iterare tutti i moduli contenuti nel progetto VBA per visualizzare le macro.

Questo codice Java mostra come estrarre le macro VBA da una presentazione contenente macro:

```java
// Carica la presentazione contenente la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Verifica se la presentazione contiene un progetto VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verificare se un progetto VBA è protetto da password**

Utilizzando il metodo [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--), è possibile determinare se le proprietà di un progetto sono protette da password.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e caricare una presentazione che contiene una macro.
2. Verificare se la presentazione contiene un [progetto VBA](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/vbaproject/).
3. Verificare se il progetto VBA è protetto da password per visualizzarne le proprietà.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Verifica se la presentazione contiene un progetto VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Cosa succede alle macro se salvo la presentazione come PPTX?**

Le macro verranno rimosse perché il formato PPTX non supporta VBA. Per conservare le macro, scegliere PPTM, PPSM o POTM.

**Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare dati?**

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo all'interno di PowerPoint con le impostazioni di sicurezza appropriate.

**È supportato lavorare con controlli ActiveX collegati a codice VBA?**

Sì, è possibile accedere ai [controlli ActiveX](/slides/it/androidjava/activex/), modificarne le proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.