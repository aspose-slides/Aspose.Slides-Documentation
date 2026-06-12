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
- licenční soubor
- verze pro hodnocení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Používejte, spravujte a řešte problémy s licencemi v Aspose.Slides pro PHP přes Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Úvod**

Někdy je pro dosažení nejlepších výsledků z hodnocení potřeba praktický přístup. Z tohoto důvodu Aspose.Slides poskytuje různé nákupní plány a také nabízí Bezplatnou zkušební verzi a 30denní dočasnou licenci pro hodnocení.

{{% alert color="primary" %}}

Všimněte si, že existuje řada obecných zásad a postupů, které vás provádějí, jak hodnotit, řádně licencovat a nakupovat naše produkty. Najdete je v sekci ["Zásady nákupu a FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Vyhodnoťte Aspose.Slides**
Aspose.Slides můžete snadno stáhnout pro hodnocení. Hodnotící balíček je stejný jako zakoupený balíček. Hodnotící verze se jednoduše licencuje poté, co přidáte několik řádků kódu pro použití licence. 

## **Omezení hodnotící verze**
Hodnotící verze Aspose.Slides (bez určené licence) poskytuje plnou funkčnost produktu, ale při otevření a uložení do dokumentu vkládá vodotisk pro hodnocení v horní části. Při extrahování textu z prezentačních snímků jste také omezeni na jeden snímek.

{{% alert color="primary" %}} 

Pokud chcete testovat Aspose.Slides bez omezení hodnotící verze, můžete požádat o **30denní dočasnou licenci**. Další informace naleznete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **O licenci**
Můžete snadno stáhnout hodnotící verzi Aspose.Slides pro PHP přes Java z její [stahovací stránky](https://packagist.org/packages/aspose/slides). Hodnotící verze poskytuje naprosto **stejné funkce** jako licencovaná verze Aspose.Slides. Navíc se hodnotící verze jednoduše licencuje po zakoupení licence a přidání několika řádků kódu pro aplikaci licence.

Licence je běžný XML soubor, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a další. Soubor je digitálně podepsaný, proto jej neupravujte. I nevědomé přidání dalšího řádkového zlomu do obsahu souboru jej zneplatní.

Aby se předešlo omezením spojeným s hodnotící verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci je třeba nastavit pouze jednou pro aplikaci nebo proces.

{{% alert color="primary" %}} 

Možná budete chtít zobrazit [Měřené licencování](https://docs.aspose.com/slides/cs/php-java/metered-licensing/).

{{% /alert %}} 

## **Zakoupená licence**

Po zakoupení je třeba aplikovat licenční soubor nebo stream. 

{{% alert color="primary" %}}

Musíte nastavit licenci:
* pouze jednou na aplikační doménu
* před použitím jakýchkoli jiných tříd Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Informace o cenách najdete na stránce [“Informace o cenách”](https://purchase.aspose.com/pricing/slides/cs/family).

{{% /alert %}}

### **Nastavte licenci v Aspose.Slides pro PHP přes Java**

Licence lze použít z následujících míst:

* Explicitní cesta
* Stream
* Jako měřená licence – nový licenční mechanismus

{{% alert color="primary" %}}

Použijte metodu **setLicense** k licencování komponenty.

I když více volání **setLicense** neškodí, jsou zbytečnou zátěží (procesor).

{{% /alert %}}

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze s verzí 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

#### **Aplikujte licenci pomocí souboru**

Tento úryvek kódu slouží k nastavení licenčního souboru:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Při volání metody setLicense by měl být název licence shodný s názvem vašeho licenčního souboru. Například můžete změnit název licenčního souboru na "Aspose.Slides.lic.xml". Poté ve svém kódu musíte předat nový název licence (Aspose.Slides.lic.xml) metodě setLicense.

#### **Aplikujte licenci ze streamu**

Tento úryvek kódu slouží k aplikaci licence ze streamu:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **Často kladené otázky**

**Mohu licenci použít v úplně offline prostředí (bez přístupu k internetu)?**

Ano. Ověření licence probíhá lokálně pomocí licenčního souboru; není vyžadováno internetové připojení.

**Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem vypršení vašeho předplatného; prostě nebudete mít nárok na novější verze bez obnovení.