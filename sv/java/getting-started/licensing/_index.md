---
title: Licensiering
type: docs
weight: 90
url: /sv/java/licensing/
keywords:
- licens
- tillfällig licens
- ange licens
- använd licens
- validera licens
- licensfil
- utvärderingsversion
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för Java. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett vattenstämpel för utvärdering när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Den här artikeln förklarar hur licensiering fungerar i Aspose.Slides och hur man tillämpar en licens innan man använder biblioteket. En licens kan laddas från en fil, ström eller inbäddad resurs med hjälp av `License`-klassen. Artikeln visar också hur man validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="primary" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Java** från dess [nedladdningssida](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Utvärderingsversionen erbjuder samma funktioner som den licensierade produktversionen. Utvärderingspaketet är samma som det köpta paketet. Utvärderingsversionen blir helt enkelt licenserad när du lägger till några kodrader (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose:s försäljningsteam.

Varje Aspose-licens kommer med ett års prenumeration för gratis uppgraderingar till nya versioner eller korrigeringar som släpps under prenumerationsperioden. Användare med licensierade produkter (eller även utvärderingsversioner) får gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar för utvärderingsversion**

* Även om Aspose.Slides utvärderingsversion (utan en specificerad licens) erbjuder full produktfunktionalitet, infogar den ett utvärderingsvattenstämpel högst upp i dokumentet vid öppning och sparning. 
* Du är begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30-dagars tillfällig licens**. Se sidan [How to get a Temporary License](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du har köpt en licens och lagt till ett par kodrader (för att tillämpa licensen).
* Licensen är en vanlig text‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationens utgångsdatum osv.
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även ett oavsiktligt extra radbrytning i filens innehåll gör den ogiltig.
* Aspose.Slides for Java söker vanligtvis efter licensen på följande platser:
  * En explicit sökväg
  * Mappen som innehåller Aspose.Slides.jar
* För att undvika begränsningarna i samband med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange licensen en gång per applikation eller process.

{{% alert color="primary" %}} 

Du kanske vill se [Metered Licensing](/slides/sv/java/metered-licensing/).

{{% /alert %}} 


## **Tillämpa en licens**

En licens kan laddas från en **fil** eller **ström**.

{{% alert color="primary" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License) för licensoperationer.

{{% /alert %}} 

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Det enklaste sättet att ange en licens är att placera licensfilen i mappen som innehåller Aspose.Slides.jar eller din applikations jar.

Denna Java‑kod visar hur du anger en licensfil:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Anger licensfilens sökväg
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog, när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License#setLicense-java.lang.String-) måste licensfilens namn i slutet av den specificerade sökvägen vara detsamma som din licensfil.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.Java.lic.xml*. Då måste du i din kod skicka sökvägen till filen (som slutar med *Aspose.Slides.Java.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Ström**

Du kan ladda en licens från en ström. Denna Java‑kod visar hur du tillämpar en licens från en ström:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Anger licensen via en ström
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Om du använder Aspose.Slides för PHP via Java kan du ange en licens via en PHP/Java‑bro. Denna bro låter dig använda Java‑klasser i PHP‑syntax. För mer information, se [License in PHP](/slides/sv/php-java/licensing/).

## **Validera en licens**

För att kontrollera om en licens har angetts korrekt kan du validera den. Denna Java‑kod visar hur du validerar en licens:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Trådsäkerhet**

{{% alert title="Note" color="warning" %}} 

Metoden [SetLicense](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License#setLicense-java.io.InputStream-) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsprimitiver (t.ex. ett lås) för att undvika problem. 

{{% /alert %}}

## **FAQ**

**Kan jag tillämpa licensen i en helt offline-miljö (ingen internetåtkomst)?**

Ja. Licensvalidering utförs lokalt med hjälp av licensfilen; ingen internetanslutning krävs.

**Vad händer när det ettåriga abonnemanget löper ut? Kommer biblioteket att sluta fungera?**

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt abonnemangs slutdatum; du kommer bara inte att ha rätt att använda nyare versioner utan förnyelse.