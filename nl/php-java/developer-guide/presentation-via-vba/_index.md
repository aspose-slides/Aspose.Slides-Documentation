---
title: Beheer VBA-projecten in presentaties met PHP
linktitle: Presentatie via VBA
type: docs
weight: 250
url: /nl/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Ontdek hoe u PowerPoint- en OpenDocument-presentaties kunt genereren en manipuleren via VBA met Aspose.Slides voor PHP via Java om uw workflow te stroomlijnen."
---
## **Inleiding**

De Aspose.Slides API bevat klassen voor het werken met macro's en VBA-code.

{{% alert title="Opmerking" color="warning" %}} 

Wanneer u een presentatie met macro's converteert naar een ander bestandsformaat (PDF, HTML, enz.), negeert Aspose.Slides alle macro's (macro's worden niet meegevoerd naar het resulterende bestand).

Wanneer u macro's toevoegt aan een presentatie of een presentatie met macro's opnieuw opslaat, schrijft Aspose.Slides simpelweg de bytes voor de macro's.

Aspose.Slides **voer** nooit de macro's in een presentatie uit.

{{% /alert %}}

## **VBA‑macro's toevoegen**

Aspose.Slides biedt de [VbaProject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/vbaproject/)‑klasse om VBA‑projecten (en projectreferenties) te maken en bestaande modules te bewerken. U kunt de `VbaProject`‑klasse gebruiken om VBA in een presentatie te beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.
1. Gebruik de [VbaProject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/vbaproject/#VbaProject)‑constructor om een nieuw VBA‑project toe te voegen.
1. Voeg een module toe aan de VbaProject.
1. Stel de broncode van de module in.
1. Voeg referenties toe aan <stdole>.
1. Voeg referenties toe aan **Microsoft Office**.
1. Koppel de referenties aan het VBA‑project.
1. Sla de presentatie op.

Deze PHP‑code toont hoe u vanaf nul een VBA‑macro aan een presentatie toevoegt:

```php
  # Maakt een instantie van de presentatieklasse
  $pres = new Presentation();
  try {
    # Maakt een nieuw VBA-project
    $pres->setVbaProject(new VbaProject());
    # Voegt een lege module toe aan het VBA-project
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Stelt de broncode van de module in
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Maakt een referentie naar <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Maakt een referentie naar Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Voegt referenties toe aan het VBA-project
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Slaat de presentatie op
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

U kunt ook de **Aspose** [Macro Remover](https://products.aspose.app/slides/nl/remove-macros) bekijken, een gratis webapplicatie om macro's uit PowerPoint-, Excel- en Word‑documenten te verwijderen. 

{{% /alert %}} 

## **VBA‑macro's verwijderen**

Via de [VbaProject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getVbaProject)‑eigenschap van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse kunt u een VBA‑macro verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met de macro.
1. Open de macro‑module en verwijder deze.
1. Sla de aangepaste presentatie op.

Deze PHP‑code toont hoe u een VBA‑macro verwijdert:

```php
  # Laadt de presentatie met de macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Benadert de Vba-module en verwijdert deze
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Slaat de presentatie op
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **VBA‑macro's extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met de macro.
2. Controleer of de presentatie een VBA‑project bevat.
3. Loop door alle modules in het VBA‑project om de macro's te bekijken.

Deze PHP‑code toont hoe u VBA‑macro's uit een presentatie met macro's kunt extraheren:

```php
  # Laadt de presentatie met de macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Controleert of de presentatie een VBA-project bevat
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Controleren of een VBA‑project met een wachtwoord is beveiligd**

Met de methode [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/vbaproject/#isPasswordProtected) kunt u bepalen of de eigenschappen van een project met een wachtwoord zijn beveiligd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en laad een presentatie die een macro bevat.
2. Controleer of de presentatie een [VBA project](https://reference.aspose.com/slides/nl/php-java/aspose.slides/vbaproject/) bevat.
3. Controleer of het VBA‑project met een wachtwoord is beveiligd om de eigenschappen te bekijken.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Controleer of de presentatie een VBA-project bevat.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wat gebeurt er met macro's als ik de presentatie opsla als PPTX?**

Macro's worden verwijderd omdat PPTX geen VBA ondersteunt. Om macro's te behouden, kiest u PPTM, PPSM of POTM.

**Kan Aspose.Slides macro's in een presentatie uitvoeren, bijvoorbeeld om gegevens te vernieuwen?**

Nee. De bibliotheek voert nooit VBA‑code uit; uitvoering is alleen mogelijk in PowerPoint met de juiste beveiligingsinstellingen.

**Wordt het werken met ActiveX‑besturingselementen die gekoppeld zijn aan VBA‑code ondersteund?**

Ja, u kunt bestaande [ActiveX controls](/slides/nl/php-java/activex/) benaderen, hun eigenschappen wijzigen en ze verwijderen. Dit is handig wanneer macro's met ActiveX communiceren.