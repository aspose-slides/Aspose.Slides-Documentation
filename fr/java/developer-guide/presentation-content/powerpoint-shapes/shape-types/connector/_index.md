---
title: Gérer les connecteurs dans les présentations avec Java
linktitle: Connecteur
type: docs
weight: 10
url: /fr/java/connector/
keywords:
- connecteur
- type de connecteur
- point de connecteur
- ligne de connecteur
- angle de connecteur
- connecter des formes
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Permettez aux applications Java de dessiner, connecter et auto‑router les lignes dans les diapositives PowerPoint — obtenez un contrôle complet sur les connecteurs droits, coudés et courbes."
---

Un connecteur PowerPoint est une ligne spéciale qui relie deux formes et reste attachée aux formes même lorsqu'elles sont déplacées ou repositionnées sur une diapositive donnée.  

Les connecteurs sont généralement reliés à des *points de connexion* (points verts), qui existent par défaut sur toutes les formes. Les points de connexion apparaissent lorsqu'un curseur s'en approche.  

Les *points d'ajustement* (points orange), qui n'existent que sur certains connecteurs, sont utilisés pour modifier les positions et les formes des connecteurs.  

## **Types de connecteurs**

Dans PowerPoint, vous pouvez utiliser des connecteurs droits, coudés (angulaires) et courbes.  

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

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Obtenez une référence à une diapositive via son indice.  
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) à la diapositive en utilisant la méthode `addAutoShape` exposée par l'objet `Shapes`.  
1. Ajoutez un connecteur en utilisant la méthode `addConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.  
1. Connectez les formes à l'aide du connecteur.  
1. Appelez la méthode `reroute` pour appliquer le chemin de connexion le plus court.  
1. Enregistrez la présentation.  

Ce code Java vous montre comment ajouter un connecteur (un connecteur coudé) entre deux formes (une ellipse et un rectangle) :
```Java
// Instancie une classe de présentation qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la collection de formes pour une diapositive spécifique
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Ajoute une forme auto Ellipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Ajoute une forme auto Rectangle
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Ajoute une forme de connecteur à la collection de formes de la diapositive
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Connecte les formes en utilisant le connecteur
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Appelle reroute qui définit le chemin le plus court automatique entre les formes
    connector.reroute();
    
    // Enregistre la présentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
La méthode `Connector.reroute` redirige un connecteur et le force à emprunter le chemin le plus court possible entre les formes. Pour atteindre cet objectif, la méthode peut modifier les points `setStartShapeConnectionSiteIndex` et `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Spécifier un point de connexion**

Si vous souhaitez qu'un connecteur relie deux formes en utilisant des points spécifiques sur les formes, vous devez spécifier vos points de connexion préférés de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Obtenez une référence à une diapositive via son indice.  
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) à la diapositive en utilisant la méthode `addAutoShape` exposée par l'objet `Shapes`.  
1. Ajoutez un connecteur en utilisant la méthode `addConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.  
1. Connectez les formes à l'aide du connecteur.  
1. Définissez vos points de connexion préférés sur les formes.  
1. Enregistrez la présentation.  

```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la collection de formes pour une diapositive spécifique
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Ajoute une forme auto Ellipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Ajoute une forme auto Rectangle
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Ajoute une forme de connecteur à la collection de formes de la diapositive
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Connecte les formes à l'aide du connecteur
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Définit l'index du point de connexion préféré sur la forme Ellipse
    int wantedIndex = 6;

    // Vérifie si l'index préféré est inférieur au nombre maximal d'indices de sites de connexion
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Définit le point de connexion préféré sur la forme auto Ellipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Enregistre la présentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajuster un point de connecteur**

Vous pouvez ajuster un connecteur existant via ses points d'ajustement. Seuls les connecteurs possédant des points d'ajustement peuvent être modifiés de cette façon. Voir le tableau sous **[Types de connecteurs.](/slides/fr/java/connector/#types-of-connectors)**  

### **Cas simple**

Considérez un cas où un connecteur entre deux formes (A et B) passe par une troisième forme (C) :

![obstruction-connexion](connector-obstruction.png)
```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```


Pour éviter ou contourner la troisième forme, nous pouvons ajuster le connecteur en déplaçant sa ligne verticale vers la gauche de cette manière :

![obstruction-connexion-corrigée](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Cas complexes**

Pour effectuer des ajustements plus complexes, vous devez prendre en compte les éléments suivants :

* Le point ajustable d'un connecteur est fortement lié à une formule qui calcule et détermine sa position. Ainsi, les modifications de l'emplacement du point peuvent modifier la forme du connecteur.  
* Les points d'ajustement d'un connecteur sont définis dans un ordre strict dans un tableau. Les points d'ajustement sont numérotés du point de départ du connecteur jusqu'à son point final.  
* Les valeurs des points d'ajustement reflètent le pourcentage de la largeur/hauteur de la forme du connecteur.  
  * La forme est limitées par les points de départ et d'arrivée du connecteur multipliés par 1000.  
  * Le premier point, le deuxième point et le troisième point définissent respectivement le pourcentage de la largeur, le pourcentage de la hauteur et à nouveau le pourcentage de la largeur.  
* Pour les calculs déterminant les coordonnées des points d'ajustement d'un connecteur, vous devez prendre en compte la rotation du connecteur et son reflet. **Note** que l'angle de rotation pour tous les connecteurs présentés sous **[Types de connecteurs](/slides/fr/java/connector/#types-of-connectors)** est 0.  

#### **Cas 1**

Considérez un cas où deux objets de cadre de texte sont reliés entre eux via un connecteur :

![connecteur-forme-complexe](connector-shape-complex.png)
```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive de la présentation
    ISlide sld = pres.getSlides().get_Item(0);
    // Ajoute des formes qui seront reliées ensemble par un connecteur
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Ajoute un connecteur
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Spécifie la direction du connecteur
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Spécifie la couleur du connecteur
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Spécifie l'épaisseur de la ligne du connecteur
    connector.getLineFormat().setWidth(3);
    
    // Lie les formes ensemble avec le connecteur
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Obtient les points d'ajustement du connecteur
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**Ajustement**

Nous pouvons modifier les valeurs des points d'ajustement du connecteur en augmentant respectivement les pourcentages de largeur et de hauteur de 20 % et 200 % :

```java
// Modifie les valeurs des points d'ajustement
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Le résultat :

![connecteur-ajusté-1](connector-adjusted-1.png)

Pour définir un modèle qui nous permette de déterminer les coordonnées et la forme des différentes parties du connecteur, créons une forme qui corresponde à la composante horizontale du connecteur au point `connector.getAdjustments().get_Item(0)` :

```java
// Dessine la composante verticale du connecteur
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Le résultat :

![connecteur-ajusté-2](connector-adjusted-2.png)

#### **Cas 2**

Dans **Cas 1**, nous avons démontré une opération d'ajustement simple d'un connecteur en utilisant des principes de base. Dans des situations normales, vous devez prendre en compte la rotation du connecteur et son affichage (qui sont définis par `connector.getRotation()`, `connector.getFrame().getFlipH()` et `connector.getFrame().getFlipV()`). Nous allons maintenant démontrer le processus.  

Tout d'abord, ajoutons un nouvel objet de cadre de texte (**To 1**) à la diapositive (à des fins de connexion) et créons un nouveau connecteur (vert) qui le relie aux objets déjà créés.

```java
// Crée un nouvel objet de liaison
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Crée un nouveau connecteur
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Connecte les objets à l'aide du connecteur nouvellement créé
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

![connecteur-ajusté-3](connector-adjusted-3.png)

Ensuite, créons une forme qui correspondra à la composante horizontale du connecteur qui passe par le nouveau point d'ajustement du connecteur `connector.getAdjustments().get_Item(0)`. Nous utiliserons les valeurs des données du connecteur pour `connector.getRotation()`, `connector.getFrame().getFlipH()` et `connector.getFrame().getFlipV()` et appliquerons la formule de conversion de coordonnées couramment utilisée pour la rotation autour d'un point donné x0 :

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dans notre cas, l'angle de rotation de l'objet est de 90 degrés et le connecteur est affiché verticalement, voici le code correspondant :

```java
// Enregistre les coordonnées du connecteur
x = connector.getX();
y = connector.getY();
// Corrige les coordonnées du connecteur si nécessaire
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Utilise la valeur du point d'ajustement comme coordonnée
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
// Convertit les coordonnées puisque Sin(90) = 1 et Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Détermine la largeur de la composante horizontale en utilisant la valeur du second point d'ajustement
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


Le résultat :

![connecteur-ajusté-4](connector-adjusted-4.png)

Nous avons démontré des calculs impliquant des ajustements simples et des points d'ajustement complexes (points d'ajustement avec angles de rotation). En utilisant les connaissances acquises, vous pouvez développer votre propre modèle (ou écrire du code) pour obtenir un objet `GraphicsPath` ou même définir les valeurs des points d'ajustement d'un connecteur à partir de coordonnées spécifiques de la diapositive.  

## **Trouver l'angle des lignes de connecteur**

1. Créez une instance de la classe.  
1. Obtenez une référence à une diapositive via son indice.  
1. Accédez à la forme de la ligne du connecteur.  
1. Utilisez la largeur, la hauteur, la hauteur du cadre de forme et la largeur du cadre de forme pour calculer l'angle.  

Ce code Java démontre une opération dans laquelle nous avons calculé l'angle d'une forme de ligne de connecteur :

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**Comment savoir si un connecteur peut être « collé » à une forme spécifique ?**  
Vérifiez que la forme expose des [sites de connexion](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getConnectionSiteCount--). S'il n'y en a aucun ou si le nombre est zéro, le collage n'est pas disponible ; dans ce cas, utilisez des extrémités libres et positionnez‑les manuellement. Il est judicieux de vérifier le nombre de sites avant d'attacher.

**Que se passe-t‑il pour un connecteur si je supprime l’une des formes connectées ?**  
Ses extrémités seront détachées ; le connecteur reste sur la diapositive comme une ligne ordinaire avec un départ/arrivée libres. Vous pouvez soit le supprimer, soit réaffecter les connexions et, si nécessaire, [rerouter](https://reference.aspose.com/slides/java/com.aspose.slides/connector/#reroute--).

**Les liaisons de connecteur sont‑elles conservées lors de la copie d’une diapositive vers une autre présentation ?**  
En général, oui, à condition que les formes cibles soient également copiées. Si la diapositive est insérée dans un autre fichier sans les formes connectées, les extrémités deviennent libres et vous devrez les rattacher.