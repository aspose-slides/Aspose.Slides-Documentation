---
title: Beheer VBA‑projecten in presentaties met Python
linktitle: Presentatie via VBA
type: docs
weight: 250
url: /nl/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- VBA‑macro
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
- Aspose.Slides
description: "Ontdek hoe u PowerPoint‑ en OpenDocument‑presentaties kunt genereren en manipuleren via VBA met Aspose.Slides voor Python via .NET om uw workflow te stroomlijnen."
---
## **Overzicht**

Dit artikel onderzoekt de belangrijkste mogelijkheden van Aspose.Slides voor Python via .NET voor het werken met macro's in PowerPoint‑presentaties. De bibliotheek biedt handige hulpmiddelen voor het toevoegen, verwijderen en extraheren van macro's, waardoor je de creatie en wijziging van presentaties kunt automatiseren.

- Versnel de ontwikkeling van presentaties – de automatisering van routinetaken verkort de tijd die nodig is om materiaal voor te bereiden.
- Zorg voor flexibiliteit – de mogelijkheid om macro's te beheren stelt je in staat presentaties af te stemmen op specifieke taken en scenario's.
- Integreer gegevens – eenvoudige integratie met externe gegevensbronnen helpt de inhoud van de dia's up‑to‑date te houden.
- Vereenvoudig onderhoud – gecentraliseerd macro‑beheer maakt het makkelijker om veranderingen toe te passen en presentaties bij te werken.

Het artikel geeft vervolgens praktische voorbeelden van hoe je Aspose.Slides kunt gebruiken om effectief met macro's in PowerPoint te werken.

De [aspose.slides.vba](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/) namespace biedt klassen voor het werken met macro's en VBA‑code.

{{% alert title="Note" color="warning" %}}
Wanneer je een presentatie die macro's bevat converteert naar een ander formaat (PDF, HTML, enz.), negeert Aspose.Slides de macro's – ze worden niet overgebracht naar het uitvoerbestand.

Wanneer je macro's toevoegt aan een presentatie of een presentatie met macro's opnieuw opslaat, schrijft Aspose.Slides de macro‑bytes ongewijzigd.

Aspose.Slides **zal** nooit macro's uitvoeren in een presentatie.
{{% /alert %}}

## **VBA‑macro's toevoegen**

Aspose.Slides levert de [VbaProject](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/vbaproject/) klasse om VBA‑projecten (en projectreferenties) te maken en bestaande modules te bewerken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Gebruik de [VbaProject](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/vbaproject/#constructors) constructor om een nieuw VBA‑project toe te voegen.
3. Voeg een module toe aan het VBA‑project.
4. Stel de broncode van de module in.
5. Voeg een referentie naar `<stdole>` toe.
6. Voeg een referentie naar **Microsoft Office** toe.
7. Koppel de referenties aan het VBA‑project.
8. Sla de presentatie op.

De volgende Python‑code toont hoe je vanaf nul een VBA‑macro aan een presentatie toevoegt:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:

    # Maak een nieuw VBA-project.
    presentation.vba_project = slides.vba.VbaProject()

    # Voeg een lege module toe aan het VBA-project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Stel de broncode van de module in.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Maak een referentie naar <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Maak een referentie naar Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Voeg de referenties toe aan het VBA-project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Sla de presentatie op.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Je kunt de **Aspose** [Macro Remover](https://products.aspose.app/slides/nl/remove-macros) proberen, een gratis webapplicatie om macro's uit PowerPoint‑, Excel‑ en Word‑documenten te verwijderen.
{{% /alert %}}

## **VBA‑macro's verwijderen**

Met de [vba_project](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/vba_project/) eigenschap van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse kun je een VBA‑macro verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en laad de presentatie die de macro bevat.
2. Open de macro‑module en verwijder deze.
3. Sla de aangepaste presentatie op.

De volgende Python‑code toont hoe je een VBA‑macro verwijdert:

```python
import aspose.slides as slides

# Laad de presentatie die de macro bevat.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Open de VBA-module.
    vba_module = presentation.vba_project.modules[0]

    # Verwijder de VBA-module.
    presentation.vba_project.modules.remove(vba_module)

    # Sla de presentatie op.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA‑macro's extraheren**

Met de `modules` eigenschap in de [VbaProject](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/vbaproject/) klasse kun je toegang krijgen tot alle modules van een VBA‑project. De [VbaModule](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/vbamodule/) klasse kan worden gebruikt om module‑eigenschappen, zoals de naam en de code, te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en laad de presentatie die de macro bevat.
2. Controleer of de presentatie een VBA‑project bevat.
3. Loop door alle modules in het VBA‑project om de macro's te bekijken.

De volgende Python‑code toont hoe je VBA‑macro's uit een presentatie extraheert:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Controleer of de presentatie een VBA‑project bevat.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Controleren of een VBA‑project met een wachtwoord is beveiligd**

Met de [VbaProject.is_password_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/vbaproject/is_password_protected/) eigenschap kun je bepalen of de eigenschappen van een project met een wachtwoord beveiligd zijn.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en laad een presentatie die een macro bevat.
2. Controleer of de presentatie een [VBA‑project](https://reference.aspose.com/slides/nl/python-net/aspose.slides.vba/vbaproject/) bevat.
3. Controleer of het VBA‑project met een wachtwoord beveiligd is om de eigenschappen te bekijken.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Controleer of de presentatie een VBA‑project bevat.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Wat gebeurt er met macro's als ik de presentatie opsla als PPTX?**

Macro's worden verwijderd omdat PPTX geen VBA ondersteunt. Om macro's te behouden, kies PPTM, PPSM of POTM.

**Kan Aspose.Slides macro's uitvoeren binnen een presentatie om bijvoorbeeld data te verversen?**

Nee. De bibliotheek voert nooit VBA‑code uit; uitvoering is alleen mogelijk binnen PowerPoint met de juiste beveiligingsinstellingen.

**Wordt werken met ActiveX‑besturingselementen gekoppeld aan VBA‑code ondersteund?**

Ja, je kunt bestaande [ActiveX‑besturingselementen](/slides/nl/python-net/activex/) benaderen, hun eigenschappen wijzigen en ze verwijderen. Dit is handig wanneer macro's met ActiveX interageren.