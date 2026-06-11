---
title: "Hantera VBA-projekt i presentationer med PHP"
linktitle: "Presentation via VBA"
type: docs
weight: 250
url: /sv/php-java/presentation-via-vba/
keywords:
- "makro"
- "VBA"
- "VBA-makro"
- "lägga till makro"
- "ta bort makro"
- "extrahera makro"
- "lägga till VBA"
- "ta bort VBA"
- "extrahera VBA"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "PHP"
- "Aspose.Slides"
description: "Upptäck hur du skapar och manipulerar PowerPoint- och OpenDocument-presentationer via VBA med Aspose.Slides för PHP via Java för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Aspose.Slides API innehåller klasser för att arbeta med makron och VBA‑kod.

{{% alert title="Note" color="warning" %}} 

När du konverterar en presentation som innehåller makron till ett annat filformat (PDF, HTML osv.) ignorerar Aspose.Slides alla makron (makron överförs inte till den resulterande filen).

När du lägger till makron i en presentation eller sparar om en presentation som innehåller makron skriver Aspose.Slides helt enkelt bytes för makrona.

Aspose.Slides **aldrig** kör makron i en presentation.

{{% /alert %}}

## **Lägg till VBA-makron**

Aspose.Slides tillhandahåller klassen [VbaProject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/vbaproject/) för att låta dig skapa VBA‑projekt (och projektreferenser) och redigera befintliga moduler. Du kan använda klassen `VbaProject` för att hantera VBA som är inbäddad i en presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) .
1. Använd [VbaProject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/vbaproject/)‑konstruktorn för att lägga till ett nytt VBA‑projekt.
1. Lägg till en modul i VbaProject.
1. Ange modulens källkod.
1. Lägg till referenser till <stdole>.
1. Lägg till referenser till **Microsoft Office**.
1. Associera referenserna med VBA‑projektet.
1. Spara presentationen.

Den här PHP‑koden visar hur du lägger till ett VBA‑makro från grunden i en presentation:

```php
  # Skapar en instans av presentationsklassen
  $pres = new Presentation();
  try {
    # Skapar ett nytt VBA-projekt
    $pres->setVbaProject(new VbaProject());
    # Lägger till en tom modul i VBA-projektet
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Anger modulens källkod
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Skapar en referens till <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Skapar en referens till Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Lägger till referenser till VBA-projektet
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Sparar presentationen
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Du kanske vill kolla in **Aspose** [Macro Remover](https://products.aspose.app/slides/sv/remove-macros), en gratis webbapp som används för att ta bort makron från PowerPoint-, Excel- och Word‑dokument.

{{% /alert %}} 

## **Ta bort VBA-makron**

Genom att använda egenskapen [VbaProject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getVbaProject) under klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) kan du ta bort ett VBA‑makro.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) och läs in presentationen som innehåller makrot.
2. Åtkomst till Makro‑modulen och ta bort den.
3. Spara den ändrade presentationen.

Den här PHP‑koden visar hur du tar bort ett VBA‑makro:

```php
  # Laddar presentationen som innehåller makrot
  $pres = new Presentation("VBA.pptm");
  try {
    # Åtkomst till Vba-modulen och tar bort den
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Sparar presentationen
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extrahera VBA-makron**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) och läs in presentationen som innehåller makrot.
2. Kontrollera om presentationen innehåller ett VBA‑projekt.
3. Loopa igenom alla moduler som finns i VBA‑projektet för att visa makrona.

Den här PHP‑koden visar hur du extraherar VBA‑makron från en presentation som innehåller makron:

```php
  # Laddar presentationen som innehåller makrot
  $pres = new Presentation("VBA.pptm");
  try {
    # Kontrollerar om presentationen innehåller ett VBA-projekt
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

## **Kontrollera om ett VBA-projekt är lösenordsskyddat**

Genom att använda metoden [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/vbaproject/#isPasswordProtected) kan du avgöra om ett projekts egenskaper är lösenordsskyddade.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in en presentation som innehåller ett makro.
2. Kontrollera om presentationen innehåller ett [VBA project](https://reference.aspose.com/slides/sv/php-java/aspose.slides/vbaproject/).
3. Kontrollera om VBA‑projektet är lösenordsskyddat för att se dess egenskaper.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Kontrollera om presentationen innehåller ett VBA-projekt.
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

**Vad händer med makron om jag sparar presentationen som PPTX?**

Makron kommer att tas bort eftersom PPTX inte stöder VBA. För att behålla makron, välj PPTM, PPSM eller POTM.

**Kan Aspose.Slides köra makron i en presentation för att exempelvis uppdatera data?**

Nej. Biblioteket kör aldrig VBA‑kod; körning är endast möjlig i PowerPoint med lämpliga säkerhetsinställningar.

**Stöds arbete med ActiveX‑kontroller som är länkat till VBA‑kod?**

Ja, du kan komma åt befintliga [ActiveX controls](/slides/sv/php-java/activex/), ändra deras egenskaper och ta bort dem. Detta är användbart när makron interagerar med ActiveX.