---
title: Gestionar campos de texto en presentaciones de PowerPoint en .NET
linktitle: Campos de texto
type: docs
weight: 52
url: /es/net/text-fields/
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
- C#
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para .NET. Conservar el formato y verificar los archivos PPTX y PPT guardados."
---
## **Visión general**

Un párrafo de texto consta de porciones. Una [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/) ordinaria contiene texto literal; una porción de campo también tiene un [IField](https://reference.aspose.com/slides/es/net/aspose.slides/ifield/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos porciones pueden mostrar los mismos caracteres aunque solo una contenga un campo.

Utilice [IPortion.Field](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/field/) para distinguirlas: es `null` para texto ordinario. [IPortion.AddField](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/addfield/) convierte una porción existente en un campo. Mantenga una etiqueta y su valor dinámico en porciones separadas para que al convertir el valor no se reemplace también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y su guardado en PPTX y PPT. Para marcos de texto y párrafos, consulte [Manage Text](/slides/es/net/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo completo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de añadir el campo, luego reabre la presentación guardada y verifica el tipo de campo, el texto y el formato. No se requiere ningún archivo de entrada.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto es `Slide 1`, y ambas verificaciones imprimen `True`. El número sigue siendo un campo después de volver a abrirla; no es un literal `1`. Los casts e índices en la verificación hacen referencia a la forma y a las porciones creadas por este ejemplo.

## **Seleccionar un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/es/net/aspose.slides/ifieldtype/) y proporciona los siguientes valores predefinidos. Pase el valor apropiado a [AddField](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/addfield/).

| Valor | Propósito |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/slidenumber/) | El número de diapositiva actual. |
| [DateTime](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/datetime/) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [DateTime1](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/datetime9/) | Formatos de fecha predefinidos o combinados de fecha/hora. |
| [DateTime10](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/datetime13/) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [Header](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/header/) | Un campo de encabezado; vea las limitaciones de marcador de posición y formato a continuación. |
| [Footer](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/footer/) | Un campo de pie de página. |

Por ejemplo, [DateTime3](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/datetime3/) representa un día, el nombre completo del mes y el año en inglés. Estos son formatos de campo predefinidos, no cadenas de formato de fecha arbitrarias de .NET. El [LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/languageid/) de la porción y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [AddField](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/addfield/) acepta un identificador de campo interno. Úsela cuando preserve un identificador proporcionado por otra aplicación que no tiene un valor predefinido. También puede construir un [FieldType](https://reference.aspose.com/slides/es/net/aspose.slides/fieldtype/fieldtype/) a partir del identificador. [IFieldType.InternalString](https://reference.aspose.com/slides/es/net/aspose.slides/ifieldtype/internalstring/) expone ese identificador para inspección.

Este ejemplo almacena un campo específico de la aplicación `custom-report-id` con el texto de respaldo `Report-042`. El identificador no registra un cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que entiende este identificador debe proporcionar su significado y actualizar su valor.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Después de este viaje de ida y vuelta en PPTX, el tipo es `custom-report-id` y el texto es `Report-042`. Pasar una cadena como `yyyy-MM-dd` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, use texto ordinario.

## **Inspeccionar, modificar y eliminar campos de fecha/hora**

Lea y cambie un campo existente a través de [IField.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ifield/type/). Verifique que el campo exista antes de acceder a su tipo. Para detener las actualizaciones automáticas, llame a [IPortion.RemoveField](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/removefield/). Esto conserva la porción y su texto actual mientras elimina la asociación del campo. Si necesita un valor fijo específico, asigne ese texto después de eliminar el campo.

Para la configuración de API asociada al procesamiento de campos de fecha/hora, vea [Presentation.CurrentDateTime](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/currentdatetime/). El ejemplo a continuación utiliza una fecha de aprobación explícita al convertir un campo a texto ordinario.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, además de etiquetas de texto ordinario. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas normales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, preservando su otro formato. Solo los campos en `ApprovedDate` se convierten en texto fijo.

El ejemplo reconoce los identificadores internos incorporados `datetime` y `datetime1` hasta `datetime13`. Los grupos, tablas, notas, diseños y patrones requieren el recorrido de sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Después de volver a abrir, `UpdatedAt` tiene el tipo `datetime3` y sigue siendo dinámico. `ApprovedDate` no tiene campo y contiene `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, configuración de negrita y color permanecen intactos. Las etiquetas de texto ordinario no se modifican. La verificación lee la primera porción de las dos formas conocidas en el ejemplo suministrado.

## **Conservar el formato de texto**

Trabaje con la porción existente al añadir un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato de esa porción. Utilice [IPortion.PortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/portionformat/) para cambiar solo las propiedades necesarias, como hacen los ejemplos para el color o la cursiva.

Evite reconstruir todo un marco de texto solo para actualizar un campo: hacerlo puede perder los límites originales de la porción y su formato individual. Además, distinga el formato establecido explícitamente del formato heredado del párrafo, diseño o tema. Consulte [Text Formatting](/slides/es/net/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo es parte de una porción de texto. Un marcador de posición es una forma con un rol en la presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los gestores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores de posición en diapositivas, diseños y patrones, incluida la propagación a diapositivas dependientes. Un campo numérico en un cuadro de texto personalizado puede ser útil incluso cuando no se usa el marcador de posición del número de diapositiva. Por el contrario, cambiar la visibilidad del marcador de posición no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores de posición correspondientes ni proporcionan su contenido. En particular, una diapositiva de PowerPoint estándar no tiene marcador de posición de encabezado; los encabezados pertenecen a las páginas de notas y folletos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un gestor de marcadores de posición. Para ese flujo de trabajo, consulte [Presentation Headers and Footers](/slides/es/net/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Compruebe tanto el tipo de campo como el texto resultante después de guardar y volver a abrir. Conservar un identificador no prueba que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento del campo y limitaciones |
|---|---|
| PPTX | Almacena los identificadores internos del campo junto con el texto del campo. En las comprobaciones de ida y vuelta, los tipos predefinidos y el identificador personalizado usado arriba sobrevivieron al guardado y la reapertura. El tipo personalizado desconocido conservó su texto de respaldo; no adquirió lógica de cálculo automático. Otra aplicación puede tratar los identificadores no compatibles de forma diferente. |
| PPT | Utiliza representaciones de campo heredadas y tiene una compatibilidad más limitada. En las comprobaciones de ida y vuelta, los campos de número de diapositiva y los campos de fecha/hora predefinidos sobrevivieron al guardado y la reapertura. Un campo personalizado en un cuadro de texto de diapositiva ordinario se reabrió con su identificador pero con `*` como texto; un campo de encabezado en el mismo contexto también produjo `*`. No confíe en que los campos personalizados o contextos de campo no soportados conserven su texto visible. |

Para una salida portable y fija, convierta los campos no compatibles a texto ordinario y asigne explícitamente el valor que desee antes de guardar. Esto conserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **FAQ**

**¿Cómo puedo saber si un número o fecha mostrado es un campo?**

Inspeccione [IPortion.Field](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/field/). Un valor distinto de null identifica un campo; el texto mostrado por sí solo no puede indicarlo.

**¿Eliminar un campo elimina su texto o formato?**

No. [RemoveField](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/removefield/) convierte la porción existente en texto ordinario. Asigne un valor explícito después si necesita una fecha congelada o un valor de respaldo concreto.

**¿Puede una cadena interna definir un nuevo formato de fecha o fórmula?**

No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha de .NET. Use un tipo predefinido soportado o formatee el valor usted mismo como texto ordinario.

**¿Por qué comprobar una presentación nuevamente después de guardarla?**

Los identificadores de campo, el texto calculado y el formato son cosas distintas a verificar. La conversión de formato puede cambiar el resultado visible incluso cuando el identificador del campo sigue presente.