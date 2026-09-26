---
title: Licencování
type: docs
weight: 80
url: /cs/net/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- používat licenci
- ověřit licenci
- licenční soubor
- evaluační verze
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Aplikujte, spravujte a odstraňujte problémy s licencemi v Aspose.Slides pro .NET. Zajistěte nepřetržitý přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Přehled**

Aspose.Slides může být používán v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává evaluační vodoznak na každý snímek každé prezentace, kterou uloží, a zkracuje text, který váš kód čte z prezentací.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak použít licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence správně použita.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="info" title="Note" %}}

Můžete si stáhnout evaluační verzi **Aspose.Slides for .NET** z [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou poté, co do ní přidáte několik řádků kódu (pro použití licence).

Jakmile budete s evaluační verzí **Aspose.Slides** spokojeni, můžete [purchase a license](https://purchase.aspose.com/pricing/slides/cs/net/). Doporučujeme projít různé typy předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné na bezplatné aktualizace na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty nebo dokonce s evaluačními verzemi dostávají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení evaluační verze**

* Evaluační verze (bez určené licence) poskytuje plnou funkčnost produktu, ale přidává evaluační vodoznak do textového pole na každém snímku každé prezentace, kterou uloží.
* Text, který váš kód čte z prezentace, je zkrácen na několik prvních znaků, následovaných upozorněním na omezení evaluační verze. Text, který váš kód zapisuje, je uložen celý.

{{% alert color="info" title="Note" %}}

Chcete‑li testovat Aspose.Slides bez omezení, můžete požádat o **30‑denní dočasnou licenci**. Více informací najdete na stránce [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**
* Evaluační verze se stane licencovanou po zakoupení licence a přidání několika řádků kódu (pro použití licence).
* Licence je prostý XML soubor, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a podobně. 
* Licenční soubor je digitálně podepsaný, proto jej nesmíte měnit. I neúmyslné přidání nového řádku do obsahu souboru jej zneplatní.
* Aspose.Slides for .NET obvykle hledá licenci na následujících místech:
  * Explicitní cesta
  * Složka obsahující DLL komponenty (součást Aspose.Slides)
  * Složka obsahující sestavení, které zavolalo DLL komponenty (součást Aspose.Slides)
  * Složka obsahující vstupní sestavení (váš .exe)
  * Vložený zdroj v sestavení, které zavolalo DLL komponenty (součást Aspose.Slides).
* Abyste se vyhnuli omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím Aspose.Slides. Licenci nastavíte jednou na aplikaci nebo proces.

{{% alert color="info" title="Note" %}}

Možná budete chtít vidět [Metered Licensing](/slides/cs/net/metered-licensing/).

{{% /alert %}} 


## **Použití licence**
Licence může být načtena ze **souboru**, **proudu** nebo **vloženého zdroje**. 

{{% alert color="info" title="Note" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/net/aspose.slides/license) pro operace s licencí.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Nové licence mohou aktivovat Aspose.Slides jen ve verzi 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**
Nejjednodušší metoda nastavení licence vyžaduje, abyste soubor licence umístili do stejné složky, kde se nachází DLL komponenty (součást Aspose.Slides), a zadali jen název souboru bez cesty.

Tento C# kód ukazuje, jak nastavit licenční soubor:

``` csharp
// Vytvoří instanci třídy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Nastaví cestu k licenčnímu souboru
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}

Pokud umístíte licenční soubor do jiné složky, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/#setlicense_1) musí být název souboru na konci zadané cesty stejný jako název vašeho licenčního souboru.

Například můžete změnit název licenčního souboru na *Aspose.Slides.lic.xml*. Pak ve svém kódu musíte předat cestu k souboru (končící na *Aspose.Slides.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Průtok**
Licenci můžete načíst z proudu. Tento C# kód ukazuje, jak použít licenci z proudu:

``` csharp
// Vytvoří instanci třídy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Otevře licenční soubor jako proud
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Nastaví licenci pomocí proudu
license.SetLicense(licenseStream);
```

### **Vložený zdroj**
Licence může být zabalená s vaší aplikací (aby nedošlo ke ztrátě) přidáním licence jako vloženého zdroje do jednoho ze sestavení, které volá DLL komponenty (součást Aspose.Slides). 

Takto přidáte licenční soubor jako vložený zdroj:

1. Ve Visual Studio přidejte licenční soubor (.lic) do projektu tímto způsobem: **File** > **Add Existing Item** > **Add**. 
2. Vyberte soubor v **Solution Explorer**.
3. V okně **Properties** nastavte **Build Action** na **Embedded Resource**.
4. Pro přístup k licenci vložené v sestavení přidejte licenční soubor jako vložený zdroj do projektu a poté předáte název souboru metodě `SetLicense`. 


Třída `License` automaticky najde licenční soubor mezi vloženými zdroji. Nemusíte volat metody `GetExecutingAssembly` a `GetManifestResourceStream` třídy `System.Reflection.Assembly` v Microsoft .NET Framework.

Tento C# kód ukazuje, jak nastavit licenci jako vložený zdroj:

``` csharp
// Vytvoří instanci třídy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Předá název licenčního souboru vložený v sestavení
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

## **Bezpečnost při více vláknech**

{{% alert color="warning" title="Warning" %}}

Metoda [license.SetLicense](https://reference.aspose.com/slides/cs/net/aspose.slides/license/setlicense/) není bezpečná při více vláknech. Pokud je tato metoda volána současně z více vláken, můžete použít synchronizační primitiva (např. zámek), aby se předešlo problémům. 

{{% /alert %}}

## **Často kladené otázky**

### Mohu použít licenci v úplně offline prostředí (bez přístupu k internetu)?

Ano. Ověření licence probíhá lokálně pomocí licenčního souboru; není vyžadováno žádné připojení k internetu.

### Co se stane po uplynutí ročního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem konce vašeho předplatného; jen nebudete mít nárok na novější vydání bez obnovení předplatného.