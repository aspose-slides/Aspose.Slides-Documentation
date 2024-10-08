---
title: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /fr/net/powerpoint-math-equations/
keywords: " Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Équations Mathématiques PowerPoint, Symboles Mathématiques, Formule et Texte Mathématique en C# ou .NET"
---

## **Aperçu**
Dans PowerPoint, il est possible d'écrire une équation mathématique ou une formule et de l'afficher dans la présentation. Pour ce faire, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l'équation. Pour cela, le constructeur d'équations mathématiques est utilisé dans PowerPoint, ce qui aide à créer des formules complexes telles que :

- Fraction Mathématique
- Racine Mathématique
- Fonction Mathématique
- Limites et fonctions log
- Opérations N-aires
- Matrice
- Grands opérateurs
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insérer -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela créera un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit : 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations mathématiques. Cependant, la création d'équations mathématiques compliquées dans PowerPoint ne donne souvent pas un résultat satisfaisant et professionnel. Les utilisateurs qui ont besoin de créer fréquemment des présentations mathématiques recourent à des solutions tierces pour créer de belles formules mathématiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/net/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de manière programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà créées. L'exportation de structures mathématiques vers des images est également partiellement supportée.

## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire toutes les constructions mathématiques avec n'importe quel niveau d'imbrication. Une collection linéaire d'éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). La classe [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) est essentiellement une expression mathématique, une formule ou une équation séparée. [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) est une portion mathématique, utilisée pour contenir du texte mathématique (ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion)). [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes mentionnées ci-dessus sont la clé pour travailler avec les équations mathématiques PowerPoint via l'API Aspose.Slides.

Voyons comment nous pouvons créer l'équation mathématique suivante via l'API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, ajoutez d'abord une forme qui contiendra le texte mathématique :

``` csharp

 using (Presentation pres = new Presentation())

{

    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

}

```

Après la création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) est une portion qui contient un texte mathématique à l'intérieur. Pour accéder au contenu mathématique à l'intérieur de [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), référez-vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) :

``` csharp

 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

```

La classe [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) permet de lire, d'ajouter, de modifier et de supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), qui sont une combinaison d'éléments mathématiques. Par exemple, créez une fraction et placez-la dans la présentation :

``` csharp

 var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));

```

Chaque élément mathématique est représenté par une classe qui implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression mathématique assez complexe avec une seule ligne de code. Par exemple, le théorème de Pythagore ressemblerait à ceci :

``` csharp

 var mathBlock = new MathematicalText("c")

    .SetSuperscript("2")

    .Join("=")

    .Join(new MathematicalText("a").SetSuperscript("2"))

    .Join("+")

    .Join(new MathematicalText("b").SetSuperscript("2"));

```

Les opérations de l'interface [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) sont mises en œuvre dans tout type d'élément, y compris le [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

L'exemple de code source complet :

``` csharp

 using (Presentation pres = new Presentation())

{

    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

   var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

   var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));

   var mathBlock = new MathematicalText("c")

        .SetSuperscript("2")

        .Join("=")

        .Join(new MathematicalText("a").SetSuperscript("2"))

        .Join("+")

        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    pres.Save("math.pptx", SaveFormat.Pptx);

}

```

## **Types d'éléments mathématiques**
Les expressions mathématiques sont formées à partir de séquences d'éléments mathématiques. La séquence d'éléments mathématiques est représentée par un bloc mathématique, et les arguments des éléments mathématiques forment un empilement en forme d'arbre.

Il existe de nombreux types d'éléments mathématiques qui peuvent être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être inclus (agrégé) dans un autre élément. Cela signifie que les éléments sont en fait des conteneurs pour d'autres, formant une structure arborescente. Le type d'élément le plus simple ne contient pas d'autres éléments du texte mathématique.

Chaque type d'élément mathématique implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), permettant d'utiliser l'ensemble commun d'opérations mathématiques sur différents types d'éléments mathématiques.
### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) représente un texte mathématique - l'élément de base de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes et des opérateurs, des variables et tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐
### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) spécifie l'objet fraction, constitué d'un numérateur et d'un dénominateur séparés par une barre de fraction. La barre de fraction peut être horizontale ou diagonale, en fonction des propriétés de la fraction. L'objet fraction est également utilisé pour représenter la fonction de pile, qui place un élément au-dessus d'un autre, sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) spécifie la fonction radicale (racine mathématique), constituée d'une base et d'un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) spécifie une fonction d'un argument. Contient des propriétés : [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - nom de la fonction et [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) spécifie un objet mathématique N-aire, tel que Somme et Intégrale. Il se compose d'un opérateur, d'une base (ou opérande) et de limites supérieures et inférieures optionnelles. Des exemples d'opérateurs N-aires sont Somme, Union, Intersection, Intégrale.

Cette classe n'inclut pas d'opérateurs simples tels que l'addition, la soustraction, etc. Ceux-ci sont représentés par un élément de texte unique - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) crée la limite supérieure ou inférieure. Elle spécifie l'objet limite, constitué de texte sur la ligne de base et de texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n'inclut pas le mot “lim", mais permet de placer du texte en haut ou en bas de l'expression. Ainsi, l'expression

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à partir d'une combinaison de classes [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) de cette manière :

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));

```

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Les classes suivantes spécifient un indice inférieur ou un indice supérieur. Vous pouvez définir un indice et un exposant en même temps sur le côté gauche ou droit d'un argument, mais un seul indice ou exposant est pris en charge sur le côté droit uniquement. Le [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) spécifie l'objet Matrice, constitué d'éléments enfants disposés en une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n'ont pas de délimiteurs intégrés. Pour placer la matrice dans des parenthèses, vous devez utiliser l'objet de délimiteur - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) spécifie un tableau vertical d'équations ou d'objets mathématiques.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatage des éléments mathématiques**
- La classe [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox) : dessine une bordure rectangulaire ou une autre autour de [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La classe [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox) : spécifie le conditionnement logique (emballage) de l'élément mathématique. Par exemple, un objet encadré peut servir d'émulateur d'opérateur avec ou sans point d'alignement, servir de point de rupture de ligne, ou être groupé afin d'éviter les retours à la ligne à l'intérieur. Par exemple, l'opérateur "==" doit être encadré pour empêcher les retours à la ligne.
- La classe [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter) : spécifie l'objet délimiteur, constitué de caractères d'ouverture et de fermeture (tels que des parenthèses, accolades, crochets et barres verticales), ainsi qu'un ou plusieurs éléments mathématiques à l'intérieur, séparés par un caractère spécifié. Exemples : (𝑥2); [𝑥2|𝑦2].
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La classe [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent) : spécifie la fonction d'accent, constituée d'une base et d'un signe diacritique combiné.

  Exemple : 𝑎́.

- La classe [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar) : spécifie la fonction barre, constituée d'un argument de base et d'une barre supérieure ou inférieure.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter) : spécifie un symbole de regroupement au-dessus ou en dessous d'une expression, généralement pour souligner les relations entre les éléments.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations mathématiques**
Chaque élément mathématique et expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Cela vous permet d'utiliser des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations disposent de deux ensembles de paramètres : soit [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) soit chaîne comme arguments. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) sont créées implicitement à partir des chaînes spécifiées lorsqu'il s'agit d'arguments de chaîne. Les opérations mathématiques disponibles dans Aspose.Slides sont listées ci-dessous.
### **Méthode Join**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Joint un élément mathématique et forme un bloc mathématique. Par exemple :

``` csharp

 IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);

```
### **Méthode Divide**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Crée une fraction du type spécifié avec ce numérateur et ce dénominateur spécifiés. Par exemple :

``` csharp

 IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);

```
### **Méthode Enclose**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Enferme l'élément dans des caractères spécifiés tels que des parenthèses ou un autre caractère comme encadrement.

``` csharp

 /// <summary>

/// Enferme un élément mathématique dans des parenthèses

/// </summary>

IMathDelimiter Enclose();

/// <summary>

/// Enferme cet élément dans des caractères spécifiés tels que des parenthèses ou d'autres caractères comme encadrement

/// </summary>

IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);

```

Par exemple :

``` csharp

 IMathDelimiter delimiter = new MathematicalText("x").Enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();

```
### **Méthode Function**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Prend une fonction d'un argument en utilisant l'objet actuel comme nom de fonction.

``` csharp

 /// <summary>

/// Prend une fonction d'un argument en utilisant cette instance comme nom de fonction

/// </summary>

/// <param name="functionArgument">Un argument de la fonction</param>

IMathFunction Function(IMathElement functionArgument);

IMathFunction Function(string functionArgument);

```

Par exemple :

``` csharp

 IMathFunction func = new MathematicalText("sin").Function("x");

```
### **Méthode AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathfunctionsoftwoarguments/asargumentoffunction/methods/3)

Prend la fonction spécifiée en utilisant l'instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par exemple “cos”.
- sélectionner l'une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), par exemple **MathFunctionsOfOneArgument.ArcSin.**
- sélectionner l'instance de [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

Par exemple :

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);

var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");

var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")

```
### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Définit un indice et un exposant. Vous pouvez définir un indice et un exposant en même temps sur le côté gauche ou droit de l'argument, mais un seul indice ou exposant est pris en charge uniquement sur le côté droit. L’**Exposant** peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple :

``` csharp

 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");

```
### **Méthode Radical**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Spécifie la racine mathématique du degré donné à partir de l'argument spécifié.

Exemple :

``` csharp

 var radical = new MathematicalText("x").Radical("3");

```
### **Méthodes SetUpperLimit et SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Prend la limite supérieure ou inférieure. Ici, la limite supérieure et inférieure indiquent simplement l'emplacement de l'argument par rapport à la base.

Considérons l'expression : 

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées à partir d'une combinaison des classes [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) et [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), et les opérations de [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) comme suit :

``` csharp

 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");

```
### **Méthodes Nary et Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathfunctionsoftwoarguments/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathfunctionsoftwoarguments/integral/methods/4)

Les méthodes **Nary** et **Integral** créent et retournent l'opérateur N-aire représenté par le type [**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). Dans la méthode Nary, l'énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) spécifie le type d'opérateur : somme, union, etc., sans inclure les intégrales. Dans la méthode Integral, il s'agit de l'opération spécialisée Intégrale avec l'énumération des types d'intégrale [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes). 

Exemple :

``` csharp

 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());

IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");

```
### **Méthode ToMathArray**
La méthode [**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) place des éléments dans un tableau vertical. Si cette opération est appelée pour une instance de **MathBlock**, tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

``` csharp

 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();

```
### **Opérations de formatage : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- La méthode [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) définit un accent (un caractère au-dessus de l'élément).
- Les méthodes [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) et [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) définissent une barre en haut ou en bas.
- La méthode [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) place dans un groupe en utilisant un caractère de groupement tel qu'un crochet inférieur ou autre.
- La méthode [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) place dans un cadre de bord.
- La méthode [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) place dans une boîte non-visuelle (regroupement logique).

Exemples :

``` csharp

 var accent = new MathematicalText("x").Accent('\u0303');

var bar = new MathematicalText("x").Overbar();

var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

var borderBox = new MathematicalText("x+y+z").ToBorderBox();

var boxedOperator = new MathematicalText(":=").ToBox();

```