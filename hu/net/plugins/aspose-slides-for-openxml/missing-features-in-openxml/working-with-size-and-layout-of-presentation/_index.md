---
title: A prezentáció méretének és elrendezésének kezelése
type: docs
weight: 90
url: /hu/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** és **SlideSize.Size** a prezentáció osztály tulajdonságai, amelyeket az alábbi példában mutatott módon lehet beállítani és lekérni.
## **Példa**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Állítsa be a generált prezentációk dia méretét a forráséval megegyezőre
auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Mentse a prezentációt lemezre
auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Mintakód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Futtatható példa letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

További részletekért látogassa meg a [A prezentáció dia méretének módosítása .NET-ben](/slides/hu/net/slide-size/).

{{% /alert %}}