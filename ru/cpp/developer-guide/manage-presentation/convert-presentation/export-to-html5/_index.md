---
title: Преобразование презентаций в HTML5 на C++
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/cpp/export-to-html5/
keywords:
- PowerPoint в HTML5
- OpenDocument в HTML5
- презентация в HTML5
- слайд в HTML5
- PPT в HTML5
- PPTX в HTML5
- ODP в HTML5
- сохранить PPT как HTML5
- сохранить PPTX как HTML5
- сохранить ODP как HTML5
- экспортировать PPT в HTML5
- экспортировать PPTX в HTML5
- экспортировать ODP в HTML5
- C++
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для C++. Сохранение форматирования, анимаций и интерактивности."
---
## **Обзор**

Эта статья объясняет, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides для C++. Описывается базовый экспорт, управление анимацией фигур и переходами слайдов, а также расположение комментариев. Также сравнивается вывод HTML5 с выводом SVG‑формата стандартного экспорта HTML.

## **Экспорт PowerPoint в HTML5**

Следующий пример загружает презентацию из текущего каталога и сохраняет её в формате HTML5. Он использует параметры экспорта по умолчанию; в следующем примере показано, как явно управлять воспроизведением анимации. Замените путь к входному файлу на путь к вашей презентации.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Помимо HTML‑документа, экспорт записывает поддерживающие файлы CSS и JavaScript для оформления слайдов, анимаций, эффектов и навигации. Сохраняйте эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы экспортировать без воспроизведения анимаций фигур или переходов слайдов, передайте `false` в [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) в [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Эти параметры независимы, поэтому можно включить один, отключив другой. Пример экспортирует презентацию с отключёнными обоими типами анимации в сгенерированной странице.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт HTML использует иной подход к рендерингу: содержимое слайда представлено в виде SVG внутри HTML‑страницы. Следующий пример преобразует презентацию в HTML‑документ, используя этот подход.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Упрощённая разметка ниже иллюстрирует структуру сгенерированной страницы. Элемент SVG содержит отрисованное содержимое слайда; заменяющий текст представляет это содержимое и не является буквальным выводом экспорта.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Экспорт на основе SVG не раскрывает фигуры PowerPoint как отдельные HTML‑элементы. Используйте экспорт HTML5, когда нужны параметры анимации фигур и переходов слайдов, продемонстрированные в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в представление слайдов HTML5**

Экспорт HTML5 создаёт страницу для просмотра и навигации слайдами презентации в браузере. В этом примере в оба метода [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) передаётся `true`, чтобы экспортируемый просмотр слайдов мог воспроизводить эффекты исходной презентации.

Используйте презентацию, уже содержащую анимацию фигур и переходы слайдов, чтобы увидеть эффект этих настроек. Включение их не добавляет новых эффектов к слайдам, у которых их нет. После экспорта откройте сгенерированный HTML5‑документ в браузере с доступными поддерживающими файлами.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Преобразовать презентацию в документ HTML5 с комментариями**

Вы можете включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели могли видеть обратную связь рядом с содержимым слайда. Пример в этом разделе предполагает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новые комментарии не создаются.

![Два комментария на слайде презентации](two_comments_pptx.png)

Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) в метод [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) класса [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Вызовите [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) с параметром `CommentsPositions::Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/), чтобы разместить комментарии справа от каждого слайда.

Следующий пример экспортирует презентацию в HTML5 с таким расположением комментариев. Презентация без комментариев не будет содержать текст комментариев для отображения.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Изображение ниже показывает экспортированный документ HTML5 с комментариями, отображаемыми рядом со слайдом.

![Комментарии в экспортированном документе HTML5](two_comments_html5.png)

## **Исключить JavaScript‑гиперссылки при экспорте**

Предположим, что `hyperlinks.pptx` содержит текст со ссылкой `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить JavaScript‑гиперссылку при экспорте, вызовите [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) с параметром `true`. По умолчанию значение `false`, поэтому такие ссылки не фильтруются, если не включить опцию.

Следующий пример загружает презентацию из текущего каталога и экспортирует её с помощью [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Экспортированный файл опускает JavaScript‑гиперссылку, сохранив её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся неизменной.

Эта опция фильтрует JavaScript‑гиперссылки; она не удаляет все скрипты или другой активный контент и не гарантирует соответствие CSP. Например, вывод HTML5 по‑прежнему включает скрипты для навигации по слайдам и анимаций.

## **Вопросы и ответы**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, экспорт HTML5 предоставляет отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии можно включить в вывод HTML5 и разместить (например, справа от слайда) с помощью [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) для заметок и комментариев.

**Могу ли я пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, метод [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) позволяет пропускать гиперссылки с вызовами JavaScript при сохранении. По умолчанию значение `false`. Смотрите [Исключить JavaScript‑гиперссылки при экспорте](/slides/ru/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта HTML5 и области действия фильтра. Эта настройка не удаляет JavaScript, используемый просмотрщиком HTML5 для навигации и анимаций.