---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en PHP
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/php-java/powerpoint-math-equations/
keywords:
- ecuación matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- añadir ecuación matemática
- añadir símbolo matemático
- añadir fórmula matemática
- añadir texto matemático
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Inserte y edite ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para PHP mediante Java, con compatibilidad con OMML, controles de formato y ejemplos de código claros."
---

## **Descripción general**
En PowerPoint, es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, varios símbolos matemáticos están representados en PowerPoint y pueden añadirse al texto o a la ecuación. Para ello, se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n-arias
- Matriz
- Operadores grandes
- Funciones seno y coseno

Para añadir una ecuación matemática en PowerPoint, se usa el menú *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite una gran cantidad de símbolos matemáticos para crear ecuaciones. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no produce un resultado buen y profesional. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas con buen aspecto.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), puede trabajar con ecuaciones matemáticas en presentaciones de PowerPoint de forma programática en C#. Crear nuevas expresiones matemáticas o editar las creadas previamente. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.

## **Cómo crear una ecuación matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidación. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) es esencialmente una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no mezclar con [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son la clave para trabajar con ecuaciones matemáticas de PowerPoint a través de la API Aspose.Slides.

Veamos cómo podemos crear la siguiente ecuación matemática mediante la API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero, añada una forma que contendrá el texto matemático:
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


Tras crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) es una porción que contiene texto matemático en su interior. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), consulte la variable [**MathParagraph** ](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

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


## **Tipos de elementos matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos está representada por un bloque matemático, y los argumentos de los elementos forman un anidamiento tipo árbol.

Existen muchos tipos de elementos matemáticos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) en otro elemento. Es decir, los elementos son en realidad contenedores de otros, formando una estructura tipo árbol. El tipo más simple de elemento que no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la clase `MathElement`, lo que permite usar el conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) especifica el objeto fracción, compuesto por un numerador y un denominador separados por una barra de fracción. La barra de fracción puede ser horizontal o diagonal, según las propiedades de la fracción. El objeto fracción también se usa para representar la función apilada, que coloca un elemento sobre otro, sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) especifica una función de un argumento. Contiene las propiedades: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - nombre de la función y [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) especifica un objeto matemático N-ario, como la Sumatoria o la Integral. Consta de un operador, una base (u operando) y límites superiores e inferiores opcionales. Los ejemplos de operadores N-arios son Sumatoria, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Estos se representan mediante un único elemento de texto – [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, formado por texto en la línea base y texto de tamaño reducido inmediatamente arriba o abajo de ella. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando los elementos [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) de la siguiente manera:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Las clases siguientes especifican un subíndice o un superíndice. Puede establecer subíndice y superíndice al mismo tiempo a la izquierda o a la derecha de un argumento, pero solo se admite un subíndice o superíndice individual en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) también puede usarse para establecer el grado matemático de un número.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) especifica el objeto Matriz, compuesto por elementos hijos dispuestos en una o varias filas y columnas. Es importante notar que las matrices no tienen delimitadores integrados. Para colocar la matriz entre corchetes debe usar el objeto delimitador – [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/). Los argumentos nulos pueden usarse para crear huecos en matrices.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) especifica una matriz vertical de ecuaciones o cualquier objeto matemático.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formato de elementos matemáticos**
- Clase [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): dibuja un borde rectangular u otro alrededor del `MathElement`.

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Clase [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): especifica el empaquetado lógico del elemento matemático. Por ejemplo, un objeto en caja puede servir como emulador de operador con o sin punto de alineación, servir como ruptura de línea o agruparse para evitar quiebres de línea dentro. Por ejemplo, el operador "==" debería estar en caja para evitar quiebres de línea.
- Clase [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): especifica el objeto delimitador, compuesto por caracteres de apertura y cierre (como paréntesis, llaves, corchetes y barras verticales), y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Clase [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): especifica la función acento, compuesta por una base y una marca diacrítica combinada.

  Ejemplo: 𝑎́.

- Clase [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): especifica la función barra, compuesta por un argumento base y una barra superior o inferior.

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): especifica un símbolo de agrupación arriba o abajo de una expresión, generalmente para resaltar las relaciones entre elementos.

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones matemáticas**
Cada elemento y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) hereda la clase `MathElement`. Permite usar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones tienen dos conjuntos de parámetros: `MathElement` o cadena de texto. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) se crean implícitamente a partir de las cadenas especificadas cuando se usan argumentos de tipo string. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.

### **Método Join**
- `join(String)`
- `join(MathElement)`

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Método Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Crea una fracción del tipo especificado con este numerador y el denominador indicado. Por ejemplo:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Método Enclose**
- `enclose()`
- `enclose(Char, Char)`

Encierra el elemento en los caracteres especificados, como paréntesis u otro carácter de marco.

```php

``` 

Por ejemplo:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Método Function**
- `function(String)`
- `function(MathElement)`

Aplica una función a un argumento usando el objeto actual como nombre de la función.

```php

``` 

Por ejemplo:

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **Método AsArgumentOfFunction**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Toma la función especificada usando la instancia actual como argumento. Puede:

- especificar una cadena como nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument::ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- seleccionar la instancia de `MathElement`.

Por ejemplo:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Establece subíndice y superíndice. Puede establecer ambos simultáneamente a la izquierda o a la derecha del argumento, pero solo se admite un subíndice o superíndice individual en el lado derecho. El **Superscript** también puede usarse para definir el grado matemático de un número.

Ejemplo:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Método Radical**
- `radical(String)`
- `radical(MathElement)`

Especifica la raíz matemática del grado indicado a partir del argumento suministrado.

Ejemplo:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Establece el límite superior o inferior. Aquí, “superior” e “inferior” indican simplemente la posición del argumento respecto a la base.

Consideremos una expresión:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden crearse combinando las clases [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) y [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit), y operaciones de `MathElement` de la siguiente forma:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Métodos Nary e Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Los métodos **nary** e **integral** crean y devuelven el operador N-ario representado por el tipo [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator). En el método nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) especifica el tipo de operador: sumatoria, unión, etc., sin incluir integrales. En el método Integral, hay una operación especializada Integral con la enumeración de tipos integrales [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

Ejemplo:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **Método ToMathArray**
`MathElement.toMathArray` coloca los elementos en una matriz vertical. Si esta operación se llama para una instancia de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), todos los elementos hijos se colocarán en la matriz devuelta.

Ejemplo:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- El método **`accent`** establece una marca de acento (un carácter sobre el elemento).
- Los métodos **`overbar`** y **`underbar`** colocan una barra arriba o abajo.
- El método **`group`** agrupa usando un carácter de agrupación, como una llave inferior u otro.
- El método **`toBorderBox`** coloca en un cuadro con borde.
- El método **`toBox`** coloca en un cuadro no visual (agrupación lógica).

Ejemplos:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**¿Cómo puedo añadir una ecuación matemática a una diapositiva de PowerPoint?**

Para añadir una ecuación matemática, debe crear un objeto de forma matemática, que contiene automáticamente una porción matemática. Después, obtenga el [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) desde el [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) y añada objetos [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) a él.

**¿Es posible crear expresiones matemáticas complejas anidadas?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas mediante la anidación de MathBlocks. Cada elemento matemático permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, debe acceder a los MathBlocks existentes a través del [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Luego, usando métodos como Join, Divide, Enclose y otros, puede modificar los elementos individuales de la ecuación. Después de editar, guarde la presentación para aplicar los cambios.