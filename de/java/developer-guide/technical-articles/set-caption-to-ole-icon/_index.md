---  
title: Beschriftung für OLE-Icon festlegen  
type: docs  
weight: 130  
url: /java/set-caption-to-ole-icon/  
---  

Neue Methoden **getSubstitutePictureTitle** und **setSubstitutePictureTitle** wurden zum **IOleObjectFrame**-Interface und zur **OleObjectFrame**-Klasse hinzugefügt. Damit kann die Beschriftung eines OLE-Icons abgerufen, festgelegt oder geändert werden. Der folgende Codeausschnitt zeigt ein Beispiel für die Erstellung eines Excel-Objekts und das Festlegen seiner Beschriftung.  

```java  
Presentation presentation = new Presentation();  
ISlide slide = presentation.getSlides().get_Item(0);  

// Füge ein OLE-Objekt zur Folie hinzu  
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));  
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");  

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);  

// Füge ein Bild zur Bildsammlung der Präsentation hinzu  
IImage image = Images.fromFile("oleIconFile.ico");  
IPPImage ppImage = presentation.getImages().addImage(image);  
image.dispose();  

// Setze das Bild als Icon für das OLE-Objekt  
oleFrame.setObjectIcon(true);  
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);  

// Setze eine Beschriftung für das OLE-Icon  
oleFrame.setSubstitutePictureTitle("Beispiel für eine Beschriftung");  
```  