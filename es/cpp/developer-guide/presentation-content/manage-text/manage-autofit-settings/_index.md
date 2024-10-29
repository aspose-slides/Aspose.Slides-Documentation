---
title: Administrar la configuración de autofit
type: docs
weight: 30
url: /es/cpp/manage-autofit-settings/
keywords: "Cuadro de texto, Autofit, presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Configurar la configuración de autofit para cuadros de texto en PowerPoint en C++"
---

Por defecto, cuando agregas un cuadro de texto, Microsoft PowerPoint utiliza la configuración de **Redimensionar forma para ajustar el texto** para el cuadro de texto; redimensiona automáticamente el cuadro de texto para asegurar que su texto siempre quepa dentro de él.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto; aumenta su altura para permitir que contenga más texto.
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto; disminuye su altura para eliminar espacio redundante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto:

* **No ajustar automáticamente**
* **Reducir texto en desbordamiento**
* **Redimensionar forma para ajustar el texto**
* **Ajustar texto en forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides para C++ proporciona opciones similares; algunos métodos bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) que te permiten controlar el comportamiento de autofit para cuadros de texto en presentaciones.

## **Redimensionar forma para ajustar el texto**

Si quieres que el texto en un cuadro siempre quepa en ese cuadro después de realizar cambios en el texto, debes usar la opción **Redimensionar forma para ajustar el texto**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código C++ te muestra cómo especificar que un texto debe siempre caber en su cuadro en una presentación de PowerPoint:

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

Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumento de altura) para asegurar que todo el texto quepa dentro de él. Si el texto se vuelve más corto, ocurre lo contrario.

## **No ajustar automáticamente**

Si deseas que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debes usar la opción **No ajustar automáticamente**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código C++ te muestra cómo especificar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:

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

## **Reducir texto en desbordamiento**

Si un texto se vuelve demasiado largo para su cuadro, a través de la opción **Reducir texto en desbordamiento**, puedes especificar que el tamaño y el espaciado del texto deben reducirse para hacer que quepa dentro de su cuadro. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código C++ te muestra cómo especificar que un texto debe ser reducido en desbordamiento en una presentación de PowerPoint:

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

{{% alert title="Información" color="info" %}}

Cuando se utiliza la opción **Reducir texto en desbordamiento**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.

{{% /alert %}}

## **Ajustar texto**

Si deseas que el texto en una forma se ajuste dentro de esa forma cuando el texto sobrepasa el borde de la forma (solo ancho), debes usar el parámetro **Ajustar texto en forma**. Para especificar esta configuración, debes establecer la propiedad [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) en `true`.

Este código C++ te muestra cómo usar la configuración de Ajustar texto en una presentación de PowerPoint:

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

{{% alert title="Nota" color="warning" %}}

Si estableces la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.

{{% /alert %}}