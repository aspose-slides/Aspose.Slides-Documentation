---
title: Beheer VBA‑projecten in presentaties met C++
linktitle: Presentatie via VBA
type: docs
weight: 250
url: /nl/cpp/presentation-via-vba/
keywords:
- macro
- VBA
- VBA‑macro
- macro toevoegen
- macro verwijderen
- macro extraheren
- VBA toevoegen
- VBA verwijderen
- VBA extraheren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u PowerPoint‑ en OpenDocument‑presentaties via VBA kunt genereren en bewerken met Aspose.Slides voor C++ om uw workflow te stroomlijnen."
---
## **Inleiding**

De [Aspose.Slides.Vba](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.vba/) namespace bevat klassen en interfaces voor het werken met macro’s en VBA‑code.

{{% alert title="Note" color="warning" %}} 

Wanneer u een presentatie met macro’s converteert naar een ander bestandsformaat (PDF, HTML, enz.), negeert Aspose.Slides alle macro’s (macro’s worden niet meegenomen in het resultaatbestand).

Wanneer u macro’s toevoegt aan een presentatie of een presentatie met macro’s opnieuw opslaat, schrijft Aspose.Slides simpelweg de bytes voor de macro’s.

Aspose.Slides **loopt nooit** de macro’s in een presentatie uit.

{{% /alert %}}

## **VBA‑macro’s toevoegen**

Aspose.Slides biedt de [VbaProject](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.vba.vba_project) klasse om VBA‑projecten (en projectreferenties) aan te maken en bestaande modules te bewerken. U kunt de [IVbaProject](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.vba.i_vba_project/) interface gebruiken om VBA die in een presentatie is ingebed te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.
1. Gebruik de [VbaProject](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b)‑constructor om een nieuw VBA‑project toe te voegen.
1. Voeg een module toe aan het VbaProject.
1. Stel de broncode van de module in.
1. Voeg referenties toe aan <stdole>.
1. Voeg referenties toe aan **Microsoft Office**.
1. Koppel de referenties aan het VBA‑project.
1. Sla de presentatie op.

Deze C++‑code laat zien hoe u vanuit nul een VBA‑macro aan een presentatie toevoegt: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Het pad naar de documentdirectory.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Maakt een instantie van de presentatie‑klasse
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Maakt een nieuw VBA‑project.
presentation->set_VbaProject(MakeObject<VbaProject>());

// Voegt een lege module toe aan het VBA‑project
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Stelt de broncode van de module in
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Maakt een referentie naar <stdole> aan
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Maakt een referentie naar Office aan
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Voegt referenties toe aan het VBA‑project
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Slaat de presentatie op
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);


```

{{% alert color="info" %}} 

U wilt wellicht de **Aspose** [Macro Remover](https://products.aspose.app/slides/nl/remove-macros) bekijken, een gratis web‑app om macro’s uit PowerPoint‑, Excel‑ en Word‑documenten te verwijderen. 

{{% /alert %}} 

## **VBA‑macro’s verwijderen**

Via de [VbaProject](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4)‑eigenschap van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse kunt u een VBA‑macro verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie met de macro.
1. Open de macro‑module en verwijder deze.
1. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe u een VBA‑macro verwijdert: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Het pad naar de documentdirectory.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Laadt de presentatie die de macro bevat
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Benadert de Vba‑module en verwijdert deze
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Slaat de presentatie op
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA‑macro’s extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse en laad de presentatie met de macro.
2. Controleer of de presentatie een VBA‑project bevat.
3. Loop door alle modules in het VBA‑project om de macro’s te bekijken.

Deze C++‑code laat zien hoe u VBA‑macro’s uit een presentatie met macro’s haalt: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// Het pad naar de documentdirectory.
	const String templatePath = u"../templates/VBA.pptm";

	// Laadt de presentatie die de macro bevat
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Controleert of de presentatie een VBA‑project bevat
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

## **Controleren of een VBA‑project met wachtwoord beveiligd is**

Met de [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/nl/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/)‑eigenschap kunt u bepalen of de eigenschappen van een project met een wachtwoord zijn beveiligd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse en laad een presentatie die een macro bevat.
2. Controleer of de presentatie een [VBA‑project](https://reference.aspose.com/slides/nl/cpp/aspose.slides.vba/vbaproject/) bevat.
3. Controleer of het VBA‑project met een wachtwoord is beveiligd om de eigenschappen te bekijken.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Controleer of de presentatie een VBA‑project bevat.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### Wat gebeurt er met macro’s als ik de presentatie opsla als PPTX?

Macro’s worden verwijderd omdat PPTX geen VBA ondersteunt. Kies PPTM, PPSM of POTM om macro’s te behouden.

### Kan Aspose.Slides macro’s in een presentatie uitvoeren, bijvoorbeeld om data te vernieuwen?

Nee. De bibliotheek voert nooit VBA‑code uit; uitvoering is alleen mogelijk binnen PowerPoint met de juiste beveiligingsinstellingen.

### Wordt werken met ActiveX‑besturingselementen die aan VBA‑code gekoppeld zijn ondersteund?

Ja, u kunt bestaande [ActiveX‑besturingselementen](/slides/nl/cpp/activex/) benaderen, hun eigenschappen wijzigen en ze verwijderen. Dit is nuttig wanneer macro’s interactief zijn met ActiveX.