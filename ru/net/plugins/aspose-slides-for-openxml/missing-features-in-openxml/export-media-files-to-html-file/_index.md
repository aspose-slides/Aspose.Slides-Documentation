---
title: Экспорт медиафайлов в HTML файл
type: docs
weight: 40
url: /net/export-media-files-to-html-file/
---

Чтобы экспортировать медиафайлы в HTML, пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд
- Установите эффект перехода
- Запишите презентацию в файл PPTX

В приведенном ниже примере мы экспортировали медиафайлы в HTML.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Загрузка презентации

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Установка параметров HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Сохранение файла

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Скачать рабочий пример**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Экспорт медиафайлов в HTML файл](/slides/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}