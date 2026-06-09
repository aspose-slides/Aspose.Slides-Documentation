---
title: "Διαχείριση Συνδέσμων σε Παρουσιάσεις με C++"
linktitle: "Σύνδεσμος"
type: docs
weight: 10
url: /el/cpp/connector/
keywords:
- σύνδεσμος
- τύπος σύνδεσμου
- σημείο σύνδεσμου
- γραμμή σύνδεσμου
- γωνία σύνδεσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ενδυναμώνει τις εφαρμογές C++ να σχεδιάζουν, συνδέουν και αυτο-δρομολογούν γραμμές σε διαφάνειες PowerPoint—αποκτήστε πλήρη έλεγχο πάνω σε ευθείς, γωνιακούς και καμπύλες συνδέσμους."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια ειδική γραμμή που συνδέει ή συνδέει δύο σχήματα μεταξύ τους και παραμένει προσαρτημένος στα σχήματα ακόμη και όταν αυτά μετακινούνται ή επανατοποθετούνται σε μια διαφάνεια.  

Οι σύνδεσμοι συνδέονται συνήθως σε *σημεία σύνδεσης* (πράσινα σημεία), τα οποία υπάρχουν σε όλα τα σχήματα εξ ορισμού. Τα σημεία σύνδεσης εμφανίζονται όταν ο κέρσορας έρχεται κοντά τους.

*Σημεία προσαρμογής* (πορτοκαλί σημεία), που υπάρχουν μόνο σε ορισμένους συνδέσμους, χρησιμοποιούνται για την τροποποίηση της θέσης και του σχήματος των συνδέσμων.

## **Τύποι Συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε ευθείς, γωνιακούς (elbow) και καμπύλες συνδέσμους.  

Το Aspose.Slides παρέχει αυτούς τους συνδέσμους:

| Σύνδεσμος | Εικόνα | Αριθμός σημείων προσαρμογής |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Σύνδεση Σχημάτων με Συνδέσμους**

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/).  
1. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.auto_shape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `AddAutoShape` που εκτίθεται από το αντικείμενο `Shapes`.  
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `AddConnector` του αντικειμένου `Shapes` ορίζοντας τον τύπο του συνδέσμου.  
1. Συνδέστε τα σχήματα με τον σύνδεσμο.  
1. Καλέστε τη μέθοδο `Reroute` για να εφαρμοστεί η συντομότερη διαδρομή σύνδεσης.  
1. Αποθηκεύστε την παρουσία.  

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε έναν σύνδεσμο (καμπυλωτό σύνδεσμο) μεταξύ δύο σχημάτων (έλλειψης και ορθογωνίου):

```c++
// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Φορτώνει την επιθυμητή παρουσίαση
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Πρόσβαση στη πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Προσθέτει ένα αυτόματο σχήμα Έλλειψη
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Προσθέτει ένα αυτόματο σχήμα Ορθογώνιο
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Προσθέτει ένα σχήμα συνδέσμου στη συλλογή σχημάτων της διαφάνειας
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Συνδέει τα σχήματα χρησιμοποιώντας το σύνδεσμο
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Καλεί τη μέθοδο reroute η οποία θέτει την αυτόματη συντομότερη διαδρομή μεταξύ των σχημάτων
	connector->Reroute();
	
	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

Η μέθοδος `connector->Reroute` επαναδρομολογεί έναν σύνδεσμο και τον αναγκάζει να ακολουθήσει την πιο σύντομη δυνατή διαδρομή μεταξύ των σχημάτων. Για να πετύχει αυτό, η μέθοδος ενδέχεται να αλλάξει τα σημεία `StartShapeConnectionSiteIndex` και `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Καθορισμός Σημείου Σύνδεσης**

Αν θέλετε ένας σύνδεσμος να συνδέει δύο σχήματα χρησιμοποιώντας συγκεκριμένα σημεία στα σχήματα, πρέπει να ορίσετε τα επιθυμητά σημεία σύνδεσης ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/).  
1. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.auto_shape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `AddAutoShape` του αντικειμένου `Shapes`.  
1. Προσθέστε έναν σύνδεσμο με τη μέθοδο `AddConnector` του αντικειμένου `Shapes` ορίζοντας τον τύπο του συνδέσμου.  
1. Συνδέστε τα σχήματα με τον σύνδεσμο.  
1. Ορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα.  
1. Αποθηκεύστε την παρουσία.  

Αυτός ο κώδικας C++ παρουσιάζει μια λειτουργία όπου καθορίζεται ένα προτιμώμενο σημείο σύνδεσης:

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Φορτώνει την επιθυμητή παρουσίαση
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Πρόσβαση στην πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Προσθέτει ένα αυτόματο σχήμα Έλλειψη
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Προσθέτει ένα αυτόματο σχήμα Ορθογώνιο
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Προσθέτει ένα σχήμα συνδέσμου στη συλλογή σχημάτων της διαφάνειας
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Συνδέει τα σχήματα χρησιμοποιώντας το σύνδεσμο
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Ορίζει τον προτιμώμενο δείκτη σημείου σύνδεσης στο σχήμα Έλλειψη
	int wantedIndex = 6;

	// Ελέγχει αν ο προτιμώμενος δείκτης είναι μικρότερος από τον μέγιστο αριθμό σημείων σύνδεσης
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Ορίζει το προτιμώμενο σημείο σύνδεσης στο αυτόματο σχήμα Έλλειψη
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Ρύθμιση Σημείου Συνδέσμου**

Μπορείτε να ρυθμίσετε έναν υπάρχοντα σύνδεσμο μέσω των σημείων προσαρμογής του. Μόνο οι σύνδεσμοι με σημεία προσαρμογής μπορούν να τροποποιηθούν με αυτόν τον τρόπο. Δείτε τον πίνακα κάτω από **[Τύπους συνδέσμων](/slides/el/cpp/connector/#types-of-connectors)**  

### **Απλή Περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (A και B) περνά από τρίτο σχήμα (C):

![connector-obstruction](connector-obstruction.png)

Κώδικας:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Για να αποφύγουμε ή να παρακάμψουμε το τρίτο σχήμα, μπορούμε να ρυθμίσουμε τον σύνδεσμο μετακινώντας την κάθετη γραμμή του προς τα αριστερά ως εξής:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Σύνθετες Περίπτωσες** 

Για πιο σύνθετες ρυθμίσεις, πρέπει να ληφθούν υπόψη τα εξής:

* Ένα προσαρμοζόμενο σημείο ενός συνδέσμου συνδέεται στενά με έναν τύπο που υπολογίζει και καθορίζει τη θέση του. Έτσι, αλλαγές στη θέση του σημείου ενδέχεται να αλλάξουν το σχήμα του συνδέσμου.  
* Τα σημεία προσαρμογής καθορίζονται με αυστηρή σειρά σε έναν πίνακα. Τα σημεία αριθμούνται από το σημείο εκκίνησης του συνδέσμου μέχρι το τέλος.  
* Οι τιμές των σημείων προσαρμογής αντιπροσωπεύουν το ποσοστό του πλάτους/υψους του σχήματος του συνδέσμου.  
  * Το σχήμα περιορίζεται από τα σημεία εκκίνησης και λήξης του συνδέσμου πολλαπλασιασμένα επί 1000.  
  * Το πρώτο, το δεύτερο και το τρίτο σημείο ορίζουν το ποσοστό από το πλάτος, το ποσοστό από το ύψος και πάλι το ποσοστό από το πλάτος, αντίστοιχα.  
* Για τους υπολογισμούς που καθορίζουν τις συντεταγμένες των σημείων προσαρμογής, πρέπει να ληφθούν υπόψη η περιστροφή του συνδέσμου και η ανάκλασή του. **Σημείωση** ότι η γωνία περιστροφής για όλους τους συνδέσμους που εμφανίζονται κάτω από **[Τύπους συνδέσμων](/slides/el/cpp/connector/#types-of-connectors)** είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου συνδέονται μεταξύ τους μέσω ενός συνδέσμου:

![connector-shape-complex](connector-shape-complex.png)

Κώδικας:

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει αρχείο PPTX
auto pres = System::MakeObject<Presentation>();
// Αποκτά τη πρώτη διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->idx_get(0);
// Λαμβάνει τα σχήματα από την πρώτη διαφάνεια
auto shapes = slide->get_Shapes();
// Προσθέτει σχήματα που θα συνδεθούν μέσω ενός συνδέσμου
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Προσθέτει έναν σύνδεσμο
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Ορίζει την κατεύθυνση του συνδέσμου
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Ορίζει το πάχος της γραμμής του συνδέσμου
lineFormat->set_Width(3);
// Ορίζει το χρώμα του συνδέσμου
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Συνδέει τα σχήματα με το σύνδεσμο
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Αποκτά τα σημεία προσαρμογής του συνδέσμου
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Ρύθμιση**

Μπορούμε να αλλάξουμε τις τιμές των σημείων προσαρμογής του συνδέσμου αυξάνοντας το αντίστοιχο ποσοστό πλάτους και ύψους κατά 20 % και 200 % αντίστοιχα:

```c++
// Αλλάζει τις τιμές των σημείων προσαρμογής
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-1](connector-adjusted-1.png)

Για να ορίσουμε ένα μοντέλο που μας επιτρέπει να προσδιορίσουμε τις συντεταγμένες και το σχήμα των μεμονωμένων τμημάτων του συνδέσμου, ας δημιουργήσουμε ένα σχήμα που αντιστοιχεί στο οριζόντιο τμήμα του συνδέσμου στο σημείο `connector.Adjustments[0]`:

```c++
// Σχεδίαζει το κάθετο τμήμα του συνδέσμου
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Το αποτέλεσμα:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, παρουσιάσαμε μια απλή λειτουργία ρύθμισης συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε κανονικές καταστάσεις, πρέπει να ληφθούν υπόψη η περιστροφή του συνδέσμου και η εμφάνισή του (που ορίζονται από τα `connector.Rotation`, `connector.Frame.FlipH` και `connector.Frame.FlipV`). Τώρα θα δείξουμε τη διαδικασία.

Πρώτα, προσθέστε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σκοπούς σύνδεσης) και δημιουργήστε έναν νέο (πράσινο) σύνδεσμο που το συνδέει με τα αντικείμενα που έχουμε ήδη δημιουργήσει.

```c++
// Δημιουργεί ένα νέο αντικείμενο δεσμευσης
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Δημιουργεί ένα νέο σύνδεσμο
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Συνδέει τα αντικείμενα χρησιμοποιώντας τον νεοδημιουργημένο σύνδεσμο
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Αποκτά τα σημεία προσαρμογής του συνδέσμου
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Αλλάζει τις τιμές των σημείων προσαρμογής
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-3](connector-adjusted-3.png)

Δεύτερον, δημιουργήστε ένα σχήμα που θα αντιστοιχεί στο οριζόντιο τμήμα του συνδέσμου που περνά από το νέο σημείο προσαρμογής `connector.Adjustments[0]`. Χρησιμοποιούμε τις τιμές από τα δεδομένα του συνδέσμου για `connector.Rotation`, `connector.Frame.FlipH` και `connector.Frame.FlipV` και εφαρμόζουμε τον γνωστό τύπο μετασχηματισμού συντεταγμένων για περιστροφή γύρω από σημείο `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Στην περίπτωσή μας, η γωνία περιστροφής του αντικειμένου είναι 90 μτ και ο σύνδεσμος εμφανίζεται κάθετα, οπότε ο αντίστοιχος κώδικας είναι:

```c++

```

Το αποτέλεσμα:

![connector-adjusted-4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που περιλαμβάνουν απλές ρυθμίσεις και σύνθετα σημεία προσαρμογής (σημεία με γωνίες περιστροφής). Χρησιμοποιώντας τη γνώση που αποκτήσατε, μπορείτε να αναπτύξετε το δικό σας μοντέλο (ή να γράψετε κώδικα) για να αποκτήσετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να ορίσετε τιμές σημείων προσαρμογής ενός συνδέσμου βάσει συγκεκριμένων συντεταγμένων διαφάνειας.

## **Εύρεση Γωνίας Γραμμών Συνδέσμου**

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/).  
1. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
1. Πρόσβαση στο σχήμα γραμμής συνδέσμου.  
1. Χρησιμοποιήστε το πλάτος, το ύψος, το ύψος πλαισίου σχήματος και το πλάτος πλαισίου σχήματος για να υπολογίσετε τη γωνία.

Αυτός ο κώδικας C++ δείχνει μια λειτουργία στην οποία υπολογίσαμε τη γωνία για ένα σχήμα γραμμής συνδέσμου:

```c++
void ConnectorLineAngle()
{

	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Φορτώνει την επιθυμητή παρουσίαση
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Πρόσβαση στην πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Πρόσβαση στη συλλογή σχημάτων των διαφανειών
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να «κολληθεί» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε εάν το σχήμα εκθέτει [σημεία σύνδεσης](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/get_connectionsitecount/). Αν δεν υπάρχουν ή ο αριθμός είναι μηδέν, η «κόλληση» δεν είναι διαθέσιμη· σε αυτή την περίπτωση, χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Είναι λογικό να ελέγχετε το πλήθος των σημείων πριν την προσάρτηση.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του αποσυνδέονται· ο σύνδεσμος παραμένει στη διαφάνεια ως απλή γραμμή με ελεύθερο αρχικό/τελικό σημείο. Μπορείτε είτε να τον διαγράψετε είτε να επανακαθορίσετε τις συνδέσεις και, εάν χρειαστεί, να το [επαναδρομολογήσετε](https://reference.aspose.com/slides/el/cpp/aspose.slides/connector/reroute/).

**Διατηρούνται οι συνδέσεις όταν αντιγράψω μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον τα αντίστοιχα σχήματα αντιγράφονται επίσης. Αν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα πρέπει να τα επαναπροσαρμόσετε.