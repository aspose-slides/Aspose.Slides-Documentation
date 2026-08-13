---
title: Säkra presentationer med lösenord i .NET
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/net/password-protected-presentation/
keywords:
- lås PowerPoint
- lås presentation
- lås upp PowerPoint
- lås upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägg till lösenord
- kryptera PowerPoint
- kryptera presentation
- dekryptera PowerPoint
- dekryptera presentation
- skrivskydd
- PowerPoint-säkerhet
- presentationsäkerhet
- ta bort lösenord
- ta bort skydd
- ta bort kryptering
- inaktivera lösenord
- inaktivera skydd
- ta bort skrivskydd
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Säkra dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation innebär det att du anger ett lösenord som upprätthåller vissa begränsningar för presentationen. För att ta bort dessa begränsningar måste lösenordet anges. En lösenordsskyddad presentation anses vara en låst presentation.

Vanligtvis kan du ange ett lösenord för att upprätthålla dessa begränsningar på en presentation:

- **Modifiering**

Om du vill att endast vissa användare ska kunna modifiera din presentation kan du ange en modifieringsbegränsning. Denna begränsning hindrar personer från att modifiera, ändra eller kopiera element i din presentation om de inte anger lösenordet.  

Men även utan lösenordet kommer en användare fortfarande kunna komma åt och öppna ditt dokument. I detta skrivskyddade läge kan användaren se innehållet—inklusive hyperlänkar, animationer, effekter och andra element—i din presentation, men de kan inte kopiera objekt eller spara presentationen.

- **Öppning**

Om du vill att endast vissa användare ska kunna öppna din presentation kan du ange en öppningsbegränsning. Denna begränsning hindrar personer från att ens se innehållet i din presentation om de inte anger lösenordet.  

Tekniskt sett förhindrar öppningsbegränsningen även att användare modifierar dina presentationer—om personer inte kan öppna en presentation kan de inte modifiera eller göra förändringar i den.

**Obs:** När du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Lösenordsskydd i Aspose.Slides**

**Stödda format**

Aspose.Slides stöder lösenordsskydd, kryptering och liknande operationer för presentationer i dessa format:

- PPTX och PPT – Microsoft PowerPoint-presentationer
- ODP – OpenDocument-presentationer
- OTP – OpenDocument-presentationmallar

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra modifieringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd på en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra ytterligare uppgifter som involverar lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är lösenordsskyddad innan den läses in
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad

## **Skydda en presentation med ett lösenord**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet.

För att kryptera (eller lösenordsskydda) en presentation, använd `Encrypt`‑metoden från [ProtectionManager](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager) för att ange ett lösenord. Skicka lösenordet till `Encrypt`‑metoden och använd sedan `Save`‑metoden för att spara den nu krypterade presentationen.

Detta exempel visar hur du krypterar en presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Ställ in skrivskydd på en presentation** 

Du kan lägga till en märkning som säger ”Do not modify” i en presentation. Detta informerar användarna om att du inte vill att de gör ändringar i presentationen.

**Obs:** Skrivskyddsprocessen krypterar inte presentationen. Därför kan användare—om de vill—modifiera presentationen, men för att spara förändringarna måste de spara den under ett annat namn.

För att ställa in skrivskydd, använd `SetWriteProtection`‑metoden. Detta exempel visar hur du sätter skrivskydd på en presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Läs in en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad presentation genom att ange rätt lösenord. Detta exempel visar hur du läser in en krypterad presentation:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Arbeta med den dekrypterade presentationen.
}
```

## **Ta bort kryptering från en presentation**

Du kan ta bort kryptering eller lösenordsskydd från en presentation, så att användare kan komma åt eller modifiera den utan begränsningar.

För att ta bort kryptering eller lösenordsskydd, anropa metoden [RemoveEncryption](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/methods/removeencryption). Detta exempel visar hur du tar bort kryptering från en presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet från en presentationsfil. På så sätt kan användare modifiera den som de vill—och de kommer inte att få några varningar när de utför sådana åtgärder.

Du kan ta bort skrivskyddet genom att använda metoden [RemoveWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/methods/removewriteprotection). Detta exempel visar hur du tar bort skrivskyddet från en presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare problem med att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt dess egenskaper.

**Obs:** Som standard, när Aspose.Slides krypterar en presentation, är presentationens dokumentegenskaper också lösenordsskyddade. Om du behöver göra dokumentegenskaperna tillgängliga även efter kryptering, låter Aspose.Slides dig göra precis det.

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en krypterad presentation, sätt egenskapen `EncryptDocumentProperties` på [IProtectionManager](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/) till `false`. Detta exempel visar hur du krypterar en presentation samtidigt som du ger användarna åtkomst till dess dokumentegenskaper:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att inspektera metadata för en krypterad presentation utan att läsa in dess bilder eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/)-objekt och sätt [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) till `true`. I detta läge ignorerar Aspose.Slides lösenordet och läser endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda och anpassade dokumentegenskaper via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Detta arbetsflöde fungerar bara när dokumentegenskaperna lämnades okrypterade (publika) när presentationen krypterades. Om dokumentegenskaperna är krypterade, kommer inställning av `OnlyLoadDocumentProperties` till `true` att orsaka ett undantag eftersom lösenordet ignoreras i detta läge. För att komma åt krypterade dokumentegenskaper eller läsa in hela presentationen, inklusive dess bilder och annat innehåll, ange rätt `Password`‑värde i [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/).

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kan du vilja kontrollera att den inte är skyddad med ett lösenord. Detta hjälper dig undvika fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan rätt lösenord.

Denna C#‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad utan att faktiskt läsa in den:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [IsEncrypted](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/properties/isencrypted), som returnerar `true` om presentationen är krypterad eller `false` om den inte är det.

Detta exempel visar hur du kontrollerar om en presentation är krypterad:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda egenskapen [IsWriteProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/properties/iswriteprotected), som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är det.

Detta exempel visar hur du kontrollerar om en presentation är skrivskyddad:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifiera användning av presentationslösenord**

Du kan vilja kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides erbjuder möjlighet att validera ett lösenord.

Detta exempel visar hur du validerar ett lösenord:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Kontrollera om lösenordet matchar.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet; annars returneras `false`.

{{% alert color="info" title="Se också" %}} 
- [Digital Signature in PowerPoint](/slides/sv/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Gå till vår sida [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock). 
1. Klicka på **Drop or upload your files**.
1. Välj filen du vill lösenordsskydda på din dator. 
1. Ange ditt föredragna lösenord för redigeringsskydd och ditt föredragna lösenord för visningsskydd.
1. Om du vill att användare ska se din presentation som slutgiltig kopia, markera kryssrutan **Mark as final**.
1. Klicka på **PROTECT NOW.** 
1. Klicka på **DOWNLOAD NOW.**

![Lösenordsskydda PowerPoint-presentationer](slides-lock.png)

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stöder moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög datasäkerhetsnivå för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan introducera en liten extra belastning vid öppnings‑ och spara‑operationer. I de flesta fall är denna prestandapåverkan minimal och har ingen betydande inverkan på den totala bearbetningstiden för dina presentationsuppgifter.