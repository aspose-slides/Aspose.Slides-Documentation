---
title: Управление свойствами презентации в C++
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/cpp/presentation-properties/
keywords:
- свойства PowerPoint
- свойства презентации
- свойства документа
- встроенные свойства
- пользовательские свойства
- расширенные свойства
- управление свойствами
- изменение свойств
- метаданные документа
- редактирование метаданных
- язык проверки орфографии
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides для C++ и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---

## **Доступ к свойствам презентации**

Как мы описали ранее, Aspose.Slides for C++ поддерживает два типа свойств документа, которые являются **Built-in** и **Custom** свойствами. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for C++. Aspose.Slides for C++ предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) который представляет свойства документа, связанные с файлом презентации через метод [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). Разработчики могут использовать метод [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402), предоставляемый объектом **Presentation**, чтобы получить доступ к свойствам документа файлов презентации, как описано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете задавать значения для полей **Application** и **Producer**, потому что в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for C++ x.x.x.

{{% /alert %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют сохранять полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Системно определённые (Built-in) свойства
- Пользовательские (Custom) свойства

**Built-in** свойства содержат общую информацию о документе, такую как заголовок документа, имя автора, статистика документа и т.д. **Custom** свойства — это свойства, определённые пользователями как пары **Name/Value**, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for C++ разработчики могут получать доступ и изменять значения встроенных и пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать, — нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** Microsoft PowerPoint 2007. После выбора пункта **Advanced Properties** появится диалог, позволяющий управлять свойствами документа PowerPoint файла. В **Properties Dialog** вы можете увидеть множество вкладок, таких как **General, Summary, Statistics, Contents and Custom**. Все эти вкладки позволяют настраивать различные виды информации, связанные с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **KeyWords**, **Created** (дата создания), **Modified** (дата изменения), **Printed** (дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (общий между разными производителями?), **PresentationFormat**, **Subject** и **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Изменить встроенные свойства**

Изменение встроенных свойств файлов презентации так же просто, как их чтение. Вы можете просто присвоить строковое значение любому нужному свойству, и значение свойства будет изменено. В приведённом ниже примере мы демонстрируем, как можно изменить встроенные свойства документа презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Добавить пользовательские свойства презентации**

Aspose.Slides for C++ также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как установить пользовательские свойства для презентации.
``` cpp
// Создать объект класса Presentation
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

Aspose.Slides for C++ также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства для презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Установить язык проверки**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (доступное через класс [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

This C++ code shows you how to set the proofing language for a PowerPoint:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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


## **Установить язык по умолчанию**

This C++ code shows you how to set the default language for an entire PowerPoint presentation:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adds a new rectangle shape with text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Живой пример**

Попробуйте онлайн‑приложение **Aspose.Slides Metadata**, чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***Вопросы‑Ответы**

**Как я могу удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и не могут быть полностью удалены. Однако вы можете изменить их значения или установить их пустыми, если это допускается конкретным свойством.

**Что происходит, если я добавлю пользовательское свойство, которое уже существует?**

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Вам не нужно удалять или проверять свойство заранее, так как Aspose.Slides автоматически обновляет значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да, вы можете получить доступ к свойствам презентации без полной загрузки, используя метод `GetPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) . Затем используйте метод `ReadDocumentProperties`, предоставляемый интерфейсом [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) , чтобы эффективно читать свойства, экономя память и повышая производительность.