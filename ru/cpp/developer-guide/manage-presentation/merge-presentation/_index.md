---
title: Эффективное объединение презентаций на C++
linktitle: Объединение презентаций
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
description: "Легко объединяйте презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP) с помощью Aspose.Slides для C++, оптимизируя ваш рабочий процесс."
---

{{% alert  title="Tip" color="primary" %}} 

Возможно, вам будет интересно ознакомиться с **Aspose бесплатным онлайн** [Merger app](https://products.aspose.app/slides/merger). Приложение позволяет объединять презентации PowerPoint в одинаковом формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

При объединении одной презентации с другой вы фактически комбинируете их слайды в одну презентацию, получая один файл. 

{{% alert title="Info" color="info" %}}

Большинство программ для работы с презентациями (PowerPoint или OpenOffice) не предоставляют функций, позволяющих пользователям комбинировать презентации таким образом. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) , однако, позволяет выполнять слияние презентаций различными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстом, форматированием, комментариями, анимациями и т.п., не опасаясь потери качества или данных. 

**See also**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **What Can Be Merged**

С помощью Aspose.Slides можно объединять 

* целые презентации. Все слайды из исходных презентаций попадают в одну презентацию  
* отдельные слайды. Выбранные слайды складываются в одну презентацию  
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг с другом. 

{{% alert title="Note" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет объединять и другие типы файлов:

* [Images](https://products.aspose.com/slides/cpp/merger/image-to-image/), например [JPG to JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) или [PNG to PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)  
* Документы, такие как [PDF to PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) или [HTML to HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)  
* А также два разных файла, например [image to PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) или [TIFF to PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/). 

{{% /alert %}}

### **Merging Options**

Можно задать параметры, определяющие, будет ли

* каждый слайд в результирующей презентации сохранять уникальный стиль  
* один общий стиль применяться ко всем слайдам в результирующей презентации. 

Для объединения презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). Существует несколько перегрузок метода `AddClone`, определяющих параметры процесса объединения. Каждый объект `Presentation` имеет коллекцию [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), поэтому вы можете вызвать `AddClone` у презентации, в которую хотите добавить слайды. 

Метод `AddClone` возвращает объект `ISlide`, являющийся клоном исходного слайда. Слайды в результирующей презентации представляют собой просто копию слайдов из источника. Поэтому вы можете изменять полученные слайды (например, применять стили, параметры форматирования или макеты), не опасаясь влияния на исходные презентации. 

## **Merge Presentations** 

Aspose.Slides предоставляет метод [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), позволяющий объединять слайды, сохраняя их макеты и стили (параметры по умолчанию). 

В этом примере на C++ показано, как объединить презентации:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Merge Presentations with a Slide Master**

Aspose.Slides предоставляет метод [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), позволяющий объединять слайды с применением шаблона мастер‑презентации. Таким образом при необходимости вы можете изменить стиль слайдов в результирующей презентации. 

Следующий код на C++ демонстрирует описанную операцию:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

Макет слайда для мастера определяется автоматически. Если подходящий макет определить не удаётся и параметр `allowCloneMissingLayout` метода `AddClone` установлен в `true`, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Если вы хотите, чтобы слайды в результирующей презентации имели иной макет, используйте метод [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) при объединении. 

## **Merge Specific Slides from Presentations**

Объединение конкретных слайдов из нескольких презентаций удобно для создания пользовательских наборов слайдов. Aspose.Slides C++ позволяет выбрать и импортировать только нужные слайды, при этом сохраняются форматирование, макет и дизайн оригинальных слайдов.

В следующем примере на C++ создаётся новая презентация, в неё добавляются титульные слайды из двух других презентаций, после чего результат сохраняется в файл:
```cpp
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


## **Merge Presentations with a Slide Layout**

Этот код на C++ показывает, как объединять слайды из презентаций с применением выбранного макета, получая одну итоговую презентацию:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

Нельзя объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить две презентации с различными размерами слайдов, необходимо изменить размер одной из них, чтобы он соответствовал размеру другой презентации. 

Пример кода, демонстрирующий описанную операцию:
```cpp
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


## **Merge Slides to a Presentation Section**

В этом примере на C++ показано, как добавить конкретный слайд в раздел презентации:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


Слайд будет добавлен в конец раздела. 

{{% alert title="Tip" color="primary" %}}

Aspose предлагает [БЕСПЛАТНОЕ веб‑приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн‑сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑решётки](https://products.aspose.app/slides/collage/photo-grid) и т.д. 

{{% /alert %}}

## **FAQ**

**Сохраняются ли примечания докладчика при слиянии?**

Да. При клонировании слайдов Aspose.Slides переносит все элементы слайда, включая примечания, форматирование и анимацию.

**Переносятся ли комментарии и их авторы?**

Комментарии, как часть содержимого слайда, копируются вместе со слайдом. Метки авторов сохраняются в виде объектов комментариев в полученной презентации.

**Что если исходная презентация защищена паролем?**

Её необходимо [открыть с паролем](/slides/ru/cpp/password-protected-presentation/) через [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/); после загрузки такие слайды можно безопасно клонировать в незащищённый целевой файл (или в защищённый).

**Насколько потокобезопасна операция слияния?**

Не используйте один и тот же экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) из нескольких потоков [/slides/cpp/multithreading/]. Рекомендуемое правило — «один документ — один поток»; разные файлы можно обрабатывать параллельно в отдельных потоках.