---
title: Ecuaciones Matemáticas de PowerPoint
type: docs
weight: 80
url: /java/powerpoint-math-equations/
keywords: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmulas de PowerPoint, Texto Matemático de PowerPoint"
description: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmulas de PowerPoint, Texto Matemático de PowerPoint"
---

## **Resumen**
En PowerPoint, es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, se representan varios símbolos matemáticos en PowerPoint que se pueden añadir al texto o ecuación. Para eso, se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones N-arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para agregar una ecuación matemática en PowerPoint, se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que se puede mostrar en PowerPoint como sigue: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite una gran cantidad de símbolos matemáticos para crear ecuaciones matemáticas. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no produce un buen resultado de aspecto profesional. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren al uso de soluciones de terceros para crear fórmulas matemáticas bien diseñadas.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/java/), puedes trabajar con ecuaciones matemáticas en las presentaciones de PowerPoint de manera programática en C#. Crea nuevas expresiones matemáticas o edita las que ya han sido creadas. La exportación de estructuras matemáticas a imágenes también es parcialmente compatible.

## **Cómo Crear una Ecuación Matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidación. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) esencialmente es una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no confundir con [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas anteriormente son la clave para trabajar con ecuaciones matemáticas en PowerPoint a través de Aspose.Slides API.

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

Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) es una porción que contiene un texto matemático dentro. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion), consulta la variable [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

La clase [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) permite leer, agregar, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), que constan de una combinación de elementos matemáticos. Por ejemplo, crea una fracción y colócala en la presentación:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Cada elemento matemático está representado por una clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Esta interfaz proporciona muchos métodos para crear expresiones matemáticas fácilmente. Puedes crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras se vería así:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) se implementan en cualquier tipo de elemento, incluyendo [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

El código fuente completo:

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
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos está representada por un bloque matemático, y los argumentos de los elementos matemáticos forman una anidación en forma de árbol.

Hay muchos tipos de elementos matemáticos que se pueden utilizar para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) en otro elemento. Es decir, los elementos son en realidad contenedores de otros, formando una estructura en forma de árbol. El tipo más simple de elemento no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement), permitiendo el uso del conjunto común de operaciones matemáticas en diferentes tipos de elementos matemáticos.
### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) representa un texto matemático: el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐
### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) especifica el objeto fracción, que consiste en un numerador y un denominador separados por una barra de fracción. La barra de fracción puede ser horizontal o diagonal, dependiendo de las propiedades de la fracción. El objeto fracción también se usa para representar la función de pila, que coloca un elemento encima de otro, sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) especifica la función radical (raíz matemática), que consiste en una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) especifica una función de un argumento. Contiene propiedades: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) - nombre de la función y [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) - argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) especifica un objeto matemático N-ario, como Suma e Integral. Consiste en un operador, una base (o operando) y límites superiores e inferiores opcionales. Ejemplos de operadores N-arios son Suma, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Se representan mediante un solo elemento de texto - [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, que consiste en texto en la línea base y texto de tamaño reducido inmediatamente encima o debajo de él. Este elemento no incluye la palabra “lim", pero permite colocar texto en la parte superior o en la inferior de la expresión. Entonces, la expresión 

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea utilizando una combinación de elementos [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) de esta manera:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Las siguientes clases especifican un índice inferior o un índice superior. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o derecho de un argumento, pero se admite el subíndice o superíndice único solo en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) también puede usarse para establecer el grado matemático de un número.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) especifica el objeto Matriz, que consta de elementos secundarios dispuestos en una o más filas y columnas. Es importante tener en cuenta que las matrices no tienen delimitadores integrados. Para colocar la matriz entre corchetes, debes usar el objeto delimitador - [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). Los argumentos nulos pueden usarse para crear espacios en matrices.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) especifica un arreglo vertical de ecuaciones u otros objetos matemáticos.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formateo de Elementos Matemáticos**
- La clase [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox): dibuja un borde rectangular u otro borde alrededor del [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La clase [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox): especifica el enmarcado lógico (empaquetado) del elemento matemático. Por ejemplo, un objeto enmarcado puede servir como emulador de operador con o sin un punto de alineación, servir como un punto de ruptura de línea o estar agrupado para no permitir saltos de línea dentro. Por ejemplo, el operador "==" debe estar enmarcado para evitar saltos de línea.
- La clase [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter): especifica el objeto delimitador, que consiste en caracteres de apertura y cierre (como paréntesis, llaves, corchetes y barras verticales), y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La clase [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent): especifica la función de acento, que consiste en una base y una marca diacrítica combinada. 

  Ejemplo: 𝑎́.

- La clase [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar): especifica la función de barra, que consiste en un argumento base y una sobrebarra o subbarra.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter): especifica un símbolo agrupador encima o debajo de una expresión, generalmente para resaltar las relaciones entre elementos.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones Matemáticas**
Cada elemento matemático y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Esto te permite usar operaciones sobre la estructura existente y formar expresiones matemáticas más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) o string como argumentos. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) se crean implícitamente a partir de cadenas especificadas cuando se utilizan argumentos de cadenas. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.
### **Método Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Método Divide**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Crea una fracción del tipo especificado con este numerador y denominador especificado. Por ejemplo:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Método Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Encierra el elemento en caracteres especificados, como paréntesis u otro carácter como enmarcamiento.

```java
/**
 * <p>
 * Encierra un elemento matemático en paréntesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encierra este elemento en caracteres especificados, como paréntesis u otros caracteres como enmarcamiento
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
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

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
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Toma la función especificada usando la instancia actual como argumento. Puedes:

- especificar una cadena como el nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- seleccionar la instancia de [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

Por ejemplo:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Establece subíndice y superíndice. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o derecho del argumento, pero el subíndice o superíndice único se admite solo en el lado derecho. El **Superscript** también puede usarse para establecer el grado matemático de un número.

Ejemplo:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Método Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Especifica la raíz matemática del grado dado del argumento especificado.

Ejemplo:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Toma el límite superior o inferior. Aquí, el superior e inferior simplemente indican la ubicación del argumento en relación con la base.

Consideremos una expresión: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Dichas expresiones pueden crearse mediante una combinación de clases [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) y [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit), y operaciones de la [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) de la siguiente manera:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Métodos Nary e Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Tanto los métodos **nary** como **integral** crean y devuelven el operador N-ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator). En el método nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) especifica el tipo de operador: suma, unión, etc., sin incluir integrales. En el método Integral, hay la operación especializada Integral con la enumeración de tipos de integral [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes). 

Ejemplo:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Método ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) coloca elementos en un arreglo vertical. Si esta operación se llama para una instancia de [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock), todos los elementos secundarios se colocarán en el arreglo devuelto.

Ejemplo:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Operaciones de formateo: Acento, Sobrebarra, Subbarra, Agrupar, ToBorderBox, ToBox**
- El método [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) establece una marca de acento (un carácter en la parte superior del elemento).
- Los métodos [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) y [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) establecen una barra en la parte superior o inferior.
- El método [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) coloca en un grupo utilizando un carácter de agrupación, como una llave inferior o otro.
- El método [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) coloca en un borde-box.
- El método [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) coloca en una caja no visual (agrupación lógica).

Ejemplos:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 