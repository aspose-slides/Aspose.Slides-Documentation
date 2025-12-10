---
title: Gestion des objets OLE dans les présentations avec Java
linktitle: Gestion OLE
type: docs
weight: 40
url: /fr/java/manage-ole/
keywords:
- objet OLE
- liaison et incorporation d'objets
- ajouter OLE
- intégrer OLE
- ajouter objet
- intégrer objet
- ajouter fichier
- intégrer fichier
- objet lié
- fichier lié
- modifier OLE
- icône OLE
- titre OLE
- extraire OLE
- extraire objet
- extraire fichier
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour Java. Intégrez, mettez à jour et exportez le contenu OLE en toute transparence."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application via un lien ou une incorporation. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d’icône. Dans ce cas, en double‑cliquant sur l’icône, le graphique s’ouvre dans son application associée (Excel), ou l’on vous demande de choisir une application pour ouvrir ou modifier l’objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d’un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l’interface du graphique se charge, et vous pouvez modifier les données du graphique depuis PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) permet d’insérer des objets OLE dans des diapositives sous forme de cadres d’objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Ajouter des cadres d’objets OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l’intégrer dans une diapositive sous forme de cadre d’objet OLE avec Aspose.Slides for Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Obtenez la référence d’une diapositive par son index.  
1. Lisez le fichier Excel sous forme de tableau d’octets.  
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) à la diapositive en fournissant le tableau d’octets et les autres informations sur l’objet OLE.  
1. Enregistrez la présentation modifiée en fichier PPTX.  

Dans l’exemple ci‑dessous, nous avons ajouté un graphique depuis un fichier Excel à une diapositive sous forme de cadre d’objet OLE avec Aspose.Slides for Java.  
**Remarque** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) accepte une extension d’objet incorporable comme second paramètre. Cette extension permet à PowerPoint d’interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.  
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Préparer les données pour l'objet OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Ajouter le cadre d'objet OLE à la diapositive.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Ajouter des cadres d’objets OLE liés**

Aspose.Slides for Java vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) sans incorporer les données, mais uniquement avec un lien vers le fichier.

Ce code Java montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) avec un fichier Excel lié à une diapositive :  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Accéder aux cadres d’objets OLE**

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez le trouver ou y accéder de cette façon :

1. Chargez une présentation contenant l’objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive en utilisant son index.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame).  
   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui ne possède qu’une forme sur la première diapositive. Nous avons ensuite **casté** cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). C’était le cadre d’objet OLE souhaité.  
4. Une fois le cadre d’objet OLE accédé, vous pouvez effectuer toute opération dessus.  

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un objet graphique Excel incorporé dans une diapositive) et ses données de fichier sont accessibles.  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Obtenir les données du fichier incorporé.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtenir l'extension du fichier incorporé.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Accéder aux propriétés du cadre d’objet OLE lié**

Aspose.Slides vous permet d’accéder aux propriétés du cadre d’objet OLE lié.

Ce code Java montre comment vérifier si un objet OLE est lié puis obtenir le chemin du fichier lié :  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Vérifier si l'objet OLE est lié.
    if (oleFrame.isObjectLink()) {
        // Afficher le chemin complet du fichier lié.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Afficher le chemin relatif du fichier lié s'il est présent.
        // Seules les présentations PPT peuvent contenir le chemin relatif.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Modifier les données d’un objet OLE**

{{% alert color="primary" %}} 

Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette façon :

1. Chargez une présentation contenant l’objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive par son index.  
3. Accédez à la forme du cadre d’objet OLE.  
   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui possède une forme sur la première diapositive. Nous avons ensuite **casté** cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). C’était le cadre d’objet OLE souhaité.  
4. Une fois le cadre d’objet OLE accédé, vous pouvez effectuer toute opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` souhaitée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Remplacez les données de l’objet OLE à partir du flux.  

Dans l’exemple ci‑dessus, un cadre d’objet OLE (un objet graphique Excel incorporé dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lire les données de l'objet OLE en tant qu'objet Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifier les données du classeur.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Modifier les données de l'objet du cadre OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Incorporer d’autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for Java vous permet d’incorporer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP comme objets. Lorsqu’un utilisateur double‑clique sur l’objet inséré, il s’ouvre automatiquement dans le programme approprié, ou l’on lui propose de choisir un programme adapté.  

Ce code Java montre comment incorporer du HTML et du ZIP dans une diapositive :  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Définir les types de fichiers pour les objets incorporés**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for Java vous permet de définir le type de fichier d’un objet incorporé, vous permettant de mettre à jour les données du cadre OLE ou son extension.  

Ce code Java montre comment définir le type de fichier d’un objet OLE incorporé sur `zip` :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Modifier le type de fichier en ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Définir les images d’icône et les titres pour les objets incorporés**

Après avoir incorporé un objet OLE, un aperçu sous forme d’image d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l’aperçu, vous pouvez définir l’image d’icône et le titre avec Aspose.Slides for Java.  

Ce code Java montre comment définir l’image d’icône et le titre pour un objet incorporé :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Ajouter une image aux ressources de la présentation.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Empêcher le redimensionnement et le repositionnement d’un cadre d’objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, il se peut qu’un message vous invite à mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d’objet OLE parce que PowerPoint actualise les données provenant de l’objet OLE lié et rafraîchit l’aperçu de l’objet. Pour empêcher PowerPoint de vous demander de mettre à jour les données de l’objet, définissez la méthode `setUpdateAutomatic` de l’interface [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) sur `false` :  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Extraire les fichiers incorporés**

Aspose.Slides for Java vous permet d’extraire les fichiers incorporés dans les diapositives sous forme d’objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contenant les objets OLE à extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).  
3. Accédez aux données des fichiers incorporés à partir des cadres d’objet OLE et écrivez‑les sur le disque.  

Ce code Java montre comment extraire les fichiers incorporés dans une diapositive sous forme d’objets OLE :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```


## **FAQ**

**Le contenu OLE sera‑t‑il rendu lors de l’exportation des diapositives en PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône/l’image de substitution (aperçu). Le contenu OLE « live » n’est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des [verrous au niveau de la forme](/slides/fr/java/applying-protection-to-presentation/). Ce n’est pas du chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j’ouvre la présentation ?**

PowerPoint peut rafraîchir l’aperçu de l’OLE lié. Pour une apparence stable, suivez les pratiques de la [Solution fonctionnelle pour le redimensionnement de feuille de calcul](/slides/fr/java/working-solution-for-worksheet-resizing/) — adaptez le cadre à la plage, ou redimensionnez la plage à un cadre fixe et définissez une image de substitution adaptée.

**Les chemins relatifs des objets OLE liés sont‑ils conservés dans le format PPTX ?**

Dans PPTX, les informations de « chemin relatif » ne sont pas disponibles — seul le chemin complet l’est. Les chemins relatifs se trouvent dans le format plus ancien PPT. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l’incorporation.