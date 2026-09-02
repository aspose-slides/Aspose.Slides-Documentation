---
title: Optimiser la gestion des images dans les présentations avec PHP
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/php-java/image/
keywords:
- ajouter une image
- ajouter une image
- ajouter un bitmap
- remplacer une image
- remplacer une image
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ressources SVG externes
- résolveur SVG
- images SVG liées
- polices SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java, en optimisant les performances et en automatisant votre flux de travail."
---
## **Introduction**

Les images rendent les présentations plus attrayantes et visuellement plaisantes. Dans Microsoft PowerPoint, vous pouvez insérer des images sur les diapositives à partir de fichiers, d'Internet ou d'autres sources. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives d'une présentation de plusieurs manières.

{{% alert  title="Astuce" color="primary" %}} 
Aspose propose des convertisseurs gratuits —[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d'images. 
{{% /alert %}} 

{{% alert title="Information" color="info" %}}
Si vous souhaitez ajouter une image sous forme de cadre d'image — surtout si vous prévoyez de la redimensionner, d'appliquer des effets ou d'utiliser d'autres options de mise en forme standard — consultez [Cadre d'image](/slides/fr/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}}
Vous pouvez convertir des images d'un format à un autre. Consultez les pages suivantes : convertissez [image en JPG](https://products.aspose.com/slides/fr/php-java/conversion/image-to-jpg/), [JPG en image](https://products.aspose.com/slides/fr/php-java/conversion/jpg-to-image/), [JPG en PNG](https://products.aspose.com/slides/fr/php-java/conversion/jpg-to-png/), [PNG en JPG](https://products.aspose.com/slides/fr/php-java/conversion/png-to-jpg/), [PNG en SVG](https://products.aspose.com/slides/fr/php-java/conversion/png-to-svg/), et [SVG en PNG](https://products.aspose.com/slides/fr/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides prend en charge les images dans les formats populaires tels que JPEG, PNG, BMP, GIF et d'autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images stockées sur votre ordinateur à une diapositive de présentation. Le code d'exemple PHP suivant montre comment ajouter une image à une diapositive :

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Ajouter des images depuis le Web aux diapositives**

Si l'image que vous voulez ajouter à une diapositive n'est pas stockée sur votre ordinateur, vous pouvez l'ajouter directement depuis le Web. 

Le code d'exemple PHP suivant montre comment ajouter une image depuis le Web à une diapositive :

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive stocke et contrôle les informations telles que le thème et la mise en page des diapositives qui l'utilisent. Lorsque vous ajoutez une image à un maître de diapositive, l'image apparaît sur chaque diapositive basée sur ce maître. 

Le code d'exemple PHP suivant montre comment ajouter une image à un maître de diapositive :

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Ajouter des images comme arrière-plan de diapositives**

Vous pouvez utiliser une image comme arrière-plan d'une ou plusieurs diapositives. Pour plus de détails, consultez *[Définir des images comme arrière-plans de diapositives](/slides/fr/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux présentations**

Le contenu SVG peut être ajouté à une présentation en utilisant la classe [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/). L'objet image SVG résultant peut ensuite être ajouté à la collection d'images de la présentation et utilisé pour créer un cadre d'image.

Le code d'exemple PHP suivant importe une chaîne SVG autonome. Toutes les images, styles et autres ressources utilisés par ce SVG sont intégrés directement dans le contenu SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importer du contenu SVG avec des ressources externes**

Les fichiers SVG exportés depuis des outils de conception, éditeurs de diagrammes, systèmes d'icônes et pipelines web peuvent faire référence à des ressources stockées en dehors du document SVG. Par exemple, un SVG peut contenir un lien d'image tel que `images/photo.png`, une valeur CSS `url(...)` ou une URL de police.

Pour importer ce type de contenu SVG, créez une implémentation d'[ExternalResourceResolver](https://reference.aspose.com/slides/fr/php-java/aspose.slides/externalresourceresolver/) et transmettez‑la, avec une URI de base, au constructeur approprié de [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/). L'URI de base identifie l'emplacement du document SVG et est utilisée pour résoudre les liens relatifs.

L'objet image SVG fournit un accès aux informations sur le SVG importé :

- `getSvgContent()` renvoie le balisage SVG sous forme de chaîne.
- `getSvgData()` renvoie le contenu SVG sous forme de tableau d'octets.
- `getBaseUri()` renvoie l'URI de base utilisé pour les liens relatifs.
- `getExternalResourceResolver()` renvoie le résolveur attribué à l'image SVG.

### **Implémenter un résolveur de ressources externes**

Le résolveur possède deux méthodes :

- `resolveUri` combine l'URI de base et un lien de ressource relatif et renvoie une URI absolue. Retournez `null` lorsque le lien ne peut pas être résolu ou n’est pas autorisé.
- `getEntity` renvoie un flux lisible pour une URI de ressource absolue. Retournez `null` lorsque la ressource est manquante, bloquée ou indisponible. Un flux de secours peut également être renvoyé le cas échéant.

Le résolveur suivant charge les ressources liées uniquement depuis un répertoire local autorisé. Les ressources réseau et les chemins en dehors du répertoire autorisé sont bloqués. Une image de secours optionnelle est renvoyée pour les liens d'image non résolus.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Ce résolveur autorise intentionnellement uniquement les fichiers locaux.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Utilisez un secours uniquement pour les ressources image. Retourner un flux d'image
            // pour une police ou une feuille de style manquante ne serait pas valide.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Résoudre les ressources liées lors de l'importation SVG**

Supposons que `assets/diagram.svg` contienne une référence relative telle que :

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Le code d'exemple PHP suivant transmet l'URI du fichier SVG comme URI de base et fournit un résolveur personnalisé. Le résolveur convertit le lien d'image relatif en URI absolue et renvoie un flux contenant la ressource liée pendant qu'Aspose.Slides traite le SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// L'URI de base représente l'emplacement du document SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// L'objet image SVG expose le contenu source, les données binaires, l'URI de base et le résolveur.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La classe `SvgImage` propose également des surcharges qui acceptent les données SVG sous forme de tableau d'octets ou de flux d'entrée, ainsi qu'un résolveur de ressources externes et une URI de base.

{{% alert title="Important" color="warning" %}}
Le résolveur de ressources rend les ressources externes disponibles pendant qu'Aspose.Slides traite et rend le SVG. Il ne modifie pas le balisage SVG original ni n'intègre automatiquement les ressources résolues.

Lorsqu'une image SVG est ajoutée à la collection d'images de la présentation, le fichier PPTX peut contenir à la fois la représentation SVG originale et une image raster de secours. Une ressource liée peut apparaître dans l'image de secours générée tandis qu'un lien relatif tel que `images/photo.png` reste inchangé dans le SVG stocké. Une application qui rend la représentation SVG native peut donc omettre le contenu lié lorsque la ressource externe d'origine n'est pas disponible.
{{% /alert %}}

### **Créer une image SVG portable**

Pour créer une image SVG qui ne dépend pas de fichiers externes, rendez le SVG autonome avant de créer le `SvgImage`. Par exemple, remplacez les URL d'images liées par des URI `data:` contenant les données de l'image :

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Après que toutes les ressources nécessaires soient intégrées dans le contenu SVG, créez le `SvgImage`, ajoutez‑le à la collection d'images de la présentation et insérez‑le dans un cadre d'image comme montré dans l'exemple précédent.

### **Gérer les ressources manquantes ou bloquées**

Retournez `null` depuis `resolveUri` lorsqu'une URI de ressource est invalide, interdite ou ne peut pas être résolue. Retournez `null` depuis `getEntity` lorsque la ressource ne peut pas être lue. Aspose.Slides poursuit le traitement du SVG sans cette ressource lorsque c'est possible.

Un flux de secours peut être renvoyé pour une ressource manquante, mais son contenu doit être compatible avec le type de ressource demandé. Par exemple, renvoyez un flux d'image uniquement pour une image manquante, pas pour une police ou une feuille de style.

{{% alert title="Sécurité" color="warning" %}}
Ne résolvez pas des chemins de fichiers arbitraires ou des URL réseau non restreintes provenant de fichiers SVG non fiables. Restreignez les schémas, répertoires et hôtes autorisés. Pour les ressources réseau, appliquez également des délais d’attente de connexion, des limites de taille de réponse et une validation du contenu.
{{% /alert %}}

## **Convertir SVG en un ensemble de formes**

Aspose.Slides peut convertir un SVG en un ensemble de formes, similaire à la fonctionnalité correspondante dans PowerPoint :

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [addGroupShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addgroupshape/) de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/) qui accepte un objet [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/) en premier argument.

Le code d'exemple PHP suivant montre comment utiliser cette méthode pour convertir un fichier SVG en un ensemble de formes :

```php
// Nom du fichier SVG source.
$svgFileName = "sample.svg";

// Nom du fichier de présentation en sortie.
$outPptxPath = "presentation.pptx";

// Créer une nouvelle présentation.
$presentation = new Presentation();
try {
    // Lire le contenu du fichier SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Créer un objet SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Obtenir la taille de la diapositive.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Convertir l'image SVG en groupe de formes et l'adapter à la taille de la diapositive.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Enregistrer la présentation au format PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Ajouter des images au format EMF aux diapositives**

Aspose.Slides pour PHP via Java vous permet de générer des images EMF à partir de feuilles de calcul Excel avec Aspose.Cells et de les ajouter aux diapositives de présentation.

Le code d'exemple PHP suivant montre comment procéder :

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Enregistrer le classeur dans un flux.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Ajouter le fichier tel quel afin que l'image reste un vecteur EMF au lieu d'être rasterisée.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Remplacer des images dans la collection d'images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d'images d'une présentation, y compris les images utilisées par les formes de diapositive. Cette section décrit plusieurs façons de mettre à jour les images de la collection. Vous pouvez remplacer une image en utilisant des données brutes sous forme de tableau d'octets, une instance [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) ou une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Chargez le fichier de présentation contenant des images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Chargez une nouvelle image depuis un fichier dans un tableau d'octets.
3. Remplacez l'image cible par la nouvelle image en utilisant le tableau d'octets.
4. Dans la deuxième approche, chargez l'image dans un objet [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) et remplacez l'image cible par cet objet.
5. Dans la troisième approche, remplacez l'image cible par une image qui existe déjà dans la collection d'images de la présentation.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation("sample.pptx");
try {
    // La première méthode.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // La deuxième méthode.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // La troisième méthode.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Enregistrer la présentation dans un fichier.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Information" color="info" %}}
Avec le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) d'Aspose, vous pouvez facilement animer du texte et créer des GIF à partir de texte. 
{{% /alert %}}

## **FAQ**

**La résolution originale de l'image reste‑t‑elle intacte après l'insertion ?**

Oui. Les pixels source sont conservés, mais l'apparence finale dépend de la façon dont le [cadre d'image](/slides/fr/php-java/picture-frame/) est redimensionné sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives d’un coup ?**

Placez le logo sur le maître de diapositive ou sur une mise en page et remplacez‑le dans la collection d'images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Une SVG insérée peut‑elle être convertie en formes éditables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi chaque partie devient éditable avec les propriétés de forme standard.

**Comment définir une image comme arrière‑plan de plusieurs diapositives en même temps ?**

[Attribuez l'image comme arrière‑plan](/slides/fr/php-java/presentation-background/) sur le maître de diapositive ou la mise en page concernée — toutes les diapositives utilisant ce maître/mise en page hériteront de l'arrière‑plan.

**Comment éviter qu'une présentation devienne trop volumineuse à cause d'un grand nombre d'images ?**

Réutilisez une même ressource d'image au lieu de dupliquer, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.