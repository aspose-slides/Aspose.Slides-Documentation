---
title: Presentaties beveiligen met wachtwoord in Python
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/python-net/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- Python
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT‑ en PPTX‑presentaties in Python met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatiedata te laden en te bekijken, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt bewerking maar versleutelt de inhoud niet en voorkomt niet dat de presentatie wordt geladen. Om wachtwoorden voor het wijzigen van presentaties te beheren, zie [Presentaties met schrijfbescherming](/slides/nl/python-net/write-protected-presentation/).

De onderstaande workflows zijn van toepassing op zowel PPT- als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestands‑ en stream‑gebaseerde gedrag belangrijk is.

## **Versleutel een presentatie met een openingswachtwoord**

Gebruik [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/encrypt/) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Documenteigenschappen openbaar houden**

Standaard neemt Aspose.Slides documenteigenschappen op in de presentatie‑versleuteling. De eigenschap [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) bepaalt dit gedrag onafhankelijk van de versleuteling van de dia‑inhoud. Stel deze in op `False` vóór het aanroepen van [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/encrypt/) wanneer een indexeer‑, classificatie‑, zoek‑ of document‑beheersysteem metadata moet lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Het instellen van `encrypt_document_properties` op `False` maakt de dia’s, masters, lay‑outs, vormen, media of andere presentatiewaarde niet openbaar. Het heeft alleen invloed op documenteigenschappen. Zie [Presentatie‑eigenschappen beheren](/slides/nl/python-net/presentation-properties/) om die eigenschappen te lezen zonder de versleutelde inhoud te laden.

## **Versleutelde presentatie laden**

Stel [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Werk met de ontsleutelde presentatie.
    pass
```

## **Versleuteling uit een presentatie verwijderen**

Laad de presentatie met het openingswachtwoord, roep [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/remove_encryption/) aan en sla het resultaat op. De opgeslagen presentatie kan daarna worden geladen zonder wachtwoord.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) om [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/) te verkrijgen zonder een volledige presentaties‑instantie te maken. Controleer [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/is_password_protected/) voordat u een wachtwoord vraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [PresentationInfo.check_password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_password/).

### **Bestandspad‑workflow**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/), en laadt vervolgens de volledige presentatie:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Stream‑workflow**

De stream‑overload van [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) biedt dezelfde workflow. Reset de positie van een doorzoekbare stream voordat u de volledige presentatie uit die stream laadt.

Het volgende voorbeeld gebruikt een PPT‑bestand:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Returnwaarden van CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_password/) retourneert `True` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `False` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `None` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het correcte wachtwoord, inspecteer [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/is_encrypted/) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming met een openingswachtwoord te detecteren vóór het laden, gebruik `PresentationInfo.is_password_protected` zoals hierboven getoond.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Security" %}}
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden alleen zo lang als nodig in het geheugen, en hergebruik een succesvolle validatieresultaat bij het direct laden van de presentatie.

Publieke documenteigenschappen kunnen auteur­namen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen, zelfs als de presentatie‑inhoud versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar houden van eigenschappen moet een expliciete beslissing zijn die alleen wordt genomen wanneer systemen de file moeten indexeren, classificeren, doorzoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Presentatie online met wachtwoord beveiligen**

1. Open de [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock) applicatie.
2. Selecteer of upload de presentatie.
3. Voer een wachtwoord in voor weergavebescherming.
4. Voer eventueel een apart wachtwoord in voor bewerkingsbescherming.
5. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="See also" %}}
- [Presentaties met schrijfbescherming](/slides/nl/python-net/write-protected-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Veelgestelde vragen**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg de presentatiedata, controleer of er een openingswachtwoord‑bescherming aanwezig is, en valideer het wachtwoord voordat u een volledige presentatied instantie maakt.

**Kan een applicatie metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie versleuteld is met `encrypt_document_properties` ingesteld op `False`. De applicatie moet dan de alleen‑documenteigenschappen‑laadmodus gebruiken die wordt beschreven in [Presentatie‑eigenschappen beheren](/slides/nl/python-net/presentation-properties/).

**Ondersteunen de wachtwoord‑controle‑workflows zowel PPT als PPTX?**

Ja. Wachtwoorddetectie en -validatie op basis van bestandspad en stream werken gelijk voor PPT‑ en PPTX‑presentaties.