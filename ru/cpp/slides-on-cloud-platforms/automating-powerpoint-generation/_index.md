---
title: "Автоматизация создания PowerPoint в C++: легко создавать динамические презентации"
linktitle: Автоматизация создания PowerPoint
type: docs
weight: 20
url: /ru/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- облачные платформы
- автоматизация создания PowerPoint
- программная генерация презентаций
- автоматизация PowerPoint
- динамическое создание слайдов
- автоматические бизнес‑отчёты
- автоматизация PPT
- презентация C++
- C++
- Aspose.Slides
description: "Автоматизируйте создание слайдов на облачных платформах с помощью Aspose.Slides для C++ — быстро и надёжно генерируйте, редактируйте и конвертируйте файлы PowerPoint и OpenDocument."
---

## **Введение**

Создание презентаций PowerPoint вручную может быть трудоёмкой и повторяющейся задачей — особенно когда содержание основано на динамических данных, которые часто меняются. Будь то генерация еженедельных бизнес‑отчётов, сбор образовательных материалов или создание готовых к использованию клиентских презентаций, автоматизация может сэкономить бесчисленные часы и обеспечить согласованность в командах.

Для разработчиков C++ автоматизация создания презентаций PowerPoint открывает мощные возможности. Вы можете интегрировать генерацию слайдов в веб‑порталы, настольные инструменты, серверные службы или облачные платформы, чтобы динамически преобразовывать данные в профессиональные, брендированные презентации по запросу.

В этой статье мы рассмотрим типичные сценарии использования автоматической генерации PowerPoint в приложениях C++ (включая развертывание на облачных платформах) и почему это становится необходимой функцией современных решений. От извлечения оперативных бизнес‑данных до преобразования текста или изображений в слайды, цель — превратить сырой контент в структурированные визуальные форматы, которые аудитория может сразу понять.

## **Типичные сценарии использования автоматизации PowerPoint в C++**

Автоматизация генерации PowerPoint особенно полезна в сценариях, где содержимое презентации должно собираться динамически, персонализироваться или часто обновляться. Некоторые из самых распространённых практических сценариев включают:

- **Бизнес‑отчёты и панели мониторинга**
  Генерировать сводки продаж, KPI или отчёты о финансовой эффективности, извлекая живые данные из баз данных или API.

- **Персонализированные презентации по продажам и маркетингу**
  Автоматически создавать презентации, адаптированные под конкретного клиента, используя данные CRM или формы, обеспечивая быструю подготовку и согласованность бренда.

- **Образовательный контент**
  Преобразовывать учебные материалы, викторины или резюме курсов в структурированные наборы слайдов для платформ e‑learning.

- **Аналитика с использованием данных и ИИ**
  Использовать обработку естественного языка или аналитические движки для преобразования сырых данных или длинных текстов в краткие презентации.

- **Слайды на основе медиа**
  Собирать презентации из загруженных изображений, аннотированных скриншотов или ключевых кадров видео с сопроводительными описаниями.

- **Конвертация документов**
  Автоматически преобразовывать документы Word, PDF или вводимые формы в визуальные презентации с минимальными ручными усилиями.

- **Инструменты для разработчиков и технические средства**
  Создавать технические демо, обзоры документации или журналы изменений в виде слайдов напрямую из кода или содержимого markdown.

Автоматизируя эти рабочие процессы, организации могут масштабировать создание контента, поддерживать согласованность и освобождать время для более стратегической работы.

## **Напишем код**

Для этого примера мы выбрали **[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)**, чтобы продемонстрировать автоматизацию PowerPoint благодаря его обширному набору функций и простоте использования при программной работе с презентациями.

В отличие от низкоуровневых библиотек, требующих от разработчиков прямой работы со структурой Open XML (что часто приводит к громоздкому и менее читаемому коду), Aspose.Slides предоставляет API более высокого уровня. Он скрывает сложность, позволяя разработчикам сосредоточиться на логике презентации — такой как макет, форматирование и привязка данных — без необходимости детально разбираться в формате файлов PowerPoint.

Хотя Aspose.Slides является коммерческой библиотекой, она предлагает [бесплатную trial‑версию](https://releases.aspose.com/slides/cpp/), полностью способную запускать примеры, приведённые в этой статье. Для демонстрации идей, тестирования функций или создания прототипа, как в данном случае, trial‑версия более чем достаточна. Это делает её удобным вариантом для экспериментов с автоматической генерацией PowerPoint без необходимости сразу приобретать лицензию.

Итак, давайте пройдёмся по созданию примерной презентации с использованием реального контента.

### **Создать титульный слайд**

Мы начнём с создания новой презентации и добавления титульного слайда с главным заголовком и подзаголовком.
```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```


![Титульный слайд](slide_0.png)

### **Добавить слайд со столбчатой диаграммой**

Затем мы создадим слайд, отображающий региональные показатели продаж в виде столбчатой диаграммы.
```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```


![Слайд с диаграммой](slide_1.png)

### **Добавить слайд с таблицей**

Теперь мы добавим слайд, представляющий ключевые показатели эффективности в виде таблицы.
```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```


![Слайд с таблицей](slide_2.png)

### **Добавить итоговый слайд с маркированным списком**

Наконец, мы включим итог и план действий, используя простой маркированный список.
```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```

```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```


![Слайд с текстом](slide_3.png)

### **Сохранить презентацию**

Наконец, сохраняем презентацию на диск:
```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Заключение**

Автоматизация генерации PowerPoint в приложениях C++ даёт явные преимущества в экономии времени и снижении ручных усилий. Интегрируя динамический контент, такой как диаграммы, таблицы и текст, разработчики могут быстро создавать согласованные, профессиональные презентации — идеально подходящие для бизнес‑отчётов, встреч с клиентами или образовательного контента.

В этой статье мы продемонстрировали, как автоматизировать создание презентации с нуля, включая добавление титульного слайда, диаграмм и таблиц. Такой подход можно применить в различных сценариях, где требуются автоматические презентации, основанные на данных.

Используя подходящие инструменты, разработчики C++ могут эффективно автоматизировать создание PowerPoint, повышая продуктивность и обеспечивая согласованность презентаций.