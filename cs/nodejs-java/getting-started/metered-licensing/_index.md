---
title: Měřené licencování
type: docs
weight: 100
url: /cs/nodejs-java/metered-licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro Node.js pomocí Java měřeného licencování umožňuje flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit pouze za to, co používáte."
---
## **Úvod**

Měřené licencování je licenční mechanismus, který lze použít vedle existujících licenčních metod. Pokud chcete být fakturováni na základě využívání funkcí Aspose.Slides API, zvolíte měřené licencování.

## **Použít měřené klíče**

Když si zakoupíte měřenou licenci, získáte klíče (a ne licenční soubor). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/metered/) poskytnuté společností Aspose pro operace měření. Další podrobnosti naleznete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/metered/).

1. Předajte své veřejné a soukromé klíče metodě [setMeteredKey](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Proveďte nějaké zpracování (vykonejte úkoly).

1. Zavolejte metodu [getConsumptionQuantity](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) třídy `Metered`.

Měli byste vidět množství/počet API požadavků, které jste doposud spotřebovali.

Tento ukázkový kód ukazuje, jak použít měřené licencování:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy Metered
var metered = new aspose.slides.Metered();

// Předá veřejný a soukromý klíč objektu Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Získá hodnotu spotřebovaného množství před voláním API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Proveďte něco s Aspose.Slides API zde
// ...

// Získá hodnotu spotřebovaného množství po volání API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
Pro používání měřeného licencování potřebujete stabilní internetové připojení, protože licenční mechanismus používá internet k neustálé interakci s našimi službami a provádění výpočtů.
{{% /alert %}} 

## **Často kladené otázky**

**Mohu použít měřenou licenci spolu s běžnou (trvalou nebo dočasnou) licencí ve stejné aplikaci?**

Ano. Měřené je doplňkový licenční mechanismus, který lze použít vedle existujících [licenčních metod](/slides/cs/nodejs-java/licensing/). Vyberete si, který mechanismus použít při spuštění aplikace.

**Co přesně se počítá jako spotřeba v rámci měřené licence: operace nebo soubory?**

Počítá se využití API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [metod sledování spotřeby](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/metered/).

**Je měřené vhodné pro mikroservisy a serverless prostředí, kde instance často restartují?**

Ano. Jelikož účtování probíhá na úrovni API volání, scénáře s častými cold starty jsou kompatibilní, za předpokladu stabilního síťového připojení pro měřené výpočty.

**Liší se funkčnost knihovny při použití měřené licence oproti trvalé licenci?**

Ne. Jedná se pouze o licenční a fakturační mechanismus; schopnosti produktu jsou stejné.

**Jak se měřené vztahuje k trial verzi a dočasné licenci?**

Trial verze má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dní a měřené odstraňuje omezení a účtuje podle skutečného využití.

**Mohu kontrolovat rozpočet automatickým reakcí, když je překročena prahová hodnota spotřeby?**

Ano. Běžnou praxí je periodicky číst aktuální spotřebu pomocí [metod sledování](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.