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
description: "Applicera, hantera och felsök licenser i Aspose.Slides för Java. Säkerställ oavbruten tillgång till alla funktioner med vår steg-för-steg-licensguide."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen ger samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du applicerar en licens innan du använder biblioteket. En licens kan läsas in från en fil, ström eller inbäddad resurs genom att använda `License`-klassen. Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Java** från dess [nedladdningssida](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Utvärderingsversionen erbjuder samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några rader kod (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose:s försäljningsteam.

Varje Aspose-licens innehåller ett årsabonnemang för gratis uppgraderingar till nya versioner eller korrigeringar som släpps under abonnemangsperioden. Användare med licensierade produkter (eller även utvärderingsversioner) får gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar för utvärderingsversion**

* Medan Aspose.Slides utvärderingsversion (utan angiven licens) erbjuder full produktfunktionalitet, infogar den ett utvärderingsvattenstämpel högst upp i dokumentet vid öppnings- och sparoperationer. 
* Du är begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="info" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30-dagars tillfällig licens**. Se sidan [Hur du får en tillfällig licens](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader (för att tillämpa licensen). 
* Licensen är en ren-text XML-fil som innehåller detaljer som produktnamn, antal utvecklare den är licensierad för, abonnemangets utgångsdatum osv. 
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även ett oavsiktligt tillägg av ett extra radbrytning i filens innehåll gör den ogiltig.
* Aspose.Slides for Java försöker vanligtvis hitta licensen på dessa platser:
  * En explicit sökväg
  * Mappen som innehåller Aspose.Slides.jar
* För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange en licens en gång per applikation eller process.

{{% alert color="info" %}} 

Du kanske vill se [Mätbaserad licensiering](/slides/sv/java/metered-licensing/).

{{% /alert %}} 

## **Applicera en licens**

En licens kan läsas in från en **fil** eller **ström**.

{{% alert color="info" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License) för licensoperationer.

{{% /alert %}} 

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Den enklaste metoden för att ange en licens kräver att du placerar licensfilen i mappen som innehåller Aspose.Slides.jar eller i din applikations jar.

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Anger sökvägen till licensfilen
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog, när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License#setLicense-java.lang.String-) måste licensfilens namn i slutet av den angivna explicit-sökvägen vara samma som din licensfil.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.Java.lic.xml*. Därefter måste du i din kod skicka sökvägen till filen (avslutande med *Aspose.Slides.Java.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Ström**

Du kan läsa in en licens från en ström. Denna Java-kod visar hur du tillämpar en licens från en ström:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensen via en ström
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Om du använder Aspose.Slides för PHP via Java kan du ange en licens via en PHP/Java-brygga. Denna brygga låter dig använda Java-klasser i PHP-syntax. För mer information, se [Licens i PHP](/slides/sv/php-java/licensing/).

## **Validera en licens**

För att kontrollera om en licens har ställts in korrekt kan du validera den. Denna Java-kod visar hur du validerar en licens:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Trådsäkerhet**

{{% alert title="Note" color="warning" %}} 

Metoden [SetLicense](https://reference.aspose.com/slides/sv/java/com.aspose.slides/License#setLicense-java.io.InputStream-) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsprimitive (som ett lås) för att undvika problem. 

{{% /alert %}}

## **FAQ**

### Kan jag applicera licensen i en helt offline-miljö (ingen internetanslutning)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när det ettåriga prenumerationsavtalet löper ut? Kommer biblioteket att sluta fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt prenumerationsslutdatum; du kommer bara inte att vara berättigad att använda nyare versioner utan förnyelse.