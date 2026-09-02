---
title: Управление свойствами презентации в C++
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/cpp/presentation-properties/
keywords:
  - Свойства PowerPoint
  - Свойства презентации
  - Свойства документа
  - Встроенные свойства
  - Пользовательские свойства
  - Расширенные свойства
  - Управление свойствами
  - Изменение свойств
  - Метаданные документа
  - Редактирование метаданных
  - Язык проверки орфографии
  - Язык по умолчанию
  - PowerPoint
  - OpenDocument
  - презентация
  - C++
  - Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides для C++ и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба этих типа свойств можно легко получить и управлять ими с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_document_properties). Экземпляр этого интерфейса возвращается методом [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_documentproperties/). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Примечание" %}}
Обратите внимание, что вы не можете задавать значения полям **Application** и **Producer**, потому что в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for C++ x.x.x.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два рода свойств документа:

- Системные (Встроенные) свойства
- Пользовательские (Настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистика документа и т.д. **Пользовательские** свойства — это пары **Name/Value**, определяемые пользователем, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for C++ разработчики могут получать и изменять значения как встроенных, так и пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентаций. Достаточно нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007. После выбора пункта **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint‑файла. В **Properties Dialog** вы увидите несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (Разделяется между разными производителями?), **PresentationFormat**, **Subject** и **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Изменение встроенных свойств**

Изменение встроенных свойств файлов презентаций так же просто, как их чтение. Вы можете просто присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Добавление пользовательских свойств презентации**

Aspose.Slides for C++ также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как задать пользовательские свойства для презентации.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создание экземпляра класса Presentation
auto presentation = System::MakeObject<Presentation>();

// Получение свойств документа
auto documentProperties = presentation->get_DocumentProperties();

// Добавление пользовательских свойств
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Получение имени свойства по определенному индексу
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Удаление выбранного свойства
documentProperties->RemoveCustomProperty(getPropertyName);

// Сохранение презентации
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for C++ также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить и изменить все эти пользовательские свойства презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides.baseportionformat/set_languageid/) (доступное через класс [PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/portionformat/)), позволяющее установить язык проверки орфографии для документа PowerPoint. Язык проверки орфографии — это язык, для которого проверяются правописание и грамматика в PowerPoint.

Этот код C++ показывает, как установить язык проверки орфографии для PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// установить идентификатор проверочного языка

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Установка языка по умолчанию**

Этот код C++ показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Добавляет новую прямоугольную форму с текстом
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Проверяет язык первой части
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Живой пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Часто задаваемые вопросы**

**Как можно удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить пустое значение, если это допускает конкретное свойство.

**Что происходит, если я добавляю пользовательское свойство, которое уже существует?**

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Нет необходимости предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит его значение.

**Могу ли я получить доступ к свойствам презентации без полного её загрузки?**

Да. Используйте [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) и затем [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). См. пример «Build a Lightweight Presentation Inventory» (/slides/ru/cpp/examine-presentation/) для полного отчёта и ограничений, зависящих от формата.