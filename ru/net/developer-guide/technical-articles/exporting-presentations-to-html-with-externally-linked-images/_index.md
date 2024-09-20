---
title: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Процедура экспорта презентаций в HTML позволяет вам определить

1. ресурсы, которые будут встроены в resulting HTML файл
2. ресурсы, которые будут сохранены отдельно и на которые будет ссылаться HTML файл.

{{% /alert %}} 

## **Предыстория**

Поведение экспорта по умолчанию — встраивать все ресурсы внутри HTML файла через кодировку base64. Такой подход формирует один HTML файл, что удобно для просмотра и распространения. Однако у данного подхода есть следующие ограничения: 

* результирующий файл значительно больше, чем его составляющие из-за кодировки base64. 
* изображения или ресурсы, содержащиеся в файле, сложно заменить.

### **Другой подход**

Другой подход, включающий **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)**, устраняет указанные ограничения.  

Класс `LinkController` реализует интерфейс `ILinkEmbedController`. Интерфейс затем передается в конструктор класса [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor). Интерфейс ILinkEmbedController содержит три метода, которые контролируют процесс встраивания и сохранения ресурсов:

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**: Этот метод вызывается, когда экспортер сталкивается с ресурсом и должен решить, как хранить ресурс. *id* (уникальный идентификатор ресурса для операции экспорта) и *contentType* (содержащий MIME тип ресурса) - наиболее важные параметры под методом. Если вы хотите связать ресурс, вы должны вернуть [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) из метода. В противном случае (для встраивания ресурса) вы должны вернуть [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/).

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**: Этот метод вызывается для получения URL ресурса в той же форме, в которой он используется в результирующем файле. Ресурс идентифицируется по *id*.

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**: Являясь последним методом последовательности, он вызывается, когда пришло время сохранить ресурс отдельно. Поскольку идентификатор ресурса и содержимое ресурса существуют в массиве байтов, вы можете выполнять различные задачи с данными ресурса.

Этот C# код для класса **LinkController** реализует интерфейс **ILinkEmbedController**:

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// Конструктор по умолчанию без параметров
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// Создает экземпляр класса и задает путь, по которому будут сохраняться сгенерированные файлы ресурсов.
    /// </summary>
    /// <param name="savePath">Путь к месту, где будут храниться сгенерированные файлы ресурсов.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// Член ILinkEmbedController
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // Здесь мы принимаем решение о хранении изображений отдельно.
        // id является уникальным идентификатором каждого объекта на протяжении всей операции экспорта.

        string template;

        // Словарь s_templates содержит типы контента, которые мы собираемся сохранять отдельно, и соответствующий шаблон имени файла.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // Сохраняем этот ресурс в список экспорта
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // Все остальные ресурсы, если таковые имеются, будут встроены
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// Член ILinkEmbedController
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // Здесь мы создаем строку ссылочного ресурса для формирования тега: <img src="%result%">
        // Нам нужно проверить словарь, чтобы отфильтровать ненужные ресурсы.
        // Параллельно с проверкой извлекаем соответствующий шаблон имени файла.
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // Предполагаем, что мы собираемся хранить файлы ресурса рядом с HTML файлом.
            // Тег изображения будет выглядеть как <img src="image-1.png"> с соответствующим идентификатором ресурса и расширением.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // Для ресурсов, остающихся встроенными, должно быть возвращено null
        return null;
    }

    /// <summary>
    /// Член ILinkEmbedController
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // Здесь мы фактически сохраняем файлы ресурсов на диск.
        // Еще раз проверяем словарь. Если id не найден здесь, это признак ошибки в методах GetObjectStoringLocation или GetUrl.
        if (m_externalImages.ContainsKey(id))
        {
            // Теперь мы используем имя файла, сохраненное в словаре, и комбинируем его с путем, как требуется.

            // Формируем имя файла, используя сохраненный шаблон и Id.
            var fileName = String.Format(m_externalImages[id], id);

            // Сочетаем с каталогом расположения
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("Что-то не так");
    }

    /// <summary>
    /// Получает или задает путь, по которому будут сохранены сгенерированные файлы ресурсов.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// Словарь для хранения ассоциаций между идентификаторами ресурсов и соответствующими именами файлов.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// Словарь для хранения ассоциаций между типами контента ресурсов, которые мы собираемся сохранять отдельно,
    /// и соответствующими шаблонами имен файлов.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

После написания класса **LinkController** мы теперь можем использовать его вместе с классом **HTMLOptions** для экспорта презентации в HTML с внешними связанными изображениями следующим образом:

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // Эта строка нужна, чтобы убрать отображение заголовка слайда в HTML.
    // Закомментируйте её, если хотите, чтобы заголовок слайда отображался.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("Начало экспорта");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

Мы присвоили `SlideImageFormat.Svg` свойству `SlideImageFormat`, чтобы результирующий HTML файл содержал данные SVG для отображения содержимого презентации.

Типы контента: Если презентация содержит растровые битмапы, то код класса должен быть подготовлен для обработки как типах контента 'image/jpeg', так и 'image/png'. Содержимое экспортируемых растровых изображений может не соответствовать тому, что было сохранено в презентации. Внутренние алгоритмы Aspose.Slides выполняют оптимизацию размера и используют либо кодек JPG, либо PNG (в зависимости от того, какой дает меньший размер данных). Изображения, содержащие альфа-канал (прозрачность), всегда кодируются в PNG.