---
title: Přechody snímků
type: docs
weight: 80
url: /cs/net/slide-transitions/
---
Aby to bylo snazší pochopit, demonstrovali jsme použití Aspose.Slides pro .NET k řízení jednoduchých přechodů snímků. Vývojáři mohou nejen aplikovat různé efekty přechodu snímků, ale také přizpůsobit chování těchto efektů přechodu. Chcete-li vytvořit jednoduchý efekt přechodu snímku, postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Použijte typ přechodu snímku na snímku z jedné z nabízených efektů přechodu od Aspose.Slides pro .NET pomocí výčtu **TransitionType** enum
- Zapište upravený soubor prezentace.

## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Vytvořte instanci třídy Presentation, která představuje soubor prezentace

using (Presentation pres = new Presentation(FileName))
{
    //Použijte přechod typu kruh na snímku 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    //Použijte přechod typu hřeben na snímku 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;
    //Použijte přechod typu zoom na snímku 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;
    //Uložte prezentaci na disk
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Stáhnout ukázkový příklad**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Pro více informací navštivte [Správa přechodů snímků](/slides/cs/net/slide-transition/).

{{% /alert %}}