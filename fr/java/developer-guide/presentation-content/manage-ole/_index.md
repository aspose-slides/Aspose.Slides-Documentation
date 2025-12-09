---
title: Gérer OLE dans les présentations avec Java
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/java/manage-ole/
keywords:
- "objet OLE"
- "Liaison et intégration d'objets"
- "ajouter OLE"
- "intégrer OLE"
- "ajouter objet"
- "intégrer objet"
- "ajouter fichier"
- "intégrer fichier"
- "objet lié"
- "fichier lié"
- "modifier OLE"
- "icône OLE"
- "titre OLE"
- "extraire OLE"
- "extraire objet"
- "extraire fichier"
- "PowerPoint"
- "présentation"
- "Java"
- "Aspose.Slides"
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour Java. Intégrez, mettez à jour et exportez le contenu OLE de manière fluide."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être placés dans une autre application via le lien ou l'intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou il vous est demandé de sélectionner une application pour ouvrir ou modifier l'objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique dans PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) vous permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Ajout de cadres d'objet OLE aux diapositives**

En supposant que vous ayez déjà créé un graphique dans Microsoft Excel et que vous souhaitiez l'intégrer dans une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for Java, vous pouvez procéder de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Obtenez la référence d'une diapositive via son indice.  
1. Lisez le fichier Excel sous forme de tableau d'octets.  
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) à la diapositive en incluant le tableau d'octets et les autres informations concernant l'objet OLE.  
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Dans l'exemple ci-dessous, nous avons ajouté un graphique provenant d'un fichier Excel à une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for Java.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) prend une extension d'objet intégrable comme second paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir l'application adéquate pour ouvrir cet objet OLE.  
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Ajout de cadres d'objet OLE liés**

Aspose.Slides for Java vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) sans intégrer les données, mais uniquement avec un lien vers le fichier.  

Ce code Java vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) avec un fichier Excel lié à une diapositive :  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Accès aux cadres d'objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :

1. Chargez une présentation contenant l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive en utilisant son indice.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui ne possède qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Il s'agissait du cadre d'objet OLE souhaité à accéder.  
4. Une fois le cadre d'objet OLE accessible, vous pouvez effectuer toute opération dessus.  

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel intégré dans une diapositive) et ses données de fichier sont accédés.  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Obtenir les données du fichier intégré.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtenir l'extension du fichier intégré.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Accès aux propriétés du cadre d'objet OLE lié**

Aspose.Slides vous permet d'accéder aux propriétés du cadre d'objet OLE lié.  

Ce code Java vous montre comment vérifier si un objet OLE est lié, puis récupérer le chemin du fichier lié :  
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


## **Modification des données d'un objet OLE**

{{% alert color="primary" %}} 

Dans cette section, l'exemple de code ci-dessous utilise [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Chargez une présentation contenant l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive via son indice.  
3. Accédez à la forme du cadre d'objet OLE.  
   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui possède une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Il s'agissait du cadre d'objet OLE souhaité à accéder.  
4. Une fois le cadre d'objet OLE accessible, vous pouvez effectuer toute opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` souhaitée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Modifiez les données de l'objet OLE à partir du flux.  

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.  
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

    // Modifier les données du workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Modifier les données de l'objet OLE frame.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Intégration d'autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for Java vous permet d'intégrer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets. Lorsqu'un utilisateur double-clique sur l'objet inséré, il s'ouvre automatiquement dans le programme correspondant, ou l'utilisateur est invité à choisir un programme approprié pour l'ouvrir.  

Ce code Java vous montre comment intégrer du HTML et du ZIP dans une diapositive :  
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


## **Définition des types de fichiers pour les objets intégrés**

Lors du travail avec des présentations, il peut être nécessaire de remplacer d'anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for Java vous permet de définir le type de fichier d'un objet intégré, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.  

Ce code Java vous montre comment définir le type de fichier d'un objet OLE intégré sur `zip` :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Définition des images d'icône et des titres pour les objets intégrés**

Après avoir intégré un objet OLE, un aperçu composé d'une image d'icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides for Java.  

Ce code Java vous montre comment définir l'image d'icône et le titre d'un objet intégré :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Ajouter une image aux ressources de la présentation.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Définir un titre et l'image pour l'aperçu OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Empêcher le redimensionnement et le repositionnement d'un cadre d'objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d'objet OLE car PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de proposer de mettre à jour les données de l'objet, réglez la méthode `setUpdateAutomatic` de l'interface [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) sur `false` :  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Extraction des fichiers intégrés**

Aspose.Slides for Java vous permet d'extraire les fichiers intégrés dans les diapositives en tant qu'objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contenant les objets OLE que vous souhaitez extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).  
3. Accédez aux données des fichiers intégrés à partir des cadres d'objet OLE et écrivez-les sur le disque.  

Ce code Java vous montre comment extraire les fichiers intégrés dans une diapositive en tant qu'objets OLE :  
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

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives en PDF/images ?**  
Ce qui est visible sur la diapositive est rendu — l'icône/l'image de substitution (aperçu). Le contenu OLE « live » n'est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**  
Verrouillez la forme : Aspose.Slides propose [des verrous au niveau de la forme](/slides/fr/java/applying-protection-to-presentation/). Ce n'est pas du chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j'ouvre la présentation ?**  
PowerPoint peut rafraîchir l'aperçu de l'OLE lié. Pour une apparence stable, suivez les pratiques de la [Solution de redimensionnement de feuille de calcul](/slides/fr/java/working-solution-for-worksheet-resizing/) — ajustez le cadre à la plage, ou redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront-ils préservés dans le format PPTX ?**  
Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles—seul le chemin complet l'est. Les chemins relatifs existent dans l'ancien format PPT. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l'intégration.