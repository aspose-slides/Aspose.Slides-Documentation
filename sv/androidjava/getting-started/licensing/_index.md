---
title: Licensiering
type: docs
weight: 90
url: /sv/androidjava/licensing/
keywords:
- licens
- tillfällig licens
- ange licens
- använda licens
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

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel på varje bild i varje presentation som sparas och trunkerar text som din kod läser från presentationer.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du tillämpar en licens innan du använder biblioteket. En licens kan laddas från en fil, en ström eller en inbäddad resurs genom att använda klassen [License](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/). Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Evaluate Aspose.Slides**

{{% alert color="info" title="Note" %}}

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Android via Java** från dess [nedladdningssida](https://releases.aspose.com/slides/sv/androidjava/). Utvärderingsversionen erbjuder samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är identiskt med det köpta paketet. Utvärderingsversionen blir helt licensierad när du lägger till några rader kod för att tillämpa licensen.

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/pricing/slides/sv/android-java/). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose försäljningsteam.

Varje Aspose-licens innehåller ett ettårsabonnemang för gratis uppgraderingar till nya versioner eller korrigeringar som släpps under prenumerationsperioden. Användare med licensierade produkter (eller även utvärderingsversioner) får fri och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar i utvärderingsversionen**

* Utvärderingsversionen (utan angiven licens) erbjuder full produktfunktionalitet, men den lägger till en textruta med utvärderingsvattenstämpel på varje bild i varje presentation som sparas.
* Text som din kod läser från en presentation trunkeras till de första några tecknen, följt av en notering om utvärderingsbegränsningen. Text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Note" %}}

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars tillfällig licens**. Se sidan [How to get a Temporary License](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* En utvärderingsversion blir licensierad när du köper en licens och lägger till ett par kodrader för att tillämpa licensen.
* Licensen är en ren text‑XML‑fil som innehåller detaljer som produktnamn, antal utvecklare den är licensierad för, prenumerationsutgångsdatum med mera. 
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även en oavsiktlig extra radbrytning i filens innehåll kommer att ogiltigförklara den.
* Aspose.Slides for Android via Java försöker vanligtvis hitta licensen på följande platser:
  * En explicit sökväg
  * Mappen som innehåller Aspose.Slides.jar
* För att undvika begränsningarna i utvärderingsversionen måste du sätta en licens innan du använder **Aspose.Slides**. Du behöver bara sätta licensen en gång per applikation eller process.

## **Applying a License**

En licens kan laddas från en **fil** eller **ström**.

{{% alert color="info" title="Note" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/) för licensoperationer.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **File**

Det enklaste sättet att sätta en licens är att placera licensfilen i mappen som innehåller Aspose.Slides.jar eller din applikations jar.

{{% alert color="info" title="Note" %}}

På Android paketeras biblioteket och din app i APK‑filen, så det finns ingen mapp som innehåller bibliotekets JAR‑fil, och en relativ sökväg som *Aspose.Slides.Android.via.Java.lic* pekar inte på en fil i din app. Lägg till licensfilen i appens assets och ladda den från en ström, enligt exemplet i [Stream from App Assets](#stream-from-app-assets).

{{% /alert %}}

Denna Java‑kod visar hur du sätter en licensfil:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Ställer in licensfilens sökväg
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Om du placerar licensfilen i en annan katalog, måste när du anropar metoden [setLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) licensfilens namn i slutet av den angivna sökvägen vara exakt detsamma som ditt licensfilnamn.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.Android.via.Java.lic.xml*. Då måste du i koden skicka sökvägen till filen (slutande med *Aspose.Slides.Android.via.Java.lic.xml*) till metoden [setLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Du kan ladda en licens från en ström. Denna Java‑kod visar hur du tillämpar en licens från en ström:

``` java
// Instansierar License-klassen
com.aspose.slides.License license = new com.aspose.slides.License();

// Sätter licensen via en ström
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Stream from App Assets**

I en Android‑app placerar du licensfilen i *assets*-mappen i app‑modulen, *app/src/main/assets*, så att den paketeras i APK‑filen. Öppna filen med metoden [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) och skicka strömmen till metoden [setLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). Koden körs i en `Activity`, till exempel i dess `onCreate`‑metod, innan appen använder Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Filnamnet som skickas till metoden [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) är relativt till *assets*-mappen. Om filen inte finns där loggas ett fel och Aspose.Slides förblir i utvärderingsläge. För att kontrollera om licensen har tillämpats, se [Validating a License](#validating-a-license).

## **Validating a License**

För att kontrollera om en licens har satts korrekt kan du validera den. Denna Java‑kod visar hur du validerar en licens:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert color="warning" title="Warning" %}}

Metoden [setLicense](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) är inte trådsäker. Om metoden måste anropas samtidigt från många trådar bör du använda synkroniseringsprimitive (t.ex. en lås) för att undvika problem.

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### What happens after the one-year subscription expires? Will the library stop working?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts innan ditt prenumerationsslutdatum; du kommer bara inte att kunna använda nyare versioner utan förnyelse.