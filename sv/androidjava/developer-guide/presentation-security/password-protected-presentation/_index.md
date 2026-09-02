---
title: Säkra presentationer med lösenord på Android
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/androidjava/password-protected-presentation/
keywords:
- låsa PowerPoint
- låsa presentation
- låsa upp PowerPoint
- låsa upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägga till lösenord
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
- Android
- Java
- Aspose.Slides
description: "Lås och lås upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java utan ansträngning. Säkra dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation betyder det att du anger ett lösenord som inför vissa begränsningar på presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation betraktas som en låst presentation.

Vanligtvis kan du ange ett lösenord för att verkställa dessa begränsningar på en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska kunna modifiera din presentation kan du ange en modifieringsbegränsning. Begränsningen förhindrar personer från att modifiera, ändra eller kopiera saker i din presentation (såvida de inte anger lösenordet). 

  Dock, i detta fall, kan en användare även utan lösenord komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren se innehållet eller saker—hyperlänkar, animationer, effekter och annat—inuti din presentation, men de kan inte kopiera objekt eller spara presentationen. 

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ange en öppningsbegränsning. Begränsningen hindrar personer från att ens se innehållet i din presentation (såvida de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsbegränsningen även att användare kan modifiera dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den. 
  
  **Obs!** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stöder lösenordsskydd, kryptering och liknande operationer för presentationer i följande format: 

- PPTX och PPT – Microsoft PowerPoint-presentation 
- ODP – OpenDocument-presentation 
- OTP – OpenDocument-presentationmall 

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra ändringar på följande sätt:

- Kryptering av en presentation
- Ställa in skrivskydd för en presentation

**Andra operationer**

Aspose.Slides låter dig utföra andra uppgifter som involverar lösenordsskydd och kryptering på följande sätt:

- Dekryptering av en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet. 

För att kryptera eller lösenordsskydda en presentation måste du använda encrypt‑metoden (från [IProtectionManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen.

Denna exempel­kod visar hur du krypterar en presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ställ in skrivskydd för en presentation**

Du kan lägga till en markering med texten “Do not modify” på en presentation. På så sätt kan du tala om för användarna att du inte vill att de ska göra ändringar i presentationen.  

**Obs!** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare — om de faktiskt vill — modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn. 

För att ställa in skrivskydd måste du använda metoden [setWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Denna exempel­kod visar hur du ställer in skrivskydd för en presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Läs in en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) utan parametrar. Därefter måste du ange rätt lösenord för att läsa in presentationen.

Denna exempel­kod visar hur du dekrypterar en presentation: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // arbete med dekrypterad presentation
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ta bort kryptering från en presentation**

Du kan ta bort kryptering eller lösenordsskydd på en presentation. På så sätt kan användare komma åt eller modifiera presentationen utan begränsningar. 

För att ta bort kryptering eller lösenordsskydd måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Denna exempel­kod visar hur du tar bort kryptering från en presentation:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet som används på en presentationsfil. På så sätt kan användare modifiera som de vill — och de får inga varningar när de utför sådana uppgifter.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [removeWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Denna exempel­kod visar hur du tar bort skrivskyddet från en presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt dess egenskaper.

**Obs!** Som standard krypterar Aspose.Slides dokumentegenskaperna för en presentation när den krypteras. Om du behöver göra dokumentegenskaperna åtkomliga även efter kryptering, låter Aspose.Slides dig göra exakt det.

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en krypterad presentation, skicka `false` till [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Denna exempel­kod visar hur du krypterar en presentation samtidigt som du ger användare åtkomst till dess dokumentegenskaper:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att inspektera metadata för en krypterad presentation utan att läsa in dess bilder eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/)‑objekt och skicka `true` till [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). I detta läge ignorerar Aspose.Slides lösenordet och läser endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda och anpassade dokumentegenskaper via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Läs inbyggda dokumentegenskaper.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Läs anpassade dokumentegenskaper.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Detta arbetsflöde fungerar endast när dokumentegenskaperna lämnades okrypterade (offentliga) när presentationen krypterades. Om dokumentegenskaperna är krypterade orsakar att skicka `true` till `loadOptions.setOnlyLoadDocumentProperties` ett undantag eftersom lösenordet ignoreras i detta läge. För att komma åt krypterade dokumentegenskaper eller läsa in hela presentationen, inklusive dess bilder och annat innehåll, ange rätt lösenord via [ILoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kan du vilja kontrollera och bekräfta att presentationen inte har skyddats med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan dess lösenord.

Denna Java‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att läsa in själva presentationen):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [isEncrypted](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

Denna exempel­kod visar hur du kontrollerar om en presentation är krypterad:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda egenskapen [isWriteProtected](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är skrivskyddad.

Denna exempel­kod visar hur du kontrollerar om en presentation är skrivskyddad:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validera eller bekräfta att ett specifikt lösenord har använts**

Du kan vilja kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller verktyg för att validera ett lösenord. 

Denna exempel­kod visar hur du validerar ett lösenord:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // kontrollera om "pass" matchar
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returneras `false`. 

{{% alert color="primary" title="Se även" %}} 
- [Digital Signature in PowerPoint](/slides/sv/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stöder moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög datasäkerhetsnivå för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när du försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket meddelar dig att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när du arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten extra belastning vid öppning och sparande. I de flesta fall är denna prestandapåverkan minimal och påverkar inte avsevärt den totala behandlingstiden för dina presentationsuppgifter.