---
title: Schrijfbeveiligde presentaties in Python
linktitle: Schrijfbeveiliging
type: docs
weight: 25
url: /nl/python-net/write-protected-presentation/
keywords:
- schrijfbeveiliging
- schrijfbeveiliging PowerPoint
- wachtwoord om te wijzigen
- presentatiebewerking beperken
- schrijfbeveiliging verwijderen
- wijzigingswachtwoord valideren
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Stel schrijfbeschermingswachtwoorden in, detecteer, valideer en verwijder ze in PowerPoint PPT- en PPTX-presentaties met Aspose.Slides voor Python."
---
## **Inleiding**

Een wachtwoord voor schrijfbescherming beperkt de wijziging van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een schrijfbeveiligde presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de toepassing kunnen ze ook de inhoud bewerken en deze onder een andere naam opslaan, dus schrijfbescherming moet niet worden beschouwd als een vertrouwelijkheidsmechanisme.

Een openingswachtwoord dient een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Om een presentatie te versleutelen of een openingswachtwoord te valideren, zie [Password-Protect Presentations](/slides/nl/python-net/password-protected-presentation/).

De werkwijzen in dit artikel zijn van toepassing op zowel PPT- als PPTX‑presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan als PPT, gebruik de extensie `.ppt` en het overeenkomstige PPT‑opslagformaat.

## **Stel schrijfbescherming in voor een presentatie**

Gebruik [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/set_write_protection/) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie behoudt de beveiligingsinstelling.

Het volgende voorbeeld stelt schrijfbescherming in voor een PPTX‑presentatie:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Laad een schrijfbeveiligde presentatie**

Omdat schrijfbescherming de presentatie‑inhoud niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beveiligde presentatie te wijzigen.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Geef geen schrijfbeschermingswachtwoord door aan [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/). Die property accepteert een openingswachtwoord voor versleutelde inhoud. Als een presentatie beide soorten bescherming heeft, geef dan het openingswachtwoord door om deze te laden en behandel het schrijfbeschermingswachtwoord apart.

## **Verwijder schrijfbescherming van een presentatie**

Gebruik [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/remove_write_protection/) om de wijzigingsbeperking te verwijderen, en sla daarna de presentatie op.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Controleren of een presentatie schrijfbeveiligd is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie te maken, roep [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) aan en controleer [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/is_write_protected/). De eigenschap maakt gebruik van [NullableBool](https://reference.aspose.com/slides/nl/python-net/aspose.slides/nullablebool/) en retourneert `NullableBool.TRUE` wanneer schrijfbescherming wordt gedetecteerd.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

De stream‑overload van [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) biedt dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Valideer een schrijfbeschermingswachtwoord**

Gebruik [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_write_protection/) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/is_write_protected/) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer schrijfbescherming aanwezig is.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_write_protection/) valideert alleen het schrijfbeschermingswachtwoord. Het valideert geen openingswachtwoord en bepaalt niet of versleutelde inhoud kan worden geladen. Omgekeerd valideert [PresentationInfo.check_password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/check_password/) alleen een openingswachtwoord. Als een volledige presentatie al is geladen, biedt [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/check_write_protection/) de equivalente schrijfbeschermingscontrole via zijn protectiemanager.

Log in productie‑toepassingen geen wachtwoorden en voeg ze niet toe aan diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen en bewaar wachtwoorden in het geheugen alleen zolang als nodig is.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/nl/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/nl/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Versleutelt schrijfbescherming een presentatie?**

Nee. Het beperkt de wijziging, maar laat de presentatie‑inhoud beschikbaar voor het laden en bekijken.

**Is het schrijfbeschermingswachtwoord vereist om een presentatie te openen?**

Nee. Alleen een openingswachtwoord is vereist om versleutelde presentatie‑inhoud te laden.

**Kan een presentatie zowel een openingswachtwoord als een schrijfbeschermingswachtwoord hebben?**

Ja. Geef het openingswachtwoord via de laadopties op om de versleutelde presentatie te openen, en valideer het schrijfbeschermingswachtwoord apart wanneer autorisatie voor wijziging vereist is.