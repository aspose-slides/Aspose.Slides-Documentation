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
description: "Zjistěte, jak rychle nainstalovat Aspose.Slides pro .NET. Průvodce krok za krokem, systémové požadavky a ukázky kódu — začněte dnes pracovat s prezentacemi PowerPoint!"
---
## **Přehled**

Tento článek popisuje, jak nainstalovat Aspose.Slides pro .NET na Windows, Linux a macOS. Zaměřuje se na instalaci pomocí NuGet a ukazuje, jak přidat knihovnu přes NuGet Package Manager nebo Package Manager Console ve Windows, do projektu .NET na Linuxu a do projektu Visual Studio na macOS. Také popisuje, jak aktualizovat balíček a instalovat předběžná vydání, pokud je to potřeba.

Před instalací si prostudujte podporované operační systémy, implementace .NET a další závislosti v [System Requirements](/slides/cs/net/system-requirements/).

## **Windows**
NuGet poskytuje nejjednodušší způsob, jak stáhnout a nainstalovat Aspose API pro .NET na PC. 

### **Metoda 1: Instalace nebo aktualizace Aspose.Slides pomocí NuGet Package Manager**

1. Otevřete Microsoft Visual Studio. 
2. Vytvořte jednoduchou konzolovou aplikaci nebo otevřete existující projekt. 
3. Přejděte na **Tools** > **NuGet package manager**.
4. V sekci **Browse** vyhledejte *Aspose Slides* v textovém poli. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klikněte na **Aspose.Slides.NET** a poté na **Install**. 
   * Pokud chcete aktualizovat Aspose.Slides — předpokládáme, že již byl nainstalován — klikněte místo toho na **Update**. 

Vybraný API se stáhne a přidá jako reference do vašeho projektu.

### **Metoda 2: Instalace nebo aktualizace Aspose.Slides pomocí Package Manager Console**

Tímto způsobem odkazujete na [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) prostřednictvím konzole správce balíčků:

1. Otevřete Microsoft Visual Studio. 
2. Vytvořte jednoduchou konzolovou aplikaci nebo otevřete existující projekt. 
3. Přejděte na **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Spusťte tento příkaz: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Nejnovější plná verze se nainstaluje do vaší aplikace. 

* Případně můžete k příkazu přidat příponu `-prerelease`, abyste specifikovali, že má být nainstalována také nejnovější verze včetně hotfixů.

Tip **Installing Aspose.Slides.NET** se zobrazí ve spodní části okna. 
![todo:image_alt_text](installation_4.png)

Jakmile se stahování dokončí, zobrazí se několik potvrzovacích zpráv. 

Pokud nejste obeznámeni s [Aspose EULA](https://about.aspose.com/legal/eula), můžete si přečíst licenční podmínky uvedené v URL. 
![todo:image_alt_text](installation_5.png)

Ve vaší aplikaci byste měli vidět, že Aspose.Slides byl úspěšně přidán a je referencován. 
![todo:image_alt_text](installation_6.png)

V Package Manager Console můžete spustit příkaz `Update-Package Aspose.Slides.NET` pro kontrolu aktualizací balíčku Aspose.Slides. Aktualizace (pokud jsou nalezeny) se nainstalují automaticky. Také můžete použít příponu `-prerelease` k aktualizaci nejnovější verze.
#### **Úvahy pro provoz na sdíleném serverovém prostředí**
Důrazně doporučujeme spouštět všechny komponenty Aspose .NET s nastavením oprávnění **Full Trust**, protože komponenty Aspose někdy potřebují přístup k registru a souborům umístěným mimo virtuální adresář — například když komponenty Aspose musí číst písma. 

Dále jsou komponenty Aspose.NET založeny na základních .NET systémových třídách — a některé z těchto tříd také vyžadují oprávnění Full Trust pro operace v určitých případech.

Poskytovatelé internetových služeb, kteří hostují více aplikací od různých firem, většinou uplatňují úroveň zabezpečení Medium Trust. V případě .NET 2.0 může taková úroveň zabezpečení vést k omezením, která ovlivňují operace Aspose.Slides:

- **RegistryPermission** není dostupné. To znamená, že nelze přistupovat k registru, který je potřebný pro výčet nainstalovaných písem při vykreslování dokumentů.
- **FileIOPermission** je omezené. To znamená, že můžete přistupovat pouze k souborům ve virtuálním adresářovém hierarchii vaší aplikace. To také potenciálně znamená, že písma nelze číst během exportních operací. 

Z výše uvedených důvodů důrazně doporučujeme spouštět Aspose.Slides s oprávněním **Full Trust**. Pokud použijete **Medium trust**, můžete zaznamenat nesrovnalosti — některé funkce knihovny (například vykreslování) nemusí fungovat při provádění určitých úkolů. 

## **Linux**

NuGet poskytuje nejjednodušší způsob, jak stáhnout a nainstalovat Aspose.Slides pro .NET na Linuxu. Přidejte balíček [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) do vašeho .NET projektu.

## **macOS**

NuGet poskytuje nejjednodušší způsob, jak stáhnout a nainstalovat Aspose.Slides pro .NET na macOS.

### **Instalace Aspose.Slides**

1. Otevřete Visual Studio. 
2. Vytvořte jednoduchou konzolovou aplikaci nebo otevřete existující projekt.
3. Přejděte na **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Do textového pole zadejte *Aspose.Slides*. 
5. Klikněte na **Aspose.Slides for .NET** a poté na **Add Package**. 
6. Přidejte jednoduchý úryvek kódu.
   * Kód můžete zkopírovat na [této stránce](/slides/cs/net/create-presentation/).
7. Spusťte aplikaci.
8. Otevřete složku *folder/bin/Debug/presentation_file_name* vašeho projektu.

## **FAQ**

**Existuje bezplatná verze nebo omezení zkušební verze?**

Ano, ve výchozím nastavení běží Aspose.Slides v režimu hodnocení, který přidává vodoznaky a může mít další omezení. Pro odstranění omezení musíte použít platnou [licenci](/slides/cs/net/licensing/).