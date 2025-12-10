---
title: Управление объектами чернил в презентации на C++
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/cpp/manage-ink/
keywords:
- чернила
- объект чернил
- трасса чернил
- управление чернилами
- рисование чернил
- рисование
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint — создавайте, редактируйте и оформляйте цифровые чернила с помощью Aspose.Slides для C++. Получите образцы кода для трасс, цвета и размера кисти."
---

PowerPoint предоставляет функцию чернил, позволяющую рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к конкретным элементам на слайде. 

Aspose.Slides предоставляет интерфейс [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/), который содержит типы, необходимые для создания и управления объектами чернил. 

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами shape. Объект shape в своей простейшей форме представляет собой контейнер, определяющий область самого объекта (его рамку) вместе с его свойствами. Последние включают размер области контейнера, форму контейнера, фон контейнера и т.д. Для справки см. [Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint работает с объектом чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Трассы Inkshape**

Трасса — базовый элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Трасы — это записи, описывающие последовательности соединённых точек. 

Самая простая форма кодирования указывает координаты X и Y каждой точки выборки. Когда все соединённые точки отрисовываются, они образуют изображение, похожее на это:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Вы можете использовать кисть для рисования линий, соединяющих точки элементов трассы. Кисть имеет собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`. 

### **Установка цвета кисти чернил**

Этот C++ код показывает, как установить цвет кисти:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **Установка размера кисти чернил** 

Этот C++ код показывает, как установить размер кисти:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры: 

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. последнее изображение). 

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти объектов трассы. Здесь целевой объект (трасса рукописного текста) масштабирован до размера контейнера (рамки). Когда размер контейнера (рамки) изменяется, размер кисти остаётся постоянным и наоборот. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint демонстрирует аналогичное поведение при работе с текстом:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительные материалы**

* Чтобы ознакомиться с фигурами в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/). 
* Для получения более подробной информации о эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).