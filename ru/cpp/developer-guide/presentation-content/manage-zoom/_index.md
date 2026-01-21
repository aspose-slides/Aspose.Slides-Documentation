---
title: Управление масштабированием презентации в C++
linktitle: Управление масштабированием
type: docs
weight: 60
url: /ru/cpp/manage-zoom/
keywords:
- масштабирование
- кадр масштабирования
- масштабирование слайда
- масштабирование раздела
- масштабирование резюме
- добавить масштабирование
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте и настраивайте масштабирование с помощью Aspose.Slides for C++ — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к определённым слайдам, разделам и частям презентации и обратно. При представлении эта возможность быстро перемещаться по содержимому может оказаться очень полезной. 

![overview_image](Overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Zoom слайда**

Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания её потока. Zoom слайды отлично подходят для коротких презентаций без множества разделов, но их можно использовать и в других сценариях.

Zoom слайды помогают исследовать несколько блоков информации, будто вы работаете на едином холсте. 

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/), интерфейс [IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **Создание Zoom Frames**

Вы можете добавить Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новые слайды, к которым планируете привязать Zoom‑кадры. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (с содержащими ссылками на созданные слайды) к первому слайду.
5. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как создать Zoom‑кадр на слайде:
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

//Создает фон для второго слайда
SetSlideBackground(slide2, Color::get_Cyan());

//Создает текстовое поле для второго слайда
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Создает фон для третьего слайда
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Создает текстовое поле для третьего слайда
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Добавляет объекты ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Создание Zoom Frames с пользовательскими изображениями**

С помощью Aspose.Slides for C++ вы можете создать Zoom‑кадр с другим изображением предварительного просмотра слайда следующим образом: 
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новый слайд, к которому планируете привязать Zoom‑кадр. 
3. Добавьте идентификационный текст и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
5. Добавьте Zoom‑кадры (с ссылкой на созданный слайд) к первому слайду.
6. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как создать Zoom‑кадр с другим изображением:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Создаёт фон для второго слайда
SetSlideBackground(slide, Color::get_Cyan());

// Создаёт текстовое поле для третьего слайда
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Создаёт новое изображение для объекта Zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Добавляет объект ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Форматирование Zoom Frames**

В предыдущих разделах мы показывали, как создать простые Zoom‑кадры. Чтобы создать более сложные Zoom‑кадры, необходимо изменить их форматирование. Существует несколько вариантов форматирования, которые можно применить к Zoom‑кадру. 

Вы можете управлять форматированием Zoom‑кадра на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новые слайды, к которым планируете привязать Zoom‑кадр. 
3. Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (с содержащими ссылки на созданные слайды) к первому слайду.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
6. Установите пользовательское изображение для первого объекта Zoom‑кадра.
7. Измените формат линии для второго объекта Zoom‑кадра.
8. Удалите фон у изображения второго объекта Zoom‑кадра.
5. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как изменить форматирование Zoom‑кадра на слайде: 
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Добавляет новые слайды в презентацию
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Создаёт фон для второго слайда
SetSlideBackground(slide2, Color::get_Cyan());

// Создаёт текстовое поле для второго слайда
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Создаёт фон для третьего слайда
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Создаёт текстовое поле для третьего слайда
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Добавляет объекты ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Создаёт новое изображение для объекта zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Устанавливает пользовательское изображение для объекта zoomFrame1
zoomFrame1->set_Image(image);

// Устанавливает формат рамки зума для объекта zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Настройка: не показывать фон для объекта zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Section Zoom**

Section Zoom — это ссылка на раздел в вашей презентации. Вы можете использовать Section Zoom, чтобы возвращаться к разделам, которые хотите особенно подчеркнуть, или чтобы показать, как отдельные части презентации связаны друг с другом. 

![overview_image](seczoomsel.png)

Для объектов Section Zoom Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **Создание Section Zoom Frames**

Вы можете добавить Section Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑кадр. 
5. Добавьте Section Zoom‑кадр (с ссылками на созданный раздел) к первому слайду.
6. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как создать Zoom‑кадр на слайде:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Создание Section Zoom Frames с пользовательскими изображениями**

С помощью Aspose.Slides for C++ вы можете создать Section Zoom‑кадр с другим изображением предварительного просмотра слайда следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑кадр. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
5. Добавьте Section Zoom‑кадр (с ссылкой на созданный раздел) к первому слайду.
6. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как создать Zoom‑кадр с другим изображением:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Adds a new Section to the presentation
pres->get_Sections()->AddSection(u"Section 1", slide);

// Создает новое изображение для объекта zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Adds SectionZoomFrame object
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Форматирование Section Zoom Frames**

Чтобы создать более сложные Section Zoom‑кадры, необходимо изменить их форматирование. Существует несколько вариантов форматирования, которые можно применить к Section Zoom‑кадру. 

Вы можете управлять форматированием Section Zoom‑кадра на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑кадр. 
5. Добавьте Section Zoom‑кадр (с ссылками на созданный раздел) к первому слайду.
6. Измените размер и положение созданного объекта Section Zoom.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного Section Zoom‑кадра.
9. Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
10. Удалите фон у изображения объекта Section Zoom‑кадра.
11. Измените формат линии для второго Zoom‑кадра.
12. Измените длительность перехода.
13. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как изменить форматирование Section Zoom‑кадра:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Форматирование для SectionZoomFrame
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


## **Summary Zoom**

Summary Zoom — это как целевая страница, на которой одновременно отображаются все части вашей презентации. При представлении вы можете использовать Zoom, чтобы перемещаться от одного места к другому в любом порядке, проявляя креативность, пропуская части или возвращаясь к предыдущим слайдам без нарушения потока презентации.

![overview_image](sumzoomsel.png)

Для объектов Summary Zoom Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/), а также некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **Создание Summary Zoom**

Вы можете добавить Summary Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Summary Zoom‑кадр к первому слайду.
4. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как создать Summary Zoom‑кадр на слайде:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 2", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 3", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 4", slide);

// Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Добавление и удаление раздела Summary Zoom**

Все разделы в Summary Zoom‑кадре представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/). Вы можете добавить или удалить объект раздела Summary Zoom через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Summary Zoom‑кадр в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в Summary Zoom‑кадр.
6. Удалите первый раздел из Summary Zoom‑кадра.
7. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как добавить и удалить разделы в Summary Zoom‑кадре:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 2", slide);

// Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Добавляет новый раздел в презентацию
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Добавляет раздел в Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Удаляет раздел из Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Форматирование разделов Summary Zoom**

Чтобы создать более сложные объекты разделов Summary Zoom, необходимо изменить их форматирование. Существует несколько вариантов форматирования, которые можно применить к объекту раздела Summary Zoom. 

Вы можете управлять форматированием объекта раздела Summary Zoom в Summary Zoom‑кадре следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Summary Zoom‑кадр к первому слайду.
4. Получите объект раздела Summary Zoom из `ISummaryZoomSectionCollection` для первого элемента.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного объекта раздела Zoom.
9. Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
11. Измените формат линии для второго Zoom‑кадра.
12. Измените длительность перехода.
13. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как изменить форматирование объекта раздела Summary Zoom:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds a new slide to the presentation
// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adds a new slide to the presentation
// Adds a new section to the presentation
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adds a SummaryZoomFrame object
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Gets the first SummaryZoomSection object
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatting for SummaryZoomSection object
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Могу ли я контролировать возврат к «родительскому» слайду после показа цели?**

Да. У объекта [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) есть метод `set_ReturnToParent`, который возвращает зрителя к исходному слайду после просмотра целевого содержимого.

**Можно ли регулировать «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку длительности перехода, что позволяет контролировать, как долго длится анимация прыжка.

**Есть ли ограничения на количество объектов Zoom в презентации?**

Жёсткого ограничения API не задокументировано. Практические ограничения зависят от сложности презентации и производительности устройства просмотра. Можно добавить много Zoom‑кадров, но следует учитывать размер файла и время рендеринга.