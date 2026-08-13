---
title: VBA‑projecten beheren in presentaties op Android
linktitle: Presentatie via VBA
type: docs
weight: 250
url: /nl/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u PowerPoint‑ en OpenDocument‑presentaties via VBA kunt genereren en manipuleren met Aspose.Slides voor Android via Java om uw workflow te stroomlijnen."
---
## **Introductie**

Aspose.Slides biedt klassen en interfaces voor het werken met macro’s en VBA‑code.

{{% alert title="Opmerking" color="warning" %}} 

Wanneer u een presentatie met macro’s converteert naar een ander bestandsformaat (PDF, HTML, enz.), negeert Aspose.Slides alle macro’s (macro’s worden niet meegenomen in het resulterende bestand).

Wanneer u macro’s toevoegt aan een presentatie of een presentatie met macro’s opnieuw opslaat, schrijft Aspose.Slides simpelweg de bytes van de macro’s.

Aspose.Slides **loopt nooit** de macro’s in een presentatie uit.

{{% /alert %}}

## **VBA‑macro’s toevoegen**

Aspose.Slides biedt de [VbaProject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/vbaproject/)‑klasse om VBA‑projecten (en projectreferenties) te maken en bestaande modules te bewerken. U kunt de [IVbaProject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivbaproject/)‑interface gebruiken om VBA dat in een presentatie is ingebed te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. Gebruik de [VbaProject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/vbaproject/#VbaProject--)‑constructor om een nieuw VBA‑project toe te voegen.
1. Voeg een module toe aan de VbaProject.
1. Stel de broncode van de module in.
1. Voeg referenties toe aan <stdole>.
1. Voeg referenties toe aan **Microsoft Office**.
1. Koppel de referenties aan het VBA‑project.
1. Sla de presentatie op.

Deze Java‑code toont hoe u vanaf nul een VBA‑macro aan een presentatie toevoegt:

```java
import com.aspose.slides.*;

// Creëert een instantie van de presentatieklasse
Presentation pres = new Presentation();
try {
    // Creëert een nieuw VBA-project
    pres.setVbaProject(new VbaProject());
    
    // Voegt een lege module toe aan het VBA-project
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Stelt de broncode van de module in
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Creëert een referentie naar <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Creëert een referentie naar Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Voeg referenties toe aan het VBA-project
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Slaat de presentatie op
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

U wilt misschien de gratis webapp **Aspose** [Macro Remover](https://products.aspose.app/slides/nl/remove-macros) bekijken, die macro’s uit PowerPoint‑, Excel‑ en Word‑documenten verwijdert. 

{{% /alert %}} 

## **VBA‑macro’s verwijderen**

Via de [VbaProject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getVbaProject--)‑eigenschap van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse kunt u een VBA‑macro verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie die de macro bevat.
1. Werk de macro‑module bij en verwijder deze.
1. Sla de aangepaste presentatie op.

Deze Java‑code laat zien hoe u een VBA‑macro verwijdert:

```java
import com.aspose.slides.*;

// Laadt de presentatie die de macro bevat
Presentation pres = new Presentation("VBA.pptm");
try {
    // Benadert de Vba-module en verwijdert deze 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Slaat de presentatie op
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA‑macro’s extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie die de macro bevat.
2. Controleer of de presentatie een VBA‑project bevat.
3. Doorloop alle modules in het VBA‑project om de macro’s te bekijken.

Deze Java‑code laat zien hoe u VBA‑macro’s uit een presentatie met macro’s haalt:

```java
import com.aspose.slides.*;

// Laadt de presentatie die de macro bevat
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Controleert of de presentatie een VBA-project bevat
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

## **Controleren of een VBA‑project met een wachtwoord is beveiligd**

Met de [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--)‑methode kunt u bepalen of de eigenschappen van een project met een wachtwoord beveiligd zijn.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en laad een presentatie die een macro bevat.
2. Controleer of de presentatie een [VBA‑project](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/vbaproject/) bevat.
3. Controleer of het VBA‑project met een wachtwoord is beveiligd om de eigenschappen te bekijken.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Controleer of de presentatie een VBA-project bevat.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Wat gebeurt er met macro’s als ik de presentatie opsla als PPTX?

Macro’s worden verwijderd omdat PPTX geen VBA ondersteunt. Om macro’s te behouden, kiest u PPTM, PPSM of POTM.

### Kan Aspose.Slides macro’s in een presentatie uitvoeren, bijvoorbeeld om gegevens te verversen?

Nee. De bibliotheek voert nooit VBA‑code uit; uitvoering is alleen mogelijk binnen PowerPoint met de juiste beveiligingsinstellingen.

### Wordt werken met ActiveX‑besturingselementen die gekoppeld zijn aan VBA‑code ondersteund?

Ja, u kunt bestaande [ActiveX controls](/slides/nl/androidjava/activex/) benaderen, hun eigenschappen wijzigen en ze verwijderen. Dit is handig wanneer macro’s met ActiveX interageren.