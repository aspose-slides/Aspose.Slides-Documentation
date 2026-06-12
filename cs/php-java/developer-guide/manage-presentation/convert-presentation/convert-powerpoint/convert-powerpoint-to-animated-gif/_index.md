---
title: "Převod prezentací PowerPoint na animované GIFy v PHP"
linktitle: "PowerPoint na GIF"
type: docs
weight: 65
url: /cs/php-java/convert-powerpoint-to-animated-gif/
keywords:
- animovaný GIF
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
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
- PHP
- Aspose.Slides
description: "Jednoduše převádějte prezentace PowerPoint (PPT, PPTX) na animované GIFy pomocí Aspose.Slides pro PHP prostřednictvím Javy. Rychlé, vysoce kvalitní výsledky."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint na animované soubory GIF pomocí několika řádků kódu. To je užitečné, když potřebujete sdílet obsah snímků v lehkém, široce podporovaném animovaném formátu, který lze vložit do webových stránek, messengerů nebo dokumentace. Tento článek vysvětluje, jak exportovat prezentaci do GIFu pomocí výchozích nastavení a jak přizpůsobit výstup konfigurací možností, jako je velikost snímku, prodleva mezi snímky a frekvence přechodových snímků prostřednictvím [GifOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/gifoptions/).

## **Převod prezentací do animovaného GIFu pomocí výchozích nastavení**

Ukázkový kód vám ukazuje, jak převést prezentaci do animovaného GIFu pomocí standardních nastavení:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Animovaný GIF bude vytvořen s výchozími parametry.

{{%  alert  title="TIP"  color="primary"  %}} 
Pokud dáváte přednost přizpůsobení parametrů pro GIF, můžete použít třídu [GifOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GifOptions). Viz ukázkový kód níže.
{{% /alert %}} 

## **Převod prezentací do animovaného GIFu pomocí vlastních nastavení**
Ukázkový kód vám ukazuje, jak převést prezentaci do animovaného GIFu pomocí vlastních nastavení :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// velikost výsledného GIFu

    $gifOptions->setDefaultDelay(2000);// jak dlouho bude každý snímek zobrazen, než bude změněn na další

    $gifOptions->setTransitionFps(35);// zvýšit FPS pro lepší kvalitu přechodové animace

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Možná budete chtít vyzkoušet ZDARMA konvertor [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) vyvinutý společností Aspose.
{{% /alert %}}

## **FAQ**

**Co když písma použité v prezentaci nejsou nainstalována v systému?**

Nainstalujte chybějící písma nebo [nastavte náhradní písma](/slides/cs/php-java/powerpoint-fonts/). Aspose.Slides nahradí, ale vzhled se může lišit. Pro branding vždy zajistěte, aby požadované typy písma byly výslovně k dispozici.

**Mohu přidat vodoznak na snímky GIFu?**

Ano. [Přidejte poloprůhledný objekt/logo](/slides/cs/php-java/watermark/) do hlavního snímku nebo do jednotlivých snímků před exportem — vodoznak se objeví na každém snímku.