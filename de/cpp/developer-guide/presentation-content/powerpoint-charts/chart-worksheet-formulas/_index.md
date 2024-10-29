---
title: Diagramm Arbeitsblattformeln
type: docs
weight: 70
url: /de/cpp/chart-worksheet-formulas/
keywords: "powerpoint gleichungen, powerpoint tabellenformeln"
description: "PowerPoint-Gleichungen und Tabellenformeln"
---


## **Über Diagramm Tabellenformeln in Präsentationen**
**Diagrammtabelle** (oder Diagramm Arbeitsblatt) in Präsentationen ist die Datenquelle des Diagramms. Die Diagrammtabelle enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das mit diesem Diagramm verbundene Arbeitsblatt automatisch erstellt. Das Diagramm Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sonnenblumendiagramm, Kreisdiagramm usw. Um die Diagrammtabelle in PowerPoint zu sehen, sollten Sie einen Doppelklick auf das Diagramm ausführen:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Die Diagrammtabelle enthält die Namen der Diagrammelemente (Kategoriename: *Kategorie1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien gehören. Standardmäßig werden beim Erstellen eines neuen Diagramms die Daten der Diagrammtabelle mit den Standarddaten festgelegt. Dann können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplizierte Daten dar (z. B. Finanzanalysten, wissenschaftliche Analysten), wobei Zellen aus Werten in anderen Zellen oder aus anderen dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und hartkodiert in die Zelle einzufügen, erschwert zukünftige Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen auch alle davon abhängigen Zellen aktualisiert werden. Darüber hinaus können die Tabellendaten von Daten aus anderen Tabellen abhängen, was ein komplexes Schema für Präsentationsdaten schafft, das auf einfache und flexible Weise aktualisiert werden muss.

**Diagramm Tabellenformel** in Präsentationen ist ein Ausdruck, um automatisch die Daten der Diagrammtabelle zu berechnen und zu aktualisieren. Die Tabellenformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder eine Menge von Zellen. Die Tabellenformel ist eine mathematische Formel oder eine logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umrechnungsfunktionen, Zeichenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Tabellenformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm Tabellenformeln in Präsentationen sind eigentlich die gleichen wie Excel-Formeln, und es werden die gleichen Standardfunktionen, Operatoren und Konstanten für deren Implementierung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) wird die Diagrammtabelle durch die 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) Methode des 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook) Typs dargestellt. 
Die Tabellenformel kann mit der 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) Methode zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1-Zellenreferenzen
- R1C1-Zellenreferenzen
- Vorinstallierte Funktionen



Typischerweise speichern Tabellen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden - gibt die **IChartDataCell.get_Value()** Methode diese Werte beim Lesen zurück. Wenn jedoch die Tabellendaten geändert wurden, wirft die **ChartDataCell.get_Value()** Methode eine **CellUnsupportedDataException** für die nicht unterstützten Formeln. Dies liegt daran, dass beim erfolgreichen Parsen der Formeln die Zellabhängigkeiten bestimmt werden und die Richtigkeit der letzten Werte festgestellt wird. Wenn die Formel jedoch nicht geparst werden kann, kann die Richtigkeit des Zellwerts nicht garantiert werden.


## **Diagramm Tabellenformel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm zur ersten Folie einer neuen Präsentation mit 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) hinzu. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) Methode aufgerufen werden:



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Lassen Sie uns einige Werte in die Zellen mit der 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) Methode 
des **Object** Typs schreiben, was bedeutet, dass Sie jedem Wert an die Methode übergeben können:



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Um nun eine Formel in die Zelle zu schreiben, können Sie die 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) Methode verwenden:





*Hinweis*: Die [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) Methode wird verwendet, um A1-Zellenreferenzen festzulegen. 



Um die R1C1Formula-Zellenreferenz festzulegen, können Sie die [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) Methode verwenden:





Wenn Sie dann versuchen, die Werte aus den Zellen B2 und C2 zu lesen, werden sie berechnet:



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellenformeln verwenden:




## **Numerische Konstanten**
Zahlen können in herkömmlichen oder wissenschaftlichen Notationen verwendet werden, um Diagramm Tabellenformeln zu erstellen:




## **Zeichenkonstanten**
Eine Zeichenkonstante (oder Literal) ist ein spezifischer Wert, der so verwendet wird, wie er ist und sich nicht ändert. Zeichenkonstanten können folgende sein: Daten, Texte, Zahlen usw.:




## **Fehlerkonstanten**
Manchmal ist es unmöglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird anstelle des Wertes der Fehlercode in der Zelle angezeigt. Jeder Fehlercode hat einen spezifischen Code:

- #DIV/0! - die Formel versucht, durch Null zu teilen.
- #GETTING_DATA - kann in einer Zelle angezeigt werden, während der Wert noch berechnet wird.
- #N/A - Informationen fehlen oder sind nicht verfügbar. Einige Gründe können sein: die in der Formel verwendeten Zellen sind leer, ein zusätzlicher Leerzeichencharakter, Schreibfehler usw.
- #NAME? - eine bestimmte Zelle oder andere Formularelemente können nicht unter ihrem Namen gefunden werden. 
- #NULL! - kann erscheinen, wenn ein Fehler in der Formel vorliegt, wie etwa: (,) oder ein Leerzeichen, das anstelle von einem Doppelpunkt (:) verwendet wird.
- #NUM! - die Zahl in der Formel kann ungültig, zu lang oder zu klein sein usw.
- #REF! - ungültige Zellenreferenz.
- #VALUE! - unerwarteter Werttyp. Zum Beispiel, ein Zeichenwert, der in eine numerische Zelle gesetzt wird.




## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm Arbeitsblattformeln verwenden:



|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unärer Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Sternchen)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Zirkumflex) |Potenzierung |2 ^ 3|


*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, schließen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern ein.


## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis ein logischer Wert, entweder *TRUE* oder FALSE:



|**Operator** |**Bedeutung** |**Bedeutung** |
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich zu |A2 = 3|
|<> (ungleichheitszeichen) |Ungleich|A2 <> 3|
|> (größer als Zeichen) |Größer als|A2 > 3|
|>= (größer oder gleich Zeichen)|Größer als oder gleich|A2 >= 3|
|< (kleiner als Zeichen)|Kleiner als|A2 < 3|
|<= (kleiner oder gleich Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1-Zellenreferenzen**
**A1-Zellenreferenzen** werden für die Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben als Identifikator hat (z. B. "*A*") und die Zeile eine numerische Kennung hat (z. B. "*1*"). A1-Zellenreferenzen können auf folgende Weise verwendet werden:



|**Zellenreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie man eine A1-Zellenreferenz in einer Formel verwendet:




## **R1C1-Zellenreferenzen**
**R1C1-Zellenreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl eine Zeile als auch eine Spalte eine numerische Kennung haben. R1C1-Zellenreferenzen können auf folgende Weise verwendet werden:



|**Zellenreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie man eine A1-Zellenreferenz in einer Formel verwendet:




## **Vorinstallierte Funktionen**
Es gibt vorinstallierte Funktionen, die in den Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten verwendeten Operationen ein, wie: 

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
- LOOKUP (Vektorgform)
- MATCH (Vektorgform)
- MAX
- SUM
- VLOOKUP