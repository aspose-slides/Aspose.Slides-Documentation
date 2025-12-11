---
title: "Получить полный фон слайда презентации в виде изображения"
linktitle: "Полный фон слайда"
type: docs
weight: 95
url: /ru/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- фон слайда
- окончательный фон
- извлечение фона
- полностью фон
- фон в изображение
- фон PPT
- фон PPTX
- фон ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Извлекать полные фоны слайдов как изображения из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для C++, упрощая визуальные рабочие процессы."
---

## **Получить полный фон слайда**

В презентациях PowerPoint фон слайда может состоять из множества элементов. Помимо изображения, установленного как [фон слайда](/slides/ru/cpp/presentation-background/), окончательный фон может зависеть от темы презентации, цветовой схемы и фигур, размещённых на мастер‑слайде и слайде‑макете.

Aspose.Slides for C++ не предоставляет простой метод для извлечения полного фона слайда презентации в виде изображения, но вы можете выполнить следующие шаги:
1. Загрузить презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получить размер слайда из презентации.
1. Выбрать слайд.
1. Создать временную презентацию.
1. Установить тот же размер слайда во временной презентации.
1. Клонировать выбранный слайд во временную презентацию.
1. Удалить фигуры из клонированного слайда.
1. Преобразовать клонированный слайд в изображение.

Следующий пример кода извлекает полный фон слайда презентации в виде изображения.
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


## **FAQ**

**Будут ли сложные градиенты, текстуры или заливки изображениями из мастер‑слайда сохранены в полученном изображении фона?**

Да. Aspose.Slides рендерит градиентные, картинные и текстурные заливки, определённые на слайде, макете или мастере. Если необходимо изолировать внешний вид от наследуемых мастеров, [установите собственный фон](/slides/ru/cpp/presentation-background/) на текущем слайде перед экспортом.

**Могу ли я добавить водяной знак к полученному изображению фона перед сохранением?**

Да. Вы можете [добавить водяной знак](/slides/ru/cpp/watermark/) в виде фигуры или изображения на рабочую [копию слайда](/slides/ru/cpp/clone-slides/) (размещённую позади другого содержимого), а затем выполнить экспорт. Это позволяет создать изображение фона с внедрённым водяным знаком.

**Можно ли получить фон для конкретного макета или мастера без привязки его к существующему слайду?**

Да. Получите нужный мастер или макет, примените его к [временному слайду](/slides/ru/cpp/clone-slides/) нужного размера и экспортируйте этот слайд, чтобы получить фон, полученный из этого макета или мастера.

**Существуют ли ограничения лицензирования, влияющие на экспорт изображений?**

Функции рендеринга полностью доступны при наличии [действительной лицензии](/slides/ru/cpp/licensing/). В режиме оценки вывод может содержать ограничения, такие как водяной знак. Активируйте лицензию один раз за процесс перед выполнением пакетного экспорта.