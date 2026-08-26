---
title: Skrivskydda presentationer på Android
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/androidjava/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd PowerPoint
- lösenord för att modifiera
- begränsa redigering av presentation
- ta bort skrivskydd
- validera modifieringslösenord
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för Android via Java."
---
## **Introduktion**

Ett skrivskyddspassord begränsar modifiering av en presentation men krypterar inte dess innehåll. Användare kan läsa in och visa en skrivskyddad presentation utan lösenordet. Beroende på program kan de även kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Password-Protect Presentations](/slides/sv/androidjava/password-protected-presentation/).

Arbetsflödena i denna artikel gäller både PPT‑ och PPTX‑presentationer. Exemplen använder PPTX‑filer; vid sparning till PPT, använd filändelsen `.ppt` och motsvarande PPT‑sparaformat.

## **Ställ in skrivskydd på en presentation**

Använd [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) för att tilldela ett lösenord för att modifiera en presentation. När presentationen sparas bevaras skyddsinställningen.

Följande exempel sätter skrivskydd på en PPTX‑presentation:

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

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när åtkomstbehörighet för att modifiera den skyddade presentationen ska valideras.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Skicka inte ett skrivskyddspassord till [ILoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Den metoden accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddspassordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) för att ta bort modifieringsrestriktionen och spara sedan presentationen.

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

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-instans, anropa [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) och undersök [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metoden använder [NullableBool](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/nullablebool/) och returnerar `NullableBool.True` när skrivskydd upptäcks.

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

Överlagringen för ström i [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ger samma information för en presentation som levereras som en ström.

## **Validera ett skrivskyddspassord**

Använd [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) för att validera ett modifieringslösenord utan att läsa in hela presentationen. Kontrollera först [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) så att applikationen bara begär eller validerar ett lösenord när skrivskydd finns.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) validerar endast skrivskyddspassordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, ger [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer bör du inte logga lösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge de behövs.

{{% alert color="info" title="Se även" %}}
- [Password-Protect Presentations](/slides/sv/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/sv/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar modifiering men lämnar presentationsinnehållet tillgängligt för läsning och visning.

**Krävs skrivskyddspassordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddspassord?**

Ja. Ange öppningslösenordet via inläsningsalternativen för att öppna den krypterade presentationen och validera skrivskyddspassordet separat när behörighet för modifiering krävs.