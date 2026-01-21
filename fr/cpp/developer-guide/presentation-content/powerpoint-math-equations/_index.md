---
title: Ajouter des équations mathématiques aux présentations PowerPoint en C++
linktitle: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /fr/cpp/powerpoint-math-equations/
keywords:
- équation mathématique
- symbole mathématique
- formule mathématique
- texte mathématique
- ajouter équation mathématique
- ajouter symbole mathématique
- ajouter formule mathématique
- ajouter texte mathématique
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Insérez et modifiez des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour C++, prenant en charge OMML, les contrôles de formatage et des exemples de code C++ clairs."
---

## **Aperçu**
Dans PowerPoint, il est possible d’écrire une équation ou une formule mathématique et de l’afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l’équation. Le constructeur d’équations mathématiques de PowerPoint permet de créer des formules complexes telles que :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations N‑aires
- Matrice
- Opérateurs extensifs
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion → Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela crée un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Cependant, la création d’équations complexes dans PowerPoint ne donne pas toujours un résultat professionnel. Les utilisateurs qui doivent créer fréquemment des présentations mathématiques se tournent souvent vers des solutions tierces pour obtenir de belles formules.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de manière programmatique en C++. Créez de nouvelles expressions mathématiques ou modifiez celles déjà présentes. L’exportation de structures mathématiques sous forme d’images est également partiellement prise en charge.


## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire n’importe quelle construction mathématique avec n’importe quel niveau d’imbrication. Une collection linéaire d’éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/). La classe [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) correspond essentiellement à une expression, une formule ou une équation mathématique séparée. [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) permet de manipuler un ensemble de blocs mathématiques. Les classes mentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.



Voyons comment créer l’équation mathématique suivante via l’API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, ajoutez d’abord une forme qui contiendra le texte mathématique :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 


Après la création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique à l’intérieur de [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/), utilisez la variable [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) :

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 


La classe [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)), qui peuvent être composés d’une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 


Chaque élément mathématique est représenté par une classe qui implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Cette interface propose de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression assez complexe en une seule ligne de code. Par exemple, le théorème de Pythagore s’écrit ainsi :

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 



Les opérations de l’interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) sont implémentées dans tout type d’élément, y compris le [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

Exemple complet :

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


## **Types d’éléments mathématiques**
Les expressions mathématiques sont constituées de séquences d’éléments mathématiques. La séquence est représentée par un bloc mathématique, et les arguments des éléments forment une imbrication en forme d’arbre.

Il existe de nombreux types d’éléments qui peuvent être utilisés pour construire un bloc mathématique. Chaque élément peut être inclus (agrégé) dans un autre élément, formant ainsi une structure arborescente. Le type le plus simple d’élément ne contient aucun autre élément du texte mathématique.

Chaque type d’élément implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), ce qui permet d’utiliser le même ensemble d’opérations mathématiques sur différents types d’éléments.
### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) représente un texte mathématique – l’élément de base de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables et tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐
### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/) définit l’objet fraction, composé d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale selon les propriétés de la fraction. L’objet fraction sert également à représenter la fonction pile, qui place un élément au-dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/) définit la fonction radicale (racine mathématique), composée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) définit une fonction d’un argument. Contient les méthodes : [get_Name()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/) – nom de la fonction et [get_Base()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/) – argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/) définit un objet mathématique N‑aire, tel que la sommation ou l’intégrale. Elle comprend un opérateur, une base (ou opérande) et des limites supérieures et inférieures optionnelles. Les opérateurs N‑aires incluent la sommation, l’union, l’intersection, l’intégrale, etc.

Cette classe ne couvre pas les opérateurs simples comme l’addition ou la soustraction, qui sont représentés par un seul élément texte – [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) crée une limite supérieure ou inférieure. Elle spécifie un objet limite composé d’un texte sur la ligne de base et d’un texte de taille réduite placé immédiatement au-dessus ou en dessous. Cet élément ne comprend pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l’aide d’une combinaison d’éléments [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) et [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) :

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 
### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Ces classes définissent un indice inférieur ou supérieur. Vous pouvez définir simultanément indice et exposant à gauche ou à droite d’un argument, mais un indice ou un exposant seul n’est pris en charge qu’à droite. Le [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/) peut également servir à indiquer le degré d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) définit l’objet Matrice, composé d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Notez que les matrices ne possèdent pas de délimiteurs intégrés. Pour placer la matrice entre crochets, utilisez l’objet délimiteur : [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/) représente un tableau vertical d’équations ou de tout autre objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Mise en forme des éléments mathématiques**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/) : dessine un rectangle ou une autre bordure autour du [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/) : spécifie l’encapsulation logique de l’élément mathématique. Par exemple, un objet encadré peut servir d’émulateur d’opérateur avec ou sans point d’alignement, ou empêcher les sauts de ligne à l’intérieur.

- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/) : définit l’objet délimiteur, composé de caractères ouvrants et fermants (parenthèses, accolades, crochets, barres verticales) et d’un ou plusieurs éléments mathématiques séparés par un caractère spécifié.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/) : définit la fonction accent, composée d’une base et d’un signe diacritique combiné.  
  Exemple : 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/) : définit la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/) : définit un symbole de regroupement au-dessus ou en dessous d’une expression, généralement pour mettre en évidence les relations entre les éléments.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations mathématiques**
Chaque élément et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Elle permet d’appliquer des opérations sur la structure existante et de créer des expressions plus complexes. Toutes les opérations acceptent deux ensembles de paramètres : soit un [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), soit une chaîne de caractères. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) sont créées implicitement à partir des chaînes lorsqu’elles sont utilisées comme arguments. Les opérations disponibles dans Aspose.Slides sont répertoriées ci‑dessous.
### **Méthode Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

Joint un élément mathématique et crée un bloc mathématique. Exemple :

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 
### **Méthode Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

Crée une fraction du type spécifié avec ce numérateur et le dénominateur indiqué. Exemple :

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Méthode Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

Encadre l’élément dans les caractères spécifiés, comme des parenthèses ou tout autre caractère.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

Exemple :

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 
### **Méthode Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

Prend une fonction d’un argument en utilisant l’objet actuel comme nom de fonction.

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

Exemple :

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **Méthode AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

Utilise l’instance actuelle comme argument de la fonction spécifiée. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par ex. “cos”.
- choisir une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsofoneargument/) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsoftwoarguments/), par ex. **MathFunctionsOfOneArgument.ArcSin**.
- fournir une instance de [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).

Exemple :

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

Définit les indices et les exposants. Vous pouvez définir simultanément indice et exposant à gauche ou à droite d’un argument, mais un indice ou un exposant seul n’est pris en charge qu’à droite. L’**exposant** peut également servir à indiquer le degré d’un nombre.

Exemple :

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Méthode Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

Spécifie la racine mathématique du degré indiqué à partir de l’argument fourni.

Exemple :

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **Méthodes SetUpperLimit et SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

Définit une limite supérieure ou inférieure. Ici, les limites indiquent simplement la position de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

Cette expression peut être créée grâce à une combinaison des classes [MathFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) et [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/), ainsi que les opérations de l’[IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) :

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Méthodes Nary et Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

Les méthodes **Nary** et **Integral** créent et renvoient l’opérateur N‑aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/). Dans la méthode Nary, l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperatortypes/) précise le type d’opérateur : sommation, union, etc., sans les intégrales. La méthode Integral utilise l’énumération [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathintegraltypes/) pour spécifier le type d’intégrale.

Exemple :

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **Méthode ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de **MathBlock**, tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent** : applique un accent (caractère placé au-dessus de l’élément).
- **Overbar** et **Underbar** : ajoutent une barre au-dessus ou en dessous.
- **Group** : regroupe à l’aide d’un caractère de regroupement tel qu’une accolade inférieure ou autre.
- **ToBorderBox** : place l’élément dans une bordure.
- **ToBox** : place l’élément dans une boîte logique non visuelle.

Exemples :

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **FAQ**

**Comment ajouter une équation mathématique à une diapositive PowerPoint ?**

Pour ajouter une équation, créez un objet forme mathématique, qui contient automatiquement une portion mathématique. Ensuite, récupérez le [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) à partir du [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) et ajoutez‑y des objets [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides permet de créer des expressions complexes en imbriquant des MathBlocks. Chaque élément mathématique implémente l’interface [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), qui autorise l’application d’opérations (Join, Divide, Enclose, etc.) pour combiner les éléments en structures plus élaborées.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, accédez aux MathBlocks existants via le [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Ensuite, en utilisant des méthodes telles que Join, Divide, Enclose, etc., modifiez les éléments de l’équation. Après la modification, enregistrez la présentation pour appliquer les changements.