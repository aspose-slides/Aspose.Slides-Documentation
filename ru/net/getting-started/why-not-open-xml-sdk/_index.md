---
title: Почему не Open XML SDK
type: docs
weight: 180
url: /ru/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- сравнение
- модель объектной презентации
- высококачественное преобразование
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, почему Aspose.Slides — лучший выбор по сравнению с бесплатным Open XML SDK: сравните возможности, конвертацию без автоматизации и широкую поддержку PPT, PPTX и ODP."
---
## **Обзор**

В этой статье объясняется, когда разработчики могут выбрать Open XML SDK или Aspose.Slides для работы с презентационными документами. Она описывает Open XML SDK как библиотеку для манипулирования пакетами OOXML и их базовыми элементами XML, тогда как Aspose.Slides представлена как библиотека обработки презентаций с высокоуровневой объектной моделью и поддержкой множества задач, связанных с PowerPoint.

Статья сравнивает оба варианта по поддерживаемым форматам, программной модели, рендерингу, поддержке платформ и типичным сценариям использования. Также уточняется, что Open XML SDK может подойти для базовых операций с PPTX или прямого доступа к элементам OOXML, тогда как Aspose.Slides более уместен для сложных задач, таких как работа с множеством форматов PowerPoint, копирование или клонирование фигур, замена текста, применение анимаций и конвертация презентаций в PDF, TIFF или XPS.

## **Что такое Open XML SDK?**
Иногда мы получаем такой вопрос: *Why should we use Aspose products rather than the free Open XML SDK?*

Мы считаем, что легко ответить на него, сравнивая возможности и функции.

Согласно [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK определяется так:

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Что такое Aspose.Slides?**
Aspose.Slides — это библиотека классов, позволяющая приложениям выполнять следующие задачи обработки презентаций:

- Программирование с объектной моделью презентации.  
- Высококачественные конвертации, охватывающие все популярные поддерживаемые форматы PowerPoint, включая конвертацию в PDF, XPS и TIFF.  
- Генерация миниатюр слайдов в известных форматах, таких как PNG, JPEG и BMP, а также экспорт слайдов в SVG.  
- Создание презентаций с нуля или путем объединения элементов из одного или нескольких документов.  
- Добавление анимаций, OLE‑фреймов, таблиц, создание и управление диаграммами.  
- Управление (расширенный контроль) и настройка форматирования текста на уровнях TextFrames, Paragraphs и Portions.  

Для получения более подробной информации о доступных функциях, пожалуйста, посетите страницу [Aspose.Slides Features](/slides/ru/net/product-overview/).

## **Сравнение Open XML SDK и Aspose.Slides**
Эта таблица сравнивает возможности и функции Open XML SDK и Aspose.Slides.

|**Функция или категория функции**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Поддерживаемые форматы презентаций|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Конвертация из PPT в PPTX|No|Yes|
|<p>Программирование высокого уровня с объектной моделью документа презентации (DOM): </p><p>- Поиск и замена текста.</p><p>- Сборка слайдов в презентациях.</p>|No|Yes|
|Подробное программирование с объектной моделью документа; доступ к отдельным элементам и форматированию, таким как TextHolders, TextFrames, Paragraphs и Portions.|Yes|Yes|
|Низкоуровневый прямой и полный доступ к базовым элементам XML и атрибутам, таким как идентификаторы отношений, идентификаторы списков OOXML‑документа.|Yes|No|
|<p>Рендеринг презентаций:</p><p>- Рендеринг презентаций в PDF, PDF Notes, XPS, TIFF‑изображения.</p><p>- Рендеринг миниатюр слайдов в PNG, JPEG, BMP, SVG и TIFF.</p><p>- Указание разрешения изображения, качества, сжатия и других параметров.</p>|No|Yes|
|Поддерживаемые платформы|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Заключение**
Open XML SDK и Aspose.Slides не конкурируют напрямую, поскольку они решают существенно разные задачи и ориентированы на разные аудитории.

{{% alert color="info" title="Note" %}}
Open XML SDK — это библиотека классов, предоставляющая типизированный способ работы с OOXML‑документами, тогда как Aspose.Slides — чрезвычайно полезная библиотека обработки презентаций, обеспечивающая отличную поддержку почти всех форматов файлов Microsoft PowerPoint.
{{% /alert %}}

Если ваш рабочий процесс представляет собой базовую программную операцию над документом PPTX, то Open XML SDK может стать хорошим выбором. С Open XML SDK вы сможете выполнять простые задачи, такие как генерация простого PPTX‑документа, удаление комментариев, колонтитулов, извлечение изображений и прочее. Некоторые задачи можно выполнить с помощью Open XML SDK, но нельзя выполнить с Aspose.Slides. Например, если вам нужен прямой доступ к элементам XML и атрибутам OOXML‑документа, стоит использовать Open XML SDK.

Если вам требуется выполнять сложные задачи над документами — такие, как перечислено ниже — то Aspose.Slides является лучшим вариантом.

- Операции с более старыми форматами PowerPoint (и PPTX тоже).  
- Копирование или клонирование фигур внутри слайдов таким образом, чтобы объединять объекты, стили и другие элементы форматирования надлежащим образом.  
- Замена отформатированного или неотформатированного текста.  
- Применение анимаций и использование соединителей с фигурами.  
- Конвертация документа в PDF, TIFF или XPS с качеством, как если бы конвертировал Microsoft PowerPoint.  
- Разработка приложений .NET или Java как для настольных, так и для веб‑окружений.