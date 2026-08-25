---
title: Administrar temas de presentación en .NET
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/net/presentation-theme/
keywords:
- Tema de PowerPoint
- tema de presentación
- tema de diapositiva
- establecer tema
- cambiar tema
- gestionar tema
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
description: "Domina los temas de presentación en Aspose.Slides para .NET para crear, personalizar y convertir archivos PowerPoint con una imagen de marca coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, tipografías, estilos de fondo, rellenos, líneas y efectos. Los objetos que admiten temas se refieren a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de la propiedad [Presentation.MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/mastertheme/). Una presentación también puede contener sustituciones de tema en niveles inferiores. Un máster puede sustituir el tema de la presentación mediante [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/masterthememanager/overridetheme/), un diseño puede sustituir su tema heredado mediante [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), y una diapositiva individual puede hacer lo mismo. En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de la presentación, sustitución del máster, sustitución del diseño y sustitución de la diapositiva.

![Componentes del tema: colores, tipografías, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo más habituales con temas: inspeccionar un tema, cambiar colores y tipografías, copiar o aplicar un tema, actualizar estilos de fondo y de efecto, y leer los valores efectivos tras resolver la herencia y las sustituciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/) expone el [ColorScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/colorscheme/), el [FontScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/fontscheme/) y el [FormatScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/mastertheme/formatscheme/) del tema. Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

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

Si un archivo utiliza varios másters, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el máster asociado a la diapositiva y use el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir sustituciones de diseño o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos dependientes del tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/net/aspose.slides/schemecolor/). Cuando cambie la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/icolorscheme/) del tema, todos los objetos que todavía referencian ese color del tema se resuelven contra el nuevo valor. Los objetos que usan un color RGB directo no se ven afectados por una actualización de color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir e imprime el color de relleno efectivo:

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

Dado que el rectángulo sigue vinculado a `Accent4`, su color visible pasa a ser rojo después de que el tema se cambie. Si sustituye el color de la esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint deriva variantes más claras y más oscuras de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante [ColorTransformOperation](https://reference.aspose.com/slides/es/net/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.  
**2** - Variantes más claras y más oscuras creadas a partir de los colores principales del tema.

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

### **Mapear valores de `SchemeColor` a ranuras de `IColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/net/aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que [IColorScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Son nombres alternativos para las mismas ranuras del tema; no son valores que se convierten dinámicamente de una forma a otra.

## **Cambiar tipografías del tema**

Un esquema de tipografías del tema contiene un conjunto principal de tipografías para encabezados y un conjunto secundario para el cuerpo del texto. Las propiedades [FontScheme.Major](https://reference.aspose.com/slides/es/net/aspose.slides.theme/fontscheme/major/) y [FontScheme.Minor](https://reference.aspose.com/slides/es/net/aspose.slides.theme/fontscheme/minor/) exponen esos conjuntos.

Los identificadores de tipografías de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado Latin (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo East Asian (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado East Asian (Major East Asian Font)

El siguiente ejemplo crea un encabezado que usa la tipografía mayor Latin del tema y una línea de cuerpo que usa la tipografía menor Latin del tema. Después cambia las tipografías del tema y guarda el resultado:

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

El encabezado sigue la tipografía mayor y el texto del cuerpo sigue la tipografía menor. El texto que tiene un nombre de tipografía explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de tipografías del tema cambie.

Las colecciones mayor y menor también pueden contener asignaciones de tipografías para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, sustituir o eliminar estas asignaciones, consulte [Fuentes de tema específicas por script](/slides/es/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para obtener más información sobre las fuentes en presentaciones, vea [Fuentes de PowerPoint](/slides/es/net/powerpoint-fonts/).
{{% /alert %}}

## **Copiar o aplicar un tema**

Existen dos flujos de trabajo habituales, y resuelven problemas diferentes.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el máster de origen en la presentación de destino con [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/addclone/), y luego clone la diapositiva con [ISlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/) y el máster clonado. Esto lleva el máster, sus diseños y el tema asociado juntos.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse idéntica en el destino. Simplemente clonar contenido sobre un máster de destino no relacionado puede cambiar los colores, tipografías, fondos y efectos impulsados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su máster y diseño actuales, inicialice una sustitución a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/initfontschemefrom/) y [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copian los tres componentes principales del tema en la sustitución.

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

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la sustitución local y volver a los valores heredados, llame a [OverrideTheme.Clear](https://reference.aspose.com/slides/es/net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar una sustitución de tema a un diseño**

Una sustitución a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia sustitución. Los mismos métodos de inicialización pueden usarse a través del [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/net/aspose.slides.theme/layoutslidethememanager/) del diseño:

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

Use un tema a nivel de máster o presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una sustitución de diseño cuando una familia de diseños necesite un estilo diferente, y una sustitución de diapositiva solo para excepciones reales. Las sustituciones excesivas a nivel de diapositiva dificultan predecir los cambios globales posteriores del tema.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint puede presentar más opciones de fondo en su interfaz que la cantidad de definiciones de relleno almacenadas físicamente en esta colección, porque la interfaz puede combinar rellenos del tema con colores del tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.StyleIndex](https://reference.aspose.com/slides/es/net/aspose.slides/background/styleindex/) actual. `StyleIndex` usa `0` para indicar que no hay relleno temático; los valores positivos son referencias a estilos de fondo del tema. Esto difiere del índice de la colección .NET, donde `[0]` representa el primer elemento almacenado. No asuma que todas las presentaciones contengan el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el número de rellenos de fondo disponibles, asigna una referencia de fondo temático al primer máster y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el máster y de cualquier sustitución de fondo en el diseño o la diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del máster puede no afectar a esa diapositiva. Use [Background.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/background/geteffective/) cuando necesite conocer el fondo final después de aplicada la herencia.

{{% alert color="warning" title="Warning" %}}
No trate `StyleIndex` como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y suponer que tendrá la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatear fondos directamente y gestionar la herencia de fondos, vea [Fondo de la presentación](/slides/es/net/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de [FillStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/linestyles/) y [EffectStyles](https://reference.aspose.com/slides/es/net/aspose.slides.theme/formatscheme/effectstyles/). Los temas típicos de Office suelen contener tres entradas de estilo principales que corresponden visualmente a formatos sutiles, moderados e intensos, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en C#, el índice de la colección es cero basado: `[0]` es el primer estilo almacenado y `[2]` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/es/net/aspose.slides/ishapestyle/). Modificar un estilo de tema afecta a las formas que referencian ese estilo del tema; las formas con formato directo pueden permanecer sin cambios.

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

Para las formas que hacen referencia a esas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y de si el formato directo sobrescribe al tema.

![Estilos de efecto del tema tras cambiar línea, relleno y sombra](presentation-design_11.png)

## **Leer valores efectivos del tema**

Los objetos de tema en bruto le indican qué está definido en un nivel concreto. Los valores efectivos le indican qué usa realmente una diapositiva o forma después de resolver la herencia y las sustituciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/es/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Para un fondo, use [Background.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/background/geteffective/), y para un relleno, use [FillFormat.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/fillformat/geteffective/).

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

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/mastertheme/), puede pasar por alto una sustitución de máster, diseño, diapositiva o forma que cambie la apariencia final.

## **FAQ**

**¿Puedo aplicar un tema a una única diapositiva sin cambiar el máster?**

Sí. Use el [SlideThemeManager](https://reference.aspose.com/slides/es/net/aspose.slides.theme/slidethememanager/) de la diapositiva e inicialice su tema de sustitución. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia original, clone el máster de origen en el destino y clone la diapositiva con ese máster usando [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/addclone/) y [ISlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/). Esto mantiene juntos el máster, los diseños y el tema.

**¿Cómo puedo ver los valores efectivos después de la herencia y las sustituciones?**

Use [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/es/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) para un tema de diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato como [Background.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/background/geteffective/) y [FillFormat.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/fillformat/geteffective/). Estas API devuelven los valores resueltos tras aplicar la herencia y las sustituciones.