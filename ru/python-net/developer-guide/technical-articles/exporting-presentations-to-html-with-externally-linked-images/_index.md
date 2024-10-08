---
title: Экспорт презентаций в HTML с внешне связанными изображениями
type: docs
weight: 100
url: /ru/python-net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

В этой статье описывается продвинутая техника, которая позволяет контролировать, какие ресурсы встраиваются в результирующий HTML-файл, а какие сохраняются отдельно и ссылаются на них из HTML-файла.

{{% /alert %}} 
## **Предыстория**
По умолчанию поведение экспорта в HTML заключается в встраивании любых ресурсов в HTML-файл. Такой подход приводит к созданию одного HTML-файла, который легко просматривать и распространять. Все необходимые ресурсы закодированы в base64. Но у этого подхода есть два недостатка:

- Размер выходного файла значительно больше из-за кодирования в base64. *Трудно заменить изображения, содержащиеся в файле.

В этой статье мы увидим, как можем изменить поведение по умолчанию, используя **Aspose.Slides для Python через .NET**, чтобы связывать изображения внешне, а не встраивать их в HTML-файл. Мы будем использовать интерфейс **ILinkEmbedController**, который содержит три метода для управления процессом встраивания и сохранения ресурсов. Мы можем передать этот интерфейс в конструктор класса HtmlOptions при подготовке к экспорту.

Ниже представлен полный код класса **LinkController**, который реализует интерфейс **ILinkEmbedController**. Как уже упоминалось, LinkController должен реализовать интерфейс ILinkEmbedController. Этот интерфейс определяет три метода:

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** Он вызывается, когда экспортер встречает ресурс и необходимо решить, как его сохранить. Наиболее важные параметры - это ‘id’ – уникальный идентификатор ресурса для всей операции экспорта и ‘contentType’ – содержит MIME-тип ресурса. Если мы решим связать ресурс, мы должны вернуть LinkEmbedDecision.Link из этого метода. В противном случае должен быть возвращен LinkEmbedDecision.Embed для встраивания ресурса.
- **public string GetUrl(int id, int referrer)** 
  Он вызывается для получения URL ресурса в той форме, в какой он используется в результирующем файле, например, для тега <img src=”%method_result_here%”>. Ресурс идентифицируется по ‘id’.
- **public void SaveExternal(int id, byte[] entityData)** 
  Последний метод последовательности, он вызывается, когда необходимо сохранить ресурс отдельно. У нас есть идентификатор ресурса и содержимое ресурса в виде массива байтов. Что делать с предоставленными данными ресурса – решать нам.

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

После написания класса **LinkController** теперь мы будем использовать его с классом **HTMLOptions** для экспорта презентации в HTML с внешне связанными изображениями, используя следующий код.

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

Мы назначили **SlideImageFormat.Svg** свойству **SlideImageFormat**, что означает, что результирующий HTML-файл будет содержать данные SVG для отображения содержимого презентации.

Что касается типов содержимого, это зависит от фактических данных изображений, содержащихся в презентации. Если в презентации есть растровые битмапы, тогда код класса должен быть готов обрабатывать как ‘image/jpeg’, так и ‘image/png’ типы содержимого. Фактический тип содержимого экспортируемых растровых битмапов может не совпадать с типами изображений, хранящимися в презентации. Внутренние алгоритмы Aspose.Slides производят оптимизацию размера и используют кодек JPG или PNG, в зависимости от того, какой генерирует меньший размер данных. Изображения, содержащие альфа-канал (прозрачность), всегда кодируются в PNG.