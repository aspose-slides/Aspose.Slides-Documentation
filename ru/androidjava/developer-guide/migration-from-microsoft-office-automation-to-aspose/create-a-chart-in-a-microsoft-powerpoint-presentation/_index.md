---
title: Создание графика в презентации Microsoft PowerPoint
type: docs
weight: 70
url: /ru/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Графики - это визуальные представления данных, которые широко используются в презентациях. В этой статье показан код для программного создания графика в Microsoft PowerPoint с помощью [VSTO](/slides/ru/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) и [Aspose.Slides для Android с помощью Java](/slides/ru/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Создание графика**
Примеры кода ниже описывают процесс добавления простого 3D-группового столбчатого графика с использованием VSTO. Вы создаете экземпляр презентации, добавляете к ней стандартный график. Затем используете рабочую книгу Microsoft Excel для доступа и изменения данных графика, а также для настройки свойств графика. Наконец, сохраните презентацию.
### **Пример VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создайте экземпляр презентации Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Добавьте **3D групповой столбчатый** график и получите к нему доступ.
1. Создайте новый экземпляр рабочей книги Microsoft Excel и загрузите данные графика.
1. Получите доступ к листу данных графика с помощью экземпляра рабочей книги Microsoft Excel.
1. Установите диапазон графика на листе и удалите серии 2 и 3 из графика.
1. Измените данные категорий графика на листе данных графика.
1. Измените данные серии 1 графика на листе данных графика.
1. Теперь получите доступ к заголовку графика и настройте связанные с шрифтом свойства.
1. Получите доступ к оси значений графика и установите основные единицы, вспомогательные единицы, максимальное и минимальное значения.
1. Получите доступ к глубине графика или оси серий и удалите ее, так как в этом примере используется только одна серия.
1. Теперь установите углы вращения графика по направлениям X и Y.
1. Сохраните презентацию.
1. Закройте экземпляры Microsoft Excel и PowerPoint.

**Выходная презентация, созданная с помощью VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Пример Aspose.Slides для Android через Java**
С использованием Aspose.Slides для Android через Java выполняются следующие шаги:

1. Создайте экземпляр презентации Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Добавьте **3D групповой столбчатый** график и получите к нему доступ.
1. Получите доступ к листу данных графика с помощью экземпляра рабочей книги Microsoft Excel.
1. Удалите неиспользуемые серии 2 и 3.
1. Получите доступ к категориям графика и измените метки.
1. Получите доступ к серии 1 и измените значения серии.
1. Теперь получите доступ к заголовку графика и установите свойства шрифта.
1. Получите доступ к оси значений графика и установите основные единицы, вспомогательные единицы, максимальное и минимальное значения.
1. Теперь установите углы вращения графика по направлениям X и Y.
1. Сохраните презентацию в формате PPTX.

**Выходная презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}