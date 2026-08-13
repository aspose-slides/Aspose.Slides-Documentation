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
- ajouter un filigrane
- modifier le filigrane
- supprimer le filigrane
- effacer le filigrane
- ajouter un filigrane à PPT
- ajouter un filigrane à PPTX
- ajouter un filigrane à ODP
- supprimer le filigrane de PPT
- supprimer le filigrane de PPTX
- supprimer le filigrane de ODP
- effacer le filigrane de PPT
- effacer le filigrane de PPTX
- effacer le filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en C++ pour indiquer un brouillon, des informations confidentielles, des droits d’auteur, etc."
---
## **Introduction**

**Un filigrane** dans une présentation est un texte ou une image apposés sur une diapositive ou sur l’ensemble des diapositives. En général, un filigrane indique que la présentation est un brouillon (par ex. un filigrane « Brouillon »), qu’elle contient des informations confidentielles (par ex. un filigrane « Confidentiel »), à quelle entreprise elle appartient (par ex. un filigrane « Nom de l’entreprise »), identifie l’auteur de la présentation, etc. Un filigrane contribue à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichier PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/fr/cpp/), plusieurs méthodes permettent de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L’aspect commun est que, pour ajouter des filigranes texte, vous devez utiliser l’interface [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l’interface [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/), ce qui vous permet d’utiliser tous les paramètres flexibles de l’objet forme. Comme `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/).

Il existe deux façons d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Masteur de Diapositive (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Slide Master, pleinement conçu là‑bas, et appliqué à toutes les diapositives sans affecter la permission de modification du filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parente du filigrane) d’être édité, Aspose.Slides fournit la fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin, à l’avenir, de le retrouver facilement parmi les formes de la diapositive et le supprimer si nécessaire.

Vous pouvez concevoir le filigrane de n’importe quelle façon ; cependant, il existe généralement des caractéristiques communes aux filigranes, telles que l’alignement centré, la rotation, la position en avant‑plan, etc. Nous verrons comment les exploiter dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre texte à cette forme. Le cadre texte est représenté par l’interface [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/). Ce type n’est pas hérité de [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/), qui possède un vaste ensemble de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [AddTextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/addtextframe/) comme indiqué ci‑dessous.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/fr/cpp/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/masterslide/). Le reste de la logique est identique à celui de l’ajout d’un filigrane à une seule diapositive — créez un objet [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) puis ajoutez le filigrane à l’aide de la méthode [AddTextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the Slide Master](/slides/fr/cpp/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire possède des couleurs de remplissage et de trait. Les lignes de code suivantes rendent la forme transparente.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Définir la police du filigrane texte**

Vous pouvez modifier la police du filigrane texte comme indiqué ci‑dessous.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrer un filigrane texte**

Il est possible de centrer le filigrane sur une diapositive ; pour cela, vous pouvez procéder comme suit :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

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

![Le filigrane de texte](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez procéder comme suit :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Verrouiller un filigrane contre l’édition**

Si vous devez empêcher l’édition d’un filigrane, utilisez la méthode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/get_autoshapelock/) sur la forme. Grâce à cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, le verrouillage du texte contre l’édition, et bien plus encore :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Verrouiller la forme du filigrane contre la modification
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Amener un filigrane en avant‑plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [IShapeCollection::Reorder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/reorder/). Pour ce faire, appelez cette méthode depuis la collection de diapositives de la présentation en transmettant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme en avant‑plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez positionner un filigrane devant le contenu de la présentation :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la méthode [IAutoShape::set_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/set_name/) :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [IAutoShape::get_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_name/) afin de la retrouver parmi les formes de la diapositive. Ensuite, transmettez cette forme à la méthode [IShapeCollection::Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/remove/) :

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Exemple en direct**

Vous pouvez tester les outils en ligne **Aspose.Slides free** : [Add Watermark](https://products.aspose.app/slides/fr/watermark) et [Remove Watermark](https://products.aspose.app/slides/fr/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)

## **FAQ**

### Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?

Un filigrane est une superposition de texte ou d’image appliquée aux diapositives qui protège la propriété intellectuelle, renforce la reconnaissance de la marque ou empêche l’utilisation non autorisée des présentations.

### Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?

Oui, Aspose.Slides permet d’ajouter programmétiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

### Comment ajuster la transparence du filigrane ?

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([FillFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/get_fillformat/)) de la forme. Cela garantit que le filigrane reste discret et ne détourne pas l’attention du contenu de la diapositive.

### Quels formats d’image sont pris en charge pour les filigranes ?

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

### Puis‑je personnaliser la police et le style d’un filigrane texte ?

Oui, vous pouvez choisir n’importe quelle police, taille et style afin de correspondre à la conception de votre présentation et de maintenir la cohérence de la marque.

### Comment modifier la position ou l’orientation d’un filigrane ?

Vous pouvez ajuster la position et l’orientation du filigrane programmétiquement en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.