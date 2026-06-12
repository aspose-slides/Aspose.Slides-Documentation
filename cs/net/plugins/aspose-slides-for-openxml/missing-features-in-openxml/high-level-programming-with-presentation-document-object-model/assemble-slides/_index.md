---
title: Sestavit snímky
type: docs
weight: 10
url: /cs/net/assemble-slides/
---
## **Přidat snímek do prezentace**
Než budeme hovořit o přidávání snímků do souborů prezentace, pojďme si probrat několik faktů o snímcích. Každý soubor PowerPoint prezentace obsahuje hlavní / rozložení snímek a další normální snímky. To znamená, že soubor prezentace obsahuje alespoň jeden nebo více snímků. Je důležité vědět, že soubory prezentace bez snímků nejsou podporovány knihovnou Aspose.Slides pro .NET. Každý snímek má unikátní Id a všechny normální snímky jsou uspořádány v pořadí určeném nulovým indexem.

Aspose.Slides pro .NET umožňuje vývojářům přidávat prázdné snímky do jejich prezentace. Pro přidání prázdného snímku do prezentace postupujte podle následujících kroků:

- Vytvořte instanci třídy **Presentation**
- Instanciujte třídu **SlideCollection** nastavením odkazu na vlastnost Slides (kolekce obsahových objektů Slide) vystavenou objektem Presentation
- Přidejte prázdný snímek do prezentace na konec kolekce obsahových snímků zavoláním metod **AddEmptySlide**, které jsou vystaveny objektem **SlideCollection**
- Proveďte nějakou operaci s nově přidaným prázdným snímkem
- Nakonec zapište soubor prezentace pomocí objektu **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Vytvořit instanci třídy SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Přidat prázdný snímek do kolekce Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Uložit soubor PPTX na disk

pres.Write("EmptySlide.pptx");

``` 
## **Přístup k snímkům v prezentaci**
Aspose.Slides pro .NET poskytuje třídu Presentation, která může být použita k vyhledání a přístupu k libovolnému požadovanému snímku v prezentaci.

**Použití kolekce Slides**

Třída **Presentation** představuje soubor prezentace a zpřístupňuje všechny snímky v ní jako kolekci **SlideCollection** (tj. kolekci objektů **Slide**). Všechny tyto snímky lze získat z této kolekce **Slides** pomocí indexu snímku.

``` csharp

 //Vytvořit objekt Presentation, který představuje soubor prezentace

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Přístup ke snímku pomocí jeho indexu

SlideEx slide = pres.Slides[0];

``` 
## **Odebrat snímky**
Víme, že třída Presentation v **Aspose.Slides pro .NET** představuje soubor prezentace. Třída Presentation zapouzdřuje **SlideCollection**, která funguje jako úložiště všech snímků, jež jsou součástí prezentace. Vývojáři mohou odebrat snímek z této kolekce Slides dvěma způsoby:

- Pomocí odkazu na snímek
- Pomocí indexu snímku

**Použití odkazu na snímek**

Pro odebrání snímku pomocí jeho odkazu postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek pomocí jeho Id nebo Indexu
- Odeberte odkazovaný snímek z prezentace
- Zapište upravený soubor prezentace

``` csharp

 //Vytvořit objekt Presentation, který představuje soubor prezentace

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Přístup ke snímku pomocí jeho indexu v kolekci snímků

SlideEx slide = pres.Slides[0];

//Odstranění snímku pomocí jeho odkazu

pres.Slides.Remove(slide);

//Zapsání souboru prezentace

pres.Write("modified.pptx");

``` 
## **Změnit pozici snímku**
Je velmi jednoduché změnit pozici snímku v prezentaci. Stačí postupovat podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek pomocí jeho Indexu
- Změňte vlastnost SlideNumber odkazovaného snímku
- Zapište upravený soubor prezentace

V ukázce níže jsme změnili pozici snímku (nacházejícího se na nultém indexu, pozice 1) v prezentaci na index 1 (Pozice 2).

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

//Vytvořit instanci třídy SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Přidat prázdný snímek do kolekce Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Uložit soubor PPTX na disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Vytvořit objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Přístup ke snímku pomocí jeho indexu

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Vytvořit objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Přístup ke snímku pomocí jeho indexu v kolekci snímků

ISlide slide = pres.Slides[0];

//Odstranění snímku pomocí jeho odkazu

pres.Slides.Remove(slide);

//Zapsání souboru prezentace

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Vytvořit instanci třídy Presentation pro načtení zdrojového souboru prezentace

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Získat snímek, jehož pozice má být změněna

    ISlide sld = pres.Slides[0];

    //Nastavit novou pozici snímku

    sld.SlideNumber = 2;

    //Zapsat prezentaci na disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)