---  
title: Управление чернилами  
type: docs  
weight: 95  
url: /ru/cpp/manage-ink/  
keywords: "Чернила в PowerPoint, Инструменты для рисования, C++ Ink, Рисовать в PowerPoint, Презентация PowerPoint, C++, CPP, Aspose.Slides для C++"  
description: "Используйте инструменты для рисования, чтобы создавать объекты в PowerPoint C++"  
---  

PowerPoint предоставляет функцию чернил, которая позволяет вам рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, показа связей и процессов, а также привлечения внимания к конкретным элементам на слайде.  

Aspose.Slides предоставляет интерфейс [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/), который содержит необходимые типы для создания и управления объектами чернил.  

## **Различия между обычными объектами и объектами чернил**  

Объекты на слайде PowerPoint обычно представлены объектами форм. Объект формы в своей самой простой форме является контейнером, который определяет область самого объекта (его рамки) наряду с его свойствами. К последним относятся размер области контейнера, форма контейнера, фон контейнера и т. д. Для получения информации смотрите [Формат макета формы](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).  

Однако, когда PowerPoint работает с объектом чернил, он игнорирует все свойства рамок объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:  

![ink_powerpoint1](ink_powerpoint1.png)  

## **Следы Inkshape**  

След — это основной элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Следы — это записи, которые описывают последовательности связанных точек.  

Самая простая форма кодирования указывает координаты X и Y каждой опорной точки. Когда все связанные точки отрисовываются, они создают изображение, подобное этому:  

![ink_powerpoint2](ink_powerpoint2.png)  

## Свойства кисти для рисования  

Вы можете использовать кисть для рисования линий, соединяющих точки элементов следа. У кисти есть свой собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`.  

### **Установка цвета кисти для чернил**  

Этот C++ код показывает, как установить цвет для кисти:  

```c++  
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");  

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));  
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();  
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();  
System::Drawing::Color brushColor = brush->get_Color();  
brush->set_Color(System::Drawing::Color::get_Red());  
```  

### **Установка размера кисти для чернил**  

Этот C++ код показывает, как установить размер для кисти:  

```c++  
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");  

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));  
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();  
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();  
System::Drawing::SizeF brushSize = brush->get_Size();  
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));  
```  

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает её размер следующим образом:  

![ink_powerpoint3](ink_powerpoint3.png)  

Для ясности давайте увеличим высоту объекта чернил и рассмотрим важные размеры:  

![ink_powerpoint4](ink_powerpoint4.png)  

Контейнер (рамка) не учитывает размер кистей—он всегда предполагает, что толщина линии равна нулю (см. последнее изображение).  

Таким образом, чтобы определить видимую область всего объекта чернил, мы должны учитывать размер кисти объектов следов. Здесь целевой объект (объект следа рукописного текста) был масштабирован до размера контейнера (рамки). Когда размер контейнера (рамки) изменяется, размер кисти остается постоянным и наоборот.  

![ink_powerpoint5](ink_powerpoint5.png)  

PowerPoint демонстрирует такое же поведение при работе с текстами:  

![ink_powerpoint6](ink_powerpoint6.png)  

**Дальнейшее чтение**  

* Чтобы прочитать о фигурах в целом, смотрите раздел [Фигуры PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-shapes/).  
* Для получения дополнительной информации о значениях свойств смотрите [Эффективные свойства формы](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).  