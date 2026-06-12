---
title: Přidat čárové tvary do prezentací v C++
linktitle: Čára
type: docs
weight: 50
url: /cs/cpp/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čárkování
- špička šipky
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat čárové tvary do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji upravit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat čárový tvar do snímku, upravit jeho vzhled a uložit aktualizovanou prezentaci. Příklady se soustředí na praktická nastavení formátování čáry, jako je styl, šířka, vzor přerušení, možnosti špičky šipky a barva výplně.

## **Vytvořit prostou čáru**
- Vytvořte instanci třídy [Presentation class](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes.
- Uložte upravenou prezentaci jako soubor PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Vytvořit čáru se šipkou**
- Vytvořte instanci třídy [Presentation class](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes.
- Nastavte styl čáry na jeden ze stylů poskytovaných knihovnou Aspose.Slides pro C++.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linedashstyle/) čáry na jeden ze stylů poskytovaných knihovnou Aspose.Slides pro C++.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/cpp/aspose.slides/lineformat/) a délku počátečního bodu čáry.
- Nastavte styl špičky šipky a délku koncového bodu čáry.
- Uložte upravenou prezentaci jako soubor PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Mohu převést běžnou čáru na spojku, aby se „přichytávala“ k tvarům?**

Ne. Běžná čára ( [AutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapetype/)) se automaticky nepromění na spojku. Chcete-li, aby se přichytávala k tvarům, použijte specializovaný typ [Connector](https://reference.aspose.com/slides/cs/cpp/aspose.slides/connector/) a [odpovídající API](/slides/cs/cpp/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry zděděny z motivu a je obtížné zjistit konečné hodnoty?**

[Přečtěte si účinné vlastnosti](/slides/cs/cpp/shape-effective-properties/) přes rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilinefillformateffectivedata/), která již zohledňují dědičnost a styly motivu.

**Mohu uzamknout čáru proti úpravám (přesunu, změně velikosti)?**

Ano. Tvary poskytují [objekty pro uzamčení](https://reference.aspose.com/slides/cs/cpp/aspose.slides/autoshape/get_autoshapelock/), které umožňují [zakázat operace úprav](/slides/cs/cpp/applying-protection-to-presentation/).