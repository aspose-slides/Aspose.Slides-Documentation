---
title: Licensiering
type: docs
weight: 80
url: /sv/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för .NET. Säkerställ oavbruten åtkomst till alla funktioner med vår steg‑för‑steg‑guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel på varje bild i varje presentation som den sparar och trunkerar text som din kod läser från presentationer.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du tillämpar en licens innan du använder biblioteket. En licens kan laddas från en fil, ström eller inbäddad resurs genom att använda klassen `License`. Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" title="Note" %}}
Du kan ladda ner en utvärderingsversion av **Aspose.Slides for .NET** från [dess NuGet-nedladdningssida](https://www.nuget.org/packages/Aspose.Slides.NET/). Utvärderingsversionen erbjuder samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några rader kod (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köpa en licens](https://purchase.aspose.com/pricing/slides/sv/net/). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose försäljningsteam.

Varje Aspose‑licens följer med ett ett‑årigt abonnemang för gratis uppgraderingar till nya versioner eller korrigeringar som släpps inom abonnemangsperioden. Användare med licensierade produkter eller även utvärderingsversioner får gratis och obegränsad teknisk support.
{{% /alert %}} 

**Begränsningar för utvärderingsversion**

* Utvärderingsversionen (utan en specificerad licens) erbjuder full produktfunktionalitet, men den lägger till en utvärderingsvattenstämpeltextruta på varje bild i varje presentation den sparar.
* Text som din kod läser från en presentation trunkeras till de första tecknen, följt av ett meddelande om utvärderingsbegränsningen. Text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Note" %}}
För att testa Aspose.Slides utan begränsningar kan du begära en **30‑Day Temporary License**. Se sidan [Hur du får en tillfällig licens](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}}

## **Licensiering i Aspose.Slides**
* En utvärderingsversion blir licensierad efter att du har köpt en licens och lagt till ett par rader kod (för att tillämpa licensen).
* Licensen är en vanlig XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, abonnemangets utgångsdatum osv.
* Licensfilen är digitalt signerad, så du får inte ändra den. Även ett oavsiktligt extra radbryt i filens innehåll gör den ogiltig.
* Aspose.Slides for .NET försöker vanligtvis hitta licensen på följande platser:
  * En explicit sökväg
  * Mappen som innehåller komponentens DLL (inkluderad i Aspose.Slides)
  * Mappen som innehåller den assembly som anropade komponentens DLL (inkluderad i Aspose.Slides)
  * Mappen som innehåller huvud‑assemblyn (din .exe)
  * En inbäddad resurs i den assembly som anropade komponentens DLL (inkluderad i Aspose.Slides).
* För att undvika begränsningarna i utvärderingsversionen måste du ange en licens innan du använder Aspose.Slides. Du behöver bara ange licensen en gång per applikation eller process.

{{% alert color="info" title="Note" %}}
Du kanske vill se [Metered Licensing](/slides/sv/net/metered-licensing/).
{{% /alert %}} 

## **Applicera en licens**
En licens kan laddas från en **fil**, **ström** eller **inbäddad resurs**. 

{{% alert color="info" title="Note" %}}
Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/net/aspose.slides/license) för licensieringsoperationer.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

### **Fil**
Det enklaste sättet att ange en licens är att placera licensfilen i samma mapp som komponentens DLL (inkluderad i Aspose.Slides) och ange endast filnamnet utan sökväg.

Den här C#‑koden visar hur du anger en licensfil:

``` csharp
// Skapar en instans av License-klassen 
Aspose.Slides.License license = new Aspose.Slides.License();

// Anger sökvägen till licensfilen
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
Om du placerar licensfilen i en annan katalog måste filnamnet i den angivna sökvägen vara detsamma som ditt licensfilnamn när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/#setlicense_1).

Till exempel kan du ändra licensfilnamnet till *Aspose.Slides.lic.xml*. Då måste du i koden skicka sökvägen till filen (som slutar på *Aspose.Slides.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/#setlicense_1).
{{% /alert %}}

### **Ström**
Du kan ladda en licens från en ström. Den här C#‑koden visar hur du tillämpar en licens från en ström:

``` csharp
// Skapar en instans av License-klassen
Aspose.Slides.License license = new Aspose.Slides.License();

// Öppnar licensfilen som en ström
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Anger licensen via en ström
license.SetLicense(licenseStream);
```

### **Inbäddad resurs**
Du kan paketera licensen med din applikation (för att undvika att förlora den) genom att lägga till licensen som en inbäddad resurs i någon av de assemblys som anropar komponentens DLL (inkluderad i Aspose.Slides). 

Så här lägger du till en licensfil som inbäddad resurs:

1. I Visual Studio, lägg till licensfilen (.lic) i projektet på följande sätt: Gå via **File** > **Add Existing Item** > **Add**. 
2. Välj filen i **Solution Explorer**.
3. På **Properties**‑fönstret, sätt **Build Action** till **Embedded Resource**.
4. För att komma åt licensen som är inbäddad i assemblyn, lägg till licensfilen som en inbäddad resurs i projektet och skicka sedan licensfilnamnet till `SetLicense`‑metoden. 


Klassen `License` hittar automatiskt licensfilen i de inbäddade resurserna. Du behöver inte anropa metoderna `GetExecutingAssembly` och `GetManifestResourceStream` i klassen `System.Reflection.Assembly` i Microsoft .NET Framework.

Den här C#‑koden visar hur du anger en licens som inbäddad resurs:

``` csharp
// Skapar en instans av License-klassen
Aspose.Slides.License license = new Aspose.Slides.License();

// Anger licensfilens namn som är inbäddat i assemblyn
license.SetLicense("Aspose.Slides.lic");
```

## **Validera en licens**

För att kontrollera om en licens har angetts korrekt kan du validera den. Den här C#‑koden visar hur du validerar en licens:

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

{{% alert color="warning" title="Warning" %}}
Metoden [license.SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du behöva använda synkroniseringsmekanismer (t.ex. en lock) för att undvika problem. 
{{% /alert %}}

## **FAQ**

### Kan jag tillämpa licensen i en helt offline‑miljö (ingen internetanslutning)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när ettårsabonnemanget går ut? Kommer biblioteket att sluta fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt abonnemangs slutdatum; du kommer bara inte att kunna använda nyare releaser utan att förnya abonnemanget.