---
title: Write-Protect Presentaties in Python
linktitle: Write‑protectie
type: docs
weight: 25
url: /nl/python-java/write-protected-presentation/
keywords:
- write‑protectie
- write‑protect PowerPoint
- wachtwoord om te wijzigen
- presentatie‑bewerking beperken
- write‑protectie verwijderen
- wijzigingswachtwoord valideren
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Stel write‑protectie wachtwoorden in, detecteer, valideer en verwijder ze in PowerPoint PPT‑ en PPTX‑presentaties met Aspose.Slides voor Python via Java."
---
## **Introductie**

Een write‑protection‑wachtwoord beperkt de wijziging van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een write‑protected‑presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de toepassing kunnen ze ook de inhoud bewerken en onder een andere naam opslaan, dus write‑protection mag niet worden beschouwd als een vertrouwelijkheidsmechanisme.

Een open‑password dient een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Om een presentatie te versleutelen of een open‑password te valideren, zie [Password‑Protect Presentations](/slides/nl/python-java/password-protected-presentation/).

De werkwijzen in dit artikel zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan naar PPT gebruik je de extensie `.ppt` en het overeenkomstige PPT‑opslagformaat.

## **Write‑protection instellen op een presentatie**

Gebruik [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#setWriteProtection) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie bewaart de beschermingsinstelling.

Het volgende voorbeeld stelt write‑protection in op een PPTX‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Write‑protected presentatie laden**

Aangezien write‑protection de presentatiew inhoud niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beschermde presentatie te wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Geef geen write‑protection‑wachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword). Die methode accepteert een open‑password voor versleutelde inhoud. Als een presentatie beide beschermingssoorten heeft, geef dan het open‑password door om deze te laden en behandel het write‑protection‑wachtwoord afzonderlijk.

## **Write‑protection verwijderen van een presentatie**

Gebruik [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#removeWriteProtection) om de wijzigingsbeperking te verwijderen, en sla daarna de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controleren of een presentatie write‑protected is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie te maken, roep je [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) aan en inspecteer je [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#isWriteProtected). De methode gebruikt [NullableBool](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/) en retourneert `NullableBool.True_` wanneer write‑protection wordt gedetecteerd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

De stream‑overload van [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) biedt dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Write‑protection‑wachtwoord valideren**

Gebruik [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#checkWriteProtection) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#isWriteProtected) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer write‑protection aanwezig is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#checkWriteProtection) valideert alleen het write‑protection‑wachtwoord. Het valideert geen open‑password of bepaalt of versleutelde inhoud kan worden geladen. Omgekeerd valideert [PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#checkPassword) alleen een open‑password. Als een volledige presentatie al is geladen, biedt [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#checkWriteProtection) de equivalente write‑protection‑controle via de protection manager.

Log in productie‑applicaties geen wachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen en bewaar wachtwoorden in het geheugen alleen zolang dat nodig is.

{{% alert color="info" title="Zie ook" %}}
- [Password‑Protect Presentations](/slides/nl/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/nl/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Veelgestelde vragen**

**Versleutelt write‑protection een presentatie?**

Nee. Het beperkt de wijziging, maar laat de presentatiew inhoud beschikbaar voor laden en bekijken.

**Is het write‑protection‑wachtwoord vereist om een presentatie te openen?**

Nee. Alleen een open‑password is vereist om versleutelde presentatiew inhoud te laden.

**Kan een presentatie zowel een open‑password als een write‑protection‑wachtwoord hebben?**

Ja. Geef het open‑password via de load‑options door om de versleutelde presentatie te openen, en valideer het write‑protection‑wachtwoord afzonderlijk wanneer wijzigingsautorisatie vereist is.