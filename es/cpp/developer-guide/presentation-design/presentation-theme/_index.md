---
title: Administrar temas de presentación en C++
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/cpp/presentation-theme/
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
- C++
- Aspose.Slides
description: "Temas maestros de presentación en Aspose.Slides para C++ para crear, personalizar y convertir archivos PowerPoint con una identidad de marca coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos sensibles al tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, de modo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_mastertheme/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un master puede anular el tema de la presentación mediante [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), mientras que un diseño o una diapositiva individual pueden usar [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). En la práctica, el tema efectivo para una diapositiva se resuelve mediante esta cadena de herencia: tema de la presentación, anulación del master, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y efectos, y leer valores efectivos después de que se hayan resuelto la herencia y las anulaciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/) expone los métodos del tema [get_ColorScheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) y [get_FormatScheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspeccionar estas colecciones antes de modificarlas es especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Si un archivo utiliza varios masters, no suponga que cada diapositiva tiene el mismo tema efectivo. Inspeccione el master asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones en el diseño o en la diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos sensibles al tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/schemecolor/). Cuando cambie la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/icolorscheme/) del tema, todos los objetos que todavía referencien ese color de tema se resolverán con el nuevo valor. Los objetos que usan un color RGB directo no se modifican con una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que utiliza `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir e imprime el color de relleno efectivo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Como el rectángulo sigue vinculado a `Accent4`, su color visible pasa a rojo tras el cambio de tema. Si sustituye el color de esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color de tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante [ColorTransformOperation](https://reference.aspose.com/slides/es/cpp/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.

**2** - Variantes más claras y más oscuras generadas a partir de los colores principales del tema.

El siguiente ejemplo crea seis rectángulos basados en `Accent4`, aplica transformaciones de luminancia a cinco de ellos y guarda el resultado:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Estas variantes siguen basadas en el color del tema. Si `Accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `Accent4`.

### **Mapear valores de `SchemeColor` a ranuras de `IColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/schemecolor/) utiliza `Text1`, `Background1`, `Text2` y `Background2`, mientras que [IColorScheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para encabezados y un conjunto secundario para el cuerpo del texto. Los métodos [FontScheme::get_Major()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/fontscheme/get_major/) y [FontScheme::get_Minor()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/fontscheme/get_minor/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado Latin (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo East Asian (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado East Asian (Major East Asian Font)

El siguiente ejemplo crea un encabezado que utiliza la fuente de tema Latin mayor y una línea de cuerpo que utiliza la fuente de tema Latin menor. Luego cambia las fuentes del tema y guarda el resultado:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

Las colecciones de fuentes mayor y menor también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, sustituir o eliminar estas asignaciones, consulte [Fuentes de tema específicas de script](/slides/es/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Para obtener más información sobre fuentes en presentaciones, vea [Fuentes de PowerPoint](/slides/es/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Copiar o aplicar un tema**

Los flujos de trabajo siguientes resuelven diferentes problemas relacionados con temas.

### **Aplicar un tema externo a las diapositivas dependientes de un master**

Use [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) cuando disponga de un archivo de tema de PowerPoint (`.thmx`) y desee reestilizar cada diapositiva que dependa de un master concreto. Seleccione el master de la colección [Presentation::get_Masters](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea una nueva diapositiva master basándose en el master seleccionado.
1. Aplica el tema externo al nuevo master.
1. Asigna el nuevo master a todas las diapositivas que previamente dependían del master seleccionado.
1. Devuelve el nuevo [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/).

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer master y guarda la presentación:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Un tema inválido, dañado o no compatible puede provocar una [PptxException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxexception/) o una de sus subclases relacionadas con el formato. Valide las rutas proporcionadas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado con éxito.

Solo se reasignan las diapositivas que dependían del master seleccionado. Las diapositivas asociadas a otros masters conservan sus masters y temas actuales. Los colores, fuentes, rellenos, líneas, fondos y efectos sensibles al tema se resuelven contra el tema externo. Los colores, fuentes, rellenos y otro formato asignado directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y diapositiva también pueden prevalecer sobre los valores heredados del nuevo master.

El tema puede referenciar fuentes que no estén disponibles en el entorno de ejecución. Para un renderizado y exportación coherentes, instale las fuentes requeridas, proporciónelas mediante [fuentes personalizadas](/slides/es/cpp/custom-font/), o configure la [sustitución de fuentes](/slides/es/cpp/font-substitution/).

Este es un flujo de trabajo directo a nivel de master: el método acepta una ruta de archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o diseño.

### **Aplicar diferentes temas externos en una presentación con varios masters**

Cuando el master relevante no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/get_layoutslide/) y [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_masterslide/). Guarde las referencias originales de los masters antes de aplicar cualquier tema, porque cada llamada crea otro master en la presentación.

El siguiente ejemplo usa diapositivas de dos secciones para localizar sus masters y aplica un tema externo diferente a cada grupo:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

La primera llamada afecta solo a las diapositivas que dependían de `firstGroupMaster`, y la segunda llamada afecta solo a las que dependían de `secondGroupMaster`. Las diapositivas pertenecientes a cualquier otro master no se reestilizan.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el master de origen en la presentación de destino con [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/addclone/), y luego clone la diapositiva con [ISlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) y el master clonado. Esto lleva el master, sus diseños y el tema asociado juntos.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse idéntica en el destino. Simplemente clonar contenido sobre un master de destino no relacionado puede alterar colores, fuentes, fondos y efectos guiados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su master y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) y [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copian los tres componentes principales del tema en la anulación.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme::Clear()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/clear/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, salvo que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través del [IOverrideThemeManager](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ioverridethememanager/) del diseño:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Utilice un tema a nivel de master o presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo diferente, y una anulación de diapositiva solo para excepciones reales. Un exceso de anulaciones a nivel de diapositiva dificulta predecir los cambios globales de tema posteriores.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint puede presentar más opciones de fondo en su UI que el número de definiciones de relleno almacenadas físicamente en esta colección, ya que la UI puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background::get_StyleIndex()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/get_styleindex/) actual. `StyleIndex` usa `0` para indicar que no hay relleno temático; los valores positivos son referencias a estilos de fondo temáticos. Esto difiere de indexar directamente una colección C++ con `idx_get(0)`, donde `0` significa el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa del número de estilos de relleno de fondo disponibles, asigna una referencia de fondo temático al primer master y guarda la presentación:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

El resultado visible depende de la entrada de tema referenciada por el master y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del master puede no afectar a esa diapositiva. Use [Background::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/geteffective/) cuando necesite conocer el fondo final tras aplicar la herencia.

{{% alert color="warning" title="Warning" %}}

No trate `StyleIndex` como un índice de colección basado en cero. Además, evite codificar en duro un número de estilo tomado de un archivo y suponer que tendrá la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Para formateo directo de fondos y herencia de fondos, consulte [Fondo de presentación](/slides/es/cpp/presentation-background/).

{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_linestyles/) y [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Los temas típicos de Office suelen contener tres entradas principales que corresponden visualmente a formateos sutil, moderado e intenso, pero el código debe inspeccionar cada colección en lugar de suponer un recuento fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en C++, el índice de la colección comienza en cero: `idx_get(0)` es el primer estilo almacenado y `idx_get(2)` el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto mediante [IShapeStyle](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapestyle/). Modificar un estilo de tema afecta a las formas que referencian ese estilo; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existan las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra externa en el tercer estilo de efecto y guarda el resultado:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Para las formas que referencian estas ranuras, el primer estilo de línea del tema pasa a rojo, el tercer estilo de relleno del tema pasa a un verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultad visual exacto sigue dependiendo de qué ranuras de estilo referencie cada forma y de si el formato directo anula el tema.

![Estilos de efecto del tema después de cambiar línea, relleno y sombra](presentation-design_11.png)

## **Determinar si un relleno sólido efectivo usa un color de tema**

Un relleno puede estar almacenado directamente en un objeto o heredado de un párrafo, diseño, master, estilo de tema u otro nivel de formato. Llame a [IFillFormat::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformat/geteffective/) para resolver esa jerarquía en un objeto inmutable [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/). Primero verifique [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Solo cuando sea `FillType::Solid` debe leer las propiedades del relleno sólido.

Para un relleno sólido, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) devuelve el valor RGB final renderizado tras la herencia, la búsqueda en el tema y la aplicación de transformaciones de color. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) devuelve la ranura lógica de [SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/schemecolor/) correspondiente, como `Text1` o `Accent6`. Un valor de `SchemeColor::NotDefined` indica que el relleno sólido efectivo no se basa en un color de esquema. En un flujo de trabajo donde los rellenos son colores de tema o colores RGB directos, este valor identifica un relleno RGB directo.

No utilice solo el valor local de [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/icolorformat/get_schemecolor/) para clasificar un relleno. Por ejemplo, una porción de texto puede no tener un color de esquema definido localmente, por lo que su valor local es `NotDefined`, mientras que su relleno efectivo hereda un color de tema y se resuelve a `Text1` o `Accent6`. Por el contrario, `get_SolidFillSchemeColor` indica qué ranura lógica del tema produjo el color efectivo, pero no indica si esa ranura proviene del objeto, del párrafo, del diseño, del master o de otro nivel de la jerarquía de formato.

El siguiente ejemplo carga una presentación, audita los rellenos de forma y los rellenos de porciones de texto, imprime cada valor RGB final y el color de esquema asociado, y marca los rellenos sólidos que no seguirán los cambios de color del tema:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

La rama `NotDefined` proporciona una lista de auditoría de rellenos sólidos que no responderán a cambios en las ranuras de color del tema. Revise esos objetos cuando una presentación deba ajustarse a una nueva paleta de marca. El valor RGB informado sigue mostrando la apariencia actual, mientras que el valor de esquema explica si esa apariencia está vinculada al tema.

Los objetos de formato efectivo son instantáneas. Después de cambiar el tema de la presentación, una anulación de tema o cualquier formato heredado, llame a `GetEffective` nuevamente y lea un nuevo objeto `IFillFormatEffectiveData` antes de comparar o informar colores.

## **Leer valores efectivos del tema**

Los objetos de tema sin procesar indican lo que está definido en un nivel concreto. Los valores efectivos indican lo que una diapositiva o forma usa realmente después de que se resuelvan la herencia y las anulaciones locales. Para una diapositiva, llame a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Para un fondo, use [Background::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/geteffective/), y para un relleno, use [FillFormat::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/geteffective/).

El siguiente ejemplo lee el tema efectivo, el fondo y el primer relleno de forma de una diapositiva:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_mastertheme/), puede perder una anulación de master, diseño, diapositiva o forma que altere la apariencia final.

## **FAQ**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reasigna solo las diapositivas que dependen del master seleccionado. Las diapositivas que usan otros masters conservan sus temas actuales.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el master?**

Sí. Utilice el [IOverrideThemeManager](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ioverridethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia original, clone el master de origen en el destino y clone la diapositiva con ese master usando [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/addclone/) y [ISlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/). Esto mantiene el master, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) para un tema de diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato como [Background::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/geteffective/) y [FillFormat::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/geteffective/). Estas API devuelven los valores resueltos tras aplicar la herencia y las anulaciones.