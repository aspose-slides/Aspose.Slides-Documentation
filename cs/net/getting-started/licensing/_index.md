---
title: Licencování
type: docs
weight: 80
url: /cs/net/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- licenční soubor
- evaluační verze
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro .NET. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává evaluační vodoznak při otevření nebo uložení prezentací a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence aplikována správně.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="primary" %}} 

Můžete si stáhnout evaluační verzi **Aspose.Slides for NET** z [její stránky pro stahování na NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou poté, co do ní přidáte několik řádků kódu (k aplikaci licence).

Jakmile budete spokojeni s evaluační verzí **Aspose.Slides**, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme projít různými typy předplatného. Máte-li otázky, obraťte se na prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné na bezplatné aktualizace na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty nebo i s evaluačními verzemi získají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení evaluační verze**

* Zatímco evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, vkládá evaluační vodoznak v horní části dokumentu při operacích otevření a uložení. 
* Jste omezeni na jeden snímek při extrakci textu z prezentačních snímků.

{{% alert color="primary" %}} 

Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Více informací naleznete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**
* Evaluační verze se stane licencovanou po zakoupení licence a přidání několika řádků kódu (k aplikaci licence).
* Licence je textový XML soubor, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licencována, datum vypršení předplatného a podobně. 
* Licenční soubor je digitálně podepsán, takže jej nesmíte měnit. I neúmyslné přidání dalšího řádku do obsahu souboru jej zneplatní.
* Aspose.Slides pro .NET obvykle hledá licenci na následujících místech:
  * Explicitní cesta
  * Složka obsahující DLL komponenty (zahrnutá v Aspose.Slides)
  * Složka obsahující sestavu, která volala DLL komponenty (zahrnutá v Aspose.Slides)
  * Složka obsahující vstupní sestavu (vaše .exe)
  * Vložený zdroj v sestavě, která volala DLL komponenty (zahrnutá v Aspose.Slides).
* Aby se předešlo omezením spojeným s evaluační verzí, je nutné nastavit licenci před použitím Aspose.Slides. Licenci je potřeba nastavit pouze jednou na aplikaci nebo proces.

{{% alert color="primary" %}} 

Možná budete chtít zobrazit [Měřené licencování](https://docs.aspose.com/slides/cs/net/metered-licensing/).

{{% /alert %}} 


## **Použití licence**
Licenci lze načíst ze **souboru**, **proudu** nebo **vloženého zdroje**. 

{{% alert color="primary" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/net/aspose.slides/license) pro operace s licencemi.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nové licence mohou aktivovat Aspose.Slides pouze ve verzi 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**
Nejjednodušší způsob nastavení licence vyžaduje umístit licenční soubor do stejné složky, která obsahuje DLL komponenty (zahrnuté v Aspose.Slides), a zadat pouze název souboru bez cesty.

Tento C# kód ukazuje, jak nastavit licenční soubor:

``` csharp
// Vytvoří instanci třídy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Nastaví cestu k licenčnímu souboru
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Pokud umístíte licenční soubor do jiného adresáře, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/#setlicense_1) musí být název licenčního souboru na konci zadané explicitní cesty shodný s vaším licenčním souborem.

Například můžete změnit název licenčního souboru na *Aspose.Slides.lic.xml*. Pak ve vašem kódu musíte předat cestu k souboru (končící na *Aspose.Slides.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Proud**
Licence lze načíst z proudu. Tento C# kód ukazuje, jak aplikovat licenci z proudu:

``` csharp
// Vytvoří instanci třídy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Nastaví licenci přes proud
license.SetLicense(myStream);
```

### **Vložený zdroj**
Licence může být zabalená s vaší aplikací (aby se neztratila) přidáním licence jako vloženého zdroje do jedné ze sestav, které volají DLL komponenty (zahrnuté v Aspose.Slides). 

Takto přidáte licenční soubor jako vložený zdroj:

1. Ve Visual Studio přidejte licenční soubor (.lic) do projektu tímto způsobem: přejděte na **File** > **Add Existing Item** > **Add**. 
2. Vyberte soubor v **Solution Explorer**.
3. V okně **Properties** nastavte **Build Action** na **Embedded Resource**.
4. Pro přístup k licenci vložené v sestavě přidejte licenční soubor jako vložený zdroj do projektu a poté předáte název licenčního souboru metodě `SetLicense`. 


Třída `License` automaticky najde licenční soubor ve vložených zdrojích. V Microsoft .NET Framework nemusíte volat metody `GetExecutingAssembly` a `GetManifestResourceStream` třídy `System.Reflection.Assembly`.

``` csharp
// Vytvoří instanci třídy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Předá název licenčního souboru vloženého v sestavě
license.SetLicense("Aspose.Slides.lic");
```

## **Ověření licence**

Pro kontrolu, zda je licence nastavena správně, ji můžete ověřit. Tento C# kód ukazuje, jak ověřit licenci:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Bezpečnost vlákna**

{{% alert title="Note" color="warning" %}} 

Metoda [license.SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/) není bezpečná pro více vláken. Pokud musí být tato metoda volána současně z mnoha vláken, můžete chtít použít synchronizační primitivy (např. zámek), aby se předešlo problémům. 

{{% /alert %}}

## **Často kladené otázky**

**Mohu aplikovat licenci v zcela offline prostředí (bez přístupu k internetu)?**

Ano. Ověření licence se provádí lokálně pomocí licenčního souboru; není vyžadováno žádné připojení k internetu.

**Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem ukončení vašeho předplatného; jen nebudete mít nárok používat novější vydání bez obnovení předplatného.