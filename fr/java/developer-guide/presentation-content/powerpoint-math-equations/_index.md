---
title: Ajouter des équations mathématiques aux présentations PowerPoint en Java
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour Java, prenant en charge OMML, les contrôles de mise en forme et des exemples de code Java clairs."
---

## **Vue d’ensemble**
Dans PowerPoint, il est possible d’écrire une équation ou une formule mathématique et de l’afficher dans la présentation. Pour cela, divers symboles mathématiques sont représentés dans PowerPoint et peuvent être ajoutés au texte ou à l’équation. Le constructeur d’équations mathématiques de PowerPoint permet de créer des formules complexes comme :

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

PowerPoint prend en charge de nombreux symboles mathématiques pour créer des équations. Toutefois, la création d’équations complexes dans PowerPoint ne donne souvent pas un résultat professionnel. Les utilisateurs qui créent fréquemment des présentations mathématiques ont recours à des solutions tierces pour obtenir des formules esthétiques.

En utilisant [**Aspose.Slide API**](https://products.aspose.com/slides/java/), vous pouvez travailler avec les équations mathématiques dans les présentations PowerPoint de façon programmatique en C#. Créez de nouvelles expressions mathématiques ou modifiez celles déjà existantes. L’exportation des structures mathématiques vers des images est également partiellement prise en charge.


## **Comment créer une équation mathématique**
Les éléments mathématiques sont utilisés pour construire n’importe quelle construction mathématique, quel que soit le niveau d’imbrication. Une collection linéaire d’éléments forme un bloc mathématique représenté par la classe [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock). La classe [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) représente essentiellement une expression, une formule ou une équation distincte. [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) est une portion mathématique, utilisée pour contenir du texte mathématique (à ne pas confondre avec [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) permet de manipuler un ensemble de blocs mathématiques. Les classes mentionnées sont la clé pour travailler avec les équations mathématiques PowerPoint via l’API Aspose.Slides.

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

Après création, la forme contient déjà par défaut un paragraphe avec une portion mathématique. La classe [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique de la [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion), référez‑vous à la variable [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) :

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

La classe [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) permet de lire, d’ajouter, de modifier et de supprimer des blocs mathématiques ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), qui sont composés d’une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Chaque élément mathématique est représenté par une classe qui implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Cette interface fournit de nombreuses méthodes pour créer facilement des expressions mathématiques. Vous pouvez créer une expression assez complexe en une seule ligne de code. Par exemple, le théorème de Pythagore s’écrirait ainsi :

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Les opérations de l’interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) sont implémentées dans chaque type d’élément, y compris la [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

Exemple complet :

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
Les expressions mathématiques sont constituées de suites d’éléments mathématiques. La suite d’éléments forme un bloc mathématique, et les arguments des éléments créent une imbrication en forme d’arbre.

De nombreux types d’éléments peuvent être utilisés pour construire un bloc mathématique. Chaque élément peut être inclus (agrégé) dans un autre élément, formant ainsi une structure arborescente. Le type le plus simple d’élément ne contient aucun autre élément du texte mathématique.

Chaque type d’élément implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement), ce qui permet d’utiliser le même ensemble d’opérations sur différents types d’éléments.

### **Classe MathematicalText**
La classe [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) représente un texte mathématique – l’élément de base de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes, des opérateurs, des variables ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**
La classe [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) définit l’objet fraction, composé d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale selon les propriétés de la fraction. L’objet fraction sert également à représenter la fonction pile, qui place un élément au-dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**
La classe [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) définit la fonction radicale (racine mathématique), composée d’une base et, éventuellement, d’un degré.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**
La classe [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) définit une fonction d’un argument. Elle possède les propriétés : [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) – nom de la fonction, et [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) – argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**
La classe [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) définit un objet mathématique n‑aire, tel que la sommation ou l’intégrale. Il se compose d’un opérateur, d’une base (ou opérande) et de limites supérieure et inférieure optionnelles. Les opérateurs n‑aires comprennent la sommation, l’union, l’intersection, l’intégrale, etc.

Cette classe n’inclut pas les opérateurs simples comme l’addition ou la soustraction, qui sont représentés par un élément texte unique – [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**
La classe [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) crée une limite supérieure ou inférieure. Elle spécifie un objet limite composé d’un texte sur la ligne de base et d’un texte réduit placé immédiatement au-dessus ou au-dessous. Cet élément ne comprend pas le mot « lim », mais permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression

![todo:image_alt_text](powerpoint-math-equations_8.png)

est générée en combinant les éléments [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) et [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) ainsi :

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Ces classes définissent un indice inférieur ou un indice supérieur. Vous pouvez définir simultanément indice inférieur et supérieur du côté gauche ou droit d’un argument, mais un indice simple n’est supporté que du côté droit. L’[MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) peut également servir à indiquer le degré mathématique d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**
La classe [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) définit l’objet matrice, composé d’éléments enfants disposés en une ou plusieurs lignes et colonnes. Les matrices ne possèdent pas de délimiteurs intégrés. Pour entourer la matrice de crochets, utilisez l’objet délimiteur — [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). Des arguments nuls peuvent être employés pour créer des espaces vides dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**
La classe [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) définit un tableau vertical d’équations ou tout autre objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**
- Classe [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) : trace un rectangle ou tout autre contour autour de l’[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Classe [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) : spécifie un encadrement logique de l’élément mathématique. Par exemple, un objet encadré peut servir d’émulateur d’opérateur avec ou sans point d’alignement, de point de pause de ligne ou être groupé pour empêcher les retours à la ligne à l’intérieur.

- Classe [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) : définit l’objet délimiteur, composé de caractères d’ouverture et de fermeture (parenthèses, accolades, crochets, barres verticales, etc.) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Classe [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) : définit la fonction accent, composée d’une base et d’un signe diacritique combiné.  
  Exemple : 𝑎́.

- Classe [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) : définit la fonction barre, composée d’un argument de base et d’une barre supérieure ou inférieure.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Classe [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) : définit un symbole de regroupement au-dessus ou au-dessous d’une expression, généralement pour mettre en évidence les relations entre éléments.  
  Exemple : ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Opérations mathématiques**
Chaque élément et chaque expression mathématique (via [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) implémente l’interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Elle permet d’appliquer des opérations sur la structure existante et de former des expressions plus complexes. Toutes les opérations acceptent deux ensembles de paramètres : soit un [**IMathElement**] soit une chaîne de caractères. Les instances de la classe [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) sont créées implicitement à partir des chaînes fournies. Les opérations mathématiques disponibles dans Aspose.Slides sont listées ci‑dessous.

### **Méthode Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Joint un élément mathématique et forme un bloc mathématique. Exemple :

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Méthode Divide**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Crée une fraction du type spécifié avec ce numérateur et ce dénominateur. Exemple :

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Méthode Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Encadre l’élément avec les caractères spécifiés (parenthèses ou autre cadre).

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

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Méthode Function**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

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

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **Méthode AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Utilise l’instance actuelle comme argument de la fonction spécifiée. Vous pouvez :

- fournir une chaîne comme nom de fonction, par ex. « cos ».
- choisir une des valeurs prédéfinies des énumérations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) ou [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments), par ex. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- fournir une instance de [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

Exemple :

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Méthodes SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Définit les indices et exposants. Vous pouvez définir simultanément indice et exposant du côté gauche ou droit d’un argument, mais un seul indice simple n’est pris en charge que du côté droit. L’**exposant** peut également être utilisé pour indiquer le degré mathématique d’un nombre.

Exemple :

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Méthode Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spécifie la racine mathématique du degré indiqué à partir de l’argument donné.

Exemple :

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Méthodes SetUpperLimit et SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Définit la limite supérieure ou inférieure. Ici, les limites indiquent simplement la position de l’argument par rapport à la base.

Considérons l’expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

Ces expressions peuvent être créées en combinant les classes [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) et [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit), ainsi que les opérations de [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) :

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Méthodes Nary et Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Les méthodes **nary** et **integral** créent et renvoient l’opérateur n‑aire représenté par le type [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator). La méthode *nary* utilise l’énumération [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) pour spécifier le type d’opérateur (sommation, union, etc.), sans les intégrales. La méthode *integral* utilise l’énumération [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes) pour les intégrales.

Exemple :

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Méthode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) place les éléments dans un tableau vertical. Si l’opération est appelée sur une instance de [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock), tous les éléments enfants seront placés dans le tableau retourné.

Exemple :

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Méthode [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) : ajoute un signe d’accent (un caractère au-dessus de l’élément).
- Méthodes [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) et [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) : ajoutent respectivement une barre au-dessus ou en dessous.
- Méthode [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) : place les éléments dans un groupe à l’aide d’un caractère de groupement tel qu’une accolade inférieure ou autre.
- Méthode [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) : place les éléments dans une boîte avec bordure.
- Méthode [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) : place les éléments dans une boîte logique non visuelle (groupement).

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

Pour ajouter une équation, créez d’abord un objet forme mathématique, qui contient automatiquement une portion mathématique. Ensuite, récupérez le [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) à partir de la [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) et ajoutez‑y des objets [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/).

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides vous permet de créer des expressions complexes en imbriquant des MathBlocks. Chaque élément mathématique implémente l’interface [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/), ce qui vous autorise à appliquer des opérations (Join, Divide, Enclose, etc.) pour combiner les éléments en structures plus complexes.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, accédez aux MathBlocks existants via le [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). Ensuite, en utilisant des méthodes telles que Join, Divide, Enclose, etc., vous pouvez modifier les éléments individuels de l’équation. Après la modification, enregistrez la présentation pour appliquer les changements.