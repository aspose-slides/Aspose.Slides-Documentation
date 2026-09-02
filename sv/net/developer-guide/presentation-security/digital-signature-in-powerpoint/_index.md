---
title: Lägg till digitala signaturer i presentationer i .NET
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/net/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX-certifikat
- PKCS#12
- validera signatur
- PowerPoint
- PPTX
- presentationsäkerhet
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du signerar befintliga PPTX-presentationer med PFX-certifikat och använder Aspose.Slides för .NET för att validera eller ta bort digitala signaturer."
---
## **Översikt**

En digital signatur hjälper en mottagare att avgöra vem som har signerat en presentation och om det signerade innehållet har ändrats. Tre relaterade säkerhetskoncept är viktiga här:

- Ett **digitalt certifikat** är ett elektroniskt bevis som kopplar en identitet till en publik nyckel. En pålitlig certifikatutfärdare (CA) kan utfärda ett certifikat, eller så kan en organisation använda ett självsignerat certifikat för interna arbetsflöden.
- En **digital signatur** skapas från presentationsinnehållet och certifikatinnehavarens privata nyckel. Certifikatets publika nyckel kan sedan användas för att verifiera signaturen. En signatur ger bevis på ursprung och integritet; den krypterar inte presentationen.
- **Lösenordsskydd** styr om en användare kan öppna eller ändra en presentation. Det är separat från digital signering och beskrivs i [Password-Protected Presentations](/net/password-protected-presentation/).

PowerPoint erbjuder kommandot **Add a Digital Signature** under **File > Info > Protect Presentation**.

![PowerPoint-menyn Protect Presentation med Add a Digital Signature markerad](add-digital-signature-in-powerpoint.png)

När en signerad presentation öppnas kan PowerPoint visa en notifikation om signaturstatus.

![PowerPoint-notifikation som visar att presentationen innehåller giltiga signaturer](digital-signature-status-in-powerpoint.png)

Aspose.Slides exponerar signaturer via [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/digitalsignatures/), en [IDigitalSignatureCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignaturecollection/), vars objekt implementerar [IDigitalSignature](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignature/). En presentation kan innehålla flera signaturer.

## **Förstå PFX‑certifikat och lösenord**

En PFX‑fil, även känd som en PKCS#12‑fil och vanligtvis med filändelsen `.pfx` eller `.p12`, kan innehålla ett X.509‑certifikat, dess privata nyckel och certifikatkedjan. Den privata nyckeln är det som möjliggör för innehavaren att skapa en signatur. Ett certifikat utan en åtkomlig privat nyckel kan inte användas för att signera en presentation.

PFX‑lösenordet skyddar certifikatpaketet och den privata nyckeln. Det är **inte** ett lösenord för att öppna eller redigera presentationen. Lagra inte PFX‑filer eller deras lösenord i källkodshantering. I produktion bör åtkomsten till certifikatfilen begränsas och lösenordet hämtas från en hemlig lagring eller en annan skyddad konfigurationskälla. Exemplen nedan använder en miljövariabel endast för att undvika att lösenordet inbäddas i kod.

## **Lägg till en digital signatur i en presentation**

För att signera ett verkligt presentationsarbetsflöde, läs in en befintlig PPTX‑fil, skapa ett [DigitalSignature](https://reference.aspose.com/slides/sv/net/aspose.slides/digitalsignature/) från ett PFX‑certifikat och dess lösenord, lägg till signaturen i presentationens samling och spara till en PPTX‑fil.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Genom att spara resultatet med ett nytt namn bevaras den osignerade källfilen. Värdet [DigitalSignature.Comments](https://reference.aspose.com/slides/sv/net/aspose.slides/digitalsignature/comments/) beskriver signaturens syfte; det är ingen säkerhetskontroll.

## **Validera digitala signaturer**

När du läser in en signerad PPTX‑fil, inspektera varje objekt i [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/digitalsignatures/). Egenskapen [IDigitalSignature.IsValid](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignature/isvalid/) visar om den inbäddade signaturen är giltig för det aktuella presentationsinnehållet.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Ett ogiltigt resultat betyder vanligtvis att det signerade presentationsinnehållet eller signaturdata har förändrats efter signering, eller att filen är skadad. Att ta bort alla signaturer skapar en osignerad presentation, så att bara kontrollera giltigheten för objekt räcker inte: ett säkerhetskänsligt arbetsflöde måste också verifiera att det förväntade antalet signaturer och förväntade signataridentiteter finns.

Detta giltighetsresultat bör inte betraktas som ett fullständigt beslut om certifikatförtroende. Beroende på din säkerhetspolicy kan din applikation också behöva bygga och validera X.509‑certifikatkedjan, kontrollera certifikatets giltighetsdatum och återkallelsestatus, bekräfta förväntad ämnesnamn eller fingeravtryck, verifiera nyckelanvändning och utvärdera en betrodd tidsstämpel. Värdet [IDigitalSignature.SignTime](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignature/signtime/) i sig är inte bevis från en betrodd tidsstämpel‑myndighet.

## **Ta bort digitala signaturer**

Att ta bort signaturer ändrar presentationens säkerhetsstatus. Följande exempel läser in en signerad PPTX‑fil, tar bort alla signaturer med [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignaturecollection/clear/), och sparar en osignerad kopia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

För att ta bort endast en signatur, anropa [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignaturecollection/removeat/) med dess nollbaserade index. Spara till en ny fil om du inte explicit ska skriva över den signerade originalfilen i ditt arbetsflöde.

## **Redigering och formatöverväganden**

- En signatur gör inte en presentation skrivskyddad. Användare och applikationer kan fortfarande redigera filen, men ändringar i signerat innehåll gör vanligtvis den befintliga signaturen ogiltig.
- Slutför alla avsedda redigeringar innan signering. Om en presentation måste ändras, spara den reviderade presentationen och signera den revisionen igen.
- Behåll slutresultatet i PPTX‑format. Att konvertera en signerad presentation till ett annat format överför inte den ursprungliga PPTX‑signaturen som en giltig signatur för den konverterade filen.
- Behandla certifikatets privata nyckel som känslig. Alla som får tag på den privata nyckeln och dess lösenord kan skapa signaturer som verkar komma från den certifikatinnehavaren.
- Bevara den osignerade källfilen eller en annan kontrollerad kopia när din dokumentbevarandepolicy kräver det.

## **FAQ**

**Krypterar en digital signatur presentationen?**

Nej. En digital signatur ger bevis om ursprung och integritet, men presentationsinnehållet förblir läsbart om inte separat kryptering används. Använd [password protection](/net/password-protected-presentation/) när åtkomst till innehållet måste begränsas.

**Är PFX‑lösenordet detsamma som ett presentationslösenord?**

Nej. PFX‑lösenordet låser upp den privata nyckeln som lagras i certifikatpaketet. Det styr inte vem som kan öppna eller redigera PPTX‑filen.

**Kan jag använda ett självsignerat certifikat?**

Tekniskt kan ett självsignerat certifikat användas när det innehåller en åtkomlig privat nyckel. Mottagare kommer dock inte automatiskt att lita på det, såvida inte certifikatet uttryckligen har lagts till i deras betrodda miljö. Offentliga eller tvärorganisationsarbetsflöden använder i allmänhet ett certifikat utfärdat av en pålitlig CA.

**Vad gör en signatur ogiltig?**

Att ändra signerat presentationsinnehåll eller signaturdata efter signering kan göra signaturen ogiltig. Filkorruption kan också få valideringen att misslyckas. Om alla signaturer tas bort är presentationen osignerad snarare än en fil som innehåller en ogiltig signatur.

**Betyder en giltig signatur att jag ska lita på signatären?**

Inte i sig. Signaturens integritet och signatarens förtroende är separata beslut. En produktionsvalideringspolicy bör också kontrollera certifikatkedjan, giltighetsperioden, återkallelsestatus, förväntad identitet, nyckelanvändning och eventuella krav på betrodda tidsstämplar.

**Vad händer när certifikatet går ut?**

Certifikatets utgång förändrar inte presentationsdata, men det påverkar bedömningen av certifikatförtroende. Om en signatur förblir godtagbar beror på din policy och på om en giltig betrodd tidsstämpel visar att signeringen skedde medan certifikatet var giltigt. Lita inte enbart på den visade signeringstiden som en betrodd tidsstämpel.

**Kan en signerad presentation fortfarande redigeras?**

Ja. Signering låser inte filen. Att redigera signerat innehåll gör vanligtvis den befintliga signaturen ogiltig, så avsluta presentationen först och signera den slutgiltiga revisionen.

**Kan en presentation innehålla mer än en signatur?**

Ja. Lägg till varje signatur i [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/digitalsignatures/) innan du sparar. Vid validering, inspektera varje signatur och bekräfta att alla erforderliga signatörer finns.

**Vilka presentationsformat stöder dessa operationer?**

Aspose.Slides stödjer de digitala signatur‑operationerna som beskrivs här endast för PPTX. PPT‑ och OpenDocument‑presentationsformat stöds inte av detta API‑arbetsflöde.

**Kan jag ta bort en signatur utan att påverka bilderna?**

Ja. Du kan ta bort en signatur eller rensa hela samlingen och sedan spara presentationen. Bildinnehållet förblir tillgängligt, men den sparade filen bär inte längre med sig beviset för den borttagna signaturen.