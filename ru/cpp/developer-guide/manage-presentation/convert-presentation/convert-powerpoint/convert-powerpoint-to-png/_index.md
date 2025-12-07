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
description: "Конвертировать презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для C++, обеспечивая точные, автоматизированные результаты."
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно широко используется. 

**Сценарий использования:** Когда у вас сложное изображение и размер не имеет значения, PNG лучше подходит, чем JPEG. 

{{% alert title="Совет" color="primary" %}} Возможно, вас заинтересуют бесплатные **конвертеры PowerPoint в PNG** от Aspose: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они являются живой реализацией процесса, описанного на этой странице. {{% /alert %}}

## **Конвертировать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите объект слайда из коллекции [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) через интерфейс [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide). 
3. Используйте метод [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) для получения миниатюры каждого слайда. 
4. С помощью метода [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) сохраните миниатюру слайда в формате PNG. 

Этот код C++ показывает, как конвертировать презентацию PowerPoint в PNG:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **Конвертировать PowerPoint в PNG с пользовательскими масштабами**

Если вам нужны PNG‑файлы определённого масштаба, задайте значения `desiredX` и `desiredY`, которые определяют размеры результирующей миниатюры. 

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


## **Конвертировать PowerPoint в PNG с пользовательским размером**

Если вам нужны PNG‑файлы определённого размера, передайте желаемые параметры `width` и `height` для `ImageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, задавая размер изображений: 
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


## **FAQ**

**Как экспортировать только конкретный объект (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/cpp/create-shape-thumbnails/); вы можете отрисовать фигуру в PNG‑изображение.

**Поддерживается ли параллельная конверсия на сервере?**

Да, но [не делитесь](/slides/ru/cpp/multithreading/) одним экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и накладывает [другие ограничения](/slides/ru/cpp/licensing/) до применения лицензии.