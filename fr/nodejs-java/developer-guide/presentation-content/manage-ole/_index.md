---
title: Gérer OLE dans les présentations avec JavaScript
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java. Intégrez, mettez à jour et exportez le contenu OLE sans effort."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être placés dans une autre application par le biais de liens ou d'intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou on vous demande de sélectionner une application pour l'ouverture ou la modification de l'objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique directement dans PowerPoint. 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) vous permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)). 

## **Ajout de cadres d'objet OLE aux diapositives**

En supposant que vous ayez déjà créé un graphique dans Microsoft Excel et que vous souhaitiez l'intégrer dans une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for Node.js via Java, vous pouvez le faire de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d'une diapositive à l'aide de son indice.  
3. Lisez le fichier Excel sous forme de tableau d'octets.  
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) à la diapositive en fournissant le tableau d'octets et les autres informations concernant l'objet OLE.  
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Dans l'exemple ci‑dessous, nous avons ajouté un graphique provenant d'un fichier Excel à une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for Node.js via Java.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) accepte une extension d'objet incrustable comme deuxième paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir l'application appropriée pour ouvrir cet objet OLE.  
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Préparer les données pour l'objet OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Ajouter le cadre d'objet OLE à la diapositive.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


### **Ajout de cadres d'objet OLE liés**

Aspose.Slides for Node.js via Java vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) sans incorporer les données mais uniquement avec un lien vers le fichier.  

Ce code JavaScript vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) avec un fichier Excel lié à une diapositive :  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Accès aux cadres d'objet OLE**

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez le trouver ou y accéder facilement de cette manière :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive en utilisant son indice.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne comporte qu'une forme sur la première diapositive.  
4. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer n'importe quelle opération dessus.  

Dans l'exemple ci‑dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) et ses données de fichier sont accessibles.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Obtenir les données du fichier intégré.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtenir l'extension du fichier intégré.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Accès aux propriétés du cadre d'objet OLE lié**

Aspose.Slides vous permet d'accéder aux propriétés du cadre d'objet OLE lié.  

Ce code JavaScript vous montre comment vérifier si un objet OLE est lié puis obtenir le chemin du fichier lié :  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Vérifier si l'objet OLE est lié.
    if (oleFrame.isObjectLink()) {
        // Afficher le chemin complet du fichier lié.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Afficher le chemin relatif du fichier lié s'il est présent.
        // Seules les présentations PPT peuvent contenir le chemin relatif.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Modification des données d'un objet OLE**

{{% alert color="primary" %}} 

Dans cette section, l'exemple de code ci‑dessous utilise [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence de la diapositive via son indice.  
3. Accédez à la forme du cadre d'objet OLE. Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui possède une forme sur la première diapositive.  
4. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer n'importe quelle opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` souhaitée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Modifiez les données de l'objet OLE à partir du flux.  

Dans l'exemple ci‑dessus, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lire les données de l'objet OLE en tant qu'objet Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifier les données du classeur.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Modifier les données de l'objet du cadre OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Incorporation d'autres types de fichiers dans les diapositives**

Outre les graphiques Excel, Aspose.Slides for Node.js via Java vous permet d'incorporer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP sous forme d'objets. Lorsqu'un utilisateur double-clique sur l'objet inséré, il s'ouvre automatiquement dans le programme correspondant, ou l'utilisateur est invité à sélectionner un programme approprié pour l'ouvrir.  

Ce code JavaScript vous montre comment intégrer du HTML et du ZIP dans une diapositive :  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Définition des types de fichiers pour les objets incorporés**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d'anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for Node.js via Java vous permet de définir le type de fichier d'un objet incorporé, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.  

Ce code JavaScript vous montre comment définir le type de fichier d'un objet OLE incorporé sur `zip` :  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Modifier le type de fichier en ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Définition des images d'icône et des titres pour les objets incorporés**

Après l'incorporation d'un objet OLE, un aperçu composé d'une image d'icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides for Node.js via Java.  

Ce code JavaScript vous montre comment définir l'image d'icône et le titre pour un objet incorporé :  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Ajouter une image aux ressources de la présentation.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Définir un titre et l'image pour l'aperçu OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Empêcher le redimensionnement et le repositionnement d'un cadre d'objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d'objet OLE car PowerPoint met à jour les données provenant de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de demander la mise à jour des données de l'objet, utilisez la méthode `setUpdateAutomatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) avec la valeur `false` :  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **Extraction des fichiers incorporés**

Aspose.Slides for Node.js via Java vous permet d'extraire les fichiers incorporés dans les diapositives en tant qu'objets OLE de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant les objets OLE que vous souhaitez extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).  
3. Accédez aux données des fichiers incorporés à partir des cadres d'objet OLE et écrivez-les sur le disque.  

Ce code JavaScript vous montre comment extraire les fichiers incorporés dans une diapositive en tant qu'objets OLE :  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```


## **FAQ**

**Le contenu OLE sera‑t‑il rendu lors de l'exportation des diapositives en PDF/images ?**  
Ce qui est visible sur la diapositive est rendu : l'icône/l'image de substitution (aperçu). Le contenu OLE « live » n'est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporté.

**Comment puis‑je verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**  
Verrouillez la forme : Aspose.Slides propose des verrous au niveau de la forme. Ce n'est pas un chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Les chemins relatifs des objets OLE liés seront‑ils conservés dans le format PPTX ?**  
Dans le format PPTX, les informations de « chemin relatif » ne sont pas disponibles —seul le chemin complet l’est. Les chemins relatifs se trouvent dans l'ancien format PPT. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l'incorporation.