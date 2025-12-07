---
title: Переобразование слайдов PowerPoint в PNG на C++
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
description: "Преобразуйте презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для C++, обеспечивая точные и автоматизированные результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен.  

**Случай использования:** Когда у вас сложное изображение и размер не имеет значения, PNG лучше подходит, чем JPEG.  

{{% alert title="Tip" color="primary" %}} Возможно, вам стоит обратить внимание на бесплатные конвертеры Aspose **PowerPoint в PNG**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Конвертировать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите объект слайда из коллекции [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) под интерфейсом [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. Вызовите метод [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage), чтобы получить миниатюру каждого слайда.
4. Используйте метод [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method), чтобы сохранить миниатюру слайда в формате PNG.

Этот код C++ показывает, как преобразовать презентацию PowerPoint в PNG:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Если вам нужны PNG‑файлы определённого масштаба, вы можете задать значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры.  

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

Если вам нужны PNG‑файлы определённого размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`.  

Этот код показывает, как конвертировать PowerPoint в PNG с указанием размера изображений:
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

**Как экспортировать только определённую форму (например, диаграмму или изображение), а не весь слайд?**  
Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/cpp/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**  
Да, но [не делитесь](/slides/ru/cpp/multithreading/) единственным экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**  
Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/cpp/licensing/), пока лицензия не будет активирована.