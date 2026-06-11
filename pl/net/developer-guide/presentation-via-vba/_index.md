---
title: Zarządzanie projektami VBA w prezentacjach w .NET
linktitle: Prezentacja przy użyciu VBA
type: docs
weight: 250
url: /pl/net/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- dodaj makro
- usuń makro
- wyodrębnij makro
- dodaj VBA
- usuń VBA
- wyodrębnij VBA
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak generować i manipulować prezentacjami PowerPoint i OpenDocument przy użyciu VBA z Aspose.Slides dla .NET, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Przestrzeń nazw [Aspose.Slides.Vba](https://reference.aspose.com/slides/pl/net/aspose.slides.vba/) zawiera klasy i interfejsy umożliwiające pracę z makrami i kodem VBA.

{{% alert title="Uwaga" color="warning" %}} 

Gdy konwertujesz prezentację zawierającą makra do innego formatu pliku (PDF, HTML itp.), Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do wynikowego pliku).

Gdy dodajesz makra do prezentacji lub ponownie zapisujesz prezentację zawierającą makra, Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodaj makra VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/net/aspose.slides.vba/vbaproject/) umożliwiającą tworzenie projektów VBA (i odwołań do projektów) oraz edycję istniejących modułów. Możesz użyć interfejsu [IVbaProject](https://reference.aspose.com/slides/pl/net/aspose.slides.vba/ivbaproject/) do zarządzania VBA osadzonym w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/net/aspose.slides.vba/vbaproject/vbaproject/#constructor), aby dodać nowy projekt VBA.
1. Dodaj moduł do VbaProject.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołania do <stdole>.
1. Dodaj odwołania do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

W tym kodzie C# pokazano, jak dodać makro VBA od podstaw do prezentacji:

```c#
    // Tworzy instancję klasy prezentacji
using (Presentation presentation = new Presentation())
{
    // Tworzy nowy projekt VBA
    presentation.VbaProject = new VbaProject();

    // Dodaje pusty moduł do projektu VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Ustawia kod źródłowy modułu
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Tworzy odwołanie do <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Tworzy odwołanie do Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Dodaje odwołania do projektu VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Zapisuje prezentację
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Możesz zainteresować się **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), który jest darmową aplikacją webową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word. 

{{% /alert %}} 

## **Usuń makra VBA**
Używając właściwości [VbaProject](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/vbaproject/) w klasie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
1. Uzyskaj dostęp do modułu Macro i usuń go.
1. Zapisz zmodyfikowaną prezentację.

W tym kodzie C# pokazano, jak usunąć makro VBA:

```c#
    // Ładuje prezentację zawierającą makro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Uzyskuje dostęp do modułu Vba i usuwa go 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Zapisuje prezentację
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Wyodrębnij makra VBA**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Przejdź pętlą przez wszystkie moduły znajdujące się w projekcie VBA, aby wyświetlić makra.

W tym kodzie C# pokazano, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

```c#
    // Ładuje prezentację zawierającą makro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Sprawdza, czy prezentacja zawiera projekt VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Sprawdź, czy projekt VBA jest chroniony hasłem**

Używając właściwości [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/pl/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), możesz określić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i wczytaj prezentację, która zawiera makro.
2. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/net/aspose.slides.vba/vbaproject/).
3. Sprawdź, czy projekt VBA jest chroniony hasłem, aby wyświetlić jego właściwości.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Sprawdza, czy prezentacja zawiera projekt VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

**Co się dzieje z makrami, jeśli zapisuję prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, na przykład w celu odświeżenia danych?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonywanie jest możliwe wyłącznie w PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/net/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.