---
title: Lägg till digitala signaturer i presentationer i PHP
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/php-java/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX-certifikat
- PKCS#12
- validera signatur
- PowerPoint
- PPTX
- presentationssäkerhet
- PHP
- Aspose.Slides
description: "Lär dig hur du signerar befintliga PPTX-presentationer med PFX-certifikat och använder Aspose.Slides för PHP via Java för att validera eller ta bort digitala signaturer."
---
## **Översikt**

En digital signatur hjälper mottagaren att avgöra vem som har signerat en presentation och om det signerade innehållet har ändrats. Tre relaterade säkerhetskoncept är viktiga här:

- En **digitalt certifikat** är en elektronisk legitimation som kopplar en identitet till en publik nyckel. En betrodd certifikatutfärdare (CA) kan utfärda ett certifikat, eller så kan en organisation använda ett självsignerat certifikat för interna arbetsflöden.
- En **digital signatur** skapas från presentationsinnehållet och certifikatägarens privata nyckel. Certifikatets publika nyckel kan sedan användas för att verifiera signaturen. En signatur ger bevis på ursprung och integritet; den krypterar inte presentationen.
- **Lösenordsskydd** styr om en användare kan öppna eller ändra en presentation. Det är separat från digital signering och beskrivs i [Password-Protected Presentations](/slides/sv/php-java/password-protected-presentation/).

PowerPoint tillhandahåller kommandot **Add a Digital Signature** under **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

När en signerad presentation öppnas kan PowerPoint visa en signaturstatusavisering.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides exponerar signaturer via [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDigitalSignatures), vilket returnerar en [DigitalSignatureCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignaturecollection/) vars objekt representeras av [DigitalSignature](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignature/) objekt. En presentation kan innehålla flera signaturer.

## **Förstå PFX-certifikat och lösenord**

En PFX-fil, även känd som en PKCS#12-fil och ofta med filändelsen `.pfx` eller `.p12`, kan innehålla ett X.509-certifikat, dess privata nyckel och certifikatkedjan. Den privata nyckeln är det som möjliggör för innehavaren att skapa en signatur. Ett certifikat utan en åtkomlig privat nyckel kan inte användas för att signera en presentation.

PFX-lösenordet skyddar certifikatpaketet och den privata nyckeln. Det är **inte** ett lösenord för att öppna eller redigera presentationen. Checka inte in PFX-filer eller deras lösenord i versionskontroll. I produktionsmiljö bör åtkomst till certifikatfilen begränsas och lösenordet hämtas från en hemlig lagring eller annan skyddad konfigurationskälla. Exemplen nedan använder en miljövariabel enbart för att undvika att lösenordet inbäddas i koden.

## **Lägg till en digital signatur i en presentation**

För att signera ett riktigt presentationsarbetsflöde, läs in en befintlig PPTX-fil, skapa en [DigitalSignature](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignature/) från ett PFX-certifikat och dess lösenord, lägg till signaturen i presentationens samling och spara till en PPTX-fil.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Att spara resultatet under ett nytt namn bevarar den osignerade källfilen. Värdet som sätts med [DigitalSignature::setComments](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignature/setcomments/) beskriver syftet med signaturen; det är inte en säkerhetskontroll.

## **Validera digitala signaturer**

När du läser in en signerad PPTX-fil, undersök varje objekt som returneras av [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDigitalSignatures). Metoden [DigitalSignature::isValid](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignature/isvalid/) indikerar om den inbäddade signaturen är giltig för presentationens aktuella innehåll.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Ett ogiltigt resultat betyder vanligtvis att det signerade presentationsinnehållet eller signaturdata har ändrats efter signering, eller att filen är skadad. Att ta bort alla signaturer skapar en osignerad presentation, så att bara kontrollera objektens giltighet räcker inte: ett säkerhetskritiskt arbetsflöde måste också verifiera att det förväntade antalet signaturer och förväntade signerande identiteter finns.

Detta giltighetsresultat bör inte betraktas som ett komplett beslut om certifikatförtroende. Beroende på din säkerhetspolicy kan din applikation också behöva bygga och validera X.509-certifikatkedjan, kontrollera certifikatets giltighetsdatum och återkallningsstatus, bekräfta förväntad ämne eller fingeravtryck, verifiera nyckelanvändning och utvärdera en betrodd tidsstämpel. Värdet från [DigitalSignature::getSignTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignature/getsigntime/) i sig är inte bevis från en betrodd tidsstämpelmyndighet.

## **Ta bort digitala signaturer**

Att ta bort signaturer förändrar presentationens säkerhetstillstånd. Följande exempel läser in en signerad PPTX-fil, tar bort alla signaturer med [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignaturecollection/clear/), och sparar en osignerad kopia.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För att bara ta bort en signatur, anropa [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/digitalsignaturecollection/removeat/) med dess nollbaserade index. Spara till en ny fil såvida inte överskrivning av den signerade originalfilen är en explicit del av ditt arbetsflöde.

## **Redigering och formatöverväganden**

- En signatur gör inte en presentation skrivskyddad. Användare och applikationer kan fortfarande redigera filen, men ändringar i signerat innehåll ogiltigförklarar normalt den befintliga signaturen.
- Slutför alla avsedda ändringar innan signering. Om en presentation måste ändras, spara den reviderade presentationen och signera den revisionen igen.
- Behåll den slutgiltiga utdata i PPTX-format. Att konvertera en signerad presentation till ett annat format överför inte det ursprungliga PPTX-signaturen som en giltig signatur för den konverterade filen.
- Behandla certifikatets privata nyckel som känslig. Alla som får tag på den privata nyckeln och dess lösenord kan kunna skapa signaturer som verkar komma från den certifikatägaren.
- Behåll den osignerade källfilen eller en annan kontrollerad kopia när din dokumentbevarandepolicy kräver det.

## **FAQ**

**Krypterar en digital signatur presentationen?**

Nej. En digital signatur ger bevis om ursprung och integritet, men presentationsinnehållet förblir läsbart såvida inte separat kryptering tillämpas. Använd [password protection](/slides/sv/php-java/password-protected-presentation/) när åtkomst till innehållet måste begränsas.

**Är PFX-lösenordet detsamma som ett presentationslösenord?**

Nej. PFX-lösenordet låser upp den privata nyckeln som lagras i certifikatpaketet. Det styr inte vem som kan öppna eller redigera PPTX-filen.

**Kan jag använda ett självsignerat certifikat?**

Tekniskt sett kan ett självsignerat certifikat användas när det inkluderar en åtkomlig privat nyckel. Mottagare kommer dock inte automatiskt att lita på det, såvida inte certifikatet uttryckligen har lagts till i deras betrodda miljö. Offentliga eller tvärorganisationella arbetsflöden använder vanligtvis ett certifikat utfärdat av en betrodd CA.

**Vad gör en signatur ogiltig?**

Att ändra det signerade presentationsinnehållet eller signaturdata efter signering kan ogiltigförklara signaturen. Filkorruption kan också få valideringen att misslyckas. Om alla signaturer tas bort blir presentationen osignerad snarare än en fil som innehåller en ogiltig signatur.

**Betyder en giltig signatur att jag ska lita på den som signerat?**

Inte i sig. Signaturens integritet och förtroendet för den som signerat är separata beslut. En produktionsvalideringspolicy bör också kontrollera certifikatkedjan, giltighetsperiod, återkallningsstatus, förväntad identitet, nyckelanvändning och eventuella krav på en betrodd tidsstämpel.

**Vad händer när certifikatet går ut?**

Certifikatets utgång påverkar inte presentationsbytarna, men det påverkar bedömningen av certifikatförtroendet. Om en signatur förblir acceptabel beror på din policy och på om en giltig betrodd tidsstämpel visar att signeringen skedde medan certifikatet var giltigt. Lita inte enbart på den visade signeringstiden som en betrodd tidsstämpel.

**Kan en signerad presentation fortfarande redigeras?**

Ja. Signering låser inte filen. Att redigera signerat innehåll gör normalt den befintliga signaturen ogiltig, så slutför presentationen först och signera den slutgiltiga revisionen.

**Kan en presentation innehålla mer än en signatur?**

Ja. Lägg till varje signatur i samlingen som returneras av [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDigitalSignatures) innan du sparar. Vid validering, granska varje signatur och bekräfta att alla nödvändiga signatörer finns.

**Vilka presentationsformat stödjer dessa operationer?**

Aspose.Slides stödjer digitala signaturoperationer som beskrivs här endast för PPTX. PPT- och OpenDocument-presentationformat stöds inte av detta API-arbetsflöde.

**Kan jag ta bort en signatur utan att påverka bildspelens bilder?**

Ja. Du kan ta bort en signatur eller rensa hela samlingen och sedan spara presentationen. Bildinnehållet kvarstår, men den sparade filen har inte längre den borttagna signaturens bevis.