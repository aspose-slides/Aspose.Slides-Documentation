---
title: Mise en forme du texte PowerPoint en C++
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/cpp/text-formatting/
keywords:
- surlignage de texte
- expression régulière
- alignement du paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété autofit
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---

## **Mettre en évidence le texte**
La nouvelle méthode HighlightText a été ajoutée aux classes ITextFrame et TextFrame. Elle permet de mettre en évidence une partie du texte avec une couleur d’arrière‑plan en utilisant un échantillon de texte, similaire à l’outil Couleur de mise en évidence du texte dans PowerPoint 2019.

L’extrait de code ci‑dessous montre comment utiliser cette fonctionnalité :

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose propose un service [gratuit d’édition en ligne de PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Mettre en évidence le texte avec des expressions régulières**
La nouvelle méthode HighlightRegex a été ajoutée aux classes ITextFrame et TextFrame. Elle permet de mettre en évidence une partie du texte avec une couleur d’arrière‑plan en utilisant une expression régulière, similaire à l’outil Couleur de mise en évidence du texte dans PowerPoint 2019.

L’extrait de code ci‑dessous montre comment utiliser cette fonctionnalité :

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Définir la couleur d’arrière‑plan du texte**

Aspose.Slides vous permet de spécifier la couleur de votre choix pour l’arrière‑plan d’un texte.

Ce code C++ montre comment définir la couleur d’arrière‑plan pour un texte entier :
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


Ce code C++ montre comment définir la couleur d’arrière‑plan pour seulement une partie d’un texte :
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"Red");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


## **Aligner les paragraphes de texte**
Le formatage du texte est l’un des éléments clés lors de la création de documents ou de présentations. Nous savons qu’Aspose.Slides pour C++ prend en charge l’ajout de texte aux diapositives, mais dans cet article, nous verrons comment contrôler l’alignement des paragraphes de texte dans une diapositive. Suivez les étapes ci‑dessous pour aligner les paragraphes de texte avec Aspose.Slides pour C++ :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Accédez aux formes de type Placeholder présentes dans la diapositive et castpez‑les en AutoShape.
4. Récupérez le paragraphe (à aligner) depuis le TextFrame exposé par l’AutoShape.
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, au centre ou justifié.
6. Enregistrez la présentation modifiée au format PPTX.

L’implémentation de ces étapes est présentée ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Définir la transparence du texte**
Cet article montre comment définir la propriété de transparence sur n’importe quelle forme de texte à l’aide d’Aspose.Slides. Pour appliquer la transparence au texte, suivez les étapes ci‑dessous :

1. Créez une instance de la classe Presentation.
2. Obtenez la référence d’une diapositive.
3. Définissez la couleur de l’ombre.
4. Enregistrez la présentation au format PPTX.

L’implémentation de ces étapes est présentée ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Définir l’espacement entre les caractères du texte**

Aspose.Slides vous permet de définir l’espace entre les lettres d’une zone de texte. Ainsi, vous pouvez ajuster la densité visuelle d’une ligne ou d’un bloc de texte en élargissant ou en contractant l’espacement entre les caractères.

Ce code C++ montre comment élargir l’espacement pour une ligne de texte et le réduire pour une autre ligne :
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // étendre
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // condenser

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Gérer les propriétés de police du texte**

Les présentations contiennent généralement du texte et des images. Le texte peut être formaté de diverses manières, que ce soit pour mettre en évidence des sections spécifiques ou pour respecter les styles corporatifs. Le formatage du texte aide les utilisateurs à varier l’apparence du contenu de la présentation. Cet article explique comment utiliser Aspose.Slides pour C++ afin de configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d’un paragraphe avec Aspose.Slides pour C++ :

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Accédez aux formes de type Placeholder dans la diapositive et castpez‑les en AutoShape.
4. Récupérez le paragraphe depuis le TextFrame exposé par l’AutoShape.
5. Justifiez le paragraphe.
6. Accédez à la Portion de texte du paragraphe.
7. Définissez la police à l’aide de FontData et appliquez‑la à la Portion.
   1. Mettez la police en gras.
   2. Mettez la police en italique.
8. Définissez la couleur de la police à l’aide du FillFormat exposé par l’objet Portion.
9. Enregistrez la présentation modifiée au format PPTX.

L’implémentation de ces étapes est présentée ci‑dessous. Elle prend une présentation vierge et formate les polices sur l’une des diapositives.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Gérer la famille de police du texte**
Une *portion* est utilisée pour regrouper du texte avec un même style de formatage dans un paragraphe. Cet article montre comment, avec Aspose.Slides pour C++, créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de police. Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Ajoutez à la diapositive une AutoShape de type Rectangle.
4. Supprimez le style de remplissage associé à l’AutoShape.
5. Accédez au TextFrame de l’AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l’objet Portion associé au TextFrame.
8. Définissez la police à utiliser pour la Portion.
9. Définissez d’autres propriétés de police comme gras, italique, souligné, couleur et taille à l’aide des propriétés correspondantes de l’objet Portion.
10. Enregistrez la présentation modifiée au format PPTX.

L’implémentation de ces étapes est présentée ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Définir la taille de police du texte**

Aspose.Slides vous permet de choisir la taille de police souhaitée pour le texte existant d’un paragraphe ainsi que pour les textes qui pourraient être ajoutés ultérieurement.

Ce code C++ montre comment définir la taille de police pour les textes contenus dans un paragraphe :
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Obtient la première forme, par exemple.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Obtient le premier paragraphe, par exemple.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Définit la taille de police par défaut à 20 pt pour toutes les portions de texte du paragraphe.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Définit la taille de police à 20 pt pour les portions de texte actuelles du paragraphe.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Définir la rotation du texte**

Aspose.Slides pour C++ permet aux développeurs de faire pivoter le texte. Le texte peut être affiché Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical ou WordArtVerticalRightToLeft. Pour faire pivoter le texte d’un quelconque TextFrame, suivez les étapes ci‑dessus :

1. Créez une instance de la classe `Presentation`.
2. Accédez à la première diapositive.
3. Ajoutez n’importe quelle forme à la diapositive.
4. Accédez au TextFrame.
5. Faites pivoter le texte.
6. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Tabulations et Tabulations effectives dans une présentation**
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs comprend toutes les tabulations (de la collection Tabs et les tabulations par défaut).
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) indique la distance entre les tabulations par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renvoie la première tabulation explicite (Position = 731), index = 1 la seconde (Position = 1241). Un appel avec index = 2 renvoie la première tabulation par défaut (Position = 1470), etc.
- EffectiveTabs.GetTabAfterPosition(pos) permet d’obtenir la tabulation suivante après un certain texte. Par exemple, pour le texte « Helloworld! », pour rendre ce texte il faut connaître le point de départ du mot « world! ». D’abord, calculez la longueur de « Hello » en pixels puis appelez GetTabAfterPosition avec cette valeur. Vous obtiendrez la position de la prochaine tabulation pour dessiner « world! ».

## **Interligne d’un paragraphe**

Aspose.Slides propose les propriétés `ParagraphFormat` — `SpaceAfter`, `SpaceBefore` et `SpaceWithin` — qui permettent de gérer l’interligne d’un paragraphe. Elles s’utilisent ainsi :

* Pour spécifier l’interligne en pourcentage, utilisez une valeur positive.  
* Pour spécifier l’interligne en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l’interligne pour un paragraphe donné :

1. Chargez une présentation contenant une AutoShape avec du texte.
2. Obtenez la référence d’une diapositive par son index.
3. Accédez au TextFrame.
4. Accédez au Paragraph.
5. Définissez les propriétés du Paragraph.
6. Enregistrez la présentation.

Ce code C++ montre comment spécifier l’interligne d’un paragraphe :
```cpp
// Le chemin du répertoire des documents.
System::String dataDir = GetDataPath();

// Créez une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Obtenez la référence d'une diapositive par son index
auto sld = presentation->get_Slides()->idx_get(0);

// Accédez au TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Accédez au paragraphe
auto para = tf1->get_Paragraphs()->idx_get(0);

// Définissez les propriétés du paragraphe
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Enregistrez la présentation
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **Définir la propriété AutofitType d’un TextFrame**
Dans cet article, nous explorons les différentes propriétés de formatage d’un texte. Nous expliquons comment définir la propriété AutofitType d’un TextFrame, l’ancrage du texte et la rotation du texte dans une présentation. Aspose.Slides pour C++ permet de définir la propriété AutofitType de n’importe quel TextFrame. AutofitType peut être réglé sur Normal ou Shape. Si elle est réglée sur Normal, la forme reste identique tandis que le texte est ajusté sans modifier la forme ; si elle est réglée sur Shape, la forme est modifiée de façon à ne contenir que le texte requis. Pour définir la propriété AutofitType d’un TextFrame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe Presentation.
2. Accédez à la première diapositive.
3. Ajoutez n’importe quelle forme à la diapositive.
4. Accédez au TextFrame.
5. Définissez l’AutofitType du TextFrame.
6. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Définir l’ancrage d’un TextFrame**
Aspose.Slides pour C++ permet de définir l’ancrage d’un TextFrame. TextAnchorType indique où le texte est placé dans la forme. TextAnchorType peut être défini sur Top, Center, Bottom, Justified ou Distributed. Pour définir l’ancrage d’un TextFrame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe `Presentation`.
2. Accédez à la première diapositive.
3. Ajoutez n’importe quelle forme à la diapositive.
4. Accédez au TextFrame.
5. Définissez le TextAnchorType du TextFrame.
6. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Définir l’angle de rotation personnalisé d’un TextFrame**
Aspose.Slides pour C++ prend désormais en charge la définition d’un angle de rotation personnalisé pour un TextFrame. Dans cet article, nous montrons avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. La nouvelle propriété RotationAngle a été ajoutée aux interfaces IChartTextBlockFormat et ITextFrameFormat, et permet de définir l’angle de rotation personnalisé d’un TextFrame. Pour définir la propriété RotationAngle, suivez les étapes ci‑dessous :

1. Créez une instance de la classe Presentation.
2. Ajoutez un graphique à la diapositive.
3. Définissez la propriété RotationAngle.
4. Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous définissons la propriété RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Définir la langue de vérification orthographique**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) pour permettre de définir la langue de vérification orthographique d’un document PowerPoint. La langue de vérification est celle pour laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code C++ montre comment définir la langue de vérification orthographique pour un PowerPoint :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **Définir la langue par défaut**

Ce code C++ montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Ajoute une nouvelle forme rectangle avec du texte
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Vérifie la langue de la première portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Définir le style de texte par défaut**

Si vous devez appliquer le même formatage de texte par défaut à tous les éléments texte d’une présentation en une fois, vous pouvez utiliser la méthode `get_DefaultTextStyle` de l’interface [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) et définir le formatage souhaité. L’exemple de code ci‑dessous montre comment définir la police par défaut en gras (14 pt) pour le texte de toutes les diapositives d’une nouvelle présentation.
```c++
auto presentation = MakeObject<Presentation>();

// Récupérer le format de paragraphe de niveau supérieur.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Extraire le texte avec l’effet Tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) — si elle indique `All`, convertissez simplement la chaîne retournée en majuscules afin que votre sortie corresponde à ce que voit l’utilisateur sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![The All Caps effect](all_caps_effect.png)

 L’exemple de code ci‑dessous montre comment extraire le texte avec l’effet **All Caps** appliqué :
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


Sortie :
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Comment modifier le texte d’un tableau sur une diapositive ?**

Pour modifier le texte d’un tableau sur une diapositive, vous devez utiliser l’objet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Vous pouvez parcourir toutes les cellules du tableau et modifier le texte de chaque cellule en accédant à son cadre texte et à ses propriétés de format de paragraphe.

**Comment appliquer un dégradé de couleur au texte d’une diapositive PowerPoint ?**

Pour appliquer un dégradé de couleur au texte, utilisez la méthode `get_FillFormat` de [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/). Définissez le format de remplissage sur `Gradient`, où vous pouvez spécifier les couleurs de départ et d’arrivée du dégradé ainsi que d’autres propriétés telles que la direction et la transparence pour créer l’effet dégradé sur le texte.