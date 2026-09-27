---
title: Licencování
type: docs
weight: 80
url: /cs/php-java/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- soubor licence
- verze pro hodnocení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro PHP přes Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho krok za krokem průvodce licencováním."
---
## **Úvod**

Někdy je pro dosažení nejlepších výsledků hodnocení potřeba praktický přístup. Z tohoto důvodu Aspose.Slides poskytuje různé nákupní plány a také nabízí bezplatnou zkušební verzi a 30‑denní dočasnou licenci pro hodnocení.

{{% alert color="info" title="Note" %}}
Všimněte si, že existuje řada obecných zásad a postupů, které vás vedou, jak hodnotit, řádně licencovat a nakupovat naše produkty. Najdete je v sekci ["Zásady nákupu a časté dotazy"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Vyzkoušejte Aspose.Slides**
Můžete snadno stáhnout Aspose.Slides pro hodnocení. Hodnotící balíček je stejný jako zakoupený balíček. Verze pro hodnocení se jednoduše stane licencovanou po přidání několika řádků kódu pro aplikaci licence.

## **Omezení verze pro hodnocení**
Verze Aspose.Slides pro hodnocení (bez určené licence) poskytuje plnou funkčnost produktu, s dvěma omezeními:

* Přidá textové pole s vodoznakem „evaluation“ do středu každého snímku každé prezentace, kterou uloží.
* Text, který váš kód načítá z prezentace, je zkrácen na několik prvních znaků, následovaný upozorněním o omezení hodnocení. Text, který váš kód zapisuje, je uložen celý.

{{% alert color="info" title="Note" %}}
Pokud chcete testovat Aspose.Slides bez omezení verze pro hodnocení, můžete požádat o **30 Day Temporary License**. Další informace najdete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **O licenci**
Snadno můžete stáhnout verzi pro hodnocení Aspose.Slides pro PHP přes Java z její [stránky ke stažení](https://packagist.org/packages/aspose/slides). Verze pro hodnocení poskytuje naprosto **stejné funkce** jako licencovaná verze Aspose.Slides. Navíc se verze pro hodnocení jednoduše stane licencovanou po zakoupení licence a přidání několika řádků kódu pro aplikaci licence.

Licence je soubor XML v prostém textu, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licencována, datum vypršení předplatného a podobně. Soubor je digitálně podepsán, takže jej nechte beze změny. I neúmyslné přidání dalšího konce řádku do obsahu souboru jej zneplatní.

Abyste se vyhnuli omezením spojeným s verzí pro hodnocení, musíte nastavit licenci před použitím **Aspose.Slides**. Licence se nastavuje jen jednou na aplikaci nebo proces.

{{% alert color="info" title="Note" %}}
Můžete si prohlédnout [Licencování na měření](/slides/cs/php-java/metered-licensing/).
{{% /alert %}} 

## **Zakoupená licence**

Po zakoupení musíte aplikovat soubor licence nebo stream. 

{{% alert color="info" title="Note" %}}
Musíte nastavit licenci:
* pouze jednou na doménu aplikace
* před použitím jakýchkoli dalších tříd Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Informace o cenách najdete na stránce [Informace o cenách](https://purchase.aspose.com/pricing/slides/cs/family).
{{% /alert %}}

### **Nastavení licence v Aspose.Slides pro PHP přes Java**

Licence mohou být aplikovány z těchto zdrojů:

* Explicitní cesta
* Proud
* Jako licencování na měření – nový licenční mechanismus

{{% alert color="info" title="Note" %}}
Použijte metodu **setLicense** k licencování komponenty.

Ačkoli více volání **setLicense** není škodlivých, jsou zbytečnou zátěží (procesor).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Nové licence mohou aktivovat Aspose.Slides jen od verze 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

#### **Aplikace licence ze souboru**

Tento úryvek kódu se používá k nastavení souboru licence:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Ukázka očekává soubor licence vedle skriptu a předává jeho absolutní cestu: Aspose.Slides běží v Tomcatu, takže neřeší relativní cestu vůči složce vašeho skriptu. Při volání metody setLicense by měl mít název licence stejný jako název vašeho souboru licence. Například můžete změnit název souboru licence na "Aspose.Slides.lic.xml". Pak ve svém kódu musíte předat nový název licence (Aspose.Slides.lic.xml) metodě setLicense.

#### **Aplikace licence z proudu**

Tento úryvek kódu se používá k aplikaci licence z proudu:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **Často kladené otázky**

### Mohu aplikovat licenci v zcela offline prostředí (bez přístupu k internetu)?
Ano. Ověření licence probíhá lokálně pomocí souboru licence; není vyžadováno internetové připojení.

### Co se stane po vypršení jednoletého předplatného? Přestane knihovna fungovat?
Ne. Licence je trvalá: můžete nadále používat verze vydané před datem ukončení vašeho předplatného; pouze nebudete mít nárok na novější verze bez obnovení.