---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις σε .NET
linktitle: Πλαίσιο Βίντεο
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
- πηγή ιστού
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για .NET. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο εντυπωσιακό και να αυξήσει τα επίπεδα δέσμευσης με το κοινό σας.

Το PowerPoint σάς επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια μιας παρουσίασης με δύο τρόπους:

* Προσθήκη ή ενσωμάτωση τοπικού βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθήκη διαδικτυακού βίντεο (από πηγή ιστού όπως το YouTube).

Για να σας επιτρέψει την προσθήκη βίντεο (αντικειμένων βίντεο) σε μια παρουσίαση, η Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα βίντεο που είναι αποθηκευμένο τοπικά σε μια παρουσίαση:

```c#
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Φορτώνει το βίντεο
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Παίρνει την πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Αποθηκεύει την παρουσίαση στον δίσκο
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας άμεσα τη διαδρομή του αρχείου στη μέθοδο [AddVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Πηγή Ιστού**
Το Microsoft [PowerPoint 2013 και νεότερο](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο διαδικτυακά (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/net/aspose.slides/ivideo/) και περάστε το σύνδεσμο του βίντεο.
1. Ορίστε μια μικρογραφία (thumbnail) για το πλαίσιο βίντεο.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα βίντεο από τον ιστό σε μια διαφάνεια σε παρουσίαση PowerPoint:

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

## **Διαχείριση Υπότιτλων Βίντεο**

Η Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της ιδιότητας [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) .

**Προσθήκη Υποτίτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Προσθέστε ένα βίντεο στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) σε μια διαφάνεια.
4. Χρησιμοποιήστε τη συλλογή [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) για να προσθέσετε ένα WebVTT κομμάτι υποτίτλου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο ακόλουθος κώδικας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Προσθέτει ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που επιτρέπει την προσθήκη υποτίτλων από ροή (stream).

**Εξαγωγή Υποτίτλων από Πλαίσιο Βίντεο**

Για να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Βρείτε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) στόχο.
3. Επανάληψη πάνω στη συλλογή [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) .
4. Αποθηκεύστε κάθε κομμάτι υποτίτλου σε αρχείο `.vtt`.

Ο ακόλουθος κώδικας δείχνει πώς να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

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

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/el/net/aspose.slides/icaptions/) αποκαλύπτει το αναγνωριστικό του υποτίτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υποτίτλου ως συμβολοσειρά UTF‑8.

**Κατάργηση Υποτίτλων από Πλαίσιο Βίντεο**

Για να καταργήσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Λάβετε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) στόχο.
3. Αφαιρέστε τα κομμάτια υποτίτλων από τη συλλογή [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/captiontracks/) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο ακόλουθος κώδικας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

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

Εάν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υποτίτλου, χρησιμοποιήστε τις μεθόδους [Remove](https://reference.aspose.com/slides/el/net/aspose.slides/captionscollection/remove/) ή [RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/captionscollection/removeat/) αντί για το [Clear](https://reference.aspose.com/slides/el/net/aspose.slides/captionscollection/clear/) .

## **Εξαγωγή Βίντεο από Διαφάνεια**

Πέρα από την προσθήκη βίντεο σε διαφάνειες, η Aspose.Slides επιτρέπει την εξαγωγή βίντεο που είναι ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Επανάληψη σε όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide) .
3. Επανάληψη σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe) . 
4. Αποθηκεύστε το βίντεο στον δίσκο.

Αυτός ο κώδικας C# δείχνει πώς να εξαγάγετε το βίντεο από μια διαφάνεια παρουσίασης:

```c#
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
Presentation presentation = new Presentation("Video.pptx");

// Διασχίζει τις διαφάνειες
foreach (ISlide slide in presentation.Slides)
{
    // Διασχίζει τα σχήματα
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Αποθηκεύει το βίντεο στον δίσκο μόλις βρεθεί το VideoFrame που περιέχει βίντεο
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

## **FAQ**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/playmode/) (αυτόματη ή με κλικ) και τη [looping](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/playloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, επομένως το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/el/net/aspose.slides/videoframe/embeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι συνηθισμένο σενάριο για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο διαθέτει έναν [content type](https://reference.aspose.com/slides/el/net/aspose.slides/video/contenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στον δίσκο.