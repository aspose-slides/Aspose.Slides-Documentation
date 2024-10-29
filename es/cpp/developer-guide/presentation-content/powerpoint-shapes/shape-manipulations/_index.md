---
title: Manipulaciones de Formas
type: docs
weight: 40
url: /es/cpp/shape-manipulations/
---

## **Encontrar Forma en Diapositiva**
Este tema describirá una técnica simple para facilitar a los desarrolladores encontrar una forma específica en una diapositiva sin utilizar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no tienen forma de identificar formas en una diapositiva excepto por un Id único interno. Parece ser difícil para los desarrolladores encontrar una forma usando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún texto alternativo. Sugerimos a los desarrolladores que utilicen texto alternativo para encontrar una forma específica. Puedes usar MS PowerPoint para definir el texto alternativo para objetos que planeas cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puedes abrir esa presentación usando Aspose.Slides para C++ e iterar a través de todas las formas añadidas a una diapositiva. Durante cada iteración, puedes verificar el texto alternativo de la forma y la forma con el texto alternativo coincidente sería la forma requerida por ti. Para demostrar esta técnica de una mejor manera, hemos creado un método, [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) que hace el truco para encontrar una forma específica en una diapositiva y luego simplemente devuelve esa forma.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Clonar Forma**
Para clonar una forma en una diapositiva usando Aspose.Slides para C++:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Accede a la colección de formas de la diapositiva fuente.
1. Agrega una nueva diapositiva a la presentación.
1. Clona las formas de la colección de formas de la diapositiva fuente a la nueva diapositiva.
1. Guarda la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Eliminar Forma**
Aspose.Slides para C++ permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, sigue los pasos a continuación:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Accede a la primera diapositiva.
1. Encuentra la forma con texto alternativo específico.
1. Elimina la forma.
1. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Ocultar Forma**
Aspose.Slides para C++ permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, sigue los pasos a continuación:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Accede a la primera diapositiva.
1. Encuentra la forma con texto alternativo específico.
1. Oculta la forma.
1. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Cambiar Orden de Forma**
Aspose.Slides para C++ permite a los desarrolladores reordenar las formas. Reordenar la forma especifica qué forma está al frente o qué forma está atrás. Para reordenar la forma de cualquier diapositiva, sigue los pasos a continuación:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Accede a la primera diapositiva.
1. Agrega una forma.
1. Agrega algo de texto en el marco de texto de la forma.
1. Agrega otra forma con las mismas coordenadas.
1. Reordena las formas.
1. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Obtener ID de Forma Interoperable**
Aspose.Slides para C++ permite a los desarrolladores obtener un identificador único de forma en el ámbito de la diapositiva en contraste con la propiedad UniqueId, que permite obtener un identificador único en el ámbito de la presentación. La propiedad OfficeInteropShapeId fue añadida a las interfaces IShape y a la clase Shape respectivamente. El valor devuelto por la propiedad OfficeInteropShapeId corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se proporciona un código de ejemplo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Establecer Propiedad AlternativeText**
Aspose.Slides para C++ permite a los desarrolladores establecer AlternateText de cualquier forma. Para establecer el AlternateText de una forma, sigue los pasos a continuación:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Accede a la primera diapositiva.
1. Agrega cualquier forma a la diapositiva.
1. Realiza algún trabajo con la forma recién añadida.
1. Recorre las formas para encontrar una forma.
1. Establece el AlternativeText.
1. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Acceder a Formatos de Diseño para Forma**
Aspose.Slides para C++ permite a los desarrolladores acceder a formatos de diseño para una forma. Este artículo demuestra cómo puedes acceder a las propiedades **FillFormat** y **LineFormat** para una forma.

A continuación se proporciona un código de ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Renderizar Forma como SVG**
Ahora Aspose.Slides para C++ soporta la renderización de una forma como svg. El método WriteAsSvg (y su sobrecarga) ha sido añadido a la clase Shape y a la interfaz IShape. Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de la diapositiva a un archivo SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Alineación de Formas**
Aspose.Slides permite alinear formas ya sea en relación con los márgenes de la diapositiva o entre sí. Para este propósito, se ha añadido un método sobrecargado [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) define las posibles opciones de alineación.

**Ejemplo 1**

El código fuente a continuación alinea las formas con índices 1, 2 y 4 a lo largo del borde superior de la diapositiva. 

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Ejemplo 2**

El ejemplo a continuación muestra cómo alinear toda la colección de formas en relación con la forma en la parte inferior de la colección.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```