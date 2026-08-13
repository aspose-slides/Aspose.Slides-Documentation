---
title: Správa projektů VBA v prezentacích pomocí C++
linktitle: Prezentace pomocí VBA
type: docs
weight: 250
url: /cs/cpp/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- přidat makro
- odstranit makro
- extrahovat makro
- přidat VBA
- odstranit VBA
- extrahovat VBA
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak pomocí VBA vygenerovat a manipulovat s prezentacemi PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, abyste zefektivnili svůj pracovní postup."
---
## **Úvod**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Poznámka" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Přidání VBA maker**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.vba.vba_project) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.vba.i_vba_project/) interface to manage VBA embedded in a presentation.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) k přidání nového VBA projektu.
1. Přidejte modul do VbaProject.
1. Nastavte zdrojový kód modulu.
1. Přidejte odkazy na <stdole>.
1. Přidejte odkazy na **Microsoft Office**.
1. Propojte odkazy s VBA projektem.
1. Uložte prezentaci.

This C++ code shows you how to add a VBA macro from scratch to a presentation: 

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

// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Vytvoří instanci třídy Presentation.
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Vytvoří nový VBA projekt.
presentation->set_VbaProject(MakeObject<VbaProject>());

// Přidá prázdný modul do VBA projektu.
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Nastaví zdrojový kód modulu.
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Vytvoří odkaz na <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Vytvoří odkaz na Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Přidá odkazy do VBA projektu.
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Uloží prezentaci.
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Odstranění VBA maker**

Using the [VbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) property under the [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) class, you can remove a VBA macro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci obsahující makro.
1. Přistupte k modulu Macro a odstraňte jej.
1. Uložte upravenou prezentaci.

This C++ code shows you how to remove a VBA macro: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Cesta k adresáři dokumentů.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Načte prezentaci obsahující makro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Přistoupí k modulu Vba a odstraní jej
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Uloží prezentaci
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Extrahování VBA maker**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje VBA Project.
3. Procházejte všechny moduly obsažené v VBA Project a zobrazte makra.

This C++ code shows you how to extract VBA macros from a presentation containing macros: 

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

	// Cesta k adresáři dokumentů.
	const String templatePath = u"../templates/VBA.pptm";

	// Načte prezentaci obsahující makro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Kontroluje, zda prezentace obsahuje VBA projekt
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

## **Kontrola, zda je VBA projekt chráněn heslem**

Using the [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA project](https://reference.aspose.com/slides/cs/cpp/aspose.slides.vba/vbaproject/).
3. Zkontrolujte, zda je VBA projekt chráněn heslem, a podívejte se na jeho vlastnosti.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Zkontrolujte, zda prezentace obsahuje VBA projekt.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### Co se stane s makry, když uložíte prezentaci jako PPTX?

Makra budou odstraněna, protože PPTX nepodporuje VBA. Pro zachování maker zvolte PPTM, PPSM nebo POTM.

### Může Aspose.Slides spouštět makra v prezentaci, například pro aktualizaci dat?

Ne. Knihovna nikdy nespouští VBA kód; vykonání je možné pouze v PowerPointu s vhodnými bezpečnostními nastaveními.

### Je podpora pro práci s ActiveX ovládacími prvky propojenými s VBA kódem?

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/cpp/activex/), měnit jejich vlastnosti a odstraňovat je. To je užitečné, když makra interagují s ActiveX.