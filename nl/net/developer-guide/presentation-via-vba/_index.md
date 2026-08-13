---
title: Beheer VBA-projecten in presentaties in .NET
linktitle: Presentatie via VBA
type: docs
weight: 250
url: /nl/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u PowerPoint- en OpenDocument-presentaties kunt genereren en manipuleren via VBA met Aspose.Slides voor .NET om uw workflow te stroomlijnen."
---
## **Inleiding**

De [Aspose.Slides.Vba](https://reference.aspose.com/slides/nl/net/aspose.slides.vba/) namespace bevat klassen en interfaces voor het werken met macro's en VBA‑code.

{{% alert title="Note" color="warning" %}} 
Wanneer u een presentatie met macro's converteert naar een ander bestandsformaat (PDF, HTML, enz.), negeert Aspose.Slides alle macro's (macro's worden niet meegenomen in het resulterende bestand).

Wanneer u macro's toevoegt aan een presentatie of een presentatie met macro's opnieuw opslaat, schrijft Aspose.Slides simpelweg de bytes voor de macro's.

Aspose.Slides **nooit** de macro's in een presentatie uitvoeren.
{{% /alert %}}

## **VBA‑macro's toevoegen**

Aspose.Slides biedt de [VbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides.vba/vbaproject/)‑klasse om VBA‑projecten (en projectreferenties) te maken en bestaande modules te bewerken. U kunt de [IVbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides.vba/ivbaproject/)‑interface gebruiken om VBA ingebed in een presentatie te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Gebruik de [VbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides.vba/vbaproject/vbaproject/#constructor)‑constructor om een nieuw VBA‑project toe te voegen.
3. Voeg een module toe aan het VbaProject.
4. Stel de broncode van de module in.
5. Voeg referenties toe aan <stdole>.
6. Voeg referenties toe aan **Microsoft Office**.
7. Koppel de referenties aan het VBA‑project.
8. Sla de presentatie op.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Maakt een instantie van de presentatieklasse
using (Presentation presentation = new Presentation())
{
    // Maakt een nieuw VBA-project aan
    presentation.VbaProject = new VbaProject();

    // Voegt een lege module toe aan het VBA-project
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Stelt de broncode van de module in
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Maakt een referentie naar <stdole> aan
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Maakt een referentie naar Office aan
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Voegt referenties toe aan het VBA-project
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // Slaat de presentatie op
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 
U wilt misschien ook **Aspose** [Macro Remover](https://products.aspose.app/slides/nl/remove-macros) bekijken, een gratis webapplicatie om macro's uit PowerPoint-, Excel- en Word‑documenten te verwijderen. 
{{% /alert %}} 

## **VBA‑macro's verwijderen**
Met de [VbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/vbaproject/)‑eigenschap onder de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse kunt u een VBA‑macro verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse en laad de presentatie die de macro bevat.
2. Open de macro‑module en verwijder deze.
3. Sla de gewijzigde presentatie op.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Laadt de presentatie met de macro
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Benadert de Vba-module en verwijdert deze
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Slaat de presentatie op
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA‑macro's extraheren**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse en laad de presentatie die de macro bevat.
2. Controleer of de presentatie een VBA‑project bevat.
3. Doorloop alle modules in het VBA‑project om de macro's te bekijken.

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Laadt de presentatie met de macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Controleert of de presentatie een VBA‑project bevat
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Controleren of een VBA‑project met een wachtwoord is beveiligd**

Met de [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/nl/net/aspose.slides.vba/ivbaproject/ispasswordprotected/)‑eigenschap kunt u bepalen of de eigenschappen van een project met een wachtwoord zijn beveiligd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse en laad een presentatie die een macro bevat.
2. Controleer of de presentatie een [VBA project](https://reference.aspose.com/slides/nl/net/aspose.slides.vba/vbaproject/) bevat.
3. Controleer of het VBA‑project met een wachtwoord is beveiligd om de eigenschappen te bekijken.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Controleer of de presentatie een VBA-project bevat.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### Wat gebeurt er met macro's als ik de presentatie opsla als PPTX?

Macro's worden verwijderd omdat PPTX geen VBA ondersteunt. Om macro's te behouden, kiest u PPTM, PPSM of POTM.

### Kan Aspose.Slides macro's binnen een presentatie uitvoeren, bijvoorbeeld om gegevens te vernieuwen?

Nee. De bibliotheek voert nooit VBA‑code uit; uitvoering is alleen mogelijk binnen PowerPoint met de juiste beveiligingsinstellingen.

### Wordt werken met ActiveX‑besturingselementen gekoppeld aan VBA‑code ondersteund?

Ja, u kunt bestaande [ActiveX controls](/slides/nl/net/activex/) benaderen, hun eigenschappen wijzigen en ze verwijderen. Dit is handig wanneer macro's communiceren met ActiveX.