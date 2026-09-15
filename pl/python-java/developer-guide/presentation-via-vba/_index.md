---
title: Zarządzanie projektami VBA w prezentacjach przy użyciu Pythona
linktitle: Prezentacja za pomocą VBA
type: docs
weight: 250
url: /pl/python-java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak generować i modyfikować prezentacje PowerPoint i OpenDocument przy użyciu VBA z Aspose.Slides dla Pythona w środowisku Java, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Aspose.Slides udostępnia klasy i interfejsy do pracy z makrami i kodem VBA.

{{% alert title="Warning" color="warning" %}} 

Kiedy konwertujesz prezentację zawierającą makra do innego formatu pliku (PDF, HTML itp.), Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do wynikowego pliku).

Kiedy dodajesz makra do prezentacji lub ponownie zapisujesz prezentację zawierającą makra, Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodawanie makr VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/vbaproject/), aby umożliwić tworzenie projektów VBA (i odwołań do projektów) oraz edytowanie istniejących modułów. Możesz używać klasy [VbaProject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/vbaproject/) do zarządzania VBA osadzonym w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/vbaproject/#vbaproject), aby dodać nowy projekt VBA.
1. Dodaj moduł do projektu VBA.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołania do `stdole`.
1. Dodaj odwołania do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

Ten kod w Pythonie pokazuje, jak od podstaw dodać makro VBA do prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Utwórz nowy projekt VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Dodaj pusty moduł i ustaw jego kod źródłowy.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Utwórz odwołania do stdole i Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Dodaj odwołania do projektu VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Zapisz prezentację.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Możesz zainteresować się **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), darmową aplikacją internetową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word. 

{{% /alert %}} 

## **Usuwanie makr VBA**

Korzystając z metody [getVbaProject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getvbaproject) klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
1. Uzyskaj dostęp do modułu makra i usuń go.
1. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak usunąć makro VBA:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Wczytaj prezentację zawierającą makro.
presentation = Presentation("VBA.pptm")
try:
    # Uzyskaj dostęp do modułu VBA i usuń go.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Zapisz prezentację.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Wyodrębnianie makr VBA**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Przejdź przez wszystkie moduły zawarte w projekcie VBA, aby wyświetlić makra.

Ten kod w Pythonie pokazuje, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Wczytaj prezentację zawierającą makro.
presentation = Presentation("VBA.pptm")
try:
    # Sprawdź, czy prezentacja zawiera projekt VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Sprawdzanie, czy projekt VBA jest zabezpieczony hasłem**

Korzystając z metody [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/vbaproject/#ispasswordprotected), możesz określić, czy właściwości projektu są zabezpieczone hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/python-java/aspose.slides/vbaproject/).
3. Sprawdź, czy projekt VBA jest zabezpieczony hasłem, aby zobaczyć jego właściwości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Sprawdź, czy prezentacja zawiera projekt VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Co się dzieje z makrami, kiedy zapisuję prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, np. odświeżać dane?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonanie jest możliwe wyłącznie w PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/python-java/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.