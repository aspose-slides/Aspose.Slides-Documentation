---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en .NET
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para .NET, con soporte OMML, controles de formato y ejemplos claros de código C#."
---

## **Descripción general**

En PowerPoint, puedes escribir una ecuación o fórmula matemática y mostrarla en tu presentación. Hay disponibles varios símbolos matemáticos que pueden añadirse al texto o a las ecuaciones. El constructor de ecuaciones matemáticas se utiliza para crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n‑arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para añadir una ecuación matemática en PowerPoint, se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite una amplia gama de símbolos matemáticos para crear ecuaciones. Sin embargo, generar ecuaciones matemáticas complejas en PowerPoint a menudo no produce un resultado pulido y profesional. Por ello, los usuarios que crean presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas de mejor aspecto.

Usando la [**Aspose.Slides API**](https://products.aspose.com/slides/net/), puedes trabajar con ecuaciones matemáticas en presentaciones de PowerPoint programáticamente en C#. Crea nuevas expresiones matemáticas o edita las ya creadas. Existe soporte parcial para exportar estructuras matemáticas como imágenes.

## **Cómo crear una ecuación matemática**

Los elementos matemáticos se utilizan para construir cualquier construcción matemática, sin importar el nivel de anidación. Una colección lineal de estos elementos forma un bloque matemático, representado por la clase [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). La clase [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) representa una expresión, fórmula o ecuación matemática independiente. [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) se usa para contener texto matemático (distinto de la clase regular [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion)), mientras que [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) permite manipular un conjunto de objetos [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Estas clases son esenciales para trabajar con ecuaciones matemáticas de PowerPoint a través de la Aspose.Slides API.

Veamos cómo crear la siguiente ecuación matemática usando la Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática a la diapositiva, primero añade una forma que contendrá el texto matemático:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


Después de crear la forma, ya contiene un párrafo con una porción matemática por defecto. La clase [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) representa una porción que contiene texto matemático. Para acceder al contenido matemático dentro de una [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), consulte la variable [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


La clase [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) le permite leer, añadir, editar y eliminar bloques matemáticos ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), que consisten en una combinación de elementos matemáticos. Por ejemplo, cree una fracción y colóquela en la presentación:
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


Cada elemento matemático está representado por una clase que implementa la interfaz [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). Esta interfaz proporciona numerosos métodos para crear expresiones matemáticas con facilidad, lo que le permite construir ecuaciones bastante complejas con una sola línea de código. Por ejemplo, el teorema de Pitágoras se vería así:
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


Las operaciones de la interfaz [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) se implementan en cada tipo de elemento, incluida la clase [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

A continuación se muestra el ejemplo de código completo:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
    var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

    var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));

    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **Tipos de elementos matemáticos**

Las expresiones matemáticas se componen de secuencias de elementos matemáticos. Un bloque matemático representa dicha secuencia, y los argumentos de estos elementos forman una estructura anidada tipo árbol.

Existen muchos tipos de elementos matemáticos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede agregarse dentro de otro, formando una estructura de árbol. El tipo más sencillo de elemento es aquel que no contiene otros elementos de texto matemático.

Cada tipo de elemento matemático implementa la interfaz [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), lo que permite usar un conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**

La clase [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables o cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**

La clase [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) especifica un objeto fracción formado por un numerador y un denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El mismo objeto también se usa para representar la función stack, que coloca un elemento sobre otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**

La clase [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**

La clase [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) especifica una función de un argumento. Contiene propiedades como [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name), que representa el nombre de la función, y [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base), que representa el argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**

La clase [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) especifica un objeto matemático N‑ario, como una Sumatoria o Integral. Consta de un operador, una base (o operando) y límites superior e inferior opcionales. Ejemplos de operadores N‑arios son Sumatoria, Unión, Intersección e Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Estos se representan mediante un único texto [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**

La clase [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) crea el límite superior o inferior. Especifica el objeto límite, compuesto por texto en la línea base y texto reducido justo encima o debajo de ella. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión  

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando los elementos [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) y [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) de la siguiente forma:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Estas clases especifican un subíndice o un superíndice. Puede establecerse simultáneamente subíndice y superíndice a la izquierda o a la derecha de un argumento, pero un solo subíndice o superíndice se soporta únicamente a la derecha. La clase [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) también puede usarse para definir el grado matemático de un número.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**

La clase [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) especifica el objeto Matriz, que consta de elementos hijos organizados en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para encerrar la matriz entre corchetes, utilice el objeto delimitador [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Los argumentos nulos pueden usarse para crear huecos en matrices.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**

La clase [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) especifica un arreglo vertical de ecuaciones o cualquier objeto matemático.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formato de elementos matemáticos**

- Clase [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): Dibuja un borde rectangular o alternativo alrededor del [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Clase [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): Especifica el encajado lógico (empaquetado) de un elemento matemático. Un objeto encajado puede servir como emulador de operador—con o sin punto de alineación—funcionar como punto de ruptura de línea o agruparse para evitar saltos de línea internos. Por ejemplo, el operador “==” debería encajarse para impedir rupturas de línea.

- Clase [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): Especifica el objeto delimitador, que consta de caracteres de apertura y cierre (como paréntesis, llaves, corchetes o barras verticales) y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥₂); [𝑥₂|𝑦₂].

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Clase [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): Especifica la función de acento, compuesta por una base y una marca diacrítica combinada.

Ejemplo: 𝑎́.

- Clase [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): Especifica la función barra, compuesta por un argumento base y una barra superior o inferior.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Clase [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): Especifica un símbolo de agrupamiento colocado sobre o bajo una expresión, típicamente para resaltar relaciones entre elementos.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones matemáticas**

Cada elemento matemático y cada expresión matemática (a través de [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implementa la interfaz [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Esto permite realizar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [IMathElement] o argumentos de cadena. Las instancias de la clase [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) se crean implícitamente a partir de las cadenas especificadas cuando se usan argumentos de tipo string. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.

### **Método Join**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Estos métodos unen un elemento matemático y forman un bloque matemático. Por ejemplo:
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Método Divide**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Estos métodos crean una fracción del tipo especificado con numerador y denominador dados. Por ejemplo:
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Método Enclose**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Estos métodos encierran el elemento entre caracteres especificados, como paréntesis u otros caracteres de encuadre. Por ejemplo:
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Método Function**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Estos métodos toman una función de un argumento usando el objeto actual como nombre de la función. Por ejemplo:
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **Método AsArgumentOfFunction**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Estos métodos toman la función especificada usando la instancia actual como argumento. Puede:

- especificar una cadena como nombre de la función, por ejemplo “cos”;
- seleccionar uno de los valores predefinidos de las enumeraciones [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) o [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), por ejemplo `MathFunctionsOfOneArgument.ArcSin`;
- pasar la instancia de [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

Por ejemplo:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")
```


### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**

- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Estos métodos establecen subíndice y superíndice. Puede establecer ambos simultáneamente a la izquierda o a la derecha del argumento; sin embargo, un solo subíndice o superíndice solo se soporta a la derecha. El **Superscript** también puede usarse para definir el grado matemático de un número.

Ejemplo:
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Método Radical**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Estos métodos especifican la raíz matemática del grado indicado a partir del argumento proporcionado.

Ejemplo:
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **Métodos SetUpperLimit y SetLowerLimit**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Estos métodos establecen un límite superior o inferior, donde “superior” e “inferior” indican la posición del argumento respecto a la base.

Consideremos la expresión:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden crearse combinando las clases [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) y [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), junto con las operaciones de la interfaz [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement), de la siguiente forma:
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Métodos Nary e Integral**

- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

Los métodos **Nary** e **Integral** crean y devuelven el operador N‑ario representado por el tipo [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). En el método Nary, la enumeración [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) especifica el tipo de operador—como sumatoria o unión—excluyendo integrales. En el método Integral, se proporciona una operación especializada para integrales, usando la enumeración [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes).

Ejemplo:
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **Método ToMathArray**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) coloca los elementos en un arreglo vertical. Si esta operación se llama sobre una instancia de [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock), todos sus elementos hijos se colocarán en el arreglo devuelto.

Ejemplo:
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Método [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent): establece un signo de acento (un carácter sobre el elemento).
- Métodos [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) y [Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar): colocan una barra sobre o bajo el elemento.
- Método [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group): agrupa usando un carácter de agrupamiento como una llave inferior u otro.
- Método [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox): coloca el elemento dentro de un borde‑caja.
- Método [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox): coloca el elemento en una caja no visual (agrupamiento lógico).

Ejemplos:
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **Preguntas frecuentes**

**¿Cómo puedo añadir una ecuación matemática a una diapositiva de PowerPoint?**

Para añadir una ecuación matemática, debe crear un objeto `MathShape`, que contiene automáticamente una porción matemática. Luego, recupere el `MathParagraph` del `MathPortion` y añada objetos `MathBlock` a él.

**¿Es posible crear expresiones matemáticas complejas y anidadas?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas mediante la anidación de `MathBlock`. Cada elemento matemático implementa la interfaz `IMathElement`, lo que permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, acceda a los `MathBlock` existentes a través del `MathParagraph`. Luego, usando métodos como Join, Divide, Enclose y otros, puede modificar los elementos individuales de la ecuación. Después de la edición, guarde la presentación para aplicar los cambios.