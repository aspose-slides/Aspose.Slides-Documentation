---
title: Skrivskydda presentationer i Java
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/java/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd PowerPoint
- lösenord för att ändra
- begränsa redigering av presentation
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för Java."
---
## **Introduktion**

Ett skrivskyddslösenord begränsar ändring av en presentation men krypterar inte dess innehåll. Användare kan läsa in och visa en skrivskyddad presentation utan lösenordet. Beroende på applikationen kan de även kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Password-Protect Presentations](/slides/sv/java/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT- och PPTX-presentationer. Exemplen använder PPTX-filer; när du sparar till PPT, använd filändelsen `.ppt` och motsvarande PPT-sparformat.

## **Ställ in skrivskydd på en presentation**

Använd [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) för att tilldela ett lösenord för att ändra en presentation. Att spara presentationen behåller skyddsinställningen.

Följande exempel sätter skrivskydd på en PPTX-presentation:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Läs in en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när man validerar behörighet att ändra den skyddade presentationen.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Skicka inte ett skrivskyddslösenord till [ILoadOptions.setPassword](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Den metoden accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) för att ta bort ändringsrestriktionen, och spara sedan presentationen.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrollera om en presentation är skrivskyddad**

För att undersöka en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)-instans, anropa [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) och inspektera [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metoden använder [NullableBool](https://reference.aspose.com/slides/sv/java/com.aspose.slides/nullablebool/) och returnerar `NullableBool.True` när skrivskydd upptäcks.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Ström‑överladdningen av [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ger samma information för en presentation som tillhandahålls som en ström.

## **Validera ett skrivskyddslösenord**

Använd [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) för att validera ett ändringslösenord utan att läsa in hela presentationen. Kontrollera först [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) validerar endast skrivskyddslösenordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, ger [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) den motsvarande skrivskyddskontrollen via sin skydds‑hanterare.

I produktionsapplikationer bör du inte logga lösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge de behövs.

{{% alert color="info" title="Se även" %}}
- [Password-Protect Presentations](/slides/sv/java/password-protected-presentation/)
- [Read-Only Presentations](/slides/sv/java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändring men lämnar presentationsinnehållet tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via inläsningsalternativen för att öppna den krypterade presentationen, och validera skrivskyddslösenordet separat när behörighet för ändring krävs.