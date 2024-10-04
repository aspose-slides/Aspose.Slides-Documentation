---
title: Ecuaciones Matemáticas de PowerPoint
type: docs
weight: 80
url: /net/powerpoint-math-equations/
keywords: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos de PowerPoint, Fórmula de PowerPoint, Texto Matemático de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Ecuaciones Matemáticas de PowerPoint, Símbolos Matemáticos, Fórmulas y Texto Matemático en C# o .NET"
---

## **Descripción General**
En PowerPoint, es posible escribir una ecuación matemática o fórmula y mostrarla en la presentación. Para hacer eso, varios símbolos matemáticos están representados en PowerPoint y se pueden agregar al texto o ecuación. Para eso, se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción Matemática
- Radical Matemático
- Función Matemática
- Límites y funciones logarítmicas
- Operaciones N-arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para agregar una ecuación matemática en PowerPoint, se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que se puede mostrar en PowerPoint de la siguiente manera:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint soporta muchos símbolos matemáticos para crear ecuaciones matemáticas. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no da un resultado bueno y profesional. Los usuarios, que necesitan crear presentaciones matemáticas con frecuencia, recurren al uso de soluciones de terceros para crear fórmulas matemáticas atractivas.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/net/), puedes trabajar con ecuaciones matemáticas en presentaciones de PowerPoint programáticamente en C#. Crea nuevas expresiones matemáticas o edita las previamente creadas. La exportación de estructuras matemáticas a imágenes también es parcialmente compatible.


## **Cómo Crear una Ecuación Matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). La clase [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) es esencialmente una expresión matemática separada, fórmula o ecuación. [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) es una porción matemática, utilizada para contener texto matemático (no mezclar con [**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion)). [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son clave para trabajar con ecuaciones matemáticas de PowerPoint a través de Aspose.Slides API.

Veamos cómo podemos crear la siguiente ecuación matemática a través de Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para agregar una expresión matemática en la diapositiva, primero, agrega una forma que contendrá el texto matemático:

``` csharp
 using (Presentation pres = new Presentation())
{
    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```

Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) es una porción que contiene un texto matemático dentro. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), referirse a la variable [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):

``` csharp
 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```

La clase [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) permite leer, agregar, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crea una fracción y colócala en la presentación:

``` csharp
 var fraction = new MathematicalText("x").Divide("y");
mathParagraph.Add(new MathBlock(fraction));
```

Cada elemento matemático está representado por alguna clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). Esta interfaz proporciona muchos métodos para crear expresiones matemáticas fácilmente. Puedes crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras se vería así:

``` csharp
 var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) se implementan en cualquier tipo de elemento, incluyendo el [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

El código fuente completo de muestra:

``` csharp
 using (Presentation pres = new Presentation())
{
    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
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
    pres.Save("math.pptx", SaveFormat.Pptx);
}
```

## **Tipos de Elementos Matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos matemáticos está representada por un bloque matemático, y los argumentos de los elementos matemáticos forman una nesting similar a un árbol.

Hay muchos tipos de elementos matemáticos que se pueden usar para construir un bloque matemático. Cada uno de estos elementos puede ser incluido (agregado) en otro elemento. Es decir, los elementos son en realidad contenedores de otros, formando una estructura similar a un árbol. El tipo más simple de elemento no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), permitiendo el uso de un conjunto común de operaciones matemáticas en diferentes tipos de elementos matemáticos.
### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) representa un texto matemático - el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables, y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐
### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) especifica el objeto fracción, que consiste en un numerador y un denominador separados por una barra de fracción. La barra de fracción puede ser horizontal o diagonal, dependiendo de las propiedades de la fracción. El objeto fracción también se utiliza para representar la función de pila, que coloca un elemento sobre otro, sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) especifica la función radical (raíz matemática), que consiste en una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) especifica una función de un argumento. Contiene propiedades: [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - nombre de la función y [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) especifica un objeto matemático N-ario, como Suma e Integral. Consiste en un operador, una base (o operando), y límites superiores e inferiores opcionales. Ejemplos de operadores N-arios son Suma, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma, resta, etc. Estos están representados por un solo elemento de texto - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) crea el límite superior o inferior. Especifica el objeto límite, que consiste en texto en la línea base y texto de tamaño reducido inmediatamente encima o debajo de él. Este elemento no incluye la palabra "lim", pero permite colocar texto en la parte superior o en la parte inferior de la expresión. Así, la expresión 

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea utilizando una combinación de los elementos [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) y [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) de esta manera:

``` csharp
 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Las siguientes clases especifican un índice inferior o un índice superior. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o en el derecho de un argumento, pero el único subíndice o superíndice es soportado solo en el lado derecho. El [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) también se puede usar para establecer el grado matemático de un número.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) especifica el objeto Matriz, que consiste en elementos secundarios dispuestos en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para colocar la matriz en los corchetes, debes usar el objeto delimitador - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Los argumentos nulos se pueden usar para crear huecos en matrices.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) especifica un arreglo vertical de ecuaciones u otros objetos matemáticos.

Ejemplo: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formateo de Elementos Matemáticos**
- La clase [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): dibuja un borde rectangular u otro alrededor del [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- La clase [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): especifica el enmarcado lógico (empaquetado) del elemento matemático. Por ejemplo, un objeto enmarcado puede servir como un emulador de operador con o sin un punto de alineación, servir como un punto de ruptura de línea, o agruparse de tal manera que no permita quiebres de línea dentro. Por ejemplo, el operador "==" debe estar enmarcado para evitar quiebres de línea.
- La clase [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): especifica el objeto delimitador, que consiste en caracteres de apertura y cierre (como paréntesis, llaves, corchetes y barras verticales), y uno o más elementos matemáticos dentro, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- La clase [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): especifica la función de acento, que consiste en una base y una marca diacrítica combinada. 

  Ejemplo: 𝑎́.

- La clase [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): especifica la función de barra, que consiste en un argumento base y una barra superior o inferior.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- La clase [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): especifica un símbolo de agrupamiento por encima o por debajo de una expresión, generalmente para resaltar las relaciones entre elementos.
  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Operaciones Matemáticas**
Cada elemento matemático y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Esto permite usar operaciones sobre la estructura existente y formar expresiones matemáticas más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) o string como argumentos. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) se crean implícitamente a partir de cadenas especificadas cuando se utilizan argumentos de cadena. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.
### **Método Join**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

``` csharp
 IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");
IMathBlock block = element1.Join(element2);
```
### **Método Divide**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Crea una fracción del tipo especificado con este numerador y denominador especificado. Por ejemplo:

``` csharp
 IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```
### **Método Enclose**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/methods/1)

Encierra el elemento en caracteres especificados como paréntesis u otro carácter como enmarcado.

``` csharp
 /// <summary>
/// Enclosa un elemento matemático en paréntesis
/// </summary>
IMathDelimiter Enclose();

/// <summary>
/// Enclosa este elemento en caracteres especificados como paréntesis u otros caracteres como enmarcado
/// </summary>
IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);
```

Por ejemplo:

``` csharp
 IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```
### **Método Function**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Toma una función de un argumento usando el objeto actual como el nombre de la función.

``` csharp
 /// <summary>
/// Toma una función de un argumento usando esta instancia como el nombre de la función
/// </summary>
/// <param name="functionArgument">Un argumento de la función</param>
IMathFunction Function(IMathElement functionArgument);
IMathFunction Function(string functionArgument);
```

Por ejemplo:

``` csharp
 IMathFunction func = new MathematicalText("sin").Function("x");
```
### **Método AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Toma la función especificada usando la instancia actual como el argumento. Puedes:

- especificar una cadena como el nombre de la función, por ejemplo "cos".
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), por ejemplo **MathFunctionsOfOneArgument.ArcSin.**
- seleccionar la instancia del [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

Por ejemplo:

``` csharp
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

Establece subíndice y superíndice. Puedes establecer subíndice y superíndice al mismo tiempo en el lado izquierdo o en el derecho de un argumento, pero el único subíndice o superíndice es soportado solo en el lado derecho. El **Superíndice** también se puede usar para establecer el grado matemático de un número.

Ejemplo:

``` csharp
 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```
### **Método Radical**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Especifica la raíz matemática del grado dado a partir del argumento especificado.

Ejemplo:

``` csharp
 var radical = new MathematicalText("x").Radical("3");
```
### **Métodos SetUpperLimit y SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Toma el límite superior o inferior. Aquí, la parte superior e inferior simplemente indican la ubicación del argumento en relación con la base.

Consideremos una expresión: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones se pueden crear a través de una combinación de las clases [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) y [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), y operaciones de [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) de la siguiente manera:

``` csharp
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

Tanto el método **Nary** como el **Integral** crean y devuelven el operador N-ario representado por el tipo [**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). En el método Nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) especifica el tipo de operador: suma, unión, etc., excluyendo integrales. En el método Integral, hay la operación especializada Integral con la enumeración de tipos de integral [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes). 

Ejemplo:

``` csharp
 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```
### **Método ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) coloca elementos en un arreglo vertical. Si esta operación se llama para una instancia de **MathBlock**, todos los elementos secundarios se colocarán en el arreglo devuelto.

Ejemplo:

``` csharp
 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```
### **Operaciones de Formateo: Acento, Barra Superior, Barra Inferior, Agrupamiento, ToBorderBox, ToBox**
- El método [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) establece una marca de acento (un carácter en la parte superior del elemento).
- Los métodos [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) y [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) establecen una barra en la parte superior o inferior.
- El método [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) coloca en un grupo usando un carácter de agrupamiento como una llave inferior o otra.
- El método [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) coloca en un borde.
- El método [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) coloca en una caja no visual (agrupamiento lógico).

Ejemplos:

``` csharp
 var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```