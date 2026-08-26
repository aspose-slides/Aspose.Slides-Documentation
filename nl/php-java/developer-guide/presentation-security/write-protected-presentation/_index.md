---
title: Schrijfbeveiliging van presentaties in PHP
linktitle: Schrijfbeveiliging
type: docs
weight: 25
url: /nl/php-java/write-protected-presentation/
keywords:
- schrijfbeveiliging
- schrijfbeveiliging PowerPoint
- wachtwoord om te wijzigen
- beperken bewerken van presentatie
- verwijder schrijfbeveiliging
- valideer wijzigingswachtwoord
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Stel schrijfbeveiligingswachtwoorden in, detecteer, valideer en verwijder ze in PowerPoint PPT‑ en PPTX‑presentaties met Aspose.Slides voor PHP."
---
## **Introductie**

Een write‑protection‑wachtwoord beperkt het wijzigen van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een write‑protected presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de applicatie kunnen ze de inhoud zelfs bewerken en opslaan onder een andere naam, dus write‑protection mag niet worden gezien als een vertrouwelijkheidsmechanisme.

Een openingswachtwoord heeft een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Zie voor het versleutelen van een presentatie of het valideren van een openingswachtwoord [Password‑Protect Presentations](/slides/nl/php-java/password-protected-presentation/).

De werkwijzen in dit artikel gelden zowel voor PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan als PPT gebruik je de extensie `.ppt` en het bijbehorende PPT‑opslagformaat.

## **Write‑protection instellen voor een presentatie**

Gebruik [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setWriteProtection) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie bewaart de beschermingsinstelling.

Het volgende voorbeeld stelt write‑protection in voor een PPTX‑presentatie:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een write‑protected presentatie laden**

Omdat write‑protection de inhoud van de presentatie niet versleutelt, is geen wachtwoord vereist om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beschermde presentatie te wijzigen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Geef geen write‑protection‑wachtwoord door aan [LoadOptions::setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword). Die methode accepteert een openingswachtwoord voor versleutelde inhoud. Als een presentatie beide beschermingssoorten heeft, geef dan het openingswachtwoord op om deze te laden en verwerk het write‑protection‑wachtwoord apart.

## **Write‑protection van een presentatie verwijderen**

Gebruik [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeWriteProtection) om de wijzigingsbeperking te verwijderen, en sla vervolgens de presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controleren of een presentatie write‑protected is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie te maken, roep je [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) aan en inspecteer je [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#isWriteProtected). De methode maakt gebruik van [NullableBool](https://reference.aspose.com/slides/nl/php-java/aspose.slides/nullablebool/) en retourneert `NullableBool::True` wanneer write‑protection wordt gedetecteerd.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

De stream‑overbelasting van [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) levert dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Een write‑protection‑wachtwoord valideren**

Gebruik [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#checkWriteProtection) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#isWriteProtected) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer write‑protection aanwezig is.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#checkWriteProtection) valideert alleen het write‑protection‑wachtwoord. Het valideert geen openingswachtwoord en bepaalt niet of versleutelde inhoud kan worden geladen. Omgekeerd valideert [PresentationInfo::checkPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#checkPassword) alleen een openingswachtwoord. Als een volledige presentatie al is geladen, biedt [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#checkWriteProtection) de equivalente write‑protection‑controle via de protection manager.

In productie‑applicaties mogen wachtwoorden niet worden gelogd of opgenomen in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen en houd wachtwoorden alleen zolang in het geheugen als dat nodig is.

{{% alert color="info" title="Zie ook" %}}
- [Password‑Protect Presentations](/slides/nl/php-java/password-protected-presentation/)
- [Read‑Only Presentations](/slides/nl/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Versleutelt write‑protection een presentatie?**

Nee. Het beperkt de wijziging, maar laat de presentatiew inhoud beschikbaar voor laden en bekijken.

**Is het write‑protection‑wachtwoord vereist om een presentatie te openen?**

Nee. Alleen een openingswachtwoord is vereist om versleutelde presentatiew inhoud te laden.

**Kan een presentatie zowel een openingswachtwoord als een write‑protection‑wachtwoord hebben?**

Ja. Geef het openingswachtwoord via de load‑options op om de versleutelde presentatie te openen, en valideer het write‑protection‑wachtwoord apart wanneer toestemming om te wijzigen nodig is.