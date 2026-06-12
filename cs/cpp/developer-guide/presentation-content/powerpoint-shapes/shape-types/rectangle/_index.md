---
title: Přidání obdélníků do prezentací v C++
linktitle: Obdélník
type: docs
weight: 80
url: /cs/cpp/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vylepšete své PowerPoint prezentace přidáním obdélníků pomocí Aspose.Slides pro C++ – snadno navrhujte a upravujte tvary programově."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat obdélníkové tvary do snímků PowerPointu. Popisuje vytvoření jednoduchého obdélníku, vytvoření formátovaného obdélníku a uložení aktualizované prezentace jako souboru PPTX.

## **Vytvoření jednoduchého obdélníku**
Stejně jako předchozí témata, i toto se týká přidání tvaru a tentokrát se budeme zabývat tvarem Obdélník. V tomto tématu jsme popisovali, jak vývojáři mohou pomocí Aspose.Slides pro C++ přidat jednoduché nebo formátované obdélníky do svých snímků. Chcete-li přidat jednoduchý obdélník do vybraného snímku prezentace, postupujte podle následujících kroků:

1. Vytvořte instance [Presentation class](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte IAutoShape typu Rectangle pomocí metody AddAutoShape, kterou poskytuje objekt IShapes.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Vytvoření formátovaného obdélníku**
Chcete-li přidat formátovaný obdélník do snímku, postupujte podle následujících kroků:

1. Vytvořte instance [Presentation class](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte IAutoShape typu Rectangle pomocí metody AddAutoShape, kterou poskytuje objekt IShapes.
1. Nastavte typ výplně obdélníku na Solid.
1. Nastavte barvu obdélníku pomocí vlastnosti SolidFillColor.Color, kterou poskytuje objekt FillFormat přiřazený k objektu IShape.
1. Nastavte barvu čar obdélníku.
1. Nastavte šířku čar obdélníku.
1. Uložte upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **Často kladené otázky**

**Jak přidat obdélník se zaoblenými rohy?**

Použijte typ tvaru [shape type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapetype/) s zaoblenými rohy a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí úprav geometrie.

**Jak vyplnit obdélník obrázkem (texturou)?**

Vyberte typ výplně [fill type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/), zadejte zdroj obrázku a nakonfigurujte [stretching/tiling modes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/cpp/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu proměnit obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/cpp/manage-hyperlinks/) na kliknutí tvaru (přechod na snímek, soubor, webovou adresu nebo e-mail).

**Jak mohu chránit obdélník před přesouváním a změnami?**

[Use shape locks](/slides/cs/cpp/applying-protection-to-presentation/): můžete zakázat přesouvání, změnu velikosti, výběr nebo úpravu textu a tak zachovat rozvržení.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](http://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) do obrázku se zadanou velikostí/měřítkem nebo jej [export it as SVG](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/) pro použití ve vektorovém formátu.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníku s ohledem na šablonu a dědičnost?**

[Use the shape’s effective properties](/slides/cs/cpp/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují styly šablony, rozvržení a místní nastavení, což usnadňuje analýzu formátování.