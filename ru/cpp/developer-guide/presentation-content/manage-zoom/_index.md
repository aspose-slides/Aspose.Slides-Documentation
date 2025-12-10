---
title: "Управление зумом презентации в C++"
linktitle: "Управление зумом"
type: docs
weight: 60
url: /ru/cpp/manage-zoom/
keywords:
- зум
- зум-рамка
- зум слайда
- зум раздела
- зум обзора
- добавить зум
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте и настраивайте зум с помощью Aspose.Slides для C++ — перемещайтесь между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Overview**
Zooms in PowerPoint allow you to jump to and from specific slides, sections, and portions of a presentation. When you are presenting, this ability to navigate quickly across content might prove very useful. 

![overview_image](Overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Увеличение слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом выбранном порядке без нарушения плавности презентации. Увеличения слайда отлично подходят для коротких презентаций без множества разделов, но их также можно использовать в разных сценариях.

Увеличения слайда помогают углубляться в несколько блоков информации, создавая ощущение единого холста. 

![overview_image](slidezoomsel.png)

Для объектов увеличения слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) , интерфейс [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) , а также некоторые методы из интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) .

### **Create Zoom Frames**

Вы можете добавить рамку увеличения на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новые слайды, к которым вы планируете привязать рамки увеличения. 
3.	Добавьте идентификационный текст и фон к созданным слайдам.
4.	Добавьте рамки увеличения (содержащие ссылки на созданные слайды) на первый слайд.
5.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как создать рамку увеличения на слайде:
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

//Adds new slides to the presentation
//Добавляет новые слайды в презентацию
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
// Создаёт фон для второго слайда
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
// Создаёт текстовый блок для второго слайда
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
// Создаёт фон для третьего слайда
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
// Создаёт текстовый блок для третьего слайда
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
//Добавляет объекты ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Create Zoom Frames with Custom Images**
С помощью Aspose.Slides для C++ вы можете создать рамку увеличения с другим изображением предварительного просмотра слайда следующим образом: 
1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новый слайд, к которому вы планируете привязать рамку увеличения. 
3.	Добавьте идентификационный текст и фон к слайду.
4.	Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) , добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) , которое будет использоваться для заполнения рамки.
5.	Добавьте рамки увеличения (содержащие ссылку на созданный слайд) на первый слайд.
6.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как создать рамку увеличения с другим изображением:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds a new slide to the presentation
//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
//Создаёт фон для второго слайда
SetSlideBackground(slide, Color::get_Cyan());

// Creates a text box for the third slide
//Создаёт текстовый блок для третьего слайда
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a new image for the zoom object
//Создаёт новое изображение для объекта увеличения
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Adds the ZoomFrame object
//Добавляет объект ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Saves the presentation
//Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Format Zoom Frames**
В предыдущих разделах мы показали, как создать простые рамки увеличения. Чтобы создать более сложные рамки увеличения, необходимо изменить форматирование простой рамки. Существует несколько вариантов форматирования, которые можно применить к рамке увеличения. 

Вы можете управлять форматированием рамки увеличения на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новые слайды, к которым вы хотите привязать рамку увеличения. 
3.	Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4.	Добавьте рамки увеличения (содержащие ссылки на созданные слайды) на первый слайд.
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) , добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) , которое будет использоваться для заполнения рамки.
6.	Установите пользовательское изображение для первого объекта рамки увеличения.
7.	Измените формат линии для второго объекта рамки увеличения.
8.	Удалите фон из изображения второго объекта рамки увеличения.
9.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как изменить форматирование рамки увеличения на слайде: 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Creates a background for the second slide
//Создаёт фон для второго слайда
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
//Создаёт текстовый блок для второго слайда
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
//Создаёт фон для третьего слайда
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Creates a text box for the third slide
//Создаёт текстовый блок для третьего слайда
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
//Добавляет объекты ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Creates a new image for the zoom object
//Создаёт новое изображение для объекта zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Sets custom image for zoomFrame1 object
//Устанавливает пользовательское изображение для объекта zoomFrame1
zoomFrame1->set_Image(image);

// Sets a zoom frame format for the zoomFrame2 object
//Устанавливает формат рамки увеличения для объекта zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Setting for Do not show background for zoomFrame2 object
//Настройка: не показывать фон для объекта zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Saves the presentation
//Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Section Zoom**

Увеличение раздела — это ссылка на раздел вашей презентации. Вы можете использовать увеличения разделов, чтобы возвращаться к разделам, которые хотите особо подчеркнуть. Или использовать их, чтобы выделить, как определённые части вашей презентации связаны друг с другом. 

![overview_image](seczoomsel.png)

Для объектов увеличения раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) , а также некоторые методы из интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) .

### **Create Section Zoom Frames**

Вы можете добавить рамку увеличения раздела на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новый слайд. 
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому вы планируете привязать рамку увеличения. 
5.	Добавьте рамку увеличения раздела (содержащую ссылки на созданный раздел) на первый слайд.
6.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как создать рамку увеличения на слайде:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds a new slide to the presentation
//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Adds a new Section to the presentation
// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

// Adds a SectionZoomFrame object
// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Saves the presentation
// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Create Section Zoom Frames with Custom Images**

С помощью Aspose.Slides для C++ вы можете создать рамку увеличения раздела с другим изображением предварительного просмотра слайда следующим образом: 

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому вы планируете привязать рамку увеличения. 
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) , добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) , которое будет использоваться для заполнения рамки.
6.	Добавьте рамку увеличения раздела (содержащую ссылку на созданный раздел) на первый слайд.
7.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как создать рамку увеличения с другим изображением:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds new slide to the presentation
//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Adds a new Section to the presentation
// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

// Creates a new image for the zoom object
// Создаёт новое изображение для объекта увеличения
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Adds SectionZoomFrame object
// Добавляет объект SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Saves the presentation
// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Format Section Zoom Frames**

Чтобы создать более сложные рамки увеличения раздела, необходимо изменить форматирование простой рамки. Существует несколько вариантов форматирования, которые можно применить к рамке увеличения раздела. 

Вы можете управлять форматированием рамки увеличения раздела на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому вы планируете привязать рамку увеличения. 
5.	Добавьте рамку увеличения раздела (содержащую ссылки на созданный раздел) на первый слайд.
6.	Измените размер и позицию созданного объекта увеличения раздела.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) , добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) , которое будет использоваться для заполнения рамки.
8.	Установите пользовательское изображение для созданного объекта рамки увеличения раздела.
9.	Установите возможность *возврата к исходному слайду из связанного раздела*.
10.	Удалите фон из изображения объекта рамки увеличения раздела.
11.	Измените формат линии для второго объекта рамки увеличения.
12.	Измените длительность перехода.
13.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как изменить форматирование рамки увеличения раздела:
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

// Форматирование SectionZoomFrame
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

Обзорное увеличение — это своего рода стартовая страница, на которой отображаются все части вашей презентации одновременно. При демонстрации вы можете использовать увеличение, чтобы переходить от одного места к другому в произвольном порядке. Вы можете проявлять креативность, перескакивать вперёд или возвращаться к частям слайд‑шоу, не прерывая его поток. 

![overview_image](sumzoomsel.png)

Для объектов обзорного увеличения Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) , а также некоторые методы из интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) .

### **Create Summary Zoom**

Вы можете добавить рамку обзорного увеличения на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте рамку обзорного увеличения на первый слайд.
4.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как создать рамку обзорного увеличения на слайде:
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


### **Add and Remove a Summary Zoom Section**

Все разделы в рамке обзорного увеличения представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) . Вы можете добавить или удалить объект раздела обзорного увеличения через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте рамку обзорного увеличения в первый слайд.
4.	Добавьте новый слайд и раздел в презентацию.
5.	Добавьте созданный раздел в рамку обзорного увеличения.
6.	Удалите первый раздел из рамки обзорного увеличения.
7.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как добавить и удалить разделы в рамке обзорного увеличения:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

//Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 2", slide);

// Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Добавляет новый слайд в презентацию
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


### **Format Summary Zoom Sections**

Чтобы создать более сложные объекты разделов обзорного увеличения, необходимо изменить форматирование простой рамки. Существует несколько вариантов форматирования, которые можно применить к объекту раздела обзорного увеличения. 

Вы можете контролировать форматирование объекта раздела обзорного увеличения в рамке обзорного увеличения следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте рамку обзорного увеличения в первый слайд.
4.	Получите объект раздела обзорного увеличения для первого объекта из `ISummaryZoomSectionCollection` .
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) , добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) , которое будет использоваться для заполнения рамки.
8.	Установите пользовательское изображение для созданного объекта рамки увеличения раздела.
9.	Установите возможность *возврата к исходному слайду из связанного раздела* .
11.	Измените формат линии для второго объекта рамки увеличения.
12.	Измените длительность перехода.
13.	Сохраните изменённую презентацию в виде PPTX-файла.

Этот C++ код показывает, как изменить форматирование объекта раздела обзорного увеличения:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds a new slide to the presentation
//Добавляет новый слайд в презентацию
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Adds a new section to the presentation
// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adds a new slide to the presentation
//Добавляет новый слайд в презентацию
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Adds a new section to the presentation
// Добавляет новый раздел в презентацию
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adds a SummaryZoomFrame object
// Добавляет объект SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Gets the first SummaryZoomSection object
// Получает первый объект SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatting for SummaryZoomSection object
// Форматирование объекта SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Saves the presentation
// Сохраняет презентацию
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Могу ли я контролировать возврат к «родительскому» слайду после показа цели?**

Да. У [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) или у [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) есть метод `set_ReturnToParent`, который возвращает зрителей к исходному слайду после посещения целевого содержания.

**Могу ли я настроить «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает настройку длительности перехода, что позволяет контролировать, сколько времени занимает анимация перехода.

**Существуют ли ограничения на количество объектов Zoom, которые может содержать презентация?**

Твёрдого ограничения API не задокументировано. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Вы можете добавить много рамок Zoom, но следует учитывать размер файла и время рендеринга.