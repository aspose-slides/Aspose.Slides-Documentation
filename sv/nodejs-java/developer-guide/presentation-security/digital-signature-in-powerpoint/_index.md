---
title: Lägg till digitala signaturer i presentationer i JavaScript
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du signerar befintliga PPTX-presentationer med PFX-certifikat och använder Aspose.Slides för Node.js via Java för att validera eller ta bort digitala signaturer."
---
## **Översikt**

En digital signatur hjälper mottagaren att avgöra vem som har signerat en presentation och om det signerade innehållet har förändrats. Tre relaterade säkerhetskoncept är viktiga här:

- En **digitalt certifikat** är en elektronisk legitimation som kopplar en identitet till en offentlig nyckel. En betrodd certifikatutfärdare (CA) kan utfärda ett certifikat, eller så kan en organisation använda ett självsignerat certifikat för interna arbetsflöden.
- En **digital signatur** skapas från presentationsinnehållet och certifikatets ägares privata nyckel. Certifikatets offentliga nyckel kan sedan användas för att verifiera signaturen. En signatur ger bevis på ursprung och integritet; den krypterar inte presentationen.
- **Lösenordsskydd** styr om en användare kan öppna eller ändra en presentation. Det är separat från digital signering och beskrivs i [Password-Protected Presentations](/nodejs-java/password-protected-presentation/).

PowerPoint tillhandahåller kommandot **Add a Digital Signature** under **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation-menyn med Add a Digital Signature markerad](add-digital-signature-in-powerpoint.png)

När en signerad presentation öppnas kan PowerPoint visa en signaturstatusavisering.

![PowerPoint-avisering som visar att presentationen innehåller giltiga signaturer](digital-signature-status-in-powerpoint.png)

Aspose.Slides exponerar signaturer via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), vilket returnerar en [DigitalSignatureCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignaturecollection/) som innehåller [DigitalSignature](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignature/)‑objekt. En presentation kan innehålla flera signaturer.

## **Förstå PFX‑certifikat och lösenord**

En PFX‑fil, även känd som en PKCS#12‑fil och vanligtvis med filändelsen `.pfx` eller `.p12`, kan innehålla ett X.509‑certifikat, dess privata nyckel och certifikatkedjan. Den privata nyckeln är det som möjliggör för ägaren att skapa en signatur. Ett certifikat utan en tillgänglig privat nyckel kan inte användas för att signera en presentation.

PFX‑lösenordet skyddar certifikatpaketet och den privata nyckeln. Det är **inte** ett lösenord för att öppna eller redigera presentationen. Checka inte in PFX‑filer eller deras lösenord i källkontrollen. I produktion bör åtkomsten till certifikatfilen begränsas och lösenordet hämtas från en hemlig lagring eller annan skyddad konfigurationskälla. Exemplen nedan använder en miljövariabel enbart för att undvika att lösenordet inbäddas i koden.

## **Lägg till en digital signatur i en presentation**

För att signera ett riktigt presentationsflöde, ladda en befintlig PPTX‑fil, skapa en [DigitalSignature](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignature/) från ett PFX‑certifikat och dess lösenord, lägg till signaturen i presentationens samling och spara till en PPTX‑fil.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att spara resultatet under ett nytt namn bevarar den osignerade källfilen. Värdet som sätts av [DigitalSignature.setComments](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignature/) beskriver syftet med signaturen; det är inte en säkerhetskontroll.

## **Validera digitala signaturer**

När du laddar en signerad PPTX‑fil, inspektera varje objekt som returneras av [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Metoden [DigitalSignature.isValid](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignature/) visar om den inbäddade signaturen är giltig för det aktuella presentationsinnehållet.

Följande exempel använder också Node.js‑klassen `X509Certificate` för att läsa ämnesnamnet från varje inbäddat certifikat.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Ett ogiltigt resultat betyder vanligtvis att det signerade presentationsinnehållet eller signaturdata ändrats efter signering, eller att filen är skadad. Att ta bort alla signaturer skapar en osignerad presentation, så att bara kontrollera giltigheten för objekten är inte tillräckligt: ett säkerhetskritiskt arbetsflöde måste också verifiera att det förväntade antalet signaturer och de förväntade signatöridentiteterna finns.

Detta giltighetsresultat bör inte betraktas som ett fullständigt beslut om certifikatförtroende. Beroende på din säkerhetspolicy kan din applikation också behöva bygga och validera X.509‑certifikatkedjan, kontrollera certifikatens giltighetsdatum och återkallningsstatus, bekräfta förväntat ämne eller fingeravtryck, verifiera nyckelanvändning och utvärdera en betrodd tidsstämpel. Värdet från [DigitalSignature.getSignTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignature/) i sig är inte bevis från en betrodd tidsstämpelmyndighet.

## **Ta bort digitala signaturer**

Att ta bort signaturer ändrar presentationens säkerhetstillstånd. Följande exempel laddar en signerad PPTX‑fil, tar bort alla signaturer med [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), och sparar en osignerad kopia.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För att ta bort endast en signatur, anropa [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) med dess nollbaserade index. Spara till en ny fil om inte överskrivning av den signerade originalfilen är en explicit del av ditt arbetsflöde.

## **Redigering och formatöverväganden**

- En signatur gör inte en presentation skrivskyddad. Användare och program kan fortfarande redigera filen, men ändringar i signerat innehåll ogiltigförklarar normalt den befintliga signaturen.
- Slutför alla avsedda redigeringar innan signering. Om en presentation måste ändras, spara den reviderade presentationen och signera den revisionen igen.
- Behåll slutresultatet i PPTX‑format. Att konvertera en signerad presentation till ett annat format överför inte den ursprungliga PPTX‑signaturen som en giltig signatur för den konverterade filen.
- Behandla certifikatets privata nyckel som känslig. Alla som får tag på den privata nyckeln och dess lösenord kan skapa signaturer som verkar komma från den certifikatägaren.
- Behåll den osignerade källan eller en annan kontrollerad kopia när din dokumentbevarandepolicy kräver det.

## **FAQ**

**Krypterar en digital signatur presentationen?**

Nej. En digital signatur ger bevis om ursprung och integritet, men presentationsinnehållet förblir läsbart om inte separata kryptering tillämpas. Använd [password protection](/nodejs-java/password-protected-presentation/) när åtkomst till innehållet måste begränsas.

**Är PFX‑lösenordet detsamma som ett presentationslösenord?**

Nej. PFX‑lösenordet låser upp den privata nyckeln som lagras i certifikatpaketet. Det styr inte vem som kan öppna eller redigera PPTX‑filen.

**Kan jag använda ett självsignerat certifikat?**

Tekniskt sett kan ett självsignerat certifikat användas när det inkluderar en åtkomlig privat nyckel. Mottagare kommer dock inte automatiskt att lita på det, såvida inte certifikatet uttryckligen har lagts till i deras betrodda miljö. Offentliga eller tvärorganisationsarbetsflöden använder vanligtvis ett certifikat utfärdat av en betrodd CA.

**Vad gör en signatur ogiltig?**

Att ändra det signerade presentationsinnehållet eller signaturdata efter signering kan göra signaturen ogiltig. Filkorruption kan också få valideringen att misslyckas. Om alla signaturer tas bort, är presentationen osignerad snarare än en fil som innehåller en ogiltig signatur.

**Betyder en giltig signatur att jag ska lita på signatören?**

Inte i sig själv. Signaturens integritet och signatörens förtroende är separata beslut. En produktionsvalideringspolicy bör också kontrollera certifikatkedjan, giltighetsperioden, återkallningsstatus, förväntad identitet, nyckelanvändning och eventuella krav på betrodda tidsstämplar.

**Vad händer när certifikatet går ut?**

Certifikatets utgång påverkar inte presentationsbytena, men det påverkar bedömningen av certifikatförtroende. Om en signatur förblir acceptabel beror på din policy och på om en giltig betrodd tidsstämpel visar att signeringen skedde medan certifikatet var giltigt. Lita inte enbart på den visade signeringstiden som en betrodd tidsstämpel.

**Kan en signerad presentation fortfarande redigeras?**

Ja. Signering låser inte filen. Att redigera signerat innehåll gör vanligtvis den befintliga signaturen ogiltig, så slutför presentationen först och signera den slutgiltiga revisionen.

**Kan en presentation innehålla mer än en signatur?**

Ja. Lägg till varje signatur i samlingen som returneras av [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) innan du sparar. Vid validering, inspektera varje signatur och bekräfta att alla erforderliga signatörer finns.

**Vilka presentationsformat stödjer dessa operationer?**

Aspose.Slides stödjer de digitala signaturoperationer som beskrivs här endast för PPTX. PPT- och OpenDocument‑presentationsformat stöds inte av detta API‑arbetsflöde.

**Kan jag ta bort en signatur utan att påverka bilderna?**

Ja. Du kan ta bort en signatur eller rensa hela samlingen och sedan spara presentationen. Bildinnehållet förblir tillgängligt, men den sparade filen bär inte längre beviset för den borttagna signaturen.