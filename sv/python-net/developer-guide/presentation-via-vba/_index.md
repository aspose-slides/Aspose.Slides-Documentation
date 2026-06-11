---
title: Hantera VBA-projekt i presentationer med Python
linktitle: Presentation via VBA
type: docs
weight: 250
url: /sv/python-net/presentation-via-vba/
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
- Aspose.Slides
description: "Upptäck hur du kan skapa och manipulera PowerPoint- och OpenDocument-presentationer via VBA med Aspose.Slides för Python via .NET för att effektivisera ditt arbetsflöde."
---
## **Översikt**

Den här artikeln granskar de viktigaste funktionerna i Aspose.Slides för Python via .NET för att arbeta med makron i PowerPoint‑presentationer. Biblioteket erbjuder praktiska verktyg för att lägga till, ta bort och extrahera makron, vilket gör det möjligt att automatisera skapande och ändring av presentationer.

- Snabba upp presentationstillverkning — automatisering av rutinuppgifter minskar den tid som krävs för att förbereda material.
- Säkerställ flexibilitet — möjligheten att hantera makron gör att du kan anpassa presentationer för specifika uppgifter och scenarier.
- Integrera data — enkel integration med externa datakällor hjälper till att hålla bildinnehållet uppdaterat.
- Förenkla underhåll — centraliserad makrohantering gör det enklare att tillämpa ändringar och uppdatera presentationer.

Artikeln fortsätter med praktiska exempel på hur du använder Aspose.Slides för att effektivt arbeta med makron i PowerPoint.

Namnområdet [aspose.slides.vba](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/) innehåller klasser för att arbeta med makron och VBA‑kod.

{{% alert title="Note" color="warning" %}}
När du konverterar en presentation som innehåller makron till ett annat format (PDF, HTML osv.) ignorerar Aspose.Slides makron — de överförs inte till utdatafilen.

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron, skriver Aspose.Slides makrobytarna oförändrade.

Aspose.Slides **aldrig** kör makron i en presentation.
{{% /alert %}}

## **Lägg till VBA‑makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/vbaproject/) för att skapa VBA‑projekt (och projektreferenser) samt för att redigera befintliga moduler.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Använd konstruktorn för [VbaProject](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/vbaproject/#constructors) för att lägga till ett nytt VBA‑projekt.
3. Lägg till en modul i VBA‑projektet.
4. Ange modulens källkod.
5. Lägg till en referens till `<stdole>`.
6. Lägg till en referens till **Microsoft Office**.
7. Associera referenserna med VBA‑projektet.
8. Spara presentationen.

Följande Python‑kod visar hur du lägger till ett VBA‑makro från början i en presentation:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:

    # Skapa ett nytt VBA-projekt.
    presentation.vba_project = slides.vba.VbaProject()

    # Lägg till en tom modul i VBA-projektet.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Ange modulens källkod.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Skapa en referens till <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Skapa en referens till Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Lägg till referenserna i VBA-projektet.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Spara presentationen.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Du kanske vill prova **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), en gratis webbapp för att ta bort makron från PowerPoint-, Excel‑ och Word‑dokument.
{{% /alert %}}

## **Ta bort VBA‑makron**

Genom att använda egenskapen [vba_project](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/vba_project/) i klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) kan du ta bort ett VBA‑makro.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in presentationen som innehåller makrot.
2. Kom åt makromodulen och ta bort den.
3. Spara den ändrade presentationen.

Följande Python‑kod visar hur du tar bort ett VBA‑makro:

```python
import aspose.slides as slides

# Läs in presentationen som innehåller makrot.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Kom åt VBA-modulen.
    vba_module = presentation.vba_project.modules[0]

    # Ta bort VBA-modulen.
    presentation.vba_project.modules.remove(vba_module)

    # Spara presentationen.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Extrahera VBA‑makron**

Genom att använda egenskapen `modules` i klassen [VbaProject](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/vbaproject/) kan du komma åt alla moduler i ett VBA‑projekt. Klassen [VbaModule](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/vbamodule/) kan användas för att extrahera modulens egenskaper, såsom namn och kod.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Iterera genom alla moduler i VBA‑projektet för att visa makrona.

Följande Python‑kod visar hur du extraherar VBA‑makron från en presentation:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Kontrollera om presentationen innehåller ett VBA-projekt.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Kontrollera om ett VBA‑projekt är lösenordsskyddat**

Genom att använda egenskapen [VbaProject.is_password_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/vbaproject/is_password_protected/) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA project](https://reference.aspose.com/slides/sv/python-net/aspose.slides.vba/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att se dess egenskaper.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Kontrollera om presentationen innehåller ett VBA-projekt.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **Vanliga frågor**

**Vad händer med makron om jag sparar presentationen som PPTX?**  
Makron tas bort eftersom PPTX inte stöder VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att t.ex. uppdatera data?**  
Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med rätt säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller som är länkade till VBA‑kod?**  
Ja, du kan komma åt befintliga [ActiveX controls](/slides/sv/python-net/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.