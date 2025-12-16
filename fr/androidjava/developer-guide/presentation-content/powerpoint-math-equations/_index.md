---
title: Ajouter des équations mathématiques aux présentations PowerPoint sur Android
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour Android, prenant en charge OMML, les contrôles de formatage et des exemples de code Java clairs."
---

## **Vue d'ensemble**
Dans PowerPoint, il est possible d’écrire une équation ou une formule mathématique et de l’afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l’équation. Pour cela, le constructeur d’équations mathématiques est utilisé dans PowerPoint, ce qui permet de créer des formules complexes comme :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n-aires
- Matrice
- Opérateurs larges
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion → Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela crée un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Cependant, la création d’équations mathématiques compliquées dans PowerPoint ne donne souvent pas un résultat professionnel et de bonne qualité. Les utilisateurs qui doivent créer fréquemment des présentations mathématiques ont recours à des solutions tierces pour obtenir des formules esthétiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/), vous pouvez travailler avec des équations mathématiques dans les présentations PowerPoint de façon programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà existantes. L’exportation des structures mathématiques vers des images est également partiellement prise en charge.

## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire toute construction mathématique avec n’importe quel niveau d’imbrication. Une collection linéaire d’éléments mathématiques forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) représente essentiellement une expression, une formule ou une équation mathématique séparée. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes sus‑mentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

Voyons comment créer l’équation mathématique suivante via l’API Aspose.Slides :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique sur la diapositive, ajoutez d’abord une forme qui contiendra le texte mathématique :

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Après création, la forme contiendra déjà un paragraphe avec une portion mathématique par défaut. La classe [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique à l’intérieur de la [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion), référez‑vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) :

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

La classe [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), qui consistent en une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Chaque élément mathématique est représenté par une classe qui implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression mathématique assez complexe en une seule ligne de code. Par exemple, le théorème de Pythagore s’écrirait ainsi :

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Les opérations de l’interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) sont implémentées dans tout type d’élément, y compris le [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

Exemple complet de code source :

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

## **Types d’éléments mathématiques**
Les expressions mathématiques sont constituées de séquences d’éléments mathématiques. La séquence d’éléments mathématiques est représentée par un bloc mathématique, et les arguments des éléments forment une imbrication en forme d’arbre.

Il existe de nombreux types d’éléments mathématiques qui peuvent être utilisés pour construire un bloc mathématique. Chaque élément peut être inclus (agrégé) dans un autre élément. Ainsi, les éléments sont en fait des conteneurs pour d’autres, formant une structure arborescente. Le type d’élément le plus simple ne contient pas d’autres éléments du texte mathématique.

Chaque type d’élément mathématique implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), permettant l’utilisation d’un jeu commun d’opérations mathématiques sur différents types d’éléments.

### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) représente un texte mathématique – l’élément sous‑jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) spécifie l’objet fraction, constitué d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale, selon les propriétés de la fraction. L’objet fraction est également utilisé pour représenter la fonction « stack », qui place un élément au‑dessus d’un autre, sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) spécifie la fonction radicale (racine mathématique), constituée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) spécifie une fonction d’un argument. Elle possède les propriétés : [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) – nom de la fonction et [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) – argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) spécifie un objet mathématique n‑aire, tel que la somme ou l’intégrale. Elle comprend un opérateur, une base (ou opérande) et des limites supérieures et inférieures optionnelles. Des exemples d’opérateurs n‑aires sont la sommation, l’union, l’intersection, l’intégrale.

Cette classe n’inclut pas les opérateurs simples tels que l’addition ou la soustraction. Ceux‑ci sont représentés par un seul élément texte – [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) crée une limite supérieure ou inférieure. Elle spécifie l’objet limite, constitué d’un texte sur la ligne de base et d’un texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n’inclut pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression  

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l’aide d’une combinaison des éléments [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) de la manière suivante :

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Ces classes spécifient un indice inférieur ou supérieur. Vous pouvez définir un indice et un exposant simultanément à gauche ou à droite d’un argument, mais un seul indice ou exposant n’est pris en charge qu’à droite. Le [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) peut également être utilisé pour définir le degré mathématique d’un nombre.

Exemple :  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) spécifie l’objet matrice, constitué d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Il faut noter que les matrices ne possèdent pas de délimiteurs intégrés. Pour placer la matrice entre crochets, utilisez l’objet délimiteur – [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) spécifie un tableau vertical d’équations ou de tout autre objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**
- Classe [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox) : dessine une bordure rectangulaire ou autre autour du [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Classe [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox) : spécifie le groupement logique (boîtage) de l’élément mathématique. Par exemple, un objet boîté peut servir d’émulateur d’opérateur avec ou sans point d’alignement, servir de rupture de ligne, ou être groupé afin d’empêcher les sauts de ligne à l’intérieur. Ainsi, l’opérateur « == » devrait être boîté pour empêcher les ruptures de ligne.

- Classe [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter) : spécifie l’objet délimiteur, composé de caractères d’ouverture et de fermeture (parenthèses, accolades, crochets, barres verticales) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié. Exemples : (𝑥2); [𝑥2|𝑦2].  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Classe [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent) : spécifie la fonction accent, composée d’une base et d’une marque diacritique combinée.  
  Exemple : 𝑎́.

- Classe [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar) : spécifie la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter) : spécifie un symbole de groupement au‑dessus ou au‑dessous d’une expression, généralement pour mettre en évidence les relations entre les éléments.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations mathématiques**
Chaque élément mathématique et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Elle permet d’appliquer des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations possèdent deux jeux de paramètres : soit [**IMathElement**] soit une chaîne de caractères comme arguments. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) sont créées implicitement à partir des chaînes spécifiées lorsqu’on utilise des arguments de type string. Les opérations mathématiques disponibles dans Aspose.Slides sont répertoriées ci‑dessous.

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

Crée une fraction du type spécifié avec ce numérateur et le dénominateur indiqué. Par exemple :

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Méthode Enclose**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Entoure l’élément avec les caractères spécifiés, tels que des parenthèses ou d’autres caractères de cadrage.

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

Prend une fonction d’un argument en utilisant l’objet courant comme nom de fonction.

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

Prend la fonction spécifiée en utilisant l’instance courante comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par exemple « cos ».
- choisir une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments), par exemple [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- fournir une instance de [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

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

Définit les indices et exposants. Vous pouvez définir un indice et un exposant simultanément à gauche ou à droite de l’argument, mais un seul indice ou exposant n’est pris en charge qu’à droite. L’**exposant** peut aussi être utilisé pour définir le degré mathématique d’un nombre.

Exemple :

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spécifie la racine mathématique du degré indiqué à partir de l’argument spécifié.

Exemple :

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Définit la limite supérieure ou inférieure. Ici, les limites indiquent simplement la position de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées à l’aide d’une combinaison des classes [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit), et des opérations de [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) comme suit :

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

Les méthodes **nary** et **integral** créent et renvoient l’opérateur N‑aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). Dans la méthode nary, l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) spécifie le type d’opérateur : sommation, union, etc., sans inclure les intégrales. Dans la méthode Integral, il existe une opération spécialisée Intégrale avec l’énumération des types d’intégrale [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes).

Exemple :

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Méthode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Méthode [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) : définit un accent (un caractère au-dessus de l’élément).  
- Méthodes [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) et [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) : définissent respectivement une barre au dessus ou en dessous.  
- Méthode [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) : place l’élément dans un groupe à l’aide d’un caractère de groupement tel qu’une accolade inférieure ou autre.  
- Méthode [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) : place l’élément dans une boîte bordée.  
- Méthode [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) : place l’élément dans une boîte logique non visuelle (groupement).

Exemples :

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**Comment ajouter une équation mathématique à une diapositive PowerPoint ?**

Pour ajouter une équation mathématique, créez un objet forme mathématique, qui contient automatiquement une portion mathématique. Ensuite, récupérez le [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) depuis la [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) et ajoutez‑y des objets [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

**Est‑il possible de créer des expressions mathématiques complexes imbriquées ?**

Oui, Aspose.Slides permet de créer des expressions mathématiques complexes en imbriquant des MathBlocks. Chaque élément mathématique implémente l’interface [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), ce qui permet d’appliquer des opérations (Join, Divide, Enclose, etc.) pour combiner les éléments en structures plus complexes.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, accédez aux MathBlocks existants via le [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Ensuite, en utilisant des méthodes telles que Join, Divide, Enclose, etc., vous pouvez modifier les éléments individuels de l’équation. Après modification, enregistrez la présentation pour appliquer les changements.