---
title: Почему не Open XML SDK
type: docs
weight: 50
url: /ru/net/why-not-open-xml-sdk/
---

## **Что такое Open XML SDK?**
Иногда нам задают вопрос: *Почему мы должны использовать продукты Aspose, а не бесплатный Open XML SDK?*

Мы легко отвечаем на этот вопрос с точки зрения функций и возможностей.

Согласно [библиотеке MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK определяется так:

> "Open XML SDK 2.0 упрощает задачу манипулирования пакетами Open XML и основными элементами схемы Open XML внутри пакета. Open XML SDK 2.0 инкапсулирует множество общих задач, которые разработчики выполняют с пакетами Open XML, так что вы можете выполнять сложные операции всего лишь несколькими строками кода. Документы OOXML по сути представляют собой запакованные XML-файлы, а Open XML SDK – это набор классов, который позволяет работать с содержимым документов OOXML в строго типизированном формате. Вместо того чтобы распаковывать файл для извлечения XML, загружать этот XML в дерево DOM и работать напрямую с элементами и атрибутами XML, Open XML SDK предоставляет классы для выполнения этих задач."

## **Что такое Aspose.Slides?**
Aspose.Slides – это классная библиотека, которая позволяет приложениям выполнять следующие задачи обработки презентаций:

- Программирование с помощью модели объектов презентации.

- Конверсии высокого качества с использованием всех популярных поддерживаемых форматов презентаций PowerPoint, включая конверсию в PDF, XPS, TIFF и печать.

- Генерация миниатюр слайдов в известных форматах, таких как PNG, JPEG и BMP, а также экспорт слайдов в SVG.

- Создание презентаций с нуля или комбинирование элементов из одного или нескольких документов.

- Добавление анимаций, OLE-фреймов, таблиц, создание и управление графиками.

- Контроль (обширный контроль) и управление форматированием текста на уровнях TextFrames, Paragraphs и Portions.

  Для получения дополнительной информации о доступных функциях посетите страницу [Aspose.Slides Features](/slides/ru/net/product-overview/).
## **Сравнение Open XML SDK с Aspose.Slides**
В этой таблице сравниваются возможности и функции Open XML SDK с Aspose.Slides.

|**Функция или категория функций**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Поддерживаемые форматы презентаций|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Конверсия из PPT в PPTX |Нет|Да|
|<p>Высокоуровневое программирование с помощью модели документа презентации (DOM): </p><p>- Поиск и замена текста.</p><p>- Сборка слайдов в презентации.</p>|Нет|Да|
|Детальное программирование с помощью модели объекта документа; доступ к отдельным элементам и форматированию, таким как TextHolders, TextFrames, Paragraphs и Portions.|Да|Да|
|Низкоуровневый прямой и полный доступ к основным элементам и атрибутам XML, таким как идентификаторы отношений, идентификаторы списка документа OOXML.|Да|Нет|
|<p>Отрисовка и печать:</p><p>- Рендеринг презентаций в PDF, PDF Notes, XPS, TIFF изображения.</p><p>- Рендеринг миниатюр слайдов в PNG, JPEG, BMP, SVG и TIFF.</p><p>- Указание разрешения изображения, качества, сжатия и других параметров.</p><p>- Печать презентаций с использованием .NET инфраструктуры печати. Компонент имеет встроенный метод печати для печати презентаций, как показано в режиме предварительного просмотра печати MS PowerPoint.</p>|Нет|Да|
|Поддерживаемые платформы|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Заключение**
Open XML SDK и Aspose.Slides не конкурируют непосредственно, так как они охватывают значительно разные потребности и нацелены на разные аудитории.

{{% alert color="primary" %}} 

Open XML SDK – это классная библиотека, которая предоставляет строгий способ работы с документами OOXML, в то время как Aspose.Slides – это невероятно полезная библиотека для обработки презентаций, которая предоставляет отличную поддержку почти всех форматов файлов Microsoft PowerPoint.

{{% /alert %}} 

Если ваш рабочий процесс – это базовая операция программирования над документом PPTX, то Open XML SDK может быть хорошим выбором. С Open XML SDK вам будет удобно выполнять простые задачи, такие как создание простого документа PPTX или удаление комментариев, заголовков/колонтитулов, извлечение изображений и других. Определенные задачи можно выполнить с помощью Open XML SDK, но их нельзя выполнить с помощью Aspose.Slides. Например, если вам нужно получить прямой доступ к элементам и атрибутам XML документа OOXML, вам следует использовать Open XML SDK.

Если вам нужно выполнять сложные задачи с документами — такие как задачи из приведенного ниже списка — тогда Aspose.Slides является вашим лучшим вариантом.

- Операции, связанные со старыми форматами PowerPoint (а также PPTX).
- Копирование или клонирование фигур внутри слайдов так, чтобы объекты, стили и другие элементы форматирования комбинировались надлежащим образом.
- Замена отформатированного или неформатированного текста.
- Применение анимаций и использование соединителей с фигурами.
- Конвертация документа в PDF, TIFF или XPS так, чтобы он выглядел так, как будто Microsoft PowerPoint выполнил конвертацию.
- Разработка приложения .NET или Java как в настольных, так и в веб-средах.