---
title: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /fr/php-java/powerpoint-math-equations/
keywords: " Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint"
description: "Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint"
---

## **Aperçu**
Dans PowerPoint, il est possible d'écrire une équation ou une formule mathématique et de l'afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l'équation. Pour cela, le constructeur d'équations mathématiques est utilisé dans PowerPoint, ce qui aide à créer des formules complexes comme :

- Fraction Mathématique
- Racine Mathématique
- Fonction Mathématique
- Limites et fonctions logarithmiques
- Opérations N-aires
- Matrice
- Grands opérateurs
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insérer -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela créera un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit : 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations mathématiques. Cependant, créer des équations mathématiques compliquées dans PowerPoint n'apporte souvent pas de bons résultats et d'aspect professionnel. Les utilisateurs qui ont souvent besoin de créer des présentations mathématiques ont recours à des solutions tierces pour créer de bonnes formules mathématiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de manière programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles créées précédemment. L'exportation des structures mathématiques sous forme d'images est également partiellement supportée.

## **Comment Créer une Équation Mathématique**
Les éléments mathématiques sont utilisés pour bâtir n'importe quelles constructions mathématiques avec n'importe quel niveau d'imbrication. Une collection linéaire d'éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) est essentiellement une expression mathématique, formule ou équation séparée. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (ne pas mélanger avec [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes mentionnées ci-dessus sont la clé pour travailler avec les équations mathématiques dans PowerPoint via l'API Aspose.Slides.

Voyons comment nous pouvons créer l'équation mathématique suivante via l'API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, d'abord, ajoutez une forme qui contiendra le texte mathématique :

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Après création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) est une portion qui contient un texte mathématique à l'intérieur. Pour accéder au contenu mathématique à l'intérieur de [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), faites référence à la variable [**MathParagraph** ](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) :

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

La classe [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permet de lire, d'ajouter, d'éditer et de supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), qui sont constitués d'une combinaison d'éléments mathématiques. Par exemple, pour créer une fraction et la placer dans la présentation :

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

Chaque élément mathématique est représenté par une classe qui implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Cette interface fournit de nombreux méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression mathématique assez complexe avec une seule ligne de code. Par exemple, le théorème de Pythagore ressemblerait à ceci :

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

Les opérations de l'interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) sont implémentées dans n'importe quel type d'élément, y compris [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

Le code source complet :

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Types d'Éléments Mathématiques**
Les expressions mathématiques sont formées de séquences d'éléments mathématiques. La séquence d'éléments mathématiques est représentée par un bloc mathématique, et les arguments des éléments mathématiques forment une structure arborescente.

Il existe de nombreux types d'éléments mathématiques qui peuvent être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être inclus (agrégé) dans un autre élément. Autrement dit, les éléments sont en fait des conteneurs pour d'autres, formant une structure en arbre. Le type d'élément le plus simple ne contient pas d'autres éléments du texte mathématique.

Chaque type d'élément mathématique implémente l'interface [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), permettant l'utilisation d'un ensemble commun d'opérations mathématiques sur différents types d'éléments mathématiques.
### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) représente un texte mathématique - l'élément sous-jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes et des opérateurs, des variables, et tout autre texte linéaire.

Exemple: 𝑎=𝑏+𝑐
### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) spécifie l'objet fraction, constitué d'un numérateur et d'un dénominateur séparés par une barre de fraction. La barre de fraction peut être horizontale ou diagonale, selon les propriétés de la fraction. L'objet fraction est également utilisé pour représenter la fonction de pile, qui place un élément au-dessus d'un autre, sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) spécifie la fonction radicale (racine mathématique), constituée d'une base et d'un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) spécifie une fonction d'un argument. Contient des propriétés : [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - nom de la fonction et [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) spécifie un objet mathématique N-aire, tel que Somme et Intégrale. Il est constitué d'un opérateur, d'une base (ou operande), et de limites supérieures et inférieures optionnelles. Des exemples d'opérateurs N-aires sont Somme, Union, Intersection, Intégrale.

Cette classe n'inclut pas d'opérateurs simples tels que l'addition, la soustraction, etc. Ils sont représentés par un seul élément de texte - [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) crée la limite supérieure ou inférieure. Elle spécifie l'objet limite, constitué de texte sur la ligne de base et d'un texte de taille réduite immédiatement au-dessus ou au-dessous. Cet élément n'inclut pas le mot “lim", mais permet de placer du texte en haut ou en bas de l'expression. Ainsi, l'expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l'aide d'une combinaison d'éléments [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) de cette manière :

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));

``` 

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Les classes suivantes spécifient un indice inférieur ou un indice supérieur. Vous pouvez définir un indice subscript et superscript en même temps à gauche ou à droite d'un argument, mais un seul subscript ou superscript est supporté à droite uniquement. Le [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) spécifie l'objet Matrice, constitué d'éléments enfants disposés en une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n'ont pas de délimiteurs intégrés. Pour placer la matrice entre crochets, vous devez utiliser l'objet délimiteur - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) spécifie un tableau vertical d'équations ou de tout objet mathématique.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Mise en Forme des Éléments Mathématiques**
- La classe [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) : dessine une bordure rectangulaire ou autre autour de l'[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La classe [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) : spécifie le boxage logique (emballage) de l'élément mathématique. Par exemple, un objet emballé peut servir d'émulateur d'opérateur avec ou sans point d'alignement, servir de point de rupture de ligne, ou être groupé pour ne pas permettre de ruptures de ligne à l'intérieur. Par exemple, l'opérateur "==" doit être emballé pour éviter les ruptures de ligne.
- La classe [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) : spécifie l'objet délimiteur, constitué de caractères d'ouverture et de fermeture (tels que parenthèses, accolades, crochets et barres verticales), et d'un ou plusieurs éléments mathématiques à l'intérieur, séparés par un caractère spécifique. Exemples : (𝑥2); [𝑥2|𝑦2].
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La classe [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) : spécifie la fonction accent, constituée d'une base et d'une marque diacritique combinante.

  Exemple : 𝑎́.

- La classe [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) : spécifie la fonction barre, constituée d'un argument de base et d'une barre au-dessus ou en-dessous.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) : spécifie un symbole de regroupement au-dessus ou en-dessous d'une expression, généralement pour mettre en évidence les relations entre les éléments.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations Mathématiques**
Chaque élément mathématique et expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) implémente l'interface [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Elle vous permet d'utiliser des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations ont deux ensembles de paramètres : soit [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) ou string comme arguments. Les instances de la classe [**MathematicalText** ](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) sont créées implicitement à partir de chaînes spécifiées lors de l'utilisation d'arguments de chaîne. Les opérations mathématiques disponibles dans Aspose.Slides sont énumérées ci-dessous.
### **Méthode Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Joins un élément mathématique et forme un bloc mathématique. Par exemple :

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);

``` 

### **Méthode Divide**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Crée une fraction du type spécifié avec ce numérateur et dénominateur spécifiés. Par exemple :

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);

``` 

### **Méthode Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Enferme l'élément dans des caractères spécifiés comme des parenthèses ou un autre caractère comme encadrement.

```php

``` 

Par exemple :

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();

``` 

### **Méthode Function**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Prend une fonction d'un argument en utilisant l'objet actuel comme nom de fonction.

```php

``` 

Par exemple :

```php
  $func = new MathematicalText("sin")->function("x");

``` 

### **Méthode AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Prend la fonction spécifiée en utilisant l'instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de la fonction, par exemple “cos”.
- sélectionner une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), par exemple [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- sélectionner l'instance de [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

Par exemple :

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");

``` 

### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Définit un subscript et un superscript. Vous pouvez définir un subscript et un superscript en même temps à gauche ou à droite de l'argument, mais un seul subscript ou superscript est pris en charge seulement à droite. Le **Superscript** peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple :

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");

``` 

### **Méthode Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spécifie la racine mathématique du degré donné à partir de l'argument spécifié.

Exemple :

```php
  $radical = new MathematicalText("x")->radical("3");

``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Prend la limite supérieure ou inférieure. Ici, la limite supérieure et inférieure indiquent simplement l'emplacement de l'argument par rapport à la base.

Considérons une expression : 

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées à travers une combinaison de classes [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit), et des opérations de l'[IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) comme suit :

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");

``` 

### **Méthodes Nary et Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Les méthodes **nary** et **integral** créent et retournent l'opérateur N-aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). Dans la méthode nary, l'énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) spécifie le type d'opérateur : somme, union, etc., sans inclure les intégrales. Dans la méthode Intégrale, il y a l'opération spécialisée Intégrale avec l'énumération des types d'intégrales [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes). 

Exemple :

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");

``` 

### **Méthode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) met les éléments dans un tableau vertical. Si cette opération est appelée pour une instance de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();

``` 

### **Opérations de Formatage : Accent, Barres, Sous-barres, Groupe, ToBorderBox, ToBox**
- La méthode [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) définit un accent (un caractère au-dessus de l'élément).
- Les méthodes [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) et [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) définissent une barre au-dessus ou en dessous.
- La méthode [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) place dans un groupe en utilisant un caractère de groupe tel qu'une accolade inférieure ou autre.
- La méthode [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) place dans une bordure encadrée.
- La méthode [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) place dans une boîte non visuelle (groupement logique).

Exemples :

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();

``` 