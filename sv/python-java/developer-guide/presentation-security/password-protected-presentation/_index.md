---
title: Lösenordsskydda presentationer i Python
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/python-java/password-protected-presentation/
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
description: "Kryptera, upptäcka, validera, öppna och dekryptera lösenordsskyddade PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Ett öppningslösenord krypterar en presentation. Det korrekta lösenordet krävs för att läsa in och visa presentationsinnehållet, så detta skydd ger konfidentialitet.

Ett öppningslösenord skiljer sig från ett skrivskyddslösenord. Skrivskydd begränsar modifiering men krypterar inte innehållet eller hindrar presentationen från att läsas in. För att hantera lösenord för att ändra presentationer, se [Skrivskydda presentationer](/slides/sv/python-java/write-protected-presentation/).

Arbetsflödena nedan gäller både PPT- och PPTX-presentationer. Exemplen använder båda formaten där deras filbaserade och strömbaserade beteende är viktigt.

## **Kryptera en presentation med ett öppningslösenord**

Använd [ProtectionManager.encrypt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#encrypt) för att tilldela ett öppningslösenord. Använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att spara den krypterade presentationen.

Följande exempel krypterar en PPTX-presentation:

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

## **Behåll dokumentegenskaper offentliga**

Som standard inkluderar Aspose.Slides dokumentegenskaper i presentationskryptering. Metoden [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) styr detta beteende oberoende av bildinnehållets kryptering. Skicka `False` innan du anropar [ProtectionManager.encrypt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#encrypt) när ett indexerings-, klassificerings-, sök- eller dokumenthanteringssystem måste läsa metadata utan öppningslösenordet.

Följande exempel skapar en krypterad PPTX-presentation samtidigt som dess inbyggda dokumentegenskaper förblir offentliga:

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

Att skicka `False` till [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) gör inte bilder, masterbilder, layouter, former, media eller annat presentationsinnehåll offentligt. Det påverkar endast dokumentegenskaper. För att läsa dessa egenskaper utan att läsa in det krypterade innehållet, se [Hantera presentationsegenskaper](/slides/sv/python-java/presentation-properties/).

## **Läs in en krypterad presentation**

Ställ in [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setPassword) till öppningslösenordet och skicka alternativen till [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) när filen läses in. Inläsning misslyckas när ett öppningslösenord krävs men det angivna lösenordet saknas eller är felaktigt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Arbeta med den dekrypterade presentationen.
    pass
finally:
    presentation.dispose()
```

## **Ta bort kryptering från en presentation**

Läs in presentationen med dess öppningslösenord, anropa [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#removeEncryption) och spara resultatet. Den sparade presentationen kan sedan läsas in utan lösenord.

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

## **Validera ett öppningslösenord innan inläsning**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) för att hämta [PresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/) utan att skapa en fullständig presentationsinstans. Kontrollera [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#isPasswordProtected) innan du begär eller validerar ett lösenord. När skydd finns, validera det angivna värdet med [PresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Filvägsarbetsflöde**

Följande exempel validerar ett öppningslösenord för en PPTX-fil, skickar det validerade värdet till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setPassword) och läser sedan in den kompletta presentationen:

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

### **Strömarbetsflöde**

Strömöverlagringen av [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ger samma arbetsflöde. Återställ positionen för en sökbar ström innan du läser in den kompletta presentationen från den strömmen.

Följande exempel använder en PPT-fil:

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

### **checkPassword returrvärden**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#checkPassword) returnerar `True` endast när presentationen har ett öppningslösenord och det angivna lösenordet är korrekt. Det returnerar `False` i var och en av följande fall:

- Lösenordet är felaktigt.
- Presentationen har inget öppningslösenord.
- Det angivna lösenordet är `None` eller tomt.

Beteendet är detsamma för PPT- och PPTX-presentationer.

## **Kontrollera om en inläst presentation är krypterad**

Efter att ha läst in en presentation med rätt lösenord, inspektera [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isEncrypted) för att bekräfta att källpresentationen var krypterad. För att upptäcka öppningslösenordsskydd innan inläsning, använd [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#isPasswordProtected) som visas ovan.

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

## **Säkerhetsrekommendationer**

{{% alert color="warning" title="Säkerhet" %}}
Logga inte öppningslösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga upprepade valideringsförsök, håll lösenord i minnet endast så länge som behövs, och återanvänd ett lyckat valideringsresultat när presentationen laddas omedelbart.

Offentliga dokumentegenskaper kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden även om presentationsinnehållet är krypterat. Kryptera känslig metadata tillsammans med presentationen. Att lämna egenskaper offentliga bör vara ett explicit beslut som endast tas när system måste indexera, klassificera, söka eller hantera filen utan ett öppningslösenord.
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Öppna applikationen [Aspose.Slides Lock](https://products.aspose.app/slides/sv/lock).
1. Välj eller ladda upp presentationen.
1. Ange ett lösenord för visningsskydd.
1. Ange eventuellt ett separat lösenord för redigeringsskydd.
1. Applicera skyddet och ladda ner den resulterande filen.

{{% alert color="info" title="Se också" %}}
- [Skrivskydda presentationer](/slides/sv/python-java/write-protected-presentation/)
- [Digital signatur i PowerPoint](/slides/sv/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**What is the difference between an opening password and a write-protection password?**

Ett öppningslösenord krypterar presentationen och krävs för att läsa in dess innehåll. Ett skrivskyddslösenord begränsar modifiering utan att kryptera innehållet.

**Can I validate an opening password without loading all slides?**

Ja. Hämta presentationsinformation, kontrollera om öppningslösenordsskydd finns, och validera lösenordet innan en fullständig presentationsinstans skapas.

**Can an application read metadata without the opening password?**

Ja, men endast när presentationen krypterades med dokumentegenskapsskydd inaktiverat. Applikationen måste då använda lägläget för enbart dokumentegenskaper som beskrivs i [Hantera presentationsegenskaper](/slides/sv/python-java/presentation-properties/).

**Do the password-checking workflows support both PPT and PPTX?**

Ja. Filvägs- och ström‑baserad lösenorddetektering och -validering fungerar likadant för PPT- och PPTX-presentationer.