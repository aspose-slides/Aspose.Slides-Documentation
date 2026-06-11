---
title: Hantera VBA-projekt i presentationer på Android
linktitle: Presentation via VBA
type: docs
weight: 250
url: /sv/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du kan skapa och manipulera PowerPoint- och OpenDocument-presentationer via VBA med Aspose.Slides för Android via Java för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Aspose.Slides tillhandahåller klasser och gränssnitt för att arbeta med makron och VBA‑kod.

{{% alert title="Obs" color="warning" %}} 
När du konverterar en presentation som innehåller makron till ett annat filformat (PDF, HTML etc.) ignorerar Aspose.Slides alla makron (makron överförs inte till den resulterande filen).

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron skriver Aspose.Slides helt enkelt bytes för makrona.

Aspose.Slides **aldrig** kör makron i en presentation.
{{% /alert %}}

## **Lägg till VBA‑makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/vbaproject/) för att du ska kunna skapa VBA‑projekt (och projektreferenser) och redigera befintliga moduler. Du kan använda gränssnittet [IVbaProject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivbaproject/) för att hantera VBA inbäddat i en presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Använd [VbaProject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/vbaproject/#VbaProject--)‑konstruktorn för att lägga till ett nytt VBA‑projekt.
1. Lägg till en modul i VbaProject.
1. Ange källkoden för modulen.
1. Lägg till referenser till <stdole>.
1. Lägg till referenser till **Microsoft Office**.
1. Koppla referenserna till VBA‑projektet.
1. Spara presentationen.

Denna Java‑kod visar hur du lägger till ett VBA‑makro från början i en presentation:

```java
    // Skapar en instans av presentationsklassen
    Presentation pres = new Presentation();
    try {
        // Skapar ett nytt VBA‑projekt
        pres.setVbaProject(new VbaProject());
        
        // Lägger till en tom modul i VBA‑projektet
        IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
        
        // Anger modulens källkod
        module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
        
        // Skapar en referens till <stdole>
        VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
        
        // Skapar en referens till Office
        VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
                "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
        
        // Lägger till referenser i VBA‑projektet
        pres.getVbaProject().getReferences().add(stdoleReference);
        pres.getVbaProject().getReferences().add(officeReference);
       
        // Sparar presentationen
        pres.save("test.pptm", SaveFormat.Pptm);
    } finally {
        if (pres != null) pres.dispose();
    }
```

{{% alert color="primary" %}} 
Du kanske vill titta på **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), en gratis webbapp som används för att ta bort makron från PowerPoint-, Excel- och Word‑dokument. 
{{% /alert %}} 

## **Ta bort VBA‑makron**

Med hjälp av egenskapen [VbaProject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getVbaProject--) under klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) kan du ta bort ett VBA‑makro.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) och öppna presentationen som innehåller makrot.
1. Åtkomst till Makro‑modulen och ta bort den.
1. Spara den ändrade presentationen.

Denna Java‑kod visar hur du tar bort ett VBA‑makro:

```java
// Läser in presentationen som innehåller makrot
Presentation pres = new Presentation("VBA.pptm");
try {
    // Åtkommer Vba‑modulen och tar bort den 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Sparar presentationen
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahera VBA‑makron**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) och öppna presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Loopa igenom alla moduler i VBA‑projektet för att visa makrona.

Denna Java‑kod visar hur du extraherar VBA‑makron från en presentation som innehåller makron:

```java
// Läser in presentationen som innehåller makrot
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Kontrollerar om presentationen innehåller ett VBA‑projekt
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kontrollera om ett VBA‑projekt är lösenordsskyddat**

Med metoden [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och öppna en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA project](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att se dess egenskaper.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Kontrollera om presentationen innehåller ett VBA-projekt.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Vad händer med makron om jag sparar presentationen som PPTX?**

Makron tas bort eftersom PPTX inte stödjer VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att till exempel uppdatera data?**

Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med rätt säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller som är länkade till VBA‑kod?**

Ja, du kan komma åt befintliga [ActiveX controls](/slides/sv/androidjava/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.