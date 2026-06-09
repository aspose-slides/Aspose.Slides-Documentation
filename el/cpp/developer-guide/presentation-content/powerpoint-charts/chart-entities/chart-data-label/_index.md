---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/cpp/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++ για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων σε ένα διάγραμμα εμφανίζουν λεπτομέρειες σχετικά με τις σειρές δεδομένων του διαγράμματος ή με μεμονωμένα σημεία δεδομένων. Επιτρέπουν στους αναγνώστες να αναγνωρίζουν γρήγορα τις σειρές δεδομένων και κάνουν τα διαγράμματα πιο εύκολα στην κατανόηση.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες διαγράμματος**

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε την ακρίβεια των δεδομένων σε μια ετικέτα δεδομένων διαγράμματος:

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Παίρνει την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσθέτει γράφημα με προεπιλεγμένα δεδομένα
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Ορίζει μορφή αριθμού για τη σειρά
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Γράφει το αρχείο παρουσίασης στο δίσκο
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Εμφάνιση ποσοστών ως ετικέτες**
Το Aspose.Slides for C++ επιτρέπει τον ορισμό ετικετών ποσοστών σε εμφανιζόμενα διαγράμματα. Αυτός ο κώδικας C++ επιδεικνύει τη λειτουργία:

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
	System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

	System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::StackedColumn, 20, 20, 400, 400);
	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	System::SharedPtr<IChartCategory> cat;
	System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(chart->get_ChartData()->get_Categories()->get_Count(), 0);
	for (int32_t k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
	{
		cat = chart->get_ChartData()->get_Categories()->idx_get(k);

		for (int32_t i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
		{
			total_for_Cat[k] = total_for_Cat[k] + System::Convert::ToDouble(chart->get_ChartData()->get_Series()->idx_get(i)->get_DataPoints()->idx_get(k)->get_Value()->get_Data());
		}
	}

	double dataPontPercent = 0.f;

	for (int32_t x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(x);
		series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

		for (int32_t j = 0; j < series->get_DataPoints()->get_Count(); j++)
		{
			System::SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(j)->get_Label();
			dataPontPercent = (System::Convert::ToDouble(series->get_DataPoints()->idx_get(j)->get_Value()->get_Data()) / total_for_Cat[j]) * 100;

			System::SharedPtr<IPortion> port = System::MakeObject<Portion>();
			port->set_Text(System::String::Format(u"{0:F2} %", dataPontPercent));
			port->get_PortionFormat()->set_FontHeight(8.f);
			lbl->get_TextFrameForOverriding()->set_Text(u"");
			System::SharedPtr<IParagraph> para = lbl->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
			para->get_Portions()->Add(port);

			lbl->get_DataLabelFormat()->set_ShowSeriesName(false);
			lbl->get_DataLabelFormat()->set_ShowPercentage(false);
			lbl->get_DataLabelFormat()->set_ShowLegendKey(false);
			lbl->get_DataLabelFormat()->set_ShowCategoryName(false);
			lbl->get_DataLabelFormat()->set_ShowBubbleSize(false);

		}

	}

	// Αποθηκεύει την παρουσίαση που περιέχει το γράφημα
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ορισμός του συμβόλου ποσοστού με τις ετικέτες δεδομένων του διαγράμματος**
Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε το σύμβολο ποσοστού για μια ετικέτα δεδομένων διαγράμματος:

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Λαμβάνει αναφορά σε μια διαφάνεια μέσω του δείκτη της
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Δημιουργεί το γράφημα PercentsStackedColumn σε μια διαφάνεια
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Ορίζει το NumberFormatLinkedToSource σε ψευδές
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Ορίζει το ευρετήριο του φύλλου δεδομένων του γραφήματος
	int defaultWorksheetIndex = 0;

	// Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Διαγράφει τη προεπιλεγμένη δημιουργημένη σειρά
	chart->get_ChartData()->get_Series()->Clear();
	

	// Προσθέτει μια νέα σειρά
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Παίρνει την πρώτη σειρά γραφήματος
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Συμπληρώνει τα δεδομένα της σειράς
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Ορίζει το χρώμα γεμίσματος για τη σειρά
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Ορίζει τις ιδιότητες του LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Παίρνει τη δεύτερη σειρά γραφήματος
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Συμπληρώνει τα δεδομένα της σειράς
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Ορίζει το χρώμα γεμίσματος για τη σειρά
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Ορίζει τις ιδιότητες του LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Γράφει το αρχείο παρουσίασης στο δίσκο
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ορισμός απόστασης ετικέτας από τον άξονα**
Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε την απόσταση της ετικέτας από έναν άξονα κατηγορίας όταν εργάζεστε με διάγραμμα που σχεδιάζεται από άξονες:

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Λαμβάνει αναφορά σε μια διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Δημιουργεί ένα γράφημα στη διαφάνεια
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Λαμβάνει τη συλλογή σειρών του γραφήματος
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Ορίζει την απόσταση ετικέτας από έναν άξονα
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Γράφει το αρχείο παρουσίασης στο δίσκο
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ρύθμιση θέσης ετικέτας**

Όταν δημιουργείτε ένα διάγραμμα που δεν βασίζεται σε άξονες, όπως ένα πίτα διάγραμμα, οι ετικέτες δεδομένων του διαγράμματος μπορεί να βρίσκονται πολύ κοντά στην άκρη του. Σε τέτοια περίπτωση, πρέπει να ρυθμίσετε τη θέση της ετικέτας ώστε οι γραμμές οδηγίας να εμφανίζονται καθαρά.

Αυτός ο κώδικας C++ δείχνει πώς να ρυθμίσετε τη θέση της ετικέτας σε ένα πίτα διάγραμμα:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> chart = pres->get_Slide(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 200.0f, 200.0f);

System::SharedPtr<IChartSeriesCollection> series = chart->get_ChartData()->get_Series();
System::SharedPtr<IDataLabel> label = series->idx_get(0)->get_Label(0);
System::SharedPtr<IDataLabelFormat> dataLabelFormat = label->get_DataLabelFormat();

dataLabelFormat->set_ShowValue(true);
dataLabelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγίας και μείωση του μεγέθους γραμματοσειράς· αν χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για τα ακραία/κλειδιά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν ορισμένο κανόνα.

**Πώς μπορώ να διασφαλίσω συνεπή στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά τις γραμματοσειρές (οικογένεια, μέγεθος) και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στην πλευρά απόδοσης για να αποφύγετε την εναλλακτική χρήση.