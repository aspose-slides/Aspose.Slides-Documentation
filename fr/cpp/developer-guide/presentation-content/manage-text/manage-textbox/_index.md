---
title: Gérer les TextBox
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords: "Textbox, Cadre texte, Ajouter textbox, Textbox avec lien, C++, Aspose.Slides pour C++"
description: "Ajouter un textbox ou un cadre texte aux présentations PowerPoint en C++"
---

Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter un texte à une diapositive, vous devez ajouter une zone de texte puis y insérer du texte. Aspose.Slides pour C++ fournit l'interface [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) qui permet d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Mais les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) peuvent contenir du texte. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous traitez avec une forme à laquelle vous souhaitez ajouter du texte, vous voudrez peut-être vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), qui est une propriété de `IAutoShape`. Voir la section [Mettre à jour le texte](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) sur cette page. 

{{% /alert %}}

## **Créer une zone de texte sur la diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. Obtenez une référence pour la première diapositive dans la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) avec [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet `IAutoShape` nouvellement ajouté. 
4. Ajoutez une propriété `TextFrame` à l'objet `IAutoShape` qui contiendra un texte. Dans l'exemple ci-dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code C++—une implémentation des étapes ci-dessus—vous montre comment ajouter du texte à une diapositive :

```cpp
// Instancie Presentation
auto pres = System::MakeObject<Presentation>();

// Obtient la première diapositive dans la présentation
auto sld = pres->get_Slides()->idx_get(0);

// Ajoute une AutoShape avec le type défini comme Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Ajoute TextFrame au Rectangle
ashp->AddTextFrame(u" ");

// Accède au cadre texte
auto txtFrame = ashp->get_TextFrame();

// Crée l'objet Paragraphe pour le cadre de texte
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Crée un objet Portion pour le paragraphe
auto portion = para->get_Portions()->idx_get(0);

// Définit le texte
portion->set_Text(u"Aspose TextBox");

// Enregistre la présentation sur le disque
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Vérifier si une forme est une zone de texte**

Aspose.Slides fournit la méthode [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (de la classe [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/)) pour vous permettre d'examiner les formes et de trouver des zones de texte.

![Zone de texte et forme](istextbox.png)

Ce code C++ vous montre comment vérifier si une forme a été créée comme une zone de texte : 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"la forme est une zone de texte") : System::String(u"la forme n'est pas une zone de texte"));
        }
    }
}
```

## **Ajouter une colonne dans une zone de texte**

Aspose.Slides fournit les méthodes [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) et [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) qui vous permettent d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir la quantité d'espacement en points entre les colonnes. 

Ce code en C++ démontre l'opération décrite : 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Obtient la première diapositive dans la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute une AutoShape avec le type défini comme Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Ajoute TextFrame au Rectangle
aShape->AddTextFrame(String(u"Tous ces colonnes sont limitées à être dans un seul conteneur de texte -- ") 
    + u"vous pouvez ajouter ou supprimer du texte et le nouveau texte ou le texte restant s'ajuste automatiquement " 
    + u"pour s'écouler dans le conteneur. Vous ne pouvez pas faire s'écouler le texte d'un conteneur " 
    + u"à un autre cependant -- nous vous avons dit que les options de colonnes de PowerPoint pour le texte sont limitées !");

// Obtient le format texte de TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Spécifie le nombre de colonnes dans TextFrame
format->set_ColumnCount(3);

// Spécifie l'espacement entre les colonnes
format->set_ColumnSpacing(10);

// Enregistre la présentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Ajouter une colonne dans un cadre de texte**
Aspose.Slides pour C++ fournit la méthode [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) qui vous permet d'ajouter des colonnes dans des cadres de texte. Grâce à cette méthode, vous pouvez spécifier votre nombre de colonnes préféré dans un cadre de texte. 

Ce code C++ vous montre comment ajouter une colonne à l'intérieur d'un cadre de texte :

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"Tous ces colonnes sont forcées de rester à l'intérieur d'un seul conteneur de texte -- ") 
    + u"vous pouvez ajouter ou supprimer du texte - et le nouveau texte ou le texte restant s'ajuste automatiquement " 
    + u"pour rester à l'intérieur du conteneur. Vous ne pouvez pas avoir du texte qui déborde d'un conteneur " 
    + u"à un autre, cependant -- car les options de colonnes de PowerPoint pour le texte sont limitées !");
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

Aspose.Slides vous permet de changer ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes contenus dans une présentation. 

Ce code C++ démontre une opération où tous les textes dans une présentation sont mis à jour ou changés :

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
                    //Change le texte
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Change le formatage
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Enregistre la présentation modifiée
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Ajouter une zone de texte avec un lien hypertexte** 

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont redirigés pour ouvrir le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence pour la première diapositive dans la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Assignez l'objet `IHyperlinkManager` à la méthode [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) associée à votre portion préférée du `TextFrame`. 
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code C++—une implémentation des étapes ci-dessus—vous montre comment ajouter une zone de texte avec un lien hypertexte à une diapositive :

```cpp
// Instancie une classe Presentation qui représente un PPTX
auto presentation = System::MakeObject<Presentation>();

// Obtient la première diapositive dans la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute un objet AutoShape avec le type défini comme Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Cast la forme en AutoShape
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