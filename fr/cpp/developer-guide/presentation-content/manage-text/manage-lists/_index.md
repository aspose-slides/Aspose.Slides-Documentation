---
title: Gérer les listes à puces et numérotées dans les présentations en C++
linktitle: Gérer les listes
type: docs
weight: 70
url: /fr/cpp/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer puce
- ajouter puce
- ajouter liste
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et formater des listes à puces, image, à plusieurs niveaux et numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ vous permet de créer et de formater des listes à puces et numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la méthode [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/get_paragraphformat/) pour accéder aux paramètres de liste au niveau du paragraphe. Le principal point d'entrée est [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/get_bullet/), qui renvoie un objet [IBulletFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l'image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- inspecter et modifier le formatage de la liste dans une présentation existante

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/) à un [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) et définissez [IBulletFormat::set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_type/) sur [BulletType::Symbol](https://reference.aspose.com/slides/fr/cpp/aspose.slides/bullettype/). Vous pouvez ensuite définir [IBulletFormat::set_Char](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/get_color/), et [IBulletFormat::set_Height](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_height/) pour contrôler l'apparence de la puce.

Le code C++ suivant montre comment créer une liste à puces dans une diapositive :

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les puces symboliques](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez les listes numérotées lorsque l'ordre des éléments est important. Définissez [IBulletFormat::set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_type/) sur [BulletType::Numbered](https://reference.aspose.com/slides/fr/cpp/aspose.slides/bullettype/). Vous pouvez également choisir un format de numérotation avec [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) ou définir [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) lorsque la liste doit commencer à une valeur autre que 1.

Le code C++ suivant montre comment créer une liste numérotée dans une diapositive :

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce standard par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="info" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphique simple avec un arrière‑plan transparent. De telles images fonctionnent bien comme symboles de puce personnalisés.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [IPresentation::get_Images](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_images/) et attribuez l'objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) retourné à [IBulletFormat::get_Picture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/get_picture/). Définissez [IBulletFormat::set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_type/) sur [BulletType::Picture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/bullettype/) avant d’attribuer l’image.

Supposons que nous ayons une image "image.png" :

![Une image pour les puces](picture_for_bullets.png)

Le code C++ suivant montre comment créer des puces image dans une diapositive :

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_depth/) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, et ainsi de suite.

Le code C++ suivant montre comment créer une liste à puces à plusieurs niveaux :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le formatage d'une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/get_bullet/). Les mêmes propriétés utilisées pour créer des listes peuvent être utilisées pour inspecter ou modifier des listes chargées depuis un fichier PPT, PPTX ou ODP.

Le code C++ suivant modifie le premier paragraphe d'un cadre de texte pour utiliser un style de liste numérotée :

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### Les listes à puces et numérotées peuvent être exportées au format PDF ou images ?

Oui. Aspose.Slides conserve le formatage des listes lorsque le format cible prend en charge la mise en page de texte et les fonctionnalités de puces correspondantes.

### Puis‑je modifier les listes dans des présentations existantes ?

Oui. Chargez la présentation, accédez au paragraphe cible, inspectez ou mettez à jour ses paramètres [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/get_bullet/), puis enregistrez la présentation.

### Les listes peuvent-elles contenir du texte non latin ?

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, vous pouvez donc créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères requis.