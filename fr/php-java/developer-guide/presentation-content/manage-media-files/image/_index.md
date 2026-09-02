---
title: Optimiser la gestion des images dans les présentations avec PHP
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/php-java/image/
keywords:
- ajouter une image
- ajouter une image
- remplacer une image
- collection d'images
- cadre d'image
- image liée
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- SVG en formes
- ressources SVG externes
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java."
---
## **Introduction**

Aspose.Slides for PHP via Java offre plusieurs façons de travailler avec des images, et chaque méthode sert un but différent. Vous pouvez stocker une image dans une présentation, l'afficher dans un cadre d'image, l'utiliser comme arrière-plan de diapositive, créer un lien vers une image externe, remplacer une ressource d'image partagée ou convertir du contenu SVG en formes modifiables.

Cet article se concentre sur les ressources image et sur leur utilisation dans une présentation. Pour le recadrage, la transparence, les effets, l'étirement et d'autres mises en forme appliquées à un cadre d'image individuel, voir [Picture Frame](/slides/fr/php-java/picture-frame/).

## **Comprendre le modèle d'image**

Les concepts d’API suivants sont étroitement liés mais ne sont pas interchangeables :

- La [collection d'images de présentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) stocke les ressources image utilisées par la présentation. Utilisez [ImageCollection::addImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) pour ajouter des données d'image et obtenir une ressource [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/).
- Un [picture frame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) est une forme qui affiche une image sur une diapositive, une mise en page ou un maître. Utilisez [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addpictureframe/) pour placer une ressource image sur une diapositive.
- Un arrière-plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme une forme. Il ne se comporte donc pas comme un picture frame.
- [PPImage::replaceImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) remplace une ressource image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d'un SVG en formes crée des formes de diapositive modifiables. Après conversion, le contenu n'est plus géré comme une unique ressource image.

Un flux de travail typique est donc : ajouter des données d'image à la collection d'images, recevoir un [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/), puis utiliser cette ressource dans une ou plusieurs images de cadre ou remplissages.

## **Ajouter une image intégrée**

Pour insérer une image locale, chargez le fichier, ajoutez‑le à la collection d'images et créez un picture frame qui utilise le `PPImage` retourné.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'image ajoutée de cette façon est intégrée à la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité continue du fichier image d'origine.

### **Ajouter une image depuis le Web**

Lorsqu'une image est disponible via HTTP ou HTTPS, téléchargez ses octets, ajoutez‑les à la collection d'images de la présentation et utilisez la ressource image retournée de la même manière qu'une image locale.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dans les applications de longue durée, réutilisez un client HTTP ou une stratégie de gestion des connexions adaptée à l'application plutôt que de créer à plusieurs reprises une infrastructure réseau inutile. Validez également les URL distantes, les tailles de réponse et les types de contenu lorsque la source n'est pas fiable.

## **Réutiliser les images sur plusieurs diapositives**

Si la même image est requise plusieurs fois, ajoutez‑la à la présentation une seule fois et réutilisez le [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) retourné lors de la création de cadres d'image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données sources et rend explicite la relation entre la ressource image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d'une entreprise, envisagez de placer le picture frame sur un [slide master](/slides/fr/php-java/slide-master/) ou une mise en page au lieu d'ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière‑plan de diapositive**

Une image d'arrière‑plan est affectée au remplissage de la diapositive ; elle n'est pas ajoutée comme forme picture‑frame. Cela est utile lorsque l'image doit couvrir l'arrière‑plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive normal.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour des options d'arrière‑plan supplémentaires, y compris les arrière‑plans de maître et de mise en page, voir [Presentation Background](/slides/fr/php-java/presentation-background/).

## **Images intégrées et images liées**

Les images intégrées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image intégrée :** les données de l'image sont stockées à l'intérieur de la présentation. La présentation est autonome, mais la taille du fichier inclut les données de l'image.
- **Image liée :** la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lorsque la présentation est ouverte ou rendue.

Une image liée peut être créée en affectant le chemin ou l'URL externe via [Picture::setLinkPathLong](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picture/) plutôt qu'en intégrant les données de l'image.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilisez les images liées uniquement lorsque l'environnement de déploiement peut accéder de manière fiable à la ressource externe. Pour les présentations qui doivent fonctionner hors ligne ou être déplacées entre systèmes, les images intégrées sont généralement plus sûres.

## **Travailler avec les images SVG**

SVG est un format vectoriel, il peut donc être utile pour les icônes, diagrammes et autres graphiques qui doivent être agrandis sans perte de détail comparable aux images raster. Aspose.Slides prend en charge les SVG à la fois comme ressource image et comme source de formes de diapositive modifiables.

### **Ajouter un SVG en tant qu'image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/), ajoutez‑le à la collection d'images et placez la ressource image résultante dans un picture frame.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Fichiers SVG avec ressources externes**

Un SVG peut référencer des images, feuilles de style ou polices externes. Dans ces cas, [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/) fournit des constructeurs qui acceptent un [ExternalResourceResolver](https://reference.aspose.com/slides/fr/php-java/aspose.slides/externalresourceresolver/) et une URI de base. Le résolveur peut mapper une URI relative à une URI absolue autorisée et renvoyer un flux pour la ressource demandée.

Le résolveur rend les ressources externes disponibles pendant que Aspose.Slides traite le SVG, mais il ne réécrit pas le SVG en un document autonome. Si le SVG doit rester portable, intégrez ses ressources requises directement dans le SVG, par exemple en utilisant des URI `data:` pour les images liées.

Lorsque les fichiers SVG proviennent de sources non fiables, limitez les schémas, emplacements de fichiers et hôtes que le résolveur peut accéder. Les résolveurs réseau doivent également appliquer des délais d'expiration, des limites de taille de réponse et une validation du contenu.

### **Convertir un SVG en formes modifiables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive modifiables, similaire à la commande correspondante de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilisez la surcharge [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addgroupshape/) qui accepte un [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/) pour réaliser la conversion.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilisez la conversion SVG‑vers‑formes lorsque des éléments vectoriels individuels doivent être modifiés en tant que formes PowerPoint. Si le SVG ne doit être qu'affiché, le conserver comme image est plus simple et évite de créer de nombreuses formes séparées.

## **Remplacer une ressource image existante**

Utilisez [PPImage::replaceImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) lorsque vous souhaitez remplacer une ressource image existante. Cela est particulièrement utile pour les graphiques partagés comme les logos.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si plusieurs picture frames, arrière‑plans, maîtres ou mises en page utilisent la même ressource image, le remplacement de cette ressource met à jour toutes ces utilisations. Si un seul picture frame doit être modifié, affectez une image différente à ce cadre plutôt que de remplacer la ressource partagée.

`PPImage::replaceImage` propose également des surcharges qui acceptent un tableau d'octets ou un autre [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/).

## **Conseils pratiques de gestion des images**

### **Contrôler la taille de la présentation**

Les grandes images raster peuvent rendre une présentation inutilement volumineuse. Utilisez des images sources dont les dimensions sont appropriées à la taille d'affichage prévue, réutilisez les ressources d'images partagées quand c'est possible et évitez d’intégrer plusieurs copies du même graphisme haute résolution.

Pour les images raster déjà placées dans des picture frames, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/) peut réduire les données d'image en fonction de la résolution et des paramètres de recadrage sélectionnés. Il s'agit d'un traitement de picture‑frame plutôt que d'une gestion de collection d'images, consultez donc [Picture Frame](/slides/fr/php-java/picture-frame/) pour les opérations de mise en forme associées.

### **Choisir entre contenu intégré et lié**

L’intégration rend la présentation portable car toutes les données d'image nécessaires voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais il introduit une dépendance externe. Utilisez les liens uniquement lorsque cette dépendance est acceptable et stable.

### **Réutiliser l’image de marque partagée**

Pour les logos, filigranes ou graphiques décoratifs répétés, utilisez une seule ressource d'image et réutilisez‑la. Si le graphique fait partie du design de la présentation plutôt que du contenu des diapositives, placez‑le sur un maître ou une mise en page afin qu'il soit hérité par les diapositives appropriées.

### **Maintenir les ressources SVG portables**

Un SVG autonome est plus facile à déplacer et à rendre de façon cohérente qu'un SVG dépendant de fichiers externes ou de ressources réseau. Lorsque c’est possible, intégrez les ressources requises avant d’importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être modifiés.

### **Utiliser l’API d’image moderne multiplateforme**

Pour le nouveau code PHP via Java, utilisez les API Aspose.Slides [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) et [Images](https://reference.aspose.com/slides/fr/php-java/aspose.slides/images/) plutôt que l'ancienne API publique basée sur `java.awt.image.BufferedImage`. Consultez [Modern API](/slides/fr/php-java/modern-api/) pour les conseils de migration.

WMF et EMF nécessitent une attention particulière. Lorsque ces formats sont transmis via un [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) convertit le métafichier en une représentation PNG raster avant l’insertion. Si la conservation des données du métafichier est importante, utilisez plutôt une surcharge basée sur un flux de [ImageCollection::addImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/). La génération de contenu EMF à partir de feuilles de calcul ou d’autres produits constitue un flux d’intégration distinct et dépasse le cadre de cet article.

## **FAQ**

**Quelle est la différence entre la collection d'images et un picture frame ?**

La collection d'images stocke des ressources image réutilisables. Un picture frame est une forme de diapositive qui affiche l'une de ces ressources et offre des options de mise en forme spécifiques à l'image, telles que le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**

Si le logo est déjà partagé en tant que ressource image unique, remplacez cette ressource avec [PPImage::replaceImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/). Pour une image de marque sur l’ensemble de la présentation, placer le logo sur un maître ou une mise en page peut également réduire le contenu dupliqué des diapositives.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**

Une image liée dépend de son fichier ou URL externe. Si cette ressource n'est pas accessible depuis l'autre ordinateur, l'image liée peut être indisponible. Intégrez l'image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être modifiée en tant que formes PowerPoint ?**

Oui. Convertissez le SVG avec [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addgroupshape/) ; le groupe résultant contient des formes de diapositive modifiables plutôt qu'une seule image SVG.

**Comment garder les présentations contenant de nombreuses images plus petites ?**

Réutilisez les ressources d'images partagées, évitez les sources raster inutilement grandes, compressez les images raster appropriées lorsque cela est pertinent, conservez les éléments de marque récurrents sur les maîtres ou les mises en page, et utilisez les images liées uniquement lorsqu'une dépendance externe est acceptable.