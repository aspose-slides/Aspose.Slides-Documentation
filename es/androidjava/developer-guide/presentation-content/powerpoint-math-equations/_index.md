---
title: Ecuaciones Matemáticas de PowerPoint
type: docs
weight: 80
url: /es/androidjava/powerpoint-math-equations/
keywords: " Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmula de PowerPoint, Texto Matemático de PowerPoint"
description: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmula de PowerPoint, Texto Matemático de PowerPoint"
---

## **Descripción General**
En PowerPoint, es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, varios símbolos matemáticos están representados en PowerPoint y pueden ser añadidos al texto o ecuación. Para eso, se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción Matemática
- Radical Matemático
- Función Matemática
- Límites y funciones logarítmicas
- Operaciones n-arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para agregar una ecuación matemática en PowerPoint, se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede ser mostrado en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint soporta una gran cantidad de símbolos matemáticos para crear ecuaciones matemáticas. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no trae un buen resultado profesional. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren al uso de soluciones de terceros para crear fórmulas matemáticas con buena apariencia.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/), puedes trabajar con ecuaciones matemáticas en las presentaciones de PowerPoint de manera programática en C#. Crea nuevas expresiones matemáticas o edita las que ya has creado previamente. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.


## **Cómo Crear una Ecuación Matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) es esencialmente una expresión matemática separada, fórmula o ecuación. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no mezclar con [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son clave para trabajar con ecuaciones matemáticas en PowerPoint a través de Aspose.Slides API.

Veamos cómo podemos crear la siguiente ecuación matemática a través de Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para agregar una expresión matemática en la diapositiva, primero, agrega una forma que contendrá el texto matemático:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) es una porción que contiene un texto matemático dentro. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion), se refiere a la variable [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

La clase [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permite leer, agregar, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crear una fracción y colocarla en la presentación:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Cada elemento matemático está representado por alguna clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Esta interfaz proporciona muchos métodos para crear fácilmente expresiones matemáticas. Puedes crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras se vería así:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) se implementan en cualquier tipo de elemento, incluyendo el [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

El código fuente completo de ejemplo:

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

## **Tipos de Elementos Matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos es representada por un bloque matemático, y los argumentos de los elementos matemáticos forman una anidación en forma de árbol.

Hay muchos tipos de elementos matemáticos que pueden ser utilizados para construir un bloque matemático. Cada uno de estos elementos puede ser incluido (agregado) en otro elemento. Es decir, los elementos son realmente contenedores de otros, formando una estructura en forma de árbol. El tipo más simple de elemento que no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), permitiendo el uso de un conjunto común de operaciones matemáticas sobre diferentes tipos de elementos matemáticos.
### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) representa un texto matemático: el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐
### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) especifica el objeto fracción, que consiste en un numerador y un denominador separados por una barra de fracción. La barra de fracción puede ser horizontal o diagonal, dependiendo de las propiedades de la fracción. El objeto fracción también se utiliza para representar la función de apilamiento, que coloca un elemento encima de otro, sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) especifica la función radical (raíz matemática), que consiste en una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) especifica una función de un argumento. Contiene propiedades: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) - nombre de la función y [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) - argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) especifica un objeto matemático n-ario, como Suma e Integral. Consiste en un operador, una base (o operando) y límites opcionales superiores e inferiores. Ejemplos de operadores n-arios son Suma, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Son representados por un único elemento de texto - [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, que consiste en texto en la línea base y texto reducido inmediatamente encima o debajo de ella. Este elemento no incluye la palabra "lim", pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión 

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea usando una combinación de elementos [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) de esta manera:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Las siguientes clases especifican un índice inferior o un índice superior. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o derecho de un argumento, pero sólo se soporta un subíndice o superíndice único en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) también puede ser utilizado para establecer el grado matemático de un número.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) especifica el objeto Matriz, que consiste en elementos secundarios dispuestos en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para colocar la matriz en los corchetes, debes usar el objeto delimitador - [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Se pueden usar argumentos nulos para crear espacios en las matrices.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) especifica un arreglo vertical de ecuaciones u otros objetos matemáticos.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formateo de Elementos Matemáticos**
- La clase [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox): dibuja un borde rectangular u otro alrededor del [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La clase [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox): especifica el enmarcado lógico del elemento matemático. Por ejemplo, un objeto enmarcado puede servir como un emulador de operador con o sin un punto de alineación, servir como un punto de ruptura de línea, o ser agrupado de tal manera que no permita saltos de línea dentro de él. Por ejemplo, el operador "==" debe ser enmarcado para prevenir saltos de línea.
- La clase [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter): especifica el objeto delimitador, que consiste en caracteres de apertura y cierre (como paréntesis, llaves, corchetes y barras verticales), y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La clase [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent): especifica la función acento, que consiste en una base y un signo diacrítico combinante.

  Ejemplo: 𝑎́.

- La clase [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar): especifica la función barra, que consiste en un argumento base y una barra superior o inferior.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter): especifica un símbolo de agrupamiento por encima o debajo de una expresión, generalmente para resaltar las relaciones entre elementos.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Operaciones Matemáticas**
Cada elemento matemático y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Esto permite usar operaciones sobre la estructura existente y formar expresiones matemáticas más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) o cadena como argumentos. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) se crean implícitamente a partir de cadenas especificadas cuando se utilizan argumentos de cadena. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.
### **Método Join**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Método Divide**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Crea una fracción del tipo especificado con este numerador y denominador especificado. Por ejemplo:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Método Enclose**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Enclava el elemento en caracteres especificados, tales como paréntesis u otro carácter como marco.

```java
/**
 * <p>
 * Enclava un elemento matemático en paréntesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Enclava este elemento en caracteres especificados, tales como paréntesis u otros caracteres como marco
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


Por ejemplo:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Método Function**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Toma una función de un argumento utilizando el objeto actual como el nombre de la función.

```java
/**
 * <p>
 * Toma una función de un argumento utilizando esta instancia como el nombre de la función
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Toma una función de un argumento utilizando esta instancia como el nombre de la función
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


Por ejemplo:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **Método AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Toma la función especificada utilizando la instancia actual como argumento. Puedes:

- especificar una cadena como el nombre de la función, por ejemplo "cos".
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- seleccionar la instancia del [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

Por ejemplo:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Establece subíndice y superíndice. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o derecho del argumento, pero el subíndice o superíndice único se soporta únicamente en el lado derecho. El **Superíndice** también puede ser utilizado para establecer el grado matemático de un número.

Ejemplo:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Método Radical**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Especifica la raíz matemática del grado dado del argumento especificado.

Ejemplo:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Toma el límite superior o inferior. Aquí, el superior e inferior simplemente indican la ubicación del argumento en relación con la base.

Consideremos una expresión: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden ser creadas a través de una combinación de clases [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) y [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit), y operaciones de [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) de la siguiente manera:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Métodos Nary e Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Tanto los métodos **nary** como **integral** crean y devuelven el operador n-ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). En el método nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) especifica el tipo de operador: suma, unión, etc., sin incluir integrales. En el método Integral, hay la operación especializada Integral con la enumeración de tipos de integral [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes). 

Ejemplo:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Método toMathArray**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) coloca elementos en un arreglo vertical. Si esta operación se llama para una instancia de [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock), todos los elementos secundarios serán colocados en el arreglo devuelto.

Ejemplo:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Operaciones de formateo: Acento, Barra superior, Barra inferior, Agrupar, ToBorderBox, ToBox**
- El método [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) establece una marca de acento (un carácter en la parte superior del elemento).
- Los métodos [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) y [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) establecen una barra en la parte superior o inferior.
- El método [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) coloca en un grupo utilizando un carácter de agrupamiento como una llave inferior o un otro.
- El método [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) coloca en un borde-box.
- El método [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) coloca en una caja no visual (agrupamiento lógico).

Ejemplos:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 