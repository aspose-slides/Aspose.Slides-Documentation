---  
title: Folienübergänge  
type: docs  
weight: 80  
url: /de/net/slide-transitions/  
---  

Um es einfacher zu verstehen, haben wir die Verwendung von Aspose.Slides für .NET zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf den Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den folgenden Schritten:

- Erstellen Sie eine Instanz der Presentation-Klasse
- Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für .NET angebotenen Übergangseffekte über das **TransitionType**-Enum an
- Schreiben Sie die modifizierte Präsentationsdatei.  
## **Beispiel**  
``` csharp  

 string FilePath = @"..\..\..\Sample Files\";  

string FileName = FilePath + "Managing Slides Transitions.pptx";  

//Instanz der Presentation-Klasse, die eine Präsentationsdatei darstellt  

using (Presentation pres = new Presentation(FileName))  

{  

    //Wenden Sie den Übergangstyp "Kreis" auf Folie 1 an  

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;  

    //Wenden Sie den Übergangstyp "Kamm" auf Folie 2 an  

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;  

    //Wenden Sie den Übergangstyp "Zoom" auf Folie 3 an  

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;  

    //Speichern Sie die Präsentation auf der Festplatte  

    pres.Save(FileName, SaveFormat.Pptx);  

}  

```  
## **Beispielcode herunterladen**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
## **Laufendes Beispiel herunterladen**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)  

{{% alert color="primary" %}}  

Für weitere Details besuchen Sie [Managing Slides Transitions](/slides/de/net/slide-transition/).  

{{% /alert %}}  