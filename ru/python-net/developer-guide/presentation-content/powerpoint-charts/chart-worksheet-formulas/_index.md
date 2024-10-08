---
title: Формулы листа диаграммы
type: docs
weight: 70
url: /ru/python-net/chart-worksheet-formulas/
keywords: "Диаграммная таблица, формула диаграммы, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Диаграммная таблица и формула в презентации PowerPoint на Python"
---


## **О формуле диаграммной таблицы в презентации**
**Диаграммная таблица** (или лист диаграммы) в презентации является источником данных для диаграммы. Диаграммная таблица содержит данные, которые представлены на диаграмме графически. Когда вы создаете диаграмму в PowerPoint, рабочий лист, связанный с этой диаграммой, также создается автоматически. Рабочий лист диаграммы создается для всех типов диаграмм: линейная диаграмма, столбчатая диаграмма, солнечная диаграмма, круговая диаграмма и т.д. Чтобы увидеть диаграммную таблицу в PowerPoint, вам нужно дважды щелкнуть на диаграмме:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Диаграммная таблица содержит названия элементов диаграммы (Имя категории: *Category1*, Имя серии) и таблицу с числовыми данными, соответствующими этим категориям и сериям. По умолчанию, когда вы создаете новую диаграмму, данные диаграммной таблицы устанавливаются с помощью данных по умолчанию. Затем вы можете вручную изменить данные таблицы в рабочем листе.

Обычно диаграмма представляет сложные данные (например, финансовые аналитики, научные аналитики), имеющие ячейки, которые рассчитываются на основе значений в других ячейках или из других динамических данных. Ручной расчет значения ячейки и жесткое кодирование его в ячейку усложняет его изменение в будущем. Если вы измените значение определенной ячейки, все ячейки, зависимые от нее, также потребуют обновления. Более того, данные таблицы могут зависеть от данных из других таблиц, создавая сложную схему презентационных данных, которая должна обновляться удобным и гибким образом.

**Формула диаграммной таблицы** в презентации представляет собой выражение для автоматического вычисления и обновления данных диаграммной таблицы. Формула таблицы определяет логику расчета данных для определенной ячейки или набора ячеек. Формула таблицы - это математическая формула или логическая формула, которая использует: ссылки на ячейки, математические функции, логические операторы, арифметические операторы, функции преобразования, строковые константы и т.д. Определение формулы записывается в ячейку, и эта ячейка не содержит простого значения. Формула таблицы рассчитывает значение и возвращает его, после чего это значение присваивается ячейке. Формулы диаграммной таблицы в презентациях фактически такие же, как формулы excel, и поддерживаются те же функции, операторы и константы по умолчанию для их реализации.

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) диаграммная таблица представлена с помощью 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) свойства типа
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/). 
Формула таблицы может быть назначена и изменена с помощью
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) свойства. 
Следующий функционал поддерживается для формул в Aspose.Slides:

- Логические константы
- Числовые константы
- Строковые константы
- Константы ошибок
- Арифметические операторы
- Операторы сравнения
- Ссылки на ячейки в стиле A1
- Ссылки на ячейки в стиле R1C1
- Предопределенные функции



Обычно таблицы хранят последние вычисленные значения формулы. Если после загрузки презентации данные диаграммы не были изменены - **IChartDataCell.Value** возвращает эти значения при чтении. Но если данные таблицы были изменены, при чтении **ChartDataCell.Value** бросает **CellUnsupportedDataException** для неподдерживаемых формул. Это связано с тем, что когда формулы успешно разбираются, определяются зависимости ячеек и проверяется правильность последних значений. Но если формулу нельзя разобрать, правильность значения ячейки не может быть гарантирована.
## **Добавление формулы диаграммной таблицы в презентацию**
Сначала добавьте диаграмму с некоторыми образцовыми данными на первый слайд новой презентации с помощью 
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/). 
Рабочий лист диаграммы создается автоматически и может быть доступен через 
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) свойства:



```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```



Давайте запишем некоторые значения в ячейки с помощью 
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) свойства 
типа **Object**, что означает, что вы можете установить любое значение для свойства:



```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```



Теперь, чтобы записать формулу в ячейку, вы можете использовать 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) свойство:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Примечание*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) свойство используется для установки ссылок на ячейки в стиле A1. 



Чтобы установить [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) ссылку на ячейку, вы можете использовать 
[**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) свойство:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Затем используйте метод [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) для расчета всех формул в рабочем листе и обновления соответствующих значений ячеек:



```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **Логические Константы**
Вы можете использовать логические константы, такие как *FALSE* и *TRUE*, в формулах ячеек:




## **Числовые Константы**
Числа могут быть использованы в обычной или научной нотации для создания формулы диаграммной таблицы:




## **Строковые Константы**
Строковая (или литеральная) константа - это конкретное значение, которое используется как есть и не изменяется. Строковые константы могут быть: даты, тексты, числа и т.д.:




## **Константы Ошибок**
Иногда невозможно рассчитать результат по формуле. В этом случае вместо значения в ячейке отображается код ошибки. Каждый тип ошибки имеет конкретный код:

- #DIV/0! - формула пытается разделить на ноль.
- #GETTING_DATA - может отображаться в ячейке, пока ее значение еще вычисляется.
- #N/A - информация отсутствует или недоступна. Некоторые причины могут быть: ячейки, используемые в формуле, пусты, лишний пробел, опечатка и т.д.
- #NAME? - определенная ячейка или другие объекты формулы не могут быть найдены по имени. 
- #NULL! - может появиться, когда в формуле есть ошибка, например:  (,) или пробел вместо двоеточия (:).
- #NUM! - числовое значение в формуле может быть недействительным, слишком длинным или слишком маленьким и т.д.
- #REF! - недействительная ссылка на ячейку.
- #VALUE! - неожиданный тип значения. Например, строковое значение назначено числовой ячейке.




## **Арифметические Операторы**
Вы можете использовать все арифметические операторы в формулах листа диаграммы:



|**Оператор** |**Значение** |**Пример**|
| :- | :- | :- |
|+ (плюс) |Сложение или унарный плюс|2 + 3|
|- (минус) |Вычитание или отрицание |2 - 3<br>-3|
|* (звездочка)|Умножение |2 * 3|
|/ (косая черта)|Деление |2 / 3|
|% (процент)|Процент |30%|
|^ (символ крыла)|Степень |2 ^ 3|


*Примечание*: Чтобы изменить порядок выполнения, заключите в скобки ту часть формулы, которая должна быть вычислена первой.


## **Операторы Сравнения**
Вы можете сравнивать значения ячеек с помощью операторов сравнения. Когда два значения сравниваются с использованием этих операторов, результат - логическое значение, либо *TRUE*, либо FALSE:



|**Оператор** |**Значение** |**Значение** |
| :- | :- | :- |
|= (равно) |Равно |A2 = 3|
|<> (не равно) |Не равно|A2 <> 3|
|> (больше чем) |Больше чем|A2 > 3|
|>= (больше или равно)|Больше или равно|A2 >= 3|
|< (меньше чем)|Меньше чем|A2 < 3|
|<= (меньше или равно)|Меньше или равно|A2 <= 3|

## **Ссылки на ячейки в стиле A1**
**Ссылки на ячейки в стиле A1** используются для рабочих листов, где столбец имеет буквенный идентификатор (например, "*A*"), а строка имеет числовой идентификатор (например, "*1*"). Ссылки на ячейки в стиле A1 могут использоваться следующим образом:



|**Ссылка на ячейку**|**Пример**|||
| :- | :- | :- | :- |
||Абсолютная |Относительная |Смешанная|
|Ячейка |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Строка |$2:$2 |2:2 |-|
|Столбец |$A:$A |A:A |-|
|Диапазон |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Вот пример, как использовать ссылку на ячейку в стиле A1 в формуле:




## **Ссылки на ячейки в стиле R1C1**
**Ссылки на ячейки в стиле R1C1** используются для рабочих листов, где как строка, так и столбец имеют числовой идентификатор. Ссылки на ячейки в стиле R1C1 могут использоваться следующим образом:



|**Ссылка на ячейку**|**Пример**|||
| :- | :- | :- | :- |
||Абсолютная |Относительная |Смешанная|
|Ячейка |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Строка |R2|R[2]|-|
|Столбец |C3|C[3]|-|
|Диапазон |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Вот пример, как использовать ссылку на ячейку в стиле A1 в формуле:




## **Предопределенные Функции**
Существуют предопределенные функции, которые можно использовать в формулах для упрощения их реализации. Эти функции инкапсулируют наиболее часто используемые операции, такие как: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (система дат 1900 года)
- DAYS
- FIND
- FINDB
- IF
- INDEX (референсная форма)
- LOOKUP (векторная форма)
- MATCH (векторная форма)
- MAX
- SUM
- VLOOKUP

