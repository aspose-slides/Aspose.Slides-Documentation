---
title: Сохранить Презентацию - Библиотека C++ PowerPoint
linktitle: Сохранить Презентацию
type: docs
weight: 80
url: /ru/cpp/save-presentation/
description: C++ PowerPoint API или библиотека позволяет сохранить презентацию в файл или поток. Вы можете создать презентацию с нуля или изменить существующую.
---

{{% alert title="Информация" color="info" %}}

Чтобы узнать, как открыть или загрузить презентации, смотрите статью [*Открыть Презентацию*](https://docs.aspose.com/slides/cpp/open-presentation/). 

{{% /alert %}}

Статья здесь объясняет, как сохранять презентации.

Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) содержит содержимое презентации. Создавая презентацию с нуля или изменяя существующую, по окончании вы хотите сохранить презентацию. С Aspose.Slides для C++ она может быть сохранена как **файл** или **поток**. Эта статья объясняет, как сохранить презентацию различными способами:

## **Сохранить Презентацию в Файл**
Сохраните презентацию в файлы, вызвав метод **Save** класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). Просто передайте имя файла и формат сохранения методу [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). Примеры, которые следуют, показывают, как сохранить презентацию с помощью Aspose.Slides для C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **Сохранить Презентацию в Поток**
Можно сохранить презентацию в поток, передав выходной поток в метод сохранения класса [Presentation]() . Существуют многие типы потоков, в которые можно сохранить презентацию. В приведенном ниже примере мы создали новый файл Презентации, добавили текст в форму и сохранили презентацию в поток.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}

## **Сохранить Презентацию с Предопределенным Типом Вида**
Aspose.Slides для C++ предоставляет возможность установить тип вида для созданной презентации при ее открытии в PowerPoint через класс [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties). Свойство [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) используется для установки типа вида с помощью перечисления [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **Сохранить Презентацию в Строгом Формате Office Open XML**
Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Для этой цели он предоставляет класс **PptxOptions**, где вы можете установить свойство Conformance при сохранении файла презентации. Если вы установите его значение как **Conformance.Iso29500_2008_Strict**, то выходной файл презентации будет сохранен в строгом формате Office Open XML.

Следующий пример кода создает презентацию и сохраняет ее в строгом формате Office Open XML. При вызове метода Save для презентации объект **PptxOptions** передается с установленным свойством Conformance как **Conformance.Iso29500_2008_Strict**.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}

## **Сохранение Обновлений Прогресса в Процентах**
 Новый интерфейс **IProgressCallback** был добавлен в интерфейс **ISaveOptions** и абстрактный класс **SaveOptions**. Интерфейс **IProgressCallback** представляет объект обратного вызова для сохранения обновлений прогресса в процентах.  

Ниже приведенные фрагменты кода показывают, как использовать интерфейс IProgressCallback:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="Информация" color="info" %}}

Используя свой собственный API, Aspose разработал [бесплатное приложение для разделения PowerPoint](https://products.aspose.app/slides/splitter), которое позволяет пользователям разделять свои презентации на несколько файлов. По сути, приложение сохраняет выбранные слайды из данной презентации как новые файлы PowerPoint (PPTX или PPT). 

{{% /alert %}}