---
title: Převést prezentace PowerPoint na animované GIFy v JavaScriptu
linktitle: PowerPoint na GIF
type: docs
weight: 65
url: /cs/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- animovaný GIF
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na GIF
- prezentace na GIF
- snímek na GIF
- PPT na GIF
- PPTX na GIF
- uložit PPT jako GIF
- uložit PPTX jako GIF
- exportovat PPT jako GIF
- exportovat PPTX jako GIF
- výchozí nastavení
- vlastní nastavení
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše převádějte prezentace PowerPoint (PPT, PPTX) na animované GIFy v JavaScriptu pomocí Aspose.Slides pro Node.js přes Javu. Rychlé, vysoce kvalitní výsledky."
---
## **Přehled**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint na animované soubory GIF pouze pomocí několika řádků kódu. To je užitečné, když potřebujete sdílet obsah snímků v lehkém, široce podporovaném animovaném formátu, který lze vložit do webových stránek, messengeri nebo dokumentace. Tento článek vysvětluje, jak exportovat prezentaci do GIFu s výchozími nastaveními a jak přizpůsobit výstup konfigurací možností, jako je velikost snímku, prodleva mezi snímky a rychlost přechodu snímků prostřednictvím [GifOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/gifoptions/).

## **Převod prezentací na animovaný GIF s výchozími nastaveními**

Tento ukázkový kód v JavaScriptu vám ukazuje, jak převést prezentaci na animovaný GIF pomocí standardních nastavení:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Animovaný GIF bude vytvořen s výchozími parametry. 

{{%  alert  title="TIP"  color="primary"  %}}
Pokud chcete přizpůsobit parametry GIFu, můžete použít třídu [GifOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GifOptions). Podívejte se na ukázkový kód níže.
{{% /alert %}} 

## **Převod prezentací na animovaný GIF s vlastními nastaveními**

Tento ukázkový kód vám ukazuje, jak převést prezentaci na animovaný GIF s vlastními nastaveními v JavaScriptu:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// velikost výsledného GIFu
    gifOptions.setDefaultDelay(2000);// jak dlouho bude každý snímek zobrazen, než bude změněn na další
    gifOptions.setTransitionFps(35);// zvýšit FPS pro lepší kvalitu přechodové animace
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Můžete vyzkoušet ZDARMA konvertor [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) vyvinutý společností Aspose. 
{{% /alert %}}

## **Často kladené otázky**

**Co když fonty použité v prezentaci nejsou nainstalovány v systému?**

Nainstalujte chybějící fonty nebo [configure fallback fonts](/slides/cs/nodejs-java/powerpoint-fonts/). Aspose.Slides je nahradí, ale vzhled se může lišit. Pro branding vždy zajistěte, aby požadované typy písma byly explicitně k dispozici.

**Mohu překrýt vodoznak na snímcích GIFu?**

Ano. [Add a semi-transparent object/logo](/slides/cs/nodejs-java/watermark/) přidejte do hlavního snímku nebo na jednotlivé snímky před exportem – vodoznak se objeví na každém snímku.