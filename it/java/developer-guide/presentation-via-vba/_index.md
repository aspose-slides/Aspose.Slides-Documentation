---
title: Gestire i progetti VBA nelle presentazioni usando Java
linktitle: Presentazione tramite VBA
type: docs
weight: 250
url: /it/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Scopri come generare e manipolare presentazioni PowerPoint e OpenDocument tramite VBA con Aspose.Slides per Java per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Aspose.Slides fornisce classi e interfacce per lavorare con macro e codice VBA.

{{% alert title="Note" color="warning" %}} 

Quando converti una presentazione contenente macro in un formato di file diverso (PDF, HTML, ecc.), Aspose.Slides ignora tutte le macro (le macro non vengono trasferite nel file risultante).

Quando aggiungi macro a una presentazione o risalvi una presentazione contenente macro, Aspose.Slides scrive semplicemente i byte delle macro.

Aspose.Slides **non** esegue mai le macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/java/com.aspose.slides/vbaproject/) per consentirti di creare progetti VBA (e riferimenti a progetti) e modificare i moduli esistenti. Puoi usare l'interfaccia [IVbaProject](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivbaproject/) per gestire il VBA incorporato in una presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) .
2. Usa il costruttore [VbaProject](https://reference.aspose.com/slides/it/java/com.aspose.slides/vbaproject/#VbaProject--) per aggiungere un nuovo progetto VBA.
3. Aggiungi un modulo al VbaProject.
4. Imposta il codice sorgente del modulo.
5. Aggiungi riferimenti a <stdole>.
6. Aggiungi riferimenti a **Microsoft Office**.
7. Associa i riferimenti al progetto VBA.
8. Salva la presentazione.

Questo codice Java mostra come aggiungere una macro VBA da zero a una presentazione:

```java
import com.aspose.slides.*;

// Crea un'istanza della classe Presentation
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

{{% alert color="info" %}} 

Potresti voler provare **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), che è un'app web gratuita utilizzata per rimuovere le macro da documenti PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Rimuovere macro VBA**

Utilizzando la proprietà [VbaProject](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getVbaProject--) nella classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation), è possibile rimuovere una macro VBA.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione contenente la macro.
2. Accedi al modulo Macro e rimuovilo.
3. Salva la presentazione modificata.

Questo codice Java mostra come rimuovere una macro VBA:

```java
import com.aspose.slides.*;

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

## **Estrarre macro VBA**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione contenente la macro.
2. Verifica se la presentazione contiene un progetto VBA.
3. Scorri tutti i moduli contenuti nel progetto VBA per visualizzare le macro.

Questo codice Java mostra come estrarre le macro VBA da una presentazione contenente macro:

```java
import com.aspose.slides.*;

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

Utilizzando il metodo [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) è possibile determinare se le proprietà di un progetto sono protette da password.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica una presentazione che contiene una macro.
2. Verifica se la presentazione contiene un [progetto VBA](https://reference.aspose.com/slides/it/java/com.aspose.slides/vbaproject/).
3. Verifica se il progetto VBA è protetto da password per visualizzarne le proprietà.

```java
import com.aspose.slides.*;

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

### Cosa succede alle macro se salvo la presentazione come PPTX?

Le macro verranno rimosse perché PPTX non supporta VBA. Per mantenere le macro, scegli PPTM, PPSM o POTM.

### Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare dati?

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo all'interno di PowerPoint con le impostazioni di sicurezza appropriate.

### È supportato il lavoro con controlli ActiveX collegati al codice VBA?

Sì, è possibile accedere ai [controlli ActiveX](/slides/it/java/activex/), modificarne le proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.