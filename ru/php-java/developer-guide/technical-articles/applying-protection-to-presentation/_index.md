---
title: Применение защиты к презентации
type: docs
weight: 60
url: /ru/php-java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Один из распространенных способов использования Aspose.Slides заключается в создании, обновлении и сохранении презентаций Microsoft PowerPoint 2007 (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложения, использующего Aspose.Slides таким образом, получают доступ к выходным презентациям. Защита их от редактирования является общей проблемой. Важно, чтобы автоматически сгенерированные презентации сохраняли свое исходное форматирование и содержимое.

В этой статье объясняется, как [конструируются презентации и слайды](/slides/ru/php-java/applying-protection-to-presentation/) и как Aspose.Slides для PHP через Java может [применить защиту к](/slides/ru/php-java/applying-protection-to-presentation/), а затем [удалить ее из](/slides/ru/php-java/applying-protection-to-presentation/) презентации. Эта функция уникальна для Aspose.Slides и на момент написания недоступна в Microsoft PowerPoint. Она предоставляет разработчикам способ контролировать, как используются презентации, создаваемые их приложениями.

{{% /alert %}} 
## **Состав слайда**
Слайд PPTX состоит из множества компонентов, таких как автофигуры, таблицы, OLE-объекты, сгруппированные фигуры, рамки для изображений, видеокадры, соединители и различные другие элементы, доступные для создания презентации. В Aspose.Slides для PHP через Java каждый элемент на слайде превращается в объект Shape. Другими словами, каждый элемент на слайде является либо объектом Shape, либо объектом, производным от объекта Shape. Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать универсальную блокировку для всех типов фигур, для разных типов фигур существуют разные виды блокировок. Класс BaseShapeLock является универсальным классом блокировки PPTX. В Aspose.Slides для PHP через Java поддерживаются следующие типы блокировок для PPTX.

- AutoShapeLock блокирует автофигуры.
- ConnectorLock блокирует соединительные фигуры.
- GraphicalObjectLock блокирует графические объекты.
- GroupshapeLock блокирует групповые фигуры.
- PictureFrameLock блокирует рамки для изображений.
  Любое действие, выполняемое над всеми объектами Shape в объекте Presentation, применяется ко всей презентации.
## **Применение и удаление защиты**
Применение защиты гарантирует, что презентацию нельзя редактировать. Это полезная техника для защиты содержимого презентации.
## **Применение защиты к фигурам PPTX**
Aspose.Slides для PHP через Java предоставляет класс Shape для обработки фигуры на слайде.

Как упоминалось ранее, для каждого класса формы есть соответствующий класс блокировки формы для защиты. Эта статья сосредоточена на блокировках NoSelect, NoMove и NoResize. Эти блокировки гарантируют, что фигуры нельзя выбрать (через щелчки мышью или другие методы выбора), а также нельзя перемещать или изменять размер.

Примеры кода, которые следуют, применяют защиту ко всем типам фигур в презентации.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **Удаление защиты**
Защита, примененная с помощью Aspose.Slides для .NET/Java, может быть удалена только с помощью Aspose.Slides для .NET/Java. Чтобы разблокировать фигуру, установите значение примененной блокировки в false. Пример кода, который следует, показывает, как разблокировать фигуры в заблокированной презентации.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}

## **Резюме**
{{% alert color="primary" %}} 

Aspose.Slides предоставляет несколько вариантов для применения защиты к фигурам в презентации. Можно заблокировать конкретную фигуру или пройти по всем фигурам в презентации и заблокировать их все, чтобы эффективно заблокировать презентацию. Только Aspose.Slides для PHP через Java может удалить защиту из презентации, которую она ранее защищала. Удалите защиту, установив значение блокировки в false.

{{% /alert %}}