---
title: Instala​ce
type: docs
weight: 70
url: /cs/cpp/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- Windows
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak rychle nainstalovat Aspose.Slides pro C++. Průvodce krok za krokem, systémové požadavky a ukázky kódu — začněte dnes pracovat s prezentacemi PowerPoint!"
---
## **Přehled**

Tento článek vysvětluje, jak nainstalovat Aspose.Slides na Windows. Soustředí se na instalaci pomocí NuGet a ukazuje, jak přidat knihovnu do projektu ve Visual Studio buď přes Správce balíčků NuGet, nebo přes Konzoli správce balíčků na Windows. Také popisuje, jak aktualizovat balíček a instalovat předběžné verze, pokud je to potřeba.

## **Windows**
NuGet poskytuje nejjednodušší cestu ke stažení a instalaci Aspose API pro C++ na PC. 

### **Možnost jedna: Instalace nebo aktualizace Aspose.Slides pro C++ pomocí Správce balíčků NuGet**

1. Otevřete Microsoft Visual Studio. 
2. Vytvořte jednoduchou konzolovou aplikaci. Nebo otevřete svůj preferovaný projekt. 
3. Přejděte přes **Tools** > **NuGet package manager**.
4. V sekci **Browse** zadejte *Aspose.Slides.Cpp* do textového pole. 

![todo:image_alt_text](installation_1.png)

3. Klikněte na požadovanou verzi **Aspose.Slides.Cpp** a poté klikněte na **Install**. 
   * Pokud chcete aktualizovat Aspose.Slides — což znamená, že jej již máte nainstalovaný — klikněte místo toho na **Update**. 

Vybrané API se stáhne a bude odkazováno ve vašem projektu.

### **Možnost 2: Instalace nebo aktualizace Aspose.Slides pomocí konzole správce balíčků**

Pro odkazování na [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) pomocí konzole správce balíčků proveďte následující:

1. Otevřete své řešení/projekt ve Visual Studio.

1. Přejděte přes **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

   Konzole správce balíčků se otevře. 

![todo:image_alt_text](installation_2.png)

4. Zadejte tento příkaz: `Install-Package Aspose.Slides.Cpp` 
> Pokud chcete nainstalovat verzi x86, použijte balíček Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Stiskněte klávesu Enter.

   Nejnovější plná verze se nainstaluje do vaší aplikace. 

   * Případně můžete k příkazu přidat příponu `-prerelease`, aby se nainstalovala také nejnovější verze (včetně oprav).

![todo:image_alt_text](installation_3.png)

​	Po dokončení stahování by se vám měly zobrazit potvrzovací zprávy.  

![todo:image_alt_text](installation_4.png)

Pokud nejste obeznámeni s [Aspose EULA](https://about.aspose.com/legal/eula), můžete si přečíst licenci uvedenou na této adrese. 

V konzole správce balíčků můžete spustit příkaz `Update-Package Aspose.Slides.Cpp` k prověření aktualizací balíčku Aspose.Slides. Aktualizace (pokud jsou k dispozici) se nainstalují automaticky. Také můžete použít příponu `-prerelease` k aktualizaci na nejnovější verzi.

### **Použití složek Include a lib**
1. [Download](https://downloads.aspose.com/slides/cs/cpp) nejnovější verzi Aspose.Slides pro C++.
1. Rozbalte složku do produkčního prostředí.
1. Pro použití Aspose.Slides pro C++ odkažte v projektu na složky Include a lib.

## **Často kladené otázky**

**Existuje bezplatná verze nebo omezení zkušební verze?**

Ano, ve výchozím nastavení běží Aspose.Slides v evaluačním režimu, který přidává vodoznaky a může mít další omezení. Pro odstranění omezení musíte použít platnou [licenci](/slides/cs/cpp/licensing/).