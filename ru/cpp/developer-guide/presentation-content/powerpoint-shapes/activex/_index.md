---
title: ActiveX
type: docs
weight: 80
url: /ru/cpp/activex/
---


Управление элементами управления ActiveX используется в презентациях. Aspose.Slides для C++ позволяет управлять элементами управления ActiveX, но управлять ими немного сложнее и это отличается от обычных фигур в презентациях. Начиная с версии Aspose.Slides для C++ 18.1, компонент поддерживает управление элементами управления ActiveX. В данный момент вы можете получить доступ к уже добавленному элементу управления ActiveX в вашей презентации и изменить или удалить его, используя его различные свойства. Помните, что элементы управления ActiveX не являются фигурами и не являются частью IShapeCollection презентации, а представляют собой отдельную IControlCollection. Эта статья показывает, как работать с ними.

## **Изменение элемента управления ActiveX**
Чтобы управлять простым элементом управления ActiveX, таким как текстовое поле и простая кнопка команды на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию с элементами управления ActiveX.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к элементам управления ActiveX на слайде, обратившись к IControlCollection.
1. Получите доступ к элементу управления ActiveX TextBox1, используя объект ControlEx.
1. Измените различные свойства элемента управления ActiveX TextBox1, включая текст, шрифт, высоту шрифта и позицию рамки.
1. Получите доступ ко второму элементу управления, названному CommandButton1.
1. Измените заголовок кнопки, шрифт и позицию.
1. Сдвиньте позицию рамок элементов управления ActiveX.
1. Запишите изменённую презентацию в файл PPTX.

Ниже приведенный фрагмент кода обновляет элементы управления ActiveX на слайдах презентации, как показано ниже.

``` cpp
// Доступ к презентации с элементами управления ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Доступ к первому слайду в презентации
auto slide = presentation->get_Slides()->idx_get(0);

// изменение текста TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Изменённый текст";
    control->get_Properties()->idx_set(u"Value", newText);

    // изменение заменяющего изображения. Powerpoint заменит это изображение во время активации activeX, поэтому иногда нормально оставлять изображение без изменений.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// изменение заголовка кнопки
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"Сообщение";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // изменение замены
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Перемещение рамок ActiveX на 100 пунктов вниз
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Сохранение презентации с отредактированными элементами управления ActiveX
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Теперь удаляем элементы управления
slide->get_Controls()->Clear();

// Сохранение презентации с очищенными элементами управления ActiveX
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Добавить элемент управления ActiveX медиаплеера**
Элементы управления ActiveX используются в презентациях. Aspose.Slides для C++ позволяет добавлять и управлять элементами управления ActiveX, но управлять ими немного сложнее и это отличается от обычных фигур в презентациях. Начиная с версии Aspose.Slides для C++ 18.1, было добавлено управление элементами управления ActiveX медиаплеера. Помните, что элементы управления ActiveX не являются фигурами и не являются частью IShapeCollection презентации, а представляют собой отдельную IControlExCollection. Эта статья показывает, как работать с ними. Чтобы управлять элементом управления ActiveX медиаплеером, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите образец презентации с элементами управления ActiveX медиаплеера.
1. Создайте экземпляр целевого класса Presentation и сгенерируйте пустой экземпляр презентации.
1. Клонируйте слайд с элементом управления ActiveX медиаплеера из шаблонной презентации в целевую презентацию.
1. Получите доступ к клонированному слайду в целевой презентации.
1. Получите доступ к элементам управления ActiveX на слайде, обратившись к IControlCollection.
1. Получите доступ к элементу управления ActiveX медиаплеера и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.

``` cpp
// Создание экземпляра класса Presentation, представляющего файл PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Создание пустого экземпляра презентации
auto newPresentation = System::MakeObject<Presentation>();

// Удаление стандартного слайда
newPresentation->get_Slides()->RemoveAt(0);

// Клонирование слайда с элементом управления ActiveX медиаплеера
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Получите доступ к элементу управления ActiveX медиаплеера и задайте путь к видео
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Сохраните презентацию
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```