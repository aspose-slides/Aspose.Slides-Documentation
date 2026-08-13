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
description: "Používejte, spravujte a řešte problémy s licencemi v Aspose.Slides pro .NET. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v režimu hodnocení nebo s platnou licencí. Evaluace poskytuje stejnou funkčnost jako licencovaná verze, ale přidává vodotisk hodnocení při otevření nebo uložení prezentací a omezuje extrakci textu na jeden snímek.

Článek vysvětluje, jak funguje licencování v Aspose.Slides a jak použít licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého prostředku pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence správně aplikována.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="info" %}} 

Můžete si stáhnout evaluační verzi **Aspose.Slides for NET** z [její stránka pro stažení na NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou poté, co do ní přidáte několik řádků kódu (pro použití licence).

Jakmile budete spokojeni s hodnocením **Aspose.Slides**, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme projít různými typy předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné na bezplatné aktualizace na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty nebo dokonce s evaluačními verzemi získají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení evaluační verze**

* Zatímco evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, vkládá vodotisk hodnocení na horní část dokumentu při operacích otevření a uložení. 
* Při extrakci textu z prezentací jste omezeni na jeden snímek.

{{% alert color="info" %}} 

Chcete-li testovat Aspose.Slides bez omezení, můžete požádat o **30denní dočasnou licenci**. Další informace najdete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**
* Evaluační verze se stane licencovanou poté, co zakoupíte licenci a přidáte několik řádků kódu (pro aplikaci licence).
* Licence je čistý textový XML soubor, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence udělena, datum vypršení předplatného a podobně. 
* Licenční soubor je digitálně podepsán, proto jej nesmíte měnit. I neúmyslné přidání dalšího konce řádku do obsahu souboru jej zneplatní.
* Aspose.Slides pro .NET obvykle hledá licenci na těchto místech:
  * Explicitní cesta
  * Složka obsahující dll komponenty (součást Aspose.Slides)
  * Složka obsahující sestavení, které volalo dll komponenty (součást Aspose.Slides)
  * Složka obsahující vstupní sestavení (váš .exe)
  * Vložený prostředek v sestavení, které volalo dll komponenty (součást Aspose.Slides).
* Abyste se vyhnuli omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím Aspose.Slides. Licenci je potřeba nastavit jen jednou za aplikaci nebo proces.

{{% alert color="info" %}} 

Možná budete chtít zobrazit [Měřené licencování](https://docs.aspose.com/slides/cs/net/metered-licensing/).

{{% /alert %}} 

## **Aplikace licence**
Licenci lze načíst ze **souboru**, **proudu** nebo **vloženého prostředku**. 

{{% alert color="info" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/net/aspose.slides/license) pro licenční operace.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nové licence mohou aktivovat Aspose.Slides pouze ve verzi 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **File**
Nejjednodušší metoda nastavení licence vyžaduje, abyste umístili licenční soubor do stejné složky, ve které se nachází DLL komponenty (součást Aspose.Slides), a zadali pouze název souboru bez cesty.

Tento C# kód ukazuje, jak nastavit licenční soubor:

``` csharp
// Vytvoří instanci třídy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Nastavuje cestu k licenčnímu souboru
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Pokud umístíte licenční soubor do jiného adresáře, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/#setlicense_1) název licenčního souboru na konci specifikované explicitní cesty musí být stejný jako váš licenční soubor.

Například můžete změnit název licenčního souboru na *Aspose.Slides.lic.xml*. Pak ve svém kódu musíte předat cestu k souboru (končící na *Aspose.Slides.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Stream**
Licenci můžete načíst ze streamu. Tento C# kód ukazuje, jak použít licenci ze streamu:

``` csharp
// Vytvoří instanci třídy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Otevře licenční soubor jako stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Nastaví licenci pomocí streamu
license.SetLicense(licenseStream);
```

### **Embedded Resource**
Můžete balíček licence přidat do své aplikace (aby se neztratil) přidáním licence jako vloženého prostředku do jednoho ze sestavení, která volají DLL komponenty (součást Aspose.Slides). 

Takto přidáte licenční soubor jako vložený prostředek:

1. Ve Visual Studiu přidejte licenční soubor (.lic) do projektu tímto způsobem: Přes **File** > **Add Existing Item** > **Add**. 
2. Vyberte soubor v **Solution Explorer**.
3. V okně **Properties** nastavte **Build Action** na **Embedded Resource**.
4. Pro přístup k licenci vložené v sestavení přidejte licenční soubor jako vložený prostředek do projektu a poté předávejte název licenčního souboru metodě `SetLicense`. 

Třída `License` automaticky najde licenční soubor ve vložených prostředcích. Nemusíte volat metody `GetExecutingAssembly` a `GetManifestResourceStream` třídy `System.Reflection.Assembly` v Microsoft .NET Framework.

``` csharp
// Vytvoří instanci třídy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Předá název licenčního souboru vloženého do sestavení
license.SetLicense("Aspose.Slides.lic");
```

## **Ověření licence**

Pro kontrolu, zda byla licence správně nastavena, ji můžete ověřit. Tento C# kód ukazuje, jak ověřit licenci:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Bezpečnost vláken**

{{% alert title="Note" color="warning" %}} 

Metoda [license.SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/) není bezpečná pro více vláken. Pokud musí být tato metoda volána současně z mnoha vláken, můžete použít synchronizační primitivy (např. zámek), abyste předešli problémům. 

{{% /alert %}}

## **Často kladené otázky**

### Mohu použít licenci v úplně offline prostředí (bez připojení k internetu)?

Ano. Ověření licence probíhá lokálně pomocí licenčního souboru; není vyžadováno internetové připojení.

### Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem konce vašeho předplatného; jen nebudete mít oprávnění používat novější vydání bez obnovení.