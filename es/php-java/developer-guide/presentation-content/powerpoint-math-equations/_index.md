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
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para PHP vía Java, con soporte OMML, controles de formato y ejemplos de código claros."
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
- Funciones sin, cos

Para añadir una ecuación matemática en PowerPoint se usa el menú *Insert → Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente forma:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint soporta una gran cantidad de símbolos matemáticos para crear ecuaciones. Sin embargo, crear ecuaciones complejas en PowerPoint a menudo no produce un resultado profesional y de buena calidad. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas con buen aspecto.

Utilizando [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), puede trabajar con ecuaciones matemáticas en presentaciones de PowerPoint programáticamente en C#. Cree nuevas expresiones matemáticas o edite las creadas anteriormente. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.


## **Cómo crear una ecuación matemática**
Los elementos matemáticos se usan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). La clase [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) es esencialmente una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) es una porción matemática, utilizada para contener texto matemático (no confundir con [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son la clave para trabajar con ecuaciones matemáticas de PowerPoint mediante la API Aspose.Slides.

Veamos cómo crear la siguiente ecuación matemática mediante la API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero añada una forma que contendrá el texto matemático:
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


Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) es una porción que contiene texto matemático dentro. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), consulte la variable [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
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
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos está representada por un bloque matemático, y los argumentos de los elementos forman un anidamiento tipo árbol.

Existen muchos tipos de elementos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) en otro elemento. Es decir, los elementos son contenedores de otros, formando una estructura arbórea. El tipo más simple de elemento no contiene otros elementos del texto matemático.

Cada tipo de elemento implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), lo que permite usar un conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) especifica el objeto fracción, compuesto por un numerador y un denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El mismo objeto también se usa para representar la función stack, que coloca un elemento encima de otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) especifica la función radical (raíz matemática), compuesta por una base y, opcionalmente, un grado.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) especifica una función de un argumento. Contiene las propiedades [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) (nombre de la función) y [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) (argumento de la función).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) especifica un objeto matemático n‑ario, como sumatorio o integral. Consta de un operador, una base (o operando) y límites superiores e inferiores opcionales. Ejemplos de operadores n‑arios: sumatorio, unión, intersección, integral.

Esta clase no incluye operadores simples como suma o resta; esos se representan con un solo elemento de texto [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) crea el límite superior o inferior. Especifica el objeto límite, compuesto por texto en la línea base y texto de tamaño reducido inmediatamente encima o debajo. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión  

![todo:image_alt_text](powerpoint-math-equations_8.png)  

se crea combinando los elementos [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) y [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) de la siguiente forma:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Estas clases especifican un subíndice o un superíndice. Puede establecer subíndice y superíndice simultáneamente a la izquierda o a la derecha de un argumento, pero únicamente un subíndice o superíndice simple está soportado a la derecha. [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) también puede usarse para establecer el grado matemático de un número.

Ejemplo:  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) especifica el objeto matriz, compuesto por elementos hijos dispuestos en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para colocar la matriz entre corchetes debe usarse el objeto delimitador [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). Los argumentos nulos pueden usarse para crear huecos en las matrices.

Ejemplo:  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) especifica un arreglo vertical de ecuaciones o cualquier objeto matemático.

Ejemplo:  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formato de elementos matemáticos**
- Clase [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): dibuja un borde rectangular u otro alrededor del [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Clase [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): especifica el empaquetado lógico del elemento matemático. Por ejemplo, un objeto en caja puede servir como emulador de operador con o sin punto de alineación, como punto de ruptura de línea o agruparse para impedir saltos de línea internos. Por ejemplo, el operador “==” debe encajarse en una caja para evitar rupturas.

- Clase [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): especifica el objeto delimitador, compuesto por caracteres de apertura y cierre (paréntesis, llaves, corchetes, barras verticales) y uno o más elementos dentro, separados por un carácter especificado. Ejemplos: (𝑥²); [𝑥²|𝑦²].  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Clase [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): especifica la función de acento, compuesta por una base y una marca diacrítica combinada.  
  Ejemplo: 𝑎́.

- Clase [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): especifica la función barra, compuesta por un argumento base y una barra superior o inferior.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): especifica un símbolo de agrupación encima o debajo de una expresión, normalmente para resaltar relaciones entre elementos.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Operaciones matemáticas**
Cada elemento y expresión (a través de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Permite usar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones aceptan dos conjuntos de parámetros: [**IMathElement**] o string. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) se crean implícitamente a partir de cadenas cuando se usan argumentos de tipo string. Las operaciones disponibles en Aspose.Slides se enumeran a continuación.

### **Método Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Une un elemento matemático y forma un bloque. Por ejemplo:

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

Crea una fracción del tipo especificado con este numerador y el denominador indicado. Por ejemplo:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Método Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Encierra el elemento entre los caracteres especificados, como paréntesis u otro símbolo de marco.

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

Toma una función de un argumento usando el objeto actual como nombre de la función.

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

Toma la función especificada usando la instancia actual como argumento. Puede:

- especificar una cadena como nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de los enumerados [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), por ejemplo [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- pasar una instancia de [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

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

Establece subíndice y superíndice. Puede establecer ambos simultáneamente a la izquierda o a la derecha del argumento, aunque un subíndice o superíndice simple solo se admite a la derecha. El **Superscript** también puede usarse para definir el grado matemático de un número.

Ejemplo:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Método Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Especifica la raíz matemática del grado indicado a partir del argumento dado.

Ejemplo:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Define el límite superior o inferior. Aquí, “superior” e “inferior” indican simplemente la posición del argumento respecto a la base.

Consideremos la expresión:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden crearse combinando las clases [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) y [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit), y usando operaciones de [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) de la siguiente manera:

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

Los métodos **nary** e **integral** crean y devuelven el operador n‑ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). En el método nary, el enumerado [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) indica el tipo de operador: sumatorio, unión, etc., sin incluir integrales. En el método integral, se usa la enumeración [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes) para especificar el tipo de integral.

Ejemplo:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **Método ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) coloca los elementos en un arreglo vertical. Si se llama a esta operación sobre una instancia de [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), todos los elementos hijos se colocarán en el arreglo devuelto.

Ejemplo:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Método [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) establece una marca de acento (carácter sobre el elemento).
- Métodos [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) y [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) colocan una barra encima o debajo.
- Método [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) agrupa usando un carácter de agrupación, como una llave curva inferior u otro.
- Método [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) coloca el elemento en un borde‑caja.
- Método [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) coloca el elemento en una caja lógica (no visual).

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

Para añadir una ecuación, debe crear un objeto forma matemática, que contiene automáticamente una porción matemática. Luego, obtenga el [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) de la [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) y añada objetos [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) a ella.

**¿Es posible crear expresiones matemáticas complejas con anidación?**

Sí, Aspose.Slides permite crear expresiones complejas anidando MathBlocks. Cada elemento permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, acceda a los MathBlocks existentes mediante el [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Luego, usando métodos como Join, Divide, Enclose, etc., modifique los elementos individuales de la ecuación. Tras la edición, guarde la presentación para aplicar los cambios.