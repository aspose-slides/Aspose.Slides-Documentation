---
title: Экспорт медиафайлов в HTML файл
type: docs
weight: 40
url: /ru/net/export-media-files-to-html-file/
---

Чтобы экспортировать медиафайлы в HTML, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд
- Установите эффект перехода
- Сохраните презентацию как файл PPTX

В приведённом ниже примере мы экспортировали медиафайлы в HTML.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Loading a presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Setting HTML options

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Saving the file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Скачать работающий пример**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20 Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Экспорт медиафайлов в файл HTML](/slides/ru/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}