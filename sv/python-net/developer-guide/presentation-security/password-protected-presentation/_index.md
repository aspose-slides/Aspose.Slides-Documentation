---
title: Lösenordsskydda presentationer i Python
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/python-net/password-protected-presentation/
keywords:
- lösenordsskyddad presentation
- öppningslösenord
- kryptera PowerPoint
- dekryptera PowerPoint
- validera presentationslösenord
- kontrollera presentationslösenord
- öppna krypterad presentation
- ta bort kryptering
- PowerPoint
- PPT
- PPTX
- presentation
- Python
- Aspose.Slides
description: "Kryptera, upptäcka, validera, öppna och dekryptera lösenordsskyddade PowerPoint PPT och PPTX-presentationer i Python med Aspose.Slides."
---
## **Översikt**

Ett öppningslösenord krypterar en presentation. Det korrekta lösenordet krävs för att ladda och visa presentationsinnehållet, så detta skydd ger konfidentialitet.

Ett öppningslösenord skiljer sig från ett skrivskyddslösenord. Skrivskydd begränsar modifiering men krypterar inte innehållet eller förhindrar att presentationen laddas. För att hantera lösenord för att modifiera presentationer, se [Write-Protect Presentations](/slides/sv/python-net/write-protected-presentation/).

Arbetsflödena nedan gäller både PPT- och PPTX-presentationer. Exemplen använder båda formaten där deras filbaserade och ström-baserade beteende är viktigt.

## **Kryptera en presentation med ett öppningslösenord**

Använd [ProtectionManager.encrypt](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/encrypt/) för att tilldela ett öppningslösenord. Använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att spara den krypterade presentationen.

Följande exempel krypterar en PPTX-presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Behåll dokumentegenskaper offentliga**

Som standard inkluderar Aspose.Slides dokumentegenskaper i presentationskryptering. Egenskapen [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) styr detta beteende oberoende av bildinnehålls‑kryptering. Ställ in den till `False` innan du anropar [ProtectionManager.encrypt](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/encrypt/) när ett indexerings-, klassificerings-, sök- eller dokumenthanteringssystem måste läsa metadata utan öppningslösenordet.

Följande exempel skapar en krypterad PPTX-presentation samtidigt som dess inbyggda dokumentegenskaper förblir offentliga:

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

Att sätta `encrypt_document_properties` till `False` gör inte bilder, masterapparater, layouter, former, media eller annat presentationsinnehåll offentligt. Det påverkar endast dokumentegenskaper. För att läsa dessa egenskaper utan att ladda det krypterade innehållet, se [Manage Presentation Properties](/slides/sv/python-net/presentation-properties/).

## **Ladda en krypterad presentation**

Ställ in [LoadOptions.password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/) till öppningslösenordet och skicka alternativet till [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) vid filinläsning. Inläsning misslyckas när ett öppningslösenord krävs men det angivna lösenordet saknas eller är felaktigt.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Arbeta med den dekrypterade presentationen.
    pass
```

## **Ta bort kryptering från en presentation**

Läs in presentationen med dess öppningslösenord, anropa [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/remove_encryption/), och spara resultatet. Den sparade presentationen kan sedan laddas utan lösenord.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Validera ett öppningslösenord innan inläsning**

Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) för att hämta [PresentationInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/) utan att skapa en komplett presentationsinstans. Kontrollera [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/is_password_protected/) innan du begär eller validerar ett lösenord. När skydd finns, validera det angivna värdet med [PresentationInfo.check_password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/check_password/).

### **Filväg arbetsflöde**

Följande exempel validerar ett öppningslösenord för en PPTX-fil, vidarebefordrar det validerade värdet till [LoadOptions.password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/), och laddar sedan den kompletta presentationen:

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

### **Ström arbetsflöde**

Strömsöverlagringen av [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) ger samma arbetsflöde. Återställ positionen för en sökbar ström innan du laddar den kompletta presentationen från den strömmen.

Följande exempel använder en PPT-fil:

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

### **Återvändningsvärden för CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/check_password/) returnerar `True` endast när presentationen har ett öppningslösenord och det angivna lösenordet är korrekt. Den returnerar `False` i var och en av följande fall:

- Lösenordet är felaktigt.
- Presentationen har inget öppningslösenord.
- Det angivna lösenordet är `None` eller tomt.

Beteendet är detsamma för PPT- och PPTX-presentationer.

## **Kontrollera om en inläst presentation är krypterad**

Efter att ha laddat en presentation med rätt lösenord, inspektera [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/is_encrypted/) för att bekräfta att källpresentationen var krypterad. För att upptäcka öppningslösenordsskydd innan inläsning, använd `PresentationInfo.is_password_protected` som visas ovan.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Säkerhetsrekommendationer**

{{% alert color="warning" title="Security" %}}
Logga inte öppningslösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga upprepade valideringsförsök, håll lösenord i minnet enbart så länge som behövs, och återanvänd ett lyckat valideringsresultat när du omedelbart laddar presentationen.

Offentliga dokumentegenskaper kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden även om presentationsinnehållet är krypterat. Kryptera känslig metadata tillsammans med presentationen. Att låta egenskaper vara offentliga bör vara ett explicit beslut som endast fattas när system måste indexera, klassificera, söka eller hantera filen utan ett öppningslösenord.
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Öppna applikationen [Aspose.Slides Lock](https://products.aspose.app/slides/sv/lock).
1. Välj eller ladda upp presentationen.
1. Ange ett lösenord för visningsskydd.
1. Ange eventuellt ett separat lösenord för redigeringsskydd.
1. Verkställ skyddet och ladda ner den resulterande filen.

{{% alert color="info" title="Se också" %}}
- [Write-Protect Presentations](/slides/sv/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett öppningslösenord och ett skrivskyddslösenord?**

Ett öppningslösenord krypterar presentationen och krävs för att ladda dess innehåll. Ett skrivskyddslösenord begränsar modifiering utan att kryptera innehållet.

**Kan jag validera ett öppningslösenord utan att ladda alla bilder?**

Ja. Hämta presentationsinformation, kontrollera om öppningslösenordsskydd finns, och validera lösenordet innan du skapar en komplett presentationsinstans.

**Kan en applikation läsa metadata utan öppningslösenordet?**

Ja, men endast när presentationen krypterades med `encrypt_document_properties` satt till `False`. Applikationen måste då använda läge för enbart dokumentegenskaper som beskrivs i [Manage Presentation Properties](/slides/sv/python-net/presentation-properties/).

**Stöder lösenordskontrollarbetsflödena både PPT och PPTX?**

Ja. Filvägs- och ström-baserad lösenorddetektering och validering fungerar likadant för PPT- och PPTX-presentationer.