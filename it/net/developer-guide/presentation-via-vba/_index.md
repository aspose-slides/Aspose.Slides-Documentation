---
title: Gestire progetti VBA nelle presentazioni in .NET
linktitle: Presentazione via VBA
type: docs
weight: 250
url: /it/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come generare e manipolare presentazioni PowerPoint e OpenDocument via VBA con Aspose.Slides per .NET per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Lo spazio dei nomi [Aspose.Slides.Vba](https://reference.aspose.com/slides/it/net/aspose.slides.vba/) contiene classi e interfacce per lavorare con macro e codice VBA.

{{% alert title="Nota" color="warning" %}} 

Quando converti una presentazione contenente macro in un formato di file diverso (PDF, HTML, ecc.), Aspose.Slides ignora tutte le macro (le macro non vengono trasferite nel file risultante).

Quando aggiungi macro a una presentazione o la risalvi contenente macro, Aspose.Slides scrive semplicemente i byte delle macro.

Aspose.Slides **non** esegue mai le macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/net/aspose.slides.vba/vbaproject/) per consentirti di creare progetti VBA (e riferimenti di progetto) e modificare i moduli esistenti. Puoi utilizzare l'interfaccia [IVbaProject](https://reference.aspose.com/slides/it/net/aspose.slides.vba/ivbaproject/) per gestire il VBA incorporato in una presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Usa il costruttore [VbaProject](https://reference.aspose.com/slides/it/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) per aggiungere un nuovo progetto VBA.
3. Aggiungi un modulo al VbaProject.
4. Imposta il codice sorgente del modulo.
5. Aggiungi riferimenti a <stdole>.
6. Aggiungi riferimenti a **Microsoft Office**.
7. Associa i riferimenti al progetto VBA.
8. Salva la presentazione.

Questo codice C# mostra come aggiungere una macro VBA da zero a una presentazione:

```c#
    // Crea un'istanza della classe Presentation
using (Presentation presentation = new Presentation())
{
    // Crea un nuovo progetto VBA
    presentation.VbaProject = new VbaProject();

    // Aggiunge un modulo vuoto al progetto VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Imposta il codice sorgente del modulo
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Crea un riferimento a <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Crea un riferimento a Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Aggiunge riferimenti al progetto VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Salva la presentazione
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Potresti voler provare **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), una app web gratuita per rimuovere le macro da documenti PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Rimuovere macro VBA**
Utilizzando la proprietà [VbaProject](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/vbaproject/) della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), è possibile rimuovere una macro VBA.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e carica la presentazione contenente la macro.
2. Accedi al modulo Macro e rimuovilo.
3. Salva la presentazione modificata.

Questo codice C# mostra come rimuovere una macro VBA:

```c#
    // Carica la presentazione contenente la macro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Accede al modulo Vba e lo rimuove 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Salva la presentazione
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Estrarre macro VBA**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e carica la presentazione contenente la macro.
2. Verifica se la presentazione contiene un progetto VBA.
3. Scorri tutti i moduli contenuti nel progetto VBA per visualizzare le macro.

Questo codice C# mostra come estrarre le macro VBA da una presentazione contenente macro:

```c#
    // Carica la presentazione contenente la macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Verifica se la presentazione contiene un progetto VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Verificare se un progetto VBA è protetto da password**

Utilizzando la proprietà [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/it/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), è possibile determinare se le proprietà di un progetto sono protette da password.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e carica una presentazione che contiene una macro.
2. Verifica se la presentazione contiene un [progetto VBA](https://reference.aspose.com/slides/it/net/aspose.slides.vba/vbaproject/).
3. Verifica se il progetto VBA è protetto da password per visualizzarne le proprietà.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Verifica se la presentazione contiene un progetto VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

**Cosa succede alle macro se salvo la presentazione come PPTX?**

Le macro verranno rimosse perché il formato PPTX non supporta VBA. Per mantenere le macro, scegli PPTM, PPSM o POTM.

**Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare i dati?**

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo all'interno di PowerPoint con le impostazioni di sicurezza appropriate.

**È supportato il lavoro con controlli ActiveX collegati al codice VBA?**

Sì, è possibile accedere ai [controlli ActiveX](/slides/it/net/activex/) esistenti, modificarne le proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.