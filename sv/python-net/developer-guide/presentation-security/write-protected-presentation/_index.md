---
title: Skrivskydda presentationer i Python
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/python-net/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd PowerPoint
- lösenord för att ändra
- begränsa redigering av presentationen
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för Python."
---
## **Introduktion**

Ett lösenord för skrivskydd begränsar ändring av en presentation men krypterar inte dess innehåll. Användare kan läsa in och visa en skrivskyddad presentation utan lösenordet. Beroende på applikationen kan de också kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Password-Protect Presentations](/slides/sv/python-net/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT- och PPTX-presentationer. Exemplen använder PPTX-filer; när du sparar till PPT, använd filändelsen `.ppt` och motsvarande PPT-sparformat.

## **Ange skrivskydd på en presentation**

Använd [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/set_write_protection/) för att tilldela ett lösenord för ändring av en presentation. När presentationen sparas bevaras skyddsinställningen.

Följande exempel sätter skrivskydd på en PPTX-presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Läs in en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när man validerar behörighet att ändra den skyddade presentationen.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Passera inte ett skrivskyddslösenord till [LoadOptions.password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/). Den egenskapen accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/remove_write_protection/) för att ta bort ändringsbegränsningen och sedan spara presentationen.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrollera om en presentation är skrivskyddad**

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans, anropa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) och granska [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/is_write_protected/). Egenskapen använder [NullableBool](https://reference.aspose.com/slides/sv/python-net/aspose.slides/nullablebool/) och returnerar `NullableBool.TRUE` när skrivskydd upptäcks.

Ström‑överladdningen av [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) ger samma information för en presentation som levereras som en ström.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

## **Validera ett skrivskyddslösenord**

Använd [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/check_write_protection/) för att validera ett ändringslösenord utan att läsa in hela presentationen. Kontrollera först [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/is_write_protected/) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

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

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/check_write_protection/) validerar endast skrivskyddslösenordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [PresentationInfo.check_password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/check_password/) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, erbjuder [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/check_write_protection/) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer, logga inte lösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge som behövs.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/sv/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/sv/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändring men låter presentationsinnehållet vara tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via lastalternativen för att öppna den krypterade presentationen, och validera skrivskyddslösenordet separat när ändringsbehörighet krävs.