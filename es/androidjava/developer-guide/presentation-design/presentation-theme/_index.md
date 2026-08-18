---
title: Gestionar temas de presentación en Android
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para Android mediante Java para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos compatibles con temas hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Una presentación también puede contener sobrescrituras de tema en niveles inferiores. Un maestro puede sobrescribir el tema de la presentación mediante [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/masterthememanager/), mientras que una diapositiva o un diseño pueden sobrescribir su tema heredado mediante [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo de una diapositiva se resuelve mediante esta cadena de herencia: tema de presentación, sobrescritura del maestro, sobrescritura del diseño y sobrescritura de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo más comunes con temas: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y efectos, y leer los valores efectivos después de que se hayan resuelto la herencia y las sobrescrituras.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/) expone el esquema de colores, el esquema de fuentes y el esquema de formato del tema a través de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/) y [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Si un archivo usa varios maestros, no se asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y use el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir sobrescrituras de diseño o diapositiva.

## **Cambiar los colores del tema**

Los rellenos, líneas y texto compatibles con temas pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icolorscheme/), todos los objetos que siguen referenciando ese color del tema se resuelven contra el nuevo valor. Los objetos que usan un color RGB directo no se ven afectados por una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Como el rectángulo sigue vinculado a `Accent4`, su color visible se vuelve rojo después de cambiar el tema. Si reemplaza el color del esquema con un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

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

### **Mapear valores de `SchemeColor` a ranuras de `IColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` y `Background2`, mientras que el [IColorScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. El mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar las fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para encabezados y un conjunto de fuentes secundario para el cuerpo del texto. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/) y [IFontScheme.getMinor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Fuente Latin secundaria)
* `+mj-lt` - Fuente del encabezado Latin (Fuente Latin principal)
* `+mn-ea` - Fuente del cuerpo East Asian (Fuente East Asian secundaria)
* `+mj-ea` - Fuente del encabezado East Asian (Fuente East Asian principal)

El siguiente ejemplo crea un encabezado que usa la fuente Latin principal del tema y una línea de cuerpo que usa la fuente Latin secundaria del tema. Luego cambia las fuentes del tema y guarda el resultado:

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

El encabezado sigue la fuente principal y el texto del cuerpo sigue la fuente secundaria. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

{{% alert color="info" title="Tip" %}}

Para obtener más información sobre las fuentes de presentación, consulte [PowerPoint Fonts](/slides/es/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Copiar o aplicar un tema**

Existen dos flujos de trabajo habituales, y resuelven problemas diferentes.

### **Conservar el tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro de origen en la presentación de destino con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/), y luego clone la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/) y el maestro clonado. Esto lleva el maestro, sus diseños y el tema asociado juntos.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse igual en el destino. Simplemente clonar contenido sobre un maestro de destino no relacionado puede modificar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su maestro y diseño actuales, inicialice una sobrescritura a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/) y [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/) copian los tres componentes principales del tema en la sobrescritura.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Esto cambia el tema utilizado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la sobrescritura local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/).

### **Aplicar una sobrescritura de tema a un diseño**

Una sobrescritura a nivel de diseño se aplica a las diapositivas que usan ese diseño, salvo que una diapositiva concreta tenga su propia sobrescritura. Los mismos métodos de inicialización pueden usarse a través de [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Utilice un tema a nivel de maestro o presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una sobrescritura de diseño cuando una familia de diseños necesite un estilo diferente, y una sobrescritura de diapositiva solo para excepciones reales. Un exceso de sobrescrituras a nivel de diapositiva dificulta predecir los cambios globales del tema más adelante.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/). PowerPoint puede presentar más opciones de fondo en su UI que el número de definiciones de relleno almacenadas físicamente en esta colección porque la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el índice de estilo actual mediante [Background.getStyleIndex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/). Un índice de estilo `0` significa que no hay relleno temático; los valores positivos son referencias a estilos de fondo del tema. Esto difiere de indexar directamente la colección Java, donde `get_Item(0)` indica el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

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

El resultado visible depende de la entrada de tema referenciada por el maestro y de cualquier sobrescritura de fondo en el diseño o la diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Utilice [Background.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/) cuando necesite conocer el fondo final después de aplicada la herencia.

{{% alert color="warning" title="Warning" %}}

No trate el índice de estilo como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y suponer que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de la presentación.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Para formateo directo de fondo y herencia de fondo, consulte [Presentation Background](/slides/es/androidjava/presentation-background/).

{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de estilos de relleno, línea y efecto, expuestas mediante [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/) y [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/). Los temas típicos de Office a menudo contienen tres entradas principales que corresponden visualmente a formato sutil, moderado e intenso, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en Java, el índice de la colección es basado en cero: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapestyle/). Modificar un estilo de tema afecta a las formas que referencian ese estilo; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existan las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra externa en el tercer estilo de efecto y guarda el resultado:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para las formas que referencian estas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y si el formato directo sobrescribe el tema.

![Estilos de efecto del tema después de cambiar línea, relleno y sombra externa](presentation-design_11.png)

## **Leer valores efectivos del tema**

Los objetos de tema sin procesar le indican lo que está definido en un nivel concreto. Los valores efectivos le indican lo que una diapositiva o forma usa realmente después de que se resuelvan la herencia y las sobrescrituras locales. Para una diapositiva, llame a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseoverridethememanager/). Para un fondo, use [Background.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/), y para un relleno, use [FillFormat.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/).

El siguiente ejemplo lee el tema efectivo, el fondo y el primer relleno de forma de una diapositiva:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Utilice datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si sólo inspecciona [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/), puede pasar por alto una sobrescritura de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **Preguntas frecuentes**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de sobrescritura. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia original, clone el maestro de origen en el destino y clone la diapositiva con ese maestro usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/) y [ISlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/). Así se mantienen juntos el maestro, los diseños y el tema.

**¿Cómo puedo ver los valores efectivos después de la herencia y las sobrescrituras?**

Utilice [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseoverridethememanager/) para un tema de diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato como [Background.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/) y [FillFormat.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/). Estas API devuelven los valores resueltos tras aplicar la herencia y las sobrescrituras.