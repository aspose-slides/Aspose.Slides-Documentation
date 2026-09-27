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
- licenční soubor
- evaluační verze
- Python
- Aspose.Slides
description: "Naučte se, jak aplikovat, spravovat a řešit problémy s licencemi v Aspose.Slides pro Python pomocí .NET. Zajistěte si nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním krok za krokem."
---
## **Přehled**

Aspose.Slides může být používán v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává evaluační vodoznak ke každému snímku každé prezentace, kterou uloží, a zkracuje text, který váš kód čte z prezentací.

## **Vyzkoušejte Aspose.Slides**

Evaluační verzi **Aspose.Slides for Python via .NET** si můžete stáhnout z její [stránky ke stažení](https://pypi.org/project/Aspose.Slides/). Evaluační verze poskytuje stejné funkce jako licencovaný produkt. Evaluační balíček je identický s zakoupeným balíčkem a po přidání několika řádků kódu pro aplikaci licence se stane licencovaným.

Jakmile budete s vyhodnocením **Aspose.Slides** spokojeni, můžete [zakoupit licenci](https://purchase.aspose.com/pricing/slides/python-net/). Doporučujeme si prohlédnout dostupné možnosti předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose zahrnuje roční předplatné s bezplatnými aktualizacemi na nové verze a opravy vydané během tohoto období. Jak licencovaní, tak evaluační uživatelé získávají bezplatnou neomezenou technickou podporu.

**Omezení evaluační verze**

* Evaluační verze (když není použita licence) poskytuje plnou funkčnost, ale přidává textové pole s evaluačním vodoznakem ke každému snímku každé prezentace, kterou uloží.
* Text, který váš kód čte z prezentace, je zkrácen na několik prvních znaků, následuje upozornění o evaluačním omezení. Text, který váš kód zapisuje, je uložen celý.

{{% alert color="info" title="Note" %}}
Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Podrobnosti najdete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencování v Aspose.Slides**

* Evaluační verze se stane licencovanou po zakoupení licence a přidání několika řádků kódu pro její aplikaci.
* Licence je soubor XML v prostém textu, který obsahuje podrobnosti jako název produktu, počet vývojářů, které pokrývá, datum expirace předplatného a podobně.
* Licenční soubor je digitálně podepsaný, takže jej nesmíte měnit. I přidání jediného zalomení řádku jej zneplatní.
* Aspose.Slides for Python via .NET hledá licenci v cestě, kterou mu předáte. Relativní cesta nebo název souboru bez cesty je vyhodnocena vůči aktuálnímu pracovnímu adresáři, který nemusí být nutně složka obsahující váš Python skript.
* Aby se předešlo evaluačním omezením, nastavit licenci před použitím Aspose.Slides. Stačí ji nastavit jednou na aplikaci či proces.

{{% alert color="info" title="Note" %}}
Můžete si také přečíst [Metered Licensing](/slides/cs/python-net/metered-licensing/).
{{% /alert %}}

## **Aplikace licence**

Licence může být načtena ze **souboru** nebo **proudu**.

{{% alert color="info" title="Note" %}}
Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) pro správu licencí.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Nové licence mohou aktivovat Aspose.Slides pouze ve verzi 21.4 nebo novější. Starší verze používají odlišný licenční systém a tyto licence nerozpoznají.
{{% /alert %}}

### **Soubor**

Nejjednodušší způsob, jak nastavit licenci, je předat cestu k licenčnímu souboru metodě [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/). Pokud předáte pouze název souboru, jako v ukázce níže, Aspose.Slides hledá soubor v aktuálním pracovním adresáři.

Následující Python kód ukazuje, jak nastavit licenční soubor:

```py
import aspose.slides as slides

# Vytvoří instanci třídy License. 
license = slides.License()

# Nastaví cestu k licenčnímu souboru.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Pokud umístíte licenční soubor do jiného adresáře, při volání [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) musí název souboru na konci explicitní cesty odpovídat názvu vašeho licenčního souboru.

Například můžete přejmenovat licenční soubor na *Aspose.Slides.lic.xml*. Pak ve svém kódu předáte úplnou cestu k tomuto souboru (končící na Aspose.Slides.lic.xml) metodě [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Proud**

Licenci můžete načíst ze streamu. Následující Python příklad ukazuje, jak aplikovat licenci ze streamu:

```py
import aspose.slides as slides

# Vytvoří instanci třídy License.
license = slides.License()

# Nastaví licenci ze streamu.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Ověření licence**

Pro ověření, že licence byla použita správně, ji můžete validovat. Následující Python kód demonstruje, jak licenci validovat:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Bezpečnost při více vláknech**

{{% alert color="warning" title="Warning" %}}
Metoda [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) není bezpečná pro více vláken. Pokud ji potřebujete volat souběžně z více vláken, použijte synchronizační primitivum, jako je `threading.Lock`, abyste se vyhnuli problémům.
{{% /alert %}}

## **Často kladené otázky**

### Můžu aplikovat licenci v úplně offline prostředí (bez přístupu k internetu)?

Ano. Ověření licence se provádí lokálně pomocí licenčního souboru; není vyžadováno připojení k internetu.

### Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem konce vašeho předplatného; jen nebudete mít nárok na novější vydání bez obnovení.