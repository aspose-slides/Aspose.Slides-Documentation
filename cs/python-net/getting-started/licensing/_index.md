---
title: Licencování
type: docs
weight: 80
url: /cs/python-net/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- soubor licence
- verze pro hodnocení
- Python
- Aspose.Slides
description: "Zjistěte, jak aplikovat, spravovat a řešit problémy s licencemi v Aspose.Slides for Python via .NET. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho krok za krokem průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze použít v režimu hodnocení nebo s platnou licencí. Hodnotící verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává vodotisk hodnocení při otevření nebo uložení prezentací a omezuje extrakci textu na jeden snímek.

## **Vyzkoušejte Aspose.Slides**

Můžete si stáhnout hodnotící verzi **Aspose.Slides for Python via .NET** z její [stránky ke stažení](https://pypi.org/project/Aspose.Slides/). Hodnotící verze poskytuje stejné funkce jako licencovaný produkt. Hodnotící balíček je identický s zakoupeným balíčkem a po přidání několika řádků kódu pro aplikaci licence se stane licencovaným.

Když budete s hodnocením **Aspose.Slides** spokojeni, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme prohlédnout dostupné možnosti předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose zahrnuje roční předplatné s bezplatnými aktualizacemi na nové verze a opravy vydávané během tohoto období. Licencovaní i hodnotící uživatelé získávají bezplatnou neomezenou technickou podporu.

**Omezení hodnotící verze**

* Zatímco hodnotící verze Aspose.Slides (když není použita licence) poskytuje plnou funkčnost, přidává vodotisk hodnocení na horní část dokumentu při každém otevření nebo uložení.
* Při extrakci textu z prezentace jste omezeni na jeden snímek.

{{% alert color="primary" %}}
Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Podrobnosti najdete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencování v Aspose.Slides**

* Hodnotící verze se stane licencovanou po zakoupení licence a přidání několika řádků kódu pro její aplikaci.
* Licence je soubor XML v prostém textu, který obsahuje podrobnosti jako název produktu, počet vývojářů, které pokrývá, datum vypršení předplatného a podobně.
* Soubor licence je digitálně podepsán, takže jej nesmíte upravovat. I přidání jediného konce řádku jej zneplatní.
* Aspose.Slides for Python via .NET obvykle hledá licenci na následujících místech:
  * Explicitní cesta, kterou zadáte
  * Složka, která obsahuje Python skript volající Aspose.Slides for Python via .NET
* Aby se zabránilo omezením hodnocení, nastavte licenci před použitím Aspose.Slides. Stačí ji nastavit jednou na aplikaci nebo proces.

{{% alert color="primary" %}}
Možná budete chtít také prohlédnout [Metered Licensing](/slides/cs/python-net/metered-licensing/).
{{% /alert %}}

## **Aplikace licence**

Licence může být načtena ze **souboru**, **proudu** nebo **vloženého prostředku**.

{{% alert color="primary" %}}
Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/python-net/aspose.slides/license/) pro správu licencování.
{{% /alert %}}

{{% alert color="warning" %}}
Nové licence mohou aktivovat Aspose.Slides pouze s verzí 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

### **Soubor**

Nejjednodušší způsob, jak nastavit licenci, je umístit soubor licence do stejné složky jako DLL komponenty a zadat pouze název souboru (bez cesty).

Následující Python kód ukazuje, jak nastavit soubor licence:

```py
import aspose.slides as slides

# Vytvoří instanci třídy License.
license = slides.License()

# Nastaví cestu k souboru licence.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Pokud umístíte soubor licence do jiné složky, při volání [License.set_license()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/license/set_license/#str) musí název souboru na konci explicitní cesty odpovídat názvu vašeho licenčního souboru.

Například můžete přejmenovat licenční soubor na *Aspose.Slides.lic.xml*. Poté ve svém kódu předáte úplnou cestu k tomuto souboru (končící Aspose.Slides.lic.xml) metodě [License.set_license()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Proud**

Licence může být načtena z proudu. Následující Python příklad ukazuje, jak aplikovat licenci z proudu:

```py
import aspose.slides as slides

# Vytvoří instanci třídy License.
license = slides.License()

# Nastaví licenci ze streamu.
license.set_license(stream)
```

## **Ověření licence**

Pro ověření, že licence byla správně aplikována, ji můžete validovat. Následující Python kód ukazuje, jak validovat licenci:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Bezpečnost vláken**

{{% alert title="Note" color="warning" %}}
Metody [License.set_license](https://reference.aspose.com/slides/cs/python-net/aspose.slides/license/) nejsou bezpečné pro více vláken. Pokud je je třeba volat souběžně z více vláken, použijte synchronizační primitiva (např. `threading.Lock`), aby se předešlo problémům.
{{% /alert %}}

## **Často kladené otázky**

**Mohu aplikovat licenci v úplně offline prostředí (bez přístupu k internetu)?**

Ano. Ověření licence se provádí lokálně pomocí licenčního souboru; není vyžadováno připojení k internetu.

**Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem skončení vašeho předplatného; jen nebudete mít nárok na novější vydání bez obnovy.