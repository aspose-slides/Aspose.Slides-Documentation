---
title: Añadir ecuaciones matemáticas a presentaciones de PowerPoint en C++
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/cpp/powerpoint-math-equations/
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
- C++
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para C++, compatible con OMML, controles de formato y ejemplos de código C++ claros."
---

## **Visión general**
En PowerPoint es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, diversos símbolos matemáticos están representados en PowerPoint y pueden añadirse al texto o a la ecuación. Para ello se utiliza el constructor de ecuaciones matemáticas de PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones n‑arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para añadir una ecuación matemática en PowerPoint se utiliza el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto generará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente forma:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite numerosos símbolos matemáticos para crear ecuaciones. Sin embargo, crear ecuaciones matemáticas complicadas en PowerPoint a menudo no produce un resultado profesional y estéticamente correcto. Los usuarios que necesitan crear presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas de buen aspecto.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/), puede trabajar con ecuaciones matemáticas en presentaciones de PowerPoint de forma programática en C++. Crear nuevas expresiones matemáticas o editar las creadas previamente. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.

## **Cómo crear una ecuación matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidado. Una colección lineal de elementos matemáticos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/). La clase [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) es esencialmente una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) es una porción matemática, usada para contener texto matemático (no confundir con [**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son la clave para trabajar con ecuaciones matemáticas de PowerPoint mediante la API Aspose.Slides.

Veamos cómo crear la siguiente ecuación matemática mediante la API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero añada una forma que contendrá el texto matemático:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

Después de crearla, la forma ya contiene un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) es una porción que contiene texto matemático interno. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/), consulte la variable [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

La clase [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) permite leer, añadir, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)), que constan de una combinación de elementos matemáticos. Por ejemplo, crear una fracción y colocarla en la presentación:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

Cada elemento matemático está representado por alguna clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Esta interfaz ofrece muchos métodos para crear expresiones matemáticas de forma sencilla. Se puede crear una expresión matemática bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras quedaría así:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) están implementadas en cualquier tipo de elemento, incluido el [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

El ejemplo completo de código fuente:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 

## **Tipos de elementos matemáticos**
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos se representa mediante un bloque matemático, y los argumentos de los elementos forman un anidado tipo árbol.

Existen muchos tipos de elementos matemáticos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) dentro de otro elemento. Es decir, los elementos son contenedores de otros, formando una estructura arbórea. El tipo más simple es aquel que no contiene otros elementos del texto matemático.

Cada tipo de elemento matemático implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), lo que permite usar el conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/) especifica el objeto fracción, compuesto por un numerador y un denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El objeto fracción también se usa para representar la función stack, que coloca un elemento sobre otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) especifica una función de un argumento. Contiene los métodos: [get_Name()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/) – nombre de la función y [get_Base()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/) – argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/) especifica un objeto matemático N‑ario, como Σ o ∫. Consta de un operador, una base (operando) y límites superior e inferior opcionales. Ejemplos de operadores N‑arios son Suma, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma o resta; esos se representan con un solo elemento de texto – [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) crea el límite superior o inferior. Define el objeto límite, compuesto por texto en la línea base y texto reducido justo arriba o abajo de él. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando los elementos [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) y [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) de la siguiente forma:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Las clases siguientes especifican un subíndice inferior o un superíndice superior. Puede establecer subíndice y superíndice simultáneamente a la izquierda o a la derecha de un argumento, pero el subíndice o superíndice único solo se admite a la derecha. El [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/) también puede usarse para establecer el grado matemático de un número.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) especifica el objeto Matriz, compuesto por elementos hijos distribuidos en una o más filas y columnas. Es importante notar que las matrices no incluyen delimitadores incorporados. Para colocar la matriz entre corchetes debe usarse el objeto delimitador – [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/). Se pueden usar argumentos nulos para crear huecos en las matrices.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/) especifica una matriz vertical de ecuaciones o de cualquier objeto matemático.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formato de elementos matemáticos**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/) : dibuja un borde rectangular (u otro) alrededor del [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/) : especifica el empaquetado lógico del elemento matemático. Por ejemplo, un objeto en caja puede servir como emulador de operador con o sin punto de alineación, como punto de ruptura de línea o agruparse para evitar rupturas de línea dentro de él. Por ejemplo, el operador “==” debería estar en caja para impedir rupturas de línea.

- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/) : especifica el objeto delimitador, compuesto por caracteres de apertura y cierre (paréntesis, llaves, corchetes, barras verticales, etc.) y uno o más elementos matemáticos internos, separados por un carácter especificado. Ejemplos: (𝑥2); [𝑥2|𝑦2].  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/) : especifica la función acento, compuesta por una base y un signo diacrítico combinante.  
  Ejemplo: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/) : especifica la función barra, compuesta por un argumento base y una barra superior o inferior.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/) : especifica un símbolo de agrupación encima o debajo de una expresión, normalmente para resaltar relaciones entre elementos.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones matemáticas**
Cada elemento y expresión matemática (a través de [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Permite aplicar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones disponen de dos conjuntos de parámetros: pueden recibir un [**IMathElement**] o una cadena. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) se crean implícitamente a partir de las cadenas cuando se usan argumentos de tipo string. Las operaciones disponibles en Aspose.Slides se enumeran a continuación.

### **Método Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Método Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

Crea una fracción del tipo especificado con este numerador y el denominador indicado. Por ejemplo:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Método Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

Envuelve el elemento en los caracteres especificados, como paréntesis u otro carácter de encuadre.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

Por ejemplo:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Método Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

Toma una función de un argumento usando el objeto actual como nombre de la función.

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

Por ejemplo:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **Método AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

Toma la función especificada usando la instancia actual como argumento. Puede:

- especificar una cadena como nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsofoneargument/) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsoftwoarguments/), por ejemplo **MathFunctionsOfOneArgument.ArcSin**.
- pasar una instancia de [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).

Por ejemplo:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

Establece subíndice y superíndice. Puede establecer ambos simultáneamente a la izquierda o a la derecha del argumento, pero el subíndice o superíndice único solo se admite a la derecha. El **Superscript** también puede usarse para fijar el grado matemático de un número.

Ejemplo:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Método Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

Especifica la raíz matemática del grado indicado a partir del argumento especificado.

Ejemplo:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

Define el límite superior o inferior. Aquí, “superior” e “inferior” indican simplemente la posición del argumento respecto a la base.

Consideremos la expresión:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Dichas expresiones pueden crearse combinando las clases [MathFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) y [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/), y las operaciones de [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) de la siguiente forma:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Métodos Nary e Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

Ambos métodos **Nary** e **Integral** crean y devuelven el operador N‑ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/). En el método Nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperatortypes/) especifica el tipo de operador: suma, unión, etc., sin incluir integrales. En el método Integral, se usa la enumeración [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathintegraltypes/) para indicar el tipo de integral.

Ejemplo:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **Método ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) coloca los elementos en una matriz vertical. Si se llama a esta operación para una instancia de **MathBlock**, todos los elementos hijos se colocarán en la matriz devuelta.

Ejemplo:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **Operaciones de formato: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent** : establece un acento (un carácter sobre el elemento).  
- **Overbar** y **Underbar** : añaden una barra sobre o bajo el elemento.  
- **Group** : agrupa usando un carácter de agrupación, como una llave inferior u otro.  
- **ToBorderBox** : coloca un borde alrededor del elemento.  
- **ToBox** : coloca el elemento en una caja lógica no visual.

Ejemplos:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **Preguntas frecuentes**

**¿Cómo puedo añadir una ecuación matemática a una diapositiva de PowerPoint?**

Para añadir una ecuación matemática, debe crear un objeto de forma matemática, que contiene automáticamente una porción matemática. Luego, recupere el [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) de la [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) y añada objetos [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) a él.

**¿Es posible crear expresiones matemáticas complejas con anidamiento?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas mediante el anidamiento de MathBlocks. Cada elemento matemático implementa la interfaz [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), lo que permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, acceda a los MathBlocks existentes a través del [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Luego, usando métodos como Join, Divide, Enclose, entre otros, modifique los elementos individuales de la ecuación. Después de editar, guarde la presentación para aplicar los cambios.