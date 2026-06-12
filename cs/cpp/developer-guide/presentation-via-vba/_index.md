---
title: Správa VBA projektů v prezentacích pomocí C++
linktitle: Prezentace přes VBA
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
description: "Objevte, jak pomocí Aspose.Slides pro C++ vytvářet a manipulovat s prezentacemi PowerPoint a OpenDocument přes VBA, abyste zjednodušili svůj pracovní postup."
---
## **Úvod**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Poznámka" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Přidat VBA makra**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.vba.vba_project) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.vba.i_vba_project/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This C++ code shows you how to add a VBA macro from scratch to a presentation: 

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Vytvoří instanci třídy prezentace
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Vytvoří nový VBA projekt
presentation->set_VbaProject(MakeObject<VbaProject>());

// Přidá prázdný modul do VBA projektu
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Nastaví zdrojový kód modulu
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Vytvoří odkaz na <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Vytvoří odkaz na Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Přidá odkazy do VBA projektu
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Uloží prezentaci
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);


```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Odstranit VBA makra**

Using the [VbaProject](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) property under the [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This C++ code shows you how to remove a VBA macro: 

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Načte prezentaci obsahující makro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Přistoupí k Vba modulu a odebere jej
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Uloží prezentaci
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Extrahovat VBA makra**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This C++ code shows you how to extract VBA macros from a presentation containing macros: 

```c++

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

## **Zkontrolovat, zda je VBA projekt chráněn heslem**

Using the [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/cs/cpp/aspose.slides.vba/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Zkontroluje, zda prezentace obsahuje VBA projekt.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **Často kladené otázky**

**Co se stane s makry, když uložíte prezentaci jako PPTX?**

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

**Může Aspose.Slides spouštět makra v prezentaci, například k aktualizaci dat?**

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

**Je podporována práce s ActiveX ovládacími prvky spojenými s VBA kódem?**

Yes, you can access existing [ActiveX controls](/slides/cs/cpp/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.