---
title: Presentaties met wachtwoord beveiligen in Python
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
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX-presentaties in Python met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en te bekijken, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeveiligingswachtwoord. Schrijfbeveiliging beperkt modificatie maar versleutelt de inhoud niet en verhindert niet dat de presentatie wordt geladen. Voor het beheren van wachtwoorden om presentaties te wijzigen, zie [Presentaties met schrijfbescherming](/slides/nl/python-net/write-protected-presentation/).

De workflows hieronder zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestand‑gebaseerde en stream‑gebaseerde gedrag belangrijk is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/encrypt/) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Een versleutelde presentatie laden**

Stel [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Werken met de ontcijferde presentatie.
    pass
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het bijbehorende openingswachtwoord, roep [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/remove_encryption/) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Een openingswachtwoord valideren voordat geladen wordt**

Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) om [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/) te verkrijgen zonder een volledige presentatiefunctie te maken. Controleer [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/is_password_protected/) voordat een wachtwoord wordt aangevraagd of gevalideerd. Wanneer bescherming aanwezig is, valideer de opgegeven waarde met [PresentationInfo.check_password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_password/).

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

De stream‑overload van [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) biedt dezelfde workflow. Reset de positie van een doorzoekbare stream voordat de volledige presentatie uit die stream wordt geladen.

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

### **Return‑waarden van CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_password/) retourneert `True` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `False` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `None` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het juiste wachtwoord, inspecteer [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/is_encrypted/) om te bevestigen dat de bronpresentatie versleuteld was. Om openings‑wachtwoordbescherming te detecteren voordat geladen wordt, gebruik `PresentationInfo.is_password_protected` zoals hierboven getoond.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Beveiliging" %}}
Log geen openingswachtwoorden en voeg ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatiepogingen, bewaar wachtwoorden alleen in het geheugen zolang dat nodig is, en hergebruik een geslaagde validatieresultaat bij het direct laden van de presentatie.
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergavebescherming.
1. Voer eventueel een apart wachtwoord in voor bewerkingsbescherming.
1. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties met schrijfbescherming](/slides/nl/python-net/write-protected-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeveiligingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeveiligingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of er een openings‑wachtwoordbescherming aanwezig is, en valideer het wachtwoord voordat een volledige presentatiefunctie wordt aangemaakt.

**Ondersteunen de wachtwoord‑controleworkflows zowel PPT als PPTX?**

Ja. Bestandspad‑ en stream‑gebaseerde wachtwoorddetectie en -validatie gedragen zich hetzelfde voor PPT‑ en PPTX‑presentaties.