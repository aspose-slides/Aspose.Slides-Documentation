---
title: Ecuaciones Matemáticas de PowerPoint
type: docs
weight: 80
url: /php-java/powerpoint-math-equations/
keywords: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmula de PowerPoint, Texto Matemático de PowerPoint"
description: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmula de PowerPoint, Texto Matemático de PowerPoint"
---

## **Descripción General**
En PowerPoint, es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para hacerlo, varios símbolos matemáticos están representados en PowerPoint y pueden ser añadidos al texto o ecuación. Para eso, se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n-arias
- Matriz
- Operadores grandes
- Funciones seno y coseno

Para añadir una ecuación matemática en PowerPoint, se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede ser visualizado en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint soporta una gran cantidad de símbolos matemáticos para crear ecuaciones matemáticas. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no arroja un resultado bueno y profesional. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren al uso de soluciones de terceros para crear fórmulas matemáticas de buena apariencia.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), puedes trabajar con ecuaciones matemáticas en presentaciones de PowerPoint programáticamente en C#. Crea nuevas expresiones matemáticas o edita las previamente creadas. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.

## **Cómo Crear una Ecuación Matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) es esencialmente una expresión matemática, fórmula o ecuación separada. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no mezclar con [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son clave para trabajar con las ecuaciones matemáticas de PowerPoint a través de Aspose.Slides API.

Veamos cómo podemos crear la siguiente ecuación matemática a través de Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero, añade una forma que contendrá el texto matemático:

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Después de crear, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) es una porción que contiene un texto matemático dentro. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), referencia la variable [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

```

La clase [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permite leer, añadir, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crea una fracción y colócala en la presentación:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

```

Cada elemento matemático está representado por alguna clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Esta interfaz proporciona muchos métodos para crear fácilmente expresiones matemáticas. Puedes crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras se vería así:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

```

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) están implementadas en cualquier tipo de elemento, incluyendo el [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

El código fuente completo es:

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tipos de Elementos Matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos está representada por un bloque matemático, y los argumentos de los elementos matemáticos forman una anidación en forma de árbol.

Existen muchos tipos de elementos matemáticos que pueden ser utilizados para construir un bloque matemático. Cada uno de estos elementos puede ser incluido (agregado) en otro elemento. Es decir, los elementos son en realidad contenedores para otros, formando una estructura en forma de árbol. El tipo más sencillo de elemento no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), permitiendo el uso de un conjunto común de operaciones matemáticas en diferentes tipos de elementos matemáticos.
### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) representa un texto matemático - el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐
### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) especifica el objeto de fracción, que consiste en un numerador y un denominador separados por una barra de fracción. La barra de fracción puede ser horizontal o diagonal, dependiendo de las propiedades de la fracción. El objeto de fracción también se utiliza para representar la función de pila, que coloca un elemento sobre otro, sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) especifica la función radical (raíz matemática), que consiste en una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) especifica una función de un argumento. Contiene propiedades: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - nombre de la función y [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) especifica un objeto matemático n-ario, como la suma y la integral. Consiste en un operador, una base (o operando) y límites superiores e inferiores opcionales. Ejemplos de operadores n-arios son la suma, la unión, la intersección, la integral.

Esta clase no incluye operadores simples como la suma, la resta, etc. Ellos están representados por un solo elemento de texto - [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, que consiste en texto sobre la línea base y texto de tamaño reducido inmediatamente por encima o por debajo de él. Este elemento no incluye la palabra "lim", pero permite colocar texto en la parte superior o en la parte inferior de la expresión. Así, la expresión 

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea mediante una combinación de elementos [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) de esta manera:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));

``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Las siguientes clases especifican un índice inferior o un índice superior. Puedes establecer subíndices y superíndices al mismo tiempo en el lado izquierdo o en el derecho de un argumento, pero el subíndice o superíndice único es soportado solo en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) también se puede utilizar para establecer el grado matemático de un número.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) especifica el objeto Matriz, que consiste en elementos secundarios dispuestos en una o más filas y columnas. Es importante señalar que las matrices no tienen delimitadores integrados. Para colocar la matriz entre corchetes debes usar el objeto delimitador - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). Pueden usarse argumentos nulos para crear espacios en las matrices.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) especifica un arreglo vertical de ecuaciones u otros objetos matemáticos.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formato de Elementos Matemáticos**
- La clase [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): dibuja un borde rectangular u otro alrededor del [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La clase [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): especifica el enmarcado lógico del elemento matemático. Por ejemplo, un objeto enmarcado puede servir como un emulador operador con o sin un punto de alineación, servir como un punto de quiebre de línea, o agruparse de tal manera que no permita los quiebres de línea dentro. Por ejemplo, el operador "==" debería estar enmarcado para evitar quiebres de línea.
- La clase [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): especifica el objeto delimitador, que consiste en caracteres de apertura y cierre (como paréntesis, llaves, corchetes y barras verticales), y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La clase [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): especifica la función de acento, que consiste en una base y un signo diacrítico combinante.

  Ejemplo: 𝑎́.

- La clase [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): especifica la función de barra, que consiste en un argumento base y un sobrebar o subbarra.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): especifica un símbolo de agrupación por encima o por debajo de una expresión, generalmente para resaltar las relaciones entre elementos.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones Matemáticas**
Cada elemento matemático y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Permite utilizar operaciones sobre la estructura existente y formar expresiones matemáticas más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) o cadena como argumentos. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) se crean implícitamente a partir de cadenas especificadas cuando se utilizan argumentos de cadena. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.
### **Método Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);

``` 

### **Método Divide**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Crea una fracción del tipo especificado con este numerador y denominador especificado. Por ejemplo:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);

``` 

### **Método Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Encierra el elemento en los caracteres especificados como paréntesis u otro carácter como enmarcado.

```php

``` 

Por ejemplo:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();

``` 

### **Método Function**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Toma una función de un argumento usando el objeto actual como el nombre de la función.

```php

``` 

Por ejemplo:

```php
  $func = new MathematicalText("sin")->function("x");

``` 

### **Método AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Toma la función especificada utilizando la instancia actual como argumento. Puedes:

- especificar una cadena como el nombre de la función, por ejemplo "cos".
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- seleccionar la instancia del [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

Por ejemplo:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");

``` 

### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Establece subíndice y superíndice. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o en el derecho del argumento, pero el subíndice o superíndice único es soportado solo en el lado derecho. El **Superíndice** también puede ser utilizado para establecer el grado matemático de un número.

Ejemplo:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");

``` 

### **Método Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Especifica la raíz matemática del grado dado a partir del argumento especificado.

Ejemplo:

```php
  $radical = new MathematicalText("x")->radical("3");

``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Toma el límite superior o inferior. Aquí, los límites superior e inferior simplemente indican la ubicación del argumento en relación con la base.

Consideremos una expresión: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tal expresiones pueden ser creadas a través de una combinación de las clases [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) y [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit), y operaciones de [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) de la siguiente manera:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");

``` 

### **Métodos Nary e Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Tanto el método **nary** como el **integral** crean y devuelven el operador n-ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). En el método nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) especifica el tipo de operador: suma, unión, etc., sin incluir integrales. En el método Integral, hay la operación especializada Integral con la enumeración de tipos de integral [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes). 

Ejemplo:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");

``` 

### **Método ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) coloca elementos en un arreglo vertical. Si esta operación se llama para una instancia de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), todos los elementos secundarios serán colocados en el arreglo devuelto.

Ejemplo:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();

``` 

### **Operaciones de Formato: Acento, Sobrebarra, Subbarra, Agrupación, ToBorderBox, ToBox**
- El método [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) establece una marca de acento (un carácter en la parte superior del elemento).
- Los métodos [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) y [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) establecen una barra en la parte superior o inferior.
- El método [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) coloca en un grupo utilizando un carácter de agrupación como un corchete inferior o otro.
- El método [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) coloca en un borde.
- El método [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) coloca en una caja no visual (agrupamiento lógico).

Ejemplos:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();

``` 