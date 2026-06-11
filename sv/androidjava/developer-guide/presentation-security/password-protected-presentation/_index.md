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
description: "Lås och lås upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java på ett enkelt sätt. Skydda dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation betyder det att du anger ett lösenord som implementerar vissa begränsningar på presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation betraktas som en låst presentation.

Typiskt kan du ange ett lösenord för att verkställa dessa begränsningar på en presentation:

- **Modifiering**

  Om du bara vill att vissa användare ska kunna modifiera din presentation kan du ange en modifieringsbegränsning. Begränsningen förhindrar här att personer ändrar, modifierar eller kopierar saker i din presentation (såvida de inte anger lösenordet). 

  Dock, i det här fallet kan en användare, även utan lösenord, komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren visa innehållet eller saker — hyperlänkar, animationer, effekter och andra — i din presentation, men de kan inte kopiera objekt eller spara presentationen. 

- **Öppning**

  Om du bara vill att vissa användare ska kunna öppna din presentation kan du ange en öppningsbegränsning. Begränsningen förhindrar här att personer ens ser innehållet i din presentation (såvida de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsbegränsningen även att användare modifierar dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den. 

  **Obs** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stödjer lösenordsskydd, kryptering och liknande operationer för presentationer i följande format: 

- PPTX och PPT – Microsoft PowerPoint-presentation 
- ODP – OpenDocument-presentation 
- OTP – OpenDocument-presentationmall 

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra modifieringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd för en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter relaterade till lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet. 

För att kryptera eller lösenordsskydda en presentation måste du använda encrypt‑metoden (från [IProtectionManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen.

Den här exempel koden visar hur du krypterar en presentation:

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

Du kan lägga till en markering som säger ”Do not modify” i en presentation. På så sätt kan du informera användarna om att du inte vill att de gör ändringar i presentationen.  

**Obs** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare — om de faktiskt vill — modifiera presentationen, men för att spara ändringarna måste de skapa en ny presentation med ett annat namn. 

För att ställa in skrivskydd måste du använda [setWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) metoden. Den här exempel koden visar hur du sätter skrivskydd på en presentation:

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

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa [removeEncryption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) metoden utan parametrar. Du måste sedan ange rätt lösenord för att läsa in presentationen.

Den här exempel koden visar hur du dekrypterar en presentation: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // arbeta med dekrypterad presentation
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Ta bort kryptering från en presentation**

Du kan ta bort krypteringen eller lösenordsskyddet på en presentation. På så sätt kan användare komma åt eller modifiera presentationen utan begränsningar. 

För att ta bort kryptering eller lösenordsskydd måste du anropa [removeEncryption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) metoden. Den här exempel koden visar hur du tar bort kryptering från en presentation:

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

Du kan ta bort skrivskyddet från en presentation genom att använda [removeWriteProtection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) metoden. Den här exempel koden visar hur du tar bort skrivskyddet från en presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Hämta egenskaperna för en krypterad presentation**

Vanligtvis har användare problem med att få dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt egenskaperna för den presentationen.

**Obs** att när Aspose.Slides krypterar en presentation blir presentationens dokumentegenskaper också lösenordsskyddade som standard. Men om du behöver göra presentationens egenskaper åtkomliga (även efter att presentationen har krypterats) så låter Aspose.Slides dig göra just det. 

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en presentation du har krypterat kan du sätta egenskapen [encryptDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) till `true`. Den här exempel koden visar hur du krypterar en presentation samtidigt som du ger användarna möjlighet att komma åt dess dokumentegenskaper:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kan du vilja kontrollera och bekräfta att presentationen inte har skyddats med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan sitt lösenord.

Den här Java‑koden visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att själva presentationen läses in):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [isEncrypted](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

Den här exempel koden visar hur du kontrollerar om en presentation är krypterad:

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

Den här exempel koden visar hur du kontrollerar om en presentation är skrivskyddad:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validera eller bekräfta att ett specifikt lösenord har använts**

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller möjligheten att validera ett lösenord. 

Den här exempel koden visar hur du validerar ett lösenord:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // kontrollera om "pass" matchas med
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returnerar den `false`. 

{{% alert color="primary" title="Se även" %}} 
- [Digital signatur i PowerPoint](/slides/sv/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stödjer moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av datasäkerhet för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när du försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten extra belastning vid öppnings‑ och sparningsoperationer. I de flesta fall är denna prestandapåverkan minimal och påverkar inte avsevärt den totala behandlingstiden för dina presentationsuppgifter.