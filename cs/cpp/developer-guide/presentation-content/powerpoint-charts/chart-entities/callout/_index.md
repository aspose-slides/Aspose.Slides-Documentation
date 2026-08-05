---
title: Správa calloutů v grafech prezentací pomocí C++
linktitle: Callout
type: docs
url: /cs/cpp/callout/
keywords:
- callout grafu
- použití calloutu
- popisek dat
- formát popisku
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte a stylizujte callouty v Aspose.Slides pro C++ pomocí stručných ukázek kódu, kompatibilních s PPT a PPTX, a automatizujte pracovní postupy prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s callouty pro popisky dat v grafech v Aspose.Slides. Ukazuje, jak použít metodu `set_ShowLabelAsDataCallout` k zobrazení popisků jako callouty, jak nakonfigurovat nastavení popisků související s callouty pro prstencový graf a uvádí, že callouty a jejich vzhled jsou zachovány při exportu prezentací do PDF, HTML5, SVG a rastrových formátů obrázků.

## **Používání calloutů**
Nová vlastnost **ShowLabelAsDataCallout** byla přidána do třídy **DataLabelFormat** a rozhraní **IDataLabelFormat**, která určuje, zda bude popisek dat v určeném grafu zobrazen jako callout nebo jako popisek. V uvedeném příkladu jsme nastavili callouty.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Nastavení calloutu pro prstencový graf**
Aspose.Slides pro C++ poskytuje podporu pro nastavení tvaru calloutu popisku dat série pro prstencový graf. Níže je uveden ukázkový příklad.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Často kladené otázky**

**Zachovají se callouty při převodu prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Callouty jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/cpp/export-to-html5/), [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/), nebo [rastrových obrázků](/slides/cs/cpp/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují vlastní fonty v calloutech a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání fontů](/slides/cs/cpp/embedded-font/) do prezentace a řídí vkládání fontů během exportů, jako je [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), což zajišťuje, že callouty vypadají stejně na různých systémech.