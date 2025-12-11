---
title: Многопоточность в Aspose.Slides для C++
linktitle: Многопоточность
type: docs
weight: 200
url: /ru/cpp/multithreading/
keywords:
- многопоточность
- несколько потоков
- параллельная работа
- конвертировать слайды
- слайды в изображения
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Многопоточность Aspose.Slides для C++ ускоряет обработку PowerPoint и OpenDocument. Узнайте лучшие практики для эффективных рабочих процессов с презентациями."
---

## **Введение**

Хотя параллельная работа с презентациями возможна (за исключением анализа/загрузки/клонирования) и обычно всё проходит гладко (в большинстве случаев), существует небольшая вероятность получения неправильных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) в многопоточной среде, потому что это может привести к непредсказуемым ошибкам или сбоям, которые трудно обнаружить.

**Недопустимо** загружать, сохранять и/или клонировать объект класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) в нескольких потоках. Такие операции **не поддерживаются**. Если необходимо выполнить такие задачи, следует параллелить операции, используя несколько однопоточных процессов — и каждый из этих процессов должен использовать свой собственный экземпляр презентации.

## **Параллельное преобразование слайдов презентации в изображения**

Предположим, что нам нужно параллельно преобразовать все слайды PowerPoint‑презентации в PNG‑изображения. Поскольку использование единственного экземпляра `Presentation` в нескольких потоках небезопасно, мы разбиваем слайды на отдельные презентации и конвертируем их в изображения параллельно, используя каждый экземпляр в отдельном потоке. Ниже приведён пример кода, демонстрирующий этот подход.
```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Извлечь слайд i в отдельную презентацию.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Преобразовать слайд в изображение в отдельной задаче.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Ожидать завершения всех задач.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```


## **FAQ**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно выполнить её один раз за процесс/домент приложения до запуска потоков. Если настройка лицензии может вызываться одновременно (например, при отложенной инициализации), синхронизируйте этот вызов, поскольку сам метод настройки лицензии не является потокобезопасным.

**Можно ли передавать объекты `Presentation` или `Slide` между потоками?**

Передача «живых» объектов презентации между потоками не рекомендуется: используйте независимые экземпляры для каждого потока или заранее создавайте отдельные презентации/контейнеры слайдов для каждого потока. Этот подход соответствует общему совету не делить один экземпляр презентации между потоками.

**Безопасно ли параллельно экспортировать в разные форматы (PDF, HTML, изображения), если каждый поток имеет свой собственный экземпляр `Presentation`?**

Да. При наличии независимых экземпляров и отдельных путей вывода такие задачи обычно успешно параллелятся; избегайте совместного использования объектов презентации и общих потоков ввода/вывода.

**Как поступать с глобальными настройками шрифтов (папки, подстановки) в многопоточном режиме?**

Инициализируйте все глобальные параметры шрифтов до запуска потоков и не изменяйте их во время параллельной работы. Это устраняет гонки при обращении к общим шрифтовым ресурсам.