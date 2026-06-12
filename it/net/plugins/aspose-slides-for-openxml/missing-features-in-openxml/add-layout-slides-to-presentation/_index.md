---
title: Aggiungi diapositive Layout alla presentazione
type: docs
weight: 20
url: /it/net/add-layout-slides-to-presentation/
---
Aspose.Slides per .NET consente agli sviluppatori di aggiungere nuove diapositive Layout in una presentazione. Per aggiungere una diapositiva Layout, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Accedi alla raccolta Master Slide
- Prova a trovare le diapositive Layout esistenti per verificare se quella necessaria è già disponibile nella raccolta Layout Slide
- Aggiungi una nuova diapositiva Layout se il layout desiderato non è disponibile
- Aggiungi una diapositiva vuota con la diapositiva Layout appena aggiunta
- Infine, scrivi il file di presentazione usando l'oggetto Presentation
## **Esempio**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Istanzia la classe Presentation che rappresenta il file della presentazione

using (Presentation p = new Presentation(FileName))

{

    // Prova a cercare per tipo di diapositiva layout

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // La situazione in cui una presentazione non contiene alcuni tipi di layout.

        // La presentazione Technographics.pptx contiene solo i tipi di layout Blank e Custom.

        // Tuttavia le diapositive layout con tipi Custom hanno nomi di diapositiva diversi,

        // come "Title", "Title and Content", ecc. Ed è possibile utilizzare questi

        // nomi per la selezione della diapositiva layout.

        // Inklusive è possibile utilizzare l'insieme dei tipi di forma placeholder. Per esempio,

        // La diapositiva Title dovrebbe avere solo il tipo di placeholder Title, ecc.

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "Title and Object")

            {

                layoutSlide = titleAndObjectLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

            {

                if (titleLayoutSlide.Name == "Title")

                {

                    layoutSlide = titleLayoutSlide;

                    break;

                }

            }

            if (layoutSlide == null)

            {

                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

                if (layoutSlide == null)

                {

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

                }

            }

        }

    }

    //Aggiunta diapositiva vuota con la diapositiva layout aggiunta 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Salva la presentazione    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica l'esempio in esecuzione**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Per ulteriori dettagli, visita [Applica o modifica layout delle diapositive in .NET](/slides/it/net/slide-layout/).

{{% /alert %}}