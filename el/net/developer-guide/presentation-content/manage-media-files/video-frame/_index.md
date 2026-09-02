---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις στο .NET
linktitle: Πλαίσιο βίντεο
type: docs
weight: 10
url: /el/net/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- πλαίσιο βίντεο
- πηγή web
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα εμπλοκής με το κοινό σας. 

Το PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα βίντεο από το διαδίκτυο (από πηγή web όπως το YouTube). 

Για να μπορείτε να προσθέσετε βίντεο (video objects) σε μια παρουσίαση, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) και άλλα σχετικούς τύπους. 

## **Δημιουργία ενσωματωμένου πλαισίου βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
4. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα βίντεο που είναι αποθηκευμένο τοπικά σε μια παρουσίαση:

```c#
 // Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Φορτώνει το βίντεο
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Αποκτά την πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Αποθηκεύει την παρουσίαση στον δίσκο
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας τη διαδρομή του αρχείου απευθείας στη μέθοδο [AddVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Δημιουργία πλαισίου βίντεο με βίντεο από πηγή web**
Οι νεότερες εκδόσεις του Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζουν βίντεο από το διαδίκτυο σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του συνδέσμου web.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) 
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) και περάστε το σύνδεσμο προς το βίντεο.
4. Ορίστε μια μικρογραφία (thumbnail) για το πλαίσιο βίντεο. 
5. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα βίντεο από το διαδίκτυο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```c#
public static void Run()
{
    // Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Προσθέτει ένα VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Φορτώνει μικρογραφία
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Περικοπή πλαισίου βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγξετε ποιο μέρος ενός βίντεο αναπαράγεται ορίζοντας τις τιμές trim‑from‑start και trim‑from‑end μέσω των [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/trimfromstart/) και [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/trimfromend/). Και οι δύο τιμές καθορίζονται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο παραλείπεται από την αρχή και το τέλος του βίντεο, αντίστοιχά. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής βίντεο στην παρουσίαση· δεν κόβουν ούτε τροποποιούν τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός ρυθμίσεων περικοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις περικοπής του:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) σε μια διαφάνεια.
4. Ορίστε τις τιμές trim‑from‑start και trim‑from‑end μέσω των [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/trimfromstart/) και [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/trimfromend/).
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Ανάγνωση ρυθμίσεων περικοπής**

Για να ελέγξετε τις υπάρχουσες ρυθμίσεις περικοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) ανάμεσα στα σχήματα της πρώτης διαφάνειας και διαβάστε τις τιμές μέσω των [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/trimfromstart/) και [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/trimfromend/).

Το παρακάτω παράδειγμα κώδικα βρίσκει το πρώτο πλαίσιο βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις περικοπής του σε χιλιοστά του δευτερολέπτου:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Διαχείριση υποτίτλων βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της ιδιότητας [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/).

**Προσθήκη υποτίτλων σε πλαίσιο βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Προσθέστε ένα βίντεο στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) σε μια διαφάνεια.
4. Χρησιμοποιήστε τη συλλογή [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) για να προσθέσετε ένα WebVTT track υποτίτλων.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Προσθέτει ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

**Εξαγωγή υποτίτλων από πλαίσιο βίντεο**

Για να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Βρείτε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) στόχο.
3. Διασχίστε τη συλλογή [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) .
4. Αποθηκεύστε κάθε track υποτίτλων σε ένα αρχείο `.vtt`.

Ο παρακάτω κώδικας δείχνει πώς να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Αποθηκεύει το κομμάτι υποτίτλων σε αρχείο WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/el/net/aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF‑8.

**Αφαίρεση υποτίτλων από πλαίσιο βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Αποκτήστε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) στόχο.
3. Αφαιρέστε τα tracks υποτίτλων από τη συλλογή [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα track υποτίτλου, χρησιμοποιήστε τις μεθόδους [Remove](https://reference.aspose.com/slides/el/net/aspose.slides/captionscollection/remove/) ή [RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/captionscollection/removeat/) αντί για την [Clear](https://reference.aspose.com/slides/el/net/aspose.slides/captionscollection/clear/).

## **Εξαγωγή βίντεο από διαφάνεια**
Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Διασχίστε όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide) .
3. Διασχίστε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe). 
4. Αποθηκεύστε το βίντεο στο δίσκο.

Αυτός ο κώδικας C# δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

```c#
 // Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
 Presentation presentation = new Presentation("Video.pptx");

 // Διατρέχει τις διαφάνειες
 foreach (ISlide slide in presentation.Slides)
 {
     // Διατρέχει τα σχήματα
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // Αποθηκεύει το βίντεο στον δίσκο μόλις βρεθεί ένα VideoFrame που περιέχει το βίντεο
         if (shape is VideoFrame)
         {
             IVideoFrame vf = shape as IVideoFrame;
             String type = vf.EmbeddedVideo.ContentType;
             int ss = type.LastIndexOf('/');
             type = type.Remove(0, type.LastIndexOf('/') + 1);
             Byte[] buffer = vf.EmbeddedVideo.BinaryData;
             using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
             {                                                     
                 stream.Write(buffer, 0, buffer.Length);
             }
         }
     }
 }
```

## **Συχνές ερωτήσεις**

**Ποια παραμέτρους αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/playmode/) (αυτόματα ή με κλικ) και τη [βρόγχο αναπαραγωγής](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/playloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα βίντεο από το διαδίκτυο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/embeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα κοινό σενάριο για την ενημέρωση μέσων σε ένα υπάρχον layout.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/el/net/aspose.slides/video/contenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.