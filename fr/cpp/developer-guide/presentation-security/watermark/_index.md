---
title: Ajouter des filigranes aux présentations en C++
linktitle: Filigrane
type: docs
weight: 40
url: /fr/cpp/watermark/
keywords:
- filigrane
- filigrane texte
- filigrane image
- ajouter filigrane
- modifier filigrane
- supprimer filigrane
- effacer filigrane
- ajouter filigrane à PPT
- ajouter filigrane à PPTX
- ajouter filigrane à ODP
- supprimer filigrane de PPT
- supprimer filigrane de PPTX
- supprimer filigrane de ODP
- effacer filigrane de PPT
- effacer filigrane de PPTX
- effacer filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en C++ pour indiquer un brouillon, des informations confidentielles, des droits d’auteur, et plus encore."
---

## **Vue d'ensemble**

**Une filigrane** dans une présentation est un tampon texte ou image utilisé sur une diapositive ou sur l’ensemble de toutes les diapositives de la présentation. En général, une filigrane sert à indiquer que la présentation est un brouillon (par exemple, une filigrane « Brouillon »), qu’elle contient des informations confidentielles (par exemple, une filigrane « Confidentiel »), à spécifier à quelle société elle appartient (par exemple, une filigrane « Nom de l’entreprise »), à identifier l’auteur de la présentation, etc. Une filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés tant dans les formats de présentation PowerPoint que OpenOffice. Dans Aspose.Slides, vous pouvez ajouter une filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/cpp/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L’aspect commun est que, pour ajouter des filigranes texte, vous devez utiliser l’interface [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l’interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), ce qui vous permet d’utiliser tous les paramètres flexibles de l’objet forme. Puisque `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

Il y a deux manières d’appliquer une filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le masque des diapositives (Slide Master) est utilisé pour appliquer une filigrane à toutes les diapositives — la filigrane est ajoutée au Slide Master, entièrement conçue à cet endroit, et appliquée à toutes les diapositives sans affecter la permission de modifier la filigrane sur les diapositives individuelles.

Une filigrane est généralement considérée comme non modifiable par d’autres utilisateurs. Pour empêcher la filigrane (ou plus précisément la forme parent de la filigrane) d’être modifiée, Aspose.Slides propose une fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme de la filigrane est verrouillée sur le Slide Master, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom à la filigrane afin, à l’avenir, de la retrouver facilement dans les formes de la diapositive pour la supprimer.

Vous pouvez concevoir la filigrane comme vous le souhaitez ; toutefois, il existe généralement des caractéristiques communes aux filigranes, comme l’alignement centré, la rotation, la position en avant-plan, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter une filigrane texte à une diapositive**

Pour ajouter une filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre texte à cette forme. Le cadre texte est représenté par l’interface [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). Ce type n’est pas hérité de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), qui possède un large ensemble de propriétés permettant de positionner la filigrane de manière flexible. Ainsi, l’objet [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) comme indiqué ci‑dessous.
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/cpp/text-formatting/)
{{% /alert %}}

### **Ajouter une filigrane texte à une présentation**

Si vous souhaitez ajouter une filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑la au [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). Le reste de la logique est identique à celui de l’ajout d’une filigrane à une seule diapositive — créez un objet [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) puis ajoutez la filigrane en utilisant la méthode [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Slide Master](/slides/fr/cpp/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme de filigrane**

Par défaut, la forme rectangle possède des couleurs de remplissage et de contour. Les lignes de code suivantes rendent la forme transparente.
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **Définir la police d’une filigrane texte**

Vous pouvez modifier la police de la filigrane texte comme indiqué ci‑dessous.
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **Définir la couleur du texte de la filigrane**

Pour définir la couleur du texte de la filigrane, utilisez ce code :
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Centrer une filigrane texte**

Il est possible de centrer la filigrane sur une diapositive, et pour cela, vous pouvez procéder comme suit :
```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```


L’image ci‑dessous montre le résultat final.

![La filigrane texte](text_watermark.png)

## **Filigrane image**

### **Ajouter une filigrane image à une présentation**

Pour ajouter une filigrane image à une diapositive de présentation, vous pouvez procéder comme suit :
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **Verrouiller une filigrane contre la modification**

Si vous devez empêcher la modification d’une filigrane, utilisez la méthode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) sur la forme. Grâce à cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, le verrouillage du texte contre l’édition, et bien plus encore :
```cpp
// Verrouiller la forme de filigrane contre les modifications
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **Faire passer une filigrane à l’avant‑plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). Pour ce faire, appelez cette méthode depuis la liste des diapositives de la présentation et transmettez la référence de la forme ainsi que son numéro d’ordre. Ainsi, il est possible de placer une forme en avant‑plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer une filigrane devant le contenu de la présentation :
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **Définir la rotation de la filigrane**

Voici un exemple de code montrant comment ajuster la rotation de la filigrane afin qu’elle soit positionnée en diagonale sur la diapositive :
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **Attribuer un nom à une filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme de filigrane, affectez‑le à la méthode [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) :
```cpp
watermarkShape->set_Name(u"watermark");
```


## **Supprimer une filigrane**

Pour supprimer la forme de filigrane, utilisez la méthode [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) afin de la trouver parmi les formes de la diapositive. Ensuite, transmettez la forme de la filigrane à la méthode [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) :
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **Exemple en direct**

Vous pouvez essayer les outils en ligne **Aspose.Slides free** : [Add Watermark](https://products.aspose.app/slides/watermark) et [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)

## **FAQ**

**Qu’est‑ce qu’une filigrane et pourquoi l’utiliser ?**

Une filigrane est une superposition texte ou image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à prévenir l’utilisation non autorisée des présentations.

**Puis‑je ajouter une filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter programmatique‑ment une filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres de la filigrane individuellement.

**Comment ajuster la transparence de la filigrane ?**

Vous pouvez ajuster la transparence de la filigrane en modifiant les paramètres de remplissage ([FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)) de la forme. Cela garantit que la filigrane reste discrète et ne distrait pas du contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge plusieurs formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

**Puis‑je personnaliser la police et le style d’une filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style afin d’harmoniser la filigrane avec le design de votre présentation et de maintenir la cohérence de la marque.

**Comment changer la position ou l’orientation d’une filigrane ?**

Vous pouvez modifier la position et l’orientation de la filigrane programmatique‑ment en ajustant les coordonnées, la taille et les propriétés de rotation de la forme.