---
title: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /fr/androidjava/powerpoint-math-equations/
keywords: " Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint"
description: "Équations Mathématiques PowerPoint, Symboles Mathématiques PowerPoint, Formule PowerPoint, Texte Mathématique PowerPoint"
---

## **Aperçu**
Dans PowerPoint, il est possible d'écrire une équation ou une formule mathématique et de l'afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l'équation. Pour cela, le constructeur d'équations mathématiques est utilisé dans PowerPoint, ce qui aide à créer des formules complexes telles que :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n-aires
- Matrice
- Grands opérateurs
- Fonctions sinus, cosinus

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insérer -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela créera un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit : 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations mathématiques. Cependant, créer des équations mathématiques compliquées dans PowerPoint ne donne souvent pas un résultat bon et professionnel. Les utilisateurs qui ont fréquemment besoin de créer des présentations mathématiques recourent à des solutions tierces pour créer de bonnes formules mathématiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de manière programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà créées. L'exportation de structures mathématiques sous forme d'images est également partiellement prise en charge.


## **Comment Créer une Équation Mathématique**
Les éléments mathématiques sont utilisés pour construire des constructions mathématiques avec n'importe quel niveau de nesting. Une collection linéaire d'éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) est essentiellement une expression mathématique, une formule ou une équation séparée. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes mentionnées ci-dessus sont la clé pour travailler avec les équations mathématiques PowerPoint via Aspose.Slides API.

Voyons comment nous pouvons créer l'équation mathématique suivante via Aspose.Slides API :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, vous devez d'abord ajouter une forme qui contiendra le texte mathématique :

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Après la création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) est une portion qui contient un texte mathématique à l'intérieur. Pour accéder au contenu mathématique à l'intérieur de [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion), référez-vous à la variable [**MathParagraph** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) :

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

La classe [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permet de lire, d'ajouter, de modifier et de supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), qui consistent en une combinaison d'éléments mathématiques. Par exemple, créez une fraction et placez-la dans la présentation :

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Chaque élément mathématique est représenté par une classe qui implémente l'interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression mathématique assez complexe avec une seule ligne de code. Par exemple, le théorème de Pythagore se présenterait comme suit :

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Les opérations de l'interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) sont mises en œuvre dans tout type d'élément, y compris le [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

Le code source complet :

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);

    IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
    
    IMathFraction fraction = new MathematicalText("x").divide("y");

    mathParagraph.add(new MathBlock(fraction));

    IMathBlock mathBlock = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);

    pres.save("math.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
``` 

## **Types d'Éléments Mathématiques**
Les expressions mathématiques sont formées à partir de séquences d'éléments mathématiques. La séquence d'éléments mathématiques est représentée par un bloc mathématique, et les arguments des éléments mathématiques forment un nesting de type arbre.

Il existe de nombreux types d'éléments mathématiques qui peuvent être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être inclus (agrégé) dans un autre élément. C'est-à-dire que les éléments sont en fait des conteneurs pour d'autres, formant une structure en arbre. Le type d'élément le plus simple qui ne contient pas d'autres éléments est le texte mathématique.

Chaque type d'élément mathématique implémente l'interface [**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), permettant l'utilisation d'un ensemble commun d'opérations mathématiques sur différents types d'éléments mathématiques.
### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) représente un texte mathématique - l'élément sous-jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes et des opérateurs, des variables et tout autre texte linéaire.

Exemple: 𝑎=𝑏+𝑐
### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) spécifie l'objet fraction, consistant en un numérateur et un dénominateur séparés par une barre fractionnaire. La barre fractionnaire peut être horizontale ou diagonale, en fonction des propriétés de la fraction. L'objet fraction est également utilisé pour représenter la fonction empilée, qui place un élément au-dessus d'un autre, sans barre fractionnaire.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) spécifie la fonction radicale (racine mathématique), consistant en une base et un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) spécifie une fonction d'un argument. Contient les propriétés : [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) - nom de la fonction et [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) - argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) spécifie un objet mathématique n-aire, tel que Somme et Intégral. Il se compose d'un opérateur, d'une base (ou opérande) et de limites supérieures et inférieures optionnelles. Des exemples d'opérateurs n-aires incluent la Somme, l'Union, l'Intersection, l'Intégral.

Cette classe n'inclut pas les opérateurs simples tels que l'addition, la soustraction, etc. Ils sont représentés par un seul élément de texte - [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) crée la limite supérieure ou inférieure. Elle spécifie l'objet limite, consistant en du texte sur la ligne de base et du texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n'inclut pas le mot “lim", mais permet de placer du texte en haut ou en bas de l'expression. Ainsi, l'expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l'aide d'une combinaison des éléments [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) de cette manière :

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Les classes suivantes spécifient un indice inférieur ou un indice supérieur. Vous pouvez définir un indice et un exposant en même temps à gauche ou à droite d'un argument, mais un seul sous-indice ou exposant est supporté uniquement sur le côté droit. L'élément [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) spécifie l'objet Matrice, consistant en des éléments enfants disposés en une ou plusieurs lignes et colonnes. Il est important de noter que les matrices n'ont pas de délimiteurs intégrés. Pour placer la matrice dans des parenthèses, vous devez utiliser l'objet délimiteur - [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) spécifie un tableau vertical d'équations ou de tout objet mathématique.

Exemple : 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatage des Éléments Mathématiques**
- La classe [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox) : dessine une bordure rectangulaire ou une autre autour de l'[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La classe [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox) : spécifie l'encapsulation logique (l'emballage) de l'élément mathématique. Par exemple, un objet encadré peut servir d'émulateur d'opérateur avec ou sans point d'alignement, servir de point de rupture de ligne, ou être groupé de manière à ne pas permettre de ruptures de ligne à l'intérieur. Par exemple, l'opérateur "==" doit être encadré pour éviter les ruptures de ligne.
- La classe [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter) : spécifie l'objet délimiteur, consistant en des caractères d'ouverture et de fermeture (tels que des parenthèses, accolades, crochets et barres verticales), et un ou plusieurs éléments mathématiques à l'intérieur, séparés par un caractère spécifié. Exemples : (𝑥2); [𝑥2|𝑦2].
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La classe [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent) : spécifie la fonction d'accent, consistant en une base et un signe diacritique combinant.

  Exemple : 𝑎́.

- La classe [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar) : spécifie la fonction de barre, consistant en un argument de base et une barre supérieure ou inférieure.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter) : spécifie un symbole de regroupement au-dessus ou en dessous d'une expression, généralement pour mettre en évidence les relations entre les éléments.
  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations Mathématiques**
Chaque élément mathématique et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implémente l'interface [**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Cela vous permet d'utiliser des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations ont deux ensembles de paramètres : soit [**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), soit une chaîne comme arguments. Les instances de la classe [**MathematicalText** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) sont implicitement créées à partir des chaînes spécifiées lorsque des arguments de chaîne sont utilisés. Les opérations mathématiques disponibles dans Aspose.Slides sont listées ci-dessous.
### **Méthode Join**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Joint un élément mathématique et forme un bloc mathématique. Par exemple :

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Méthode Divide**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Crée une fraction du type spécifié avec ce numérateur et le dénominateur spécifié. Par exemple :

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Méthode Enclose**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Enclôt l'élément dans les caractères spécifiés tels que des parenthèses ou un autre caractère comme cadre.

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


Par exemple :

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Méthode Function**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Prend une fonction d'un argument en utilisant l'objet actuel comme nom de fonction.

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


Par exemple :

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **Méthode AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Prend la fonction spécifiée en utilisant l'instance actuelle comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par exemple “cos”.
- sélectionner l'une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments), par exemple [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- sélectionner l'instance de l'[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

Par exemple :

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Définit l'indice inférieur et l'indice supérieur. Vous pouvez définir un indice et un exposant en même temps à gauche ou à droite de l'argument, mais un seul sous-indice ou exposant est supporté uniquement sur le côté droit. Le **Superscript** peut également être utilisé pour définir le degré mathématique d'un nombre.

Exemple :

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spécifie la racine mathématique du degré donné à partir de l'argument spécifié.

Exemple :

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Prend la limite supérieure ou inférieure. Ici, le haut et le bas indiquent simplement la position de l'argument par rapport à la base.

Considérons une expression : 

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées à l'aide d'une combinaison des classes [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit), et des opérations de l'[IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) comme suit :

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Méthodes Nary et Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Les méthodes **nary** et **integral** créent et renvoient l'opérateur n-aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). Dans la méthode nary, l'énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) spécifie le type d'opérateur : somme, union, etc., n'incluant pas les intégrales. Dans la méthode Integral, il s'agit de l'opération spécialisée Intégral avec l'énumération des types d'intégrale [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes). 

Exemple :

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Méthode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) place des éléments dans un tableau vertical. Si cette opération est appelée pour une instance de [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Opérations de Formatage : Accent, Barre supérieure, Barre inférieure, Regroupement, ToBorderBox, ToBox**
- La méthode **accent** [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) place un accent (un caractère au sommet de l'élément).
- Les méthodes **overbar** [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) et **underbar** [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) placent une barre au-dessus ou en dessous.
- La méthode **group** [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) place dans un groupe en utilisant un caractère de regroupement tel qu'une accolade inférieure ou autre.
- La méthode **toBorderBox** [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) place dans une border-box.
- La méthode **toBox** [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) place dans une boîte non visualisée (groupement logique).

Exemples :

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 