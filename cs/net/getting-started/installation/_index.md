---
title: Instalace
type: docs
weight: 70
url: /cs/net/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nainstalujte Aspose.Slides pro .NET z NuGet ve Windows, Linuxu a macOS: vyberte jeden ze dvou balíčků, přidejte jej pomocí .NET CLI nebo Visual Studio a nainstalujte předpoklady pro Linux."
---
## **Přehled**

Tento článek vysvětluje, jak přidat Aspose.Slides pro .NET do projektu ve Windows, Linuxu a macOS. Aspose.Slides je distribuován prostřednictvím NuGet. Můžete jej přidat pomocí .NET CLI na libovolném operačním systému nebo pomocí Správce balíčků NuGet nebo konzole Správce balíčků ve Visual Studio ve Windows. Článek také popisuje, který ze dvou NuGet balíčků zvolit a co dalšího Linux potřebuje.

Před instalací si prostudujte podporované operační systémy, implementace .NET a další závislosti v [System Requirements](/slides/cs/net/system-requirements/).

## **Vyberte balíček**

Aspose.Slides pro .NET je vydán jako dva NuGet balíčky. Oba poskytují stejné jmenné prostory a třídy Aspose.Slides, takže se váš kód při přepínání mezi nimi nemění; liší se pouze odkaz na balíček a požadavky na platformu.

| Balíček | Použít pro | Další požadavky |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Aplikace Windows a .NET Framework | Na Linuxu a macOS: knihovna `libgdiplus` a přepínač `System.Drawing.EnableUnixSupport` povolený při spuštění aplikace |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 nebo novější na Windows, Linuxu a macOS | Na Linuxu: knihovna `fontconfig`, pokud již není nainstalována |

Pokud si nejste jisti, použijte Aspose.Slides.NET ve Windows a Aspose.Slides.NET6.CrossPlatform na Linuxu a macOS. Na Alpine Linux a na Linuxových systémech, jejichž glibc je starší než 2.23 (x64) nebo 2.39 (ARM64), použijte místo toho Aspose.Slides.NET. [System Requirements](/slides/cs/net/system-requirements/) uvádí podporované platformy každého balíčku.

## **Instalace pomocí .NET CLI**

Tyto kroky fungují ve Windows, Linuxu a macOS s .NET SDK 6 nebo novějším. Vytvořte konzolovou aplikaci:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Poté přidejte balíček pro vaši platformu. Do projektu přidejte pouze jeden ze dvou balíčků.

- Na Windows: `dotnet add package Aspose.Slides.NET`
- Na Linuxu a macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (na Linuxu nejprve nainstalujte předpoklad; viz [Linux](#linux))

Pro ověření, že balíček funguje, nahraďte obsah souboru *Program.cs* prvním příkladem v [Create Presentations](/slides/cs/net/create-presentation/) a spusťte `dotnet run`. Uloží *hello.pptx* do složky projektu.

## **Windows**

### **Metoda 1: Instalace nebo aktualizace Aspose.Slides pomocí Správce balíčků NuGet**

1. Otevřete Microsoft Visual Studio.
2. Vytvořte konzolovou aplikaci nebo otevřete existující projekt.
3. V **Solution Explorer** klikněte pravým tlačítkem na projekt a vyberte **Manage NuGet Packages** (nebo přejděte na **Project** > **Manage NuGet Packages**).
4. V sekci **Browse** vyhledejte *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klikněte na **Aspose.Slides.NET** a poté klikněte na **Install**.
   * Pokud jste již Aspose.Slides nainstalovali a chcete jej aktualizovat, klikněte místo toho na **Update**.

Balíček je stažen a přidán do vašeho projektu.

### **Metoda 2: Instalace nebo aktualizace Aspose.Slides pomocí konzole Správce balíčků**

Takto odkazujete na balíček [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) pomocí konzole Správce balíčků:

1. Otevřete Microsoft Visual Studio.
2. Vytvořte konzolovou aplikaci nebo otevřete existující projekt.
3. Přejděte na **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Opening the Package Manager Console](installation_2.png)
4. Spusťte tento příkaz: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
Nejnovější verze je nainstalována ve vašem projektu.

Zpráva **Installing Aspose.Slides.NET** se zobrazí v dolní části okna.
![Installation progress in the Package Manager Console](installation_4.png)

Po dokončení stahování se zobrazí potvrzovací zprávy. Balíček je distribuován pod [Aspose EULA](https://about.aspose.com/legal/eula).
![Installation confirmation messages](installation_5.png)

Aspose.Slides je nyní přidán do vašeho projektu a odkazován.
![Aspose.Slides referenced in the project](installation_6.png)

Pro aktualizaci balíčku spusťte `Update-Package Aspose.Slides.NET` v konzole Správce balíčků.

## **Linux**

Použijte výše uvedené kroky .NET CLI. Zvolte balíček a nainstalujte jeho předpoklad pomocí správce balíčků vaší distribuce. V Debianu a Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: nainstalujte `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: nainstalujte `libgdiplus` a povolte Unix podporu pro System.Drawing před tím, než vaše aplikace použije Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

Přidejte tento příkaz na začátek vaší aplikace, před jakýmkoli voláním Aspose.Slides. V *Program.cs* s příkazy na nejvyšší úrovni jej vložte po direktivách `using`:
```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

Používejte tento balíček na Alpine Linux a na systémech, jejichž glibc je příliš stará pro Aspose.Slides.NET6.CrossPlatform.

Fonty použité ve vašich prezentacích, nebo vhodné náhrady, musí být nainstalovány v systému, aby se text vykresloval správně. [System Requirements](/slides/cs/net/system-requirements/) popisuje balíčky, které Aspose.Slides.NET potřebuje na Alpine Linux, včetně fontů.

## **macOS**

Použijte výše uvedené kroky .NET CLI s balíčkem **Aspose.Slides.NET6.CrossPlatform**, který podporuje jak Intel (x86_64), tak Apple silicon (ARM64) počítače Mac:
```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Existuje bezplatná verze nebo omezení zkušební verze?**

Ano. Bez licence Aspose.Slides běží v evaluačním režimu: přidává evaluační vodoznak na každou snímek, který uloží, a zkracuje text načtený z prezentací. Pro odstranění těchto omezení použijte platnou [license](/slides/cs/net/licensing/).