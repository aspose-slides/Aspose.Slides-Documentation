---
title: "Gestionar cuadros de texto en presentaciones usando C++"
linktitle: "Gestionar cuadro de texto"
type: docs
weight: 20
url: /es/cpp/manage-textbox/
keywords:
- "cuadro de texto"
- "marco de texto"
- "añadir texto"
- "actualizar texto"
- "crear cuadro de texto"
- "comprobar cuadro de texto"
- "añadir columna de texto"
- "añadir hipervínculo"
- "PowerPoint"
- "presentación"
- "C++"
- "Aspose.Slides"
description: "Crear, identificar, dar formato y actualizar cuadros de texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para C++."
---
## **Introducción**

En Aspose.Slides para C++, el texto de una diapositiva se almacena en marcos de texto que pertenecen a formas. La interfaz [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) representa la forma que más comúnmente contiene texto y expone su texto mediante el método [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Nota" %}}
Todo auto‑shape implementa [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/), pero no todas las formas son auto‑shapes ni admiten un marco de texto. Al procesar una presentación existente, compruebe que una forma implemente [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) antes de acceder a su texto.
{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada un auto‑shape a una diapositiva, añada texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Las coordenadas y dimensiones que se pasan a [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addautoshape/) se miden en puntos. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/addtextframe/) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice el método [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/get_istextbox/) para determinar si un auto‑shape se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto auto‑shapes con texto como auto‑shapes puramente gráficos.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada auto‑shape en una presentación:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Un auto‑shape recién añadido no se considera un cuadro de texto hasta que contenga texto no vacío. Puede suministrar ese texto mediante [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/addtextframe/) o [ITextFrame::set_Text](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/set_text/). Añadir o asignar una cadena vacía hace que [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/get_istextbox/) devuelva `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Las dos primeras comprobaciones devuelven `true`; las dos últimas devuelven `false`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) sin saber qué objeto de presentación lo contiene. Utilice el método [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentshape/) para volver a su forma propietaria [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/).

Para un marco de texto perteneciente a un auto‑shape o a otra forma con texto, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentshape/) devuelve el propietario y [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentcell/) devuelve `nullptr`. Ambos métodos proporcionan una navegación de solo lectura. Compruebe el valor devuelto para `nullptr` antes de acceder a él. Para identificar tanto propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos de SmartArt, consulte [Buscar y reemplazar texto](/slides/es/cpp/search-and-replace-text/).

## **Agregar columnas a un cuadro de texto**

El método [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_columncount/) divide el marco de texto en columnas, mientras que [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_columnspacing/) establece la separación entre columnas en puntos. Ambos pertenecen a [ITextFrameFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/) y pueden invocarse a través del marco de texto de un cuadro de texto existente. El texto se reorganiza entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee la configuración almacenada del archivo de salida:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Extraer texto de columnas individuales**

Utilice [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/splittextbycolumns/) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por columna, en orden de lectura basado en columnas. Un marco de una sola columna produce una matriz con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto sin formato; la formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer texto manteniendo su orden de lectura por columnas.
- Indexar o comparar el contenido de diapositivas con varias columnas.
- Exportar cada columna a un archivo, campo de base de datos u otro destino separado.
- Inspeccionar cómo se redistribuye el texto después de establecer el número de columnas con [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_columncount/) o el espaciado con [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_columnspacing/), o al cambiar la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) actual; no fluye automáticamente el texto entre formas o cuadros de texto separados. La distribución por columnas puede depender de las fuentes disponibles y de otras configuraciones de maquetación, así que asegúrese de que las fuentes necesarias estén disponibles cuando los resultados consistentes sean importantes.

El siguiente ejemplo carga una presentación, encuentra el primer auto‑shape con varias columnas y marco de texto en la primera diapositiva, lee su número de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Actualizar texto**

Para actualizar texto en toda la presentación, recorra las diapositivas y formas, seleccione los auto‑shapes y luego edite sus porciones de texto. Trabajar a nivel de porción le permite cambiar tanto el texto como el formato de los caracteres.

El siguiente ejemplo sustituye cada aparición de `years` por `months` dentro de porciones de texto de auto‑shapes y pone en negrita cada porción afectada:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Este recorrido actualiza el texto solo en auto‑shapes. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere el recorrido de las colecciones propias de esos objetos.

## **Agregar un cuadro de texto con hipervínculo**

Se puede asignar un hipervínculo a una porción de texto específica, de modo que solo ese texto actúe como enlace clicable. Utilice [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/es/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) para asociar la porción a una URL externa.

El siguiente ejemplo crea texto enlazado y lo guarda en una presentación:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [marcador de posición](/slides/es/cpp/manage-placeholder/) puede heredar su posición y formato de una [diapositiva maestra](https://reference.aspose.com/slides/es/cpp/aspose.slides/masterslide/) o una [diapositiva de diseño](https://reference.aspose.com/slides/es/cpp/aspose.slides/layoutslide/). Un cuadro de texto normal es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando el diseño cambia.

**¿Cómo puedo sustituir texto sin modificar el texto en gráficos, tablas o SmartArt?**

Limite el recorrido a las formas que implementen [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/), como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objetos, por lo que no se modifican con ese bucle.