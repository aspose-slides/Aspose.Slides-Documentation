---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε C++
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/cpp/create-chart/
aliases:
  - /cpp/update-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διασκορπισμένο διάγραμμα
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα δένδρου
- διάγραμμα χρηματιστηρίου
- διάγραμμα κουτιού και φυκιδοφόρου
- διάγραμμα χωνιού
- διάγραμμα ηλιακής έκλαμψης
- διάγραμμα ιστογράμματος
- διάγραμμα ραντάρ
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε C++."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζουν με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος έως τη διαμόρφωση σειρών, αξόνων και υπομνοίων. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε μια στέρεη κατανόηση του πώς να ενσωματώσετε τη δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, βελτιστοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων με βάση τα δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους χρήστες να απεικονίζουν γρήγορα τα δεδομένα και να εξάγουν συμπεράσματα, τα οποία ίσως δεν είναι άμεσα εμφανή από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να Δημιουργείτε Διαγράμματα;**

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μια μόνο διαφάνεια παρουσίασης  
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα  
* να συναγάγετε την κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης  
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα, ασύνετα δεδομένα κ.λπ.  
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα  

Σε το PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας εισαγωγής, η οποία παρέχει πρότυπα για σχεδίαση πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) και προσαρμοσμένα διαγράμματα. 

{{% alert color="primary" %}} 

Για να μπορείτε να δημιουργήσετε διαγράμματα, το Aspose.Slides παρέχει την κλάση enum [ChartType](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) στο χώρο ονομάτων [Aspose::Slides::Charts](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.charts/). Οι τιμές σε αυτήν την κλάση enum αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων. 

{{% /alert %}} 

### **Δημιουργία Κανονικών Διαγραμμάτων**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον προτιμώμενο τύπο διαγράμματος.  
1. Προσθέστε τίτλο στο διάγραμμα.  
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.  
1. Διαγράψτε όλες τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Προσθέστε χρώμα γεμίσματος για τις σειρές του διαγράμματος.  
1. Προσθέστε ετικέτες για τις σειρές του διαγράμματος.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```c++
// Διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Προσεγγίζει την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Ορίζει το δείκτη του φύλλου δεδομένων του διαγράμματος
	int defaultWorksheetIndex = 0;

	// Αποκτά το φύλλο δεδομένων του διαγράμματος
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Ορίζει τον τίτλο του διαγράμματος
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Προσθέτει μια νέα σειρά
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Προσθέτει κατηγορίες
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// Παίρνει την πρώτη σειρά διαγράμματος
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Συμπληρώνει τα δεδομένα της σειράς
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Ορίζει το χρώμα γεμίσματος για τη σειρά
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Παίρνει τη δεύτερη σειρά διαγράμματος
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Συμπληρώνει τα δεδομένα της σειράς
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Ορίζει το χρώμα γεμίσματος για τη σειρά
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// Η πρώτη ετικέτα ορίζεται να εμφανίζει το όνομα της κατηγορίας
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Εμφανίζει την τιμή για την τρίτη ετικέτα
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Δημιουργία Διασκορπισμένων Διαγραμμάτων**
Τα διασκορπισμένα διαγράμματα (επίσης γνωστά ως διασκορπισμένα σημεία ή γραφήματα x‑y) χρησιμοποιούνται συχνά για να ελέγξουν μοτίβα ή να δείξουν συσχετισμούς μεταξύ δύο μεταβλητών. 

Μπορεί να θέλετε να χρησιμοποιήσετε ένα διασκορπισμένο διάγραμμα όταν  

* έχετε ζεύγη αριθμητικών δεδομένων  
* έχετε 2 μεταβλητές που ταιριάζουν καλά μεταξύ τους  
* θέλετε να προσδιορίσετε αν 2 μεταβλητές σχετίζονται  
* έχετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή  

```c++
// Διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Προσπελαύνει την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Ορίζει τον τίτλο του διαγράμματος
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Διαγράφει τη προεπιλεγμένη παραγόμενη σειρά 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
	int defaultWorksheetIndex = 0;

	// Αποκτά το φύλλο δεδομένων του διαγράμματος
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Προσθέτει μια νέα σειρά
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Αποκτά την πρώτη σειρά διαγράμματος
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Προσθέτει ένα νέο σημείο (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Προσθέτει ένα νέο σημείο (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Επεξεργάζεται τον τύπο της σειράς
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Αλλάζει το δείκτη της σειράς διαγράμματος
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Αποκτά τη δεύτερη σειρά διαγράμματος
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Προσθέτει νέο σημείο (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Προσθέτει ένα νέο σημείο (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Προσθέτει ένα νέο σημείο (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Προσθέτει ένα νέο σημείο (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Αλλάζει το δείκτη της σειράς διαγράμματος
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Ορίζει το περίγραμμα του τομέα
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Ορίζει το περίγραμμα του τομέα
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Ορίζει το περίγραμμα του τομέα
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Δημιουργεί τις προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// Εμφανίζει τις γραμμές οδηγούς για το διάγραμμα
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Ορίζει τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Πίτας Διαγραμμάτων**
Τα διαγράμματα πίτας είναι ιδανικά για να δείξουν τη σχέση μέρος‑στο‑σύνολο στα δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγοριοποιημένες ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ραβδόγραμμα αντί αυτού. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (σε αυτήν την περίπτωση, `ChartType.Pie`).  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Προσθέστε νέους σημείου για το διάγραμμα και προσαρμόστε χρώματα για τους τομείς της πίτας.  
1. Ορίστε ετικέτες για τις σειρές.  
1. Ορίστε γραμμές οδηγούς για τις ετικέτες των σειρών.  
1. Ορίστε τη γωνία περιστροφής για τις διαφάνειες της πίτας.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
	// Διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/PieChart_out.pptx";

	//Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Προσπελαύνει την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Ορίζει τον τίτλο του διαγράμματος
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Ορίζει το δείκτη του φύλλου δεδομένων του διαγράμματος
	int defaultWorksheetIndex = 0;

	// Αποκτά το φύλλο δεδομένων του διαγράμματος
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Προσθέτει κατηγορίες
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// Προσθέτει μια νέα σειρά
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// Παίρνει την πρώτη σειρά του διαγράμματος
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Συμπληρώνει τα δεδομένα της σειράς
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Ορίζει το περίγραμμα του τομέα
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Ορίζει το περίγραμμα του τομέα
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Ορίζει το περίγραμμα του τομέα
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// Ορίζει τη σειρά να εμφανίζει γραμμές οδηγούς για το διάγραμμα
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Ορίζει τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Γραμμικών Διαγραμμάτων**
Τα γραμμικά διαγράμματα (επίσης γνωστά ως γραφήματα γραμμής) είναι ιδανικά σε περιπτώσεις όπου θέλετε να δείξετε αλλαγές τιμών με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε πολλά δεδομένα ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις, να επισημάνετε ανωμαλίες σε σειρές κλπ.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (στην περίπτωση αυτή, `ChartType::Line`).  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

Από προεπιλογή, τα σημεία ενός γραμμικού διαγράμματος συνδέονται με συνεχείς ευθείες γραμμές. Αν θέλετε τα σημεία να συνδέονται με παύλες, μπορείτε να καθορίσετε τον προτιμώμενο τύπο παύλας ως εξής:  

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Δημιουργία Διαγραμμάτων Δένδρου (Tree Map)**
Τα διαγράμματα δένδρου είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών και ταυτόχρονα να τραβήξετε την προσοχή σε στοιχεία που συνεισφέρουν πολύ σε κάθε κατηγορία.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (σε αυτήν την περίπτωση, `ChartType.TreeMap`).  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/TreemapChart_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Πρόσβαση στην πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Κλαδί 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// Κλαδί 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Treemap);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	series->set_ParentLabelLayout(Aspose::Slides::Charts::ParentLabelLayoutType::Overlapping);

	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Διαγραμμάτων Χρηματιστηρίου**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον τύπο `ChartType.OpenHighLowClose`.  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Ορίστε μορφοποίηση HiLowLines.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
	// Διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Αποκτά την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
	int defaultWorksheetIndex = 0;

	// Αποκτά το φύλλο δεδομένων του διαγράμματος
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Προσθέτει κατηγορίες
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Προσθέτει μια νέα σειρά
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// Αποκτά την πρώτη σειρά του διαγράμματος
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Συμπληρώνει τα δεδομένα της πρώτης σειράς
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Συμπληρώνει τα δεδομένα της δεύτερης σειράς
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Συμπληρώνει τα δεδομένα της δεύτερης σειράς
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Συμπληρώνει τα δεδομένα της δεύτερης σειράς
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Ορίζει την ομάδα σειράς
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Διαγραμμάτων Box and Whisker**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον τύπο `ChartType.BoxAndWhisker`.  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Αποκτά την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 1")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::BoxAndWhisker);

	series->set_QuartileMethod(Aspose::Slides::Charts::QuartileMethodType::Exclusive);
	series->set_ShowMeanLine(true);
	series->set_ShowMeanMarkers(true);
	series->set_ShowInnerPoints(true);
	series->set_ShowOutlierPoints(true);

	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(41)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(23)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(16)));


	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Διαγραμμάτων Funnel**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον τύπο `ChartType.Funnel`.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Αποκτά την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));


	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Διαγραμμάτων Sunburst**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον τύπο `ChartType.sunburst`.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Αποκτά την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Κλαδί 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// Κλαδί 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Sunburst);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	// Γράφει το αρχείο παρουσίασης στο δίσκο
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Δημιουργία Διαγραμμάτων Ιστογράμματος**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με δεδομένα και καθορίστε τον προτιμώμενο τύπο (`ChartType.Histogram`).  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```c++
	// Διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Αποκτά την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Histogram, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Histogram);
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A2", System::ObjectExt::Box<int32_t>(-41)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A5", System::ObjectExt::Box<int32_t>(-23)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A6", System::ObjectExt::Box<int32_t>(16)));

	chart->get_Axes()->get_HorizontalAxis()->set_AggregationType(Aspose::Slides::Charts::AxisAggregationType::Automatic);

	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Διαγραμμάτων Radar**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με δεδομένα και καθορίστε τον προτιμώμενο τύπο (`ChartType.Radar`).  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX  

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Πολυκατηγορικών Διαγραμμάτων**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον τύπο `ChartType.ClusteredColumn`.  
1. Πρόσβαση στα δεδομένα του διαγράμματος μέσω του `IChartDataWorkbook`.  
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Αποκτά την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
	int defaultWorksheetIndex = 0;

	// Αποκτά το φύλλο δεδομένων του διαγράμματος
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Καθαρίζει το βιβλίο εργασίας
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// Προσθέτει κατηγορίες
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// Προσθέτει μια νέα σειρά
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"Series 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// Αποθηκεύει την παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Δημιουργία Χαρτών (Map Charts)**
Ένα διάγραμμα χάρτη είναι η απεικόνιση μιας περιοχής που περιέχει δεδομένα. Τα διαγράμματα χάρτη είναι ιδανικά για σύγκριση δεδομένων ή τιμών μεταξύ γεωγραφικών περιοχών.  

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**
Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα γράφημα. Αυτό το διάγραμμα σας επιτρέπει να υπογραμμίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.  

![Το συνδυαστικό διάγραμμα](combination_chart.png)

Ο παρακάτω κώδικας C++ δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:  

```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Ορίστε τον τίτλο του διαγράμματος.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // Ορίστε το υπόμνημα του διαγράμματος.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // Διαγράψτε τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Προσθέστε νέες κατηγορίες.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // Προσθέστε την πρώτη σειρά.
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<double>(4.3)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));

    return chart;
}

static void AddSecondSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<double>(2.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<double>(4.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<double>(1.8)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 2, ObjectExt::Box<double>(2.8)));
}

static void AddThirdSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box<String>(u"Series 3"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Line);

    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box<double>(3.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box<double>(5.0)));

    series->set_PlotOnSecondAxis(true);
}

static void SetAxisTitle(SharedPtr<IAxis> axis, String axisTitle)
{
    axis->set_HasTitle(true);
    axis->get_Title()->set_Overlay(false);
    auto titleParagraph = axis->get_Title()->AddTextFrameForOverriding(axisTitle)->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(12.0);
}

static void SetPrimaryAxesFormat(SharedPtr<IChart> chart)
{
    // Ορίστε τον οριζόντιο άξονα.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // Ορίστε τον κάθετο άξονα.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // Ορίστε το χρώμα των κύριων τιταναρίων του κάθετου άξονα.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // Ορίστε τον δευτερεύοντα οριζόντιο άξονα.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ορίστε τον δευτερεύοντα κάθετο άξονα.
    auto secondaryVerticalAxis = chart->get_Axes()->get_SecondaryVerticalAxis();
    secondaryVerticalAxis->set_Position(AxisPositionType::Right);
    secondaryVerticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    secondaryVerticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(secondaryVerticalAxis, u"Y Axis 2");
}

static void CreateComboChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = CreateChartWithFirstSeries(slide);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation->Save(u"combo-chart.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Ενημέρωση Διαγραμμάτων**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) που αντιπροσωπεύει την παρουσίαση με το διάγραμμα.  
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.  
4. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.  
5. Τροποποιήστε τα δεδομένα των σειρών του διαγράμματος αλλάζοντας τις τιμές των σειρών.  
6. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```c++
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Αποκτά το πρώτο slide
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Ορίζει το δείκτη για το φύλλο δεδομένων του διαγράμματος
int32_t defaultWorksheetIndex = 0;

// Αποκτά το φύλλο δεδομένων του διαγράμματος
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Αλλάζει το όνομα της κατηγορίας του διαγράμματος
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// Παίρνει την πρώτη σειρά του διαγράμματος
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Ενημερώνει τα δεδομένα της σειράς
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// Αλλάζει το όνομα της σειράς
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Παίρνει τη δεύτερη σειρά του διαγράμματος
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Τώρα ενημερώνει τα δεδομένα της σειράς
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// Αλλάζει το όνομα της σειράς
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Τώρα, προσθέτει μια νέα σειρά
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// Παίρνει την τρίτη σειρά του διαγράμματος
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Τώρα γεμίζει τα δεδομένα της σειράς
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Αποθηκεύει την παρουσίαση με το διάγραμμα
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ορισμός Εύρους Δεδομένων για Διαγράμματα**

1. Ανοίξτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) που περιέχει το διάγραμμα.  
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.  
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε το εύρος.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

``` cpp
// Η διαδρομή προς τον φάκελο εγγράφων.
String dataDir = GetDataPath();

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Αποκτά το πρώτο slide και προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **Χρήση Προεπιλεγμένων Δεικτών (Markers) σε Διαγράμματα**
Όταν χρησιμοποιείτε έναν προεπιλεγμένο δείκτη σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει διαφορετικό προεπιλεγμένο σύμβολο αυτόματα.  

``` cpp
// Η διαδρομή προς τον φάκελο εγγράφων.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Παίρνει τη δεύτερη σειρά του διαγράμματος
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// Συμπληρώνει τα δεδομένα της σειράς
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει ευρύ φάσμα τύπων διαγραμμάτων, συμπεριλαμβανομένων των ραβδωτών, γραμμικών, πίτας, περιοχής, διασκορπισμένων, ιστογράμματος, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) , ανακτάτε τη διαφάνειά σας χρησιμοποιώντας το δείκτη της και έπειτα καλείτε τη μέθοδο προσθήκης διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος αποκτώντας πρόσβαση στο βιβλίο εργασίας δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/)), διαγράφοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα δικά σας προσαρμοσμένα δεδομένα. Αυτό σας επιτρέπει να ανανεώσετε προγραμματιστικά το διάγραμμα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Είναι δυνατή η προσαρμογή της εμφάνισης του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτεταμένες επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης ώστε το διάγραμμα να ταιριάζει στις συγκεκριμένες απαιτήσεις σχεδίασής σας.