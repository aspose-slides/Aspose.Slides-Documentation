---
title: Personnaliser les formes de présentation en JavaScript
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec JavaScript et Aspose.Slides pour Node.js : chemins géométriques, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie d’une forme à l’aide de points d’édition et de chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) pour modifier des formes existantes, effectuer des opérations d’édition de chemin de base, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins arrondis, déterminer si une géométrie de forme est fermée, inspecter les éléments de forme, et convertir les contours de texte Java AWT en chemins géométriques.

## **Modifier une forme à l'aide des points d'édition**

Dans PowerPoint, vous pouvez utiliser **Edit Points** pour modifier un carré :

* Déplacer un coin vers l’intérieur ou l’extérieur.
* Ajuster la courbure d’un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d’une forme ou d’utiliser une forme existante comme base pour une nouvelle.

## **Conseils de modification des formes**

![overview_image](custom_shape_0.png)

Lorsque vous modifiez des formes PowerPoint, gardez à l’esprit les concepts suivants :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Le chemin d’une forme se compose de points d’ancrage reliés par des segments.
* Un segment peut être droit ou courbé. Les points d’ancrage et les poignées de contrôle déterminent sa forme.
* Les points d’ancrage existent sous forme de points de coin, points droits ou points lisses :
  * Au point de coin, les segments adjacents peuvent se rencontrer sous un angle.
  * Au point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d’ancrage.
  * Au point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d’ancrage.
* Déplacer les points d’ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour éditer les formes PowerPoint via les points d’édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) représente le chemin géométrique de l’objet [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) à partir d’une instance de [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), utilisez la méthode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) d’une forme, utilisez ces méthodes : [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) pour les formes à chemin unique et [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) pour les formes à plusieurs chemins.
* Pour ajouter des segments, utilisez les méthodes sous [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* En utilisant les méthodes [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) et [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), vous pouvez définir l’apparence d’un chemin géométrique.
* En utilisant la méthode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), vous pouvez récupérer le chemin géométrique d’un [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.
* Pour accéder à des options supplémentaires de personnalisation de la géométrie d’une forme, vous pouvez lire un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) et rejouer les segments sur un [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Opérations d’édition simples**

Utilisez les méthodes suivantes pour modifier un chemin géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position basée sur zéro dans le tableau de segments du chemin.

| Opération | Méthode |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Ajouter ou insérer une courbe de Bézier cubique avec deux points de contrôle et un point final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Ajouter ou insérer une courbe de Bézier quadratique avec un point de contrôle et un point final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Ajouter un arc elliptique avec les dimensions et les angles spécifiés en degrés. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Fermer la figure actuelle en reliant son point final à son point de départ. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Définir le point de départ d’une figure. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Supprimer un segment à un indice basé sur zéro. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire en utilisant [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) et applique le chemin édité avec [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Les coordonnées sont locales à la forme : les deux nouveaux points sont à son centre, à 100 points du bord gauche et à 50 points du bord supérieur. Les indices de segment 1 et 4 les placent respectivement sur les bords supérieurs et inférieurs, tirant ces bords vers l’intérieur.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Supprimer des points d’une forme**

Cet exemple modifie le contour d’une forme en cœur en supprimant le segment à l’indice zéro‑based 2 avec [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). L’application du chemin modifié avec [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) met à jour le contour de la forme.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

Cet exemple construit une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les encoches ; un pas de 72 degrés espace les cinq pointes de manière uniforme. Le chemin est fermé avec [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) et appliqué à une forme rectangulaire à l’aide de [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), remplaçant son contour.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Créer une forme composite personnalisée**

Cet exemple définit deux [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) fermés pour le tiers supérieur et le tiers inférieur d’une forme. L’application des deux chemins avec [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) crée une forme composite unique avec un espace au tiers central.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec des coins arrondis**

Cet exemple combine des segments droits avec [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) pour créer une forme aux coins courbés vers l’intérieur. Chaque taille de coin définit la largeur et la hauteur de l’arc en points, et le balayage de –90 degrés trace un quart d’ellipse dans le sens antihoraire. Le chemin complet est appliqué avec [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), puis la présentation est enregistrée au format PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Déterminer si une géométrie de forme est fermée**

L’assistant suivant vérifie si chaque chemin géométrique non vide se termine par un segment de fermeture. Il lit [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) et compare la commande du segment final via [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) avec [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Il renvoie false lorsqu’il n’existe aucun chemin non vide. Cette vérification porte sur la commande finale de chaque chemin ; elle n’inspecte pas chaque sous‑figure à l’intérieur d’un chemin. L’exemple affiche `true` pour un rectangle.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Extraire et inspecter les éléments d’une forme**

Utilisez [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) pour inspecter une forme existante sous forme d’éléments contenant les points de chemin et leurs types. Utilisez chaque [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) renvoyé pour récupérer les tableaux de points et de types via les méthodes [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) et [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Cette représentation est utile pour l’analyse de contours ou le passage de la géométrie à des outils de dessin personnalisés.

L’exemple ouvre input.pptx, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et courbés pour voir les deux types de sortie. Il ne recherche pas à l’intérieur des groupes.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Conserver le type de segment, en excluant les indicateurs.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Les tableaux sont corrélés par indice : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment de Bézier cubique démarre au point final précédent et utilise trois entrées de type `3` consécutives : deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie le point final pour la fermeture.

Les types de points contiennent également des indicateurs. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous‑chemin, et `131` (`0x83`) signifie un point final de Bézier qui en ferme un. Java stocke ces indicateurs dans des octets signés ; le masquage préserve les valeurs de bits prévues. Comparer la valeur brute uniquement avec `1` ou `3` ferait manquer ces cas. D’autres indicateurs, tels que le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 de pouce), X augmentant vers la droite et Y augmentant vers le bas. Pour une forme non groupée, les coordonnées extraites comprennent déjà la position renvoyée par [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) et [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné à `(100, 200)` avec une taille de `120 × 80` a des limites de contour `(100, 200)`–`(220, 280)`. N’ajoutez pas à nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n’appliquent pas la rotation de la forme, renvoyée par [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ni les renversements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne supposez pas que les points extraits sont les coordonnées finales rendues sur la diapositive ni n’appliquez une translation ou un redimensionnement deux fois s’ils sont déjà reflétés dans le cadre de l’enfant.

**Inspection versus édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin a besoin de tableaux point/type. Utilisez [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) lorsque vous avez besoin des commandes géométriques dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les chemins édités via [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ou [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertir une forme Java AWT en GeometryPath**

Cet exemple combine un contour rectangulaire avec du texte converti en géométrie. La méthode [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) du contour désactive son remplissage. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crée le contour du texte dans un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fournit les segments de déplacement, ligne, quadratique, cubique et de fermeture, que l’exemple rejoue sur un [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Le pont Java utilise des valeurs explicites de type float et byte pour les paramètres Java correspondants. L’itérateur écrit les coordonnées dans un tableau float Java ; la réflexion lit ses valeurs mises à jour dans JavaScript. Le texte utilise une police Arial de 40 points. Le contour est décalé de 20 points horizontalement et positionné de sorte que son haut visuel se trouve 10 points sous le bord supérieur de la forme. Le chemin texte est rempli, tandis que le rectangle d’origine reste un contour. L’application des deux chemins avec [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) produit une forme unique contenant le rectangle et le texte.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Déplacer vers.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Ligne vers.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Courbe de Bézier quadratique.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Courbe de Bézier cubique.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Fermer la figure.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il du remplissage et du contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre à la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [diapositive](/slides/fr/nodejs-java/convert-powerpoint-to-png/) requise ou la [forme](/slides/fr/nodejs-java/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.