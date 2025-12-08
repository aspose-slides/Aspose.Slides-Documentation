---
title: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/nodejs-java/powerpoint-math-equations/
keywords: "Ecuaciones matemáticas de PowerPoint, Símbolos matemáticos de PowerPoint, Fórmula de PowerPoint, Texto matemático de PowerPoint"
description: "Ecuaciones matemáticas de PowerPoint, Símbolos matemáticos de PowerPoint, Fórmula de PowerPoint, Texto matemático de PowerPoint"
---

## **Descripción general**
En PowerPoint es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, varios símbolos matemáticos están representados en PowerPoint y pueden añadirse al texto o a la ecuación. Para eso se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n‑arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para añadir una ecuación matemática en PowerPoint se utiliza el menú *Insertar → Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite muchos símbolos matemáticos para crear ecuaciones. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no brinda un resultado profesional y de buena calidad. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas de buen aspecto.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/), puede trabajar con ecuaciones matemáticas en presentaciones de PowerPoint de forma programática en C#. Cree nuevas expresiones matemáticas o edite las que ya existen. La exportación de estructuras matemáticas a imágenes también es parcialmente compatible.

## **Cómo crear una ecuación matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) es esencialmente una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no lo confunda con [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son la clave para trabajar con ecuaciones matemáticas de PowerPoint mediante la API Aspose.Slides.

Veamos cómo crear la siguiente ecuación matemática mediante la API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero añada una forma que contendrá el texto matemático:

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

Después de crearla, la forma ya contiene un párrafo con una porción matemática por defecto. La [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) es una porción que contiene texto matemático. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion), consulte la variable [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph):

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

La clase [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) permite leer, añadir, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crear una fracción y colocarla en la presentación:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Cada elemento matemático está representado por alguna clase que implementa la clase [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). Esta clase ofrece muchos métodos para crear expresiones matemáticas fácilmente. Puede crear una expresión bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras quedaría así:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Las operaciones de la clase [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) están implementadas en cualquier tipo de elemento, incluido [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

Código de ejemplo completo:

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

## **Tipos de elementos matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos se representa mediante un bloque matemático, y los argumentos de los elementos forman un anidamiento tipo árbol.

Existen muchos tipos de elementos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) en otro elemento. Es decir, los elementos son contenedores de otros, formando una estructura arbórea. El tipo más simple es aquel que no contiene otros elementos de texto matemático.

Cada tipo de elemento implementa la clase [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement), lo que permite usar el conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.
### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐
### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) especifica el objeto fracción, compuesto por un numerador y un denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El objeto también se usa para representar la función de apilamiento, que coloca un elemento sobre otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) especifica una función de un argumento. Contiene las propiedades: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) — nombre de la función y [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) — argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) especifica un objeto matemático N‑ario, como Sumatorio o Integral. Consiste en un operador, una base (u operando) y límites superior e inferior opcionales. Ejemplos de operadores N‑arios son Sumatorio, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc.; esos se representan mediante un solo elemento de texto — [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, compuesto por texto en la línea base y texto reducido inmediatamente arriba o abajo de ella. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión  

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando los elementos [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) de la siguiente forma:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 


### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Las siguientes clases especifican un subíndice o un superíndice. Puede establecer subíndice y superíndice simultáneamente a la izquierda o a la derecha del argumento, pero un solo subíndice o superíndice se admite solo a la derecha. La clase [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) también puede usarse para establecer el grado matemático de un número.

Ejemplo:  

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) especifica el objeto Matriz, compuesto por elementos hijos organizados en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para colocar la matriz entre corchetes debe usarse el objeto delimitador — [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Los argumentos nulos pueden usarse para crear huecos en las matrices.

Ejemplo:  

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) especifica un conjunto vertical de ecuaciones o cualquier objeto matemático.

Ejemplo:  

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formato de elementos matemáticos**
- Clase [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox): dibuja un borde rectangular u otro tipo alrededor del [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Clase [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox): especifica el empaquetado lógico del elemento matemático. Por ejemplo, un objeto en caja puede servir como emulador de operador con o sin punto de alineación, servir como salto de línea, o agruparse para evitar saltos de línea dentro. Por ejemplo, el operador “==” debería estar en una caja para impedir saltos de línea.

- Clase [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter): especifica el objeto delimitador, compuesto por caracteres de apertura y cierre (paréntesis, llaves, corchetes, barras verticales) y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Clase [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent): especifica la función de acento, compuesta por una base y una marca diacrítica combinada.  
  Ejemplo: 𝑎́.

- Clase [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar): especifica la función barra, compuesta por un argumento base y una barra superior o inferior.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter): especifica un símbolo de agrupación encima o debajo de una expresión, usualmente para resaltar relaciones entre elementos.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Operaciones matemáticas**
Cada elemento y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) implementa la clase [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). Permite usar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) o una cadena como argumento. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) se crean implícitamente a partir de las cadenas especificadas cuando se usan argumentos de tipo string. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.
### **Método Join**
- [join(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-aspose.slides.IMathElement-)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Método Divide**
- [divide(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-int-)

Crea una fracción del tipo especificado con este numerador y el denominador indicado. Por ejemplo:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Método Enclose**
- [enclose()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose-char-char-)

Encierra el elemento entre caracteres especificados, como paréntesis u otro carácter de marco.

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

Por ejemplo:

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **Método Function**
- [function(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-aspose.slides.IMathElement-)

Toma una función de un argumento usando el objeto actual como nombre de la función.

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

Por ejemplo:

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **Método AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-java.lang.String-)

Toma la función especificada usando la instancia actual como argumento. Puede:

- especificar una cadena como nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de los enumerados [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- seleccionar la instancia del [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

Por ejemplo:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-aspose.slides.IMathElement-aspose.slides.IMathElement-)

Establece subíndice y superíndice. Puede establecer ambos simultáneamente a la izquierda o a la derecha del argumento, pero un solo subíndice o superíndice solo se admite a la derecha. El **Superscript** también puede usarse para establecer el grado matemático de un número.

Ejemplo:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Método Radical**
- [radical(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-aspose.slides.IMathElement-)

Especifica la raíz matemática del grado dado a partir del argumento especificado.

Ejemplo:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-aspose.slides.IMathElement-)

Define el límite superior o inferior. Aquí, los límites simplemente indican la posición del argumento respecto a la base.

Consideremos la expresión:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden crearse mediante una combinación de las clases [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) y [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit), y las operaciones de [MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) de la siguiente forma:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Métodos Nary e Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-int-)

Los métodos **nary** e **integral** crean y devuelven el operador N‑ario representado por el tipo [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator). En el método nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) especifica el tipo de operador: sumatorio, unión, etc., sin incluir integrales. En el método Integral, se utiliza la enumeración [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes).

Ejemplo:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **Método ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toMathArray--) coloca los elementos en una matriz vertical. Si esta operación se llama para una instancia de [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock), todos los elementos hijos se colocarán en la matriz devuelta.

Ejemplo:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Método [**accent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#accent-char-) establece una marca de acento (un carácter sobre el elemento).
- Métodos [**overbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#overbar--) y [**underbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#underbar--) establecen una barra superior o inferior.
- Método [**group**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#group--) coloca en un grupo usando un carácter de agrupación, como una llave inferior u otro.
- Método [**toBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBorderBox--) coloca en un cuadro con borde.
- Método [**toBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBox--) coloca en una caja no visual (agrupación lógica).

Ejemplos:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **Preguntas frecuentes**

**¿Cómo puedo añadir una ecuación matemática a una diapositiva de PowerPoint?**

Para añadir una ecuación matemática, debe crear un objeto `MathShape`, que automáticamente contiene una porción matemática. Luego, recupere el `MathParagraph` de la `MathPortion` y añada objetos `MathBlock` a él.

**¿Es posible crear expresiones matemáticas complejas y anidadas?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas anidando MathBlocks. Cada elemento matemático implementa la clase `IMathElement`, que permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, acceda a los MathBlocks existentes a través del `MathParagraph`. Luego, usando métodos como Join, Divide, Enclose y otros, modifique los elementos individuales de la ecuación. Después de editar, guarde la presentación para aplicar los cambios.