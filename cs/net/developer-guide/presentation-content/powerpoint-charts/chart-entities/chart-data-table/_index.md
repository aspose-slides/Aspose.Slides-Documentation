---
title: Přizpůsobení datových tabulek grafů v prezentacích v .NET
linktitle: Datová tabulka
type: docs
url: /cs/net/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte datové tabulky grafů v .NET pro PPT a PPTX pomocí Aspose.Slides a zvyšte efektivitu a atraktivitu v prezentacích."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s datovými tabulkami grafů v Aspose.Slides. Ukazuje, jak zobrazit datovou tabulku pro graf a přizpůsobit její formátování textu nastavením vlastností písma, jako je tučný styl a výška fontu. Příklad demonstruje načtení prezentace, přidání grafu, povolení datové tabulky grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

Obsahuje také stručné odpovědi na časté otázky o zobrazování legendových klíčů v datové tabulce grafu, zachování datové tabulky při exportu, práci s grafy načtenými ze stávajících prezentací nebo šablon a identifikaci grafů, u nichž je datová tabulka povolena.

## **Nastavení vlastností fontu pro datovou tabulku grafu**
Aspose.Slides pro .NET poskytuje podporu pro změnu barvy kategorií v barvě série.

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) třídy.
1. Přidejte graf na snímek.
1. nastavit tabulku grafu.
1. Nastavte výšku fontu.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v datové tabulce grafu?**

Ano. Datová tabulka podporuje [legendové klíče](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/datatable/showlegendkey/), a můžete je zapnout nebo vypnout.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/net/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/net/convert-powerpoint-to-html/)/[obrázek](/slides/cs/net/convert-powerpoint-to-png/) obsahuje graf s jeho datovou tabulkou.

**Jsou datové tabulky podporovány u grafů, které pocházejí ze souboru šablony?**

Ano. U libovolného grafu načteného ze stávající prezentace nebo šablony můžete zkontrolovat a změnit, zda je datová tabulka [zobrazena](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/hasdatatable/) pomocí vlastností grafu.

**Jak mohu rychle najít, které grafy v souboru mají povolenou datovou tabulku?**

Prozkoumejte vlastnost každého grafu, která udává, zda je datová tabulka [zobrazena](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/hasdatatable/), a projděte snímky, abyste identifikovali grafy, u nichž je povolena.