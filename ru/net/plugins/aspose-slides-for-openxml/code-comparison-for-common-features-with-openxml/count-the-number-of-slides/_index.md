---
title: Подсчет количества слайдов
type: docs
weight: 50
url: /net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Подсчет количества слайдов.pptx";

Console.WriteLine("Количество слайдов = {0}",

CountSlides(FileName));

Console.ReadKey();

// Получите объект презентации и передайте его в следующий метод CountSlides.

public static int CountSlides(string presentationFile)

{

    // Откройте презентацию только для чтения.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Передайте презентацию в следующий метод CountSlide

        // и верните количество слайдов.

        return CountSlides(presentationDocument);

    }

}

// Подсчет слайдов в презентации.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Проверьте объект документа на null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Получите часть презентации документа.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Получите количество слайдов из SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Верните количество слайдов в предыдущий метод.

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Подсчет количества слайдов.pptx";

Console.WriteLine("Количество слайдов = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Создать объект PresentationEx, представляющий файл PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Скачать пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip)