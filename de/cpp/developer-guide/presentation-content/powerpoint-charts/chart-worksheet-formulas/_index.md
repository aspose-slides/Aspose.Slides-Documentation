---
title: Diagramm-Arbeitsblatt-Formeln in Präsentationen mit C++ anwenden
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/cpp/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenblatt
- Diagramm-Arbeitsblatt
- Diagrammformel
- Arbeitsblatt-Formel
- Tabellenkalkulationsformel
- Datenquelle
- logische Konstante
- numerische Konstante
- Zeichenkettenkonstante
- Fehlerkonstante
- arithmetische Konstante
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Excel-ähnliche Formeln in Aspose.Slides für C++-Diagramm-Arbeitsblätter anwenden und Berichte in PPT- und PPTX-Dateien automatisieren."
---
## **Übersicht**

Ein Diagramm-Arbeitsblatt ist die Datenquelle hinter einem Diagramm in einer Präsentation. Es speichert Kategorie‑ und Seriennamen zusammen mit den numerischen Werten, die im Diagramm angezeigt werden. In Aspose.Slides ist dieses Arbeitsblatt über das Diagrammdaten‑Workbook verfügbar, das Ihnen die programmgesteuerte Arbeit mit Diagrammdaten ermöglicht.

Dieser Artikel erklärt, wie Sie Arbeitsblatt‑Formeln in Diagrammdaten verwenden, sodass Zellwerte automatisch berechnet und aktualisiert werden können, anstatt manuell eingegeben zu werden. Er zeigt, wie Formeln zugewiesen werden, wie sowohl A1‑ als auch R1C1‑Referenzen verwendet werden, wie Workbook‑Formeln neu berechnet werden und wie mit den unterstützten Konstanten, Operatoren, Zellreferenzen und vordefinierten Funktionen für Diagramm‑Arbeitsblätter in Präsentationen gearbeitet wird.

## **Über Diagramm‑Tabellenformeln in Präsentationen**
**Diagramm‑Tabellenkalkulation** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Diagramm‑Tabellenkalkulation enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das dem Diagramm zugehörige Arbeitsblatt ebenfalls automatisch erstellt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Tabellenblatt in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Das Diagramm‑Tabellenblatt enthält die Namen von Diagrammelementen (Kategoriename: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Diagramm‑Tabellendaten mit den Standarddaten gesetzt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplizierte Daten dar (z. B. Finanz‑ oder Wissenschaftsanalyse), bei denen Zellen aus den Werten anderer Zellen oder aus anderen dynamischen Daten berechnet werden. Das manuelle Berechnen des Zellwerts und das harte Kodieren in die Zelle erschwert zukünftige Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, was ein komplexes Präsentations‑Datenschema erzeugt, das einfach und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenformel** in einer Präsentation ist ein Ausdruck, der Diagramm‑Tabellendaten automatisch berechnet und aktualisiert. Die Tabellenformel definiert die Datenberechnungs‑Logik für eine bestimmte Zelle oder einen Satz von Zellen. Eine Tabellenformel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umwandlungsfunktionen, Zeichenketten‑Konstanten usw. Die Definition der Formel wird in eine Zelle geschrieben; diese Zelle enthält keinen einfachen Wert. Die Tabellenformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellenformeln in Präsentationen sind im Wesentlichen dieselben wie Excel‑Formeln, und es werden dieselben Standardfunktionen, Operatoren und Konstanten für ihre Implementierung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/de/cpp/) wird das Diagramm‑Tabellenblatt mit der Methode 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) des Typs 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.i_chart_data_workbook) dargestellt. 
Tabellenformeln können mit der Methode  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Style Zellreferenzen
- R1C1‑Style Zellreferenzen
- Vorgegebene Funktionen



Typischerweise speichern Tabellen die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die Methode **IChartDataCell.get_Value()** diese Werte beim Lesen zurück. Wurden jedoch die Tabellendaten geändert, wirft die Methode **ChartDataCell.get_Value()** beim Lesen die **CellUnsupportedDataException** für nicht unterstützte Formeln. Das liegt daran, dass nach erfolgreichem Parsen der Formeln die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt wird. Kann die Formel nicht geparst werden, lässt sich die Korrektheit des Zellwerts nicht garantieren.


## **Eine Diagramm‑Tabellenformel zu einer Präsentation hinzufügen**
Fügen Sie zunächst einem neuen Präsentationsdokument auf der ersten Folie ein Diagramm mit 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) hinzu. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die Methode  
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) zugegriffen werden:



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Schreiben Sie einige Werte in Zellen mit der Methode 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) des Typs **Object**, was bedeutet, dass Sie jeder Methode einen beliebigen Wert übergeben können:



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Um nun eine Formel in die Zelle zu schreiben, können Sie die Methode 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) verwenden:





*Hinweis*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) wird verwendet, um A1‑Style Zellreferenzen zu setzen. 



Um die R1C1Formula‑Zellreferenz zu setzen, können Sie die Methode [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) verwenden:





Wenn Sie nun die Werte aus den Zellen B2 und C2 auslesen, werden sie berechnet:



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:




## **Numerische Konstanten**
Zahlen können in Dezimal‑ oder Wissenschaftsschreibweise verwendet werden, um Diagramm‑Tabellenformeln zu erstellen:




## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein spezifischer Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Datumsangaben, Texte, Zahlen usw.:




## **Fehler‑Konstanten**
Manchmal ist es nicht möglich, das Ergebnis der Formel zu berechnen. In diesem Fall wird im Zellinhalt anstelle des Wertes ein Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! ‑ Formel versucht, durch Null zu teilen.
- #GETTING_DATA ‑ kann in einer Zelle erscheinen, während ihr Wert noch berechnet wird.
- #N/A ‑ Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen in der Formel, ein zusätzliches Leerzeichen, Rechtschreibfehler usw.
- #NAME? ‑ eine bestimmte Zelle oder ein anderer Formel‑Objekt kann nicht über ihren Namen gefunden werden.
- #NULL! ‑ tritt auf, wenn in der Formel ein Fehler wie (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:) verwendet wird.
- #NUM! ‑ die numerische Angabe in der Formel ist ungültig, zu lang oder zu klein usw.
- #REF! ‑ ungültige Zellreferenz.
- #VALUE! ‑ unerwarteter Werttyp. Beispiel: Zeichenkettenwert in einer numerischen Zelle.




## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblatt‑Formeln verwenden:



|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen)|Addition oder unäres Plus|2 + 3|
|- (Minuszeichen)|Subtraktion oder Negation|2 - 3<br>-3|
|* (Stern)|Multiplikation|2 * 3|
|/ (Schrägstrich)|Division|2 / 3|
|% (Prozentzeichen)|Prozent|30%|
|^ (Caret)|Exponentiation|2 ^ 3|


*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, setzen Sie den zuerst zu berechnenden Teil der Formel in Klammern.


## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:



|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleichwertig|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen)|Größer‑oder‑gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen)|Kleiner‑oder‑gleich|A2 <= 3|


## **A1‑Style Zellreferenzen**
**A1‑Style Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben‑Identifier (z. B. "*A*") und die Zeile einen numerischen Identifier (z. B. "*1*") hat. A1‑Style Zellreferenzen können folgendermaßen verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ein Beispiel, wie man eine A1‑Style Zellreferenz in einer Formel verwendet:




## **R1C1‑Style Zellreferenzen**
**R1C1‑Style Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte numerische Identifier besitzen. R1C1‑Style Zellreferenzen können folgendermaßen verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ein Beispiel, wie man eine R1C1‑Style Zellreferenz in einer Formel verwendet:




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

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagrammdatenquelle](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagrammformeln Blätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem Standard‑Excel‑Referenzmodell, sodass Sie andere Blätter innerhalb derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappennamen gemäß Excel‑Syntax an.