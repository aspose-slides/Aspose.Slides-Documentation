---
title: У管理ение свойствами презентации на C++
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
description: "Полный контроль над свойствами презентаций в Aspose.Slides for C++ и оптимизация поиска, брендинга и рабочего процесса в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба типа свойств легко доступны и управляемы с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами документа презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/) . Экземпляр этого интерфейса возвращается методом [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_documentproperties/). Ниже приведены примеры, демонстрирующие чтение, изменение и управление этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что нельзя задавать значения для полей **Application** и **Producer**, потому что в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for C++ x.x.x.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- Системно определённые (встроенные) свойства
- Пользовательские (custom) свойства

**Built-in** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Custom** свойства — это пары **Name/Value**, определяемые пользователем, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for C++ разработчики могут получать и изменять значения как встроенных, так и пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документов презентаций. Всё, что нужно сделать — открыть значок Office и выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007. После выбора пункта **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами PowerPoint‑файла. В **Properties Dialog** отображаются вкладки **General, Summary, Statistics, Contents и Custom**. Все эти вкладки позволяют задавать различную информацию, связанную с PowerPoint‑файлами. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Чтение публичных свойств зашифрованной презентации**

Пароль для открытия обычно защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована передачей `false` в [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), её свойства остаются публичными. Затем приложение может передать `true` в [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) и считать публичные метаданные без указания пароля.

`set_OnlyLoadDocumentProperties` контролирует, что загружает Aspose.Slides; он ничего не расшифровывает. Если свойства были включены в шифрование, загрузка без пароля завершится ошибкой. Если презентация не зашифрована, опция игнорируется и загружается полная презентация.

Следующий пример проверяет режим загрузки через [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) и затем считывает встроенные свойства через [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения должны всегда проверять `get_IsOnlyDocumentPropertiesLoaded` перед выполнением операций, требующих полной модели объектов презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрывать имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только в случаях, когда индексация, классификация, поиск или системы управления документами требуют доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная после вызова `set_OnlyLoadDocumentProperties(true)`, предназначена только для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из объекта, содержащего лишь метаданные, поскольку публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля для открытия и полной загрузки.

Следующий пример открывает презентацию с помощью [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/), обновляет публичные встроенные свойства и сохраняет результат. Затем используется [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) для проверки сохранения шифрования и повторно открывает публичные метаданные без пароля, чтобы убедиться в новых значениях:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Если приложение не имеет права расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как доступные только для чтения.

## **Доступ к встроенным свойствам**

Эти свойства, представленные объектом **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **KeyWords**, **Created** (дата создания), **Modified** (дата изменения), **Printed** (дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (является ли документ общим между различными производителями?), **PresentationFormat**, **Subject** и **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Изменение встроенных свойств**

Изменение встроенных свойств файлов презентаций так же просто, как и их получение. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации.

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

// Получение имени свойства по индексу
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Удаление выбранного свойства
documentProperties->RemoveCustomProperty(getPropertyName);

// Сохранение презентации
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for C++ также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, демонстрирующий, как получить и изменить все эти пользовательские свойства для презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_languageid/) (доступное через класс [PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/portionformat/)), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются правописание и грамматика в PowerPoint.

Этот C++ код показывает, как установить язык проверки орфографии для PowerPoint:

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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Установка языка по умолчанию**

Этот C++ код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

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

## **Онлайн‑пример**

Попробуйте онлайн‑приложение **Aspose.Slides Metadata**, чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако при необходимости их можно либо изменить, либо задать пустое значение, если конкретное свойство допускает такое значение.

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять свойство не требуется — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) и затем [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Смотрите пример [Build a Lightweight Presentation Inventory](/slides/ru/cpp/examine-presentation/) для полного отчёта и ограничений, связанных с конкретными форматами.

**Можно ли прочитать публичные свойства зашифрованной презентации без её пароля?**

Да. Презентация должна быть зашифрована передачей `false` в `set_EncryptDocumentProperties`, а затем загружена с параметром `true` в `set_OnlyLoadDocumentProperties`.

**Можно ли обновить зашифрованный файл PPTX в режиме «только свойства документа»?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного PPTX‑файла требует полной загрузки презентации с правильным паролем.