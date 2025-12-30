---
title: Ajouter des équations mathématiques aux présentations PowerPoint en PHP
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/php-java/powerpoint-math-equations/
keywords:
- équation mathématique
- symbole mathématique
- formule mathématique
- texte mathématique
- ajouter une équation mathématique
- ajouter un symbole mathématique
- ajouter une formule mathématique
- ajouter du texte mathématique
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour PHP via Java, en prenant en charge OMML, les contrôles de mise en forme et des exemples de code clairs."
---

## **Aperçu**
Dans PowerPoint, il est possible d’écrire une équation ou une formule mathématique et de l’afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l’équation. Le constructeur d’équations mathématiques de PowerPoint permet de créer des formules complexes telles que :

- Fraction mathématique
- Racine mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n‑aires
- Matrice
- Opérateurs larges
- Fonctions sinus, cosinus

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion → Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela crée un texte mathématique au format XML qui peut être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Cependant, la création d’équations mathématiques complexes dans PowerPoint ne donne souvent pas un résultat professionnel. Les utilisateurs qui doivent fréquemment créer des présentations mathématiques ont recours à des solutions tierces pour obtenir des formules esthétiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), vous pouvez travailler avec les équations mathématiques dans les présentations PowerPoint de manière programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà créées. L’exportation des structures mathématiques vers des images est également partiellement prise en charge.

## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire n’importe quelle construction mathématique avec n’importe quel niveau d’imbrication. Une collection linéaire d’éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) représente essentiellement une expression, une formule ou une équation séparée. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes susmentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

Voyons comment créer l’équation mathématique suivante via l’API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, ajoutez d’abord une forme qui contiendra le texte mathématique :
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


Après création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique à l’intérieur de [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), référez‑vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) :
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

```


## **Types d'éléments mathématiques**
Les expressions mathématiques sont constituées de séquences d’éléments mathématiques. La séquence d’éléments est représentée par un bloc mathématique, et les arguments des éléments forment une imbrication en arbre.

Il existe de nombreux types d’éléments pouvant être utilisés pour construire un bloc mathématique. Chaque élément peut être inclus (agrégé) dans un autre élément. Ainsi, les éléments sont en réalité des conteneurs pour d’autres, formant une structure arborescente. Le type le plus simple d’élément ne contient pas d’autres éléments du texte mathématique.

Chaque type d’élément implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), ce qui permet d’utiliser un jeu commun d’opérations mathématiques sur différents types d’éléments.

### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) représente un texte mathématique — l’élément de base de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) définit l’objet fraction, composé d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale, selon les propriétés de la fraction. L’objet fraction sert également à représenter la fonction « stack », qui place un élément au-dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) définit la fonction radicale (racine mathématique), composée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) définit une fonction d’un argument. Elle possède les propriétés : [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) – nom de la fonction et [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) – argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) définit un objet mathématique n‑aire, tel que la sommation ou l’intégrale. Elle se compose d’un opérateur, d’une base (ou opérande) et de limites supérieures et inférieures optionnelles. Des exemples d’opérateurs n‑aires sont la sommation, l’union, l’intersection, l’intégrale.

Cette classe n’inclut pas les opérateurs simples comme l’addition ou la soustraction ; ils sont représentés par un seul élément texte – [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) crée une limite supérieure ou inférieure. Elle spécifie un objet limite composé d’un texte sur la ligne de base et d’un texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n’inclut pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée en combinant les éléments [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) de la manière suivante :

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Ces classes définissent un indice inférieur ou supérieur. Vous pouvez définir simultanément un indice et un exposant du côté gauche ou du côté droit d’un argument, mais un seul indice ou exposant est pris en charge uniquement du côté droit. La classe [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) peut également être utilisée pour définir le degré mathématique d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) définit l’objet Matrice, composé d’éléments enfants disposés sur une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n’ont pas de délimiteurs intégrés. Pour placer la matrice entre crochets, utilisez l’objet délimiteur – [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) définit un tableau vertical d’équations ou de tout autre objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**
- Classe [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) : dessine un cadre rectangulaire ou autre autour de l’[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Classe [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) : spécifie un conditionnement logique de l’élément mathématique. Par exemple, un objet encadré peut servir d’émulateur d’opérateur avec ou sans point d’alignement, de point d’arrêt de ligne, ou être groupé afin d’empêcher les ruptures de ligne à l’intérieur. Par exemple, l’opérateur « == » doit être encadré pour éviter les ruptures de ligne.

- Classe [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) : spécifie l’objet délimiteur, composé de caractères ouvrants et fermants (parenthèses, accolades, crochets, barres verticales) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié. Exemple : (𝑥2); [𝑥2|𝑦2].  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Classe [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) : spécifie la fonction accent, composée d’une base et d’un diacritique combiné.  
  Exemple : 𝑎́.

- Classe [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) : spécifie la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) : spécifie un symbole de regroupement au-dessus ou en dessous d’une expression, généralement pour mettre en évidence les relations entre les éléments.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations mathématiques**
Chaque élément et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Elle permet d’appliquer des opérations sur la structure existante et de former des expressions plus complexes. Toutes les opérations acceptent deux ensembles de paramètres : soit un [**IMathElement**] soit une chaîne de caractères. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) sont créées implicitement à partir des chaînes lorsqu’un argument de type string est utilisé. Les opérations mathématiques disponibles dans Aspose.Slides sont listées ci‑dessous.

### **Méthode Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Joint un élément mathématique et forme un bloc mathématique. Exemple :

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

Crée une fraction du type spécifié avec ce numérateur et ce dénominateur. Exemple :

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Méthode Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Encadre l’élément avec les caractères spécifiés, tels que des parenthèses ou tout autre caractère de cadrage.

```php

``` 

Exemple :

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Méthode Function**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Applique une fonction à un argument en utilisant l’objet courant comme nom de fonction.

```php

``` 

Exemple :

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **Méthode AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Utilise la fonction spécifiée en prenant l’instance courante comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par ex. “cos”.
- choisir une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), par ex. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- fournir une instance de [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

Exemple :

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

Définit le sous‑indice et l’exposant. Vous pouvez définir simultanément indice et exposant du côté gauche ou droite de l’argument, mais un seul indice ou exposant est pris en charge uniquement du côté droit. L’**Superscript** peut également être utilisé pour définir le degré mathématique d’un nombre.

Exemple :

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spécifie la racine mathématique du degré indiqué à partir de l’argument fourni.

Exemple :

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Définit la limite supérieure ou inférieure. Ici, « upper » et « lower » indiquent simplement la position de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées en combinant les classes [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) ainsi que les opérations de [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) :

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

Les méthodes **nary** et **integral** créent et renvoient l’opérateur n‑aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). Dans la méthode nary, l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) précise le type d’opérateur : sommation, union, etc., sans les intégrales. Dans la méthode Integral, l’énumération [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes) précise les types d’intégrales.

Exemple :

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **Méthode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Méthode [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) : ajoute un accent (caractère au‑dessus de l’élément).
- Méthodes [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) et [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) : ajoutent une barre au‑dessus ou au‑dessous.
- Méthode [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) : regroupe en utilisant un caractère de regroupement tel qu’une accolade inférieure ou autre.
- Méthode [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) : place dans un cadre bordé.
- Méthode [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) : place dans une boîte logique non visuelle (groupement).

Exemples :

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**Comment ajouter une équation mathématique à une diapositive PowerPoint ?**

Pour ajouter une équation, créez un objet forme mathématique, qui contient automatiquement une portion mathématique. Ensuite, récupérez le [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) depuis la [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) et ajoutez‑y des objets [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides permet de créer des expressions complexes en imbriquant des MathBlocks. Chaque élément mathématique offre des opérations (Join, Divide, Enclose, etc.) pour les combiner en structures plus élaborées.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, accédez aux MathBlocks existants via le [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Ensuite, à l’aide des méthodes telles que Join, Divide, Enclose, etc., modifiez les éléments individuels. Après modification, sauvegardez la présentation pour appliquer les changements.