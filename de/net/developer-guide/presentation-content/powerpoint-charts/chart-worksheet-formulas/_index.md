---
title: "Anwenden von Diagramm‑Arbeitsblatt‑Formeln in Präsentationen in .NET"
linktitle: "Arbeitsblatt‑Formeln"
type: docs
weight: 70
url: /de/net/chart-worksheet-formulas/
keywords:
- "Diagramm‑Arbeitsblatt"
- "Diagramm‑Arbeitsblatt"
- "Diagramm‑Formel"
- "Arbeitsblatt‑Formel"
- "Tabellenblatt‑Formel"
- "Datenquelle"
- "Logische Konstante"
- "Numerische Konstante"
- "Zeichenkettenkonstante"
- "Fehlerkonstante"
- "Arithmetische Konstante"
- "Vergleichsoperator"
- "A1‑Stil"
- "R1C1‑Stil"
- "Vordefinierte Funktion"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Wenden Sie Excel‑ähnliche Formeln in Aspose.Slides für .NET‑Diagramm‑Arbeitsblätter an und automatisieren Sie Berichte in PPT‑ und PPTX‑Dateien."
---

## **Über Diagramm‑Arbeitsblatt‑Formeln in der Präsentation**
**Diagramm‑Arbeitsblatt** (oder Diagramm‑Arbeitsmappe) in einer Präsentation ist die Datenquelle des Diagramms. Das Diagramm‑Arbeitsblatt enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das zugehörige Arbeitsblatt automatisch erzeugt. Das Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Arbeitsblatt in PowerPoint zu sehen, doppelklicken Sie das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Das Diagramm‑Arbeitsblatt enthält die Namen der Diagrammelemente (Kategoriename: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien gehören. Standardmäßig werden beim Erstellen eines neuen Diagramms die Daten des Arbeitsblatts mit Standardwerten befüllt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplexe Daten dar (z. B. Finanz‑ oder Wissenschaftsanalyse), bei denen Zellen aus den Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Werte manuell zu berechnen und fest in die Zelle zu schreiben, erschwert spätere Änderungen. Ändern Sie den Wert einer Zelle, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von anderen Tabellen abhängen, was ein komplexes Präsentations‑Datenschema erzeugt, das flexibel aktualisiert werden muss.

**Diagramm‑Arbeitsblatt‑Formel** in einer Präsentation ist ein Ausdruck, der die Daten des Arbeitsblatts automatisch berechnet und aktualisiert. Eine Arbeitsblatt‑Formel definiert die Berechnungslogik für eine bestimmte Zelle oder einen Zellenbereich. Sie ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben; diese Zelle enthält keinen einfachen Wert. Die Formel berechnet den Wert, gibt ihn zurück und der Wert wird der Zelle zugewiesen. Diagramm‑Arbeitsblatt‑Formeln in Präsentationen entsprechen Excel‑Formeln und unterstützen dieselben Standardfunktionen, Operatoren und Konstanten.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) wird das Diagramm‑Arbeitsblatt durch die Eigenschaft
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) des Typs
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) dargestellt. 
Eine Arbeitsblatt‑Formel kann über die Eigenschaft
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil‑Zellreferenzen
- R1C1‑Stil‑Zellreferenzen
- Vorgegebene Funktionen

Typischerweise speichern Arbeitsblätter die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, liefert die Eigenschaft **IChartDataCell.Value** diese Werte beim Lesen. Werden die Arbeitsblatt‑Daten jedoch geändert, wirft das Lesen von **ChartDataCell.Value** die **CellUnsupportedDataException** wegen nicht unterstützter Formeln. Das liegt daran, dass beim erfolgreichen Parsen einer Formel die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt werden. Kann eine Formel nicht geparst werden, lässt sich die Korrektheit des Zellwertes nicht garantieren.

## **Diagramm‑Arbeitsblatt‑Formel zur Präsentation hinzufügen**
Fügen Sie zunächst ein Diagramm mit Beispieldaten zur ersten Folie einer neuen Präsentation hinzu, indem Sie
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
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```


Um eine Formel in die Zelle zu schreiben, verwenden Sie die Eigenschaft
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula):
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*Hinweis*: Die Eigenschaft [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) wird für A1‑Stil‑Zellreferenzen verwendet.

Um eine R1C1‑Stil‑Referenz zu setzen, verwenden Sie die Eigenschaft
[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


Anschließend rufen Sie die Methode
[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) auf, um alle Formeln im Arbeitsbuch zu berechnen und die zugehörigen Zellwerte zu aktualisieren:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:

## **Numerische Konstanten**
Zahlen können in normaler oder wissenschaftlicher Schreibweise verwendet werden, um Diagramm‑Arbeitsblatt‑Formeln zu erstellen:

## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Daten, Texte, Zahlen usw.:

## **Fehler‑Konstanten**
Manchmal ist es nicht möglich, das Ergebnis einer Formel zu berechnen. In diesem Fall wird im Feld ein Fehlercode anstelle des Werts angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann bei einer Zelle erscheinen, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen, ein zusätzliches Leerzeichen, Tippfehler usw.
- #NAME? – ein bestimmtes Feld oder ein anderes Formelelement wurde nicht gefunden.
- #NULL! – kann auftreten, wenn ein Fehler in der Formel vorliegt, z. B. (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).
- #NUM! – die numerische Angabe in der Formel ist ungültig, zu lang oder zu klein.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp, z. B. ein Zeichenkettenwert in einer numerischen Zelle.

## **Arithmetische Operatoren**
Alle arithmetischen Operatoren können in Diagramm‑Arbeitsblatt‑Formeln verwendet werden:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen)|Addition oder unäres Plus|2 + 3|
|- (Minuszeichen)|Subtraktion oder Negation|2 - 3<br>-3|
|* (Sternchen)|Multiplikation|2 * 3|
|/ (Schrägstrich)|Division|2 / 3|
|% (Prozentzeichen)|Prozent|30%|
|^ (Caret)|Potenzierung|2 ^ 3|

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den zu berechnenden Teil in Klammern.

## **Vergleichsoperatoren**
Mit Vergleichsoperatoren können Sie Zellwerte vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich zu|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich zu|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen)|Größer oder gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1‑Stil‑Zellreferenzen**
**A1‑Stil‑Zellreferenzen** werden in Arbeitsblättern verwendet, bei denen die Spalte einen Buchstaben (z. B. *A*) und die Zeile eine Zahl (z. B. *1*) hat. Sie können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle|$A$2|A2|A$2<br>$A2|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|$A$2:C4<br>A$2:$C4|

Ein Beispiel für die Verwendung einer A1‑Stil‑Referenz in einer Formel:

## **R1C1‑Stil‑Zellreferenzen**
**R1C1‑Stil‑Zellreferenzen** werden in Arbeitsblättern verwendet, bei denen sowohl Zeile als auch Spalte numerisch gekennzeichnet sind. Sie können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Ein Beispiel für die Verwendung einer R1C1‑Stil‑Referenz in einer Formel:

## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln häufig genutzte Operationen, wie:

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

**Können Diagramm‑Formeln Tabellen innerhalb derselben Arbeitsmappe per Tabellenname referenzieren?**

Ja. Formeln folgen dem üblichen Excel‑Referenzmodell, sodass Sie andere Tabellen derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappennamen gemäß Excel‑Syntax an.