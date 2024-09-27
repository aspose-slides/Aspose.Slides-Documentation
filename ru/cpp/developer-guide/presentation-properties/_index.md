---
title: Свойства презентации
type: docs
weight: 70
url: /ru/cpp/presentation-properties/
---


## **Доступ к свойствам презентации**
Как уже было описано ранее, Aspose.Slides для C++ поддерживает два типа свойств документа: **Встроенные** и **Пользовательские** свойства. Таким образом, разработчики могут получить доступ к обоим типам свойств с помощью API Aspose.Slides для C++. Aspose.Slides для C++ предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties), который представляет свойства документа, ассоциированные с файлом презентации, через метод [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). Разработчики могут использовать метод [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402), предоставляемый объектом **Presentation**, для доступа к свойствам документа файлов презентации, как описано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете устанавливать значения для полей **Application** и **Producer**, так как в этих полях будут отображаться Aspose Ltd. и Aspose.Slides для C++ x.x.x.

{{% /alert %}} 


Microsoft PowerPoint предоставляет возможность добавлять некоторые свойства к файлам презентации. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Определенные системой (встроенные) свойства
- Определенные пользователем (пользовательские) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок документа, имя автора, статистику документа и т.д. **Пользовательские** свойства - это те, которые определены пользователями в виде пар **Имя/Значение**, где как имя, так и значение определяются пользователем. С помощью Aspose.Slides для C++ разработчики могут получать доступ и изменять значения встроенных свойств, а также пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Все, что вам нужно сделать, это щелкнуть значок Office и затем выбрать пункт меню **Подготовка | Свойства | Дополнительные свойства** в Microsoft PowerPoint 2007. После выбора пункта меню **Дополнительные свойства** появится диалоговое окно, позволяющее управлять свойствами документа файла PowerPoint. В **Диалоге свойств** вы можете увидеть множество вкладок, таких как **Общие, Сводка, Статистика, Содержимое и Пользовательские**. Все эти вкладки позволяют настраивать различные виды информации, относящиеся к файлам PowerPoint. Вкладка **Пользовательские** используется для управления пользовательскими свойствами файлов PowerPoint.


## **Доступ к встроенным свойствам**
Эти свойства, предоставляемые объектом **IDocumentProperties**, включают: **Creator(Автор)**, **Описание**, **КлючевыеСлова**, **Создан** (Дата создания), **Изменен** (Дата изменения), **Напечатан** (Дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (Разделяемый между разными производителями?), **PresentationFormat**, **Subject** и **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **Изменение встроенных свойств**
Изменение встроенных свойств файлов презентации так же легко, как и их получение. Вы можете просто присвоить строковое значение любому желаемому свойству, и значение свойства будет изменено. В приведенном ниже примере мы продемонстрировали, как мы можем изменить встроенные свойства документа файла презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Добавление пользовательских свойств презентации**
Aspose.Slides для C++ также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Пример приведен ниже, который демонстрирует, как установить пользовательские свойства для презентации.

``` cpp
// Создание экземпляра класса Presentation
auto presentation = System::MakeObject<Presentation>();

// Получение свойств документа
auto documentProperties = presentation->get_DocumentProperties();

// Добавление пользовательских свойств
documentProperties->idx_set(u"Новое Пользовательское", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"Мое Имя", ObjectExt::Box<String>(u"Мудассир"));
documentProperties->idx_set(u"Пользовательское", ObjectExt::Box<int32_t>(124));

// Получение имени свойства по определенному индексу
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Удаление выбранного свойства
documentProperties->RemoveCustomProperty(getPropertyName);

// Сохранение презентации
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Доступ и изменение пользовательских свойств презентации**
Aspose.Slides для C++ также позволяет разработчикам получать доступ к значениям пользовательских свойств. Пример приведен ниже, который показывает, как вы можете получить доступ и изменить все эти пользовательские свойства для презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}


## **Проверка, была ли презентация изменена или создана**
Aspose.Slides для C++ предоставляет возможность проверить, была ли презентация изменена или создана. Пример приведен ниже, который показывает, как проверить, была ли презентация создана или изменена.

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **Установить язык проверки**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (предоставляемое классом [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)), которое позволяет установить язык проверки для документа PowerPoint. Язык проверки - это язык, на котором проверяются орфография и грамматика в PowerPoint.

Этот код на C++ показывает, как установить язык проверки для PowerPoint:

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
// установить идентификатор языка проверки

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Установить язык по умолчанию**

Этот код на C++ показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Добавление новой прямоугольной формы с текстом
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Новый Текст");

// Проверка языка первой порции
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```