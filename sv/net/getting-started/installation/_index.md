---
title: Installation
type: docs
weight: 70
url: /sv/net/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- installation av Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du snabbt installerar Aspose.Slides för .NET. Steg-för-steg-guide, systemkrav och kodexempel — börja arbeta med PowerPoint-presentationer redan idag!"
---
## **Översikt**

Den här artikeln förklarar hur man installerar Aspose.Slides för .NET på Windows och macOS. Den fokuserar på NuGet‑baserad installation och visar hur man lägger till biblioteket i ett Visual Studio‑projekt antingen via NuGet Package Manager eller Package Manager Console på Windows. Den beskriver också hur man uppdaterar paketet och installerar förhandsutgåvor när så behövs.

## **Windows**
NuGet erbjuder det enklaste sättet att ladda ner och installera Aspose‑API:er för .NET på PC‑datorer. 

### **Metod 1: Installera eller uppdatera Aspose.Slides från NuGet Package Manager**

1. Öppna Microsoft Visual Studio. 
2. Skapa en enkel konsolapp eller öppna ett befintligt projekt. 
3. Gå via **Tools** > **NuGet package manager**. 
4. Under **Browse**, sök efter *Aspose Slides* i textfältet. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klicka på **Aspose.Slides.NET** och klicka sedan på **Install**. 
   * Om du vill uppdatera Aspose.Slides—förutsatt att du redan har installerat det—klicka **Update** istället. 

Det valda API‑et laddas ner och refereras i ditt projekt.

### **Metod 2: Installera eller uppdatera Aspose.Slides via Package Manager Console**

Så här refererar du [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) via paket‑hanteringskonsolen:

1. Öppna Microsoft Visual Studio. 
2. Skapa en enkel konsolapp eller öppna ett befintligt projekt. 
3. Gå via **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Kör följande kommando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Den senaste fullständiga versionen installeras i din applikation. 

* Alternativt kan du lägga till suffixet `-prerelease` till kommandot för att ange att även den senaste utgåvan (inklusive hotfixar) ska installeras.

Tipsen **Installing Aspose.Slides.NET** visas längst ner i fönstret. 
![todo:image_alt_text](installation_4.png)

När nedladdningen är klar bör du se några bekräftelsemeddelanden. 

Om du inte är bekant med [Aspose EULA](https://about.aspose.com/legal/eula) vill du kanske läsa licensen som refereras i URL‑en. 
![todo:image_alt_text](installation_5.png)

I din applikation bör du se att Aspose.Slides har lagts till och refererats korrekt. 
![todo:image_alt_text](installation_6.png)

I Package Manager Console kan du köra kommandot `Update-Package Aspose.Slides.NET` för att kontrollera om det finns uppdateringar av Aspose.Slides‑paketet. Uppdateringar (om några finns) installeras automatiskt. Du kan också använda suffixet `-prerelease` för att uppdatera den senaste utgåvan.
#### **Överväganden vid körning i en delad servermiljö**
Vi rekommenderar starkt att du kör alla Aspose‑.NET‑komponenter med **Full Trust**‑behörighetsuppsättning eftersom Aspose‑komponenter ibland behöver komma åt registerinställningar och filer som ligger på andra ställen än den virtuella katalogen — till exempel när Aspose‑komponenter måste läsa teckensnitt. 

Dessutom är Aspose.NET‑komponenter baserade på .NET‑kärnklasser, och vissa av dessa klasser kräver också Full Trust‑behörighet för vissa operationer. 

Internetleverantörer som hostar flera applikationer från olika företag använder oftast säkerhetsnivån Medium Trust. I .NET 2.0‑fallet kan en sådan säkerhetsnivå leda till begränsningar som påverkar Aspose.Slides‑operationer:

- **RegistryPermission** är inte tillgänglig. Det betyder att du inte kan komma åt registret, vilket krävs för att lista installerade teckensnitt vid rendering av dokument. 
- **FileIOPermission** är begränsad. Det betyder att du endast kan komma åt filer i din applikations virtuella katalognivå. Detta kan också innebära att teckensnitt inte kan läsas under exportoperationer. 

Av de ovanstående skälen rekommenderar vi starkt att du kör Aspose.Slides med **Full Trust**‑behörigheter. Om du använder **Medium trust** kan du uppleva inkonsekvenser — vissa biblioteksegenskaper (t.ex. rendering) kanske inte fungerar när du utför vissa uppgifter. 

## **macOS**

NuGet erbjuder det enklaste sättet att ladda ner och installera Aspose.Slides för .NET på mac‑datorer. 

**Installera förutsättningar**

`System.Drawing`‑namnutrymmet fungerar annorlunda i macOS, så du måste installera mono‑libgdiplus. 

> I .NET 5 och tidigare versioner fungerar NuGet‑paketet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) på Windows, Linux och macOS. Det finns dock plattforms­skillnader. På Linux och macOS implementeras GDI+‑funktionaliteten av biblioteket [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/). Detta bibliotek installeras inte som standard i de flesta Linux‑distributioner och stödjer inte all funktionalitet i GDI+ på Windows och macOS. Det finns även plattformar där libgdiplus inte alls är tillgängligt. För att använda typer från System.Drawing.Common‑paketet på Linux och macOS måste du installera libgdiplus separat. För mer information, se [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) eller [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus). 

För att installera mono‑libgdiplus separat på din mac, se [denna artikel](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) från .NET‑dokumentationen. 

### **Installera Aspose.Slides**

1. Öppna Visual Studio. 
2. Skapa en enkel konsolapp eller öppna ett befintligt projekt. 
3. Gå via **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Skriv *Aspose.Slides* i textfältet. 
5. Klicka på **Aspose.Slides for .NET** och klicka sedan på **Add Package**. 
6. Lägg till ett enkelt kodexempel.  
   * Du kan kopiera koden på [den här sidan](/slides/sv/net/create-presentation/). 
7. Kör appen. 
8. Öppna ditt projekts *folder/bin/Debug/presentation_file_name*. 

## **FAQ**

**Finns det en gratis version eller begränsning i provversionen?**

Ja, som standard kör Aspose.Slides i utvärderingsläge, vilket lägger till vattenstämplar och kan ha andra begränsningar. För att ta bort begränsningarna måste du tillämpa en giltig [licens](/slides/sv/net/licensing/).