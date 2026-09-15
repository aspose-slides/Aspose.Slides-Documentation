---
title: Beheer VBA-projecten in presentaties met Python
linktitle: Presentatie via VBA
type: docs
weight: 250
url: /nl/python-java/presentation-via-vba/
keywords:
- macro
- VBA
- VBA-macro
- macro toevoegen
- macro verwijderen
- macro extraheren
- VBA toevoegen
- VBA verwijderen
- VBA extraheren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek hoe u PowerPoint- en OpenDocument-presentaties kunt genereren en manipuleren via VBA met Aspose.Slides voor Python via Java om uw workflow te stroomlijnen."
---
## **Inleiding**

Aspose.Slides biedt klassen en interfaces voor het werken met macro’s en VBA‑code.

{{% alert title="Waarschuwing" color="warning" %}} 

Wanneer u een presentatie met macro’s converteert naar een ander bestandsformaat (PDF, HTML, enz.), negeert Aspose.Slides alle macro’s (macro’s worden niet meegenomen in het resulterende bestand).

Wanneer u macro’s toevoegt aan een presentatie of een presentatie met macro’s opnieuw opslaat, schrijft Aspose.Slides simpelweg de bytes voor de macro’s.

Aspose.Slides **draait nooit** de macro’s in een presentatie.

{{% /alert %}}

## **VBA‑macro’s toevoegen**

Aspose.Slides levert de [VbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/vbaproject/)‑klasse waarmee u VBA‑projecten (en projectreferenties) kunt maken en bestaande modules kunt bewerken. U kunt de [VbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/vbaproject/)‑klasse gebruiken om VBA in een presentatie te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Gebruik de [VbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/vbaproject/#vbaproject)‑constructor om een nieuw VBA‑project toe te voegen.
1. Voeg een module toe aan het VBA‑project.
1. Stel de broncode van de module in.
1. Voeg referenties toe aan `stdole`.
1. Voeg referenties toe aan **Microsoft Office**.
1. Koppel de referenties aan het VBA‑project.
1. Sla de presentatie op.

Deze Python‑code laat zien hoe u vanaf nul een VBA‑macro aan een presentatie toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Maak een nieuw VBA-project.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Voeg een lege module toe en stel de broncode in.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Maak referenties aan naar stdole en Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Voeg referenties toe aan het VBA-project.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Sla de presentatie op.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}} 

U kunt ook eens kijken naar **Aspose** [Macro Remover](https://products.aspose.app/slides/nl/remove-macros), een gratis webapplicatie om macro’s uit PowerPoint‑, Excel‑ en Word‑documenten te verwijderen. 

{{% /alert %}} 

## **VBA‑macro’s verwijderen**

Met de [getVbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getvbaproject)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse kunt u een VBA‑macro verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die de macro bevat.
1. Open de macro‑module en verwijder deze.
1. Sla de aangepaste presentatie op.

Deze Python‑code laat zien hoe u een VBA‑macro verwijdert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Laad de presentatie met de macro.
presentation = Presentation("VBA.pptm")
try:
    # Open de VBA-module en verwijder deze.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Sla de presentatie op.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **VBA‑macro’s extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die de macro bevat.
2. Controleer of de presentatie een VBA‑project bevat.
3. Loop door alle modules in het VBA‑project om de macro’s te bekijken.

Deze Python‑code laat zien hoe u VBA‑macro’s uit een presentatie met macro’s kunt extraheren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Laad de presentatie met de macro.
presentation = Presentation("VBA.pptm")
try:
    # Controleer of de presentatie een VBA‑project bevat.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Controleren of een VBA‑project is beveiligd met een wachtwoord**

Met de [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/vbaproject/#ispasswordprotected)‑methode kunt u bepalen of de eigenschappen van een project met een wachtwoord zijn beveiligd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad een presentatie die een macro bevat.
2. Controleer of de presentatie een [VBA‑project](https://reference.aspose.com/slides/nl/python-java/aspose.slides/vbaproject/) bevat.
3. Controleer of het VBA‑project met een wachtwoord is beveiligd om de eigenschappen te bekijken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Controleer of de presentatie een VBA-project bevat.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Wat gebeurt er met macro’s als ik de presentatie opsla als PPTX?**

Macro’s worden verwijderd omdat PPTX geen VBA ondersteunt. Om macro’s te behouden, kiest u PPTM, PPSM of POTM.

**Kan Aspose.Slides macro’s in een presentatie uitvoeren, bijvoorbeeld om gegevens te vernieuwen?**

Nee. De bibliotheek voert nooit VBA‑code uit; uitvoering is alleen mogelijk binnen PowerPoint met de juiste beveiligingsinstellingen.

**Wordt er gewerkt met ActiveX‑besturingselementen gekoppeld aan VBA‑code?**

Ja, u kunt bestaande [ActiveX‑besturingselementen](/slides/nl/python-java/activex/) benaderen, hun eigenschappen wijzigen en ze verwijderen. Dit is handig wanneer macro’s communiceren met ActiveX.