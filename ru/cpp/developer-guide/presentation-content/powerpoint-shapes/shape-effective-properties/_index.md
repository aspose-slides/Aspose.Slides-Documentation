---
title: Эффективные свойства формы
type: docs
weight: 50
url: /cpp/shape-effective-properties/
---


В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы задаем значения напрямую на этих уровнях

1. В свойствах части на слайде части.
1. В стиле текста прототипа формы на макете или главном слайде (если форма текстового поля части имеет один).
1. В глобальных настройках текста презентации.

то эти значения называют **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но, наконец, когда_application needs to know what the portion should look like it uses **effective** values. Вы можете получить эффективные значения, используя метод **GetEffective()** из локального формата.

Следующий пример показывает, как получить эффективные значения.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Получить эффективные свойства камеры**
Aspose.Slides для C++ позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен класс **CameraEffectiveData**. Класс CameraEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства камеры. Экземпляр класса **CameraEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий кодовый пример показывает, как получить эффективные свойства для камеры.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Получить эффективные свойства светового оборудования**
Aspose.Slides для C++ позволяет разработчикам получать эффективные свойства светового оборудования. Для этой цели в Aspose.Slides был добавлен класс **LightRigEffectiveData**. Класс LightRigEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства светового оборудования. Экземпляр класса **LightRigEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий кодовый пример показывает, как получить эффективные свойства для светового оборудования.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Получить эффективные свойства фаски формы**
Aspose.Slides для C++ позволяет разработчикам получать эффективные свойства фаски формы. Для этой цели в Aspose.Slides был добавлен класс **ShapeBevelEffectiveData**. Класс ShapeBevelEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства рельефной поверхности формы. Экземпляр класса **ShapeBevelEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий кодовый пример показывает, как получить эффективные свойства для фаски формы.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Получить эффективные свойства текстового поля**
Используя Aspose.Slides для C++, вы можете получить эффективные свойства текстового поля. Для этой цели в Aspose.Slides был добавлен класс **TextFrameFormatEffectiveData**, который содержит эффективные свойства форматирования текстового поля.

Следующий кодовый пример показывает, как получить эффективные свойства форматирования текстового поля.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Получить эффективные свойства текстового стиля**
Используя Aspose.Slides для C++, вы можете получить эффективные свойства текстового стиля. Для этой цели в Aspose.Slides был добавлен класс **TextStyleEffectiveData**, который содержит эффективные свойства текстового стиля.

Следующий кодовый пример показывает, как получить эффективные свойства текстового стиля.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Получить значение эффективной высоты шрифта**
Используя Aspose.Slides для C++, вы можете получить эффективные свойства высоты шрифта. Вот код, демонстрирующий изменение эффективного значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Получить эффективный формат заливки для таблицы**
Используя Aspose.Slides для C++, вы можете получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс **IFillFormatEffectiveData**, который содержит эффективные свойства форматирования заливки. Обратите внимание, что форматирование ячеек всегда имеет более высокий приоритет, чем форматирование строки, строка имеет более высокий приоритет, чем столбец, а столбец выше, чем вся таблица.

Таким образом, свойства **CellFormatEffectiveData** всегда используются для отрисовки таблицы. Следующий кодовый пример показывает, как получить эффективное форматирование заливки для различных логических частей таблицы.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}