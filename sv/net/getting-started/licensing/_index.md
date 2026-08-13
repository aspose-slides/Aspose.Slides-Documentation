---
title: Licensiering
type: docs
weight: 80
url: /sv/net/licensing/
keywords:
- licens
- temporär licens
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
description: "Tillämpa, hantera och felsöka licenser i Aspose.Slides för .NET. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i evalueringsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Den här artikeln förklarar hur licensiering fungerar i Aspose.Slides och hur du tillämpar en licens innan du använder biblioteket. En licens kan laddas från en fil, ström eller inbäddad resurs med hjälp av `License`‑klassen. Artikeln visar också hur du verifierar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for NET** från [dess NuGet-nedladdningssida](https://www.nuget.org/packages/Aspose.Slides.NET/). Utvärderingsversionen erbjuder samma funktioner som den licensierade versionen av produkten. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några kodrader (för att tillämpa licensen).

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köp en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose:s försäljningsteam.

Varje Aspose‑licens innehåller ett års prenumeration för gratis uppgraderingar till nya versioner eller korrigeringar som släpps under prenumerationsperioden. Användare med licensierade produkter eller även utvärderingsversioner får gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar för utvärderingsversion**

* Även om Aspose.Slides utvärderingsversion (utan specificerad licens) erbjuder full produktfunktionalitet, lägger den in ett utvärderingsvattenstämpel högst upp i dokumentet vid öppnings‑ och sparoperationer. 
* Du är begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="info" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars temporär licens**. Se sidan [Hur du får en temporär licens](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Licensiering i Aspose.Slides**
* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader (för att tillämpa licensen).
* Licensen är en rentext‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare som den är licensierad för, prenumerationsutgångsdatum med mera. 
* Licensfilen är digitalt signerad, så du får inte ändra filen. Även ett oavsiktligt tillägg av ett extra radbrytning i filens innehåll gör den ogiltig.
* Aspose.Slides för .NET försöker vanligtvis hitta licensen på följande platser:
  * En explicit sökväg
  * Mappen som innehåller komponentens DLL (inkluderad i Aspose.Slides)
  * Mappen som innehåller den samling som anropade komponentens DLL (inkluderad i Aspose.Slides)
  * Mappen som innehåller start‑assemblyn (din .exe)
  * En inbäddad resurs i den assembly som anropade komponentens DLL (inkluderad i Aspose.Slides).
* För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder Aspose.Slides. Du behöver bara ange en licens en gång per applikation eller process.

{{% alert color="info" %}} 

Du kanske vill se [Metered Licensing](https://docs.aspose.com/slides/sv/net/metered-licensing/).

{{% /alert %}} 


## **Tillämpa en licens**
En licens kan laddas från en **fil**, **ström**, eller **inbäddad resurs**. 

{{% alert color="info" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/net/aspose.slides/license) för licensieringsoperationer.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **File**
Den enklaste metoden för att ange en licens kräver att du placerar licensfilen i samma mapp som innehåller komponentens DLL (inkluderad i Aspose.Slides) och anger endast filnamnet utan dess sökväg.

Denna C#‑kod visar hur du anger en licensfil:

``` csharp
// Instansierar License-klassen 
Aspose.Slides.License license = new Aspose.Slides.License();

// Anger licensfilens sökväg
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog, när du anropar metoden [SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/#setlicense_1) måste licensfilens namn i slutet av den specificerade explicita vara detsamma som din licensfil.

Till exempel kan du ändra licensfilens namn till *Aspose.Slides.lic.xml*. Då måste du i din kod skicka sökvägen till filen (slutande med *Aspose.Slides.lic.xml*) till metoden [SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Stream**
Du kan ladda en licens från en ström. Denna C#‑kod visar hur du tillämpar en licens från en ström:

``` csharp
// Instansierar License-klassen
Aspose.Slides.License license = new Aspose.Slides.License();

// Öppnar licensfilen som en ström
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Sätter licensen genom en ström
license.SetLicense(licenseStream);
```

### **Embedded Resource**
Du kan paketera licensen med din applikation (för att undvika att den försvinner) genom att lägga till licensen som en inbäddad resurs i en av de assemblys som anropar komponentens DLL (inkluderad i Aspose.Slides). 

Så här lägger du till en licensfil som en inbäddad resurs:

1. I Visual Studio, lägg till licensfilen (.lic) i projektet på följande sätt: Gå via **File** > **Add Existing Item** > **Add**. 
2. Välj filen i **Solution Explorer**.
3. I **Properties**‑fönstret, sätt **Build Action** till **Embedded Resource**.
4. För att komma åt licensen som är inbäddad i assemblyn, lägg till licensfilen som en inbäddad resurs i projektet och skicka sedan licensfilens namn till `SetLicense`‑metoden. 


`License`‑klassen hittar automatiskt licensfilen i de inbäddade resurserna. Du behöver inte anropa metoderna `GetExecutingAssembly` och `GetManifestResourceStream` i klassen `System.Reflection.Assembly` i Microsoft .NET Framework.

Denna C#‑kod visar hur du anger en licens som en inbäddad resurs:

``` csharp
// Instansierar License-klassen
Aspose.Slides.License license = new Aspose.Slides.License();

// Skickar licensfilens namn som är inbäddat i assemblyn
license.SetLicense("Aspose.Slides.lic");
```

## **Validera en licens**

För att kontrollera om en licens har satts korrekt kan du validera den. Denna C#‑kod visar hur du validerar en licens:

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

Metoden [license.SetLicense](https://reference.aspose.com/slides/sv/net/aspose.slides/license/setlicense/) är inte trådsäker. Om denna metod måste anropas samtidigt från många trådar kan du vilja använda synkroniseringsprimitiver (som ett lås) för att undvika problem. 

{{% /alert %}}

## **FAQ**

### Kan jag tillämpa licensen i en helt offline‑miljö (utan internetåtkomst)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när ettårs‑prenumerationen löper ut? Kommer biblioteket att sluta fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt prenumerationsslutdatum; du kommer bara inte vara berättigad att använda nyare versioner utan förnyelse.