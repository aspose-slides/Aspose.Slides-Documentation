---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις σε .NET
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
- διαδικτυακή πηγή
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides for .NET. Γρήγορος οδηγός how-to."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην εξήγηση ιδεών και στην εμπλοκή του κοινού. Aspose.Slides for .NET σάς επιτρέπει να προσθέσετε πλαίσια βίντεο σε διαφάνειες, να προσαρμόσετε τις ρυθμίσεις αναπαραγωγής, να διαχειριστείτε υπότιτλους και να εξάγετε ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους προς διαδικτυακά βίντεο, όπως βίντεο του YouTube.

Για την αναπαράσταση δεδομένων βίντεο και πλαισίων βίντεο, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία ενσωματωμένου πλαισίου βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του πλαισίου είναι σε points. Η ροή παραμένει ανοιχτή μέχρι να ολοκληρωθεί η αποθήκευση επειδή το [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) το κρατά κλειδωμένο ενώ η παρουσίαση το χρησιμοποιεί.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Μπορείτε επίσης να περάσετε μια τοπική διαδρομή βίντεο απευθείας στο [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι να αποθηκευτεί η παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Ορισμός έντασης βίντεο με ακρίβεια**

Στο Aspose.Slides for .NET 26.11 ή νεότερο, το [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) ορίζει ένα ποσοστό κινητής υποδιαστολής από 0 έως 100. Χρησιμοποιήστε το όταν οι προεπιλογές [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) είναι πολύ ασάφεις. Για παράδειγμα, το `75.5f` ζητά ένταση 75,5%.

Αυτό το παράδειγμα απαιτεί το [Aspose.Slides for .NET](/slides/el/net/installation/) 26.11 ή νεότερο και ένα τοπικό `video.mp4`. Ενσωματώνει το βίντεο, αρχικοποιεί ρητά την αναπαραγωγή, αποθηκεύει την παρουσίαση και διαβάζει το αποθηκευμένο ποσοστό πίσω.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Επικυρώστε την είσοδο μόνοι σας· μην βασίζεστε στην μέθοδο setter για την απόρριψη τιμών εκτός του τεκμηριωμένου εύρους. Οι προεπιλογές Low, Medium και Loud αντιστοιχούν σε 20, 50 και 80 στο 26.11. Ο ορισμός μιας προεπιλογής μπορεί να αντικαταστήσει ένα προηγούμενο ποσοστό, επομένως ορίστε το ποσοστό τελευταίο όταν χρειάζεστε ακριβή τιμή. Χρησιμοποιήστε το [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) για την ρητή ρύθμιση σίγασης· το μηδενικό αριθμητικό και η προεπιλογή enum δεν είναι αμοιβαία εναλλάξιμες καταστάσεις.

Ορίστε ρητά το [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) όταν ρυθμίζετε επίσης ένα συνδεδεμένο βίντεο και διατηρήστε το αρχείο πολυμέσων διαθέσιμο για τον θεατή. Η αποθήκευση και η επανέναρξη επαληθεύουν την αποθηκευμένη ρύθμιση· η πραγματική αναπαραγωγή και ένταση εξαρτώνται από τον αναπαραγωγέα παρουσίασης και τις ρυθμίσεις ήχου του.

## **Δημιουργία πλαισίου βίντεο με βίντεο από διαδικτυακή πηγή**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει διαδικτυακά βίντεο σε παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο που συνδέεται με ένα διαδικτυακό βίντεο, όπως ένα βίντεο του YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η ρύθμιση [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο θεατής παρουσίασης πρέπει επίσης να υποστηρίζει την αναπαραγωγή διαδικτυακού βίντεο.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Αναπαραγωγή βίντεο σε λειτουργία πλήρους οθόνης**

Σε μια εκπαιδευτική παρουσίαση, μπορείτε να αναπαράγετε μια επίδειξη λογισμικού σε λειτουργία πλήρους οθόνης ώστε το κοινό να δει τις λεπτομέρειες. Ορίστε το [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) σε `true` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή σε πλήρη οθόνη. Η εισερχόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με ένα υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Η αναπαραγωγή σε πλήρη οθνη ελέγχει πώς εμφανίζεται το βίντεο. Ανεξάρτητα, το [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ελέγχει αν ξεκινά αυτόματα ή με κλικ, και το [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και βρόχου.

## **Επαναφορά βίντεο μετά την αναπαραγωγή**

Σε μια εκπαιδευτική παρουσίαση, η επιστροφή ενός βίντεο επίδειξης στην αρχή το κάνει έτοιμο για τον παρουσιαστή να το αναπαράγει ξανά. Ορίστε το [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) στη τιμή `true` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επαναφορά. Απενεργοποιεί την επανάληψη ώστε η αναπαραγωγή να μπορεί να ολοκληρωθεί και ορίζει την αναπαραγωγή να ξεκινά με κλικ. Η εισερχόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Η επαναφορά επιστρέφει το βίντεο στην αρχή χωρίς να το ξεκινήσει ξανά. Αντιθέτως, η ενεργοποίηση του [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) επαναλαμβάνει την αναπαραγωγή αυτόματα. Διατηρήστε την επανάληψη απενεργοποιημένη όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανααναπαραγωγή. Το [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ελέγχει ανεξάρτητα την αυτόματη ή κλικ-εκκίνηση· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση του βρόχου, όπως φαίνεται στο παράδειγμα. Η επαναφορά λειτουργεί ανεξάρτητα από το [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Περικοπή πλαισίου βίντεο**

Χρησιμοποιήστε το [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) και το [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές είναι σε χιλιοστά του δευτερολέπτου. Η περικοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός ρυθμίσεων περικοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τις πρώτες 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναπαράξιμο τμήμα.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Ανάγνωση ρυθμίσεων περικοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές περικοπής του πρώτου πλαισίου βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια. Εάν η διαφάνεια αυτή δεν έχει πλαίσιο βίντεο, δεν εκτυπώνεται κάτι. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Διαχείριση υπότιτλων βίντεο**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της ιδιότητας [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Προσθήκη υποτίτλων σε πλαίσιο βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα WebVTT κομμάτι υποτίτλων με ετικέτα English. Τα χρονικά στιγμιότυπα των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλους του.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) παρέχει επίσης υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

### **Εξαγωγή υποτίτλων από πλαίσιο βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα κομμάτια υποτίτλων από τα πλαίσια βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Διαδοχικοί αριθμοί διατηρούν τα αρχεία εξόδου διαφορετικά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων κομματιών. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) εκθέτει το αναγνωριστικό υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

### **Αφαίρεση υποτίτλων από πλαίσιο βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο στην πρώτη θέση σχήματος της πρώτης διαφάνειας και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι ένα πλαίσιο βίντεο.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Αν χρειάζεστε να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) ή [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) αντί για το [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Αναζήτηση υποτίτλων βίντεο**

Το [ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) επιστρέφει το πλήρες κομμάτι WebVTT, συμπεριλαμβανομένου του κεφαλίδας, των γραμμών χρονισμού και του κειμένου υποτίτλου. Για να βρείτε μια προφορική φράση και το χρονικό της σήμα, διαβάστε τα cues στη μνήμη. Για παράδειγμα, ένα αγγλικό κομμάτι στη διαφάνεια 2 μπορεί να περιέχει το παρακάτω κείμενο:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Το παράδειγμα επισκέπτεται κάθε διαφάνεια και διαβάζει τα κομμάτια των ανώτερων πλαισίων βίντεο μέσω του [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). Σε ένα απλό κείμενο cue, η γραμμή χρονισμού περιέχει `-->` και μια κενή γραμμή λήγει το cue. Όταν το κείμενο του υπότιτλου περιέχει «café», το παράδειγμα εκτυπώνει τον αριθμό της διαφάνειας, την ετικέτα του κομματιού, την αρχική γραμμή χρονισμού και τον πλήρη υπότιτλο.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Η αναζήτηση για «café» παράγει ένα ταίριασμα για το παράδειγμα κομματιού. Η κεφαλίδα και η ρύθμιση χρονισμού είναι εκτός του κειμένου cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Εξαγωγή βίντεο από διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει τα ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει τον τύπο MIME κάθε βίντεο και το συνολικό αριθμό. Η έξοδος χρησιμοποιεί τη γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερόμενο τύπο μέσου όταν χρειάζεται.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ποια παραμέτρους αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα πλαίσιο βίντεο;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (αυτόματα ή με κλικ) και την [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέετε ένα διαδικτυακό βίντεο και προσθέτετε μικρογραφία, η παρουσίαση αποθηκεύει τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα βίντεο, έτσι η αύξηση του μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον πλαίσιο βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) εντός του πλαισίου διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι μια κοινή κατάσταση για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε σε δίσκο.