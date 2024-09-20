---  
title: Получить все внешние гиперссылки в презентации  
type: docs  
weight: 90  
url: /net/get-all-the-external-hyperlinks-in-a-presentation/  
---  

## **OpenXML Презентация**  
``` csharp  

 string FilePath = @"..\..\..\..\Sample Files\";  

string FileName = FilePath + "Получить все внешние гиперссылки.pptx";  

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))  

Console.WriteLine(s);  

// Возвращает все внешние гиперссылки на слайдах презентации.  

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)  

{  

// Объявляем список строк.  

List<string> ret = new List<string>();  

// Открываем файл презентации только для чтения.  

using (PresentationDocument document = PresentationDocument.Open(fileName, false))  

{  

    // Итерируемся по всем частям слайдов в части презентации.  

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)  

    {  

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();  

        // Итерируемся по всем гиперссылкам в части слайда.  

        foreach (Drawing.HyperlinkType link in links)  

        {  

            // Итерируемся по всем внешним отношениям в части слайда.  

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)  

            {  

                // Если ID отношения совпадает с ID гиперссылки...  

                if (relation.Id.Equals(link.Id))  

                {  

                    // Добавляем URI внешнего отношения в список строк.  

                    ret.Add(relation.Uri.AbsoluteUri);  

                }  

            }  

        }  

    }  

}  

// Возвращаем список строк.  

return ret;  

}  

```  
## **Aspose.Slides**  
Aspose.Slides для .NET позволяет разработчикам управлять гиперссылками в презентации на уровне презентации, слайда и текстового фрейма. Класс **IHyperlinkQueries** помогает управлять гиперссылками в презентации.  

``` csharp  

 string FilePath = @"..\..\..\..\Sample Files\";  

string FileName = FilePath + "Получить все внешние гиперссылки.pptx";  

//Создаем объект Presentation, представляющий файл PPTX  

Presentation pres = new Presentation(FileName);  

//Получаем гиперссылки из презентации  

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();  

foreach (IHyperlinkContainer link in links)  

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);  

```  
## **Скачать рабочий пример кода**  
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)  
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)  
## **Пример кода**  
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Получить все внешние гиперссылки/)  
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Получить%20все%20внешние%20гиперссылки)  