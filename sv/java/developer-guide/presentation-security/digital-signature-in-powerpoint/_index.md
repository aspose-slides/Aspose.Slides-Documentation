---
title: Lägg till digitala signaturer i presentationer i Java
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Lär dig hur du signerar befintliga PPTX-presentationer med PFX-certifikat och använder Aspose.Slides för Java för att validera eller ta bort digitala signaturer."
---
## **Översikt**

En digital signatur hjälper en mottagare att avgöra vem som har signerat en presentation och om det signerade innehållet har ändrats. Tre relaterade säkerhetskoncept är viktiga här:

- Ett **digitalt certifikat** är ett elektroniskt referensdokument som kopplar en identitet till en publik nyckel. En betrodd certifikatutfärdare (CA) kan utfärda ett certifikat, eller så kan en organisation använda ett självsignerat certifikat för interna arbetsflöden.
- En **digital signatur** skapas från presentationsinnehållet och certifikatets ägares privata nyckel. Certifikatets publika nyckel kan sedan användas för att verifiera signaturen. En signatur ger bevis på ursprung och integritet; den krypterar inte presentationen.
- **Lösenordsskydd** styr om en användare kan öppna eller ändra en presentation. Det är separat från digital signering och beskrivs i [Lösenordsskyddade presentationer](/slides/sv/java/password-protected-presentation/).

PowerPoint tillhandahåller kommandot **Lägg till en digital signatur** under **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation‑meny med Lägg till en digital signatur markerad](add-digital-signature-in-powerpoint.png)

När en signerad presentation öppnas kan PowerPoint visa en signatur‑statusnotifikation.

![PowerPoint‑notifikation som visar att presentationen innehåller giltiga signaturer](digital-signature-status-in-powerpoint.png)

Aspose.Slides exponerar signaturer via [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), vilket returnerar en [IDigitalSignatureCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignaturecollection/) vars objekt implementerar [IDigitalSignature](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignature/). En presentation kan innehålla flera signaturer.

## **Förstå PFX‑certifikat och lösenord**

En PFX‑fil, även känd som en PKCS#12‑fil och ofta med filändelsen `.pfx` eller `.p12`, kan innehålla ett X.509‑certifikat, dess privata nyckel och certifikatkedjan. Den privata nyckeln möjliggör för ägaren att skapa en signatur. Ett certifikat utan en åtkomlig privat nyckel kan inte användas för att signera en presentation.

PFX‑lösenordet skyddar certifikatpaketet och den privata nyckeln. Det är **inte** ett lösenord för att öppna eller redigera presentationen. Lagra inte PFX‑filer eller deras lösenord i källkontrollen. I produktion, begränsa åtkomsten till certifikatfilen och hämta dess lösenord från en hemlig lagring eller en annan skyddad konfigurationskälla. Exemplen nedan använder en miljövariabel endast för att undvika att inbädda lösenordet i koden.

## **Lägg till en digital signatur i en presentation**

För att signera en verklig presentationsarbetsflöde, läs in en befintlig PPTX‑fil, skapa en [DigitalSignature](https://reference.aspose.com/slides/sv/java/com.aspose.slides/digitalsignature/) från ett PFX‑certifikat och dess lösenord, lägg till signaturen i presentationens samling och spara till en PPTX‑fil.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att spara resultatet under ett nytt namn bevarar den osignerade källfilen. Värdet som sätts via [IDigitalSignature.setComments](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) beskriver syftet med signaturen; det är inte en säkerhetskontroll.

## **Validera digitala signaturer**

När du läser in en signerad PPTX‑fil, inspektera varje objekt som returneras av [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoden [IDigitalSignature.isValid](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignature/#isValid--) indikerar om den inbäddade signaturen är giltig för det aktuella presentationsinnehållet.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Ett ogiltigt resultat betyder vanligtvis att det signerade presentationsinnehållet eller signaturdata har ändrats efter signering, eller att filen är skadad. Att ta bort alla signaturer skapar en osignerad presentation, så det räcker inte att enbart kontrollera giltigheten för objekten: ett säkerhetskänsligt arbetsflöde måste också verifiera att det förväntade antalet signaturer och förväntade undertecknares identiteter finns.

Detta giltighetsresultat bör inte betraktas som ett fullständigt beslut om certifikat‑förtroende. Beroende på din säkerhetspolicy kan din applikation också behöva bygga och validera X.509‑certifikatkedjan, kontrollera certifikatets giltighetsdatum och återkallningsstatus, bekräfta förväntad ämnes‑ eller fingeravtrycksidentifierare, verifiera nyckelanvändning och utvärdera en betrodd tidsstämpel. Värdet från [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignature/#getSignTime--) i sig är inte ett bevis från en betrodd tidsstämpelmyndighet.

## **Ta bort digitala signaturer**

Att ta bort signaturer förändrar presentationens säkerhetstillstånd. Följande exempel läser in en signerad PPTX‑fil, tar bort alla signaturer med [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignaturecollection/#clear--), och sparar en osignerad kopia.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För att bara ta bort en signatur, anropa [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) med dess noll‑baserade index. Spara till en ny fil såvida du inte uttryckligen tänker skriva över den signerade originalfilen som en del av ditt arbetsflöde.

## **Redigering och formataspekter**

- En signatur gör inte en presentation skrivskyddad. Användare och applikationer kan fortfarande redigera filen, men ändringar av signerat innehåll ogiltigförklarar vanligtvis den befintliga signaturen.
- Slutför alla avsedda redigeringar innan du signerar. Om en presentation måste ändras, spara den reviderade presentationen och signera den revisionen igen.
- Behåll slutresultatet i PPTX‑format. Att konvertera en signerad presentation till ett annat format överför inte den ursprungliga PPTX‑signaturen som en giltig signatur för den konverterade filen.
- Behandla certifikatets privata nyckel som känslig information. Vem som än får tag i den privata nyckeln och dess lösenord kan skapa signaturer som ser ut att komma från certifikatets ägare.
- Behåll den osignerade källfilen eller en annan kontrollerad kopia när din dokument‑retentionspolicy kräver det.

## **FAQ**

**Krypterar en digital signatur presentationen?**

Nej. En digital signatur ger bevis om ursprung och integritet, men presentationsinnehållet förblir läsbart såvida inte separat kryptering tillämpas. Använd [lösenordsskydd](/slides/sv/java/password-protected-presentation/) när åtkomst till innehållet måste begränsas.

**Är PFX‑lösenordet samma som presentationslösenordet?**

Nej. PFX‑lösenordet låser upp den privata nyckeln som lagras i certifikatpaketet. Det styr inte vem som kan öppna eller redigera PPTX‑filen.

**Kan jag använda ett självsignerat certifikat?**

Ja, ett självsignerat certifikat kan användas när det innehåller en åtkomlig privat nyckel. Mottagare litar inte automatiskt på det, såvida inte certifikatet uttryckligen har lagts till i deras betrodda miljö. Offentliga eller tvärorganisationella arbetsflöden använder vanligtvis ett certifikat utfärdat av en betrodd CA.

**Vad gör en signatur ogiltig?**

Att ändra det signerade presentationsinnehållet eller signaturdata efter signering kan ogiltigförklara signaturen. Filkorruption kan också få valideringen att misslyckas. Om alla signaturer tas bort blir presentationen osignerad snarare än en fil med en ogiltig signatur.

**Betyder en giltig signatur att jag ska lita på undertecknaren?**

Inte på egen hand. Signaturens integritet och förtroendet för undertecknaren är separata beslut. En produktionsvalideringspolicy bör också kontrollera certifikatkedjan, giltighetsperiod, återkallningsstatus, förväntad identitet, nyckelanvändning och eventuella krav på betrodda tidsstämplar.

**Vad händer när certifikatet löper ut?**

Certifikatets utgång ändrar inte presentationsbytarna, men det påverkar bedömningen av certifikatförtroendet. Om en signatur förblir acceptabel beror på din policy och huruvida en giltig betrodd tidsstämpel kan bevisa att signeringen skedde medan certifikatet var giltigt. Lita inte bara på den visasande signeringstiden som en betrodd tidsstämpel.

**Kan en signerad presentation fortfarande redigeras?**

Ja. Signering låser inte filen. Att redigera signerat innehåll gör vanligtvis den befintliga signaturen ogiltig, så slutför presentationen först och signera den slutgiltiga revisionen.

**Kan en presentation innehålla mer än en signatur?**

Ja. Lägg till varje signatur i samlingen som returneras av [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) innan du sparar. Under validering, inspektera varje signatur och bekräfta att alla erforderliga undertecknare finns.

**Vilka presentationsformat stöder dessa operationer?**

Aspose.Slides stödjer de digitala signatur‑operationer som beskrivs här endast för PPTX. PPT‑ och OpenDocument‑presentationsformat stöds inte av detta API‑arbetsflöde.

**Kan jag ta bort en signatur utan att påverka bilderna?**

Ja. Du kan ta bort en signatur eller rensa hela samlingen och sedan spara presentationen. Bildinnehållet förblir tillgängligt, men den sparade filen innehåller inte längre den borttagna signaturens bevis.