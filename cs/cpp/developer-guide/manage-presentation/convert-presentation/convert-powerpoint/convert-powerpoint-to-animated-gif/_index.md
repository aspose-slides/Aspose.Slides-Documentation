---
title: Převod prezentací PowerPoint na animované GIFy v C++
linktitle: PowerPoint na GIF
type: docs
weight: 65
url: /cs/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "Jednoduše převádějte prezentace PowerPoint (PPT, PPTX) na animované GIFy pomocí Aspose.Slides pro C++. Rychlé a vysoce kvalitní výsledky."
---
## **Přehled**

Aspose.Slides umožňuje převést prezentace PowerPoint do animovaných souborů GIF pomocí několika řádků kódu. To je užitečné, když potřebujete sdílet obsah snímků v lehkém, široce podporovaném animovaném formátu, který lze vložit do webových stránek, messengerů nebo dokumentace. Tento článek vysvětluje, jak exportovat prezentaci do GIFu pomocí výchozích nastavení a jak přizpůsobit výstup konfigurací možností, jako je velikost snímku, zpoždění snímku a frekvence přechodových snímků pomocí [GifOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/gifoptions/).

## **Převod prezentací do animovaného GIF pomocí výchozích nastavení**

Tento ukázkový kód v C++ ukazuje, jak převést prezentaci do animovaného GIFu pomocí standardních nastavení:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Animovaný GIF bude vytvořen s výchozími parametry. 

{{%  alert  title="TIP"  color="primary"  %}} 
Pokud chcete přizpůsobit parametry GIFu, můžete použít třídu [GifOptions](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.gif_options). Viz ukázkový kód níže. 
{{% /alert %}} 

## **Převod prezentací do animovaného GIF pomocí vlastních nastavení**

Tento ukázkový kód ukazuje, jak převést prezentaci do animovaného GIFu pomocí vlastních nastavení v C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// velikost výsledného GIFu 
gifOptions->set_FrameSize(Size(960, 720));
// jak dlouho bude každý snímek zobrazen, než bude přepnut na další
gifOptions->set_DefaultDelay(2000);
// zvýšit FPS pro lepší kvalitu animačních přechodů
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Možná budete chtít vyzkoušet ZDARMA konvertor [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) vyvinutý společností Aspose. 
{{% /alert %}}

## **Často kladené otázky**

**Co když nejsou písma použité v prezentaci nainstalována v systému?**  
Nainstalujte chybějící písma nebo [nakonfigurujte náhradní písma](/slides/cs/cpp/powerpoint-fonts/). Aspose.Slides provede náhradu, ale vzhled se může lišit. Pro značkování vždy zajistěte, aby požadované typy písma byly explicitně dostupné.

**Mohu přidat vodoznak na snímky GIFu?**  
Ano. [Přidejte poloprůhledný objekt/logo](/slides/cs/cpp/watermark/) do hlavního snímku nebo do jednotlivých snímků před exportem — vodoznak se zobrazí na každém rámci.