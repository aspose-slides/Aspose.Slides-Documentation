---
title: Рамка для изображения
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "Добавить рамку для изображения, создать рамку для изображения, добавить изображение, создать изображение, извлечь изображение, свойство StretchOff, форматирование рамки для изображения, свойства рамки для изображения, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Добавьте рамку для изображения в презентацию PowerPoint на C++"
---

Рамка для изображения — это форма, которая содержит изображение, — это как изображение в рамке.

Вы можете добавить изображение на слайд через рамку для изображения. Таким образом, вы можете форматировать изображение, форматируя рамку для изображения.

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют людям быстро создавать презентации из изображений.

{{% /alert %}}

## **Создать рамку для изображения**

1. Создайте экземпляр [класса Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), связанное с объектом презентации, который будет использоваться для заполнения формы.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) на основе ширины и высоты изображения через метод `AddPictureFrame`, предоставляемый объектом формы, связанным с ссылочным слайдом.
6. Добавьте рамку для изображения (содержащую изображение) на слайд.
7. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать рамку для изображения:

```c++
// Путь к директории документов.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает изображение
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку для изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительное масштабирование по высоте и ширине
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Применяет форматирование к рамке для изображения
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width(20);
pf->set_Rotation(45);

// Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}}

Рамки для изображений позволяют быстро создавать слайды презентаций на основе изображений. Когда вы комбинируете рамку для изображения с параметрами сохранения Aspose.Slides, вы можете манипулировать операциями ввода/вывода, чтобы конвертировать изображения из одного формата в другой. Вы можете ознакомиться с этими страницами: конвертировать [изображение в JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/); конвертировать [PNG в JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/); конвертировать [SVG в PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Создать рамку для изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку для изображения.

1. Создайте экземпляр [класса Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), связанное с объектом презентации, который будет использоваться для заполнения формы.
5. Укажите относительную ширину и высоту изображения в рамке для изображения.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как создать рамку для изображения с относительным масштабом:

```c++
// Путь к директории документов.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает изображение
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку для изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительное масштабирование по высоте и ширине
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);

// Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Извлечь изображение из рамки для изображения**

Вы можете извлекать изображения из объектов [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) и сохранять их в форматах PNG, JPG и других. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Получить прозрачность изображения**

Aspose.Slides позволяет вам получить прозрачность изображения. Этот код на C++ демонстрирует операцию:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Прозрачность изображения: ") + transparencyValue);
    }
}
```

## **Форматирование рамки для изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые могут быть применены к рамке для изображения. Используя эти параметры, вы можете изменить рамку для изображения, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр [класса Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), связанное с объектом презентации, который будет использоваться для заполнения формы.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), предоставляемый объектом [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection), связанным с ссылочным слайдом.
6. Добавьте рамку для изображения (содержащую изображение) на слайд.
7. Установите цвет линии рамки для изображения.
8. Установите ширину линии рамки для изображения.
9. Поверните рамку для изображения, дав ей положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке.
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку для изображения (содержащую изображение) на слайд.
11. Запишите измененную презентацию в файл PPTX.

Этот код на C++ демонстрирует процесс форматирования рамки для изображения:

```c++
// Путь к директории документов.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает изображение
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку для изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительное масштабирование по высоте и ширине
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);

// Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Совет" color="primary" %}}

Aspose недавно разработал [бесплатный Коллаж создатель](https://products.aspose.app/slides/collage). Если вам когда-либо нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG изображения, [создать сетки из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете использовать этот сервис.

{{% /alert %}}

## **Добавить изображение как ссылку**

Чтобы избежать больших размеров презентации, вы можете добавлять изображения (или видео) через ссылки вместо того, чтобы встраивать файлы непосредственно в презентации. Этот код на C++ показывает, как добавить изображение и видео в заполнители:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Обрезать изображение**

Этот код на C++ показывает, как обрезать существующее изображение на слайде:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
// Создает новый объект изображения
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Добавляет рамку для изображения на слайд
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Обрезает изображение (процентные значения)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Сохраняет результат
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## Удалить обрезанные области изображения

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, вы можете использовать метод [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Этот метод возвращает обрезанное изображение или оригинальное изображение, если обрезка не требуется.

Этот код на C++ демонстрирует операцию:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Получает рамку для изображения с первого слайда
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Удаляет обрезанные области изображения рамки и возвращает обрезанное изображение
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Сохраняет результат
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Метод [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [рамке для изображения](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), эта настройка может уменьшить размер презентации. В противном случае количество изображений в итоговой презентации увеличится.

Этот метод конвертирует метафайлы WMF/EMF в растровое изображение PNG в процессе обрезки.

{{% /alert %}}

## **Сохранить аспектное соотношение**

Если вы хотите, чтобы форма, содержащая изображение, сохраняла свое аспектное соотношение даже после изменения размеров изображения, вы можете использовать метод [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) для установки параметра *Сохранить аспектное соотношение*.

Этот код на C++ показывает, как заблокировать аспектное соотношение формы:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// Задать форме постоянство аспектного соотношения при изменении размера
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Этот параметр *Сохранить аспектное соотношение* сохраняет только аспектное соотношение формы и не сохраняет изображение, которое она содержит.

{{% /alert %}}

## **Использовать свойство StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) и [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) и класса [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format), вы можете указать заполнение прямоугольника.

Когда растяжение изображения задано, исходный прямоугольник масштабируется так, чтобы соответствовать указанному заполненному прямоугольнику. Каждый край заполненного прямоугольника определяется процентным смещением от соответствующего края ограничивающего прямоугольника формы. Положительный процент указывает на вкладку. Отрицательный процент указывает на выдвижение.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольную `AutoShape`.
4. Создайте изображение.
5. Установите тип заливки формы.
6. Установите режим заливки изображения формы.
7. Добавьте установленное изображение для заполнения формы.
8. Укажите смещения изображения от соответствующего края ограничивающего прямоугольника формы.
9. Запишите измененную презентацию в файл PPTX.

Этот код на C++ демонстрирует процесс, в котором используется свойство StretchOff:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Устанавливает растяжение изображения с каждой стороны в теле формы
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```