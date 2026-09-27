---
title: Создание презентаций на C++
linktitle: Создание презентации
type: docs
weight: 10
url: /ru/cpp/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Создавайте презентации на C++ с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

В этой статье показано, как создать презентацию в Aspose.Slides, добавить текстовое поле на её первый слайд и сохранить результат в файл. Краткий раздел FAQ в конце охватывает часто задаваемые вопросы о форматах, шаблонах, размере слайдов, единицах измерения, использовании памяти, потоках, лицензировании, цифровых подписях и поддержке VBA.

Прежде чем начать, добавьте Aspose.Slides в ваш проект: из NuGet в проекте Visual Studio на Windows или из ZIP‑пакета с CMake на Linux. См. [Установка](/slides/ru/cpp/installation/).

## **Создание презентации PowerPoint**

Чтобы создать презентацию и поместить текстовое поле на её первый слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Новая презентация уже содержит один пустой слайд.
2. Получите этот слайд с помощью метода [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) и его индекс, 0.
3. Добавьте прямоугольник с помощью метода [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) и задайте его текст через метод [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/).
4. Сохраните презентацию как файл PPTX с помощью метода [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Верхний левый угол прямоугольника находится на расстоянии 50 пунктов от левого края и 50 пунктов от верхнего края слайда, а ширина прямоугольника — 400 пунктов, высота — 100 пунктов. Программа сохраняет *hello.pptx* в текущем рабочем каталоге, создавая один слайд, содержащий прямоугольник и его текст. Без лицензии Aspose.Slides также добавляет водяной знак оценки к каждому сохраняемому слайду; см. [Лицензирование](/slides/ru/cpp/licensing/).

## **FAQ**

### В какие форматы я могу сохранить новую презентацию?

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/cpp/save-presentation/), а также экспортировать в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/ru/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), [SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/) и [изображения](/slides/ru/cpp/convert-powerpoint-to-png/), и др.

### Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/cpp/supported-file-formats/).

### Как управлять размером/соотношением сторон слайда при создании презентации?

Установите [размер слайда](/slides/ru/cpp/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите, как должен масштабироваться контент.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм равен 72 единицам.

### Как работать с очень большими презентациями (с множеством медиафайлов), чтобы снизить использование памяти?

Используйте [стратегии управления BLOB](/slides/ru/cpp/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтительно используйте файловые рабочие процессы вместо полностью потоковых в памяти.

### Могу ли я создавать/сохранять презентации параллельно?

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/cpp/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

### Как удалить пробный водяной знак и ограничения?

[Примените лицензию](/slides/ru/cpp/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована, если задействовано несколько потоков.

### Могу ли я цифрово подписать создаваемый PPTX?

Да. [Цифровые подписи](/slides/ru/cpp/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в созданных презентациях?

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/cpp/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.