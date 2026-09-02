---
title: Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen in C++
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- hierarchisches Diagramm
- Datenpunkt
- Datenbeschriftung
- Zweigfarbe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Lernen Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für C++ anpassen."
---
## **Überblick**

Treemap- und Sunburst-Diagramme zeigen dieselbe Art von hierarchischen Daten an, verwenden jedoch unterschiedliche Layouts. Eine Treemap stellt die Hierarchie als verschachtelte Rechtecke dar, deren Flächen die Blattwerte repräsentieren. Ein Sunburst stellt sie als konzentrische Ringe dar: Gruppen der obersten Ebene befinden sich in der Nähe des Zentrums und Blattkategorien am äußeren Ring.

In Aspose.Slides for C++ ist jeder numerische Wert ein [IChartDataPoint](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/). Seine [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) Methode bietet Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen anhand derselben Beispieldaten erstellt und formatiert werden können.

![Ein Treemap-Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst-Diagramm mit derselben Consumer- und Business-Hierarchie](sunburst-hierarchy.png)

## **Kategorien, Datenpunkte und Ebenen verstehen**

Das unten verwendete Beispiel hat drei Kategorisierungsebenen und eine numerische Serie:

| Zweig | Ast | Blatt | Umsatz |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Kategorisierungs‑Ebenen beschreiben den Pfad von diesem Blatt zu seinen übergeordneten Gruppen. Für die erste Zeile ist der Pfad `Consumer > Computers > Laptops`.

Die von [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) zurückgegebenen Indizes laufen vom Blatt aufwärts:

| `get_DataPointLevels()` Index | Logische Ebene | Treemap‑Darstellung | Sunburst‑Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Wertrechteck | Außenringsegment |
| `1` | Ast | Elternrechteck oder Kopfzeile | Mittelringsegment |
| `2` | Zweig | Oberste‑Ebene Rechteck oder Kopfzeile | Innenringsegment |

Diese Reihenfolge ist für beide Diagrammtypen gleich, obwohl sich ihre visuellen Layouts unterscheiden. Ein übergeordnetes Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Beispielsweise beginnt der `Consumer`‑Zweig mit dem `Laptops`‑Punkt, während der `Software`‑Ast mit dem `Licenses`‑Punkt beginnt. Das Beibehalten von Referenzen zu diesen Punkten ist klarer und sicherer, als unerklärte Ausdrücke wie `dataPoints->idx_get(0)` oder `dataPoints->idx_get(6)` zu verwenden.

## **Erstellen und Anpassen beider Diagrammtypen**

Das folgende vollständige Beispiel erstellt eine Treemap auf der ersten Folie und einen Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, wendet feste Farben auf ausgewählte Ebenen an, formatiert ein Zweig‑Label und speichert die Präsentation.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Füge die Blattkategorien hinzu. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
    // die nachfolgenden Kategorien bleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Zeige die Kategorie und den Wert im Blatt Tablets an.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formatiere den Consumer-Zweig über das erste Blatt in diesem Zweig.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Formatiere den Software-Ast über das erste Blatt in diesem Ast.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout beeinflusst die übergeordneten Labels bei Treemap; Sunburst verwendet Ringe‑Segmente.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Kategoriezellen und Wertzellen verwenden dieselbe Arbeitsblattzeile, sodass ihre Sammlungspositionen ausgerichtet bleiben. Wenn Sie mit einem bestehenden Diagramm arbeiten, anstatt eines zu erstellen, prüfen Sie zuerst die Kategoriezahlen und speichern Sie benannte Referenzen zu den Datenpunkten und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Eine Treemap verwendet Fläche, um den Wert zu kommunizieren, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) Methode steuert, wie Eltern‑Labels in diesem Diagrammtyp angezeigt werden.
- Ein Sunburst verwendet den Winkel, um den Wert zu kommunizieren, und die Ringtiefe, um die Hierarchie darzustellen. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) steuert nicht die Ring‑Labels.
- Beide Diagrammtypen verwenden dieselben Kategorisierungs‑Ebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge, die von [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) zurückgegeben wird, sodass der Code zum Erstellen von Daten und zum Formatieren von Ebenen gemeinsam genutzt werden kann.
- Elternwerte werden aus ihren abgeleiteten Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Äste hinzu.

### **Sortierung und Segmentreihenfolge**

Die Diagramm‑Layout‑Engine bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie zusammengehörige Kategoriezahlen vor dem Hinzufügen gruppiert, aber verlassen Sie sich nicht auf eine bestimmte Rechteckposition oder Anfangswinkel. Wenn die Reihenfolge Bedeutung hat, integrieren Sie sie in die Labels oder verwenden Sie einen Diagrammtyp mit einer expliziten Kategorienachse.

### **Design und feste Farben**

Unformatierte Diagrammebenen erben Farben aus dem Präsentationsdesign. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ergebnisse. Wenn das Diagramm Design‑Änderungen folgen soll, verwenden Sie Schema‑Farben anstelle fester RGB‑Werte und vermeiden Sie das Überschreiben jeder Ebene. Überprüfen Sie außerdem den Label‑Kontrast, nachdem Sie die Füllung eines Zweigs oder Astes geändert haben.

### **Labels und verfügbarer Platz**

PowerPoint kann Labels ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, das Kürzen von Kategorienamen oder das Anzeigen weniger Label‑Felder führt in der Regel zu einem klareren Ergebnis. Ein Label kann den Kategorienamen, den Seriennamen und den Wert über [IDataLabelFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatalabelformat/) kombinieren, aber das Aktivieren aller Felder erschwert hierarchische Diagramme häufig das Lesen.

### **Export und Rendering**

Das Speichern als PPTX hält das Diagramm editierbar. Wenn Aspose.Slides die Präsentation in PDF oder ein Bild rendert, werden die unterstützten Füllungen und Label‑Einstellungen mit dem Diagramm gerendert. Schriftart‑Ersetzungen und kleine Unterschiede im verfügbaren Layout‑Raum können Zeilenumbrüche oder die Sichtbarkeit von Labels ändern, daher sollten die erforderlichen Schriftarten installiert und wichtige Exportziele überprüft werden.

## **FAQ**

**Warum wirkt sich das Ändern einer übergeordneten Ebene auf mehrere Blätter aus?**

Ein Zweig oder Ast ist ein gemeinsam genutztes visuelles Segment. Sein [IChartDataPointLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapointlevel/) kann über ein abgeleitetes Blatt erreicht werden, jedoch gehört die Formatierung dem gemeinsam genutzten übergeordneten Segment und nicht nur dem Blatt.

**Warum fehlt ein Daten-Label?**

Aktivieren Sie zunächst die erforderlichen Felder im [IDataLabelFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatalabelformat/)‑Objekt des Labels. Prüfen Sie dann, ob das Segment ausreichend Platz hat. Das Treemap‑Eltern‑Label‑Layout, die Diagrammgröße, die Label‑Länge, die Schriftgröße und die Anzahl aktivierter Felder beeinflussen alle, ob ein Label angezeigt werden kann.

**Kann ich die genaue Reihenfolge oder Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quellzeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine genauen Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Diagramm‑Layout‑Engine berechnet sie aus der Hierarchie, den Werten und dem verfügbaren Raum.

**Warum ändern sich die Farben, wenn das Präsentationsdesign geändert wird?**

Design‑basierte Füllungen sind dafür vorgesehen, der Präsentationspalette zu folgen. Verwenden Sie explizite RGB‑Farben für die Ebenen, die unverändert bleiben müssen, oder behalten Sie Schema‑Farben bei, wenn das Anpassen an ein neues Design bevorzugt wird.

**Wird die benutzerdefinierte Formatierung bei PDF‑ und Bild‑Exporten beibehalten?**

Ja, unterstützte Diagramm‑Füllungen und Label‑Einstellungen werden beim Rendering berücksichtigt. Für konsistente Ergebnisse über verschiedene Systeme hinweg stellen Sie die erforderlichen Schriftarten bereit und testen Sie die endgültige Exportgröße, da das Anpassen von Labels vom Layout abhängt.

## **Siehe auch**

- [Treemap‑Diagramme erstellen](/slides/de/cpp/create-chart/#create-tree-map-charts)
- [Sunburst‑Diagramme erstellen](/slides/de/cpp/create-chart/#create-sunburst-charts)
- [Präsentationsdiagramme exportieren](/slides/de/cpp/export-chart/)
- [Präsentationsdesigns verwalten](/slides/de/cpp/presentation-theme/)