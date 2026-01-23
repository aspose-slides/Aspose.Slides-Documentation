---
title: "Gérer les objets OLE dans les présentations avec PHP"
linktitle: "Gestion OLE"
type: docs
weight: 40
url: /fr/php-java/manage-ole/
keywords:
  - "objet OLE"
  - "liaison et intégration d'objets"
  - "ajouter OLE"
  - "intégrer OLE"
  - "ajouter un objet"
  - "intégrer un objet"
  - "ajouter un fichier"
  - "intégrer un fichier"
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
  - "PHP"
  - "Aspose.Slides"
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides for PHP via Java. Intégrez, mettez à jour et exportez le contenu OLE de manière transparente."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application via le lien ou l'intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou il vous est demandé de sélectionner une application pour l'ouverture ou la modification de l'objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique directement dans PowerPoint. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) vous permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)). 

## **Ajouter des cadres d'objets OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l'intégrer dans une diapositive en tant que cadre d'objet OLE à l'aide d'Aspose.Slides for PHP via Java, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
1. Obtenez la référence d'une diapositive via son index. 
1. Lisez le fichier Excel sous forme de tableau d'octets. 
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) à la diapositive en incluant le tableau d'octets et les autres informations sur l'objet OLE. 
1. Enregistrez la présentation modifiée au format PPTX. 

Dans l'exemple ci-dessous, nous avons ajouté un graphique d'un fichier Excel à une diapositive en tant que cadre d'objet OLE à l'aide d'Aspose.Slides for PHP via Java.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) accepte une extension d'objet intégrable comme deuxième paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.  
```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


### **Ajouter des cadres d'objets OLE liés**

Aspose.Slides for PHP via Java vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sans intégrer de données, mais uniquement avec un lien vers le fichier.  

Ce code PHP vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) avec un fichier Excel lié à une diapositive :  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Accéder aux cadres d'objets OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :

1. Chargez une présentation contenant l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Obtenez la référence de la diapositive en utilisant son index. 
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne contient qu'une seule forme sur la première diapositive. 
4. Une fois le cadre d'objet OLE accessible, vous pouvez effectuer toute opération dessus.  

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel intégré dans une diapositive) et ses données de fichier sont accessibles.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Obtient les données du fichier intégré.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Obtient l'extension du fichier intégré.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **Accéder aux propriétés du cadre d'objet OLE lié**

Aspose.Slides vous permet d'accéder aux propriétés du cadre d'objet OLE lié.  

Ce code PHP vous montre comment vérifier si un objet OLE est lié, puis obtenir le chemin du fichier lié :  
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Vérifier si l'objet OLE est lié.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Afficher le chemin complet du fichier lié.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Afficher le chemin relatif du fichier lié s'il est présent.
        // Seules les présentations PPT peuvent contenir le chemin relatif.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```


## **Modifier les données d'un objet OLE**

{{% alert color="primary" %}} 

Dans cette section, l'exemple de code ci-dessous utilise [Aspose.Cells for PHP via Java](/cells/php-java/).  

{{% /alert %}} 

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Chargez une présentation contenant l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Obtenez la référence de la diapositive via son index. 
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui possède une forme sur la première diapositive. 
4. Une fois le cadre d'objet OLE accessible, vous pouvez effectuer toute opération dessus. 
5. Créez un objet `Workbook` et accédez aux données OLE. 
6. Accédez à la `Worksheet` souhaitée et modifiez les données. 
7. Enregistrez le `Workbook` mis à jour dans un flux. 
8. Modifiez les données de l'objet OLE à partir du flux.  

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Lire les données de l'objet OLE en tant qu'objet Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modifier les données du classeur.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Modifier les données de l'objet du cadre OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Intégrer d'autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for PHP via Java vous permet d'intégrer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets. Lorsqu'un utilisateur double-clique sur l'objet inséré, il s'ouvre automatiquement dans le programme approprié, ou l'utilisateur est invité à choisir un programme adéquat pour l'ouvrir.  

Ce code PHP vous montre comment intégrer du HTML et du ZIP dans une diapositive :  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Définir les types de fichiers pour les objets intégrés**

Lorsque vous travaillez avec des présentations, il peut être nécessaire de remplacer d'anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for PHP via Java vous permet de définir le type de fichier pour un objet intégré, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.  

Ce code PHP vous montre comment définir le type de fichier d'un objet OLE intégré à `zip` :  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Définir les images d'icône et les titres pour les objets intégrés**

Après l'intégration d'un objet OLE, un aperçu composé d'une image d'icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre à l'aide d'Aspose.Slides for PHP via Java.  

Ce code PHP vous montre comment définir l'image d'icône et le titre pour un objet intégré :  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Ajouter une image aux ressources de la présentation.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Empêcher le redimensionnement et le repositionnement d'un cadre d'objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d'objet OLE parce que PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de vous inviter à mettre à jour les données de l'objet, définissez la méthode `setUpdateAutomatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sur `false` :  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **Extraire les fichiers intégrés**

Aspose.Slides for PHP via Java vous permet d'extraire les fichiers intégrés dans les diapositives en tant qu'objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) contenant les objets OLE que vous souhaitez extraire. 
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). 
3. Accédez aux données des fichiers intégrés provenant des cadres d'objets OLE et écrivez-les sur le disque.  

Ce code PHP vous montre comment extraire les fichiers intégrés dans une diapositive en tant qu'objets OLE :  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```


## **FAQ**

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives en PDF/images ?**  
Ce qui est visible sur la diapositive est rendu — l'icône/l'image de substitution (aperçu). Le contenu OLE "en direct" n'est pas exécuté pendant le rendu. Si nécessaire, définissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/éditer dans PowerPoint ?**  
Verrouillez la forme : Aspose.Slides propose des verrous au niveau de la forme. Ce n'est pas un chiffrement, mais cela empêche effectivement les modifications et déplacements accidentels.

**Les chemins relatifs pour les objets OLE liés seront-ils conservés dans le format PPTX ?**  
Dans le format PPTX, l'information "chemin relatif" n'est pas disponible — seul le chemin complet l'est. Les chemins relatifs existent dans l'ancien format PPT. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l'intégration.