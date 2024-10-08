---
title: SmartArt verwalten
type: docs
weight: 10
url: /de/java/manage-smartart/
---

## **Text aus SmartArt erhalten**
Jetzt wurde die TextFrame-Methode zum [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) Interface und zur [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, allen Text aus [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu erhalten, wenn er nicht nur Knotentext enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten zu erhalten.

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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu ändern, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie den [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) auf BasicProcess.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```java
Presentation pres = new Presentation();
try {
    // Füge SmartArt BasicProcess hinzu
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Ändere den LayoutType auf BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Präsentation speichern
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Überprüfen der versteckten Eigenschaft von SmartArt**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu überprüfen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) Eigenschaft.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```java
Presentation pres = new Presentation();
try {
    // Füge SmartArt BasicProcess hinzu 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Füge einen Knoten zu SmartArt hinzu 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Überprüfe die isHidden-Eigenschaft
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

## **Organisation Diagramm Typ erhalten oder setzen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen oder Setzen des mit dem aktuellen Knoten verbundenen Organisationdiagrammtyps. Um den Organisationdiagrammtyp zu erhalten oder zu setzen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
- Holen Sie sich oder [setzen Sie den Organisationdiagrammtyp](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```java
Presentation pres = new Presentation();
try {
    // Füge SmartArt BasicProcess hinzu
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Holen Sie sich oder setzen Sie den Organisationdiagrammtyp
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bild Organisation Diagramm erstellen**
Aspose.Slides für Java bietet eine einfache API zur Erstellung von Bildorganisation Diagrammen auf einfache Weise. Um ein Diagramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz der Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.

```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt-Zustand erhalten oder setzen**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu ändern, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
1. [Holen Sie sich](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) oder [setzen Sie](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) den Zustand des SmartArt-Diagramms.
1. Schreiben Sie die Präsentation als PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.

```java
// Instanziiere die Präsentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Füge SmartArt BasicProcess hinzu
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Holen Sie sich oder setzen Sie den Zustand des SmartArt-Diagramms
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Präsentation speichern
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```