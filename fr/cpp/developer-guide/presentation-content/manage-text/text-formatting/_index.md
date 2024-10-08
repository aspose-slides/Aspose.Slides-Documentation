---
title: Mise en Forme du Texte
type: docs
weight: 50
url: /fr/cpp/text-formatting/
keywords:
- mettre en surbrillance du texte
- expression régulière
- aligner les paragraphes de texte
- transparence du texte
- propriétés de la police des paragraphes
- famille de polices
- rotation du texte
- rotation d'angle personnalisé
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancre de cadre de texte
- tabulation de texte
- style de texte par défaut
- C++
- Aspose.Slides pour .C++
description: "Gérez et manipulez les propriétés du texte et du cadre de texte en C++"
---

## **Mettre en Surbrillance du Texte**
Une nouvelle méthode HighlightText a été ajoutée aux classes ITextFrame et TextFrame. Elle permet de mettre en surbrillance une partie du texte avec une couleur de fond en utilisant un échantillon de texte, similaire à l'outil de couleur de surbrillance de texte dans PowerPoint 2019.

Le fragment de code ci-dessous montre comment utiliser cette fonctionnalité :

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose propose un simple [service d'édition de PowerPoint en ligne](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Mettre en Surbrillance le Texte à l'aide d'une Expression Régulière**
Une nouvelle méthode HighlightRegex a été ajoutée aux classes ITextFrame et TextFrame. Elle permet de mettre en surbrillance une partie du texte avec une couleur de fond en utilisant une expression régulière, similaire à l'outil de couleur de surbrillance de texte dans PowerPoint 2019.

Le fragment de code ci-dessous montre comment utiliser cette fonctionnalité :

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Définir la Couleur de Fond du Texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière-plan d'un texte.

Ce code C++ vous montre comment définir la couleur de fond pour un texte entier :

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

Ce code C++ vous montre comment définir la couleur de fond pour seulement une partie d'un texte :

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

## **Aligner le Paragraphe de Texte**
La mise en forme du texte est l'un des éléments clés lors de la création de tout type de documents ou de présentations. Nous savons qu'Aspose.Slides pour C++ prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous allons voir comment nous pouvons contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides pour C++ :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de l'espace réservé présentes dans la diapositive et cast them as an AutoShape.
4. Obtenez le paragraphe (qui doit être aligné) à partir du TextFrame exposé par AutoShape.
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, centré ou justifié.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Définir la Transparence pour le Texte**
Cet article démontre comment définir la propriété de transparence à toute forme de texte à l'aide d'Aspose.Slides. Afin de définir la transparence pour le texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
2. Obtenez la référence d'une diapositive.
3. Définissez la couleur de l'ombre.
4. Écrivez la présentation sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Définir l'Espacement des Caractères pour le Texte**

Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. De cette manière, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en condensant l'espacement entre les caractères.

Ce code C++ vous montre comment élargir l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne :

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // élargir
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // condenser

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Gérer les Propriétés de la Police des Paragraphes**

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de différentes manières, soit pour mettre en avant des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. La mise en forme du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour C++ pour configurer les propriétés de la police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de la police d'un paragraphe à l'aide d'Aspose.Slides pour C++ :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez aux formes de l'espace réservé dans la diapositive et cast them to AutoShape.
1. Obtenez le paragraphe à partir du TextFrame exposé par AutoShape.
1. Justifiez le paragraphe.
1. Accédez à la portion de texte d'un paragraphe.
1. Définissez la police à l'aide de FontData et définissez la police de la portion de texte en conséquence.
   1. Définissez la police en gras.
   1. Définissez la police en italique.
1. Définissez la couleur de la police à l'aide de FillFormat exposé par l'objet Portion.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation non ornée et formate les polices sur l'une des diapositives.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Gérer la Famille de Polices du Texte**
Une portion est utilisée pour contenir du texte avec un style de mise en forme similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour C++ pour créer une zone de texte avec un texte et puis définir une police particulière, et diverses autres propriétés de la catégorie de famille de polices. Pour créer une zone de texte et définir les propriétés de la police du texte qui s'y trouve :

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez un AutoShape de type rectangle à la diapositive.
4. Supprimez le style de remplissage associé à l'AutoShape.
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé au TextFrame.
8. Définissez la police à utiliser pour la Portion.
9. Définissez d'autres propriétés de police comme en gras, en italique, souligné, couleur et hauteur à l'aide des propriétés pertinentes exposées par l'objet Portion.
10. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Définir la Taille de la Police pour le Texte**

Aspose.Slides vous permet de choisir la taille de police préférée pour le texte existant dans un paragraphe et d'autres textes qui peuvent être ajoutés au paragraphe par la suite.

Ce code C++ vous montre comment définir la taille de la police pour les textes contenus dans un paragraphe :

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Obtient la première forme, par exemple.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Obtient le premier paragraphe, par exemple.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Définit la taille de police par défaut à 20 pt pour toutes les portions de texte dans le paragraphe.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Définit la taille de police à 20 pt pour les portions de texte actuelles dans le paragraphe.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Définir la Rotation du Texte**

Aspose.Slides pour C++ permet aux développeurs de faire pivoter le texte. Le texte peut être défini pour apparaître de manière horizontale, verticale, verticale270, WordArtVertical, EastAsianVertical, MongolianVertical ou WordArtVerticalRightToLeft. Pour faire pivoter le texte d'un TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
2. Accédez à la première diapositive.
3. Ajoutez une forme quelconque à la diapositive.
4. Accédez au TextFrame.
5. Faites pivoter le texte.
6. Enregistrez le fichier sur disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Tabulations et EffectiveTabs dans la Présentation**
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs inclut toutes les tabulations (de la collection Tabs et des tabulations par défaut)
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) montre la distance entre les tabulations par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renverra la première tabulation explicite (Position = 731), index = 1 - deuxième tabulation (Position = 1241). Si vous essayez d'obtenir la tabulation suivante avec index = 2, elle renverra la première tabulation par défaut (Position = 1470) et ainsi de suite.
- EffectiveTabs.GetTabAfterPosition(pos) est utilisé pour obtenir la prochaine tabulation après un texte donné. Par exemple, vous avez le texte: "Helloworld!". Pour rendre ce texte, vous devez savoir où commencer à dessiner "world!". Au début, vous devez calculer la longueur de "Hello" en pixels et appeler GetTabAfterPosition avec cette valeur. Vous obtiendrez la prochaine position de tabulation pour dessiner "world!".

## **Interligne du Paragraphe**

Aspose.Slides fournit des propriétés sous `ParagraphFormat`—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—qui vous permettent de gérer l'interligne pour un paragraphe. Les trois propriétés sont utilisées de cette manière :

* Pour spécifier l'interligne pour un paragraphe en pourcentage, utilisez une valeur positive.
* Pour spécifier l'interligne pour un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16pt pour un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l'interligne pour un paragraphe spécifique :

1. Chargez une présentation contenant un AutoShape avec du texte.
2. Obtenez la référence d'une diapositive par son index.
3. Accédez au TextFrame.
4. Accédez au Paragraphe.
5. Définissez les propriétés du Paragraphe.
6. Enregistrez la présentation.

Ce code C++ vous montre comment spécifier l'interligne pour un paragraphe :

```cpp
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

// Créez une instance de la classe Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Obtenez la référence d'une diapositive par son index
auto sld = presentation->get_Slides()->idx_get(0);

// Accédez au TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Accédez au Paragraphe
auto para = tf1->get_Paragraphs()->idx_get(0);

// Définissez les propriétés du Paragraphe
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Enregistrez la Présentation
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```

## **Définir la Propriété AutofitType du Cadre de Texte**
Dans ce sujet, nous explorerons les différentes propriétés de mise en forme du cadre de texte. Cet article traite de la définition de la propriété AutofitType du cadre de texte, de l'ancrage du texte et de la rotation du texte dans la présentation. Aspose.Slides pour C++ permet aux développeurs de définir la propriété AutofitType de tout cadre de texte. AutofitType peut être défini sur Normal ou Shape. S'il est défini sur Normal, la forme restera la même tandis que le texte sera ajusté sans que la forme elle-même ne change. En revanche, si AutofitType est défini sur Shape, alors la forme sera modifiée de manière à ne contenir que le texte nécessaire. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
2. Accédez à la première diapositive.
3. Ajoutez une forme quelconque à la diapositive.
4. Accédez au TextFrame.
5. Définissez le AutofitType du TextFrame.
6. Enregistrez le fichier sur disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Définir l'Ancre du TextFrame**
Aspose.Slides pour C++ permet aux développeurs de définir l'ancre de tout TextFrame. TextAnchorType spécifie où ce texte est placé dans la forme. TextAnchorType peut être défini sur Top, Center, Bottom, Justified ou Distributed. Pour définir l'ancre de tout TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
2. Accédez à la première diapositive.
3. Ajoutez une forme quelconque à la diapositive.
4. Accédez au TextFrame.
5. Définissez le TextAnchorType du TextFrame.
6. Enregistrez le fichier sur disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Définir un Angle de Rotation Personnalisé pour le TextFrame**
Aspose.Slides pour C++ prend maintenant en charge la définition d'un angle de rotation personnalisé pour le cadre de texte. Dans ce sujet, nous allons voir avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. La nouvelle propriété RotationAngle a été ajoutée aux interfaces IChartTextBlockFormat et ITextFrameFormat, permettant de définir l'angle de rotation personnalisé pour le cadre de texte. Afin de définir la propriété RotationAngle, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
2. Ajoutez un graphique sur la diapositive.
3. Définissez la propriété RotationAngle.
4. Écrivez la présentation sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous définissons la propriété RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Définir la Langue de Révision**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) pour vous permettre de définir la langue de révision pour un document PowerPoint. La langue de révision est la langue pour laquelle l'orthographe et la grammaire dans le PowerPoint sont vérifiées.

Ce code C++ vous montre comment définir la langue de révision pour un PowerPoint :

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
// définir l'Id d'une langue de révision

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Définir la Langue Par Défaut**

Ce code C++ vous montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Ajoute une nouvelle forme rectangulaire avec du texte
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Nouveau Texte");

// Vérifie la langue de la première portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Définir le Style de Texte Par Défaut**

Si vous avez besoin d'appliquer le même formatage de texte par défaut à tous les éléments de texte d'une présentation à la fois, vous pouvez utiliser la méthode `get_DefaultTextStyle` de l'interface [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) pour définir le formatage préféré. L'exemple de code ci-dessous montre comment définir la police en gras par défaut (14 pt) pour le texte de toutes les diapositives dans une nouvelle présentation.

```c++
auto presentation = MakeObject<Presentation>();

// Obtenez le format de paragraphe de niveau supérieur.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```