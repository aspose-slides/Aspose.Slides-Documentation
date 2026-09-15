---
title: Měřené licencování
type: docs
weight: 100
url: /cs/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro Python via Java s měřeným licencováním umožňuje flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit jen za to, co používáte."
---
## **Úvod**

Metered licensing je licenční mechanismus, který lze používat spolu s existujícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolte měřenou licencování.

## **Použití měřených klíčů**

{{% alert color="info" title="Poznámka" %}}

Metered licensing je nový licenční mechanismus, který lze používat spolu s existujícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolte měřenou licencování.

Když si zakoupíte měřenou licenci, získáte klíče (a ne licenční soubor). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/) poskytované společností Aspose pro operace měření. Další podrobnosti naleznete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/).

1. Předáte své veřejné a soukromé klíče metodě [setMeteredKey](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/#setMeteredKey).

1. Proveďte zpracování (provádějte úkoly).

1. Zavolejte metodu [getConsumptionQuantity](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/#getConsumptionQuantity) třídy [Metered](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/).

Měli byste vidět množství/počet API požadavků, které jste doposud spotřebovali.

Tento ukázkový kód vám ukazuje, jak používat měřenou licenci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Vytvořte instanci třídy Metered.
metered = Metered()

try:
    # Předávejte veřejný a soukromý klíč objektu Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Získejte množství spotřeby před voláními API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Proveďte zde něco s API Aspose.Slides.
    # ...

    # Získejte množství spotřeby po voláních API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Varování" %}}

Pro použití měřeného licencování potřebujete stabilní připojení k internetu, protože licenční mechanismus používá internet k neustálé interakci s našimi službami a provádění výpočtů.

{{% /alert %}}

## **Často kladené otázky**

**Mohu použít měřenou licenci spolu s běžnou (perpetuální nebo dočasnou) licencí ve stejné aplikaci?**

Ano. Měřená licence je doplňkový licenční mechanismus, který lze používat spolu s existujícími [licensing methods](/slides/cs/python-java/licensing/). Při startu aplikace si vyberete, který mechanismus použít.

**Co přesně se počítá jako spotřeba v rámci měřené licence: operace nebo soubory?**

Počítá se používání API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [consumption‑tracking methods](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/).

**Je měřená licence vhodná pro mikroservisy a serverless prostředí, kde instance často restartují?**

Ano. Protože účtování probíhá na úrovni API volání, scénáře s častými „cold starty“ jsou kompatibilní, pokud je k dispozici stabilní síťové připojení pro výpočty měřeného licencování.

**Liší se funkčnost knihovny při použití měřené licence oproti perpetuální licenci?**

Ne. Jedná se jen o licenční a fakturační mechanismus; schopnosti produktu jsou stejné.

**Jak se měřená licence vztahuje k verzi pro zkušební použití a dočasné licenci?**

Verze pro zkušební použití má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dní a měřená licence odstraňuje omezení a účtuje podle skutečného využití.

**Mohu kontrolovat rozpočet automatickým reagováním, když je překročen práh spotřeby?**

Ano. Běžnou praxí je pravidelně číst aktuální spotřebu pomocí [tracking methods](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.