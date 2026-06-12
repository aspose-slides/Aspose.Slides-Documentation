---
title: Převod prezentací PowerPoint na animované GIFy v Androidu
linktitle: PowerPoint do GIF
type: docs
weight: 65
url: /cs/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- animovaný GIF
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint do GIF
- prezentace do GIF
- snímek do GIF
- PPT do GIF
- PPTX do GIF
- uložit PPT jako GIF
- uložit PPTX jako GIF
- exportovat PPT jako GIF
- exportovat PPTX jako GIF
- výchozí nastavení
- vlastní nastavení
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše převádějte prezentace PowerPoint (PPT, PPTX) na animované GIFy pomocí Aspose.Slides pro Android v Javě. Rychlé, vysoce kvalitní výsledky."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint na animované soubory GIF pomocí pouhých několika řádků kódu. To je užitečné, když potřebujete sdílet obsah snímků v lehkém, široce podporovaném animovaném formátu, který lze vložit do webových stránek, messengerů nebo dokumentace. Tento článek vysvětluje, jak exportovat prezentaci do formátu GIF pomocí výchozích nastavení a jak přizpůsobit výstup konfigurací možností, jako je velikost snímku, prodleva mezi snímky a rychlost přechodových snímků prostřednictvím [GifOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/gifoptions/).

## **Převod prezentací na animovaný GIF pomocí výchozích nastavení**

Tento ukázkový kód v Javě ukazuje, jak převést prezentaci na animovaný GIF pomocí standardních nastavení:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Animovaný GIF bude vytvořen s výchozími parametry. 

{{%  alert  title="TIP"  color="primary"  %}} 
Pokud chcete přizpůsobit parametry GIFu, můžete použít třídu [GifOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/GifOptions). Níže najdete ukázkový kód.
{{% /alert %}} 

## **Převod prezentací na animovaný GIF pomocí vlastních nastavení**

Tento ukázkový kód ukazuje, jak převést prezentaci na animovaný GIF pomocí vlastních nastavení v Javě:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // velikost výsledného GIFu
	gifOptions.setDefaultDelay(2000); // jak dlouho bude každý snímek zobrazen, dokud nebude nahrazen dalším
	gifOptions.setTransitionFps(35); // zvýšení FPS pro lepší kvalitu přechodové animace
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Možná budete chtít vyzkoušet ZDARMA převodník [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) vyvinutý společností Aspose. 
{{% /alert %}}

## **Často kladené otázky**

**Co když nejsou v systému nainstalovány písma použité v prezentaci?**

Nainstalujte chybějící písma nebo [nastavte náhradní písma](/slides/cs/androidjava/powerpoint-fonts/). Aspose.Slides je nahradí, ale vzhled se může lišit. Pro branding vždy zajistěte, aby požadované typy písma byly explicitně k dispozici.

**Mohu překrýt vodoznak na rámcích GIFu?**

Ano. [Přidejte poloprůhledný objekt/logo](/slides/cs/androidjava/watermark/) do hlavního snímku nebo na jednotlivé snímky před exportem – vodoznak se objeví na každém rámci.