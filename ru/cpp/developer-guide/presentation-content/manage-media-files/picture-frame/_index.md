---
title: Управление рамками изображений в презентациях с использованием C++
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/cpp/picture-frame/
keywords:
  - рамка изображения
  - добавить рамку изображения
  - создать рамку изображения
  - добавить изображение
  - создать изображение
  - извлечь изображение
  - растровое изображение
  - векторное изображение
  - обрезать изображение
  - обрезанная область
  - свойство StretchOff
  - форматирование рамки изображения
  - свойства рамки изображения
  - относительный масштаб
  - эффект изображения
  - соотношение сторон
  - прозрачность изображения
  - PowerPoint
  - OpenDocument
  - презентация
  - C++
  - Aspose.Slides
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Оптимизируйте рабочий процесс и улучшите дизайн слайдов."
---

Рамка изображения — это форма, содержащая картинку; она похожа на фотографию в раме. 

Вы можете добавить изображение в слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), связанную с объектом презентации, которое будет использоваться для заполнения формы.  
4. Укажите ширину и высоту изображения.  
5. Создайте [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) на основе ширины и высоты изображения через метод `AddPictureFrame`, доступный у объекта формы, связанного с выбранным слайдом.  
6. Добавьте рамку изображения (содержит картинку) на слайд.  
7. Сохраните изменённую презентацию как файл PPTX.  

Этот код C++ показывает, как создать рамку изображения:
```c++
// Путь к каталогу документов.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загрузите нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает картинку
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительные масштаб ширины и высоты
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Применяет некоторое форматирование к рамке изображения
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="warning" %}} 

Рамки изображения позволяют быстро создавать слайды презентаций на основе картинок. При сочетании рамки изображения с параметрами сохранения Aspose.Slides можно управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вам будут интересны эти страницы: конвертировать [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).  

{{% /alert %}}

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку изображения.  

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте изображение в коллекцию изображений презентации.  
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), связанную с объектом презентации, которое будет использоваться для заполнения формы.  
5. Укажите относительные ширину и высоту изображения в рамке изображения.  
6. Сохраните изменённую презентацию как файл PPTX.  

Этот код C++ показывает, как создать рамку изображения с относительным масштабом:
```c++
// Путь к каталогу документов.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает требуемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает картинку
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительные масштаб ширины и высоты
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Извлечение растровых изображений из рамок изображения**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) и сохранять их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.  
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


## **Извлечение SVG‑изображений из рамок изображения**

Когда в презентации находятся SVG‑графики, размещённые внутри форм [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), Aspose.Slides for C++ позволяет извлечь оригинальные векторные изображения с полной точностью. Путём перебора коллекции форм слайда можно определить каждую [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), проверить, содержит ли связанный [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его родном SVG‑формате.  

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки изображения:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```


## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот код C++ демонстрирует операцию:
```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```


{{% alert color="primary" %}} 
Все эффекты, применяемые к изображениям, можно найти в [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/).  
{{% /alert %}}

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. Используя эти параметры, вы можете изменить рамку изображения в соответствии с конкретными требованиями.  

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), связанную с объектом презентации, которое будет использоваться для заполнения формы.  
4. Укажите ширину и высоту изображения.  
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), доступный у объекта [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection), связанного с выбранным слайдом.  
6. Добавьте рамку изображения (содержит картинку) на слайд.  
7. Установите цвет линии рамки изображения.  
8. Установите ширину линии рамки изображения.  
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.  
10. Добавьте рамку изображения (содержит картинку) на слайд.  
11. Сохраните изменённую презентацию как файл PPTX.  

Этот код C++ демонстрирует процесс форматирования рамки изображения:
```c++
// Путь к каталогу документов.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Загружает требуемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
// Получает картинку
auto image = Images::FromFile(filePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Добавляет рамку изображения на слайд
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Устанавливает относительные масштаб ширины и высоты
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Записывает файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert title="Tip" color="primary" %}}

Aspose недавно разработала [free Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этой службой.  

{{% /alert %}}

## **Добавление изображения как ссылки**

Чтобы избежать больших размеров презентаций, вы можете добавлять изображения (или видео) через ссылки, вместо встраивания файлов непосредственно в презентацию. Этот код C++ показывает, как добавить изображение и видео в заполнитель:
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


## **Обрезка изображений**

Этот код C++ показывает, как обрезать существующее изображение на слайде:  
```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Создает новый объект изображения
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Добавляет PictureFrame на слайд
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Обрезает изображение (значения в процентах)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Сохраняет результат
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Удаление обрезанных областей рамки изображения**

Если нужно удалить обрезанные области изображения, содержащегося в рамке, вы можете воспользоваться методом [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Этот метод возвращает обрезанное изображение или оригинальное изображение, если обрезка не требуется.  

Этот код C++ демонстрирует операцию:  
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```


{{% alert title="NOTE" color="warning" %}} 

Метод [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.  

Этот метод конвертирует метафайлы WMF/EMF в растровое PNG‑изображение в процессе обрезки.  

{{% /alert %}}

## **Блокировка соотношения сторон**

Если нужно, чтобы форма, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, используйте метод [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) для установки параметра *Lock Aspect Ratio*.  

Этот код C++ показывает, как заблокировать соотношение сторон формы:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```


{{% alert title="NOTE" color="warning" %}} 

Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон формы, а не изображения, которое она содержит.  

{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) и [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) и класса [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) можно задать прямоугольник заполнения.  

При указании растяжения изображения исходный прямоугольник масштабируется до заданного прямоугольника заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего прямоугольника формы. Положительный процент задаёт отступ, отрицательный — выступ.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте прямоугольник `AutoShape`.  
4. Создайте изображение.  
5. Установите тип заполнения формы.  
6. Установите режим заполнения формы картинкой.  
7. Добавьте изображение для заполнения формы.  
8. Укажите смещения изображения от соответствующей грани ограничивающего прямоугольника формы.  
9. Сохраните изменённую презентацию как файл PPTX.  

Этот код C++ демонстрирует процесс использования свойства StretchOff:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, который назначается [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/). Список поддерживаемых форматов в основном совпадает с возможностями движка конвертации слайдов и изображений.  

**Как добавление десятков больших изображений влияет на размер и производительность PPTX?**

Встраивание крупных изображений увеличивает размер файла и потребление памяти; привязка изображений позволяет уменьшить размер презентации, но требует наличия внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для сокращения размера файла.  

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**

Используйте [shape locks](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/get_pictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размера). Механизм блокировки описан в отдельной [статье о защите](/slides/ru/cpp/applying-protection-to-presentation/) и поддерживается для разных типов форм, включая [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/).  

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) в оригинальном векторном виде. При [экспорте в PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/) или в [растровые форматы](/slides/ru/cpp/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт сохранения оригинального SVG как вектора подтверждается поведением извлечения.