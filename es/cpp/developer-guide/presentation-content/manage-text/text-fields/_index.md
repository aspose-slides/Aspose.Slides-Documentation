---
title: Gestionar campos de texto en presentaciones de PowerPoint en C++
linktitle: Campos de texto
type: docs
weight: 52
url: /es/cpp/text-fields/
keywords:
- campo de texto
- texto automático
- número de diapositiva
- fecha y hora
- encabezado
- pie de página
- porción de texto
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para C++. Preservar el formato y comprobar los archivos PPTX y PPT guardados."
---
## **Visión general**

Un párrafo de texto se compone de fragmentos. Un [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/) ordinario contiene texto literal; un fragmento de campo también tiene un [IField](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifield/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos fragmentos pueden mostrar los mismos caracteres mientras solo uno contiene un campo.

Utilice [IPortion::get_Field](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/get_field/) para distinguirlos: devuelve `nullptr` para texto ordinario. [IPortion::AddField](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/addfield/) convierte un fragmento existente en un campo. Mantenga una etiqueta y su valor dinámico en fragmentos separados para que la conversión del valor no reemplace también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y su guardado en PPTX y PPT. Para marcos de texto y párrafos, consulte [Manage Text](/slides/es/cpp/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de añadir el campo, luego vuelve a abrir la presentación guardada y comprueba el tipo de campo, el texto y el formato. No se requiere archivo de entrada.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto esperado es `Slide 1`, y ambas comprobaciones deberían imprimir `True`. El número sigue siendo un campo después de volver a abrirla; no es un literal `1`. La conversión y los índices en la verificación se refieren a la forma y a los fragmentos creados por este ejemplo.

## **Elegir un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifieldtype/) y proporciona los siguientes valores predefinidos. Pase el valor apropiado a [AddField](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/addfield/).

| Accesor | Propósito |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_slidenumber/) | El número de diapositiva actual. |
| [get_DateTime](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_datetime/) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [get_DateTime1](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_datetime9/) | Formatos de fecha o combinaciones de fecha/hora predefinidos. |
| [get_DateTime10](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_datetime13/) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [get_Header](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_header/) | Un campo de encabezado; consulte las limitaciones de marcadores y formatos a continuación. |
| [get_Footer](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_footer/) | Un campo de pie de página. |

Por ejemplo, [get_DateTime3](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/get_datetime3/) proporciona el día, el nombre completo del mes y el año en inglés. Estos son formatos de campo predefinidos, no cadenas de formato de fecha arbitrarias. El idioma del fragmento, establecido con [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_languageid/), y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [AddField](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/addfield/) acepta un identificador interno de campo. Úsela cuando necesite conservar un identificador suministrado por otra aplicación que no tiene un valor predefinido. También puede construir un [FieldType](https://reference.aspose.com/slides/es/cpp/aspose.slides/fieldtype/fieldtype/) a partir del identificador. [IFieldType::get_InternalString](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifieldtype/get_internalstring/) expone ese identificador para su inspección.

Este ejemplo almacena un campo específico de aplicación `custom-report-id` con el texto de reserva `Report-042`. No se requiere archivo de entrada. El identificador no registra ningún cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que entienda este identificador debe proporcionar su significado y actualizar su valor.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Después de este viaje de ida y vuelta en PPTX, el tipo esperado es `custom-report-id` y el texto esperado es `Report-042`. Pasar una cadena como `yyyy-MM-dd` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, use texto ordinario.

## **Examinar, modificar y eliminar campos de fecha/hora**

Lea un tipo de campo existente a través de [IField::get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifield/get_type/) y cámbielo mediante [IField::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifield/set_type/). Verifique que el campo exista antes de acceder a su tipo. Para detener las actualizaciones automáticas, llame a [IPortion::RemoveField](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/removefield/). Esto mantiene el fragmento y su texto actual mientras elimina la asociación del campo. Si necesita un valor fijo específico, asigne ese texto después de eliminar el campo.

Para la configuración de API asociada al procesamiento de campos de fecha/hora, consulte [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/set_currentdatetime/). El ejemplo siguiente utiliza una fecha de aprobación explícita al convertir un campo a texto ordinario.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, además de etiquetas de texto ordinario. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas habituales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, preservando su otro formato. Solo los campos en `ApprovedDate` se convierten en texto fijo.

La muestra reconoce los identificadores internos incorporados `datetime` y `datetime1` a `datetime13`. Los grupos, tablas, notas, diseños y maestros requieren recorrer sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Después de volver a abrir, `UpdatedAt` debería tener el tipo `datetime3` y seguir siendo dinámico. `ApprovedDate` no debería tener campo y contener `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, configuración de negrita y color permanecen intactos. Las etiquetas de texto ordinario no se modifican. La verificación lee la primera porción de las dos formas conocidas en la muestra proporcionada.

## **Preservar el formato del texto**

Trabaje con el fragmento existente al añadir un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato del fragmento. Use [IPortion::get_PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/get_portionformat/) para cambiar solo las propiedades necesarias, como hacen los ejemplos para color o cursiva.

Evite reconstruir todo un marco de texto solo para actualizar un campo: hacerlo puede perder los límites originales de los fragmentos y su formato individual. Además, distinga el formato establecido explícitamente del heredado del párrafo, diseño o tema. Consulte [Text Formatting](/slides/es/cpp/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo forma parte de un fragmento de texto. Un marcador de posición es una forma con un rol de presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los gestores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores en diapositivas, diseños y maestros, incluida la propagación a diapositivas dependientes. Un campo numérico en un cuadro de texto personalizado puede ser útil incluso cuando no se utiliza el marcador de número de diapositiva. Por el contrario, cambiar la visibilidad del marcador no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores correspondientes ni suministran su contenido. En particular, una diapositiva estándar de PowerPoint no tiene marcador de encabezado; los encabezados pertenecen a páginas de notas y folletos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un gestor de marcadores. Para ese flujo de trabajo, consulte [Presentation Headers and Footers](/slides/es/cpp/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Compruebe tanto el tipo de campo como el texto resultante después de guardar y volver a abrir. Conservar un identificador no prueba que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento del campo y limitaciones |
|---|---|
| PPTX | Almacena identificadores internos de campo junto con el texto del campo. Use los ejemplos anteriores para comprobar tipos predefinidos e identificadores personalizados después de guardar y volver a abrir. Un tipo personalizado desconocido no adquiere lógica de cálculo automática. Otra aplicación puede tratar los identificadores no compatibles de forma distinta. |
| PPT | Utiliza representaciones de campo heredadas y tiene una compatibilidad más limitada. Los campos de número de diapositiva y los campos de fecha/hora predefinidos tienen representaciones heredadas. Los campos personalizados no compatibles o los campos de encabezado en un cuadro de texto ordinario pueden producir `*` como su texto. No confíe en que los campos personalizados o contextos de campo no compatibles conserven su texto visible. |

Para obtener una salida portátil y fija, convierta los campos no compatibles a texto ordinario y asigne explícitamente el valor que desea antes de guardar. Esto conserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **FAQ**

**¿Cómo puedo saber si un número o fecha mostrados son un campo?**  
Inspeccione [IPortion::get_Field](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/get_field/). Un valor no nulo identifica un campo; el texto mostrado por sí solo no lo indica.

**¿Eliminar un campo elimina su texto o formato?**  
No. [RemoveField](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/removefield/) convierte el fragmento existente en texto ordinario. Asigne un valor explícito después si necesita una fecha congelada o un texto de reserva.

**¿Una cadena interna puede definir un nuevo formato de fecha o fórmula?**  
No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha. Use un tipo predefinido compatible o formatee el valor usted mismo como texto ordinario.

**¿Por qué comprobar la presentación nuevamente después de guardarla?**  
Los identificadores de campo, el texto calculado y el formato son cosas distintas que verificar. La conversión de formato puede cambiar el resultado visible aun cuando el identificador del campo siga presente.