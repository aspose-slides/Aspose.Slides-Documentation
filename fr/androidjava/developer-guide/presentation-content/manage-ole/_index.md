---
title: Gérer OLE dans les présentations sur Android
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/androidjava/manage-ole/
keywords:
- objet OLE
- liaison et intégration d'objets
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
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java. Intégrez, mettez à jour et exportez le contenu OLE sans effort."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application via le lien ou l’intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d’icône. Dans ce cas, lorsque vous double‑cliquez sur l’icône, le graphique s’ouvre dans son application associée (Excel), ou il vous est demandé de sélectionner une application pour l’ouverture ou la modification de l’objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d’un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l’interface du graphique se charge, et vous pouvez modifier les données du graphique directement dans PowerPoint.

[Aspose.Slides pour Android via Java](https://products.aspose.com/slides/androidjava/) permet d’insérer des objets OLE dans les diapositives sous forme de cadres d’objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Ajouter des cadres d'objet OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l’intégrer dans une diapositive en tant que cadre d’objet OLE à l’aide d’Aspose.Slides pour Android via Java, vous pouvez procéder ainsi :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) classe.  
1. Obtenez la référence d’une diapositive via son index.  
1. Lisez le fichier Excel sous forme de tableau d’octets.  
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) à la diapositive en incluant le tableau d’octets et les autres informations sur l’objet OLE.  
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Dans l’exemple ci‑dessous, nous avons ajouté un graphique provenant d’un fichier Excel à une diapositive en tant que cadre d’objet OLE à l’aide d’Aspose.Slides pour Android via Java.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) accepte une extension d’objet intégrable comme second paramètre. Cette extension permet à PowerPoint d’interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.  
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

// Ajouter le cadre d'objet OLE à la diapositive.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Ajouter des cadres d'objet OLE liés**

Aspose.Slides pour Android via Java vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) sans intégrer les données mais uniquement avec un lien vers le fichier.

Ce code Java montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) avec un fichier Excel lié à une diapositive :  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Accéder aux cadres d'objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez le trouver ou y accéder facilement de cette manière :

1. Chargez une présentation contenant l’objet OLE intégré en créant une instance de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) classe.  
2. Obtenez la référence de la diapositive en utilisant son index.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).  
   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui ne comporte qu’une seule forme sur la première diapositive. Nous avons ensuite *cast* cet objet en tant qu’[IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). C’était le cadre d’objet OLE souhaité à accéder.  
4. Une fois le cadre d’objet OLE accédé, vous pouvez effectuer toute opération dessus.  

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un graphique Excel intégré dans une diapositive) et les données du fichier qui le composent sont accessibles.  
```java 
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


### **Accéder aux propriétés du cadre d'objet OLE lié**

Aspose.Slides permet d’accéder aux propriétés des cadres d’objet OLE liés.

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

        // Afficher le chemin relatif du fichier lié si présent.
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

Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells pour Android via Java](/cells/androidjava/).  

{{% /alert %}}

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de la façon suivante :

1. Chargez une présentation contenant l’objet OLE intégré en créant une instance de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) classe.  
2. Obtenez la référence de la diapositive via son index.  
3. Accédez à la forme du cadre d’objet OLE.  
   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui ne comporte qu’une forme sur la première diapositive. Nous avons ensuite *cast* cet objet en tant qu’[IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). C’était le cadre d’objet OLE souhaité à accéder.  
4. Une fois le cadre d’objet OLE accédé, vous pouvez effectuer toute opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` désirée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Remplacez les données de l’objet OLE à partir du flux.  

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un graphique Excel intégré dans une diapositive) est accédé et les données du fichier sont modifiées afin de mettre à jour les données du graphique.  
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


## **Intégrer d'autres types de fichiers dans les diapositives**

Outre les graphiques Excel, Aspose.Slides pour Android via Java vous permet d’intégrer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP comme objets. Lorsqu’un utilisateur double‑clique sur l’objet inséré, il s’ouvre automatiquement dans le programme approprié, ou l’utilisateur est invité à choisir un programme adapté pour l’ouvrir.

Ce code Java montre comment intégrer du HTML et du ZIP dans une diapositive :  
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


## **Définir les types de fichiers pour les objets intégrés**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou de substituer un objet OLE non pris en charge par un objet supporté. Aspose.Slides pour Android via Java vous permet de définir le type de fichier d’un objet intégré, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.

Ce code Java montre comment définir le type de fichier d’un objet OLE intégré sur `zip` :  
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


## **Définir les images d'icône et les titres pour les objets intégrés**

Après l’intégration d’un objet OLE, un aperçu constitué d’une image d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides pour Android via Java.

Ce code Java montre comment définir l’image d’icône et le titre pour un objet intégré :  
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

// Définir un titre et l'image pour l'aperçu OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Empêcher le redimensionnement et le repositionnement d'un cadre d'objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, un message peut vous demander de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d’objet OLE parce que PowerPoint actualise les données de l’objet OLE lié et rafraîchit l’aperçu de l’objet. Pour empêcher PowerPoint de demander la mise à jour des données de l’objet, définissez la méthode `setUpdateAutomatic` de l’interface [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) sur `false` :  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Extraire les fichiers intégrés**

Aspose.Slides pour Android via Java vous permet d’extraire les fichiers intégrés dans les diapositives en tant qu’objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant les objets OLE que vous souhaitez extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).  
3. Accédez aux données des fichiers intégrés à partir des cadres d’objet OLE et écrivez‑les sur le disque.  

Ce code Java montre comment extraire les fichiers intégrés dans une diapositive sous forme d’objets OLE :  
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

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives vers PDF/images ?**  
Ce qui est visible sur la diapositive est rendu : l’icône ou l’image de substitution (aperçu). Le contenu OLE « live » n’est pas exécuté pendant le rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

**Comment puis‑je verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer ou le modifier dans PowerPoint ?**  
Verrouillez la forme : Aspose.Slides propose des [verrous au niveau de la forme](/slides/fr/androidjava/applying-protection-to-presentation/). Ce n’est pas du chiffrement, mais cela empêche effectivement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j'ouvre la présentation ?**  
PowerPoint peut actualiser l’aperçu de l’objet OLE lié. Pour une apparence stable, suivez les bonnes pratiques décrites dans la [Solution fonctionnelle pour le redimensionnement des feuilles de calcul](/slides/fr/androidjava/working-solution-for-worksheet-resizing/) : adaptez le cadre à la plage, ou mettez l’échelle de la plage dans un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront‑ils conservés dans le format PPTX ?**  
Dans PPTX, les informations de « chemin relatif » ne sont pas disponibles ; seul le chemin complet est stocké. Les chemins relatifs existent uniquement dans le format PPT plus ancien. Pour garantir la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l’intégration directe.  