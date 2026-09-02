---
title: Skrivskydda presentationer i PHP
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/php-java/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd PowerPoint
- lösenord för att ändra
- begränsa redigering av presentation
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för PHP."
---
## **Introduktion**

Ett skrivskyddslösenord begränsar ändring av en presentation men krypterar inte dess innehåll. Användare kan läsa in och visa en skrivskyddad presentation utan lösenordet. Beroende på applikationen kan de även kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Password-Protect Presentations](/slides/sv/php-java/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT- och PPTX-presentationer. Exemplen använder PPTX-filer; när du sparar till PPT, använd filändelsen `.ppt` och motsvarande PPT-sparformat.

## **Ställ in skrivskydd på en presentation**

Använd [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#setWriteProtection) för att tilldela ett lösenord för att ändra en presentation. När presentationen sparas bevaras skyddinställningen.

Följande exempel sätter skrivskydd på en PPTX-presentation:

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

## **Läs in en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när behörigheten att ändra den skyddade presentationen ska valideras.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Skicka inte ett skrivskyddslösenord till [LoadOptions::setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword). Den metoden accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeWriteProtection) för att ta bort begränsningen för ändring, spara sedan presentationen.

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

## **Kontrollera om en presentation är skrivskyddad**

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-instans, anropa [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/#getPresentationInfo) och granska [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#isWriteProtected). Metoden använder [NullableBool](https://reference.aspose.com/slides/sv/php-java/aspose.slides/nullablebool/) och returnerar `NullableBool::True` när skrivskydd upptäcks.

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

Ström‑överladdningen av [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ger samma information för en presentation som tillhandahålls som en ström.

## **Validera ett skrivskyddslösenord**

Använd [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#checkWriteProtection) för att validera ett ändringslösenord utan att läsa in den kompletta presentationen. Kontrollera först [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#isWriteProtected) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

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

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#checkWriteProtection) validerar endast skrivskyddslösenordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [PresentationInfo::checkPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#checkPassword) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, ger [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#checkWriteProtection) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer bör du inte logga lösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge de behövs.

{{% alert color="info" title="Se även" %}}
- [Password-Protect Presentations](/slides/sv/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/sv/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändring men låter presentationsinnehållet vara tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via lastalternativen för att öppna den krypterade presentationen, och validera skrivskyddslösenordet separat när behörighet för ändring krävs.