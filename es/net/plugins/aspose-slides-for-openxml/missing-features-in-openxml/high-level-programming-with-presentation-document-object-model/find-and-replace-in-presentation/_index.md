---
title: Buscar y Reemplazar en Presentación
type: docs
weight: 20
url: /es/net/find-and-replace-in-presentation/
---

Los siguientes son los pasos a seguir:

1. Abre una presentación.
1. Busca el texto.
1. Reemplaza el texto.
1. Escribe la presentación.

``` csharp

 string FilePath = @"..\..\..\Archivos de muestra\";

//Abre la presentación

Presentation pres = new Presentation(FilePath + "Buscar y Reemplazar.pptx");

//Obtén todos los cuadros de texto en la presentación

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Encuentra el texto que debe ser reemplazado

        if (port.Text.Contains(strToFind))

        //Reemplaza el texto existente con el nuevo texto

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Buscar y Reemplazar.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Buscar%20y%20Reemplazar%20%28Aspose.Slides%29.zip)