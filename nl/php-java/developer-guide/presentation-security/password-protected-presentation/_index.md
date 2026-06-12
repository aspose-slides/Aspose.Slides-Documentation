---
title: Beveilig presentaties met wachtwoorden in PHP
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/php-java/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beveiligen
- presentatie beveiligen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbeperking
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbeperking verwijderen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe je moeiteloos PowerPoint- en OpenDocument‑presentaties met wachtwoordbeveiliging kunt vergrendelen en ontgrendelen met Aspose.Slides voor PHP. Beveilig je presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen afdwingt op de presentatie. Om de beperkingen op te heffen, moet het wachtwoord worden ingevoerd. Een presentatie die met een wachtwoord is beveiligd, wordt beschouwd als een vergrendelde presentatie.

Typisch kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijzigen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking verhindert dat mensen de inhoud van je presentatie wijzigen, aanpassen of kopiëren (tenzij ze het wachtwoord invoeren).

  In dit geval kan een gebruiker, zelfs zonder wachtwoord, het document wel openen. In de alleen‑lezen modus kan de gebruiker de inhoud – hyperlinks, animaties, effecten en andere elementen – bekijken, maar hij kan geen items kopiëren of de presentatie opslaan.

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentatie wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of wijzigen.

  **Opmerking** dat wanneer je een presentatie beveiligt om openen te voorkomen, het presentatiebestand versleuteld wordt.

## **Hoe een presentatie online met wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock)‑pagina.

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Drop or upload your files**.

3. Selecteer het bestand dat je wilt beveiligen op je computer.

4. Voer je gewenste wachtwoord in voor bewerking; voer je gewenste wachtwoord in voor weergave.

5. Als je wilt dat gebruikers je presentatie als definitief exemplaar zien, vink dan het selectievak **Mark as final** aan.

6. Klik op **PROTECT NOW.**

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in deze formaten:

- PPTX en PPT – Microsoft PowerPoint‑presentatie
- ODP – OpenDocument‑presentatie
- OTP – OpenDocument‑presentatiesjabloon

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging op presentaties toe te passen om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbeperking instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides biedt de mogelijkheid om andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbeperking van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie wachtwoordbeveiligd is

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren.

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de **encrypt**‑methode (van [ProtectionManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/)) gebruiken om een wachtwoord aan de presentatie toe te wijzen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie kunt versleutelen:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Schrijfbeperking aan een presentatie toevoegen**

Je kunt een markering “Niet wijzigen” toevoegen aan een presentatie. Op die manier kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen.

**Opmerking** dat het proces van schrijfbeperking de presentatie niet versleutelt. Gebruikers – als ze dat willen – kunnen de presentatie wel wijzigen, maar om de wijzigingen op te slaan moeten ze een nieuw bestand met een andere naam aanmaken.

Om een schrijfbeperking in te stellen, moet je de [setWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setWriteProtection)‑methode gebruiken. Deze voorbeeldcode laat zien hoe je een schrijfbeperking aan een presentatie toevoegt:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Een versleutelde presentatie laden**

Aspose.Slides maakt het mogelijk om een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeEncryption)‑methode zonder parameters aanroepen. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden.

Deze voorbeeldcode laat zien hoe je een presentatie kunt ontsleutelen:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # werk met ontsleutelde presentatie
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Versleuteling van een presentatie verwijderen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op die manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen.

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeEncryption)‑methode aanroepen. Deze voorbeeldcode laat zien hoe je de versleuteling van een presentatie verwijdert:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Schrijfbeperking van een presentatie verwijderen**

Met Aspose.Slides kun je de schrijfbeperking van een presentatiedocument verwijderen. Zo kunnen gebruikers naar eigen inzicht wijzigen, zonder waarschuwingen.

Je kunt de schrijfbeperking van een presentatie verwijderen via de [removeWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeWriteProtection)‑methode. Deze voorbeeldcode toont hoe je de schrijfbeperking van een presentatie verwijdert:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **De eigenschappen van een versleutelde presentatie ophalen**

Gebruikers hebben vaak moeite om de documenteigenschappen van een versleutelde of wachtwoordbeschermde presentatie te verkrijgen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen en tegelijk de mogelijkheid biedt om de eigenschappen te bekijken.

**Opmerking** dat wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen standaard ook met een wachtwoord worden beschermd. Als je wilt dat de eigenschappen toegankelijk blijven (ook na versleuteling), kun je dit doen met de [encryptDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties)‑methode en de waarde `true`.

Deze voorbeeldcode laat zien hoe je een presentatie kunt versleutelen en tegelijkertijd gebruikers toegang geeft tot de documenteigenschappen:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Controleren of een presentatie wachtwoordbeschermd is**

Voordat je een presentatie laadt, wil je wellicht verifiëren dat de presentatie niet met een wachtwoord is beschermd. Zo kun je fouten voorkomen die ontstaan wanneer een wachtwoordbeveiligde presentatie zonder wachtwoord wordt geopend.

Deze PHP‑code laat zien hoe je kunt onderzoeken of een presentatie wachtwoordbeschermd is (zonder de presentatie zelf te laden):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Hiervoor kun je de [isEncrypted](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isEncrypted)‑methode gebruiken, die `true` retourneert als de presentatie versleuteld is, of `false` als dat niet het geval is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Controleren of een presentatie schrijfbeveiligd is**

Aspose.Slides biedt een methode om te controleren of een presentatie schrijfbeveiligd is. Gebruik hiervoor de [isWriteProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isWriteProtected)‑methode, die `true` retourneert als de presentatie schrijfbeveiligd is, of `false` als dat niet zo is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeveiligd is:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt**

Je wilt wellicht controleren of een bepaald wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren.

Deze voorbeeldcode toont hoe je een wachtwoord kunt valideren:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # controleer of "pass" overeenkomt met
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

De methode retourneert `true` als de presentatie versleuteld is met het opgegeven wachtwoord; anders `false`.

{{% alert color="primary" title="Zie ook" %}} 
- [Digital Signature in PowerPoint](/slides/nl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog beveiligingsniveau voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een uitzondering gegenereerd wanneer een onjuist wachtwoord wordt gebruikt, waarmee wordt aangegeven dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met wachtwoordbeveiligde presentaties?**

Het versleutel‑ en ontsleutelproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is de impact minimaal en heeft het geen significante invloed op de totale verwerkingstijd van je presentatietaken.