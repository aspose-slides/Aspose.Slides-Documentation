---
title: Digitale handtekeningen toevoegen aan presentaties in C++
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Leer hoe u bestaande PPTX‑presentaties ondertekent met PFX‑certificaten en Aspose.Slides voor C++ gebruikt om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie verwante veiligheidsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch bewijs dat een identiteit koppelt aan een publieke sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gecreëerd vanuit de presentatiew inhoud en de privésleutel van de certificaathouder. De publieke sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van herkomst en integriteit; ze versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Password-Protected Presentations](/cpp/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint‑menu Bescherming van presentatie met Add a Digital Signature gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een handtekeningstatusmelding weergeven.

![PowerPoint‑melding die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_digitalsignatures/), die een [IDigitalSignatureCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignaturecollection/) retourneert waarvan de items [IDigitalSignature](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/) implementeren. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook wel een PKCS#12‑bestand genoemd en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder om een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **niet** het wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar versiebeheer. In productie moet de toegang tot het certificaatbestand beperkt worden en moet het wachtwoord worden opgehaald uit een geheimopslag of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken alleen een omgevingsvariabele om te voorkomen dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening aan een presentatie toevoegen**

Om een echte presentatie te ondertekenen, laad een bestaand PPTX‑bestand, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/cpp/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie en sla het op als een PPTX‑bestand.

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

Het opslaan van het resultaat onder een nieuwe naam behoudt het niet‑ondertekende bronbestand. De waarde van [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/set_comments/) beschrijft het doel van de handtekening; het is geen beveiligingscontrole.

## **Digitale handtekeningen valideren**

Wanneer u een ondertekend PPTX‑bestand laadt, inspecteert u elk item dat wordt geretourneerd door [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_digitalsignatures/). De methode [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/get_isvalid/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatiew inhoud.

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

Een ongeldig resultaat betekent meestal dat de ondertekende presentatiew inhoud of de handtekeninggegevens na ondertekening zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van elke handtekening levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een security‑gevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaar‑identiteiten aanwezig zijn.

Dit geldigheidsresultaat mag niet worden beschouwd als een volledige certificaattrust‑beslissing. Afhankelijk van uw beveiligingsbeleid moet uw applicatie mogelijk ook de X.509‑certificaatketen opbouwen en valideren, de geldigheidsdatums en intrekkingsstatus van het certificaat controleren, het verwachte subject of vingerafdruk bevestigen, sleutelgebruik verifiëren en een vertrouwde tijdstempel evalueren. De waarde van [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/get_signtime/) is op zichzelf geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen wijzigt de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignaturecollection/clear/), en slaat een niet‑ondertekende kopie op.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Om slechts één handtekening te verwijderen, roept u [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignaturecollection/removeat/) aan met de nul‑gebaseerde index. Sla op onder een nieuw bestand tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van uw workflow is.

## **Bewerken en formatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken normaal gesproken de bestaande handtekening ongeldig.
- Voltooi alle bewerkingen vóór het ondertekenen. Als een presentatie gewijzigd moet worden, sla dan de herziene presentatie op en onderteken die revisie opnieuw.
- Houd de uiteindelijke uitvoer in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan mogelijk handtekeningen maken die lijken te komen van die certificaathouder.
- Behoud de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer uw documentbewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over herkomst en integriteit, maar de presentatiew inhoud blijft leesbaar tenzij aparte versleuteling wordt toegepast. Gebruik [password protection](/cpp/password-protected-presentation/) wanneer de toegang tot de inhoud beperkt moet worden.

**Is het PFX‑wachtwoord hetzelfde als het presentatie‑wachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie het PPTX‑bestand kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet aan hun vertrouwde omgeving is toegevoegd. Publieke of cross‑organisatorische workflows gebruiken doorgaans een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatiew inhoud of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandsschade kan eveneens een validatiefout veroorzaken. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van een bestand dat een ongeldige handtekening bevat.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productie‑validatiebeleid moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van een certificaat verandert de bytes van de presentatie niet, maar het beïnvloedt de evaluatie van het certificaatvertrouwen. Of een handtekening acceptabel blijft, hangt af van uw beleid en van of een geldige vertrouwde tijdstempel aantoont dat de ondertekening plaatsvond terwijl het certificaat geldig was. Vertrouw niet alleen op de weergegeven ondertekeningstijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog bewerkt worden?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus voltooi de presentatie eerst en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_digitalsignatures/) voordat u opslaat. Tijdens validatie inspecteert u elke handtekening en bevestigt u dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatieformaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekeningbewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden door deze API‑workflow niet ondersteund.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. U kunt één handtekening verwijderen of de hele collectie wissen en vervolgens de presentatie opslaan. De inhoud van de dia's blijft behouden, maar het opgeslagen bestand bevat de verwijderde handtekening niet meer.