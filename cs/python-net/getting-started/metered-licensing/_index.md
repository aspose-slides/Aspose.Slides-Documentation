---
title: Měřená licence
type: docs
weight: 90
url: /cs/python-net/metered-licensing/
keywords:
- licence
- měřená licence
- licenční klíče
- veřejný klíč
- soukromý klíč
- množství spotřeby
- Python
- Aspose.Slides
description: "Zjistěte, jak vám Aspose.Slides pro Python pomocí .NET měřené licence umožní flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit pouze za to, co používáte."
---
## **Úvod**

Metered licensing je licenční mechanismus, který lze použít spolu se stávajícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřenou licenci.

## **Použití měřených klíčů**

{{% alert color="primary" %}} 

Metered licensing je nový licenční mechanismus, který lze použít spolu se stávajícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřenou licenci.

Když si zakoupíte měřenou licenci, získáte klíče (a ne licenční soubor). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/python-net/aspose.slides/metered/), kterou Aspose poskytuje pro operace měření. Další podrobnosti najdete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/python-net/aspose.slides/metered/).
2. Předávejte své veřejné a soukromé klíče metodě [set_metered_key](https://reference.aspose.com/slides/cs/python-net/aspose.slides/metered/set_metered_key/#str-str).
3. Proveďte nějaké zpracování (vykonejte úlohy).
4. Zavolejte metodu [get_consumption_quantity](https://reference.aspose.com/slides/cs/python-net/aspose.slides/metered/get_consumption_quantity/#) třídy `Metered`.

Měli byste vidět množství požadavků na API, které jste doposud spotřebovali.

Tento ukázkový kód vám ukazuje, jak používat měřenou licenci:

```python
import aspose.slides as slides

# Vytvoří instanci třídy Metered
metered = slides.Metered()

# Předá veřejný a soukromý klíč objektu Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Získá hodnotu spotřebovaného množství před voláními API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Proveďte něco s Aspose.Slides API zde
# ...

# Získá hodnotu spotřebovaného množství po voláních API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Pro používání měřené licence potřebujete stabilní internetové připojení, protože licenční mechanismus používá internet k neustálé interakci s našimi službami a provádění výpočtů.

{{% /alert %}} 

## **FAQ**

**Mohu používat měřenou licenci společně s běžnou (trvalou nebo dočasnou) v téže aplikaci?**

Ano. Metered je doplňkový licenční mechanismus, který lze použít spolu se stávajícími [licenčními metodami](/slides/cs/python-net/licensing/). Vyberete si, který mechanismus použít při spuštění aplikace.

**Co se přesně počítá jako spotřeba v rámci měřené licence: operace nebo soubory?**

Počítá se využití API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [metod sledování spotřeby](https://reference.aspose.com/slides/cs/python-net/aspose.slides/metered/).

**Je měřená licence vhodná pro mikroslužby a serverless prostředí, kde se instance často restartují?**

Ano. Protože účtování probíhá na úrovni jednotlivých volání API, scénáře s častými cold starty jsou kompatibilní, pokud je k dispozici stabilní síťový přístup pro výpočty měření.

**Liší se funkčnost knihovny při použití měřené licence oproti trvalé licenci?**

Ne. Jedná se jen o licenční a fakturační mechanismus; schopnosti produktu jsou stejné.

**Jak se měřená licence vztahuje k verzi zkoušky a dočasné licenci?**

Verze zkoušky má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dní a měřená licence odstraňuje omezení a účtuje se na základě skutečného využití.

**Mohu řídit rozpočet automatickým reakcím, když je překročena prahová hodnota spotřeby?**

Ano. Běžnou praxí je periodicky číst aktuální spotřebu pomocí [sledovacích metod](https://reference.aspose.com/slides/cs/python-net/aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.