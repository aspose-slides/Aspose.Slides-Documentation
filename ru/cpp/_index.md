---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /ru/cpp/
keywords:
- документация
- обработка презентаций
- конвертация презентаций
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides для C++, создайте первую презентацию и найдите руководства по типовым задачам, справочник API и поддержку."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ — это нативная C++ библиотека для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument без Microsoft PowerPoint или автоматизации Office.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, и экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/cpp/installation/">Установка</a></li>
<li><a href="/slides/ru/cpp/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/cpp/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНИТЬ</p>
<ul>
<li><a href="/slides/ru/cpp/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/cpp/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/cpp/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с помощью Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/cpp/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/cpp/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/cpp/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/cpp/convert-slide/">Отрисовать слайды как изображения</a></li>
<li><a href="/slides/ru/cpp/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>РАБОЧИЕ ПРОЦЕССЫ SLIDES</p>
<ul>
<li><a href="/slides/ru/cpp/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/cpp/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/cpp/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/cpp/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/cpp/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/cpp/examples/">Примеры по элементам слайда</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Примеры на GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка &amp; Поддержка</b></p>
<hr>
<p>СПРАВКА</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ru/cpp/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/ru/cpp/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/cpp/known-issues/">Известные проблемы</a></li>
<li><a href="https://releases.aspose.com/slides/ru/cpp/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ru/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная служба поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

В Windows создайте проект C++ **Console App** в Visual Studio и установите пакет NuGet с помощью консоли диспетчера пакетов (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

В Linux загрузите ZIP‑пакет для Linux и настройте проект CMake, описанный в разделе [Установка](/slides/ru/cpp/installation/#linux).

Затем используйте этот код в качестве основного исходного файла программы. Он создает презентацию с одним текстовым полем и сохраняет её:

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

Чтобы запустить её в Windows, выберите платформу **x64** на панели инструментов и нажмите **Ctrl+F5**. В Linux сохраните её как *main.cpp* в папке проекта, затем соберите и запустите её там:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Программа сохраняет *hello.pptx* с одним слайдом, содержащим текстовое поле. Без лицензии сохранённый файл будет помечен отметкой оценки — смотрите [Лицензирование](/slides/ru/cpp/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Создание презентаций](/slides/ru/cpp/create-presentation/).