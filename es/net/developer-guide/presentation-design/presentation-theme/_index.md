---
title: Gestionar temas de presentación en .NET
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/net/presentation-theme/
keywords:
- tema de PowerPoint
- tema de presentación
- tema de diapositiva
- establecer tema
- cambiar tema
- gestionar tema
- tema externo
- THMX
- color del tema
- paleta adicional
- fuente del tema
- estilo del tema
- efecto del tema
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para .NET para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos conscientes del tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de la propiedad [Presentation.MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/mastertheme/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un maestro puede anular el tema de la presentación mediante [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/masterthememanager/overridetheme/), un diseño puede anular su tema heredado mediante [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), y una diapositiva individual puede hacer lo mismo. En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de presentación, anulación del maestro, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones a continuación muestran los flujos de trabajo de tema más comunes: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y de efectos, y leer valores efectivos después de que la herencia y las anulaciones se hayan resuelto.

## **Inspeccionar un Tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/) expone el [ColorScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/fontscheme/) y [FormatScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/formatscheme/) del tema. Inspeccionar estas colecciones antes de modificarlas resulta especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones a nivel de diseño o diapositiva.

## **Cambiar los Colores del Tema**

Los rellenos, líneas y textos conscientes del tema pueden referirse a un color lógico del enumerado [SchemeColor](https://reference.aspose.com/slides/es/net/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/icolorscheme/) del tema, todos los objetos que todavía hacen referencia a ese color del tema se resuelven con el nuevo valor. Los objetos que usan un color RGB directo no se modifican con una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Como el rectángulo sigue vinculado a `Accent4`, su color visible pasa a ser rojo después de cambiar el tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores a `Accent4` ya no afectarán a ese relleno.

### **Usar Colores de la Paleta Adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante [ColorTransformOperation](https://reference.aspose.com/slides/es/net/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.  
**2** - Variantes más claras y más oscuras producidas a partir de los colores principales del tema.

El siguiente ejemplo crea seis rectángulos basados en `Accent4`, aplica transformaciones de luminancia a cinco de ellos y guarda el resultado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Estas variantes permanecen basadas en el color del tema. Si `Accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` a Ranuras de `IColorScheme`**

El enumerado [SchemeColor](https://reference.aspose.com/slides/es/net/aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que [IColorScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar las Fuentes del Tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para los encabezados y un conjunto de fuentes secundario para el cuerpo del texto. Las propiedades [FontScheme.Major](https://reference.aspose.com/slides/es/net/aspose.slides.theme/fontscheme/major/) y [FontScheme.Minor](https://reference.aspose.com/slides/es/net/aspose.slides.theme/fontscheme/minor/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden utilizarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado Latin (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo Este Asiático (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado Este Asiático (Major East Asian Font)

El siguiente ejemplo crea un encabezado que usa la fuente Latin mayor del tema y una línea de cuerpo que usa la fuente Latin menor del tema. Luego cambia las fuentes del tema y guarda el resultado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando cambie el esquema de fuentes del tema.

Las colecciones de fuentes mayor y menor también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como Cirílico, Árabe, Japonés, Georgiano y Thaana. Para inspeccionar, añadir, reemplazar o eliminar estas asignaciones, consulte [Fuentes de Tema Específicas por Script](/slides/es/net/script-specific-font-mappings/).

{{% alert color="info" title="Consejo" %}}
Para obtener más información sobre las fuentes en presentaciones, consulte [Fuentes de PowerPoint](/slides/es/net/powerpoint-fonts/).
{{% /alert %}}

## **Copiar o Aplicar un Tema**

Los flujos de trabajo a continuación resuelven diferentes problemas relacionados con los temas.

### **Aplicar un Tema Externo a las Diapositivas Dependientes de un Maestro**

Utilice [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) cuando disponga de un archivo de tema de PowerPoint (`.thmx`) y desee restilizar cada diapositiva que dependa de un maestro concreto. Seleccione el maestro de la colección [Presentation.Masters](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea una nueva diapositiva maestra basada en el maestro seleccionado.  
2. Aplica el tema externo a la nueva maestra.  
3. Asigna la nueva maestra a todas las diapositivas que previamente dependían del maestro seleccionado.  
4. Devuelve la nueva [IMasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/) creada.

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer maestro, guarda la presentación y vuelve a abrir el resultado:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Un tema inválido, corrupto o no compatible puede provocar una [PptxException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxexception/) o una de sus subclases relacionadas con el formato. Valide las rutas suministradas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado con éxito.

Solo se reasignan las diapositivas que dependían del maestro seleccionado. Las diapositivas asociadas a otros maestros conservan sus maestros y temas existentes. Los colores, fuentes, rellenos, líneas, fondos y efectos conscientes del tema se resuelven con el tema externo. Los colores, fuentes, rellenos y demás formato asignado directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y diapositiva también pueden tomar precedencia sobre los valores heredados del nuevo maestro.

El tema puede referenciar fuentes que no estén disponibles en el entorno de ejecución. Para una renderización y exportación consistentes, instale las fuentes necesarias, proporciónelas mediante [fuentes personalizadas](/slides/es/net/custom-font/), o configure la [sustitución de fuentes](/slides/es/net/font-substitution/).

Este es un flujo de trabajo directo a nivel de maestro: el método acepta la ruta a un archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o de diseño.

### **Aplicar Diferentes Temas Externos en una Presentación con Varios Maestros**

Cuando el maestro relevante no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [ISlide.LayoutSlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/layoutslide/) y [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/masterslide/). Guarde las referencias originales del maestro antes de aplicar cualquier tema, ya que cada llamada crea otro maestro en la presentación.

El siguiente ejemplo utiliza diapositivas de dos secciones para localizar sus maestros y aplica un tema externo diferente a cada grupo:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

La primera llamada afecta solo a las diapositivas que dependían de `firstGroupMaster`, y la segunda llamada afecta solo a las diapositivas que dependían de `secondGroupMaster`. Las diapositivas pertenecientes a cualquier otro maestro no se restilizan.

### **Conservar un Tema de Origen al Mover Diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro de origen en la presentación destino con [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/addclone/), luego clone la diapositiva con [ISlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/) y el maestro clonado. Así se trasladan el maestro, sus diseños y el tema asociado juntos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse igual en el destino. Clonar simplemente el contenido sobre un maestro de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar Valores de Tema a una Diapositiva Existente**

Si la diapositiva objetivo debe permanecer en su maestro y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/initfontschemefrom/) y [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copian los tres componentes principales del tema en la anulación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Esto cambia el tema usado por esa diapositiva sin cambiar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.Clear](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar una Anulación de Tema a un Diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, salvo que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través del [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/net/aspose.slides.theme/layoutslidethememanager/) del diseño:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Utilice un tema a nivel de maestro o presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo distinto, y una anulación de diapositiva solo para excepciones reales. Las anulaciones excesivas a nivel de diapositiva dificultan predecir los cambios globales posteriores del tema.

## **Actualizar los Estilos de Fondo del Tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint puede presentar más opciones de fondo en su interfaz de usuario que la cantidad de definiciones de relleno físicamente almacenadas en esta colección, porque la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el valor actual de [Background.StyleIndex](https://reference.aspose.com/slides/es/net/aspose.slides/background/styleindex/). `StyleIndex` usa `0` para indicar que no hay relleno tematizado; los valores positivos son referencias a estilos de fondo del tema. Esto difiere del índice de la colección .NET, donde `[0]` representa el primer elemento almacenado. No asuma que todas las presentaciones contienen la misma cantidad de estilos de relleno de fondo.

El siguiente ejemplo informa el número de rellenos de fondo disponibles, asigna una referencia de fondo tematizado al primer maestro y guarda la presentación:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

El resultado visible depende de la entrada del tema referenciada por el maestro y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Utilice [Background.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/background/geteffective/) cuando necesite conocer el fondo final tras aplicar la herencia.

{{% alert color="warning" title="Advertencia" %}}
No trate `StyleIndex` como un índice de colección basado en cero. Asimismo, evite codificar un número de estilo de un archivo y suponer que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Consejo" %}}
Para formateo directo de fondos y herencia de fondos, consulte [Fondo de Presentación](/slides/es/net/presentation-background/).
{{% /alert %}}

## **Actualizar los Efectos del Tema**

Un esquema de formato del tema contiene colecciones separadas de [FillStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/linestyles/) y [EffectStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/effectstyles/). Los temas típicos de Office suelen contener tres entradas de estilo principales que corresponden visualmente a formatos sutiles, moderados e intensos, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en C#, el índice de la colección es basado en cero: `[0]` es el primer estilo almacenado y `[2]` el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto mediante [IShapeStyle](https://reference.aspose.com/slides/es/net/aspose.slides/ishapestyle/). Modificar un estilo del tema afecta a las formas que hacen referencia a ese estilo; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existan las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra externa en el tercer estilo de efecto y guarda el resultado:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Para las formas que referencian estas ranuras, el primer estilo de línea del tema pasa a ser rojo, el tercer estilo de relleno del tema pasa a ser verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y de si el formato directo anula el tema.

![Estilos de efecto del tema después de cambiar línea, relleno y sombra](presentation-design_11.png)

## **Leer Valores Efectivos del Tema**

Los objetos de tema sin procesar le indican qué está definido en un nivel concreto. Los valores efectivos le indican qué usa realmente una diapositiva o forma tras resolver la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/es/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Para un fondo, utilice [Background.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/background/geteffective/), y para un relleno, use [FillFormat.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/fillformat/geteffective/).

El siguiente ejemplo lee el tema efectivo, el fondo y el primer relleno de forma de una diapositiva:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/mastertheme/), puede pasar por alto una anulación de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **Preguntas Frecuentes**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reasigna solo las diapositivas que dependen del maestro seleccionado. Las diapositivas que usan otros maestros conservan sus temas existentes.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/es/net/aspose.slides.theme/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de transportar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia original, clone el maestro de origen en el destino y clone la diapositiva con ese maestro usando [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/addclone/) y [ISlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/). Así se mantiene el maestro, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos tras la herencia y las anulaciones?**

Use [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/es/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) para un tema de diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/background/geteffective/) y [FillFormat.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/fillformat/geteffective/). Estas API devuelven los valores resueltos tras aplicar la herencia y las anulaciones.