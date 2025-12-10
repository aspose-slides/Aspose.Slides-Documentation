---
title: SmartArt in PowerPoint-Präsentationen mit C++ verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bildorganisationsdiagramm
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für C++ erstellen und bearbeiten, indem Sie klare Code‑Beispiele verwenden, die die Foliengestaltung und Automatisierung beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Die Eigenschaft TextFrame wurde nun zur ISmartArtShape‑Schnittstelle bzw. zur SmartArtShape‑Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus SmartArt abzurufen, falls nicht nur Knotentexte vorhanden sind. Der folgende Beispielcode hilft Ihnen, den Text aus einem SmartArt‑Knoten zu erhalten.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Layouttyp eines SmartArt-Objekts ändern**
Um den Layouttyp von SmartArt zu ändern, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie LayoutType zu BasicProcess.
- Speichern Sie die Präsentation als PPTX‑Datei.
  Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Versteckte Eigenschaft eines SmartArt-Objekts prüfen**
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() **true** zurückgibt, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen SmartArt‑Knotens zu prüfen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Prüfen Sie die Eigenschaft isHidden.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Organization‑Chart‑Typ abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() und setOrganizationChartLayout(int) ermöglichen das Abrufen bzw. Festlegen des Organization‑Chart‑Typs des aktuellen Knotens. Um den Organization‑Chart‑Typ zu erhalten oder zu setzen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Fügen Sie SmartArt zur Folie hinzu.
- Abrufen oder Festlegen des Organization‑Chart‑Typs.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Zustand eines SmartArt abrufen oder festlegen**
Einige SmartArt‑Diagramme unterstützen keine Umkehrung, zum Beispiel: Vertikale Aufzählungsliste, Vertikaler Prozess, Absteigender Prozess, Trichter, Zahnrad, Balance, Kreis‑Beziehung, Hexagon‑Cluster, Umgekehrte Liste, Gestapelte Venn‑Diagramme. Um die Orientierung von SmartArt zu ändern, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Fügen Sie SmartArt zur Folie hinzu.
- Abrufen oder Festlegen des Zustands des SmartArt‑Diagramms.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Picture‑Organization‑Chart erstellen**
Aspose.Slides for C++ stellt eine einfache API zum Erstellen von PictureOrganization‑Charts bereit. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code wird zum Erstellen eines Diagramms verwendet.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die Methode [set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) ändert die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Formensammlung klonen ([ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)) oder die gesamte Folie klonen, die diese Form enthält. Beide Methoden erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Raster‑Bild für eine Vorschau oder den Web‑Export?**

Rendern Sie die Folie (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis ist die Verwendung von Alternativ‑Text ([set_alternativetext](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/)) oder Namen ([set_name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/)) und die Suche nach der Form anhand dieses Attributs innerhalb der [Folienformen](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um ein SmartArt handelt ([SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)).