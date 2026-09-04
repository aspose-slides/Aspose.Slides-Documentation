---
title: "Автоматизация создания PowerPoint в Python: легко создавать динамические презентации"
linktitle: "Автоматизация создания PowerPoint"
type: docs
weight: 20
url: /ru/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- облачные платформы
- облачная интеграция
- автоматизация создания PowerPoint
- программное создание презентаций
- автоматизация PowerPoint
- динамическое создание слайдов
- автоматизированные бизнес-отчеты
- автоматизация PPT
- презентация Python
- Python
- Aspose.Slides
description: "Автоматизируйте создание PowerPoint с помощью Aspose.Slides for Python via Java: создавайте бизнес-презентацию с диаграммами, таблицами и маркерами в облачных приложениях."
---
## **Введение**

Создание презентаций вручную становится утомительным, когда их содержимое часто меняется. Еженедельные отчёты, учебные материалы и клиентские презентации часто имеют общую структуру, но требуют новых данных для каждой выдачи.

Aspose.Slides for Python via Java позволяет генерировать такие презентации из приложений Python. Вы можете интегрировать создание слайдов в веб‑порталы, планируемые задачи и облачные воркеры, используя данные из баз данных, API или загруженных файлов.

## **Распространённые сценарии автоматизации PowerPoint в Python**

- **Бизнес‑отчёты и дашборды:** преобразовывать цифры продаж и показатели эффективности в диаграммы и таблицы.  
- **Персонализированные презентации продаж:** заполнять слайды данными, специфичными для клиента, сохраняя единый дизайн.  
- **Обучающие материалы:** собирать уроки, викторины и резюме курсов из структурированных данных.  
- **Аналитика и ИИ‑поддержка:** использовать результаты аналитических или языковых сервисов в качестве содержимого презентации.  
- **Слайды с медиа‑контентом:** комбинировать загруженные изображения или скриншоты с пояснительным текстом.  
- **Документооборот:** переносить контент, извлечённый другими инструментами, в макеты презентаций.  
- **Инструменты для разработчиков:** генерировать сводки релизов, технические обзоры или демонстрации из данных проекта.  

## **Требования**

Следуйте [Installation](/slides/ru/python-java/installation/) для настройки Python, Java, JPype и Aspose.Slides. Для облачного развертывания также просмотрите [Slides on Cloud Platforms](/slides/ru/python-java/slides-on-cloud-platforms/).

В примере используются фиксированные бизнес‑данные, чтобы его можно было запустить без базы данных или внешних сервисов. Замените эти значения данными из вашего приложения при интеграции в рабочий процесс отчётов.

{{% alert color="info" title="Note" %}}

Вы можете попробовать пример без лицензии, но вывод оценки будет содержать водяной знак и подпадать под ограничения оценки. См. [Evaluate Aspose.Slides](/slides/ru/python-java/evaluate-aspose-slides/) для подробностей и информации о временной лицензии.

{{% /alert %}}

## **Создание презентации**

Полный скрипт ниже создаёт одну презентацию, содержащую четыре слайда. Каждый шаг использует одну и ту же презентацию, а последний шаг сохраняет её как `presentation.pptx`.

### **Создание титульного слайда**

Используйте начальный слайд в новой [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и примените макет заголовка. Заполните его заполнители заголовка и подзаголовка заголовком отчёта и аудиторией.

![Слайд заголовка](slide_0.png)

### **Добавление слайда с колонной диаграммой**

Добавьте пустой слайд и создайте диаграмму с помощью [ShapeCollection.addChart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addChart). Заполните встроенную книгу данными о пяти регионах и одной серии продаж. Значения останутся редактируемыми в PowerPoint.

![Слайд с диаграммой](slide_1.png)

### **Добавление слайда с таблицей**

Создайте таблицу с помощью [ShapeCollection.addTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addTable) и заполните два столбца названиями метрик и их значениями. Пример передаёт явные массивы Java типа double для ширины столбцов и высоты строк через JPype.

![Слайд с таблицей](slide_2.png)

### **Добавление итогового слайда с маркерами**

Создайте текстовую форму и добавьте [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) для каждого пункта действия. Примените маркировку‑символ и чёрный текст к каждому абзацу, а также снимите заливку и обводку формы.

![Слайд с итогом](slide_3.png)

### **Сохранение презентации**

Используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи файла PowerPoint. Освободите презентацию с помощью [Presentation.dispose](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#dispose) в блоке `finally`.

### **Полный пример на Python**

Сохраните этот скрипт в доступный для записи каталог и запустите его в настроенной выше среде Python. Он запускает JVM только при необходимости и оставляет её активной до завершения процесса. Для использования в ноутбуках и сервисах см. [JVM lifecycle guidance](/slides/ru/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Создать титульный слайд.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Добавить слайд с диаграммой.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Добавить слайд с таблицей.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Добавить итоговый слайд.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Иллюстрации показывают соответствующие слайды из Java‑примера. Внешний вид может отличаться в зависимости от установленных шрифтов и режима оценки.

## **Использование примера в облачном приложении**

Получите данные отчёта перед построением презентации, затем передайте их в шаги создания диаграммы, таблицы и генерации текста. Используйте отдельный путь вывода для каждой задачи. После сохранения ваше приложение может загрузить файл в объектное хранилище или вернуть его как загрузку.

Поддерживайте работу JVM между задачами в рамках одного воркер‑процесса и освобождайте каждую презентацию после завершения её задачи. Включите шрифты, необходимые для дизайна отчёта, в пакет развертывания, чтобы уменьшить различия между окружениями.

## **Заключение**

Этот пример генерирует полную бизнес‑презентацию из Python с редактируемыми диаграммами, таблицами и текстом. Замена примерных данных на данные вашего приложения делает такой подход полезным для периодических отчётов, клиентских презентаций и учебных материалов.

## **FAQ**

**Требуется ли скрипту Microsoft PowerPoint или Excel?**

Нет. Aspose.Slides создаёт слайды и встроенную книгу диаграммы без необходимости в этих приложениях.

**Почему в примере таблицы используются массивы Java?**

Основной метод принимает массивы Java типа double. Явные массивы делают типы чисел, передаваемых через JPype, понятными.

**Можно ли сохранить ту же презентацию в PDF или ODP?**

Да. До освобождения презентации сохраните её под другим именем файла, используя соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/). См. [Supported File Formats](/slides/ru/python-java/supported-file-formats/) для возможностей конкретных форматов.

**Можно ли использовать фирменный шаблон?**

Да. Загрузите ваш шаблон вместо создания пустой презентации, затем адаптируйте макет и порядок заполнителей под этот шаблон. Пример предполагает макеты и порядок заполнителей новой презентации по умолчанию.