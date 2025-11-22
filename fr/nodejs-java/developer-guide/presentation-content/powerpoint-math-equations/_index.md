---
title: PowerPoint Équations Mathématiques
type: docs
weight: 80
url: /fr/nodejs-java/powerpoint-math-equations/
keywords: " PowerPoint Équations Mathématiques, PowerPoint Symboles Mathématiques, PowerPoint Formule, PowerPoint Texte Mathématique"
description: "PowerPoint Équations Mathématiques, PowerPoint Symboles Mathématiques, PowerPoint Formule, PowerPoint Texte Mathématique"
---

## **Vue d'ensemble**
Dans PowerPoint, il est possible d’écrire une équation ou une formule mathématique et de l’afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l’équation. Le constructeur d’équations mathématiques de PowerPoint aide à créer des formules complexes telles que :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n‑aires
- Matrice
- Opérateurs larges
- Fonctions sinus, cosinus

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insert -> Equation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela créera un texte mathématique en XML qui pourra être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Cependant, créer des équations compliquées dans PowerPoint ne donne pas toujours un résultat professionnel. Les utilisateurs qui ont fréquemment besoin de créer des présentations mathématiques se tournent vers des solutions tierces pour obtenir des formules bien présentées.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de façon programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà créées. L’exportation de structures mathématiques vers des images est également prise en charge partiellement.


## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire n’importe quelle construction mathématique avec n’importe quel niveau d’imbrication. Une collection linéaire d’éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) représente essentiellement une expression, une formule ou une équation mathématique séparée. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes citées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

Voyons comment créer l’équation mathématique suivante via l’API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, ajoutez d’abord une forme qui contiendra le texte mathématique :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

Après création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique à l’intérieur de [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion), faites référence à la variable [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) :

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

La classe [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), qui sont composés d’une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Chaque élément mathématique est représenté par une classe qui implémente la classe [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). Cette classe offre de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression assez complexe en une seule ligne de code. Par exemple, le théorème de Pythagore s’écrit ainsi :

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Les opérations de la classe [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) sont implémentées dans tout type d’élément, y compris dans la classe [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

Exemple complet de code source :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **Types d'éléments mathématiques**
Les expressions mathématiques sont formées à partir de séquences d’éléments mathématiques. La séquence d’éléments est représentée par un bloc mathématique, et les arguments des éléments forment une imbrication en forme d’arbre.

Il existe de nombreux types d’éléments qui peuvent être utilisés pour construire un bloc mathématique. Chaque élément peut être agrégé dans un autre élément. En d’autres termes, les éléments sont des conteneurs les uns pour les autres, formant une structure arborescente. Le type le plus simple d’élément ne contient aucun autre élément du texte mathématique.

Chaque type d’élément implémente la classe [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement), ce qui permet d’utiliser le même ensemble d’opérations mathématiques sur différents types d’éléments.

### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) représente un texte mathématique – l’élément sous‑jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) spécifie l’objet fraction, constitué d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale selon les propriétés de la fraction. L’objet fraction sert aussi à représenter la fonction « stack », qui place un élément au‑dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) spécifie la fonction radicale (racine mathématique), composée d’une base et, éventuellement, d’un degré.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) spécifie une fonction d’un argument. Elle possède les propriétés : [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) – nom de la fonction et [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) – argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) spécifie un objet mathématique n‑aire, tel que la sommation ou l’intégrale. Elle comprend un opérateur, une base (ou opérande) et des limites supérieures et inférieures optionnelles. Les opérateurs n‑aires incluent la sommation, l’union, l’intersection, l’intégrale, etc.

Cette classe ne regroupe pas les opérateurs simples comme l’addition ou la soustraction ; ceux‑ci sont représentés par un seul élément texte – [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) crée une limite supérieure ou inférieure. Elle définit l’objet limite, constitué du texte sur la ligne de base et d’un texte réduit placé immédiatement au‑dessus ou en dessous. Cet élément ne comprend pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l’aide d’une combinaison de [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) et de [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) :

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Ces classes spécifient un indice inférieur ou supérieur. Vous pouvez définir simultanément indice inférieur et supérieur à gauche ou à droite d’un argument, mais un indice simple n’est pris en charge qu’à droite. La classe [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) peut également être utilisée pour indiquer le degré d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) spécifie l’objet Matrice, constitué d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Notez que les matrices n’ont pas de délimiteurs intégrés. Pour placer la matrice entre crochets, utilisez l’objet délimiteur : [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Des arguments nuls permettent de créer des espaces vides dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) spécifie un tableau vertical d’équations ou de tout objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**
- [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox) : classe qui trace un bord rectangulaire ou autre autour du [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox) : classe qui spécifie l’encapsulation logique de l’élément mathématique. Par exemple, un objet encadré peut servir d’émulateur d’opérateur avec ou sans point d’alignement, de point de rupture de ligne, ou être groupé afin d’empêcher les sauts de ligne à l’intérieur. Ainsi, l’opérateur « == » doit être encadré pour éviter les ruptures de ligne.

- [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter) : classe qui spécifie l’objet délimiteur, composé de caractères ouvrants et fermants (parenthèses, accolades, crochets, barres verticales, etc.) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié. Exemples : (𝑥2) ; [𝑥2|𝑦2].

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent) : classe qui spécifie la fonction accent, composée d’une base et d’un signe diacritique combiné.

  Exemple : 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar) : classe qui spécifie la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter) : classe qui spécifie un symbole de regroupement au‑dessus ou en dessous d’une expression, généralement pour mettre en évidence les relations entre les éléments.

  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations mathématiques**
Chaque élément et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) implémente la classe [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). Elle permet d’appliquer des opérations sur la structure existante et de former des expressions plus complexes. Toutes les opérations acceptent deux jeux de paramètres : soit un [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) soit une chaîne de caractères. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) sont créées implicitement à partir des chaînes spécifiées lorsqu’on utilise des arguments de type chaîne. Les opérations mathématiques disponibles dans Aspose.Slides sont répertoriées ci‑dessous.

### **Méthode Join**
- [join(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-aspose.slides.IMathElement-)

Joint un élément mathématique et crée un bloc mathématique. Exemple :

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Méthode Divide**
- [divide(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-int-)

Crée une fraction du type spécifié avec ce numérateur et le dénominateur indiqué. Exemple :

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Méthode Enclose**
- [enclose()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose-char-char-)

Encadre l’élément avec les caractères spécifiés, comme des parenthèses ou un autre caractère.

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

Exemple :

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **Méthode Function**
- [function(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-aspose.slides.IMathElement-)

Prend une fonction d’un argument en utilisant l’objet actuel comme nom de fonction.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

Exemple :

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **Méthode AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-java.lang.String-)

Prend la fonction spécifiée en utilisant l’instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par exemple “cos”.
- choisir une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments), par exemple [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- sélectionner l’instance de [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

Exemple :

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-aspose.slides.IMathElement-aspose.slides.IMathElement-)

Définit les indices et exposants. Vous pouvez définir les deux simultanément à gauche ou à droite de l’argument, mais un indice simple ou un exposant seul n’est pris en charge qu’à droite. L’**exposant** peut également être utilisé pour indiquer le degré d’un nombre.

Exemple :

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- [radical(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-aspose.slides.IMathElement-)

Spécifie la racine mathématique du degré donné à partir de l’argument indiqué.

Exemple :

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-aspose.slides.IMathElement-)

Définit la limite supérieure ou inférieure. Ici, la position supérieure ou inférieure indique simplement la localisation de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées grâce à une combinaison des classes [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit), et aux opérations de [MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) :

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Méthodes Nary et Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-int-)

Les méthodes **nary** et **integral** créent et renvoient l’opérateur n‑aire représenté par le type [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator). Dans la méthode nary, l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) indique le type d’opérateur : sommation, union, etc., sans les intégrales. Dans la méthode Integral, l’énumération [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes) indique le type d’intégrale.

Exemple :

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **Méthode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toMathArray--) place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#accent-char-) : méthode qui ajoute un accent (caractère placé au‑dessus de l’élément).
- [**overbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#overbar--) et [**underbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#underbar--) : méthodes qui ajoutent une barre en haut ou en bas.
- [**group**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#group--) : méthode qui groupe à l’aide d’un caractère de regroupement tel qu’une accolade inférieure ou autre.
- [**toBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBorderBox--) : méthode qui place l’élément dans une bordure.
- [**toBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBox--) : méthode qui place l’élément dans une boîte logique non visuelle.

Exemples :

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **FAQ**

**Comment ajouter une équation mathématique à une diapositive PowerPoint ?**

Pour ajouter une équation, créez un objet `MathShape`, qui contient automatiquement une portion mathématique. Puis récupérez le `MathParagraph` depuis le `MathPortion` et ajoutez‑y des objets `MathBlock`.

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides permet de créer des expressions complexes en imbriquant des MathBlocks. Chaque élément mathématique implémente la classe `IMathElement`, qui autorise l’utilisation d’opérations (Join, Divide, Enclose, etc.) pour combiner les éléments en structures plus complexes.

**Comment mettre à jour ou modifier une équation existante ?**

Pour mettre à jour une équation, accédez aux MathBlocks existants via le `MathParagraph`. Ensuite, en utilisant des méthodes telles que Join, Divide, Enclose, etc., vous pouvez modifier les éléments individuels de l’équation. Après modification, enregistrez la présentation pour appliquer les changements.