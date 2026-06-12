---
title: Převést prezentaci na TIFF s poznámkami
type: docs
weight: 50
url: /cs/net/convert-presentation-to-tiff-with-notes/
---
TIFF je jedním z několika široce používaných formátů obrázků, které Aspose.Slides pro .NET podporuje pro převod prezentace s poznámkami na obrázky. Také můžete generovat náhledy snímků v zobrazení poznámek ke snímkům. Níže jsou dva úryvky kódu, které ukazují, jak vytvořit TIFF obrázky prezentace v zobrazení poznámek ke snímkům.

Metoda [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save) zveřejněná třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) může být použita k převodu celé prezentace v zobrazení poznámek ke snímkům do formátu TIFF. Také můžete vytvořit náhled snímku v zobrazení poznámek ke snímkům pro jednotlivé snímky.
## **Příklad**

``` 

  //Vytvořte objekt Presentation, který představuje soubor prezentace

 Presentation pres = new Presentation("Conversion.pptx");

 //Ukládání prezentace do TIFF s poznámkami

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pro více informací navštivte [Převod PowerPoint prezentací do TIFF s poznámkami v .NET](/slides/cs/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}