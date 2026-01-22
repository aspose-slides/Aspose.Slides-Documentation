---
title: Gérer OLE dans les présentations sur Android
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour Android via Java. Intégrez, mettez à jour et exportez le contenu OLE de façon transparente."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être placés dans une autre application via la liaison ou l'intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou il vous est demandé de sélectionner une application pour ouvrir ou modifier l'objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique directement dans PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Ajouter des cadres d'objet OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l'intégrer dans une diapositive comme cadre d'objet OLE en utilisant Aspose.Slides for Android via Java, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). 
1. Obtenez la référence d'une diapositive via son index. 
1. Lisez le fichier Excel sous forme de tableau d'octets. 
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) à la diapositive en incluant le tableau d'octets et les autres informations concernant l'objet OLE. 
1. Enregistrez la présentation modifiée en tant que fichier PPTX. 

Dans l'exemple ci-dessous, nous avons ajouté un graphique provenant d'un fichier Excel à une diapositive comme cadre d'objet OLE en utilisant Aspose.Slides for Android via Java.  
**Remarque** : le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) accepte une extension d'objet incorporable comme second paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.  
```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Préparer les données pour l'objet OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Ajouter le cadre d'objet OLE à la diapo.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Ajouter des cadres d'objet OLE liés**

Aspose.Slides for Android via Java vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) sans incorporer les données, mais uniquement avec un lien vers le fichier.  

Ce code Java vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) avec un fichier Excel lié à une diapositive :  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Accéder aux cadres d'objet OLE**

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive en utilisant son index.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne contient qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Il s'agissait du cadre d'objet OLE souhaité à accéder.  
4. Une fois le cadre d'objet OLE accessible, vous pouvez effectuer toute opération dessus.  

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) et ses données de fichier sont accessibles.  
```java 
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


### **Accéder aux propriétés du cadre d'objet OLE lié**

Aspose.Slides vous permet d'accéder aux propriétés du cadre d'objet OLE lié.  

Ce code Java vous montre comment vérifier si un objet OLE est lié puis récupérer le chemin du fichier lié :  
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


## **Modifier les données d'un objet OLE**

{{% alert color="primary" %}} 

Dans cette section, l'exemple de code ci-dessous utilise [Aspose.Cells for Android via Java](/cells/androidjava/).  

{{% /alert %}}

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive via son index.  
3. Accédez à la forme du cadre d'objet OLE. Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui a une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Il s'agissait du cadre d'objet OLE souhaité à accéder.  
4. Une fois le cadre d'objet OLE accessible, vous pouvez effectuer toute opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` souhaitée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Modifiez les données de l'objet OLE à partir du flux.  

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) est accessible, et ses données de fichier sont modifiées afin de mettre à jour les données du graphique.  
```java 
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


## **Incorporer d'autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for Android via Java vous permet d'incorporer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets. Lorsqu'un utilisateur double-clique sur l'objet inséré, il s'ouvre automatiquement dans le programme approprié, ou l'utilisateur est invité à choisir un programme adéquat pour l'ouvrir.  

Ce code Java vous montre comment incorporer du HTML et du ZIP dans une diapositive :  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Définir les types de fichiers pour les objets incorporés**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d'anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for Android via Java vous permet de définir le type de fichier d'un objet incorporé, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.  

Ce code Java vous montre comment définir le type de fichier d'un objet OLE incorporé sur `zip` :  
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


## **Définir les images d'icône et les titres pour les objets incorporés**

Après avoir incorporé un objet OLE, un aperçu composé d'une image d'icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides for Android via Java.  

Ce code Java vous montre comment définir l'image d'icône et le titre pour un objet incorporé :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Ajouter une image aux ressources de la présentation.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Empêcher un cadre d'objet OLE d'être redimensionné et repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsqu'on ouvre la présentation dans PowerPoint, il peut apparaître un message vous demandant de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d'objet OLE parce que PowerPoint actualise les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de proposer de mettre à jour les données de l'objet, définissez la méthode `setUpdateAutomatic` de l'interface [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) sur `false` :  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Extraire les fichiers incorporés**

Aspose.Slides for Android via Java vous permet d'extraire les fichiers incorporés dans les diapositives en tant qu'objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant les objets OLE que vous souhaitez extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).  
3. Accédez aux données des fichiers incorporés à partir des cadres d'objet OLE et écrivez-les sur le disque.  

Ce code Java vous montre comment extraire les fichiers incorporés dans une diapositive en tant qu'objets OLE :  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```


## **FAQ**

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives en PDF/images ?**  
Ce qui est visible sur la diapositive est rendu —l'icône/l'image de substitution (aperçu). Le contenu OLE « live » n'est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/éditer dans PowerPoint ?**  
Verrouillez la forme : Aspose.Slides fournit des verrous au niveau de la forme. Ce n'est pas du chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsqu'on ouvre la présentation ?**  
PowerPoint peut actualiser l'aperçu de l'OLE lié. Pour une apparence stable, suivez les bonnes pratiques de la [Solution fonctionnelle pour le redimensionnement de feuille de calcul](/slides/fr/androidjava/working-solution-for-worksheet-resizing/) —soit ajustez le cadre à la plage, soit redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront-ils conservés dans le format PPTX ?**  
Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles —seul le chemin complet l'est. Les chemins relatifs existent dans l'ancien format PPT. Pour la portabilité, privilégiez les chemins absolus fiables/URI accessibles ou l'incorporation.  