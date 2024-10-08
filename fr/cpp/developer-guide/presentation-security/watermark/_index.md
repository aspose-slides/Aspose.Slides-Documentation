---
title: Filigrane
type: docs
weight: 40
url: /cpp/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane texte
- filigrane image
- PowerPoint
- présentation
- C++
- Aspose.Slides pour C++
description: "Ajouter des filigranes texte et image aux présentations PowerPoint en C++"
---

## **À propos des Filigranes**

**Un filigrane** dans une présentation est un texte ou une image utilisé sur une diapositive ou sur toutes les diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'entreprise"), pour identifier l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations du droit d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/cpp/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur design et comportement. L'aspect commun est que pour ajouter des filigranes texte, vous devez utiliser l'interface [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l'interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), vous permettant d'utiliser tous les réglages flexibles de l'objet forme. Comme `ITextFrame` n'est pas une forme et que ses réglages sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

Il existe deux façons d'appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Maître de Diapositive est utilisé pour appliquer un filigrane à toutes les diapositives de la présentation — le filigrane est ajouté au Maître de Diapositive, entièrement conçu là-bas, et appliqué à toutes les diapositives sans affecter l'autorisation de modifier le filigrane sur des diapositives individuelles.

Un filigrane est généralement considéré comme non disponible pour modification par d'autres utilisateurs. Pour empêcher que le filigrane (ou plutôt la forme parente du filigrane) ne soit modifié, Aspose.Slides offre une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Maître de Diapositive. Lorsque la forme de filigrane est verrouillée sur le Maître de Diapositive, elle sera verrouillée sur toutes les diapositives de présentation.

Vous pouvez définir un nom pour le filigrane afin que dans le futur, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il y a généralement des caractéristiques communes dans les filigranes, telles que l'alignement central, la rotation, la position avant, etc. Nous allons considérer comment les utiliser dans les exemples ci-dessous.

## **Filigrane Texte**

### **Ajouter un Filigrane Texte à une Diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX, ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l'interface [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). Ce type n'hérite pas de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), qui a un large ensemble de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l'objet [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) comme indiqué ci-dessous.

```cpp
auto watermarkText = u"CONFIDENTIEL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/cpp/text-formatting/)
{{% /alert %}}

### **Ajouter un Filigrane Texte à une Présentation**

Si vous souhaitez ajouter un filigrane texte à l'ensemble de la présentation (c'est-à-dire à toutes les diapositives à la fois), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). Le reste de la logique est le même que lors de l'ajout d'un filigrane à une seule diapositive : créez un objet [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) puis ajoutez le filigrane en utilisant la méthode [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIEL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Maître de Diapositive](/slides/cpp/slide-master/)
{{% /alert %}}

### **Définir la Transparence de la Forme de Filigrane**

Par défaut, la forme rectangulaire est stylée avec des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Définir la Police pour un Filigrane Texte**

Vous pouvez changer la police du filigrane texte comme indiqué ci-dessous.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Définir la Couleur du Texte du Filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrer un Filigrane Texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela, vous pouvez faire ce qui suit :

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

L'image ci-dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane Image**

### **Ajouter un Filigrane Image à une Présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez faire ce qui suit :

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Verrouiller un Filigrane contre la Modification**

S'il est nécessaire d'empêcher qu'un filigrane ne soit modifié, utilisez la méthode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le regroupement avec d'autres éléments, verrouiller son texte pour l'édition, et bien plus encore :

```cpp
// Verrouillez la forme de filigrane contre la modification
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Amener un Filigrane au Premier Plan**

Dans Aspose.Slides, l'ordre Z des formes peut être réglé via la méthode [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). Pour ce faire, vous devez appeler cette méthode à partir de la liste des diapositives de la présentation et passer la référence de la forme ainsi que son numéro d'ordre à la méthode. De cette façon, il est possible d'amener une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Définir la Rotation du Filigrane**

Voici un exemple de code expliquant comment ajuster la rotation du filigrane afin qu'il soit positionné en diagonale sur la diapositive :

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Définir un Nom pour un Filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour le modifier ou le supprimer. Pour définir le nom de la forme de filigrane, attribuez-le à la méthode [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) :

```cpp
watermarkShape->set_Name(u"filigrane");
```

## **Supprimer un Filigrane**

Pour supprimer la forme de filigrane, utilisez la méthode [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) pour la trouver dans les formes de la diapositive. Ensuite, passez la forme de filigrane à la méthode [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) :

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"filigrane", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Un Exemple en Direct**

Vous pouvez vouloir consulter le **gratuit Aspose.Slides** [Ajouter Filigrane](https://products.aspose.app/slides/watermark) et [Supprimer Filigrane](https://products.aspose.app/slides/watermark/remove-watermark) outils en ligne.

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)