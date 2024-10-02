---
title: Управление Зумом
type: docs
weight: 60
url: /ru/cpp/manage-zoom/
keywords: "Зум, Зум-фрейм, Добавить зум, Формат зум-фрейма, Сводный зум, Презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Добавление зума или зум-фреймов в презентации PowerPoint на C++"
---

## **Обзор**
Зумы в PowerPoint позволяют вам быстро переходить к конкретным слайдам, разделам и частям презентации и обратно. Эта возможность быстрой навигации по контенту может оказаться очень полезной во время презентации.

![overview_image](Overview.png)

* Чтобы обобщить всю презентацию на одном слайде, используйте [Сводный Зум](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Зум Слайда](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Зум Раздела](#Section-Zoom).

## **Зум Слайда**
Зум слайда может сделать вашу презентацию более динамичной, позволяя свободно переходить между слайдами в любом порядке, который вы выберете, не прерывая поток вашей презентации. Зумы слайдов отлично подходят для кратких презентаций без множества разделов, но вы все равно можете использовать их в различных сценариях презентации.

Зумы слайдов помогают вам углубляться в несколько частей информации, пока вы ощущаете, что находитесь на одном холсте.

![overview_image](slidezoomsel.png)

Для объектов зума слайдов Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2), интерфейс [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) и некоторые методы из интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Создание Зум-Фреймов**

Вы можете добавить зум-фрейм на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новые слайды, к которым вы собираетесь связать зум-фреймы. 
3. Добавьте идентификационный текст и фон на созданные слайды.
4. Добавьте зум-фреймы (ссылающиеся на созданные слайды) на первый слайд.
5. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать зум-фрейм на слайде:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новые слайды в презентацию
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Создает фон для второго слайда
SetSlideBackground(slide2, Color::get_Cyan());

// Создает текстовое поле для второго слайда
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Второй Слайд");

// Создает фон для третьего слайда
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Создает текстовое поле для третьего слайда
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Третий Слайд");

//Добавляет объекты ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Создание Зум-Фреймов с Пользовательскими Изображениями**
С помощью Aspose.Slides для C++ вы можете создать зум-фрейм с другим изображением предварительного просмотра слайда следующим образом: 
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новый слайд, к которому вы собираетесь связать зум-фрейм. 
3. Добавьте идентификационный текст и фон на слайд.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), которое будет использоваться для заполнения фрейма.
5. Добавьте зум-фреймы (ссылающиеся на созданный слайд) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать зум-фрейм с другим изображением:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Создает фон для второго слайда
SetSlideBackground(slide, Color::get_Cyan());

// Создает текстовое поле для третьего слайда
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Второй Слайд");

// Создает новое изображение для объекта зума
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Добавляет объект ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Форматирование Зум-Фреймов**
В предыдущих разделах мы показали, как создавать простые зум-фреймы. Для создания более сложных зум-фреймов вам нужно изменить форматирование простого фрейма. Существует несколько вариантов форматирования, которые вы можете применить к зум-фрейму. 

Вы можете контролировать форматирование зум-фрейма на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новые слайды, которые вы собираетесь связать с зум-фреймом. 
3. Добавьте некоторый идентификационный текст и фон на созданные слайды.
4. Добавьте зум-фреймы (ссылающиеся на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), которое будет использоваться для заполнения фрейма.
6. Установите пользовательское изображение для первого объекта зум-фрейма.
7. Измените формат линии для второго объекта зум-фрейма.
8. Удалите фон из изображения второго объекта зум-фрейма.
9. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как изменить форматирование зум-фрейма на слайде: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Добавляет новые слайды в презентацию
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Создает фон для второго слайда
SetSlideBackground(slide2, Color::get_Cyan());

// Создает текстовое поле для второго слайда
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Второй Слайд");

// Создает фон для третьего слайда
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Создает текстовое поле для третьего слайда
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Третий Слайд");

//Добавляет объекты ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Создает новое изображение для объекта зума
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Устанавливает пользовательское изображение для объекта zoomFrame1
zoomFrame1->set_Image(image);

// Устанавливает формат зум-фрейма для объекта zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Установка "Не показывать фон" для объекта zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Зум Раздела**

Зум раздела - это ссылка на раздел в вашей презентации. Вы можете использовать зумы разделов, чтобы вернуться к разделам, которые вы хотите действительно выделить. Или вы можете использовать их, чтобы подчеркнуть, как определенные части вашей презентации связаны. 

![overview_image](seczoomsel.png)

Для объектов зума разделов Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Создание Зум-Фреймов Раздела**

Вы можете добавить зум-фрейм раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон на созданный слайд.
4. Создайте новый раздел, к которому вы собираетесь связать зум-фрейм. 
5. Добавьте зум-фрейм раздела (ссылающийся на созданный раздел) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать зум-фрейм на слайде:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 1", slide);

// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Создание Зум-Фреймов Раздела с Пользовательскими Изображениями**

С использованием Aspose.Slides для C++ вы можете создать зум-фрейм раздела с другим изображением предварительного просмотра слайда следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон на созданный слайд.
4. Создайте новый раздел, к которому вы собираетесь связать зум-фрейм. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), которое будет использоваться для заполнения фрейма.
5. Добавьте зум-фрейм раздела (ссылающийся на созданный раздел) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать зум-фрейм с другим изображением:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 1", slide);

// Создает новое изображение для объекта зума
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Форматирование Зум-Фреймов Раздела**

Чтобы создать более сложные зум-фреймы раздела, вам нужно изменить форматирование простого фрейма. Существует несколько параметров форматирования, которые вы можете применить к зум-фрейму раздела. 

Вы можете контролировать форматирование зум-фрейма раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон на созданный слайд.
4. Создайте новый раздел, к которому вы собираетесь связать зум-фрейм. 
5. Добавьте зум-фрейм раздела (ссылающийся на созданный раздел) на первый слайд.
6. Измените размер и положение созданного объекта зума.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), которое будет использоваться для заполнения фрейма.
8. Установите пользовательское изображение для созданного объекта зум-фрейма.
9. Установите возможность "возврата к оригинальному слайду из связанного раздела". 
10. Удалите фон из изображения объекта зум-фрейма раздела.
11. Измените формат линии для второго объекта зум-фрейма.
12. Измените продолжительность перехода.
13. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как изменить форматирование зум-фрейма раздела:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 1", slide);

// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Форматы для SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Сводный Зум**

Сводный зум - это как "страница приземления", на которой все части вашей презентации отображаются одновременно. Когда вы проводите презентацию, вы можете использовать зум, чтобы переходить с одного места в вашей презентации на другое в любом порядке, который вам нравится. Вы можете проявить креативность, перескочить вперед или вернуться к частям вашего слайд-шоу, не прерывая поток вашей презентации.

![overview_image](sumzoomsel.png)

Для объектов сводного зума Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection), а также некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Создание Сводного Зума**

Вы можете добавить сводный зум-фрейм на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте сводный зум-фрейм на первый слайд.
4. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать сводный зум-фрейм на слайде:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 1", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 2", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 3", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 4", slide);

// Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Добавление и Удаление Разделов Сводного Зума**

Все разделы в сводном зум-фрейме представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), которые сохраняются в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection). Вы можете добавлять или удалять объекты раздела сводного зума через интерфейс [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте сводный зум-фрейм на первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в сводный зум-фрейм.
6. Удалите первый раздел из сводного зум-фрейма.
7. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как добавлять и удалять разделы в сводном зум-фрейме:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 1", slide);

//Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 2", slide);

//Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Добавляет новый раздел в презентацию
auto section3 = pres->get_Sections()->AddSection(u"Раздел 3", slide);

// Добавляет раздел в Сводный Зум
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Удаляет раздел из Сводного Зума
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Форматирование Разделов Сводного Зума**

Чтобы создать более сложные объекты разделов сводного зума, вам нужно изменить форматирование простого фрейма. Существует несколько параметров форматирования, которые вы можете применить к объекту раздела сводного зума. 

Вы можете контролировать форматирование для объекта раздела сводного зума в сводном зум-фрейме следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте сводный зум-фрейм на первый слайд.
4. Получите объект раздела сводного зума для первого объекта из `ISummaryZoomSectionCollection`.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), которое будет использоваться для заполнения фрейма.
6. Установите пользовательское изображение для созданного объекта раздела зум-фрейма.
7. Установите возможность "возврата к оригинальному слайду из связанного раздела". 
8. Измените формат линии для второго объекта зум-фрейма.
9. Измените продолжительность перехода.
10. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как изменить форматирование для объекта раздела сводного зума:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 1", slide);

//Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Раздел 2", slide);

// Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Получает первый объект SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Форматы для объекта SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```