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
- Administrar tema
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
description: "Domina los temas de presentación en Aspose.Slides para Android mediante Java para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos con conocimiento de tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible mediante [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un maestro puede anular el tema de la presentación mediante [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), mientras que una diapositiva de diseño o una diapositiva individual pueden anular su tema heredado mediante [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de presentación, anulación del maestro, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y de efecto, y leer los valores efectivos después de que se hayan resuelto la herencia y las anulaciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) expone el esquema de colores, el esquema de fuentes y el esquema de formato del tema mediante [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) y [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El ejemplo siguiente lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

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

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo mostrado más adelante en este artículo cuando puedan existir anulaciones de diseño o de diapositiva.

## **Cambiar los colores del tema**

Los rellenos, líneas y textos con conocimiento de tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), todos los objetos que aún hacen referencia a ese color del tema se resuelven contra el nuevo valor. Los objetos que usan un color RGB directo no se modifican con una actualización de color de tema.

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

Como el rectángulo sigue vinculado a `Accent4`, su color visible pasa a ser rojo tras cambiar el tema. Si reemplaza el color del esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint deriva variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

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

Estas variantes siguen basándose en el color del tema. Si `Accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear los valores `SchemeColor` a los espacios de `IColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` y `Background2`, mientras que [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) expone los mismos espacios del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. El mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para los mismos espacios del tema; no son valores que se convierten dinámicamente de una forma a otra.

## **Cambiar las fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto principal de fuentes para encabezados y un conjunto secundario de fuentes para el cuerpo del texto. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) y [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado Latin (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo East Asian (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado East Asian (Major East Asian Font)
* `+mn-cs` - Fuente del cuerpo Complex Script (Minor Complex Script Font)
* `+mj-cs` - Fuente del encabezado Complex Script (Major Complex Script Font)

El siguiente ejemplo crea un encabezado que usa la fuente latina principal del tema y una línea de cuerpo que usa la fuente latina secundaria del tema. Luego cambia las fuentes del tema y guarda el resultado:

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

El encabezado sigue la fuente principal y el texto del cuerpo sigue la fuente secundaria. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no se cambiará automáticamente cuando el esquema de fuentes del tema cambie.

Las colecciones de fuentes principales y secundarias también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, sustituir o eliminar estas asignaciones, consulte [Fuentes de tema específicas de script](/slides/es/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Para obtener más información sobre las fuentes de presentación, consulte [Fuentes de PowerPoint](/slides/es/androidjava/powerpoint-fonts/).

{{% /alert %}}

### **Resolver referencias de fuentes del tema**

Al inspeccionar texto, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) puede devolver una referencia de tema como `+mn-lt` en lugar de un nombre de familia tipográfica. Llame a [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) con el [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) apropiado para resolver esa referencia. Los prefijos `+mj` y `+mn` seleccionan los conjuntos de fuentes principales y secundarios; los sufijos `-lt`, `-ea` y `-cs` seleccionan sus fuentes Latin, East Asian y Complex Script, respectivamente.

Obtenga el tema efectivo mediante [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) en el objeto cuyo tema se aplica al texto inspeccionado. Para texto ordinario en una diapositiva, llame a este método en la diapositiva para que el contexto incluya el tema heredado de esa diapositiva y sus anulaciones locales. Al inspeccionar un diseño o un maestro, utilice su propio tema efectivo. No asuma que el tema del primer maestro se aplica a todas las diapositivas.

El siguiente ejemplo crea una porción de texto que hace referencia explícita a la fuente latina secundaria. Inicializa un esquema de fuentes de diapositiva mediante [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) y establece las familias latinas principales y secundarias en `Arial` y `Calibri`, haciendo que el resultado sea reproducible sin un archivo de entrada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

La salida es `+mn-lt -> Calibri` seguida de `Verdana -> Verdana`. La referencia almacenada permanece sin cambios, mientras que un nombre de familia explícito se devuelve tal cual. Si la porción usara `+mj-lt`, se resolvería a `Arial` en este tema.

Resolver una referencia de tema identifica la familia tipográfica especificada por el tema. No verifica la disponibilidad de la fuente ni determina el archivo de fuente que se usará finalmente tras la sustitución o el fallback de glifos durante la representación. Consulte [Secuencia de selección de fuentes](/slides/es/androidjava/font-selection-sequence/) y [Sustitución de fuentes](/slides/es/androidjava/font-substitution/) para esos pasos independientes.

## **Copiar o aplicar un tema**

Los flujos de trabajo a continuación resuelven diferentes problemas relacionados con temas.

### **Aplicar un tema externo a las diapositivas dependientes de un maestro**

Utilice [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) cuando disponga de un archivo de tema de PowerPoint (`.thmx`) y desee restilar todas las diapositivas que dependen de un maestro concreto. Seleccione el maestro de la colección [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea una nueva diapositiva maestra basada en el maestro seleccionado.
1. Aplica el tema externo al nuevo maestro.
1. Asigna el nuevo maestro a todas las diapositivas que previamente dependían del maestro seleccionado.
1. Devuelve el nuevo [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer maestro y guarda la presentación:

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

Un tema inválido, dañado o no compatible puede provocar [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Valide las rutas proporcionadas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado correctamente.

Solo se reasignan las diapositivas que dependían del maestro seleccionado. Las diapositivas asociadas a otros maestros conservan sus maestros y temas actuales. Los colores, fuentes, rellenos, líneas, fondos y efectos con conocimiento de tema se resuelven contra el tema externo. Los colores, fuentes, rellenos y demás formatos asignados directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y de diapositiva también pueden tener prioridad sobre los valores heredados del nuevo maestro.

El tema puede hacer referencia a fuentes que no estén disponibles en el entorno de ejecución. Para una representación y exportación consistentes, instale las fuentes requeridas, proporciónelas mediante [fuentes personalizadas](/slides/es/androidjava/custom-font/), o configure la [sustitución de fuentes](/slides/es/androidjava/font-substitution/).

Este es un flujo de trabajo directo a nivel de maestro: el método acepta una ruta de archivo a un archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o de diseño.

### **Aplicar diferentes temas externos en una presentación con varios maestros**

Cuando el maestro relevante no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) y [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Guarde las referencias originales de los maestros antes de aplicar cualquier tema, ya que cada llamada crea otro maestro en la presentación.

El siguiente ejemplo usa diapositivas de dos secciones para localizar sus maestros y aplica un tema externo diferente a cada grupo:

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

La primera llamada afecta solo a las diapositivas que dependían de `firstGroupMaster`, y la segunda llamada afecta solo a las diapositivas que dependían de `secondGroupMaster`. Las diapositivas que pertenecen a cualquier otro maestro no se restilan.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro de origen en la presentación de destino con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), luego clone la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) y el maestro clonado. Esto lleva al destino el maestro, sus diseños y el tema asociado.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse idéntica en el destino. Simplemente clonar contenido sobre un maestro de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su maestro y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) y [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) copian los tres componentes principales del tema en la anulación.

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

Esto cambia el tema utilizado por esa diapositiva sin modificar el tema heredado por las demás diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través de [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Utilice un tema a nivel de maestro o de presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo diferente, y una anulación de diapositiva solo para verdaderas excepciones. Las anulaciones excesivas a nivel de diapositiva dificultan predecir los cambios globales del tema más adelante.


<!-- visual-explanation:presentation-theme:start -->
[![Un tema maestro alimenta dos diseños; una anulación de diseño afecta a sus diapositivas salvo a una diapositiva con una anulación más local.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Una anulación de diseño se aplica a las diapositivas que usan ese diseño salvo que una diapositiva proporcione su propia anulación. Los valores basados en tema siguen su esquema resuelto; los objetos formateados explícitamente pueden conservar su apariencia local. Mantenga las anulaciones tan estrechas como la excepción de diseño prevista.*
<!-- visual-explanation:presentation-theme:end -->

## **Actualizar los estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint puede presentar más opciones de fondo en su interfaz que el número de definiciones de relleno almacenadas físicamente en esta colección porque la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el índice de estilo actual mediante [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). Un índice de estilo `0` significa que no hay relleno temático; los valores positivos son referencias de estilo de fondo temático. Esto difiere de indexar directamente la colección Java, donde `get_Item(0)` representa el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el recuento disponible de rellenos de fondo, asigna una referencia de fondo temático al primer maestro y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el maestro y de cualquier anulación de fondo a nivel de diseño o de diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Utilice [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) cuando necesite conocer el fondo final tras aplicar la herencia.

{{% alert color="warning" title="Warning" %}}

No trate el índice de estilo como un índice de colección basado en cero. Evite también codificar un número de estilo de un archivo y asumir que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de la presentación.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Para el formateo directo de fondos y la herencia de fondos, consulte [Fondo de presentación](/slides/es/androidjava/presentation-background/).

{{% /alert %}}

## **Actualizar los efectos del tema**

Un esquema de formato de tema contiene colecciones separadas de relleno, línea y efecto a las que se accede mediante [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) y [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Los temas típicos de Office suelen contener tres entradas principales de estilo que corresponden visualmente a formatos sutil, moderado e intenso, pero el código debe inspeccionar cada colección en vez de asumir un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en Java, el índice de la colección es basado en cero: `get_Item(0)` es el primer estilo almacenado y `get_Item(2)` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto mediante [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Modificar un estilo de tema afecta a las formas que hacen referencia a ese estilo de tema; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existen las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra exterior en el tercer estilo de efecto y guarda el resultado:

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

Para las formas que hacen referencia a estos espacios, el primer estilo de línea del tema pasa a ser rojo, el tercer estilo de relleno del tema pasa a ser verde bosque sólido, y el tercer estilo de efecto gana una sombra exterior con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué espacios de estilo referencia cada forma y si el formato directo anula el tema.

![Estilos de efecto de tema después de cambiar línea, relleno y ajustes de sombra](presentation-design_11.png)

## **Seleccionar estilos de relleno y línea del tema para una forma**

Una forma puede seleccionar su relleno y contorno de forma independiente mediante [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) y [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Para ambos métodos, el índice `1` selecciona la primera entrada en la colección temática correspondiente (`get_Item(0)`), y el índice `2` selecciona la segunda (`get_Item(1)`).

El siguiente ejemplo configura dos estilos de relleno (oro y azul cielo) y dos estilos de línea (azul oscuro a 6 pt y rojo oscuro a 12 pt) en el tema predeterminado de una nueva presentación. Guarda la diapositiva en tres etapas para que pueda comparar los resultados en PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Estilos iniciales | Cambiar el contorno derecho | Editar el primer relleno del tema |
|:---:|:---:|:---:|
| ![Rectángulos dorado y azul cielo con contornos finos azul oscuro coincidentes](theme-style-initial.png) | ![El rectángulo azul cielo ahora tiene un contorno rojo oscuro grueso](theme-style-line-changed.png) | ![El rectángulo izquierdo ahora es verde y ambos contornos permanecen sin cambios](theme-style-fill-changed.png) |

Seleccionar un estilo de línea distinto solo cambia el contorno del rectángulo derecho. Editar el primer relleno del tema actualiza todas las formas que lo usan. Aquí, solo el rectángulo izquierdo se vuelve verde.

En una forma existente, un color de relleno local, color de línea o grosor de línea puede anular esa parte del estilo del tema. Si cambiar un índice de estilo no produce efecto visible, revise el [formateo directo](/slides/es/androidjava/shape-formatting/) de la forma.

## **Determinar si un relleno sólido efectivo usa un color de tema**

Un relleno puede almacenarse directamente en un objeto o heredarse de un párrafo, diseño, maestro, estilo de tema u otro nivel de formato. Llame a [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) para resolver esa jerarquía en un [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) inmutable. Primero compruebe [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Solo cuando sea `FillType.Solid` debe leer las propiedades del relleno sólido.

Para un relleno sólido, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) devuelve el valor RGB final renderizado tras la herencia, la búsqueda en el tema y la aplicación de transformaciones de color. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) devuelve el espacio lógico [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) correspondiente, como `Text1` o `Accent6`. Un valor de `SchemeColor.NotDefined` indica que el relleno sólido efectivo no se basa en un color de esquema. En un flujo de trabajo donde los rellenos son colores de tema o colores RGB directos, este valor identifica un relleno RGB directo.

No utilice solo el valor local de [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) para clasificar un relleno. Por ejemplo, una porción de texto puede no tener un color de esquema definido localmente, por lo que su valor local es `NotDefined`, mientras que su relleno efectivo hereda un color de tema y se resuelve a `Text1` o `Accent6`. Por el contrario, `getSolidFillSchemeColor` le indica qué espacio lógico del tema produjo el color efectivo, pero no le dice si ese espacio proviene del objeto, párrafo, diseño, maestro u otro nivel de la jerarquía de formato.

El siguiente ejemplo carga una presentación, audita los rellenos de forma y los rellenos de porciones de texto, imprime cada valor RGB final y el color de esquema asociado, y marca los rellenos sólidos que no seguirán los cambios de color del tema:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La rama `NotDefined` proporciona una lista de auditoría de rellenos sólidos que no responderán a cambios en los espacios de color del tema. Revise esos objetos cuando una presentación deba seguir una nueva paleta de marca. El valor RGB informado sigue mostrando la apariencia actual, mientras que el valor de esquema explica si esa apariencia está conectada al tema.

Los objetos de formato efectivo son instantáneas. Después de cambiar el tema de la presentación, una anulación de tema o cualquier formato heredado, llame a `getEffective` nuevamente y lea un nuevo objeto `IFillFormatEffectiveData` antes de comparar o informar colores.

## **Leer valores de tema efectivos**

Los objetos de tema en bruto le indican qué está definido en un nivel concreto. Los valores efectivos le indican qué usa realmente una diapositiva o forma después de que se haya resuelto la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Para un fondo, use [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), y para un relleno, use [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

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

Utilice los datos efectivos para diagnósticos de representación, validación y comparaciones. Si solo inspecciona [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), puede pasar por alto una anulación de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **FAQ**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) reasigna solo las diapositivas que dependen del maestro seleccionado. Las diapositivas que usan otros maestros conservan sus temas actuales.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia de origen, clone el maestro de origen en el destino y clone la diapositiva con ese maestro usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) y [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Esto mantiene el maestro, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) para una diapositiva o tema de diseño y los métodos de datos efectivos correspondientes para objetos de formato como [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) y [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Estas API devuelven los valores resueltos después de aplicar la herencia y las anulaciones.