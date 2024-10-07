---
title: SmartArt verwalten
type: docs
weight: 10
url: /androidjava/manage-smartart/
---

## **Text aus SmartArt abrufen**
Jetzt wurde die Methode TextFrame zum [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) Interface und zur [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) Klasse hinzugefügt. Diese Eigenschaft ermöglicht es Ihnen, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) abzurufen, wenn er mehr als nur Knotentext enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten abzurufen.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Layouttyp von SmartArt ändern**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```java
Presentation pres = new Presentation();
try {
    // Fügen Sie SmartArt BasicProcess hinzu
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Ändern Sie den Layouttyp zu BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Präsentation speichern
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Versteckte Eigenschaft von SmartArt überprüfen**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu überprüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) Eigenschaft.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```java
Presentation pres = new Presentation();
try {
    // Fügen Sie SmartArt BasicProcess hinzu 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Fügen Sie einen Knoten zu SmartArt hinzu 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Überprüfen Sie die isHidden Eigenschaft
    boolean hidden = node.isHidden(); // Gibt true zurück

    if (hidden)
    {
        // Führen Sie einige Aktionen oder Benachrichtigungen durch
    }
    // Präsentation speichern
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Organigrammtyp abrufen oder festlegen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen oder Festlegen des mit dem aktuellen Knoten verbundenen Organigrammtyps. Um den Organigrammtyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf einer Folie hinzu.
- [Rufen Sie den Organigrammtyp ab oder legen Sie ihn fest](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```java
Presentation pres = new Presentation();
try {
    // Fügen Sie SmartArt BasicProcess hinzu
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Organigrammtyp abrufen oder festlegen
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bild-Organigramm erstellen**
Aspose.Slides für Android über Java bietet eine einfache API zum Erstellen von Bild-Organigrammen auf einfache Weise. Um ein Organigramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie durch deren Index.
1. Fügen Sie ein Organigramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Organigramm zu erstellen.

```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt-Zustand abrufen oder festlegen**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf einer Folie hinzu.
1. [Holen Sie sich](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) oder [legen Sie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) den Zustand des SmartArt-Diagramms fest.
1. Schreiben Sie die Präsentation als PPTX-Datei.

Der folgende Code wird verwendet, um ein Organigramm zu erstellen.

```java
// Instantiate Presentation class that represents the PPTX file
Presentation pres = new Presentation();
try {
    // Fügen Sie SmartArt BasicProcess hinzu
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Holen Sie sich oder legen Sie den Zustand des SmartArt-Diagramms fest
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Präsentation speichern
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```