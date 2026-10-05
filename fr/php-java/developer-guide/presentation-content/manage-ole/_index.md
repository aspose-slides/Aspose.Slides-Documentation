---
title: Gérer OLE dans les présentations avec PHP
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/php-java/manage-ole/
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
- PHP
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java. Intégrez, mettez à jour et exportez le contenu OLE de manière transparente."
---
## **Introduction**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application via un lien ou une insertion. 
{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou il vous est demandé de sélectionner une application pour ouvrir ou modifier l'objet.  
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique dans PowerPoint.  

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) vous permet d’insérer des objets OLE dans les diapositives sous forme de cadres d’objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Ajouter des cadres d'objets OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l'intégrer dans une diapositive en tant que cadre d'objet OLE à l'aide d'Aspose.Slides for PHP via Java, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .  
1. Obtenez la référence d’une diapositive via son indice.  
1. Lisez le fichier Excel sous forme de tableau d’octets.  
1. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) à la diapositive en fournissant le tableau d’octets et les autres informations concernant l’objet OLE.  
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Dans l’exemple ci‑dessous, nous avons ajouté un graphique à partir d’un fichier Excel à une diapositive en tant que cadre d’objet OLE à l’aide d’Aspose.Slides for PHP via Java.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) prend comme deuxième paramètre une extension d’objet incrustable. Cette extension permet à PowerPoint d’interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Préparer les données pour l'objet OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Ajouter le cadre d'objet OLE à la diapositive.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Ajouter des cadres d'objet OLE liés**

Aspose.Slides for PHP via Java vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sans intégrer les données, mais uniquement avec un lien vers le fichier.  

Ce code PHP vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) avec un fichier Excel lié à une diapositive :

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Accéder aux cadres d'objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :  

1. Chargez une présentation contenant l’objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .  
2. Obtenez la référence de la diapositive en utilisant son indice.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne possède qu’une forme sur la première diapositive.  
4. Une fois le cadre d’objet OLE acces, vous pouvez effectuer toute opération dessus.  

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un objet graphique Excel intégré dans une diapositive) et ses données de fichier sont accessibles.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Obtenir les données du fichier intégré.
    // Obtenir l'extension du fichier intégré.
    // ...
}
```

### **Accéder aux propriétés du cadre d'objet OLE lié**

Aspose.Slides vous permet d’accéder aux propriétés des cadres d’objet OLE liés.  

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

## **Modifier les données d’un objet OLE**

{{% alert color="info" title="Note" %}}
Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).  
{{% /alert %}}

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette façon :

1. Chargez une présentation contenant l’objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .  
2. Obtenez la référence de la diapositive via son indice.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne possède qu’une forme sur la première diapositive.  
4. Une fois le cadre d’objet OLE acces, vous pouvez effectuer toute opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` souhaitée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Modifiez les données de l’objet OLE à partir du flux.  

Dans l’exemple ci‑dessus, un cadre d’objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Lire les données de l'objet OLE sous forme d'objet Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modifier les données du workbook.
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

## **Intégrer d’autres types de fichiers dans les diapositives**

Outre les graphiques Excel, Aspose.Slides for PHP via Java vous permet d’intégrer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP comme objets. Lorsqu’un utilisateur double‑clique sur l’objet inséré, il s’ouvre automatiquement dans le programme correspondant, ou il est invité à sélectionner un programme approprié pour l’ouvrir.  

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

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for PHP via Java vous permet de définir le type de fichier d’un objet intégré, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.  

Ce code PHP vous montre comment définir le type de fichier d’un objet OLE intégré sur `zip` :

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Modifier le type de fichier en ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Définir les images d’icône et les titres pour les objets intégrés**

Après l’intégration d’un objet OLE, un aperçu composé d’une image d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides for PHP via Java.  

Ce code PHP vous montre comment définir l’image d’icône et le titre pour un objet intégré :

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Ajouter une image aux ressources de la présentation.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Empêcher le redimensionnement et le repositionnement d’un cadre d’objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lors de l’ouverture de la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d’objet OLE car PowerPoint met à jour les données de l’objet OLE lié et actualise l’aperçu de l’objet. Pour empêcher PowerPoint de demander la mise à jour des données de l’objet, appelez la méthode [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) de la classe [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) avec la valeur `false` :

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Extraire les fichiers intégrés**

Aspose.Slides for PHP via Java vous permet d’extraire les fichiers intégrés dans les diapositives sous forme d’objets OLE de la manière suivante :  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) contenant les objets OLE que vous souhaitez extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).  
3. Accédez aux données des fichiers intégrés à partir des cadres d’objet OLE et écrivez‑les sur le disque.  

Ce code PHP vous montre comment extraire les fichiers intégrés dans une diapositive sous forme d’objets OLE :

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

**Le contenu OLE sera‑t‑il rendu lors de l’exportation des diapositives en PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône/l’image de substitution (aperçu). Le contenu OLE « en direct » n’est pas exécuté pendant le rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

Pour également conserver le fichier intégré en tant que pièce jointe PDF, appelez [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) avec la valeur `true`. Cette option est désactivée par défaut. Pour un exemple et des instructions pour vérifier la pièce jointe, consultez [Preserve Embedded OLE Files as PDF Attachments](/slides/fr/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Comment puis‑je verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des verrous au niveau de la forme. Ce n’est pas un chiffrement, mais cela empêche efficacement les modifications ou déplacements accidentels.

**Les chemins relatifs des objets OLE liés seront‑ils conservés dans le format PPTX ?**

Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles — seul le chemin complet l’est. Les chemins relatifs se trouvent dans l’ancien format PPT. Pour la portabilité, privilégiez les chemins absolus fiables/URI accessibles ou l’intégration.