---
title: Digitale handtekeningen toevoegen aan presentaties in Python
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/python-java/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX certificaat
- PKCS#12
- handtekening valideren
- PowerPoint
- PPTX
- presentatiebeveiliging
- Python
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX certificaten en Aspose.Slides voor Python via Java kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft getekend en of de ondertekende inhoud is gewijzigd. Drie verwante beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch credential dat een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt van de presentatie-inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van oorsprong en integriteit; het versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/slides/nl/python-java/password-protected-presentation/).

PowerPoint biedt de opdracht **Digitale handtekening toevoegen** onder **Bestand > Info > Presentatie beveiligen**.

![PowerPoint menu Presentatie beveiligen met Digitale handtekening toevoegen gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een notificatie over de handtekeningstatus weergeven.

![PowerPoint-notificatie die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDigitalSignatures), die een [DigitalSignatureCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignaturecollection/) teruggeeft waarvan de items instanties van [DigitalSignature](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignature/) zijn. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX-certificaten en wachtwoorden**

Een PFX‑bestand, ook bekend als een PKCS#12‑bestand en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de bijbehorende privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder om een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaat‑pakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Voeg geen PFX‑bestanden of hun wachtwoorden toe aan source control. In productie moet de toegang tot het certificaatbestand worden beperkt en moet het wachtwoord worden verkregen uit een secret‑store of een andere beveiligde configuratiebron. De voorbeelden hieronder gebruiken een omgevingsvariabele alleen om te voorkomen dat het wachtwoord in code wordt ingesloten.

## **Digitale handtekening toevoegen aan een presentatie**

Om een echte ondertekeningsworkflow te demonstreren, laad je een bestaand PPTX‑bestand, maak je een [DigitalSignature](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignature/) van een PFX‑certificaat en het bijbehorende wachtwoord, voeg je de handtekening toe aan de collectie van de presentatie, en sla je het op als een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Het resultaat onder een nieuwe naam opslaan behoudt het niet‑ondertekende bronbestand. De waarde die wordt ingesteld via [DigitalSignature.setComments](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignature/#setComments) beschrijft het doel van de handtekening; het is geen beveiligingsmiddel.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekend PPTX‑bestand laadt, inspecteer je elk item dat wordt teruggegeven door [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDigitalSignatures). De methode [DigitalSignature.isValid](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignature/#isValid) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie-inhoud.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Een ongeldig resultaat betekent meestal dat de ondertekende presentatie‑inhoud of handtekeninggegevens na ondertekening zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaar‑identiteiten aanwezig zijn.

Dit geldigheidsresultaat mag niet worden beschouwd als een definitieve certificaat‑vertrouwensbeslissing. Afhankelijk van je beveiligingsbeleid moet je mogelijk ook de X.509‑certificaatketen opbouwen en valideren, de geldigheidsdata en intrekkingsstatus van het certificaat controleren, het verwachte subject of de vingerafdruk bevestigen, sleutel­gebruik verifiëren, en een vertrouwd tijdstempel evalueren. De waarde van [DigitalSignature.getSignTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignature/#getSignTime) alleen is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen verandert de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignaturecollection/#clear), en slaat een niet‑ondertekende kopie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om slechts één handtekening te verwijderen, roep je [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/digitalsignaturecollection/#removeAt) aan met de nul‑gebaseerde index. Sla op onder een nieuw bestand tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van je workflow is.

## **Bewerkings- en formaatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken doorgaans de bestaande handtekening ongeldig.
- Voltooi alle bewerkingen voordat je ondertekent. Als een presentatie later moet worden aangepast, sla dan de herziene presentatie op en onderteken die revisie opnieuw.
- Houd de uiteindelijke uitvoer in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer jouw bewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**  
Nee. Een digitale handtekening levert bewijs over oorsprong en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij er aparte encryptie wordt toegepast. Gebruik [wachtwoordbeveiliging](/slides/nl/python-java/password-protected-presentation/) wanneer de toegang tot de inhoud moet worden beperkt.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**  
Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaat‑pakket is opgeslagen. Het regelt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**  
Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatie workflows maken doorgaans gebruik van een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**  
Het wijzigen van ondertekende presentatie‑inhoud of van de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandscorruptie kan ook zorgen voor een mislukte validatie. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van dat er een ongeldige handtekening in zit.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**  
Niet op zichzelf. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productie‑validatiebeleid moet ook de certificaatketen, de geldigheidsperiode, de intrekkingsstatus, de verwachte identiteit, sleutel‑gebruik en eventuele vereiste tijdstempels controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**  
Het verlopen van het certificaat verandert de bytes van de presentatie niet, maar het beïnvloedt de evaluatie van het certificaat‑vertrouwen. Of een handtekening acceptabel blijft, hangt af van je beleid en van de aanwezigheid van een geldig, vertrouwd tijdstempel dat bewijst dat ondertekening gebeurde terwijl het certificaat geldig was. Vertrouw niet alleen op de weergegeven ondertekeningtijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**  
Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt de bestaande handtekening doorgaans ongeldig, dus maak de presentatie eerst af en onderteken daarna de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**  
Ja. Voeg elke handtekening toe aan de collectie die wordt teruggegeven door [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDigitalSignatures) voordat je opslaat. Tijdens de validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatie‑formaten ondersteunen deze bewerkingen?**  
Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**  
Ja. Je kunt één handtekening verwijderen of de hele collectie wissen en vervolgens de presentatie opslaan. De inhoud van de dia's blijft beschikbaar, maar het opgeslagen bestand bevat niet langer het verwijderde handtekening‑bewijs.