---
title: Gestionar temas de presentación en C++
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/cpp/presentation-theme/
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
- C++
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para C++ para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos compatibles con el tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, por lo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_mastertheme/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un maestro puede anular el tema de la presentación mediante [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), mientras que una diapositiva de diseño o una diapositiva individual pueden usar [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). En la práctica, el tema efectivo para una diapositiva se resuelve a través de esta cadena de herencia: tema de presentación, anulación del maestro, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y efectos, y leer valores efectivos después de que la herencia y las anulaciones se hayan resuelto.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/) expone los métodos [get_ColorScheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) y [get_FormatScheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspeccionar estas colecciones antes de modificarlas resulta especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

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

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y use el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan estar presentes anulaciones de diseño o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos compatibles con el tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [IColorScheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/icolorscheme/) del tema, todos los objetos que aún referencian ese color de tema se resuelven contra el nuevo valor. Los objetos que usan un color RGB directo no se modifican con una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `Accent4`, cambia el color `Accent4` del tema a rojo, guarda la presentación, la vuelve a abrir e imprime el color de relleno efectivo:

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

Como el rectángulo sigue vinculado a `Accent4`, su color visible pasa a ser rojo después de cambiar el tema. Si sustituye el color de esquema por un color directo en la forma, los cambios posteriores de `Accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema mediante transformaciones de color. Aspose.Slides expone estas transformaciones a través de [ColorTransformOperation](https://reference.aspose.com/slides/es/cpp/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y más oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.  
**2** - Variantes más claras y más oscuras producidas a partir de los colores principales del tema.

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

### **Mapear valores `SchemeColor` a ranuras `IColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` y `Background2`, mientras que [IColorScheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/icolorscheme/) expone las mismas ranuras del tema como `Dark1`, `Light1`, `Dark2` y `Light2`. La asignación es fija:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se convierten dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para encabezados y un conjunto de fuentes secundario para el cuerpo del texto. Los métodos [FontScheme::get_Major()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/fontscheme/get_major/) y [FontScheme::get_Minor()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/fontscheme/get_minor/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo Latin (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado Latin (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo East Asian (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado East Asian (Major East Asian Font)

El siguiente ejemplo crea un encabezado que usa la fuente Latin principal del tema y una línea de cuerpo que usa la fuente Latin secundaria del tema. A continuación cambia las fuentes del tema y guarda el resultado:

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

El encabezado sigue la fuente principal y el texto del cuerpo sigue la fuente secundaria. El texto que tiene un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando cambie el esquema de fuentes del tema.

Las colecciones de fuentes principales y secundarias también pueden contener mapeos de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, añadir, sustituir o eliminar estos mapeos, consulte [Script-Specific Theme Fonts](/slides/es/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para obtener más información sobre fuentes en presentaciones, consulte [PowerPoint Fonts](/slides/es/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Copiar o aplicar un tema**

Los flujos de trabajo siguientes resuelven diferentes problemas relacionados con temas.

### **Aplicar un tema externo a diapositivas dependientes de un maestro**

Utilice [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) cuando tenga un archivo de tema de PowerPoint (`.thmx`) y desee volver a aplicar el estilo a cada diapositiva que dependa de un maestro concreto. Seleccione el maestro de la colección [Presentation::get_Masters](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/), y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea una nueva diapositiva maestra basada en el maestro seleccionado.  
2. Aplica el tema externo a la nueva maestra.  
3. Asigna la nueva maestra a todas las diapositivas que anteriormente dependían del maestro seleccionado.  
4. Devuelve el [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/) recién creado.

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer maestro y guarda la presentación:

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

Un tema inválido, corrupto o no admitido puede provocar una [PptxException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxexception/) o una de sus subclases relacionadas con el formato. Valide las rutas proporcionadas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado correctamente.

Solo se reasignan las diapositivas que dependían del maestro seleccionado. Las diapositivas asociadas a otros maestros conservan sus maestros y temas existentes. Los colores, fuentes, rellenos, líneas, fondos y efectos compatibles con el tema se resuelven contra el tema externo. Los colores, fuentes, rellenos y demás formato asignado directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y de diapositiva también pueden prevalecer sobre los valores heredados del nuevo maestro.

El tema puede hacer referencia a fuentes que no están disponibles en el entorno de ejecución. Para lograr una visualización y exportación coherentes, instale las fuentes requeridas, proporciónelas mediante [fuentes personalizadas](/slides/es/cpp/custom-font/), o configure la [sustitución de fuentes](/slides/es/cpp/font-substitution/).

Este es un flujo de trabajo directo a nivel de maestro: el método acepta la ruta a un archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o de diseño.

### **Aplicar diferentes temas externos en una presentación con varios maestros**

Cuando el maestro pertinente no se conoce de antemano, obténgalo a partir de una diapositiva representativa mediante [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/get_layoutslide/) y [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_masterslide/). Guarde las referencias originales de los maestros antes de aplicar cualquier tema, ya que cada llamada crea otro maestro en la presentación.

El siguiente ejemplo usa diapositivas de dos secciones para localizar sus maestros y aplica un tema externo diferente a cada grupo:

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

La primera llamada afecta solo a las diapositivas que dependían de `firstGroupMaster`, y la segunda llamada afecta solo a las que dependían de `secondGroupMaster`. Las diapositivas pertenecientes a cualquier otro maestro no se restilan.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro de origen en la presentación destino con [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/addclone/), luego clone la diapositiva con [ISlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) y el maestro clonado. Esto lleva el maestro, sus diseños y el tema asociado juntos.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse idéntica en el destino. Simplemente clonar el contenido sobre un maestro de destino no relacionado puede cambiar colores, fuentes, fondos y efectos definidos por el tema.

### **Aplicar valores del tema a una diapositiva existente**

Si la diapositiva objetivo debe permanecer en su maestro y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) y [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copian los tres componentes principales del tema en la anulación.

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

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través del [IOverrideThemeManager](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ioverridethememanager/) del diseño:

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

Utilice un tema a nivel de maestro o de presentación cuando muchos diseños y diapositivas deban compartir el mismo diseño base, una anulación de diseño cuando una familia de diseños necesite un estilo distinto, y una anulación de diapositiva solo para excepciones reales. Un exceso de anulaciones a nivel de diapositiva dificulta predecir los cambios globales posteriores del tema.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint puede presentar más opciones de fondo en su interfaz que el número de definiciones de relleno almacenadas físicamente en esta colección, porque la UI puede combinar rellenos del tema con colores del tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el índice actual mediante [Background::get_StyleIndex()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` usa `0` para indicar que no hay relleno tematizado; los valores positivos son referencias a estilos de fondo del tema. Esto difiere de indexar directamente una colección C++ con `idx_get(0)`, donde `0` representa el primer elemento almacenado. No asuma que todas las presentaciones contienen el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa del recuento de rellenos de fondo disponibles, asigna una referencia de fondo tematizado al primer maestro y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el maestro y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Use [Background::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/geteffective/) cuando necesite conocer el fondo final tras aplicar la herencia.

{{% alert color="warning" title="Warning" %}}
No trate `StyleIndex` como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y suponer que tendrá la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formateo directo de fondo y herencia de fondo, consulte [Presentation Background](/slides/es/cpp/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones independientes de [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_linestyles/) y [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Los temas típicos de Office suelen contener tres entradas principales que corresponden visualmente a formato sutil, moderado e intenso, pero el código debe inspeccionar cada colección en lugar de asumir un número fijo.

![Efectos de tema sutil, moderado e intenso aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en C++, el índice de la colección es basado en cero: `idx_get(0)` es el primer estilo almacenado y `idx_get(2)` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapestyle/). Modificar un estilo del tema afecta a las formas que hacen referencia a ese estilo; las formas con formato directo pueden permanecer sin cambios.

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

Para las formas que referencian estas ranuras, el primer estilo de línea del tema pasa a ser rojo, el tercer estilo de relleno del tema pasa a ser verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencie cada forma y de si el formato directo sobrescribe el tema.

![Estilos de efecto del tema después de cambiar línea, relleno y sombra](presentation-design_11.png)

## **Leer valores efectivos del tema**

Los objetos de tema sin procesar indican lo que está definido en un nivel concreto. Los valores efectivos indican lo que una diapositiva o forma utiliza realmente después de que la herencia y las anulaciones locales se resuelvan. Para una diapositiva, llame a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Para un fondo, use [Background::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/geteffective/), y para un relleno, use [FillFormat::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/geteffective/).

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

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_mastertheme/), puede pasar por alto una anulación de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **FAQ**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reasigna solo las diapositivas que dependen del maestro seleccionado. Las diapositivas que usan otros maestros conservan sus temas existentes.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Utilice el [IOverrideThemeManager](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ioverridethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de transferir un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia de origen, clone el maestro de origen en el destino y clone la diapositiva con ese maestro mediante [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/addclone/) y [ISlideCollection::AddClone()](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/). Así se mantiene el maestro, los diseños y el tema juntos.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) para una diapositiva o tema de diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/background/geteffective/) y [FillFormat::GetEffective()](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/geteffective/). Estas API devuelven los valores resueltos tras aplicar la herencia y las anulaciones.