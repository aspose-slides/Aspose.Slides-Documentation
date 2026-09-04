---
title: Lösenordsskydda presentationer i JavaScript
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/nodejs-java/password-protected-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kryptera, upptäcka, validera, öppna och dekryptera lösenordsskyddade PowerPoint PPT- och PPTX-presentationer i JavaScript med Aspose.Slides."
---
## **Översikt**

Ett öppningslösenord krypterar en presentation. Det korrekta lösenordet krävs för att läsa in och visa presentationsinnehållet, så detta skydd ger konfidentialitet.

Ett öppningslösenord skiljer sig från ett skrivskyddslösenord. Skrivskydd begränsar ändringar men krypterar inte innehållet eller hindrar presentationen från att läsas in. För att hantera lösenord för att ändra presentationer, se [Write-Protect Presentations](/slides/sv/nodejs-java/write-protected-presentation/).

Arbetsflödena nedan gäller för både PPT- och PPTX-presentationer. Exemplen använder båda formaten när deras filbaserade och strömbaserade beteende är viktigt.

## **Kryptera en presentation med ett öppningslösenord**

Använd [ProtectionManager.encrypt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#encrypt) för att tilldela ett öppningslösenord. Använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) för att spara den krypterade presentationen.

Följande exempel krypterar en PPTX-presentation:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Behåll dokumentegenskaper offentliga**

Som standard inkluderar Aspose.Slides dokumentegenskaper i presentationskryptering. Metoden [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) styr detta beteende oberoende av bildinnehållskryptering. Skicka `false` innan du anropar [ProtectionManager.encrypt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#encrypt) när ett indexerings-, klassificerings-, sök- eller dokumenthanteringssystem måste läsa metadata utan öppningslösenordet.

Följande exempel skapar en krypterad PPTX-presentation samtidigt som dess inbyggda dokumentegenskaper förblir offentliga:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att skicka `false` till [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) gör inte bilder, masterbilder, layouter, former, media eller annat presentationsinnehåll offentligt. Det påverkar endast dokumentegenskaper. För att läsa dessa egenskaper utan att läsa in det krypterade innehållet, se [Manage Presentation Properties](/slides/sv/nodejs-java/presentation-properties/).

## **Läs in en krypterad presentation**

Ställ in [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword) till öppningslösenordet och skicka alternativen till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) när filen läses in. Inläsning misslyckas när ett öppningslösenord krävs men det angivna lösenordet saknas eller är felaktigt.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Arbeta med den dekrypterade presentationen.
} finally {
    presentation.dispose();
}
```

## **Ta bort kryptering från en presentation**

Läs in presentationen med dess öppningslösenord, anropa [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#removeEncryption), och spara resultatet. Den sparade presentationen kan sedan läsas in utan lösenord.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validera ett öppningslösenord innan inläsning**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) för att hämta [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/) utan att skapa en fullständig presentationsinstans. Kontrollera [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) innan du begär eller validerar ett lösenord. När skydd finns, validera det angivna värdet med [PresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Filvägsarbetsflöde**

Följande exempel validerar ett öppningslösenord för en PPTX-fil, skickar det validerade värdet till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword), och läser sedan in den kompletta presentationen:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Strömarbetsflöde**

Använd [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) för att inspektera en läsbar Node.js-ström. Efter att inspektionsströmmen har förbrukats, skapa en ny ström innan du läser in den kompletta presentationen med [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Följande exempel använder en PPT-fil:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword returnvärden**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#checkPassword) returnerar `true` endast när presentationen har ett öppningslösenord och det angivna lösenordet är korrekt. Det returnerar `false` i varje av följande fall:

- Lösenordet är felaktigt.
- Presentationen har inget öppningslösenord.
- Det angivna lösenordet är `null` eller tomt.

Beteendet är detsamma för PPT- och PPTX-presentationer.

## **Kontrollera om en inläst presentation är krypterad**

Efter att ha läst in en presentation med rätt lösenord, inspektera [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) för att bekräfta att källpresentationen var krypterad. För att upptäcka öppningslösenordsskydd innan inläsning, använd [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) som visat ovan.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Säkerhetsrekommendationer**

{{% alert color="warning" title="Security" %}}
Logga inte öppningslösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga upprepade valideringsförsök, håll lösenord i minnet bara så länge som behövs, och återanvänd ett lyckat valideringsresultat när presentationen laddas omedelbart.

Offentliga dokumentegenskaper kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden även om presentationsinnehållet är krypterat. Kryptera känslig metadata tillsammans med presentationen. Att lämna egenskaper offentliga bör vara ett explicit beslut som endast tas när system måste indexera, klassificera, söka eller hantera filen utan ett öppningslösenord.
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Öppna applikationen [Aspose.Slides Lock](https://products.aspose.app/slides/sv/lock).
1. Välj eller ladda upp presentationen.
1. Ange ett lösenord för visningsskydd.
1. Ange eventuellt ett separat lösenord för redigeringsskydd.
1. Tillåt skyddet och ladda ner den resulterande filen.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/sv/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett öppningslösenord och ett skrivskyddslösenord?**

Ett öppningslösenord krypterar presentationen och krävs för att läsa in dess innehåll. Ett skrivskyddslösenord begränsar ändringar utan att kryptera innehållet.

**Kan jag validera ett öppningslösenord utan att läsa in alla bilder?**

Ja. Hämta presentationsinformation, kontrollera om öppningslösenordsskydd finns och validera lösenordet innan du skapar en komplett presentationsinstans.

**Kan en applikation läsa metadata utan öppningslösenordet?**

Ja, men bara när presentationen krypterades med dokumentegenskapskryptering inaktiverad. Applikationen måste då använda laddningsläget som endast läser dokumentegenskaper, beskrivna i [Manage Presentation Properties](/slides/sv/nodejs-java/presentation-properties/).

**Stöder lösenordskontrollarbetsflöden både PPT och PPTX?**

Ja. Filvägs- och strömbaserad lösenorddetektering och -validering beter sig lika för PPT- och PPTX-presentationer.