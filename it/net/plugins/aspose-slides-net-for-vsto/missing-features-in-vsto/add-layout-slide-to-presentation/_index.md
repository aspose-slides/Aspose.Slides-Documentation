---
title: Aggiungi diapositiva Layout alla Presentazione
type: docs
weight: 10
url: /it/net/add-layout-slide-to-presentation/
---
Aspose.Slides per .NET consente agli sviluppatori di aggiungere nuove diapositive Layout in una presentazione. Per aggiungere una diapositiva Layout, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Accedi alla raccolta Master Slide
- Prova a trovare le diapositive Layout esistenti per verificare se quella richiesta è già disponibile nella raccolta Layout Slide o meno
- Aggiungi una nuova diapositiva Layout se il layout desiderato non è disponibile
- Aggiungi una diapositiva vuota con la diapositiva Layout appena aggiunta
- Infine, scrivi il file della presentazione usando l'oggetto Presentation.

## **Esempio**
``` csharp

 //Instanzia la classe Presentation che rappresenta il file della presentazione

using (Presentation p = new Presentation("Test.pptx"))

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

     // Però le diapositive layout con tipi Custom hanno nomi di diapositiva diversi,

     // come "Title", "Title and Content", ecc. È possibile utilizzare questi

     // nomi per la selezione della diapositiva layout.

     // È anche possibile utilizzare l'insieme dei tipi di forma segnaposto. Per esempio,

     // La diapositiva Title dovrebbe avere solo il tipo di segnaposto Title, ecc.

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

  //Aggiunta di una diapositiva vuota con la diapositiva layout aggiunta

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Salva la presentazione

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Scarica Esempio Eseguibile**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Per ulteriori dettagli, visita [Applica o Modifica Layout Diapositiva in .NET](/slides/it/net/slide-layout/).

{{% /alert %}}