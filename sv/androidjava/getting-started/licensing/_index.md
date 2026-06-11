---
title: Licensiering
type: docs
weight: 90
url: /sv/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för Android via Java. Säkerställ oavbruten åtkomst till alla funktioner med vår licensguide."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du applicerar en licens innan du använder biblioteket. En licens kan läsas in från en fil, en ström eller en inbäddad resurs med hjälp av `License`‑klassen. Artikeln visar också hur du validerar att en licens har applicerats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="primary" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Android via Java** från dess [nedladdningssida](https://releases.aspose.com/slides/sv/androidjava/). Utvärderingsversionen erbjuder samma funktioner som den licensierade produkten. Utvärderingspaketet är identiskt med det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad när du lägger till några få kodrader (för att applicera licensen).

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose‑försäljningsteamet.

Varje Aspose‑licens kommer med ett års prenumeration för gratis uppgraderingar till nya versioner eller korrigeringar som släpps inom prenumerationsperioden. Användare med licensierade produkter (eller även utvärderingsversioner) får gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar i utvärderingsversionen**

* Medan Aspose.Slides utvärderingsversion (utan angiven licens) ger full produktfunktionalitet, infogar den ett utvärderingsvattenstämpel högst upp i dokumentet vid öppning och sparning. 
* Du är begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars tillfällig licens**. Se sidan [How to get a Temporary License](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader (för att applicera licensen).
* Licensen är en klartext‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationsutgångsdatum med mera. 
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även ett oavsiktligt extra radbryt i filens innehåll gör licensen ogiltig.
* Aspose.Slides for Android via Java försöker vanligtvis hitta licensen på dessa platser:
  * En explicit sökväg
  * Mappen som innehåller Aspose.Slides.jar
* För att undvika begränsningarna i utvärderingsversionen måste du sätta en licens innan du använder **Aspose.Slides**. Du behöver bara sätta licensen en gång per applikation eller process.

## **Applicera en licens**

En licens kan läsas in från en **fil** eller **ström**.

{{% alert color="primary" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/) för licensoperationer.

{{% /alert %}} 

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Det enklaste sättet att sätta en licens är att placera licensfilen i mappen som innehåller Aspose.Slides.jar eller din applika­tions‑jar.

Denna Java‑kod visar hur du sätter en licensfil:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensfilens sökväg
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog måste du, när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), ange det explicit angivna licensfilnamnet exakt som ditt licensfilnamn.

Till exempel kan du ändra licensfilnamnet till *Aspose.Slides.Android.via.Java.lic.xml*. Då måste du i koden skicka sökvägen till filen (som slutar med *Aspose.Slides.Android.via.Java.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Ström**

Du kan läsa in en licens från en ström. Denna Java‑kod visar hur du applicerar en licens från en ström:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensen via en ström
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Validera en licens**

För att kontrollera om en licens har satts korrekt kan du validera den. Denna Java‑kod visar hur du validerar en licens:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Trådsäkerhet**

{{% alert title="Note" color="warning" %}} 

Metoden [SetLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsmekanismer (som ett lås) för att undvika problem. 

{{% /alert %}}

## **FAQ**

**Kan jag applicera licensen i en helt offline‑miljö (ingen internetåtkomst)?**

Ja. Licensvalidering sker lokalt med licensfilen; ingen internetanslutning krävs.

**Vad händer när det ettåriga prenumerationsavtalet löper ut? Slutar biblioteket att fungera?**

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt prenumerationsslutdatum; du får bara inte använda nyare versioner utan att förnya prenumerationen.