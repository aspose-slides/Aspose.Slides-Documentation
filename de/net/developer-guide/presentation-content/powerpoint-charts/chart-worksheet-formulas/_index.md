---
title: Chart Worksheet Formulas
type: docs
weight: 70
url: /de/net/chart-worksheet-formulas/
keywords: "Diagramm‑Tabellenkalkulation, Diagrammformel, PowerPoint‑Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Diagramm‑Tabellenkalkulation und Formel in PowerPoint‑Präsentation in C# oder .NET"
---

## **Über Diagramm‑Tabellenkalkulationsformel in der Präsentation**
**Diagramm‑Tabellenkalkulation** (oder Diagramm‑Arbeitsblatt) in der Präsentation ist die Datenquelle des Diagramms. Diagramm‑Tabellenkalkulation enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das dem Diagramm zugehörige Arbeitsblatt ebenfalls automatisch erstellt. Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um die Diagramm‑Tabellenkalkulation in PowerPoint zu sehen, sollten Sie das Diagramm doppelklicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Diagramm‑Tabellenkalkulation enthält die Namen der Diagrammelemente (Kategorienname: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig, wenn Sie ein neues Diagramm erstellen, werden die Diagramm‑Tabellenkalkulationsdaten mit den Standarddaten festgelegt. Anschließend können Sie die Tabellenkalkulationsdaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplizierte Daten dar (z. B. Finanzanalysten, Wissenschaftsanwender), wobei Zellen berechnet werden aus Werten in anderen Zellen oder aus anderen dynamischen Daten. Den Zellenwert manuell zu berechnen und hartkodiert in die Zelle einzufügen, macht es schwierig, ihn in Zukunft zu ändern. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Zudem können Tabellendaten von Daten aus anderen Tabellen abhängen, wodurch ein komplexes Präsentationsdatenschema entsteht, das leicht und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenkalkulationsformel** in der Präsentation ist ein Ausdruck, um Diagramm‑Tabellenkalkulationsdaten automatisch zu berechnen und zu aktualisieren. Eine Tabellenkalkulationsformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Satz von Zellen. Eine Tabellenkalkulationsformel ist eine mathematische Formel oder eine logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umwandlungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Tabellenkalkulationsformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellenkalkulationsformeln in Präsentationen sind tatsächlich dieselben wie Excel‑Formeln, und es werden dieselben Standardfunktionen, Operatoren und Konstanten für ihre Implementierung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) wird die Diagramm‑Tabellenkalkulation durch die Eigenschaft [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) des Typs [**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) dargestellt. Tabellenkalkulationsformeln können über die Eigenschaft [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) zugewiesen und geändert werden. Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenkettenkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil Zellreferenzen
- R1C1‑Stil Zellreferenzen
- Vordefinierte Funktionen



Typischerweise speichern Tabellenkalkulationen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden – gibt die **IChartDataCell.Value**‑Eigenschaft diese Werte beim Lesen zurück. Wenn jedoch die Tabellenkalkulationsdaten geändert wurden, wirft beim Lesen der **ChartDataCell.Value**‑Eigenschaft die **CellUnsupportedDataException** für die nicht unterstützten Formeln. Das liegt daran, dass beim erfolgreichen Parsen der Formeln die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt wird. Wenn die Formel nicht geparst werden kann, kann die Korrektheit des Zellwerts nicht garantiert werden.
## **Diagramm‑Tabellenkalkulationsformel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm mit Beispieldaten zur ersten Folie einer neuen Präsentation hinzu mit [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1). Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die Eigenschaft [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) zugegriffen werden:
``` csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```




Schreiben Sie einige Werte in Zellen mit der Eigenschaft [**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) vom Typ **Object**, was bedeutet, dass Sie jedem Wert zuweisen können:
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```




Um eine Formel in die Zelle zu schreiben, können Sie die Eigenschaft [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) verwenden:
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*Hinweis*: Die Eigenschaft [**IChartDataCell.Formula**] wird verwendet, um A1‑Stil Zellreferenzen festzulegen.



Um die Zellreferenz [R1C1Formula] festzulegen, können Sie die Eigenschaft [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) verwenden:
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


Verwenden Sie dann die Methode [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas), um alle Formeln im Arbeitsbuch zu berechnen und die entsprechenden Zellwerte zu aktualisieren:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:




## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Notation verwendet werden, um Diagramm‑Tabellenkalkulationsformeln zu erstellen:




## **Zeichenkettenkonstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein spezifischer Wert, der unverändert verwendet wird und sich nicht ändert. Zeichenkettenkonstanten können sein: Daten, Texte, Zahlen usw.:




## **Fehlerkonstanten**
Manchmal ist es nicht möglich, das Ergebnis mit der Formel zu berechnen. In diesem Fall wird im Zellwert stattdessen der Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu dividieren.
- #GETTING_DATA – kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: Die in der Formel verwendeten Zellen sind leer, ein zusätzliches Leerzeichen, Tippfehler usw.
- #NAME? – eine bestimmte Zelle oder ein anderer Formelobjekt kann nicht über seinen Namen gefunden werden.
- #NULL! – kann auftreten, wenn ein Fehler in der Formel ist, z. B. (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).
- #NUM! – die im Formel verwendete Zahl ist ungültig, zu lang oder zu klein usw.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp. Zum Beispiel ein Zeichenkettenwert in einer numerischen Zelle.




## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblattformeln verwenden:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unäres Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Sternchen)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Caret)|Potenzierung |2 ^ 3|

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern.


## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis ein logischer Wert, entweder *TRUE* oder FALSE:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich |A2 = 3|
|<> (Ungleichheitszeichen) |Ungleich |A2 <> 3|
|> (Größer‑als‑Zeichen) |Größer |A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen) |Größer oder gleich |A2 >= 3|
|< (Kleiner‑als‑Zeichen) |Kleiner |A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen) |Kleiner oder gleich |A2 <= 3|

## **A1‑Stil Zellreferenzen**
**A1‑Stil Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen die Spalte eine Buchstaben‑Kennung (z. B. "A") und die Zeile eine numerische Kennung (z. B. "1") hat. A1‑Stil Zellreferenzen können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
||Absolute |Relative |Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C$4</p>|


Hier ist ein Beispiel, wie man eine A1‑Stil Zellreferenz in einer Formel verwendet:




## **R1C1‑Stil Zellreferenzen**
**R1C1‑Stil Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte eine numerische Kennung haben. R1C1‑Stil Zellreferenzen können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
||Absolute |Relative |Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie man eine A1‑Stil Zellreferenz in einer Formel verwendet:




## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten verwendeten Operationen, wie:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagrammdatenquelle](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/), wodurch Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagrammformeln Tabellenblätter innerhalb derselben Arbeitsmappe über den Blattnamen referenzieren?**

Ja. Formeln folgen dem Standard‑Excel‑Referenzmodell, sodass Sie andere Blätter innerhalb derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappennamen mit Excel‑Syntax an.