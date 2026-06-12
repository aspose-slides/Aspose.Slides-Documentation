---
title: Modifica il colore di riempimento di una forma in una presentazione
type: docs
weight: 40
url: /it/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **Presentazione OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Modifica il colore di riempimento di una forma.

// Il file di test deve contenere una forma riempita come prima forma sulla prima diapositiva.

public static void SetPPTShapeColor(string docName)

{
    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))
    {
        // Ottieni l'ID di relazione della prima diapositiva.
        PresentationPart part = ppt.PresentationPart;
        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
        string relId = (slideIds[0] as SlideId).RelationshipId;
        // Ottieni la parte della diapositiva dall'ID di relazione.
        SlidePart slide = (SlidePart)part.GetPartById(relId);
        if (slide != null)
        {
            // Ottieni l'albero delle forme che contiene la forma da modificare.
            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;
            // Ottieni la prima forma nell'albero delle forme.
            Shape shape = tree.GetFirstChild<Shape>();
            if (shape != null)
            {
                // Ottieni lo stile della forma.
                ShapeStyle style = shape.ShapeStyle;
                // Ottieni il riferimento di riempimento.
                Drawing.FillReference fillRef = style.FillReference;
                // Imposta il colore di riempimento su SchemeColor Accent 6;
                fillRef.SchemeColor = new Drawing.SchemeColor();
                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;
                // Salva la diapositiva modificata.
                slide.Slide.Save();
            }
        }
    }
}
``` 
## **Aspose.Slides**
È necessario seguire questi passaggi per riempire le forme nella presentazione:

- Creare un'istanza della classe Presentation.
- Ottenere il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungere un IShape alla diapositiva.
- Impostare il tipo di riempimento della forma su Solido.
- Impostare il colore della forma.
- Scrivere la presentazione modificata come file PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Istanzia la classe PrseetationEx che rappresenta il PPTX 

using (Presentation pres = new Presentation())

{
    //Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];
    //Aggiungi una forma automatica di tipo rettangolo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    //Imposta il tipo di riempimento su Solido
    shp.FillFormat.FillType = FillType.Solid;
    //Imposta il colore del rettangolo
    shp.FillFormat.SolidFillColor.Color = Color.Yellow;
    //Scrivi il file PPTX su disco
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **Scarica Esempio di Codice in Esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)