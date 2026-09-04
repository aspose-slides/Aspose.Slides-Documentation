---
title: Presentaties beveiligen met wachtwoord in PHP
linktitle: Wachtwoordbescherming
type: docs
weight: 20
url: /nl/php-java/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- PHP
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX‑presentaties in PHP met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het correcte wachtwoord is vereist om de presentatie‑inhoud te laden en weer te geven, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeveiligingswachtwoord. Schrijfbeveiliging beperkt bewerking maar versleutelt de inhoud niet en voorkomt niet dat de presentatie wordt geladen. Om wachtwoorden voor het wijzigen van presentaties te beheren, zie [Write-Protect Presentations](/slides/nl/php-java/write-protected-presentation/).

De onderstaande werkstromen zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten waar hun bestandsgebaseerde en streamgebaseerde gedrag belangrijk is.

## **Versleutel een presentatie met een openingswachtwoord**

Gebruik [ProtectionManager::encrypt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#encrypt) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Documenteigenschappen openbaar houden**

Standaard neemt Aspose.Slides documenteigenschappen op in de versleuteling van de presentatie. De methode [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) regelt dit gedrag onafhankelijk van de versleuteling van de dia‑inhoud. Geef `false` door vóór het aanroepen van [ProtectionManager::encrypt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#encrypt) wanneer een indexerings‑, classificerings‑, zoek‑ of documentbeheersysteem metadata moet lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het doorgeven van `false` aan [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) maakt de dia's, masters, layouts, vormen, media of andere presentatiewaarde niet openbaar. Het beïnvloedt alleen documenteigenschappen. Om die eigenschappen te lezen zonder de versleutelde inhoud te laden, zie [Manage Presentation Properties](/slides/nl/php-java/presentation-properties/).

## **Een versleutelde presentatie laden**

Stel [LoadOptions::setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Werk met de ontsleutelde presentatie.
} finally {
    $presentation->dispose();
}
```

## **Versleuteling uit een presentatie verwijderen**

Laad de presentatie met zijn openingswachtwoord, roep [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeEncryption) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) om [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/) te verkrijgen zonder een volledige presentatiestructuur aan te maken. Controleer [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#isPasswordProtected) voordat u om een wachtwoord vraagt of het valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [PresentationInfo::checkPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Bestandspad-werkstroom**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions::setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword) en laadt vervolgens de volledige presentatie:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Stream-werkstroom**

De stream‑overload van [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) biedt dezelfde werkstroom. Reset de positie van een doorzoekbare stream voordat de volledige presentatie uit die stream wordt geladen.

Het volgende voorbeeld gebruikt een PPT‑bestand:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Teruggeefwaarden van checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#checkPassword) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Nadat een presentatie is geladen met het juiste wachtwoord, inspecteer [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isEncrypted) om te bevestigen dat de bronpresentatie versleuteld was. Om openingswachtwoordbescherming vóór het laden te detecteren, gebruik [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#isPasswordProtected) zoals hierboven getoond.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Beveiliging" %}}
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatiepogingen, bewaar wachtwoorden in het geheugen alleen zolang als nodig is, en hergebruik een succesvolle validatieresultaat bij het direct laden van de presentatie.

Openbare documenteigenschappen kunnen de namen van auteurs, titels, onderwerpe, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen, zelfs als de presentatie‑inhoud versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar houden van eigenschappen moet een expliciete beslissing zijn die alleen wordt genomen wanneer systemen de file moeten indexeren, classificeren, zoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Open de toepassing [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergavebeveiliging.
1. Voer eventueel een apart wachtwoord in voor bewerkingsbeveiliging.
1. Pas de beveiliging toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Write-Protect Presentations](/slides/nl/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of er een openingswachtwoordbeveiliging aanwezig is, en valideer het wachtwoord voordat een volledige presentatie‑instantie wordt aangemaakt.

**Kan een toepassing metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie is versleuteld met uitgeschakelde encryptie van documenteigenschappen. De toepassing moet dan de alleen‑documenteigenschappen‑laadmodus gebruiken die wordt beschreven in [Manage Presentation Properties](/slides/nl/php-java/presentation-properties/).

**Ondersteunen de wachtwoord‑validatiewerkstromen zowel PPT als PPTX?**

Ja. Bestands‑ en stream‑gebaseerde wachtwoorddetectie en -validatie gedragen zich gelijk voor PPT‑ en PPTX‑presentaties.