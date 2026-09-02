---
title: Obtener propiedades efectivas de forma en presentaciones Java
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- sistema de iluminación
- forma con bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a usar Aspose.Slides para Java para distinguir el formato local, heredado y efectivo de formas en presentaciones de PowerPoint."
---
## **Entender las Propiedades Locales, Heredadas y Efectivas**

El formato de PowerPoint puede proceder de varios lugares. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está establecido, PowerPoint busca fuentes de formato superiores, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o los valores predeterminados a nivel de la presentación. Esos valores son **valores heredados**. El valor que queda después de que se resuelve toda la jerarquía es el **valor efectivo**—el valor utilizado para renderizar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su valor local [getFontHeight](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) es entonces `Float.NaN`, que significa "no establecido aquí". La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación u otra fuente aplicable. Llamar a [getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportionformat/#getEffective--) en el formato de la porción devuelve la altura final resuelta.

Utilice los dos tipos de datos de formato para diferentes propósitos:

- Lea o modifique un objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportionformat/), cuando necesite controlar dónde se define un valor.
- Lea un objeto de datos efectivo, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportionformateffectivedata/), cuando necesite el resultado final renderizado. Los datos efectivos son de solo lectura.

## **Comparar Valores Locales, Heredados y Efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso muestra los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También demuestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Definir valores heredados en dos niveles diferentes.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Un valor local en la porción sobrescribe ambos valores heredados.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Cambiar un valor heredado no sobrescribe un valor local existente.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Borrar el valor local. La porción vuelve a heredar del párrafo.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Borrar el valor del párrafo. Ahora el valor predeterminado de la presentación proporciona el resultado.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Leer los datos efectivos después de los cambios anteriores.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

La prioridad en este ejemplo es el formato local de la porción, luego el formato del párrafo y después el valor predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico prevalece, y [getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportionformat/#getEffective--) devuelve el resultado final.

## **Obtener Propiedades de Texto Efectivas**

El formato de texto se divide entre varios objetos:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframeformat/#getEffective--) resuelve propiedades del marco de texto, como márgenes, anclaje, ajuste automático y dirección vertical del texto.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextstyle/#getEffective--) resuelve el formato de párrafo para cada nivel de estilo de texto.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#getEffective--) resuelve propiedades del párrafo, como alineación, sangría y viñetas.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportionformat/#getEffective--) resuelve propiedades de carácter como altura de fuente, tipografía, color, negrita e itálica.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una [AutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/autoshape/) con un marco de texto no vacío. La AutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Obtener Propiedades 3D Efectivas**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/es/java/com.aspose.slides/ithreedformat/#getEffective--) devuelve un objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ithreedformateffectivedata/) que agrupa todos los ajustes 3D resueltos. Sus métodos [getCamera](https://reference.aspose.com/slides/es/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/es/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/es/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), y [getBevelBottom](https://reference.aspose.com/slides/es/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) exponen los datos efectivos correspondientes. Leer estos ajustes relacionados a la vez facilita comprender la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique ajustes de cámara 3D, iluminación o bisel a esa forma si desea que la salida contenga valores diferentes a los predeterminados.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Obtener Formato de Tabla Efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, a una columna, a una fila o a una celda individual. En caso de conflictos entre rellenos definidos explícitamente, la prioridad es celda, fila, columna y luego toda la tabla. El formato efectivo de una celda es el formato final usado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca una [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/itable/) en lugar de asumir que `getShapes().get_Item(0)` es una tabla.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Si necesita el color en lugar de solo el tipo de relleno, primero compruebe el [getFillType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) efectivo, y luego lea el método que se aplica a ese tipo—por ejemplo, [getSolidFillColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) para un relleno sólido.

## **Volver a leer los datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a `getEffective` de nuevo después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluyendo:

- el formato local del objeto;
- los valores predeterminados de párrafo o marco de texto;
- un estilo de tabla, tabla, columna, fila o formato de celda;
- el formato de diseño o de diapositiva maestra;
- los datos del tema o los valores predeterminados a nivel de presentación;
- el diseño o la maestra asignados a una diapositiva.

No mantenga un objeto de datos efectivo como una instantánea permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a `getEffective` puede actualizar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite—como la altura de fuente, color, alineación o ancho del bisel—en sus propias variables antes de efectuar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y luego llame a `getEffective` para verificar el resultado. Los objetos de datos efectivos son de solo lectura.

## **FAQ**

**¿Cómo puedo saber qué nivel proporcionó un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para texto, esto puede incluir la porción, párrafo, marco de texto, diseño, maestra, tema y valores predeterminados de la presentación. Los valores indefinidos como `Float.NaN` o `null` indican que la búsqueda continúa en otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado apropiado de PowerPoint o de la biblioteca. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo defina explícitamente.

**¿Por qué a veces un valor efectivo es igual al valor local?**

El valor local ganó el cálculo de herencia. Esto es esperado cuando la propiedad está establecida explícitamente en el objeto y ninguna regla más específica la sobrescribe.

**¿Cuándo debería usar datos locales en lugar de datos efectivos?**

Utilice datos locales para inspeccionar o editar un nivel de formato específico. Utilice datos efectivos cuando necesite la apariencia final después de que la herencia, las reglas del tema y los estilos aplicables se hayan resuelto. El [ejemplo completo de comparación](#compare-local-inherited-and-effective-values) muestra ambos en el mismo flujo de trabajo.