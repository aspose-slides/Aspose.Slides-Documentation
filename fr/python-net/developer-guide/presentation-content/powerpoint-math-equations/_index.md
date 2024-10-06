---
title: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /python-net/powerpoint-math-equations/
keywords: " Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Équations Mathématiques PowerPoint, Symboles Mathématiques, Formule, et Texte Mathématique en Python"
---

## **Aperçu**
Dans PowerPoint, il est possible d'écrire une équation ou une formule mathématique et de l'afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l'équation. Pour cela, le constructeur d'équations mathématiques est utilisé dans PowerPoint, ce qui aide à créer des formules complexes telles que :

- Fraction mathématique
- Radicale mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations N-aires
- Matrice
- Grands opérateurs
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insérer -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela créera un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit : 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint supporte de nombreux symboles mathématiques pour créer des équations mathématiques. Cependant, créer des équations mathématiques compliquées dans PowerPoint n'apporte souvent pas un bon résultat professionnel. Les utilisateurs, qui doivent fréquemment créer des présentations mathématiques, ont recours à l'utilisation de solutions tierces pour créer de belles formules mathématiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/python-net/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de manière programmatique en Python. Créez de nouvelles expressions mathématiques ou éditez celles déjà créées. L'exportation de structures mathématiques en images est également partiellement prise en charge.

## **Comment Créer une Équation Mathématique**
Les éléments mathématiques sont utilisés pour construire toute construction mathématique avec n'importe quel niveau d'imbrication. Une collection linéaire d'éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). La classe [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) est essentiellement une expression mathématique, une formule ou une équation séparée. [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) est une portion mathématique, utilisée pour contenir du texte mathématique (ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) permet de manipuler un ensemble de blocs mathématiques. Les classes susmentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l'API Aspose.Slides.

Voyons comment nous pouvons créer l'équation mathématique suivante via l'API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, ajoutez d'abord une forme qui contiendra le texte mathématique :

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

Après la création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) est une portion qui contient un texte mathématique à l'intérieur. Pour accéder au contenu mathématique à l'intérieur de [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), référez-vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) :

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

La classe [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), qui se composent d'une combinaison d'éléments mathématiques. Par exemple, créez une fraction et placez-la dans la présentation :

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

Chaque élément mathématique est représenté par une classe qui implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression mathématique assez complexe avec une seule ligne de code. Par exemple, le théorème de Pythagore pourrait ressembler à ceci :

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

Les opérations de l'interface [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) sont implémentées dans tous les types d'éléments, y compris le [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Le code source complet :

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **Types d'Éléments Mathématiques**
Les expressions mathématiques sont formées à partir de séquences d'éléments mathématiques. La séquence d'éléments mathématiques est représentée par un bloc mathématique, et les arguments des éléments mathématiques forment une imbrication en forme d'arbre.

Il existe de nombreux types d'éléments mathématiques pouvant être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être inclus (agrégé) dans un autre élément. Autrement dit, les éléments sont en fait des conteneurs pour d'autres, formant une structure en forme d'arbre. Le type d'élément le plus simple qui ne contient pas d'autres éléments du texte mathématique.

Chaque type d'élément mathématique implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), permettant d'utiliser l'ensemble commun d'opérations mathématiques sur différents types d'éléments mathématiques.
### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) représente un texte mathématique - l'élément de base de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes et des opérateurs, des variables, et tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐
### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) spécifie l'objet fraction, constitué d'un numérateur et d'un dénominateur séparés par une barre de fraction. La barre de fraction peut être horizontale ou diagonale, selon les propriétés de la fraction. L'objet fraction est également utilisé pour représenter la fonction de pile, qui place un élément au-dessus d'un autre, sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) spécifie la fonction radicale (racine mathématique), composée d'une base, et d'un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) spécifie une fonction d'un argument. Contient les propriétés : [Nom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - nom de la fonction et [Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) spécifie un objet mathématique N-aire, tel que Somme et Intégral. Il se compose d'un opérateur, d'une base (ou opérande), et de limites supérieures et inférieures optionnelles. Les exemples d'opérateurs N-aires sont Somme, Union, Intersection, Intégral.

Cette classe n'inclut pas les opérateurs simples tels que addition, soustraction, etc. Ils sont représentés par un seul élément de texte - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) crée la limite supérieure ou inférieure. Elle spécifie l'objet limite, composé de texte sur la ligne de base et de texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n'inclut pas le mot "lim", mais permet de placer du texte en haut ou en bas de l'expression. Ainsi, l'expression

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée en utilisant une combinaison des éléments [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) et [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) de cette manière :

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Les classes suivantes spécifient un indice inférieur ou un indice supérieur. Vous pouvez définir un indice et un exposant en même temps sur le côté gauche ou droit d'un argument, mais un seul indice ou exposant est pris en charge uniquement sur le côté droit. Le [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) spécifie l'objet Matrice, composé d'éléments enfants disposés en une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n'ont pas de délimiteurs intégrés. Pour placer la matrice dans des crochets, vous devez utiliser l'objet délimiteur - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) spécifie un tableau vertical d'équations ou d'objets mathématiques.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Mise en forme des éléments mathématiques**
- La classe [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) : dessine une bordure rectangulaire ou autre autour de l'[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La classe [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) : spécifie l'encapsulation logique (packaging) de l'élément mathématique. Par exemple, un objet encadré peut servir d'émulateur d'opérateur avec ou sans point d'alignement, servir de point de rupture de ligne, ou être groupé de manière à ne pas permettre les retours à la ligne à l'intérieur. Par exemple, l'opérateur "==" devrait être encadré pour empêcher les retours à la ligne.
- La classe [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) : spécifie l'objet délimiteur, constitué de caractères d'ouverture et de fermeture (tels que parenthèses, accolades, crochets et barres verticales), et d'un ou plusieurs éléments mathématiques à l'intérieur, séparés par un caractère spécifié. Exemples : (𝑥2); [𝑥2|𝑦2].
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La classe [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) : spécifie la fonction d'accent, composée d'une base et d'un signe diacritique combiné. 

  Exemple : 𝑎́.

- La classe [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) : spécifie la fonction de barre, composée d'un argument de base et d'une barre au-dessus ou en dessous.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) : spécifie un symbole de regroupement au-dessus ou en dessous d'une expression, généralement pour mettre en évidence les relations entre les éléments.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations Mathématiques**
Chaque élément mathématique et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Cela vous permet d'utiliser des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations ont deux ensembles de paramètres : soit [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) soit une chaîne de caractères comme arguments. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) sont créées implicitement à partir des chaînes spécifiées lorsque des arguments en chaîne sont utilisés. Les opérations mathématiques disponibles dans Aspose.Slides sont énumérées ci-dessous.
### **Méthode Join**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Joint un élément mathématique et forme un bloc mathématique. Par exemple :

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Méthode Divide**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Crée une fraction du type spécifié avec ce numérateur et ce dénominateur. Par exemple :

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Méthode Enclose**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Encadre l'élément dans des caractères spécifiés tels que des parenthèses ou un autre caractère comme cadre.

```py
# Encadre un élément mathématique dans des parenthèses
MathDelimiter enclose()

# Encadre cet élément dans des caractères spécifiés tels que des parenthèses ou d'autres caractères comme cadre
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```

Par exemple :

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Méthode Function**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Prend une fonction d'un argument en utilisant l'objet actuel comme nom de fonction.

Par exemple :

```py
func = math.MathematicalText("sin").function("x")
```
### **Méthodes AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Prend la fonction spécifiée en utilisant l'instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de la fonction, par exemple "cos".
- sélectionner l'une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), par exemple **MathFunctionsOfOneArgument.ArcSin.**
- sélectionner l'instance de [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Par exemple :

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Définit un indice inférieur et un exposant. Vous pouvez définir un indice et un exposant en même temps sur le côté gauche ou droit de l'argument, mais un seul indice ou exposant est pris en charge uniquement sur le côté droit. Le **Superscript** peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple :

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Méthode Radical**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Spécifie la racine mathématique du degré donné à partir de l'argument spécifié.

Exemple :

```py
    radical = math.MathematicalText("x").radical("3")
```
### **Méthodes SetUpperLimit et SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Prend la limite supérieure ou inférieure. Ici, le haut et le bas indiquent simplement l'emplacement de l'argument par rapport à la base.

Considérons une expression : 

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées à travers une combinaison des classes [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) et [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), et des opérations de [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) de la manière suivante :

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Méthodes Nary et Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Les méthodes **Nary** et **Integral** créent et retournent l'opérateur N-aire représenté par le type [**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/). Dans la méthode Nary, l'énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) spécifie le type d'opérateur : somme, union, etc., sans inclure les intégrales. Dans la méthode Integral, il y a l'opération spécialisée Intégrale avec l'énumération des types d'intégrale [**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/). 

Exemple :

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **Méthode ToMathArray**
La méthode [**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) place les éléments dans un tableau vertical. Si cette opération est appelée pour une instance de **MathBlock**, tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- La méthode [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) définit un signe d'accent (un caractère au-dessus de l'élément).
- Les méthodes [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) et [**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) définissent une barre en haut ou en bas.
- La méthode [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) place dans un groupe en utilisant un caractère de regroupement tel qu'une accolade courbe inférieure ou autre.
- La méthode [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) place dans une boîte de bordure.
- La méthode [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) place dans une boîte non visible (application logique).

Exemples :

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```