---
title: Lösenordsskydda presentationer i PHP
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/php-java/password-protected-presentation/
keywords:
- lösenordsskyddad presentation
- öppningslösenord
- kryptera PowerPoint
- dekryptera PowerPoint
- validera presentationslösenord
- kontrollera presentationslösenord
- öppna krypterad presentation
- ta bort kryptering
- PowerPoint
- PPT
- PPTX
- presentation
- PHP
- Aspose.Slides
description: "Kryptera, upptäck, validera, öppna och dekryptera lösenordsskyddade PowerPoint PPT- och PPTX-presentationer i PHP med Aspose.Slides."
---
## **Översikt**

Ett öppningslösenord krypterar en presentation. Det korrekta lösenordet krävs för att läsa in och visa presentationsinnehållet, så detta skydd ger konfidentialitet.

Ett öppningslösenord skiljer sig från ett skrivskyddslösenord. Skrivskydd begränsar ändringar men krypterar inte innehållet eller hindrar presentationen från att läsas in. För att hantera lösenord för att ändra presentationer, se [Write-Protect Presentations](/slides/sv/php-java/write-protected-presentation/).

Arbetssätten nedan gäller både PPT- och PPTX-presentationer. Exemplen använder båda formaten där deras filbaserade och strömbaserade beteende är viktigt.

## **Kryptera en presentation med ett öppningslösenord**

Använd [ProtectionManager::encrypt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#encrypt) för att tilldela ett öppningslösenord. Använd sedan [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) för att spara den krypterade presentationen.

Följande exempel krypterar en PPTX-presentation:

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

## **Läs in en krypterad presentation**

Ange [LoadOptions::setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword) till öppningslösenordet och skicka alternativet till [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) när filen läses in. Inläsning misslyckas när ett öppningslösenord krävs men det angivna lösenordet saknas eller är felaktigt.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Arbeta med den dekrypterade presentationen.
} finally {
    $presentation->dispose();
}
```

## **Ta bort kryptering från en presentation**

Läs in presentationen med dess öppningslösenord, anropa [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeEncryption) och spara resultatet. Den sparade presentationen kan sedan läsas in utan lösenord.

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

## **Validera ett öppningslösenord innan inläsning**

Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/#getPresentationInfo) för att hämta [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/) utan att skapa en komplett presentationsinstans. Kontrollera [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#isPasswordProtected) innan du begär eller validerar ett lösenord. När skyddet finns, validera det angivna värdet med [PresentationInfo::checkPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Filvägsarbetsflöde**

Följande exempel validerar ett öppningslösenord för en PPTX-fil, överför det validerade värdet till [LoadOptions::setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword) och läser sedan in den kompletta presentationen:

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

### **Strömflöde**

Strömmultipliseringen av [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/#getPresentationInfo) erbjuder samma arbetsflöde. Återställ positionen för en sökbar ström innan den kompletta presentationen läses in från den strömmen.

Följande exempel använder en PPT-fil:

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

### **checkPassword retureringsvärden**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#checkPassword) returnerar `true` endast när presentationen har ett öppningslösenord och det angivna lösenordet är korrekt. Den returnerar `false` i var och en av följande fall:

- Lösenordet är felaktigt.
- Presentationen har inget öppningslösenord.
- Det angivna lösenordet är `null` eller tomt.

Beteendet är detsamma för PPT- och PPTX-presentationer.

## **Kontrollera om en inläst presentation är krypterad**

Efter att ha läst in en presentation med rätt lösenord, inspektera [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isEncrypted) för att bekräfta att källpresentationen var krypterad. För att upptäcka öppningslösenordsskydd innan inläsning, använd [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#isPasswordProtected) som visat ovan.

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

## **Säkerhetsrekommendationer**

{{% alert color="warning" title="Security" %}}
Logga inte öppningslösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga återkommande valideringsförsök, håll lösenord i minnet endast så länge de behövs, och återanvänd ett framgångsrikt valideringsresultat när presentationen laddas omedelbart.
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Öppna applikationen [Aspose.Slides Lock](https://products.aspose.app/slides/sv/lock).
1. Välj eller ladda upp presentationen.
1. Ange ett lösenord för visningsskydd.
1. Ange eventuellt ett separat lösenord för redigeringsskydd.
1. Tillämpa skyddet och ladda ner den resulterande filen.

{{% alert color="info" title="Se även" %}}
- [Write-Protect Presentations](/slides/sv/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett öppningslösenord och ett skrivskyddslösenord?**

Ett öppningslösenord krypterar presentationen och krävs för att läsa in dess innehåll. Ett skrivskyddslösenord begränsar ändringar utan att kryptera innehållet.

**Kan jag validera ett öppningslösenord utan att ladda alla bilder?**

Ja. Hämta presentationsinformation, kontrollera om öppningslösenordsskydd finns, och validera lösenordet innan du skapar en komplett presentationsinstans.

**Stöder lösenordsverifieringsarbetsflödena både PPT och PPTX?**

Ja. Filvägs- och strömbaserad lösenorddetektering och -validering fungerar likadant för PPT- och PPTX-presentationer.