---
title: Installatie
type: docs
weight: 70
url: /nl/cpp/installation/
keywords:
- installeren Aspose.Slides
- downloaden Aspose.Slides
- gebruiken Aspose.Slides
- Aspose.Slides installatie
- Windows
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u snel Aspose.Slides voor C++ kunt installeren. Stapsgewijze handleiding, systeemvereisten en code-voorbeelden — begin vandaag nog met het werken aan PowerPoint-presentaties!"
---
## **Overzicht**

Dit artikel legt uit hoe je Aspose.Slides op Windows installeert. Het richt zich op een NuGet‑gebaseerde installatie en toont hoe je de bibliotheek toevoegt aan een Visual Studio‑project, hetzij via de NuGet Package Manager, hetzij via de Package Manager Console op Windows. Het beschrijft ook hoe je het pakket bijwerkt en prerelease‑builds installeert wanneer dat nodig is.

## **Windows**
NuGet biedt de eenvoudigste manier om Aspose‑API’s voor C++ op pc’s te downloaden en te installeren. 

### **Optie één: Installeer of werk Aspose.Slides voor C++ bij via de NuGet Package Manager**

1. Open Microsoft Visual Studio. 
2. Maak een eenvoudige console‑applicatie. Of je kunt je voorkeursproject openen. 
3. Ga via **Tools** > **NuGet package manager**.
4. Typ onder **Browse** *Aspose.Slides.Cpp* in het tekstvak. 

![todo:image_alt_text](installation_1.png)

3. Klik op de versie die je nodig hebt **Aspose.Slides.Cpp** en klik vervolgens op **Install**. 
   * Als je Aspose.Slides wilt bijwerken — wat betekent dat je het al geïnstalleerd hebt—klik dan op **Update**. 

De geselecteerde API wordt gedownload en aan je project toegevoegd.

### **Optie 2: Installeer of werk Aspose.Slides bij via de Package Manager Console**

Om de [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) te refereren via de package manager console, doe je het volgende:

1. Open je solution/project in Visual Studio.

1. Ga via **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

   De Package Manager Console wordt geopend. 

![todo:image_alt_text](installation_2.png)

4. Typ dit commando: `Install-Package Aspose.Slides.Cpp` 
> Als je de x86‑versie wilt installeren, gebruik dan het Aspose.Slides.Cpp.x86‑pakket: `Install-Package Aspose.Slides.Cpp.x86`

5. Druk op de Enter‑toets.

   De nieuwste volledige release wordt in je applicatie geïnstalleerd. 

   * Als alternatief kun je de `-prerelease`‑optie aan het commando toevoegen om aan te geven dat de nieuwste release (inclusief hotfixes) eveneens geïnstalleerd moet worden.

![todo:image_alt_text](installation_3.png)

​Zodra de download voltooid is, zie je enkele bevestigings‑berichten.  

![todo:image_alt_text](installation_4.png)

Als je niet bekend bent met de [Aspose EULA](https://about.aspose.com/legal/eula), wil je misschien de in de URL genoemde licentie lezen.

In de Package Manager Console kun je het commando `Update-Package Aspose.Slides.Cpp` uitvoeren om te controleren op updates voor het Aspose.Slides‑pakket. Updates (indien gevonden) worden automatisch geïnstalleerd. Je kunt ook de `-prerelease`‑optie gebruiken om de nieuwste release bij te werken.


### **Gebruik van Include‑ en lib‑mappen**
1. [Download](https://downloads.aspose.com/slides/nl/cpp) de nieuwste versie van Aspose.Slides voor C++.
1. Pak de map uit naar de productie‑omgeving.
1. Om Aspose.Slides voor C++ te gebruiken, verwijs je naar de Include‑ en lib‑mappen in je project

## **FAQ**

**Is er een gratis versie of proefbeperking?**

Ja, standaard draait Aspose.Slides in evaluatiemodus, waardoor er watermerken worden geplaatst en er mogelijk andere beperkingen zijn. Om de beperkingen te verwijderen, moet je een geldige [license](/slides/nl/cpp/licensing/) toepassen.