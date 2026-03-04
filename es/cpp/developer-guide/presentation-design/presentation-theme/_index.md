---
title: Gestionar temas de presentación en C++
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/cpp/presentation-theme/
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
- C++
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para C++ para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
Un tema de presentación define las propiedades de los elementos de diseño. Cuando seleccionas un tema de presentación, estás eligiendo esencialmente un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema comprende colores, [fuentes](/slides/es/cpp/powerpoint-fonts/), [estilos de fondo](/slides/es/cpp/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar el color del tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, los cambias aplicando nuevos colores al tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Este código C++ te muestra cómo cambiar el color de acento de un tema:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Puedes determinar el valor efectivo del color resultante de esta manera:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Para demostrar aún más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

El nuevo color se aplica automáticamente a ambos elementos.

### **Establecer el color del tema a partir de una paleta adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Entonces puedes establecer y obtener esos colores del tema.

![additional-palette-colors](additional-palette-colors.png)

**1**- Colores principales del tema

**2** - Colores de la paleta adicional.

Este código C++ muestra una operación en la que los colores de la paleta adicional se obtienen del color principal del tema y luego se usan en formas:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Acento 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Acento 4, más claro 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Acento 4, más claro 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Acento 4, más claro 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Acento 4, más oscuro 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Acento 4, más oscuro 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Mapear `SchemeColor` a colores `IColorScheme`**

Cuando trabajas con [SchemeColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/schemecolor/), puedes notar que contiene los siguientes valores de color del tema:

`Background1`, `Background2`, `Text1` y `Text2`.

Sin embargo, `Presentation::get_MasterTheme()::get_ColorScheme()` devuelve [IColorScheme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/icolorscheme/), que expone los colores correspondientes como:

`Dark1`, `Dark2`, `Light1` y `Light2`.

Esta diferencia es solo de denominación. Estos valores se refieren a los mismos espacios de colores del tema y el mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

No hay conversión dinámica entre `Text`/`Background` y `Dark`/`Light`. Son simplemente nombres alternativos para los mismos colores del tema.

Esta diferencia de nomenclatura proviene de la terminología de Microsoft Office. Las versiones antiguas de Office utilizaban `Dark 1`, `Light 1`, `Dark 2` y `Light 2`, mientras que las versiones más recientes de la interfaz muestran los mismos espacios como `Text 1`, `Background 1`, `Text 2` y `Background 2`.

## **Cambiar la fuente del tema**

Para permitirte seleccionar fuentes para los temas y otros fines, Aspose.Slides usa estos identificadores especiales (similares a los que se usan en PowerPoint):

* **+mn-lt** - Fuente del cuerpo Latin (Minor Latin Font)
* **+mj-lt** - Fuente del encabezado Latin (Major Latin Font)
* **+mn-ea** - Fuente del cuerpo East Asian (Minor East Asian Font)
* **+mj-ea** - Fuente del cuerpo East Asian (Major East Asian Font)

Este código C++ te muestra cómo asignar la fuente Latin a un elemento del tema:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Este código C++ te muestra cómo cambiar la fuente del tema de la presentación:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="CONSEJO" %}} 
Puede que quieras consultar [PowerPoint fonts](/slides/es/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Cambiar el estilo de fondo del tema**

De forma predeterminada, la aplicación PowerPoint proporciona 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica.

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación PowerPoint, puedes ejecutar este código C++ para averiguar el número de fondos predefinidos en la presentación:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Usando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) de la clase [FormatScheme](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.theme.i_format_scheme/), puedes añadir o acceder al estilo de fondo en un tema de PowerPoint. 
{{% /alert %}}

Este código C++ muestra cómo establecer el fondo para una presentación:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Guía de índices**: 0 se usa para sin relleno. El índice comienza en 1.

{{% alert color="primary" title="CONSEJO" %}} 
Puede que quieras consultar [PowerPoint Background](/slides/es/cpp/presentation-background/).
{{% /alert %}}

## **Cambiar el efecto del tema**

Un tema de PowerPoint suele contener 3 valores para cada matriz de estilo. Esas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando se aplican los efectos a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) de la clase [FormatScheme](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.theme.i_format_scheme/) puedes cambiar los elementos de un tema (incluso con más flexibilidad que las opciones en PowerPoint).

Este código C++ muestra cómo cambiar un efecto del tema alterando partes de los elementos:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Aspose.Slides admite sobrescrituras de tema a nivel de diapositiva, por lo que puedes aplicar un tema local solo a esa diapositiva mientras mantienes intacto el tema maestro (a través de [SlideThemeManager](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/slidethememanager/)).

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

[Clone slides](/slides/es/cpp/clone-slides/) junto con su maestro en la presentación destino. Esto conserva el maestro original, los diseños y el tema asociado, de modo que la apariencia permanezca coherente.

**¿Cómo puedo ver los valores "efectivos" después de toda la herencia y sobrescrituras?**

Utiliza las vistas ["effective"](/slides/es/cpp/shape-effective-properties/) de la API para tema/color/fuente/efecto. Estas devuelven las propiedades resueltas y finales tras aplicar el maestro y cualquier sobrescritura local.