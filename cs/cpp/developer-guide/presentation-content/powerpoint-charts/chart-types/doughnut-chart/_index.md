---
title: Přizpůsobení donut grafů v prezentacích pomocí C++
linktitle: Donut graf
type: docs
weight: 30
url: /cs/cpp/doughnut-chart/
keywords:
- donut graf
- středová mezera
- velikost díry
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak vytvořit a přizpůsobit donut grafy v Aspose.Slides pro C++, s podporou formátů PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s donut grafem v Aspose.Slides přidáním grafu na snímek, nastavením velikosti středové díry a uložením prezentace. Soustředí se na metodu `set_DoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

## **Určete středovou mezeru v donut grafu**
Pro určení velikosti díry v donut grafu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
- Přidejte donut graf na snímek.
- Určete velikost díry v donut grafu.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v donut grafu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Mohu vytvořit víceúrovňový donut s více prstenci?**

Ano. Přidejte do jednoho donut grafu několik řad – každá řada se stane samostatným prstencem. Pořadí prstenců je určeno pořadím řad v kolekci.

**Je podporován „rozpraskaný“ donut (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) a vlastnost exploze na datových bodech; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek donut grafu (PNG/SVG) pro zprávu?**

Graf je tvar; můžete jej vykreslit do [rastru obrazu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) nebo exportovat graf do [SVG obrazu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/).