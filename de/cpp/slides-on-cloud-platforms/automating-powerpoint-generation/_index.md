---
title: "Automatisierung der PowerPoint-Generierung in C++: Dynamische Präsentationen einfach erstellen"
linktitle: "Automatisierung der PowerPoint-Generierung"
type: docs
weight: 20
url: /de/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- Cloud-Plattformen
- PowerPoint-Generierung automatisieren
- Präsentationen programmgesteuert erzeugen
- PowerPoint-Automatisierung
- Dynamische Folienerstellung
- Automatisierte Geschäftsberichte
- PPT-Automatisierung
- C++-Präsentation
- C++
- Aspose.Slides
description: "Automatisieren Sie die Folienerstellung auf Cloud-Plattformen mit Aspose.Slides für C++ – schnell und zuverlässig PowerPoint- und OpenDocument-Dateien erzeugen, bearbeiten und konvertieren."
---

## **Einleitung**

PowerPoint-Präsentationen manuell zu erstellen kann zeitaufwendig und repetitiv sein – besonders wenn der Inhalt auf dynamischen Daten basiert, die sich häufig ändern. Ob es darum geht, wöchentliche Geschäftsberichte zu erstellen, Lernmaterial zusammenzustellen oder verkaufsfertige Kundenpräsentationen zu produzieren, Automatisierung kann unzählige Stunden einsparen und Konsistenz über Teams hinweg gewährleisten.

Für C++‑Entwickler eröffnet die Automatisierung der Erstellung von PowerPoint‑Präsentationen leistungsstarke Möglichkeiten. Sie können die Foliengenerierung in Webportale, Desktop‑Tools, Backend‑Dienste oder Cloud‑Plattformen integrieren, um Daten dynamisch in professionelle, markenbezogene Präsentationen – nach Bedarf – zu konvertieren.

In diesem Artikel untersuchen wir die gängigen Anwendungsfälle für die automatisierte PowerPoint‑Erstellung in C++‑Apps (einschließlich Deployments auf Cloud‑Plattformen) und warum sie zu einem unverzichtbaren Feature moderner Lösungen wird. Vom Abrufen von Echtzeit‑Geschäftsdaten bis hin zur Umwandlung von Text oder Bildern in Folien, das Ziel ist, Rohinhalt in strukturierte, visuelle Formate zu verwandeln, die Ihr Publikum sofort versteht.

## **Gängige Anwendungsfälle für PowerPoint‑Automatisierung in C++**

Die Automatisierung der PowerPoint‑Erstellung ist besonders nützlich in Szenarien, in denen Präsentationsinhalte dynamisch zusammengestellt, personalisiert oder häufig aktualisiert werden müssen. Einige der häufigsten realen Anwendungsfälle sind:

- **Geschäftsberichte & Dashboards**  
  Erzeugen Sie Verkaufszusammenfassungen, KPIs oder Finanzleistungsberichte, indem Sie Live‑Daten aus Datenbanken oder APIs abrufen.

- **Personalisierte Verkaufs‑ & Marketing‑Decks**  
  Erstellen Sie automatisch kundenspezifische Pitch‑Decks mithilfe von CRM‑ oder Formulardaten, um schnelle Lieferzeiten und Markenkonsistenz zu gewährleisten.

- **Bildungsinhalt**  
  Konvertieren Sie Lernmaterial, Quizze oder Kurszusammenfassungen in strukturierte Folien‑Decks für E‑Learning‑Plattformen.

- **Daten‑ & KI‑gestützte Erkenntnisse**  
  Nutzen Sie Natural‑Language‑Processing‑ oder Analyse‑Engines, um Rohdaten oder lange Texte in zusammengefasste Präsentationen zu verwandeln.

- **Medienbasierte Folien**  
  Stellen Sie Präsentationen aus hochgeladenen Bildern, kommentierten Screenshots oder Video‑Keyframes mit unterstützenden Beschreibungen zusammen.

- **Dokumentkonvertierung**  
  Konvertieren Sie automatisch Word‑Dokumente, PDFs oder Formulareingaben in visuelle Präsentationen bei minimalem manuellem Aufwand.

- **Entwickler‑ und Technik‑Tools**  
  Erstellen Sie technische Demos, Dokumentations‑Übersichten oder Änderungsprotokolle im Folienformat direkt aus Code‑ oder Markdown‑Inhalten.

Durch die Automatisierung dieser Workflows können Organisationen die Inhaltserstellung skalieren, Konsistenz wahren und Zeit für strategischere Aufgaben freisetzen.

## **Lass uns codieren**

Für dieses Beispiel haben wir **[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)** ausgewählt, um PowerPoint‑Automatisierung zu demonstrieren, da es über einen umfassenden Funktionsumfang und eine einfache Handhabung bei der programmgesteuerten Arbeit mit Präsentationen verfügt.

Im Gegensatz zu Low‑Level‑Bibliotheken, die Entwickler dazu zwingen, direkt mit der Open‑XML‑Struktur zu arbeiten (was häufig zu ausschweifendem und weniger lesbarem Code führt), bietet Aspose.Slides eine höherwertige API. Sie abstrahiert die Komplexität, sodass sich Entwickler auf die Präsentationslogik – wie Layout, Formatierung und Datenbindung – konzentrieren können, ohne das PowerPoint‑Dateiformat im Detail verstehen zu müssen.

Obwohl Aspose.Slides eine kommerzielle Bibliothek ist, bietet sie eine [Kostenlose Testversion](https://releases.aspose.com/slides/cpp/) an, die vollständig in der Lage ist, die in diesem Artikel bereitgestellten Beispiele auszuführen. Für Demonstrationszwecke, das Testen von Funktionen oder das Erstellen eines Proof‑of‑Concepts, wie wir es hier behandeln, ist die Testversion mehr als ausreichend. Das macht sie zu einer praktischen Option, um mit automatisierter PowerPoint‑Erstellung zu experimentieren, ohne zunächst eine Lizenz erwerben zu müssen.

Ok, lassen Sie uns Schritt für Schritt eine Beispielpräsentation mit realen Inhalten erstellen.

### **Erstelle eine Titelfolie**

Wir beginnen damit, eine neue Präsentation zu erstellen und eine Titelfolie mit einer Hauptüberschrift und einem Untertitel hinzuzufügen.
```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```


![Die Titelfolie](slide_0.png)

### **Füge eine Folie mit einem Säulendiagramm hinzu**

Als Nächstes erstellen wir eine Folie, die die regionale Verkaufsleistung als Säulendiagramm zeigt.
```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```


![Die Folie mit dem Diagramm](slide_1.png)

### **Füge eine Folie mit einer Tabelle hinzu**

Jetzt fügen wir eine Folie hinzu, die wichtige Leistungskennzahlen im Tabellenformat präsentiert.
```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```


![Die Folie mit der Tabelle](slide_2.png)

### **Füge eine Zusammenfassungsfolie mit Aufzählungspunkten hinzu**

Abschließend fügen wir eine Zusammenfassung und einen Aktionsplan mithilfe einer einfachen Aufzählungsliste hinzu.
```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```

```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```


![Die Folie mit dem Text](slide_3.png)

### **Speichere die Präsentation**

Abschließend speichern wir die Präsentation auf dem Datenträger:
```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Fazit**

Die Automatisierung der PowerPoint‑Erstellung in C++‑Anwendungen bietet klare Vorteile bei der Zeitersparnis und der Reduzierung manueller Arbeit. Durch die Integration dynamischer Inhalte wie Diagramme, Tabellen und Text können Entwickler schnell konsistente, professionelle Präsentationen erzeugen – ideal für Geschäftsberichte, Kundentreffen oder Bildungsinhalte.

In diesem Artikel haben wir demonstriert, wie man die Erstellung einer Präsentation von Grund auf automatisiert, einschließlich dem Hinzufügen einer Titelfolie, Diagrammen und Tabellen. Dieser Ansatz lässt sich auf verschiedene Anwendungsfälle übertragen, in denen automatisierte, datengetriebene Präsentationen benötigt werden.

Durch den Einsatz der richtigen Werkzeuge können C++‑Entwickler die PowerPoint‑Erstellung effizient automatisieren, die Produktivität steigern und Konsistenz über alle Präsentationen hinweg sicherstellen.