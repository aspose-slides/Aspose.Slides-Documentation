---
title: Folie löschen
type: docs
weight: 80
url: /de/net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp
 // Öffnen Sie das Quelldokument zum Lesen/Schreiben.
 using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))
 {
     // Übergeben Sie das Quelldokument und den Index der zu löschenden Folie an die nächste DeleteSlide-Methode.
     DeleteSlide(presentationDocument, slideIndex);
 }

 // Löscht die angegebene Folie aus der Präsentation.
 public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)
 {
     if (presentationDocument == null)
     {
         throw new ArgumentNullException("presentationDocument");
     }

     // Verwenden Sie das CountSlides‑Beispiel, um die Anzahl der Folien in der Präsentation zu ermitteln.
     int slidesCount = CountSlides(presentationDocument);
     if (slideIndex < 0 || slideIndex >= slidesCount)
     {
         throw new ArgumentOutOfRangeException("slideIndex");
     }

     // Holen Sie den Präsentationsteil aus dem Präsentationsdokument.
     PresentationPart presentationPart = presentationDocument.PresentationPart;
     // Holen Sie die Präsentation aus dem Präsentationsteil.
     Presentation presentation = presentationPart.Presentation;
     // Holen Sie die Liste der Folien‑IDs in der Präsentation.
     SlideIdList slideIdList = presentation.SlideIdList;
     // Holen Sie die Folien‑ID der angegebenen Folie.
     SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;
     // Holen Sie die Beziehungs‑ID der Folie.
     string slideRelId = slideId.RelationshipId;
     // Entfernen Sie die Folie aus der Folienliste.
     slideIdList.RemoveChild(slideId);
     //
     // Entfernen Sie Verweise auf die Folie aus allen benutzerdefinierten Shows.
     if (presentation.CustomShowList != null)
     {
         // Durchlaufen Sie die Liste der benutzerdefinierten Shows.
         foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())
         {
             if (customShow.SlideList != null)
             {
                 // Erstellen Sie eine Liste von Folienlisteneinträgen.
                 LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();
                 foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())
                 {
                     // Finden Sie den Folienverweis, der aus der benutzerdefinierten Show entfernt werden soll.
                     if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)
                     {
                         slideListEntries.AddLast(slideListEntry);
                     }
                 }
                 // Entfernen Sie alle Verweise auf die Folie aus der benutzerdefinierten Show.
                 foreach (SlideListEntry slideListEntry in slideListEntries)
                 {
                     customShow.SlideList.RemoveChild(slideListEntry);
                 }
             }
         }
     }
     // Speichern Sie die geänderte Präsentation.
     presentation.Save();
     // Holen Sie den Folienteil für die angegebene Folie.
     SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;
     // Entfernen Sie den Folienteil.
     presentationPart.DeletePart(slidePart);
 }

 // Holen Sie das Präsentationsobjekt und übergeben Sie es an die nächste CountSlides‑Methode.
 public static int CountSlides(string presentationFile)
 {
     // Öffnen Sie die Präsentation als Nur‑Lese‑Zugriff.
     using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
     {
         // Übergeben Sie die Präsentation an die nächste CountSlide‑Methode
         // und geben Sie die Folienanzahl zurück.
         return CountSlides(presentationDocument);
     }
 }

 // Zählt die Folien in der Präsentation.
 public static int CountSlides(PresentationDocument presentationDocument)
 {
     // Prüfen Sie, ob das Dokumentobjekt null ist.
     if (presentationDocument == null)
     {
         throw new ArgumentNullException("presentationDocument");
     }

     int slidesCount = 0;
     // Holen Sie den Präsentationsteil des Dokuments.
     PresentationPart presentationPart = presentationDocument.PresentationPart;
     // Ermitteln Sie die Folienanzahl aus den SlideParts.
     if (presentationPart != null)
     {
         slidesCount = presentationPart.SlideParts.Count();
     }
     // Geben Sie die Folienanzahl an die vorherige Methode zurück.
     return slidesCount;
 }   
```
## **Aspose.Slides**
``` csharp
 // Instanziieren Sie ein PresentationEx‑Objekt, das eine PPTX‑Datei darstellt
 using (Presentation pres = new Presentation(presentationFile))
 {
     // Zugriff auf eine Folie über ihren Index in der Folien‑Collection
     ISlide slide = pres.Slides[slideIndex];

     // Entfernen einer Folie über ihre Referenz
     pres.Slides.Remove(slide);

     // Schreiben der Präsentation als PPTX‑Datei
     pres.Save(presentationFile, Aspose.Slides.Export.SaveFormat.Pptx);
 }
```
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)