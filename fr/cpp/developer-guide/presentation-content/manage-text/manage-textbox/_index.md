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
description: "Aspose.Slides pour C++ facilite la création, la modification et la duplication des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l'automatisation de vos présentations."
---

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis insérer du texte à l'intérieur de celle‑ci. Aspose.Slides for C++ fournit l'interface [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) qui permet d’ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides propose également l'interface [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) qui permet d’ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l’interface `IShape` ne peuvent pas contenir de texte. En revanche, les formes ajoutées via l’interface [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) peuvent contenir du texte. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Donc, lorsque vous travaillez avec une forme à laquelle vous souhaitez ajouter du texte, il est recommandé de vérifier et de confirmer qu’elle a été castée via l’interface `IAutoShape`. Ce n’est qu’alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), qui est une propriété de `IAutoShape`. Consultez la section [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) de cette page. 

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée.  
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) avec le [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) défini sur `Rectangle` à une position spécifiée sur la diapositive et récupérez la référence de l’objet `IAutoShape` ajouté.  
4. Ajoutez une propriété `TextFrame` à l’objet `IAutoShape` qui contiendra du texte. Dans l’exemple ci‑dessous, nous avons ajouté ce texte : *Aspose TextBox*  
5. Enfin, écrivez le fichier PPTX à l’aide de l’objet `Presentation`.  

Ce code C++—une implémentation des étapes ci‑above—vous montre comment ajouter du texte à une diapositive :
```cpp
// Instancie la présentation
auto pres = System::MakeObject<Presentation>();

// Obtient la première diapositive de la présentation
auto sld = pres->get_Slides()->idx_get(0);

// Ajoute une AutoShape dont le type est Rectangle
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


## **Vérifier la présence d’une forme zone de texte**

Aspose.Slides fournit la méthode [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) de l’interface [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) qui permet d’examiner les formes et d’identifier les zones de texte.

![Text box and shape](istextbox.png)

Ce code C++ vous montre comment vérifier si une forme a été créée en tant que zone de texte : 
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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


Notez que si vous ajoutez simplement une forme automatique à l’aide de la méthode `AddAutoShape` de l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/), la méthode `get_IsTextBox` de la forme automatique renverra `false`. En revanche, après avoir ajouté du texte à la forme automatique via la méthode `AddTextFrame` ou la méthode `set_Text`, la méthode `get_IsTextBox` renverra `true`.
```cpp
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


## **Ajouter des colonnes à une zone de texte**

Aspose.Slides fournit les méthodes [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) et [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) qui permettent d’ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l’espacement, en points, entre les colonnes. 

Ce code C++ illustre l’opération décrite : 
```cpp
auto presentation = System::MakeObject<Presentation>();
// Obtient la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute une AutoShape dont le type est Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Ajoute un TextFrame au rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Obtient le format de texte du TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Spécifie le nombre de colonnes dans le TextFrame
format->set_ColumnCount(3);

// Spécifie l'espacement entre les colonnes
format->set_ColumnSpacing(10);

// Enregistre la présentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Ajouter des colonnes à un cadre de texte**

Aspose.Slides for C++ propose la méthode [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) qui permet d’ajouter des colonnes dans les cadres de texte. Grâce à cette méthode, vous pouvez spécifier le nombre de colonnes souhaité dans un cadre de texte. 

Ce code C++ vous montre comment ajouter une colonne à l’intérieur d’un cadre de texte :
```cpp
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
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
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

Vous pouvez insérer un lien à l’intérieur d’une zone de texte. Lorsque la zone de texte est cliquée, l’utilisateur est redirigé vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`.  
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée.  
3. Ajoutez un objet `AutoShape` avec le `ShapeType` défini sur `Rectangle` à une position spécifiée sur la diapositive et récupérez la référence de l’objet AutoShape ajouté.  
4. Ajoutez un `TextFrame` à l’objet `AutoShape` contenant *Aspose TextBox* comme texte par défaut.  
5. Instanciez la classe `IHyperlinkManager`.  
6. Assignez l’objet `IHyperlinkManager` à la méthode [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) associée à la partie souhaitée du `TextFrame`.  
7. Enfin, écrivez le fichier PPTX à l’aide de l’objet `Presentation`.  

Ce code C++—une implémentation des étapes ci‑above—vous montre comment ajouter une zone de texte avec un hyperlien à une diapositive :
```cpp
// Instancie une classe Presentation qui représente un PPTX
// Obtient la première diapositive de la présentation
// Ajoute un objet AutoShape dont le type est Rectangle
// Convertit la forme en AutoShape
// Accède à la propriété ITextFrame associée à l'AutoShape
auto presentation = System::MakeObject<Presentation>();

// Accède à la propriété ITextFrame associée à l'AutoShape
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute un objet AutoShape dont le type est Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Convertit la forme en AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Ajoute du texte au cadre
autoShape->AddTextFrame(u"");

// Accède à la propriété ITextFrame associée à l'AutoShape
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

**Quelle est la différence entre une zone de texte et un espace réservé de texte lorsqu’on travaille avec les diapositives maîtres ?**

Un [placeholder](/slides/fr/cpp/manage-placeholder/) hérite du style/position de la [master](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/), tandis qu’une zone de texte ordinaire est un objet indépendant sur une diapositive spécifique et ne change pas lorsque vous changez de layout.

**Comment effectuer un remplacement massif de texte dans la présentation sans toucher aux textes des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux formes automatiques possédant des cadres de texte et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.