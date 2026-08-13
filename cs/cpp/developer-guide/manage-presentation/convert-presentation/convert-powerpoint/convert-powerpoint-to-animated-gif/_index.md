---
title: Převést prezentace PowerPoint na animované GIFy v C++
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
description: "Jednoduše převádějte prezentace PowerPoint (PPT, PPTX) na animované GIFy pomocí Aspose.Slides pro C++. Rychlé, vysoce kvalitní výsledky."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint na animované soubory GIF pomocí několika řádků kódu. To je užitečné, když potřebujete sdílet obsah snímků v lehkém, široce podporovaném animovaném formátu, který lze vložit do webových stránek, messengerů nebo dokumentace. Tento článek vysvětluje, jak exportovat prezentaci do GIFu pomocí výchozích nastavení a jak přizpůsobit výstup konfigurací možností, jako je velikost snímku, prodleva snímku a frekvence přechodových snímků pomocí [GifOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/gifoptions/).

## **Převod prezentací na animovaný GIF pomocí výchozích nastavení**

Tento ukázkový kód v C++ vám ukazuje, jak převést prezentaci na animovaný GIF pomocí standardních nastavení:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Animovaný GIF bude vytvořen s výchozími parametry.

{{%  alert  title="TIP"  color="info"  %}} 
Pokud chcete přizpůsobit parametry GIFu, můžete použít třídu [GifOptions](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.gif_options). Viz ukázkový kód níže. 
{{% /alert %}} 

## **Převod prezentací na animovaný GIF pomocí vlastních nastavení**

Tento ukázkový kód vám ukazuje, jak převést prezentaci na animovaný GIF pomocí vlastních nastavení v C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// velikost vytvořeného GIFu
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// jak dlouho bude každý snímek zobrazen, než se přepne na další
gifOptions->set_DefaultDelay(2000);
// zvyšte FPS pro lepší kvalitu přechodové animace
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Možná budete chtít vyzkoušet ZDARMA převodník [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) vyvinutý společností Aspose. 
{{% /alert %}}

## **Často kladené dotazy**

### Co když písma použité v prezentaci nejsou nainstalována v systému?

Nainstalujte chybějící písma nebo [nastavte záložní písma](/slides/cs/cpp/powerpoint-fonts/). Aspose.Slides je nahradí, ale vzhled se může lišit. Pro značku vždy zajistěte, aby požadovaná písma byla explicitně k dispozici.

### Mohu přidat vodoznak na snímky GIFu?

Ano. [Přidejte poloprůhledný objekt/logo](/slides/cs/cpp/watermark/) do hlavního snímku nebo do jednotlivých snímků před exportem — vodoznak se objeví na každém snímku.