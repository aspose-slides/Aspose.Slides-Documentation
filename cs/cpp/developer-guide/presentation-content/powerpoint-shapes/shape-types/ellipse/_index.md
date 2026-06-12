---
title: Přidání elips do prezentací v C++
linktitle: Elipsa
type: docs
weight: 30
url: /cs/cpp/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- kreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se vytvářet, formátovat a manipulovat s elipsovými tvary v Aspose.Slides pro C++ v prezentacích PPT a PPTX — zahrnuty příklady kódu v C++."
---
## **Přehled**

Tento článek ukazuje, jak přidat elipsové tvary do snímků PowerPoint pomocí Aspose.Slides. Popisuje vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Zabývá se také souvisejícími otázkami, jako je práce s pozicí a velikostí elipsy, řízení pořadí vrstvení a použití animačních efektů.

## **Vytvořit elipsu**
V tomto tématu představíme vývojářům, jak přidat elipsové tvary do svých snímků pomocí Aspose.Slides for C++. Aspose.Slides for C++ poskytuje jednodušší sadu API pro kreslení různých typů tvarů pomocí několika řádků kódu. Pro přidání jednoduché elipsy do vybraného snímku prezentace postupujte podle níže uvedených kroků:

1. Vytvořte instanci [Presentation class](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)
1. Získejte odkaz na snímek pomocí jeho Indexu
1. Přidejte AutoShape typu Ellipse pomocí metody AddAutoShape poskytované objektem IShapes
1. Uložte upravenou prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme přidali elipsu na první snímek.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Vytvořit formátovanou elipsu**
Pro přidání lépe naformátované elipsy na snímek postupujte podle níže uvedených kroků:

1. Vytvořte instanci [Presentation class](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho Indexu.
1. Přidejte AutoShape typu Ellipse pomocí metody AddAutoShape poskytované objektem IShapes.
1. Nastavte typ výplně elipsy na Solid.
1. Nastavte barvu elipsy pomocí vlastnosti SolidFillColor.Color, jak je poskytována objektem FillFormat přidruženým k objektu IShape.
1. Nastavte barvu čar elipsy.
1. Nastavte šířku čar elipsy.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali na první snímek prezentace formátovanou elipsu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **Často kladené otázky**

**Jak nastavit přesnou pozici a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a rozměry se typicky udávají **v bodech**. Pro předvídatelné výsledky založte své výpočty na velikosti snýmku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládat pořadí vrstev)?**

Upravte pořadí kreslení objektu tím, že jej přenesete dopředu nebo dozadu. Tím umožníte, aby elipsa překrývala jiné objekty nebo odhalila objekty pod ní.

**Jak animovat zobrazení nebo zdůraznění elipsy?**

[Apply](/slides/cs/cpp/shape-animation/) vstupní, zdůrazňovací nebo ukončovací efekty na tvar a nakonfigurujte spouštěče a časování, aby bylo určeno, kdy a jak se animace přehraje.