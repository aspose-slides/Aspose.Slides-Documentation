---
title: Licensiering
type: docs
weight: 90
url: /sv/java/licensing/
keywords:
- licens
- tillfällig licens
- sätt licens
- använd licens
- validera licens
- licensfil
- utvärderingsversion
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Applicera, hantera och felsök licenser i Aspose.Slides för Java. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen ger samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel på varje bild i varje presentation som sparas och trunkerar text som din kod läser via API:et.

Den här artikeln förklarar hur licensiering fungerar i Aspose.Slides och hur du tillämpar en licens innan du använder biblioteket. En licens kan laddas från en fil, ström eller inbäddad resurs genom att använda klassen `License`. Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" title="Note" %}}

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Java** från dess [nedladdningssida](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Utvärderingsversionen erbjuder samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är samma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några rader kod (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köpa en licens](https://purchase.aspose.com/pricing/slides/java/). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose försäljningsteam.

Varje Aspose-licens kommer med ett ettårsabonnemang för gratis uppgraderingar till nya versioner eller korrigeringar som släpps under prenumerationsperioden. Användare med licensierade produkter (eller även utvärderingsversioner) får gratis och obegränsad teknisk support.

{{% /alert %}}

**Begränsningar för utvärderingsversionen**

* Utvärderingsversionen (utan specificerad licens) ger full produktfunktionalitet, men den lägger till en utvärderingsvattenstämpeltextbox på varje bild i varje presentation som sparas.
* Text som din kod läser via API:et, inklusive text den precis har satt, trunkeras till de första tecknen, följt av ett meddelande om utvärderingsbegränsningen. Text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Note" %}}

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars Tillfällig Licens**. Se sidan [Hur du får en Tillfällig Licens](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader (för att tillämpa licensen).
* Licensen är en ren text‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationsutgångsdatum osv.
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även en oavsiktlig extra radbrytning i filens innehåll gör den ogiltig.
* Aspose.Slides for Java försöker vanligtvis hitta licensen på dessa platser:
  * En explicit sökväg
  * Mappen som innehåller Aspose.Slides.jar
* För att undvika begränsningarna i utvärderingsversionen måste du ställa in en licens innan du använder **Aspose.Slides**. Du behöver bara ställa in licensen en gång per applikation eller process.

{{% alert color="info" title="Note" %}}

Du kanske vill se [Mätad licensiering](/slides/sv/java/metered-licensing/).

{{% /alert %}}

## **Tillämpa en Licens**

En licens kan laddas från en **fil** eller **ström**.

{{% alert color="info" title="Note" %}}

Aspose.Slides tillhandahåller klassen [Licens](https://reference.aspose.com/slides/java/com.aspose.slides/license/) för licensieringsoperationer.

{{% /alert %}}

{{% alert color="warning" title="Warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Det enklaste sättet att ange en licens är att placera licensfilen i mappen som innehåller Aspose.Slides.jar eller ditt programs jar‑fil.

Denna Java‑kod visar hur du anger en licensfil:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensfilens sökväg
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Om du placerar licensfilen i en annan katalog, när du anropar metoden [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) måste licensfilens namn i slutet av den angivna sökvägen vara exakt samma som ditt licensfilnamn.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.Java.lic.xml*. Då måste du i din kod skicka sökvägen till filen (slutande med *Aspose.Slides.Java.lic.xml*) till metoden [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Ström**

Du kan ladda en licens från en ström. Denna Java‑kod visar hur du tillämpar en licens från en ström:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensen via en ström
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Om du använder Aspose.Slides för PHP via Java kan du ange en licens genom en PHP/Java‑bridge. Denna bridge låter dig använda Java‑klasser i PHP‑syntax. Mer information finns i [Licens i PHP](/slides/sv/php-java/licensing/).

## **Validera en Licens**

För att kontrollera om en licens har ställts in korrekt kan du validera den. Denna Java‑kod visar hur du validerar en licens:

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

{{% alert color="warning" title="Warning" %}}

Metoden [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) är inte trådsäker. Om den här metoden måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsprimitiver (som en lås) för att undvika problem.

{{% /alert %}}

## **FAQ**

### Kan jag tillämpa licensen i en helt offline‑miljö (utan internetåtkomst)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när det ettårsabonnemanget löper ut? Kommer biblioteket att sluta fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts innan ditt abonnemangs slutdatum; du kommer bara inte att kunna använda nyare releaser utan förnyelse.