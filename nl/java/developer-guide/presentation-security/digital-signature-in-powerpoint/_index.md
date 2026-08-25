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
- presentatiebeveiliging
- Java
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties ondertekent met PFX-certificaten en Aspose.Slides voor Java gebruikt om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger te bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie gerelateerde beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch bewijs dat een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne werkstromen.
- Een **digitale handtekening** wordt gemaakt van de presentatie‑inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening biedt bewijs van herkomst en integriteit; het versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/slides/nl/java/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een melding over de handtekeningstatus tonen.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides.ipresentation/#getDigitalSignatures--), die een [IDigitalSignatureCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignaturecollection/) retourneert waarvan de items [IDigitalSignature](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignature/) implementeren. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook wel een PKCS#12‑bestand genoemd en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de bijbehorende privésleutel en de certificaatketen bevatten. De privésleutel stelt de houder in staat een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar versiebeheer. In productie moet de toegang tot het certificaatbestand beperkt worden en moet het wachtwoord worden opgehaald uit een geheime opslag of een andere beveiligde configuratiebron. De voorbeelden hieronder gebruiken een omgevingsvariabele alleen om te vermijden dat het wachtwoord in code wordt ingebed.

## **Een digitale handtekening aan een presentatie toevoegen**

Om een echte ondertekeningsworkflow te demonstreren, laad je een bestaande PPTX‑file, maak je een [DigitalSignature](https://reference.aspose.com/slides/nl/java/com.aspose.slides.digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg je de handtekening toe aan de collectie van de presentatie, en sla je het op als een PPTX‑file.

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

Het opslaan van het resultaat onder een nieuwe naam behoudt het niet‑ondertekende bronbestand. De waarde die wordt gezet met [IDigitalSignature.setComments](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignature/#setComments-java.lang.String-) beschrijft het doel van de handtekening; het is geen beveiligingsmaatregel.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekende PPTX‑file laadt, inspecteer je elk item dat wordt geretourneerd door [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides.ipresentation/#getDigitalSignatures--). De methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignature/#isValid--) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie‑inhoud.

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

Een ongeldig resultaat betekent meestal dat de ondertekende presentatie‑inhoud of handtekeninggegevens na ondertekening zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingskritieke workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat moet niet worden geïnterpreteerd als een volledige certificaat‑vertrouwensbeslissing. Afhankelijk van je beveiligingsbeleid moet je mogelijk ook de X.509‑certificaatketen bouwen en valideren, de geldigheidsdatums en intrekkingsstatus van het certificaat controleren, het verwachte onderwerp of vingerafdruk bevestigen, het sleutelgebruik verifiëren, en een vertrouwde tijdstempel evalueren. De waarde van [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignature/#getSignTime--) op zichzelf is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen verandert de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekende PPTX‑file, verwijdert alle handtekeningen met [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignaturecollection/#clear--), en slaat een niet‑ondertekende kopie op.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om slechts één handtekening te verwijderen, roep je [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idigitalsignaturecollection/#removeAt-int-) aan met de nul‑gebaseerde index. Sla op in een nieuw bestand tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van je workflow is.

## **Bewerkings‑ en formaatoverwegingen**

- Een handtekening maakt een presentatie niet uitsluitend alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen aan ondertekende inhoud maken normaal gesproken de bestaande handtekening ongeldig.
- Voer alle gewenste bewerkingen uit vóór het ondertekenen. Als een presentatie later moet worden gewijzigd, sla dan de gewijzigde versie op en onderteken die revisie opnieuw.
- Bewaar de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar het niet‑ondertekende bronbestand of een andere gecontroleerde kopie wanneer je document‑retentiebeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening biedt bewijs van herkomst en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij er aparte versleuteling wordt toegepast. Gebruik [password protection](/slides/nl/java/password-protected-presentation/) wanneer de toegang tot de inhoud beperkt moet worden.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers vertrouwen het niet automatisch, tenzij dat certificaat expliciet aan hun vertrouwde omgeving is toegevoegd. Publieke of cross‑organisatie workflows gebruiken doorgaans een certificaat dat door een vertrouwde CA is uitgegeven.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatie‑inhoud of van de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandscorruptie kan ook de validatie doen falen. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van een bestand met een ongeldige handtekening.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zich. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn aparte beslissingen. Een productie‑validatiebeleid moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele eisen aan een vertrouwde tijdstempel controleren.

**Wat gebeurt er als het certificaat verloopt?**

Het verlopen van het certificaat wijzigt de bytes van de presentatie niet, maar het beïnvloedt de evaluatie van het certificaat‑vertrouwen. Of een handtekening acceptabel blijft, hangt af van je beleid en van een eventuele geldige, vertrouwde tijdstempel die aantoont dat de ondertekening plaatsvond terwijl het certificaat nog geldig was. Vertrouw niet uitsluitend op de weergegeven ondertekenings‑tijd als een betrouwbare tijdstempel.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt de bestaande handtekening doorgaans ongeldig, dus voltooi de presentatie eerst en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/java/com.aspose.slides.ipresentation/#getDigitalSignatures--) voordat je opslaat. Tijdens validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatieformaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de gehele collectie wissen en vervolgens de presentatie opslaan. De inhoud van de dia's blijft beschikbaar, maar het opgeslagen bestand bevat niet langer het bewijs van de verwijderde handtekening.