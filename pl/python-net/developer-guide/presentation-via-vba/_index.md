---
title: Zarządzanie projektami VBA w prezentacjach przy użyciu Pythona
linktitle: Prezentacja przez VBA
type: docs
weight: 250
url: /pl/python-net/presentation-via-vba/
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
- Python
- Aspose.Slides
description: "Odkryj, jak generować i manipulować prezentacjami PowerPoint i OpenDocument przy użyciu VBA w Aspose.Slides for Python via .NET, aby usprawnić swój przepływ pracy."
---
## **Przegląd**

Ten artykuł omawia kluczowe możliwości Aspose.Slides for Python via .NET w pracy z makrami w prezentacjach PowerPoint. Biblioteka zapewnia wygodne narzędzia do dodawania, usuwania i wyodrębniania makr, co umożliwia automatyzację tworzenia i modyfikacji prezentacji.

Z Aspose.Slides możesz:

- Przyspieszyć rozwój prezentacji — automatyzacja rutynowych zadań skraca czas potrzebny na przygotowanie materiałów.
- Zapewnić elastyczność — możliwość zarządzania makrami pozwala dostosować prezentacje do konkretnych zadań i scenariuszy.
- Zintegrować dane — prosta integracja z zewnętrznymi źródłami danych pomaga utrzymać zawartość slajdów na bieżąco.
- Uprościć konserwację — scentralizowane zarządzanie makrami ułatwia wprowadzanie zmian i aktualizację prezentacji.

Artykuł przedstawia praktyczne przykłady wykorzystania Aspose.Slides do efektywnej pracy z makrami w PowerPoint.

Przestrzeń nazw [aspose.slides.vba](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/) udostępnia klasy do pracy z makrami i kodem VBA.

{{% alert title="Note" color="warning" %}}
Podczas konwertowania prezentacji zawierającej makra do innego formatu (PDF, HTML itp.), Aspose.Slides ignoruje makra — nie są one przenoszone do pliku wyjściowego.

Podczas dodawania makr do prezentacji lub ponownego zapisywania prezentacji zawierającej makra, Aspose.Slides zapisuje bajty makr tak, jak są.

Aspose.Slides **nigdy** nie wykonuje makr w prezentacji.
{{% /alert %}}

## **Dodaj makra VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/vbaproject/) do tworzenia projektów VBA (i referencji projektów) oraz edytowania istniejących modułów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/vbaproject/#constructors), aby dodać nowy projekt VBA.
1. Dodaj moduł do projektu VBA.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołanie do `<stdole>`.
1. Dodaj odwołanie do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

Poniższy kod Python pokazuje, jak od podstaw dodać makro VBA do prezentacji:

```python
import aspose.slides as slides

    # Utwórz instancję klasy Presentation.
    with slides.Presentation() as presentation:

        # Utwórz nowy projekt VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Dodaj pusty moduł do projektu VBA.
        module = presentation.vba_project.modules.add_empty_module("Module")

        # Ustaw kod źródłowy modułu.
        module.source_code = """
            Sub Test(oShape As Shape)
                MsgBox "Hello, world!"
            End Sub
        """

        # Utwórz odwołanie do <stdole>.
        stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
            "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

        # Utwórz odwołanie do Microsoft Office.
        office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

        # Dodaj odwołania do projektu VBA.
        presentation.vba_project.references.add(stdole_reference)
        presentation.vba_project.references.add(office_reference)

        # Zapisz prezentację.
        presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Możesz wypróbować **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), darmową aplikację internetową do usuwania makr z dokumentów PowerPoint, Excel i Word.
{{% /alert %}}

## **Usuń makra VBA**

Korzystając z właściwości [vba_project](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/vba_project/) klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
1. Uzyskaj dostęp do modułu makra i usuń go.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod Python pokazuje, jak usunąć makro VBA:

```python
import aspose.slides as slides

# Załaduj prezentację, która zawiera makro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Uzyskaj dostęp do modułu VBA.
    vba_module = presentation.vba_project.modules[0]

    # Usuń moduł VBA.
    presentation.vba_project.modules.remove(vba_module)

    # Zapisz prezentację.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Wyodrębnij makra VBA**

Korzystając z właściwości `modules` w klasie [VbaProject](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/vbaproject/), możesz uzyskać dostęp do wszystkich modułów projektu VBA. Klasa [VbaModule](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/vbamodule/) może być użyta do wyodrębnienia właściwości modułu, takich jak nazwa i kod.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
1. Sprawdź, czy prezentacja zawiera projekt VBA.
1. Iteruj po wszystkich modułach w projekcie VBA, aby zobaczyć makra.

Poniższy kod Python pokazuje, jak wyodrębnić makra VBA z prezentacji:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Sprawdź, czy prezentacja zawiera projekt VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Sprawdź, czy projekt VBA jest chroniony hasłem**

Korzystając z właściwości [VbaProject.is_password_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/vbaproject/is_password_protected/), możesz określić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację, która zawiera makro.
1. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/python-net/aspose.slides.vba/vbaproject/).
1. Sprawdź, czy projekt VBA jest chroniony hasłem, aby zobaczyć jego właściwości.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Sprawdź, czy prezentacja zawiera projekt VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Co się stanie z makrami, jeśli zapiszę prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, np. aby odświeżyć dane?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonywanie jest możliwe tylko w PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/python-net/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.