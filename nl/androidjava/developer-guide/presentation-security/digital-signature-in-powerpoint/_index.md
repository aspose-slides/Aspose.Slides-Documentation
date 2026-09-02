---
title: Digitale handtekeningen toevoegen aan presentaties op Android
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/androidjava/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX‑certificaat
- PKCS#12
- handtekening valideren
- PowerPoint
- PPTX
- beveiliging van presentaties
- Android
- Java
- Aspose.Slides
description: "Leer hoe u bestaande PPTX‑presentaties kunt ondertekenen met PFX‑certificaten en Aspose.Slides voor Android via Java kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger te bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie verwante beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch legitimatiebewijs dat een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt uit de presentatie‑inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening biedt bewijs van oorsprong en integriteit; hij versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** regelt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/androidjava/password-protected-presentation/).

PowerPoint biedt het commando **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation-menu met Add a Digital Signature gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een handtekening‑statusmelding tonen.

![PowerPoint‑melding die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), die een [IDigitalSignatureCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignaturecollection/) retourneren waarvan de items [IDigitalSignature](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignature/) implementeren. Een presentatie kan meerdere handtekeningen bevatten.

## **PFX‑certificaten en wachtwoorden begrijpen**

Een PFX‑bestand, ook wel een PKCS#12‑bestand genoemd en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de bijbehorende privésleutel en de certificaathierarchie bevatten. De privésleutel maakt het mogelijk om een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaat‑pakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar bronbeheer. In productie moet de toegang tot het certificaat‑bestand beperkt worden en moet het wachtwoord worden verkregen uit een geheime opslag of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken een omgevingsvariabele alleen om te voorkomen dat het wachtwoord in code wordt ingebed.

## **Digitale handtekening toevoegen aan een presentatie**

Om een echte ondertekeningsworkflow uit te voeren, laad je een bestaand PPTX‑bestand, maak je een [DigitalSignature](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg je de handtekening toe aan de collectie van de presentatie, en sla je het op als een PPTX‑bestand.

```java
import com.aspose.slides.*;

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

Het opslaan van het resultaat onder een nieuwe naam behoudt het niet‑ondertekende bronbestand. De waarde die wordt ingesteld via [IDigitalSignature.setComments](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) beschrijft het doel van de handtekening; het is geen beveiligingscontrole.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekend PPTX‑bestand laadt, inspecteer je elk item dat wordt geretourneerd door [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). De methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignature/#isValid--) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie‑inhoud.

```java
import com.aspose.slides.*;

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

Een ongeldig resultaat betekent meestal dat de ondertekende presentatie‑inhoud of de handtekeninggegevens na ondertekening zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaaridentiteiten aanwezig zijn.

Dit geldigheidsresultaat mag niet worden beschouwd als een volledige besluitvorming over certificaat‑vertrouwen. Afhankelijk van uw beveiligingsbeleid moet uw toepassing mogelijk ook de X.509‑certificaathierarchie opbouwen en valideren, de geldigheidsdata en intrekkingsstatus van het certificaat controleren, het verwachte onderwerp of vingerafdruk bevestigen, sleutelgebruik valideren en een vertrouwde tijdstempel evalueren. De waarde van [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) op zich is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen verandert de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), en slaat een niet‑ondertekende kopie op.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om slechts één handtekening te verwijderen, roep je [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) aan met de nul‑gebaseerde index. Sla op in een nieuw bestand, tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van uw workflow is.

## **Bewerken en formatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en toepassingen kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken doorgaans de bestaande handtekening ongeldig.
- Voltooi alle gewenste bewerkingen voordat u ondertekent. Als een presentatie moet worden aangepast, sla dan de herziene presentatie op en onderteken die revisie opnieuw.
- Houd de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer uw document‑bewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening biedt bewijs over oorsprong en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij een aparte versleuteling wordt toegepast. Gebruik [password protection](/androidjava/password-protected-presentation/) wanneer de toegang tot de inhoud moet worden beperkt.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaat‑pakket is opgeslagen. Het bepaalt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch gezien kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet aan hun vertrouwde omgeving is toegevoegd. Publieke of cross‑organisatie workflows gebruiken doorgaans een certificaat dat door een vertrouwde CA is uitgegeven.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van de ondertekende presentatie‑inhoud of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandscorruptie kan ook leiden tot een mislukte validatie. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van een bestand dat een ongeldige handtekening bevat.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productieve validatie‑policy moet ook de certificaathierarchie, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er als het certificaat verloopt?**

Het verlopen van het certificaat verandert niets aan de bytes van de presentatie, maar het beïnvloedt de beoordeling van certificaat‑vertrouwen. Of een handtekening acceptabel blijft, hangt af van uw beleid en van of een geldige vertrouwde tijdstempel aantoont dat ondertekening plaatsvond terwijl het certificaat nog geldig was. Vertrouw niet uitsluitend op de weergegeven ondertekenings‑tijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog bewerkt worden?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus voltooi de presentatie eerst en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) voordat u opslaat. Tijdens validatie inspecteert u elke handtekening en bevestigt u dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatiesformaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. U kunt één handtekening verwijderen of de volledige collectie wissen en vervolgens de presentatie opslaan. De dia‑inhoud blijft behouden, maar het opgeslagen bestand bevat niet meer het verwijderde handtekening‑bewijs.