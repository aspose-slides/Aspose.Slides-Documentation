---
title: Installation
type: docs
weight: 70
url: /sv/net/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du snabbt installerar Aspose.Slides för .NET. Steg-för-steg-guide, systemkrav och kodexempel — börja arbeta med PowerPoint-presentationer idag!"
---
## **Översikt**

Denna artikel förklarar hur du installerar Aspose.Slides för .NET på Windows, Linux och macOS. Den fokuserar på NuGet‑baserad installation och visar hur du lägger till biblioteket via NuGet Package Manager eller Package Manager Console på Windows, i ett .NET‑projekt på Linux och i ett Visual Studio‑projekt på macOS. Den beskriver också hur du uppdaterar paketet och installerar förhandsutgåvor vid behov.

Innan installationen bör du gå igenom de stödjade operativsystemen, .NET‑implementationerna och ytterligare beroenden i [Systemkrav](/slides/sv/net/system-requirements/).

## **Windows**
NuGet erbjuder den enklaste vägen för att ladda ner och installera Aspose‑API:er för .NET på PC‑datorer. 

### **Metod 1: Installera eller uppdatera Aspose.Slides från NuGet Package Manager**

1. Öppna Microsoft Visual Studio. 
2. Skapa en enkel konsolapp eller öppna ett befintligt projekt. 
3. Gå via **Tools** > **NuGet package manager**.
4. Under **Browse**, sök efter *Aspose Slides* i textrutan. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klicka på **Aspose.Slides.NET** och sedan på **Install**. 
   * Om du vill uppdatera Aspose.Slides — förutsatt att du redan har installerat det — klicka på **Update** istället. 

Det valda API‑et laddas ner och refereras i ditt projekt.

### **Metod 2: Installera eller uppdatera Aspose.Slides via Package Manager Console**

Så här refererar du [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) via pakethanterarkonsolen:

1. Öppna Microsoft Visual Studio. 
2. Skapa en enkel konsolapp eller öppna ett befintligt projekt. 
3. Gå via **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Kör detta kommando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Den senaste fullständiga utgåvan installeras i din applikation. 

* Alternativt kan du lägga till suffixet `-prerelease` till kommandot för att ange att den senaste utgåvan (inklusive hotfixar) också ska installeras som väl. 

Tipset **Installing Aspose.Slides.NET** visas nära botten av fönstret. 
![todo:image_alt_text](installation_4.png)

När nedladdningen är klar bör du se några bekräftelsemeddelanden. 

Om du inte är bekant med [Aspose EULA](https://about.aspose.com/legal/eula) kan du vilja läsa licensen som refereras i URL:en. 
![todo:image_alt_text](installation_5.png)

I din applikation borde du se att Aspose.Slides har lagts till och refererats framgångsrikt. 
![todo:image_alt_text](installation_6.png)

I Package Manager Console kan du köra kommandot `Update-Package Aspose.Slides.NET` för att söka efter uppdateringar till Aspose.Slides‑paketet. Uppdateringar (om de finns) installeras automatiskt. Du kan också använda suffixet `-prerelease` för att uppdatera den senaste utgåvan.
#### **Överväganden vid körning i en delad servermiljö**
Vi rekommenderar starkt att du kör alla Aspose .NET‑komponenter med behörighetsinställningen **Full Trust**, eftersom Aspose‑komponenter ibland måste komma åt registerinställningar och filer på andra platser än den virtuella katalogen — till exempel när Aspose‑komponenter måste läsa teckensnitt. 

Dessutom är Aspose.NET‑komponenter baserade på de centrala .NET‑systemklasserna — och vissa av dessa klasser kräver också Full Trust‑behörighet för operationer i vissa fall.

Internetleverantörer, som är värdar för flera applikationer från olika företag, upprätthåller ofta säkerhetsnivån Medium Trust. I .NET 2.0‑fallet kan en sådan säkerhetsnivå leda till begränsningar som påverkar Aspose.Slides‑operationer:

- **RegistryPermission** är inte tillgänglig. Detta betyder att du inte kan komma åt registret, vilket krävs för att lista installerade teckensnitt vid rendering av dokument.
- **FileIOPermission** är begränsad. Detta betyder att du bara kan komma åt filer i din applikations virtuella kataloghierarki. Detta kan också innebära att teckensnitt inte kan läsas under exportoperationer. 

Av de ovanstående skälen rekommenderar vi starkt att du kör Aspose.Slides med **Full Trust**‑behörigheter. Om du använder **Medium trust** kan du uppleva inkonsekvenser — vissa biblioteksegenskaper (t.ex. rendering) kanske inte fungerar när du utför vissa uppgifter. 

## **Linux**

NuGet erbjuder den enklaste vägen för att ladda ner och installera Aspose.Slides för .NET på Linux. Lägg till paketet [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) i ditt .NET‑projekt.

## **macOS**

NuGet erbjuder den enklaste vägen för att ladda ner och installera Aspose.Slides för .NET på Mac-datorer.

### **Installera Aspose.Slides**

1. Öppna Visual Studio. 
2. Skapa en enkel konsolapp eller öppna ett befintligt projekt.
3. Gå via **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Skriv *Aspose.Slides* i textrutan. 
5. Klicka på **Aspose.Slides for .NET** och sedan på **Add Package.** 
6. Lägg till ett enkelt kodexempel.
   * Du kan kopiera koden på [denna sida](/slides/sv/net/create-presentation/).
7. Kör appen.
8. Öppna ditt projekts *folder/bin/Debug/presentation_file_name*.

## **FAQ**

**Finns det en gratis version eller begränsning för provperioden?**

Ja, som standard kör Aspose.Slides i utvärderingsläge, vilket lägger till vattenmärken och kan ha andra begränsningar. För att ta bort restriktionerna måste du tillämpa en giltig [licens](/slides/sv/net/licensing/).