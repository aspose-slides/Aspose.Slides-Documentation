---
title: Ajouter un filigrane à une présentation en C#
linktitle: Filigrane
type: docs
weight: 40
url: /fr/net/watermark/
keywords:
- filigrane
- filigrane texte
- filigrane image
- ajouter filigrane
- modifier filigrane
- supprimer filigrane
- effacer filigrane
- ajouter filigrane à la présentation
- ajouter filigrane à PPT
- ajouter filigrane à PPTX
- ajouter filigrane à ODP
- supprimer filigrane de la présentation
- supprimer filigrane de PPT
- supprimer filigrane de PPTX
- supprimer filigrane de ODP
- effacer filigrane de la présentation
- effacer filigrane de PPT
- effacer filigrane de PPTX
- effacer filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Découvrez comment gérer les filigranes texte et image dans les présentations PowerPoint et OpenDocument en C# pour indiquer un brouillon, des informations confidentielles, des droits d'auteur, etc."
---

## **Vue d'ensemble**

**Un filigrane** dans une présentation est un texte ou une image tampon utilisée sur une diapositive ou sur l'ensemble des diapositives. Généralement, un filigrane indique que la présentation est un brouillon (par exemple, un filigrane « Brouillon »), qu'elle contient des informations confidentielles (par exemple, un filigrane « Confidentiel »), à quelle société elle appartient (par exemple, un filigrane « Nom de l'entreprise »), identifie l’auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés à la fois dans les formats de présentation PowerPoint et OpenDocument. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenDocument ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/net/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenDocument et de modifier leur conception et leur comportement. Le point commun est que, pour ajouter des filigranes texte, vous devez utiliser l’interface [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l’interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) permettant d’utiliser tous les réglages flexibles de l’objet forme. Étant donné que `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est enveloppé dans un objet [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Il existe deux manières d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Masque des diapositives (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Masque des diapositives, entièrement conçu là‑bas, et appliqué à toutes les diapositives sans affecter la permission de modification du filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être modifié, Aspose.Slides offre une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur le Masque des diapositives. Lorsque la forme du filigrane est verrouillée sur le Masque des diapositives, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez définir un nom pour le filigrane afin, à l’avenir, de le retrouver facilement dans les formes de la diapositive et le supprimer si nécessaire.

Vous pouvez concevoir le filigrane de n’importe quelle façon ; toutefois, il existe généralement des caractéristiques communes, telles que l’alignement centré, la rotation, la position avant, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l’interface [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). Ce type n’est pas hérité de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), qui possède un large ensemble de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) est enveloppé dans un objet [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) comme indiqué ci‑dessous.
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Ajouter le filigrane à la diapositive.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame ?](/slides/fr/net/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous voulez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). Le reste de la logique est identique à celui de l’ajout d’un filigrane à une seule diapositive — créez un objet [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) puis ajoutez le filigrane à l’aide de la méthode [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Ajouter le filigrane à la diapositive maître.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Masque des diapositives ?](/slides/fr/net/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de ligne. Cela signifie que, lorsqu’il est ajouté, le filigrane peut apparaître avec un arrière‑plan ou une bordure solide qui risque de détourner l’attention du contenu de la diapositive. Pour que le filigrane reste discret et n’interfère pas avec le design visuel de la présentation, vous pouvez rendre la forme entièrement transparente.

Les lignes de code ci‑dessous rendent la forme transparente en supprimant à la fois sa couleur de remplissage et sa couleur de bordure :
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **Définir la police d’un filigrane texte**

Avant d’appliquer le filigrane texte à votre diapositive, il est important de personnaliser son apparence afin qu’elle s’harmonise avec le design global. Vous pouvez changer le type et la taille de la police pour garantir que le filigrane soit lisible et esthétiquement agréable. La personnalisation de la police aide également à renforcer l’identité de marque ou simplement à assortir le style de la présentation.

Le fragment de code ci‑dessus montre comment ajuster les paramètres de police du filigrane en sélectionnant une police latine spécifique et en définissant une hauteur de police appropriée :
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **Définir la couleur du texte du filigrane**

Avant d’appliquer votre filigrane, il est essentiel de définir correctement la couleur du texte afin qu’elle se fonde bien avec le contenu de votre diapositive sans le dominer. Ajuster la transparence (alpha) ainsi que les composantes rouge, vert et bleu vous permet de créer un filigrane subtil, semi‑transparent, visible mais discret. Cette approche aide à garder l’attention sur votre présentation principale tout en protégeant votre contenu.

Pour définir la couleur du texte du filigrane, utilisez le code suivant :
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **Centrer un filigrane texte**

Centrer correctement votre filigrane texte peut améliorer considérablement l’esthétique globale de votre présentation en assurant que le filigrane soit positionné symétriquement, quelle que soit la taille des diapositives. Cette méthode donne à vos diapositives un aspect professionnel et garantit que le filigrane n’interfère pas avec le contenu principal.

Le fragment de code ci‑dessous montre comment calculer la position centrale d’une diapositive et placer le filigrane texte en conséquence :
```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


L’image ci‑dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Dans de nombreux cas, un filigrane image peut offrir un élément de marque unique ou une alternative visuellement plus attrayante à un filigrane texte. Avant d’ajouter le filigrane, assurez‑vous que le fichier image est disponible (par exemple, PNG pour la transparence). L’exemple suivant montre comment charger une image depuis le système de fichiers, l’ajouter à la présentation, puis l’appliquer comme filigrane à l’aide des propriétés de remplissage de la forme.
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **Verrouiller un filigrane contre la modification**

S’il faut empêcher la modification d’un filigrane, utilisez la propriété [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, le verrouillage du texte contre la modification, etc. :
```cs
// Verrouiller la forme du filigrane contre la modification.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **Amener un filigrane à l’avant**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). Pour ce faire, appelez cette méthode depuis la liste des diapositives de la présentation en transmettant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de mettre une forme au premier plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant le reste de la présentation :
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **Définir la rotation du filigrane**

Ajuster la rotation de votre filigrane peut grandement améliorer l’impact visuel et la subtilité de votre présentation. Un filigrane diagonal, par exemple, est moins intrusif tout en offrant une protection robuste contre l’utilisation non autorisée. L’exemple suivant calcule l’angle approprié en fonction des dimensions de la diapositive afin que le filigrane soit positionné en diagonale sur la diapositive. Ce calcul dynamique garantit que le filigrane reste efficace quelles que soient les tailles de diapositive.
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la propriété [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) :
```cs
watermarkShape.Name = "watermark";
```


## **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la propriété [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) afin de la retrouver parmi les formes de la diapositive. Ensuite, transmettez la forme du filigrane à la méthode [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) :
```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```


## **Exemple en direct**

Vous pouvez tester les outils en ligne **Aspose.Slides free** [Ajouter un filigrane](https://products.aspose.app/slides/watermark) et [Supprimer un filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)

## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?**

Un filigrane est une superposition de texte ou d’image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’usage non autorisé des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter programmatiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)) de la forme. Cela garantit que le filigrane reste discret et ne distrait pas du contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, et plus encore.

**Puis‑je personnaliser la police et le style d’un filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style pour qu’ils correspondent au design de votre présentation et maintiennent la cohérence de la marque.

**Comment changer la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane programmatiquement en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.