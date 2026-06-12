---
title: "Přizpůsobení prstencových grafů v prezentacích pomocí C++"
linktitle: "Prstencový graf"
type: docs
weight: 30
url: /cs/cpp/doughnut-chart/
keywords:
- "prstencový graf"
- "střední mezera"
- "velikost díry"
- "PowerPoint"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Objevte, jak vytvářet a přizpůsobovat prstencové grafy v Aspose.Slides pro C++, s podporou formátů PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu na snímek, nastavením velikosti jeho středové díry a uložením prezentace. Soustředí se na metodu `set_DoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

## **Určete střední mezeru v prstencovém grafu**
Pro určení velikosti díry v prstencovém grafu postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Přidejte prstencový graf na snímek.
- Určete velikost díry v prstencovém grafu.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v prstencovém grafu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Často kladené otázky**

**Mohu vytvořit víceúrovňový prstenec s několika kruhy?**

Ano. Přidejte do jediného prstencového grafu více sérií – každá série se stane samostatným kruhem. Pořadí kruhů je určeno pořadím sérií v kolekci.

**Je podporován „explodovaný“ prstenec (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) a vlastnost explozí na datových bodech; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek prstencového grafu (PNG/SVG) pro zprávu?**

Graf je tvar; můžete jej vykreslit jako [rastrový obrázek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) nebo exportovat graf do [SVG obrázku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/).