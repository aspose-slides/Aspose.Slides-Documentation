---
title: Конвертировать PPT и PPTX в JPG на C++
linktitle: PowerPoint в JPG
type: docs
weight: 60
url: /ru/cpp/convert-powerpoint-to-jpg/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в JPG
- презентацию в JPG
- слайд в JPG
- PPT в JPG
- PPTX в JPG
- сохранить PowerPoint как JPG
- сохранить презентацию как JPG
- сохранить слайд как JPG
- сохранить PPT как JPG
- сохранить PPTX как JPG
- экспортировать PPT в JPG
- экспортировать PPTX в JPG
- C++
- Aspose.Slides
description: "Конвертировать слайды PowerPoint (PPT, PPTX) в высококачественные JPG изображения на C++ с помощью Aspose.Slides, используя быстрые и надежные примеры кода."
---

## **Обзор**

Преобразование презентаций PowerPoint и OpenDocument в изображения JPG помогает делиться слайдами, повышать производительность и встраивать контент в веб‑сайты или приложения. Aspose.Slides for C++ позволяет преобразовать файлы PPTX, PPT и ODP в изображения JPEG высокого качества. В этом руководстве объясняются различные методы конвертации.

Благодаря этим возможностям легко реализовать собственный просмотрщик презентаций и создавать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды от копирования или демонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет преобразовать всю презентацию или отдельный слайд в графические форматы.

## **Преобразовать слайды презентации в изображения JPG**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) из коллекции слайдов презентации.
3. Создайте изображение слайда с помощью метода [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).
4. Вызовите метод [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) у объекта изображения. Передайте в него имя выходного файла и формат изображения в качестве аргументов.

{{% alert color="primary" %}} 

**Примечание:** Конвертация PPT, PPTX или ODP в JPG отличается от конвертации в другие форматы в API Aspose.Slides for C++. Для других форматов обычно используется метод [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). Однако для конвертации в JPG необходимо использовать метод [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Создать изображение слайда с указанным масштабом.
    auto image = slide->GetImage(scaleX, scaleY);

    // Сохранить изображение на диск в формате JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Преобразовать слайды в JPG с пользовательскими размерами**

Чтобы изменить размеры получаемых изображений JPG, вы можете задать размер изображения, передав его в метод [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Это позволяет генерировать изображения с конкретными значениями ширины и высоты, гарантируя, что результат соответствует вашим требованиям к разрешению и соотношению сторон. Такая гибкость особенно полезна при создании изображений для веб‑приложений, отчетов или документации, где требуются точные размеры изображения.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Создать изображение слайда указанного размера.
    auto image = slide->GetImage(imageSize);

    // Сохранить изображение на диск в формате JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Отображать комментарии при сохранении слайдов как изображения**

Aspose.Slides for C++ предоставляет возможность отображать комментарии на слайдах презентации при их конвертации в изображения JPG. Эта функция особенно полезна для сохранения аннотаций, отзывов или обсуждений, добавленных сотрудниками в презентациях PowerPoint. Включив эту опцию, вы гарантируете, что комментарии будут видны на созданных изображениях, что упрощает их просмотр и обмен отзывами без необходимости открывать исходный файл презентации.

Предположим, у нас есть файл презентации "sample.pptx" со слайдом, содержащим комментарии:

![The slide with comments](slide_with_comments.png)

Следующий код C++ конвертирует слайд в изображение JPG, сохраняя комментарии:
```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Задать параметры для комментариев слайда.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Преобразовать первый слайд в изображение.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```


Результат:

![The JPG image with comments](image_with_comments.png)

## **Смотрите также**

Смотрите другие варианты конвертации PPT, PPTX или ODP в изображения, например:

- [Преобразовать PowerPoint в GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/)
- [Преобразовать PowerPoint в PNG](/slides/ru/cpp/convert-powerpoint-to-png/)
- [Преобразовать PowerPoint в TIFF](/slides/ru/cpp/convert-powerpoint-to-tiff/)
- [Преобразовать PowerPoint в SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в изображения JPG, попробуйте эти бесплатные онлайн‑конвертеры: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}}

![Бесплатный онлайн‑конвертер PPTX в JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

[Aspose предоставляет бесплатное веб‑приложение Collage](https://products.aspose.app/slides/collage). С помощью этой онлайн‑службы вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑сеточки](https://products.aspose.app/slides/collage/photo-grid) и т.д.

Используя те же принципы, описанные в этой статье, вы можете конвертировать изображения из одного формата в другой. Для получения дополнительной информации см. следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживает ли этот метод пакетную конвертацию?**

Да, Aspose.Slides позволяет выполнять пакетную конвертацию нескольких слайдов в JPG за одну операцию.

**Поддерживает ли конвертация SmartArt, диаграммы и другие сложные объекты?**

Да, Aspose.Slides отображает всё содержимое, включая SmartArt, диаграммы, таблицы, фигуры и многое другое. Однако точность отображения может немного отличаться от PowerPoint, особенно при использовании пользовательских или отсутствующих шрифтов.

**Есть ли ограничения на количество слайдов, которые можно обработать?**

Сам Aspose.Slides не накладывает строгих ограничений на количество обрабатываемых слайдов. Однако при работе с крупными презентациями или изображениями высокого разрешения вы можете столкнуться с ошибкой нехватки памяти.