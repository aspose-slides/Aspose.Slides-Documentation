---
title: Diagramm Arbeitsblatt Formeln
type: docs
weight: 70
url: /de/net/chart-worksheet-formulas/
keywords: "Diagramm Tabellenkalkulation, Diagramm Formel, PowerPoint Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Diagramm Tabellenkalkulation und Formel in PowerPoint Präsentation in C# oder .NET"
---


## **Über die Diagramm Tabellenkalkulation Formel in Präsentationen**
**Diagramm Tabellenkalkulation** (oder Diagramm Arbeitsblatt) in Präsentationen ist die Datenquelle des Diagramms. Diagramm Tabellenkalkulation enthält Daten, die grafisch im Diagramm dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird auch das Arbeitsblatt, das mit diesem Diagramm verbunden ist, automatisch erstellt. Das Diagramm Arbeitsblatt wird für alle Arten von Diagrammen erstellt: Liniendiagramm, Säulendiagramm, Sonnenblumen-Diagramm, Kreisdiagramm usw. Um die Diagramm Tabellenkalkulation in PowerPoint zu sehen, sollten Sie doppelt auf das Diagramm klicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Die Diagramm Tabellenkalkulation enthält die Namen der Diagrammelemente (Kategoriename: *Kategorie1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig, wenn Sie ein neues Diagramm erstellen - werden die Daten der Diagramm Tabellenkalkulation mit den Standarddaten gesetzt. Dann können Sie die Tabellenkalkulationsdaten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplizierte Daten dar (z.B. Finanzanalysen, wissenschaftliche Analysen), mit Zellen, die aus den Werten in anderen Zellen oder aus anderen dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und ihn fest in die Zelle einzutragen, macht es schwierig, ihn in Zukunft zu ändern. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen auch alle Zellen, die davon abhängen, aktualisiert werden. Darüber hinaus können tabellarische Daten von den Daten anderer Tabellen abhängig sein, was ein komplexes Schema von Präsentationsdaten schafft, das auf eine einfache und flexible Weise aktualisiert werden muss.

**Die Diagramm Tabellenkalkulation Formel** in Präsentationen ist ein Ausdruck, um automatisch die Daten der Diagramm Tabellenkalkulation zu berechnen und zu aktualisieren. Die Tabellenkalkulationsformel definiert die Logik zur Berechnung der Daten für eine bestimmte Zelle oder eine Gruppe von Zellen. Eine Tabellenkalkulationsformel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umrechnungsfunktionen, Stringkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Tabellenkalkulationsformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm Tabellenkalkulationsformeln in Präsentationen sind tatsächlich die gleichen wie Excel-Formeln, und es werden die gleichen Standardfunktionen, Operatoren und Konstanten für ihre Implementierung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) wird die Diagramm Tabellenkalkulation mit der 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) Eigenschaft des 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) Typs dargestellt. 
Die Tabellenkalkulationsformel kann mit der 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) Eigenschaft zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Stringkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1-style Zellreferenzen
- R1C1-style Zellreferenzen
- Vorab definierte Funktionen



In der Regel speichern Tabellenkalkulationen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden - gibt die **IChartDataCell.Value** Eigenschaft diese Werte beim Lesen zurück. Wenn jedoch die Daten der Tabellenkalkulation geändert wurden, wird beim Lesen der **ChartDataCell.Value** Eigenschaft die **CellUnsupportedDataException** für die nicht unterstützten Formeln ausgelöst. Dies liegt daran, dass, wenn die Formeln erfolgreich geparst werden, die Zellabhängigkeiten bestimmt und die Richtigkeit der letzten Werte festgestellt wird. Kann die Formel jedoch nicht geparst werden, kann die Richtigkeit des Zellwerts nicht garantiert werden.
## **Diagramm Tabellenkalkulation Formel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm mit einigen Beispieldaten zur ersten Folie einer neuen Präsentation mit 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1) hinzu. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit der 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) Eigenschaft zugegriffen werden:



``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```



Lassen Sie uns einige Werte in Zellen mit der 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) Eigenschaft 
des **Object** Typs schreiben, was bedeutet, dass Sie jeden Wert der Eigenschaft zuweisen können:



``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```



Jetzt, um die Formel in die Zelle zu schreiben, können Sie die 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) Eigenschaft verwenden:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Hinweis*: Die [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) Eigenschaft wird verwendet, um A1-style Zellreferenzen festzulegen. 



Um die [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) Zellreferenz festzulegen, können Sie die [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) Eigenschaft verwenden:

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Verwenden Sie dann die [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) Methode, um alle Formeln innerhalb der Arbeitsmappe zu berechnen und die entsprechenden Zellwerte zu aktualisieren:



``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:




## **Numerische Konstanten**
Zahlen können in gängigen oder wissenschaftlichen Notationen verwendet werden, um Diagramm Tabellenkalkulationsformeln zu erstellen:




## **Stringkonstanten**
String (oder Literal) Konstanten sind spezifische Werte, die so verwendet werden, wie sie sind, und sich nicht ändern. Stringkonstanten können sein: Daten, Texte, Zahlen usw.:




## **Fehlerkonstanten**
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird der Fehlercode in der Zelle anstelle seines Wertes angezeigt. Jeder Fehler hat einen spezifischen Code:

- #DIV/0! - die Formel versucht, durch Null zu teilen.
- #GETTING_DATA - kann in einer Zelle angezeigt werden, während sein Wert noch berechnet wird.
- #N/A - Informationen fehlen oder sind nicht verfügbar. Einige Gründe können sein: die Zellen, die in der Formel verwendet werden, sind leer, ein zusätzlicher Leerzeichen-Zeichencode, Schreibfehler usw.
- #NAME? - eine bestimmte Zelle oder andere Formelelemente können nicht durch ihren Namen gefunden werden. 
- #NULL! - kann auftreten, wenn ein Fehler in der Formel vorliegt, wie z.B.: (,) oder ein Leerzeichenzeichen, das anstelle eines Doppelpunktes (:) verwendet wird.
- #NUM! - die Zahl in der Formel kann ungültig, zu lang oder zu klein sein usw.
- #REF! - ungültige Zellreferenz.
- #VALUE! - unerwarteter Wertetyp. Zum Beispiel, ein Stringwert, der in eine numerische Zelle eingegeben wird.




## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm Arbeitsblattformeln verwenden:



|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unärer Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Stern)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Zirkumflex) |Exponentialfunktion |2 ^ 3|


*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, setzen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern.


## **Vergleichsoperatoren**
Sie können die Werte der Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis entweder ein logischer Wert *TRUE* oder FALSE:



|**Operator** |**Bedeutung** |**Bedeutung** |
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich wie |A2 = 3|
|<> (ungleichheitszeichen) |Ungleich|A2 <> 3|
|> (größer als Zeichen) |Größer als|A2 > 3|
|>= (größer oder gleich Zeichen)|Größer oder gleich|A2 >= 3|
|< (kleiner als Zeichen)|Kleiner als|A2 < 3|
|<= (kleiner oder gleich Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1-style Zellreferenzen**
**A1-style Zellreferenzen** werden für die Arbeitsblätter verwendet, wo die Spalte einen Buchstabenbezeichner hat (z.B. "*A*") und die Zeile eine numerische Bezeichnung hat (z.B. "*1*"). A1-style Zellreferenzen können auf folgende Weise verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie man A1-style Zellreferenzen in Formeln verwenden kann:




## **R1C1-style Zellreferenzen**
**R1C1-style Zellreferenzen** werden für die Arbeitsblätter verwendet, in denen sowohl eine Zeile als auch eine Spalte einen numerischen Bezeichner haben. R1C1-style Zellreferenzen können auf folgende Weise verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie man A1-style Zellreferenzen in Formeln verwenden kann:




## **Vorab definierte Funktionen**
Es gibt vordefinierte Funktionen, die zur Vereinfachung der Implementierung in den Formeln verwendet werden können. Diese Funktionen kapseln die am häufigsten verwendeten Operationen ein, wie: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 Datensystem)
- DAYS
- FIND
- FINDB
- IF
- INDEX (Referenzform)
- LOOKUP (Vektorform)
- MATCH (Vektorform)
- MAX
- SUM
- VLOOKUP