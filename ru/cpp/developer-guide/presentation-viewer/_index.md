---
title: Создание просмотрщика презентаций на C++
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/cpp/presentation-viewer/
keywords: 
- просмотр презентации
- просмотрщик презентаций
- создание просмотрщика презентаций
- просмотр PPT
- просмотр PPTX
- просмотр ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Создайте пользовательский просмотрщик презентаций на C++ с помощью Aspose.Slides. Легко отображайте файлы PowerPoint и OpenDocument без Microsoft PowerPoint."
---

Aspose.Slides for C++ используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint, например. Однако иногда разработчикам может потребоваться просматривать слайды как изображения в предпочитаемом просмотрщике изображений или создавать собственный просмотрщик презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельный слайд как изображение. Эта статья описывает, как это сделать.

## **Создать SVG‑изображение со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Откройте файловый поток.
1. Сохраните слайд как SVG‑изображение в файловый поток.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **Создать SVG с пользовательским идентификатором фигуры**

Aspose.Slides можно использовать для создания [SVG](https://docs.fileformat.com/page-description-language/svg/) со слайда с пользовательским идентификатором фигуры. Для этого используйте метод `set_Id` из [ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/). Класс `CustomSvgShapeFormattingController` может быть использован для задания идентификатора фигуры.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **Создать изображение эскиза слайда**

Aspose.Slides помогает генерировать эскизы слайдов. Чтобы создать эскиз слайда с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Получите эскиз изображения указанного слайда в заданном масштабе.
1. Сохраните эскиз в любом требуемом формате изображения.
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Создать эскиз слайда с пользовательскими размерами**

Чтобы создать изображение эскиза слайда с пользовательскими размерами, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Получите эскиз изображения указанного слайда с заданными размерами.
1. Сохраните эскиз в любом требуемом формате изображения.
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Создать эскиз слайда с примечаниями к докладчику**

Чтобы создать эскиз слайда с примечаниями к докладчику с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) .
1. Используйте метод `RenderingOptions.set_SlidesLayoutOptions`, чтобы задать позицию примечаний к докладчику.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Получите эскиз изображения слайда с учётом параметров рендеринга.
1. Сохраните эскиз в любом требуемом формате изображения.
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Живой пример**

Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) , чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

![Онлайн просмотрщик PowerPoint](online-PowerPoint-viewer.png)

## **Часто задаваемые вопросы**

**Могу ли я встроить просмотрщик презентаций в веб‑приложение?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в виде изображений или HTML и отображать их в браузере. Навигацию и масштабирование можно реализовать с помощью JavaScript для интерактивного опыта.

**Как лучше всего отображать слайды в пользовательском просмотрщике?**

Рекомендуемый подход — рендерить каждый слайд как изображение (например, PNG или SVG) либо конвертировать его в HTML с помощью Aspose.Slides, затем выводить результат в элементе picture (для десктопа) или в HTML‑контейнере (для веба).

**Как обрабатывать крупные презентации с большим количеством слайдов?**

Для больших презентаций стоит использовать отложенную загрузку или рендеринг по запросу. Это означает генерацию содержимого слайда только в момент, когда пользователь переходит к нему, что сокращает расход памяти и время загрузки.