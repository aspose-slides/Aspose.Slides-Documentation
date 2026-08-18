---
title: Gestionar temas de presentación en Java
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Color del tema
- Paleta adicional
- Fuente del tema
- Estilo del tema
- Efecto del tema
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Temas maestros de presentación en Aspose.Slides para Java para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos con conciencia de tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, por lo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un maestro puede anular el tema de la presentación mediante [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/masterthememanager/), mientras que una disposición o una diapositiva individual puede anular su tema heredado mediante [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo para una diapositiva se resuelve mediante esta cadena de herencia: tema de la presentación, anulación del maestro, anulación de la disposición y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más comunes: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar los estilos de fondo y de efecto, y leer los valores efectivos después de que la herencia y las anulaciones se hayan resuelto.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/) expone el esquema de colores, el esquema de fuentes y el esquema de formato del tema a través de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/) y [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan estar presentes anulaciones de disposición o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos con conciencia de tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/schemecolor/). Cuando cambias la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/icolorscheme/), todos los objetos que aún hacen referencia a ese color del tema se resuelven con el nuevo valor. Los objetos que usan un color RGB directo no se modifican con una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que utiliza `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Como el rectángulo sigue vinculado a `Accent4`, su color visible se vuelve rojo después de cambiar el tema. Si sustituyes el color de esquema por un color directo en la forma, los cambios posteriores a `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/es/java/com.aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y más oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.

**2** - Variantes más claras y más oscuras producidas a partir de los colores principales del tema.

El siguiente ejemplo crea seis rectángulos basados en `Accent4`, aplica transformaciones de luminancia a cinco de ellos y guarda el resultado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Estas variantes siguen basadas en el color del tema. Si `Accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear valores `SchemeColor` a ranuras `IColorScheme`**

El enumerado [SchemeColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que el [IColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se convierten dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para los encabezados y un conjunto de fuentes secundario para el texto del cuerpo. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/) y [IFontScheme.getMinor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Fuente Latin menor)
* `+mj-lt` - Fuente del encabezado Latin (Fuente Latin mayor)
* `+mn-ea` - Fuente del cuerpo Este Asiático (Fuente Este Asiático menor)
* `+mj-ea` - Fuente del encabezado Este Asiático (Fuente Este Asiático mayor)

El siguiente ejemplo crea un encabezado que utiliza la fuente Latin mayor del tema y una línea de cuerpo que utiliza la fuente Latin menor del tema. Luego cambia las fuentes del tema y guarda el resultado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

{{% alert color="info" title="Tip" %}}
Para obtener más información sobre fuentes de presentación, consulte [PowerPoint Fonts](/slides/es/java/powerpoint-fonts/).
{{% /alert %}}

## **Copiar o aplicar un tema**

Existen dos flujos de trabajo comunes, y resuelven problemas diferentes.

### **Conservar un tema origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro origen en la presentación de destino con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/), luego clone la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/) y el maestro clonado. Esto lleva el maestro, sus disposiciones y el tema asociado juntos.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Este es el flujo de trabajo preferido cuando la diapositiva origen debe verse igual en el destino. Simplemente clonar contenido sobre un maestro de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su maestro y disposición actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/) y [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/) copian los tres componentes principales del tema en la anulación.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/).

### **Aplicar una anulación de tema a una disposición**

Una anulación a nivel de disposición se aplica a las diapositivas que utilizan esa disposición, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través de [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Utilice un tema a nivel de maestro o de presentación cuando muchas disposiciones y diapositivas deben compartir el mismo diseño base, una anulación de disposición cuando una familia de disposiciones necesita un estilo diferente, y una anulación de diapositiva solo para excepciones reales. Un exceso de anulaciones a nivel de diapositiva hace que los cambios globales posteriores del tema sean más difíciles de predecir.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/). PowerPoint puede presentar más opciones de fondo en su interfaz que el número de definiciones de relleno almacenadas físicamente en esta colección, ya que la interfaz puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.getStyleIndex](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/) actual. Un índice de estilo de `0` significa que no hay relleno temático; los valores positivos son referencias de estilo de fondo del tema. Esto difiere de indexar directamente la colección Java, donde `get_Item(0)` representa el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el recuento de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer maestro y guarda la presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado visible depende de la entrada de tema referenciada por el maestro y de cualquier anulación de fondo a nivel de disposición o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Use [Background.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/) cuando necesite conocer el fondo final después de aplicada la herencia.

{{% alert color="warning" title="Warning" %}}
No trate el índice de estilo como un índice de colección basado en cero. Además, evite codificar de forma rígida un número de estilo de un archivo y suponer que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de la presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para el formato directo de fondos y la herencia de fondos, consulte [Presentation Background](/slides/es/java/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato de tema contiene colecciones separadas de estilos de relleno, línea y efecto expuestas mediante [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/) y [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/). Los temas típicos de Office suelen contener tres entradas principales de estilo que corresponden visualmente a formatos sutiles, moderados e intensos, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutiles, moderados e intensos aplicados a la misma forma](presentation-design_10.png)

Cuando accede a estas colecciones en Java, el índice de la colección comienza en cero: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapestyle/). Modificar un estilo del tema afecta a las formas que referencian ese estilo del tema; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existan las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra externa en el tercer estilo de efecto y guarda el resultado:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para las formas que referencian estas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido, y el tercer estilo de efecto obtiene una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y si el formato directo anula el tema.

![Estilos de efecto del tema después de cambiar la línea, el relleno y la configuración de sombra](presentation-design_11.png)

## **Leer valores efectivos del tema**

Los objetos de tema sin procesar le indican lo que está definido en un nivel concreto. Los valores efectivos le indican lo que una diapositiva o forma usa realmente después de que la herencia y las anulaciones locales se resuelvan. Para una diapositiva, llame a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseoverridethememanager/). Para un fondo, use [Background.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/), y para un relleno, use [FillFormat.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/fillformat/).

El siguiente ejemplo lee el tema efectivo, el fondo y el relleno de la primera forma de una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Utilice datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/), puede pasar por alto una anulación de maestro, disposición, diapositiva o forma que cambie la apariencia final.

## **FAQ**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Use el [SlideThemeManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia original, clone el maestro origen en el destino y clone la diapositiva con ese maestro usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/) y [ISlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/). Esto mantiene el maestro, las disposiciones y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseoverridethememanager/) para un tema de diapositiva o disposición y los métodos de datos efectivos correspondientes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/) y [FillFormat.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/fillformat/). Estas API devuelven los valores resueltos después de aplicar la herencia y las anulaciones.