---
title: Licensiering
type: docs
weight: 80
url: /sv/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för .NET. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen ger samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenmärke när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du applicerar en licens innan du använder biblioteket. En licens kan laddas från en fil, en ström eller en inbäddad resurs med hjälp av `License`‑klassen. Artikeln visar också hur du verifierar att en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**
{{% alert color="primary" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for NET** från [dess NuGet‑nedladdningssida](https://www.nuget.org/packages/Aspose.Slides.NET/). Utvärderingsversionen erbjuder samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några rader kod (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Asposes försäljningsteam.

Varje Aspose‑licens inkluderar ett ettårigt abonnemang för gratis uppgraderingar till nya versioner eller korrigeringar som släpps under abonnemangsperioden. Användare med licensierade produkter eller även utvärderingsversioner får gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar för utvärderingsversion**

* Medan Aspose.Slides utvärderingsversion (utan angiven licens) ger full produktfunktionalitet, infogar den ett utvärderingsvattenmärke högst upp i dokumentet vid öppnings‑ och sparningsoperationer. 
* Du är begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars tillfällig licens**. Se sidan [Hur du får en tillfällig licens](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensiering i Aspose.Slides**
* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader (för att tillämpa licensen).
* Licensen är en ren text‑XML‑fil som innehåller detaljer som produktnamn, antal utvecklare den licensieras till, abonnemangets utgångsdatum osv. 
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även ett oavsiktligt tillägg av en extra radbrytning i filens innehåll gör den ogiltig.
* Aspose.Slides för .NET försöker vanligtvis hitta licensen på följande platser:
  * En explicit sökväg
  * Mappen som innehåller komponentens dll (inkluderad i Aspose.Slides)
  * Mappen som innehåller den assembly som anropade komponentens dll (inkluderad i Aspose.Slides)
  * Mappen som innehåller huvudentrén (din .exe)
  * En inbäddad resurs i den assembly som anropade komponentens dll (inkluderad i Aspose.Slides).
* För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder Aspose.Slides. Du behöver bara ange en licens en gång per applikation eller process.

{{% alert color="primary" %}} 

Du kanske vill se [Måttbaserad licensiering](https://docs.aspose.com/slides/sv/net/metered-licensing/).

{{% /alert %}} 


## **Tillämpa en licens**
En licens kan laddas från en **fil**, **ström** eller **inbäddad resurs**. 

{{% alert color="primary" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/net/aspose.slides/license) för licensoperationer.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Äldre versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**
Den enklaste metoden för att ange en licens kräver att du placerar licensfilen i samma mapp som komponentens DLL (inkluderad i Aspose.Slides) och anger endast filnamnet utan sökväg.

Denna C#‑kod visar hur du anger en licensfil:

``` csharp
// Instansierar License-klassen 
Aspose.Slides.License license = new Aspose.Slides.License();

// Anger licensfilens sökväg
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog, när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/#setlicense_1) måste licensfilens namn i slutet av den angivna sökvägen vara samma som din licensfil.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.lic.xml*. Då måste du i koden skicka sökvägen till filen (slutande med *Aspose.Slides.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Ström**
Du kan ladda en licens från en ström. Denna C#‑kod visar hur du tillämpar en licens från en ström:

``` csharp
// Instansierar License-klassen 
Aspose.Slides.License license = new Aspose.Slides.License();

// Anger licensen via en ström
license.SetLicense(myStream);
```

### **Inbäddad resurs**
Du kan paketera licensen med din applikation (för att undvika att den försvinner) genom att lägga till licensen som en inbäddad resurs i någon av de assemblys som anropar komponentens DLL (inkluderad i Aspose.Slides). 

Så här lägger du till en licensfil som en inbäddad resurs:

1. I Visual Studio, lägg till licensfilen (.lic) i projektet på följande sätt: Gå via **File** > **Add Existing Item** > **Add**. 
2. Markera filen i **Solution Explorer**.
3. I fönstret **Properties**, sätt **Build Action** till **Embedded Resource**.
4. För att komma åt licensen som är inbäddad i assemblyn, lägg till licensfilen som en inbäddad resurs i projektet och skicka sedan licensfilens namn till `SetLicense`‑metoden. 


`License`‑klassen hittar automatiskt licensfilen i de inbäddade resurserna. Du behöver inte anropa metoderna `GetExecutingAssembly` och `GetManifestResourceStream` i klassen `System.Reflection.Assembly` i Microsoft .NET Framework.

Denna C#‑kod visar hur du anger en licens som en inbäddad resurs:

``` csharp
// Instansierar License-klassen
Aspose.Slides.License license = new Aspose.Slides.License();

// Skickar licensfilens namn inbäddat i assemblyn
license.SetLicense("Aspose.Slides.lic");
```

## **Verifiera en licens**

För att kontrollera om en licens har satts korrekt kan du verifiera den. Denna C#‑kod visar hur du verifierar en licens:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Trådsäkerhet**

{{% alert title="Note" color="warning" %}} 

Metoden [license.SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsprimitiver (t.ex. en lock) för att undvika problem. 

{{% /alert %}}

## **FAQ**

**Kan jag tillämpa licensen i en helt offline‑miljö (utan internetanslutning)?**

Ja. Licensvalidering sker lokalt med licensfilen; ingen internetanslutning krävs.

**Vad händer när det ettåriga abonnemanget går ut? Kommer biblioteket att sluta fungera?**

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt abonnemangs slutdatum; du kommer bara inte kunna använda nyare versioner utan att förnya.