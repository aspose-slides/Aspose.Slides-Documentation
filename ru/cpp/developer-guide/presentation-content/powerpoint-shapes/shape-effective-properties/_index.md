---
title: Получить эффективные свойства формы из презентаций на C++
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/cpp/shape-effective-properties/
keywords:
- свойства формы
- свойства камеры
- осветительная установка
- фигура с фаской
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для C++ вычисляет и применяет эффективные свойства фигур для точного рендеринга PowerPoint."
---

В этой теме мы обсудим **effective** и **local** свойства. Когда мы задаём значения напрямую на этих уровнях

1. В свойствах части на слайде части.  
1. В стиле текста прототипной формы на макете или главном слайде (если у формы текстового кадра части есть такой стиль).  
1. В глобальных настройках текста презентации.  

то такие значения называются **local** значениями. На любом уровне **local** значения могут быть определены или опущены. Но в конечном итоге, когда приложению нужно определить, как должна выглядеть часть, оно использует **effective** значения. Вы можете получить effective значения, используя метод **GetEffective()** локального формата.

Следующий пример показывает, как получить effective значения.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}

## **Get Effective Properties of a Camera**
Aspose.Slides for C++ позволяет разработчикам получать effective свойства камеры. Для этой цели в Aspose.Slides был добавлен класс **CameraEffectiveData**. Класс **CameraEffectiveData** представляет собой неизменяемый объект, содержащий effective свойства камеры. Экземпляр класса **CameraEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который представляет пару effective значений для класса **ThreeDFormat**.

Следующий пример кода показывает, как получить effective свойства камеры.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Get Effective Properties of a Light Rig**
Aspose.Slides for C++ позволяет разработчикам получать effective свойства Light Rig. Для этой цели в Aspose.Slides был добавлен класс **LightRigEffectiveData**. Класс **LightRigEffectiveData** представляет собой неизменяемый объект, содержащий effective свойства осветительной установки. Экземпляр класса **LightRigEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который представляет пару effective значений для класса **ThreeDFormat**.

Следующий пример кода показывает, как получить effective свойства Light Rig.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Get Effective Properties of a Bevel Shape**
Aspose.Slides for C++ позволяет разработчикам получать effective свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен класс **ShapeBevelEffectiveData**. Класс **ShapeBevelEffectiveData** представляет собой неизменяемый объект, содержащий effective свойства рельефа грани фигуры. Экземпляр класса **ShapeBevelEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который представляет пару effective значений для класса **ThreeDFormat**.

Следующий пример кода показывает, как получить effective свойства Bevel Shape.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Get Effective Properties of a Text Frame**
С помощью Aspose.Slides for C++ вы можете получить effective свойства Text Frame. Для этой цели в Aspose.Slides был добавлен класс **TextFrameFormatEffectiveData**, который содержит effective свойства форматирования текстового кадра.

Следующий пример кода показывает, как получить effective свойства форматирования текстового кадра.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Get Effective Properties of a Text Style**
С помощью Aspose.Slides for C++ вы можете получить effective свойства Text Style. Для этой цели в Aspose.Slides был добавлен класс **TextStyleEffectiveData**, который содержит effective свойства текстового стиля.

Следующий пример кода показывает, как получить effective свойства текстового стиля.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Get the Effective Font Height Value**
С помощью Aspose.Slides for C++ вы можете получить effective свойства высоты шрифта. Ниже приведён код, демонстрирующий изменение effective значения высоты шрифта части после задания локальных значений высоты шрифта на разных уровнях структуры презентации.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Get the Effective Fill Format for a Table**
С помощью Aspose.Slides for C++ вы можете получить effective формат заполнения для разных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс **IFillFormatEffectiveData**, который содержит effective свойства форматирования заполнения. Обратите внимание, что форматирование ячейки всегда имеет более высокий приоритет, чем форматирование строки, строка имеет более высокий приоритет, чем столбец, а столбец — чем вся таблица.

Поэтому в конце свойства **CellFormatEffectiveData** всегда используются для отрисовки таблицы. Следующий пример кода показывает, как получить effective формат заполнения для разных логических частей таблицы.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}

## **FAQ**

**Как я могу понять, что получил "снимок", а не "живой объект", и когда следует заново читать effective свойства?**

Объекты EffectiveData — это неизменяемые снимки вычисленных значений на момент вызова. Если вы изменяете локальные или унаследованные настройки фигуры, получите данные EffectiveData вновь, чтобы получить обновлённые значения.

**Влияет ли изменение макета/главного слайда на effective свойства, которые уже были получены?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется автоматически — запросите его снова после изменения макета или главного слайда.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (figure/text/3D и т.д.), а затем заново получайте effective значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/главного слайда и глобальных настроек?**

Effective значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли по effective значению шрифта понять, какой уровень предоставил размер или семейство шрифта?**

Непрямо. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/абзаце/текстовом кадре и стили текста на уровне макета/главного слайда/презентации, где появляется первое явное определение.

**Почему значения EffectiveData иногда выглядят идентичными локальным?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях effective значение совпадает с локальным.

**Когда следует использовать effective свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда нужен результат «как отрендерено» после применения всей наследственности (например, для согласования цветов, отступов или размеров). Если нужно изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, повторно считывайте EffectiveData, чтобы убедиться в результате.