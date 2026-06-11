---
title: "Hantera VBA‑projekt i presentationer med C++"
linktitle: "Presentation via VBA"
type: docs
weight: 250
url: /sv/cpp/presentation-via-vba/
keywords:
- "makro"
- "VBA"
- "VBA‑makro"
- "lägg till makro"
- "ta bort makro"
- "extrahera makro"
- "lägg till VBA"
- "ta bort VBA"
- "extrahera VBA"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "Upptäck hur du kan skapa och manipulera PowerPoint- och OpenDocument-presentationer via VBA med Aspose.Slides för C++ för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Namnutrymmet [Aspose.Slides.Vba](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.vba/) innehåller klasser och gränssnitt för att arbeta med makron och VBA‑kod.

{{% alert title="Note" color="warning" %}} 

När du konverterar en presentation som innehåller makron till ett annat filformat (PDF, HTML, osv.) ignorerar Aspose.Slides alla makron (makron överförs inte till den resulterande filen).

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron, skriver Aspose.Slides helt enkelt makronas byte.

Aspose.Slides **aldrig** kör makron i en presentation.

{{% /alert %}}

## **Lägg till VBA‑makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.vba.vba_project) så att du kan skapa VBA‑projekt (och projektreferenser) och redigera befintliga moduler. Du kan använda gränssnittet [IVbaProject](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.vba.i_vba_project/) för att hantera VBA som är inbäddad i en presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Använd konstruktorn för [VbaProject](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) för att lägga till ett nytt VBA‑projekt.
1. Lägg till en modul i VbaProject.
1. Ange modulens källkod.
1. Lägg till referenser till <stdole>.
1. Lägg till referenser till **Microsoft Office**.
1. Koppla referenserna till VBA‑projektet.
1. Spara presentationen.

Den här C++‑koden visar hur du lägger till ett VBA‑makro från början i en presentation: 

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Skapar en instans av presentationsklassen
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Skapar ett nytt VBA‑projekt
presentation->set_VbaProject(MakeObject<VbaProject>());

// Lägger till en tom modul i VBA‑projektet
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Anger modulens källkod
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Skapar en referens till <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Skapar en referens till Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Lägger till referenser i VBA‑projektet
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Sparar presentationen
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

Du kanske vill kolla in **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), en gratis webbapp som används för att ta bort makron från PowerPoint-, Excel- och Word‑dokument. 

{{% /alert %}} 

## **Ta bort VBA‑makron**

Genom att använda egenskapen [VbaProject](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) i klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) kan du ta bort ett VBA‑makro.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och läs in presentationen som innehåller makrot.
1. Öppna makro‑modulen och ta bort den.
1. Spara den modifierade presentationen.

Den här C++‑koden visar hur du tar bort ett VBA‑makro: 

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Laddar presentationen som innehåller makrot
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Kommer åt Vba-modulen och tar bort den 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Sparar presentationen
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Extrahera VBA‑makron**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och läs in presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Loopa igenom alla moduler som finns i VBA‑projektet för att visa makron.

Den här C++‑koden visar hur du extraherar VBA‑makron från en presentation som innehåller makron: 

```c++

	// Sökvägen till dokumentkatalogen.
	const String templatePath = u"../templates/VBA.pptm";

	// Laddar presentationen som innehåller makrot
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Kontrollerar om presentationen innehåller ett VBA‑projekt
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

## **Kontrollera om ett VBA‑projekt är lösenordsskyddat**

Genom att använda egenskapen [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/sv/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och läs in en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA‑projekt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.vba/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att visa dess egenskaper.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Kontrollera om presentationen innehåller ett VBA‑projekt.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

**Vad händer med makron om jag sparar presentationen som PPTX?**

Makron kommer att tas bort eftersom PPTX inte stödjer VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att till exempel uppdatera data?**

Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med rätt säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller kopplade till VBA‑kod?**

Ja, du kan komma åt befintliga [ActiveX‑kontroller](/slides/sv/cpp/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.