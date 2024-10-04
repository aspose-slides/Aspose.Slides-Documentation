---
title: Obtener todos los hipervínculos externos en una presentación
type: docs
weight: 90
url: /es/net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **Presentación OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener todos los hipervínculos externos.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Devuelve todos los hipervínculos externos en las diapositivas de una presentación.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Declara una lista de cadenas.

List<string> ret = new List<string>();

// Abre el archivo de presentación como solo lectura.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Itera a través de todas las partes de la diapositiva en la parte de la presentación.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Itera a través de todos los enlaces en la parte de la diapositiva.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Itera a través de todas las relaciones externas en la parte de la diapositiva. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Si el ID de la relación coincide con el ID del enlace...

                if (relation.Id.Equals(link.Id))

                {

                    // Agrega la URI de la relación externa a la lista de cadenas.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Devuelve la lista de cadenas.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides para .NET permite a los desarrolladores gestionar los hipervínculos en la presentación, a nivel de presentación, diapositiva y marco de texto. La clase **IHyperlinkQueries** ayuda a gestionar los hipervínculos en una presentación.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener todos los hipervínculos externos.pptx";

// Instanciar un objeto Presentación que representa un archivo PPTX

Presentation pres = new Presentation(FileName);

// Obtener los hipervínculos de la presentación

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Ejemplo de código de descarga en ejecución**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Obtener todos los hipervínculos externos/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Obtener%20todos%20los%20hipervínculos%20externos)