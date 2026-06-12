---
title: Správa calloutů v grafech prezentací pomocí С++
linktitle: Popisek
type: docs
url: /cs/cpp/callout/
keywords:
- callout grafu
- použít callout
- popisek dat
- formát popisku
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Vytvářejte a stylizujte callouty v Aspose.Slides pro С++ pomocí stručných ukázek kódu, kompatibilních s PPT a PPTX, pro automatizaci pracovních postupů v prezentacích."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s callouty pro popisky dat v grafu v Aspose.Slides. Ukazuje, jak použít metodu `set_ShowLabelAsDataCallout` k zobrazení popisků jako calloutů, jak nakonfigurovat nastavení popisků související s callouty pro prstencový graf a uvádí, že callouty a jejich vzhled jsou zachovány při exportu prezentací do formátů PDF, HTML5, SVG a rastrových obrázků.

## **Používání calloutů**
Nová vlastnost **ShowLabelAsDataCallout** byla přidána do třídy **DataLabelFormat** a rozhraní **IDataLabelFormat**, což určuje, zda bude popisek dat v uvedeném grafu zobrazen jako callout nebo jako běžný popisek. V níže uvedeném příkladu jsme nastavili callouty.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Nastavení calloutu pro prstencový graf**
Aspose.Slides pro C++ poskytuje podporu pro nastavení tvaru calloutu popisků dat řady pro prstencový graf. Níže je uveden příklad.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Často kladené otázky**

**Jsou callouty zachovány při konverzi prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Callouty jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/cpp/export-to-html5/), [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) nebo [raster images](/slides/cs/cpp/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují vlastní písma v calloutech a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [embedding fonts](/slides/cs/cpp/embedded-font/) do prezentace a řídí vložení písem během exportu, jako je [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), což zajišťuje, že callouty vypadají stejně na různých systémech.