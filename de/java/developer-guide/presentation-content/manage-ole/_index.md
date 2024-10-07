---
title: OLE verwalten
type: docs
weight: 40
url: /java/manage-ole/
keywords:
- OLE hinzufügen
- OLE einbetten
- ein Objekt hinzufügen
- ein Objekt einbetten
- eine Datei einbetten
- verknüpftes Objekt
- Objektverknüpfung und -einbettung
- OLE-Objekt
- PowerPoint 
- Präsentation
- Java
- Aspose.Slides für Java
description: Fügen Sie OLE-Objekte in PowerPoint-Präsentationen in Java hinzu
---

{{% alert color="primary" %}} 

OLE (Objektverknüpfung und -einbettung) ist eine Microsoft-Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen Anwendung durch Verknüpfung oder Einbettung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in eine PowerPoint-Folie eingefügt. Dieses Excel-Diagramm wird als OLE-Objekt betrachtet. 

- Ein OLE-Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm, wenn Sie auf das Symbol doppelklicken, in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE-Objekt kann tatsächliche Inhalte anzeigen - zum Beispiel die Inhalte eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammoberfläche lädt und Sie können die Daten des Diagramms innerhalb der PowerPoint-App ändern.

[Aspose.Slides für Java](https://products.aspose.com/slides/java/) ermöglicht es Ihnen, OLE-Objekte als OLE-Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)) in Folien einzufügen.

## **Hinzufügen von OLE-Objektrahmen zu Folien**
Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten dieses Diagramm als OLE-Objektrahmen in eine Folie mit Aspose.Slides für Java einbetten, können Sie es wie folgt tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Erhalten Sie die Referenz der Folie, indem Sie ihren Index verwenden.
1. Öffnen Sie die Excel-Datei, die das Excel-Diagrammobjekt enthält, und speichern Sie sie im `MemoryStream`.
1. Fügen Sie den [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) zur Folie hinzu und übergeben Sie das Byte-Array und weitere Informationen über das OLE-Objekt.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel-Datei in eine Folie als OLE-Objektrahmen mit Aspose.Slides für Java eingefügt.  
**Hinweis**: Der Konstruktor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) akzeptiert eine einbettbare Objekterweiterung als zweiten Parameter. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE-Objekts auszuwählen.

``` java 
// Instanziiert die Präsentationsklasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Lädt eine Excel-Datei in den Stream
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // Erstellt ein Datenobjekt zum Einbetten
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // Fügt eine Ole Object Frame-Form hinzu
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    //Schreibt die PPTX-Datei auf die Festplatte
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugriff auf OLE-Objektrahmen**
Wenn ein OLE-Objekt bereits in eine Folie eingebettet ist, können Sie dieses Objekt leicht auf folgende Weise finden oder darauf zugreifen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Erhalten Sie die Referenz der Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die OLE-Objektrahmenform zu.

   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie hat. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) *cast*. Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.
1. Sobald der OLE-Objektrahmen zugegriffen wurde, können Sie beliebige Operationen darauf ausführen.

Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen - und dann werden die Dateidaten in eine Excel-Datei geschrieben.

``` java 
// Lädt die PPTX in ein Präsentationsobjekt
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Castet die Form zu OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Liest das OLE-Objekt und schreibt es auf die Festplatte
    if (oleObjectFrame != null) {
        // Holt die eingebetteten Dateidaten
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // Holt die eingebettete Dateierweiterung
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // Erstellt einen Pfad, um die extrahierte Datei zu speichern
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // Speichert die extrahierten Daten
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändern von OLE-Objektdaten**

Wenn ein OLE-Objekt bereits in eine Folie eingebettet ist, können Sie problemlos auf dieses Objekt zugreifen und seine Daten auf folgende Weise ändern:

1. Öffnen Sie die gewünschte Präsentation mit dem eingebetteten OLE-Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse erstellen.
1. Holen Sie sich die Referenz der Folie über ihren Index. 
1. Greifen Sie auf die OLE-Objektrahmenform zu.

   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie hat. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) *cast*. Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.
1. Sobald der OLE-Objektrahmen zugegriffen wurde, können Sie beliebige Operationen darauf ausführen.
1. Erstellen Sie das Workbook-Objekt und greifen Sie auf die OLE-Daten zu.
1. Greifen Sie auf das gewünschte Arbeitsblatt zu und ändern Sie die Daten.
1. Speichern Sie das aktualisierte Workbook in Streams.
1. Ändern Sie die OLE-Objektdaten aus den Stream-Daten.

Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen - und dann werden seine Dateidaten geändert, um die Diagrammdaten zu ändern:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Durchläuft alle Formen für Ole-Rahmen
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // Liest Objektdaten im Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // Ändert die Daten des Workbooks
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // Ändert die Ole-Rahmenobjektdaten
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Einbetten anderer Dateitypen in Folien

Neben Excel-Diagrammen ermöglicht es Aspose.Slides für Java, andere Dateitypen in Folien einzubetten. Zum Beispiel können Sie HTML-, PDF- und ZIP-Dateien als Objekte in eine Folie einfügen. Wenn ein Benutzer auf das eingefügte Objekt doppelklickt, wird das Objekt automatisch im entsprechenden Programm gestartet, oder der Benutzer wird aufgefordert, ein passendes Programm zum Öffnen des Objekts auszuwählen. 

Dieser Java-Code zeigt Ihnen, wie Sie HTML und ZIP in eine Folie einbetten:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Festlegen von Dateitypen für eingebettete Objekte

Beim Arbeiten mit Präsentationen müssen Sie möglicherweise alte OLE-Objekte durch neue ersetzen. Oder Sie müssen ein nicht unterstütztes OLE-Objekt durch ein unterstütztes ersetzen. 

Aspose.Slides für Java ermöglicht es Ihnen, den Dateityp für ein eingebettetes Objekt festzulegen. So können Sie die OLE-Rahmendaten oder dessen Erweiterung ändern. 

Dieser Java-Code zeigt Ihnen, wie Sie den Dateityp für ein eingebettetes OLE-Objekt festlegen:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("Die aktuelle eingebettete Daten Erweiterung ist: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Festlegen von Symbolbildern und Titeln für eingebettete Objekte

Nachdem Sie ein OLE-Objekt eingebettet haben, wird automatisch eine Vorschau mit einem Symbolbild und einem Titel hinzugefügt. Die Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE-Objekt zugreifen oder es öffnen. 

Wenn Sie ein bestimmtes Bild und einen bestimmten Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für Java festlegen. 

Dieser Java-Code zeigt Ihnen, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen: 

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("Mein Titel");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verhindern, dass ein OLE-Objektrahmen geändert oder repositioniert wird**

Nachdem Sie ein verknüpftes OLE-Objekt in eine Präsentationsfolie eingefügt haben, sehen Sie möglicherweise eine Meldung, die Sie auffordert, die Links zu aktualisieren, wenn Sie die Präsentation in PowerPoint öffnen. Ein Klick auf die Schaltfläche "Links aktualisieren" kann die Größe und Position des OLE-Objektrahmens ändern, da PowerPoint die Daten des verknüpften OLE-Objekts aktualisiert und die Objektvorschau aktualisiert. Um PowerPoint daran zu hindern, zur Aktualisierung der Objektdaten aufzufordern, setzen Sie die Methode `setUpdateAutomatic` der [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/)-Schnittstelle auf `false`:

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## Extrahieren eingebetteter Dateien

Aspose.Slides für Java ermöglicht es Ihnen, die in Folien als OLE-Objekte eingebetteten Dateien wie folgt zu extrahieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse, die das OLE-Objekt enthält, das Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)-Form zu.
3. Greifen Sie auf die Daten der eingebetteten Datei aus dem OLE-Objektrahmen zu und schreiben Sie sie auf die Festplatte. 

Dieser Java-Code zeigt Ihnen, wie Sie eine in eine Folie als OLE-Objekt eingebettete Datei extrahieren:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // Speichert die extrahierten Daten
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```