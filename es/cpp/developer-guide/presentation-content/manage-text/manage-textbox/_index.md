---
title: Administrar TextBox
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords: "Textbox, Marco de texto, Agregar textbox, Textbox con hipervínculo, C++, Aspose.Slides for C++"
description: "Agregar un textbox o marco de texto a las presentaciones de PowerPoint en C++"
---

Los textos en las diapositivas generalmente existen en cuadros de texto o formas. Por lo tanto, para agregar un texto a una diapositiva, tienes que agregar un cuadro de texto y luego poner algún texto dentro del textbox. Aspose.Slides for C++ proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) que te permite agregar una forma que contenga algún texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides también proporciona la interfaz [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) que te permite agregar formas a las diapositivas. Sin embargo, no todas las formas agregadas a través de la interfaz `IShape` pueden contener texto. Pero las formas agregadas a través de la interfaz [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) pueden contener texto.

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Por lo tanto, al tratar con una forma a la que deseas agregar texto, es posible que desees comprobar y confirmar que se haya convertido a través de la interfaz `IAutoShape`. Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), que es una propiedad bajo `IAutoShape`. Consulta la sección [Actualizar Texto](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear Cuadro de Texto en Diapositiva**

Para crear un textbox en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén una referencia para la primera diapositiva en la presentación recién creada.
3. Agrega un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) con [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) establecido como `Rectangle` en una posición especificada en la diapositiva y obtiene la referencia al objeto `IAutoShape` recién agregado.
4. Agrega una propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, agregamos este texto: *Aspose TextBox*
5. Finalmente, guarda el archivo PPTX a través del objeto `Presentation`.

Este código C++—una implementación de los pasos anteriores—te muestra cómo agregar texto a una diapositiva:

```cpp
// Instancia Presentation
auto pres = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva en la presentación
auto sld = pres->get_Slides()->idx_get(0);

// Agrega un AutoShape con tipo establecido como Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Agrega TextFrame al Rectangle
ashp->AddTextFrame(u" ");

// Accede al marco de texto
auto txtFrame = ashp->get_TextFrame();

// Crea el objeto Paragraph para el marco de texto
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Crea un objeto Portion para el párrafo
auto portion = para->get_Portions()->idx_get(0);

// Establece el texto
portion->set_Text(u"Aspose TextBox");

// Guarda la presentación en disco
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Verificar si es una Forma de Cuadro de Texto**

Aspose.Slides proporciona el método [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (de la clase [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/)) que te permite examinar formas y encontrar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código C++ te muestra cómo verificar si una forma fue creada como un cuadro de texto:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"la forma es un cuadro de texto") : System::String(u"la forma no es un cuadro de texto"));
        }
    }
}
```

## **Agregar Columna en Cuadro de Texto**

Aspose.Slides proporciona los métodos [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) y [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) y la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) que te permiten agregar columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y establecer la cantidad de espaciado en puntos entre columnas.

Este código en C++ demuestra la operación descrita:

```cpp
auto presentation = System::MakeObject<Presentation>();
// Obtiene la primera diapositiva en la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// Agrega un AutoShape con tipo establecido como Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Agrega TextFrame al Rectangle
aShape->AddTextFrame(String(u"Todas estas columnas están limitadas a estar dentro de un solo contenedor de texto -- ") 
    + u"puedes agregar o eliminar texto y el nuevo o restante texto se ajusta automáticamente " 
    + u"para fluir dentro del contenedor. ¡No puedes hacer que el texto fluya de un contenedor " 
    + u"a otro, ya que te dijimos que las opciones de columnas de PowerPoint para texto son limitadas!");

// Obtiene el formato de texto de TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Especifica el número de columnas en TextFrame
format->set_ColumnCount(3);

// Especifica el espaciado entre columnas
format->set_ColumnSpacing(10);

// Guarda la presentación
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Agregar Columna en Marco de Texto**
Aspose.Slides for C++ proporciona el método [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) que te permite agregar columnas en marcos de texto. A través de este método, puedes especificar tu número preferido de columnas en un marco de texto.

Este código C++ te muestra cómo agregar una columna dentro de un marco de texto:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"Todas estas columnas están obligadas a permanecer dentro de un solo contenedor de texto -- ") 
    + u"puedes agregar o eliminar texto - y el nuevo o restante texto se ajusta automáticamente " 
    + u"para permanecer dentro del contenedor. No puedes hacer que el texto se desborde de un contenedor " 
    + u"a otro, ya que las opciones de columnas de PowerPoint para texto son limitadas!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Actualizar Texto**

Aspose.Slides te permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación.

Este código C++ demuestra una operación donde todos los textos en una presentación se actualizan o cambian:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Cambia el texto
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Cambia el formato
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Guarda la presentación modificada
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Agregar Cuadro de Texto con Hipervínculo** 

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace.

 Para agregar un cuadro de texto que contenga un enlace, sigue estos pasos:

1. Crea una instancia de la clase `Presentation`. 
2. Obtén una referencia para la primera diapositiva en la presentación recién creada. 
3. Agrega un objeto `AutoShape` con `ShapeType` establecido como `Rectangle` en una posición especificada en la diapositiva y obtiene una referencia del objeto AutoShape recién agregado.
4. Agrega un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como su texto predeterminado. 
5. Instancia la clase `IHyperlinkManager`. 
6. Asigna el objeto `IHyperlinkManager` al método [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) asociado con tu porción preferida del `TextFrame`. 
7. Finalmente, guarda el archivo PPTX a través del objeto `Presentation`. 

Este código C++—una implementación de los pasos anteriores—te muestra cómo agregar un cuadro de texto con un hipervínculo a una diapositiva:

```cpp
// Instancia una clase Presentation que representa un PPTX
auto presentation = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva en la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// Agrega un objeto AutoShape con tipo establecido como Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Convierte la forma a AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Accede a la propiedad ITextFrame asociada con el AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Agrega algo de texto al marco
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Establece el hipervínculo para el texto de la porción
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Guarda la presentación PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```