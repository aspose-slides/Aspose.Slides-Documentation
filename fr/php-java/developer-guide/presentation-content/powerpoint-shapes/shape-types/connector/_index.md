---
title: Connecteur
type: docs
weight: 10
url: /fr/php-java/connector/
keywords: "Connecter des formes, connecteurs, formes PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Connecter des formes PowerPoint"
---

Un connecteur PowerPoint est une ligne spéciale qui connecte ou relie deux formes ensemble et reste attachée aux formes même lorsqu'elles sont déplacées ou repositionnées sur une diapositive donnée.

Les connecteurs sont généralement connectés à des *points de connexion* (points verts), qui existent par défaut sur toutes les formes. Les points de connexion apparaissent lorsqu'un curseur s'en approche.

Les *points d'ajustement* (points oranges), qui existent uniquement sur certains connecteurs, sont utilisés pour modifier les positions et les formes des connecteurs.

## **Types de connecteurs**

Dans PowerPoint, vous pouvez utiliser des connecteurs droits, en coude (angulaires) et courbés.

Aspose.Slides fournit ces connecteurs :

| Connecteur                      | Image                                                        | Nombre de points d'ajustement |
| ------------------------------ | ------------------------------------------------------------ | ----------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                             |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                             |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                             |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                             |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                             |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                             |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                             |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                             |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                             |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                             |

## **Connecter des formes à l'aide de connecteurs**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) à la diapositive à l'aide de la méthode `addAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur à l'aide de la méthode `addConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes à l'aide du connecteur.
1. Appelez la méthode `reroute` pour appliquer le chemin de connexion le plus court.
1. Enregistrez la présentation.

Ce code PHP vous montre comment ajouter un connecteur (un connecteur en coude) entre deux formes (une ellipse et un rectangle) :

```php
// Instancie une classe de présentation qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la collection de formes pour une diapositive spécifique
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Ajoute une forme auto ellipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Ajoute une forme auto rectangle
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Ajoute une forme de connecteur à la collection de formes de la diapositive
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Connecte les formes à l'aide du connecteur
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Appelle reroute qui fixe le chemin automatique le plus court entre les formes
    $connector->reroute();
    # Enregistre la présentation
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="REMARQUE"  color="warning"   %}} 

La méthode `Connector.reroute` réachemine un connecteur et l'oblige à prendre le chemin le plus court possible entre les formes. Pour atteindre cet objectif, la méthode peut modifier les points `setStartShapeConnectionSiteIndex` et `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Spécifier le point de connexion**

Si vous souhaitez qu'un connecteur relie deux formes à l'aide de points spécifiques sur les formes, vous devez spécifier vos points de connexion préférés comme ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) à la diapositive à l'aide de la méthode `addAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur à l'aide de la méthode `addConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes à l'aide du connecteur.
1. Définissez vos points de connexion préférés sur les formes.
1. Enregistrez la présentation.

Ce code PHP illustre une opération où un point de connexion préféré est spécifié :

```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la collection de formes pour une diapositive spécifique
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Ajoute une forme auto ellipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Ajoute une forme auto rectangle
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Ajoute une forme de connecteur à la collection de formes de la diapositive
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Connecte les formes à l'aide du connecteur
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Définit l'index du point de connexion préféré sur la forme Ellipse
    $wantedIndex = 6;
    # Vérifie si l'index préféré est inférieur au compte maximum d'index de site
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Définit le point de connexion préféré sur la forme auto ellipse
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Enregistre la présentation
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajuster un point de connecteur**

Vous pouvez ajuster un connecteur existant à travers ses points d'ajustement. Seuls les connecteurs avec des points d'ajustement peuvent être modifiés de cette manière. Voir le tableau sous **[Types de connecteurs](/slides/fr/php-java/connector/#types-of-connectors)**

#### **Cas simple**

Considérons un cas où un connecteur entre deux formes (A et B) passe par une troisième forme (C) :

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Pour éviter ou contourner la troisième forme, nous pouvons ajuster le connecteur en déplaçant sa ligne verticale vers la gauche de cette manière :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Cas complexes** 

Pour effectuer des ajustements plus compliqués, vous devez prendre en compte ces éléments :

* Un point ajustable d'un connecteur est fortement lié à une formule qui calcule et détermine sa position. Donc, les changements de l'emplacement du point peuvent modifier la forme du connecteur.
* Les points d'ajustement d'un connecteur sont définis dans un ordre strict dans un tableau. Les points d'ajustement sont numérotés depuis le point de départ d'un connecteur jusqu'à son extrémité.
* Les valeurs des points d'ajustement reflètent le pourcentage de la largeur/hauteur d'une forme de connecteur. 
  * La forme est limitée par les points de départ et d'arrivée du connecteur multipliés par 1000. 
  * Le premier point, le deuxième point, et le troisième point définissent respectivement le pourcentage de la largeur, le pourcentage de la hauteur, et le pourcentage de la largeur (à nouveau).
* Pour les calculs qui déterminent les coordonnées des points d'ajustement d'un connecteur, vous devez prendre en compte la rotation du connecteur et sa réflexion. **Remarque** : l'angle de rotation pour tous les connecteurs affichés sous **[Types de connecteurs](/slides/fr/php-java/connector/#types-of-connectors)** est 0.

#### **Cas 1**

Considérons un cas où deux objets cadre de texte sont liés ensemble par un connecteur :

![connector-shape-complex](connector-shape-complex.png)

```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive de la présentation
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute des formes qui seront jointes ensemble par un connecteur
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("Depuis");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("Vers");
    # Ajoute un connecteur
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Spécifie la direction du connecteur
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Spécifie la couleur du connecteur
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Spécifie l'épaisseur de la ligne du connecteur
    $connector->getLineFormat()->setWidth(3);
    # Lie les formes ensemble avec le connecteur
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Obtient les points d'ajustement du connecteur
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Ajustement**

Nous pouvons changer les valeurs des points d'ajustement du connecteur en augmentant respectivement le pourcentage de largeur et de hauteur de 20% et 200% :

```php
  # Change les valeurs des points d'ajustement
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Le résultat :

![connector-adjusted-1](connector-adjusted-1.png)

Pour définir un modèle qui nous permet de déterminer les coordonnées et la forme des parties individuelles du connecteur, créons une forme qui correspond au composant horizontal du connecteur au point connector.getAdjustments().get_Item(0) :

```php
  # Dessine le composant vertical du connecteur
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);

```

Le résultat :

![connector-adjusted-2](connector-adjusted-2.png)

#### **Cas 2**

Dans **Cas 1**, nous avons démontré une opération d'ajustement de connecteur simple utilisant des principes de base. Dans des situations normales, vous devez prendre en compte la rotation du connecteur et son affichage (qui sont définis par connector.getRotation(), connector.getFrame().getFlipH(), et connector.getFrame().getFlipV()). Nous allons maintenant démontrer le processus.

Tout d'abord, ajoutons un nouvel objet cadre de texte (**Vers 1**) à la diapositive (à des fins de connexion) et créons un nouveau connecteur (vert) qui le connecte aux objets que nous avons déjà créés.

```php
  # Crée un nouvel objet de liaison
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("Vers 1");
  # Crée un nouveau connecteur
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Connecte les objets à l'aide du connecteur nouvellement créé
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Obtient les points d'ajustement du connecteur
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Change les valeurs des points d'ajustement
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Le résultat :

![connector-adjusted-3](connector-adjusted-3.png)

Deuxièmement, créons une forme qui correspond au composant horizontal du connecteur qui passe par le point d'ajustement du nouveau connecteur connector.getAdjustments().get_Item(0). Nous utiliserons les valeurs des données du connecteur pour connector.getRotation(), connector.getFrame().getFlipH(), et connector.getFrame().getFlipV() et appliquerons la formule de conversion de coordonnées populaire pour la rotation autour d'un point donné x0 :

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dans notre cas, l'angle de rotation de l'objet est de 90 degrés et le connecteur est affiché verticalement, donc voici le code correspondant :

```php
  # Enregistre les coordonnées du connecteur
  $x = $connector->getX();
  $y = $connector->getY();
  # Corrige les coordonnées du connecteur en cas d'apparence
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Prends la valeur du point d'ajustement comme coordonnée
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Convertit les coordonnées puisque Sin(90) = 1 et Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Détermine la largeur du composant horizontal en utilisant la valeur du deuxième point d'ajustement
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

```

Le résultat :

![connector-adjusted-4](connector-adjusted-4.png)

Nous avons démontré des calculs impliquant des ajustements simples et des points d'ajustement compliqués (points d'ajustement avec des angles de rotation). En utilisant les connaissances acquises, vous pouvez développer votre propre modèle (ou écrire un code) pour obtenir un objet `GraphicsPath` ou même définir les valeurs des points d'ajustement d'un connecteur en fonction des coordonnées spécifiques de la diapositive.

## **Trouver l'angle des lignes de connecteur**

1. Créez une instance de la classe.
1. Obtenez la référence d'une diapositive par son index.
1. Accédez à la forme de ligne de connecteur.
1. Utilisez la largeur de la ligne, la hauteur, la hauteur du cadre de la forme et la largeur du cadre de la forme pour calculer l'angle.

Ce code PHP démontre une opération dans laquelle nous avons calculé l'angle pour une forme de ligne de connecteur :

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```