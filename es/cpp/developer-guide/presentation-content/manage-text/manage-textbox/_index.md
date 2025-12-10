---
title: Administrar cuadros de texto en presentaciones usando C++
linktitle: Administrar cuadro de texto
type: docs
weight: 20
url: /es/cpp/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- agregar texto
- actualizar texto
- crear cuadro de texto
- verificar cuadro de texto
- agregar columna de texto
- agregar hipervínculo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ facilita la creación, edición y clonación de cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---

Los textos en diapositivas normalmente existen en cuadros de texto o formas. Por lo tanto, para añadir texto a una diapositiva, debes agregar un cuadro de texto y luego colocar algún texto dentro del cuadro. Aspose.Slides for C++ proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) que permite añadir una forma que contiene texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides también ofrece la interfaz [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) que permite añadir formas a las diapositivas. Sin embargo, no todas las formas añadidas a través de la interfaz `IShape` pueden contener texto. Pero las formas añadidas mediante la interfaz [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) pueden contener texto. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Por lo tanto, cuando trabajes con una forma a la que deseas añadir texto, quizás quieras comprobar y confirmar que se ha convertido mediante la interfaz `IAutoShape`. Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), que es una propiedad de `IAutoShape`. Consulta la sección [Actualizar texto](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) en esta página. 

{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. Obtén una referencia a la primera diapositiva de la presentación recién creada. 
3. Añade un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) con [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) establecido como `Rectangle` en una posición especificada de la diapositiva y obtén la referencia al objeto `IAutoShape` recién añadido. 
4. Añade la propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, añadimos este texto: *Aspose TextBox* 
5. Finalmente, escribe el archivo PPTX mediante el objeto `Presentation`. 

Este código C++—una implementación de los pasos anteriores—muestra cómo añadir texto a una diapositiva:
```cpp
// Instancia la presentación
auto pres = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva de la presentación
auto sld = pres->get_Slides()->idx_get(0);

// Añade una AutoShape con tipo establecido como Rectángulo
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Añade TextFrame al rectángulo
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


## **Comprobar si una forma es un cuadro de texto**

Aspose.Slides proporciona el método [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) de la interfaz [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) que permite examinar formas e identificar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código C++ muestra cómo comprobar si una forma se creó como cuadro de texto: 
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```


Ten en cuenta que si simplemente añades una autoforma mediante el método `AddAutoShape` de la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/), el método `get_IsTextBox` de la autoforma devolverá `false`. Sin embargo, después de añadir texto a la autoforma mediante el método `AddTextFrame` o el método `set_Text`, el método `get_IsTextBox` devolverá `true`.
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() devuelve false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() devuelve true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() devuelve false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() devuelve true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() devuelve false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() devuelve false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() devuelve false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() devuelve false
```


## **Añadir columnas a un cuadro de texto**

Aspose.Slides proporciona los métodos [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) y [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) y la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) que permiten añadir columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y definir el espaciado en puntos entre columnas. 

Este código C++ demuestra la operación descrita: 
```cpp
auto presentation = System::MakeObject<Presentation>();
// Obtiene la primera diapositiva de la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// Añade una AutoShape con el tipo establecido como Rectángulo
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Añade TextFrame al rectángulo
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Obtiene el formato de texto del TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Especifica el número de columnas en el TextFrame
format->set_ColumnCount(3);

// Especifica el espaciado entre columnas
format->set_ColumnSpacing(10);

// Guarda la presentación
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Añadir columnas a un marco de texto**

Aspose.Slides for C++ proporciona el método [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) que permite añadir columnas en marcos de texto. Mediante este método, puedes especificar el número de columnas que deseas en un marco de texto. 

Este código C++ muestra cómo añadir una columna dentro de un marco de texto:
```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
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


## **Actualizar texto**

Aspose.Slides permite cambiar o actualizar el texto contenido en un cuadro de texto o todo el texto contenido en una presentación. 

Este código C++ demuestra una operación en la que todo el texto de una presentación se actualiza o cambia:
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
                    // Cambia el texto
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    // Cambia el formato
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

// Guarda la presentación modificada
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```


## **Añadir un cuadro de texto con hipervínculo** 

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

 Para añadir un cuadro de texto que contenga un enlace, sigue estos pasos:

1. Crea una instancia de la clase `Presentation`. 
2. Obtén una referencia a la primera diapositiva de la presentación recién creada. 
3. Añade un objeto `AutoShape` con `ShapeType` establecido como `Rectangle` en una posición especificada de la diapositiva y obtén una referencia al objeto `AutoShape` recién añadido. 
4. Añade un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como texto predeterminado. 
5. Instancia la clase `IHyperlinkManager`. 
6. Asigna el objeto `IHyperlinkManager` al método [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) asociado con la porción preferida del `TextFrame`. 
7. Finalmente, escribe el archivo PPTX mediante el objeto `Presentation`. 

Este código C++—una implementación de los pasos anteriores—muestra cómo añadir un cuadro de texto con hipervínculo a una diapositiva:
```cpp
// Instancia una clase Presentation que representa un PPTX
// Obtiene la primera diapositiva de la presentación
// Añade un objeto AutoShape con el tipo establecido como Rectangle
// Convierte la forma a AutoShape
// Accede a la propiedad ITextFrame asociada con el AutoShape
// Añade algo de texto al marco
// Establece el hipervínculo para el texto de la porción
// Guarda la presentación PPTX
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

auto autoShape = System::ExplicitCast<IAutoShape>(shape);

autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [placeholder](/slides/es/cpp/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) y puede sobrescribirse en los [layouts](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva específica y no cambia al cambiar de layout.

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin afectar el texto dentro de gráficos, tablas y SmartArt?**

Limita tu iteración a autoformas que tengan marcos de texto y excluye los objetos incrustados ([charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) recorriendo sus colecciones por separado o omitiendo esos tipos de objetos.