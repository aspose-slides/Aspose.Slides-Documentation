---
title: Diák összeállítása
type: docs
weight: 10
url: /hu/net/assemble-slides/
---
## **Dia hozzáadása egy bemutatóhoz**
Mielőtt a diák bemutató fájlokhoz való hozzáadásáról beszélnénk, tekintsünk át néhány tényt a diákkal kapcsolatban. Minden PowerPoint bemutató fájl tartalmaz egy mester/ elrendezési diát és további normál diát. Ez azt jelenti, hogy egy bemutató fájl legalább egy vagy több diát tartalmaz. Fontos tudni, hogy a diák nélküli bemutató fájlokat az Aspose.Slides for .NET nem támogatja. Minden diához egyedülálló azonosító tartozik, és a normál diák egy, a nullától induló index alapján meghatározott sorrendben vannak elrendezve.

- Hozzon létre egy példányt a **Presentation** osztályból
- Példányosítsa a **SlideCollection** osztályt a Presentation objektum Slides (a tartalmi Slide objektumok gyűjteménye) tulajdonságára való hivatkozással
- Adjunk egy üres diát a bemutatóhoz a tartalmi diák gyűjteményének végén, a **SlideCollection** objektum által kiadott **AddEmptySlide** metódusok meghívásával
- Végezzen némi műveletet az újonnan hozzáadott üres diával
- Végül írja ki a bemutató fájlt a **Presentation** objektum használatával

``` csharp

 PresentationEx pres = new PresentationEx();

//SlideCollection osztály példányosítása

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Üres dia hozzáadása a Slides gyűjteményhez

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//A PPTX fájl mentése a lemezre

pres.Write("EmptySlide.pptx");

``` 
## **Diaok elérése egy bemutatóban**
Az Aspose.Slides for .NET biztosít egy Presentation osztályt, amelyet felhasználhatunk a bemutatóban jelenlévő bármely kívánt dia megtalálására és elérésére.

**Diakollekció használata**

**Presentation** osztály egy bemutató fájlt reprezentál, és az összes diát egy **SlideCollection** gyűjteményként (azaz **Slide** objektumok gyűjteményeként) teszi hozzáférhetővé. Ezek a diák a **Slides** gyűjteményből a dia indexének használatával érhetők el.

``` csharp

 //Egy Presentation objektum példányosítása, amely egy bemutató fájlt képvisel

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Dia elérése a dia indexe alapján

SlideEx slide = pres.Slides[0];

``` 
## **Diaok eltávolítása**
Tudjuk, hogy a **Aspose.Slides for .NET** Presentation osztálya egy bemutató fájlt reprezentál. A Presentation osztály egy **SlideCollection**-t foglal magába, amely a bemutató részét képező összes dia tárolóját képezi. A fejlesztők két módon távolíthatnak el egy diát ebből a Slides gyűjteményből:

- Slide hivatkozás használata
- Slide index használata

**Slide hivatkozás használata**

Egy dia hivatkozásával történő eltávolításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze be egy dia hivatkozását az azonosítója vagy indexe alapján
- Távolítsa el a hivatkozott diát a bemutatóból
- Írja ki a módosított bemutató fájlt

``` csharp

 //Egy Presentation objektum példányosítása, amely egy bemutató fájlt képvisel

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Dia elérése a diák gyűjteményének indexe alapján

SlideEx slide = pres.Slides[0];

//Dia eltávolítása a hivatkozása alapján

pres.Slides.Remove(slide);

//A bemutató fájl írása

pres.Write("modified.pptx");

``` 
## **Dia pozíciójának megváltoztatása**
Nagyon egyszerű megváltoztatni egy dia pozícióját a bemutatóban. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze be egy dia hivatkozását az indexe alapján
- Módosítsa a hivatkozott dia SlideNumber értékét
- Írja ki a módosított bemutató fájlt

Az alábbi példában a bemutató egy diájának (amely a nullától számított 1-es indexen helyezkedett) pozícióját 1-es indexre (2. pozíció) változtattuk meg.

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//SlideCollection osztály példányosítása

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Üres dia hozzáadása a Slides gyűjteményhez

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//A PPTX fájl mentése a lemezre

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Presentation objektum példányosítása, amely egy bemutató fájlt képvisel

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Dia elérése a dia indexe alapján

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Presentation objektum példányosítása, amely egy bemutató fájlt képvisel

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Dia elérése a diák gyűjteményének indexe alapján

ISlide slide = pres.Slides[0];

//Dia eltávolítása a hivatkozása alapján

pres.Slides.Remove(slide);

//A bemutató fájl írása

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Presentation osztály példányosítása a forrás bemutató fájl betöltéséhez

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Az a dia lekérése, amelynek pozícióját módosítani kell

    ISlide sld = pres.Slides[0];

    //Az új pozíció beállítása a diához

    sld.SlideNumber = 2;

    //A bemutató mentése a lemezre

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)