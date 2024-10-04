---
title: Obtener todo el texto en todas las diapositivas
type: docs
weight: 100
url: /es/net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener todo el texto en una diapositiva.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Número de diapositivas = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Diapositiva #{0} contiene: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Abrir la presentación en modo solo lectura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pasar la presentación al siguiente método CountSlides

        // y devolver el conteo de diapositivas.

        return CountSlides(presentationDocument);

    }

}

// Contar las diapositivas en la presentación.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verificar si el objeto del documento es nulo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtener la parte de presentación del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtener el conteo de diapositivas de las SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Devolver el conteo de diapositivas al método anterior.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Obtener el ID de relación de la primera diapositiva.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Obtener la parte de la diapositiva del ID de relación.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Construir un objeto StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Obtener el texto interno de la diapositiva:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtener todo el texto en una diapositiva.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Número de diapositivas = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Diapositiva #{0} contiene: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Instanciar la clase PresentationEx que representa PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Instanciar la clase PresentationEx que representa PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Acceder a la diapositiva

        ISlide sld = pres.Slides[index];

        //Iterar a través de formas para encontrar el marcador de posición

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //obtener el texto de cada marcador de posición

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Descargar el código de ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Obtener%20todo%20el%20texto%20en%20todas%20las%20diapositivas%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Obtener%20todo%20el%20texto%20en%20todas%20las%20diapositivas%20\(Aspose.Slides\).zip)