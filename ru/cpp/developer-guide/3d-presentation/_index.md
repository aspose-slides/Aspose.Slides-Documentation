---
title: 3D Презентация
type: docs
weight: 232
url: /ru/cpp/3d-presentation/
---

## Общий обзор
Начиная с версии Aspose.Slides 20.9, стало возможным создавать и изменять 3D модели PowerPoint. Это можно сделать, добавив к 2D формам набор 3D эффектов. Создавая вид камеры на форме, вы можете поворачивать её по оси. Создайте экструдирование или глубину на форме, что преобразует форму из 2D в 3D модель. Установка светового эффекта на 3D форме или изменение материалов может сделать её более живой. Изменение цветов 3D моделей на градиент 3D, модификация контура форм, добавление фаски придаёт 3D модели большую объемность. Все 3D эффекты могут быть применены как к 3D моделям PowerPoint, так и к текстам.

Давайте рассмотрим первый пример создания 3D моделей, который включает все вышеупомянутые функции:
``` cpp
{
    using namespace Aspose::Slides;

    auto pres = System::MakeObject<Presentation>();
    auto slide = pres->get_Slide(0);
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

    slide->GetImage(2.0f, 2.0f)->Save(u"sample_3d.png");
    pres->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);
}
```

Полученная 3D модель PowerPoint:

![todo:image_alt_text](img_01_01.png)

## 3D Поворот
В PowerPoint вращение формы доступно через:

![todo:image_alt_text](img_02_01.png)

Чтобы повернуть 3D модели PowerPoint, необходимо создать вид камеры на форме. Это делается с помощью метода [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4). Метод вращения вызывается из класса камеры, как если бы вы вращали камеру. На самом деле, когда вы вращаете камеру относительно формы, вы вращаете форму на 3D плоскости.

``` cpp
{
    using namespace Aspose::Slides;

    auto slide = pres->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
    shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
    // ... установите другие параметры 3D сцены
    slide->GetImage(2, 2)->Save(u"sample_3d.png");
}
```

## 3D Глубина и Экструдирование
Чтобы добавить глубину и экструдирование для 3D модели PowerPoint, используйте метод 
[IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295).
Для изменения цвета экструдирования используйте метод 
[IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e):

``` cpp
{
    using namespace Aspose::Slides;

    auto slide = pres->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
    shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
    shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
    shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
    // ... установите другие параметры 3D сцены
    slide->GetImage(2, 2)->Save(u"sample_3d.png");
}
```

Меню глубины в PowerPoint:

![todo:image_alt_text](img_02_02.png)

## 3D Градиент
Рисование 3D градиента на 3D модели PowerPoint можно выполнить через 
[Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58) метод:

``` cpp
{
    using namespace Aspose::Slides;

    auto slide = pres->get_Slide(0);
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

    slide->GetImage(2, 2)->Save(u"sample_3d.png");
}
```

3D модель с 3D градиентом:

![todo:image_alt_text](img_02_03.png)
  
Чтобы создать градиент изображения, используйте 
[Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb) метод:
``` cpp
{
    using namespace Aspose::Slides;

    shape->get_FillFormat()->set_FillType(FillType::Picture);
    shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.jpg")));
    shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
    // .. настройка 3D: Камера, LightRig, Экструдирование
    pres->get_Slide(0)->GetImage(2, 2)->Save(u"sample_3d.png");
}
    
```

3D модель с градиентом изображения:

![todo:image_alt_text](img_02_04.png)

## 3D Текст (WordArt)
Чтобы применить вращение, экструзию, свет, градиент к тексту и сделать его 3D текстом (WordArt), вам необходимо получить доступ к методу [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30):

``` cpp
{
    using namespace Aspose::Slides;
    using namespace Aspose::Slides::Export;

    auto slide = pres->get_Slide(0);
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

    auto textFrame = shape->get_TextFrame();
    // настройка эффекта "Арка вверх" WordArt
    textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUp);

    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->set_Depth(3.0);
    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

    textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    pres->get_Slide(0)->GetImage(2, 2)->Save(u"text3d.png");
    pres->Save(u"text3d.pptx", SaveFormat::Pptx);
}
```

Пример 3D текста (WordArt):

![todo:image_alt_text](img_02_05.png)

## Не поддерживается - Скоро
Следующие функции 3D PowerPoint еще не поддерживаются: 
- Фаска
- Материал
- Контур
- Освещение

Мы продолжаем улучшать наш 3D движок, и эти функции являются предметом дальнейшей реализации.