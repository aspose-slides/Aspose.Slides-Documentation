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
- ajouter un texte mathématique
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Insérez et modifiez des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour PHP via Java, en prenant en charge OMML, les contrôles de mise en forme et des exemples de code clairs."
---

## **Vue d'ensemble**
Dans PowerPoint, il est possible d’écrire une équation ou une formule mathématique et de l’afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l’équation. Le constructeur d’équations mathématiques de PowerPoint permet de créer des formules complexes telles que :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n‑aires
- Matrice
- Opérateurs larges
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion → Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela crée un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Cependant, créer des équations complexes dans PowerPoint ne donne souvent pas un résultat professionnel. Les utilisateurs qui doivent régulièrement créer des présentations mathématiques ont recours à des solutions tierces pour obtenir des formules esthétiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de façon programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles existantes. L’exportation des structures mathématiques vers des images est également partiellement prise en charge.


## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire des constructions mathématiques avec n’importe quel niveau d’imbrication. Une collection linéaire d’éléments forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) désigne essentiellement une expression, une formule ou une équation séparée. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes susmentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

Voyons comment créer l’équation mathématique suivante via l’API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, commencez par ajouter une forme qui contiendra le texte mathématique :
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


## **Types d’éléments mathématiques**
Les expressions mathématiques sont formées à partir de séquences d’éléments mathématiques. La séquence est représentée par un bloc mathématique, et les arguments des éléments forment une imbrication arborescente.

Il existe de nombreux types d’éléments qui peuvent être utilisés pour construire un bloc mathématique. Chaque élément peut être inclus (agrégé) dans un autre élément, formant ainsi une structure arborescente. Le type le plus simple d’élément ne contient pas d’autres éléments du texte mathématique.

Chaque type d’élément implémente la classe `MathElement`, permettant l’utilisation d’un ensemble commun d’opérations mathématiques sur différents types d’éléments.

### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) représente un texte mathématique – l’élément sous‑jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables et tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) spécifie l’objet fraction, composé d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale selon les propriétés de la fraction. L’objet fraction sert également à représenter la fonction « stack », qui place un élément au-dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) spécifie la fonction radicale (racine mathématique), composée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) spécifie une fonction d’un argument. Elle contient les propriétés : [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) – nom de la fonction et [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) – argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) spécifie un objet mathématique n‑aire, tel que la sommation ou l’intégrale. Elle comprend un opérateur, une base (ou opérande) et des limites supérieures et inférieures optionnelles. Les exemples d’opérateurs n‑aires sont la sommation, l’union, l’intersection, l’intégrale.

Cette classe n’inclut pas les opérateurs simples tels que addition ou soustraction ; ceux‑ci sont représentés par un seul élément texte – [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) crée une limite supérieure ou inférieure. Elle spécifie un objet limite composé du texte sur la ligne de base et d’un texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n’inclut pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression

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

Ces classes spécifient un indice inférieur ou supérieur. Vous pouvez définir simultanément un indice et un exposant du côté gauche ou droit d’un argument, mais un indice ou un exposant seul n’est pris en charge que du côté droit. La classe [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) peut également être utilisée pour définir le degré mathématique d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) spécifie l’objet Matrice, composé d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Notez que les matrices n’ont pas de délimiteurs intégrés. Pour placer la matrice entre crochets, utilisez l’objet délimiteur – [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/). Des arguments nuls peuvent être utilisés pour créer des espaces vides dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) spécifie un tableau vertical d’équations ou de tout objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**
- Classe [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) : dessine un cadre rectangulaire ou autre autour du `MathElement`.

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Classe [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) : spécifie l’encapsulation logique de l’élément mathématique. Par exemple, un objet encadré peut servir d’émulateur d’opérateur avec ou sans point d’alignement, servir de point de rupture de ligne ou être groupé afin d’interdire les sauts de ligne à l’intérieur. Ainsi, l’opérateur « == » doit être encadré pour éviter les ruptures de ligne.
- Classe [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) : spécifie l’objet délimiteur, composé de caractères ouvrants et fermants (parenthèses, accolades, crochets, barres verticales) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié. Exemples : (𝑥²); [𝑥²|𝑦²].

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Classe [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) : spécifie la fonction accent, composée d’une base et d’un signe diacritique combiné.

  Exemple : 𝑎́.

- Classe [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) : spécifie la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) : spécifie un symbole de regroupement au-dessus ou en dessous d’une expression, généralement pour mettre en relief les relations entre les éléments.

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations mathématiques**
Chaque élément et chaque expression (via [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) hérite de la classe `MathElement`. Elle permet d’appliquer des opérations sur la structure existante et de former des expressions plus complexes. Toutes les opérations acceptent deux jeux de paramètres : soit un `MathElement`, soit une chaîne de caractères. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) sont créées implicitement à partir des chaînes lorsqu’elles sont utilisées comme arguments. Les opérations disponibles sont listées ci‑dessous.

### **Méthode Join**
- `join(String)`
- `join(MathElement)`

Joint un élément mathématique et forme un bloc.

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Méthode Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Crée une fraction du type spécifié avec ce numérateur et le dénominateur indiqué.

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Méthode Enclose**
- `enclose()`
- `enclose(Char, Char)`

Encadre l’élément avec les caractères spécifiés (parenthèses, etc.).

```php

``` 

Par exemple :

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Méthode Function**
- `function(String)`
- `function(MathElement)`

Applique une fonction à un argument en utilisant l’objet actuel comme nom de fonction.

```php

``` 

Par exemple :

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **Méthode AsArgumentOfFunction**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Utilise la fonction spécifiée en traitant l’instance actuelle comme argument. Vous pouvez :

- spécifier le nom de fonction sous forme de chaîne, par ex. “cos”.
- choisir une valeur prédéfinie des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), par ex. [**MathFunctionsOfOneArgument::ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- passer une instance de `MathElement`.

Par exemple :

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Définit les indices et exposants. Vous pouvez les définir simultanément à gauche ou à droite de l’argument, mais un seul indice ou exposant seul n’est supporté que du côté droit. Le **Superscript** peut également servir à indiquer le degré d’un nombre.

Exemple :

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- `radical(String)`
- `radical(MathElement)`

Spécifie la racine mathématique du degré indiqué à partir de l’argument donné.

Exemple :

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Définit la limite supérieure ou inférieure. Ici, les termes « upper » et « lower » indiquent simplement la position de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

Ces expressions peuvent être créées en combinant les classes [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit), ainsi que les opérations de `MathElement` :

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Méthodes Nary et Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Les deux méthodes créent et renvoient l’opérateur n‑aire représenté par le type [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator). Dans la méthode nary, l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) spécifie le type d’opérateur : sommation, union, etc., sans les intégrales. La méthode Integral utilise l’opération spécialisée intégrale avec l’énumération des types d’intégrale [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

Exemple :

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **Méthode ToMathArray**
`MathElement.toMathArray` place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Méthode **`accent`** : ajoute un signe d’accent (caractère au‑dessus de l’élément).
- Méthodes **`overbar`** et **`underbar`** : ajoutent une barre au‑dessus ou en dessous.
- Méthode **`group`** : regroupe en utilisant un caractère de groupement tel qu’une accolade inférieure ou autre.
- Méthode **`toBorderBox`** : place l’élément dans un cadre.
- Méthode **`toBox`** : place l’élément dans une boîte logique non visuelle.

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

Oui, Aspose.Slides permet de créer des expressions complexes en imbriquant des MathBlocks. Chaque élément mathématique peut être combiné à l’aide d’opérations (Join, Divide, Enclose, etc.) pour former des structures plus élaborées.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, accédez aux MathBlocks existants via le [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Ensuite, en utilisant des méthodes comme Join, Divide, Enclose, etc., modifiez les éléments individuels de l’équation. Après modification, enregistrez la présentation pour appliquer les changements.