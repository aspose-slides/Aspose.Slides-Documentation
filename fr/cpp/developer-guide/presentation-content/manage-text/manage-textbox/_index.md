---
title: Gérer les zones de texte dans les présentations avec C++
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/cpp/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ facilite la création, la modification et la duplication des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l'automatisation de vos présentations."
---
## **Introduction**

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis y placer du texte. Aspose.Slides for C++ fournit l’interface [IAutoShape](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_auto_shape) qui vous permet d’ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}
Aspose.Slides fournit également l’interface [IShape](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_shape) qui permet d’ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l’interface `IShape` ne peuvent pas contenir de texte. En revanche, les formes ajoutées via l’interface [IAutoShape](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_auto_shape) peuvent contenir du texte. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Par conséquent, lorsque vous travaillez avec une forme à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu’elle a été convertie via l’interface `IAutoShape`. Ce n’est qu’alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.text_frame), qui est une propriété de `IAutoShape`. Consultez la section [Update Text](https://docs.aspose.com/slides/fr/cpp/manage-textbox/#update-text) de cette page. 
{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation). 
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_auto_shape) avec [ShapeType](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l’objet `IAutoShape` ajouté. 
4. Ajoutez une propriété `TextFrame` à l’objet `IAutoShape` qui contiendra du texte. Dans l’exemple ci‑dessus, nous avons ajouté ce texte : *Aspose TextBox* 
5. Enfin, écrivez le fichier PPTX via l’objet `Presentation`. 

Ce code C++ — une implémentation des étapes ci‑dessus — montre comment ajouter du texte à une diapositive :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instancie la présentation
auto pres = System::MakeObject<Presentation>();

// Récupère la première diapositive de la présentation
auto sld = pres->get_Slides()->idx_get(0);

// Ajoute une AutoShape avec le type défini sur Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Ajoute un TextFrame au rectangle
ashp->AddTextFrame(u" ");

// Accède au cadre de texte
auto txtFrame = ashp->get_TextFrame();

// Crée l'objet Paragraph pour le cadre de texte
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Crée un objet Portion pour le paragraphe
auto portion = para->get_Portions()->idx_get(0);

// Définit le texte
portion->set_Text(u"Aspose TextBox");

// Enregistre la présentation sur le disque
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Vérifier qu’une forme est une zone de texte**

Aspose.Slides fournit la méthode [get_IsTextBox](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/get_istextbox/) de l’interface [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/), vous permettant d’examiner les formes et d’identifier les zones de texte.

![Text box and shape](istextbox.png)

Ce code C++ montre comment vérifier si une forme a été créée en tant que zone de texte :

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Notez que si vous ajoutez simplement une forme automatique à l’aide de la méthode `AddAutoShape` de l’interface [IShapeCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/), la méthode `get_IsTextBox` de la forme automatique renverra `false`. En revanche, après avoir ajouté du texte à la forme automatique avec la méthode `AddTextFrame` ou la méthode `set_Text`, la méthode `get_IsTextBox` renvoie `true`.

```cpp
#include <DOM/IAutoShape.h>
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

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() renvoie false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() renvoie true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() renvoie false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() renvoie true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() renvoie false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() renvoie false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() renvoie false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() renvoie false
```

## **Trouver la forme qui possède un cadre de texte**

Dans un code de traitement de texte générique, vous pouvez recevoir un [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) sans connaître à l’avance l’objet de présentation qui le contient. Utilisez [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentshape/) pour revenir à la [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) propriétaire.

Pour un cadre de texte appartenant à une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) ou à une autre forme contenant du texte, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentshape/) renvoie le propriétaire et [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentcell/) renvoie `nullptr`. Les deux méthodes offrent une navigation en lecture seule, ainsi leur appel ne modifie pas la propriété. Vérifiez toujours que la valeur renvoyée n’est pas `nullptr` avant d’accéder à la forme.

Pour un exemple complet qui identifie les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/cpp/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

Aspose.Slides fournit les méthodes [set_ColumnCount](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) et [set_ColumnSpacing](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (issues de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_text_frame_format) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_text_frame_format)) qui permettent d’ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l’espacement en points entre les colonnes. 

Ce code en C++ montre l’opération décrite :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Récupère la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute une AutoShape avec le type défini sur Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Ajoute un TextFrame au rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Récupère le format de texte du TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Spécifie le nombre de colonnes dans le TextFrame
format->set_ColumnCount(3);

// Spécifie l'espacement entre les colonnes
format->set_ColumnSpacing(10);

// Enregistre la présentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Ajouter des colonnes à un cadre de texte**

Aspose.Slides for C++ fournit la méthode [set_ColumnCount](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (issue de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_text_frame_format)) qui permet d’ajouter des colonnes dans les cadres de texte. Grâce à cette méthode, vous pouvez spécifier le nombre de colonnes souhaité dans un cadre de texte. 

Ce code C++ montre comment ajouter une colonne à l’intérieur d’un cadre de texte :

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou l’ensemble des textes d’une présentation. 

Ce code C++ montre une opération où tous les textes d’une présentation sont mis à jour ou modifiés :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Modifie le texte
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Modifie le formatage
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Enregistre la présentation modifiée
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Ajouter une zone de texte avec un hyperlien**

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l’objet AutoShape ajouté. 
4. Ajoutez un `TextFrame` à l’objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Attribuez l’objet `IHyperlinkManager` à la méthode [set_HyperlinkClick](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) associée à la partie souhaitée du `TextFrame`. 
7. Enfin, écrivez le fichier PPTX via l’objet `Presentation`. 

Ce code C++ — une implémentation des étapes ci‑dessus — montre comment ajouter une zone de texte avec un hyperlien à une diapositive :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instancie une classe Presentation qui représente un PPTX
auto presentation = System::MakeObject<Presentation>();

// Récupère la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute un objet AutoShape avec le type défini sur Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Convertit la forme en AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Accède à la propriété ITextFrame associée à l'AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Ajoute du texte au cadre
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Définit le lien hypertexte pour le texte de la portion
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Enregistre la présentation PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé au texte lors de l’utilisation des diapositives maîtres ?**

Un [placeholder](/slides/fr/cpp/manage-placeholder/) hérite du style/position de la [maître](https://reference.aspose.com/slides/fr/cpp/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/layoutslide/), alors qu’une zone de texte normale est un objet indépendant sur une diapositive spécifique et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement massif de texte dans toute la présentation sans toucher au texte à l’intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux formes automatiques qui possèdent des cadres de texte et excluez les objets incorporés ([graphiques](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chart/), [tableaux](https://reference.aspose.com/slides/fr/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.