---
title: Vytvoření grafů pomocí VSTO a Aspose.Slides pro Java
linktitle: Vytvořit graf
type: docs
weight: 70
url: /cs/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- vytvořit graf
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak automatizovat vytváření grafů v PowerPointu v jazyce Java. Tento průvodce krok po kroku ukazuje, proč je Aspose.Slides pro Java rychlejší a výkonnější alternativou k Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

Grafy jsou vizuálními reprezentacemi dat, které jsou široce používány v prezentacích. Tento článek ukazuje kód pro vytvoření grafu v Microsoft PowerPoint programově pomocí [VSTO](/slides/cs/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) a [Aspose.Slides for Java](/slides/cs/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Vytvoření grafu**
Ukázky kódu níže popisují proces přidání jednoduchého 3D seskupeného sloupcového grafu pomocí VSTO. Vytvoříte instanci prezentace, přidáte do ní výchozí graf. Pak použijete Microsoft Excel workbook k přístupu a úpravě dat grafu spolu s nastavením vlastností grafu. Nakonec prezentaci uložíte.
### **Příklad VSTO**
Pomocí VSTO jsou provedeny následující kroky:

1. Vytvořte instanci prezentace Microsoft PowerPoint.
1. Přidejte prázdný snímek do prezentace.
1. Přidejte graf **3D clustered column** a přistupte k němu.
1. Vytvořte novou instanci Microsoft Excel Workbook a načtěte data grafu.
1. Přistupte k listu s daty grafu pomocí Microsoft Excel Workbook instancefromworkbook.
1. Nastavte rozsah grafu v listu a odstraňte řady 2 a 3 z grafu.
1. Upravte data kategorií grafu v listu s daty grafu.
1. Upravte data řady 1 grafu v listu s daty grafu.
1. Nyní přistupte k názvu grafu a nastavte související vlastnosti písma.
1. Přistupte k hodnotové ose grafu a nastavte hlavní jednotku, vedlejší jednotky, maximální a minimální hodnotu.
1. Přistupte k ose hloubky nebo osy řad a odstraňte ji, protože v tomto příkladu je použita pouze jedna řada.
1. Nyní nastavte úhly otáčení grafu ve směru X a Y.
1. Uložte prezentaci.
1. Uzavřete instance Microsoft Excel a PowerPoint.

**Výstupní prezentace vytvořená pomocí VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Příklad Aspose.Slides for Java**
Pomocí Aspose.Slides for Java jsou provedeny následující kroky:

1. Vytvořte instanci prezentace Microsoft PowerPoint.
1. Přidejte prázdný snímek do prezentace.
1. Přidejte graf **3D clustered column** a přistupte k němu.
1. Přistupte k listu s daty grafu pomocí Microsoft Excel Workbook instancefromworkbook.
1. Odstraňte nepoužívané řady 2 a 3.
1. Přistupte k kategoriím grafu a upravte popisky.
1. Přistupte k řadě 1 a upravte hodnoty řady.
1. Nyní přistupte k názvu grafu a nastavte vlastnosti písma.
1. Přistupte k hodnotové ose grafu a nastavte hlavní jednotku, vedlejší jednotky, maximální a minimální hodnotu.
1. Nyní nastavte úhly otáčení grafu ve směru X a Y.
1. Uložte prezentaci ve formátu PPTX.

**Výstupní prezentace vytvořená pomocí Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

**Mohu vytvořit jiné typy grafů, jako jsou koláčové, čárové nebo sloupcové grafy, pomocí Aspose.Slides?**

Ano. Aspose.Slides podporuje širokou škálu [typy grafů](/slides/cs/java/create-chart/), včetně koláčových, čárových, sloupcových, rozptýlených, bublinových a dalších. Požadovaný typ grafu můžete zadat pomocí třídy [ChartType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) při přidávání grafu.

**Mohu na graf použít vlastní styly nebo motivy?**

Ano. Můžete plně přizpůsobit vzhled grafu, včetně barev, fontů, výplní, obrysů, mřížek a rozložení. Přesto aplikace Office motivů přesně tak, jak jsou viditelné v PowerPointu, vyžaduje ruční nastavení jednotlivých stylů.

**Mohu exportovat graf jako samostatný obrázek mimo snímek?**

Ano, Aspose.Slides umožňuje exportovat libovolný tvar – včetně grafů – jako samostatný obrázek (např. PNG, JPEG) pomocí metody `getImage` na objektu grafu [shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/).