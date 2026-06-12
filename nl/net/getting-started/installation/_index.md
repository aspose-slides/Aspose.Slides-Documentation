---
title: Installatie
type: docs
weight: 70
url: /nl/net/installation/
keywords:
- Installeer Aspose.Slides
- Download Aspose.Slides
- Gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u snel Aspose.Slides voor .NET kunt installeren. Stapsgewijze handleiding, systeemvereisten en codevoorbeelden — begin vandaag nog met het werken met PowerPoint-presentaties!"
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides voor .NET kunt installeren op Windows en macOS. Het richt zich op installatie via NuGet en laat zien hoe u de bibliotheek aan een Visual Studio‑project kunt toevoegen, zowel via de NuGet Package Manager als de Package Manager Console op Windows. Het beschrijft ook hoe u het pakket kunt bijwerken en prerelease‑builds kunt installeren wanneer dat nodig is.

## **Windows**
NuGet biedt de eenvoudigste manier om Aspose‑API’s voor .NET op pc’s te downloaden en te installeren. 

### **Methode 1: Aspose.Slides installeren of bijwerken via de NuGet Package Manager**

1. Open Microsoft Visual Studio. 
2. Maak een eenvoudige console‑applicatie aan of open een bestaand project. 
3. Ga via **Tools** > **NuGet package manager**. 
4. Onder **Browse**, zoekt u naar *Aspose Slides* in het tekstveld. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klik op **Aspose.Slides.NET** en vervolgens op **Install**. 
   * Als u Aspose.Slides wilt bijwerken—ervan uitgaande dat u het al geïnstalleerd heeft—klikt u in plaats daarvan op **Update**. 

De geselecteerde API wordt gedownload en in uw project gerefereerd.

### **Methode 2: Aspose.Slides installeren of bijwerken via de Package Manager Console**

Zo verwijst u naar [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) via de package manager console:

1. Open Microsoft Visual Studio. 
2. Maak een eenvoudige console‑applicatie aan of open een bestaand project. 
3. Ga via **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Run this command: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
De nieuwste volledige release wordt geïnstalleerd in uw applicatie. 

* U kunt ook de `-prerelease`‑suffix aan het commando toevoegen om aan te geven dat de nieuwste release (inclusief hotfixes) eveneens moet worden geïnstalleerd. 

De tip **Installing Aspose.Slides.NET** verschijnt onderaan het venster. 
![todo:image_alt_text](installation_4.png)

Wanneer de download voltooid is, ziet u enkele bevestigingsberichten. 

Als u niet bekend bent met de [Aspose EULA](https://about.aspose.com/legal/eula), wilt u wellicht de licentie op de URL lezen. 
![todo:image_alt_text](installation_5.png)

In uw applicatie zou u moeten zien dat Aspose.Slides succesvol is toegevoegd en gerefereerd. 
![todo:image_alt_text](installation_6.png)

In de Package Manager Console kunt u het commando `Update-Package Aspose.Slides.NET` uitvoeren om te controleren op updates voor het Aspose.Slides‑pakket. Updates (indien gevonden) worden automatisch geïnstalleerd. U kunt ook de `-prerelease`‑suffix gebruiken om de nieuwste release bij te werken.

#### **Overwegingen bij uitvoering in een gedeelde serveromgeving**
We raden ten zeerste aan om alle Aspose .NET‑componenten uit te voeren met de **Full Trust**‑toestemming, omdat Aspose‑componenten soms registerinstellingen en bestanden op andere locaties dan de virtuele map moeten benaderen, bijvoorbeeld wanneer ze lettertypen moeten lezen. 

Bovendien zijn Aspose.NET‑componenten gebaseerd op de kern‑.NET‑systeemklassen, en sommige van deze klassen vereisen in bepaalde gevallen ook Full Trust‑toestemming voor hun bewerkingen.

Internet Service Providers die meerdere applicaties van verschillende bedrijven hosten, handhaven meestal het Medium Trust‑beveiligingsniveau. In het geval van .NET 2.0 kan een dergelijk beveiligingsniveau beperkingen opleveren die de bewerkingen van Aspose.Slides beïnvloeden:

- **RegistryPermission** is niet beschikbaar. Dit betekent dat u geen toegang heeft tot het register, wat nodig is om geïnstalleerde lettertypen te enumereren bij het renderen van documenten.
- **FileIOPermission** is beperkt. Dit betekent dat u alleen toegang heeft tot bestanden in de hiërarchie van de virtuele map van uw applicatie. Dit kan er tevens toe leiden dat lettertypen niet gelezen kunnen worden tijdens exportbewerkingen.

Om bovenstaande redenen raden wij ten zeerste aan om Aspose.Slides uit te voeren met **Full Trust**‑toestemming. Als u **Medium trust** gebruikt, kunt u inconsistenties ervaren—sommige bibliotheekfuncties (bijvoorbeeld rendering) werken mogelijk niet bij bepaalde taken. 

## **macOS**

NuGet biedt de eenvoudigste manier om Aspose.Slides voor .NET op Macs te downloaden en te installeren. 

**Installeer vereiste**

De `System.Drawing`‑namespace werkt anders in macOS, dus moet u mono-libgdiplus installeren. 

> In .NET 5 en eerdere versies werkt het [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet‑pakket op Windows, Linux en macOS. Er zijn echter enkele platformverschillen. Op Linux en macOS wordt de GDI+‑functionaliteit geïmplementeerd door de [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/)‑bibliotheek. Deze bibliotheek is niet standaard geïnstalleerd in de meeste Linux‑distributies en ondersteunt niet alle functionaliteit van GDI+ op Windows en macOS. Er zijn ook platformen waar libgdiplus helemaal niet beschikbaar is. Om types uit het System.Drawing.Common‑pakket te gebruiken op Linux en macOS, moet u libgdiplus apart installeren. Zie voor meer informatie [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) of [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus). 

Om mono-libgdiplus apart op uw Mac te installeren, zie [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) from .NET documentation. 

### **Aspose.Slides installeren**

1. Open Visual Studio. 
2. Maak een eenvoudige console‑applicatie aan of open een bestaand project.
3. Ga via **Project** > **Manage NuGet Packages...** 
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Typ *Aspose.Slides* in het tekstveld. 
5. Klik op **Aspose.Slides for .NET** en vervolgens op **Add Package.** 
6. Voeg een eenvoudig code‑fragment toe.
   * U kunt de code kopiëren van [this page](/slides/nl/net/create-presentation/).
7. Voer de app uit.
8. Open de *folder/bin/Debug/presentation_file_name* van uw project.

## **FAQ**

**Is er een gratis versie of proefbeperking?**

Ja, standaard draait Aspose.Slides in evaluatiemodus, die watermerken toevoegt en mogelijk andere beperkingen heeft. Om de beperkingen te verwijderen moet u een geldige [licentie](/slides/nl/net/licensing/) toepassen.