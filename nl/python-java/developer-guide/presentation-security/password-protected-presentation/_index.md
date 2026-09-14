---
title: Presentaties met wachtwoord beveiligen in Python
linktitle: Wachtwoordbescherming
type: docs
weight: 20
url: /nl/python-java/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- encryptie verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- Python
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en weer te geven, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt bewerken, maar versleutelt de inhoud niet en verhindert niet dat de presentatie wordt geladen. Voor het beheren van wachtwoorden voor het wijzigen van presentaties, zie [Presentaties schrijfbeveiligen](/slides/nl/python-java/write-protected-presentation/) .

De workflows hieronder gelden voor zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun gedrag op bestand‑ en stream‑basis belangrijk is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#encrypt) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Documenteigenschappen openbaar houden**

Standaard omvat Aspose.Slides documenteigenschappen bij de encryptie van een presentatie. De methode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) regelt dit gedrag onafhankelijk van de encryptie van de dia‑inhoud. Geef `False` door vóór het aanroepen van [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#encrypt) wanneer een indexeer‑, classificatie‑, zoek‑ of documentbeheersysteem metadata moet kunnen lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie, terwijl de ingebouwde documenteigenschappen openbaar blijven:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`False` doorgeven aan [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) maakt niet de dia’s, masters, lay‑outs, vormen, media of andere presentatietekst openbaar. Het heeft alleen effect op documenteigenschappen. Zie [Presentatie‑eigenschappen beheren](/slides/nl/python-java/presentation-properties/) om die eigenschappen te lezen zonder de versleutelde inhoud te laden.

## **Een versleutelde presentatie laden**

Stel [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Werk met de ontsleutelde presentatie.
    pass
finally:
    presentation.dispose()
```

## **Encryptie van een presentatie verwijderen**

Laad de presentatie met het openingswachtwoord, roep [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#removeEncryption) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) om [PresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/) te verkrijgen zonder een volledige presentatie‑instance te maken. Controleer [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#isPasswordProtected) voordat u een wachtwoord vraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#checkPassword) .

### **Bestandspad‑workflow**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword) en laadt daarna de volledige presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Stream‑workflow**

De stream‑overload van [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) biedt dezelfde workflow. Reset de positie van een seek‑bare stream vóór het laden van de volledige presentatie vanaf die stream.

Het volgende voorbeeld gebruikt een PPT‑bestand:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Teruggeefwaarden van checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#checkPassword) retourneert `True` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `False` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `None` of leeg.

Het gedrag is identiek voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het juiste wachtwoord, controleer [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isEncrypted) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming met een openingswachtwoord vóór het laden te detecteren, gebruik [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#isPasswordProtected) zoals hierboven beschreven.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Beveiliging" %}}
Log geen openingswachtwoorden en vermeld ze niet in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden slechts zo lang als nodig in het geheugen, en hergebruik een geslaagde validatie‑resultaat bij direct laden van de presentatie.

Openbare documenteigenschappen kunnen auteur­namen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen, zelfs wanneer de presentatietekst versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het publiek houden van eigenschappen moet een expliciete beslissing zijn die alleen wordt genomen wanneer systemen de file moeten indexeren, classificeren, doorzoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock) .
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergavebeveiliging.
1. Voer eventueel een apart wachtwoord in voor bewerkingsbeveiliging.
1. Pas de beveiliging toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties schrijfbeveiligen](/slides/nl/python-java/write-protected-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia’s te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of er een openingswachtwoordbeveiliging aanwezig is, en valideer het wachtwoord voordat u een volledige presentaties‑instance maakt.

**Kan een applicatie metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie is versleuteld met document‑eigenschap‑encryptie uitgeschakeld. De applicatie moet dan de alleen‑document‑eigenschappen‑laadmodus gebruiken die wordt beschreven in [Presentatie‑eigenschappen beheren](/slides/nl/python-java/presentation-properties/) .

**Ondersteunen de wachtwoord‑validatie‑workflows zowel PPT als PPTX?**

Ja. Detectie en validatie van wachtwoorden op bestandspad‑ en stream‑basis werken hetzelfde voor PPT‑ en PPTX‑presentaties.