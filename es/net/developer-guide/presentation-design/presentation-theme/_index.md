---
title: Gestionar temas de presentación en .NET
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/net/presentation-theme/
keywords:
- Tema de PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Tema externo
- THMX
- Color de tema
- Paleta adicional
- Fuente del tema
- Estilo del tema
- Efecto del tema
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Temas maestros de presentación en Aspose.Slides para .NET para crear, personalizar y convertir archivos PowerPoint con una marca coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos conscientes del tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de la propiedad [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un master puede anular el tema de la presentación mediante [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/), un diseño puede anular su tema heredado mediante [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), y una diapositiva individual puede hacer lo mismo. En la práctica, el tema efectivo para una diapositiva se resuelve mediante esta cadena de herencia: tema de presentación, anulación del master, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y de efectos, y leer los valores efectivos después de que se haya resuelto la herencia y las anulaciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) expone el [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), el [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) y el [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) del tema. Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y contenido de las entradas de estilo pueden variar.

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

Si un archivo utiliza varios masters, no asuma que cada diapositiva tenga el mismo tema efectivo. Inspeccione el master asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones en el diseño o en la diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y texto conscientes del tema pueden referirse a un color lógico del enumerado [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) del tema, todos los objetos que todavía hacen referencia a ese color del tema se resuelven contra el nuevo valor. Los objetos que utilizan un color RGB directo no se modifican con la actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que utiliza `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

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

Porque el rectángulo sigue vinculado a `Accent4`, su color visible pasa a rojo después de cambiar el tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Utilizar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y más oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

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

Estas variantes siguen basadas en el color del tema. Si `Accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear valores `SchemeColor` a ranuras `IColorScheme`**

El enumerado [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para los encabezados y un conjunto de fuentes secundario para el cuerpo del texto. Las propiedades [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) y [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn‑lt` - Fuente del cuerpo Latin (Minor Latin Font)
* `+mj‑lt` - Fuente del encabezado Latin (Major Latin Font)
* `+mn‑ea` - Fuente del cuerpo East Asian (Minor East Asian Font)
* `+mj‑ea` - Fuente del encabezado East Asian (Major East Asian Font)
* `+mn‑cs` - Fuente del cuerpo Complex Script (Minor Complex Script Font)
* `+mj‑cs` - Fuente del encabezado Complex Script (Major Complex Script Font)

El siguiente ejemplo crea un encabezado que usa la fuente Latin principal del tema y una línea de cuerpo que usa la fuente Latin secundaria del tema. A continuación cambia las fuentes del tema y guarda el resultado:

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

El encabezado sigue la fuente principal y el texto del cuerpo sigue la fuente secundaria. Un texto que tenga un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

Los conjuntos de fuentes principales y secundarios también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, sustituir o eliminar estas asignaciones, consulte [Script‑Specific Theme Fonts](/slides/es/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para obtener más información sobre fuentes de presentación, consulte [Fuentes de PowerPoint](/slides/es/net/powerpoint-fonts/).
{{% /alert %}}

### **Resolver referencias de fuentes del tema**

Al inspeccionar texto, [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) puede contener una referencia al tema como `+mn‑lt` en lugar de un nombre de familia de fuente. Llame a [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) con el [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) apropiado para resolver esa referencia. Los prefijos `+mj` y `+mn` seleccionan los conjuntos de fuentes mayor y menor; los sufijos `-lt`, `-ea` y `-cs` seleccionan sus fuentes Latin, East Asian y Complex Script, respectivamente.

Obtenga el tema efectivo mediante [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) en el objeto cuyo tema se aplica al texto inspeccionado. Para texto ordinario en una diapositiva, use `slide.CreateThemeEffective()` de modo que el contexto incluya el tema heredado de esa diapositiva y sus anulaciones locales. Al inspeccionar un diseño o un master, use su propio tema efectivo. No asuma que el tema del primer master se aplique a todas las diapositivas.

El siguiente ejemplo crea una porción de texto que referencia explícitamente la fuente Latin secundaria. Inicializa un esquema de fuentes de diapositiva mediante [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) y establece las familias Latin mayor y menor a `Arial` y `Calibri`, haciendo que el resultado sea reproducible sin un archivo de entrada.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

La salida es `+mn‑lt -> Calibri` seguida de `Verdana -> Verdana`. La referencia almacenada permanece sin cambios, mientras que un nombre de familia explícito se devuelve tal cual. Si la porción hubiera usado `+mj‑lt`, se resolvería a `Arial` en este tema.

Resolver una referencia de tema identifica la familia de fuentes especificada por el tema. No comprueba la disponibilidad de la fuente ni determina el archivo de fuente que finalmente se usa después de la sustitución o el fallback de glifos durante la representación. Consulte [Secuencia de selección de fuentes](/slides/es/net/font-selection-sequence/) y [Sustitución de fuentes](/slides/es/net/font-substitution/) para esos pasos separados.

## **Copiar o aplicar un tema**

Los flujos de trabajo siguientes resuelven diferentes problemas relacionados con el tema.

### **Aplicar un tema externo a las diapositivas dependientes de un master**

Use [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) cuando tenga un archivo de tema de PowerPoint (`.thmx`) y desee restilizar cada diapositiva que dependa de un master concreto. Seleccione el master de la colección [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea un nuevo master slide basado en el master seleccionado.
1. Aplica el tema externo al nuevo master.
1. Asigna el nuevo master a todas las diapositivas que previamente dependían del master seleccionado.
1. Devuelve el nuevo [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/).

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer master, guarda la presentación y vuelve a abrir el resultado:

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

Un tema no válido, corrupto o no compatible puede provocar una [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) o una de sus subclases relacionadas con el formato. Valide las rutas proporcionadas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación sólo después de que el tema se haya aplicado correctamente.

Sólo se reasignan las diapositivas que dependían del master seleccionado. Las diapositivas asociadas a otros masters conservan sus masters y temas existentes. Los colores, fuentes, rellenos, líneas, fondos y efectos conscientes del tema se resuelven frente al tema externo. Los colores, fuentes, rellenos y demás formatos asignados directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y de diapositiva también pueden prevalecer sobre los valores heredados del nuevo master.

El tema puede referenciar fuentes que no estén disponibles en el entorno de ejecución. Para un renderizado y exportación consistentes, instale las fuentes necesarias, proporciónelas mediante [fuentes personalizadas](/slides/es/net/custom-font/), o configure la [sustitución de fuentes](/slides/es/net/font-substitution/).

Este es un flujo de trabajo directo a nivel de master: el método acepta la ruta a un archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o de diseño.

### **Aplicar diferentes temas externos en una presentación con varios masters**

Cuando el master relevante no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) y [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). Guarde las referencias originales de los masters antes de aplicar cualquier tema porque cada llamada crea otro master en la presentación.

El siguiente ejemplo usa diapositivas de dos secciones para localizar sus masters y aplica un tema externo distinto a cada grupo:

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

La primera llamada afecta sólo a las diapositivas que dependían de `firstGroupMaster`, y la segunda llamada afecta sólo a las diapositivas que dependían de `secondGroupMaster`. Las diapositivas pertenecientes a cualquier otro master no se restilizan.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el master de origen en la presentación de destino con [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/), y luego clone la diapositiva con [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) y el master clonado. De este modo se trasladan el master, sus diseños y el tema asociado.

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

Este es el flujo de trabajo preferido cuando la diapositiva origen debe verse idéntica en el destino. Simplemente clonar el contenido sobre un master de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos impulsados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su master y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) y [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copian los tres componentes principales del tema en la anulación.

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

Esto cambia el tema utilizado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través del [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) del diseño:

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

Utilice un tema a nivel de master o de presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo diferente, y una anulación de diapositiva solo para excepciones reales. Un exceso de anulaciones a nivel de diapositiva dificulta la predicción de cambios posteriores en el tema global.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint puede presentar más opciones de fondo en su UI que el número de definiciones de relleno almacenadas físicamente en esta colección, ya que la UI puede combinar rellenos del tema con colores del tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) actual. `StyleIndex` usa `0` para indicar que no hay relleno temático; los valores positivos son referencias a estilos de fondo del tema. Esto difiere del índice de la colección .NET, donde `[0]` representa el primer elemento almacenado. No asuma que cada presentación contenga el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el número de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer master y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el master y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del master puede no afectar a esa diapositiva. Use [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) cuando necesite conocer el fondo final después de aplicar la herencia.

{{% alert color="warning" title="Warning" %}}
No considere `StyleIndex` como un índice de colección basado en cero. Evite también codificar un número de estilo de un archivo y suponer que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de la presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para el formato directo de fondo y la herencia de fondo, consulte [Fondo de presentación](/slides/es/net/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) y [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). Los temas típicos de Office suelen contener tres entradas de estilo principales que corresponden visualmente a formatos sutil, moderado e intenso, pero el código debe inspeccionar cada colección en vez de asumir un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en C#, el índice de la colección es base cero: `[0]` es el primer estilo almacenado y `[2]` el tercero. Los índices de referencia de estilo de una forma son un concepto distinto, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). Modificar un estilo del tema afecta a las formas que hacen referencia a ese estilo del tema; las formas con formato directo pueden permanecer sin cambios.

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

Para las formas que hacen referencia a estas ranuras, el primer estilo de línea del tema pasa a rojo, el tercer estilo de relleno del tema pasa a verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencie cada forma y si el formato directo anula el tema.

![Estilos de efecto del tema después de cambiar línea, relleno y ajustes de sombra](presentation-design_11.png)

## **Seleccionar estilos de relleno y línea del tema para una forma**

Una forma puede seleccionar su relleno y contorno de forma independiente mediante [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) y [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). Para ambas propiedades, el índice `1` selecciona la primera entrada en la colección correspondiente del tema (`FillStyles[0]` o `LineStyles[0]`), y el índice `2` selecciona la segunda entrada.

El siguiente ejemplo prepara dos estilos de relleno (oro y azul cielo) y dos estilos de línea (azul oscuro a 6 pt y rojo oscuro a 12 pt) en el tema predeterminado de una nueva presentación. Guarda la diapositiva en tres etapas para que pueda comparar los resultados en PowerPoint.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Estilos iniciales | Cambiar el contorno derecho | Editar el primer relleno del tema |
|:---:|:---:|:---:|
| ![Rectángulos oro y azul cielo con contornos finos azul oscuro coincidentes](theme-style-initial.png) | ![El rectángulo azul cielo ahora tiene un contorno rojo grueso](theme-style-line-changed.png) | ![El rectángulo izquierdo pasa a verde y ambos contornos permanecen sin cambios](theme-style-fill-changed.png) |

Seleccionar un estilo de línea diferente solo cambia el contorno del rectángulo derecho. Editar el primer relleno del tema actualiza cada forma que lo usa. Aquí, solo el rectángulo izquierdo se vuelve verde.

En una forma existente, un color de relleno, color de línea o ancho de línea local pueden anular esa parte del estilo del tema. Si cambiar un índice de estilo no produce ningún efecto visible, revise el [formato directo](/slides/es/net/shape-formatting/) de la forma.

## **Determinar si un relleno sólido efectivo usa un color del tema**

Un relleno puede estar almacenado directamente en un objeto o heredarse de un párrafo, diseño, master, estilo del tema u otro nivel de formato. Llame a [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) para resolver esa jerarquía en un [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) inmutable. Primero compruebe [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). Sólo cuando sea `FillType.Solid` debe leer las propiedades del relleno sólido.

Para un relleno sólido, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) devuelve el valor RGB final después de aplicar herencia, búsqueda en el tema y transformaciones de color. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) devuelve la ranura lógica [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) correspondiente, como `Text1` o `Accent6`. Un valor de `SchemeColor.NotDefined` indica que el relleno sólido efectivo no se basa en un color de esquema. En un flujo de trabajo donde los rellenos son colores del tema o colores RGB directos, este valor identifica un relleno RGB directo.

No utilice únicamente el valor local [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) para clasificar un relleno. Por ejemplo, una porción de texto puede no tener un color de esquema definido localmente, por lo que su valor local es `NotDefined`, mientras que su relleno efectivo hereda un color del tema y se resuelve a `Text1` o `Accent6`. Por el contrario, `SolidFillSchemeColor` le indica qué ranura lógica del tema produjo el color efectivo, pero no indica si esa ranura proviene del objeto, párrafo, diseño, master u otro nivel de la jerarquía de formato.

El siguiente ejemplo carga una presentación, auditoría los rellenos de forma y los rellenos de porciones de texto, imprime cada valor RGB final y el color de esquema asociado, y marca los rellenos sólidos que no seguirán los cambios de color del tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

La rama `NotDefined` proporciona una lista de auditoría de rellenos sólidos que no responderán a cambios en las ranuras de color del tema. Revise esos objetos cuando una presentación deba ajustarse a una nueva paleta de marca. El valor RGB informado sigue mostrando la apariencia actual, mientras que el valor de esquema explica si esa apariencia está conectada al tema.

Los objetos de formato efectivo son instantáneas. Después de cambiar el tema de la presentación, una anulación de tema o cualquier formato heredado, llame a `GetEffective` nuevamente y lea un nuevo objeto `IFillFormatEffectiveData` antes de comparar o informar colores.

## **Leer valores efectivos del tema**

Los objetos de tema sin procesar le indican qué está definido en un nivel concreto. Los valores efectivos le indican qué usa realmente una diapositiva o forma después de que se haya resuelto la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Para un fondo, use [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), y para un relleno, use [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

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

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si sólo inspecciona [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/), puede pasar por alto una anulación en master, diseño, diapositiva o forma que cambie la apariencia final.

## **FAQ**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reasigna solo las diapositivas que dependen del master seleccionado. Las diapositivas que usan otros masters conservan sus temas existentes.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el master?**

Sí. Use el [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia de origen, clone el master de origen en el destino y clone la diapositiva con ese master mediante [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) y [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). Así se mantiene el master, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) para una diapositiva o tema de diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) y [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). Estas API devuelven los valores resueltos tras aplicar herencia y anulaciones.