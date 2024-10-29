---
title: Изображение
type: docs
weight: 10
url: /ru/cpp/image/
---


## **Изображения в слайдах презентаций**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять изображения из файла, интернета или других мест на слайды. Точно так же Aspose.Slides позволяет вам добавлять изображения на слайды в ваших презентациях различными способами.

{{% alert title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют людям быстро создавать презентации из изображений.

{{% /alert %}} 

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение в качестве объекта рамки — особенно если вы планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и так далее — смотрите [Рамка для изображения](/slides/ru/cpp/picture-frame/).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}}

Вы можете управлять операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. Смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в этих популярных форматах: JPEG, PNG, GIF и других.

## **Добавление изображений, хранящихся локально, на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Этот пример кода на C++ показывает, как добавить изображение на слайд:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Добавление изображений с веба на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить изображение непосредственно с веба.

Этот пример кода показывает, как добавить изображение с веба на слайд на C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[ЗАМЕНИТЕ НА URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Добавление изображений в мастер-слайды**

Мастер-слайд — это верхний слайд, который хранит и контролирует информацию (тему, макет и т. д.) обо всех слайдах под ним. Поэтому, когда вы добавляете изображение в мастер-слайд, это изображение появляется на каждом слайде под этим мастер-слайдом.

Этот пример кода на C++ показывает, как добавить изображение в мастер-слайд:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Добавление изображений в качестве фона слайда**

Вы можете решить использовать изображение в качестве фона для конкретного слайда или нескольких слайдов. В этом случае вам нужно посмотреть *[Установка изображений в качестве фонов для слайдов](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Вставка/Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

Чтобы создать объект изображения на основе SVG, вы можете сделать это следующим образом:

1. Создайте объект SvgImage, чтобы вставить его в ImageShapeCollection
2. Создайте объект PPImage из ISvgImage
3. Создайте объект PictureFrame, используя интерфейс IPPImage

Этот пример кода показывает, как реализовать описанные шаги для добавления SVG-изображения в презентацию:
``` cpp 
// Путь к директории документов
System::String dataDir = u"D:\\Documents\\";

// Имя исходного SVG-файла
System::String svgFileName = dataDir + u"sample.svg";

// Имя выходного файла презентации
System::String outPptxPath = dataDir + u"presentation.pptx";

// Создайте новую презентацию
auto p = System::MakeObject<Presentation>();

// Прочитайте содержимое SVG-файла
System::String svgContent = File::ReadAllText(svgFileName);

// Создайте объект SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Создайте объект PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Создайте новый PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Сохраните презентацию в формате PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Конвертация SVG в набор фигур**
Конвертация SVG в набор фигур в Aspose.Slides аналогична функциональности PowerPoint, используемой для работы с SVG-изображениями:


![Всплывающее меню PowerPoint](img_01_01.png)

Эта функциональность предоставляется одним из перегруженных методов [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для конвертации SVG-файла в набор фигур:

``` cpp 
// Путь к директории документов
System::String dataDir = u"D:\\Documents\\";

// Имя исходного SVG-файла
System::String svgFileName = dataDir + u"sample.svg";

// Имя выходного файла презентации
System::String outPptxPath = dataDir + u"presentation.pptx";

// Создайте новую презентацию
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Прочитайте содержимое SVG-файла
System::String svgContent = File::ReadAllText(svgFileName);

// Создайте объект SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Получите размер слайда
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Конвертируйте SVG-изображение в группу фигур, масштабируя его до размера слайда
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Сохраните презентацию в формате PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Добавление изображений как EMF на слайдах**
Aspose.Slides для C++ позволяет генерировать EMF-изображения из таблиц Excel и добавлять изображения как EMF на слайды с помощью Aspose.Cells.

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

// Сохраните рабочую книгу в поток
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

{{% alert title="Информация" color="info" %}}

Используя бесплатный конвертер Aspose [Текст в GIF](https://products.aspose.app/slides/text-to-gif), вы можете легко анимировать тексты, создавать GIF-изображения из текстов и т. д. 

{{% /alert %}}