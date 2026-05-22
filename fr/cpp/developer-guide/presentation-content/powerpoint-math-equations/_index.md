---
title: Ajouter des équations mathématiques aux présentations PowerPoint en C++
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/cpp/powerpoint-math-equations/
keywords:
- équation mathématique
- symbole mathématique
- formule mathématique
- texte mathématique
- ajouter une équation mathématique
- ajouter un symbole mathématique
- ajouter une formule mathématique
- ajouter un texte mathématique
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides for C++, prenant en charge OMML, les contrôles de formatage, et des exemples de code C++ clairs."
---
## **Aperçu**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides for C++, vous pouvez créer le même type de contenu mathématique de façon programmatique : fractions, radicaux, fonctions, limites, opérateurs N‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent normalement les équations via **Insertion > Équation** :

![Onglet Insertion de PowerPoint avec la commande Équation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique modifiable sur la diapositive :

![Une diapositive PowerPoint contenant une équation mathématique modifiable](powerpoint-math-equations_2.png)

Aspose.Slides construit ce texte mathématique à l’aide de trois objets principaux :

- Une forme mathématique, créée avec [AddMathShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapecollection/), est la forme qui contient l’équation.
- [MathPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathportion/) stocke le contenu mathématique à l’intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathblock/).

La plupart des exemples ci‑dessous utilisent [MathematicalText](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathematicaltext/) et les méthodes fluentes de [IMathElement](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/) pour garder le code court et lisible.

Pour les scénarios d’exportation MathML, consultez [Export Math Equations from Presentations in C++](/slides/fr/cpp/exporting-math-equations/).

## **Créer une équation**

Cet exemple crée une forme mathématique et ajoute le théorème de Pythagore :

![L’équation c carré égale a carré plus b carré](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier `MathPortion`, récupérez son `MathParagraph` et ajoutez‑y des blocs ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez `Divide` pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathfractiontypes/).

![Une fraction mathématique inclinée montrant un divisé par x](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour une fraction empilée, utilisez `MathFractionTypes::Bar` :

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Ajouter des radicaux**

Utilisez `Radical` pour créer une racine carrée, une racine cubique ou toute autre racine. L’élément actuel devient la base et l’argument devient le degré.

![Une expression radiculaire n‑ième racine avec x sous le signe radical](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter des fonctions et des limites**

Utilisez `AsArgumentOfFunction` ou `Function` pour des fonctions telles que `sin(x)`, `log(x)` ou des noms de fonctions personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathlimit/) ou utilisez `SetLowerLimit`.

![La limite de x lorsque x tend vers l’infini](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour un nom de fonction personnalisé, faites du nom de la fonction l’élément actuel :

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Ajouter des opérateurs N‑aires et des intégrales**

Utilisez `Nary` pour les sommes, les unions, les intersections et autres grands opérateurs. Utilisez `Integral` pour les intégrales. Les deux méthodes permettent de définir les limites inférieure et supérieure.

![Une sommation avec limites inférieure et supérieure](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Les opérateurs N‑aires sont destinés aux grands opérateurs avec limites optionnelles. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés en tant que `MathematicalText` et concaténés dans l’expression.

Pour une intégrale, utilisez `Integral` :

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathmatrix/) pour les lignes et colonnes. Les matrices n’incluent pas de crochets par défaut, il faut donc les encadrer vous‑même si vous avez besoin de parenthèses, de crochets ou d’accolades.

![Une matrice mathématique à deux lignes avec une cellule vide](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter des tableaux d’équations**

Utilisez `ToMathArray` lorsque vous avez besoin d’équations alignées ou d’une pile verticale d’expressions.

![Un tableau mathématique vertical avec x au-dessus de y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter des fonctions trigonométriques**

Utilisez `AsArgumentOfFunction` lorsque l’argument est l’élément actuel et que le nom de la fonction est connu.

![La fonction trigonométrique cos appliquée à 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter des indices et des exposants**

Utilisez les assistants d’indice et d’exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez `SetSubSuperscriptOnTheLeft`.

![Un Y majuscule avec l’indice gauche 1 et l’exposant n](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter des délimiteurs**

Utilisez `Enclose` pour placer une expression entre délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitantes contenant plusieurs éléments.

![Une expression délimitée contenant x, y et z séparés par des barres verticales](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajouter une boîte de bordure**

Utilisez `ToBorderBox` lorsque l’équation elle‑même doit être encadrée.

![Une équation encadrée montrant a carré égal b carré plus c carré](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Regrouper des termes**

Utilisez `Group` pour placer un caractère de regroupement au-dessus ou en dessous d’une expression. Ajoutez une limite pour étiqueter les termes regroupés.

![L’expression x plus y regroupée avec l’étiquette texte quelconque en dessous](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Formater les éléments mathématiques**

Utilisez les assistants de formatage uniquement lorsque cela clarifie la formule. Par exemple, `Overbar` place une barre au‑dessus d’un élément mathématique.

![Une expression mathématique ABC avec une barre supérieure](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Combiner des éléments | [IMathElement.Join](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/join/) |
| Créer des fractions | [IMathElement.Divide](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Ajouter un exposant ou un indice | [SetSuperscript](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Ajouter des fonctions | [Function](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Ajouter des radicaux | [IMathElement.Radical](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Ajouter des limites | [SetLowerLimit](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Ajouter des scripts côté gauche | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Ajouter des sommes et des intégrales | [Nary](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathmatrix/) |
| Ajouter des tableaux d’équations | [ToMathArray](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Ajouter des délimiteurs | [Enclose](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Ajouter des barres et des bordures | [Overbar](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Regrouper des termes | [Group](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Puis‑je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un `MathPortion`, récupérez son `MathParagraph` et mettez à jour les blocs mathématiques de ce paragraphe.

**Les équations sont‑elles enregistrées comme du math auto‑éditable de PowerPoint ?**

Oui. Lors de l’enregistrement au format PPTX, Aspose.Slides écrit l’équation comme du contenu mathématique Office modifiable.

**Puis‑je exporter les équations vers LaTeX ?**

Aspose.Slides exporte les équations mathématiques vers MathML. Si vous avez besoin de LaTeX, exportez d’abord vers MathML puis convertissez le MathML avec un outil qui prend en charge le dialecte LaTeX cible.