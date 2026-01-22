---
title: Ajouter des équations mathématiques aux présentations PowerPoint en JavaScript
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour Node.js, prenant en charge OMML, les contrôles de mise en forme et des exemples de code clairs."
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
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion → Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela crée un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Cependant, la création d’équations complexes dans PowerPoint ne donne souvent pas un résultat professionnel. Les utilisateurs qui créent fréquemment des présentations mathématiques ont recours à des solutions tierces pour obtenir des formules esthétiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de façon programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà existantes. L’exportation des structures mathématiques vers des images est également partiellement prise en charge.


## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire toute construction mathématique avec n’importe quel niveau d’imbrication. Une collection linéaire d’éléments forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) est essentiellement une expression, une formule ou une équation mathématique séparée. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes mentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

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

Après création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique de la [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion), référez‑vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) :

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

La classe [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), qui sont composés d’une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Chaque élément mathématique est représenté par une classe implémentant la classe **MathElement**. Cette classe fournit de nombreuses méthodes pour créer facilement des expressions. Vous pouvez créer une expression assez complexe en une seule ligne de code. Par exemple, le théorème de Pythagore s’écrirait ainsi :

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Les opérations de la classe **MathElement** sont implémentées dans tout type d’élément, y compris le [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

Exemple complet :

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

## **Types d’éléments mathématiques**
Les expressions mathématiques sont formées à partir de séquences d’éléments. La séquence est représentée par un bloc mathématique, et les arguments des éléments forment une imbrication en forme d’arbre.

Il existe de nombreux types d’éléments pouvant être utilisés pour construire un bloc mathématique. Chaque élément peut être inclus (agrégé) dans un autre élément, formant ainsi une structure arborescente. Le type le plus simple ne contient aucun autre élément du texte mathématique.

Chaque type d’élément implémente la classe **MathElement**, permettant l’utilisation d’un ensemble commun d’opérations sur différents types d’éléments.

### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) représente du texte mathématique — l’élément de base de toutes les constructions. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables, ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) décrit un objet fraction, composé d’un numérateur et d’un dénominateur séparés par une barre. La barre peut être horizontale ou diagonale, selon les propriétés. Elle sert aussi à représenter la fonction « stack », plaçant un élément au-dessus d’un autre sans barre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) décrit la fonction radicale (racine), composée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) décrit une fonction d’un argument. Elle possède les propriétés : [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) — nom de la fonction, et [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) — argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) décrit un objet mathématique n‑aire, tel que la sommation ou l’intégrale. Elle se compose d’un opérateur, d’une base (ou opérande) et d’éventuelles limites supérieure et inférieure. Les opérateurs simples comme + ou – ne sont pas inclus ; ils sont représentés par un élément texte simple — [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) crée une limite supérieure ou inférieure. Elle consiste en du texte sur la ligne de base et du texte réduit placé immédiatement au-dessus ou en dessous. L’élément ne comprend pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression suivante :

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée via une combinaison de [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) :

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Ces classes spécifient respectivement un indice inférieur ou supérieur. Vous pouvez définir simultanément indice et exposant à gauche ou à droite d’un argument, mais un seul indice ou exposant seul n’est supporté que du côté droit. L’[MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) peut également servir à définir le degré mathématique d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) décrit un objet matrice, composé d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Les matrices n’ont pas de délimiteurs intégrés ; pour les placer entre parenthèses, il faut utiliser l’objet délimiteur — [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Des arguments nuls peuvent créer des espaces vides dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) définit un tableau vertical d’équations ou de tout objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**
- **MathBorderBox** : dessine un contour rectangulaire (ou autre) autour de l’**MathElement**.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** : spécifie un emballage logique de l’élément mathématique. Par exemple, un objet encadré peut servir d’émulateur d’opérateur avec ou sans point d’alignement, servir de rupture de ligne, ou être groupé afin d’interdire les sauts de ligne. Exemple : l’opérateur « == » doit être encadré pour éviter les ruptures de ligne.

- **MathDelimiter** : définit l’objet délimiteur, composé de caractères d’ouverture et de fermeture (parenthèses, accolades, crochets, barres verticales) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** : définit la fonction accent, composée d’une base et d’une marque diacritique combinée.  
  Exemple : 𝑎́.

- **MathBar** : définit la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** : définit un symbole de regroupement au-dessus ou en dessous d’une expression, généralement pour mettre en évidence les relations entre les éléments.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations mathématiques**
Chaque élément et chaque expression (via [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) implémente la classe **MathElement**. Elle permet d’appliquer des opérations sur la structure existante et de former des expressions plus complexes. Toutes les opérations acceptent deux jeux de paramètres : soit un **MathElement**, soit une chaîne de caractères. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) sont créées implicitement à partir des chaînes fournies. Les opérations disponibles sont répertoriées ci‑dessous.

### **Méthode Join**
- `join(String)`
- `join(MathElement)`

Joint un élément mathématique pour former un bloc. Exemple :

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Méthode Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Crée une fraction du type indiqué avec ce numérateur et ce dénominateur. Exemple :

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Méthode Enclose**
- `enclose()`
- `enclose(Char, Char)`

Encadre l’élément avec les caractères spécifiés (parenthèses ou autre).

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
- `function(String)`
- `function(MathElement)`

Prend une fonction d’un argument en utilisant l’objet actuel comme nom de fonction.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

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
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Utilise l’instance courante comme argument d’une fonction spécifiée. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par ex. “cos”.
- sélectionner une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments), par ex. [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- fournir une instance de **MathElement**.

Exemple :

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
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

Définit les indices et exposants. Vous pouvez les appliquer simultanément à gauche ou à droite, mais un indice ou exposant seul n’est supporté que du côté droit. L’**Superscript** peut également servir à indiquer le degré d’un nombre.

Exemple :

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- `radical(String)`
- `radical(MathElement)`

Spécifie la racine mathématique du degré indiqué à partir de l’argument fourni.

Exemple :

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Définit la limite supérieure ou inférieure. Ici, « upper » et « lower » indiquent simplement la position de l’argument par rapport à la base.

Considérons l’expression suivante :

![todo:image_alt_text](powerpoint-math-equations_8.png)

Elle peut être créée grâce à une combinaison des classes [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit), ainsi que des opérations de `MathElement` :

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Méthodes Nary et Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Les deux méthodes créent et renvoient un opérateur n‑aire représenté par le type [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator). Dans la méthode *nary*, l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) indique le type d’opérateur (sommation, union, etc.), excluant les intégrales. La méthode *integral* traite l’opération d’intégrale avec l’énumération des types d’intégrale [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes).

Exemple :

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **Méthode ToMathArray**
**toMathArray** place les éléments dans un tableau vertical. Si elle est appelée sur une instance de [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent** : ajoute un accent (caractère au-dessus de l’élément).  
- **overbar** et **underbar** : ajoutent une barre au-dessus ou en dessous.  
- **group** : regroupe avec un caractère de groupement tel qu’une accolade inférieure ou autre.  
- **toBorderBox** : place l’élément dans une bordure.  
- **toBox** : place l’élément dans une boîte logique non visuelle.

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

Pour ajouter une équation, créez un objet `MathShape`, qui contient automatiquement une portion mathématique. Récupérez ensuite le `MathParagraph` depuis le `MathPortion` et ajoutez‑y des objets `MathBlock`.

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides permet de créer des expressions imbriquées en imbriquant des `MathBlock`. Chaque élément hérite de la classe `MathElement`, ce qui vous permet d’appliquer des opérations (Join, Divide, Enclose, etc.) pour les combiner en structures plus complexes.

**Comment mettre à jour ou modifier une équation existante ?**

Accédez aux `MathBlock` existants via le `MathParagraph`. Ensuite, utilisez les méthodes telles que Join, Divide, Enclose, etc., pour modifier les éléments de l’équation. Après les changements, enregistrez la présentation pour appliquer les modifications.