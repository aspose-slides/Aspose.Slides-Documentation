---
title: Applicare un tema a una presentazione
type: docs
weight: 30
url: /it/net/apply-a-theme-to-a-presentation/
---
## **Presentazione OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Applica un nuovo tema alla presentazione. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Applica un nuovo tema alla presentazione. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Ottieni la parte di presentazione del documento di presentazione.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni la parte master delle diapositive esistente.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Ottieni la nuova parte master delle diapositive.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Rimuovi la parte tema esistente.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Rimuovi la vecchia parte master delle diapositive.

    presentationPart.DeletePart(slideMasterPart);

    // Importa la nuova parte master delle diapositive e riutilizza il vecchio ID di relazione.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Cambia alla nuova parte tema.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Inserisci il codice per il layout per questo esempio.

    string defaultLayoutType = "Title and Content";

    // Rimuovi la relazione del layout delle diapositive su tutte le diapositive. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Determina il tipo di layout della diapositiva per ogni diapositiva.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Elimina la vecchia parte del layout.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Applica la nuova parte del layout.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Applica la nuova parte del layout predefinito.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Ottieni il tipo di layout della diapositiva.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Osservazioni: se questo è usato nel codice di produzione, verificare un riferimento nullo.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Per applicare il tema è necessario clonare la diapositiva con il master, si prega di seguire i passaggi seguenti:

- Creare un'istanza della classe Presentation contenente la presentazione di origine da cui verrà clonata la diapositiva.
- Creare un'istanza della classe Presentation contenente la presentazione di destinazione nella quale la diapositiva verrà clonata.
- Accedere alla diapositiva da clonare insieme al master slide.
- Istanziare la classe IMasterSlideCollection facendo riferimento alla collezione Masters esposta dall'oggetto Presentation della presentazione di destinazione.
- Chiamare il metodo AddClone esposto dall'oggetto IMasterSlideCollection e passare il master del PPTX di origine da clonare come parametro al metodo AddClone.
- Istanziare la classe ISlideCollection impostando il riferimento alla collezione Slides esposta dall'oggetto Presentation della presentazione di destinazione.
- Chiamare il metodo AddClone esposto dall'oggetto ISlideCollection e passare la diapositiva della presentazione di origine da clonare e il master slide come parametri al metodo AddClone.
- Scrivere il file della presentazione di destinazione modificato.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instanzia la classe Presentation per caricare il file di presentazione di origine

    Presentation srcPres = new Presentation(presentationFile);

    //Instanzia la classe Presentation per la presentazione di destinazione (dove la slide deve essere clonata)

    Presentation destPres = new Presentation(outputFile);

    //Instanzia ISlide dalla collezione di slide nella presentazione di origine insieme a

    //slide master

    ISlide SourceSlide = srcPres.Slides[0];

    //Clona lo slide master desiderato dalla presentazione di origine alla collezione dei master nella

    //presentazione di destinazione

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Clona lo slide master desiderato dalla presentazione di origine alla collezione dei master nella

    //presentazione di destinazione

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Clona la slide desiderata dalla presentazione di origine con lo slide master desiderato alla fine della

    //collezione di slide nella presentazione di destinazione

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Clona lo slide master desiderato dalla presentazione di origine alla collezione dei master nella//presentazione di destinazione

    //Salva la presentazione di destinazione su disco

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Scarica Esempio di Codice Eseguibile**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)