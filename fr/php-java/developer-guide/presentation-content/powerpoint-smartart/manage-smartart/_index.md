---
title: Gérer SmartArt dans les présentations PowerPoint avec PHP
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/php-java/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour PHP via Java en utilisant des exemples de code clairs qui accélèrent la conception et l'automatisation des diapositives."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides for PHP via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions des organigrammes et créer des organigrammes illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), puis lisez le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) retourné par [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

L'exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt en tant que première forme de cette diapositive. Il affiche chaque cadre de texte disponible dans la console.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Modifier le type de disposition d'un objet SmartArt**

La disposition SmartArt contrôle la façon dont les nœuds sont organisés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, la change en valeur `BasicProcess` et enregistre la présentation. La position et la taille passées à [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) sont exprimées en points. Utilisez [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) pour modifier la disposition.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` et vérifie l'état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtenir ou définir la disposition de l'organigramme**

Pour les diagrammes SmartArt utilisant une disposition d'organigramme, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) et [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) définissent la façon dont les nœuds enfants sont organisés sous un nœud parent. Par exemple, vous pouvez placer les nœuds enfants suspendus à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) sélectionné.

L'exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. L'index basé sur zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent la disposition sélectionnée. La présentation modifiée est ensuite enregistrée.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Créer un organigramme illustré**

Un organigramme illustré est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d'images. Utilisez la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` lors de l'ajout de l'objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d'images ; il ne remplit pas les espaces réservés avec des images.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Convertir les diagrammes hérités en groupes de formes**

Lors de la modernisation d’une présentation existante, il se peut que vous deviez mettre à jour un organigramme créé à l’origine dans PowerPoint 97‑2003. Aspose.Slides représente ces diagrammes hérités sous forme d’objets [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Utilisez [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) pour convertir un diagramme en groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l’original avec [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) afin d’éviter le contenu dupliqué. Rassemblez les diagrammes hérités dans une liste avant de les convertir, de sorte que l’ajout et la suppression de formes n’interrompent pas l’itération.

L'exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La présentation enregistrée contient des groupes de formes éditables à la place des diagrammes hérités convertis, sans diagrammes originaux restants à côté. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels de chaque groupe, tels que le texte, le remplissage ou la position.

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La méthode [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) change le sens du diagramme de gauche à droite vers droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/php-java/shape-manipulations/) avec [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) ou [cloner la diapositive entière](/slides/fr/php-java/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image raster pour l'aperçu ou l'exportation web ?**

[Rendre la diapositive](/slides/fr/php-java/convert-powerpoint-to-png/) ou toute la présentation en PNG ou JPEG. SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s'il y en a plusieurs ?**

Utilisez [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) ou [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) pour attribuer un texte alternatif ou un nom distinctif à la forme SmartArt, recherchez cette valeur dans [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).