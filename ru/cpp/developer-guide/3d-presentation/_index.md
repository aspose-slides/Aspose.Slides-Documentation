---
title: Создание 3D презентаций на C++
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D выдавливание
- 3D градиент
- 3D текст
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Создавайте интерактивные 3D презентации на C++ с помощью Aspose.Slides без усилий. Быстро экспортируйте в форматы PowerPoint и OpenDocument для универсального использования."
---

## **Обзор**
С версии Aspose.Slides 20.9 стало возможно создавать и изменять 3D‑модели PowerPoint. Это можно выполнить, применив к двумерным фигурам набор 3D‑эффектов. Создав вид камеры на фигуре, вы можете вращать её вокруг оси. Создайте выдавливание или глубину фигуры, что преобразует её из 2D‑фигуры в 3D‑модель. Установка светового эффекта на 3D‑фигуру или изменение материалов делает её более живой. Изменение цветов 3D‑моделей на 3D‑градиент, корректировка контуров фигур, добавление фаски придаёт 3D‑модели объём. Все 3D‑эффекты могут быть применены как к 3D‑моделям PowerPoint, так и к текстам.

Рассмотрим первый пример создания 3D‑моделей, который включает все перечисленные выше функции:
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Matte);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Blue());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();

presentation->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);
presentation->Dispose();
```


Получившаяся 3D‑модель PowerPoint:

![todo:image_alt_text](img_01_01.png)

## **3D вращение**
В PowerPoint вращение фигур доступно через:

![todo:image_alt_text](img_02_01.png)

Чтобы вращать 3D‑модели PowerPoint, необходимо создать вид камеры на фигуре. Это делается с помощью метода [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4). Метод вращения вызывается из класса камеры, как если бы вы вращали камеру. Фактически, когда вы вращаете камеру относительно фигуры, вы вращаете фигуру в 3D‑пространстве.
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... установить другие параметры 3D сцены

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


## **3D глубина и выдавливание**
Чтобы добавить глубину и выдавливание к 3D‑модели PowerPoint, используйте метод [IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295). Для изменения цвета выдавливания используйте метод [IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e):
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... установить другие параметры 3D сцены

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


Меню глубины в PowerPoint:

![todo:image_alt_text](img_02_02.png)


## **3D градиент**
Создание 3D‑градиента на 3D‑модели PowerPoint может быть выполнено с помощью метода [Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58):
``` cpp
using namespace Aspose::Slides;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0, System::Drawing::Color::get_Blue());
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, System::Drawing::Color::get_Orange());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_DarkOrange());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


3D‑модель с 3D‑градиентом:

![todo:image_alt_text](img_02_03.png)
  
Чтобы создать градиент изображения, используйте метод [Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb):
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. настройка 3D: Camera, LightRig, Extrusion

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


3D‑модель с градиентом изображения:

![todo:image_alt_text](img_02_04.png)

## **3D текст (WordArt)**
Чтобы применить вращение, выдавливание, освещение, градиент к тексту и сделать его 3D‑текстом (WordArt), необходимо обратиться к методу [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30):
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
// настройка эффекта трансформации WordArt "Arch Up"
textFrameFormat->set_Transform(TextShapeType::ArchUp);

textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text3d.png");
thumbnail->Dispose();

presentation->Save(u"text3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Пример 3D‑текста (WordArt):

![todo:image_alt_text](img_02_05.png)

## **Часто задаваемые вопросы**

**Будут ли 3D‑эффекты сохранены при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides отображает 3D‑эффекты при экспорте в поддерживаемые форматы ([изображения](/slides/ru/cpp/convert-powerpoint-to-png/), [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), и т.д.).

**Могу ли я получить «эффективные» (окончательные) значения 3D‑параметров, учитывающие темы, наследование и т.п.?**

Да. Slides предоставляет API для [чтения эффективных значений](/slides/ru/cpp/shape-effective-properties/) (в том числе для 3D — освещение, фаски и т.д.), что позволяет увидеть окончательные применённые настройки.

**Работают ли 3D‑эффекты при конвертации презентации в видео?**

Да. При [генерации кадров для видео](/slides/ru/cpp/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как и для [экспортированных изображений](/slides/ru/cpp/convert-powerpoint-to-png/).