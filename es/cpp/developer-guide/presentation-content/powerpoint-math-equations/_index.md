---
title: Agregar ecuaciones matemáticas a presentaciones de PowerPoint en С++
linktitle: Ecuaciones matemáticas de PowerPoint
type: docs
weight: 80
url: /es/cpp/powerpoint-math-equations/
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
- С++
- Aspose.Slides
description: "Insertar y editar ecuaciones matemáticas en PowerPoint PPT y PPTX con Aspose.Slides para С++, con soporte para OMML, controles de formato y claros ejemplos de código en С++."
---

## **Visión general**
En PowerPoint es posible escribir una ecuación o fórmula matemática y mostrarla en la presentación. Para ello, varios símbolos matemáticos están representados en PowerPoint y pueden añadirse al texto o a la ecuación. Para ello se utiliza el constructor de ecuaciones matemáticas en PowerPoint, que ayuda a crear fórmulas complejas como:

- Fracción matemática
- Radical matemático
- Función matemática
- Límites y funciones logarítmicas
- Operaciones N-arias
- Matriz
- Operadores grandes
- Funciones seno, coseno

Para agregar una ecuación matemática en PowerPoint, se usa el menú *Insertar -> Ecuación*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Esto creará un texto matemático en XML que puede mostrarse en PowerPoint de la siguiente forma:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint admite numerosos símbolos matemáticos para crear ecuaciones. Sin embargo, crear ecuaciones complejas en PowerPoint a menudo no produce un resultado profesional. Los usuarios que necesiten crear presentaciones matemáticas con frecuencia recurren a soluciones de terceros para obtener fórmulas con buen aspecto.

Usando [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/), puedes trabajar con ecuaciones matemáticas en presentaciones de PowerPoint de forma programática en C++. Crear nuevas expresiones matemáticas o editar las ya creadas. La exportación de estructuras matemáticas a imágenes también está parcialmente soportada.

## **Cómo crear una ecuación matemática**
Los elementos matemáticos se utilizan para construir cualquier construcción matemática con cualquier nivel de anidamiento. Una colección lineal de elementos forma un bloque matemático representado por la clase [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block). La clase [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) es esencialmente una expresión, fórmula o ecuación matemática separada. [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) es una porción matemática, usada para contener texto matemático (no confundir con [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) permite manipular un conjunto de bloques matemáticos. Las clases mencionadas son la clave para trabajar con ecuaciones matemáticas de PowerPoint mediante la API Aspose.Slides.

Veamos cómo crear la siguiente ecuación matemática mediante la API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Para añadir una expresión matemática en la diapositiva, primero agrega una forma que contenga el texto matemático:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

Después de crearla, la forma ya contendrá un párrafo con una porción matemática por defecto. La clase [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) es una porción que contiene texto matemático dentro. Para acceder al contenido matemático dentro de [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion), consulta la variable [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

La clase [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) permite leer, agregar, editar y eliminar bloques matemáticos ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), que consisten en una combinación de elementos matemáticos. Por ejemplo, crear una fracción y colocarla en la presentación:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

Cada elemento matemático está representado por una clase que implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Esta interfaz ofrece muchos métodos para crear expresiones matemáticas fácilmente. Puedes crear una expresión bastante compleja con una sola línea de código. Por ejemplo, el teorema de Pitágoras quedaría así:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

Las operaciones de la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) están implementadas en cualquier tipo de elemento, incluido [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

Código fuente completo:

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
Las expresiones matemáticas se forman a partir de secuencias de elementos matemáticos. La secuencia de elementos está representada por un bloque matemático, y los argumentos de los elementos forman un anidamiento tipo árbol.

Existen muchos tipos de elementos que pueden usarse para construir un bloque matemático. Cada uno de estos elementos puede incluirse (agregarse) en otro elemento. Es decir, los elementos son contenedores de otros, formando una estructura en árbol. El tipo más simple de elemento es aquel que no contiene otros elementos del texto matemático.

Cada tipo de elemento implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element), lo que permite usar el conjunto común de operaciones matemáticas sobre diferentes tipos de elementos.

### **Clase MathematicalText**
La clase [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) representa un texto matemático, el elemento subyacente de todas las construcciones matemáticas. El texto matemático puede representar operandos y operadores, variables y cualquier otro texto lineal.

Ejemplo: 𝑎=𝑏+𝑐

### **Clase MathFraction**
La clase [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) especifica el objeto fracción, compuesto por numerador y denominador separados por una barra de fracción. La barra puede ser horizontal o diagonal, según las propiedades de la fracción. El mismo objeto también se usa para representar la función de apilamiento, que coloca un elemento sobre otro sin barra de fracción.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Clase MathRadical**
La clase [**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) especifica la función radical (raíz matemática), compuesta por una base y un grado opcional.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Clase MathFunction**
La clase [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) especifica una función de un argumento. Contiene los métodos: [get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) – nombre de la función y [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) – argumento de la función.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Clase MathNaryOperator**
La clase [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) especifica un objeto matemático N-ario, como Sumatorio o Integral. Consiste en un operador, una base (u operando) y límites superiores e inferiores opcionales. Ejemplos de operadores N-arios son Sumatorio, Unión, Intersección, Integral.

Esta clase no incluye operadores simples como suma o resta; éstos se representan con un solo elemento de texto – [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Clase MathLimit**
La clase [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) crea el límite superior o inferior. Especifica el objeto límite, compuesto por texto en la línea base y texto de tamaño reducido justo encima o debajo. Este elemento no incluye la palabra “lim”, pero permite colocar texto en la parte superior o inferior de la expresión. Así, la expresión  

![todo:image_alt_text](powerpoint-math-equations_8.png)

se crea combinando [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) y [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) de la siguiente manera:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **Clases MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

Las siguientes clases especifican un subíndice o un superíndice. Puedes establecer subíndice y superíndice al mismo tiempo a la izquierda o a la derecha de un argumento, pero solo se admite un subíndice o superíndice simple en el lado derecho. La clase [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) también puede usarse para establecer el grado matemático de un número.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Clase MathMatrix**
La clase [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) especifica el objeto Matriz, compuesto por elementos hijos dispuestos en una o más filas y columnas. Es importante notar que las matrices no tienen delimitadores incorporados. Para colocar la matriz entre corchetes se debe usar el objeto delimitador – [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). Los argumentos nulos pueden usarse para crear espacios en blanco en matrices.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Clase MathArray**
La clase [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) especifica una matriz vertical de ecuaciones o cualquier objeto matemático.

Ejemplo:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formateo de elementos matemáticos**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box) dibuja un borde rectangular u otro alrededor del [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box) especifica el empaquetado lógico del elemento matemático. Por ejemplo, un objeto en caja puede servir como emulador de operador con o sin punto de alineación, como punto de ruptura de línea, o agruparse para evitar quiebres de línea internos. Por ejemplo, el operador "==" debe enmarcarse para evitar quiebres de línea.

- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter) especifica el objeto delimitador, compuesto por caracteres de apertura y cierre (paréntesis, llaves, corchetes, barras verticales) y uno o más elementos dentro, separados por un carácter especificado. Ejemplos: (𝑥²); [𝑥²|𝑦²].  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent) especifica la función de acento, compuesta por una base y una marca diacrítica combinada.  
  Ejemplo: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar) especifica la función de barra, compuesta por un argumento base y una barra superior o inferior.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character) especifica un símbolo de agrupación sobre o bajo una expresión, generalmente para resaltar relaciones entre elementos.  
  Ejemplo: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Operaciones matemáticas**
Cada elemento y expresión matemática (mediante [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) implementa la interfaz [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Permite usar operaciones sobre la estructura existente y formar expresiones más complejas. Todas las operaciones tienen dos conjuntos de parámetros: ya sea [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) o cadena como argumentos. Las instancias de la clase [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) se crean implícitamente a partir de cadenas cuando se usan argumentos de tipo cadena. Las operaciones matemáticas disponibles en Aspose.Slides se enumeran a continuación.

### **Método Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Une un elemento matemático y forma un bloque matemático. Por ejemplo:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Método Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

Crea una fracción del tipo especificado con este numerador y el denominador indicado. Por ejemplo:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Método Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Envuelve el elemento en caracteres especificados, como paréntesis u otro carácter de marco.

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
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

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
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Toma la función especificada usando la instancia actual como argumento. Puedes:

- especificar una cadena como nombre de la función, por ejemplo “cos”.
- seleccionar uno de los valores predefinidos de las enumeraciones [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) o [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b), por ejemplo **MathFunctionsOfOneArgument.ArcSin**.
- seleccionar la instancia de la [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

Por ejemplo:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 

### **Métodos SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

Establece subíndice y superíndice. Puedes establecer ambos simultáneamente a la izquierda o a la derecha del argumento, pero solo se admite un subíndice o superíndice individual en el lado derecho. El **Superscript** también puede usarse para establecer el grado matemático de un número.

Ejemplo:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Método Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Especifica la raíz matemática del grado dado a partir del argumento especificado.

Ejemplo:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **Métodos SetUpperLimit y SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Establece el límite superior o inferior. Aquí, el superior e inferior indican simplemente la posición del argumento respecto a la base.

Consideremos la expresión:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Tales expresiones pueden crearse combinando las clases [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) y [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit), y las operaciones de la [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) de la siguiente forma:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Métodos Nary e Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

Los métodos **Nary** y **Integral** crean y devuelven el operador N-ario representado por el tipo [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). En el método Nary, la enumeración [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) especifica el tipo de operador: sumatoria, unión, etc., sin incluir integrales. En el método Integral, la enumeración [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607) define los tipos de integral.

Ejemplo:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **Método ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) coloca los elementos en una matriz vertical. Si esta operación se llama para una instancia de **MathBlock**, todos los elementos hijos se colocarán en la matriz resultante.

Ejemplo:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **Operaciones de formateo: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent** establece una marca de acento (un carácter sobre el elemento).  
- **Overbar** y **Underbar** establecen una barra superior o inferior.  
- **Group** coloca en un grupo usando un carácter de agrupación como una llave inferior u otro.  
- **ToBorderBox** coloca en un cuadro con borde.  
- **ToBox** coloca en un cuadro no visual (agrupación lógica).

Ejemplos:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **Preguntas frecuentes**

**¿Cómo puedo agregar una ecuación matemática a una diapositiva de PowerPoint?**

Para agregar una ecuación matemática, debes crear un objeto de forma matemática, que contiene automáticamente una porción matemática. Luego, obtienes el [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) de la [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) y agregas objetos [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) a él.

**¿Es posible crear expresiones matemáticas complejas anidadas?**

Sí, Aspose.Slides permite crear expresiones matemáticas complejas mediante la anidación de MathBlocks. Cada elemento matemático implementa la interfaz [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), lo que permite aplicar operaciones (Join, Divide, Enclose, etc.) para combinar elementos en estructuras más complejas.

**¿Cómo puedo actualizar o modificar una ecuación matemática existente?**

Para actualizar una ecuación, debes acceder a los MathBlocks existentes a través del [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Luego, usando métodos como Join, Divide, Enclose, entre otros, puedes modificar los elementos individuales de la ecuación. Después de editar, guarda la presentación para aplicar los cambios.