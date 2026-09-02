---
title: Lägg till digitala signaturer i presentationer i C++
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/cpp/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX‑certifikat
- PKCS#12
- validera signatur
- PowerPoint
- PPTX
- presentationssäkerhet
- C++
- Aspose.Slides
description: "Lär dig hur du signerar befintliga PPTX‑presentationer med PFX‑certifikat och använder Aspose.Slides för C++ för att validera eller ta bort digitala signaturer."
---
## **Översikt**

En digital signatur hjälper mottagaren att avgöra vem som har signerat en presentation och om det signerade innehållet har förändrats. Tre relaterade säkerhetskoncept är viktiga här:

- Ett **digitalt certifikat** är ett elektroniskt intyg som kopplar en identitet till en publik nyckel. En pålitlig certifikatutfärdare (CA) kan utfärda ett certifikat, eller så kan en organisation använda ett självsignerat certifikat för interna arbetsflöden.
- En **digital signatur** skapas från presentationsinnehållet och den privata nyckeln hos certifikatinnehavaren. Certifikatets publika nyckel kan sedan användas för att verifiera signaturen. En signatur ger bevis på ursprung och integritet; den krypterar inte presentationen.
- **Lösenordsskydd** styr huruvida en användare kan öppna eller ändra en presentation. Det är separat från digital signering och beskrivs i [Lösenordsskyddade presentationer](/cpp/password-protected-presentation/).

PowerPoint erbjuder kommandot **Add a Digital Signature** under **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation-meny med Add a Digital Signature markerad](add-digital-signature-in-powerpoint.png)

Efter att en signerad presentation har öppnats kan PowerPoint visa ett signaturstatusmeddelande.

![PowerPoint-meddelande som visar att presentationen innehåller giltiga signaturer](digital-signature-status-in-powerpoint.png)

Aspose.Slides exponerar signaturer via [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_digitalsignatures/), vilket returnerar en [IDigitalSignatureCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignaturecollection/) vars objekt implementerar [IDigitalSignature](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignature/). En presentation kan innehålla flera signaturer.

## **Förstå PFX-certifikat och lösenord**

En PFX-fil, även känd som en PKCS#12-fil och vanligtvis med filändelsen `.pfx` eller `.p12`, kan innehålla ett X.509-certifikat, dess privata nyckel och certifikatkedjan. Den privata nyckeln möjliggör för innehavaren att skapa en signatur. Ett certifikat utan en åtkomlig privat nyckel kan inte användas för att signera en presentation.

PFX-lösenordet skyddar certifikatpaketet och den privata nyckeln. Det är **inte** ett lösenord för att öppna eller redigera presentationen. Checka inte in PFX-filer eller deras lösenord i versionskontroll. I produktion bör åtkomst till certifikatfilen begränsas och lösenordet hämtas från en hemlig lagring eller annan skyddad konfigurationskälla. Exemplen nedan använder en miljövariabel enbart för att undvika att lösenordet hårdkodas i kod.

## **Lägg till en digital signatur i en presentation**

För att signera en riktig presentationsarbetsgång, läs in en befintlig PPTX-fil, skapa en [DigitalSignature](https://reference.aspose.com/slides/sv/cpp/aspose.slides/digitalsignature/) från ett PFX‑certifikat och dess lösenord, lägg till signaturen i presentationens samling och spara till en PPTX‑fil.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Att spara resultatet under ett nytt namn bevarar den osignerade källfilen. Värdet på [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignature/set_comments/) beskriver signaturens syfte; det är ingen säkerhetskontroll.

## **Validera digitala signaturer**

När du läser in en signerad PPTX‑fil, inspektera varje objekt som returneras av [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Metoden [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignature/get_isvalid/) indikerar om den inbäddade signaturen är giltig för det aktuella presentationsinnehållet.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Ett ogiltigt resultat betyder vanligtvis att det signerade presentationsinnehållet eller signaturdata har ändrats efter signering, eller att filen är skadad. Att ta bort alla signaturer ger en osignerad presentation, så att bara kontrollera giltigheten för objekt räcker inte: ett säkerhetskänsligt arbetsflöde måste även verifiera att förväntat antal signaturer och förväntade undertecknare finns.

Detta giltighetsresultat bör inte betraktas som ett fullständigt beslut om certifikatförtroende. Beroende på din säkerhetspolicy kan din applikation också behöva bygga och validera X.509‑certifikatkedjan, kontrollera certifikatets giltighetsperiod och återkallningsstatus, bekräfta förväntad ämnesnamn eller tumregel, verifiera nyckelanvändning och utvärdera ett betrott tidsstämpel. Värdet på [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignature/get_signtime/) i sig är inte bevis från en betrodd tidsstämpelmyndighet.

## **Ta bort digitala signaturer**

Att ta bort signaturer ändrar presentationens säkerhetstillstånd. Följande exempel läser in en signerad PPTX‑fil, tar bort alla signaturer med [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignaturecollection/clear/), och sparar en osignerad kopia.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

För att ta bort endast en signatur, anropa [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idigitalsignaturecollection/removeat/) med dess nollbaserade index. Spara till en ny fil om du inte uttryckligen vill skriva över den signerade originalfilen som en del av ditt arbetsflöde.

## **Redigering och formatöverväganden**

- En signatur gör inte en presentation skrivskyddad. Användare och program kan fortfarande redigera filen, men ändringar i signerat innehåll gör vanligtvis den befintliga signaturen ogiltig.
- Slutför alla avsedda redigeringar innan du signerar. Om en presentation måste ändras, spara den reviderade versionen och signera den revisionen igen.
- Behåll slutresultatet i PPTX‑format. Att konvertera en signerad presentation till ett annat format överför inte den ursprungliga PPTX‑signaturen som en giltig signatur för den konverterade filen.
- Behandla certifikatets privata nyckel som känslig information. Alla som får tag på den privata nyckeln och dess lösenord kan kunna skapa signaturer som verkar komma från certifikatinnehavaren.
- Behåll den osignerade källfilen eller en annan kontrollerad kopia när din dokumentbevarande‑policy kräver det.

## **FAQ**

**Krypterar en digital signatur presentationen?**

Nej. En digital signatur ger bevis om ursprung och integritet, men presentationsinnehållet förblir läsbart såvida ingen separat kryptering appliceras. Använd [Lösenordsskyddade presentationer](/cpp/password-protected-presentation/) när åtkomst till innehållet måste begränsas.

**Är PFX‑lösenordet samma som ett presentationslösenord?**

Nej. PFX‑lösenordet låser upp den privata nyckeln som lagras i certifikatpaketet. Det styr inte vem som kan öppna eller redigera PPTX‑filen.

**Kan jag använda ett självsignerat certifikat?**

Tekniskt kan ett självsignerat certifikat användas när det inkluderar en åtkomlig privat nyckel. Mottagare kommer dock inte automatiskt att lita på det, såvida inte certifikatet explicit har lagts till i deras betrodda miljö. Offentliga eller tvärorganisatoriska arbetsflöden använder vanligtvis ett certifikat utfärdat av en betrodd CA.

**Vad gör en signatur ogiltig?**

Att ändra signerat presentationsinnehåll eller signaturdata efter signering kan göra signaturen ogiltig. Filkorruption kan också få valideringen att misslyckas. Om alla signaturer tas bort är presentationen osignerad snarare än att innehålla en ogiltig signatur.

**Betyder en giltig signatur att jag ska lita på undertecknaren?**

Inte enbart. Signaturintegritet och förtroende för undertecknaren är separata beslut. En produktionsvalideringspolicy bör också kontrollera certifikatkedjan, giltighetsperiod, återkallningsstatus, förväntad identitet, nyckelanvändning och eventuella betrodda tidsstämpelkrav.

**Vad händer när certifikatet löper ut?**

Certifikatets utgång förändrar inte presentationsbytes, men det påverkar certifikat‑förtroendeutvärderingen. Huruvida en signatur fortsatt anses acceptabel beror på din policy och på om en giltig betrodd tidsstämpel kan bevisa att signeringen skedde medan certifikatet var giltigt. Lita inte enbart på den visade signeringstiden som en betrodd tidsstämpel.

**Kan en signerad presentation fortfarande redigeras?**

Ja. Signering låser inte filen. Att redigera signerat innehåll gör vanligtvis den befintliga signaturen ogiltig, så avsluta presentationen först och signera den slutgiltiga revisionen.

**Kan en presentation innehålla mer än en signatur?**

Ja. Lägg till varje signatur i samlingen som returneras av [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_digitalsignatures/) innan du sparar. Vid validering, inspektera varje signatur och bekräfta att alla erforderliga undertecknare finns.

**Vilka presentationsformat stöder dessa operationer?**

Aspose.Slides stödjer de digitala signatur‑operationer som beskrivs här endast för PPTX. PPT‑ och OpenDocument‑presentationsformat stöds inte av detta API‑arbetsflöde.

**Kan jag ta bort en signatur utan att påverka bilderna?**

Ja. Du kan ta bort en signatur eller rensa hela samlingen och sedan spara presentationen. Bildinnehållet förblir tillgängligt, men den sparade filen innehåller inte längre bevis på den borttagna signaturen.