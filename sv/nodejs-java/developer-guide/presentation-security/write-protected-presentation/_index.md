---
title: Skrivskydda presentationer i JavaScript
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/nodejs-java/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd PowerPoint
- lösenord för att ändra
- begränsa redigering av presentation
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

Ett lösenord för skrivskydd begränsar ändring av en presentation men krypterar inte dess innehåll. Användare kan ladda och visa en skrivskyddad presentation utan lösenordet. Beroende på programmet kan de också kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Lösenordsskydda presentationer](/slides/sv/nodejs-java/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT- och PPTX-presentationer. Exemplen använder PPTX-filer; när du sparar till PPT, använd filändelsen `.ppt` och motsvarande PPT-sparformat.

## **Ställ in skrivskydd på en presentation**

Använd [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) för att tilldela ett lösenord för att ändra en presentation. Att spara presentationen bevarar skyddsinställningen.

Följande exempel sätter skrivskydd på en PPTX-presentation:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ladda en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att ladda presentationen. Lösenordet är bara relevant när auktorisation för att ändra den skyddade presentationen ska valideras.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Skicka inte ett skrivskyddslösenord till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword). Den metoden accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att ladda den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) för att ta bort ändringsrestriktionen, spara sedan presentationen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrollera om en presentation är skrivskyddad**

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans, anropa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) och granska [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Metoden använder [NullableBool](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/nullablebool/) och returnerar `NullableBool.True` när skrivskydd upptäcks.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Den ström‑baserade metoden [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) ger samma information för en presentation som levereras som en Node.js‑läsström.

## **Validera ett skrivskyddslösenord**

Använd [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) för att validera ett ändringslösenord utan att ladda den kompletta presentationen. Kontrollera först [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) validerar endast skrivskyddslösenordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [PresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#checkPassword) endast ett öppningslösenord. Om en komplett presentation redan har laddats in, tillhandahåller [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer ska du inte logga lösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet bara så länge de behövs.

{{% alert color="info" title="Se även" %}}
- [Lösenordsskydda presentationer](/slides/sv/nodejs-java/password-protected-presentation/)
- [Endast läsbara presentationer](/slides/sv/nodejs-java/read-only-presentation/)
- [Digital signatur i PowerPoint](/slides/sv/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Vanliga frågor**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändring men lämnar presentationsinnehållet tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via laddningsalternativen för att öppna den krypterade presentationen, och validera skrivskyddslösenordet separat när ändringsauktorisation krävs.