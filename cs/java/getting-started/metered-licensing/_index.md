---
title: Měřené licencování
type: docs
weight: 100
url: /cs/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "Zjistěte, jak vám měřené licencování Aspose.Slides pro Java umožní flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit jen za to, co použijete."
---
## **Úvod**

Měřené licencování je licenční mechanismus, který lze použít společně se stávajícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřené licencování.

## **Použití měřených klíčů**

{{% alert color="primary" %}} 

Měřené licencování je nový licenční mechanismus, který lze použít společně se stávajícími licenčními metodami. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřené licencování.

Po zakoupení měřené licence získáte klíče (a ne soubor licence). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/) kterou Aspose poskytuje pro operace měření. Další podrobnosti najdete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/).

1. Předávejte své veřejné a soukromé klíče metodě [setMeteredKey](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Proveďte nějaké zpracování (provedení úkolů).

1. Zavolejte metodu [getConsumptionQuantity](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/#getConsumptionQuantity--) třídy `Metered`.

Měli byste vidět množství/počet API požadavků, které jste doposud spotřebovali.

Tento ukázkový kód vám ukazuje, jak použít měřené licencování:

```java
// Vytvoří instanci třídy Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Předá veřejný a soukromý klíč objektu Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Získá hodnotu spotřebovaného množství před voláním API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Proveďte něco s API Aspose.Slides zde
    // ...

    // Získá hodnotu spotřebovaného množství po volání API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="POZNÁMKA"  %}} 

Pro použití měřeného licencování potřebujete stabilní připojení k internetu, protože licenční mechanismus používá internet k neustálé interakci s našimi službami a provádění výpočtů.

{{% /alert %}} 

## **Často kladené otázky**

**Mohu používat měřenou licenci společně s běžnou (trvalou nebo dočasnou) licencí ve stejné aplikaci?**

Ano. Měřené licencování je doplňkový licenční mechanismus, který lze použít společně se stávajícími [licenčními metodami](/slides/cs/java/licensing/). Vyberete, který mechanismus použijete při spuštění aplikace.

**Co se přesně počítá jako spotřeba při měřené licenci: operace nebo soubory?**

Počítá se využití API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [metod sledování spotřeby](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/).

**Je měřené licencování vhodné pro mikroservisy a serverless prostředí, kde se instance často restartují?**

Ano. Jelikož se účtování provádí na úrovni API volání, scénáře s častými studenými starty jsou kompatibilní, pokud je k dispozici stabilní síťové připojení pro výpočty měřeného licencování.

**Liší se funkčnost knihovny při použití měřené licence oproti trvalé licenci?**

Ne. Jedná se pouze o licenční a fakturační mechanismus; schopnosti produktu jsou stejné.

**Jak se měřené licencování vztahuje k zkušební verzi a dočasné licenci?**

Zkušební verze má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dnů a měřené licencování odstraňuje omezení a účtuje se na základě skutečného využití.

**Mohu řídit rozpočet automatickým reagováním při překročení prahu spotřeby?**

Ano. Běžnou praxí je periodicky číst aktuální spotřebu pomocí [sledovacích metod](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.