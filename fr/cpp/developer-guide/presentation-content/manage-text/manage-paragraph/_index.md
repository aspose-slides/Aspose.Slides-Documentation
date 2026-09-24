---
title: Gérer les paragraphes de texte PowerPoint en C++
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer la puce
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ représente le texte sous la forme d’une hiérarchie de cadres de texte, de paragraphes et de portions :

* [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) représente le conteneur de texte dans une forme et fournit l’accès à sa collection de paragraphes.
* [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) représente un paragraphe dans un cadre de texte et fournit l’accès à ses portions ainsi qu’au formatage au niveau du paragraphe.
* [IPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/) représente une séquence de texte au sein d’un paragraphe. Chaque portion peut avoir son propre texte et un formatage de caractère.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formatages en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte contenant trois paragraphes, chacun contenant trois portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée via son indice.
3. Ajoutez une forme rectangulaire [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme.
5. Utilisez le paragraphe par défaut et ajoutez deux objets [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) supplémentaires au cadre de texte.
6. Ajoutez suffisamment d’objets [IPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définissez le texte de chaque portion.
8. Appliquez un formatage de caractère via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/get_portionformat/).
9. Enregistrez la présentation modifiée.

Cet exemple C++ implémente les étapes :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Créer des listes à puces et numérotées**

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments associés. Dans Aspose.Slides, les paramètres de liste sont définis via [IBulletFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme.
5. Supprimez le paragraphe par défaut du cadre de texte.
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/) pour une puce symbole.
7. Appelez [IBulletFormat::set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_type/) avec [BulletType::Symbol](https://reference.aspose.com/slides/fr/cpp/aspose.slides/bullettype/) et spécifiez le caractère de puce.
8. Définissez le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Créez un second paragraphe et appelez [IBulletFormat::set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_type/) avec [BulletType::Numbered](https://reference.aspose.com/slides/fr/cpp/aspose.slides/bullettype/).
11. Configurez le style de puce numérotée et ajoutez le paragraphe au cadre de texte.
12. Enregistrez la présentation.

Cet exemple C++ crée une puce symbole et une puce numérotée :

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Utiliser des puces d’image**

Les puces d’image vous permettent d’utiliser une image personnalisée à la place d’un symbole ou d’un numéro.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive concernée via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) et accédez à son [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/).
4. Supprimez le paragraphe par défaut du cadre de texte.
5. Chargez l’image de puce et ajoutez‑la à la collection d’images de la présentation sous forme d’[IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/).
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/paragraph/) et définissez son texte.
7. Appelez [IBulletFormat::set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_type/) avec [BulletType::Picture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/bullettype/).
8. Assignez l’image via [ISlidesPicture::set_Image](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/set_image/) et définissez la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Enregistrez la présentation modifiée.

Cet exemple C++ crée une puce image :

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Créer une liste à plusieurs niveaux**

Définissez [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_depth/) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) et supprimez le paragraphe par défaut de son cadre de texte.
3. Créez quatre paragraphes et configurez leurs symboles de puce.
4. Définissez leurs valeurs [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_depth/) à `0`, `1`, `2` et `3`.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

Cet exemple C++ crée une liste à puces à quatre niveaux :

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Débuter les éléments de liste numérotée à des valeurs personnalisées**

Utilisez [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à une diapositive.
2. Supprimez le paragraphe par défaut du cadre de texte de la forme.
3. Créez trois paragraphes numérotés.
4. Définissez [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

Cet exemple C++ assigne un numéro de départ personnalisé à chaque paragraphe :

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Contrôler la mise en page du paragraphe et les propriétés de fin**

### **Définir un retrait de première ligne**

Utilisez [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour contrôler le retrait de la première ligne d’un paragraphe. Cette méthode ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées sur le corps du paragraphe.

Utilisez [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginleft/) lorsque vous devez déplacer tout le paragraphe. Utilisez [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) lorsque vous ne devez déplacer que la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour illustrer l’impact du retrait de première ligne sur la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une forme rectangulaire [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour chacun d’eux.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait de paragraphe :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une mise en page où la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/). Définissez le retrait à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginleft/) définit la position gauche du corps du paragraphe, et [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une marge‑gauche positive et un retrait négatif.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes enroulées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une forme rectangulaire [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_marginleft/) pour chaque paragraphe.
6. Définissez une valeur négative [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_indent/) pour obtenir l’effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait suspendu pour un paragraphe :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin de paragraphe**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) contrôle le formatage du caractère de fin de paragraphe. L’exemple suivant affecte une taille de police et une police latine au caractère de fin du second paragraphe :

1. Chargez une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) et supprimez son paragraphe par défaut.
3. Créez deux paragraphes et ajoutez‑leur des portions de texte.
4. Créez un [PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/portionformat/) pour le caractère de fin du second paragraphe.
5. Définissez [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_fontheight/) et [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Appliquez le format avec [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) et enregistrez la présentation.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Compter les lignes rendues**

Utilisez [IParagraph::GetLinesCount](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getlinescount/) pour compter le nombre de lignes occupées par un paragraphe après la mise en page du texte, y compris les retours à la ligne automatiques. Cela est utile lors de la vérification de la longueur du texte et de la mise en page dans des modèles de présentation.

Un paragraphe est un élément de [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_paragraphs/), et il peut occuper plusieurs lignes rendues. Un saut de ligne explicite dans un paragraphe force une nouvelle ligne sans créer un autre paragraphe. L’enroulement automatique crée des lignes en fonction de la largeur disponible sans insérer de sauts de ligne explicites dans le texte. Ainsi, compter les paragraphes ou les caractères de saut de ligne ne donne pas le nombre réel de lignes rendues.

L’exemple suivant crée une forme de texte, compte ses lignes, rétrécit la forme, puis remplace le texte par une chaîne plus courte. L’enroulement est activé et l’ajustement automatique désactivé afin que la largeur de la forme contrôle l’enroulement sans réduire automatiquement le texte ni redimensionner la forme. Les dimensions de la forme sont exprimées en points. Enfin, l’exemple ajoute un autre paragraphe et additionne les comptes de lignes dans le cadre de texte.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

Avec ce texte et ces dimensions, rétrécir la forme augmente le nombre de lignes, tandis que remplacer le texte par la chaîne courte le réduit. Les comptes exacts peuvent varier selon la disponibilité des polices et les substitutions, la taille de la police, les marges, les retraits, l’enroulement et les paramètres d’ajustement. Utilisez les polices et les paramètres de mise en page prévus pour l’environnement cible lors de la vérification d’un modèle.

Le nombre de lignes seul ne détermine pas si le texte dépasse son conteneur. La hauteur disponible, la hauteur des lignes, l’interligne du paragraphe et le comportement d’ajustement sont également importants ; même une seule ligne peut excéder la largeur disponible si l’enroulement est désactivé.

## **Importer et exporter le contenu de paragraphes**

### **Importer du texte HTML dans des paragraphes**

Utilisez [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphcollection/addfromhtml/) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Accédez à une diapositive et ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/).
3. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
4. Lisez le fichier HTML source.
5. Transmettez la chaîne HTML à [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Enregistrez la présentation modifiée.

Cet exemple C++ importe du HTML dans un cadre de texte :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Exporter le texte d’un paragraphe vers HTML**

Utilisez [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphcollection/exporttohtml/) pour exporter une plage sélectionnée de paragraphes au format HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la diapositive et repérez la [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) contenant le texte.
3. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) de la forme.
4. Appelez [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphcollection/exporttohtml/) en indiquant l’indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrivez la chaîne HTML renvoyée dans un fichier.

Cet exemple C++ exporte tous les paragraphes du premier cadre de texte :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Rendre un paragraphe sous forme d’image**

[IParagraph::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getimage/) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/save/). Vous n’avez pas besoin de rendre la forme contenant le paragraphe ni de recadrer manuellement un bitmap.

[IParagraph::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getimage/) peut renvoyer `nullptr` si le paragraphe est introuvable dans sa collection parente, s’il n’a pas de limites de rendu valides ou s’il ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

Supposons que nous possédions un fichier de présentation nommé sample.pptx contenant une diapositive, dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L’exemple suivant rend le deuxième paragraphe d’une forme de texte ordinaire à l’échelle par défaut et enregistre l’image obtenue au format PNG.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Le résultat :

![L’image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [IParagraph::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getimage/) qui accepte les paramètres `float scaleX` et `float scaleY` pour définir les facteurs d’échelle horizontaux et verticaux. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat au format PNG.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Un facteur d’échelle de `1` conserve cette dimension en pixels. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement le double des dimensions par défaut, ce qui crée quatre fois plus de pixels. Des facteurs plus élevés produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent également la consommation mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour conserver le rapport d’aspect du paragraphe ; des facteurs différents horizontalement et verticalement étirent la sortie indépendamment.

Rendre une forme complète avec [IShape::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/getimage/) reste utile lorsque la sortie doit inclure le remplissage, le contour ou d’autres contextes visuels de la forme. Pour une image ne contenant qu’un paragraphe, utilisez [IParagraph::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Puis‑je désactiver complètement l’enroulement du texte dans un cadre de texte ?**

Oui. Utilisez [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/set_wraptext/) pour désactiver l’enroulement afin que les lignes ne se cassent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Utilisez [IParagraph::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/getrect/) pour récupérer le rectangle englobant du paragraphe. [IPortion::GetRect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/getrect/) fournit les limites d’une portion individuelle.

**Où est contrôlé l’alignement des paragraphes (gauche, droite, centre ou justifié) ?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/set_alignment/) est un paramètre au niveau du paragraphe et s’applique à l’ensemble du paragraphe, quel que soit le formatage des portions individuelles.

**Puis‑je définir la langue de vérification orthographique pour une partie d’un paragraphe ?**

Oui. Utilisez [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_languageid/) pour les portions individuelles, de sorte qu’un même paragraphe puisse contenir du texte dans plusieurs langues.