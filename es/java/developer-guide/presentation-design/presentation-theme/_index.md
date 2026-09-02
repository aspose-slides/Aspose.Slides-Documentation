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
description: "Domina los temas de presentación en Aspose.Slides para Java para crear, personalizar y convertir archivos PowerPoint con una marca coherente."  
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, tipografías, estilos de fondo, rellenos, líneas y efectos. Los objetos compatibles con temas hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). Una presentación también puede contener sobrescrituras de tema en niveles inferiores. Un master puede sobres escribir el tema de la presentación mediante [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/masterthememanager/), mientras que una diapositiva o un layout pueden sobrescribir su tema heredado mediante [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de presentación, sobrescritura del master, sobrescritura del layout y sobrescritura de la diapositiva.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de temas más habituales: inspeccionar un tema, cambiar colores y tipografías, copiar o aplicar un tema, actualizar estilos de fondo y efectos, y leer los valores efectivos después de que la herencia y las sobrescrituras se hayan resuelto.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/) expone el esquema de colores, el esquema de tipografías y el esquema de formato del tema mediante [MasterTheme.getColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/) y [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto se almacenan en el tema:

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

Si un archivo usa varios masters, no suponga que cada diapositiva tiene el mismo tema efectivo. Inspeccione el master asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir sobrescrituras en el layout o en la diapositiva.

## **Cambiar los colores del tema**

Los rellenos, líneas y textos compatibles con temas pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/icolorscheme/), todos los objetos que aún hacen referencia a ese color del tema se resuelven con el nuevo valor. Los objetos que usan un color RGB directo no se modifican con una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir e imprime el color de relleno efectivo:

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

Como el rectángulo sigue vinculado a `Accent4`, su color visible se vuelve rojo después de cambiar el tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/es/java/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Colores principales del tema.

**2** – Variantes más claras y más oscuras generadas a partir de los colores principales del tema.

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

### **Mapear valores de `SchemeColor` a ranuras de `IColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` y `Background2`, mientras que el [IColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. El mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar las tipografías del tema**

Un esquema tipográfico del tema contiene un juego tipográfico principal para encabezados y un juego secundario para el texto del cuerpo. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/) y [IFontScheme.getMinor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/) exponen esos conjuntos.

Los identificadores de tipografía compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` – Fuente del cuerpo Latin (Minor Latin Font)
* `+mj-lt` – Fuente del encabezado Latin (Major Latin Font)
* `+mn-ea` – Fuente del cuerpo East Asian (Minor East Asian Font)
* `+mj-ea` – Fuente del encabezado East Asian (Major East Asian Font)

El siguiente ejemplo crea un encabezado que usa la fuente Latin mayor del tema y una línea de cuerpo que usa la fuente Latin menor del tema. Luego cambia las tipografías del tema y guarda el resultado:

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

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. El texto que tenga un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema tipográfico del tema cambie.

Las colecciones mayor y menor también pueden contener asignaciones de tipografías para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, reemplazar o eliminar estas asignaciones, consulte [Script-Specific Theme Fonts](/slides/es/java/script-specific-font-mappings/).

{{% alert color="info" title="Consejo" %}}

Para obtener más información sobre las tipografías de presentación, consulte [PowerPoint Fonts](/slides/es/java/powerpoint-fonts/).

{{% /alert %}}

## **Copiar o aplicar un tema**

Existen dos flujos de trabajo habituales, y resuelven problemas diferentes.

### **Conservar un tema origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el master de origen en la presentación de destino con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/), y luego clone la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/) y el master clonado. De este modo el master, sus layouts y el tema asociado se trasladan juntos.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse idéntica en el destino. Simplemente clonar contenido sobre un master de destino no relacionado puede cambiar los colores, tipografías, fondos y efectos controlados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su master y layout actuales, inicialice una sobrescritura a nivel de diapositiva a partir del tema origen. Los métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/) y [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/) copian los tres componentes principales del tema en la sobrescritura.

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

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la sobrescritura local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/overridetheme/).

### **Aplicar una sobrescritura de tema a un layout**

Una sobrescritura a nivel de layout se aplica a las diapositivas que usan ese layout, salvo que una diapositiva concreta tenga su propia sobrescritura. Los mismos métodos de inicialización pueden usarse a través de [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/layoutslidethememanager/):

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

Utilice un tema a nivel de master o presentación cuando muchos layouts y diapositivas deben compartir el mismo diseño base, una sobrescritura de layout cuando una familia de layouts necesita una estética diferente, y una sobrescritura de diapositiva solo para excepciones reales. Un exceso de sobrescrituras a nivel de diapositiva dificulta predecir los cambios globales posteriores del tema.

## **Actualizar los estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/). PowerPoint puede presentar más opciones de fondo en su interfaz que el número de definiciones de relleno almacenadas físicamente en esta colección, porque la UI puede combinar rellenos del tema con colores del tema y otras referencias de estilo.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.getStyleIndex](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/) actual. Un índice de estilo `0` significa que no hay relleno temático; los valores positivos son referencias a estilos de fondo del tema. Esto difiere de indexar directamente la colección Java, donde `get_Item(0)` representa el primer elemento almacenado. No asuma que todas las presentaciones contengan el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el número de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer master y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el master y de cualquier sobrescritura de fondo en el layout o la diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del master puede no afectar a esa diapositiva. Use [Background.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/) cuando necesite conocer el fondo final tras aplicar la herencia.

{{% alert color="warning" title="Advertencia" %}}

No trate el índice de estilo como un índice de colección basado en cero. También evite codificar un número de estilo de un archivo y suponer que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.

{{% /alert %}}

{{% alert color="info" title="Consejo" %}}

Para formateo directo de fondo y herencia de fondo, vea [Presentation Background](/slides/es/java/presentation-background/).

{{% /alert %}}

## **Actualizar los efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de estilos de relleno, línea y efecto expuestas mediante [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/) y [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/iformatscheme/). Los temas típicos de Office suelen contener tres entradas de estilo principales que correspondan visualmente a formatos sutiles, moderados e intensos, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Al acceder a estas colecciones en Java, el índice de la colección es cero basado: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto mediante [IShapeStyle](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapestyle/). Modificar un estilo del tema afecta a las formas que hacen referencia a ese estilo; las formas con formato directo pueden permanecer sin cambios.

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

Para las formas que referencian esas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y si el formato directo sobrescribe el tema.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Leer los valores efectivos del tema**

Los objetos de tema sin procesar le indican qué está definido en un nivel concreto. Los valores efectivos le dicen qué usa realmente una diapositiva o forma después de resolver la herencia y las sobrescrituras locales. Para una diapositiva, llame a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseoverridethememanager/). Para un fondo, use [Background.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/), y para un relleno, use [FillFormat.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/fillformat/).

El siguiente ejemplo lee el tema efectivo, el fondo y el primer relleno de forma de una diapositiva:

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

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/), puede pasar por alto una sobrescritura en master, layout, diapositiva o forma que cambie la apariencia final.

## **Preguntas frecuentes**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el master?**

Sí. Use el [SlideThemeManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de sobrescritura. El cambio permanece local a esa diapositiva; las demás continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia origen, clone el master de origen en el destino y clone la diapositiva con ese master usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslidecollection/) y [ISlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/). Así se mantiene el master, los layouts y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las sobrescrituras?**

Utilice [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseoverridethememanager/) para un tema de diapositiva o layout y los métodos de datos efectivos correspondientes para objetos de formato como [Background.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/background/) y [FillFormat.getEffective](https://reference.aspose.com/slides/es/java/com.aspose.slides/fillformat/). Estas API devuelven los valores resueltos tras aplicar la herencia y las sobrescrituras.