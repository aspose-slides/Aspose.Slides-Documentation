---
title: Folien aus Präsentationen in C++ entfernen
linktitle: Folien entfernen
type: docs
weight: 30
url: /de/cpp/remove-slide-from-presentation/
keywords:
- Folien entfernen
- Folien löschen
- Unbenutzte Folien entfernen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Mühelos Folien aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ entfernen. Erhalten Sie klare Codebeispiele und steigern Sie Ihren Workflow."
---

Wenn eine Folie (oder ihr Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides stellt die Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) bereit, die die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) kapselt und ein Repository für alle Folien in einer Präsentation ist. Durch die Verwendung von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)‑Objekt können Sie die zu entfernende Folie angeben. 

## **Entfernen einer Folie per Referenz**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Folie, die Sie entfernen möchten, über deren ID oder Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die geänderte Präsentation. 

Dieser C++‑Code zeigt, wie Sie eine Folie über ihre Referenz entfernen: 
```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Greift über den Index in der Folien-Sammlung auf eine Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Entfernt eine Folie über ihre Referenz
	pres->get_Slides()->Remove(slide);

	// Speichert die geänderte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Entfernen einer Folie per Index**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.
1. Speichern Sie die geänderte Präsentation. 

Dieser C++‑Code zeigt, wie Sie eine Folie über ihren Index entfernen: 
```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Entfernt eine Folie über ihren Folienindex
	pres->get_Slides()->RemoveAt(0);

	// Speichert die geänderte Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Entfernen ungenutzter Layout‑Folien**

Aspose.Slides stellt die Methode [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (aus der Klasse [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) bereit, mit der Sie unerwünschte und ungenutzte Layout‑Folien löschen können. Dieser C++‑Code zeigt, wie Sie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernen:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **Entfernen ungenutzter Master‑Folien**

Aspose.Slides stellt die Methode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (aus der Klasse [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) bereit, mit der Sie unerwünschte und ungenutzte Master‑Folien löschen können. Dieser C++‑Code zeigt, wie Sie eine Master‑Folie aus einer PowerPoint‑Präsentation entfernen:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Was passiert mit den Folien‑Indizes, nachdem ich eine Folie gelöscht habe?**

Nach dem Löschen indexiert die [collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) neu: Jede nachfolgende Folie rückt um eine Position nach links, sodass frühere Index‑Nummern veraltet sind. Wenn Sie eine stabile Referenz benötigen, verwenden Sie die dauerhafte ID jeder Folie anstelle ihres Indexes.

**Unterscheidet sich die ID einer Folie vom Index, und ändert sie sich, wenn benachbarte Folien gelöscht werden?**

Ja. Der Index ist die Position der Folie und ändert sich, wenn Folien hinzugefügt oder entfernt werden. Die Folien‑ID ist ein permanenter Bezeichner und ändert sich nicht, wenn andere Folien gelöscht werden.

**Wie wirkt sich das Löschen einer Folie auf Folienabschnitte aus?**

Wenn die Folie zu einem Abschnitt gehörte, enthält dieser Abschnitt einfach eine Folie weniger. Die Abschnittsstruktur bleibt erhalten; wird ein Abschnitt leer, können Sie ihn nach Bedarf [remove or reorganize sections](/slides/de/cpp/slide-section/).

**Was passiert mit Notizen und Kommentaren, die an einer Folie angehängt sind, wenn sie gelöscht wird?**

[Notes](/slides/de/cpp/presentation-notes/) und [comments](/slides/de/cpp/presentation-comments/) sind an die jeweilige Folie gebunden und werden zusammen mit ihr entfernt. Inhalte anderer Folien bleiben unverändert.

**Wie unterscheidet sich das Löschen von Folien vom Aufräumen ungenutzter Layouts/Master?**

Beim Löschen werden bestimmte normale Folien aus der Präsentation entfernt. Das Aufräumen ungenutzter Layouts/Master entfernt Layout‑ oder Master‑Folien, auf die nichts verweist, wodurch die Dateigröße reduziert wird, ohne den Inhalt der verbleibenden Folien zu verändern. Diese Maßnahmen ergänzen sich: In der Regel zuerst löschen, dann aufräumen.