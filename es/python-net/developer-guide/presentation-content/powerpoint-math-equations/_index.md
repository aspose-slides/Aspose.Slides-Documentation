---
title: Añadir ecuaciones matemáticas a presentaciones PowerPoint en Python
linktitle: Ecuaciones matemáticas
type: docs
weight: 80
url: /es/python-net/powerpoint-math-equations/
keywords:
- ecuación matemática
- ecuación matemática PowerPoint
- símbolo matemático
- símbolo matemático PowerPoint
- fórmula matemática
- fórmula matemática PowerPoint
- texto matemático
- texto matemático PowerPoint
- añadir ecuación matemática a PowerPoint
- añadir símbolo matemático a PowerPoint
- añadir fórmula matemática a PowerPoint
- añadir texto matemático a PowerPoint
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a trabajar con ecuaciones matemáticas en PowerPoint usando Aspose.Slides para Python a través de .NET. Obtenga instrucciones detalladas, ejemplos de código y consejos para automatizar la creación y edición de presentaciones."
---

## **Visión general**

En PowerPoint, puedes escribir una ecuación o fórmula matemática y mostrarla en tu presentación. Hay disponibles varios símbolos matemáticos que pueden añadirse al texto o a las ecuaciones. El constructor de ecuaciones matemáticas se utiliza para crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n-arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para añadir una ecuación matemática en PowerPoint, se utiliza el menú *Insertar → Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que podrá mostrarse en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite una amplia gama de símbolos matemáticos para crear ecuaciones. Sin embargo, generar ecuaciones matemáticas complejas en PowerPoint a menudo no produce un resultado pulido y profesional. Por ello, los usuarios que crean presentaciones matemáticas con frecuencia suelen recurrir a soluciones de terceros para obtener fórmulas matemáticas con mejor apariencia.

Usando la [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/), puedes trabajar con ecuaciones matemáticas en presentaciones de PowerPoint de forma programática en Python. Crea nuevas expresiones matemáticas o edita las creadas previamente. Existe soporte parcial para exportar estructuras matemáticas como imágenes.

## **Cómo crear una ecuación matemática**

Los elementos matemáticos se utilizan para construir cualquier construcción matemática, sin importar el nivel de anidamiento. Una colección lineal de estos elementos forma un bloque matemático, representado por la clase [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). La clase [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) representa una expresión, fórmula o ecuación matemática independiente. La clase [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) se usa para contener texto matemático (distinto del regular [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)), mientras que [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) permite manipular un conjunto de objetos [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Estas clases son esenciales para trabajar con ecuaciones matemáticas de PowerPoint a través de la Aspose.Slides API.

Veamos cómo podemos crear la siguiente ecuación matemática utilizando la Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática a la diapositiva, primero añade una forma que contenga el texto matemático:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


Después de crear la forma, ésta ya contiene un párrafo con una porción matemática por defecto. La clase [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) representa una porción que contiene texto matemático. Para acceder al contenido matemático dentro de una [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), consulta la variable [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


La clase [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) te permite leer, añadir, editar y eliminar bloques matemáticos ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crea una fracción y colócala en la presentación:
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
``` 

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```


Las operaciones de la clase [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) están implementadas en todo tipo de elemento, incluida la clase [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

A continuación se muestra el ejemplo de código completo:
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


## **Tipos de elementos matemáticos**

Las expresiones matemáticas están compuestas por secuencias de elementos matemáticos. Un bloque matemático representa dicha secuencia, y los argumentos de estos elementos forman una estructura anidada tipo árbol.

Existen muchos tipos de elementos matemáticos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede agruparse dentro de otro, formando una estructura tipo árbol. El tipo de elemento más simple es aquel que no contiene ningún otro elemento de texto matemático.

Cada tipo de elemento matemático implementa la clase [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), lo que permite utilizar un conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**

La clase [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables o cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**

La clase [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) especifica un objeto fracción compuesto por un numerador y un denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El objeto fracción también se usa para representar la función de apilamiento, que coloca un elemento encima de otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**

La clase [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**

La clase [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) especifica una función de un argumento. Contiene propiedades como [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/), que representa el nombre de la función, y [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/), que representa el argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**

La clase [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) especifica un objeto matemático n-ario, como una suma o una integral. Consta de un operador, una base (u operando) y límites superiores e inferiores opcionales. Los operadores n-arios incluyen Suma, Unión, Intersección e Integral.

Esta clase no incluye operadores simples como suma, resta, etc.; esos se representan mediante un único texto [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**

La clase [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) crea el límite superior o inferior. Especifica el objeto límite, formado por texto en la línea base y texto reducido justo encima o debajo. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión  

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando los elementos [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) y [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) de la siguiente manera:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Estas clases especifican un subíndice o un superíndice. Puedes establecer simultáneamente subíndice y superíndice en el lado izquierdo o derecho de un argumento, pero un solo subíndice o superíndice solo se admite en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) también puede usarse para establecer el grado matemático de un número.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**

La clase [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) especifica el objeto Matriz, que consiste en elementos hijos ordenados en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para rodear la matriz con corchetes, usa el objeto delimitador [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). Los argumentos nulos pueden usarse para crear huecos en las matrices.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**

La clase [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) especifica una matriz vertical de ecuaciones o cualquier objeto matemático.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formato de elementos matemáticos**

- Clase [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/): Dibuja un borde rectangular o alternativo alrededor del [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Clase [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/): Especifica el encajado lógico (empaquetado) de un elemento matemático. Un objeto encajado puede servir como emulador de operador—con o sin punto de alineación—funcionar como interrupción de línea o agruparse para evitar saltos de línea dentro. Por ejemplo, el operador “==” debe encajarse para evitar saltos de línea.

- Clase [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/): Especifica el objeto delimitador, que consiste en caracteres de apertura y cierre (paréntesis, llaves, corchetes o barras verticales) y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Clase [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/): Especifica la función de acento, compuesta por una base y una marca diacrítica combinada.

Ejemplo: 𝑎́.

- Clase [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/): Especifica la función de barra, compuesta por un argumento base y una barra superior o inferior.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Clase [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/): Especifica un símbolo de agrupación colocado arriba o abajo de una expresión, normalmente para resaltar relaciones entre elementos.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones matemáticas**

Cada elemento y cada expresión matemática (mediante [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implementa la clase [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Esto permite realizar operaciones sobre la estructura existente y crear expresiones más complejas. Todas las operaciones disponen de dos conjuntos de parámetros: ya sea [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) o argumentos de tipo cadena. Las instancias de la clase [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) se crean implícitamente a partir de las cadenas especificadas cuando se usan argumentos de tipo cadena. A continuación se enumeran las operaciones disponibles en Aspose.Slides.

### **Método Join**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

Estos métodos unen un elemento matemático y forman un bloque matemático. Por ejemplo:
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Método Divide**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

Estos métodos crean una fracción del tipo especificado con numerador y denominador indicados. Por ejemplo:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Método Enclose**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

Estos métodos encierran el elemento entre los caracteres especificados, como paréntesis u otros caracteres de marco. Por ejemplo:
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Método Function**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

Estos métodos toman una función de un argumento usando el objeto actual como nombre de la función. Por ejemplo:
```py
function = math.MathematicalText("sin").function("x")
```


### **Método AsArgumentOfFunction**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Estos métodos usan la instancia actual como argumento de la función especificada. Puedes:

- especificar una cadena como nombre de la función, por ejemplo “cos”;
- seleccionar uno de los valores predefinidos de los enumerados [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) o [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), por ejemplo `MathFunctionsOfOneArgument.ARC_SIN`;
- pasar una instancia de [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Por ejemplo:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

Estos métodos establecen subíndice y superíndice. Puedes establecer ambos simultáneamente en el lado izquierdo o derecho del argumento; sin embargo, un único subíndice o superíndice solo se admite en el lado derecho. El **Superscript** también puede usarse para establecer el grado matemático de un número.

Ejemplo:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Método Radical**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

Estos métodos especifican la raíz matemática del grado dado basándose en el argumento indicado.

Ejemplo:
```py
radical = math.MathematicalText("x").radical("3")
```


### **Métodos SetUpperLimit y SetLowerLimit**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

Estos métodos establecen un límite superior o inferior, donde “superior” e “inferior” indican la posición del argumento respecto a la base.

Consideremos una expresión:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden crearse combinando las clases [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) y [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), junto con las operaciones de la clase [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), como sigue:
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Métodos Nary e Integral**

- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

Los métodos `nary` e `integral` crean y devuelven el operador n-ario representado por el tipo [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/). En el método Nary, el enumerado [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) indica el tipo de operador—como suma o unión—excluyendo integrales. En el método Integral, se proporciona una operación especializada para integrales mediante el enumerado [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).

Ejemplo:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **Método ToMathArray**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) coloca elementos en una matriz vertical. Si esta operación se llama sobre una instancia de [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), todos sus elementos hijos se colocarán en la matriz resultante.

Ejemplo:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- El método [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) establece una marca de acento (un carácter sobre el elemento).
- Los métodos [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) y [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) colocan una barra en la parte superior o inferior.
- El método [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) agrupa usando un carácter de agrupación, como una llave inferior u otro.
- El método [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) coloca en un borde‑caja.
- El método [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) coloca en una caja no visual (agrupación lógica).

Ejemplos:
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

**¿Cómo puedo añadir una ecuación matemática a una diapositiva de PowerPoint?**

Para añadir una ecuación matemática, debes [crear un objeto shape de tipo math](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), que contiene automáticamente una porción matemática. Luego, recuperas el [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) desde el [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) y añades objetos [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) a él.

**¿Es posible crear expresiones matemáticas complejas y anidadas?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas anidando [MathBlocks](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Cada elemento matemático permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, debes acceder al [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) existente a través del [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Luego, usando métodos como Join, Divide, Enclose, entre otros, puedes modificar los elementos individuales de la ecuación. Después de editar, guarda la presentación para aplicar los cambios.