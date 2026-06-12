---
title: Licencování
description: "Aspose.Slides pro Python via Java poskytuje různé plány pro nákup nebo nabízí bezplatnou zkušební verzi a 30denní dočasnou licenci pro hodnocení podle licenčních a předplatných zásad."
type: docs
weight: 80
url: /cs/python-java/licensing/
---
Někdy může být pro dosažení nejlepších výsledků hodnocení potřeba praktický přístup. Z tohoto důvodu Aspose.Slides nabízí různé nákupní plány a také poskytuje bezplatnou zkušební verzi a 30denní dočasnou licenci pro hodnocení.

{{% alert color="primary" %}}
Všimněte si, že existuje řada obecných zásad a postupů, které vás vedou, jak hodnotit, řádně licencovat a nakupovat naše produkty. Najdete je v sekci ["Politiky nákupu a časté dotazy"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Vyzkoušejte Aspose.Slides**
Aspose.Slides můžete snadno stáhnout pro vyhodnocení. Vyhodnocovací balíček je stejný jako zakoupený balíček. Vyhodnocovací verze se jednoduše licencuje poté, co přidáte několik řádků kódu pro použití licence. 

## **Omezení vyhodnocovací verze**
Vyhodnocovací verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, ale při otevření a uložení vloží vodotisk pro vyhodnocení do horní části dokumentu. Při extrahování textu z prezentačních snímků jste také omezeni na jeden snímek.

{{% alert color="primary" %}} 
Pokud chcete testovat Aspose.Slides bez omezení vyhodnocovací verze, můžete požádat o **30denní dočasnou licenci**. Další informace naleznete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **O licenci**
Vyhodnocovací verzi Aspose.Slides pro Python via Java můžete snadno stáhnout z jeho [stránky ke stažení](https://releases.aspose.com/slides/cs/python-java/). Vyhodnocovací verze poskytuje naprosto **stejné funkce** jako licencovaná verze Aspose.Slides. Navíc se vyhodnocovací verze jednoduše licencuje po zakoupení licence a přidání několika řádků kódu pro použití licence.

Licence je textový soubor XML, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a další. Soubor je digitálně podepsán, proto jej neprovádějte úpravy. I neúmyslné přidání dalšího řádku do obsahu souboru jej zneplatní.

Abyste se vyhnuli omezením spojeným s vyhodnocovací verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci je třeba nastavit pouze jednou na aplikaci nebo proces.

## Zakoupená licence

Po zakoupení je nutné použít soubor licence nebo proud. 

{{% alert color="primary" %}}
Musíte nastavit licenci:
* pouze jednou na doménu aplikace
* před použitím jakékoli jiné třídy Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Informace o cenách najdete na stránce [“Informace o cenách”](https://purchase.aspose.com/pricing/slides/cs/family).
{{% /alert %}}

### **Nastavení licence v Aspose.Slides pro Python via Java**

Licence lze použít z těchto míst:

* Explicitní cesta
* Proud
* Jako měřená licence – nový licenční mechanismus

{{% alert color="primary" %}}
Použijte metodu **setLicense** k licencování komponenty.

I když jsou více volání **setLicense** neškodná, jsou zbytečnou ztrátou zdrojů (procesoru).
{{% /alert %}}

{{% alert color="warning" %}}
Nové licence mohou aktivovat Aspose.Slides pouze od verze 21.4 a vyšší. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

#### **Použití licence ze souboru**

Tento úryvek kódu slouží k nastavení souboru licence:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Při volání metody setLicense by měl být název licence stejný jako název vašeho licenčního souboru. Například můžete změnit název licenčního souboru na "Aspose.Slides.lic.xml". Pak ve vašem kódu musíte předat nový název licence (Aspose.Slides.lic.xml) metodě setLicense.

#### **Použití licence z bajtů**

Tento úryvek kódu slouží k použití licence z bajtů:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Použít měřenou licenci

Aspose.Slides umožňuje vývojářům použít měřený klíč. Jedná se o nový licenční mechanismus.

Nový licenční mechanismus bude používán spolu s existující licenční metodou. Zákazníci, kteří chtějí být fakturováni na základě využití funkcí API, mohou použít měřené licencování.

Po dokončení všech potřebných kroků k získání tohoto typu licence obdržíte klíče, nikoli licenční soubor. Tento měřený klíč lze použít pomocí třídy **Metered**, která byla speciálně zavedena pro tento účel.

Následující ukázka kódu ukazuje, jak nastavit veřejné a soukromé měřené klíče:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Vytvořte instanci třídy CAD Metered
metered = Metered();

# Přístup k vlastnosti set_metered_key a předání veřejného a soukromého klíče jako parametrů
metered.setMeteredKey("*****", "*****");

# Získejte množství měřených dat před voláním API
amountbefore = Metered.getConsumptionQuantity()

# Zobrazte informace
print("Amount Consumed Before: \" + amountbefore + \"" )

# Načtěte dokument z disku.
pres = Presentation();

# Získejte počet stránek dokumentu
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# Uložte jako PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Získejte množství měřených dat po volání API
amountafter = Metered.getConsumptionQuantity()

# Zobrazte informace
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Vezměte prosím na vědomí, že pro správné používání měřené licence musíte mít stabilní připojení k Internetu, protože mechanismus Metered vyžaduje neustálou interakci s našimi službami pro správné výpočty. Další podrobnosti najdete v sekci [“Časté dotazy o měřeném licencování”](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}