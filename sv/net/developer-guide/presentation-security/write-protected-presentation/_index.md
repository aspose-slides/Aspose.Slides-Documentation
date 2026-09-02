---
title: Skrivskydda presentationer i .NET
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/net/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd för PowerPoint
- lösenord för att ändra
- begränsa presentationens redigering
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för .NET."
---
## **Introduktion**

Ett skrivskyddslösenord begränsar ändring av en presentation men krypterar inte innehållet. Användare kan ladda och visa en skrivskyddad presentation utan lösenordet. Beroende på applikationen kan de också kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att ladda dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Password-Protect Presentations](/slides/sv/net/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT‑ och PPTX‑presentationer. Exemplen använder PPTX‑filer; när du sparar till PPT, använd filändelsen `.ppt` och motsvarande PPT‑sparformat.

## **Ställ in skrivskydd på en presentation**

Använd [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/setwriteprotection/) för att tilldela ett lösenord för att ändra en presentation. När presentationen sparas bibehålls skyddsinställningen.

Följande exempel anger skrivskydd på en PPTX‑presentation:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Läs in en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när man validerar behörighet att ändra den skyddade presentationen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Skicka inte ett skrivskyddslösenord till [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/). Den egenskapen accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/removewriteprotection/) för att ta bort begränsningen för ändring och spara sedan presentationen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Kontrollera om en presentation är skrivskyddad**

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans, anropa [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationfactory/getpresentationinfo/) och kontrollera [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/iswriteprotected/). Egenskapen använder [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/) och returnerar `NullableBool.True` när skrivskydd upptäcks.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Ström‑överladdningen av [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationfactory/getpresentationinfo/) ger samma information för en presentation som levereras som en ström.

## **Validera ett skrivskyddslösenord**

Använd [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/checkwriteprotection/) för att validera ett ändringslösenord utan att läsa in hela presentationen. Kontrollera först [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/iswriteprotected/) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/checkwriteprotection/) validerar endast skrivskyddslösenordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/checkpassword/) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, ger [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/checkwriteprotection/) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer bör du inte logga lösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge som behövs.

{{% alert color="info" title="Se även" %}}
- [Password-Protect Presentations](/slides/sv/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/sv/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändring men lämnar presentationsinnehållet tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att läsa in krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via läsalternativen för att öppna den krypterade presentationen och validera skrivskyddslösenordet separat när ändringsbehörighet krävs.