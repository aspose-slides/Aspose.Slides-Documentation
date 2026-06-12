---
title: Přizpůsobení tabulek dat grafů v prezentacích pomocí C++
linktitle: Datová tabulka
type: docs
url: /cs/cpp/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte tabulky dat grafů v C++ pro PPT a PPTX pomocí Aspose.Slides a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat v grafech v Aspose.Slides. Ukazuje, jak zobrazit tabulku dat pro graf a přizpůsobit formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje načtení prezentace, přidání grafu, povolení tabulky dat grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

## **Nastavení vlastností písma pro tabulku dat grafu**
Aspose.Slides pro C++ umožňuje měnit vlastnosti písma pro tabulku dat grafu. 

1. Instancujte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Přidejte graf na snímek.
1. Nastavte tabulku grafu.
1. Nastavte výšku písma.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v tabulce dat grafu?**

Ano. Tabulka dat podporuje [legendové klíče](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/datatable/set_showlegendkey/), a můžete je zapnout nebo vypnout.

**Zůstane tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/cpp/convert-powerpoint-to-html/)/[obrázek](/slides/cs/cpp/convert-powerpoint-to-png/) obsahuje graf s jeho tabulkou dat.

**Jsou tabulky dat podporovány pro grafy, které pocházejí ze souboru šablony?**

Ano. Pro libovolný graf načtený z existující prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/set_hasdatatable/).

**Jak mohu rychle najít, které grafy v souboru mají povolenou tabulku dat?**

Prozkoumejte vlastnost každého grafu, která udává, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/get_hasdatatable/), a projděte snímky, abyste identifikovali grafy, kde je povolena.