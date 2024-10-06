---
title: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /cpp/powerpoint-math-equations/
keywords: " Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint"
description: "Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint"
---

## **Aperçu**
Dans PowerPoint, il est possible d'écrire une équation ou une formule mathématique et de l'afficher dans la présentation. Pour ce faire, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l'équation. Pour cela, le constructeur d'équations mathématiques est utilisé dans PowerPoint, qui aide à créer des formules complexes telles que :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations N-aires
- Matrice
- Grands opérateurs
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insérer -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Ceci va créer un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit : 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations mathématiques. Cependant, créer des équations mathématiques compliquées dans PowerPoint ne produit souvent pas un résultat bon et professionnel. Les utilisateurs, qui ont besoin de créer fréquemment des présentations mathématiques, recourent à des solutions tierces pour créer de bonnes formules mathématiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de manière programmatique en C++. Créez de nouvelles expressions mathématiques ou modifiez celles qui ont été précédemment créées. L'exportation de structures mathématiques en images est également partiellement supportée.


## **Comment Créer une Équation Mathématique**
Les éléments mathématiques sont utilisés pour construire des constructions mathématiques de tout niveau de nestage. Une collection linéaire d'éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block). La classe [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) est essentiellement une expression mathématique, formule ou équation séparée. [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) est une portion mathématique, utilisée pour contenir du texte mathématique (ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). La classe [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) permet de manipuler un ensemble de blocs mathématiques. Les classes susmentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l'API Aspose.Slides.



Voyons comment nous pouvons créer l'équation mathématique suivante via l'API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, d'abord, ajoutez une forme qui contiendra le texte mathématique :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 


Après la création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) est une portion qui contient un texte mathématique à l'intérieur. Pour accéder au contenu mathématique à l'intérieur de [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion), référez-vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) :

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 


La classe [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) permet de lire, ajouter, éditer et supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), qui se composent d'une combinaison d'éléments mathématiques. Par exemple, créez une fraction et placez-la dans la présentation :

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 


Chaque élément mathématique est représenté par une certaine classe qui implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression mathématique complexe avec une seule ligne de code. Par exemple, le théorème de Pythagore aurait l'apparence suivante :

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 



Les opérations de l'interface [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) sont mises en œuvre dans n'importe quel type d'élément, y compris le [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

Le code source complet :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 


## **Types d'Éléments Mathématiques**
Les expressions mathématiques sont formées à partir de séquences d'éléments mathématiques. La séquence d'éléments mathématiques est représentée par un bloc mathématique, et les arguments des éléments mathématiques forment un nestage en forme d'arbre.

Il existe de nombreux types d'éléments mathématiques qui peuvent être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être inclus (agrégé) dans un autre élément. C'est-à-dire que les éléments sont en réalité des conteneurs pour d'autres, formant une structure en forme d'arbre. Le type d'élément le plus simple ne contient pas d'autres éléments du texte mathématique.

Chaque type d'élément mathématique implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element), permettant l'utilisation d'un ensemble commun d'opérations mathématiques sur différents types d'éléments mathématiques.
### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) représente un texte mathématique - l'élément sous-jacent de toutes les constructions mathématiques. Un texte mathématique peut représenter des opérandes et des opérateurs, des variables et tout autre texte linéaire.

Exemple: 𝑎=𝑏+𝑐
### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) spécifie l'objet fraction, constitué d'un numérateur et d'un dénominateur séparés par une barre de fraction. La barre de fraction peut être horizontale ou diagonale, selon les propriétés de la fraction. L'objet fraction est également utilisé pour représenter la fonction de pile, qui place un élément au-dessus d'un autre, sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) spécifie la fonction radicale (racine mathématique), consistant en une base et un degré facultatif.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) spécifie une fonction d'un argument. Elle contient des méthodes : [get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) - nom de la fonction et [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) spécifie un objet mathématique N-aire, tel que Somme et Intégrale. Il se compose d'un opérateur, d'une base (ou opérande), et de limites supérieures et inférieures facultatives. Les exemples d'opérateurs N-aires sont Somme, Union, Intersection, Intégrale.

Cette classe n'inclut pas les opérateurs simples tels que l'addition, la soustraction, etc. Ils sont représentés par un élément de texte unique - [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) crée la limite supérieure ou inférieure. Elle spécifie l'objet limite, constitué de texte sur la ligne de base et d'un texte de taille réduite immédiatement au-dessus ou au-dessous. Cet élément n'inclut pas le mot "lim", mais permet de placer du texte en haut ou en bas de l'expression. Ainsi, l'expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée en utilisant une combinaison des éléments [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) et [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) de cette manière :

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 


### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

Les classes suivantes spécifient un index inférieur ou un index supérieur. Vous pouvez définir un exposant et un indice à la fois à gauche ou à droite d'un argument, mais un seul exposant ou indice est pris en charge du côté droit seulement. Le [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) spécifie l'objet Matrice, constitué d'éléments enfants disposés en une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n'ont pas de délimiteurs intégrés. Pour placer la matrice dans les crochets, vous devez utiliser l'objet délimiteur - [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) spécifie un tableau vertical d'équations ou d'objets mathématiques.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatage des Éléments Mathématiques**
- La classe [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box) : dessine une bordure rectangulaire ou d'une autre forme autour de [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La classe [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box) : spécifie l'encadrement logique (packaging) de l'élément mathématique. Par exemple, un objet encadré peut servir d'émulateur d'opérateur avec ou sans point d'alignement, servir de point de rupture de ligne, ou être groupé pour ne pas permettre des interruptions de ligne à l'intérieur. Par exemple, l'opérateur "==" doit être encadré pour empêcher les ruptures de ligne.
- La classe [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter) : spécifie l'objet délimiteur, constitué de caractères d'ouverture et de fermeture (comme des parenthèses, des accolades, des crochets et des barres verticales), et un ou plusieurs éléments mathématiques à l'intérieur, séparés par un caractère spécifié. Exemples: (𝑥2); [𝑥2|𝑦2].
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La classe [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent) : spécifie la fonction accent, constituée d'une base et d'une marque diacritique combinante. 

  Exemple : 𝑎́.

- La classe [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar) : spécifie la fonction barre, constituée d'un argument de base et d'une barre supérieure ou inférieure.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character) : spécifie un symbole de regroupement au-dessus ou en dessous d'une expression, généralement pour mettre en évidence les relations entre les éléments.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations Mathématiques**
Chaque élément mathématique et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Cela vous permet d'utiliser des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations ont deux ensembles de paramètres : soit [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) soit chaîne comme arguments. Des instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) sont créées implicitement à partir de chaînes spécifiées lorsque les arguments de chaîne sont utilisés. Les opérations mathématiques disponibles dans Aspose.Slides sont énumérées ci-dessous.
### **Méthode Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Joint un élément mathématique et forme un bloc mathématique. Par exemple :

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 


### **Méthode Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

Crée une fraction du type spécifié avec ce numérateur et le dénominateur spécifié. Par exemple :

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Méthode Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Enferme l'élément dans des caractères spécifiés tels que des parenthèses ou un autre caractère comme encadrement.

``` cpp
/// <summary>
/// Enferme un élément mathématique dans des parenthèses
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Enferme cet élément dans des caractères spécifiés tels que des parenthèses ou d'autres caractères comme encadrement
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 


Par exemple :

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Méthode Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

Prend une fonction d'un argument en utilisant l'objet actuel comme nom de la fonction.

``` cpp
/// <summary>
/// Prend une fonction d'un argument en utilisant cette instance comme nom de la fonction
/// </summary>
/// <param name="functionArgument">Un argument de la fonction</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 


Par exemple :

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **Méthode AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Prend la fonction spécifiée en utilisant l'instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de la fonction, par exemple "cos".
- sélectionner l'une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b), par exemple **MathFunctionsOfOneArgument.ArcSin.**
- sélectionner l'instance de [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

Par exemple :

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

Définit l'indice et l'exposant. Vous pouvez définir un exposant et un indice à la fois à gauche ou à droite de l'argument, mais un seul exposant ou indice est pris en charge uniquement du côté droit. Le **Superscript** peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple :

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Méthode Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Spécifie la racine mathématique du degré donné à partir de l'argument spécifié.

Exemple :

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **Méthodes SetUpperLimit et SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Prend la limite supérieure ou inférieure. Ici, le haut et le bas indiquent simplement la position de l'argument par rapport à la base.

Considérons une expression : 

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées grâce à une combinaison des classes [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) et [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit), et des opérations de [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) comme suit :

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Méthodes Nary et Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

Les méthodes **Nary** et **Integral** créent et renvoient l'opérateur N-aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). Dans la méthode Nary, l'énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) spécifie le type d'opérateur : somme, union, etc., sans inclure les intégrales. Dans la méthode Integral, il y a l'opération spécialisée Intégrale avec l'énumération des types d'intégrales [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607). 

Exemple :

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **Méthode ToMathArray**
La méthode [**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) place des éléments dans un tableau vertical. Si cette opération est appelée pour une instance de **MathBlock**, tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **Opérations de formatage : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- La méthode [**Accent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483) définit une marque d'accent (un caractère sur le dessus de l'élément).
- Les méthodes [**Overbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3) et [**Underbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5) définissent une barre au-dessus ou en dessous.
- La méthode [**Group**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546) place dans un groupe en utilisant un caractère de regroupement tel qu'une accolade inférieure ou autre.
- La méthode [**ToBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b) place dans une boîte à bord.
- La méthode [**ToBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2) place dans une boîte non visible (regroupement logique).

Exemples :

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 