---
title: Редактирование PDF-документов в C++
linktitle: Редактировать PDF
type: docs
weight: 65
url: /ru/cpp/edit-pdf/
keywords:
- редактировать PDF
- заменить текст PDF
- PDF в PPTX
- PPTX в PDF
- C++
- Aspose.Slides
description: "Редактируйте PDF-документы в C++, импортируя их в Aspose.Slides, заменяя текст и сохраняя изменённую презентацию обратно в PDF."
---
## **Обзор**

Aspose.Slides для C++ позволяет редактировать содержимое PDF, импортируя его страницы в виде слайдов, изменяя презентацию и экспортируя её обратно в PDF. В этой статье показана простая замена текста. Презентация остаётся в памяти, поэтому сохранение промежуточного файла PPTX необязательно.

## **Замена текста в PDF**

Используйте [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slidecollection/addfrompdf/) для импорта страниц, [Presentation::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/replacetext/) для обновления текста и [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) для экспорта результата.

В следующем примере ожидается, что `input.pdf` содержит слово «Draft» в виде редактируемого текста после импорта. Оно заменяется на «Final», и результат сохраняется в `edited.pdf`. Очистка начального слайда перед импортом предотвращает появление лишней пустой страницы в выходном файле. Поиск совпадает с полными словами с учётом регистра; `nullptr` означает, что обратный вызов результата не требуется.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Для получения дополнительных параметров см. [Поиск и замена текста](/slides/ru/cpp/search-and-replace-text/) и [Конвертация PowerPoint в PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Замена текста работает с импортированным текстом, а не с текстом внутри отсканированных изображений. Конвертация может влиять на макет и форматирование, поэтому проверьте результат, особенно если заменяемый текст длиннее оригинального.
{{% /alert %}}

## **FAQ**

**Нужно ли сохранять файл PPTX перед экспортом в PDF?**

Нет. Вы можете редактировать и экспортировать одну и ту же презентацию в памяти. Сохраняйте копию PPTX только если хотите дальше редактировать её в PowerPoint; см. [Сохранение презентаций](/slides/ru/cpp/save-presentation/).

**Почему некоторый текст может остаться без изменений?**

В примере происходит поиск полного слова «Draft» с точным регистром. Текст, импортированный как изображение, или разбитый на отдельные текстовые фреймы, может не совпадать с поиском. Проверьте импортированное содержание и скорректируйте поиск под ваш документ.