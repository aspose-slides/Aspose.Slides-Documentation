---
title: "Hantera VBA‑projekt i presentationer med JavaScript"
linktitle: "Presentation via VBA"
type: docs
weight: 250
url: /sv/nodejs-java/presentation-via-vba/
keywords:
- makro
- VBA
- VBA‑makro
- lägga till makro
- ta bort makro
- extrahera makro
- lägga till VBA
- ta bort VBA
- extrahera VBA
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och manipulera PowerPoint‑ och OpenDocument‑presentationer via VBA i JavaScript med Aspose.Slides för Node.js via Java för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Aspose.Slides tillhandahåller klasser för att arbeta med makron och VBA‑kod.

{{% alert title="Note" color="warning" %}} 

När du konverterar en presentation som innehåller makron till ett annat filformat (PDF, HTML etc.) ignorerar Aspose.Slides alla makron (makron överförs inte till den resulterande filen).

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron skriver Aspose.Slides helt enkelt makronas bytes.

Aspose.Slides **aldrig** kör makron i en presentation.

{{% /alert %}}

## **Lägg till VBA‑makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/vbaproject/) för att låta dig skapa VBA‑projekt (och projektreferenser) och redigera befintliga moduler. Du kan använda klassen [VbaProject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/vbaproject/) för att hantera VBA som är inbäddad i en presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Använd [VbaProject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/vbaproject/#VbaProject--)‑konstruktorn för att lägga till ett nytt VBA‑projekt.
1. Lägg till en modul i VbaProject.
1. Ange modulens källkod.
1. Lägg till referenser till <stdole>.
1. Lägg till referenser till **Microsoft Office**.
1. Koppla referenserna till VBA‑projektet.
1. Spara presentationen.

Den här JavaScript‑koden visar hur du lägger till ett VBA‑makro från början i en presentation:

```javascript
// Skapar en instans av presentationsklassen
let pres = new aspose.slides.Presentation();
try {
    // Skapar ett nytt VBA‑projekt
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Lägger till en tom modul i VBA‑projektet
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Anger modulens källkod
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Skapar en referens till <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Skapar en referens till Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Lägger till referenser till VBA‑projektet
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Sparar presentationen
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Du kanske vill titta på **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), en gratis webbapp som används för att ta bort makron från PowerPoint-, Excel‑ och Word‑dokument. 

{{% /alert %}} 

## **Ta bort VBA‑makron**

Med egenskapen [VbaProject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getVbaProject--) under klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) kan du ta bort ett VBA‑makro.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen som innehåller makrot.
1. Åtkomst till Makro‑modulen och ta bort den.
1. Spara den modifierade presentationen.

Den här JavaScript‑koden visar hur du tar bort ett VBA‑makro:

```javascript
// Laddar presentationen som innehåller makrot
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Åtkommer Vba-modulen och tar bort den
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Sparar presentationen
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extrahera VBA‑makron**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Loopa igenom alla moduler som finns i VBA‑projektet för att se makrona.

Den här JavaScript‑koden visar hur du extraherar VBA‑makron från en presentation som innehåller makron:

```javascript
// Laddar presentationen som innehåller makrot
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Kontrollerar om presentationen innehåller ett VBA‑projekt
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kontrollera om ett VBA‑projekt är lösenordsskyddat**

Med metoden [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och läs in en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA‑projekt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att se dess egenskaper.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Kontrollera om presentationen innehåller ett VBA-projekt.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad händer med makron om jag sparar presentationen som PPTX?**

Makron kommer att tas bort eftersom PPTX inte stöder VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att till exempel uppdatera data?**

Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med rätt säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller som är länkat till VBA‑kod?**

Ja, du kan komma åt befintliga [ActiveX‑kontroller](/slides/sv/nodejs-java/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.