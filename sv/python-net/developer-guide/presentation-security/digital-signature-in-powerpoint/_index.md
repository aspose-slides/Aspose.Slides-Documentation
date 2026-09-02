---
title: Lägg till digitala signaturer i presentationer i Python
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Lär dig hur du signerar befintliga PPTX-presentationer med PFX-certifikat och använder Aspose.Slides för Python via .NET för att validera eller ta bort digitala signaturer."
---
## **Översikt**

En digital signatur hjälper en mottagare att avgöra vem som har signerat en presentation och om det signerade innehållet har ändrats. Tre relaterade säkerhetskoncept är viktiga här:

- Ett **digitalt certifikat** är en elektronisk legitimation som kopplar en identitet till en publik nyckel. En betrodd certifikatutfärdare (CA) kan utfärda ett certifikat, eller så kan en organisation använda ett självsignerat certifikat för interna arbetsflöden.
- En **digital signatur** skapas från presentationsinnehållet och certifikatinnehavarens privata nyckel. Certifikatets publika nyckel kan sedan användas för att verifiera signaturen. En signatur ger bevis på ursprung och integritet; den krypterar inte presentationen.
- **Lösenordsskydd** styr om en användare kan öppna eller ändra en presentation. Det är separat från digital signering och beskrivs i [Password-Protected Presentations](/python-net/password-protected-presentation/).

PowerPoint erbjuder kommandot **Add a Digital Signature** under **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Efter att en signerad presentation har öppnats kan PowerPoint visa ett signaturstatus‑meddelande.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides exponerar signaturer via [Presentation.digital_signatures](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/digital_signatures/), en [DigitalSignatureCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignaturecollection/) vars element är [DigitalSignature](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignature/)‑objekt. En presentation kan innehålla flera signaturer.

## **Förstå PFX‑certifikat och lösenord**

En PFX‑fil, även känd som en PKCS#12‑fil och vanligtvis med filändelsen `.pfx` eller `.p12`, kan innehålla ett X.509‑certifikat, dess privata nyckel och certifikatkedjan. Den privata nyckeln möjliggör för innehavaren att skapa en signatur. Ett certifikat utan en åtkomlig privat nyckel kan inte användas för att signera en presentation.

PFX‑lösenordet skyddar certifikatpaketet och den privata nyckeln. Det är **inte** ett lösenord för att öppna eller redigera presentationen. Checka inte in PFX‑filer eller deras lösenord i källkontrollen. I produktionsmiljö ska åtkomsten till certifikatfilen begränsas och lösenordet hämtas från en hemlig lagring eller annan skyddad konfigurationskälla. Exemplen nedan använder en miljövariabel endast för att undvika att bädda in lösenordet i kod.

## **Lägg till en digital signatur i en presentation**

För att signera ett verkligt presentationsarbetsflöde, läs in en befintlig PPTX‑fil, skapa en [DigitalSignature](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignature/) från ett PFX‑certifikat och dess lösenord, lägg till signaturen i presentationens samling och spara till en PPTX‑fil.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Att spara resultatet under ett nytt namn bevarar den osignerade källfilen. Värdet i [DigitalSignature.comments](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignature/comments/) beskriver signaturens syfte; det är ingen säkerhetskontroll.

## **Validera digitala signaturer**

När du läser in en signerad PPTX‑fil, inspektera varje objekt i [Presentation.digital_signatures](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/digital_signatures/). Egenskapen [DigitalSignature.is_valid](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignature/is_valid/) indikerar om den inbäddade signaturen är giltig för det aktuella presentationsinnehållet.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Ett ogiltigt resultat betyder ofta att det signerade presentationsinnehållet eller signaturdata har ändrats efter signering, eller att filen är skadad. Att ta bort alla signaturer ger en osignerad presentation, så att bara kontrollera giltigheten hos objekten räcker inte: ett säkerhetskänsligt arbetsflöde måste också verifiera att förväntat antal signaturer och förväntade undertecknare finns.

Egenskapen [DigitalSignature.certificate](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignature/certificate/) ger certifikatdata som en byte‑array. Exemplet beräknar dess SHA‑256‑fingeravtryck så att en applikation kan jämföra det med fingeravtrycket för ett förväntat undertecknarcertifikat.

Detta giltighetsresultat bör inte betraktas som ett fullständigt beslut om certifikat‑förtroende. Beroende på din säkerhetspolicy kan din applikation också behöva bygga och validera X.509‑certifikatkedjan, kontrollera certifikatets giltighetsperiod och återkallningsstatus, bekräfta förväntad ämnes‑ eller fingeravtryck, verifiera nyckelanvändning och utvärdera ett betrott tidsstämpel. Värdet [DigitalSignature.sign_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignature/sign_time/) i sig är inte bevis från en betrodd tidsstämplings­auktoritet.

## **Ta bort digitala signaturer**

Att ta bort signaturer ändrar presentationens säkerhetstillstånd. Följande exempel läser in en signerad PPTX‑fil, tar bort alla signaturer med [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignaturecollection/clear/), och sparar en osignerad kopia.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

För att ta bort endast en signatur, anropa [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides/digitalsignaturecollection/remove_at/) med dess nollbaserade index. Spara till en ny fil om du inte avsiktligt ska skriva över den signerade originalfilen som en del av ditt arbetsflöde.

## **Redigering och format­överväganden**

- En signatur gör inte en presentation skrivskyddad. Användare och applikationer kan fortfarande redigera filen, men ändringar av signerat innehåll ogiltigförklarar normalt den befintliga signaturen.
- Slutför alla avsedda redigeringar innan du signerar. Om en presentation måste ändras, spara den reviderade versionen och signera den revisionen igen.
- Behåll slututdata i PPTX‑format. Att konvertera en signerad presentation till ett annat format överför inte den ursprungliga PPTX‑signaturen som en giltig signatur för den konverterade filen.
- Behandla certifikatets privata nyckel som känslig information. Vem som än får tag på den privata nyckeln och dess lösenord kan skapa signaturer som ser ut att komma från den certifikatägaren.
- Behåll den osignerade källfilen eller en annan kontrollerad kopia när din dokument‑bevarandepolicy kräver det.

## **FAQ**

**Krypterar en digital signatur presentationen?**

Nej. En digital signatur ger bevis om ursprung och integritet, men presentationsinnehållet förblir läsbart om inte separat kryptering tillämpas. Använd [password protection](/python-net/password-protected-presentation/) när åtkomst till innehållet måste begränsas.

**Är PFX‑lösenordet samma som ett presentationslösenord?**

Nej. PFX‑lösenordet låser upp den privata nyckeln som lagras i certifikatpaketet. Det styr inte vem som kan öppna eller redigera PPTX‑filen.

**Kan jag använda ett självsignerat certifikat?**

Ja, ett självsignerat certifikat kan användas när det innehåller en åtkomlig privat nyckel. Mottagarna kommer dock inte automatiskt att lita på det, såvida inte certifikatet uttryckligen har lagts till i deras betrodda miljö. Offentliga eller tvärorganisations‑arbetsflöden använder vanligtvis ett certifikat utfärdat av en betrodd CA.

**Vad gör en signatur ogiltig?**

Att ändra det signerade presentationsinnehållet eller signaturdata efter signering kan ogiltigförklara signaturen. Filkorruption kan också leda till att valideringen misslyckas. Om alla signaturer tas bort är presentationen osignerad snarare än att den innehåller en ogiltig signatur.

**Betyder en giltig signatur att jag ska lita på undertecknaren?**

Inte i sig självt. Signaturens integritet och förtroende för undertecknaren är separata beslut. En produktionsvalideringspolicy bör också kontrollera certifikatkedjan, giltighetsperiod, återkallningsstatus, förväntad identitet, nyckelanvändning och eventuella krav på betrodda tidsstämplar.

**Vad händer när certifikatet löper ut?**

Certifikatets utgångsdatum ändrar inte presentationsbytes, men det påverkar bedömningen av certifikat‑förtroende. Om en signatur fortsatt anses acceptabel beror på din policy och på om en giltig betrodd tidsstämpel visar att signeringen skedde medan certifikatet var giltigt. Lita inte enbart på den visade signeringstiden som en betrodd tidsstämpel.

**Kan en signerad presentation fortfarande redigeras?**

Ja. Signering låser inte filen. Att redigera signerat innehåll gör generellt den befintliga signaturen ogiltig, så slutför presentationen först och signera den slutgiltiga revisionen.

**Kan en presentation innehålla mer än en signatur?**

Ja. Lägg till varje signatur i [Presentation.digital_signatures](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/digital_signatures/) innan du sparar. Vid validering, inspektera varje signatur och bekräfta att alla erforderliga undertecknare finns.

**Vilka presentationsformat stöder dessa operationer?**

Aspose.Slides stöder de digital‑signatur‑operationer som beskrivs här endast för PPTX. PPT‑ och OpenDocument‑presentationsformat stöds inte av detta API‑arbetsflöde.

**Kan jag ta bort en signatur utan att påverka bilderna?**

Ja. Du kan ta bort en signatur eller rensa hela samlingen och sedan spara presentationen. Bildinnehållet förblir tillgängligt, men den sparade filen innehåller inte längre bevis på den borttagna signaturen.