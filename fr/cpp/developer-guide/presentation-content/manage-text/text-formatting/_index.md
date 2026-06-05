---
title: "Formater le texte de la présentation en C++"
linktitle: "Mise en forme du texte"
type: docs
weight: 50
url: /fr/cpp/text-formatting/
keywords:
- "mise en évidence du texte"
- "expression régulière"
- "aligner le paragraphe"
- "style du texte"
- "arrière-plan du texte"
- "transparence du texte"
- "espacement des caractères"
- "propriétés de police"
- "famille de police"
- "rotation du texte"
- "angle de rotation"
- "cadre de texte"
- "interligne"
- "propriété d’ajustement automatique"
- "ancrage du cadre de texte"
- "tabulation du texte"
- "langue par défaut"
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour C++. Personnalisez les polices, les couleurs, l’alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l'aide d’Aspose.Slides pour C++. Il couvre la mise en évidence, les couleurs d’arrière-plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les arrêts de tabulation et les paramètres de langue.

Dans les exemples ci‑dessous, nous utilisons un fichier nommé **sample.pptx**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Mettre en évidence du texte**

Utilisez la méthode [ITextFrame.HighlightText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlighttext/) lorsque vous devez mettre en évidence le texte correspondant à un échantillon spécifique dans un cadre de texte. La méthode applique une couleur de surbrillance aux fragments de texte correspondants et peut être utilisée avec [ITextSearchOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/) pour contrôler la façon dont la recherche est effectuée, par exemple pour ne correspondre qu’aux mots entiers.

L’exemple de code ci‑dessous met en évidence toutes les occurrences des caractères **"try"** puis ne met en évidence que le mot complet **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Obtenir la première forme de la première diapositive.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Mettre en évidence le mot "try" dans la forme.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Mettre en évidence le mot "to" dans la forme.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le texte mis en évidence](highlighted_text.png)

## **Mettre en évidence du texte à l’aide d’expressions régulières**

La méthode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlightregex/) met en évidence les correspondances de texte trouvées par une expression régulière. En C++, cette API est exposée sur [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/).

L’exemple de code ci‑dessous met en évidence tous les mots contenant **sept caractères ou plus** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le texte mis en évidence à l’aide de l’expression régulière](highlighted_text_using_regex.png)

## **Définir la couleur d’arrière‑plan du texte**

Utilisez [IParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)`.HighlightColor` pour des portions de texte individuelles.

L’exemple de code suivant montre comment définir la couleur d’arrière‑plan pour le **paragraphe entier** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour les **portions de texte en gras** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Définir la couleur de surbrillance pour la portion de texte.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/)`.Alignment` pour définir l’alignement du paragraphe à l’intérieur d’un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L’exemple de code suivant montre comment aligner le paragraphe **au centre** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Définir l'alignement du paragraphe au centre.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur attribuée à [IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)`.FillFormat`. Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur une échelle de 0 à 255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence au **paragraphe entier** :

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Définir la couleur de remplissage du texte en couleur transparente.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Définir la transparence de la portion de texte.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l’espacement des caractères du texte**

Utilisez [IBasePortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/)`.Spacing` pour élargir ou réduire l’espacement entre les caractères dans une zone de texte.

Le code C++ suivant montre comment élargir l’espacement des caractères dans le **paragraphe entier** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Remarque: Utilisez des valeurs négatives pour compresser l'espacement des caractères.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment élargir l’espacement des caractères dans les **portions de texte en gras** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Remarque: Utilisez des valeurs négatives pour compresser l'espacement des caractères.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu se rapproche de PowerPoint dans de tels cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` à une valeur nettement supérieure à la taille réelle de la police :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ce paramètre empêche l’application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement propre à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)`.

Le code suivant définit la police et le style du texte pour le **paragraphe entier** : il applique la taille de police, le gras, l’italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Définir les propriétés de police pour le paragraphe.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Définir les propriétés de police pour la portion de texte.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` pour définir une orientation de texte prédéfinie dans une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/)`.RotationAngle` pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/).

L’exemple de code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens horaire à l’intérieur de la forme :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![La rotation de texte personnalisée](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides fournit [IParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` et `IParagraphFormat.SpaceWithin` pour contrôler l’espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple de code suivant montre comment spécifier l’interligne au sein du paragraphe :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![L’interligne dans le paragraphe](line_spacing.png)

## **Définir le type d’ajustement automatique pour les cadres de texte**

[ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/)`.AutofitType` détermine le comportement du texte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se réduit, dépasse ou redimensionne la forme automatiquement.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Définir l’ancrage des cadres de texte**

[ITextFrameFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframeformat/)`.AnchoringType` définit la façon dont le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au centre ou en bas.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Définir la tabulation du texte**

Utilisez [IParagraphFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` et `IParagraphFormat.Tabs` pour configurer les arrêts de tabulation dans un paragraphe.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)`.LanguageId`, qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L’exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Définir l'identifiant de la langue de vérification.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Définir la langue par défaut**

Utilisez [ILoadOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Ajouter une nouvelle forme rectangulaire avec du texte.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Vérifier la langue de la première portion.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [IPresentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

L’exemple de code suivant montre comment définir une police par défaut en gras avec une taille de 14 pt pour tout le texte des diapositives dans une nouvelle présentation.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Obtenir le format de paragraphe de niveau supérieur.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extraire du texte avec l’effet Tout en majuscules**

Dans PowerPoint, l’application de l’effet de police **Tout en majuscules** affiche le texte en majuscules sur la diapositive même s’il a été tapé en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour obtenir le texte affiché, examinez [TextCapType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier **sample2.pptx**.

![L’effet Tout en majuscules](all_caps_effect.png)

L’exemple de code ci‑dessus montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icell/)`.TextFrame` ainsi que le formatage des paragraphes via [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/)`.FillFormat`. Définissez [IFillFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformat/)`.FillType` sur [FillType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/filltype/)`.Gradient` et configurez les arrêts du dégradé, la direction et la transparence.