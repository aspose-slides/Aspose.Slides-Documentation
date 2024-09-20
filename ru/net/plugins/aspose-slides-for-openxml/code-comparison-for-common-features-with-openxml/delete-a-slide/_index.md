---
title: Удалить слайд
type: docs
weight: 80
url: /net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Удалить слайд.pptx";

DeleteSlide(FileName, 1);

// Получите объект презентации и передайте его следующему методу DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Откройте исходный документ для чтения/записи.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Передайте исходный документ и индекс слайда, который следует удалить, следующему методу DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Удалите указанный слайд из презентации.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Используйте пример CountSlides, чтобы получить количество слайдов в презентации.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Получите часть презентации из документа презентации. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Получите презентацию из части презентации.

    Presentation presentation = presentationPart.Presentation;

    // Получите список идентификаторов слайдов в презентации.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Получите идентификатор слайда указанного слайда

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Получите идентификатор отношения слайда.

    string slideRelId = slideId.RelationshipId;

    // Удалите слайд из списка слайдов.

    slideIdList.RemoveChild(slideId);

    //

    // Удалите ссылки на слайд из всех пользовательских показов.

    if (presentation.CustomShowList != null)

    {

        // Перебор списка пользовательских показов.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Объявите связный список записей списка слайдов.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Найдите ссылку на слайд, которую нужно удалить из пользовательского показа.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Удалите все ссылки на слайд из пользовательского показа.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Сохраните измененную презентацию.

    presentation.Save();

    // Получите часть слайда для указанного слайда.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Удалите часть слайда.

    presentationPart.DeletePart(slidePart);

}

// Получите объект презентации и передайте его следующему методу CountSlides.

public static int CountSlides(string presentationFile)

{

    // Откройте презентацию только для чтения.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Передайте презентацию следующему методу CountSlide

        // и верните количество слайдов.

        return CountSlides(presentationDocument);

    }

}

// Подсчитайте количество слайдов в презентации.

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

string FileName = FilePath + "Удалить слайд.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Создайте объект PresentationEx, представляющий файл PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Доступ к слайду по его индексу в коллекции слайдов

        ISlide slide = pres.Slides[slideIndex];


        //Удаление слайда по его ссылке

        pres.Slides.Remove(slide);


        //Запись презентации как файла PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Скачать пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Удалить%20слайд%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Удалить%20слайд%20\(Aspose.Slides\).zip)
