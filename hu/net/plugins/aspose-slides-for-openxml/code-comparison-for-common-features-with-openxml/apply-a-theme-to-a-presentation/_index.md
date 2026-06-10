---
title: Sablon alkalmazása egy prezentációra
type: docs
weight: 30
url: /hu/net/apply-a-theme-to-a-presentation/
---
## **OpenXML prezentáció**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Új sablont alkalmaz a prezentációra. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Új sablont alkalmaz a prezentációra. 

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

    // Lekéri a prezentáció dokumentum prezentáció részét.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lekéri a meglévő dia mester részt.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Lekéri az új dia mester részt.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Eltávolítja a meglévő sablon részt.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Eltávolítja a régi dia mester részt.

    presentationPart.DeletePart(slideMasterPart);

    // Importálja az új dia mester részt, és újra felhasználja a régi kapcsolat azonosítót.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Átvált az új sablon részre.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Beszúrja a kódot a elrendezéshez ebben a példában.

    string defaultLayoutType = "Title and Content";

    // Eltávolítja a dia elrendezés kapcsolatot minden dián. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Meghatározza a dia elrendezés típusát minden dián.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Törli a régi elrendezés részt.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Alkalmazza az új elrendezés részt.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Alkalmazza az új alapértelmezett elrendezés részt.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Lekéri a dia elrendezés típusát.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Megjegyzés: Ha ezt éles kódban használja, ellenőrizze a null hivatkozást.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
A sablon alkalmazásához a diát a masterrel együtt kell klónozni, kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy Presentation osztály példányt, amely tartalmazza a forrás prezentációt, ahonnan a diát klónozni kell.
- Hozzon létre egy Presentation osztály példányt, amely tartalmazza a cél prezentációt, ahova a diát klónozni kell.
- Érje el a klónozandó diát a master diával együtt.
- Hozzon létre egy IMasterSlideCollection példányt azzal, hogy hivatkozik a cél prezentáció Presentation objektuma által biztosított Masters gyűjteményre.
- Hívja meg az IMasterSlideCollection objektum által biztosított AddClone metódust, és adja át a forrás PPTX-ből származó, klónozandó mastert paraméterként az AddClone metódusnak.
- Hozzon létre egy ISlideCollection példányt, azzal hogy beállítja a hivatkozást a cél prezentáció Presentation objektuma által biztosított Slides gyűjteményre.
- Hívja meg az ISlideCollection objektum által biztosított AddClone metódust, és adja át a forrás prezentációból származó, klónozandó diát és a master diát paraméterként az AddClone metódusnak.
- Írja ki a módosított cél prezentáció fájlt.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Példányosítja a Presentation osztályt a forrás prezentáció fájl betöltéséhez
    //Példányosítja a Presentation osztályt a cél prezentációhoz (ahová a diát klónozni kell)
    //Példányosítja az ISlide interfészt a forrás prezentáció diái közül a
    //mesterdiát
    //Klónozza a kívánt mesterdiót a forrás prezentációból a mestergyűjteménybe a
    //cél prezentációba
    //Klónozza a kívánt mesterdiót a forrás prezentációból a mestergyűjteménybe a
    //cél prezentációba
    //Klónozza a kívánt diát a forrás prezentációból a kívánt masterrel a végére a
    //diagyűjteményben a cél prezentációban
    //Klónozza a kívánt mesterdiót a forrás prezentációból a mestergyűjteménybe a//cél prezentációba
    //Mentse a cél prezentációt a lemezre
    ISlide SourceSlide = srcPres.Slides[0];

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **Futtatható kódpélda letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Minta kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)