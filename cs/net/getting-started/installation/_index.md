---
title: Instalace
type: docs
weight: 70
url: /cs/net/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- používat Aspose.Slides
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
description: "Zjistěte, jak rychle nainstalovat Aspose.Slides pro .NET. Podrobný průvodce, systémové požadavky a ukázky kódu — začněte ještě dnes pracovat s prezentacemi PowerPoint!" 
---
## **Přehled**

Tento článek popisuje, jak nainstalovat Aspose.Slides pro .NET ve Windows i macOS. Soustředí se na instalaci prostřednictvím NuGet a ukazuje, jak přidat knihovnu do projektu ve Visual Studiu buď pomocí správce balíčků NuGet, nebo přes konzoli správce balíčků ve Windows. Dále popisuje, jak aktualizovat balíček a instalovat předběžné verze, pokud je to potřeba.

## **Windows**
NuGet poskytuje nejnávrhovější cestu ke stažení a instalaci Aspose API pro .NET na počítačích.

### **Metoda 1: Instalace nebo aktualizace Aspose.Slides přes správce balíčků NuGet**

1. Otevřete Microsoft Visual Studio.  
2. Vytvořte jednoduchou konzolovou aplikaci nebo otevřete existující projekt.  
3. Přesuňte se na **Tools** > **NuGet package manager**.  
4. V sekci **Browse** vyhledejte *Aspose Slides* v textovém poli.  
{{% image img="installation_1.png" alt="Instalace Aspose.Slides z NuGet Package Manager – 1" %}}
5. Klikněte na **Aspose.Slides.NET** a poté klikněte na **Install**.  
   * Pokud chcete aktualizovat Aspose.Slides – předpokládáme, že je již nainstalováno – klikněte místo toho na **Update**.

Vybraný API se stáhne a odkáže do vašeho projektu.

### **Metoda 2: Instalace nebo aktualizace Aspose.Slides přes konzoli správce balíčků**

Toto je způsob, jak odkazovat na [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) pomocí konzole správce balíčků:

1. Otevřete Microsoft Visual Studio.  
2. Vytvořte jednoduchou konzolovou aplikaci nebo otevřete existující projekt.  
3. Přesuňte se na **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Spusťte tento příkaz: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
Nejnovější plná verze se nainstaluje do vaší aplikace.  

* Případně můžete k příkazu přidat příponu `-prerelease`, aby se nainstalovala také nejnovější předběžná verze (včetně oprav).

 Tip **Installing Aspose.Slides.NET** se zobrazí poblíž spodní části okna.  
![todo:image_alt_text](installation_4.png)

Po dokončení stahování by se měly zobrazit potvrzující zprávy.  

Pokud neznáte [Aspose EULA](https://about.aspose.com/legal/eula), můžete si přečíst licenci uvedenou v URL.  
![todo:image_alt_text](installation_5.png)

Ve vaší aplikaci by se mělo zobrazit, že Aspose.Slides byl úspěšně přidán a odkazován.  
![todo:image_alt_text](installation_6.png)

V konzoli správce balíčků můžete spustit příkaz `Update-Package Aspose.Slides.NET` a zkontrolovat, zda jsou k dispozici aktualizace balíčku Aspose.Slides. Aktualizace (pokud jsou nalezeny) se nainstalují automaticky. Pro aktualizaci na nejnovější předběžnou verzi můžete také použít příponu `-prerelease`.

#### **Úvahy při provozu v prostředí sdíleného serveru**
Doporučujeme spouštět všechny komponenty Aspose .NET s nastavením oprávnění **Full Trust**, protože komponenty Aspose někdy potřebují přístup k nastavením registru a souborům umístěným mimo virtuální adresář – například když komponenty Aspose musí číst písma.

Dále jsou komponenty Aspose.NET postaveny na základních třídách .NET systému – a některé z těchto tříd také vyžadují oprávnění Full Trust pro operace v určitých případech.

Poskytovatelé internetových služeb, kteří hostují více aplikací od různých firem, obvykle vynucují úroveň zabezpečení Medium Trust. V případě .NET 2.0 může taková úroveň zabezpečení vést k omezením, která ovlivňují operace Aspose.Slides:

- **RegistryPermission** není k dispozici. To znamená, že nemáte přístup k registru, který je potřeba pro výčet nainstalovaných písem při vykreslování dokumentů.  
- **FileIOPermission** je omezeno. To znamená, že můžete přistupovat jen k souborům v hierarchii virtuálního adresáře vaší aplikace. To také může způsobit, že písma nelze přečíst během exportních operací.  

Z výše uvedených důvodů důrazně doporučujeme spouštět Aspose.Slides s oprávněními **Full Trust**. Pokud použijete **Medium Trust**, můžete zaznamenat nesrovnalosti – některé funkce knihovny (například vykreslování) nemusí fungovat při určitých úlohách.  

## **macOS**

NuGet poskytuje nejnávrhovější cestu ke stažení a instalaci Aspose.Slides pro .NET na počítačích Mac.

**Instalace předpokladu**

Namespace `System.Drawing` funguje v macOS odlišně, takže je nutné nainstalovat `mono-libgdiplus`.

> V .NET 5 a předchozích verzích funguje balíček [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) na Windows, Linuxu i macOS. Existují však platformní rozdíly. Na Linuxu a macOS je funkčnost GDI+ implementována knihovnou [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). Tato knihovna není ve výchozím nastavení nainstalována ve většině distribucí Linuxu a nepodporuje veškerou funkčnost GDI+ na Windows a macOS. Existují také platformy, kde libgdiplus není vůbec dostupná. Pro použití typů z balíčku System.Drawing.Common na Linuxu a macOS musíte libgdiplus nainstalovat samostatně. Další informace viz [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) nebo [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).

Pro samostatnou instalaci `mono-libgdiplus` na vašem Macu viz [tento článek](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) v dokumentaci .NET.

### **Instalace Aspose.Slides**

1. Otevřete Visual Studio.  
2. Vytvořte jednoduchou konzolovou aplikaci nebo otevřete existující projekt.  
3. Přesuňte se na **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Zadejte *Aspose.Slides* do textového pole.  
5. Klikněte na **Aspose.Slides for .NET** a poté klikněte na **Add Package**.  
6. Přidejte jednoduchý úryvek kódu.  
   * Kód můžete zkopírovat ze [této stránky](/slides/cs/net/create-presentation/).  
7. Spusťte aplikaci.  
8. Otevřete *folder/bin/Debug/presentation_file_name* vašeho projektu.

## **Často kladené otázky**

**Existuje bezplatná verze nebo omezení zkušební verze?**

Ano, ve výchozím nastavení funguje Aspose.Slides v režimu hodnocení, který přidává vodoznaky a může mít další omezení. Pro odebrání omezení musíte použít platnou [licenci](/slides/cs/net/licensing/).