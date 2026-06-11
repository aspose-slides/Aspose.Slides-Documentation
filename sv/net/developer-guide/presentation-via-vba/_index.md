---
title: Hantera VBA-projekt i presentationer i .NET
linktitle: Presentation via VBA
type: docs
weight: 250
url: /sv/net/presentation-via-vba/
keywords:
- makro
- VBA
- VBA-makro
- lägga till makro
- ta bort makro
- extrahera makro
- lägga till VBA
- ta bort VBA
- extrahera VBA
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du skapar och manipulerar PowerPoint- och OpenDocument-presentationer via VBA med Aspose.Slides för .NET för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/sv/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Obs" color="warning" %}} 

När du konverterar en presentation som innehåller makron till ett annat filformat (PDF, HTML osv.) ignorerar Aspose.Slides alla makron (makron förs inte över till den resulterande filen).

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron skriver Aspose.Slides bara bytes för makron.

Aspose.Slides **kör aldrig** makron i en presentation.

{{% /alert %}}

## **Lägg till VBA-makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides.vba/vbaproject/) för att låta dig skapa VBA‑projekt (och projektreferenser) och redigera befintliga moduler. Du kan använda gränssnittet [IVbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides.vba/ivbaproject/) för att hantera VBA som är inbäddad i en presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Använd konstruktorn för [VbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) för att lägga till ett nytt VBA‑projekt.
1. Lägg till en modul i VbaProject.
1. Ange modulens källkod.
1. Lägg till referenser till <stdole>.
1. Lägg till referenser till **Microsoft Office**.
1. Koppla referenserna till VBA‑projektet.
1. Spara presentationen.

Denna C#‑kod visar hur du lägger till ett VBA‑makro från början till en presentation:

```c#
    // Skapar en instans av presentationsklassen
using (Presentation presentation = new Presentation())
{
    // Skapar ett nytt VBA-projekt
    presentation.VbaProject = new VbaProject();

    // Lägger till en tom modul i VBA-projektet
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Ställer in modulens källkod
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Skapar en referens till <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Skapar en referens till Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Lägger till referenser i VBA-projektet
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Sparar presentationen
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Du kanske vill prova **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), en gratis webbapp för att ta bort makron från PowerPoint-, Excel- och Word-dokument. 

{{% /alert %}} 

## **Ta bort VBA-makron**
Genom egenskapen [VbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/vbaproject/) under klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) kan du ta bort ett VBA‑makro.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) klassen och läs in presentationen som innehåller makrot.
1. Få åtkomst till makromodulen och ta bort den.
1. Spara den ändrade presentationen.

Denna C#‑kod visar hur du tar bort ett VBA‑makro:

```c#
    // Läser in presentationen som innehåller makrot
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Kommer åt Vba-modulen och tar bort den 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Sparar presentationen
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Extrahera VBA-makron**
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen och läs in presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Loopa igenom alla moduler i VBA‑projektet för att visa makrona.

Denna C#‑kod visar hur du extraherar VBA‑makron från en presentation som innehåller makron:

```c#
    // Laddar presentationen som innehåller makrot
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Kontrollerar om presentationen innehåller ett VBA-projekt
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Kontrollera om ett VBA-projekt är lösenordsskyddat**

Med egenskapen [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/sv/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen och läs in en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA‑projekt](https://reference.aspose.com/slides/sv/net/aspose.slides.vba/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att visa dess egenskaper.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Kontrollera om presentationen innehåller ett VBA-projekt.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

**Vad händer med makron om jag sparar presentationen som PPTX?**

Makron tas bort eftersom PPTX inte stödjer VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att exempelvis uppdatera data?**

Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med rätt säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller som är länkade till VBA‑kod?**

Ja, du kan komma åt befintliga [ActiveX controls](/slides/sv/net/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.