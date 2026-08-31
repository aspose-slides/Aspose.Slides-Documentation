---
title: Installatie
type: docs
weight: 70
url: /nl/net/installation/
keywords:
- installeren Aspose.Slides
- downloaden Aspose.Slides
- gebruiken Aspose.Slides
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
description: "Leer hoe u snel Aspose.Slides voor .NET kunt installeren. Stapsgewijze handleiding, systeemvereisten en codevoorbeelden — begin vandaag nog met werken aan PowerPoint-presentaties!"
---
## **Overzicht**

Dit artikel legt uit hoe je Aspose.Slides voor .NET installeert op Windows, Linux en macOS. Het richt zich op installatie via NuGet en toont hoe je de bibliotheek toevoegt via de NuGet Package Manager of de Package Manager Console op Windows, aan een .NET‑project op Linux, en aan een Visual Studio‑project op macOS. Daarnaast wordt beschreven hoe je het pakket bijwerkt en pre‑release builds installeert wanneer dat nodig is.

Bekijk vóór de installatie de ondersteunde besturingssystemen, .NET‑implementaties en extra afhankelijkheden in [System Requirements](/slides/nl/net/system-requirements/).

## **Windows**
NuGet biedt de eenvoudigste manier om Aspose‑API's voor .NET op pc's te downloaden en te installeren. 

### **Methode 1: Aspose.Slides installeren of bijwerken via de NuGet Package Manager**

1. Open Microsoft Visual Studio.  
2. Maak een eenvoudige console‑applicatie of open een bestaand project.  
3. Ga via **Tools** > **NuGet package manager**.  
4. Zoek onder **Browse** naar *Aspose Slides* in het zoekveld.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klik op **Aspose.Slides.NET** en daarna op **Install**.  
   * Als je Aspose.Slides wilt bijwerken — ervan uitgaande dat je het al geïnstalleerd hebt — klik dan op **Update**.

Het geselecteerde API‑pakket wordt gedownload en aan je project gekoppeld.

### **Methode 2: Aspose.Slides installeren of bijwerken via de Package Manager Console**

Zo verwijs je naar de [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) via de package manager console:

1. Open Microsoft Visual Studio.  
2. Maak een eenvoudige console‑applicatie of open een bestaand project.  
3. Ga via **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Voer deze opdracht uit: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
De nieuwste volledige release wordt in je applicatie geïnstalleerd.  

* Als alternatief kun je de `-prerelease`‑suffix toevoegen aan de opdracht om ook de laatste release (inclusief hotfixes) te installeren.

De tip **Installing Aspose.Slides.NET** verschijnt onderaan het venster.  
![todo:image_alt_text](installation_4.png)

Wanneer de download voltooid is, zie je een aantal bevestigingsberichten.

Als je niet bekend bent met de [Aspose EULA](https://about.aspose.com/legal/eula), kun je de licentie die in de URL wordt vermeld raadplegen.  
![todo:image_alt_text](installation_5.png)

In je applicatie zie je dat Aspose.Slides succesvol is toegevoegd en verwezen.  
![todo:image_alt_text](installation_6.png)

In de Package Manager Console kun je de opdracht `Update-Package Aspose.Slides.NET` uitvoeren om te controleren op updates voor het Aspose.Slides‑pakket. Updates (indien gevonden) worden automatisch geïnstalleerd. Je kunt ook de `-prerelease`‑suffix gebruiken om de laatste release bij te werken.

#### **Overwegingen bij uitvoering in een gedeelde serveromgeving**
We raden sterk aan om alle Aspose .NET‑componenten uit te voeren met de **Full Trust**‑machtigingsinstelling, omdat Aspose‑componenten soms registerinstellingen en bestanden buiten de virtuele map moeten benaderen — bijvoorbeeld wanneer lettertypen moeten worden gelezen.

Bovendien zijn Aspose.NET‑componenten gebaseerd op de kern‑.NET‑systeemplassen, en sommige van deze klassen vereisen ook Full Trust‑machtigingen voor bepaalde bewerkingen.

Internet Service Providers die meerdere applicaties van verschillende bedrijven hosten, handhaven meestal het **Medium Trust**‑beveiligingsniveau. In .NET 2.0‑scenario’s kan een dergelijk beveiligingsniveau leiden tot beperkingen die de werking van Aspose.Slides beïnvloeden:

- **RegistryPermission** is niet beschikbaar. Je kunt dus niet bij het register, wat nodig is om geïnstalleerde lettertypen op te sommen bij het renderen van documenten.
- **FileIOPermission** is beperkt. Je hebt alleen toegang tot bestanden binnen de virtuele maphiërarchie van je applicatie. Dit betekent mogelijk dat lettertypen niet kunnen worden gelezen tijdens exportbewerkingen.

Om deze redenen raden wij sterk aan om Aspose.Slides uit te voeren met **Full Trust**‑machtigingen. Als je **Medium Trust** gebruikt, kun je inconsistenties ondervinden — sommige bibliotheekfuncties (bijvoorbeeld renderen) werken mogelijk niet bij bepaalde taken.

## **Linux**

NuGet biedt de eenvoudigste manier om Aspose.Slides voor .NET op Linux te downloaden en te installeren. Voeg het [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)‑pakket toe aan je .NET‑project.

## **macOS**

NuGet biedt de eenvoudigste manier om Aspose.Slides voor .NET op Macs te downloaden en te installeren.

### **Aspose.Slides installeren**

1. Open Visual Studio.  
2. Maak een eenvoudige console‑applicatie of open een bestaand project.  
3. Ga via **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Typ *Aspose.Slides* in het zoekveld.  
5. Klik op **Aspose.Slides for .NET** en daarna op **Add Package**.  
6. Voeg een eenvoudige code‑fragment toe.  
   * Je kunt de code kopiëren van [deze pagina](/slides/nl/net/create-presentation/).  
7. Voer de app uit.  
8. Open de *folder/bin/Debug/presentation_file_name* van je project.

## **FAQ**

**Is er een gratis versie of een proefbeperking?**

Ja, standaard draait Aspose.Slides in evaluatiemodus, waardoor er watermerken worden geplaatst en er andere beperkingen kunnen gelden. Om de beperkingen te verwijderen, moet je een geldige [licentie](/slides/nl/net/licensing/) toepassen.