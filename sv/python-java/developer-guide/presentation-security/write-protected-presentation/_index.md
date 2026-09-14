---
title: Skrivskydda presentationer i Python
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/python-java/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd för PowerPoint
- lösenord för att ändra
- begränsa redigering av presentation
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för Python via Java."
---
## **Introduktion**

Ett skrivskyddslösenord begränsar ändring av en presentation men krypterar inte dess innehåll. Användare kan läsa in och visa en skrivskyddad presentation utan lösenordet. Beroende på programmet kan de även kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en konfidentialitetsmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Password-Protect Presentations](/slides/sv/python-java/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT- och PPTX-presentationer. Exemplen använder PPTX-filer; när du sparar till PPT, använd filändelsen `.ppt` och motsvarande PPT‑sparformat.

## **Ställ in skrivskydd på en presentation**

Använd [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#setWriteProtection) för att tilldela ett lösenord för att ändra en presentation. När presentationen sparas bevaras skyddsinställningen.

Följande exempel sätter skrivskydd på en PPTX-presentation:

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

## **Läs in en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när auktorisation för att ändra den skyddade presentationen ska valideras.

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

Skicka inte ett skrivskyddslösenord till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setPassword). Den metoden accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#removeWriteProtection) för att ta bort ändringsrestriktionen, och spara sedan presentationen.

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

## **Kontrollera om en presentation är skrivskyddad**

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑instans, anropa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) och granska [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#isWriteProtected). Metoden använder [NullableBool](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/) och returnerar `NullableBool.True_` när skrivskydd upptäcks.

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

Strömöverlagringen av [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ger samma information för en presentation som levereras som en ström.

## **Validera ett skrivskyddslösenord**

Använd [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#checkWriteProtection) för att validera ett ändringslösenord utan att läsa in hela presentationen. Kontrollera först [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#isWriteProtected) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

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

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#checkWriteProtection) validerar endast skrivskyddslösenordet. Den validerar inte ett öppningslösenord eller fastställer om krypterat innehåll kan läsas in. Omvänt validerar [PresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#checkPassword) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, ger [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#checkWriteProtection) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer, logga inte lösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge de behövs.

{{% alert color="info" title="Se även" %}}
- [Lösenordsskydda presentationer](/slides/sv/python-java/password-protected-presentation/)
- [Skrivskyddade presentationer](/slides/sv/python-java/read-only-presentation/)
- [Digital signatur i PowerPoint](/slides/sv/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Vanliga frågor**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändringar men låter presentationsinnehållet vara tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via inläsningsalternativen för att öppna den krypterade presentationen, och validera skrivskyddslösenordet separat när ändringsauktorisation krävs.