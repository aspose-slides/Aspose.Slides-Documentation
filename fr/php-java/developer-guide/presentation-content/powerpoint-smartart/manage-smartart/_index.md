---
title: Gérer SmartArt dans les présentations PowerPoint avec PHP
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/php-java/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour PHP via Java en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Aperçu**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une mise en page. Avec Aspose.Slides pour PHP via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur mise en page, inspecter les nœuds masqués, configurer les mises en page des organigrammes et créer des organigrammes illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [SmartArt::getAllNodes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartart/#getAllNodes), puis lisez le [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) renvoyé par [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Modifier le type de mise en page d'un objet SmartArt**

La mise en page SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartlayouttype/), la change en `BasicProcess`, puis enregistre la présentation.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartnode/ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme des éléments visibles du diagramme.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartlayouttype/), puis vérifie l'état masqué du nœud.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtenir ou définir la mise en page de l'organigramme**

Pour les diagrammes SmartArt qui utilisent une mise en page d'organigramme, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) et [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) définissent la façon dont les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez configurer les nœuds enfants pour qu'ils pendent à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/organizationchartlayouttype/) sélectionné.

L'exemple suivant crée un organigramme et définit la mise en page du premier nœud sur la valeur `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/organizationchartlayouttype/).

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Créer un organigramme illustré**

Un organigramme illustré est une mise en page SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d'images. Utilisez la valeur `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartlayouttype/) lors de l'ajout de l'objet SmartArt à une diapositive.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La méthode [SmartArt::setReversed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartart/setreversed/) inverse la direction du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/php-java/shape-manipulations/) avec [ShapeCollection::addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addclone/) ou [cloner la diapositive entière](/slides/fr/php-java/clone-slides/) qui contient le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image matricielle pour un aperçu ou une exportation web ?**

[Rendre la diapositive](/slides/fr/php-java/convert-powerpoint-to-png/) ou toute la présentation en PNG ou JPEG. Le SmartArt est rendu comme faisant partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape::getAlternativeText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getalternativetext/) ou [Shape::getName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getname/) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide::getShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getShapes), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartart/).