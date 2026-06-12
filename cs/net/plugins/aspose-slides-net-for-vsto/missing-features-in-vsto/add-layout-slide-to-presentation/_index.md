---
title: Přidat rozložení snímku do prezentace
type: docs
weight: 10
url: /cs/net/add-layout-slide-to-presentation/
---
Aspose.Slides pro .NET umožňuje vývojářům přidávat nové Layout snímky v prezentaci. Pro přidání Layout snímku postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation
- Získejte přístup ke kolekci Master Slide
- Zkuste najít existující Layout snímky, abyste zjistili, zda požadovaný již není k dispozici v kolekci Layout Slide
- Přidejte nový Layout snímek, pokud požadované rozložení není k dispozici
- Přidejte prázdný snímek s nově přidaným Layout snímkem
- Nakonec zapište soubor prezentace pomocí objektu Presentation.
## **Příklad**
``` csharp

 //Vytvořte instanci třídy Presentation, která představuje soubor prezentace

using (Presentation p = new Presentation("Test.pptx"))

{

   // Pokuste se vyhledat podle typu rozložení snímku

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Situace, kdy prezentace neobsahuje některé typy rozložení.

     // Prezentace Technographics.pptx obsahuje pouze typy rozložení Blank a Custom.

     // Ale snímky s typem Custom mají různé názvy snímků,

     // jako "Title", "Title and Content" atd. A je možné použít tyto

     // názvy pro výběr rozložení snímku.

     // Také je možné použít sadu typů placeholder tvarů. Například,

     // Snímek Title by měl mít pouze typ placeholder Title, atd.

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

  //Přidání prázdného snímku s přidaným rozložením snímku

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Uložit prezentaci

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Stáhnout vzorový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pro více podrobností navštivte [Použití nebo změna rozložení snímků v .NET](/slides/cs/net/slide-layout/).

{{% /alert %}}