---
title: Převod PowerPoint prezentací na animované GIFy v .NET
linktitle: PowerPoint na GIF
type: docs
weight: 65
url: /cs/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Jednoduše převádějte PowerPoint prezentace (PPT, PPTX) na animované GIFy pomocí Aspose.Slides pro .NET. Rychlé, vysoce kvalitní výsledky."
---
## **Přehled**

Aspose.Slides vám umožňuje převádět PowerPoint prezentace na animované soubory GIF pomocí několika řádků kódu. To je užitečné, když potřebujete sdílet obsah snímků v lehkém, široce podporovaném animovaném formátu, který lze vložit do webových stránek, messengerů nebo dokumentace. Tento článek vysvětluje, jak exportovat prezentaci do GIFu pomocí výchozích nastavení a jak přizpůsobit výstup konfigurací možností, jako je velikost snímku, prodleva snímku a frekvence přechodových snímků prostřednictvím [GifOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/gifoptions/).

## **Převod prezentací na animovaný GIF pomocí výchozích nastavení**

Tento ukázkový kód v C# ukazuje, jak převést prezentaci na animovaný GIF pomocí standardních nastavení:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Animovaný GIF bude vytvořen s výchozími parametry. 

{{%  alert  title="TIP"  color="info"  %}} 
Pokud dáváte přednost přizpůsobení parametrů pro GIF, můžete použít třídu [GifOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/gifoptions). Viz ukázkový kód níže. 
{{% /alert %}} 

## **Převod prezentací na animovaný GIF pomocí vlastních nastavení**

Tento ukázkový kód ukazuje, jak převést prezentaci na animovaný GIF pomocí vlastních nastavení v C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // velikost výsledného GIFu
        DefaultDelay = 2000, // jak dlouho bude každý snímek zobrazen, než bude přepnut na další
        TransitionFps = 35 // zvýšit FPS pro lepší kvalitu animačních přechodů
    });
}
```

{{% alert title="Info" color="info" %}}
Možná budete chtít vyzkoušet ZDARMA převodník Text na GIF vyvinutý společností Aspose. 
{{% /alert %}}

## **Často kladené otázky**

### Co když písma použité v prezentaci nejsou nainstalována v systému?

Nainstalujte chybějící písma nebo [nastavte náhradní písma](/slides/cs/net/powerpoint-fonts/). Aspose.Slides je nahradí, ale vzhled se může lišit. Pro branding vždy zajistěte, aby požadované typy písma byly výslovně dostupné.

### Mohu překrýt vodotisk na snímcích GIFu?

Ano. [Přidejte poloprůhledný objekt/logo](/slides/cs/net/watermark/) na hlavní snímek nebo na jednotlivé snímky před exportem — vodotisk se objeví na každém snímku.