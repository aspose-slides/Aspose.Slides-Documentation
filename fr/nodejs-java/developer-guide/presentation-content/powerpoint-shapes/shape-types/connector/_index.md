---
title: Connecteur
type: docs
weight: 10
url: /fr/nodejs-java/connector/
keywords: "Connecter des formes, connecteurs, formes PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Connecter des formes PowerPoint en JavaScript"
---

Un connecteur PowerPoint est une ligne spéciale qui relie deux formes et reste attaché aux formes même lorsqu'elles sont déplacées ou repositionnées sur une diapositive donnée. 

Les connecteurs sont généralement reliés à des *points de connexion* (points verts), qui existent par défaut sur toutes les formes. Les points de connexion apparaissent lorsqu'un curseur s'en approchent.

*Les points d'ajustement* (points orange), qui n'existent que sur certains connecteurs, servent à modifier les positions et les formes des connecteurs.

## **Types de connecteurs**

Dans PowerPoint, vous pouvez utiliser des connecteurs droits, coudés (angiés) et courbes. 

Aspose.Slides fournit ces connecteurs :

| Connecteur                      | Image                                                        | Nombre de points d'ajustement |
| ------------------------------ | ------------------------------------------------------------ | ----------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Connecter des formes à l'aide de connecteurs**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) à la diapositive en utilisant la méthode `addAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur à l'aide de la méthode `addConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes à l'aide du connecteur. 
1. Appelez la méthode `reroute` pour appliquer le chemin de connexion le plus court.
1. Enregistrez la présentation. 

Ce code JavaScript vous montre comment ajouter un connecteur (un connecteur coudé) entre deux formes (une ellipse et un rectangle) :
```javascript
// Instancie une classe de présentation qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la collection de formes pour une diapositive spécifique
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Ajoute une forme auto Ellipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Ajoute une forme auto Rectangle
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Ajoute une forme de connecteur à la collection de formes de la diapositive
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Connecte les formes en utilisant le connecteur
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Appelle reroute qui définit le chemin le plus court automatique entre les formes
    connector.reroute();
    // Enregistre la présentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
La méthode `Connector.reroute` redirige un connecteur et le force à prendre le chemin le plus court possible entre les formes. Pour atteindre cet objectif, la méthode peut modifier les points `setStartShapeConnectionSiteIndex` et `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Spécifier le point de connexion**

Si vous voulez qu'un connecteur relie deux formes en utilisant des points spécifiques sur les formes, vous devez spécifier vos points de connexion préférés de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) à la diapositive en utilisant la méthode `addAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur à l'aide de la méthode `addConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes à l'aide du connecteur. 
1. Définissez vos points de connexion préférés sur les formes. 
1. Enregistrez la présentation.

Ce code JavaScript montre une opération où un point de connexion préféré est spécifié :
```javascript
// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la collection de formes pour une diapositive spécifique
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Ajoute une forme auto Ellipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Ajoute une forme auto Rectangle
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Ajoute une forme de connecteur à la collection de formes de la diapositive
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Connecte les formes en utilisant le connecteur
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Définit l'index du point de connexion préféré sur la forme Ellipse
    var wantedIndex = 6;
    // Vérifie si l'index préféré est inférieur au nombre maximal de sites
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Définit le point de connexion préféré sur la forme auto Ellipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Enregistre la présentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajuster le point du connecteur**

Vous pouvez ajuster un connecteur existant via ses points d'ajustement. Seuls les connecteurs disposant de points d'ajustement peuvent être modifiés de cette manière. Consultez le tableau sous **[Types de connecteurs.](/slides/fr/nodejs-java/connector/#types-of-connectors)**

### **Cas simple**

Considérez un cas où un connecteur entre deux formes (A et B) passe à travers une troisième forme (C) :
![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Pour éviter ou contourner la troisième forme, nous pouvons ajuster le connecteur en déplaçant sa ligne verticale vers la gauche de cette façon :
![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Cas complexes** 

Pour effectuer des ajustements plus complexes, vous devez prendre ces éléments en compte :

* Le point ajustable d'un connecteur est fortement lié à une formule qui calcule et détermine sa position. Ainsi, les modifications de la position du point peuvent changer la forme du connecteur.
* Les points d'ajustement d'un connecteur sont définis dans un ordre strict dans un tableau. Les points d'ajustement sont numérotés du point de départ du connecteur jusqu'à son point d'arrivée.
* Les valeurs des points d'ajustement reflètent le pourcentage de la largeur/hauteur de la forme du connecteur. 
  - La forme est délimitée par les points de départ et d'arrivée du connecteur multipliés par 1000. 
  - Le premier point, le deuxième point et le troisième point définissent respectivement le pourcentage de la largeur, le pourcentage de la hauteur et à nouveau le pourcentage de la largeur.
* Pour les calculs déterminant les coordonnées des points d'ajustement d'un connecteur, vous devez prendre en compte la rotation du connecteur et son reflet. **Note** que l'angle de rotation de tous les connecteurs affichés sous **[Types de connecteurs](/slides/fr/nodejs-java/connector/#types-of-connectors)** est 0.

#### **Cas 1**

Considérez un cas où deux objets de cadre de texte sont reliés entre eux par un connecteur :
![connector-shape-complex](connector-shape-complex.png)
```javascript
// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive de la présentation
    var sld = pres.getSlides().get_Item(0);
    // Ajoute des formes qui seront reliées ensemble via un connecteur
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Ajoute un connecteur
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Spécifie la direction du connecteur
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Spécifie la couleur du connecteur
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Spécifie l'épaisseur de la ligne du connecteur
    connector.getLineFormat().setWidth(3);
    // Lie les formes ensemble avec le connecteur
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Obtient les points d'ajustement du connecteur
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Ajustement**

Nous pouvons modifier les valeurs des points d'ajustement du connecteur en augmentant respectivement le pourcentage de largeur et de hauteur de 20 % et 200 % :
```javascript
// Modifie les valeurs des points d'ajustement
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Le résultat :

![connector-adjusted-1](connector-adjusted-1.png)

Pour définir un modèle qui nous permette de déterminer les coordonnées et la forme des différentes parties du connecteur, créons une forme qui correspond à la composante horizontale du connecteur au point connector.getAdjustments().get_Item(0) :
```javascript
// Dessine la composante verticale du connecteur
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


Le résultat :

![connector-adjusted-2](connector-adjusted-2.png)

#### **Cas 2**

Dans **Cas 1**, nous avons démontré une opération simple d'ajustement de connecteur en utilisant des principes de base. Dans des situations normales, vous devez prendre en compte la rotation du connecteur et son affichage (qui sont définis par connector.getRotation(), connector.getFrame().getFlipH() et connector.getFrame().getFlipV()). Nous allons maintenant démontrer le processus.

Tout d'abord, ajoutons un nouvel objet de cadre de texte (**To 1**) à la diapositive (à des fins de connexion) et créons un nouveau connecteur (vert) qui le relie aux objets déjà créés.
```javascript
// Crée un nouvel objet de liaison
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Crée un nouveau connecteur
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Connecte les objets en utilisant le connecteur nouvellement créé
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Obtient les points d'ajustement du connecteur
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Modifie les valeurs des points d'ajustement
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Le résultat :

![connector-adjusted-3](connector-adjusted-3.png)

Ensuite, créons une forme qui correspondra à la composante horizontale du connecteur qui passe par le nouveau point d'ajustement du connecteur connector.getAdjustments().get_Item(0). Nous utiliserons les valeurs provenant des données du connecteur pour connector.getRotation(), connector.getFrame().getFlipH() et connector.getFrame().getFlipV() et appliquerons la formule de conversion de coordonnées couramment utilisée pour la rotation autour d'un point x0 :

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dans notre cas, l'angle de rotation de l'objet est de 90 degrés et le connecteur est affiché verticalement, donc voici le code correspondant :
```javascript
// Enregistre les coordonnées du connecteur
x = connector.getX();
y = connector.getY();
// Corrige les coordonnées du connecteur au besoin
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Utilise la valeur du point d'ajustement comme coordonnée
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Convertit les coordonnées puisque Sin(90) = 1 et Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Détermine la largeur de la composante horizontale en utilisant la valeur du second point d'ajustement
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


Le résultat :

![connector-adjusted-4](connector-adjusted-4.png)

Nous avons démontré des calculs impliquant des ajustements simples et des points d'ajustement complexes (points d'ajustement avec angles de rotation). Grâce aux connaissances acquises, vous pouvez développer votre propre modèle (ou écrire un code) pour obtenir un objet `GraphicsPath` ou même définir les valeurs des points d'ajustement d'un connecteur en fonction de coordonnées de diapositive spécifiques.

## **Trouver l'angle des lignes de connecteur**

1. Créez une instance de la classe.
1. Obtenez une référence à la diapositive via son index.
1. Accédez à la forme de ligne du connecteur.
1. Utilisez la largeur, la hauteur, la hauteur du cadre de forme et la largeur du cadre de forme pour calculer l'angle.

Ce code JavaScript montre une opération dans laquelle nous avons calculé l'angle d'une forme de ligne de connecteur :
```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**Comment savoir si un connecteur peut être « collé » à une forme spécifique ?**

Vérifiez que la forme expose des [sites de connexion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/). S'il n'y en a aucun ou si le nombre est zéro, le collage n'est pas disponible ; dans ce cas, utilisez des extrémités libres et positionnez‑les manuellement. Il est judicieux de vérifier le nombre de sites avant de les attacher.

**Que se passe-t-il pour un connecteur si je supprime l'une des formes connectées ?**

Ses extrémités seront détachées ; le connecteur reste sur la diapositive comme une ligne ordinaire avec un début/fin libres. Vous pouvez le supprimer ou réattribuer les connexions et, si nécessaire, [reroute](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/).

**Les liaisons des connecteurs sont‑elles préservées lors de la copie d’une diapositive vers une autre présentation ?**

En général oui, à condition que les formes cibles soient également copiées. Si la diapositive est insérée dans un autre fichier sans les formes connectées, les extrémités deviennent libres et vous devrez les rattacher.