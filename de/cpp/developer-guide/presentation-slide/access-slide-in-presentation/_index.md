---
title: Zugriff auf Präsentationsfolien in C++
linktitle: Zugriff auf Folie
type: docs
weight: 20
url: /de/cpp/access-slide-in-presentation/
keywords:
- Zugriff auf Folie
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ zugreifen und verwalten können. Steigern Sie die Produktivität mit Codebeispielen."
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: nach Index und nach ID.

## **Zugriff auf eine Folie nach Index**

Alle Folien in einer Präsentation werden numerisch basierend auf ihrer Position beginnend bei 0 angeordnet. Die erste Folie ist über Index 0 erreichbar; die zweite Folie über Index 1; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als Sammlung von [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (Sammlung von [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) Objekten) bereit. Dieser C++-Code zeigt, wie Sie über den Index auf eine Folie zugreifen können: 
```c++
	// Der Pfad zum Dokumentverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instanziiert die Klasse Presentation.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Holt die Referenz einer Folie über ihren Index.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```


## **Zugriff auf eine Folie nach ID**

Jede Folie in einer Präsentation hat eine eindeutige zugehörige ID. Sie können die Methode [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) verwenden, um diese ID anzusprechen. Dieser C++-Code zeigt, wie Sie eine gültige Folien‑ID übergeben und über die Methode [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) auf diese Folie zugreifen:
```c++
	// Der Pfad zum Dokumentverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instanziert die Klasse Presentation.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Holt die Folien-ID.
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Greift über die Folien-ID auf die Folie zu.
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```


## **Folienposition ändern**

Aspose.Slides ermöglicht das Ändern der Position einer Folie. Zum Beispiel können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Holen Sie die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index
1. Setzen Sie eine neue Position für die Folie über die Eigenschaft [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/). 
1. Speichern Sie die geänderte Präsentation.

Dieser C++-Code demonstriert einen Vorgang, bei dem die Folie an Position 1 nach Position 2 verschoben wird:
```c++
	// Der Pfad zum Dokumentverzeichnis.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instanziert die Klasse Presentation.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Holt die Folie, deren Position geändert wird.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Setzt die neue Position für die Folie.
	slide->set_SlideNumber(2);

	// Speichert die geänderte Präsentation.
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Foliennummer festlegen**

Durch die Verwendung der Eigenschaft [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang führt dazu, dass die anderen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Holen Sie die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die geänderte Präsentation.

Dieser C++-Code demonstriert einen Vorgang, bei dem die erste Foliennummer auf 10 gesetzt wird: 
```c++
	// Der Pfad zum Dokumentverzeichnis.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instanziert die Klasse Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Holt die Foliennummer
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Setzt die Foliennummer
	pres->set_FirstSlideNumber(2);
	
	// Speichert die geänderte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) auf diese Weise:
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Setzt die Nummer für die erste Folie der Präsentation
presentation->set_FirstSlideNumber(0);

// Zeigt die Foliennummern für alle Folien an
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Blendet die Foliennummer für die erste Folie aus
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Speichert die geänderte Präsentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Entspricht die vom Benutzer gesehenen Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann mit einem beliebigen Wert beginnen (z. B. 10) und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indexierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indexierung berücksichtigt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge‑, Lösch‑ und Verschiebevorgängen neu berechnet.