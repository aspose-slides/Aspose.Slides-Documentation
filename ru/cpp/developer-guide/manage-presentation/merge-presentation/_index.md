---
title: Объединение Презентаций - C++ PowerPoint API
linktitle: Объединение Презентаций
type: docs
weight: 40
url: /cpp/merge-presentation/
keywords: "Объединение PowerPoint, PPTX, PPT, комбинирование PowerPoint, объединение презентации, комбинирование презентации, C++"
description: Статья объясняет, как можно объединить презентации PowerPoint с использованием C++ PowerPoint API или библиотеки.
---

{{% alert  title="Совет" color="primary" %}} 

Вам может быть интересно ознакомиться с **бесплатным онлайн приложением** [Merger](https://products.aspose.app/slides/merger) от Aspose. Оно позволяет пользователям объединять презентации PowerPoint в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и объединять презентации в разных форматах (PPT в PPTX, PPTX в ODP и т.д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Объединение Презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически комбинируете их слайды в одной презентации, чтобы получить один файл. 

{{% alert title="Информация" color="info" %}}

Большинство программ для создания презентаций (PowerPoint или OpenOffice) не имеют функций, которые позволяли бы пользователям объединять презентации таким образом. 

Тем не менее, [**Aspose.Slides для C++**](https://products.aspose.com/slides/cpp/) позволяет вам объединять презентации различными способами. Вы можете объединить презентации со всеми их формами, стилями, текстами, форматированием, комментариями, анимациями и др., не беспокоясь о потере качества или данных. 

**См. также**

[Клонировать Слайды](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Что Можно Объединять**

С помощью Aspose.Slides вы можете объединять 

* целые презентации. Все слайды из презентаций оказываются в одной презентации
* отдельные слайды. Выбранные слайды оказываются в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг с другом. 

{{% alert title="Примечание" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет вам объединять другие файлы:

* [Изображения](https://products.aspose.com/slides/cpp/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* И два разных файла, такие как [изображение в PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Опции Объединения**

Вы можете применять опции, которые определяют, будут ли

* каждый слайд в выходной презентации сохранять уникальный стиль
* используется ли конкретный стиль для всех слайдов в выходной презентации. 

Для объединения презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). Существует несколько реализаций методов `AddClone`, которые определяют параметры процесса объединения презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), поэтому вы можете вызвать метод `AddClone` из презентации, в которую хотите объединить слайды. 

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в выходной презентации являются просто копией слайдов из источника. Поэтому вы можете вносить изменения в полученные слайды (например, применять стили или параметры форматирования или макеты), не беспокоясь о том, что исходные презентации будут затронуты. 

## **Объединение Презентаций** 

Aspose.Slides предоставляет метод [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), который позволяет вам объединять слайды, при этом слайды сохраняют свои макеты и стили (параметры по умолчанию). 

Этот код на C++ показывает, как объединять презентации:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Объединение Презентаций с Мастером Слайда**

Aspose.Slides предоставляет метод [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), который позволяет вам объединять слайды, применяя шаблон мастер-презентации слайда. Таким образом, если необходимо, вы можете изменить стиль для слайдов в выходной презентации. 

Этот код на C++ демонстрирует описанную операцию:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Примечание" color="warning" %}} 

Макет слайда для мастера слайда определяется автоматически. Когда подходящий макет не может быть определён, если булевый параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет для исходного слайда. В противном случае будет выброшено [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Если вы хотите, чтобы слайды в выходной презентации имели другой макет слайда, используйте вместо этого метод [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) при объединении. 

## **Объединение Конкретных Слайдов Из Презентаций**

Этот код на C++ показывает, как выбрать и объединить конкретные слайды из разных презентаций, чтобы получить одну выходную презентацию:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Объединение Презентаций С Макетом Слайда**

Этот код на C++ показывает, как объединить слайды из презентаций, применяя к ним ваш предпочтительный макет слайда, чтобы получить одну выходную презентацию:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Объединение Презентаций С Разными Размером Слайдов**

{{% alert title="Примечание" color="warning" %}} 

Вы не можете объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, вам нужно изменить размер одной из презентаций, чтобы его размеры совпадали с размерами другой презентации. 

Этот пример кода демонстрирует описанную операцию:

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

## **Объединение Слайдов в Раздел Презентации**

Этот код на C++ показывает, как объединить конкретный слайд в раздел презентации:

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

Слайд добавляется в конец раздела. 

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создавать [фото-гриды](https://products.aspose.app/slides/collage/photo-grid) и многое другое. 

{{% /alert %}}