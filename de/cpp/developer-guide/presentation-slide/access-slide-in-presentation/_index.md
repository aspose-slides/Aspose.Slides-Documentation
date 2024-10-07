---
title: Zugriff auf Folien in der Präsentation
type: docs
weight: 20
url: /cpp/access-slide-in-presentation/
keywords: "Zugriff PowerPoint Präsentation, Zugriff Folie, Folieneigenschaften bearbeiten, Folienposition ändern, Foliennummer, Index, ID, Position C++, CPP, Aspose.Slides"
description: "Zugriff auf PowerPoint-Folie nach Index, ID oder Position in C++. Folieneigenschaften bearbeiten"
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: nach Index und nach ID.

## **Zugriff auf Folie nach Index**

Alle Folien in einer Präsentation sind numerisch basierend auf der Folienposition angeordnet, beginnend bei 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 aufgerufen; usw.

Die Presentation-Klasse, die eine Präsentationsdatei repräsentiert, stellt alle Folien als [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) Objekten) bereit. Dieser C++-Code zeigt Ihnen, wie Sie auf eine Folie über ihren Index zugreifen können:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instanziiert die Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Erhält eine Referenz auf eine Folie über ihren Index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Zugriff auf Folie nach ID**

Jede Folie in einer Präsentation hat eine eindeutige ID, die ihr zugeordnet ist. Sie können die [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) Methode (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse) verwenden, um diese ID anzusprechen. Dieser C++-Code zeigt Ihnen, wie Sie eine gültige Folien-ID bereitstellen und auf diese Folie über die [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) Methode zugreifen:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instanziiert die Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Erhält eine Folien-ID
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Greift auf die Folie über ihre ID zu
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Folienposition ändern**

Aspose.Slides ermöglicht es Ihnen, die Folienposition zu ändern. Zum Beispiel können Sie angeben, dass die erste Folie die zweite Folie werden soll.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index.
1. Setzen Sie eine neue Position für die Folie über die [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/) Eigenschaft.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code demonstriert eine Operation, in der die Folie in Position 1 auf Position 2 verschoben wird:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instanziiert die Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Erhält die Folie, deren Position geändert wird
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Setzt die neue Position für die Folie
	slide->set_SlideNumber(2);

	// Speichert die modifizierte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden andere Folien automatisch angepasst.

## **Foliennummer festlegen**

Mit der [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) Eigenschaft (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse) können Sie eine neue Nummer für die erste Folie in einer Präsentation angeben. Diese Operation führt dazu, dass andere Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instanziiert die Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Erhält die Foliennummer
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Setzt die Foliennummer
	pres->set_FirstSlideNumber(2);
	
	// Speichert die modifizierte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung von der zweiten Folie aus starten (und die Nummerierung für die erste Folie ausblenden), so:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Setzt die Nummer für die erste Präsentationsfolie
presentation->set_FirstSlideNumber(0);

// Zeigt die Foliennummern für alle Folien an
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Blendet die Foliennummer für die erste Folie aus
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Speichert die modifizierte Präsentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```