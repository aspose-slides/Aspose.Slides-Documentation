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
description: "Installera Aspose.Slides för .NET från NuGet på Windows, Linux och macOS: välj mellan de två paketen, lägg till ett med .NET CLI eller Visual Studio och installera Linux-förutsättningarna."
---
## **Översikt**

Denna artikel förklarar hur du lägger till Aspose.Slides för .NET i ett projekt på Windows, Linux och macOS. Aspose.Slides distribueras via NuGet. Du kan lägga till det med .NET CLI på alla operativsystem, eller med NuGet Package Manager eller Package Manager Console i Visual Studio på Windows. Artikeln förklarar också vilket av de två NuGet-paketen du ska välja och vad Linux behöver utöver detta.

Innan installationen, gå igenom de stödjade operativsystemen, .NET-implementationerna och ytterligare beroenden i [Systemkrav](/slides/sv/net/system-requirements/).

## **Välj ett paket**

Aspose.Slides för .NET publiceras som två NuGet-paket. Båda tillhandahåller samma Aspose.Slides-rymder och -klasser, så din kod ändras inte när du byter mellan dem; endast paketreferensen och plattformskraven skiljer sig.

| Paket | Användning | Ytterligare krav |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows‑ och .NET Framework‑applikationer | På Linux och macOS: `libgdiplus`‑biblioteket och `System.Drawing.EnableUnixSupport`‑växeln aktiverad vid applikationsstart |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 eller senare på Windows, Linux och macOS | På Linux: `fontconfig`‑biblioteket, om det inte redan är installerat |

Om du är osäker, använd Aspose.Slides.NET på Windows och Aspose.Slides.NET6.CrossPlatform på Linux och macOS. På Alpine Linux och på Linux‑system vars glibc är äldre än 2.23 (x64) eller 2.39 (ARM64), använd Aspose.Slides.NET istället. [Systemkrav](/slides/sv/net/system-requirements/) listar de stödda plattformarna för varje paket.

## **Installera med .NET CLI**

Dessa steg fungerar på Windows, Linux och macOS med .NET SDK 6 eller senare. Skapa en konsolapplikation:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Lägg sedan till paketet för din plattform. Lägg bara till ett av de två paketen i ett projekt.

- På Windows: `dotnet add package Aspose.Slides.NET`
- På Linux och macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (på Linux, installera dess förutsättning först; se [Linux](#linux))

För att kontrollera att paketet fungerar, ersätt innehållet i *Program.cs* med det första exemplet i [Skapa presentationer](/slides/sv/net/create-presentation/) och kör `dotnet run`. Det sparar *hello.pptx* i projektmappen.

## **Windows**

### **Metod 1: Installera eller uppdatera Aspose.Slides från NuGet Package Manager**

1. Öppna Microsoft Visual Studio.
2. Skapa en konsolapp eller öppna ett befintligt projekt.
3. I **Solution Explorer**, högerklicka på projektet och välj **Manage NuGet Packages** (eller gå till **Project** > **Manage NuGet Packages**).
4. Under **Browse**, sök efter *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klicka på **Aspose.Slides.NET** och klicka sedan på **Install**.
   * Om du redan har installerat Aspose.Slides och vill uppdatera det, klicka på **Update** istället.

Paketet har hämtats och refereras i ditt projekt.

### **Metod 2: Installera eller uppdatera Aspose.Slides via Package Manager Console**

Så här refererar du paketet [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) via Package Manager Console:

1. Öppna Microsoft Visual Studio.
2. Skapa en konsolapp eller öppna ett befintligt projekt.
3. Gå till **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Öppna Package Manager Console](installation_2.png)
4. Kör detta kommando: `Install-Package Aspose.Slides.NET`
![Kör Install-Package-kommandot](installation_3.png)
Den senaste utgåvan är installerad i ditt projekt.

Meddelandet **Installing Aspose.Slides.NET** visas nära botten av fönstret.
![Installationsförlopp i Package Manager Console](installation_4.png)

När nedladdningen är klar visas bekräftelsemeddelanden. Paketet distribueras under [Aspose EULA](https://about.aspose.com/legal/eula).
![Bekräftelsemeddelanden för installation](installation_5.png)

Aspose.Slides har nu lagts till i ditt projekt och refereras.
![Aspose.Slides refererad i projektet](installation_6.png)

För att uppdatera paketet, kör `Update-Package Aspose.Slides.NET` i Package Manager Console.

## **Linux**

Använd .NET CLI-stegen ovan. Välj paketet och installera dess förutsättning med din distributionens pakethanterare. På Debian och Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: installera `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: installera `libgdiplus` och aktivera Unix‑stöd för System.Drawing innan din applikation använder Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

Lägg till detta uttalande i början av din applikation, före något Aspose.Slides‑anrop. I en *Program.cs* med top‑level‑satser, placera det efter `using`‑direktiven:

```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

Använd detta paket på Alpine Linux och på system vars glibc är för gammal för Aspose.Slides.NET6.CrossPlatform.

Teckensnitten som används i dina presentationer, eller lämpliga ersättningar, måste vara installerade på systemet för att texten ska renderas korrekt. [Systemkrav](/slides/sv/net/system-requirements/) beskriver de paket som Aspose.Slides.NET behöver på Alpine Linux, inklusive teckensnitt.

## **macOS**

Använd .NET CLI-stegen ovan med **Aspose.Slides.NET6.CrossPlatform**‑paketet, som stödjer både Intel (x86_64) och Apple silicon (ARM64) Macs:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Finns det en gratis version eller begränsning i provperioden?**

Ja. Utan en licens kör Aspose.Slides i utvärderingsläge: den lägger till ett utvärderingsvattenmärke på varje bild den sparar och trunkerar text som läses från presentationer. För att ta bort dessa begränsningar, tillämpa en giltig [licens](/slides/sv/net/licensing/).