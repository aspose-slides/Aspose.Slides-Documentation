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
description: "Zjistěte, jak měřené licencování Aspose.Slides pro Javu umožňuje flexibilně zpracovávat soubory PowerPoint a OpenDocument a platit jen za to, co použijete."
---
## **Úvod**

Měřené licencování je licenční mechanismus, který lze použít vedle existujících licenčních metod. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřené licencování.

## **Použití měřených klíčů**

{{% alert color="info" %}} 

Měřené licencování je nový licenční mechanismus, který lze použít vedle existujících licenčních metod. Pokud chcete být fakturováni na základě využití funkcí Aspose.Slides API, zvolíte měřené licencování.

Když si zakoupíte měřenou licenci, získáte klíče (ne soubor licence). Tento měřený klíč lze použít pomocí třídy [Metered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/) poskytované společností Aspose pro operace měření. Další podrobnosti naleznete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Vytvořte instanci třídy [Metered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/).

1. Předajte své veřejné a soukromé klíče metodě [setMeteredKey](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Proveďte zpracování (vykonejte úlohy).

1. Zavolejte metodu [getConsumptionQuantity](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/#getConsumptionQuantity--) třídy `Metered`.

Měli byste vidět množství/počet API požadavků, které jste doposud spotřebovali.

Tento ukázkový kód vám ukazuje, jak použít měřené licencování:

```java
// Vytvoří instanci třídy Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Předá veřejný a soukromý klíč objektu Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Získá hodnotu spotřebovaného množství před voláními API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Proveďte něco s Aspose.Slides API zde
    // ...

    // Získá hodnotu spotřebovaného množství po voláních API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Pro používání měřeného licencování potřebujete stabilní internetové připojení, protože licenční mechanismus používá internet k neustálé interakci s našimi službami a provádění výpočtů.

{{% /alert %}} 

## **Často kladené otázky**

### Mohu použít měřenou licenci spolu s běžnou licencí (trvalou nebo dočasnou) ve stejné aplikaci?

Ano. Měřené licencování je doplňkový licenční mechanismus, který lze použít vedle existujících [licenčních metod](/slides/cs/java/licensing/). Vyberete, který mechanismus použijete při spuštění aplikace.

### Co se přesně počítá jako spotřeba v rámci měřené licence: operace nebo soubory?

Počítá se využití API, tj. počet požadavků nebo operací. Aktuální spotřebu můžete získat pomocí [metod sledování spotřeby](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/).

### Je měřená licence vhodná pro mikroslužby a serverless prostředí, kde se instance často restartují?

Ano. Protože účtování probíhá na úrovni jednotlivých API volání, scénáře s častými “cold starty” jsou kompatibilní, pokud je k dispozici stabilní síťové připojení pro výpočty měření.

### Liší se funkčnost knihovny při použití měřené licence oproti trvalé licenci?

Ne. Jedná se pouze o licenční a fakturační mechanismus; schopnosti produktu zůstávají stejné.

### Jak se měřené licencování vztahuje k zkušební verzi a dočasné licenci?

Zkušební verze má omezení a vodoznaky, [dočasná licence](https://purchase.aspose.com/temporary-license/) odstraňuje omezení na 30 dní a měřené licencování odstraňuje omezení a účtuje se na základě skutečného využití.

### Můžu kontrolovat rozpočet automatickým reakcí, když je překročena prahová hodnota spotřeby?

Ano. Běžnou praxí je periodicky číst aktuální spotřebu pomocí [metod sledování](https://reference.aspose.com/slides/cs/java/com.aspose.slides/metered/) a implementovat vlastní limity nebo upozornění na úrovni aplikace či monitoringu.