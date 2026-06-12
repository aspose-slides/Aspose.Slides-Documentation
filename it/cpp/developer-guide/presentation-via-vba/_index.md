---
title: Gestisci progetti VBA nelle presentazioni con C++
linktitle: Presentazione via VBA
type: docs
weight: 250
url: /it/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Scopri come generare e manipolare presentazioni PowerPoint e OpenDocument tramite VBA con Aspose.Slides per C++ per semplificare il tuo flusso di lavoro."
---
## **Introduzione**

Il namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.vba/) contiene classi e interfacce per lavorare con macro e codice VBA.

{{% alert title="Nota" color="warning" %}} 

Quando converti una presentazione contenente macro in un formato di file diverso (PDF, HTML, ecc.), Aspose.Slides ignora tutte le macro (le macro non vengono trasferite nel file risultante).

Quando aggiungi macro a una presentazione o salvi nuovamente una presentazione contenente macro, Aspose.Slides scrive semplicemente i byte delle macro.

Aspose.Slides **non** esegue mai le macro in una presentazione.

{{% /alert %}}

## **Aggiungere macro VBA**

Aspose.Slides fornisce la classe [VbaProject](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.vba.vba_project) per consentirti di creare progetti VBA (e riferimenti di progetto) e modificare i moduli esistenti. Puoi utilizzare l'interfaccia [IVbaProject](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.vba.i_vba_project/) per gestire il VBA incorporato in una presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Usa il costruttore [VbaProject](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) per aggiungere un nuovo progetto VBA.
1. Aggiungi un modulo al VbaProject.
1. Imposta il codice sorgente del modulo.
1. Aggiungi riferimenti a <stdole>.
1. Aggiungi riferimenti a **Microsoft Office**.
1. Associa i riferimenti al progetto VBA.
1. Salva la presentazione.

Questo codice C++ mostra come aggiungere una macro VBA da zero a una presentazione: 

```c++
// Il percorso della cartella dei documenti.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Crea un'istanza della classe Presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Crea un nuovo progetto VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Aggiunge un modulo vuoto al progetto VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Imposta il codice sorgente del modulo
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Crea un riferimento a <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crea un riferimento a Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Aggiunge riferimenti al progetto VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Salva la presentazione
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

Potresti voler provare **Aspose** [Macro Remover](https://products.aspose.app/slides/it/remove-macros), un'app web gratuita per rimuovere le macro da documenti PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Rimuovere macro VBA**

Utilizzando la proprietà [VbaProject](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation), puoi rimuovere una macro VBA.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione contenente la macro.
1. Accedi al modulo Macro e rimuovilo.
1. Salva la presentazione modificata.

Questo codice C++ mostra come rimuovere una macro VBA: 

```c++
// Il percorso della cartella dei documenti.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Carica la presentazione contenente la macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accede al modulo Vba e lo rimuove 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Salva la presentazione
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Estrarre macro VBA**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione contenente la macro.
2. Verifica se la presentazione contiene un progetto VBA.
3. Scorri tutti i moduli contenuti nel progetto VBA per visualizzare le macro.

Questo codice C++ mostra come estrarre macro VBA da una presentazione contenente macro: 

```c++

	// Il percorso della cartella dei documenti.
	const String templatePath = u"../templates/VBA.pptm";

	// Carica la presentazione contenente la macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Verifica se la Presentazione contiene un progetto VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Verificare se un progetto VBA è protetto da password**

Utilizzando la proprietà [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/it/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), è possibile determinare se le proprietà di un progetto sono protette da password.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e carica una presentazione che contiene una macro.
2. Verifica se la presentazione contiene un [progetto VBA](https://reference.aspose.com/slides/it/cpp/aspose.slides.vba/vbaproject/).
3. Controlla se il progetto VBA è protetto da password per visualizzarne le proprietà.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Verifica se la presentazione contiene un progetto VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

**Cosa succede alle macro se salvo la presentazione come PPTX?**

Le macro verranno rimosse perché il formato PPTX non supporta VBA. Per mantenere le macro, scegli PPTM, PPSM o POTM.

**Aspose.Slides può eseguire macro all'interno di una presentazione per, ad esempio, aggiornare i dati?**

No. La libreria non esegue mai codice VBA; l'esecuzione è possibile solo all'interno di PowerPoint con le impostazioni di sicurezza appropriate.

**È supportato il lavoro con controlli ActiveX collegati a codice VBA?**

Sì, puoi accedere ai [controlli ActiveX](/slides/it/cpp/activex/), modificarne le proprietà e rimuoverli. Questo è utile quando le macro interagiscono con ActiveX.