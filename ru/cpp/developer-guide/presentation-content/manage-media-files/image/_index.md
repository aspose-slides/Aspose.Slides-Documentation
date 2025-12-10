---
title: Оптимизация управления изображениями в презентациях с использованием C++
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/cpp/image/
keywords:
- добавить изображение
- добавить картинку
- добавить bitmap
- заменить изображение
- заменить картинку
- из веба
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- EMF
- SVG
- C++
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для C++, повышая производительность и автоматизируя рабочий процесс."
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более захватывающими и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других источников на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды ваших презентаций различными способами. 

{{% alert title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение как объект кадра — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.п. — см. [Кадр изображения](/slides/ru/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете выполнять операции ввода/вывода, связанные с изображениями и презентациями PowerPoint, чтобы преобразовать изображение из одного формата в другой. Смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в популярных форматах: JPEG, PNG, GIF и других. 

## **Добавление локальных изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд презентации. Этот пример кода на C++ показывает, как добавить изображение на слайд:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```




## **Добавление изображений из веба на слайды**

Если нужное изображение отсутствует на вашем компьютере, вы можете добавить его напрямую из интернета. 

Этот пример кода показывает, как добавить изображение из веба на слайд в C++:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Добавление изображений в мастер‑слайды**

Мастер‑слайд — это верхний слайд, который хранит и контролирует информацию (тема, макет и т.п.) обо всех слайдах под ним. Поэтому, когда вы добавляете изображение в мастер‑слайд, это изображение появляется на каждом слайде, использующем данный мастер. 

Этот пример кода на C++ показывает, как добавить изображение в мастер‑слайд:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Добавление изображений в качестве фона слайдов**

Вы можете использовать картинку в качестве фона для отдельного слайда или нескольких слайдов. В этом случае см. *[Настройка изображений как фона для слайдов](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), принадлежащий интерфейсу [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

Чтобы создать объект изображения на основе SVG‑изображения, сделайте следующее:

1. Создайте объект SvgImage для вставки в ImageShapeCollection.  
2. Создайте объект PPImage из ISvgImage.  
3. Создайте объект PictureFrame, используя интерфейс IPPImage.  

Этот пример кода показывает, как реализовать описанные шаги для добавления SVG‑изображения в презентацию:
``` cpp 
// Путь к каталогу документов
System::String dataDir = u"D:\\Documents\\";

// Исходное имя SVG-файла
System::String svgFileName = dataDir + u"sample.svg";

// Имя файла выходной презентации
System::String outPptxPath = dataDir + u"presentation.pptx";

// Создать новую презентацию
auto p = System::MakeObject<Presentation>();

// Прочитать содержимое SVG-файла
System::String svgContent = File::ReadAllText(svgFileName);

// Создать объект SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Создать объект PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Создает новый PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Сохранить презентацию в формате PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **Преобразование SVG в набор фигур**
Преобразование SVG в набор фигур в Aspose.Slides аналогично функционалу PowerPoint, используемому для работы с SVG‑изображениями:

![Меню всплывающего окна PowerPoint](img_01_01.png)

Функционал предоставляется одной из перегрузок метода [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection), принимающей объект [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) в качестве первого аргумента.

Этот пример кода показывает, как использовать указанный метод для преобразования SVG‑файла в набор фигур:
``` cpp 
// Путь к каталогу документов
System::String dataDir = u"D:\\Documents\\";

// Имя исходного SVG‑файла
System::String svgFileName = dataDir + u"sample.svg";

// Имя выходного файла презентации
System::String outPptxPath = dataDir + u"presentation.pptx";

// Создать новую презентацию
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Прочитать содержимое SVG‑файла
System::String svgContent = File::ReadAllText(svgFileName);

// Создать объект SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Получить размер слайда
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Преобразовать SVG‑изображение в группу фигур, масштабируя его до размеров слайда
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Сохранить презентацию в формате PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **Добавление изображений в формате EMF на слайды**
Aspose.Slides для C++ позволяет генерировать EMF‑изображения из листов Excel и добавлять их в слайды с помощью Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Сохранить книгу в поток
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```


## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, которые используются фигурами слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с использованием необработанных байтовых данных, экземпляра [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) или другого изображения, уже находящегося в коллекции.

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Загрузите новое изображение из файла в массив байтов.  
3. Замените целевое изображение новым, используя массив байтов.  
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) и замените целевое изображение этим объектом.  
5. В третьем подходе замените целевое изображение изображением, уже присутствующим в коллекции изображений презентации.  
6. Сохраните изменённую презентацию в файл PPTX.  
```cpp
// Создать экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Первый способ.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Второй способ.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Третий способ.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Сохранить презентацию в файл.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}

Используя бесплатный конвертер Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif), вы можете легко анимировать тексты, создавать GIF‑изображения из текста и т.д. 

{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но конечный вид зависит от того, как [картинка](/slides/ru/cpp/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Как лучше всего заменить один и тот же логотип сразу на десятках слайдов?**

Разместите логотип на мастер‑слайде или макете и замените его в коллекции изображений презентации — изменения автоматически отразятся во всех элементах, использующих данный ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете преобразовать SVG в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.

**Как установить изображение в качестве фона сразу для нескольких слайдов?**

[Назначьте изображение как фон](/slides/ru/cpp/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие этот мастер/макет, наследуют фон.

**Как предотвратить «раздувание» размера презентации из‑за большого количества картинок?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и, при необходимости, размещайте повторяющиеся графические элементы в мастере.