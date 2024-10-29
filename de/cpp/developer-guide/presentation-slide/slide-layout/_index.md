---
title: Folienlayout
type: docs
weight: 60
url: /de/cpp/slide-layout/
keyword: "Foliengröße festlegen, Folienoptionen festlegen, Foliengröße angeben, Fußzeilenanzeige, Kindfußzeile, Inhaltsmaßstab, Seitengröße, C++, CPP, Aspose.Slides"
description: "Legen Sie die Größe und Optionen von PowerPoint-Folien in C++ fest"
---

Ein Folienlayout enthält die Platzhalter und Formatierungsinformationen für alle Inhalte, die auf einer Folie erscheinen. Das Layout bestimmt die verfügbaren Inhaltsplatzhalter und deren Position.

Folienlayouts ermöglichen es Ihnen, Präsentationen schnell zu erstellen und zu gestalten (ob einfach oder komplex). Dies sind einige der beliebtesten Folienlayouts, die in PowerPoint-Präsentationen verwendet werden:

* **Titel-Folienlayout**. Dieses Layout besteht aus zwei Textplatzhaltern. Ein Platzhalter ist für den Titel und der andere ist für den Untertitel.
* **Titel und Inhalt Layout**. Dieses Layout enthält einen relativ kleinen Platzhalter an der Oberseite für den Titel und einen größeren Platzhalter für den Kerninhalt (Diagramm, Absätze, Aufzählungsliste, nummerierte Liste, Bilder usw.).
* **Leeres Layout**. Dieses Layout weist keine Platzhalter auf, sodass Sie Elementen von Grund auf neu erstellen können.

Da eine Masterfolie die höchste hierarchische Folie ist, die Informationen über Folienlayouts speichert, können Sie die Masterfolie verwenden, um auf Folienlayouts zuzugreifen und Änderungen vorzunehmen. Ein Layout-Folie kann nach Typ oder Name abgerufen werden. Ebenso hat jede Folie eine eindeutige ID, die verwendet werden kann, um auf sie zuzugreifen.

Alternativ können Sie Änderungen direkt an einem bestimmten Folienlayout in einer Präsentation vornehmen.

* Um Ihnen die Arbeit mit Folienlayouts (einschließlich der in Masterfolien) zu ermöglichen, bietet Aspose.Slides Eigenschaften wie [get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) und [get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) in der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse an.
* Um verwandte Aufgaben auszuführen, bietet Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/) und viele andere Typen.

{{% alert title="Info" color="info" %}}

Für weitere Informationen zur Arbeit mit Master-Folien im Besonderen siehe den Artikel [Slide Master](https://docs.aspose.com/slides/cpp/slide-master/).

{{% /alert %}}

## **Folienlayout zur Präsentation hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die [MasterSlide-Sammlung](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/) zu.
1. Durchlaufen Sie die vorhandenen Layout-Folien, um zu bestätigen, dass die benötigte Layout-Folie bereits in der Layout-Folien-Sammlung vorhanden ist. Andernfalls fügen Sie die gewünschte Layout-Folie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layout-Folie hinzu.
1. Speichern Sie die Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie ein Folienlayout zu einer PowerPoint-Präsentation hinzufügen:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// Instanziiert eine Präsentationsklasse, die die Präsentationsdatei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	// Durchläuft die Layout-Folientypen
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();


	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// Die Situation, in der eine Präsentation einige Layout-Typen nicht enthält.
		// Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layout-Typen.
		// Aber Layout-Folien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,
		// wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese
		// Namen für die Auswahl des Layouts zu verwenden.
		// Sie können auch eine Reihe von Platzhalter-Formtypen verwenden. Zum Beispiel,
		// das Titel-Folienlayout sollte nur den Platzhaltertyp Titel haben usw.

		for (int i = 0; i<layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"Title"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
				}
			}
		}
	}

	// Fügt eine leere Folie mit dem hinzugefügten Layout-Folie hinzu  
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// Speichert die Präsentation auf der Festplatte
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Nicht verwendetes Layout-Folie entfernen**

Aspose.Slides bietet die [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) Methode aus der [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) Klasse, um Ihnen das Löschen unerwünschter und ungenutzter Layout-Folien zu ermöglichen. Dieser C++-Code zeigt Ihnen, wie Sie eine Layout-Folie aus einer PowerPoint-Präsentation entfernen:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```


## **Größe und Typ für Folienlayout festlegen**

Um Ihnen zu ermöglichen, Größe und Typ für eine bestimmte Layout-Folie festzulegen, bietet Aspose.Slides die Eigenschaften [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) und [get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/) (aus der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse). Dieser C++-Code zeigt die Operation:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// Greift auf Folie durch ID aus der Sammlung zu
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// Legt die Foliengröße für die generierte Präsentation auf die der Quelle fest
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// Speichert die Präsentation auf der Festplatte
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Fußzeilenanzeige innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich den Verweis auf eine Folie über ihren Index.
1. Stellen Sie den Fußzeilenplatzhalter der Folie auf sichtbar.
1. Stellen Sie den Datum-Zeit-Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie die Sichtbarkeit für eine Folienfußzeile festlegen (und damit verbundene Aufgaben ausführen):

```c++
 // Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instanziiert eine Klasse für die Folienkollektion
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // Die Eigenschaft IsFooterVisible wird verwendet, um anzugeben, dass ein Platzhalter für die Folienfußzeile fehlt
{
	headerFooterManager->SetFooterVisibility(true); // Die Methode SetFooterVisibility wird verwendet, um einen Platzhalter für die Folienfußzeile sichtbar zu machen
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // Die Eigenschaft IsSlideNumberVisible wird verwendet, um anzugeben, dass ein Platzhalter für die Foliennummer fehlt
{
	headerFooterManager->SetSlideNumberVisibility(true); // Die Methode SetSlideNumberVisibility wird verwendet, um einen Platzhalter für die Foliennummer sichtbar zu machen
}
if (!headerFooterManager->get_IsDateTimeVisible()) // Die Eigenschaft IsDateTimeVisible wird verwendet, um anzugeben, dass ein Platzhalter für Datum und Uhrzeit fehlt
{
	headerFooterManager->SetDateTimeVisibility(true); // Die Methode SetFooterVisibility wird verwendet, um einen Platzhalter für Datum und Uhrzeit sichtbar zu machen
}
headerFooterManager->SetFooterText(u"Fußzeilentext"); // Die Methode SetFooterText wird verwendet, um einen Text für einen Platzhalter der Folienfußzeile festzulegen
headerFooterManager->SetDateTimeText(u"Datum und Uhrzeit Text"); // Die Methode SetDateTimeText wird verwendet, um einen Text für einen Platzhalter von Datum und Uhrzeit festzulegen.


// Speichert die Präsentation auf der Festplatte
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Fußzeilenanzeige für Kinder innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf die Masterfolie über ihren Index.
1. Stellen Sie die Masterfolie und alle Platzhalter für Fußzeilen auf sichtbar.
1. Setzen Sie einen Text für die Masterfolie und alle Platzhalter für Fußzeilen.
1. Setzen Sie einen Text für die Masterfolie und alle Platzhalter für Datum und Uhrzeit.
1. Speichern Sie die Präsentation.

Dieser C++-Code demonstriert die Operation:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instanziiert eine Klasse für die Folienkollektion
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // Die Methode SetFooterAndChildFootersVisibility wird verwendet, um die Masterfolie und alle Platzhalter für Fußzeilen sichtbar zu machen
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // Die Methode SetSlideNumberAndChildSlideNumbersVisibility wird verwendet, um die Masterfolie und alle Platzhalter für Foliennummern sichtbar zu machen
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // Die Methode SetDateTimeAndChildDateTimesVisibility wird verwendet, um eine Masterfolie und alle Platzhalter für Datum und Uhrzeit sichtbar zu machen

headerFooterManager->SetFooterAndChildFootersText(u"Fußzeilentext"); // Die Methode SetFooterAndChildFootersText wird verwendet, um Texte für die Masterfolie und alle Platzhalter für Fußzeilen festzulegen
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Datum und Uhrzeit Text"); // Die Methode SetDateTimeAndChildDateTimesText wird verwendet, um Texte für die Masterfolie und alle Platzhalter für Datum und Uhrzeit festzulegen

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Foliengröße im Hinblick auf Inhaltsmaßstab festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die die Folie enthält, deren Größe Sie festlegen möchten.
1. Erstellen Sie eine weitere Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, um eine neue Präsentation zu erstellen.
1. Holen Sie sich den Verweis auf die Folie (aus der ersten Präsentation) über ihren Index.
1. Stellen Sie den Platzhalter für die Fußzeile der Folie auf sichtbar.
1. Stellen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar.
1. Speichern Sie die Präsentation.

Dieser C++-Code zeigt die Operation:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// Instanziiert eine Klasse für die Folienkollektion
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// Legt die Foliengröße für die generierten Präsentationen auf die der Quelle fest
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // Methode SetSize wird verwendet, um die Foliengröße mit Maßstab-Inhalt zu setzen, um sicherzustellen, dass es passt
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // Methode SetSize wird verwendet, um die Foliengröße mit Maximalgröße des Inhalts zu setzen

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// Speichert die Präsentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Seitengröße beim Generieren von PDF festlegen**

Bestimmte Präsentationen (wie Poster) werden häufig in PDF-Dokumente umgewandelt. Wenn Sie Ihre PowerPoint-Präsentation in PDF umwandeln möchten, um die besten Druck- und Zugänglichkeitsoptionen zu nutzen, möchten Sie Ihre Folien auf Größen festlegen, die für PDF-Dokumente geeignet sind (z. B. A4).

Aspose.Slides bietet die [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/) Klasse, um Ihnen zu ermöglichen, Ihre bevorzugten Einstellungen für Folien anzugeben. Dieser C++-Code zeigt Ihnen, wie Sie die Eigenschaft [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) (aus der `SlideSize` Klasse) verwenden, um eine bestimmte Papiergröße für die Folien in einer Präsentation festzulegen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
	SharedPtr<Presentation>pres = MakeObject<Presentation>();

	// Legt die Eigenschaft SlideSize.Type fest
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// Legt verschiedene Eigenschaften der PDF-Optionen fest
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```