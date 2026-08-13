---
title: Эффективное объединение презентаций в C++
linktitle: Объединить презентации
type: docs
weight: 40
url: /ru/cpp/merge-presentation/
keywords:
- объединить PowerPoint
- объединить презентации
- объединить слайды
- объединить PPT
- объединить PPTX
- объединить ODP
- комбинировать PowerPoint
- комбинировать презентации
- комбинировать слайды
- комбинировать PPT
- комбинировать PPTX
- комбинировать ODP
- C++
- Aspose.Slides
description: "Без усилий объединяйте презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP) с помощью Aspose.Slides для C++, упрощая ваш рабочий процесс."
---
## **Обзор**

Aspose.Slides позволяет объединять презентации, клонируя слайды из одной презентации в другую. В этой статье объясняется, как объединять целые презентации или выбранные слайды, использовать мастер‑слайдов или конкретный макет во время объединения, работать с презентациями разного размера слайдов и добавлять объединённые слайды в раздел презентации. Также рассматриваются практические замечания, связанные с объединённым содержимым, включая заметки докладчика, комментарии, защищённые паролем исходные файлы и использование потоков.

## **Объединение презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически собираете их слайды в одну презентацию, получая один файл. 

{{% alert title="Info" color="info" %}}

Большинству программ для работы с презентациями (PowerPoint или OpenOffice) не хватает функций, позволяющих пользователям объединять презентации таким образом. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/ru/cpp/) , однако Aspose.Slides for C++ позволяет объединять презентации разными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстами, форматированием, комментариями, анимациями и т.д., не беспокоясь о потере качества или данных. 

**См. также**

[Клонировать слайды](https://docs.aspose.com/slides/ru/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Что можно объединять**

С помощью Aspose.Slides вы можете объединять 

* полные презентации. Все слайды из презентаций оказываются в одной презентации
* конкретные слайды. Выбранные слайды оказываются в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг к другу. 

{{% alert title="Note" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет объединять другие файлы:

* [Изображения](https://products.aspose.com/slides/ru/cpp/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/ru/cpp/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/ru/cpp/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/ru/cpp/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/ru/cpp/merger/html-to-html/)
* И два разных файла, такие как [изображение в PDF](https://products.aspose.com/slides/ru/cpp/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/ru/cpp/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/ru/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Опции объединения**

Вы можете применить параметры, определяющие, будет ли

* каждый слайд в результирующей презентации сохранять уникальный стиль
* для всех слайдов в результирующей презентации использовать один конкретный стиль. 

Для объединения презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_slide_collection)). Существует несколько реализаций методов `AddClone`, определяющих параметры процесса объединения презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), поэтому вы можете вызвать метод `AddClone` у презентации, в которую хотите добавить слайды. 

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в результирующей презентации просто копируются из исходных слайдов. Поэтому вы можете изменять полученные слайды (например, применять стили, параметры форматирования или макеты), не опасаясь, что исходные презентации будут затронуты. 

## **Объединить презентации** 

Aspose.Slides предоставляет метод [**AddClone (ISlide)**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), который позволяет объединять слайды, сохраняя их макеты и стили (параметры по умолчанию). 

Этот код на C++ показывает, как объединять презентации:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Объединить презентации с мастером слайдов** 

Aspose.Slides предоставляет метод [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), который позволяет объединять слайды, применяя шаблон мастера презентации. Таким образом при необходимости вы можете изменить стиль слайдов в результирующей презентации. 

Этот код на C++ демонстрирует описанную операцию:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Макет слайда для мастера определяется автоматически. Когда подходящий макет определить не удаётся, если логический параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Если вы хотите, чтобы слайды в результирующей презентации имели иной макет, используйте вместо этого метод [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) при объединении. 

## **Объединить отдельные слайды из презентаций** 

Объединение конкретных слайдов из нескольких презентаций полезно для создания кастомных наборов слайдов. Aspose.Slides C++ позволяет выбирать и импортировать только необходимые слайды. API сохраняет форматирование, макет и дизайн оригинальных слайдов.

Следующий код на C++ создает новую презентацию, добавляет заглавные слайды из двух других презентаций и сохраняет результат в файл:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Объявлено в коде выше.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Объединить презентации с макетом слайда** 

Этот код на C++ показывает, как объединять слайды из презентаций, применяя к ним предпочитаемый макет слайда, чтобы получить одну результирующую презентацию:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Объединить презентации с разными размерами слайдов** 

{{% alert title="Note" color="warning" %}} 

Нельзя объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить две презентации с разными размерами слайдов, необходимо изменить размер одной из презентаций, приведя его к размеру другой презентации. 

Этот пример кода демонстрирует описанную операцию:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Объединить слайды в раздел презентации** 

Этот код на C++ показывает, как объединить конкретный слайд в раздел презентации:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Слайд добавляется в конец раздела. 

{{% alert title="Tip" color="info" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб‑приложение Collage](https://products.aspose.app/slides/ru/collage). С помощью этого онлайн‑сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/ru/collage/jpg) или PNG в PNG изображения, создавать [фото‑сетки](https://products.aspose.app/slides/ru/collage/photo-grid) и т.д. 

{{% /alert %}}

## **FAQ**

### Сохраняются ли заметки докладчика при объединении?

Да. При клонировании слайдов Aspose.Slides переносит все элементы слайда, включая заметки, форматирование и анимацию.

### Переносятся ли комментарии и их авторы?

Комментарии, как часть содержимого слайда, копируются вместе со слайдом. Метки авторов сохраняются как объекты комментариев в результирующей презентации.

### Что делать, если исходная презентация защищена паролем?

Её необходимо [открыть с паролем](/slides/ru/cpp/password-protected-presentation/) с помощью [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/); после загрузки такие слайды можно безопасно клонировать в незащищённый целевой файл (или в защищённый тоже).

### Насколько потокобезопасна операция объединения?

Не используйте один и тот же объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) из нескольких потоков. Рекомендуемое правило — «один документ — один поток»; разные файлы можно обрабатывать параллельно в отдельных потоках.