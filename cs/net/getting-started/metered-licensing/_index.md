---
title: Měřené licencování
type: docs
weight: 90
url: /cs/net/metered-licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro .NET s měřeným licencováním umožňuje flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit jen za to, co použijete."
---
## **Úvod**

Měřené licencování je licenční mechanismus, který lze použít vedle stávajících licenčních metod. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřené licencování.

## **Použití měřených klíčů**

Když si zakoupíte měřenou licenci, získáte klíče (a ne licenční soubor). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/net/aspose.slides/metered/) poskytnuté společností Aspose pro operace měření. Další podrobnosti najdete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/net/aspose.slides/metered/).
2. Předávejte své veřejné a soukromé klíče metodě [SetMeteredKey](https://reference.aspose.com/slides/cs/net/aspose.slides/metered/setmeteredkey/).
3. Proveďte nějaké zpracování (vykonejte úkoly).
4. Zavolejte metodu [GetConsumptionQuantity](https://reference.aspose.com/slides/cs/net/aspose.slides/metered/getconsumptionquantity/) třídy `Metered`.

Měli byste vidět množství/počet API požadavků, které jste doposud spotřebovali.

Tento ukázkový kód vám ukazuje, jak použít měřené licencování:

```cs
// Vytvoří instanci třídy Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Předá veřejný a soukromý klíč objektu Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Získá množství měřených dat před voláním API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Proveďte něco s API Aspose.Slides zde
// ...

// Získá množství měřených dat po volání API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="POZNÁMKA"  %}} 

Pro použití měřeného licencování potřebujete stabilní internetové připojení, protože licenční mechanismus používá internet k neustálé komunikaci s našimi službami a provádění výpočtů.

{{% /alert %}} 

## **Často kladené otázky**

**Mohu v jedné aplikaci používat měřenou licenci společně s běžnou licencí (trvalou nebo dočasnou)?**

Ano. Měřené licencování je doplňkový licenční mechanismus, který lze použít vedle stávajících [licenčních metod](/slides/cs/net/licensing/). Při spuštění aplikace si zvolíte, který mechanismus použít.

**Co přesně se počítá jako spotřeba v rámci měřené licence: operace nebo soubory?**

Počítá se využití API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [metod sledování spotřeby](https://reference.aspose.com/slides/cs/net/aspose.slides/metered/).

**Je měřené licencování vhodné pro mikroservisy a serverless prostředí, kde se instance často restartují?**

Ano. Vzhledem k tomu, že účtování probíhá na úrovni volání API, scénáře s častými cold starty jsou kompatibilní, pokud je k dispozici stabilní síťové připojení pro výpočty měřeného licencování.

**Liší se funkčnost knihovny při použití měřené licence oproti trvalé licenci?**

Ne. Jedná se pouze o licenční a fakturační mechanismus; schopnosti produktu jsou stejné.

**Jak se měřené licencování vztahuje k zkušební verzi a dočasné licenci?**

Zkušební verze má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dní a měřené licencování odstraňuje omezení a účtuje na základě skutečného využití.

**Mohu kontrolovat rozpočet automatickým reakcí, když je překročena hranice spotřeby?**

Ano. Běžnou praxí je periodicky číst aktuální spotřebu pomocí [sledovacích metod](https://reference.aspose.com/slides/cs/net/aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.