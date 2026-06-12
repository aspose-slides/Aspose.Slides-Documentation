---
title: Měřené licencování
type: docs
weight: 100
url: /cs/php-java/metered-licensing/
keywords:
- licence
- měřená licence
- licenční klíče
- veřejný klíč
- soukromý klíč
- množství spotřeby
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro PHP přes Java s měřeným licencováním umožňuje flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit jen za to, co použijete."
---
## **Úvod**

Měřené licencování je licenční mechanismus, který lze použít spolu s existujícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřené licencování.

## **Použití měřených klíčů**

Když si zakoupíte měřenou licenci, získáte klíče (a ne licenční soubor). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/php-java/aspose.slides/metered/) poskytnuté společností Aspose pro operace měření. Další podrobnosti naleznete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/php-java/aspose.slides/metered/).

2. Předáte své veřejné a soukromé klíče metodě [setMeteredKey](https://reference.aspose.com/slides/cs/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

3. Proveďte určité zpracování (vykonejte úkoly).

4. Zavolejte metodu [getConsumptionQuantity](https://reference.aspose.com/slides/cs/php-java/aspose.slides/metered/#getConsumptionQuantity--) třídy `Metered`.

Měli byste vidět množství/počet API požadavků, které jste doposud spotřebovali.

Tento ukázkový kód vám ukazuje, jak použít měřené licencování:

```php
// Vytvoří instanci třídy Metered
$metered = new Metered();

try {
    // Předá veřejný a soukromý klíč objektu Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Získá hodnotu spotřebovaného množství před voláním API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Proveďte něco s Aspose.Slides API zde
    // ...

    // Získá hodnotu spotřebovaného množství po volání API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Pro použití měřeného licencování potřebujete stabilní internetové připojení, protože licenční mechanismus využívá internet k neustálé interakci s našimi službami a provádění výpočtů.
{{% /alert %}} 

## **Často kladené otázky**

**Mohu v jedné aplikaci použít měřenou licenci společně s běžnou (perpetuální nebo dočasnou) licencí?**

Ano. Měřené licencování je další licenční mechanismus, který lze použít vedle existujících [licenčních metod](/slides/cs/php-java/licensing/). Vyberete, který mechanismus použijete při spuštění aplikace.

**Co přesně se počítá jako spotřeba v rámci měřené licence: operace nebo soubory?**

Počítá se využití API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [metod sledování spotřeby](https://reference.aspose.com/slides/cs/php-java/aspose.slides/metered/).

**Je měřené licencování vhodné pro mikroservisy a serverless prostředí, kde se instance často restartují?**

Ano. Protože účtování probíhá na úrovni API volání, scénáře s častými cold starty jsou kompatibilní, pokud je k dispozici stabilní síťový přístup pro měřené výpočty.

**Liší se funkčnost knihovny při použití měřené licence oproti perpetual licenci?**

Ne. Jedná se pouze o licenční a fakturační mechanismus; schopnosti produktu jsou stejné.

**Jak se měřené licencování vztahuje k zkušební verzi a dočasné licenci?**

Zkušební verze má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dní a měřené licencování odstraňuje omezení a účtuje se na základě skutečného využití.

**Mohu kontrolovat rozpočet automatickým reagováním při překročení prahu spotřeby?**

Ano. Běžnou praxí je pravidelně číst aktuální spotřebu pomocí [sledovacích metod](https://reference.aspose.com/slides/cs/php-java/aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.