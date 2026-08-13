---
title: Licenshantering
type: docs
weight: 90
url: /sv/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Applicera, hantera och felsök licenser i Aspose.Slides för Android via Java. Säkerställ oavbruten åtkomst till alla funktioner med vår licensguide."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen ger samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Denna artikel förklarar hur licenshantering fungerar i Aspose.Slides och hur man tillämpar en licens innan biblioteket används. En licens kan laddas från en fil, en ström eller en inbäddad resurs med hjälp av klassen `License`. Artikeln visar också hur man validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Android via Java** från dess [nedladdningssida](https://releases.aspose.com/slides/sv/androidjava/). Utvärderingsversionen ger samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några rader kod (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose försäljningsteam.

Varje Aspose-licens kommer med ett års prenumeration för gratis uppgraderingar till nya versioner eller korrigeringar som släpps inom prenumerationsperioden. Användare med licensierade produkter (eller även utvärderingsversioner) får gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar för utvärderingsversionen**

* Medan Aspose.Slides utvärderingsversion (utan specificerad licens) ger full funktionalitet, infogar den ett utvärderingsvattenstämpel högst upp i dokumentet vid öppnings- och spara‑operationer. 
* Du är begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="info" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars temporär licens**. Se sidan [Hur man får en temporär licens](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licenshantering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader (för att tillämpa licensen).
* Licensen är en vanlig text‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationens utgångsdatum med mera.
* Licensfilen är digitalt signerad, så du får inte ändra den. Även ett oavsiktligt extra radbryt i filens innehåll gör den ogiltig.
* Aspose.Slides for Android via Java söker vanligtvis efter licensen på följande platser:
  * En explicit sökväg
  * Mappen som innehåller Aspose.Slides.jar
* För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange en licens en gång per applikation eller process.

## **Applicera en licens**

En licens kan laddas från en **fil** eller **ström**.

{{% alert color="info" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/) för licenshantering.

{{% /alert %}} 

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Den enklaste metoden för att ange en licens kräver att du placerar licensfilen i mappen som innehåller Aspose.Slides.jar eller din applikations jar.

Denna Java‑kod visar hur du anger en licensfil:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Anger sökvägen till licensfilen
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog, när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) måste licensfilens namn i slutet av den specificerade explicit‑sökvägen vara samma som din licensfil.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.Android.via.Java.lic.xml*. Då måste du i din kod skicka sökvägen till filen (som slutar med *Aspose.Slides.Android.via.Java.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Ström**

Du kan ladda en licens från en ström. Denna Java‑kod visar hur du tillämpar en licens från en ström:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensen via en ström
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Validera en licens**

För att kontrollera om en licens har angetts korrekt kan du validera den. Denna Java‑kod visar hur du validerar en licens:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Trådsäkerhet**

{{% alert title="Note" color="warning" %}} 

Metoden [SetLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsprimitiver (t.ex. en lås) för att undvika problem. 

{{% /alert %}}

## **Vanliga frågor**

### Kan jag tillämpa licensen i en helt offline-miljö (ingen internetuppkoppling)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när enårs‑prenumerationen löper ut? Slutar biblioteket fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt prenumerationsslutdatum; du kommer bara inte att kunna använda nyare versioner utan att förnya.