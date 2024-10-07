---
title: SmartArt verwalten
type: docs
weight: 10
url: /cpp/manage-smartart/
---

## **Text aus SmartArt abrufen**
Jetzt wurde die TextFrame-Eigenschaft zum ISmartArtShape-Interface und zur SmartArtShape-Klasse hinzugefügt. Diese Eigenschaft ermöglicht es Ihnen, gesamten Text aus SmartArt abzurufen, wenn sie nicht nur Knotentext hat. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten abzurufen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Layouttyp von SmartArt ändern**
Um den Layouttyp von SmartArt zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
- Erhalten Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie den LayoutType in BasicProcess.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Versteckte Eigenschaften von SmartArt überprüfen**
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() true zurückgibt, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von SmartArt zu überprüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die isHidden-Eigenschaft.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Organigrammtyp abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ermöglichen das Abrufen oder Festlegen des mit dem aktuellen Knoten verknüpften Organigrammtyps. Um den Organigrammtyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
- Fügen Sie SmartArt auf die Folie hinzu.
- Holen Sie sich den Organigrammtyp oder setzen Sie ihn.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Zustand von SmartArt abrufen oder festlegen**
Einige SmartArt-Diagramme unterstützen keine Umkehrung, z.B.; vertikale Aufzählungsliste, vertikaler Prozess, absteigender Prozess, Trichter, Zahnrad, Gleichgewicht, Kreisbeziehung, Sechseck-Cluster, umgekehrte Liste, gestapelte Venn. Um die Ausrichtung von SmartArt zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
- Fügen Sie SmartArt auf die Folie hinzu.
- Holen Sie sich den Zustand des SmartArt-Diagramms oder setzen Sie ihn.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Bild-Organigramm erstellen**
Aspose.Slides für C++ bietet eine einfache API zum Erstellen von Bild-Organigrammen auf einfache Weise. Um ein Diagramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie anhand ihres Indexes.
3. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (ChartType.PictureOrganizationChart).
4. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```