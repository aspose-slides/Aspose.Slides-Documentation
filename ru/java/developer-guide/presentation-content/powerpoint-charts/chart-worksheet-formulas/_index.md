---
title: Формулы таблицы диаграмм
type: docs
weight: 70
url: /ru/java/chart-worksheet-formulas/
keywords: "формулы powerpoint, формулы таблицы powerpoint"
description: "Формулы в PowerPoint и таблицы"
---


## **Об использовании формул таблицы диаграмм в презентации**
**Таблица диаграммы** (или таблица диаграмм) в презентации является источником данных для диаграммы. Таблица диаграммы содержит данные, которые представлены на диаграмме графически. Когда вы создаете диаграмму в PowerPoint, рабочий лист, связанный с этой диаграммой, также создается автоматически. Рабочий лист диаграммы создается для всех типов диаграмм: линейная диаграмма, столбчатая диаграмма, диаграмма-солнце, круговая диаграмма и т.д. Чтобы увидеть таблицу диаграммы в PowerPoint, вам нужно дважды щелкнуть по диаграмме:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Таблица диаграммы содержит названия элементов диаграммы (Имя категории: *Категория1*, Имя серии) и таблицу с числовыми данными, соответствующими этим категориям и сериям. По умолчанию, когда вы создаете новую диаграмму, данные таблицы диаграммы устанавливаются с использованием данных по умолчанию. После этого вы можете изменять данные таблицы вручную в рабочем листе.

Обычно диаграмма представляет собой сложные данные (например, финансовые аналитики, научные аналитики), содержащие ячейки, которые вычисляются на основе значений в других ячейках или других динамических данных. Ручное вычисление значения ячейки и жесткое кодирование его в ячейку затрудняет его изменение в будущем. Если вы измените значение определенной ячейки, все ячейки, зависящие от нее, также необходимо будет обновить. Более того, данные таблицы могут зависеть от данных из других таблиц, создавая сложную схему презентационных данных с необходимостью обновления в легком и гибком порядке.

**Формула таблицы диаграммы** в презентации – это выражение для автоматического вычисления и обновления данных таблицы диаграммы. Формула таблицы определяет логику вычисления данных для определенной ячейки или набора ячеек. Формула таблицы – это математическая формула или логическая формула, которая использует: ссылки на ячейки, математические функции, логические операторы, арифметические операторы, функции преобразования, строковые константы и т.д. Определение формулы записывается в ячейку, и эта ячейка не содержит простого значения. Формула таблицы вычисляет значение и возвращает его обратно, затем это значение присваивается ячейке. Формулы таблиц диаграмм в презентациях фактически такие же, как и формулы excel, и поддерживаются те же функции, операторы и константы по умолчанию для их реализации.

В [**Aspose.Slides**](https://products.aspose.com/slides/java/) таблица диаграммы представлена с помощью 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) метода типа
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook). 
Формулу таблицы можно задать и изменить с помощью 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) метода. 
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


Как правило, таблицы хранят последние вычисленные значения формул. Если после загрузки презентации данные диаграммы не изменились, метод [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) возвращает эти значения при чтении. Но если данные таблицы были изменены, при чтении свойства **ChartDataCell.Value** он генерирует [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) для неподдерживаемых формул. Это происходит потому, что при успешном разборе формул определяются зависимости ячеек, и устанавливается правильность последних значений. Но если формулу нельзя разобрать, точность значения ячейки не может быть гарантирована.

## **Добавление формулы таблицы диаграмм в презентацию**
Сначала добавьте диаграмму на первый слайд новой презентации с помощью 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Рабочий лист диаграммы создается автоматически и может быть доступен с помощью метода 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--):



```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Давайте заполним некоторые ячейки значениями с помощью 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) свойства 
типа **Object**, что означает, что вы можете установить любое значение для свойства:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Теперь, чтобы записать формулу в ячейку, вы можете использовать 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) метод:

*Примечание*: метод [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) используется для установки ссылок на ячейки в стиле A1. 

Чтобы установить ссылку ячейки [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--), вы можете использовать метод [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Тогда, если вы попробуете прочитать значения из ячеек B2 и C2, они будут вычислены:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Логические константы**
Вы можете использовать логические константы, такие как *FALSE* и *TRUE*, в формулах ячеек:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // значение содержит логическое "false"
```

## **Числовые константы**
Числа могут использоваться в обычной или научной записи для создания формулы таблицы диаграммы:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Строковые константы**
Строковая (или литеральная) константа — это конкретное значение, которое используется как есть и не изменяется. Строковые константы могут быть: даты, тексты, числа и т.д.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Константы ошибок**
Иногда невозможно вычислить результат по формуле. В таком случае код ошибки отображается в ячейке вместо её значения. Каждый тип ошибки имеет конкретный код:

- #DIV/0! - формула пытается разделить на ноль.
- #GETTING_DATA - может отображаться в ячейке, пока её значение все еще вычисляется.
- #N/A - информация отсутствует или недоступна. К некоторым причинам могут относиться: ячейки, используемые в формуле, пусты, лишний пробел, ошибка в написании и т.д.
- #NAME? - определённую ячейку или другие объекты формул невозможно найти по имени. 
- #NULL! - может появиться, когда в формуле есть ошибка, например: (,) или пробел вместо двоеточия (:).
- #NUM! - числовое значение в формуле может быть недействительным, слишком длинным или слишком маленьким и т.д.
- #REF! - недопустимая ссылка на ячейку.
- #VALUE! - неожиданный тип значения. Например, строковое значение установлено в числовую ячейку.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // значение содержит строку "#DIV/0!"
```

## **Арифметические операторы**
Вы можете использовать все арифметические операторы в формулах таблицы диаграммы:

|**Оператор** |**Значение** |**Пример**|
| :- | :- | :- |
|+ (плюс) |Сложение или унарный плюс|2 + 3|
|- (минус) |Вычитание или отрицание |2 - 3<br>-3|
|* (звездочка)|Умножение |2 * 3|
|/ (косая черта)|Деление |2 / 3|
|% (процент)|Процент |30%|
|^ (крышка) |Степень |2 ^ 3|

*Примечание*: Чтобы изменить порядок вычислений, оберните в скобки ту часть формулы, которую необходимо вычислить первой.

## **Операторы сравнения**
Вы можете сравнивать значения ячеек с операторами сравнения. Когда два значения сравниваются с использованием этих операторов, результат — логическое значение, либо *TRUE*, либо FALSE:

|**Оператор** |**Значение** |**Значение** |
| :- | :- | :- |
|= (знак равенства) |Равно |A2 = 3|
|<> (знак неравенства) |Не равно|A2 <> 3|
|> (знак больше) |Больше|A2 > 3|
|>= (знак больше или равно)|Больше или равно|A2 >= 3|
|< (знак меньше)|Меньше|A2 < 3|
|<= (знак меньше или равно)|Меньше или равно|A2 <= 3|

## **Ссылки на ячейки в стиле A1**
**Ссылки на ячейки в стиле A1** используются для рабочих листов, где столбец имеет буквенный идентификатор (например, "*A*"), а строка имеет числовой идентификатор (например, "*1*"). Ссылки на ячейки в стиле A1 могут использоваться следующим образом:

|**Ссылка на ячейку**|**Пример**|||
| :- | :- | :- | :- |
||Абсолютная |Относительная |Смешанная|
|Ячейка |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Строка |$2:$2 |2:2 |-|
|Столбец |$A:$A |A:A |-|
|Диапазон |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Вот пример того, как использовать ссылку на ячейку в стиле A1 в формуле:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Ссылки на ячейки в стиле R1C1**
**Ссылки на ячейки в стиле R1C1** используются для рабочих листов, где как строка, так и столбец имеют числовой идентификатор. Ссылки на ячейки в стиле R1C1 могут использоваться следующим образом:

|**Ссылка на ячейку**|**Пример**|||
| :- | :- | :- | :- |
||Абсолютная |Относительная |Смешанная|
|Ячейка |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Строка |R2|R[2]|-|
|Столбец |C3|C[3]|-|
|Диапазон |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Вот пример того, как использовать ссылку на ячейку в стиле R1C1 в формуле:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Предопределенные функции**
Существуют предопределенные функции, которые могут использоваться в формулах для упрощения их реализации. Эти функции инкапсулируют наиболее часто используемые операции, такие как: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 система дат)
- DAYS
- FIND
- FINDB
- IF
- INDEX (формат ссылки)
- LOOKUP (векторное представление)
- MATCH (векторное представление)
- MAX
- SUM
- VLOOKUP