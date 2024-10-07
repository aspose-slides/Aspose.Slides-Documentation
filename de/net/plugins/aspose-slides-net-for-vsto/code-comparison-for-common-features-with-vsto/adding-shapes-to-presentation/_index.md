---  
title: Formen zur Präsentation hinzufügen  
type: docs  
weight: 30  
url: /net/adding-shapes-to-presentation/  
---  

## **VSTO**  
Unten finden Sie den Code-Snippet zum Hinzufügen einer Linienform:  

``` csharp  

   Slide slide = Application.ActivePresentation.Slides[1];  

  slide.Shapes.AddLine(10, 10, 100, 10);  

```  
## **Aspose.Slides**  
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:  

- Erstellen Sie eine Instanz der Klasse Presentation  
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden  
- Fügen Sie eine AutoForm vom Typ Linie mit der Methode AddAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird  
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei  

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.  

``` csharp  

   //Instanziieren der Klasse Presentation, die die PPTX repräsentiert  

  Presentation pres = new Presentation();  

  //Holen Sie sich die erste Folie  

  ISlide slide = pres.Slides[0];  

  //Fügen Sie eine Autoform vom Typ Linie hinzu  

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);  

```  
## **Download Ausführbaren Code**  
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)  
## **Download Beispielcode**  
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)  