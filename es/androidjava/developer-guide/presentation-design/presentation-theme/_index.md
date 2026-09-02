---
title: Gestionar temas de presentación en Android
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/androidjava/presentation-theme/
keywords:
- Tema de PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Tema externo
- THMX
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
description: "Temas maestros de presentación en Aspose.Slides para Android vía Java para crear, personalizar y convertir archivos PowerPoint con una marca consistente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos con conocimiento de tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Una presentación también puede contener anulación de temas en niveles inferiores. Un máster puede anular el tema de la presentación mediante [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/masterthememanager/), mientras que un diseño o una diapositiva individual pueden anular su tema heredado mediante [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de presentación, anulación del máster, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y de efecto, y leer los valores efectivos tras la herencia y las anulaciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/) expone el esquema de colores, el esquema de fuentes y el esquema de formato del tema mediante [MasterTheme.getColorScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/) y [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es particularmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto se almacenan en el tema:

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

Si un archivo utiliza varios másters, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el máster asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones de diseño o diapositiva.

## **Cambiar los colores del tema**

Los rellenos, líneas y textos con conocimiento de tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/schemecolor/). Cuando se modifica la entrada correspondiente en la [IColorScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icolorscheme/), todos los objetos que todavía hacen referencia a ese color de tema se resuelven con el nuevo valor. Los objetos que usan un color RGB directo no se modifican con la actualización del color del tema.

El siguiente ejemplo integral crea una forma que utiliza `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

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

Dado que el rectángulo sigue vinculado a `Accent4`, su color visible pasa a rojo tras el cambio de tema. Si sustituye el color de esquema por un color directo en la forma, los posteriores cambios de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** – Colores principales del tema.

**2** – Variantes más claras y más oscuras producidas a partir de los colores principales del tema.

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

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que la [IColorScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar las fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para encabezados y un conjunto secundario para el cuerpo del texto. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/) y [IFontScheme.getMinor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/) exponen esos conjuntos.

Los identificadores de fuentes del tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` – Fuente del cuerpo (Latin Minor)
* `+mj-lt` – Fuente del encabezado (Latin Major)
* `+mn-ea` – Fuente del cuerpo (East Asian Minor)
* `+mj-ea` – Fuente del encabezado (East Asian Major)

El siguiente ejemplo crea un encabezado que utiliza la fuente latina mayor del tema y una línea de cuerpo que utiliza la fuente latina menor del tema. Luego cambia las fuentes del tema y guarda el resultado:

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

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. Un texto que tenga un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

Las colecciones mayor y menor también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, reemplazar o eliminar estas asignaciones, consulte [Fuentes del tema específicas de script](/slides/es/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Consejo" %}}

Para obtener más información sobre fuentes en presentaciones, consulte [Fuentes de PowerPoint](/slides/es/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Copiar o aplicar un tema**

Los flujos de trabajo siguientes resuelven diferentes problemas relacionados con temas.

### **Aplicar un tema externo a las diapositivas dependientes de un máster**

Utilice [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/) cuando disponga de un archivo de tema de PowerPoint (`.thmx`) y desee re‑estilizar todas las diapositivas que dependen de un máster concreto. Seleccione el máster de la colección [Presentation.getMasters](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea una nueva diapositiva máster basada en el máster seleccionado.  
2. Aplica el tema externo al nuevo máster.  
3. Asigna el nuevo máster a todas las diapositivas que previamente dependían del máster seleccionado.  
4. Devuelve el [IMasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/) recién creado.

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer máster y guarda la presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un tema inválido, corrupto o no compatible puede provocar una [PptxReadException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxreadexception/). Valide las rutas proporcionadas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado correctamente.

Solo se reasignan las diapositivas que dependían del máster seleccionado. Las diapositivas asociadas a otros másters conservan sus másters y temas actuales. Los colores, fuentes, rellenos, líneas, fondos y efectos con conocimiento de tema se resuelven contra el tema externo. Los colores, fuentes, rellenos y demás formato asignado directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y a nivel de diapositiva también pueden prevalecer sobre los valores heredados del nuevo máster.

El tema puede hacer referencia a fuentes que no estén disponibles en el entorno de ejecución. Para un renderizado y exportación consistentes, instale las fuentes requeridas, proporciónelas mediante [fuentes personalizadas](/slides/es/androidjava/custom-font/), o configure la [sustitución de fuentes](/slides/es/androidjava/font-substitution/).

Este es un flujo de trabajo directo a nivel de máster: el método acepta la ruta a un archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o diseño.

### **Aplicar diferentes temas externos en una presentación con varios másters**

Cuando el máster relevante no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [ISlide.getLayoutSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/) y [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilayoutslide/). Guarde las referencias al máster original antes de aplicar cualquier tema, ya que cada llamada crea otro máster en la presentación.

El siguiente ejemplo usa diapositivas de dos secciones para localizar sus másters y aplica un tema externo distinto a cada grupo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

La primera llamada afecta solo a las diapositivas que dependían de `firstGroupMaster`, y la segunda llamada afecta solo a las que dependían de `secondGroupMaster`. Las diapositivas pertenecientes a cualquier otro máster no se re‑estilizan.

### **Conservar el tema origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el máster origen en la presentación de destino con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/), y luego clone la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/) y el máster clonado. Así se transportan el máster, sus diseños y el tema asociado.

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

Este es el flujo de trabajo recomendado cuando la diapositiva origen debe verse idéntica en el destino. Simplemente clonar contenido sobre un máster de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos controlados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su máster y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema origen. Los métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/) y [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/) copian los tres componentes principales del tema en la anulación.

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

Esto cambia el tema utilizado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/overridetheme/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, salvo que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través de [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Utilice un tema a nivel de máster o de presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo distinto, y una anulación de diapositiva solo para excepciones reales. Un exceso de anulaciones a nivel de diapositiva dificulta predecir los cambios globales de tema posteriores.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/). PowerPoint puede ofrecer más opciones de fondo en su UI que el número de definiciones de relleno realmente almacenadas en esta colección, ya que la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de utilizar un estilo de fondo, inspeccione la colección almacenada y el índice actual mediante [Background.getStyleIndex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/). Un índice de estilo `0` significa que no hay relleno temático; los valores positivos son referencias a estilos de fondo del tema. Esto difiere de indexar directamente la colección Java, donde `get_Item(0)` indica el primer elemento almacenado. No asuma que todas las presentaciones contienen la misma cantidad de estilos de relleno de fondo.

El siguiente ejemplo informa del número de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer máster y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el máster y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva utiliza su propio fondo, cambiar solo el fondo del máster puede no afectar a esa diapositiva. Utilice [Background.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/) cuando necesite conocer el fondo final después de aplicar la herencia.

{{% alert color="warning" title="Advertencia" %}}

No trate el índice de estilo como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y suponer que tendrá la misma apariencia en otro archivo; las definiciones de estilo de tema son específicas de cada presentación.

{{% /alert %}}

{{% alert color="info" title="Consejo" %}}

Para formato directo de fondo y herencia de fondo, consulte [Fondo de la presentación](/slides/es/androidjava/presentation-background/).

{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de estilos de relleno, línea y efecto, expuestas mediante [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/) y [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iformatscheme/). Los temas típicos de Office suelen contener tres entradas principales que corresponden visualmente a formatos sutil, moderado e intenso, pero el código debe inspeccionar cada colección en vez de asumir un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en Java, el índice de la colección es cero‑based: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapestyle/). Modificar un estilo de tema afecta a las formas que hacen referencia a ese estilo; las formas con formato directo pueden quedar sin cambios.

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

Para las formas que referencian esas ranuras, el primer estilo de línea del tema pasa a rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencie cada forma y de si el formato directo sobrescribe al tema.

![Estilos de efecto del tema tras modificar línea, relleno y sombra](presentation-design_11.png)

## **Leer valores de tema efectivos**

Los objetos de tema sin procesar indican lo que está definido en un nivel determinado. Los valores efectivos indican lo que una diapositiva o forma utiliza realmente tras la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseoverridethememanager/). Para un fondo, use [Background.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/), y para un relleno, use [FillFormat.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/).

El siguiente ejemplo lee el tema efectivo, el fondo y el relleno de la primera forma de una diapositiva:

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

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/), puede pasar por alto una anulación de máster, diseño, diapositiva o forma que altere la apariencia final.

## **Preguntas frecuentes**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/) reasigna solo las diapositivas que dependen del máster seleccionado. Las diapositivas que utilizan otros másters conservan sus temas actuales.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el máster?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su aspecto original, clone el máster origen en el destino y clone la diapositiva con ese máster usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslidecollection/) y [ISlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/). Así se mantiene el máster, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos tras la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseoverridethememanager/) para el tema de una diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/background/) y [FillFormat.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/). Estas APIs devuelven los valores resueltos tras aplicar la herencia y las anulaciones.