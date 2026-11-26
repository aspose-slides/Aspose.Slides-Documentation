---
title: Personnaliser les formes de présentation sur Android
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/androidjava/custom-shape/
keywords:
- forme personnalisée
- ajouter forme
- créer forme
- modifier forme
- géométrie de forme
- chemin géométrique
- points du chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour Android via Java : chemins géométriques, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes via les points d'édition et les chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) et [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) pour modifier des formes existantes, effectuer des opérations de base d'édition de chemin, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins arrondis, déterminer si la géométrie d'une forme est fermée, et inspecter les éléments de forme à l'aide de tableaux de points Android.

## **Modifier une forme à l'aide de points d'édition**

* Déplacer un coin vers l'intérieur ou vers l'extérieur.
* Ajuster la courbure à un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d’une forme ou d’utiliser une forme existante comme base pour une nouvelle.

## **Conseils pour l'édition de formes**

![image_apercu](custom_shape_0.png)

Lors de l'édition de formes PowerPoint, gardez ces concepts à l'esprit :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Le chemin d'une forme est composé de points d'ancrage reliés par des segments.
* Un segment peut être droit ou courbe. Les points d'ancrage et les poignées de contrôle déterminent sa forme.
* Les points d'ancrage existent sous forme de points d'angle, points droits ou points lisses :
  * À un point d'angle, les segments adjacents peuvent se rencontrer à un angle.
  * À un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d'ancrage.
  * À un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d'ancrage.
* Déplacer les points d'ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour modifier les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) et l'interface [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) représente un chemin géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) depuis l'instance [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), vous pouvez utiliser la méthode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) d’une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) pour les formes à chemin unique et [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) pour les formes à chemins multiples.
* Pour ajouter des segments, utilisez les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* En utilisant les méthodes [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) et [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), vous pouvez définir l’apparence d’un chemin géométrique.
* En utilisant la méthode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--), vous pouvez récupérer le chemin géométrique d’un [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.

## **Opérations d'édition simples**

Utilisez les méthodes suivantes pour éditer un chemin géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position zéro‑basée dans le tableau de segments du chemin.

| Opération | Méthode |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Ajouter ou insérer une courbe Bézier cubique avec deux points de contrôle et un point final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Ajouter ou insérer une courbe Bézier quadratique avec un point de contrôle et un point final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Fermer la figure actuelle en reliant son point final à son point de départ. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Définir le point de départ d'une figure. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Supprimer un segment à un indice zéro‑basé. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire à l’aide de [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) et applique le chemin édité avec [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Les coordonnées sont locales à la forme : les deux nouveaux points se trouvent au centre, à 100 points du bord gauche et à 50 points du bord supérieur. Les indices de segments 1 et 4 les placent respectivement sur les arêtes supérieures et inférieures, tirant ces arêtes vers l’intérieur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![image_exemple1](custom_shape_1.png)

## **Supprimer des points d'une forme**

Cet exemple modifie le contour d’une forme en cœur en supprimant le segment à l’indice zéro‑basé 2 avec [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Appliquer le chemin modifié avec [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) met à jour le contour de la forme.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![image_exemple2](custom_shape_2.png)

## **Créer une forme personnalisée**

Cet exemple construit une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent respectivement les pointes et les encoches ; un pas de 72 degrés espace uniformément les cinq pointes. Le chemin est fermé avec [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) et appliqué à une forme rectangulaire à l’aide de [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), remplaçant son contour.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![image_exemple3](custom_shape_3.png)

## **Créer une forme personnalisée composite**

Cet exemple définit deux objets [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) fermés pour le tiers supérieur et le tiers inférieur d’une forme. Appliquer les deux chemins avec [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) crée une forme composite unique avec un espace au milieu du tiers central.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![image_exemple4](custom_shape_4.png)

## **Créer une forme personnalisée avec des coins arrondis**

Cet exemple combine des segments droits avec [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) pour créer une forme dont les coins sont incurvés vers l’intérieur. Chaque taille de coin définit la largeur et la hauteur de l’arc en points, et le balayage de –90 degrés trace un quart d’ellipse dans le sens antihoraire. Le chemin complet est appliqué avec [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), puis la présentation est enregistrée au format PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Déterminer si la géométrie d'une forme est fermée**

L’assistant suivant vérifie si chaque chemin géométrique non vide se termine par un segment de fermeture. Il lit [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) et compare la commande du segment final [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) avec [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Il renvoie false lorsqu’il n’y a aucun chemin non vide. Cette vérification porte sur la commande finale de chaque chemin ; elle n’inspecte pas chaque sous‑figure d’un chemin. L’exemple affiche `true` pour un rectangle.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Inspecter les commandes du chemin géométrique**

Téléchargez [contour.pptx](contour.pptx) et remplacez le nom de fichier d’exemple par son chemin sur l’appareil. La première forme de la première diapositive possède un bord supérieur droit, une courbe cubic Bézier et un bord de fermeture droit. Utilisez [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) pour lire les chemins de la forme et [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) pour lire les segments de chaque chemin dans l’ordre de dessin. Pour chaque segment, [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) identifie la commande et détermine comment interpréter les valeurs renvoyées par [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

La forme se trouve aux coordonnées (200, 100) points sur la diapositive. Les coordonnées rapportées sont locales à la forme, avec (0, 0) à son coin supérieur gauche, x augmentant vers la droite et y augmentant vers le bas. Le segment de fermeture revient au point de départ sans coordonnées supplémentaires.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Forme PowerPoint avec un bord supérieur droit, un bord courbe du coin supérieur droit au coin inférieur gauche, et un bord gauche droit](contour.png)

## **Extraire et inspecter les éléments de forme**

Utilisez [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) pour inspecter une forme existante en tant qu’éléments contenant des points de chemin et des types de points. Convertissez chaque [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) retourné en [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) afin de récupérer les tableaux de points et de types via les méthodes [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) et [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--). Cette représentation est utile pour l’analyse de contours ou le passage de la géométrie à des outils de dessin personnalisés.

L’exemple ouvre input.pptx, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et courbes pour voir les deux types de sortie. Il ne recherche pas à l’intérieur des groupes.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Conserver le type de segment, en excluant les indicateurs.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Les tableaux correspondent par index : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment Bézier cubique démarre au point final précédent et utilise trois entrées de type `3` consécutives : deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie le point final pour la fermeture.

Les types de points contiennent également des indicateurs. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous‑chemin, et `131` (`0x83`) signifie un point final de Bézier qui en ferme un. Java stocke ces indicateurs dans des octets signés ; le masquage préserve les valeurs de bits attendues. Comparer la valeur brute uniquement avec `1` ou `3` manquerait ces cas. D’autres indicateurs, comme le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), avec X augmentant vers la droite et Y augmentant vers le bas. Pour une forme non groupée, les coordonnées extraites incluent déjà la position retournée par [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) et [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné situé à `(100, 200)` avec une taille de `120 × 80` possède des limites de contour `(100, 200)`–`(220, 280)`. N’ajoutez pas de nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n’appliquent pas la rotation de la forme, retournée par [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), ni les retournements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne partez pas du principe que les points extraits sont les coordonnées finales rendues sur la diapositive, ni d’appliquer une translation ou une mise à l’échelle deux fois si elle est déjà reflétée dans le cadre de l’enfant.

**Inspection versus édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin nécessite des tableaux point/type. Utilisez [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) lorsque vous avez besoin des commandes géométriques dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les chemins modifiés via [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ou [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Que se passera-t-il pour le remplissage et le contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre à la forme.

**Puis-je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la [diapositive](/slides/fr/androidjava/convert-powerpoint-to-png/) ou la [forme](/slides/fr/androidjava/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.