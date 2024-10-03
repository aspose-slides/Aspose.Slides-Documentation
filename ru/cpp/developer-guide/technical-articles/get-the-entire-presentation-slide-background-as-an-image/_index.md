---
title: Получите весь фон слайдов презентации в виде изображения
type: docs
weight: 95
url: /ru/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- слайд
- фон
- фон слайда
- фон в изображение
- PowerPoint
- PPT
- PPTX
- Презентация PowerPoint
- C++
- Aspose.Slides для C++
---

В презентациях PowerPoint фон слайда может состоять из многих элементов. В дополнение к изображению, установленному в качестве [фона слайда](/slides/ru/cpp/presentation-background/), финальный фон может зависеть от темы презентации, цветовой схемы и фигур, размещенных на главном слайде и слайде макета.

Aspose.Slides для C++ не предоставляет простого метода для извлечения всего фона слайда презентации в виде изображения, но вы можете следовать приведенным ниже шагам, чтобы сделать это:
1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите такой же размер слайда в временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает весь фон слайда презентации в виде изображения.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```