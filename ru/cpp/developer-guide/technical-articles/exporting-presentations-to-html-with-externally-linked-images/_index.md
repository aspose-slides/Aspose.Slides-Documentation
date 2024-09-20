---
title: Экспорт презентаций в HTML с внешне связанными изображениями
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

В этой статье описывается усовершенствованная техника, позволяющая контролировать, какие ресурсы встраиваются в результирующий HTML-файл, а какие сохраняются внешне и ссылаются из HTML-файла.

{{% /alert %}} 
## **Предыстория**
Поведение по умолчанию при экспорте в HTML заключается в том, чтобы встраивать любой ресурс в HTML-файл. Такой подход приводит к созданию одного HTML-файла, который легко просматривать и распространять. Все необходимые ресурсы базируются в коде base64 внутри. Но у такого подхода есть два недостатка:

- Размер выходного файла значительно больше из-за кодирования base64. Заменить изображения, содержащиеся в файле, сложно.

В этой статье мы рассмотрим, как мы можем изменить поведение по умолчанию с помощью **Aspose.Slides для C++**, чтобы ссылки на изображения были внешними, а не встроенными в HTML-файл. Мы будем использовать интерфейс [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller), который содержит три метода для управления процессом встраивания и сохранения ресурсов. Мы можем передать этот интерфейс в конструктор [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options), когда подготавливаем экспорт.

Следующий код представляет собой полный код класса **LinkController**, который реализует интерфейс [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). Как уже упоминалось, **LinkController** должен реализовать интерфейс [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). Этот интерфейс определяет три метода:

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** Он вызывается, когда экспортер встречает ресурс и должен решить, как его сохранить. Наиболее важные параметры – это ‘id’ – уникальный идентификатор ресурса для всей операции экспорта и ‘contentType’ – содержит MIME-тип ресурса. Если мы решим связать ресурс, мы должны вернуть LinkEmbedDecision::Link из этого метода. В противном случае следует вернуть LinkEmbedDecision::Embed, чтобы встроить ресурс.
- **String GetUrl(int32_t id, int32_t referrer)**
  Он вызывается, чтобы получить URL ресурса в той форме, в какой он используется в результирующем файле, скажем, для тега ```<img src=%method_result_here%>```. Ресурс идентифицируется по ‘id’.
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  Заключительный метод последовательности, он вызывается, когда необходимо сохранить ресурс внешне. У нас есть идентификатор ресурса и содержимое ресурса в виде массива байтов. Решение о том, что делать с предоставленными данными ресурса, остается за нами.

``` cpp
/// <summary>
/// Этот класс отвечает за принятие решений о ресурсах, сохраняемых внешне.
/// Он должен реализовать интерфейс Aspose::Slides::Export::ILinkEmbedController.
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // Здесь мы принимаем решение о внешнем сохранении изображений.
        // id – уникальный идентификатор каждого объекта на протяжении всей операции экспорта.

        String template_;

        // Словарь s_templates содержит MIME-типы, которые мы собираемся сохранить внешне, и соответствующий шаблон имени файла.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // Сохраняем этот ресурс в списке экспорта
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // Все другие ресурсы, если они есть, будут встроены
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // Здесь мы формируем строку ссылки на ресурс для тега: <img src="%result%">
        // Нам нужно проверить словарь, чтобы отфильтровать ненужные ресурсы.
        // Параллельно с проверкой мы извлекаем соответствующий шаблон имени файла.
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // Предполагаем, что мы собираемся сохранять файлы ресурсов рядом с HTML-файлом.
            // Тег изображения будет выглядеть как <img src="image-1.png"> с соответствующим идентификатором ресурса и расширением.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // для ресурсов, остающихся встроенными, должно быть возвращено null
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // Здесь мы на самом деле сохраняем файлы ресурсов на диск.
        // Снова проверяем словарь. Если id не найдено здесь, это признак ошибки в методах GetObjectStoringLocation или GetUrl.
        if (m_externalImages->ContainsKey(id))
        {
            // Теперь мы используем имя файла, сохраненное в словаре, и комбинируем его с путем по необходимости.

            // Создаем имя файла, используя сохраненный шаблон и Id.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // Объединяем с директорией расположения
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"Что-то не так");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

После написания класса **LinkController** теперь мы будем использовать его с классом [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) для экспорта презентации в HTML с внешне связанными изображениями, используя следующий код.

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// Эта строка нужна, чтобы удалить отображение заголовка слайда в HTML.
// Закомментируйте это, если предпочитаете отображать заголовок слайда.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

Мы передаем **SlideImageFormat::Svg** в метод **set_SlideImageFormat**, что означает, что результирующий HTML-файл будет содержать данные SVG для отображения содержимого презентации.

Что касается MIME-типов, это зависит от фактических данных изображений, содержащихся в презентации. Если в презентации есть растровые битмап, то код класса должен быть готов обрабатывать как ‘image/jpeg’, так и ‘image/png’. Фактический MIME-тип экспортируемых растровых битмап может не совпадать с типом контента изображений, хранящихся в презентации. Внутренние алгоритмы Aspose.Slides для C++ выполняют оптимизацию размера и используют либо кодек JPG, либо PNG, в зависимости от того, какой из них генерирует меньший размер данных. Изображения, содержащие альфа-канал (прозрачность), всегда кодируются в PNG.