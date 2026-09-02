---
title: Digitale handtekeningen toevoegen aan presentaties in Java
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/java/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX-certificaat
- PKCS#12
- handtekening valideren
- PowerPoint
- PPTX
- beveiliging van presentaties
- Java
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties ondertekent met PFX-certificaten en Aspose.Slides voor Java gebruikt om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie verwante beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronische referentie die een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt op basis van de presentatie‑inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening biedt bewijs van herkomst en integriteit; het versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde Presentaties](/java/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint‑menu Bescherm presentatie met Add a Digital Signature gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een melding over de handtekeningstatus weergeven.

![PowerPoint‑melding die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides exposeert handtekeningen via [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), die een [IDigitalSignatureCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignaturecollection/) retourneert, waarvan de items [IDigitalSignature](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignature/) implementeren. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook wel een PKCS#12‑bestand genoemd en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de bijbehorende privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder om een handtekening te creëren. Een certificaat zonder toegankelijke privésleutel kan niet gebruikt worden om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **niet** het wachtwoord om de presentatie te openen of te bewerken. Sla PFX‑bestanden of hun wachtwoorden niet op in versiebeheer. In productie moet de toegang tot het certificaatbestand beperkt worden en moet het wachtwoord verkregen worden uit een geheimopslag of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken een omgevingsvariabele alleen om te vermijden dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening toevoegen aan een presentatie**

Om een echte onderteken‑workflow te demonstreren, laad je een bestaand PPTX‑bestand, maak je een [DigitalSignature](https://reference.aspose.com/slides/nl/java/com.aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg je de handtekening toe aan de collectie van de presentatie, en sla je het op als een PPTX‑bestand.

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

Het opslaan van het resultaat onder een nieuwe naam behoudt het oorspronkelijke, niet‑ondertekende bronbestand. De waarde die wordt ingesteld met [IDigitalSignature.setComments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) beschrijft het doel van de handtekening; het is geen beveiligingsmaatregel.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekend PPTX‑bestand laadt, inspecteer je elk item dat wordt geretourneerd door [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). De methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignature/#isValid--) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatiesinhoud.

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

Een ongeldige uitkomst betekent meestal dat de ondertekende presentatie‑inhoud of de handtekeninggegevens zijn gewijzigd na ondertekening, of dat het bestand beschadigd is. Het verwijderen van elke handtekening levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een security‑gevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat mag niet worden beschouwd als een volledige certificaat‑vertrouwensbeslissing. Afhankelijk van jouw beveiligingsbeleid kan jouw applicatie ook de X.509‑certificaatketen moeten opbouwen en valideren, controle op geldigheidsdatums en intrekkingsstatus uitvoeren, de verwachte subject‑ of vingerafdruk bevestigen, key usage verifiëren en een vertrouwde timestamp evalueren. De waarde van [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignature/#getSignTime--) op zich is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen verandert de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignaturecollection/#clear--), en slaat een niet‑ondertekende kopie op.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om slechts één handtekening te verwijderen, roep je [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) aan met de nul‑gebaseerde index. Sla op onder een nieuwe bestandsnaam, tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van je workflow is.

## **Bewerkings‑ en formatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen aan ondertekende inhoud maken de bestaande handtekening doorgaans ongeldig.
- Voltooi alle bewerkingen voordat je ondertekent. Als een presentatie later gewijzigd moet worden, sla dan de herziene versie op en onderteken die revisie opnieuw.
- Houd de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Behandel de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het bijbehorende wachtwoord verkrijgt, kan handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer jouw bewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over herkomst en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij er afzonderlijke versleuteling wordt toegepast. Gebruik [wachtwoordbeveiliging](/java/password-protected-presentation/) wanneer de toegang tot de inhoud moet worden beperkt.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers vertrouwen het echter niet automatisch, tenzij dat certificaat expliciet aan hun vertrouwde omgeving is toegevoegd. Publieke of cross‑organisatieworkflows maken doorgaans gebruik van een certificaat dat door een vertrouwde CA is uitgegeven.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatiewijzig of van de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandscorruptie kan ook leiden tot een mislukte validatie. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van een bestand met een ongeldige handtekening.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productie‑validatiebeleid moet bovendien de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, key usage en eventuele vertrouwde timestamp criteria controleren.

**Wat gebeurt er als het certificaat verloopt?**

Het verlopen van het certificaat verandert de bytes van de presentatie niet, maar het beïnvloedt de beoordeling van certificaat‑vertrouwen. Of een handtekening acceptabel blijft, hangt af van jouw beleid en of een geldige vertrouwde timestamp kan aantonen dat ondertekening heeft plaatsgevonden terwijl het certificaat nog geldig was. Vertrouw niet alleen op de weergegeven onderteken‑tijd als een vertrouwde timestamp.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**

Ja. Ondertekenen blokkeert het bestand niet. Bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus rond de presentatie eerst af en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) voordat je opslaat. Tijdens de validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatiefomaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia’s te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de gehele collectie wissen en daarna de presentatie opslaan. De inhoud van de dia’s blijft behouden, maar het opgeslagen bestand draagt de verwijderde handtekening niet meer.