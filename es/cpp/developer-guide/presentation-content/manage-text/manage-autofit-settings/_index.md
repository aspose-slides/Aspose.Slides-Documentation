---
title: Mejora tus presentaciones con AutoFit en C++
linktitle: Configuración de Autofit
type: docs
weight: 30
url: /es/cpp/manage-autofit-settings/
keywords:
- cuadro de texto
- ajuste automático
- no ajustar automáticamente
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo administrar la configuración de AutoFit en Aspose.Slides para C++ para optimizar la visualización del texto en sus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

De forma predeterminada, cuando añades un cuadro de texto, Microsoft PowerPoint utiliza la configuración **Resize shape to fix text** para el cuadro de texto: redimensiona automáticamente el cuadro de texto para asegurar que su contenido siempre quepa.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementa su altura—para permitir que contenga más texto.  
* Cuando el texto del cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar el espacio sobrante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ ofrece opciones similares—algunos métodos bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)—que le permiten controlar el comportamiento de autofit para los cuadros de texto en presentaciones.

## **Resize a Shape to Fit Text**

Si desea que el texto de un cuadro siempre quepa en ese cuadro después de modificarlo, debe usar la opción **Resize shape to fix text**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código C++ muestra cómo especificar que un texto debe ajustarse siempre a su cuadro en una presentación de PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para garantizar que todo el texto quepa. Si el texto se vuelve más corto, ocurrirá lo contrario.

## **Do Not Autofit**

Si desea que un cuadro de texto o una forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debe usar la opción **Do not Autofit**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código C++ muestra cómo especificar que un cuadro de texto debe conservar siempre sus dimensiones en una presentación de PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


Cuando el texto se vuelve demasiado largo para su cuadro, se desborda.

## **Shrink Text on Overflow**

Si un texto se vuelve demasiado largo para su cuadro, mediante la opción **Shrink text on overflow** puede especificar que el tamaño y el espaciado del texto se reduzcan para que quepan en el cuadro. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código C++ muestra cómo especificar que un texto debe encogerse al desbordarse en una presentación de PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Info" color="info" %}}
Cuando se usa la opción **Shrink text on overflow**, el ajuste se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.
{{% /alert %}}

## **Wrap Text**

Si desea que el texto dentro de una forma se ajuste dentro de esa forma cuando el texto supera el borde de la forma (solo en ancho), debe usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debe establecer la propiedad [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `true`.

Este código C++ muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}}
Si establece la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma supera el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.
{{% /alert %}}

## **FAQ**

**¿Los márgenes internos del marco de texto afectan a AutoFit?**

Sí. El relleno (márgenes internos) reduce el área utilizable para el texto, por lo que AutoFit se activará antes, reduciendo la fuente o redimensionando la forma más pronto. Revise y ajuste los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y blandos?**

Los saltos forzados permanecen, y AutoFit adapta el tamaño de fuente y el espaciado alrededor de ellos. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit debe encoger el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes cambia el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuentes, vuelva a comprobar las diapositivas.