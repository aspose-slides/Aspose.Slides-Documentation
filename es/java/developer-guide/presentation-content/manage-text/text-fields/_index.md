---
title: Gestionar campos de texto en presentaciones de PowerPoint en Java
linktitle: Campos de texto
type: docs
weight: 52
url: /es/java/text-fields/
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
- Java
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para Java. Conservar el formato y verificar los archivos PPTX y PPT guardados."
---
## **Descripción general**

Un párrafo de texto se compone de porciones. Una [IPortion](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/) ordinaria contiene texto literal; una porción de campo también tiene un [IField](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifield/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos porciones pueden mostrar los mismos caracteres mientras que sólo una contiene un campo.

Utilice [IPortion.getField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#getField--) para distinguirlas: es `null` para texto ordinario. [IPortion.addField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) convierte una porción existente en un campo. Mantenga una etiqueta y su valor dinámico en porciones separadas para que la conversión del valor no reemplace también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y su guardado en PPTX y PPT. Para marcos de texto y párrafos, consulte [Manage Text](/slides/es/java/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo completo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de agregar el campo, luego vuelve a abrir la presentación guardada y verifica el tipo de campo, el texto y el formato. No se requiere archivo de entrada.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto es `Slide 1`, y ambas comprobaciones imprimen `true`. El número sigue siendo un campo después de volver a abrir; no es un literal `1`. Los cast y los índices en la verificación se refieren a la forma y a las porciones creadas por este ejemplo.

## **Elegir un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifieldtype/) y proporciona los siguientes métodos para obtener valores predefinidos. Pase el valor apropiado a [addField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getSlideNumber--) | El número actual de diapositiva. |
| [getDateTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getDateTime--) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [getDateTime1](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getDateTime9--) | Formatos de fecha o combinaciones de fecha/hora predefinidos. |
| [getDateTime10](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getDateTime13--) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getHeader--) | Un campo de encabezado; vea las limitaciones de marcador de posición y formato a continuación. |
| [getFooter](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getFooter--) | Un campo de pie de página. |

Por ejemplo, [getDateTime3](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#getDateTime3--) representa un día, el nombre completo del mes y el año en inglés. Estos son formatos de campo predefinidos, no cadenas arbitrarias de formato de fecha de Java. El idioma establecido con [setLanguageId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [addField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#addField-java.lang.String-) acepta un identificador interno de campo. Úselo cuando quiera preservar un identificador suministrado por otra aplicación que no tiene un valor predefinido. También puede construir un [FieldType](https://reference.aspose.com/slides/es/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) a partir del identificador. [IFieldType.getInternalString](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifieldtype/#getInternalString--) expone ese identificador para inspección.

Este ejemplo almacena un campo específico de la aplicación `custom-report-id` con el texto de reserva `Report-042`. El identificador no registra un cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que comprende este identificador debe proporcionar su significado y actualizar su valor.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Después de este viaje de ida y vuelta en PPTX, el tipo es `custom-report-id` y el texto es `Report-042`. Pasar una cadena como `yyyy-MM-dd` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, use texto ordinario.

## **Inspeccionar, modificar y eliminar campos de fecha/hora**

Cambie un campo existente mediante [IField.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Verifique que el campo exista antes de acceder a su tipo. Para detener las actualizaciones automáticas, llame a [IPortion.removeField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#removeField--). Esto conserva la porción y su texto actual mientras elimina la asociación del campo. Si necesita un valor fijo específico, asigne ese texto después de eliminar el campo.

Para la configuración de API asociada al procesamiento de campos de fecha/hora, vea [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). El ejemplo a continuación usa una fecha de aprobación explícita al convertir un campo a texto ordinario.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, además de etiquetas de texto ordinarias. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas normales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, conservando su otro formato. Sólo los campos en `ApprovedDate` se convierten en texto fijado.

Los identificadores internos incorporados `datetime` y `datetime1` a través de `datetime13` son reconocidos por la muestra. Grupos, tablas, notas, diseños y maestros requieren recorrer sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Después de volver a abrir, `UpdatedAt` tiene el tipo `datetime3` y sigue siendo dinámico. `ApprovedDate` no tiene campo y contiene `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, configuración de negrita y color permanecen intactos. Las etiquetas de texto ordinarias no cambian. La verificación lee la primera porción de las dos formas conocidas en la muestra suministrada.

## **Conservar el formato de texto**

Trabaje con la porción existente al agregar un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato de esa porción. Use [IPortion.getPortionFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#getPortionFormat--) para cambiar sólo las propiedades requeridas, como hacen los ejemplos para color o cursiva.

Evite reconstruir todo un marco de texto solo para actualizar un campo: hacerlo puede perder los límites originales de las porciones y su formato individual. Distinga también entre el formato establecido explícitamente y el heredado del párrafo, diseño o tema. Consulte [Text Formatting](/slides/es/java/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo es parte de una porción de texto. Un marcador de posición es una forma con un rol en la presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los gestores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores en diapositivas, diseños y maestros, incluida la propagación a diapositivas dependientes. Un campo numérico en un cuadro de texto personalizado puede ser útil incluso cuando no se utiliza el marcador de posición de número de diapositiva. Por el contrario, cambiar la visibilidad de un marcador no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores de posición correspondientes ni suministran su contenido. En particular, una diapositiva de PowerPoint normal no tiene marcador de posición de encabezado; los encabezados pertenecen a páginas de notas y folletos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un gestor de marcadores de posición. Para ese flujo, vea [Presentation Headers and Footers](/slides/es/java/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Verifique tanto el tipo de campo como el texto resultante después de guardar y volver a abrir. Conservar un identificador no prueba que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento del campo y limitaciones |
|---|---|
| PPTX | Almacena los identificadores internos de campo junto al texto del campo. En las comprobaciones de ida y vuelta, los tipos predefinidos y el identificador personalizado usado arriba sobrevivieron a la guardado y reapertura. El tipo personalizado desconocido mantuvo su texto de reserva; no adquirió lógica de cálculo automática. Otra aplicación puede tratar los identificadores no soportados de forma distinta. |
| PPT | Utiliza representaciones de campo heredadas y tiene compatibilidad más limitada. En las comprobaciones de ida y vuelta, los campos de número de diapositiva y los campos de fecha/hora predefinidos sobrevivieron a la guardado y reapertura. Un campo personalizado en un cuadro de texto ordinario se volvió a abrir con su identificador pero con `*` como texto; un campo de encabezado en el mismo contexto también produjo `*`. No confíe en que los campos personalizados o contextos de campo no soportados conserven su texto visible. |

Para una salida portátil y fija, convierta los campos no soportados a texto ordinario y asigne explícitamente el valor que desea antes de guardar. Esto preserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **Preguntas frecuentes**

**¿Cómo puedo saber si un número o fecha mostrados son un campo?**

Inspeccione [IPortion.getField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#getField--). Un valor distinto de `null` identifica un campo; el texto mostrado por sí solo no lo indica.

**¿Eliminar un campo elimina su texto o formato?**

No. [removeField](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#removeField--) convierte la porción existente en texto ordinario. Asigne un valor explícito después si necesita una fecha congelada o un texto de reserva particular.

**¿Una cadena interna puede definir un nuevo formato de fecha o una fórmula?**

No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha de Java. Use un tipo predefinido compatible o formatee el valor usted mismo como texto ordinario.

**¿Por qué volver a comprobar una presentación después de guardarla?**

Los identificadores de campo, el texto calculado y el formato son aspectos independientes que deben verificarse. La conversión de formato puede cambiar el resultado visible aun cuando el identificador del campo siga presente.