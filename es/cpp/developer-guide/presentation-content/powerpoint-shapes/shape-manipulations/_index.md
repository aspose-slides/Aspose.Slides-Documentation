---
title: Administrar formas de presentación en C++
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/cpp/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de presentación
- Forma en diapositiva
- Buscar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma Interop
- Texto alternativo de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a crear, editar y optimizar formas en Aspose.Slides para C++ y entregar presentaciones de PowerPoint de alto rendimiento."
---

## **Buscar una forma en una diapositiva**
Este tema describirá una técnica simple para facilitar a los desarrolladores la búsqueda de una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no disponen de ninguna forma de identificar las formas en una diapositiva excepto por un Id único interno. Parece ser difícil para los desarrolladores encontrar una forma usando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún Texto alternativo. Sugerimos a los desarrolladores usar texto alternativo para encontrar una forma específica. Puede usar MS PowerPoint para definir el texto alternativo para los objetos que planea cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puede abrir esa presentación usando Aspose.Slides para C++ e iterar a través de todas las formas añadidas a una diapositiva. En cada iteración, puede comprobar el texto alternativo de la forma y la forma con el texto alternativo coincidente será la forma que necesita. Para demostrar esta técnica de una manera mejor, hemos creado un método, [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) que hace el truco para encontrar una forma específica en una diapositiva y luego simplemente devuelve esa forma.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Clonar una forma**
Para clonar una forma en una diapositiva usando Aspose.Slides para C++:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a la colección de formas de la diapositiva origen.
1. Añadir una nueva diapositiva a la presentación.
1. Clonar las formas de la colección de formas de la diapositiva origen a la nueva diapositiva.
1. Guardar la presentación modificada como un archivo PPTX.

El ejemplo a continuación añade una forma de grupo a una diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Eliminar una forma**
Aspose.Slides para C++ permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Acceder a la primera diapositiva.
1. Encontrar la forma con el AlternativeText específico.
1. Eliminar la forma.
1. Guardar el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Ocultar una forma**
Aspose.Slides para C++ permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Acceder a la primera diapositiva.
1. Encontrar la forma con el AlternativeText específico.
1. Ocultar la forma.
1. Guardar el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Cambiar el orden de las formas**
Aspose.Slides para C++ permite a los desarrolladores reordenar las formas. Reordenar la forma especifica cuál forma está al frente y cuál está atrás. Para reordenar la forma en cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Acceder a la primera diapositiva.
1. Añadir una forma.
1. Añadir algo de texto en el marco de texto de la forma.
1. Añadir otra forma con las mismas coordenadas.
1. Reordenar las formas.
1. Guardar el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Obtener el ID de forma Interop**
Aspose.Slides para C++ permite a los desarrolladores obtener un identificador único de forma en el alcance de la diapositiva, en contraste con la propiedad UniqueId, que permite obtener un identificador único en el alcance de la presentación. La propiedad OfficeInteropShapeId se añadió a las interfaces IShape y a la clase Shape respectivamente. El valor devuelto por la propiedad OfficeInteropShapeId corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra el código de ejemplo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Establecer la propiedad AlternativeText**
Aspose.Slides para C++ permite a los desarrolladores establecer el AlternateText de cualquier forma. Para establecer el AlternateText de una forma, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Acceder a la primera diapositiva.
1. Añadir cualquier forma a la diapositiva.
1. Realizar algún trabajo con la forma recién añadida.
1. Recorrer las formas para encontrar una forma.
1. Establecer el AlternativeText.
1. Guardar el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Acceder a los formatos de diseño de una forma**
Aspose.Slides para C++ permite a los desarrolladores acceder a los formatos de diseño de una forma. Este artículo demuestra cómo puede acceder a las propiedades **FillFormat** y **LineFormat** de una forma.

A continuación se muestra el código de ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Renderizar una forma como SVG**
Ahora Aspose.Slides para C++ admite renderizar una forma como SVG. El método WriteAsSvg (y su sobrecarga) se ha añadido a la clase Shape y a la interfaz IShape. Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de la diapositiva a un archivo SVG.
``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **Alineación de formas**
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

El ejemplo a continuación muestra cómo alinear toda la colección de formas en relación con la forma más inferior de la colección.
``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **Propiedades de volteo**

En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) proporciona control sobre el reflejo horizontal y vertical de las formas mediante sus propiedades `flipH` y `flipV`. Ambas propiedades son del tipo [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/), permitiendo valores `True` para indicar un volteo, `False` para no voltear, o `NotDefined` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) con la posición y tamaño actuales de la forma, los valores deseados para `flipH` y `flipV`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) de la forma y guardar la presentación aplica las transformaciones de espejo y las guarda en el archivo de salida.

Supongamos que tenemos un archivo sample.pptx en el que la primera diapositiva contiene una única forma con la configuración de volteo predeterminada, como se muestra a continuación.

![The shape to be flipped](shape_to_be_flipped.png)

El siguiente ejemplo de código obtiene las propiedades de volteo actuales de la forma y la voltea tanto horizontalmente como verticalmente.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Recuperar la propiedad de volteo horizontal de la forma.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Recuperar la propiedad de volteo vertical de la forma.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Voltear horizontalmente.
auto flipV = NullableBool::True; // Voltear horizontalmente.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![The flipped shape](flipped_shape.png)

## **FAQ**

**¿Puedo combinar formas (unir/intersectar/restar) en una diapositiva como en un editor de escritorio?**

No existe una API de operaciones booleanas incorporada. Puede aproximarse construyendo el contorno deseado usted mismo—p. ej., calculando la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)) y creando una nueva forma con ese contorno, opcionalmente eliminando las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre permanezca "en la parte superior"?**

Cambie el orden de inserción/movimiento dentro de la colección de [shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) de la diapositiva. Para obtener resultados predecibles, finalice el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo "bloquear" una forma para evitar que los usuarios la editen en PowerPoint?**

Sí. Establezca [banderas de protección a nivel de forma](/slides/es/cpp/applying-protection-to-presentation/) (p. ej., bloquear selección, movimiento, redimensionado, edición de texto). Si es necesario, refleje las restricciones en la diapositiva maestra o en el diseño. Tenga en cuenta que esto es una protección a nivel de UI, no una característica de seguridad; para una protección más fuerte, combine con restricciones a nivel de archivo como [recomendaciones de solo lectura o contraseñas](/slides/es/cpp/password-protected-presentation/).