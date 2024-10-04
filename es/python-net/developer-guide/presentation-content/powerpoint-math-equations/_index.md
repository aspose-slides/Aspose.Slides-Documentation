---
title: Ecuaciones Matemáticas de PowerPoint
type: docs
weight: 80
url: /python-net/powerpoint-math-equations/
keywords: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmula de PowerPoint, Texto Matemático de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos, Fórmulas y Texto Matemático en Python"
---

## **Descripción general**
En PowerPoint, es posible escribir una ecuación matemática o fórmula y mostrarla en la presentación. Para hacer eso, varios símbolos matemáticos están representados en PowerPoint y pueden ser añadidos al texto o a la ecuación. Para eso, se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción Matemática
- Radical Matemático
- Función Matemática
- Límites y funciones logarítmicas
- Operaciones N-arias
- Matriz
- Operadores grandes
- Funciones sen, cos

Para agregar una ecuación matemática en PowerPoint, se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que se puede mostrar en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint soporta una gran cantidad de símbolos matemáticos para crear ecuaciones matemáticas. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no produce un resultado atractivo y profesional. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren al uso de soluciones de terceros para crear fórmulas matemáticas de buen aspecto.

Usando la [**API de Aspose.Slide**](https://products.aspose.com/slides/python-net/), puedes trabajar con ecuaciones matemáticas en las presentaciones de PowerPoint programáticamente en Python. Crea nuevas expresiones matemáticas o edita las ya creadas. La exportación de estructuras matemáticas a imágenes también es compatible de manera parcial.

## **Cómo crear una ecuación matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). La clase [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) es esencialmente una expresión matemática separada, fórmula o ecuación. [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) es una porción matemática, utilizada para contener texto matemático (no mezclar con [**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) permite manipular un conjunto de bloques matemáticos. Las clases antes mencionadas son clave para trabajar con ecuaciones matemáticas de PowerPoint a través de la API de Aspose.Slides.

Veamos cómo podemos crear la siguiente ecuación matemática a través de la API de Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero añade una forma que contenga el texto matemático:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) es una porción que contiene un texto matemático en su interior. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), referirse a la variable [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

La clase [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) permite leer, agregar, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crea una fracción y colócala en la presentación:

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

Cada elemento matemático está representado por alguna clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Esta interfaz proporciona muchos métodos para crear expresiones matemáticas de manera sencilla. Puedes crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras se vería así:

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) están implementadas en cualquier tipo de elemento, incluidos los [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

El código fuente completo de ejemplo:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipos de elementos matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos es representada por un bloque matemático, y los argumentos de los elementos matemáticos forman una anidación en forma de árbol.

Hay muchos tipos de elementos matemáticos que se pueden utilizar para construir un bloque matemático. Cada uno de estos elementos puede ser incluido (agregado) en otro elemento. Es decir, los elementos son en realidad contenedores para otros, formando una estructura en forma de árbol. El tipo más simple de elemento que no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), permitiendo el uso del conjunto común de operaciones matemáticas en diferentes tipos de elementos matemáticos.
### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) representa un texto matemático: el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables, y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐
### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) especifica el objeto de fracción, consistiendo en un numerador y un denominador separados por una barra de fracción. La barra de fracción puede ser horizontal o diagonal, dependiendo de las propiedades de la fracción. El objeto de fracción también se utiliza para representar la función de pila, que coloca un elemento encima de otro, sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) especifica la función radical (raíz matemática), que consiste en una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) especifica una función de un argumento. Contiene propiedades: [Name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - nombre de la función y [Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) especifica un objeto matemático N-ario, como Suma e Integral. Consiste en un operador, una base (o operando), y límites superiores e inferiores opcionales. Ejemplos de operadores N-arios son Suma, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Están representados por un solo elemento de texto - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) crea el límite superior o inferior. Especifica el objeto límite, que consiste en texto en la línea base y texto de tamaño reducido inmediatamente arriba o abajo de él. Este elemento no incluye la palabra "lim", pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea utilizando una combinación de elementos [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) y [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) de esta manera:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Las siguientes clases especifican un índice inferior o un índice superior. Puedes establecer superíndices e índices inferiores al mismo tiempo en el lado izquierdo o derecho de un argumento, pero se admite un solo superíndice o subíndice solo en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) también puede ser utilizado para establecer el grado matemático de un número.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) especifica el objeto Matriz, que consiste en elementos secundarios dispuestos en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para colocar la matriz en los corchetes, debes usar el objeto delimitador - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/). Los argumentos nulos se pueden utilizar para crear espacios en las matrices.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) especifica un arreglo vertical de ecuaciones u objetos matemáticos.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatación de elementos matemáticos**
- La clase [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/): dibuja un borde rectangular u otro alrededor del [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La clase [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) especifica el enmarcado lógico (empaque) del elemento matemático. Por ejemplo, un objeto enmarcado puede servir como emulador de operador con o sin un punto de alineación, servir como un punto de ruptura de línea, o ser agrupado para no permitir saltos de línea dentro. Por ejemplo, el operador "==" debe estar enmarcado para prevenir saltos de línea.
- La clase [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) especifica el objeto delimitador, consistiendo en caracteres de apertura y cierre (como paréntesis, llaves, corchetes y barras verticales), y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].

  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La clase [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) especifica la función acento, que consiste en una base y una marca diacrítica combinada. 

  Ejemplo: 𝑎́.

- La clase [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) especifica la función de barra, que consiste en un argumento base y una barra superior o inferior.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) especifica un símbolo de agrupamiento por encima o por debajo de una expresión, generalmente para resaltar las relaciones entre elementos.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones Matemáticas**
Cada elemento matemático y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Permite utilizar operaciones sobre la estructura existente y formar expresiones matemáticas más complejas. Todas las operaciones tienen dos conjuntos de parámetros: o [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) o cadena como argumentos. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) se crean implícitamente a partir de cadenas especificadas cuando se utilizan argumentos de cadena. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.
### **Método Join**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Método Divide**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Crea una fracción del tipo especificado con este numerador y denominador especificado. Por ejemplo:

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Método Enclose**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Encierra el elemento en caracteres especificados como paréntesis u otro carácter como enmarcamiento.

```py
# Enclava un elemento matemático en paréntesis
MathDelimiter enclose()

# Enclava este elemento en caracteres especificados como paréntesis u otros caracteres como enmarcamiento
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```

Por ejemplo:

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Método Function**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Toma una función de un argumento utilizando el objeto actual como el nombre de la función.

Por ejemplo:

```py
func = math.MathematicalText("sin").function("x")
```
### **Método AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Toma la función especificada utilizando la instancia actual como argumento. Puedes:

- especificar una cadena como el nombre de la función, por ejemplo, “cos”.
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), por ejemplo **MathFunctionsOfOneArgument.ArcSin.**
- seleccionar la instancia de [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Por ejemplo:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Establece subíndices y superíndices. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o derecho del argumento, pero se admite un solo subíndice o superíndice solo en el lado derecho. El **Superíndice** también puede ser usado para establecer el grado matemático de un número.

Ejemplo:

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Método Radical**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Especifica la raíz matemática del grado dado del argumento especificado.

Ejemplo:

```py
    radical = math.MathematicalText("x").radical("3")
```
### **Métodos SetUpperLimit y SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Toma el límite superior o inferior. Aquí, el superior e inferior simplemente indican la ubicación del argumento respecto a la base.

Consideremos una expresión: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones se pueden crear a través de una combinación de las clases [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) y [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), y operaciones de [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) de la siguiente manera:

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Métodos Nary e Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Tanto el método **Nary** como el método **Integral** crean y devuelven el operador N-ario representado por el tipo [**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/). En el método Nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) especifica el tipo de operador: suma, unión, etc., sin incluir integrales. En el método Integral, hay la operación especializada Integral con la enumeración de tipos integrales [**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).  

Ejemplo:

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **Método ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) coloca elementos en un arreglo vertical. Si esta operación se llama para una instancia de **MathBlock**, todos los elementos secundarios se colocarán en el arreglo devuelto.

Ejemplo:

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **Operaciones de formato: Acento, Barra superior, Barra inferior, Agrupación, ToBorderBox, ToBox**
- El método [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) establece una marca de acento (un carácter en la parte superior del elemento).
- Los métodos [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) y [**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) establecen una barra en la parte superior o inferior.
- El método [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) coloca en un grupo utilizando un carácter de agrupación como una llave inferior o otro.
- El método [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) coloca en una caja borde.
- El método [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) coloca en una caja no visual (agrupación lógica).

Ejemplos:

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```