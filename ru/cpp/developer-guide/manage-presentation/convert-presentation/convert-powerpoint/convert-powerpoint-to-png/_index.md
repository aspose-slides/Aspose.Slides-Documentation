---
title: Конвертировать слайды PowerPoint в PNG на C++
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/cpp/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- C++
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для C++, обеспечивая точные, автоматические результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё же широко используется. 

**Случай использования:** Если у вас сложное изображение и размер не имеет значения, PNG является лучшим форматом изображения, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно ознакомьтесь с бесплатными конвертерами Aspose **PowerPoint to PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Преобразование PowerPoint в PNG**

Выполните следующие шаги:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Get the slide object from the [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) collection under the [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) interface. 
3. Use a [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) method to get the thumbnail for each slide. 
4. Use the [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) method to save the slide thumbnail to the PNG format. 

Этот код на C++ показывает, как преобразовать презентацию PowerPoint в PNG:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **Преобразование PowerPoint в PNG с пользовательскими размерами**

Если вам нужны PNG‑файлы определённого масштаба, вы можете задать значения `desiredX` и `desiredY`, которые определяют размеры получаемого миниатюра. 

Этот код на C++ демонстрирует описанную операцию:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```


## **Преобразование PowerPoint в PNG с пользовательским размером**

Если вам нужны PNG‑файлы определённого размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`. 

Этот код показывает, как преобразовать PowerPoint в PNG, задавая размер изображений: 
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```


## **Часто задаваемые вопросы**

**Как экспортировать только конкретный объект (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных объектов](/slides/ru/cpp/create-shape-thumbnails/); вы можете отобразить объект в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делитесь](/slides/ru/cpp/multithreading/) единственным экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

В режиме оценки к выходным изображениям добавляется водяной знак, а также применяются [другие ограничения](/slides/ru/cpp/licensing/) до применения лицензии.