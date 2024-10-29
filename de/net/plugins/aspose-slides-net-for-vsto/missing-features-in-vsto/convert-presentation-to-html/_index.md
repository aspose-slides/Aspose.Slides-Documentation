---  
title: Präsentation in HTML umwandeln  
type: docs  
weight: 40  
url: /de/net/convert-presentation-to-html/  
---  

**HTML** ist eines von mehreren weit verbreiteten Formaten zum Austausch von Daten. **Aspose.Slides für .NET** bietet Unterstützung für die Umwandlung einer Präsentation in HTML. Nachfolgend finden Sie einen Codeausschnitt, der zeigt, wie es geht.  
## **Beispiel**  
```  

//Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert  

Presentation pres = new Presentation("Conversion.ppt");  

HtmlOptions htmlOpt = new HtmlOptions();  

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);  

//Speichern der Präsentation als HTML  

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);  

```  
## **Laden Sie das ausführbare Beispiel herunter**  
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)  
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)  
## **Beispielcode herunterladen**  
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)  
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)  

{{% alert color="primary" %}}  

Für weitere Details besuchen Sie [Präsentation in HTML umwandeln](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-html/).  

{{% /alert %}}