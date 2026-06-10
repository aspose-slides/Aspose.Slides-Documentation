---
title: Dia törlése
type: docs
weight: 80
url: /hu/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Szerezze meg a prezentáció objektumot, és adja át a következő DeleteSlide metódusnak.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Nyissa meg a forrásdokumentumot olvasás/írás módban.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Adja át a forrásdokumentumot és a törlendő dia indexét a következő DeleteSlide metódusnak.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Törli a megadott diát a prezentációból.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Használja a CountSlides példát a prezentáció diáinak számának lekérdezéséhez.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Szerezze meg a prezentáció részét a prezentációdokumentumból. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Szerezze meg a prezentációt a prezentáció részből.

    Presentation presentation = presentationPart.Presentation;

    // Szerezze meg a diaazonosítók listáját a prezentációban.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Szerezze meg a megadott dia azonosítóját

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Szerezze meg a dia kapcsolat azonosítóját.

    string slideRelId = slideId.RelationshipId;

    // Távolítsa el a diát a dia listáról.

    slideIdList.RemoveChild(slideId);

    //

    // Távolítsa el a dia hivatkozásait az összes egyéni bemutatóból.

    if (presentation.CustomShowList != null)

    {

        // Iteráljon végig az egyéni bemutatók listáján.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Hozzon létre egy linklistát a dia listaelemeinek.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Keresse meg a diahivatkozást, amelyet el kell távolítani az egyéni bemutatóból.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Távolítsa el a dia minden hivatkozását az egyéni bemutatóból.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Mentse a módosított prezentációt.

    presentation.Save();

    // Szerezze meg a megadott dia részét.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Távolítsa el a dia részt.

    presentationPart.DeletePart(slidePart);

}

// Szerezze meg a prezentáció objektumot, és adja át a következő CountSlides metódusnak.

public static int CountSlides(string presentationFile)

{

    // Nyissa meg a prezentációt csak olvasásra.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Adja át a prezentációt a következő CountSlide metódusnak

        // és adja vissza a dia számát.

        return CountSlides(presentationDocument);

    }

}

// Számolja meg a diák számát a prezentációban.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ellenőrizze, hogy a dokumentumobjektum null-e.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Szerezze meg a dokumentum prezentáció részét.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Szerezze meg a diaok számát a SlideParts-ból.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Adja vissza a dia számát az előző metódusnak.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Példányosítson egy PresentationEx objektumot, amely egy PPTX fájlt képvisel

    using (Presentation pres = new Presentation(presentationFile))

    {

        //A diát az indexe segítségével a diák gyűjteményéből érjük el

        ISlide slide = pres.Slides[slideIndex];


        //Dia eltávolítása a hivatkozásával

        pres.Slides.Remove(slide);


        //A prezentáció mentése PPTX fájlként

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)