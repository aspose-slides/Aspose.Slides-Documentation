---
title: Управление текстовыми полями в презентациях PowerPoint на C++
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/cpp/text-fields/
keywords:
- текстовое поле
- автоматический текст
- номер слайда
- дата и время
- заголовок
- нижний колонтитул
- часть текста
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для C++. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей. Обычный [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) содержит буквальный текст; часть‑поле также имеет [IField](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifield/) тип которой определяет автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, но только одна содержит поле.

Используйте [IPortion::get_Field](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_field/) чтобы различать их: он возвращает `nullptr` для обычного текста. [IPortion::AddField](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/addfield/) преобразует существующую часть в поле. Держите подпись и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило подпись.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых рамок и абзацев см. [Manage Text](/slides/ru/cpp/manage-text/).

## **Создание поля номера слайда**

Следующий пример создаёт текстовое поле, содержащее буквальную метку `Slide ` и автоматически обновляемый номер. Он задаёт размер, толщину и цвет номера перед добавлением поля, затем открывает сохранённую презентацию и проверяет тип поля, текст и форматирование. Входной файл не требуется.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Новая презентация начинается с номера слайда 1, поэтому ожидаемый текст — `Slide 1`, и обе проверки должны вывести `True`. Номер остаётся полем после повторного открытия; это не буквальная `1`. Приведение типов и индексы в проверке относятся к фигуре и частям, созданным в этом примере.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/) реализует [IFieldType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifieldtype/) и предоставляет следующие предопределённые значения. Передайте соответствующее значение в [AddField](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/addfield/).

| Селектор | Назначение |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_slidenumber/) | Текущий номер слайда. |
| [get_DateTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_datetime/) | Дата/время в форматe по умолчанию приложения‑рендерера. |
| [get_DateTime1](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_datetime9/) | Предопределённые форматы даты или комбинированные форматы даты/времени. |
| [get_DateTime10](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_datetime13/) | Предопределённые форматы времени, включая варианты с секундами и 12‑часовым форматом. |
| [get_Header](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_header/) | Поле заголовка; см. ограничения заполнителей и формата ниже. |
| [get_Footer](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_footer/) | Поле нижнего колонтитула. |

Например, [get_DateTime3](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/get_datetime3/) предоставляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата даты. Язык части, задаваемый через [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_languageid/), и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка строки метода [AddField](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/addfield/) принимает внутренний идентификатор поля. Используйте её, когда нужно сохранить идентификатор, поставляемый другим приложением, для которого нет предопределённого значения. Вы также можете создать [FieldType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fieldtype/fieldtype/) из идентификатора. [IFieldType::get_InternalString](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifieldtype/get_internalstring/) предоставляет этот идентификатор для просмотра.

Этот пример сохраняет приложение‑специфичное поле `custom-report-id` с резервным текстом `Report-042`. Входной файл не требуется. Идентификатор не регистрирует расчёт: Aspose.Slides не генерирует идентификаторы отчётов для неизвестных типов. Приложение, понимающее этот идентификатор, должно обеспечить его смысл и обновлять значение.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

После кругового прохода PPTX ожидаемый тип — `custom-report-id`, а ожидаемый текст — `Report-042`. Передача строки типа `yyyy-MM-dd` назовёт тип поля; она не задаст пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Чтение существующего типа поля происходит через [IField::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifield/get_type/) и изменение через [IField::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifield/set_type/). Убедитесь, что поле существует, прежде чем обращаться к его типу. Чтобы остановить автоматические обновления, вызовите [IPortion::RemoveField](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/removefield/). Это сохраняет часть и её текущий текст, удаляя связь с полем. Если нужен конкретный фиксированный результат, присвойте текст после удаления поля.

Для настройки API, связанного с обработкой полей даты/времени, см. [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/set_currentdatetime/). Пример ниже использует явную дату утверждения при преобразовании поля в обычный текст.

Скачайте [sample.pptx](sample.pptx) и поместите его в рабочий каталог. Файл содержит две именованные текстовые фигуры, `UpdatedAt` и `ApprovedDate`, каждая с полем даты/времени, а также обычные текстовые подписи. Ниже показан пример обхода верхних уровней текстовых фигур на обычных слайдах. Он меняет поля даты/времени на формат «длинная дата» и делает их курсивом, сохраняя прочее форматирование. Только поля в `ApprovedDate` становятся фиксированным текстом.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

После повторного открытия `UpdatedAt` должен иметь тип `datetime3` и оставаться динамичным. `ApprovedDate` не должен содержать поле и должен содержать `05 April 2030`. Обе даты курсивом, а их исходный размер шрифта, полужирное начертание и цвет остаются без изменений. Обычные подписи текста остаются неизменными. Проверка читает первую часть двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующей частью при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование части. Используйте [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_portionformat/) чтобы менять только необходимые свойства, как в примерах для цвета или курсива.

Избегайте перестроения всей текстовой рамки только для обновления одного поля: это может потерять исходные границы частей и их индивидуальное форматирование. Также отличайте явно установленное форматирование от наследуемого от абзаца, макета или темы. Смотрите раздел [Text Formatting](/slides/ru/cpp/text-formatting/) для более широких возможностей форматирования.

## **Поля и заполнители заголовков/нижних колонтитулов**

Поле является частью текстовой части. Заполнитель — это фигура с ролью презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не превращает эту фигуру в заполнитель.

Менеджеры заголовков/нижних колонтитулов управляют текстом заполнителей и их видимостью на слайдах, макетах и шаблонах, включая распространение на зависимые слайды. Поле‑номер в пользовательском текстовом блоке может быть полезным даже при отсутствии используемого заполнителя номера слайда. Напротив, изменение видимости заполнителя не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовков и нижних колонтитулов не создают соответствующие заполнители и не поставляют их содержимое. В частности, обычный слайд PowerPoint не имеет заполнитель заголовка; заголовки относятся к страницам заметок и раздаточным материалам. Не полагайтесь на то, что поле заголовка или нижнего колонтитула в произвольной фигуре автоматически получит текст, сконфигурированный через менеджер заполнителей. Для такого рабочего процесса см. [Presentation Headers and Footers](/slides/ru/cpp/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверяйте как тип поля, так и получаемый текст после сохранения и повторного открытия. Сохранение идентификатора не доказывает, что приложение способно вычислить или отобразить его значение.

| Формат | Поведение поля и ограничения |
|---|---|
| PPTX | Хранит внутренние идентификаторы полей вместе с их текстом. Используйте приведённые примеры для проверки предопределённых типов и пользовательских идентификаторов после сохранения и повторного открытия. Неизвестный пользовательский тип не получает автоматическую логику расчёта. Другое приложение может обрабатывать неподдерживаемые идентификаторы иначе. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. Поля номера слайда и предопределённые поля даты/времени имеют устаревшие представления. Неподдерживаемые пользовательские поля или поля заголовка в обычном текстовом блоке слайда могут отображать `*` вместо текста. Не рассчитывайте на сохранение видимого текста для пользовательских полей или в неподдерживаемых контекстах. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте нужное значение перед сохранением. Это сохраняет выбранный текст, но намеренно останавливает автоматические обновления. Тестируйте целевое приложение, если его собственный перерасчёт полей входит в ваш процесс.

## **FAQ**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [IPortion::get_Field](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_field/). Ненулевое значение указывает на поле; по самому отображаемому тексту это определить нельзя.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [RemoveField](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/removefield/) преобразует существующую часть в обычный текст. При необходимости задайте явное значение после этого.

**Может ли внутренняя строка определить новый формат даты или формулу?**

Нет. Она лишь идентифицирует тип поля. Неизвестный идентификатор не предоставляет вычислитель или шаблон формата даты. Используйте поддерживаемый предопределённый тип или оформляйте значение вручную как обычный текст.

**Почему после сохранения нужно снова проверять презентацию?**

Идентификаторы полей, вычисленный текст и форматирование — это отдельные аспекты, которые необходимо проверять. Конверсия формата может изменить видимый результат, даже если идентификатор поля остаётся.