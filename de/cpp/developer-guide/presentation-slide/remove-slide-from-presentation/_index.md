---
title: Folie aus der Präsentation entfernen
type: docs
weight: 30
url: /de/cpp/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, C++, Aspose.Slides"
description: "Entfernen Sie eine Folie aus PowerPoint nach Referenz oder Index in C++"

---

Wenn eine Folie (oder deren Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides bietet die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) kapselt, ein Repository für alle Folien in einer Präsentation. Mit Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie nach Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf die Folie, die Sie entfernen möchten, durch ihre ID oder ihren Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie eine Folie über ihre Referenz entfernen:

```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Greift auf eine Folie über ihren Index in der Folienkollektion zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Entfernt eine Folie über ihre Referenz
	pres->get_Slides()->Remove(slide);

	// Speichert die modifizierte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Folie nach Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Entfernen Sie die Folie aus der Präsentation durch ihre Indexposition.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie eine Folie über ihren Index entfernen:

```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Entfernt eine Folie über ihren Folienindex
	pres->get_Slides()->RemoveAt(0);

	// Speichert die modifizierte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Unused Layout Folie entfernen**

Aspose.Slides bietet die Methode [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (aus der [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) Klasse), um unerwünschte und ungenutzte Layoutfolien zu löschen. Dieser C++-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Unused Master Folie entfernen**

Aspose.Slides bietet die Methode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (aus der [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) Klasse), um unerwünschte und ungenutzte Masterfolien zu löschen. Dieser C++-Code zeigt Ihnen, wie Sie eine Masterfolie aus einer PowerPoint-Präsentation entfernen:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```