---
title: Agregar ecuaciones matemáticas a presentaciones de PowerPoint en Android
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/androidjava/powerpoint-math-equations/
keywords:
- ecuación matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- agregar ecuación matemática
- agregar símbolo matemático
- agregar fórmula matemática
- agregar texto matemático
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PPT y PPTX de PowerPoint con Aspose.Slides para Android, compatible con OMML, controles de formato y ejemplos claros de código Java."
---

## **Descripción general**
En PowerPoint es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, varios símbolos matemáticos están representados en PowerPoint y pueden añadirse al texto o a la ecuación. Para eso se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n-arias
- Matriz
- Operadores grandes
- Funciones sin, cos

Para añadir una ecuación matemática en PowerPoint se utiliza el menú *Insertar → Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente forma:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite una gran cantidad de símbolos matemáticos para crear ecuaciones. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no produce un resultado profesional. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas con buen aspecto.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/), puede trabajar con ecuaciones matemáticas en presentaciones de PowerPoint de forma programática en C#. Cree nuevas expresiones matemáticas o edite las creadas anteriormente. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.


## **Cómo crear una ecuación matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidación. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) es esencialmente una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no confundir con [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son la clave para trabajar con ecuaciones matemáticas de PowerPoint a través de la API Aspose.Slides.

Veamos cómo crear la siguiente ecuación matemática mediante la API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero añada una forma que contendrá el texto matemático:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) es una porción que contiene texto matemático internamente. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion), consulte la variable [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

La clase [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) permite leer, añadir, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), que consisten en una combinación de elementos matemáticos. Por ejemplo, cree una fracción y colóquela en la presentación:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Cada elemento matemático está representado por alguna clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Esta interfaz proporciona muchos métodos para crear expresiones matemáticas fácilmente. Puede crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras quedaría así:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) están implementadas en cualquier tipo de elemento, incluida la [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

El ejemplo completo de código fuente:

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

## **Tipos de elementos matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos está representada por un bloque matemático, y los argumentos de los elementos forman una anidación tipo árbol.

Existen muchos tipos de elementos matemáticos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) dentro de otro elemento. Es decir, los elementos son realmente contenedores de otros, formando una estructura tipo árbol. El tipo más simple de elemento que no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), lo que permite usar el conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) especifica el objeto fracción, compuesto por un numerador y un denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El objeto fracción también se usa para representar la función de apilamiento, que coloca un elemento sobre otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) especifica una función de un argumento. Contiene las propiedades: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) ‑ nombre de la función y [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) ‑ argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) especifica un objeto matemático N-ario, como sumatorio o integral. Consiste en un operador, una base (u operando) y límites superior e inferior opcionales. Ejemplos de operadores N-arios son Sumatorio, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Esos se representan con un solo elemento de texto ‑ [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, compuesto por texto en la línea base y texto reducido inmediatamente arriba o abajo de ella. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando los elementos [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) de la siguiente manera:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Estas clases especifican un subíndice o un superíndice. Puede establecer subíndice y superíndice simultáneamente a la izquierda o a la derecha de un argumento, pero solo subíndice o superíndice único es compatible a la derecha. [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) también puede usarse para establecer el grado matemático de un número.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) especifica el objeto Matriz, compuesto por elementos hijos distribuidos en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores integrados. Para colocar la matriz entre corchetes debe usar el objeto delimitador ‑ [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Los argumentos nulos pueden usarse para crear huecos en matrices.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) especifica un arreglo vertical de ecuaciones o cualquier objeto matemático.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formato de elementos matemáticos**
- **MathBorderBox** ([**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox)): dibuja un borde rectangular (u otro) alrededor del [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** ([**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox)): especifica el empaquetado lógico del elemento matemático. Por ejemplo, un objeto en caja puede servir como emulador de operador con o sin punto de alineación, como salto de línea, o agruparse para evitar saltos de línea internos. Por ejemplo, el operador “==” debe encerrarse en caja para impedir saltos de línea.

- **MathDelimiter** ([**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter)): especifica el objeto delimitador, compuesto por caracteres de apertura y cierre (paréntesis, llaves, corchetes, barras verticales) y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥²); [𝑥²|𝑦²].

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** ([**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent)): especifica la función de acento, compuesta por una base y una marca diacrítica combinada.

  Ejemplo: 𝑎́.

- **MathBar** ([**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar)): especifica la función barra, compuesta por un argumento base y una barra superior o inferior.

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** ([**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter)): especifica un símbolo de agrupación arriba o abajo de una expresión, generalmente para resaltar relaciones entre elementos.

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Operaciones matemáticas**
Cada elemento y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Permite usar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones aceptan dos conjuntos de parámetros: ya sea [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) o una cadena como argumento. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) se crean implícitamente a partir de cadenas especificadas. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.

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

Crea una fracción del tipo especificado con este numerador y el denominador indicado. Por ejemplo:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Método Enclose**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Encierra el elemento entre los caracteres especificados, como paréntesis u otro carácter de marco.

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

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Método Function**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

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

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **Método AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Toma la función especificada usando la instancia actual como argumento. Puede:

- especificar una cadena como nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- pasar una instancia de [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

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

Establece subíndice y superíndice. Puede establecer ambos simultáneamente a la izquierda o a la derecha del argumento, pero solo subíndice o superíndice único es compatible a la derecha. El **Superscript** también puede usarse para establecer el grado matemático de un número.

Ejemplo:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Método Radical**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Especifica la raíz matemática del grado indicado a partir del argumento especificado.

Ejemplo:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Establece el límite superior o inferior. Aquí, “superior” e “inferior” indican simplemente la posición del argumento respecto a la base.

Consideremos la expresión:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Dichas expresiones pueden crearse combinando las clases MathFunction y MathLimit y las operaciones de [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) de la siguiente forma:

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

Los métodos **nary** e **integral** crean y devuelven el operador N-ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). En el método nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) especifica el tipo de operador: sumatorio, unión, etc., sin incluir integrales. En el método integral, se usa la enumeración [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes) para indicar el tipo de integral.

Ejemplo:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Método ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) coloca los elementos en un arreglo vertical. Si se llama a esta operación sobre una instancia de [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock), todos los elementos hijos se colocarán en el arreglo resultante.

Ejemplo:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent** ([**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-)) establece una marca de acento (un carácter sobre el elemento).
- **overbar** ([**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--)) y **underbar** ([**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--)) colocan una barra superior o inferior.
- **group** ([**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--)) agrupa usando un carácter de agrupación como una llave inferior u otro.
- **toBorderBox** ([**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--)) coloca en un cuadro con borde.
- **toBox** ([**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--)) coloca en un cuadro lógico no visual.

Ejemplos:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **Preguntas frecuentes**

**¿Cómo puedo añadir una ecuación matemática a una diapositiva de PowerPoint?**

Para añadir una ecuación matemática, debe crear un objeto de forma matemática, que automáticamente contiene una porción matemática. Luego, obtenga el [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) desde la [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) y añada objetos [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) a él.

**¿Es posible crear expresiones matemáticas complejas con anidación?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas mediante la anidación de MathBlocks. Cada elemento matemático implementa la interfaz [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), lo que permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, acceda a los MathBlocks existentes a través del [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Luego, usando métodos como Join, Divide, Enclose, entre otros, modifique los elementos individuales de la ecuación. Después de editar, guarde la presentación para aplicar los cambios.