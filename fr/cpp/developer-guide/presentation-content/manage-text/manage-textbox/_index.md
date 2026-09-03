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
description: "Créer, identifier, formater et mettre à jour les zones de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++."
---
## **Introduction**

Dans Aspose.Slides pour C++, le texte des diapositives est stocké dans des cadres de texte qui appartiennent aux formes. L’interface [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) représente la forme la plus courante contenant du texte et expose son texte via la méthode [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}
Chaque forme automatique implémente [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/), mais toutes les formes ne sont pas des formes automatiques ni ne prennent en charge un cadre de texte. Lors du traitement d’une présentation existante, vérifiez qu’une forme implémente [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) avant d’accéder à son texte.
{{% /alert %}}

## **Create a Text Box on a Slide**

Pour créer une zone de texte, ajoutez une forme automatique à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L’exemple suivant crée une zone de texte rectangulaire :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Les coordonnées et dimensions transmises à [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addautoshape/) sont mesurées en points. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/addtextframe/) initialise le cadre de texte avec le texte fourni.

## **Check for a Text Box Shape**

Utilisez la méthode [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/get_istextbox/) pour déterminer si une forme automatique est considérée comme une zone de texte. Cela est utile lorsqu’une présentation contient à la fois des formes automatiques contenant du texte et des formes purement graphiques.

![Une zone de texte et une forme](istextbox.png)

L’exemple suivant examine chaque forme automatique d’une présentation :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Une forme automatique nouvellement ajoutée n’est pas considérée comme une zone de texte tant qu’elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/addtextframe/) ou [ITextFrame::set_Text](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/set_text/). Ajouter ou affecter une chaîne vide fait que [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/get_istextbox/) renvoie `false` :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Les deux premiers contrôles renvoient `true` ; les deux derniers renvoient `false`.

## **Find the Shape That Owns a Text Frame**

Le code générique de traitement du texte peut recevoir un [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) sans savoir quel objet de présentation le possède. Utilisez la méthode [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentshape/) pour revenir à la [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) qui le possède.

Pour un cadre de texte détenu par une forme automatique ou une autre forme contenant du texte, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentshape/) renvoie le propriétaire et [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_parentcell/) renvoie `nullptr`. Les deux méthodes offrent une navigation en lecture seule. Vérifiez la valeur renvoyée pour `nullptr` avant d’y accéder. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/cpp/search-and-replace-text/).

## **Add Columns to a Text Box**

La méthode [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/set_columncount/) divise le cadre de texte en colonnes, tandis que [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/set_columnspacing/) définit l’espacement entre les colonnes en points. Les deux méthodes appartiennent à [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/) et peuvent être appelées via le cadre de texte d’une zone de texte existante. Le texte se réajuste entre les colonnes à l’intérieur de la même forme ; il ne continue pas dans une autre forme.

L’exemple suivant crée une zone de texte à trois colonnes avec un espacement de 10 points entre les colonnes, enregistre la présentation et lit les paramètres stockés à partir du fichier de sortie :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Extract Text from Individual Columns**

Utilisez [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/splittextbycolumns/) pour récupérer le texte attribué à chaque colonne visuelle d’un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l’ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau contenant un seul élément, et une colonne vide est représentée par une chaîne vide. Les chaînes ne contiennent que du texte brut ; le formatage au niveau des portions n’est pas conservé.

Ceci est utile lorsque vous devez :

- Extraire le texte tout en conservant son ordre de lecture en colonnes.
- Indexer ou comparer le contenu de diapositives à plusieurs colonnes.
- Exporter chaque colonne vers un fichier séparé, un champ de base de données ou une autre destination.
- Examiner la redistribution du texte après avoir défini le nombre de colonnes avec [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/set_columncount/) ou l’espacement avec [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/set_columnspacing/), ou en modifiant la police ou la taille du cadre de texte.

La méthode rapporte le texte distribué à l’intérieur du [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) actuel ; elle ne fait pas automatiquement circuler le texte entre des formes ou zones de texte distinctes. La distribution en colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque des résultats cohérents sont indispensables.

L’exemple suivant charge une présentation, trouve la première forme automatique à plusieurs colonnes avec un cadre de texte sur la première diapositive, lit son nombre de colonnes configuré, puis écrit le texte de chaque colonne dans un fichier séparé. Les formes qui ne fournissent pas de cadre de texte sont ignorées.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Update Text**

Pour mettre à jour le texte dans l’ensemble d’une présentation, parcourez les diapositives et les formes, sélectionnez les formes automatiques, puis modifiez leurs portions de texte. Travailler au niveau des portions vous permet de changer à la fois le texte et le formatage des caractères.

L’exemple suivant remplace chaque occurrence de `years` par `months` dans les portions de texte des formes automatiques et rend chaque portion affectée en gras :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Ce parcours ne met à jour le texte que dans les formes automatiques. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite le parcours des collections propres à ces objets.

## **Add a Text Box with a Hyperlink**

Un hyperlien peut être attribué à une portion de texte spécifique, de sorte que seul ce texte agisse comme lien cliquable. Utilisez [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) pour associer la portion à une URL externe.

L’exemple suivant crée du texte lié et l’enregistre dans une présentation :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou de mise en page ?**

Un [placeholder](/slides/fr/cpp/manage-placeholder/) peut hériter de sa position et de son formatage d’une [master slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/masterslide/) ou d’une [layout slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et ne récupère pas le comportement d’espace réservé lorsqu’une mise en page change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux formes qui implémentent [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/), comme illustré dans l’exemple de mise à jour du texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objets, ils ne sont donc pas modifiés par cette boucle.