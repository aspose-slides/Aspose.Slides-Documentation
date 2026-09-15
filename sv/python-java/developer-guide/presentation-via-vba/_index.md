---
title: Hantera VBA-projekt i presentationer med Python
linktitle: Presentation via VBA
type: docs
weight: 250
url: /sv/python-java/presentation-via-vba/
keywords:
- makro
- VBA
- VBA-makro
- lägg till makro
- ta bort makro
- extrahera makro
- lägg till VBA
- ta bort VBA
- extrahera VBA
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Upptäck hur du kan skapa och manipulera PowerPoint- och OpenDocument-presentationer via VBA med Aspose.Slides för Python via Java för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Aspose.Slides tillhandahåller klasser och gränssnitt för att arbeta med makron och VBA‑kod.

{{% alert title="Varning" color="warning" %}} 

När du konverterar en presentation som innehåller makron till ett annat filformat (PDF, HTML osv.) ignorerar Aspose.Slides alla makron (makron överförs inte till den resulterande filen).

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron skriver Aspose.Slides helt enkelt bytes för makrona.

Aspose.Slides **utför aldrig** makron i en presentation.

{{% /alert %}}

## **Lägg till VBA‑makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/vbaproject/) så att du kan skapa VBA‑projekt (och projektreferenser) samt redigera befintliga moduler. Du kan använda klassen [VbaProject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/vbaproject/) för att hantera VBA som är inbäddad i en presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Använd [VbaProject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/vbaproject/#vbaproject) konstruktorn för att lägga till ett nytt VBA‑projekt.
1. Lägg till en modul i VBA‑projektet.
1. Ange modulens källkod.
1. Lägg till referenser till `stdole`.
1. Lägg till referenser till **Microsoft Office**.
1. Koppla referenserna till VBA‑projektet.
1. Spara presentationen.

Denna Python‑kod visar hur du lägger till ett VBA‑makro från början i en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Skapa ett nytt VBA‑projekt.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Lägg till en tom modul och ange dess källkod.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Skapa referenser till stdole och Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Lägg till referenser till VBA‑projektet.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Spara presentationen.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Obs" %}} 

Du kanske vill prova **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), som är en gratis webbapp för att ta bort makron från PowerPoint-, Excel- och Word‑dokument. 

{{% /alert %}} 

## **Ta bort VBA‑makron**

Genom att använda metoden [getVbaProject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getvbaproject) i klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) kan du ta bort ett VBA‑makro.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in presentationen som innehåller makrot.
1. Åtkomst till makronmodulen och ta bort den.
1. Spara den ändrade presentationen.

Denna Python‑kod visar hur du tar bort ett VBA‑makro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Ladda presentationen som innehåller makrot.
presentation = Presentation("VBA.pptm")
try:
    # Åtkomst till VBA-modulen och ta bort den.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Spara presentationen.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extrahera VBA‑makron**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Loopa igenom alla moduler i VBA‑projektet för att visa makrona.

Denna Python‑kod visar hur du extraherar VBA‑makron från en presentation som innehåller makron:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Ladda presentationen som innehåller makrot.
presentation = Presentation("VBA.pptm")
try:
    # Kontrollera om presentationen innehåller ett VBA-projekt.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Kontrollera om ett VBA‑projekt är lösenordsskyddat**

Genom att använda metoden [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/vbaproject/#ispasswordprotected) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA‑projekt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att visa dess egenskaper.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Kontrollera om presentationen innehåller ett VBA-projekt.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Vad händer med makron om jag sparar presentationen som PPTX?**

Makron kommer att tas bort eftersom PPTX inte stöder VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att till exempel uppdatera data?**

Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med rätt säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller kopplade till VBA‑kod?**

Ja, du kan komma åt befintliga [ActiveX‑kontroller](/slides/sv/python-java/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.