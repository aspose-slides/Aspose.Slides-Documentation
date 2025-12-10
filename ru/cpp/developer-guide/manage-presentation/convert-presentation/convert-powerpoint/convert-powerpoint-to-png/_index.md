---
title: Конвертация слайдов PowerPoint в PNG на C++
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
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- C++
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint в высококачественные PNG-изображения быстро с помощью Aspose.Slides для C++, обеспечивая точные, автоматизированные результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно широко используется. 

**Сценарий использования:** Когда у вас сложное изображение и размер не имеет значения, PNG лучше подходит, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно воспользоваться бесплатными **конвертерами PowerPoint в PNG** от Aspose: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите объект слайда из коллекции [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) через интерфейс [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide). 
3. Вызовите метод [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage), чтобы получить миниатюру каждого слайда. 
4. С помощью метода [IImage::Save(String,ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) сохраните миниатюру слайда в формате PNG. 

Этот пример кода на C++ показывает, как конвертировать презентацию PowerPoint в PNG:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **Преобразовать PowerPoint в PNG с пользовательскими масштабами**

Если необходимо получить PNG‑файлы определённого масштаба, задайте значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

Следующий код на C++ демонстрирует описанную операцию:
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


## **Преобразовать PowerPoint в PNG с пользовательским размером**

Если необходимо получить PNG‑файлы определённого размера, передайте желаемые аргументы `width` и `height` для `ImageSize`. 

Этот пример кода показывает, как конвертировать PowerPoint в PNG с указанием размеров изображений: 
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

**Как экспортировать только конкретный элемент (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/cpp/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делитесь](/slides/ru/cpp/multithreading/) одним экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Какие ограничения имеются в пробной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выводимым изображениям и накладывает [другие ограничения](/slides/ru/cpp/licensing/) до применения лицензии.