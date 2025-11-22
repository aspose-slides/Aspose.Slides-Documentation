---
title: Ajouter des équations mathématiques aux présentations PowerPoint en C#
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/net/powerpoint-math-equations/
keywords:
- équation mathématique
- équation mathématique PowerPoint
- symbole mathématique
- symbole mathématique PowerPoint
- formule mathématique
- formule mathématique PowerPoint
- texte mathématique
- texte mathématique PowerPoint
- ajouter une équation mathématique à PowerPoint
- ajouter un symbole mathématique à PowerPoint
- ajouter une formule mathématique à PowerPoint
- ajouter du texte mathématique à PowerPoint
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à travailler avec les équations mathématiques dans PowerPoint en utilisant Aspose.Slides pour .NET. Obtenez des instructions détaillées, des exemples de code et des conseils pour automatiser la création et la modification de présentations."
---

## **Aperçu**

Dans PowerPoint, vous pouvez écrire une équation ou une formule mathématique et l’afficher dans votre présentation. Divers symboles mathématiques sont disponibles et peuvent être ajoutés au texte ou aux équations. Le constructeur d’équations mathématiques est utilisé pour créer des formules complexes comme :

- Fraction mathématique
- Racine mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n-aires
- Matrice
- Opérateurs larges
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela créera un texte mathématique en XML qui pourra être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge un large éventail de symboles mathématiques pour créer des équations. Cependant, générer des équations mathématiques complexes dans PowerPoint ne donne souvent pas un résultat poli et professionnel. En conséquence, les utilisateurs qui créent fréquemment des présentations mathématiques se tournent souvent vers des solutions tierces pour obtenir des formules plus esthétiques.

En utilisant l’[**API Aspose.Slides**](https://products.aspose.com/slides/net/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de façon programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà créées. Un support partiel est disponible pour l’exportation des structures mathématiques sous forme d’images.

## **Comment créer une équation mathématique**

Les éléments mathématiques sont utilisés pour construire toute construction mathématique, quel que soit le niveau d’imbrication. Une collection linéaire de ces éléments forme un bloc mathématique, représenté par la classe [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). La classe [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) représente une expression, une formule ou une équation mathématique autonome. [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) sert à contenir du texte mathématique (distinct de la classe [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) ordinaire), tandis que [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) vous permet de manipuler un ensemble d’objets [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Ces classes sont essentielles pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

Voyons comment créer l’équation mathématique suivante à l’aide de l’API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique à la diapositive, ajoutez d’abord une forme qui contiendra le texte mathématique :
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


Après la création de la forme, elle contient déjà un paragraphe avec une portion mathématique par défaut. La classe [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) représente une portion qui contient du texte mathématique. Pour accéder au contenu mathématique à l’intérieur d’une [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), référez‑vous à la variable [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) :
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


La classe [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) vous permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), qui se composent d’une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


Chaque élément mathématique est représenté par une classe qui implémente l’interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques, vous permettant de construire des équations assez complexes en une seule ligne de code. Par exemple, le théorème de Pythagore s’écrirait ainsi :
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


Les opérations de l’interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) sont implémentées dans chaque type d’élément, y compris la classe [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

Voici le code complet d’exemple :
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
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

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **Types d’éléments mathématiques**

Les expressions mathématiques sont composées de séquences d’éléments mathématiques. Un bloc mathématique représente une telle séquence, et les arguments de ces éléments forment une structure imbriquée en forme d’arbre.

Il existe de nombreux types d’éléments mathématiques qui peuvent être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être agrégé à l’intérieur d’un autre, formant ainsi une structure arborescente. Le type d’élément le plus simple est celui qui ne contient aucun autre élément de texte mathématique.

Chaque type d’élément mathématique implémente l’interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), ce qui vous permet d’utiliser un ensemble commun d’opérations mathématiques sur différents types d’éléments.

### **Classe MathematicalText**

La classe [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) représente un texte mathématique — l’élément sous‑jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes et opérateurs, des variables ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**

La classe [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) spécifie un objet fraction composé d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale, selon les propriétés de la fraction. L’objet fraction sert également à représenter la fonction « stack », qui place un élément au-dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**

La classe [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) spécifie la fonction radicande (racine mathématique), composée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**

La classe [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) spécifie une fonction d’un argument. Elle possède des propriétés telles que [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name), qui représente le nom de la fonction, et [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base), qui représente l’argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**

La classe [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) spécifie un objet mathématique N‑aire, tel qu’une sommation ou une intégrale. Elle comprend un opérateur, une base (ou opérande) et des limites supérieures et inférieures optionnelles. Parmi les opérateurs N‑aires figurent la sommation, l’union, l’intersection et l’intégrale.

Cette classe n’inclut pas les opérateurs simples comme l’addition ou la soustraction ; ceux‑ci sont représentés par un texte unique [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**

La classe [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) crée une limite supérieure ou inférieure. Elle spécifie l’objet limite, composé de texte sur la ligne de base et de texte réduit placé immédiatement au-dessus ou en dessous. Cet élément ne comprend pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l’aide d’une combinaison des éléments [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) et [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) comme suit :
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Ces classes spécifient un indice inférieur ou supérieur. Vous pouvez définir à la fois l’indice inférieur et supérieur simultanément du côté gauche ou droit d’un argument, mais un indice simple n’est supporté que du côté droit. L’[MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) peut également être utilisé pour définir le degré mathématique d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**

La classe [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) spécifie l’objet Matrice, composé d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n’ont pas de délimiteurs intégrés. Pour entourer la matrice de crochets, utilisez l’objet délimiteur [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**

La classe [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) spécifie un tableau vertical d’équations ou de tout objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**

- Classe [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox) : trace une bordure rectangulaire ou alternative autour de l’[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Classe [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox) : spécifie l’encapsulation logique d’un élément mathématique. Un objet encadré peut servir d’émulateur d’opérateur — avec ou sans point d’ancrage — fonctionner comme un point de rupture de ligne, ou être groupé pour empêcher les coupures de ligne à l’intérieur. Par exemple, l’opérateur « == » doit être encadré pour éviter les coupures.

- Classe [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter) : spécifie l’objet délimiteur, composé de caractères d’ouverture et de fermeture (parenthèses, accolades, crochets ou barres verticales) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié. Exemples : (𝑥2) ; [𝑥2|𝑦2].

Exemple :

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Classe [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent) : spécifie la fonction accent, composée d’une base et d’une marque diacritique combinée.

Exemple : 𝑎́.

- Classe [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar) : spécifie la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Classe [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter) : spécifie un symbole de groupement placé au-dessus ou au-dessous d’une expression, généralement pour mettre en évidence les relations entre éléments.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations mathématiques**

Chaque élément mathématique et chaque expression mathématique (via [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implémente l’interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Cela vous permet d’effectuer des opérations sur la structure existante et de former des expressions plus complexes. Toutes les opérations disposent de deux jeux de paramètres : soit des arguments [IMathElement], soit des chaînes de caractères. Les instances de la classe [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) sont créées implicitement à partir des chaînes spécifiées lorsqu’on utilise des arguments de type string. Les opérations mathématiques disponibles dans Aspose.Slides sont listées ci‑dessous.

### **Méthode Join**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Ces méthodes joignent un élément mathématique et forment un bloc mathématique. Exemple :
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Méthode Divide**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Ces méthodes créent une fraction du type spécifié avec un numérateur et le dénominateur indiqué. Exemple :
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Méthode Enclose**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Ces méthodes entourent l’élément de caractères spécifiés, tels que des parenthèses ou d’autres caractères de cadrage. Exemple :
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Méthode Function**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Ces méthodes prennent une fonction d’un argument en utilisant l’objet actuel comme nom de fonction. Exemple :
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **Méthode AsArgumentOfFunction**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Ces méthodes utilisent la fonction spécifiée en prenant l’instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par exemple « cos »;
- choisir l’une des valeurs prédéfinies des énumérations [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) ou [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), par ex. `MathFunctionsOfOneArgument.ArcSin`;
- fournir l’instance de l’[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

Exemple :
```cs
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

Ces méthodes définissent l’indice inférieur et supérieur. Vous pouvez les définir simultanément du côté gauche ou droit de l’argument ; cependant, un seul indice est supporté uniquement du côté droit. Le **Superscript** peut également être utilisé pour définir le degré mathématique d’un nombre.

Exemple :
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Méthode Radical**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Ces méthodes spécifient la racine mathématique du degré donné à partir de l’argument indiqué.

Exemple :
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **Méthodes SetUpperLimit et SetLowerLimit**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Ces méthodes définissent une limite supérieure ou inférieure, où « upper » et « lower » indiquent la position de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées à l’aide d’une combinaison des classes [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) et [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), ainsi que des opérations de l’interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement), comme suit :
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Méthodes Nary et Integral**

- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/4)

Les deux méthodes **Nary** et **Integral** créent et renvoient l’opérateur N‑aire représenté par le type [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). Dans la méthode Nary, l’énumération [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) spécifie le type d’opérateur — comme la sommation ou l’union — excluant les intégrales. Dans la méthode Integral, une opération spécialisée pour les intégrales est fournie, utilisant l’énumération [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes).

Exemple :
```cs
IMMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **Méthode ToMathArray**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock), tous ses éléments enfants seront placés dans le tableau retourné.

Exemple :
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Méthode [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) : définit une marque d’accent (un caractère au-dessus de l’élément).
- Méthodes [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) et [Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) : définissent une barre au-dessus ou en dessous.
- Méthode [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) : place dans un groupe à l’aide d’un caractère de groupement tel qu’une accolade inférieure ou autre.
- Méthode [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) : place dans une bordure‑boîte.
- Méthode [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) : place dans une boîte non visuelle (groupement logique).

Exemples :
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **FAQ**

**Comment ajouter une équation mathématique à une diapositive PowerPoint ?**

Pour ajouter une équation mathématique, créez un objet `MathShape`, qui contient automatiquement une portion mathématique. Ensuite, récupérez le `MathParagraph` à partir du `MathPortion` et ajoutez‑y des objets `MathBlock`.

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides vous permet de créer des expressions mathématiques complexes en imbriquant des `MathBlock`. Chaque élément mathématique implémente l’interface `IMathElement`, ce qui vous permet d’appliquer des opérations (Join, Divide, Enclose, etc.) pour combiner les éléments en structures plus complexes.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, accédez aux `MathBlock` existants via le `MathParagraph`. Puis, en utilisant des méthodes telles que Join, Divide, Enclose, etc., modifiez les éléments individuels de l’équation. Après modification, enregistrez la présentation pour appliquer les changements.