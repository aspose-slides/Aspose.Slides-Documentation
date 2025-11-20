---
title: Ajouter des équations mathématiques aux présentations PowerPoint en Python
linktitle: Équations mathématiques
type: docs
weight: 80
url: /fr/python-net/powerpoint-math-equations/
keywords:
- équation mathématique
- équation mathématique PowerPoint
- symbole mathématique
- symbole mathématique PowerPoint
- formule mathématique
- formule mathématique PowerPoint
- texte mathématique
- texte mathématique PowerPoint
- ajouter équation mathématique à PowerPoint
- ajouter symbole mathématique à PowerPoint
- ajouter formule mathématique à PowerPoint
- ajouter texte mathématique à PowerPoint
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à travailler avec les équations mathématiques dans PowerPoint en utilisant Aspose.Slides pour Python via .NET. Obtenez des instructions détaillées, des exemples de code et des astuces pour automatiser la création et la modification de présentations."
---

## **Vue d'ensemble**

Dans PowerPoint, vous pouvez écrire une équation ou une formule mathématique et l'afficher dans votre présentation. Divers symboles mathématiques sont disponibles et peuvent être ajoutés au texte ou aux équations. Le constructeur d'équations mathématiques est utilisé pour créer des formules complexes comme :

- Fraction mathématique
- Radical mathématique
- Fonction mathématique
- Limites et fonctions logarithmiques
- Opérations n‑aires
- Matrice
- Opérateurs larges
- Fonctions sin, cos

Pour ajouter une équation mathématique dans PowerPoint, le menu *Insertion -> Équation* est utilisé :

![todo:image_alt_text](powerpoint-math-equations_1.png)

Cela crée un texte mathématique en XML qui peut être affiché dans PowerPoint comme suit :

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint prend en charge un large éventail de symboles mathématiques pour créer des équations. Cependant, la génération d'équations mathématiques complexes dans PowerPoint ne donne souvent pas un résultat poli et professionnel. Par conséquent, les utilisateurs qui créent fréquemment des présentations mathématiques se tournent souvent vers des solutions tierces pour obtenir des formules plus présentables.

En utilisant l'[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/), vous pouvez travailler avec les équations mathématiques dans les présentations PowerPoint de façon programmatique en Python. Créez de nouvelles expressions mathématiques ou modifiez celles déjà créées. Un support partiel est disponible pour exporter les structures mathématiques sous forme d'images.

## **Comment créer une équation mathématique**

Les éléments mathématiques sont utilisés pour construire toute construction mathématique, quel que soit le niveau d’imbrication. Une collection linéaire de ces éléments forme un bloc mathématique, représenté par la classe [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). La classe [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) représente une expression, une formule ou une équation mathématique autonome. [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) est utilisé pour contenir du texte mathématique (différent de la classe [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)), tandis que [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) vous permet de manipuler un ensemble d’objets [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Ces classes sont essentielles pour travailler avec les équations mathématiques PowerPoint via l’Aspose.Slides API.

Voyons comment créer l’équation mathématique suivante en utilisant l’Aspose.Slides API :

![todo:image_alt_text](powerpoint-math-equations_3.png)

Pour ajouter une expression mathématique à la diapositive, ajoutez d’abord une forme qui contiendra le texte mathématique :
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


Après la création de la forme, elle contient déjà un paragraphe avec une portion mathématique par défaut. La classe [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) représente une portion contenant du texte mathématique. Pour accéder au contenu mathématique d’une [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), reportez‑vous à la variable [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) :
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


La classe [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) vous permet de lire, ajouter, modifier et supprimer des blocs mathématiques ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), qui consistent en une combinaison d’éléments mathématiques. Par exemple, créez une fraction et placez‑la dans la présentation :
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
```


Les opérations de l’interface [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) sont implémentées dans chaque type d’élément, y compris la classe [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) .

Ci‑dessous, le code source complet :
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **Types d’éléments mathématiques**

Les expressions mathématiques sont composées de séquences d’éléments mathématiques. Un bloc mathématique représente une telle séquence, et les arguments de ces éléments forment une structure imbriquée en forme d’arbre.

Il existe de nombreux types d’éléments mathématiques pouvant être utilisés pour construire un bloc mathématique. Chacun de ces éléments peut être agrégé dans un autre, formant une structure arborescente. Le type d’élément le plus simple est celui qui ne contient aucun autre élément de texte mathématique.

Chaque type d’élément mathématique implémente l’interface [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), vous permettant d’utiliser un ensemble commun d’opérations mathématiques sur différents types d’éléments.

### **Classe MathematicalText**

La classe [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) représente un texte mathématique — l’élément sous‑jacent de toutes les constructions mathématiques. Le texte mathématique peut représenter des opérandes et des opérateurs, des variables ou tout autre texte linéaire.

Exemple : 𝑎=𝑏+𝑐

### **Classe MathFraction**

La classe [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) spécifie un objet fraction composé d’un numérateur et d’un dénominateur séparés par une barre de fraction. La barre peut être horizontale ou diagonale, selon les propriétés de la fraction. L’objet fraction sert également à représenter la fonction pile, qui place un élément au-dessus d’un autre sans barre de fraction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Classe MathRadical**

La classe [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) spécifie la fonction radicale (racine mathématique), composée d’une base et d’un degré optionnel.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Classe MathFunction**

La classe [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) spécifie une fonction d’un argument. Elle possède des propriétés telles que [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/), qui représente le nom de la fonction, et [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/), qui représente l’argument de la fonction.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Classe MathNaryOperator**

La classe [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) spécifie un objet mathématique N‑aire, tel qu’une sommation ou une intégrale. Elle se compose d’un opérateur, d’une base (ou opérande) et de limites supérieures et inférieures optionnelles. Les opérateurs N‑aires comprennent la sommation, l’union, l’intersection et l’intégrale.

Cette classe n’inclut pas les opérateurs simples comme l’addition ou la soustraction ; ils sont représentés par un texte unique [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Classe MathLimit**

La classe [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) crée une limite supérieure ou inférieure. Elle spécifie l’objet limite, constitué de texte sur la ligne de base et de texte de taille réduite immédiatement au-dessus ou en dessous. Cet élément n’inclut pas le mot « lim », mais vous permet de placer du texte en haut ou en bas de l’expression. Ainsi, l’expression  

![todo:image_alt_text](powerpoint-math-equations_8.png)

est créée à l’aide d’une combinaison d’éléments [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) et [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) comme suit :
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **Classes MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Ces classes spécifient un indice inférieur ou supérieur. Vous pouvez définir simultanément l’indice inférieur et supérieur du côté gauche ou droit d’un argument, mais un seul indice (inférieur ou supérieur) n’est supporté que du côté droit. Le [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) peut également être utilisé pour définir le degré mathématique d’un nombre.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Classe MathMatrix**

La classe [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) spécifie l’objet Matrice, qui se compose d’éléments enfants organisés en une ou plusieurs lignes et colonnes. Notez que les matrices n’ont pas de délimiteurs intégrés. Pour encadrer la matrice de crochets, utilisez l’objet délimiteur [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). Des arguments nuls peuvent être utilisés pour créer des espaces dans les matrices.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Classe MathArray**

La classe [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) spécifie un tableau vertical d’équations ou de tout objet mathématique.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Mise en forme des éléments mathématiques**

- Classe [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) : dessine une bordure rectangulaire ou alternative autour de l’[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Exemple :

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Classe [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) : spécifie le conditionnement logique d’un élément mathématique. Un objet encadré peut servir d’émulateur d’opérateur, avec ou sans point d’alignement, fonctionner comme point de coupure de ligne ou être groupé pour empêcher les retours à la ligne.

- Classe [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) : spécifie l’objet délimiteur, qui se compose de caractères d’ouverture et de fermeture (parenthèses, accolades, crochets ou barres verticales) et d’un ou plusieurs éléments mathématiques à l’intérieur, séparés par un caractère spécifié. Exemples : (𝑥2); [𝑥2|𝑦2].

Exemple :

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Classe [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) : spécifie la fonction accent, qui se compose d’une base et d’un signe diacritique combiné.

Exemple : 𝑎́.

- Classe [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) : spécifie la fonction barre, qui se compose d’un argument de base et d’une barre supérieure ou inférieure.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Classe [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) : spécifie un symbole de regroupement placé au-dessus ou en dessous d’une expression, généralement pour mettre en évidence les relations entre les éléments.

Exemple :

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Opérations mathématiques**

Chaque élément mathématique et chaque expression mathématique (via [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implémente l’interface [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Cela vous permet d’exécuter des opérations sur la structure existante et de former des expressions mathématiques plus complexes. Toutes les opérations ont deux ensembles de paramètres : soit des arguments [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), soit des chaînes de caractères. Les instances de la classe [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) sont créées implicitement à partir des chaînes fournies lorsqu’on utilise des arguments de type string. Les opérations mathématiques disponibles dans Aspose.Slides sont listées ci‑dessous.

### **Méthode join**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

Ces méthodes joignent un élément mathématique et forment un bloc mathématique. Par exemple :
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Méthode divide**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String,MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement,MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

Ces méthodes créent une fraction du type spécifié avec un numérateur et le dénominateur indiqué. Par exemple :
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Méthode enclose**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char,Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

Ces méthodes entourent l’élément de caractères spécifiés, tels que des parenthèses ou d’autres caractères d’encadrement. Par exemple :
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Méthode function**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

Ces méthodes prennent une fonction d’un argument en utilisant l’objet actuel comme nom de fonction. Par exemple :
```py
function = math.MathematicalText("sin").function("x")
```


### **Méthode as_argument_of_function**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Ces méthodes utilisent la fonction spécifiée en employant l’instance courante comme argument. Vous pouvez :

- spécifier une chaîne comme nom de fonction, par exemple "cos";
- choisir l’une des valeurs prédéfinies des énumérations [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) ou [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), par exemple `MathFunctionsOfOneArgument.ARC_SIN`;
- fournir l’instance de [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Par exemple :
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **Méthodes set_subscript, set_superscript, set_sub_superscript_on_the_right, set_sub_superscript_on_the_left**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

Ces méthodes définissent l’indice inférieur et l’indice supérieur. Vous pouvez les définir simultanément du côté gauche ou droit de l’argument ; toutefois, un seul indice (inférieur ou supérieur) n’est supporté que du côté droit. Le **Superscript** peut également être utilisé pour définir le degré mathématique d’un nombre.

Exemple :
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Méthode radical**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

Ces méthodes spécifient la racine mathématique du degré donné à partir de l’argument indiqué.

Exemple :
```py
radical = math.MathematicalText("x").radical("3")
```


### **Méthodes set_upper_limit et set_lower_limit**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

Ces méthodes prennent une limite supérieure ou inférieure, où « upper » et « lower » indiquent la position de l’argument par rapport à la base.

Considérons une expression :

![todo:image_alt_text](powerpoint-math-equations_8.png)

De telles expressions peuvent être créées via une combinaison des classes [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) et [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), ainsi que les opérations de l’interface [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), comme suit :
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Méthodes nary et integral**

- [nary(MathNaryOperatorTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes,String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes,String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes,IMathElement,IMathElement,MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes,String,String,MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

Les deux méthodes `nary` et `integral` créent et renvoient l’opérateur N‑aire représenté par le type [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/). Dans la méthode Nary, l’énumération [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) spécifie le type d’opérateur—tel que sommation ou union—excluant les intégrales. Dans la méthode Integral, une opération spécialisée pour les intégrales est fournie, en utilisant l’énumération [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).

Exemple :
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **Méthode to_math_array**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) place les éléments dans un tableau vertical. Si cette opération est appelée sur une instance de [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), tous ses éléments enfants seront placés dans le tableau renvoyé.

Exemple :
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **Opérations de mise en forme : Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Méthode [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) : définit un signe d’accent (un caractère au dessus de l’élément).
- Méthodes [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) et [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) : placent une barre au dessus ou en dessous.
- Méthode [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) : place dans un groupe à l’aide d’un caractère de groupement tel qu’une accolade inférieure ou autre.
- Méthode [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) : place dans une boîte à bordure.
- Méthode [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) : place dans une boîte non visuelle (groupement logique).

Exemples :
```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```


## **FAQ**

**Comment ajouter une équation mathématique à une diapositive PowerPoint ?**

Pour ajouter une équation mathématique, vous devez [créer un objet forme mathématique](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) qui contient automatiquement une portion mathématique. Ensuite, récupérez le [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) depuis la [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) et ajoutez des objets [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) à celui‑ci.

**Est‑il possible de créer des expressions mathématiques imbriquées complexes ?**

Oui, Aspose.Slides vous permet de créer des expressions mathématiques complexes en imbriquant des [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Chaque élément mathématique vous permet d’appliquer des opérations (Join, Divide, Enclose, etc.) pour combiner les éléments en structures plus complexes.

**Comment mettre à jour ou modifier une équation mathématique existante ?**

Pour mettre à jour une équation, vous devez accéder au [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) existant via le [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Puis, en utilisant des méthodes telles que Join, Divide, Enclose, etc., vous pouvez modifier les éléments individuels de l’équation. Après la modification, enregistrez la présentation pour appliquer les changements.