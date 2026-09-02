---
title: Säkra presentationer med lösenord i .NET
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/net/password-protected-presentation/
keywords:
- lås PowerPoint
- lås presentation
- låsa upp PowerPoint
- låsa upp presentation
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
- presentationssäkerhet
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
description: "Lär dig hur du enkelt kan låsa och låsa upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Säkra dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation innebär det att du ställer in ett lösenord som tillämpar vissa begränsningar på presentationen. För att ta bort dessa begränsningar måste lösenordet anges. En lösenordsskyddad presentation betraktas som en låst presentation.

Vanligtvis kan du ställa in ett lösenord för att upprätthålla dessa begränsningar på en presentation:

- **Modifiering**

Om du vill att endast vissa användare ska kunna ändra din presentation kan du sätta en modifieringsbegränsning. Denna begränsning hindrar personer från att modifiera, förändra eller kopiera element i din presentation om de inte anger lösenordet.  

Men även utan lösenordet kommer en användare ändå att kunna öppna och komma åt ditt dokument. I detta skrivskyddade läge kan användaren visa innehållet—inklusive hyperlänkar, animationer, effekter och andra element—i presentationen, men de kan inte kopiera objekt eller spara presentationen.

- **Öppning**

Om du vill att endast vissa användare ska kunna öppna din presentation kan du sätta en öppningsbegränsning. Denna begränsning hindrar personer från ens att se innehållet i din presentation om de inte anger lösenordet.  

Tekniskt sett förhindrar öppningsbegränsningen även att användare kan ändra dina presentationer—om någon inte kan öppna en presentation kan de inte modifiera eller göra förändringar i den.

**Observera:** När du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Lösenordsskydd i Aspose.Slides**

**Stödda format**

Aspose.Slides stödjer lösenordsskydd, kryptering och liknande operationer för presentationer i dessa format:

- PPTX och PPT – Microsoft PowerPoint-presentationer
- ODP – OpenDocument-presentationer
- OTP – OpenDocument-presentationsmallar

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra ändringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd på en presentation

**Andra operationer**

Aspose.Slides låter dig utföra ytterligare uppgifter som involverar lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är lösenordsskyddad innan den laddas
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad

## **Skydda en presentation med ett lösenord**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet.

För att kryptera (eller lösenordsskydda) en presentation, använd `Encrypt`‑metoden från [ProtectionManager](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager) för att ange ett lösenord. Skicka lösenordet till `Encrypt`‑metoden och använd sedan `Save`‑metoden för att spara den nu krypterade presentationen.

Detta exempel visar hur du krypterar en presentation:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Ställ in skrivskydd på en presentation** 

Du kan lägga till en markering med texten "Do not modify" i en presentation. Detta informerar användarna om att du inte vill att de ska göra ändringar i presentationen.

**Observera:** Skrivskyddsprocessen krypterar inte presentationen. Därför kan användare—om de så önskar—modifiera presentationen, men för att spara ändringarna måste de spara den under ett annat namn.

För att ställa in skrivskydd, använd `SetWriteProtection`‑metoden. Detta exempel visar hur du ställer in skrivskydd på en presentation:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Läs in en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad presentation genom att ange rätt lösenord. Detta exempel visar hur du läser in en krypterad presentation:

```c#
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
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet från en presentationsfil. På så sätt kan användare modifiera den som de vill—och de får inga varningar när de utför sådana åtgärder.

Du kan ta bort skrivskyddet genom att använda metoden [RemoveWriteProtection](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/methods/removewriteprotection). Detta exempel visar hur du tar bort skrivskyddet från en presentation:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare problem med att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som gör att du kan lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt dess egenskaper.

**Observera:** Som standard krypterar Aspose.Slides en presentation och presentationens dokumentegenskaper skyddas också med lösenord. Om du behöver göra dokumentegenskaperna tillgängliga även efter kryptering, låter Aspose.Slides dig göra exakt det.

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en krypterad presentation, sätt egenskapen `EncryptDocumentProperties` på [IProtectionManager](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/) till `false`. Detta exempel visar hur du krypterar en presentation samtidigt som du ger användare åtkomst till dess dokumentegenskaper:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att inspektera metadata för en krypterad presentation utan att läsa in dess bilder eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/)-objekt och sätt [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) till `true`. I detta läge ignorerar Aspose.Slides lösenordet och läser endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda och anpassade dokumentegenskaper via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/documentproperties/):

```c#
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

Detta arbetsflöde fungerar endast när dokumentegenskaperna lämnades okrypterade (publika) när presentationen krypterades. Om dokumentegenskaperna är krypterade, orsakar inställning av `OnlyLoadDocumentProperties` till `true` ett undantag eftersom lösenordet ignoreras i detta läge. För att komma åt krypterade dokumentegenskaper eller läsa in hela presentationen, inklusive dess bilder och annat innehåll, ange rätt `Password`‑värde i [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/).

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kan du vilja kontrollera att den inte har skyddats med ett lösenord. Detta hjälper dig att undvika fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan rätt lösenord.

Denna C#‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad utan att faktiskt läsa in den:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [IsEncrypted](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/properties/isencrypted), som returnerar `true` om presentationen är krypterad eller `false` om den inte är det.

Detta exempel visar hur du kontrollerar om en presentation är krypterad:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda egenskapen [IsWriteProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/properties/iswriteprotected), som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är det.

Detta exempel visar hur du kontrollerar om en presentation är skrivskyddad:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifiera användning av presentationslösenord**

Du kan vilja kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides erbjuder möjligheten att validera ett lösenord.

Detta exempel visar hur du validerar ett lösenord:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Kontrollera om lösenordet matchar.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet; annars returnerar den `false`.

{{% alert color="primary" title="Se också" %}} 
- [Digital signatur i PowerPoint](/slides/sv/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Gå till vår [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock) sida. 
2. Klicka på **Drop or upload your files**. 
3. Välj den fil du vill lösenordsskydda på din dator. 
4. Ange ditt föredragna lösenord för redigeringsskydd och ditt föredragna lösenord för visningsskydd. 
5. Om du vill att användare ska se din presentation som den slutliga kopian, kryssa i kryssrutan **Mark as final**. 
6. Klicka på **PROTECT NOW.** 
7. Klicka på **DOWNLOAD NOW.**

![Lösenordsskydda PowerPoint-presentationer](slides-lock.png)

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stödjer moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av datasäkerhet för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när du arbetar med lösenordsskyddade presentationer?**

Krypterings- och dekrypteringsprocessen kan medföra en liten overhead under öppnings‑ och sparningsoperationer. I de flesta fall är denna prestandapåverkan minimal och påverkar inte avsevärt den totala bearbetningstiden för dina presentationsuppgifter.