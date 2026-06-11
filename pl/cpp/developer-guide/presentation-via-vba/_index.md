---
title: "Zarządzanie projektami VBA w prezentacjach przy użyciu C++"
linktitle: "Prezentacja przy użyciu VBA"
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
description: "Dowiedz się, jak generować i manipulować prezentacjami PowerPoint i OpenDocument przy użyciu VBA z Aspose.Slides dla C++, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Przestrzeń nazw [Aspose.Slides.Vba](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.vba/) zawiera klasy i interfejsy do pracy z makrami i kodem VBA.

{{% alert title="Note" color="warning" %}} 

Podczas konwertowania prezentacji zawierającej makra na inny format pliku (PDF, HTML itp.) Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do powstałego pliku).

Podczas dodawania makr do prezentacji lub ponownego zapisywania prezentacji zawierającej makra Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodawanie makr VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.vba.vba_project), która pozwala tworzyć projekty VBA (i odwołania do projektów) oraz edytować istniejące moduły. Do zarządzania kodem VBA osadzonym w prezentacji możesz użyć interfejsu [IVbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.vba.i_vba_project/) .

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b), aby dodać nowy projekt VBA.
1. Dodaj moduł do VbaProject.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołania do <stdole>.
1. Dodaj odwołania do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

Ten kod C++ pokazuje, jak od podstaw dodać makro VBA do prezentacji:

```c++
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

{{% alert color="primary" %}} 

Możesz wypróbować **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), darmową aplikację internetową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word. 

{{% /alert %}} 

## **Usuwanie makr VBA**

Korzystając z właściwości [VbaProject](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) dostępnej w klasie [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i załaduj prezentację zawierającą makro.
1. Uzyskaj dostęp do modułu makra i usuń go.
1. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak usunąć makro VBA:

```c++
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

## **Wyodrębnianie makr VBA**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i załaduj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Przejdź przez wszystkie moduły znajdujące się w projekcie VBA, aby wyświetlić makra.

Ten kod C++ pokazuje, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

```c++

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

## **Sprawdzanie, czy projekt VBA jest chroniony hasłem**

Używając właściwości [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), możesz określić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i załaduj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/cpp/aspose.slides.vba/vbaproject/).
3. Sprawdź, czy projekt VBA jest chroniony hasłem, aby wyświetlić jego właściwości.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Sprawdza, czy prezentacja zawiera projekt VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

**Co się stanie z makrami, jeśli zapiszę prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, np. odświeżać dane?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonywanie jest możliwe jedynie w PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługiwane jest korzystanie z kontrolek ActiveX powiązanych z kodem VBA?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/cpp/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.