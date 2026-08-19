---
title: Оптимизация управления изображениями в презентациях с использованием C++
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/cpp/image/
keywords:
- добавить изображение
- добавить картинку
- заменить изображение
- коллекция изображений
- рамка изображения
- связанное изображение
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- SVG в фигуры
- внешние SVG ресурсы
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как добавлять, повторно использовать, связывать, заменять и управлять растровыми и SVG-изображениями в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++."
---
## **Введение**

Aspose.Slides for C++ предоставляет несколько способов работы с изображениями, каждый из которых служит своей цели. Вы можете хранить изображение в презентации, отображать его в рамке изображения, использовать его как фон слайда, связать с внешним изображением, заменить общий ресурс изображения или преобразовать содержимое SVG в редактируемые фигуры.

Эта статья посвящена ресурсам изображений и тому, как они используются в презентации. Для кадрирования, прозрачности, эффектов, растяжения и другого форматирования, применяемого к отдельной рамке изображения, см. [Рамка изображения](/slides/ru/cpp/picture-frame/).

## **Понимание модели изображения**

- [Коллекция изображений презентации](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/) хранит ресурсы изображений, используемые в презентации. Используйте [IImageCollection::AddImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/addimage/) для добавления данных изображения и получения ресурса [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).
- [Рамка изображения](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) — это фигура, отображающая изображение на слайде, макете или мастере. Используйте [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addpictureframe/) для размещения ресурса изображения на слайде.
- Фон слайда использует изображение как часть заливки слайда, а не как фигуру. Поэтому он не ведёт себя как рамка изображения.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/replaceimage/) заменяет ресурс изображения. Если несколько элементов презентации используют этот ресурс, они все используют замену.
- Преобразование SVG в фигуры создаёт редактируемые фигуры слайда. После преобразования содержимое более не управляется как один ресурс изображения.

Типичный рабочий процесс выглядит так: добавить данные изображения в коллекцию изображений, получить [IPPImage], а затем использовать этот ресурс в одной или нескольких рамках изображения или заливках.

## **Добавление встроенного изображения**

Чтобы вставить локальное изображение, прочитайте файл, добавьте его данные в коллекцию изображений и создайте рамку изображения, использующую полученный ресурс [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Изображение, добавленное таким образом, встраивается в презентацию, поэтому полученный файл не зависит от наличия исходного файла изображения.

### **Добавление изображения из веба**

Когда изображение доступно по HTTP или HTTPS, загрузите его байты, добавьте их в коллекцию изображений презентации и используйте полученный ресурс изображения так же, как локальное изображение.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Проверяйте удалённые URL‑адреса, размер ответов и типы содержимого, если источник не заслуживает доверия. В приложениях, где уже используется другой HTTP‑клиент, вы можете загрузить изображение этим клиентом и передать полученные байты или поток в [IImageCollection::AddImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/addimage/).

## **Повторное использование изображений на разных слайдах**

Если одно и то же изображение требуется более одного раза, добавьте его в презентацию один раз и повторно используйте полученный [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) при создании дополнительных рамок изображения. Это избавляет от повторной загрузки одних и тех же исходных данных и явно связывает общий ресурс изображения с его использующими объектами.

Для графики, которую нужно автоматически отображать на многих слайдах (например, логотип компании), рассмотрите возможность размещения рамки изображения на [мастере слайда](/slides/ru/cpp/slide-master/) или макете вместо добавления эквивалентной фигуры на каждый слайд.

## **Использование изображения в качестве фона слайда**

Фоновое изображение назначается заливке слайда; оно не добавляется как фигура‑рамка изображения. Это полезно, когда изображение должно покрывать фон слайда и не должно манипулироваться как обычный объект слайда.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для дополнительных вариантов фоновых изображений, включая фоны мастеров и макетов, см. [Фон презентации](/slides/ru/cpp/presentation-background/).

## **Встроенные и связанные изображения**

Встроенные и связанные изображения имеют разные компромиссы по портативности и размеру файла:

- **Встроенное изображение:** данные изображения хранятся внутри презентации. Презентация автономна, но размер файла включает данные изображения.
- **Связанное изображение:** презентация хранит путь или URL к внешнему изображению. Это может уменьшить размер презентации, но внешний ресурс должен быть доступен при открытии или рендеринге.

Связанное изображение можно создать, задав внешний путь или URL через [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/set_linkpathlong/) вместо встраивания данных изображения.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Используйте связанные изображения только тогда, когда окружение развертывания может надёжно получать внешний ресурс. Для презентаций, которые должны работать офлайн или перемещаться между системами, обычно безопаснее использовать встроенные изображения.

## **Работа с SVG‑изображениями**

SVG — векторный формат, поэтому он полезен для значков, диаграмм и другой графики, которую нужно масштабировать без потери детализации, характерной для растровых изображений. Aspose.Slides поддерживает SVG как ресурс изображения и как источник редактируемых фигур слайда.

### **Добавление SVG в виде изображения**

Создайте [SvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/svgimage/), добавьте его в коллекцию изображений и разместите полученный ресурс изображения в рамке изображения.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **SVG‑файлы с внешними ресурсами**

SVG может ссылаться на внешние изображения, таблицы стилей или шрифты. Для таких случаев [SvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/svgimage/) предоставляет конструкторы, принимающие [IExternalResourceResolver](https://reference.aspose.com/slides/ru/cpp/aspose.slides.import/iexternalresourceresolver/) и базовый URI. Резольвер может сопоставлять относительный URI с разрешённым абсолютным URI и возвращать поток для запрошенного ресурса.

Резольвер делает внешние ресурсы доступными во время обработки SVG Aspose.Slides, но не переписывает SVG в самодостаточный документ. Если SVG должен оставаться портативным, встраивайте требуемые ресурсы непосредственно в SVG, например, используя URI `data:` для связанных изображений.

Когда SVG‑файлы поступают из ненадёжных источников, ограничьте схемы, расположения файлов и хосты, к которым резольвер может обращаться. Сетевые резольверы также должны применять тайм‑ауты, ограничения размера ответов и проверку содержимого.

### **Преобразование SVG в редактируемые фигуры**

Aspose.Slides может преобразовать SVG в группу редактируемых фигур слайда, аналогично соответствующей команде PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Используйте перегруженный метод [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addgroupshape/), принимающий [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/), для выполнения преобразования.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Применяйте преобразование SVG‑в‑фигуры, когда отдельные векторные элементы необходимо редактировать как фигуры PowerPoint. Если SVG только нужно отобразить, храните его как изображение — это проще и не создаёт множество отдельных фигур.

## **Замена существующего ресурса изображения**

Используйте [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/replaceimage/), когда нужно заменить существующий ресурс изображения. Это особенно полезно для общих графических элементов, таких как логотипы.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Если несколько рамок изображения, фоновых заливок, мастеров или макетов используют один и тот же ресурс изображения, замена этого ресурса обновит все их использования. Если нужно изменить только одну рамку изображения, задайте другой ресурс для этой рамки вместо замены общего ресурса.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/replaceimage/) также предоставляет перегрузки, принимающие [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) или другой [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).

## **Практические рекомендации по управлению изображениями**

### **Контроль размера презентации**

Большие растровые изображения могут сделать презентацию избыточно большой. Используйте исходные изображения с размерами, соответствующими их предполагаемому месту отображения, повторно используйте общие ресурсы изображений, где это возможно, и избегайте встраивания повторяющихся копий одного и того же графического файла высокого разрешения.

Для уже размещённых в рамках изображения растровых картинок можно применить [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/compressimage/) — это уменьшит данные изображения в соответствии с выбранным разрешением и настройками обрезки. Это обработка рамки изображения, а не управление коллекцией изображений, поэтому см. [Рамка изображения](/slides/ru/cpp/picture-frame/) для связанных операций форматирования.

### **Выбор между встроенным и связанным содержимым**

Встраивание делает презентацию портативной, поскольку все необходимые данные изображений находятся в одном файле. Связывание может уменьшить размер файла, но вводит внешнюю зависимость. Используйте ссылки только тогда, когда такая зависимость приемлема и стабильна.

### **Повторное использование общего фирменного стиля**

Для повторяющихся логотипов, водяных знаков или декоративных графических элементов используйте один ресурс изображения и переиспользуйте его. Если графика относится к дизайну презентации, а не к содержимому слайдов, разместите её на мастере или макете, чтобы она наследовалась соответствующими слайдами.

### **Обеспечение портативности SVG‑ресурсов**

Самодостаточный SVG проще перемещать и рендерить последовательно, чем SVG, зависящий от внешних файлов или сетевых ресурсов. По возможности встраивайте необходимые ресурсы до импорта SVG. Преобразуйте SVG в фигуры только тогда, когда отдельные векторные элементы требуется редактировать.

### **Использование API изображений Aspose.Slides**

Для C++‑рабочих процессов с изображениями используйте API Aspose.Slides [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) и [Images](https://reference.aspose.com/slides/ru/cpp/aspose.slides/images/), когда нужен объект изображения, и используйте [IImageCollection::AddImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/addimage/), когда необходимо зарегистрировать данные изображения как ресурс презентации. Перегрузки коллекции также поддерживают массивы байтов и потоки, что удобно, когда данные изображения поступают из файлов, сетевых клиентов, баз данных или других библиотек.

Генерация содержимого EMF из электронных таблиц или другого продукта — это отдельный процесс интеграции и выходит за рамки данной статьи. Если существующий файл WMF или EMF нужно лишь вставить в презентацию, передайте его данные в соответствующую перегрузку [IImageCollection::AddImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/addimage/) без добавления зависимости от второго продукта в процесс управления изображениями.

## **FAQ**

**В чём разница между коллекцией изображений и рамкой изображения?**

Коллекция изображений хранит переиспользуемые ресурсы изображений. Рамка изображения — это фигура слайда, отображающая один из этих ресурсов и предоставляющая специфическое для изображения форматирование, такое как обрезка и эффекты.

**Как лучше всего заменить один и тот же логотип повсюду?**

Если логотип уже общим ресурсом изображения, замените его с помощью [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/replaceimage/). Для фирменного оформления всей презентации также можно разместить логотип на мастере или макете, что сократит дублирование содержимого слайдов.

**Почему связанное изображение исчезает на другом компьютере?**

Связанное изображение зависит от внешнего файла или URL‑адреса. Если ресурс недоступен с другого компьютера, связанное изображение будет недоступно. Встраивайте изображение, когда презентация должна быть автономной.

**Можно ли отредактировать вставленный SVG как фигуры PowerPoint?**

Да. Преобразуйте SVG с помощью [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addgroupshape/); полученная группа будет содержать редактируемые фигуры слайда вместо одного SVG‑изображения.

**Как сделать большие презентации с множеством изображений меньше?**

Повторно используйте общие ресурсы изображений, избегайте излишне больших растровых исходников, при необходимости сжимайте подходящие растровые картинки, размещайте часто используемую брендинговую графику на мастерах или макетах и используйте связанные изображения только тогда, когда внешняя зависимость приемлема.