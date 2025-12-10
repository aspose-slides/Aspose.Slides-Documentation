---
title: Chart‑Arbeitsblatt‑Formeln in Präsentationen mit C++ anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/cpp/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenblatt
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenblatt‑Formel
- Datenquelle
- logische Konstante
- numerische Konstante
- Zeichenketten‑Konstante
- Fehler‑Konstante
- arithmetische Konstante
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- С++
- Aspose.Slides
description: "Excel‑artige Formeln in Aspose.Slides für С++‑Diagramm‑Arbeitsblätter anwenden und Berichte in PPT‑ und PPTX‑Dateien automatisieren."
---

## **Über Diagramm‑Tabellenblatt‑Formeln in Präsentationen**
**Diagramm‑Tabellenblatt** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Diagramm‑Tabellenblatt enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das zugehörige Tabellenblatt automatisch erzeugt. Das Diagramm‑Tabellenblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Tabellenblatt in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Diagramm‑Tabellenblatt enthält die Namen von Diagrammelementen (Kategoriespalte: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Diagramm‑Tabellenblatt‑Daten mit Standardwerten gesetzt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplexe Daten dar (z. B. Finanz‑ oder Wissenschaftsanalyse), wobei Zellen aus Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Den Zellenwert manuell zu berechnen und fest in die Zelle zu schreiben, erschwert spätere Änderungen. Ändern Sie den Wert einer bestimmten Zelle, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Außerdem können Tabellendaten von Daten anderer Tabellen abhängen und ein komplexes Präsentations‑Datenschema erzeugen, das einfach und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenblatt‑Formel** in einer Präsentation ist ein Ausdruck, der Diagramm‑Tabellenblatt‑Daten automatisch berechnet und aktualisiert. Eine Tabellenblatt‑Formel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Zellenbereich. Eine Tabellenblatt‑Formel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenketten‑Konstanten usw. Die Definition der Formel wird in eine Zelle geschrieben; diese Zelle enthält keinen einfachen Wert. Die Tabellenblatt‑Formel berechnet den Wert und liefert ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellenblatt‑Formeln in Präsentationen sind im Prinzip die gleichen wie Excel‑Formeln und unterstützen dieselben Standardfunktionen, Operatoren und Konstanten.

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) wird das Diagramm‑Tabellenblatt durch die
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)-Methode des
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook)-Typs dargestellt. 
Eine Tabellenblatt‑Formel kann mit 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) zugewiesen und geändert werden. 
Folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil‑Zellreferenzen
- R1C1‑Stil‑Zellreferenzen
- Vorgefertigte Funktionen



Typischerweise speichern Tabellenblätter die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die **IChartDataCell.get_Value()**‑Methode beim Lesen diese Werte zurück. Wurden jedoch die Tabellenblatt‑Daten geändert, wirft die **ChartDataCell.get_Value()**‑Methode beim Lesen eine **CellUnsupportedDataException** wegen nicht unterstützter Formeln. Das liegt daran, dass beim erfolgreichen Parsen von Formeln die Zellabhängigkeiten ermittelt und die Gültigkeit der letzten Werte geprüft wird. Kann eine Formel nicht geparst werden, kann die Korrektheit des Zellenwertes nicht garantiert werden.


## **Eine Diagramm‑Tabellenblatt‑Formel zu einer Präsentation hinzufügen**
Fügen Sie zunächst dem ersten Folien einer neuen Präsentation ein Diagramm mit 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) hinzu. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) abgerufen werden:
``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```




Schreiben wir einige Werte in Zellen mit 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) der **Object**‑Klasse, das bedeutet, Sie können jeder Methode einen beliebigen Wert übergeben:
``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```




Um nun eine Formel in die Zelle zu schreiben, können Sie die 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑Methode verwenden:





*Hinweis*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) setzt A1‑Stil‑Zellreferenzen. 



Um die R1C1‑Formel‑Zellreferenz zu setzen, können Sie die [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7)‑Methode verwenden:





Wenn Sie anschließend die Werte aus den Zellen B2 und C2 auslesen, werden sie berechnet:
``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```



## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:




## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Schreibweise verwendet werden, um Diagramm‑Tabellenblatt‑Formeln zu erstellen:




## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Datumsangaben, Texte, Zahlen usw.:




## **Fehler‑Konstanten**
Manchmal kann das Ergebnis einer Formel nicht berechnet werden. In diesem Fall wird im Zellinhalt ein Fehlercode anstelle des Werts angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann in einer Zelle erscheinen, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen in der Formel, ein zusätzliches Leerzeichen, Tippfehler usw.
- #NAME? – eine bestimmte Zelle oder ein anderes Formelelement kann nicht über ihren Namen gefunden werden.
- #NULL! – tritt auf, wenn ein Fehler in der Formel vorliegt, z. B. (,) oder ein Leerzeichen statt eines Doppelpunkts (:).
- #NUM! – die numerische Angabe in der Formel ist ungültig, zu lang oder zu klein usw.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp, z. B. ein Zeichenkettenwert in einer numerischen Zelle.




## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Tabellenblatt‑Formeln verwenden:



|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen)|Addition oder unary plus|2 + 3|
|- (Minuszeichen)|Subtraktion oder Negation|2 - 3<br>-3|
|* (Stern)|Multiplikation|2 * 3|
|/ (Schrägstrich)|Division|2 / 3|
|% (Prozentzeichen)|Prozent|30%|
|^ (Caret)|Potenzierung|2 ^ 3|


*Hinweis*: Um die Reihenfolge der Berechnung zu ändern, setzen Sie den entsprechenden Teil der Formel in Klammern.


## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Werden zwei Werte mit diesen Operatoren verglichen, ergibt das einen logischen Wert, entweder *TRUE* oder *FALSE*:



|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (größer‑oder‑gleich‑Zeichen)|Größer oder gleich|A2 >= 3|
|< (kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (kleiner‑oder‑gleich‑Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1‑Stil‑Zellreferenzen**
**A1‑Stil‑Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben‑Identifier (z. B. "*A*") und die Zeile einen numerischen Identifier (z. B. "*1*") hat. A1‑Stil‑Zellreferenzen können wie folgt verwendet werden:



|**Zellreferenz**|**Beispiel**| | |
| :- | :- | :- | :- |
| |Absolut|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ein Beispiel, wie man eine A1‑Stil‑Zellreferenz in einer Formel verwendet:




## **R1C1‑Stil‑Zellreferenzen**
**R1C1‑Stil‑Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte numerische Identifier besitzen. R1C1‑Stil‑Zellreferenzen können wie folgt verwendet werden:



|**Zellreferenz**|**Beispiel**| | |
| :- | :- | :- | :- |
| |Absolut|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ein Beispiel, wie man eine R1C1‑Stil‑Zellreferenz in einer Formel verwendet:




## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten genutzten Vorgänge, wie zum Beispiel:

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
- INDEX (Referenzform)
- LOOKUP (Vektorform)
- MATCH (Vektorform)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagramm‑Datenquelle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Tabellenblätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem Standard‑Excel‑Referenzmodell, sodass Sie andere Blätter derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie den Pfad und den Dateinamen gemäß Excel‑Syntax an.