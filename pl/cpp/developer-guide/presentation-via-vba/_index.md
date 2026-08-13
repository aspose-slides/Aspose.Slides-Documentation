---
title: "Zarządzanie projektami VBA w prezentacjach przy użyciu C++"
linktitle: "Prezentacja przez VBA"
type: docs
weight: 250
url: /pl/cpp/presentation-via-vba/
keywords:
  - "makro"
  - "VBA"
  - "makro VBA"
  - "dodaj makro"
  - "usuń makro"
  - "wyodrębnij makro"
  - "dodaj VBA"
  - "usuń VBA"
  - "wyodrębnij VBA"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - "C++"
  - "Aspose.Slides"
description: "Odkryj, jak generować i manipulować prezentacjami PowerPoint i OpenDocument przy użyciu VBA z Aspose.Slides dla C++, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Dodaj makra VBA**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.vba.vba_project) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.vba.i_vba_project/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

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

// Ścieżka do katalogu z dokumentami.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Tworzy instancję klasy prezentacji
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Tworzy nowy projekt VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Dodaje pusty moduł do projektu VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Ustawia kod źródłowy modułu
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Tworzy odwołanie do <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Tworzy odwołanie do Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Dodaje odwołania do projektu VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Zapisuje prezentację
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Usuń makra VBA**

Using the [VbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) property under the [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

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

// Ścieżka do katalogu z dokumentami.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Ładuje prezentację zawierającą makro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Uzyskuje dostęp do modułu Vba i usuwa go
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Zapisuje prezentację
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Wyodrębnij makra VBA**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

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

	// Ścieżka do katalogu z dokumentami.
	const String templatePath = u"../templates/VBA.pptm";

	// Ładuje prezentację zawierającą makro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Sprawdza, czy prezentacja zawiera projekt VBA
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

## **Sprawdź, czy projekt VBA jest chroniony hasłem**

Using the [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/pl/cpp/aspose.slides.vba/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Sprawdź, czy prezentacja zawiera projekt VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### Co się stanie z makrami, jeśli zapiszę prezentację jako PPTX?

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

### Czy Aspose.Slides może uruchamiać makra w prezentacji, aby na przykład odświeżyć dane?

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

### Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?

Yes, you can access existing [ActiveX controls](/slides/pl/cpp/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.