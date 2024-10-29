---
title: Définir la légende sur l'icône OLE
type: docs
weight: 130
url: /fr/java/set-caption-to-ole-icon/
---

De nouvelles méthodes **getSubstitutePictureTitle** et **setSubstitutePictureTitle** ont été ajoutées à l'interface **IOleObjectFrame** et à la classe **OleObjectFrame**. Cela permet d'obtenir, de définir ou de changer la légende d'une icône OLE. L'extrait de code ci-dessous montre un exemple de création d'objet Excel et de définition de sa légende.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter un objet OLE à la diapositive
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// Ajouter une image à la collection d'images de la présentation
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// Définir l'image comme icône pour l'objet OLE
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// Définir une légende sur l'icône OLE
oleFrame.setSubstitutePictureTitle("Exemple de légende");
```