---
title: Anwenden von Diagramm-Arbeitsblatt-Formeln in Präsentationen in .NET
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/net/chart-worksheet-formulas/
keywords:
- diagramm-tabellenkalkulation
- diagramm-arbeitsblatt
- diagramm-formel
- arbeitsblatt-formel
- tabellenkalkulations-formel
- datenquelle
- logische konstante
- numerische konstante
- zeichenketten-konstante
- fehlerkonstante
- arithmetische konstante
- vergleichsoperator
- A1-Stil
- R1C1-Stil
- vordefinierte funktion
- PowerPoint
- präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie Excel-ähnliche Formeln in Aspose.Slides für .NET-Diagramm-Arbeitsblätter und automatisieren Sie Berichte für PPT- und PPTX-Dateien."
---

## **Über Diagramm‑Tabellenkalkulationen in Präsentationen**
**Diagramm‑Tabellenkalkulation** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Die Diagramm‑Tabellenkalkulation enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das zugehörige Arbeitsblatt automatisch erstellt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um die Diagramm‑Tabellenkalkulation in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Die Diagramm‑Tabellenkalkulation enthält die Namen von Diagrammelementen (Kategoriename: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Diagramm‑Tabellenkalkulationsdaten mit den Standarddaten befüllt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplexe Daten dar (z. B. Finanz‑ oder Wissenschaftsanalyse), bei denen Zellen aus den Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Die manuelle Berechnung des Zellenwertes und das Hard‑Coden in die Zelle erschwert zukünftige Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, wodurch ein komplexes Präsentationsdatenschema entsteht, das flexibel und einfach zu aktualisieren sein muss.

**Diagramm‑Tabellenkalkulationsformel** in einer Präsentation ist ein Ausdruck, der Diagramm‑Tabellenkalkulationsdaten automatisch berechnet und aktualisiert. Die Tabellenkalkulationsformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Zellenbereich. Eine Tabellenkalkulationsformel ist eine mathematische oder logische Formel, die verwendet: Zellbezüge, Mathe‑Funktionen, logische Operatoren, arithmetische Operatoren, Umwandlungsfunktionen, Zeichenketten‑Konstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Formel berechnet den Wert, gibt ihn zurück und dieser Wert wird der Zelle zugewiesen. Diagramm‑Tabellenkalkulationsformeln in Präsentationen sind im Grunde dieselben wie Excel‑Formeln, und dieselben Standard‑Funktionen, Operatoren und Konstanten werden unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) wird die Diagramm‑Tabellenkalkulation mit der Eigenschaft 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) des Typs 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) dargestellt. 
Tabellenkalkulationsformeln können mit der Eigenschaft 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) zugewiesen und geändert werden. 
Folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Style Zellbezüge
- R1C1‑Style Zellbezüge
- Vorgegebene Funktionen

Typischerweise speichern Tabellenkalkulationen die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die Eigenschaft **IChartDataCell.Value** diese Werte beim Lesen zurück. Ändern sich jedoch die Tabellendaten, wirft das Lesen der Eigenschaft **ChartDataCell.Value** die **CellUnsupportedDataException** wegen nicht unterstützter Formeln. Das liegt daran, dass bei erfolgreichem Parsen der Formeln die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt werden. Kann eine Formel nicht geparst werden, lässt sich die Korrektheit des Zellenwertes nicht garantieren.

## **Eine Diagramm‑Tabellenkalkulationsformel zu einer Präsentation hinzufügen**
Fügen Sie zuerst einem neuen Präsentationsdokument ein Diagramm mit Beispielwerten zur ersten Folie hinzu, indem Sie 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1) verwenden. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die Eigenschaft 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) abgerufen werden:
``` csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```


Schreiben Sie einige Werte in Zellen mit der Eigenschaft 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) des Typs **Object**, was bedeutet, dass Sie beliebige Werte zuweisen können:
{{eb03​9d3a-6f97-41ee-b052-644c95a8a37d}}

Um eine Formel in die Zelle zu schreiben, verwenden Sie die 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)‑Eigenschaft:
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*Hinweis*: Die Eigenschaft [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) wird verwendet, um A1‑Style Zellbezüge zu setzen. 

Um den **R1C1Formula**‑Zellbezug zu setzen, können Sie die Eigenschaft 
[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) verwenden:
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


Anschließend verwenden Sie die Methode 
[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas), um alle Formeln im Arbeitsbuch zu berechnen und die entsprechenden Zellenwerte zu aktualisieren:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:

## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Notation verwendet werden, um Diagramm‑Tabellenkalkulationsformeln zu erstellen:

## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Datumsangaben, Texte, Zahlen usw.:

## **Fehler‑Konstanten**
Manchmal ist es nicht möglich, das Ergebnis einer Formel zu berechnen. In diesem Fall wird im Feld ein Fehlercode anstelle des Wertes angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.  
- #GETTING_DATA – kann in einer Zelle erscheinen, während ihr Wert noch berechnet wird.  
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: die in der Formel verwendeten Zellen sind leer, ein zusätzliches Leerzeichen, Tippfehler usw.  
- #NAME? – eine bestimmte Zelle oder ein anderes Formelelement kann nicht über seinen Namen gefunden werden.  
- #NULL! – tritt auf, wenn ein Fehler in der Formel vorliegt, z. B. (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).  
- #NUM! – die in der Formel angegebene Zahl ist ungültig, zu lang oder zu kurz usw.  
- #REF! – ungültiger Zellbezug.  
- #VALUE! – unerwarteter Werttyp, z. B. Zeichenkette in einer numerischen Zelle.

## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblatt‑Formeln verwenden:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen)|Addition oder unäres Plus|2 + 3|
|- (Minuszeichen)|Subtraktion oder Negation|2 - 3<br>-3|
|* (Sternchen)|Multiplikation|2 * 3|
|/ (Schrägstrich)|Division|2 / 3|
|% (Prozentzeichen)|Prozent|30%|
|^ (Caret)|Exponentiation|2 ^ 3|

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den zu berechnenden Teil in Klammern.

## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen)|Größer oder gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1‑Style Zellbezüge**
**A1‑Style Zellbezüge** werden für Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben‑Identifier (z. B. *A*) und die Zeile einen numerischen Identifier (z. B. *1*) hat. A1‑Style Zellbezüge können wie folgt verwendet werden:

|**Zellbezug**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier ein Beispiel, wie ein A1‑Style Zellbezug in einer Formel verwendet wird:

## **R1C1‑Style Zellbezüge**
**R1C1‑Style Zellbezüge** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte numerische Identifier besitzen. R1C1‑Style Zellbezüge können wie folgt verwendet werden:

|**Zellbezug**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier ein Beispiel, wie ein A1‑Style Zellbezug in einer Formel verwendet wird:

## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen bündeln die am häufigsten genutzten Operationen, wie:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑Datumsystem)
- DAYS
- FIND
- FINDB
- IF
- INDEX (Referenz‑Form)
- LOOKUP (Vektor‑Form)
- MATCH (Vektor‑Form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagramm‑Datenquelle](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Tabellenblätter innerhalb derselben Arbeitsmappe über den Blattnamen referenzieren?**

Ja. Formeln folgen dem Standard‑Excel‑Referenzmodell, sodass Sie andere Blätter derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappennamen nach Excel‑Syntax an.