---
title: Connecteur
type: docs
weight: 10
url: /net/connector/
keywords: "Connecter des formes, connecteurs, formes PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Connecter des formes PowerPoint en C# ou .NET"
---

Un connecteur PowerPoint est une ligne spéciale qui relie ou connecte deux formes ensemble et reste attachée aux formes même lorsqu'elles sont déplacées ou repositionnées sur une diapositive donnée.

Les connecteurs sont généralement connectés à des *points de connexion* (points verts), qui existent par défaut sur toutes les formes. Les points de connexion apparaissent lorsque le curseur s'en approche.

*Points d'ajustement* (points oranges), qui existent uniquement sur certains connecteurs, sont utilisés pour modifier les positions et les formes des connecteurs.

## **Types de Connecteurs**

Dans PowerPoint, vous pouvez utiliser des connecteurs droits, en coude (angulaires) et courbés.

Aspose.Slides fournit ces connecteurs :

| Connecteur                      | Image                                                        | Nombre de points d'ajustement |
| ------------------------------- | ------------------------------------------------------------ | ------------------------------ |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                              |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                              |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                              |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                              |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                              |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                              |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                              |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                              |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                              |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                              |

## **Connecter des Formes à l'Aide de Connecteurs**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) à la diapositive en utilisant la méthode `AddAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur en utilisant la méthode `AddConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes en utilisant le connecteur.
1. Appelez la méthode `Reroute` pour appliquer le chemin de connexion le plus court.
1. Enregistrez la présentation.

Ce code C# vous montre comment ajouter un connecteur (un connecteur courbé) entre deux formes (une ellipse et un rectangle) :

```c#
// Instancie une classe de présentation qui représente un fichier PPTX
using (Presentation input = new Presentation())
{                
    // Accède à la collection de formes pour une diapositive spécifique
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Ajoute une autoforme ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Ajoute une autoforme rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Ajoute une forme de connecteur à la collection de formes de la diapositive
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Connecte les formes en utilisant le connecteur
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Appelle reroute qui définit le chemin automatique le plus court entre les formes
    connector.Reroute();

    // Enregistre la présentation
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

La méthode `Connector.Reroute` redirige un connecteur et le force à prendre le chemin le plus court possible entre les formes. Pour atteindre cet objectif, la méthode peut changer les indices des points `StartShapeConnectionSiteIndex` et `EndShapeConnectionSiteIndex`.

{{% /alert %}} 

## **Spécifiez le Point de Connexion**
Si vous souhaitez qu'un connecteur relie deux formes en utilisant des points spécifiques sur les formes, vous devez spécifier vos points de connexion préférés de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) à la diapositive en utilisant la méthode `AddAutoShape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur en utilisant la méthode `AddConnector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes en utilisant le connecteur.
1. Définissez vos points de connexion préférés sur les formes.
1. Enregistrez la présentation.

Ce code C# démontre une opération où un point de connexion préféré est spécifié :

```c#
// Instancie une classe de présentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la collection de formes pour une diapositive spécifique
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Ajoute une forme de connecteur à la collection de formes de la diapositive
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Ajoute une autoforme ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Ajoute une autoforme rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Connecte les formes en utilisant le connecteur
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Définit l'indice du point de connexion préféré sur la forme Ellipse
    uint wantedIndex = 6;

    // Vérifie si l'indice préféré est inférieur au nombre maximum d'indices de site
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Définit le point de connexion préféré sur l'autoforme Ellipse
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Enregistre la présentation
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Ajuster le Point du Connecteur**

Vous pouvez ajuster un connecteur existant à travers ses points d'ajustement. Seuls les connecteurs ayant des points d'ajustement peuvent être modifiés de cette manière. Voir le tableau sous **[Types de connecteurs.](/slides/net/connector/#types-of-connectors)** 

#### **Cas Simple**

Considérons un cas où un connecteur entre deux formes (A et B) passe à travers une troisième forme (C) :

![connector-obstruction](connector-obstruction.png)

Code :

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Pour éviter ou contourner la troisième forme, nous pouvons ajuster le connecteur en déplaçant sa ligne verticale vers la gauche de cette manière :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Cas Complexes** 

Pour effectuer des ajustements plus compliqués, vous devez prendre en compte ces éléments :

* Le point ajustable d'un connecteur est étroitement lié à une formule qui calcule et détermine sa position. Ainsi, les changements à l'emplacement du point peuvent modifier la forme du connecteur.
* Les points d'ajustement d'un connecteur sont définis dans un ordre strict dans un tableau. Les points d'ajustement sont numérotés depuis le point de départ d'un connecteur jusqu'à son point d'arrivée.
* Les valeurs des points d'ajustement reflètent le pourcentage de la largeur/hauteur de la forme d'un connecteur. 
  * La forme est délimitée par les points de départ et d'arrivée du connecteur multipliés par 1000. 
  * Le premier point, le deuxième point et le troisième point définissent respectivement le pourcentage de la largeur, le pourcentage de la hauteur et le pourcentage de la largeur (à nouveau).
* Pour les calculs qui déterminent les coordonnées des points d'ajustement d'un connecteur, vous devez tenir compte de la rotation du connecteur et de sa réflexion. **Remarque** que l'angle de rotation pour tous les connecteurs montrés sous **[Types de connecteurs](/slides/net/connector/#types-of-connectors)** est de 0.

#### **Cas 1**

Considérons un cas où deux objets de cadre de texte sont reliés par un connecteur :

![connector-shape-complex](connector-shape-complex.png)

Code :

```c#
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
// Obtient la première diapositive de la présentation
ISlide sld = pres.Slides[0];
// Ajoute des formes qui seront jointes ensemble par un connecteur
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "De";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "À";
// Ajoute un connecteur
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Spécifie la direction du connecteur
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Spécifie la couleur du connecteur
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Spécifie l'épaisseur de la ligne du connecteur
connector.LineFormat.Width = 3;

// Lie les formes ensemble avec le connecteur
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Obtient les points d'ajustement pour le connecteur
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Ajustement**

Nous pouvons changer les valeurs des points d'ajustement du connecteur en augmentant le pourcentage de largeur et de hauteur correspondants de 20% et 200%, respectivement :

```c#
// Change les valeurs des points d'ajustement
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Le résultat :

![connector-adjusted-1](connector-adjusted-1.png)

Pour définir un modèle qui nous permet de déterminer les coordonnées et la forme des parties individuelles du connecteur, créons une forme qui correspond au composant horizontal du connecteur au point connector.Adjustments[0] :

```c#
// Dessine le composant vertical du connecteur

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Le résultat :

![connector-adjusted-2](connector-adjusted-2.png)

#### **Cas 2**

Dans **Cas 1**, nous avons démontré une opération d'ajustement de connecteur simple en utilisant des principes de base. Dans des situations normales, vous devez tenir compte de la rotation du connecteur et de son affichage (qui sont définis par les propriétés connector.Rotation, connector.Frame.FlipH et connector.Frame.FlipV). Nous allons maintenant démontrer le processus.

Tout d'abord, ajoutons un nouvel objet de cadre de texte (**À 1**) à la diapositive (à des fins de connexion) et créons un nouveau connecteur (vert) qui le relie aux objets que nous avons déjà créés.

```c#
// Crée un nouvel objet de liaison
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "À 1";
// Crée un nouveau connecteur
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Connecte les objets en utilisant le connecteur nouvellement créé
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Obtient les points d'ajustement du connecteur
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Change les valeurs des points d'ajustement 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Le résultat :

![connector-adjusted-3](connector-adjusted-3.png)

Deuxièmement, créons une forme qui correspond au composant horizontal du connecteur qui passe par le point d'ajustement connector.Adjustments[0] du nouveau connecteur. Nous utiliserons les valeurs des données du connecteur pour connector.Rotation, connector.Frame.FlipH et connector.Frame.FlipV et appliquerons la formule de conversion de coordonnées populaire pour une rotation autour d'un point donné x0 :

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dans notre cas, l'angle de rotation de l'objet est de 90 degrés et le connecteur est affiché verticalement, donc voici le code correspondant :

```c#
// Enregistre les coordonnées du connecteur
x = connector.X;
y = connector.Y;
// Corrige les coordonnées du connecteur au cas où elles apparaissent
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Prend la valeur du point d'ajustement comme coordonnée
x += connector.Width * adjValue_0.RawValue / 100000;
//  Convertit les coordonnées puisque Sin(90) = 1 et Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Détermine la largeur du composant horizontal en utilisant la valeur du deuxième point d'ajustement
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Le résultat :

![connector-adjusted-4](connector-adjusted-4.png)

Nous avons démontré des calculs impliquant des ajustements simples et des points d'ajustement compliqués (points d'ajustement avec angles de rotation). En utilisant les connaissances acquises, vous pouvez développer votre propre modèle (ou écrire un code) pour obtenir un objet `GraphicsPath` ou même définir les valeurs de point d'ajustement d'un connecteur en fonction de coordonnées de diapositive spécifiques.

## **Trouver l'Angle des Lignes de Connecteur**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Accédez à la forme de ligne de connecteur.
1. Utilisez la largeur de la ligne, la hauteur, la hauteur du cadre de la forme et la largeur du cadre de la forme pour calculer l'angle.

Ce code C# démontre une opération dans laquelle nous avons calculé l'angle d'une forme de ligne de connecteur :

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```