---
title: У管理 ActiveX‑контролями в презентациях с использованием C++
linktitle: ActiveX
type: docs
weight: 80
url: /ru/cpp/activex/
keywords:
- ActiveX
- ActiveX‑контрол
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for C++ использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

ActiveX‑контролы используются в презентациях. Aspose.Slides for C++ позволяет управлять ActiveX‑контролями, но их управление немного сложнее и отличается от обычных фигур презентации. Начиная с Aspose.Slides for C++ 18.1 компонент поддерживает управление ActiveX‑контролями. В данный момент вы можете получить доступ к уже добавленному ActiveX‑контролю в вашей презентации и изменить или удалить его, используя его различные свойства. Помните, ActiveX‑контролы не являются фигурами и не входят в IShapeCollection презентации, а находятся в отдельном IControlCollection. В этой статье показано, как работать с ними.

## **Изменить ActiveX‑контрол**
Для управления простым ActiveX‑контролем, таким как текстовое поле и простая кнопка команд на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию, содержащую ActiveX‑контролы.  
2. Получите ссылку на слайд по его индексу.  
3. Получите доступ к ActiveX‑контролям на слайде, обратившись к IControlCollection.  
4. Получите доступ к ActiveX‑контролю TextBox1 с помощью объекта ControlEx.  
5. Измените различные свойства ActiveX‑контроля TextBox1, включая текст, шрифт, высоту шрифта и позицию рамки.  
6. Получите доступ ко второму элементу управления под названием CommandButton1.  
7. Измените подпись кнопки, шрифт и позицию.  
8. Сдвиньте позицию рамок ActiveX‑контролей.  
9. Запишите изменённую презентацию в файл PPTX.

Приведённый ниже фрагмент кода обновляет ActiveX‑контролы на слайдах презентации, как показано ниже.  
``` cpp
// Доступ к презентации с  ActiveX‑контролями
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Доступ к первому слайду в презентации
auto slide = presentation->get_Slides()->idx_get(0);

// изменение текста TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // изменение заменяющего изображения. Powerpoint заменит это изображение при активации ActiveX, поэтому иногда можно оставить изображение без изменений.
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

// изменение подписи кнопки
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // изменение заменяющего
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

// Сохранить презентацию с отредактированными ActiveX‑контролями
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Теперь удаляем элементы управления
slide->get_Controls()->Clear();

// Сохранение презентации с очищенными ActiveX‑контролями
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **Добавить ActiveX‑контрол Media Player**
ActiveX‑контролы используются в презентациях. Aspose.Slides for C++ позволяет добавлять и управлять ActiveX‑контролами, но их управление несколько сложнее и отличается от обычных фигур презентации. Начиная с Aspose.Slides for C++ 18.1 поддержка добавления ActiveX‑контроля Media Player была включена в Aspose.Slides. Помните, ActiveX‑контролы не являются фигурами и не входят в IShapeCollection презентации, а находятся в отдельном IControlExCollection. В этой статье показано, как работать с ними. Чтобы управлять ActiveX‑контролем Media Player, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите образец презентации, содержащий ActiveX‑контролы Media Player.  
2. Создайте экземпляр целевого класса Presentation и создайте пустой экземпляр презентации.  
3. Клонируйте слайд с ActiveX‑контролем Media Player из шаблонной презентации в целевую презентацию.  
4. Получите доступ к склонированному слайду в целевой презентации.  
5. Получите доступ к ActiveX‑контролям на слайде, обратившись к IControlCollection.  
6. Получите доступ к ActiveX‑контролю Media Player и задайте путь к видео, используя его свойства.  
7. Сохраните презентацию в файл PPTX.  
``` cpp
// Создать объект класса Presentation, представляющий файл PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Создать пустой экземпляр презентации
auto newPresentation = System::MakeObject<Presentation>();

// Удалить слайд по умолчанию
newPresentation->get_Slides()->RemoveAt(0);

// Клонировать слайд с ActiveX‑контролем Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Получить доступ к ActiveX‑контролю Media Player и задать путь к видео
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Сохранить презентацию
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Сохраняет ли Aspose.Slides ActiveX‑контролы при чтении и повторном сохранении, если они не могут быть выполнены в среде выполнения C++?**  
Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; выполнение самих контролов не требуется для их сохранения.

**Чем отличаются ActiveX‑контролы от объектов OLE в презентации?**  
ActiveX‑контролы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/cpp/manage-ole/) относится к встроенным объектам приложений (например, листу Excel). Они хранятся и обрабатываются по‑разному и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**  
Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы работают только внутри PowerPoint на Windows при разрешённых настройках безопасности. Библиотека не выполняет VBA.