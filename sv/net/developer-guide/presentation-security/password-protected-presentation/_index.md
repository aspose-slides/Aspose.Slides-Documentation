---
title: Lösenordsskydda presentationer i .NET
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/net/password-protected-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Kryptera, upptäcka, validera, öppna och dekryptera lösenordsskyddade PowerPoint PPT- och PPTX-presentationer i C# med Aspose.Slides för .NET."
---
## **Översikt**

Ett öppningslösenord krypterar en presentation. Det korrekta lösenordet krävs för att läsa in och visa presentationsinnehållet, så detta skydd ger konfidentialitet.

Ett öppningslösenord skiljer sig från ett skrivskyddslösenord. Skrivskydd begränsar modifiering men krypterar inte innehållet eller förhindrar att presentationen läses in. För att hantera lösenord för att modifiera presentationer, se [Write-Protect Presentations](/slides/sv/net/write-protected-presentation/).

Arbetsflödena nedan gäller både PPT- och PPTX-presentationer. Exemplen använder båda formaten där deras filbaserade och strömbaserade beteende är viktigt.

## **Kryptera en presentation med ett öppningslösenord**

Använd [IProtectionManager.Encrypt](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/encrypt/) för att tilldela ett öppningslösenord. Använd sedan [IPresentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/) för att spara den krypterade presentationen.

Följande exempel krypterar en PPTX-presentation:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Behåll dokumentegenskaper offentliga**

Som standard inkluderar Aspose.Slides dokumentegenskaper i presentationskrypteringen. Egenskapen [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) styr detta beteende oberoende av bildinnehållets kryptering. Sätt den till `false` innan du anropar [IProtectionManager.Encrypt](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/encrypt/) när ett indexerings-, klassificerings-, sök- eller dokumenthanteringssystem måste läsa metadata utan öppningslösenordet.

Följande exempel skapar en krypterad PPTX-presentation samtidigt som dess inbyggda dokumentegenskaper förblir offentliga:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Att sätta `EncryptDocumentProperties` till `false` gör inte bilder, masterbilder, layouter, former, media eller annat presentationsinnehåll offentligt. Det påverkar endast dokumentegenskaper. För att läsa dessa egenskaper utan att läsa in det krypterade innehållet, se [Manage Presentation Properties](/slides/sv/net/presentation-properties/).

## **Läs in en krypterad presentation**

Ange [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/) till öppningslösenordet och skicka alternativen till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) när filen läses in. Inläsning misslyckas när ett öppningslösenord krävs men det angivna lösenordet saknas eller är felaktigt.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Arbeta med den dekrypterade presentationen.
```

## **Ta bort kryptering från en presentation**

Läs in presentationen med dess öppningslösenord, anropa [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/removeencryption/), och spara resultatet. Den sparade presentationen kan sedan läsas in utan lösenord.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Validera ett öppningslösenord innan inläsning**

Använd [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationfactory/getpresentationinfo/) för att få [IPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/) utan att skapa en fullständig presentationsinstans. Kontrollera [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/ispasswordprotected/) innan du begär eller validerar ett lösenord. När skydd finns, validera det angivna värdet med [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Arbetsflöde för filsökväg**

Följande exempel validerar ett öppningslösenord för en PPTX-fil, skickar det validerade värdet till [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/), och läser sedan in den kompletta presentationen:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Ström‑arbetsflöde**

Ström‑överladdningen av [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationfactory/getpresentationinfo/) ger samma arbetsflöde. Återställ positionen för en sökbar ström innan du läser in den kompletta presentationen från den strömmen.

Följande exempel använder en PPT-fil:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Returnvärden för CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/checkpassword/) returnerar `true` endast när presentationen har ett öppningslösenord och det angivna lösenordet är korrekt. Den returnerar `false` i var och en av följande fall:

- Lösenordet är felaktigt.
- Presentationen har inget öppningslösenord.
- Det angivna lösenordet är `null` eller tomt.

Beteendet är detsamma för PPT- och PPTX-presentationer.

## **Kontrollera om en inläst presentation är krypterad**

Efter att ha läst in en presentation med korrekt lösenord, inspektera [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/isencrypted/) för att bekräfta att källpresentationen var krypterad. För att upptäcka öppningslösenordsskydd innan inläsning, använd `IPresentationInfo.IsPasswordProtected` som visat ovan.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Säkerhetsrekommendationer**

{{% alert color="warning" title="Security" %}}
Logga inte öppningslösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga upprepade valideringsförsök, behåll lösenord i minnet endast så länge som de behövs, och återanvänd ett lyckat valideringsresultat när presentationen laddas omedelbart.

Offentliga dokumentegenskaper kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden även om presentationsinnehållet är krypterat. Kryptera känslig metadata tillsammans med presentationen. Att lämna egenskaper offentliga bör vara ett explicit beslut som endast fattas när system måste indexera, klassificera, söka eller hantera filen utan ett öppningslösenord.
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Öppna applikationen [Aspose.Slides Lock](https://products.aspose.app/slides/sv/lock).
2. Välj eller ladda upp presentationen.
3. Ange ett lösenord för visningsskydd.
4. Ange eventuellt ett separat lösenord för redigeringsskydd.
5. Verkställ skyddet och ladda ner den resulterande filen.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/sv/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/sv/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan ett öppningslösenord och ett skrivskyddslösenord?**

Ett öppningslösenord krypterar presentationen och krävs för att läsa in dess innehåll. Ett skrivskyddslösenord begränsar modifiering utan att kryptera innehållet.

**Kan jag validera ett öppningslösenord utan att läsa in alla bilder?**

Ja. Hämta presentationsinformation, kontrollera om öppningslösenordsskydd finns och validera lösenordet innan en komplett presentationsinstans skapas.

**Kan en applikation läsa metadata utan öppningslösenordet?**

Ja, men endast när presentationen krypterades med `EncryptDocumentProperties` satt till `false`. Applikationen måste då använda laddningsläget som bara läser dokumentegenskaper, beskrivet i [Manage Presentation Properties](/slides/sv/net/presentation-properties/).

**Stöder lösenordskontrollarbetsflödena både PPT och PPTX?**

Ja. Filvägs- och strömbaserade lösenordsdetektering och -validering fungerar på samma sätt för PPT- och PPTX-presentationer.